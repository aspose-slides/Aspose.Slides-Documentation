---
title: Gerenciar hyperlinks de apresentação em .NET
linktitle: Gerenciar hyperlink
type: docs
weight: 20
url: /pt/net/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hyperlink
- criar hyperlink
- formatar hyperlink
- remover hyperlink
- atualizar hyperlink
- hyperlink de texto
- hyperlink de slide
- hyperlink de forma
- hyperlink de imagem
- hyperlink de vídeo
- hyperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie hyperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para .NET de forma fácil—melhore a interatividade e o fluxo de trabalho em minutos."
---
## **Introdução**

Um hyperlink é uma referência a um objeto, dado ou a um local em algo. Estes são hyperlinks comuns em Apresentações do PowerPoint:

* Links para sites dentro de textos, formas ou mídias
* Links para slides

Aspose.Slides for .NET permite que você execute muitas tarefas envolvendo hyperlinks em apresentações. 

{{% alert color="primary" %}} 

Você pode querer conferir o Aspose Simple, [editor online gratuito de PowerPoint.](https://products.aspose.app/slides/pt/editor)

{{% /alert %}} 

## **Adicionar hyperlinks de URL**

### **Adicionar hyperlinks de URL ao texto**

Este código C# mostra como adicionar um hyperlink de site a um texto:

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

### **Adicionar hyperlinks de URL a formas ou quadros**

Este código de exemplo em C# mostra como adicionar um hyperlink de site a uma forma:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Adicionar hyperlinks de URL a mídia**

Aspose.Slides permite que você adicione hyperlinks a imagens, arquivos de áudio e vídeo. 

Este código de exemplo mostra como adicionar um hyperlink a uma **imagem**:

```c#
using (Presentation pres = new Presentation())
{
    // Adiciona imagem à apresentação
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Cria quadro de imagem no slide 1 com base na imagem adicionada anteriormente
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Este código de exemplo mostra como adicionar um hyperlink a um **arquivo de áudio**:

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

Este código de exemplo mostra como adicionar um hyperlink a um **vídeo**:

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

Você pode querer ver *[Gerenciar OLE](https://docs.aspose.com/slides/pt/net/manage-ole/)*.

{{% /alert %}}


## **Usar hyperlinks para criar um índice**

Como os hyperlinks permitem adicionar referências a objetos ou locais, você pode usá‑los para criar um índice. 

Este código de exemplo mostra como criar um índice com hyperlinks:

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

## **Formatar hyperlinks**

### **Cor**

Com a propriedade [ColorSource](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/properties/colorsource) na interface [IHyperlink](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink), você pode definir a cor dos hyperlinks e também obter as informações de cor dos hyperlinks. O recurso foi introduzido pela primeira vez no PowerPoint 2019, portanto alterações envolvendo a propriedade não se aplicam a versões anteriores do PowerPoint.

Este código de exemplo demonstra uma operação onde hyperlinks com cores diferentes foram adicionados ao mesmo slide:

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
### **Som**

Aspose.Slides fornece estas propriedades para permitir que você enfatize um hyperlink com um som:
- [IHyperlink.Sound](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Adicionar som a um hyperlink**

Este código C# mostra como definir o hyperlink que reproduz um som e pará‑lo com outro hyperlink:

```c#
using (Presentation pres = new Presentation())
{
	// Adiciona novo áudio à coleção de áudio da apresentação
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Adiciona nova forma com o hyperlink para o próximo slide
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Verifica o hyperlink para "No Sound"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Define o hyperlink que reproduz som
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Adiciona o slide vazio 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Adiciona nova forma com o hyperlink NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Define a flag do hyperlink "Stop previous sound"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Extrair som de um hyperlink**

Este código C# mostra como extrair o som usado em um hyperlink:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtém o hyperlink da primeira forma
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrai o som do hyperlink em array de bytes
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Remover hyperlinks de apresentações**

### **Remover hyperlinks de texto**

Este código C# mostra como remover o hyperlink de um texto em um slide de apresentação:

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

### **Remover hyperlinks de formas ou quadros**

Este código C# mostra como remover o hyperlink de uma forma em um slide de apresentação: 

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

## **Hyperlink mutável**

A classe [Hyperlink](https://reference.aspose.com/slides/pt/net/aspose.slides/hyperlink) é mutável. Com esta classe, você pode alterar os valores dessas propriedades:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/properties/highlightclick)

O trecho de código mostra como adicionar um hyperlink a um slide e editar seu tooltip posteriormente:

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

## **Propriedades suportadas em IHyperlinkQueries**

Você pode acessar IHyperlinkQueries a partir de uma apresentação, slide ou texto para o qual o hyperlink está definido. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/properties/hyperlinkqueries)

A classe IHyperlinkQueries suporta estes métodos e propriedades: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **Perguntas frequentes**

**Como posso criar navegação interna não apenas para um slide, mas para uma "seção" ou o primeiro slide de uma seção?**

Seções no PowerPoint são agrupamentos de slides; a navegação tecnicamente aponta para um slide específico. Para "navegar para uma seção", normalmente você vincula ao seu primeiro slide.

**Posso anexar um hyperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos do slide mestre e layouts suportam hyperlinks. Esses links aparecem nos slides filhos e são clicáveis durante a apresentação de slides.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Em [PDF](/slides/pt/net/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/net/convert-powerpoint-to-html/), sim — os links geralmente são preservados. Ao exportar para [imagens](/slides/pt/net/convert-powerpoint-to-png/) e [vídeo](/slides/pt/net/convert-powerpoint-to-video/), a capacidade de clique não será mantida devido à natureza desses formatos (quadros raster/vídeo não suportam hyperlinks).