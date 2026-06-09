---
title: .NET'te Sunumlara Çizgi Şekilleri Ekleme
linktitle: Çizgi
type: docs
weight: 50
url: /tr/net/Line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgiyi yapılandır
- çizgiyi özelleştir
- kesik stil
- ok ucu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında çizgi biçimlendirmesini yönetmeyi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, programlı olarak PowerPoint slaytlarına çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve çizgiyi bir ok gibi görünmesi için nasıl özelleştirileceğini gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesikli desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Çizgi Oluşturma**
Sunumun seçili bir slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Sunum sınıfının bir örneğini oluşturun: [Sunum ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)class.
- Bir slaydın referansını, indeksini kullanarak alın.
- Shapes nesnesi tarafından sunulan [AddAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/methods/addautoshape/index) yöntemini kullanarak Çizgi tipinde bir AutoShape ekleyin.
- Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıda verilen örnekte, sunumun ilk slaytına bir çizgi ekledik.

```c#
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekle
using (Presentation pres = new Presentation())
{
    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Çizgi tipinde bir autoshape ekle
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //PPTX dosyasını diske kaydet
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Ok Şeklinde Çizgi Oluşturma**
Aspose.Slides for .NET ayrıca geliştiricilerin çizginin görünümünü daha çekici hâle getirmek için bazı özelliklerini yapılandırmasına olanak tanır. Çizgiyi bir ok gibi görünecek şekilde birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- Sunum sınıfının bir örneğini oluşturun: [Sunum ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)sınıf[] (http://www.aspose.com/api/net/slides/tr/aspose.slides/)[](http://www.aspose.com/api/net/slides/tr/aspose.slides/).
- Bir slaydın referansını, indeksini kullanarak alın.
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemini kullanarak Çizgi tipinde bir AutoShape ekleyin.
- Çizgi Stilini Aspose.Slides for .NET tarafından sunulan stillerden biri olarak ayarlayın.
- Çizginin Genişliğini ayarlayın.
- Çizginin [Dash Style](https://reference.aspose.com/slides/tr/net/aspose.slides/linedashstyle) stilini Aspose.Slides for .NET tarafından sunulan stillerden biri olarak ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/net/aspose.slides/linearrowheadstyle) ve Uzunluğunu ayarlayın.
- Çizginin bitiş noktasının Ok Ucu Stili ve Uzunluğunu ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```c#
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekle
using (Presentation pres = new Presentation())
{

    // İlk slaytı al
    ISlide sld = pres.Slides[0];

    // Çizgi tipinde bir autoshape ekle
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Çizgiye bazı biçimlendirmeler uygula
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //PPTX dosyasını diske kaydet
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Düzenli bir çizgiyi bağlayıcıya dönüştürüp şekillere "yapışmasını" sağlayabilir miyim?**

Hayır. Düzenli bir çizgi (bir [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) türü olan [Line](https://reference.aspose.com/slides/tr/net/aspose.slides/shapetype/)) otomatik olarak bir bağlayıcıya dönüşmez. Şekillere yapışması için özel [Connector](https://reference.aspose.com/slides/tr/net/aspose.slides/connector/) türünü ve bağlantılar için [corresponding APIs](/slides/tr/net/connector/) kullanın.

**Tema tarafından devralınan çizgi özellikleri varsa ve nihai değerleri belirlemek zor ise ne yapmalıyım?**

[Etkin özellikleri](/slides/tr/net/shape-effective-properties/) [ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilinefillformateffectivedata/) arayüzleri aracılığıyla okuyun—bunlar zaten kalıtım ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Shapes, [lock objects](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/autoshapelock/) sağlayarak düzenleme işlemlerini [disallow editing operations](/slides/tr/net/applying-protection-to-presentation/) mümkün kılar.