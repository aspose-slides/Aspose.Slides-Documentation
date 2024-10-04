---
title: Conector
type: docs
weight: 10
url: /net/connector/
keywords: "Conectar formas, conectores, formas de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Conectar formas de PowerPoint en C# o .NET"
---

Un conector de PowerPoint es una línea especial que conecta o enlaza dos formas juntas y permanece adjunta a las formas incluso cuando se mueven o reubican en una diapositiva determinada.

Los conectores están típicamente conectados a *puntos de conexión* (puntos verdes), que existen en todas las formas por defecto. Los puntos de conexión aparecen cuando un cursor se acerca a ellos.

*Puntos de ajuste* (puntos naranjas), que existen solo en ciertos conectores, se utilizan para modificar las posiciones y formas de los conectores.

## **Tipos de Conectores**

En PowerPoint, puedes usar conectores rectos, en ángulo (doblados) y curvados.

Aspose.Slides proporciona estos conectores:

| Conector                      | Imagen                                                       | Número de puntos de ajuste |
| ----------------------------- | ----------------------------------------------------------- | -------------------------- |
| `ShapeType.Line`              | ![shapetype-lineconnector](shapetype-lineconnector.png)     | 0                          |
| `ShapeType.StraightConnector1`| ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                          |
| `ShapeType.BentConnector2`    | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0                          |
| `ShapeType.BentConnector3`    | ![shapetype-bentconnector3](shapetype-bentconnector3.png)   | 1                          |
| `ShapeType.BentConnector4`    | ![shapetype-bentconnector4](shapetype-bentconnector4.png)   | 2                          |
| `ShapeType.BentConnector5`    | ![shapetype-bentconnector5](shapetype-bentconnector5.png)   | 3                          |
| `ShapeType.CurvedConnector2`  | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                          |
| `ShapeType.CurvedConnector3`  | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                          |
| `ShapeType.CurvedConnector4`  | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                          |
| `ShapeType.CurvedConnector5`  | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                          |

## **Conectar Formas Usando Conectores**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) a la diapositiva usando el método `AddAutoShape` expuesto por el objeto `Shapes`.
1. Agrega un conector usando el método `AddConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector.
1. Llama al método `Reroute` para aplicar la ruta de conexión más corta.
1. Guarda la presentación.

Este código C# muestra cómo agregar un conector (un conector doblado) entre dos formas (una elipse y un rectángulo):

```c#
// Instancia una clase de presentación que representa un archivo PPTX
using (Presentation input = new Presentation())
{                
    // Accede a la colección de formas para una diapositiva específica
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Agrega una forma de Elipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Agrega una forma de Rectángulo
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Agrega una forma de conector a la colección de formas de la diapositiva
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Conecta las formas usando el conector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Llama a reroute que establece la ruta automática más corta entre las formas
    connector.Reroute();

    // Guarda la presentación
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTA"  color="warning"   %}} 

El método `Connector.Reroute` redirige un conector y obliga a tomar la ruta más corta posible entre las formas. Para lograr su objetivo, el método puede cambiar los puntos `StartShapeConnectionSiteIndex` y `EndShapeConnectionSiteIndex`.

{{% /alert %}} 

## **Especificar Punto de Conexión**
Si deseas que un conector enlace dos formas utilizando puntos específicos en las formas, debes especificar tus puntos de conexión preferidos de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) a la diapositiva usando el método `AddAutoShape` expuesto por el objeto `Shapes`.
1. Agrega un conector usando el método `AddConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector. 
1. Establece tus puntos de conexión preferidos en las formas. 
1. Guarda la presentación.

Este código C# demuestra una operación donde se especifica un punto de conexión preferido:

```c#
// Instancia una clase de presentación que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la colección de formas para una diapositiva específica
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Agrega una forma de conector a la colección de formas de la diapositiva
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Agrega una forma de Elipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Agrega una forma de Rectángulo
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Conecta las formas usando el conector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Establece el índice del punto de conexión preferido en la forma de Elipse
    uint wantedIndex = 6;

    // Verifica si el índice preferido es menor que el recuento máximo de índices de sitio
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Establece el punto de conexión preferido en la forma de Elipse
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Guarda la presentación
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Ajustar Punto del Conector**

Puedes ajustar un conector existente a través de sus puntos de ajuste. Solo se pueden modificar de esta manera los conectores que tienen puntos de ajuste. Consulta la tabla bajo **[Tipos de conectores.](/slides/net/connector/#types-of-connectors)** 

#### **Caso Simple**

Considera un caso en el que un conector entre dos formas (A y B) pasa a través de una tercera forma (C):

![connector-obstruction](connector-obstruction.png)

Código:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Para evitar o eludir la tercera forma, podemos ajustar el conector moviendo su línea vertical a la izquierda de esta manera:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Casos Complejos** 

Para realizar ajustes más complicados, debes tener en cuenta estas cosas:

* El punto ajustable de un conector está fuertemente vinculado a una fórmula que calcula y determina su posición. Por lo tanto, los cambios en la ubicación del punto pueden alterar la forma del conector.
* Los puntos de ajuste de un conector están definidos en un orden estricto en una matriz. Los puntos de ajuste están numerados desde el punto de inicio de un conector hasta su fin.
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/alto de la forma del conector. 
  * La forma está delimitada por los puntos de inicio y fin del conector multiplicados por 1000. 
  * El primer punto, el segundo punto y el tercer punto definen el porcentaje del ancho, el porcentaje de la altura y el porcentaje del ancho (nuevamente), respectivamente.
* Para los cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debes tener en cuenta la rotación y su reflexión. **Nota** que el ángulo de rotación para todos los conectores que se muestran bajo **[Tipos de conectores](/slides/net/connector/#types-of-connectors)** es 0.

#### **Caso 1**

Considera un caso en el que dos objetos de marco de texto están vinculados a través de un conector:

![connector-shape-complex](connector-shape-complex.png)

Código:

```c#
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
// Obtiene la primera diapositiva de la presentación
ISlide sld = pres.Slides[0];
// Agrega formas que estarán unidas a través de un conector
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "Desde";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "Hasta";
// Agrega un conector
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Especifica la dirección del conector
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Especifica el color del conector
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Especifica el grosor de la línea del conector
connector.LineFormat.Width = 3;

// Une las formas con el conector
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Obtiene puntos de ajuste para el conector
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Ajuste**

Podemos cambiar los valores de los puntos de ajuste del conector aumentando el porcentaje de ancho y alto correspondiente en un 20% y 200%, respectivamente:

```c#
// Cambia los valores de los puntos de ajuste
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

El resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de las partes individuales del conector, creemos una forma que corresponda al componente horizontal del conector en el punto connector.Adjustments[0]:

```c#
// Dibuja el componente vertical del conector

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

El resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

En **Caso 1**, demostramos una operación simple de ajuste de conector usando principios básicos. En situaciones normales, debes tener en cuenta la rotación del conector y su visualización (que están determinadas por connector.Rotation, connector.Frame.FlipH y connector.Frame.FlipV). Ahora demostraremos el proceso.

Primero, agreguemos un nuevo objeto de marco de texto (**Hasta 1**) a la diapositiva (para fines de conexión) y creemos un nuevo conector (verde) que lo conecte a los objetos que ya hemos creado.

```c#
// Crea un nuevo objeto de unión
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "Hasta 1";
// Crea un nuevo conector
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Une los objetos usando el nuevo conector creado
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectedTo = 3;
// Obtiene los puntos de ajuste del conector
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Cambia los valores de los puntos de ajuste 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

El resultado:

![connector-adjusted-3](connector-adjusted-3.png)

Segundo, creemos una forma que corresponderá al componente horizontal del conector que pasa a través del nuevo punto de ajuste del conector connector.Adjustments[0]. Usaremos los valores de los datos del conector para connector.Rotation, connector.Frame.FlipH y connector.Frame.FlipV y aplicaremos la popular fórmula de conversión de coordenadas para rotación alrededor de un punto dado x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

En nuestro caso, el ángulo de rotación del objeto es de 90 grados y el conector se muestra verticalmente, por lo que este es el código correspondiente:

```c#
// Guarda las coordenadas del conector
x = connector.X;
y = connector.Y;
// Corrige las coordenadas del conector en caso de que aparezca
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Toma el valor del punto de ajuste como coordenada
x += connector.Width * adjValue_0.RawValue / 100000;
//  Convierte las coordenadas ya que Sin(90) = 1 y Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Determina el ancho del componente horizontal usando el valor del segundo punto de ajuste
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

El resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demostramos cálculos que involucran ajustes simples y complicados (puntos de ajuste con ángulos de rotación). Con el conocimiento adquirido, puedes desarrollar tu propio modelo (o escribir un código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste de un conector en función de coordenadas específicas de la diapositiva.

## **Encontrar Ángulo de Líneas de Conector**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Accede a la forma de línea del conector. 
1. Usa el ancho de línea, altura, altura del marco de la forma y ancho del marco de la forma para calcular el ángulo.

Este código C# demuestra una operación en la que calculamos el ángulo para una forma de línea de conector:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```