---
title: Python'da Sunumlara Dikdörtgen Ekleme
linktitle: Dikdörtgen
type: docs
weight: 80
url: /tr/python-net/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekli
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile dikdörtgen ekleyerek PowerPoint ve OpenDocument sunumlarınızı güçlendirin—şekilleri programlı olarak kolayca tasarlayın ve değiştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemeyi gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar.

Ayrıca, katı dolgu rengi, kenar rengi ve kenar genişliği gibi temel dikdörtgen biçimlendirmesinin nasıl uygulanacağını göreceksiniz. Buna ek olarak, makalenin SSS bölümü, yuvarlatılmış köşeler, resim dolgu, görsel efektler, bağlantılar, şekil kilitleri, dışa aktarma seçenekleri ve etkili özellikler gibi ilgili dikdörtgen görevlerine işaret eder.

## **Basit Dikdörtgen Oluşturma**
Önceki konular gibi, bu da bir şekil eklemekle ilgilidir ve bu sefer üzerinde konuşacağımız şekil Dikdörtgendir. Bu konuda, geliştiricilerin Aspose.Slides for Python via .NET kullanarak slaytlarına basit veya biçimlendirilmiş dikdörtgenler ekleyebileceği açıklanmıştır. Sunumun seçili bir slaytına basit bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı örneği oluşturun.
1. Bir slaydın referansını, indeksini kullanarak elde edin.
1. IShapes nesnesi tarafından sağlanan AddAutoShape yöntemiyle Rectangle türünde bir IAutoShape ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, sunumun ilk slaytına basit bir dikdörtgen ekledik.

```py
import aspose.slides as slides

# PPTX'i temsil eden Presentation sınıfını örnekleyin
with slides.Presentation() as pres:
    # İlk slaytı al
    sld = pres.slides[0]

    # Dikdörtgen türünde bir autoshape ekle
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # PPTX dosyasını diske kaydet
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Biçimlendirilmiş Dikdörtgen Oluşturma**
Bir slayta biçimlendirilmiş bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı örneği oluşturun.
1. Bir slaydın referansını, indeksini kullanarak elde edin.
1. IShapes nesnesi tarafından sağlanan AddAutoShape yöntemiyle Rectangle türünde bir IAutoShape ekleyin.
1. Dikdörtgenin Dolgu Türünü Solid olarak ayarlayın.
1. IShape nesnesine bağlı FillFormat nesnesi tarafından sağlanan SolidFillColor.Color özelliğini kullanarak Dikdörtgenin Rengini ayarlayın.
1. Dikdörtgenin kenarlarının rengini ayarlayın.
1. Dikdörtgenin kenar genişliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımlar aşağıdaki örnekte uygulanmıştır.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX'i temsil eden Presentation sınıfını örnekleyin
with slides.Presentation() as pres:
    # İlk slaytı alın
    sld = pres.slides[0]

    # Dikdörtgen türünde bir autoshape ekleyin
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Dikdörtgen şekline bazı biçimlendirmeler uygulayın
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Dikdörtgenin çizgi kısmına bazı biçimlendirmeler uygulayın
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #PPTX dosyasını diske kaydedin
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Yuvarlatılmış köşeli bir dikdörtgen nasıl ekleyebilirim?**

Yuvarlatılmış köşeli [şekil türü](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapetype/) kullanın ve şeklin özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma, geometri ayarlamalarıyla köşe bazında da uygulanabilir.

**Bir dikdörtgeni görüntü (doku) ile nasıl doldururum?**

Resim [fill type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) seçin, görüntü kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillmode/) yapılandırın.

**Bir dikdörtgen gölge ve parıltı (glow) alabilir mi?**

Evet. [Outer/inner shadow, glow, and soft edges](/slides/tr/python-net/shape-effect/) ayarlanabilir parametrelerle mevcuttur.

**Bir dikdörtgeni hiperbağlantılı bir düğmeye dönüştürebilir miyim?**

Evet. Şekle tıklama için [Assign a hyperlink](/slides/tr/python-net/manage-hyperlinks/) atayabilirsiniz (slayta, dosyaya, web adresine veya e‑postaya atlamak).

**Bir dikdörtgeni hareket ettirmeye ve değişikliklere karşı nasıl koruyabilirim?**

[Use shape locks](/slides/tr/python-net/applying-protection-to-presentation/): hareket, yeniden boyutlandırma, seçim veya metin düzenlemeyi engelleyerek yerleşimi koruyabilirsiniz.

**Bir dikdörtgeni raster görüntüye veya SVG'ye dönüştürebilir miyim?**

Evet. Şekli belirtilen boyut/ölçekle bir görüntüye [render the shape](http://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/) ya da vektör amaçlı [export it as SVG](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/write_as_svg/) edebilirsiniz.

**Tema ve kalıtımı dikkate alarak bir dikdörtgenin gerçek (etkili) özelliklerini hızlıca nasıl alabilirim?**

[Use the shape’s effective properties](/slides/tr/python-net/shape-effective-properties/): API, tema stilleri, düzen ve yerel ayarları hesaba katan hesaplanmış değerleri döndürür ve biçimlendirme analizini basitleştirir.