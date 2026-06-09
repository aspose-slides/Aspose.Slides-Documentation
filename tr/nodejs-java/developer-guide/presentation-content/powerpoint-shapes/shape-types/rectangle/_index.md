---
title: JavaScript'te Sunumlara Dikdörtgen Ekle
linktitle: Dikdörtgen
type: docs
weight: 80
url: /tr/nodejs-java/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekli
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak dikdörtgen ekleyerek PowerPoint sunumlarınızı güçlendirin—şekilleri programatik olarak kolayca tasarlayın ve değiştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemeyi gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar.

Ayrıca, katı dolgu rengi, kenar rengi ve kenar kalınlığı gibi temel dikdörtgen biçimlendirmesini nasıl uygulayacağınızı göreceksiniz. Ayrıca, makalenin SSS bölümü, yuvarlatılmış köşeler, resim dolguları, görsel efektler, köprüler, şekil kilitlemeleri, dışa aktarma seçenekleri ve etkili özellikler gibi ilgili dikdörtgen görevlerine işaret eder.

## **Slayta Dikdörtgen Ekle**

Önceki konular gibi, bu da bir şekil eklemekle ilgilidir ve bu sefer tartışacağımız şekil Dikdörtgendir. Bu konuda, geliştiricilerin Aspose.Slides kullanarak slaytlarına basit veya biçimlendirilmiş dikdörtgenleri nasıl ekleyebileceğini açıkladık.

Sunumun seçili bir slaytına basit bir dikdörtgen eklemek için, lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak elde edin.
- Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) Rectangle tipinde, [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yöntemiyle ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaydına basit bir dikdörtgen ekledik.

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alın
    var sld = pres.getSlides().get_Item(0);
    // Elips tipinde AutoShape ekle
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // PPTX dosyasını diske yaz
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Slayta Biçimlendirilmiş Dikdörtgen Ekle**

Biçimlendirilmiş bir dikdörtgen eklemek için, lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak elde edin.
- Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) Rectangle tipinde, [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yöntemiyle ekleyin.
- Dikdörtgenin [Fill Type](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FillType) özelliğini Solid olarak ayarlayın.
- Dikdörtgenin rengini, [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape) nesnesiyle ilişkili [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FillFormat) nesnesi tarafından sunulan [SolidFillColor.setColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) yöntemiyle ayarlayın.
- Dikdörtgenin çizgi renklerini ayarlayın.
- Dikdörtgenin çizgi kalınlığını ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımlar aşağıda verilen örnekte uygulanmıştır.

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alın
    var sld = pres.getSlides().get_Item(0);
    // Elips tipinde AutoShape ekle
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Elips şekline bazı biçimlendirmeler uygulayın
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Elipsin çizgisine bazı biçimlendirmeler uygulayın
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX dosyasını diske yaz
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Dikdörtgene yuvarlatılmış köşeler nasıl eklenir?**

Yuvarlatılmış köşe [shape type](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapetype/) kullanın ve şeklin özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma, geometrik ayarlamalarla köşe başına da uygulanabilir.

**Dikdörtgeni bir görüntü (doku) ile nasıl doldururum?**

Resim [fill type](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) seçin, görüntü kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillmode/) yapılandırın.

**Dikdörtgen gölge ve parlaklık alabilir mi?**

Evet. [Outer/inner shadow, glow, and soft edges](/slides/tr/nodejs-java/shape-effect/) ayarlanabilir parametrelerle kullanılabilir.

**Dikdörtgeni bir köprü ile butona dönüştürebilir miyim?**

Evet. Şekle tıklandığında (bir slayta, dosyaya, web adresine veya e-postaya gitmek için) [Assign a hyperlink](/slides/tr/nodejs-java/manage-hyperlinks/) ekleyin.

**Dikdörtgeni hareketten ve değişikliklerden nasıl koruyabilirim?**

Şekil kilitlerini kullanın: yerleşimi korumak için taşıma, yeniden boyutlandırma, seçim veya metin düzenlemeyi yasaklayabilirsiniz.

**Dikdörtgeni raster görüntüye veya SVG'ye dönüştürebilir miyim?**

Evet. Şekli belirtilen boyut/ölçekle bir görüntüye [render the shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) edebilir veya vektör kullanımı için [export it as SVG](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/) yapabilirsiniz.

**Tema ve kalıtımı dikkate alarak bir dikdörtgenin gerçek (etkili) özelliklerini hızlıca nasıl alabilirim?**

[Use the shape’s effective properties](/slides/tr/nodejs-java/shape-effective-properties/): API, tema stilleri, düzen ve yerel ayarları dikkate alan hesaplanmış değerleri döndürerek biçimlendirme analizini basitleştirir.