---
title: Manipulaciones de Formas
type: docs
weight: 40
url: /es/net/shape-manipulations/
keywords: "forma de PowerPoint, forma en diapositiva, buscar forma, clonar forma, eliminar forma, ocultar forma, cambiar orden de forma, obtener ID de forma Interop, texto alternativo de forma, formatos de diseño de forma, forma como SVG, alinear forma, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Manipular formas de PowerPoint en C# o .NET"
---

## **Buscar forma en diapositiva**
Este tema describirá una técnica sencilla para facilitar a los desarrolladores la búsqueda de una forma específica en una diapositiva sin usar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no disponen de ningún método para identificar las formas en una diapositiva, salvo un Id único interno. Resulta difícil para los desarrolladores encontrar una forma utilizando su Id único interno. Todas las formas añadidas a las diapositivas tienen algún Texto alternativo. Sugerimos a los desarrolladores que usen el texto alternativo para encontrar una forma específica. Puedes usar MS PowerPoint para definir el texto alternativo para los objetos que planeas modificar en el futuro.

Después de establecer el texto alternativo de la forma deseada, puedes abrir esa presentación usando Aspose.Slides for .NET y recorrer todas las formas añadidas a una diapositiva. En cada iteración, puedes comprobar el texto alternativo de la forma y la forma cuyo texto alternativo coincida será la forma que necesitas. Para demostrar esta técnica de manera más clara, hemos creado un método, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) que permite encontrar una forma específica en una diapositiva y simplemente devuelve esa forma.
```c#
public static void Run()
{
    // Instanciar una clase Presentation que representa el archivo de presentación
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Texto alternativo de la forma a encontrar
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Implementación del método para encontrar una forma en una diapositiva usando su texto alternativo
public static IShape FindShape(ISlide slide, string alttext)
{
    // Iterando a través de todas las formas dentro de la diapositiva
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Si el texto alternativo de la forma coincide con el requerido entonces
        // Devolver la forma
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```




## **Clonar forma**
Para clonar una forma a una diapositiva usando Aspose.Slides for .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Acceder a la colección de formas de la diapositiva origen.
1. Agregar una nueva diapositiva a la presentación.
1. Clonar las formas de la colección de formas de la diapositiva origen a la nueva diapositiva.
1. Guardar la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.
```c#
// Instanciar la clase Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

        // Escribir el archivo PPTX en disco
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```




## **Eliminar forma**
Aspose.Slides for .NET permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, sigue los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Buscar la forma con un AlternativeText específico.
1. Eliminar la forma.
1. Guardar el archivo en disco.
```c#
// Crear objeto Presentation
Presentation pres = new Presentation();

// Obtener la primera diapositiva
ISlide sld = pres.Slides[0];

// Añadir autoshape de tipo rectángulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Guardar la presentación en disco
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```




## **Ocultar forma**
Aspose.Slides for .NET permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, sigue los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Buscar la forma con un AlternativeText específico.
1. Ocultar la forma.
1. Guardar el archivo en disco.
```c#
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();

// Obtener la primera diapositiva
ISlide sld = pres.Slides[0];

// Añadir autoshape de tipo rectángulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Guardar la presentación en disco
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```




## **Cambiar orden de formas**
Aspose.Slides for .NET permite a los desarrolladores reordenar las formas. Reordenar la forma especifica qué forma está al frente o cuál está detrás. Para reordenar la forma en cualquier diapositiva, sigue los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Agregar una forma.
1. Agregar texto al marco de texto de la forma.
1. Agregar otra forma con las mismas coordenadas.
1. Reordenar las formas.
1. Guardar el archivo en disco.
```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```



## **Obtener ID de forma Interop**
Aspose.Slides for .NET permite a los desarrolladores obtener un identificador único de forma en el ámbito de la diapositiva, a diferencia de la propiedad UniqueId, que permite obtener un identificador único en el ámbito de la presentación. La propiedad OfficeInteropShapeId se añadió a las interfaces IShape y a la clase Shape respectivamente. El valor devuelto por la propiedad OfficeInteropShapeId corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se muestra un ejemplo de código.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Obtener identificador único de forma en el ámbito de la diapositiva
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```




## **Establecer texto alternativo para forma**
Aspose.Slides for .NET permite a los desarrolladores establecer el AlternateText de cualquier forma. Las formas en una presentación pueden distinguirse por la propiedad AlternativeText o por el nombre de la forma. La propiedad AlternativeText puede leerse o establecerse usando Aspose.Slides así como Microsoft PowerPoint. Mediante esta propiedad, puedes etiquetar una forma y realizar diferentes operaciones como eliminar una forma, ocultar una forma o reordenar formas en una diapositiva. Para establecer el AlternateText de una forma, sigue los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Agregar cualquier forma a la diapositiva.
1. Realizar alguna acción con la forma recién añadida.
1. Recorrer las formas para encontrar una forma.
1. Establecer el AlternativeText.
1. Guardar el archivo en disco.
```c#
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();

// Obtener la primera diapositiva
ISlide sld = pres.Slides[0];

// Agregar autoshape de tipo rectángulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Guardar la presentación en disco
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```





## **Acceder a formatos de diseño para forma**
Aspose.Slides for .NET proporciona una API sencilla para acceder a los formatos de diseño de una forma. Este artículo muestra cómo puedes acceder a los formatos de diseño.

A continuación se muestra el código de ejemplo.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```


## **Renderizar forma como SVG**
Ahora Aspose.Slides for .NET admite renderizar una forma como SVG. El método WriteAsSvg (y su sobrecarga) se ha añadido a la clase Shape y a la interfaz IShape. Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de una diapositiva a un archivo SVG.
```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```


## **Alinear forma**

A través del método sobrecargado [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index), puedes

* alinear formas respecto a los márgenes de una diapositiva. Ver Ejemplo 1.
* alinear formas entre sí. Ver Ejemplo 2.

La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) define las opciones de alineación disponibles.

**Ejemplo 1**

Este código C# muestra cómo alinear formas con índices 1,2 y 4 a lo largo del borde superior de una diapositiva:
El código fuente a continuación alinea las formas con índices 1,2 y 4 a lo largo del borde superior de la diapositiva.
```csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```


**Ejemplo 2**

Este código C# muestra cómo alinear una colección completa de formas respecto a la forma inferior de la colección:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **Propiedades de volteo**

En Aspose.Slides, la clase [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) ofrece control sobre el espejo horizontal y vertical de las formas mediante sus propiedades `FlipH` y `FlipV`. Ambas propiedades son del tipo [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), permitiendo valores `True` para indicar un volteo, `False` para no voltear, o `NotDefined` para usar el comportamiento predeterminado. Estos valores son accesibles desde el [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) de una forma.

Para modificar la configuración de volteo, se construye una nueva instancia de [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) con la posición y tamaño actuales de la forma, los valores deseados para `FlipH` y `FlipV`, y el ángulo de rotación. Asignar esta instancia al [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) de la forma y guardar la presentación aplica las transformaciones de espejo y las guarda en el archivo de salida.

Supongamos que tenemos un archivo sample.pptx en el que la primera diapositiva contiene una única forma con la configuración de volteo predeterminada, como se muestra a continuación.

![The shape to be flipped](shape_to_be_flipped.png)

El siguiente ejemplo de código recupera las propiedades de volteo actuales de la forma y la voltea tanto horizontal como verticalmente.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Obtener la propiedad de volteo horizontal de la forma.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Obtener la propiedad de volteo vertical de la forma.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Voltear horizontalmente.
    NullableBool flipV = NullableBool.True; // Voltear verticalmente.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The flipped shape](flipped_shape.png)

## **FAQ**

**¿Puedo combinar formas (unión/intersección/ sustracción) en una diapositiva como en un editor de escritorio?**

No hay una API de operaciones booleanas incorporada. Puedes aproximarte construyendo el contorno deseado tú mismo—por ejemplo, calculando la geometría resultante (mediante [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)) y crear una nueva forma con ese contorno, opcionalmente eliminando las originales.

**¿Cómo puedo controlar el orden de apilamiento (z-order) para que una forma siempre permanezca "en la parte superior"?**

Cambiar el orden de inserción/movimiento dentro de la colección de [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) de la diapositiva. Para resultados predecibles, finaliza el z-order después de todas las demás modificaciones de la diapositiva.

**¿Puedo "bloquear" una forma para evitar que los usuarios la editen en PowerPoint?**

Sí. Establece [banderas de protección a nivel de forma](/slides/es/net/applying-protection-to-presentation/) (por ejemplo, bloquear selección, movimiento, redimensionado, edición de texto). Si es necesario, aplica restricciones en la diapositiva maestra o de diseño. Ten en cuenta que esto es una protección a nivel de UI, no una característica de seguridad; para una protección más fuerte, combínala con restricciones a nivel de archivo como [recomendaciones de solo lectura o contraseñas](/slides/es/net/password-protected-presentation/).