---
title: Gerenciar hiperlinks de apresentação em Java
linktitle: Gerenciar hiperlink
type: docs
weight: 20
url: /pt/java/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hiperlink
- criar hiperlink
- formatar hiperlink
- remover hiperlink
- atualizar hiperlink
- hiperlink de texto
- hiperlink de slide
- hiperlink de forma
- hiperlink de imagem
- hiperlink de vídeo
- hiperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Gerencie hiperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para Java — aumente a interatividade e o fluxo de trabalho em minutos."
---
## **Introdução**

Um hiperlink é uma referência a um objeto, dado ou um local em algo. Estes são hiperlinks comuns em apresentações do PowerPoint:

* Links para sites dentro de textos, formas ou mídia
* Links para slides

Aspose.Slides for Java permite que você execute muitas tarefas envolvendo hiperlinks em apresentações. 

{{% alert color="info" %}} 
Você pode querer conferir o Aspose simples, [editor online gratuito de PowerPoint.](https://products.aspose.app/slides/pt/editor)
{{% /alert %}} 

## **Adicionar hiperlinks de URL**

### **Adicionar hiperlinks de URL ao texto**

Este código Java mostra como adicionar um hiperlink de site a um texto:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Adicionar hiperlinks de URL a formas ou quadros**

Este exemplo de código em Java mostra como adicionar um hiperlink de site a uma forma:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Adicionar hiperlinks de URL a mídia**

Aspose.Slides permite que você adicione hiperlinks a imagens, arquivos de áudio e vídeo. 

Este exemplo de código mostra como adicionar um hiperlink a uma **imagem**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Adiciona imagem à apresentação
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Cria quadro de imagem no slide 1 com base na imagem adicionada anteriormente
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Este exemplo de código mostra como adicionar um hiperlink a um **arquivo de áudio**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Este exemplo de código mostra como adicionar um hiperlink a um **vídeo**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Tip"  color="info"  %}} 
Você pode querer ver *[Gerenciar OLE](/slides/pt/java/manage-ole/)*.
{{% /alert %}}

## **Usar hiperlinks para criar um índice**

Como os hiperlinks permitem que você adicione referências a objetos ou locais, pode usá‑los para criar um índice. 

Este exemplo de código mostra como criar um índice com hiperlinks:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Formatar hiperlinks**

### **Cor**

Com a propriedade [ColorSource](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Hyperlink#setColorSource-int-) na interface [IHyperlink](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlink), você pode definir a cor dos hiperlinks e também obter informações de cor dos hiperlinks. O recurso foi introduzido pela primeira vez no PowerPoint 2019, portanto alterações envolvendo a propriedade não se aplicam a versões mais antigas do PowerPoint.

Este exemplo de código demonstra uma operação onde hiperlinks com cores diferentes foram adicionados ao mesmo slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Remover hiperlinks de apresentações**

### **Remover hiperlinks do texto**

Este código Java mostra como remover o hiperlink de um texto em um slide de apresentação:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Remover hiperlinks de formas ou quadros**

Este código Java mostra como remover o hiperlink de uma forma em um slide de apresentação: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Hiperlink mutável**

A classe [Hyperlink](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Hyperlink) é mutável. Com esta classe, você pode alterar os valores dessas propriedades:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

O trecho de código mostra como adicionar um hiperlink a um slide e editar seu tooltip posteriormente:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// Altera o tooltip do hyperlink que já foi adicionado
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Propriedades suportadas em IHyperlinkQueries**

Você pode acessar [IHyperlinkQueries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlinkQueries) a partir de uma apresentação, slide ou texto para o qual o hiperlink está definido. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

A classe [IHyperlinkQueries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlinkQueries) suporta estes métodos e propriedades: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

### Como posso criar navegação interna não apenas para um slide, mas para uma “seção” ou o primeiro slide de uma seção?

Seções no PowerPoint são agrupamentos de slides; a navegação tecnicamente aponta para um slide específico. Para “navegar até uma seção”, normalmente você cria um link para o primeiro slide da seção.

### Posso anexar um hiperlink a elementos do slide mestre para que ele funcione em todos os slides?

Sim. Elementos do slide mestre e de layout suportam hiperlinks. Esses links aparecem nos slides filhos e são clicáveis durante a apresentação.

### Os hiperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?

Em [PDF](/slides/pt/java/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/java/convert-powerpoint-to-html/), sim — os links geralmente são preservados. Ao exportar para [imagens](/slides/pt/java/convert-powerpoint-to-png/) e [vídeo](/slides/pt/java/convert-powerpoint-to-video/), a clicabilidade não será mantida devido à natureza desses formatos (quadros raster/vídeo não suportam hiperlinks).