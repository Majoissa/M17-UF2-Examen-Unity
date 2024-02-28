# Examen de Plataformas 2D en Unity

Este proyecto de Unity es un juego de plataformas 2D en el que he implementado varios elementos y funcionalidades siguiendo las especificaciones de las tareas asignadas.

## Características Implementadas

### Asignación de Sorting Layers
- **Player**: Se ha colocado en la capa 'Player' para asegurarse de que se renderiza por encima del terreno y el fondo.
- **Terrain**: Se ha asignado a la capa 'Default' y se utiliza como suelo para que el jugador camine sobre él.
- **Background**: Se ha colocado en la capa 'Background' para que se renderice detrás de todos los demás elementos.

### Animaciones del Jugador
- **Idle**: Animación por defecto que va del frame `idle_01` a `idle_06`.
- **Attack**: Secuencia de frames `attack_01`, `attack_02`, `attack_03`, `attack_02`, `attack_01` sin bucle.
- **Hurt**: Secuencia `hurt_01`, `hurt_02`, `hurt_01` que vuelve al estado idle al terminar.
- **Die**: Secuencia desde `die_001` a `die_010`, termina sin bucle y vuelve al estado idle.

Las animaciones se activan mediante las teclas asignadas en el Inspector de Unity, que se pueden configurar para cada acción.

### Control del Jugador
- El jugador puede mirar hacia la izquierda o derecha utilizando el eje horizontal del input.
- Se utiliza `transform.scale` para girar el sprite del personaje.

### Función de Teletransporte
- El jugador se teletransporta una distancia definida en `dist_x` y `dist_y` cuando la animación de ataque está entre `attack_03` y `attack_02`.
- Se visualiza una línea en el editor desde el jugador hasta el destino de la teletransportación utilizando `OnDrawGizmos`.

### Código de Buenas Prácticas
- Se han utilizado modificadores `private` en las variables de los scripts siempre que ha sido posible.
- Se han definido dos `Header` en el script del jugador para organizar las variables de las animaciones y las de teletransporte.

### Implementación de Clases de Personajes
- Se ha creado una clase base `Character` con propiedades como `health` y `speed`, y métodos para mover al personaje, recibir daño y manejar la muerte.
- Se ha implementado una clase `Wizard` que extiende `Character`, con una propiedad adicional de `protection`. El método `TakeDamage` ha sido sobreescrito para usar primero la `protection` y luego la `health`.

## Scripts
Los scripts principales incluyen `PlayerController` y `Wizard`, que manejan la lógica del personaje y las interacciones en el juego.

## Cómo Jugar
- Usa las teclas Alpha1, Alpha2, y Alpha3 para activar las animaciones de Hurt, Die y Attack respectivamente.
- Presiona las teclas de flecha izquierda y derecha para cambiar la dirección del personaje.

