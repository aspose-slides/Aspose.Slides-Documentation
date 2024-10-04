---
title: Manipulaciones de Formas
type: docs
weight: 40
url: /net/shape-manipulations/
keywords: "forma de PowerPoint, forma en la diapositiva, encontrar forma, clonar forma, eliminar forma, ocultar forma, cambiar orden de formas, obtener ID de forma interop, texto alternativo de forma, formatos de diseño de forma, forma como SVG, alinear forma, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Manipular formas de PowerPoint en C# o .NET"
---

## **Encontrar Forma en Diapositiva**
Este tema describirá una técnica sencilla para facilitar a los desarrolladores encontrar una forma específica en una diapositiva sin usar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no tienen ninguna forma de identificar formas en una diapositiva excepto un Id único interno. Parece ser difícil para los desarrolladores encontrar una forma usando su Id único interno. Todas las formas añadidas a las diapositivas tienen algún Texto Alternativo. Sugerimos a los desarrolladores usar texto alternativo para encontrar una forma específica. Puede usar MS PowerPoint para definir el texto alternativo para objetos que planea cambiar en el futuro.

Después de establecer el texto alternativo de cualquier forma deseada, puede abrir esa presentación usando Aspose.Slides para .NET e iterar a través de todas las formas añadidas a una diapositiva. Durante cada iteración, puede verificar el texto alternativo de la forma y la forma con el texto alternativo coincidente sería la forma requerida por usted. Para demostrar esta técnica de mejor manera, hemos creado un método, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) que hace el truco para encontrar una forma específica en una diapositiva y luego simplemente devuelve esa forma.

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
            Console.WriteLine("Nombre de la Forma: " + shape.Name);
        }
    }
}
        
// Implementación del método para encontrar una forma en una diapositiva usando su texto alternativo
public static IShape FindShape(ISlide slide, string alttext)
{
    // Iterar a través de todas las formas dentro de la diapositiva
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Si el texto alternativo de la diapositiva coincide con el requerido entonces
        // Devolver la forma
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Clonar Forma**
Para clonar una forma a una diapositiva usando Aspose.Slides para .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Acceder a la colección de formas de la diapositiva de origen.
1. Agregar una nueva diapositiva a la presentación.
1. Clonar formas de la colección de formas de la diapositiva de origen a la nueva diapositiva.
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

	// Escribir el archivo PPTX en el disco
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Eliminar Forma**
Aspose.Slides para .NET permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Encontrar la forma con TextoAlternativo específico.
1. Eliminar la forma.
1. Guardar el archivo en el disco.

```c#
// Crear objeto Presentation
Presentation pres = new Presentation();

// Obtener la primera diapositiva
ISlide sld = pres.Slides[0];

// Agregar una forma automática de tipo rectángulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Definido por el usuario";
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



## **Ocultar Forma**
Aspose.Slides para .NET permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Encontrar la forma con TextoAlternativo específico.
1. Ocultar la forma.
1. Guardar el archivo en el disco.

```c#
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();

// Obtener la primera diapositiva
ISlide sld = pres.Slides[0];

// Agregar una forma automática de tipo rectángulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Definido por el usuario";
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



## **Cambiar Orden de Formas**
Aspose.Slides para .NET permite a los desarrolladores reordenar las formas. Reordenar las formas especifica qué forma está al frente o qué forma está atrás. Para reordenar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Agregar una forma.
1. Agregar algún texto en el marco de texto de la forma.
1. Agregar otra forma con las mismas coordenadas.
1. Reordenar las formas.
1. Guardar el archivo en el disco.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Texto de Marca de Agua Texto de Marca de Agua Texto de Marca de Agua";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Obtener ID de Forma Interop**
Aspose.Slides para .NET permite a los desarrolladores obtener un identificador único de forma en el ámbito de la diapositiva en contraste con la propiedad UniqueId, que permite obtener un identificador único en el ámbito de la presentación. La propiedad OfficeInteropShapeId se ha añadido a las interfaces IShape y la clase Shape respectivamente. El valor devuelto por la propiedad OfficeInteropShapeId corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se proporciona un código de muestra.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Obtener el identificador único de forma en el ámbito de la diapositiva
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **Establecer Texto Alternativo para la Forma**
Aspose.Slides para .NET permite a los desarrolladores establecer el TextoAlternativo de cualquier forma. 
Las formas en una presentación pueden ser diferenciadas por el TextoAlternativo o la propiedad Nombre de Forma. 
La propiedad TextoAlternativo puede ser leída o establecida mediante Aspose.Slides así como Microsoft PowerPoint. 
Usando esta propiedad, puede etiquetar una forma y realizar diferentes operaciones como eliminar una forma, 
ocultar una forma o reordenar formas en una diapositiva.
Para establecer el TextoAlternativo de una forma, siga los pasos a continuación:

1. Crear una instancia de la clase `Presentation`.
1. Acceder a la primera diapositiva.
1. Agregar cualquier forma a la diapositiva.
1. Hacer algún trabajo con la forma recién añadida.
1. Recorrer las formas para encontrar una forma.
1. Establecer el TextoAlternativo.
1. Guardar el archivo en el disco.

```c#
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();

// Obtener la primera diapositiva
ISlide sld = pres.Slides[0];

// Agregar una forma automática de tipo rectángulo
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
        ashp.AlternativeText = "Definido por el usuario";
    }
}

// Guardar la presentación en disco
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Acceder a Formatos de Diseño para la Forma**
Aspose.Slides para .NET proporciona una API simple para acceder a formatos de diseño para una forma. Este artículo demuestra cómo puede acceder a los formatos de diseño.

A continuación se proporciona un código de muestra.

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

## **Renderizar Forma como SVG**
Ahora Aspose.Slides para .NET apoya renderizar una forma como svg. El método WriteAsSvg (y su sobrecarga) ha sido añadido a la clase Shape y la interfaz IShape. Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de la diapositiva a un archivo SVG.

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

## Alinear Forma

A través del método sobrecargado [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index), puede 

* alinear formas en relación con los márgenes de una diapositiva. Ver Ejemplo 1. 
* alinear formas entre sí. Ver Ejemplo 2. 

La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) define las opciones de alineación disponibles.

### Ejemplo 1

Este código C# le muestra cómo alinear formas con índices 1, 2 y 4 a lo largo del borde superior de una diapositiva:
El código fuente a continuación alinea formas con índices 1, 2 y 4 a lo largo del borde superior de la diapositiva. 

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

### Ejemplo 2

Este código C# le muestra cómo alinear toda una colección de formas en relación con la forma inferior en la colección:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```