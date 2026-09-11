---
title: Python via Java ile Sunumlara Çizgi Şekilleri Ekleme
linktitle: Çizgi
type: docs
weight: 50
url: /tr/python-java/line/
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
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarında çizgi biçimlendirmesini yönetmeyi öğrenin. Özellikleri, metodları ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve bir çizgiyi ok gibi görünmesi için nasıl özelleştireceğinizi gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesikli desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Bir Çizgi Oluşturma**

Seçili bir slayta basit bir çizgi eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- İndeksine göre bir slayta referans alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) nesnesinin [addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak bir çizgi şekli ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnek, sunumun ilk slaytına bir çizgi ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
presentation = Presentation()
try:
    # İlk slaytı alın.
    slide = presentation.getSlides().get_Item(0)

    # Bir çizgi şekli ekleyin.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # PPTX dosyasını diske yazın.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ok Şeklinde Bir Çizgi Oluşturma**

Aspose.Slides for Python via Java, geliştiricilerin bir çizgiyi daha çekici hâle getirmek için çizgi özelliklerini yapılandırmasına da olanak tanır. Bir çizgiyi ok gibi görünmesi için yapılandırmak üzere aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- İndeksine göre bir slayta referans alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) nesnesinin [addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak bir çizgi şekli ekleyin.
- [çizgi stili](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linestyle/)ni Aspose.Slides for Python via Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin genişliğini ayarlayın.
- [kesikli stil](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linedashstyle/)ni Aspose.Slides for Python via Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin başlangıcında [ok ucu stili](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linearrowheadstyle/) ve [uzunluk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linearrowheadlength/) ayarlayın.
- Çizginin sonunda [ok ucu stili](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linearrowheadstyle/) ve [uzunluk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linearrowheadlength/) ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
presentation = Presentation()
try:
    # İlk slaytı alın.
    slide = presentation.getSlides().get_Item(0)

    # Bir çizgi şekli ekleyin.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Çizgiye biçimlendirme uygulayın.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # PPTX dosyasını diske yazın.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Düzenli bir çizgiyi bağlayıcıya dönüştürüp şekillere “yapışmasını” sağlayabilir miyim?**

Hayır. Düzenli bir çizgi (bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) türü [Line](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/)) otomatik olarak bağlayıcıya dönüşmez. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/python-java/aspose.slides/connector/) türünü ve bağlantılar için [corresponding APIs](/slides/tr/python-java/connector/) kullanın.

**Bir çizginin özellikleri temadan kalıtıldığında ve nihai değerleri belirlemek zor olduğunda ne yapmalıyım?**

Çizginin ve dolgusunun [Etkili özellikleri](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#getAutoShapeLock)(/slides/tr/python-java/shape-effective-properties/) okuyun—bunlar zaten kalıtım ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Şekiller, [kilitleme nesneleri](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#getAutoShapeLock) sağlayarak [düzenleme işlemlerini engellemenizi](/slides/tr/python-java/applying-protection-to-presentation/) sağlar.