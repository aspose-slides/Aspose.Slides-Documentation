---
title: Gestionar formas de presentación en .NET
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/net/shape-manipulations/
keywords:
- Forma de PowerPoint
- Forma de presentación
- Forma en diapositiva
- Encontrar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma Interop
- Texto alternativo de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear, editar y optimizar formas en Aspose.Slides para .NET y ofrecer presentaciones de PowerPoint de alto rendimiento."
---

## **Buscar una forma en una diapositiva**
Este tema describirá una técnica sencilla para facilitar a los desarrolladores la búsqueda de una forma específica en una diapositiva sin utilizar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no disponen de ningún método para identificar formas en una diapositiva, salvo un Id único interno. A los desarrolladores les resulta complicado localizar una forma mediante su Id único interno. Todas las formas añadidas a las diapositivas poseen algún Texto alternativo. Sugerimos a los desarrolladores que utilicen texto alternativo para encontrar una forma concreta. Puede usar MS PowerPoint para definir el texto alternativo de los objetos que planea modificar en el futuro.

Después de establecer el texto alternativo de la forma deseada, puede abrir esa presentación con Aspose.Slides for .NET e iterar a través de todas las formas añadidas a una diapositiva. En cada iteración, puede comprobar el texto alternativo de la forma y la forma cuyo texto alternativo coincida será la que necesita. Para demostrar esta técnica de forma más clara, hemos creado un método, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) que realiza la búsqueda de una forma específica en una diapositiva y simplemente devuelve esa forma.
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


## **Clonar una forma**
Para clonar una forma en una diapositiva usando Aspose.Slides for .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Acceder a la colección de formas de la diapositiva fuente.
1. Añadir una nueva diapositiva a la presentación.
1. Clonar las formas de la colección de la diapositiva fuente a la nueva diapositiva.
1. Guardar la presentación modificada como archivo PPTX.

El ejemplo a continuación añade una forma de grupo a una diapositiva.
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


## **Eliminar una forma**
Aspose.Slides for .NET permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Encontrar la forma con el TextoAlternativo específico.
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


## **Ocultar una forma**
Aspose.Slides for .NET permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Encontrar la forma con el TextoAlternativo específico.
1. Ocultar la forma.
1. Guardar el archivo en disco.
```c#
 // Instanciar la clase Presentation que representa el PPTX
 Presentation pres = new Presentation();

 // Obtener la primera diapositiva
 ISlide sld = pres.Slides[0];

 // Agregar autoshape de tipo rectángulo
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


## **Cambiar el orden de las formas**
Aspose.Slides for .NET permite a los desarrolladores reordenar las formas. Reordenar una forma determina cuál está al frente y cuál está detrás. Para reordenar las formas de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Añadir una forma.
1. Añadir texto al marco de texto de la forma.
1. Añadir otra forma con las mismas coordenadas.
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


## **Obtener el ID de forma Interop**
Aspose.Slides for .NET permite a los desarrolladores obtener un identificador de forma único en el ámbito de la diapositiva, a diferencia de la propiedad UniqueId, que proporciona un identificador único en el ámbito de la presentación. La propiedad OfficeInteropShapeId se añadió a las interfaces IShape y a la clase Shape. El valor devuelto por la propiedad OfficeInteropShapeId corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se muestra un ejemplo de código.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Obtención del identificador de forma único en el ámbito de la diapositiva
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```


## **Establecer texto alternativo para una forma**
Aspose.Slides for .NET permite a los desarrolladores establecer el AlternateText de cualquier forma.  
Las formas en una presentación pueden distinguirse mediante la propiedad AlternativeText o el nombre de la forma.  
La propiedad AlternativeText puede leerse o establecerse tanto con Aspose.Slides como con Microsoft PowerPoint.  
Al usar esta propiedad, puede etiquetar una forma y realizar distintas operaciones como eliminar, ocultar o reordenar formas en una diapositiva.  
Para establecer el AlternateText de una forma, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Añadir cualquier forma a la diapositiva.
1. Realizar alguna operación con la forma recién añadida.
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


## **Acceder a formatos de diseño para una forma**
Aspose.Slides for .NET proporciona una API sencilla para acceder a los formatos de diseño de una forma. Este artículo muestra cómo puede acceder a dichos formatos.

A continuación se muestra un ejemplo de código.
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


## **Renderizar una forma como SVG**
Ahora Aspose.Slides for .NET admite la renderización de una forma como SVG. El método WriteAsSvg (y su sobrecarga) se añadió a la clase Shape y a la interfaz IShape. Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de una diapositiva a un archivo SVG.
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


## **Alinear una forma**

A través del método [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) sobrecargado, puede

* alinear formas respecto a los márgenes de una diapositiva. Ver Ejemplo 1.  
* alinear formas entre sí. Ver Ejemplo 2.  

La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) define las opciones de alineación disponibles.

**Example 1**

Este código C# muestra cómo alinear las formas con índices 1, 2 y 4 a lo largo del borde superior de una diapositiva:
El código fuente a continuación alinea las formas con índices 1, 2 y 4 a lo largo del borde superior de la diapositiva. 
``` csharp
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


**Example 2**

Este código C# muestra cómo alinear una colección completa de formas respecto a la forma inferior de la colección:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **Propiedades de volteo**

En Aspose.Slides, la clase [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) proporciona control sobre el espejo horizontal y vertical de las formas mediante sus propiedades `FlipH` y `FlipV`. Ambas propiedades son del tipo [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), permitiendo valores `True` para indicar un volteo, `False` para no voltear, o `NotDefined` para usar el comportamiento predeterminado. Estos valores son accesibles desde el [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) de una forma.

Para modificar la configuración de volteo, se construye una nueva instancia de [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) con la posición y el tamaño actuales de la forma, los valores deseados para `FlipH` y `FlipV`, y el ángulo de rotación. Asignar esta instancia al [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) de la forma y guardar la presentación aplica las transformaciones de espejo y las compromete en el archivo de salida.

Supongamos que tenemos un archivo sample.pptx en el que la primera diapositiva contiene una única forma con la configuración de volteo predeterminada, como se muestra a continuación.

![The shape to be flipped](shape_to_be_flipped.png)

El siguiente ejemplo de código recupera las propiedades de volteo actuales de la forma y la voltea tanto horizontal como verticalmente.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Recuperar la propiedad de volteo horizontal de la forma.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Recuperar la propiedad de volteo vertical de la forma.
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

## **Preguntas frecuentes**

**¿Puedo combinar formas (unir/intersectar/restar) en una diapositiva como en un editor de escritorio?**

No existe una API de operaciones booleanas incorporada. Puede aproximarse construyendo manualmente el contorno deseado—por ejemplo, calculando la geometría resultante (mediante [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)) y creando una nueva forma con ese contorno, eliminando opcionalmente las originales.

**¿Cómo puedo controlar el orden de apilamiento (z-order) para que una forma siempre quede “encima”?**

Cambie el orden de inserción/movimiento dentro de la colección [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) de la diapositiva. Para resultados predecibles, finalice el z-order después de todas las demás modificaciones de la diapositiva.

**¿Puedo “bloquear” una forma para evitar que los usuarios la editen en PowerPoint?**

Sí. Establezca los [flags de protección a nivel de forma](/slides/es/net/applying-protection-to-presentation/) (por ejemplo, bloquear la selección, el movimiento, el cambio de tamaño o la edición de texto). Si es necesario, extienda las restricciones al maestro o al diseño. Tenga en cuenta que esta es una protección a nivel de UI, no una característica de seguridad; para una protección más fuerte, combínela con restricciones a nivel de archivo, como recomendaciones de solo lectura o contraseñas [/slides/net/password-protected-presentation/].