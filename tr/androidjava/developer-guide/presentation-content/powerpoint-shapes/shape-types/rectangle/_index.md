---
title: Android'de Sunumlara Dikdörtgen Ekle
linktitle: Dikdörtgen
type: docs
weight: 80
url: /tr/androidjava/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekil
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarınızı dikdörtgenler ekleyerek güçlendirin—şekilleri programlı olarak kolayca tasarlayın ve değiştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemeyi gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenen sunumu PPTX dosyası olarak kaydetmeyi kapsar.

Ayrıca, bir katı dolgu rengi, kenar rengi ve kenar genişliği gibi temel dikdörtgen biçimlendirmesinin nasıl uygulanacağını da göreceksiniz. Ayrıca, makalenin SSS bölümü, yuvarlatılmış köşeler, resim dolguları, görsel efektler, köprüler, şekil kilitleri, dışa aktarma seçenekleri ve etkili özellikler gibi ilgili dikdörtgen görevlerine işaret eder.

## **Bir Slayta Dikdörtgen Ekle**
Sunumun seçili bir slaytına basit bir dikdörtgen eklemek için, lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- İndeksini kullanarak bir slaydın referansını alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metodunu kullanarak Dikdörtgen türünde bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) ekleyin.
- Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaytına basit bir dikdörtgen ekledik.

```java
// PPTX'i temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Elips türünde AutoShape ekle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX dosyasını diske yaz
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Slayta Biçimlendirilmiş Dikdörtgen Ekle**
Bir slayta biçimlendirilmiş bir dikdörtgen eklemek için, lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- İndeksini kullanarak bir slaydın referansını alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metodunu kullanarak Dikdörtgen türünde bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) ekleyin.
- Dikdörtgenin [Fill Type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FillType) özelliğini Solid olarak ayarlayın.
- [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape) nesnesiyle ilişkili [IFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IFillFormat) nesnesi tarafından sunulan [SolidFillColor.setColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) metodunu kullanarak Dikdörtgenin rengini ayarlayın.
- Dikdörtgenin kenarlarının rengini ayarlayın.
- Dikdörtgenin kenarlarının genişliğini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımlar aşağıda verilen örnekte uygulanmıştır.

```java
// PPTX'i temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Elips türünde AutoShape ekle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Elips şekline bazı biçimlendirmeler uygula
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Elipsin çizgisine bazı biçimlendirmeler uygula
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX dosyasını diske yaz
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Yuvarlatılmış köşeli bir dikdörtgen nasıl eklenir?**

Yuvarlatılmış köşe [shape type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapetype/) kullanın ve şeklin özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma, geometrik ayarlamalarla köşe bazında da uygulanabilir.

**Bir dikdörtgeni resim (doku) ile nasıl doldururum?**

Resim [fill type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) seçin, görüntü kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturefillmode/) yapılandırın.

**Bir dikdörtgen gölge ve parıltı alabilir mi?**

Evet. Ayarlanabilir parametrelerle [Outer/inner shadow, glow, and soft edges](/slides/tr/androidjava/shape-effect/) mevcuttur.

**Bir dikdörtgeni köprü içeren bir düğmeye dönüştürebilir miyim?**

Evet. Şekle tıklama (slayta, dosyaya, web adresine veya e-postaya atlama) için [Assign a hyperlink](/slides/tr/androidjava/manage-hyperlinks/) ekleyin.

**Bir dikdörtgeni hareketten ve değişikliklerden nasıl korurum?**

Şekil kilitlerini kullanın: düzeni korumak için hareket, yeniden boyutlandırma, seçim veya metin düzenlemesini engelleyebilirsiniz.

**Bir dikdörtgeni raster görüntüye veya SVG'ye dönüştürebilir miyim?**

Evet. Şekli belirtilen boyut/ölçekle bir görüntüye [render the shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) yapabilir veya vektör kullanım için [export it as SVG](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) edebilirsiniz.

**Tema ve kalıtımı göz önünde bulundurarak bir dikdörtgenin gerçek (etkin) özelliklerini hızlıca nasıl alırım?**

[Use the shape’s effective properties](/slides/tr/androidjava/shape-effective-properties/): API, tema stilleri, yerleşim ve yerel ayarları hesaba katan hesaplanmış değerleri döndürerek biçimlendirme analizini basitleştirir.