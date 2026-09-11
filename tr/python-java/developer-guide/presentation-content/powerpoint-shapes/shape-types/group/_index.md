---
title: Python via Java ile Grup Sunum Şekilleri
linktitle: Şekil Grubu
type: docs
weight: 40
url: /tr/python-java/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında şekilleri gruplamayı ve gruplamayı çözmeyi öğrenin—ücretsiz Python kodu ile adım adım bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grup şekilleriyle nasıl çalışılacağını açıklar. Bir slayta grup şekli eklemeyi, şekilleri içine yerleştirmeyi ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca bir grup içinde saklanan şekillere nasıl erişileceğini ve [getAlternativeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getAlternativeText) kullanarak alternatif metinlerinin nasıl okunacağını gösterir. Ek olarak, makale iç içe gruplar, z-sırası ve kilitleme seçenekleri gibi ilgili grup‑şekli özelliklerine kısaca değinir.

## **Bir Grup Şekli Ekleme**

Aspose.Slides, slaytlarda grup şekilleriyle çalışmayı destekler. Bu özellik, geliştiricilerin daha zengin sunumlar oluşturmasına yardımcı olur. Aspose.Slides for Python via Java, grup şekilleri eklemeyi ve erişmeyi destekler. Bir grup şekline şekiller ekleyebilir veya özelliklerine erişebilirsiniz. Aspose.Slides for Python via Java kullanarak bir slayta grup şekli eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle bir slayta referans alın.  
3. Slayta bir grup şekli ekleyin.  
4. Grup şekline şekiller ekleyin.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir slayta grup şekli ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Presentation sınıfını örnekleyin.
presentation = Presentation()
try:
    # İlk slaytı alın.
    slide = presentation.getSlides().get_Item(0)

    # Slaydın şekil koleksiyonuna erişin.
    slide_shapes = slide.getShapes()

    # Slayta bir grup şekli ekleyin.
    group_shape = slide_shapes.addGroupShape()

    # Grup şekli içinde şekiller ekleyin.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Grup şeklinin çerçevesini ayarlayın.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # PPTX dosyasını diske yazın.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alternatif Metni Erişme**

Bu bölüm, bir slayttaki grup içindeki şekillerin alternatif metnine nasıl erişileceğini gösterir. Aspose.Slides for Python via Java kullanarak bu metne erişmek için:

1. PPTX dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle bir slayta referans alın.  
3. Slaydın şekil koleksiyonuna erişin.  
4. Grup şekline erişin.  
5. Şekillerinin alternatif metnini [getAlternativeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getAlternativeText) kullanarak okuyun.

Aşağıdaki örnek, bir grup içindeki şekillerin alternatif metnine erişir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
presentation = Presentation("AltText.pptx")
try:
    # İlk slaytı alın.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Slaydın şekil koleksiyonundaki bir şekle erişin.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Grubun içindeki şekillere erişin.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Alternatif metni okuyun.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **SSS**

**İç içe gruplama (bir grup içinde başka bir grup) destekleniyor mu?**  
Evet. [GroupShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshape/) sınıfının [getParentGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getParentGroup) metodu vardır; bu, hiyerarşi desteğini gösterir: bir grup başka bir grubun çocuğu olabilir.

**Grubun z-sırasını slayttaki diğer nesnelere göre nasıl kontrol ederim?**  
[GroupShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshape/) nesnesinin [getZOrderPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getZOrderPosition) metodunu kullanarak, görüntüleme yığınıındaki konumunu inceleyebilirsiniz.

**Hareket ettirmeyi, düzenlemeyi veya grubu çözmeyi önleyebilir miyim?**  
Evet. Grubun kilitleri, [getGroupShapeLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshape/#getGroupShapeLock) aracılığıyla sunulur; bu, nesne üzerindeki işlemleri kısıtlamanıza olanak tanır.