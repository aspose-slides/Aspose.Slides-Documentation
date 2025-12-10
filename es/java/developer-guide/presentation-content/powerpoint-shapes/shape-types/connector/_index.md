---
title: Administrar conectores en presentaciones usando Java
linktitle: Conector
type: docs
weight: 10
url: /es/java/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo del conector
- conectar formas
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Capacita a aplicaciones Java para dibujar, conectar y enrutar automáticamente líneas en diapositivas de PowerPoint—obtén control total sobre conectores rectos, en codo y curvos."
---

Un conector de PowerPoint es una línea especial que conecta o vincula dos formas entre sí y permanece unido a las formas incluso cuando se mueven o reposicionan en una diapositiva determinada. 

Los conectores se conectan normalmente a *puntos de conexión* (puntos verdes), que existen en todas las formas por defecto. Los puntos de conexión aparecen cuando el cursor se acerca a ellos.

*Puntos de ajuste* (puntos naranjas), que existen solo en ciertos conectores, se utilizan para modificar la posición y forma de los conectores.

## **Tipos de conectores**

En PowerPoint, puedes usar conectores rectos, de codo (angular) y curvos. 

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

## **Conectar formas usando conectores**

1. Crea una instancia de la clase [Presentación](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation).  
1. Obtén una referencia a una diapositiva mediante su índice.  
1. Añade dos [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.  
1. Añade un conector usando el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.  
1. Conecta las formas mediante el conector.  
1. Llama al método `reroute` para aplicar la ruta de conexión más corta.  
1. Guarda la presentación.  

Este código Java muestra cómo añadir un conector (un conector doblado) entre dos formas (una elipse y un rectángulo):
```Java
// Instancia una clase de presentación que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la colección de formas de una diapositiva específica
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Añade una forma automática de elipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Añade una forma automática de rectángulo
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Añade una forma de conector a la colección de formas de la diapositiva
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Conecta las formas usando el conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Llama a reroute que establece la ruta más corta automática entre las formas
    connector.reroute();
    
    // Guarda la presentación
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTA" color="warning" %}} 

El método `Connector.reroute` reencamina un conector y lo obliga a tomar la ruta más corta posible entre las formas. Para lograr su objetivo, el método puede cambiar los puntos `setStartShapeConnectionSiteIndex` y `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar un punto de conexión**

Si deseas que un conector enlace dos formas usando puntos específicos en las formas, debes especificar tus puntos de conexión preferidos de esta manera:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
1. Obtén una referencia a una diapositiva mediante su índice.  
1. Añade dos [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.  
1. Añade un conector usando el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.  
1. Conecta las formas mediante el conector.  
1. Establece tus puntos de conexión preferidos en las formas.  
1. Guarda la presentación.  

Este código Java demuestra una operación donde se especifica un punto de conexión preferido:
```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la colección de formas de una diapositiva específica
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Añade una forma automática de elipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Añade una forma automática de rectángulo
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Añade una forma de conector a la colección de formas de la diapositiva
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Conecta las formas usando el conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Establece el índice del punto de conexión preferido en la forma Elipse
    int wantedIndex = 6;

    // Comprueba si el índice preferido es menor que el recuento máximo de sitios de conexión
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


## **Ajustar un punto de conector**

Puedes ajustar un conector existente a través de sus puntos de ajuste. Solo los conectores con puntos de ajuste pueden modificarse de esta manera. Consulta la tabla bajo **[Tipos de conectores](/slides/es/java/connector/#types-of-connectors)**. 

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


Para evitar o sortear la tercera forma, podemos ajustar el conector moviendo su línea vertical hacia la izquierda de esta forma:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Casos complejos** 

Para realizar ajustes más complicados, debes tener en cuenta lo siguiente:

* Un punto ajustable de un conector está fuertemente vinculado a una fórmula que calcula y determina su posición. Por lo tanto, los cambios en la ubicación del punto pueden alterar la forma del conector.  
* Los puntos de ajuste de un conector se definen en un orden estricto dentro de una matriz. Los puntos se numeran desde el punto inicial del conector hasta su final.  
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/alto de la forma del conector.  
  * La forma está limitada por los puntos de inicio y fin del conector multiplicados por 1000.  
  * El primer punto, segundo punto y tercer punto definen respectivamente el porcentaje del ancho, el porcentaje del alto y nuevamente el porcentaje del ancho.  
* Para los cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debes considerar la rotación del conector y su reflexión. **Nota** que el ángulo de rotación para todos los conectores mostrados bajo **[Tipos de conectores](/slides/es/java/connector/#types-of-connectors)** es 0.

#### **Caso 1**

Considera un caso donde dos objetos de marco de texto están vinculados entre sí mediante un conector:

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
    
    // Enlaza las formas entre sí con el conector
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

Podemos cambiar los valores de los puntos de ajuste del conector incrementando los porcentajes correspondientes de ancho y alto en un 20 % y 200 % respectivamente:
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

En **Caso 1**, demostramos una operación simple de ajuste de conector usando principios básicos. En situaciones normales, debes tener en cuenta la rotación del conector y su visualización (establecidos por `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()`). Ahora demostraremos el proceso.

Primero, añadamos un nuevo objeto de marco de texto (**To 1**) a la diapositiva (para fines de conexión) y creemos un nuevo conector (verde) que lo una a los objetos ya creados.
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

Segundo, creemos una forma que corresponda al componente horizontal del conector que pasa por el nuevo punto de ajuste `connector.getAdjustments().get_Item(0)`. Utilizaremos los valores de los datos del conector para `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()` y aplicaremos la conocida fórmula de conversión de coordenadas para rotación alrededor de un punto dado `x0`:

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

Demostramos cálculos que involucran ajustes simples y puntos de ajuste complejos (puntos de ajuste con ángulos de rotación). Con el conocimiento adquirido, puedes desarrollar tu propio modelo (o escribir código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste de un conector basándote en coordenadas de diapositiva específicas.

## **Encontrar el ángulo de las líneas del conector**

1. Crea una instancia de la clase.  
1. Obtén una referencia a una diapositiva mediante su índice.  
1. Accede a la forma de línea del conector.  
1. Usa el ancho, alto, altura del marco de la forma y anchura del marco de la forma para calcular el ángulo.  

Este código Java demuestra una operación en la que calculamos el ángulo de una línea de conector:
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


## **FAQ**

**¿Cómo puedo saber si un conector puede "pegarse" a una forma específica?**

Verifica que la forma exponga [sitios de conexión](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getConnectionSiteCount--). Si no hay ninguno o el recuento es cero, la fijación no está disponible; en ese caso, usa extremos libres y colócalos manualmente. Es aconsejable comprobar el recuento de sitios antes de adjuntar.

**¿Qué ocurre con un conector si elimino una de las formas conectadas?**

Sus extremos quedarán desacoplados; el conector permanecerá en la diapositiva como una línea ordinaria con inicio/final libres. Puedes eliminarlo o volver a asignar las conexiones y, si es necesario, [reencaminar](https://reference.aspose.com/slides/java/com.aspose.slides/connector/#reroute--).

**¿Se conservan los enlaces de los conectores al copiar una diapositiva a otra presentación?**

Generalmente sí, siempre que las formas objetivo también se copien. Si la diapositiva se inserta en otro archivo sin las formas conectadas, los extremos se vuelven libres y tendrás que volver a adjuntarlos.