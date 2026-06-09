---
title: Java'da Sunumlara Dikdörtgen Ekleme
linktitle: Dikdörtgen
type: docs
weight: 80
url: /tr/java/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekli
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile dikdörtgenler ekleyerek PowerPoint sunumlarınızı güçlendirin—şekilleri programlı olarak kolayca tasarlayın ve değiştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemeyi gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar.

Ayrıca, katı dolgu rengi, çizgi rengi ve çizgi kalınlığı gibi temel dikdörtgen biçimlendirmesini nasıl uygulayacağınızı göreceksiniz. Ayrıca, makalenin SSS bölümü, yuvarlatılmış köşeler, resim dolguları, görsel efektler, köprüler, şekil kilitleri, dışa aktarma seçenekleri ve etkili özellikler gibi ilgili dikdörtgen görevlerine işaret eder.

## **Bir Slayta Dikdörtgen Ekle**

Bir sunumun seçili slaytına basit bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını indeksini kullanarak alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanarak Rectangle türünde bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaytına basit bir dikdörtgen ekledik.

```java
// PPTX'i temsil eden Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Ellipse tipinde AutoShape ekle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX dosyasını diske yaz
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Biçimlendirilmiş Bir Dikdörtgeni Slayta Ekle**

Bir slayta biçimlendirilmiş bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını indeksini kullanarak alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanarak Rectangle türünde bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) ekleyin.
- Dikdörtgenin [Fill Type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FillType) ayarını Solid olarak ayarlayın.
- [IFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFillFormat) nesnesiyle ilişkili [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape) nesnesi tarafından sunulan [SolidFillColor.setColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) yöntemini kullanarak Dikdörtgenin rengini ayarlayın.
- Dikdörtgenin kenar çizgilerinin rengini ayarlayın.
- Dikdörtgenin kenar çizgilerinin genişliğini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımlar aşağıdaki örnekte uygulanmıştır.

```java
// PPTX'i temsil eden Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Ellipse tipinde AutoShape ekle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Ellipse şekline bazı biçimlendirmeler uygula
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Ellipse'in çizgi kısmına bazı biçimlendirmeler uygula
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

**Yuvarlatılmış köşeli bir dikdörtgen nasıl eklerim?**  
Yuvarlatılmış köşeli [shape type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapetype/) kullanın ve şeklin özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma ayrıca geometri ayarlamalarıyla köşe başına uygulanabilir.

**Bir dikdörtgeni bir resim (doku) ile nasıl doldururum?**  
Resim [fill type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) seçin, görüntü kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturefillmode/) yapılandırın.

**Bir dikdörtgen gölge ve parıltı alabilir mi?**  
Evet. Ayarlanabilir parametrelerle [Outer/inner shadow, glow, and soft edges](/slides/tr/java/shape-effect/) mevcuttur.

**Bir dikdörtgeni köprüyle bir düğmeye dönüştürebilir miyim?**  
Evet. Şekil tıklamasına (bir slayta, dosyaya, web adresine veya e-postaya gitmek için) [Assign a hyperlink](/slides/tr/java/manage-hyperlinks/) ekleyin.

**Bir dikdörtgeni hareket ve değişikliklerden koruyabilir miyim?**  
[Use shape locks](/slides/tr/java/applying-protection-to-presentation/): hareketi, yeniden boyutlandırmayı, seçimi veya metin düzenlemeyi engelleyerek düzeni koruyabilirsiniz.

**Bir dikdörtgeni raster görüntüye veya SVG'ye dönüştürebilir miyim?**  
Evet. Şekli belirli bir boyut/ölçekle bir görüntüye [render the shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) edebilir veya vektör kullanımı için [export it as SVG](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) yapabilirsiniz.

**Tema ve kalıtımı dikkate alarak bir dikdörtgenin gerçek (etkili) özelliklerini hızlıca nasıl alırım?**  
[Use the shape’s effective properties](/slides/tr/java/shape-effective-properties/): API, tema stilleri, düzen ve yerel ayarları göz önünde bulunduran hesaplanmış değerleri döndürür, biçimlendirme analizini basitleştirir.