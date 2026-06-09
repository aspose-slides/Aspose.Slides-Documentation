---
title: Sunumlarda JavaScript ile Yazı Tiplerini Yönetme
linktitle: Yazı Tiplerini Yönet
type: docs
weight: 10
url: /tr/nodejs-java/manage-fonts/
keywords:
- yazı tiplerini yönet
- yazı tipi özellikleri
- paragraf
- metin biçimlendirme
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile yazı tiplerini kontrol edin: özel yazı tiplerini yerleştirin, değiştirin ve yükleyin, PPT, PPTX ve ODP sunumlarının net ve tutarlı kalmasını sağlayın."
---
## **Giriş**

Sunumlar genellikle hem metin hem de görüntü içerir. Metin, belirli bölümleri ve kelimeleri vurgulamak ya da kurumsal stillere uygun hale getirmek için çeşitli şekillerde biçimlendirilebilir. Metin biçimlendirme, kullanıcıların sunum içeriğinin görünüm ve hissini çeşitlendirmesine yardımcı olur. Bu makale, Aspose.Slides for Node.js via Java kullanarak slaytlardaki metin paragraflarının yazı tipi özelliklerini nasıl yapılandırabileceğinizi gösterir.

## **Yazı Tipi ile İlgili Özellikleri Yönetme**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksini kullanarak elde edin.  
1. Slayd içindeki [Placeholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholder/) şekillerine erişin ve bunları [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) tipine dönüştürün.  
1. [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) tarafından sunulan [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) içinden [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) alın.  
1. Paragrafı iki yana hizalayın.  
1. Bir [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) metninin [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) öğesine erişin.  
1. [FontData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontdata/) kullanarak yazı tipini tanımlayın ve metin [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) **Font** özelliğini buna göre ayarlayın.  
   1. Yazı tipini kalın yapın.  
   1. Yazı tipini italik yapın.  
1. [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) nesnesi tarafından sunulan [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/) kullanarak yazı tipi rengini ayarlayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir. Bu, süslü olmayan bir sunumu alır ve slaytlardan birindeki yazı tiplerini biçimlendirir. Aşağıdaki ekran görüntüleri giriş dosyasını ve kod parçacıklarının nasıl değiştirdiğini gösterir. Kod, yazı tipini, rengi ve yazı tipi stilini değiştirir.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Şekil: Giriş dosyasındaki metin**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Şekil: Güncellenmiş biçimlendirmeye sahip aynı metin**|

```javascript
// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturun
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Slayt konumunu kullanarak bir slayta erişme
    var slide = pres.getSlides().get_Item(0);
    // Slayttaki birinci ve ikinci yer tutucuya erişerek AutoShape olarak tip dönüştürme
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // İlk Paragraph'a erişme
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Paragrafı iki yana hizala
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // İlk portion'a erişme
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Yeni yazı tiplerini tanımla
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Yeni yazı tiplerini portion'a ata
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Yazı tipini Kalın olarak ayarla
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Yazı tipini İtalik olarak ayarla
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Yazı tipi rengini ayarla
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // PPTX dosyasını diske kaydet
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Metin Yazı Tipi Özelliklerini Ayarlama**
{{% alert color="primary" %}} 

Yukarıda **Yazı Tipi ile İlgili Özellikleri Yönetme** bölümünde belirtildiği gibi, bir [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) paragrafta benzer biçimlendirme stiline sahip metni tutmak için kullanılır. Bu makale, Aspose.Slides for Node.js via Java kullanarak bir metin kutusu oluşturmayı ve ardından belirli bir yazı tipini ve yazı tipi ailesi kategorisinin çeşitli diğer özelliklerini tanımlamayı gösterir.

{{% /alert %}} 

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksini kullanarak elde edin.  
1. Slayta **Rectangle** tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.  
1. [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ile ilişkilendirilmiş doldurma stilini kaldırın.  
1. [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/)’ın [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.  
1. [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) içine bir metin ekleyin.  
1. [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) ile ilişkili [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) nesnesine erişin.  
1. [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) için kullanılacak yazı tipini tanımlayın.  
1. [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) nesnesi tarafından sunulan ilgili özellikleri kullanarak kalın, italik, altı çizili, renk ve yükseklik gibi diğer yazı tipi özelliklerini ayarlayın.  
1. Değiştirilen sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Şekil: Aspose.Slides for Node.js via Java tarafından ayarlanan bazı yazı tipi özelliklerine sahip metin**|

```javascript
// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturun
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Rectangle tipinde bir AutoShape ekle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // AutoShape ile ilişkili herhangi bir doldurma stilini kaldır
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // AutoShape ile ilişkili TextFrame'e eriş
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // TextFrame ile ilişkili Portion'a eriş
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Portion için Font'u ayarla
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Fontun Kalın özelliğini ayarla
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Fontun İtalik özelliğini ayarla
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Fontun Altı Çizili özelliğini ayarla
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Fontun Yüksekliğini ayarla
    port.getPortionFormat().setFontHeight(25);
    // Fontun rengini ayarla
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Sunumu diske kaydet
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```