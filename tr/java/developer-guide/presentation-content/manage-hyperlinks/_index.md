---
title: "Java'da Sunum Köprülerini Yönetme"
linktitle: "Köprüyü Yönet"
type: docs
weight: 20
url: /tr/java/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprüyü biçimlendir
- köprüyü kaldır
- köprüyü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- görsel köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarındaki köprüleri zahmetsizce yönetin—etkileşimi ve iş akışını dakikalar içinde geliştirin."
---
## **Giriş**

Bir köprü, bir nesneye, veriye ya da bir yere referanstır. Bunlar PowerPoint Sunularında yaygın köprülerdir:

* Metin, şekil veya medya içindeki web sitesi bağlantıları
* Slaytlara bağlantılar

Aspose.Slides for Java, sunularda köprülerle ilgili birçok görevi gerçekleştirmenizi sağlar. 

{{% alert color="primary" %}} 

Aspose basit, [ücretsiz çevrimiçi PowerPoint düzenleyicisini](https://products.aspose.app/slides/tr/editor) incelemek isteyebilirsiniz.

{{% /alert %}} 

## **URL Köprüleri Ekleme**

### **Metne URL Köprüleri Ekleme**

Bu Java kodu, bir metne web sitesi köprüsü eklemenizi gösterir:

```java
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

### **Şekillere veya Çerçevelere URL Köprüleri Ekleme**

Bu örnek Java kodu, bir şekle web sitesi köprüsü eklemenizi gösterir:

```java
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

### **Medyaya URL Köprüleri Ekleme**

Aspose.Slides, görüntülere, ses ve video dosyalarına köprü eklemenizi sağlar. 

Bu örnek kod, bir **görüntüye** köprü eklemenizi gösterir:

```java
Presentation pres = new Presentation();
try {
	// Sunuma resim ekler
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Daha önce eklenen resme dayanarak slayt 1'de resim çerçevesi oluşturur
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Bu örnek kod, bir **ses dosyasına** köprü eklemenizi gösterir:

```java
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

Bu örnek kod, bir **video**ya köprü eklemenizi gösterir:

```java
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

{{%  alert  title="Tip"  color="primary"  %}} 

Şu sayfaya bakmak isteyebilirsiniz *[OLE Yönetimi](/slides/tr/java/manage-ole/)*.

{{% /alert %}}

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Köprüler nesnelere veya yerlere referans eklemenizi sağladığı için, bunları bir içindekiler tablosu oluşturmakta kullanabilirsiniz. 

Bu örnek kod, köprülerle bir içindekiler tablosu oluşturmanızı gösterir:

```java
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

## **Köprüleri Biçimlendirme**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlink) arayüzündeki [ColorSource](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Hyperlink#setColorSource-int-) özelliği ile köprülerin rengini ayarlayabilir ve köprülerin renk bilgisini alabilirsiniz. Bu özellik ilk kez PowerPoint 2019'da tanıtıldı, bu yüzden özelliği etkileyen değişiklikler eski PowerPoint sürümlerine uygulanmaz.

Bu örnek kod, farklı renklerde köprülerin aynı slayta eklendiği bir işlemi gösterir:

```java
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

## **Sunumlardan Köprüleri Kaldırma**

### **Metinden Köprüleri Kaldırma**

Bu Java kodu, bir sunum slaydındaki metinden köprüyü kaldırmanızı gösterir:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
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

### **Şekillerden veya Çerçevelerden Köprüleri Kaldırma**

Bu Java kodu, bir sunum slaydındaki bir şekilden köprüyü kaldırmanızı gösterir: 

```java
Presentation pres = new Presentation();
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

## **Değiştirilebilir Köprü**

[Hyperlink](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Hyperlink) sınıfı değiştirilebilir. Bu sınıf ile aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Bu kod parçacığı, bir slayta köprü eklemenizi ve daha sonra araç ipucunu düzenlemenizi gösterir:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries içinde Desteklenen Özellikler**

Köprünün tanımlı olduğu bir sunum, slayt veya metinden [IHyperlinkQueries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlinkQueries) öğesine erişebilirsiniz. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlinkQueries) sınıfı şu yöntem ve özellikleri destekler: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **SSS**

**Bir slayta değil, bir "bölüm"e veya bir bölümün ilk slaytına iç gezinme nasıl oluşturabilirim?**  

PowerPoint'teki bölümler, slaytların gruplandırılmalarıdır; gezinme teknik olarak belirli bir slayta hedeflenir. "Bir bölüme gezinmek" için genellikle bölümün ilk slaytına bağlanırsınız.

**Ana slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**  

Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu tür bağlantılar alt slaytlarda görünür ve sunum sırasında tıklanabilir.

**PDF, HTML, görüntüler veya video olarak dışa aktarırken köprüler korunur mu?**  

[PDF](/slides/tr/java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/java/convert-powerpoint-to-html/) formatlarında evet—bağlantılar genellikle korunur. [Görüntüler](/slides/tr/java/convert-powerpoint-to-png/) ve [video](/slides/tr/java/convert-powerpoint-to-video/) formatlarına dışa aktarırken, bu formatların doğası gereği (raster çerçeveler/video köprüleri desteklemez) tıklanabilirlik taşınmaz.