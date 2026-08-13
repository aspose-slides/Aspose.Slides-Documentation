---
title: Android'de Sunum Köprülerini Yönet
linktitle: Köprüyü Yönet
type: docs
weight: 20
url: /tr/androidjava/manage-hyperlinks/
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
- görüntü köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument sunumlarındaki köprüleri zahmetsizce yönetin—dakikalar içinde etkileşimi ve iş akışını artırın."
---
## **Giriş**

Bir köprü, bir nesneye, veriye veya bir şeydeki bir konuma referanstır. Bunlar PowerPoint Sunumlarında yaygın köprülerdir:

* Metinler, şekiller veya medya içinde web sitelerine bağlantılar
* Slaytlara bağlantılar

Aspose.Slides for Android via Java, sunumlardaki köprülerle ilgili pek çok görevi gerçekleştirmenizi sağlar.

{{% alert color="info" %}} 
Aspose basit, [ücretsiz çevrimiçi PowerPoint düzenleyicisini](https://products.aspose.app/slides/tr/editor) görmek isteyebilirsiniz.
{{% /alert %}} 

## **URL Bağlantılarını Ekle**

### **Metne URL Bağlantıları Ekle**

Bu Java kodu, bir metne web sitesi köprüsü eklemenizi gösterir:

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

### **Şekillere veya Çerçevelere URL Bağlantıları Ekle**

Bu Java örnek kodu, bir şekle web sitesi köprüsü eklemenizi gösterir:

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

### **Medyaya URL Köprüleri Ekle**

Aspose.Slides, görüntülere, ses ve video dosyalarına köprü eklemenize olanak tanır. 

Bu örnek kod, bir **görüntüye** köprü eklemenizi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Sunuma resmi ekler
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Daha önce eklenen resme dayalı olarak slayt 1'de resim çerçevesi oluşturur
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Bu örnek kod, bir **ses dosyasına** köprü eklemenizi gösterir:

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

Bu örnek kod, bir **video**ya köprü eklemenizi gösterir:

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
*[OLE Yönetimini](/slides/tr/androidjava/manage-ole/)* görmek isteyebilirsiniz.
{{% /alert %}}

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Köprüler nesnelere veya yerlere referans eklemenizi sağladığı için, bunları bir içindekiler tablosu oluşturmak için kullanabilirsiniz.

Bu örnek kod, köprülerle bir içindekiler tablosu oluşturmanızı gösterir:

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

## **Köprüleri Biçimlendirme**

### **Renk**

[ColorSource](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) özelliği, [IHyperlink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink) arayüzünde, köprülerin rengini ayarlamanıza ve köprülerden renk bilgisi almanıza olanak tanır. Bu özellik ilk kez PowerPoint 2019'da tanıtıldı, bu yüzden özellik ile ilgili değişiklikler eski PowerPoint sürümlerine uygulanmaz.

Bu örnek kod, farklı renklerdeki köprülerin aynı slayta eklendiği bir işlemi gösterir:

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

## **Sunumlardan Köprüleri Kaldırma**

### **Metinden Köprüleri Kaldırma**

Bu Java kodu, bir sunum slaydındaki metinden köprüyü kaldırmayı gösterir:

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

### **Şekillerden veya Çerçevelerden Köprüleri Kaldırma**

Bu Java kodu, bir sunum slaydındaki bir şekilden köprüyü kaldırmayı gösterir:

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

## **Değiştirilebilir Köprü**

[Hyperlink](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Hyperlink) sınıfı değiştirilebilir. Bu sınıf ile aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Kod snippet'i, bir slayta köprü eklemeyi ve daha sonra araç ipucunu düzenlemeyi gösterir:

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

	// Zaten eklenmiş olan köprünün araç ipucunu değiştirir
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries İçindeki Desteklenen Özellikler**

Köprünün tanımlandığı bir sunum, slayt veya metinden [IHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries) erişebilirsiniz.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries) sınıfı bu yöntemleri ve özellikleri destekler:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **SSS**

### Bir slayta değil, bir "bölüm"a ya da bir bölümün ilk slaytına iç navigasyon nasıl oluşturabilirim?

PowerPoint'te bölümler, slaytların gruplandırılmasıdır; navigasyon teknik olarak belirli bir slayta yönelir. Bir "bölüme" gitmek için genellikle onun ilk slaytına bağlanırsınız.

### Ana slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?

Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu bağlantılar alt slaytlarda görünür ve slayt gösterisi sırasında tıklanabilir.

### Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarılırken korunur mu?

PDF ve HTML dışa aktarmalarında ([PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/)), evet—bağlantılar genellikle korunur. Görüntü ([images](/slides/tr/androidjava/convert-powerpoint-to-png/)) ve video ([video](/slides/tr/androidjava/convert-powerpoint-to-video/)) dışa aktarmalarında, tıklanabilirlik bu formatların doğası gereği (raster kareler/video köprüleri desteklemez) taşınmaz.