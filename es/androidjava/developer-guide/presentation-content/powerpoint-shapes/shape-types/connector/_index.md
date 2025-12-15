---
title: Gestionar conectores en presentaciones en Android
linktitle: Conector
type: docs
weight: 10
url: /es/androidjava/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo del conector
- conectar formas
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Empodere aplicaciones Java para dibujar, conectar y auto-rutar líneas en diapositivas PowerPoint en Android—obtenga control total sobre conectores rectos, en codo y curvos."
---

Un conector de PowerPoint es una línea especial que une o enlaza dos formas y permanece adherida a las formas incluso cuando se mueven o reposicionan en una diapositiva determinada. 

Los conectores suelen estar vinculados a *puntos de conexión* (puntos verdes), que existen en todas las formas por defecto. Los puntos de conexión aparecen cuando el cursor se acerca a ellos.

*Puntos de ajuste* (puntos naranjas), que existen solo en ciertos conectores, se usan para modificar la posición y la forma de los conectores.

## **Tipos de conectores**

En PowerPoint, puedes usar conectores rectos, en codo (angulados) y curvos. 

Aspose.Slides proporciona estos conectores:

| Conector                      | Imagen                                                        | Número de puntos de ajuste |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Conectar formas mediante conectores**

1. Crea una instancia de la clase [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Añade dos [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.
1. Añade un conector mediante el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector. 
1. Llama al método `reroute` para aplicar la ruta de conexión más corta.
1. Guarda la presentación. 

Este código Java muestra cómo añadir un conector (un conector doblado) entre dos formas (una elipse y un rectángulo):
```Java
// Instancia una clase de presentación que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la colección de formas de una diapositiva específica
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Agrega una autoshape de elipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Agrega una autoshape de rectángulo
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Agrega una forma de conector a la colección de formas de la diapositiva
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Conecta las formas usando el conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Llama a reroute que establece la ruta automática más corta entre las formas
    connector.reroute();
    
    // Guarda la presentación
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

El método `Connector.reroute` vuelve a enrutar un conector y lo obliga a tomar la ruta más corta posible entre las formas. Para lograr su objetivo, el método puede cambiar los puntos `setStartShapeConnectionSiteIndex` y `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar un punto de conexión**

Si deseas que un conector enlace dos formas usando puntos específicos en las formas, debes especificar tus puntos de conexión preferidos de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Añade dos [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.
1. Añade un conector mediante el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector. 
1. Establece tus puntos de conexión preferidos en las formas. 
1. Guarda la presentación.

Este código Java demuestra una operación donde se especifica un punto de conexión preferido:
```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la colección de formas de una diapositiva específica
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Agrega una autoshape de elipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Agrega una autoshape de rectángulo
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Añade una forma de conector a la colección de formas de la diapositiva
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Conecta las formas usando el conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Establece el índice del punto de conexión preferido en la forma Elipse
    int wantedIndex = 6;

    // Comprueba si el índice preferido es menor que el recuento máximo de índices de sitio
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Establece el punto de conexión preferido en la autoshape Elipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Guarda la presentación
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajustar un punto del conector**

Puedes ajustar un conector existente a través de sus puntos de ajuste. Solo los conectores con puntos de ajuste pueden modificarse de esta manera. Consulta la tabla bajo **[Tipos de conectores.](/slides/es/androidjava/connector/#types-of-connectors)**

### **Caso simple**

Considera un caso donde un conector entre dos formas (A y B) pasa por una tercera forma (C):

![connector-obstruction](connector-obstruction.png)
```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```


Para evitar o eludir la tercera forma, podemos ajustar el conector moviendo su línea vertical hacia la izquierda de esta forma:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Casos complejos** 

Para realizar ajustes más complicados, debes tener en cuenta lo siguiente:

* El punto ajustable de un conector está estrechamente vinculado a una fórmula que calcula y determina su posición. Por lo tanto, los cambios en la ubicación del punto pueden alterar la forma del conector.
* Los puntos de ajuste de un conector se definen en un orden estricto en una matriz. Los puntos de ajuste se numeran desde el punto de inicio del conector hasta su fin.
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/alto de la forma del conector. 
  * La forma está limitada por los puntos de inicio y fin del conector multiplicados por 1000. 
  * El primer punto, segundo punto y tercer punto definen respectivamente el porcentaje del ancho, el porcentaje del alto y nuevamente el porcentaje del ancho.
* Para los cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debes considerar la rotación del conector y su reflexión. **Nota** que el ángulo de rotación para todos los conectores mostrados bajo **[Tipos de conectores](/slides/es/androidjava/connector/#types-of-connectors)** es 0.

#### **Caso 1**

Considera un caso donde dos objetos de marco de texto están vinculados mediante un conector:

![connector-shape-complex](connector-shape-complex.png)
```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    ISlide sld = pres.getSlides().get_Item(0);
    // Añade formas que se unirán mediante un conector
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Añade un conector
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Especifica la dirección del conector
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Especifica el color del conector
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Especifica el grosor de la línea del conector
    connector.getLineFormat().setWidth(3);
    
    // Vincula las formas con el conector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Obtiene los puntos de ajuste del conector
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**Ajuste**

Podemos cambiar los valores de los puntos de ajuste del conector incrementando el porcentaje correspondiente de ancho y alto en un 20 % y 200 %, respectivamente:
```java
// Cambia los valores de los puntos de ajuste
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


El resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de las partes individuales del conector, creemos una forma que corresponda al componente horizontal del conector en el punto `connector.getAdjustments().get_Item(0)`:
```java
// Dibuja el componente vertical del conector
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


El resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

En **Caso 1**, demostramos una operación simple de ajuste de conector usando principios básicos. En situaciones normales, debes considerar la rotación del conector y su visualización (que se establecen mediante `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()`). Ahora demostraremos el proceso.

Primero, añadamos un nuevo objeto de marco de texto (**To 1**) a la diapositiva (para fines de conexión) y creemos un nuevo conector (verde) que lo una con los objetos que ya creamos.
```java
// Crea un nuevo objeto de enlace
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Crea un nuevo conector
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Conecta objetos usando el conector recién creado
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Obtiene los puntos de ajuste del conector
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Cambia los valores de los puntos de ajuste
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


El resultado:

![connector-adjusted-3](connector-adjusted-3.png)

Segundo, creemos una forma que corresponda al componente horizontal del conector que pasa por el nuevo punto de ajuste `connector.getAdjustments().get_Item(0)`. Utilizaremos los valores de los datos del conector para `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()` y aplicaremos la conocida fórmula de conversión de coordenadas para rotación alrededor de un punto dado x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

En nuestro caso, el ángulo de rotación del objeto es 90 grados y el conector se muestra verticalmente, por lo que este es el código correspondiente:
```java
// Guarda las coordenadas del conector
x = connector.getX();
y = connector.getY();
// Corrige las coordenadas del conector en caso de que aparezca
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Toma el valor del punto de ajuste como coordenada
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Convierte las coordenadas ya que Sin(90) = 1 y Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Determina el ancho del componente horizontal usando el valor del segundo punto de ajuste
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


El resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demostramos cálculos que involucran ajustes simples y puntos de ajuste complicados (puntos de ajuste con ángulos de rotación). Con el conocimiento adquirido, puedes desarrollar tu propio modelo (o escribir código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste de un conector basándote en coordenadas específicas de la diapositiva.

## **Encontrar el ángulo de las líneas del conector**

1. Crea una instancia de la clase.
1. Obtén la referencia de una diapositiva a través de su índice.
1. Accede a la forma de línea del conector.
1. Usa el ancho, alto, altura del marco de la forma y ancho del marco de la forma para calcular el ángulo.

Este código Java demuestra una operación en la que calculamos el ángulo para una forma de línea de conector:
```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber si un conector puede “pegarse” a una forma específica?**

Comprueba que la forma exponga [puntos de conexión](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--). Si no hay ninguno o el recuento es cero, no es posible pegar; en ese caso, usa extremos libres y posiciónalos manualmente. Es aconsejable verificar el recuento de sitios antes de adjuntar.

**¿Qué ocurre con un conector si elimino una de las formas conectadas?**

Sus extremos se desacoplan; el conector permanece en la diapositiva como una línea ordinaria con inicio/final libres. Puedes eliminarlo o reasignar las conexiones y, si es necesario, [reroute](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/#reroute--).

**¿Se conservan los enlaces de los conectores al copiar una diapositiva a otra presentación?**

Generalmente sí, siempre que las formas objetivo también se copien. Si la diapositiva se inserta en otro archivo sin las formas conectadas, los extremos se vuelven libres y deberás volver a unirlos.