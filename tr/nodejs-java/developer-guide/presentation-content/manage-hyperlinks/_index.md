---
title: JavaScript'te Sunum Köprülerini Yönet
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/nodejs-java/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprü biçimlendir
- köprü kaldır
- köprü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- görsel köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint ve OpenDocument sunumlarında köprüleri zahmetsizce yönetin—etkileşimi ve iş akışını dakikalar içinde artırın."
---
## **Giriş**

Bir köprü, bir nesneye, veriye veya bir şey içinde bir konuma referanstır. Bunlar PowerPoint Sunumlarında yaygın köprülerdir:

* Metinler, şekiller veya medya içinde web sitelerine bağlantılar
* Slaytlara bağlantılar

Aspose.Slides for Node.js via Java, sunumlardaki köprülerle ilgili birçok görevi gerçekleştirmenizi sağlar.

{{% alert color="primary" %}} 
Aspose basit, [ücretsiz çevrimiçi PowerPoint düzenleyicisi.](https://products.aspose.app/slides/tr/editor) incelemek isteyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

### **Metinlere URL Köprüleri Ekleme**

Bu JavaScript kodu, bir metne web sitesi köprüsü eklemenizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Şekillere veya Çerçevelere URL Köprüleri Ekleme**

Bu JavaScript örnek kodu, bir şekle web sitesi köprüsü eklemenizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Medyaya URL Köprüleri Ekleme**

Aspose.Slides, resimlere, ses ve video dosyalarına köprü eklemenize olanak tanır.

Bu örnek kod, bir **görsele** köprü eklemenizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma görüntü ekler
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Daha önce eklenen görüntüyü temel alarak slayt 1'de resim çerçevesi oluşturur
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bu örnek kod, bir **ses dosyasına** köprü eklemenizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bu örnek kod, bir **videoya** köprü eklemenizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
Şu bağlantıyı görmek isteyebilirsiniz *[OLE Yönetimi](/slides/tr/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Köprüler nesnelere veya konumlara referans eklemenizi sağladığından, bunları bir içindekiler tablosu oluşturmak için kullanabilirsiniz.

Bu örnek kod, köprülerle bir içindekiler tablosu oluşturmanızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Köprüleri Biçimlendirme**

### **Renk**

Bu [Hyperlink](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink) sınıfındaki [setColorSource](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) yöntemiyle, köprülerin rengini ayarlayabilir ve köprülerden renk bilgisi alabilirsiniz. Özellik ilk olarak PowerPoint 2019'da tanıtıldı, bu nedenle özelliği etkileyen değişiklikler eski PowerPoint sürümlerine uygulanmaz.

Bu örnek kod, farklı renklere sahip köprülerin aynı slayta eklendiği bir işlemi göstermektedir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumlardan Köprüleri Kaldırma**

### **Metinlerden Köprüleri Kaldırma**

Bu JavaScript kodu, bir sunum slaydındaki metinden köprüyü nasıl kaldıracağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Metin çerçevesindeki paragrafları döngüyle iterasyon eder
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Paragraftaki her bölümü döngüyle iterasyon eder
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Metni değiştirir
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Biçimlendirmeyi değiştirir
                    }
                }
            }
        }
    }
    // Değiştirilmiş sunumu kaydeder
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Şekillerden veya Çerçevelerden Köprüleri Kaldırma**

Bu JavaScript kodu, bir sunum slaydındaki şekilden köprüyü nasıl kaldıracağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Değiştirilebilir Köprü**

[Hyperlink](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink) sınıfı değiştirilebilir. Bu sınıfla, aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Kod parçacığı, bir slayta köprü eklemeyi ve daha sonra araç ipucunu düzenlemeyi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **IHyperlinkQueries İçindeki Desteklenen Özellikler**

Bir sunum, slayt veya köprünün tanımlı olduğu metinden [HyperlinkQueries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries)'e erişebilirsiniz.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

[HyperlinkQueries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries) sınıfı bu yöntemleri ve özellikleri destekler:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **SSS**

**Bir slayta değil, bir "bölüm"e veya bölümün ilk slaytına iç navigasyon nasıl oluşturabilirim?**

PowerPoint'teki bölümler, slaytların gruplandırılmasıdır; navigasyon teknik olarak belirli bir slayta yönelir. "Bir bölüme" gitmek için genellikle onun ilk slaytına bağlantı verirsiniz.

**Usta slayt elemanlarına bir köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Usta slayt ve düzen elemanları köprüleri destekler. Bu tür bağlantılar alt slaytlarda görünür ve sunum sırasında tıklanabilir.

**PDF, HTML, resimler veya video olarak dışa aktarırken köprüler korunacak mı?**

[PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) içinde, evet—bağlantılar genellikle korunur. [Resimler](/slides/tr/nodejs-java/convert-powerpoint-to-png/) ve [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) olarak dışa aktarırken, bu formatların doğası gereği tıklanabilirlik taşınmaz (raster çerçeveler/video köprüleri desteklemez).