---
title: Java’da Grup Sunum Şekilleri
linktitle: Şekil Grubu
type: docs
weight: 40
url: /tr/java/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarında şekilleri gruplama ve gruptan çıkarma öğrenin—hızlı, adım adım rehber ve ücretsiz Java kodu."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grup şekilleriyle nasıl çalışılacağını açıklar. Bir grup şeklinin slayta nasıl ekleneceğini, içinde şekillerin nasıl konumlandırılacağını ve güncellenmiş sunumun nasıl kaydedileceğini gösterir. Ayrıca, bir grup içinde depolanan şekillere nasıl erişileceğini ve bunların `AlternativeText` (AlternatifMetin) değerlerinin nasıl okunacağını gösterir. Ek olarak, iç içe gruplar, z-sırası ve kilitleme seçenekleri gibi ilgili grup‑şekil yeteneklerine kısaca değinir.

## **Grup Şekli Ekleme**
Aspose.Slides, slaytlarda grup şekilleriyle çalışmayı destekler. Bu özellik, geliştiricilerin daha zengin sunumlar oluşturmasına yardımcı olur. Aspose.Slides for Java, grup şekilleri eklemeyi veya bunlara erişmeyi destekler. Eklenen bir grup şekline şekil ekleyerek onu doldurabilir veya grup şeklinin herhangi bir özelliğine erişebilirsiniz. Aspose.Slides for Java kullanarak bir slayta grup şekli eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın indeksini kullanarak slayt referansını alın.  
1. Slayta bir grup şekli ekleyin.  
1. Eklenen grup şekline şekilleri ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek, bir slayta grup şekli ekler.

```java
// Presentation sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Slaytların şekil koleksiyonuna erişiliyor
    IShapeCollection slideShapes = sld.getShapes();

    // Slayta bir grup şekli ekleniyor
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Eklenen grup şeklinin içine şekiller ekleniyor
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Grup şekli çerçevesi ekleniyor
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTX dosyasını diske yaz
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **AltText Özelliğine Erişme**
Bu bölüm, grup şekli eklemek ve slaytlardaki grup şekillerinin AltText özelliğine erişmek için kod örnekleriyle birlikte basit adımları gösterir. Aspose.Slides for Java kullanarak bir slayttaki grup şeklinin AltText’ine erişmek için:

1. PPTX dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın indeksini kullanarak slayt referansını alın.  
1. Slaytların şekil koleksiyonuna erişin.  
1. Grup şekline erişin.  
1. [AlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getAlternativeText--) özelliğine erişin.

Aşağıdaki örnek, grup şeklinin alternatif metnine erişir.

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("AltText.pptx");
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Slaytların şekil koleksiyonuna erişiliyor
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Grup şekline erişiliyor.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // AltText özelliğine erişiliyor
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**İç içe gruplama (bir grup içinde bir grup) destekleniyor mu?**

Evet. [GroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/groupshape/) sınıfının [getParentGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getParentGroup--) yöntemi, hiyerarşi desteğini doğrudan gösterir (bir grup başka bir grubun çocuğu olabilir).

**Grubun z-sırasını slayttaki diğer nesnelere göre nasıl kontrol edebilirim?**

Grubun gösterim yığını içindeki konumunu incelemek için [GroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/groupshape/)’nin [getZOrderPosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getZOrderPosition--) yöntemini kullanın.

**Hareket ettirmeyi/düzenlemeyi/gruptan çıkarmayı engelleyebilir miyim?**

Evet. Grubun kilitleme bölümü, nesne üzerindeki işlemleri kısıtlamanızı sağlayan [GroupShapeLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/groupshape/#getGroupShapeLock--) aracılığıyla ortaya çıkar.