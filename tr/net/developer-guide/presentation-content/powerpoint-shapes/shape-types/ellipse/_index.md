---
title: .NET'te Sunumlara Elips Eklemek
linktitle: Elips
type: docs
weight: 30
url: /tr/net/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te PPT ve PPTX sunumları için elips şekillerini oluşturma, biçimlendirme ve manipüle etme konusunda bilgi edinin—C# kod örnekleri dahildir."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemeyi gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elipsin konumu ve boyutu, yığılma sırasının kontrolü ve animasyon efektlerinin uygulanması gibi ilgili sorulara da değinir.

## **Elips Oluştur**
Sunumun seçili bir slaytına basit bir elips eklemek için aşağıdaki adımları izleyin:

1. [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)class bir örnek oluşturun
1. Slaydın indeksini kullanarak bir slayt referansı alın
1. IShapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Ellipse türünde bir AutoShape ekleyin
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin

Aşağıdaki örnekte, ilk slayta bir elips ekledik.

```c#
// PPTX'i temsil eden Presentation sınıfını örnekleyin
using (Presentation pres = new Presentation())
{

    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Elips tipinde bir AutoShape ekle
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // PPTX dosyasını diske yaz
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Biçimlendirilmiş Elips Oluştur**
Bir slayta daha iyi biçimlendirilmiş bir elips eklemek için aşağıdaki adımları izleyin:

1. [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)class bir örnek oluşturun.
1. Slaydın indeksini kullanarak bir slayt referansı alın.
1. IShapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Ellipse türünde bir AutoShape ekleyin.
1. Elipsin Dolgu Türünü Katı olarak ayarlayın.
1. IShape nesnesiyle ilişkili FillFormat nesnesi tarafından sunulan SolidFillColor.Color özelliği ile Elipsin Rengini ayarlayın.
1. Elipsin çizgi rengini ayarlayın.
1. Elipsin çizgi kalınlığını ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, sunumun ilk slaytına biçimlendirilmiş bir elips ekledik.

```c#
// PPTX'i temsil eden Presentation sınıfını örnekleyin
using (Presentation pres = new Presentation())
{

    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Elips tipinde bir AutoShape ekle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Elips şekline bazı biçimlendirmeler uygulayın
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Elipsin çizgisine bazı biçimlendirmeler uygulayın
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX dosyasını diske yaz
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Bir elipsin konumunu ve boyutunu slayt birimlerine göre nasıl tam olarak ayarlarım?**

Koordinatlar ve boyutlar genellikle **puan** cinsinden belirtilir. Öngörülebilir sonuçlar için hesaplamalarınızı slayt boyutuna göre yapın ve değer atamadan önce gerekli milimetre veya inçleri puana dönüştürün.

**Bir elipsi diğer nesnelerin üzerinde ya da altında nasıl konumlandırırım (yığılma sırasını kontrol et)?**

Nesnenin çizim sırasını öne getirerek ya da arkaya göndererek ayarlayın. Bu, elipsin diğer nesnelerin üzerine gelmesini veya altındakileri ortaya çıkarmasını sağlar.

**Bir elipsin görünümünü veya vurgusunu nasıl canlandırırım?**

[Uygula](/slides/tr/net/shape-animation/) giriş, vurgu veya çıkış efektlerini şekle ekleyin ve tetikleyicileri ve zamanlamayı yapılandırarak animasyonun ne zaman ve nasıl oynatılacağını ayarlayın.