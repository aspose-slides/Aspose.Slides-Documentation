---
title: Gestionar hipervínculos de presentación en .NET
linktitle: Gestionar hipervínculo
type: docs
weight: 20
url: /es/net/manage-hyperlinks/
keywords:
- añadir URL
- añadir hipervínculo
- crear hipervínculo
- formatear hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- hipervínculo de texto
- hipervínculo de diapositiva
- hipervínculo de forma
- hipervínculo de imagen
- hipervínculo de vídeo
- hipervínculo mutable
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona sin esfuerzo los hipervínculos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para .NET: mejora la interactividad y el flujo de trabajo en minutos."
---
## **Introducción**

Un hipervínculo es una referencia a un objeto o dato o a un lugar en algo. Estos son hipervínculos habituales en presentaciones de PowerPoint:

* Enlaces a sitios web dentro de textos, formas o medios
* Enlaces a diapositivas

Aspose.Slides for .NET le permite realizar muchas tareas relacionadas con hipervínculos en presentaciones. 

{{% alert color="info" %}} 
Es posible que quiera probar el editor de PowerPoint en línea gratuito y sencillo de Aspose, [free online PowerPoint editor.](https://products.aspose.app/slides/es/editor)
{{% /alert %}} 

## **Agregar hipervínculos URL**

### **Agregar hipervínculos URL a texto**

Este código C# muestra cómo añadir un hipervínculo a un sitio web en un texto:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Agregar hipervínculos URL a formas o marcos**

Este ejemplo de código en C# muestra cómo añadir un hipervínculo a un sitio web en una forma:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Agregar hipervínculos URL a medios**

Aspose.Slides le permite añadir hipervínculos a imágenes, archivos de audio y video. 

Este fragmento de código muestra cómo añadir un hipervínculo a una **imagen**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // Añade una imagen a la presentación
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Crea un marco de imagen en la diapositiva 1 basándose en la imagen añadida previamente
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Este fragmento de código muestra cómo añadir un hipervínculo a un **archivo de audio**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Este fragmento de código muestra cómo añadir un hipervínculo a un **vídeo**:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 
Es posible que quiera ver *[Manage OLE](https://docs.aspose.com/slides/es/net/manage-ole/)*.
{{% /alert %}}

## **Utilizar hipervínculos para crear una tabla de contenidos**

Dado que los hipervínculos le permiten añadir referencias a objetos o lugares, puede utilizarlos para crear una tabla de contenidos. 

Este fragmento de código muestra cómo crear una tabla de contenidos con hipervínculos:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Formato de los hipervínculos**

### **Color**

Con la propiedad [ColorSource](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/properties/colorsource) del interfaz [IHyperlink](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink), puede establecer el color de los hipervínculos y también obtener la información de color de los mismos. La característica se introdujo por primera vez en PowerPoint 2019, por lo que los cambios que implican esta propiedad no se aplican a versiones anteriores de PowerPoint.

Este fragmento de código demuestra una operación en la que se añadieron hipervínculos con colores distintos a la misma diapositiva:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```

### **Sonido**

Aspose.Slides proporciona estas propiedades para permitirle enfatizar un hipervínculo con un sonido:
- [IHyperlink.Sound](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Agregar un sonido al hipervínculo**

Este código C# muestra cómo configurar el hipervínculo para que reproduzca un sonido y lo detenga con otro hipervínculo:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Añade nuevo audio a la colección de audio de la presentación
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Añade una nueva forma con el hipervínculo a la siguiente diapositiva
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Comprueba el hipervínculo para "Sin sonido"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Establece el hipervínculo que reproduce sonido
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Añade la diapositiva vacía 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Añade una nueva forma con el hipervínculo NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Establece la bandera del hipervínculo "Detener sonido anterior"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Extraer el sonido de un hipervínculo**

Este código C# muestra cómo extraer el sonido utilizado en un hipervínculo:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtiene el hipervínculo de la primera forma
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrae el sonido del hipervínculo en un array de bytes
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Eliminar hipervínculos de presentaciones**

### **Eliminar hipervínculos de texto**

Este código C# muestra cómo eliminar el hipervínculo de un texto en una diapositiva de la presentación:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **Eliminar hipervínculos de formas o marcos**

Este código C# muestra cómo eliminar el hipervínculo de una forma en una diapositiva de la presentación:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Hipervínculo mutable**

La clase [Hyperlink](https://reference.aspose.com/slides/es/net/aspose.slides/hyperlink) es mutable. Con ella, puede cambiar los valores de estas propiedades:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlink/properties/highlightclick)

El fragmento de código muestra cómo añadir un hipervínculo a una diapositiva y editar su información sobre herramienta más adelante:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Propiedades admitidas en IHyperlinkQueries**

Puede acceder a IHyperlinkQueries desde una presentación, diapositiva o texto en el que se define el hipervínculo. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/properties/hyperlinkqueries)

La clase IHyperlinkQueries admite estos métodos y propiedades: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/es/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **Preguntas frecuentes**

### ¿Cómo puedo crear una navegación interna no solo a una diapositiva, sino a una "sección" o a la primera diapositiva de una sección?

Las secciones en PowerPoint agrupan diapositivas; la navegación técnicamente apunta a una diapositiva concreta. Para "navegar a una sección", normalmente se enlaza a su primera diapositiva.

### ¿Puedo adjuntar un hipervínculo a los elementos de la diapositiva maestra para que funcione en todas las diapositivas?

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. Estos enlaces aparecen en las diapositivas hijas y son clicables durante la presentación.

### ¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o vídeo?

En [PDF](/slides/es/net/convert-powerpoint-to-pdf/) y [HTML](/slides/es/net/convert-powerpoint-to-html/), sí: los enlaces generalmente se conservan. Al exportar a [imágenes](/slides/es/net/convert-powerpoint-to-png/) y [vídeo](/slides/es/net/convert-powerpoint-to-video/), la capacidad de hacer clic no se mantiene debido a la naturaleza de esos formatos (los fotogramas rasterizados y el vídeo no admiten hipervínculos).