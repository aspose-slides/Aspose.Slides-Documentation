---
title: Administrar cuadros de texto en presentaciones en .NET
linktitle: Administrar cuadro de texto
type: docs
weight: 20
url: /es/net/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- agregar texto
- actualizar texto
- crear cuadro de texto
- verificar cuadro de texto
- agregar columna de texto
- agregar hipervínculo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET facilita la creación, edición y clonación de cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---

Los textos en diapositivas normalmente existen en cuadros de texto o formas. Por lo tanto, para agregar texto a una diapositiva, debe agregar primero un cuadro de texto y luego colocar algo de texto dentro del cuadro de texto. 

Para permitirle agregar una forma que pueda contener texto, Aspose.Slides for .NET proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides también proporciona la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) para permitirle agregar formas a las diapositivas. Sin embargo, no todas las formas añadidas a través de la interfaz `IShape` pueden contener texto. Las formas añadidas a través de la interfaz [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) normalmente contienen texto. 

Por lo tanto, al trabajar con una forma existente a la que desea agregar texto, puede querer verificar y confirmar que se haya convertido mediante la interfaz `IAutoShape`. Sólo entonces podrá trabajar con [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe), que es una propiedad de `IAutoShape`. Consulte la sección [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) en esta página. 

{{% /alert %}}

## **Crear cuadro de texto en la diapositiva**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtenga la referencia de la primera diapositiva mediante su índice. 
3. Agregue un objeto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) con [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) configurado como `Rectangle` en una posición especificada en la diapositiva y obtenga la referencia del nuevo objeto `IAutoShape`. 
4. Agregue una propiedad `TextFrame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, añadimos este texto: *Aspose TextBox* 
5. Finalmente, escriba el archivo PPTX mediante el objeto `Presentation`. 

This C# code—an implementation of the steps above—shows you how to add text to a slide:
```c#
// Instancia PresentationEx
using (Presentation pres = new Presentation())
{

    // Obtiene la primera diapositiva de la presentación
    ISlide sld = pres.Slides[0];

    // Añade un AutoShape con el tipo establecido como Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Añade TextFrame al rectángulo
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


## **Comprobar forma de cuadro de texto**

Aspose.Slides proporciona la propiedad [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) de la interfaz [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), lo que le permite examinar formas e identificar cuadros de texto. 

![Text box and shape](istextbox.png)

This C# code shows you how to check whether a shape was created as a text box: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```


Tenga en cuenta que si simplemente agrega una forma automática usando el método `AddAutoShape` de la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/), la propiedad `IsTextBox` de la forma automática devolverá `false`. Sin embargo, después de agregar texto a la forma automática mediante el método `AddTextFrame` o la propiedad `Text`, la propiedad `IsTextBox` devolverá `true`.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox es falso
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox es verdadero

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox es falso
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox es verdadero

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox es falso
    shape3.AddTextFrame("");
    // shape3.IsTextBox es falso

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox es falso
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox es falso
}
```


## **Agregar columna en cuadro de texto**

Aspose.Slides proporciona las propiedades [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) y [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) y la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) para permitirle agregar columnas a los cuadros de texto. Puede especificar el número de columnas en un cuadro de texto y luego especificar el espaciado en puntos entre columnas. 

This code in C# demonstrates the described operation: 
```c#
using (Presentation presentation = new Presentation())
{
	// Obtiene la primera diapositiva de la presentación
	ISlide slide = presentation.Slides[0];

	// Añade un AutoShape con el tipo establecido como Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Añade TextFrame al rectángulo
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

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


## **Agregar columna en marco de texto**

Aspose.Slides for .NET proporciona la propiedad [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) que le permite agregar columnas en marcos de texto. Mediante esta propiedad, puede especificar el número deseado de columnas en un marco de texto. 

This C# code shows you how to add a column inside a text frame:
```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
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


## **Actualizar texto**

Aspose.Slides le permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

This C# code demonstrates an operation where all the texts in a presentation are updated or changed:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Comprueba si la forma admite marco de texto (IAutoShape). 
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


## **Agregar cuadro de texto con hipervínculo** 

Puede insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

1. Cree una instancia de la clase `Presentation`. 
2. Obtenga la referencia de la primera diapositiva mediante su índice.  
3. Agregue un objeto `AutoShape` con `ShapeType` configurado como `Rectangle` en una posición especificada en la diapositiva y obtenga una referencia del nuevo objeto AutoShape añadido. 
4. Agregue un `TextFrame` al objeto `AutoShape` que contiene *Aspose TextBox* como texto predeterminado. 
5. Instancie la clase `IHyperlinkManager`. 
6. Asigne el objeto `IHyperlinkManager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) asociada con la porción deseada del `TextFrame`. 
7. Finalmente, escriba el archivo PPTX mediante el objeto `Presentation`. 

This C# code—an implementation of the steps above—shows you how to add a text box with a hyperlink to a slide:
```c#
 // Instancia una clase Presentation que representa un PPTX
 Presentation pptxPresentation = new Presentation();

 // Obtiene la primera diapositiva de la presentación
 ISlide slide = pptxPresentation.Slides[0];

 // Añade un objeto AutoShape con el tipo establecido como Rectangle
 IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

 // Convierte la forma a AutoShape
 IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

 // Accede a la propiedad ITextFrame asociada con el AutoShape
 pptxAutoShape.AddTextFrame("");

 ITextFrame ITextFrame = pptxAutoShape.TextFrame;

 // Añade algo de texto al marco
 ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

 // Establece el hipervínculo para el texto de la porción
 IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
 HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

 // Guarda la presentación PPTX
 pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto al trabajar con diapositivas maestras?**

Un [placeholder](/slides/es/net/manage-placeholder/) hereda estilo/posición de la [master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) y puede ser sobrescrito en los [layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), mientras que un cuadro de texto regular es un objeto independiente en una diapositiva específica y no cambia al cambiar de layout.  

**¿Cómo puedo realizar un reemplazo masivo de texto en toda la presentación sin afectar el texto dentro de gráficos, tablas y SmartArt?**

Limite su iteración a autoformas que tengan marcos de texto y excluya los objetos incrustados ([charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) recorriendo sus colecciones por separado o omitiendo esos tipos de objetos.