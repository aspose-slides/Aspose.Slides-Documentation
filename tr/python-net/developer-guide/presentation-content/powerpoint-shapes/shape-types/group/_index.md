---
title: Python ile Grup Sunum Şekilleri
linktitle: Şekil Grubu
type: docs
weight: 40
url: /tr/python-net/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak PowerPoint ve OpenDocument destelerinde şekilleri gruplama ve gruptan çıkarma öğrenin—hızlı, adım adım rehber ve ücretsiz kod."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grup şekilleriyle nasıl çalışılacağını açıklar. Bir slayta grup şekli eklemeyi, şekilleri içine yerleştirmeyi ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca bir grup içinde depolanan şekillere nasıl erişileceğini ve bunların `alternative_text` değerlerini nasıl okuyacağınızı gösterir. Ek olarak, makale iç içe gruplar, z-sırası ve kilitleme seçenekleri gibi ilgili grup şekli özelliklerine kısaca değinir.

## **Grup Şekilleri Ekle**

Aspose.Slides, bir slaytta grup şekilleriyle çalışmayı destekler. Bu özellik, birden fazla şekli tek bir nesne gibi ele alarak daha zengin sunumlar oluşturmanıza olanak tanır. Yeni grup şekilleri ekleyebilir, mevcut olanlara erişebilir, onları alt şekillerle doldurabilir ve özelliklerini okuyabilir veya değiştirebilirsiniz. Bir slayta grup şekli eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeks ile bir slayta referans alın.
3. Slayta bir [GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/) ekleyin.
4. Yeni grup şekline şekiller ekleyin.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek, bir slayta grup şekli eklemeyi gösterir.

```py
import aspose.slides as slides

# Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Slayta bir grup şekli ekleyin.
    group_shape = slide.shapes.add_group_shape()

    # Grup şekli içinde şekiller ekleyin.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # PPTX dosyasını diske kaydedin.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Alt Metin Özelliğine Erişim**

Bu bölüm, Aspose.Slides kullanarak bir slayttaki grup şekli içinde bulunan şekillerin Alt Metnini nasıl okuyacağınızı açıklar. Şekillerin Alt Metnine erişmek için:

1. Bir PPTX dosyasını temsil etmek için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın indeksine göre bir referans alın.
3. Slaydın şekil koleksiyonuna erişin.
4. [GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/) öğesine erişin.
5. Alt Metin özelliğini okuyun.

Aşağıdaki örnek, grup şekilleri içinde bulunan şekillerin Alt Metnini alır.

```py
import aspose.slides as slides

# PPTX dosyasını açmak için Presentation sınıfını örnekleyin.
with slides.Presentation("group_shape.pptx") as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Grup şekline erişin.
            for child_shape in shape.shapes:
                # Alt Metin özelliğine erişin.
                print(child_shape.alternative_text)
```

## **SSS**

**İç içe gruplama (bir grup içinde başka bir grup) destekleniyor mu?**

Evet. [GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/) bir [parent_group](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/parent_group/) özelliğine sahiptir; bu doğrudan hiyerarşi desteğini gösterir (bir grup başka bir grubun çocuğu olabilir).

**Grubun z-sırasını slayttaki diğer nesnelere göre nasıl kontrol edebilirim?**

[GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/)’nin [z_order_position](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/z_order_position/) özelliğini kullanarak, görüntüleme yığındaki konumunu inceleyebilirsiniz.

**Taşıma/düzenleme/grup dışı bırakma işlemlerini engelleyebilir miyim?**

Evet. Grup kilitleme bölümü, [group_shape_lock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/group_shape_lock/) aracılığıyla sunulur; bu, nesne üzerinde işlemleri kısıtlamanızı sağlar.