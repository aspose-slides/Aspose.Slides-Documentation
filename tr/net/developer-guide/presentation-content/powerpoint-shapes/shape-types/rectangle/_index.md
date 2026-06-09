---
title: .NET'te Sunumlara Dikdörtgen Ekleme
linktitle: Dikdörtgen
type: docs
weight: 80
url: /tr/net/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekli
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile dikdörtgen ekleyerek PowerPoint sunumlarınızı güçlendirin—şekilleri programlama yoluyla kolayca tasarlayın ve değiştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemenin nasıl yapılacağını gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar.

Ayrıca, dolgulu bir renk, kenar rengi ve kenar genişliği gibi temel dikdörtgen biçimlendirmelerini nasıl uygulayacağınızı göreceksiniz. Ek olarak, makalenin SSS bölümü, yuvarlatılmış köşeler, resim dolguları, görsel efektler, köprüler, şekil kilitleri, dışa aktarma seçenekleri ve etkili özellikler gibi ilgili dikdörtgen görevlerine işaret eder.

## **Basit Bir Dikdörtgen Oluşturma**
Önceki konular gibi, bu da bir şekil eklemekle ilgilidir ve bu sefer ele alacağımız şekil Dikdörtgen. Bu konuda, geliştiricilerin Aspose.Slides for .NET kullanarak slaytlarına basit veya biçimlendirilmiş dikdörtgenler ekleyebileceği açıklanmıştır. Sunumun seçili bir slaytına basit bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını, Index'ini kullanarak elde edin.
3. IShapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Rectangle türünde bir IAutoShape ekleyin.
4. Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaytına basit bir dikdörtgen ekledik.

```c#
// PPTX'i temsil eden Presentation sınıfını örnekleyin
using (Presentation pres = new Presentation())
{

    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Dikdörtgen tipinde bir otomatik şekil ekle
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX dosyasını diske kaydet
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Biçimlendirilmiş Bir Dikdörtgen Oluşturma**
Bir slayta biçimlendirilmiş bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını, Index'ini kullanarak elde edin.
3. IShapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Rectangle türünde bir IAutoShape ekleyin.
4. Dikdörtgenin Dolgu Türünü Solid olarak ayarlayın.
5. IShape nesnesine ilişkili FillFormat nesnesi tarafından sunulan SolidFillColor.Color özelliğini kullanarak Dikdörtgenin Rengini ayarlayın.
6. Dikdörtgenin çizgi rengini ayarlayın.
7. Dikdörtgenin çizgi genişliğini ayarlayın.
8. Değiştirilen sunumu PPTX dosyası olarak yazın.
   Yukarıdaki adımlar aşağıdaki örnekte uygulanmıştır.

```c#
// PPTX'i temsil eden Presentation sınıfını örnekleyin
using (Presentation pres = new Presentation())
{

    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Dikdörtgen tipinde bir otomatik şekil ekle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Dikdörtgen şekline bazı biçimlendirmeler uygulayın
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Dikdörtgenin çizgisine bazı biçimlendirmeler uygulayın
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // PPTX dosyasını diske kaydedin
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **SSS**

**Yuvarlatılmış köşeli bir dikdörtgen nasıl eklerim?**

Yuvarlatılmış köşe [shape type](https://reference.aspose.com/slides/tr/net/aspose.slides/shapetype/) kullanın ve şeklin özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma ayrıca geometrik ayarlamalarla köşe bazında uygulanabilir.

**Bir dikdörtgeni görüntü (doku) ile nasıl doldururum?**

Resim [fill type](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) seçin, görüntü kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillmode/) yapılandırın.

**Bir dikdörtgen gölge ve parıltıya sahip olabilir mi?**

Evet. [Outer/inner shadow, glow, and soft edges](/slides/tr/net/shape-effect/) ayarlanabilir parametrelerle mevcuttur.

**Bir dikdörtgeni köprü (hyperlink) ile bir düğmeye dönüştürebilir miyim?**

Evet. [Bir köprü ata](/slides/tr/net/manage-hyperlinks/) şekle tıklama için (slayta, dosyaya, web adresine veya e-postaya geçiş).

**Bir dikdörtgeni hareket etmekten ve değişikliklerden nasıl korurum?**

[Şekil kilitlerini kullan](/slides/tr/net/applying-protection-to-presentation/): hareketi, yeniden boyutlandırmayı, seçimi veya metin düzenlemeyi yasaklayarak düzeni koruyabilirsiniz.

**Bir dikdörtgeni raster görüntüye ya da SVG'ye dönüştürebilir miyim?**

Evet. Şekli belirli bir boyut/ölçekle bir görüntüye [şekli render et](http://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/) edebilir veya vektör kullanımı için [SVG olarak dışa aktar](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/writeassvg/)abilirsiniz.

**Tema ve kalıtımı dikkate alarak bir dikdörtgenin gerçek (etkili) özelliklerini hızlıca nasıl alırım?**

[Şeklin etkili özelliklerini kullan](/slides/tr/net/shape-effective-properties/): API, tema stilleri, düzen ve yerel ayarları hesaba katan hesaplanmış değerleri döndürür, biçimlendirme analizini basitleştirir.