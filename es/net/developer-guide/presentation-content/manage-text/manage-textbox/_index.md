---
title: Gestionar TextBox
type: docs
weight: 20
url: /es/net/manage-textbox/
keywords: "Textbox, Marco de texto, Agregar textbox, Textbox con hiperenlace, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar un textbox o marco de texto a presentaciones de PowerPoint en C# o .NET"
---

Los textos en las diapositivas generalmente existen en cuadros de texto o formas. Por lo tanto, para agregar texto a una diapositiva, primero debes agregar un textbox y luego poner algún texto dentro del textbox.

Para permitirte agregar una forma que pueda contener texto, Aspose.Slides para .NET proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).

{{% alert title="Nota" color="warning" %}}

Aspose.Slides también proporciona la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) para permitirte agregar formas a las diapositivas. Sin embargo, no todas las formas añadidas a través de la interfaz `IShape` pueden contener texto. Las formas añadidas a través de la interfaz [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) generalmente contienen texto.

Por lo tanto, al tratar con una forma existente a la que deseas agregar texto, es posible que desees verificar y confirmar que fue convertida a través de la interfaz `IAutoShape`. Solo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe), que es una propiedad bajo `IAutoShape`. Consulta la sección [Actualizar Texto](https://docs.aspose.com/slides/net/manage-textbox/#update-text) en esta página.

{{% /alert %}}

## **Crear Cuadro de Texto en Diapositiva**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de la primera diapositiva a través de su índice.
3. Agrega un objeto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) con [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) configurado como `Rectangle` en una posición especificada en la diapositiva y obtén la referencia del objeto `IAutoShape` recién agregado.
4. Agrega una propiedad `TextFrame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, agregamos este texto: *Aspose TextBox*
5. Finalmente, escribe el archivo PPTX a través del objeto `Presentation`.

Este código C#—una implementación de los pasos anteriores—te muestra cómo agregar texto a una diapositiva:

```c#
// Instancia PresentationEx
using (Presentation pres = new Presentation())
{

    // Obtiene la primera diapositiva en la presentación
    ISlide sld = pres.Slides[0];

    // Agrega un AutoShape con el tipo configurado como Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Agrega TextFrame al Rectangle
    ashp.AddTextFrame(" ");

    // Accede al marco de texto
    ITextFrame txtFrame = ashp.TextFrame;

    // Crea el objeto Paragraph para el marco de texto
    IParagraph para = txtFrame.Paragraphs[0];

    // Crea un objeto Portion para el párrafo
    IPortion portion = para.Portions[0];

    // Establece el texto
    portion.Text = "Aspose TextBox";

    // Guarda la presentación en disco
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Verificar Forma de Cuadro de Texto**

Aspose.Slides proporciona la propiedad [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (de la clase [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)) para permitirte examinar formas y encontrar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código C# te muestra cómo verificar si una forma fue creada como un cuadro de texto:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(pres, (shape, slide, index) =>
    {
        if (shape is AutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "la forma es un cuadro de texto" : "la forma es un texto no cuadro");
        }
    });
}
```

## **Agregar Columna en Cuadro de Texto**

Aspose.Slides proporciona las propiedades [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) y [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) y la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) para permitirte agregar columnas a los cuadros de texto. Puedes especificar el número de columnas en un cuadro de texto y luego especificar el espaciado en puntos entre columnas.

Este código en C# demuestra la operación descrita:

```c#
using (Presentation presentation = new Presentation())
{
	// Obtiene la primera diapositiva en la presentación
	ISlide slide = presentation.Slides[0];

	// Agrega un AutoShape con el tipo configurado como Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Agrega TextFrame al Rectangle
	aShape.AddTextFrame("Todas estas columnas están limitadas a estar dentro de un único contenedor de texto -- " +
	"puedes agregar o eliminar texto y el nuevo o restante texto se ajusta automáticamente " +
	"para fluir dentro del contenedor. No puedes hacer que el texto fluya de un contenedor " +
	"a otro, sin embargo -- te dijimos que las opciones de columnas de PowerPoint para texto son limitadas!");

	// Obtiene el formato de texto de TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Especifica el número de columnas en TextFrame
	format.ColumnCount = 3;

	// Especifica el espaciado entre columnas
	format.ColumnSpacing = 10;

	// Guarda la presentación
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Agregar Columna en Marco de Texto**
Aspose.Slides para .NET proporciona la propiedad [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) que permite agregar columnas en marcos de texto. A través de esta propiedad, puedes especificar tu número preferido de columnas en un marco de texto.

Este código C# te muestra cómo agregar una columna dentro de un marco de texto:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "Todas estas columnas están forzadas a permanecer dentro de un único contenedor de texto -- " +
                                "puedes agregar o eliminar texto - y el nuevo o restante texto se ajusta automáticamente " +
                                "para permanecer dentro del contenedor. No puedes hacer que el texto se derrame de un contenedor " +
                                "a otro, sin embargo -- porque las opciones de columnas de PowerPoint para texto son limitadas!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Actualizar Texto**

Aspose.Slides te permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación.

Este código C# demuestra una operación donde todos los textos en una presentación son actualizados o cambiados:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Verifica si la forma admite el marco de texto (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Itera a través de los párrafos en el marco de texto
               {
                   foreach (IPortion portion in paragraph.Portions) //Itera a través de cada porción en el párrafo
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Cambia el texto
                       portion.PortionFormat.FontBold = NullableBool.True; //Cambia el formato
                   }
               }
           }
       }
   }
  
   //Guarda la presentación modificada
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Agregar Cuadro de Texto con Hiperenlace**

Puedes insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios serán dirigidos a abrir el enlace.

1. Crea una instancia de la clase `Presentation`.
2. Obtén la referencia de la primera diapositiva a través de su índice.
3. Agrega un objeto `AutoShape` con `ShapeType` configurado como `Rectangle` en una posición especificada en la diapositiva y obtén una referencia del objeto AutoShape recién agregado.
4. Agrega un `TextFrame` al objeto `AutoShape` que contiene *Aspose TextBox* como su texto predeterminado.
5. Instancia la clase `IHyperlinkManager`.
6. Asigna el objeto `IHyperlinkManager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) asociada con la porción preferida de tu `TextFrame`.
7. Finalmente, escribe el archivo PPTX a través del objeto `Presentation`.

Este código C#—una implementación de los pasos anteriores—te muestra cómo agregar un cuadro de texto con un hiperenlace a una diapositiva:

```c#
// Instancia una clase Presentation que representa un PPTX
Presentation pptxPresentation = new Presentation();

// Obtiene la primera diapositiva en la presentación
ISlide slide = pptxPresentation.Slides[0];

// Agrega un objeto AutoShape con el tipo configurado como Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Convierte la forma a AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Accede a la propiedad ITextFrame asociada con el AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Agrega algo de texto al marco
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Establece el hiperenlace para el texto de la porción
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Guarda la presentación PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```