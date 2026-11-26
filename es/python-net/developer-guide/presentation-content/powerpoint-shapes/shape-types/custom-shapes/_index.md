---
title: Personalizar formas de presentación en Python
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/python-net/custom-shape/
keywords:
- forma personalizada
- añadir forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- añadir punto
- eliminar punto
- operación de edición
- esquina curvada
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crea y personaliza formas en presentaciones PowerPoint con Aspose.Slides para Python vía .NET: rutas de geometría, esquinas curvadas, formas compuestas."
---
## **Descripción general**

Este artículo explica cómo personalizar formas de presentación en Aspose.Slides editando la geometría de la forma mediante puntos de edición y rutas de geometría. Muestra cómo trabajar con [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) para modificar formas existentes, realizar operaciones básicas de edición de rutas, añadir o eliminar puntos y aplicar la geometría actualizada a una forma.

También demuestra cómo crear formas personalizadas y compuestas, construir formas con esquinas curvadas, determinar si la geometría de una forma está cerrada y extraer los elementos de la forma para el análisis de contorno.

## **Cambiar una forma usando puntos de edición**

En PowerPoint, puedes usar **Puntos de edición** para modificar un cuadrado:

* Mover una esquina hacia dentro o fuera.
* Ajustar la curvatura en un punto.
* Añadir nuevos puntos.

Editar puntos te permite modificar el contorno de una forma o usar una forma existente como base para una nueva.

## **Consejos para la edición de formas**

![overview_image](custom_shape_0.png)

Al editar formas de PowerPoint, ten en cuenta estos conceptos:

* Una forma (o su ruta) puede estar cerrada o abierta.
* La ruta de una forma está compuesta por puntos de anclaje conectados por segmentos.
* Un segmento puede ser recto o curvo. Los puntos de anclaje y los manejadores de control determinan su forma.
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * En un punto de esquina, los segmentos adyacentes pueden encontrarse en un ángulo.
  * En un punto suave, los dos manejadores de control están alineados y a la misma distancia del punto de anclaje.
  * En un punto recto, los dos manejadores de control están alineados pero pueden estar a diferentes distancias del punto de anclaje.
* Mover los puntos de anclaje o ajustar sus manejadores cambia el contorno de la forma.

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) representa una ruta de geometría del objeto [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Para obtener el [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) del objeto [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), puedes usar el método [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Para establecer el [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) de una forma, puedes usar estos métodos: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) para formas con una sola ruta y [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) para formas con varias rutas.
* Para añadir segmentos, puedes usar los métodos bajo [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Usando las propiedades [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) y [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), puedes establecer la apariencia de una ruta de geometría.
* Usando la propiedad [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), puedes obtener la ruta de geometría de un [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) como una matriz de segmentos de ruta.

## **Operaciones de edición simples**

Utiliza los siguientes métodos para editar una ruta de geometría. Las sobrecargas que aceptan un índice insertan un segmento en esa posición basada en cero dentro de la matriz de segmentos de la ruta.

| Operation | Method |
| --- | --- |
| Añadir o insertar una línea recta. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Añadir o insertar una curva Bézier cúbica con dos puntos de control y un punto final. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Añadir o insertar una curva Bézier cuadrática con un punto de control y un punto final. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Añadir un arco elíptico con las dimensiones y ángulos especificados en grados. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Cerrar la figura actual conectando su punto final con su punto de inicio. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Establecer el punto de inicio de una figura. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Eliminar un segmento en un índice basado en cero. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Añadir puntos personalizados a una forma**

Este ejemplo inserta dos puntos en una forma rectangular usando [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) y aplica la ruta editada con [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Las coordenadas son locales a la forma: ambos puntos nuevos están en su centro, a 100 puntos del lado izquierdo y 50 puntos de la parte superior. Los índices de segmento 1 y 4 los sitúan en los bordes superior e inferior, tirando esos bordes hacia adentro.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Eliminar puntos de una forma**

Este ejemplo modifica el contorno de una forma con forma de corazón eliminando el segmento en el índice basado en cero 2 con [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Aplicar la ruta modificada con [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) actualiza el contorno de la forma.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Crear una forma personalizada**

Este ejemplo construye una estrella de cinco puntas con [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Los radios exterior e interior alternados de 100 y 50 puntos definen las puntas y las hendiduras; un paso de 72 grados distribuye las cinco puntas uniformemente. La ruta se cierra con [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) y se aplica a una forma rectangular usando [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), sustituyendo su contorno.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Crear una forma personalizada compuesta**

Este ejemplo define dos objetos [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) cerrados para el tercio superior e inferior de una forma. Aplicar ambas rutas con [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) crea una única forma compuesta con una apertura en el tercio medio.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Crear una forma personalizada con esquinas curvadas**

Este ejemplo combina segmentos rectos con [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) para crear una forma con esquinas curvadas hacia adentro. Cada tamaño de esquina establece el ancho y alto del arco en puntos, y el barrido de -90 grados dibuja un cuarto de elipse en sentido contrario a las agujas del reloj. La ruta completada se aplica con [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), y la presentación se guarda en formato PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Descubrir si la geometría de una forma está cerrada**

El siguiente asistente comprueba si cada ruta de geometría no vacía termina con un segmento de cierre. Lee [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) y compara el comando del segmento final [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) con [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Devuelve false cuando no hay rutas no vacías. Esto verifica el comando final de cada ruta; no inspecciona cada subfigura dentro de una ruta. El ejemplo imprime `True` para un rectángulo.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Inspeccionar comandos de ruta de geometría**

Descarga [contour.pptx](contour.pptx) y colócalo en tu directorio de trabajo. La primera forma de la primera diapositiva tiene un borde superior recto, una curva Bézier cúbica y un borde de cierre recto. Usa [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) para leer sus rutas. Para cada ruta, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) enumera los segmentos en orden de dibujo. El [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) de cada segmento determina cómo interpretar su [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

La forma está ubicada en (200, 100) puntos en la diapositiva. Las coordenadas informadas son locales a la forma. Su esquina superior izquierda es (0, 0), x aumenta hacia la derecha e y aumenta hacia abajo. El segmento de cierre vuelve al punto de inicio sin coordenadas adicionales.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![Forma de PowerPoint con un borde superior recto, un borde curvo de la esquina superior derecha a la inferior izquierda y un borde izquierdo recto](contour.png)

## **Extraer e inspeccionar elementos de forma**

Usa [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) para inspeccionar una forma existente como elementos que contienen puntos de ruta y tipos de punto. Cada [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) devuelto expone sus matrices [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) y [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Esta representación es útil para el análisis de contorno o para pasar la geometría a herramientas de dibujo personalizadas.

El ejemplo abre una presentación, encuentra la primera forma de geometría directamente en la primera diapositiva y muestra sus segmentos de ruta. Usa una presentación que contenga una forma con segmentos rectos y curvos para ver ambos tipos de salida. No busca dentro de grupos.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Mantener el tipo de segmento, excluyendo banderas.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consumir ambos puntos de control y el punto final.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Las matrices corresponden por índice: `points[i]` es un punto y `types[i]` describe su función. El tipo `0` inicia una figura, y el tipo `1` dibuja una línea desde el punto anterior al punto actual. Un segmento Bézier cúbico comienza en el extremo anterior y utiliza tres entradas consecutivas de tipo `3`: dos puntos de control seguidos del nuevo extremo. El bucle consume estas tres entradas juntas y verifica el extremo para el cierre.

Los tipos de punto también contienen banderas. Aplica una máscara con `0x07` para identificar el tipo de segmento, y prueba `0x80` por separado para detectar un subtrazo cerrado. Por ejemplo, `129` (`0x81`) significa un extremo de línea que cierra un subtrazo, y `131` (`0x83`) significa un extremo Bézier que cierra uno. Comparar el valor bruto solo con `1` o `3` perdería estos casos. Otras banderas, como guión (`0x10`) y marcador (`0x20`), no cambian el tipo de segmento base.

**Coordenadas y transformaciones.** Los puntos se miden en puntos (1/72 pulgada), con X aumentando hacia la derecha e Y aumentando hacia abajo. Para una forma sin agrupar, las coordenadas extraídas ya incluyen su posición [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) y [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) y reflejan su ancho y altura actuales. Por ejemplo, un rectángulo sin rotar en `(100, 200)` con tamaño `120 × 80` tiene límites de contorno `(100, 200)`–`(220, 280)`. No añadas de nuevo la posición de la forma. Resta su X e Y para obtener coordenadas relativas a su marco sin rotar.

Los puntos extraídos no aplican la [rotación](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) de la forma ni los giros horizontales y verticales. Para reproducir el contorno mostrado, aplica esas transformaciones alrededor del centro de la forma. Para formas agrupadas, también ten en cuenta el mapeo de coordenadas del grupo y sus transformaciones; no asumas que los puntos extraídos son las coordenadas finales renderizadas en la diapositiva ni apliques una traslación o escala dos veces si ya está reflejada en el marco del hijo.

**Inspección frente a edición.** Las matrices extraídas describen el contorno; cambiarlas no actualiza la forma original. Elige este enfoque cuando tu análisis o código de dibujo necesite matrices de punto/tipo. Usa [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) cuando necesites comandos de geometría en el sistema de coordenadas local de la forma o quieras editar su geometría. Aplica rutas editadas mediante [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) o [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **Preguntas frecuentes**

**¿Qué pasará al relleno y al contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo el contorno cambia. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utiliza la propiedad [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) de la forma; la geometría rota con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para "bloquear" el resultado?**

Sí. Exporta el área de la [diapositiva](/slides/es/python-net/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/python-net/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.