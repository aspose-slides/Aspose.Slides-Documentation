---
title: Android'de Grup Sunum Şekilleri
linktitle: Şekil Grubu
type: docs
weight: 40
url: /tr/androidjava/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PowerPoint sunumlarında şekilleri gruplamayı ve gruptan çıkarmayı öğrenin—hızlı, adım adım rehber ve ücretsiz Java kodu."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grup şekilleriyle nasıl çalışılacağını açıklar. Bir slayta grup şekli ekleme, içine şekil yerleştirme ve güncellenmiş sunumu kaydetme adımlarını gösterir. Ayrıca bir grup içinde depolanan şekillere nasıl erişileceğini ve `AlternativeText` değerlerinin nasıl okunacağını gösterir. Ek olarak, iç içe gruplar, z‑sırası ve kilitleme seçenekleri gibi ilgili grup‑şekli özelliklerine de kısaca değinir.

## **Grup Şekli Ekleme**
Aspose.Slides, slaytlarda grup şekilleriyle çalışmayı destekler. Bu özellik geliştiricilerin daha zengin sunumlar oluşturmasına yardımcı olur. Aspose.Slides for Android via Java, grup şekilleri eklemeyi ve onlara erişmeyi sağlar. Eklenmiş bir grup şekline şekiller ekleyerek onu doldurabilir veya grup şeklinin herhangi bir özelliğine erişebilirsiniz. Aspose.Slides for Android via Java kullanarak bir slayta grup şekli eklemek için:

1. [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaydın referansını alın
1. Slayta bir grup şekli ekleyin.
1. Eklenen grup şekline şekilleri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir slayta grup şekli ekler.

```java
    // Presentation sınıfını örnekle
    Presentation pres = new Presentation();
    try {
        // İlk slaytı al
        ISlide sld = pres.getSlides().get_Item(0);

        // Slaytların şekil koleksiyonuna erişim
        IShapeCollection slideShapes = sld.getShapes();

        // Slayta bir grup şekli ekleme
        IGroupShape groupShape = slideShapes.addGroupShape();
        
        // Eklenen grup şeklinin içine şekiller ekleme
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

        // Grup şekli çerçevesi ekleme
        groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

        // PPTX dosyasını diske kaydet
        pres.save("GroupShape.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **AltText Özelliğine Erişim**
Bu bölüm, grup şekli ekleme ve slaytlardaki grup şekillerinin AltText özelliğine erişme konusunda kod örnekleriyle birlikte basit adımları gösterir. Aspose.Slides for Android via Java kullanarak bir slayttaki grup şeklinin AltText özelliğine erişmek için:

1. PPTX dosyasını temsil eden [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini başlatın.
1. İndeksini kullanarak bir slaydın referansını alın.
1. Slaytların şekil koleksiyonuna erişin.
1. Grup şekline erişin.
1. [AlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getAlternativeText--) özelliğine erişin.

Aşağıdaki örnek grup şeklinin alternatif metnine erişir.

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("AltText.pptx");
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Slaytların şekil koleksiyonuna erişim
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Grup şekline erişim.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // AltText özelliğine erişim
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**İç içe gruplama (bir grup içinde başka bir grup) destekleniyor mu?**

Evet. [GroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/groupshape/) sınıfının [getParentGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getParentGroup--) yöntemi, hiyerarşi desteğini doğrudan gösterir (bir grup başka bir grubun çocuğu olabilir).

**Grubun z‑sırasını slayttaki diğer nesnelere göre nasıl kontrol edebilirim?**

Grubun görüntü yığını içindeki konumunu incelemek için [GroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/groupshape/)’nin [getZOrderPosition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getZOrderPosition--) yöntemini kullanın.

**Taşıma/düzenleme/grup çözmeyi engelleyebilir miyim?**

Evet. Grubun kilitleme bölümü, nesne üzerindeki işlemleri kısıtlamanıza izin veren [getGroupShapeLock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) yöntemi aracılığıyla sunulur.