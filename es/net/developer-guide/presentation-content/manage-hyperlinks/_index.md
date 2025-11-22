---
title: Administrar hipervínculos
type: docs
weight: 20
url: /es/net/manage-hyperlinks/
keywords: "Agregar hipervínculo, Presentación de PowerPoint, Hipervínculo de PowerPoint, hipervínculo de texto, hipervínculo de diapositiva, hipervínculo de forma, hipervínculo de imagen, hipervínculo de video, .NET, C#, Csharp"
description: "Agregar un hipervínculo a una presentación de PowerPoint en C# o .NET"
---

Un hipervínculo es una referencia a un objeto, datos o a un lugar en algo. Estos son hipervínculos comunes en presentaciones de PowerPoint:

* Enlaces a sitios web dentro de textos, formas o medios
* Enlaces a diapositivas

Aspose.Slides para .NET le permite realizar muchas tareas relacionadas con hipervínculos en presentaciones. 

{{% alert color="primary" %}} 

Puede que desee probar Aspose simple, [editor en línea gratuito de PowerPoint.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Agregar hipervínculos URL**

### **Agregar hipervínculos URL a textos**

Este código C# le muestra cómo agregar un hipervínculo a un sitio web en un texto:
```c#
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

Este código de ejemplo en C# le muestra cómo agregar un hipervínculo a un sitio web en una forma:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **Agregar hipervínculos URL a medios**

Aspose.Slides le permite agregar hipervínculos a imágenes, audio y archivos de video. 

Este código de ejemplo le muestra cómo agregar un hipervínculo a una **imagen**:
```c#
using (Presentation pres = new Presentation())
{
    // Agrega imagen a la presentación
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Crea un marco de imagen en la diapositiva 1 basado en la imagen agregada previamente
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


 Este código de ejemplo le muestra cómo agregar un hipervínculo a un **archivo de audio**:
```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


 Este código de ejemplo le muestra cómo agregar un hipervínculo a un **video**:
``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


{{%  alert  title="Tip"  color="primary"  %}} 

Puede que desee ver *[Administrar OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}


## **Usar hipervínculos para crear tabla de contenido**

Dado que los hipervínculos le permiten agregar referencias a objetos o lugares, puede utilizarlos para crear una tabla de contenido. 

Este código de ejemplo le muestra cómo crear una tabla de contenido con hipervínculos:
```c#
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


## **Formato de hipervínculos**

### **Color**

Con la propiedad [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) en la interfaz [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink), puede establecer el color para los hipervínculos y también obtener la información del color de los hipervínculos. La característica se introdujo por primera vez en PowerPoint 2019, por lo que los cambios relacionados con la propiedad no se aplican a versiones anteriores de PowerPoint.

Este código de ejemplo demuestra una operación donde se agregaron hipervínculos con diferentes colores a la misma diapositiva:
```c#
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
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Agregar sonido al hipervínculo**

Este código C# le muestra cómo establecer el hipervínculo que reproduce un sonido y detenerlo con otro hipervínculo:
```c#
using (Presentation pres = new Presentation())
{
	// Agrega nuevo audio a la colección de audio de la presentación
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Agrega una nueva forma con el hipervínculo a la siguiente diapositiva
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Verifica el hipervínculo para "Sin sonido"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Establece el hipervínculo que reproduce sonido
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Agrega la diapositiva vacía 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Agrega una nueva forma con el hipervínculo NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Establece la bandera "Detener sonido anterior" del hipervínculo
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **Extraer sonido del hipervínculo**

Este código C# le muestra cómo extraer el sonido usado en un hipervínculo:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtiene el hipervínculo de la primera forma
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrae el sonido del hipervínculo en un arreglo de bytes
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **Eliminar hipervínculos en presentaciones**

### **Eliminar hipervínculos de textos**

Este código C# le muestra cómo eliminar el hipervínculo de un texto en una diapositiva de presentación:
```c#
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

Este código C# le muestra cómo eliminar el hipervínculo de una forma en una diapositiva de presentación: 
``` csharp
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

La clase [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) es mutable. Con esta clase, puede cambiar los valores de estas propiedades:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

El fragmento de código muestra cómo agregar un hipervínculo a una diapositiva y editar su información sobre herramienta posteriormente:
```c#
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


## **Propiedades compatibles en IHyperlinkQueries**

Puede acceder a IHyperlinkQueries desde una presentación, diapositiva o texto para el cual está definido el hipervínculo. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

La clase IHyperlinkQueries admite estos métodos y propiedades: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**¿Cómo puedo crear una navegación interna no solo a una diapositiva, sino a una "sección" o a la primera diapositiva de una sección?**

Las secciones en PowerPoint son agrupaciones de diapositivas; la navegación técnicamente apunta a una diapositiva específica. Para "navegar a una sección", normalmente se enlaza a su primera diapositiva.

**¿Puedo adjuntar un hipervínculo a los elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de diseño admiten hipervínculos. Dichos enlaces aparecen en las diapositivas hijas y son clicables durante la presentación.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o video?**

En [PDF](/slides/es/net/convert-powerpoint-to-pdf/) y [HTML](/slides/es/net/convert-powerpoint-to-html/), sí—los enlaces generalmente se conservan. Al exportar a [imágenes](/slides/es/net/convert-powerpoint-to-png/) y [video](/slides/es/net/convert-powerpoint-to-video/), la capacidad de hacer clic no se mantendrá debido a la naturaleza de esos formatos (fotogramas rasterizados/video no admiten hipervínculos).