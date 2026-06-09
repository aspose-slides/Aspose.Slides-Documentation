---
title: Python'da Sunumlara Elips Ekle
linktitle: Elips
type: docs
weight: 30
url: /tr/python-net/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PPT, PPTX ve ODP sunumlarında elips şekillerini oluşturma, biçimlendirme ve manipüle etme yöntemlerini öğrenin—kod örnekleri dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemeyi gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips oluşturmayı ve güncellenen sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elipsin konumu ve boyutu, yığılma düzeninin kontrolü ve animasyon efektlerinin uygulanması gibi ilgili konulara da değinir.

## **Elips Oluştur**
Bu konuda, geliştiricilere Aspose.Slides for Python via .NET kullanarak slaytlarına elips şekilleri eklemeyi tanıtacağız. Aspose.Slides for Python via .NET, yalnızca birkaç satır kodla farklı şekiller çizmeyi sağlayan daha kolay bir API seti sunar. Sunumun seçili bir slaytına basit bir elips eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun
1. İndex değerini kullanarak bir slayt referansı alın
1. IShapes nesnesi tarafından sağlanan AddAutoShape yöntemiyle Elips türünde bir AutoShape ekleyin
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın

Aşağıdaki örnekte, ilk slayta bir elips ekledik.

```py
import aspose.slides as slides

# PPTX'i temsil eden Presentation sınıfını örnekleyin
with slides.Presentation() as pres:
    # İlk slaytı al
    sld = pres.slides[0]

    # Elips tipinde bir autoshape ekle
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #PPTX dosyasını diske yaz
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Biçimlendirilmiş Elips Oluştur**
Bir slayta daha iyi biçimlendirilmiş bir elips eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndex değerini kullanarak bir slayt referansı alın.
1. IShapes nesnesi tarafından sağlanan AddAutoShape yöntemiyle Elips türünde bir AutoShape ekleyin.
1. Elipsin Dolgu Tipini Katı olarak ayarlayın.
1. IShape nesnesiyle ilişkili FillFormat nesnesi tarafından sunulan SolidFillColor.Color özelliğini kullanarak Elipsin Rengini ayarlayın.
1. Elipsin çizgi rengini ayarlayın.
1. Elipsin çizgi genişliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına biçimlendirilmiş bir elips ekledik.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX'i temsil eden Presentation sınıfını örnekleyin
with slides.Presentation() as pres:
    # İlk slaytı al
    sld = pres.slides[0]

    # Elips tipinde bir autoshape ekle
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Elips şekline bazı biçimlendirmeler uygula
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Elipsin çizgi kısmına bazı biçimlendirmeler uygula
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #PPTX dosyasını diske yaz
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir elipsin slayt birimlerine göre tam konum ve boyutunu nasıl ayarlarım?**

Koordinatlar ve boyutlar genellikle **nokta** cinsinden belirtilir. Öngörülebilir sonuçlar için hesaplamalarınızı slayt boyutuna göre yapın ve gerekli milimetre veya inç değerlerini noktalara dönüştürerek atayın.

**Bir elipsi diğer nesnelerin üstüne ya da altına nasıl yerleştiririm (yığılma düzenini kontrol ederim)?**

Nesnenin çizim sırasını öne getirerek ya da arkaya göndererek ayarlayın. Böylece elips diğer nesnelerin üzerine biner veya onun altındaki nesneleri ortaya çıkarır.

**Bir elipsin görünümünü veya vurgusunu nasıl canlandırırım?**

[Uygula](/slides/tr/python-net/shape-animation/) giriş, vurgu veya çıkış efektlerini şekle ekleyin ve tetikleyicileri ve zamanlamayı yapılandırarak animasyonun ne zaman ve nasıl çalışacağını yönetin.