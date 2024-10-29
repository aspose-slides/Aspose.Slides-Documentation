---
title: Administrar Hipervínculos
type: docs
weight: 20
url: /es/net/manage-hyperlinks/
keywords: "Agregar hipervínculo, Presentación de PowerPoint, Hipervínculo de PowerPoint, hipervínculo de texto, hipervínculo de diapositiva, hipervínculo de forma, hipervínculo de imagen, hipervínculo de video, .NET, C#, Csharp"
description: "Agregar hipervínculo a una Presentación de PowerPoint en C# o .NET"
---

Un hipervínculo es una referencia a un objeto, dato o lugar en algo. Estos son hipervínculos comunes en las Presentaciones de PowerPoint:

* Enlaces a sitios web dentro de textos, formas o medios
* Enlaces a diapositivas

Aspose.Slides para .NET te permite realizar muchas tareas que involucran hipervínculos en presentaciones.

{{% alert color="primary" %}} 

Puede que desees probar el sencillo y [gratuito editor de PowerPoint en línea de Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Agregar Hipervínculos URL**

### **Agregar Hipervínculos URL a Textos**

Este código C# muestra cómo agregar un hipervínculo a un sitio web a un texto:

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Más del 70% de las compañías Fortune 100 confían en las APIs de Aspose";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Agregar Hipervínculos URL a Formas o Marcos**

Este código de muestra en C# muestra cómo agregar un hipervínculo a un sitio web a una forma:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "Más del 70% de las compañías Fortune 100 confían en las APIs de Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Agregar Hipervínculos URL a Medios**

Aspose.Slides te permite agregar hipervínculos a imágenes, archivos de audio y video.

Este código de muestra muestra cómo agregar un hipervínculo a una **imagen**:

```c#
using (Presentation pres = new Presentation())
{
    // Agrega una imagen a la presentación
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Crea un marco de imagen en la diapositiva 1 basado en la imagen previamente agregada
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "Más del 70% de las compañías Fortune 100 confían en las APIs de Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Este código de muestra muestra cómo agregar un hipervínculo a un **archivo de audio**:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "Más del 70% de las compañías Fortune 100 confían en las APIs de Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Este código de muestra muestra cómo agregar un hipervínculo a un **video**:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "Más del 70% de las compañías Fortune 100 confían en las APIs de Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Consejo"  color="primary"  %}} 

Puede que desees ver *[Administrar OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}


## **Usar Hipervínculos para Crear Índices**

Dado que los hipervínculos te permiten agregar referencias a objetos o lugares, puedes usarlos para crear un índice.

Este código de muestra muestra cómo crear un índice con hipervínculos:

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
    paragraph.Text = "Título de la diapositiva 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Página 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Formatear Hipervínculos**

### **Color**

Con la propiedad [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) en la interfaz [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink), puedes establecer el color para los hipervínculos y también obtener la información de color de los hipervínculos. La función se introdujo por primera vez en PowerPoint 2019, por lo que los cambios que involucran la propiedad no se aplican a versiones anteriores de PowerPoint.

Este código de muestra demuestra una operación donde se agregaron hipervínculos con diferentes colores a la misma diapositiva:

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("Este es un ejemplo de hipervínculo coloreado.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("Este es un ejemplo de hipervínculo habitual.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **Sonido**

Aspose.Slides proporciona estas propiedades para permitirte enfatizar un hipervínculo con un sonido:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Agregar Sonido a Hipervínculo**

Este código C# muestra cómo establecer el hipervínculo que reproduce un sonido y detenerlo con otro hipervínculo:

```c#
using (Presentation pres = new Presentation())
{
	// Agrega nuevo audio a la colección de audio de la presentación
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Agrega nueva forma con el hipervínculo a la siguiente diapositiva
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Verifica el hipervínculo para "Sin Sonido"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Establece el hipervínculo que reproduce sonido
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Agrega la diapositiva vacía 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Agrega nueva forma con el hipervínculo sin acción
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Establece la marca del hipervínculo "Detener sonido anterior"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Extraer Sonido de Hipervínculo**

Este código C# muestra cómo extraer el sonido utilizado en un hipervínculo:

```c#
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

## **Eliminar Hipervínculos en Presentaciones**

### **Eliminar Hipervínculos de Textos**

Este código C# muestra cómo eliminar el hipervínculo de un texto en una diapositiva de presentación:

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

### **Eliminar Hipervínculos de Formas o Marcos**

Este código C# muestra cómo eliminar el hipervínculo de una forma en una diapositiva de presentación:

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

## **Hipervínculo Mutable**

La clase [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) es mutable. Con esta clase, puedes cambiar los valores de estas propiedades:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

El fragmento de código muestra cómo agregar un hipervínculo a una diapositiva y editar su tooltip más tarde:

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Más del 70% de las compañías Fortune 100 confían en las APIs de Aspose";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Propiedades Admitidas en IHyperlinkQueries**

Puedes acceder a IHyperlinkQueries desde una presentación, diapositiva o texto para el cual se ha definido el hipervínculo.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

La clase IHyperlinkQueries admite estos métodos y propiedades: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)