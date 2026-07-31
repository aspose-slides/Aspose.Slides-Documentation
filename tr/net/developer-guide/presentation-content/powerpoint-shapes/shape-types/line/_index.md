---
title: ".NET'te Sunumlara Çizgi Şekilleri Ekleyin"
linktitle: "Çizgi"
type: docs
weight: 50
url: /tr/net/line/
keywords:
- "çizgi"
- "çizgi oluştur"
- "çizgi ekle"
- "düz çizgi"
- "çizgi yapılandır"
- "çizgi özelleştir"
- "kesikli stil"
- "ok ucu"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında çizgi biçimlendirmeyi nasıl yöneteceğinizi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve çizgiyi ok şeklinde özelleştirmeyi gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesikli desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Bir Çizgi Oluşturma**
Sunumun seçili bir slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Slaytın indeksini kullanarak bir slayt referansı alın.
- Shapes nesnesi tarafından sunulan [AddAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/methods/addautoshape/index) yöntemiyle Çizgi türünde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına bir çizgi ekledik.

```c#
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
using (Presentation pres = new Presentation())
{
    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Çizgi tipinde bir autoshape ekle
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // PPTX dosyasını diske kaydet
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Ok Şeklinde Çizgi Oluşturma**
Aspose.Slides for .NET ayrıca geliştiricilerin çizgiyi daha çekici hale getirmek için bazı özellikleri yapılandırmasına izin verir. Çizgiyi ok gibi görünmesi için birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/tr/aspose.slides/)[](http://www.aspose.com/api/net/slides/tr/aspose.slides/). sınıfının bir örneğini oluşturun.
- Slaytın indeksini kullanarak bir slayt referansı alın.
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Çizgi türünde bir AutoShape ekleyin.
- Çizgi Stilini Aspose.Slides for .NET tarafından sunulan stillerden birine ayarlayın.
- Çizginin Genişliğini ayarlayın.
- Çizginin [Dash Style](https://reference.aspose.com/slides/tr/net/aspose.slides/linedashstyle) özelliğini Aspose.Slides for .NET tarafından sunulan stillerden birine ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/net/aspose.slides/linearrowheadstyle) ve Uzunluğunu ayarlayın.
- Çizginin bitiş noktasının Ok Ucu Stilini ve Uzunluğunu ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```c#
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekle
using (Presentation pres = new Presentation())
{

    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Çizgi tipinde bir autoshape ekle
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Çizgi üzerinde bazı biçimlendirmeler uygula
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // PPTX dosyasını diske kaydet
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Normal bir çizgiyi bağlayıcıya dönüştürüp şekillere “yapışmasını” sağlayabilir miyim?**

Hayır. Normal bir çizgi (bir [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) tipinde [Line](https://reference.aspose.com/slides/tr/net/aspose.slides/shapetype/)) otomatik olarak bağlayıcı olmaz. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/net/aspose.slides/connector/) tipini ve bağlantılar için [corresponding APIs](/slides/tr/net/connector/) kullanın.

**Bir çizginin özellikleri temadan devralındığında nihai değerleri belirlemek zor olursa ne yapmalıyım?**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilinefillformateffectivedata/) arayüzleri üzerinden [etkili özellikleri](/slides/tr/net/shape-effective-properties/) okuyun—bunlar zaten miras alma ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Shapes, [kilitleme nesneleri](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/autoshapelock/) sağlayarak [düzenleme işlemlerini reddetmenize](/slides/tr/net/applying-protection-to-presentation/) izin verir.