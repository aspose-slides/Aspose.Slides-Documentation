---
title: "PHP'de Sunumlara Dikdörtgen Ekleme"
linktitle: "Dikdörtgen"
type: docs
weight: 80
url: /tr/php-java/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekli
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarınıza dikdörtgen ekleyin — şekilleri programlı olarak kolayca tasarlayın ve değiştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemenin nasıl yapılacağını gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenen sunumu PPTX dosyası olarak kaydetmeyi kapsar.

Ayrıca, katı dolgu rengi, kenar rengi ve kenar kalınlığı gibi temel dikdörtgen biçimlendirmesinin nasıl uygulanacağını da göreceksiniz. Ek olarak, makalenin SSS bölümü, yuvarlatılmış köşeler, resim dolguları, görsel efektler, hiperlinkler, şekil kilitleri, dışa aktarma seçenekleri ve etkili özellikler gibi ilgili dikdörtgen görevlerine işaret eder.

## **Bir Slayta Dikdörtgen Ekle**
Sunumun seçili bir slaydına basit bir dikdörtgen eklemek için lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesnesini, Rectangle (Dikdörtgen) türünde, [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) yöntemiyle ekleyin.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaydına basit bir dikdörtgen ekledik.

```php
  # PPTX'i temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Elips türünde AutoShape ekle
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # PPTX dosyasını diske yaz
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Slayta Biçimlendirilmiş Dikdörtgen Ekle**
Bir slayta biçimlendirilmiş bir dikdörtgen eklemek için lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesnesini, Rectangle (Dikdörtgen) türünde, [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) yöntemiyle ekleyin.
- Dikdörtgenin [Fill Type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FillType) değerini Solid (Katı) olarak ayarlayın.
- Dikdörtgenin rengini, [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesnesiyle ilişkili [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) nesnesi tarafından sunulan [ColorFormat::setColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorformat/#setColor) yöntemiyle ayarlayın.
- Dikdörtgenin kenarlarının rengini ayarlayın.
- Dikdörtgenin kenarlarının genişliğini ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımlar, aşağıda verilen örnekte uygulanmıştır.

```php
  # PPTX'i temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Ellipse türünde AutoShape ekle
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Ellipse şekline bazı biçimlendirmeler uygulayın
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Ellipse'in çizgisinde bazı biçimlendirmeler uygulayın
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX dosyasını diske yaz
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Yuvarlatılmış köşeli bir dikdörtgen nasıl eklerim?**  
Yuvarlatılmış köşeli [shape type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapetype/) kullanın ve şeklin özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma aynı zamanda geometrik ayarlamalarla köşe bazında uygulanabilir.

**Bir dikdörtgeni resim (doku) ile nasıl doldururum?**  
Resim [fill type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) seçin, görüntü kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillmode/) yapılandırın.

**Bir dikdörtgen gölge ve parıltı alabilir mi?**  
Evet. [Outer/inner shadow, glow, and soft edges](/slides/tr/php-java/shape-effect/) ayarlanabilir parametrelerle kullanılabilir.

**Bir dikdörtgeni hiperlinkli bir düğmeye dönüştürebilir miyim?**  
Evet. Şekle tıklama sırasında [Bir hiperlink atayın](/slides/tr/php-java/manage-hyperlinks/) (bir slayta, dosyaya, web adresine veya e‑postaya atlamak için).

**Bir dikdörtgenin hareket etmesini ve değişmesini nasıl korurum?**  
Şekil kilitlerini kullanın: düzeni korumak için hareket etmeyi, yeniden boyutlandırmayı, seçim yapmayı veya metin düzenlemeyi yasaklayabilirsiniz.

**Bir dikdörtgeni raster görüntüye veya SVG'ye dönüştürebilir miyim?**  
Evet. Şekli, belirtilen bir boyut/ölçekle bir görüntüye [Şekli render edin](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) ya da vektörel kullanım için [SVG olarak dışa aktarın](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/) yapabilirsiniz.

**Bir dikdörtgenin tema ve kalıtımını dikkate alarak gerçek (etkili) özelliklerini hızlıca nasıl alırım?**  
[Şeklin etkili özelliklerini kullanın](/slides/tr/php-java/shape-effective-properties/): API, tema stilleri, düzen ve yerel ayarları dikkate alan hesaplanmış değerleri döndürür, biçimlendirme analizini basitleştirir.