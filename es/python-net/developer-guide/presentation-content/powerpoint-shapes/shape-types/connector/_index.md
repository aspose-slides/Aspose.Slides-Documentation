---
title: Conector
type: docs
weight: 10
url: /es/python-net/connector/
keywords: "Conectar formas, conectores, formas de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Conectar formas de PowerPoint en Python"
---

Un conector de PowerPoint es una línea especial que conecta o enlaza dos formas y permanece adherido a las formas incluso cuando se mueven o se reubican en una diapositiva determinada.

Los conectores generalmente están conectados a *puntos de conexión* (puntos verdes), que existen en todas las formas por defecto. Los puntos de conexión aparecen cuando un cursor se acerca a ellos.

Los *puntos de ajuste* (puntos naranjas), que existen solo en ciertos conectores, se utilizan para modificar las posiciones y formas de los conectores.

## **Tipos de Conectores**

En PowerPoint, puedes usar conectores rectos, de codo (angulados) y curvados.

Aspose.Slides proporciona estos conectores:

| Conector                       | Imagen                                                        | Número de puntos de ajuste |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.LINE`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Conectar Formas Usando Conectores**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva usando el método `add_auto_shape` expuesto por el objeto `Shapes`.
1. Agrega un conector utilizando el método `add_auto_shape` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector.
1. Llama al método `reroute` para aplicar la ruta de conexión más corta.
1. Guarda la presentación.

Este código Python muestra cómo agregar un conector (un conector doblado) entre dos formas (una elipse y un rectángulo):

```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo PPTX
with slides.Presentation() as input:
    # Accede a la colección de formas para una diapositiva específica
    shapes = input.slides[0].shapes

    # Agrega una autoforma de elipse
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Agrega una autoforma de rectángulo
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # Agrega una forma de conector a la colección de formas de la diapositiva
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Conecta las formas usando el conector
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Llama a reroute que establece la ruta automática más corta entre formas
    connector.reroute()

    # Guarda la presentación
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)

```

{{%  alert title="NOTA"  color="warning"   %}} 

El método `connector.reroute` redirige un conector y lo obliga a tomar la ruta más corta posible entre formas. Para lograr su objetivo, el método puede cambiar los índices de los puntos `start_shape_connection_site_index` y `end_shape_connection_site_index`. 

{{% /alert %}} 

## **Especificar Punto de Conexión**

Si deseas que un conector enlace dos formas usando puntos específicos sobre las formas, debes especificar tus puntos de conexión preferidos de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva usando el método `add_auto_shape` expuesto por el objeto `Shapes`.
1. Agrega un conector usando el método `add_connector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector.
1. Establece tus puntos de conexión preferidos sobre las formas.
1. Guarda la presentación.

Este código Python demuestra una operación donde se especifica un punto de conexión preferido:

```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo PPTX
with slides.Presentation() as presentation:
    # Accede a la colección de formas para una diapositiva específica
    shapes = presentation.slides[0].shapes

    # Agrega una forma de conector a la colección de formas de la diapositiva
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Agrega una autoforma de elipse
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Agrega una autoforma de rectángulo
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # Conecta las formas usando el conector
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Establece el índice del punto de conexión preferido sobre la forma elipse
    wantedIndex = 6

    # Verifica si el índice preferido es menor que el conteo máximo de índices de sitio
    if ellipse.connection_site_count > wantedIndex:
        # Establece el punto de conexión preferido sobre la autoforma elipse
        connector.start_shape_connection_site_index = wantedIndex

    # Guarda la presentación
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Ajustar Punto del Conector**

Puedes ajustar un conector existente a través de sus puntos de ajuste. Solo los conectores con puntos de ajuste pueden ser alterados de esta manera. Consulta la tabla en **[Tipos de conectores.](/slides/es/python-net/connector/#types-of-connectors)** 

#### **Caso Simple**

Considera un caso donde un conector entre dos formas (A y B) pasa a través de una tercera forma (C):

![connector-obstruction](connector-obstruction.png)

Código:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

Para evitar o eludir la tercera forma, podemos ajustar el conector moviendo su línea vertical hacia la izquierda de esta manera:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **Casos Complejos** 

Para realizar ajustes más complicados, debes tener en cuenta las siguientes cosas:

* Un punto ajustable de un conector está estrechamente relacionado con una fórmula que calcula y determina su posición. Por lo tanto, los cambios en la ubicación del punto pueden alterar la forma del conector.
* Los puntos de ajuste de un conector están definidos en un estricto orden en un arreglo. Los puntos de ajuste están numerados desde el punto de inicio de un conector hasta su fin.
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/altura de la forma del conector. 
  * La forma está limitada por los puntos de inicio y fin del conector multiplicados por 1000. 
  * El primer punto, el segundo punto y el tercer punto definen el porcentaje del ancho, el porcentaje de la altura, y el porcentaje del ancho (nuevamente), respectivamente.
* Para cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debes tener en cuenta la rotación del conector y su reflexión. **Nota** que el ángulo de rotación para todos los conectores mostrados bajo **[Tipos de conectores](/slides/es/python-net/connector/#types-of-connectors)** es 0.

#### **Caso 1**

Considera un caso donde dos objetos de marco de texto están enlazados entre sí a través de un conector:

![connector-shape-complex](connector-shape-complex.png)

Código:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase de presentación que representa un archivo PPTX
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva en la presentación
    sld = pres.slides[0]
    # Agrega formas que se unirán a través de un conector
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "Desde"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "A"
    # Agrega un conector
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Especifica la dirección del conector
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Especifica el color del conector
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Especifica el grosor de la línea del conector
    connector.line_format.width = 3

    # Une las formas con el conector
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connection_site_index = 2

    # Obtiene los puntos de ajuste para el conector
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**Ajuste**

Podemos cambiar los valores de los puntos de ajuste del conector aumentando el porcentaje correspondiente del ancho y la altura en un 20% y 200%, respectivamente:

```python
    # Cambia los valores de los puntos de ajuste
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

El resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de las partes individuales del conector, vamos a crear una forma que corresponda al componente horizontal del conector en el punto connector.adjustments[0]:

```python
    # Dibuja el componente vertical del conector

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

El resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

En **Caso 1**, demostramos una operación simple de ajuste de conector usando principios básicos. En situaciones normales, debes tener en cuenta la rotación del conector y su visualización (que están establecidas por connector.rotation, connector.frame.flip_h y connector.frame.flip_v). Ahora vamos a demostrar el proceso.

Primero, añadamos un nuevo objeto de marco de texto (**A 1**) a la diapositiva (con propósitos de conexión) y creamos un nuevo conector (verde) que lo conecta a los objetos que ya creamos.

```python
    # Crea un nuevo objeto de unión
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "A 1"
    # Crea un nuevo conector
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # Conecta objetos usando el nuevo conector creado
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connection_site_index = 3
    # Obtiene los puntos de ajuste del conector
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # Cambia los valores de los puntos de ajuste 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

El resultado:

![connector-adjusted-3](connector-adjusted-3.png)

En segundo lugar, crear una forma que corresponderá al componente horizonal del conector que pasa a través del punto de ajuste connector.adjustments[0]. Usaremos los valores de los datos del conector para connector.rotation, connector.frame.flip_h y connector.frame.flip_v y aplicaremos la popular fórmula de conversión de coordenadas para rotación alrededor de un punto dado x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

En nuestro caso, el ángulo del objeto es de 90 grados y el conector se muestra verticalmente, así que este es el código correspondiente:

```python
    # Guarda las coordenadas del conector
    x = connector.x
    y = connector.y
    # Corrige las coordenadas del conector en caso de que aparezca
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Toma el valor del punto de ajuste como coordenada
    x += connector.width * adjValue_0.raw_value / 100000
    
    #  Convierte las coordenadas ya que Sin(90) = 1 y Cos(90) = 0
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determina el ancho del componente horizontal usando el segundo valor del punto de ajuste
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

El resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demostramos cálculos que involucran ajustes simples y puntos de ajuste complicados (puntos de ajuste con ángulos de rotación). Usando el conocimiento adquirido, puedes desarrollar tu propio modelo (o escribir un código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste de un conector en función de coordenadas específicas de la diapositiva.

## **Encontrar Ángulo de Líneas de Conector**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Accede a la forma de línea del conector.
1. Usa la anchura de la línea, altura, altura del marco de la forma y anchura del marco de la forma para calcular el ángulo.

Este código Python demuestra una operación en la que calculamos el ángulo para una forma de línea de conector:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.Height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)

```