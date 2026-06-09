---
title: Android'de Sunum Hipermetin Bağlantılarını Yönetme
linktitle: Hipermetin Bağlantısını Yönet
type: docs
weight: 20
url: /tr/androidjava/manage-hyperlinks/
keywords:
- URL ekle
- hipermetin bağlantısı ekle
- hipermetin bağlantısı oluştur
- hipermetin bağlantısını biçimlendir
- hipermetin bağlantısını kaldır
- hipermetin bağlantısını güncelle
- metin hipermetin bağlantısı
- slayt hipermetin bağlantısı
- şekil hipermetin bağlantısı
- görüntü hipermetin bağlantısı
- video hipermetin bağlantısı
- değiştirilebilir hipermetin bağlantısı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument sunumlarındaki hipermetin bağlantılarını zahmetsizce yönetin—interaktiviteyi ve iş akışını dakikalar içinde artırın."
---
## **Giriş**

Bir hipermetin bağlantısı, bir nesneye, veriye veya bir konuma referanstır. PowerPoint Sunumlarında yaygın hipermetin bağlantıları şunlardır:

* Metin, şekil veya medya içinde web sitelerine bağlantılar
* Slaytlara bağlantılar

Aspose.Slides for Android via Java, sunumlardaki hipermetin bağlantılarıyla ilgili birçok görevi gerçekleştirmenizi sağlar.

{{% alert color="primary" %}} 
Aspose basit, [Ücretsiz çevrimiçi PowerPoint editörü](https://products.aspose.app/slides/tr/editor) incelemek isteyebilirsiniz.
{{% /alert %}} 

## **URL Hipermetin Bağlantılarını Ekle**

### **Metne URL Hipermetin Bağlantısı Ekle**

Bu Java kodu, bir metne web sitesi hipermetin bağlantısı eklemenizi gösterir:

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

### **Şekillere veya Çerçevelere URL Hipermetin Bağlantısı Ekle**

Bu Java örnek kodu, bir şekle web sitesi hipermetin bağlantısı eklemenizi gösterir:

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

### **Medyaya URL Hipermetin Bağlantısı Ekle**

Aspose.Slides, görüntülere, ses ve video dosyalarına hipermetin bağlantısı eklemenizi sağlar. 

Bu örnek kod bir **görüntüye** hipermetin bağlantısı eklemeyi gösterir:

```java
Presentation pres = new Presentation();
try {
	// Sunuma görüntü ekler
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Daha önce eklenen görüntüye dayanarak slayt 1'de resim çerçevesi oluşturur
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Bu örnek kod bir **ses dosyasına** hipermetin bağlantısı eklemeyi gösterir:

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

Bu örnek kod bir **videoya** hipermetin bağlantısı eklemeyi gösterir:

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

{{% alert title="İpucu" color="primary" %}} 
*[OLE Yönetimi](/slides/tr/androidjava/manage-ole/)* sayfasına bakmak isteyebilirsiniz.
{{% /alert %}}

## **İçindekiler Tablosu Oluşturmak İçin Hipermetin Bağlantılarını Kullanma**

Hipermetin bağlantıları nesnelere veya konumlara referans eklemenizi sağladığından, bunları bir içindekiler tablosu oluşturmak için kullanabilirsiniz. 

Bu örnek kod, hipermetin bağlantılarıyla bir içindekiler tablosu oluşturmayı gösterir:

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

## **Hipermetin Bağlantılarını Biçimlendirme**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink) arayüzündeki [ColorSource](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) özelliğiyle hipermetin bağlantılarının rengini ayarlayabilir ve renk bilgisini alabilirsiniz. Bu özellik PowerPoint 2019’da ilk kez tanıtıldı; bu yüzden özellikteki değişiklikler daha eski PowerPoint sürümlerine uygulanmaz.

Bu örnek kod, aynı slayta farklı renklerde hipermetin bağlantıları eklenmesini gösterir:

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

## **Sunumlardan Hipermetin Bağlantılarını Kaldırma**

### **Metinden Hipermetin Bağlantılarını Kaldırma**

Bu Java kodu, bir sunum slaydındaki metinden hipermetin bağlantısını kaldırmanızı gösterir:

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

### **Şekillerden veya Çerçevelerden Hipermetin Bağlantılarını Kaldırma**

Bu Java kodu, bir sunum slaydındaki bir şekilden hipermetin bağlantısını kaldırmanızı gösterir: 

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

## **Değiştirilebilir Hipermetin Bağlantısı**

[Hyperlink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Hyperlink) sınıfı değiştirilebilir. Bu sınıfla aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Kod parçacığı, bir slayta hipermetin bağlantısı eklemeyi ve sonradan araç ipucunu düzenlemeyi gösterir:

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

## **IHyperlinkQueries İçin Desteklenen Özellikler**

Bir sunum, slayt veya metin üzerinden tanımlı hipermetin bağlantısı için [IHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries) erişebilirsiniz.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries) sınıfı aşağıdaki yöntem ve özellikleri destekler:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **SSS**

**Bir slayda değil, bir “bölüm”e veya bir bölümün ilk slaytına iç navigasyon nasıl oluşturabilirim?**

PowerPoint’te bölümler, slayt gruplarıdır; navigasyon teknik olarak belirli bir slayta yönelir. “Bir bölüme gitmek” için genellikle onun ilk slaytına bağlanırsınız.

**Ana slayt öğelerine hipermetin bağlantısı ekleyebilir miyim, böylece tüm slaytlarda çalışsın?**

Evet. Ana slayt ve düzen öğeleri hipermetin bağlantılarını destekler. Bu bağlantılar alt slaytlarda görünür ve sunum sırasında tıklanabilir.

**Hipermetin bağlantıları PDF, HTML, görüntü veya video olarak dışa aktarılırken korunur mu?**

[PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) dışa aktarmalarında genellikle bağlantılar korunur. [Görüntüler](/slides/tr/androidjava/convert-powerpoint-to-png/) ve [video](/slides/tr/androidjava/convert-powerpoint-to-video/) dışa aktarmalarında ise tıklanabilirlik, bu formatların raster kare/video yapısı nedeniyle taşınmaz.