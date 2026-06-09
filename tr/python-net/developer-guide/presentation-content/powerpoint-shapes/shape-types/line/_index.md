---
title: Python ile Sunumlarda Çizgi Şekilleri Oluşturma
linktitle: Çizgi
type: docs
weight: 50
url: /tr/python-net/line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgi yapılandır
- çizgi özelleştir
- kesikli stil
- ok ucu
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarında çizgi biçimlendirmesini yönetmeyi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, slaytlara farklı şekiller eklemeyi destekler. Bu konuda, slaytlara çizgi ekleyerek şekillerle çalışmaya başlayacağız. Aspose.Slides kullanarak, yalnızca basit çizgiler oluşturmakla kalmaz, aynı zamanda slaytlara bazı şık çizgiler de çizebilirsiniz.

## **Düz Çizgiler Oluşturma**

Aspose.Slides ile bir slayta basit bir ayırıcı veya bağlayıcı olarak düz bir çizgi ekleyin. Bir sunumdaki seçili slayta düz bir çizgi eklemek için aşağıdaki adımları izleyin:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizine göre slayta bir referans alın.
1. [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) nesnesi üzerindeki `add_auto_shape` yöntemiyle `LINE` türünde bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, sunumun ilk slaytına bir çizgi eklenir.

```py
import aspose.slides as slides

# Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]

    # LINE türünde bir otomatik şekil ekleyin.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Ok Şeklinde Çizgiler Oluşturma**

Aspose.Slides, çizgi özelliklerini daha çekici hale getirmenize izin verir. Aşağıda, bir çizgiyi ok gibi göstermek için birkaç özelliği yapılandırıyoruz. Bu adımları izleyin:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizine göre bir slayta referans alın.
1. [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) nesnesi üzerindeki `add_auto_shape` yöntemiyle `LINE` türünde bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. [çizgi stili](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linestyle/) ayarlayın.
1. Çizgi kalınlığını belirleyin.
1. Çizginin [çizgi dash stili](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linedashstyle/) ayarlayın.
1. Çizginin başlangıç noktası için [ok ucu stili](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linearrowheadstyle/) ve uzunluğunu ayarlayın.
1. Çizginin bitiş noktası için ok ucu stilini ve uzunluğunu ayarlayın.
1. Sunumu PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # LINE türünde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Çizgiye biçimlendirme uygulayın.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Düz bir çizgiyi, şekillere "yapışması" için bir bağlayıcıya dönüştürebilir miyim?**

Hayır. Düz bir çizgi (bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) türü olarak [LINE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapetype/)) otomatik olarak bağlayıcı olmaz. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/python-net/aspose.slides/connector/) türünü ve bağlantılar için [ilgili API'leri](/slides/tr/python-net/connector/) kullanın.

**Bir çizginin özellikleri temadan miras alındıysa ve nihai değerleri belirlemek zor ise ne yapmalıyım?**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ilinefillformateffectivedata/) sınıfları aracılığıyla [etkili özellikleri okuyun](/slides/tr/python-net/shape-effective-properties/) — bunlar zaten miras ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Şekiller, [düzenleme işlemlerine izin vermeme](/slides/tr/python-net/applying-protection-to-presentation/) sağlayan [kilitleme nesneleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/auto_shape_lock/) sunar.