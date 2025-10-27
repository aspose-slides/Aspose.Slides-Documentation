---
title: Administrar conectores en presentaciones con Python
linktitle: Conector
type: docs
weight: 10
url: /es/python-net/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo de conector
- conectar formas
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Capacite a las aplicaciones Python para dibujar, conectar y enrutar automáticamente líneas en diapositivas PowerPoint y OpenDocument, obteniendo control total sobre conectores rectos, en codo y curvos."
---

## **Introducción**

Un conector de PowerPoint es una línea especializada que une dos formas y permanece adherida cuando las formas se mueven o reposicionan en una diapositiva. Los conectores se unen a **puntos de conexión** (puntos verdes) en las formas. Los puntos de conexión aparecen cuando el puntero se aproxima a ellos. **Mangos de ajuste** (puntos amarillos), disponibles en ciertos conectores, permiten modificar la posición y la forma del conector.

## **Tipos de Conector**

En PowerPoint, puedes usar tres tipos de conectores: recto, en codo (angular) y curvo.

Aspose.Slides admite los siguientes tipos de conectores:

| Tipo de Conector                | Imagen                                                    | Número de puntos de ajuste |
| --------------------------------| ----------------------------------------------------------| --------------------------- |
| `ShapeType.LINE`                | ![Conector de línea](shapetype-lineconnector.png)         | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Conector recto 1](shapetype-straightconnector1.png)     | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![Conector doblado 2](shapetype-bent-connector2.png)      | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![Conector doblado 3](shapetype-bentconnector3.png)       | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![Conector doblado 4](shapetype-bentconnector4.png)       | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![Conector doblado 5](shapetype-bentconnector5.png)       | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![Conector curvo 2](shapetype-curvedconnector2.png)       | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![Conector curvo 3](shapetype-curvedconnector3.png)       | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![Conector curvo 4](shapetype-curvedconnector4.png)       | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![Conector curvo 5](shapetype.curvedconnector5.png)       | 3                           |

## **Conectar formas con conectores**

Esta sección muestra cómo enlazar formas con conectores en Aspose.Slides. Añadirás un conector a una diapositiva y conectarás su extremo inicial y final a las formas objetivo. Utilizar puntos de conexión garantiza que el conector permanezca “pegado” a las formas aunque se muevan o cambien de tamaño.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtén una referencia a la diapositiva por su índice.  
3. Añade dos objetos [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva mediante el método `add_auto_shape` expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).  
4. Añade un conector usando el método `add_connector` expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) y especifica el tipo de conector.  
5. Conecta las formas con el conector.  
6. Llama al método `reroute` para aplicar la ruta de conexión más corta.  
7. Guarda la presentación.

El siguiente código Python muestra cómo añadir un conector doblado entre dos formas (una elipse y un rectángulo):

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Call reroute to set the shortest path.
    connector.reroute()

    # Save the presentation.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTA" color="warning" %}}

El método `connector.reroute` vuelve a enrutar un conector, obligándolo a tomar la ruta más corta posible entre formas. Para ello, el método puede cambiar los valores de `start_shape_connection_site_index` y `end_shape_connection_site_index`.

{{% /alert %}}

## **Especificar puntos de conexión**

Esta sección explica cómo adjuntar un conector a un punto de conexión específico en una forma dentro de Aspose.Slides. Al dirigirnos a sitios de conexión precisos, podemos controlar el enrutamiento y la disposición del conector, produciendo diagramas limpios y predecibles en nuestras presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtén una referencia a la diapositiva por su índice.  
3. Añade dos objetos [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva mediante el método `add_auto_shape` del objeto [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).  
4. Añade un conector usando el método `add_connector` del objeto [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) y especifica el tipo de conector.  
5. Conecta las formas con el conector.  
6. Define tus puntos de conexión preferidos en las formas.  
7. Guarda la presentación.

El siguiente código Python demuestra cómo especificar un punto de conexión preferido:

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide's shape collection.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Set the preferred connection site index on the ellipse.
    site_index = 6

    # Check that the preferred index is within the available site count.
    if  ellipse.connection_site_count > site_index:
        # Assign the preferred connection site on the ellipse AutoShape.
        connector.start_shape_connection_site_index = site_index

    # Save the presentation.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar puntos del conector**

Puedes modificar los conectores mediante sus puntos de ajuste. Solo los conectores que exponen puntos de ajuste pueden editarse de esta manera. Para obtener detalles sobre qué conectores admiten ajustes, consulta la tabla bajo [Tipos de Conector](/slides/es/python-net/connector/#connector-types).

### **Caso simple**

Considera un caso en el que un conector entre dos formas (A y B) intersecta una tercera forma (C):

![Obstrucción del conector](connector-obstruction.png)

Ejemplo de código:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Para evitar la tercera forma, ajusta el conector moviendo su segmento vertical a la izquierda:

![Obstrucción del conector corregida](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Casos complejos** 

Para ajustes más avanzados, considera lo siguiente:

- El punto ajustable de un conector está gobernado por una fórmula que determina su posición. Cambiar este punto puede alterar la forma global del conector.  
- Los puntos de ajuste de un conector se almacenan en un arreglo estrictamente ordenado, numerado desde el inicio del conector hasta su fin.  
- Los valores de los puntos de ajuste representan porcentajes del ancho/alto de la forma del conector.  
  - La forma está delimitada por los puntos de inicio y fin del conector y se escala por 1000.  
  - El primer, segundo y tercer punto de ajuste representan: porcentaje de ancho, porcentaje de alto y nuevamente porcentaje de ancho, respectivamente.  
- Al calcular las coordenadas de los puntos de ajuste, hay que tener en cuenta la rotación y el reflejo del conector. **Nota:** Para todos los conectores listados bajo [Tipos de Conector](/slides/es/python-net/connector/#connector-types), el ángulo de rotación es 0.

#### **Caso 1**

Considera un caso en el que dos objetos de marco de texto están enlazados con un conector:

![Formas enlazadas](connector-shape-complex.png)

Ejemplo de código:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Get the first slide.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Add a connector.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Set the connector's direction.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Set the connector's color.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Set the connector's line thickness.
    connector.line_format.width = 3

    # Link the shapes with the connector.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Get the connector's adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Ajuste**

Cambia los valores de los puntos de ajuste del conector incrementando el porcentaje de ancho en un 20 % y el porcentaje de alto en un 200 %:

```python
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

El resultado:

![Ajuste del conector 1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de los segmentos del conector, crea una forma que corresponda al componente vertical del conector en `connector.adjustments[0]`:

```python
    # Draw the vertical component of the connector.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

El resultado:

![Ajuste del conector 2](connector-adjusted-2.png)

#### **Caso 2**

En **Caso 1**, demostramos un ajuste simple del conector usando principios básicos. En escenarios típicos, debes considerar la rotación del conector y sus configuraciones de visualización (controladas por `connector.rotation`, `connector.frame.flip_h` y `connector.frame.flip_v`). A continuación el proceso.

Primero, añade un nuevo objeto de marco de texto (**To 1**) a la diapositiva (para la conexión) y crea un nuevo conector verde que lo enlace a los objetos existentes.

```python
    # Create a new target object.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Create a new connector.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Connect the objects using the newly created connector.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Get the connector adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

El resultado:

![Ajuste del conector 3](connector-adjusted-3.png)

Segundo, crea una forma que corresponda al **segmento horizontal** del conector que pasa por el nuevo punto de ajuste `connector.adjustments[0]`. Utiliza los valores de `connector.rotation`, `connector.frame.flip_h` y `connector.frame.flip_v`, y aplica la fórmula estándar de conversión de coordenadas para rotación alrededor de un punto `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

En nuestro caso, el ángulo de rotación del objeto es 90 ° y el conector se muestra verticalmente, por lo que el código correspondiente es:

```python
    # Save the connector coordinates.
    x = connector.x
    y = connector.y
    
    # Correct the connector coordinates if it is flipped.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Use the adjustment point value as the coordinate.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Convert the coordinates because sin(90°) = 1 and cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determine the width of the horizontal segment using the second adjustment point value.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

El resultado:

![Ajuste del conector 4](connector-adjusted-4.png)

Demostramos cálculos que involucran ajustes simples y puntos de ajuste más complejos (los que consideran rotación). Con este conocimiento, puedes desarrollar tu propio modelo — o escribir código — para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste del conector según coordenadas específicas de la diapositiva.

## **Encontrar ángulos de líneas de conector**

Utiliza el siguiente ejemplo para determinar el ángulo de las líneas de conector en una diapositiva con Aspose.Slides. Aprenderás a leer los extremos del conector y a calcular su orientación para alinear con precisión flechas, etiquetas y otras formas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtén una referencia a la diapositiva por índice.  
3. Accede a la forma de línea del conector.  
4. Utiliza el ancho y alto de la línea, y el ancho y alto del marco de la forma, para calcular el ángulo.

El siguiente código Python muestra cómo calcular el ángulo de una forma de línea de conector:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si un conector puede “pegarse” a una forma específica?**  
Comprueba que la forma exponga [sitios de conexión](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). Si no hay ninguno o el recuento es cero, no es posible pegar; en ese caso, usa extremos libres y posiciónalos manualmente. Es aconsejable verificar el recuento de sitios antes de adjuntar.

**¿Qué ocurre con un conector si elimino una de las formas conectadas?**  
Sus extremos se separarán; el conector permanecerá en la diapositiva como una línea ordinaria con inicio y fin libres. Puedes eliminarlo o volver a asignar las conexiones y, si es necesario, [volver a enrutar](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**¿Se conservan los enlaces de los conectores al copiar una diapositiva a otra presentación?**  
Generalmente sí, siempre que las formas objetivo también se copien. Si la diapositiva se inserta en otro archivo sin las formas conectadas, los extremos se vuelven libres y deberás volver a adjuntarlos.