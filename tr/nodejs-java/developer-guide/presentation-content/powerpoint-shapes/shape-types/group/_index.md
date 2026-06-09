---
title: JavaScript'te Grup Sunum Şekilleri
linktitle: Şekil Grubu
type: docs
weight: 40
url: /tr/nodejs-java/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında şekilleri gruplama ve gruptan ayırma öğrenin — hızlı, adım adım rehber ve ücretsiz JavaScript kodu."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grup şekilleri ile nasıl çalışılacağını açıklar. Bir slayta grup şekli eklemeyi, içine şekiller yerleştirmeyi ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca bir grup içinde depolanan şekillere nasıl erişileceğini ve bunların `AlternativeText` değerlerini nasıl okuyacağınızı da gösterir. Ek olarak, makale iç içe gruplar, z‑sırası ve kilitleme seçenekleri gibi ilgili grup‑şekli özelliklerine kısaca değinir.

## **Grup Şekli Ekle**
Aspose.Slides, slaytlarda grup şekilleriyle çalışmayı destekler. Bu özellik, geliştiricilerin daha zengin sunumlar oluşturmasına yardımcı olur. Aspose.Slides for Node.js via Java, grup şekilleri eklemeyi veya onlara erişmeyi destekler. Eklenen bir grup şekline şekil ekleyerek onu doldurmak veya grup şeklinin herhangi bir özelliğine erişmek mümkündür. Aspose.Slides for Node.js via Java kullanarak bir slayta grup şekli eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Index'ini kullanarak bir slaytın referansını alın.
3. Slayta bir grup şekli ekleyin.
4. Eklenen grup şekline şekilleri ekleyin.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir slayta grup şekli ekler.

```javascript
// Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Slaytların şekil koleksiyonuna erişiliyor
    var slideShapes = sld.getShapes();
    // Slayta bir grup şekli ekleniyor
    var groupShape = slideShapes.addGroupShape();
    // Eklenen grup şeklinin içine şekiller ekleniyor
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Grup şekli çerçevesi ekleniyor
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // PPTX dosyasını diske kaydet
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **AltText Özelliğine Erişim**
Bu konu, bir grup şekli eklemek ve slaytlardaki grup şekillerinin AltText özelliğine erişmek için kod örnekleriyle birlikte basit adımları gösterir. Aspose.Slides for Node.js via Java kullanarak bir slayttaki grup şeklinin AltText'ine erişmek için:

1. PPTX dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Index'ini kullanarak bir slaytın referansını alın.
3. Slaytların şekil koleksiyonuna erişin.
4. Grup şekline erişin.
5. [getAlternativeText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getAlternativeText--) özelliğini çağırın.

Aşağıdaki örnek grup şeklinin alternatif metnine erişir.

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Slaytların şekil koleksiyonuna erişiliyor
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Grup şekline erişiliyor.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // AltText özelliğine erişiliyor
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**İç içe gruplama (bir grup içinde bir grup) destekleniyor mu?**

Evet. [GroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/) sınıfının, hiyerarşi desteğini doğrudan gösteren bir [getParentGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getparentgroup/) metodu vardır (bir grup başka bir grubun çocuğu olabilir).

**Grubun z‑sırasını slayttaki diğer nesnelere göre nasıl kontrol edebilirim?**

[GroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/)'in [getZOrderPosition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getzorderposition/) metodunu kullanarak görüntü yığını içindeki konumunu inceleyin.

**Taşıma/düzenleme/grup çözmeyi engelleyebilir miyim?**

Evet. Grup kilitleme bölümü, [GroupShapeLock](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) aracılığıyla sunulur; bu sayede nesne üzerindeki işlemleri kısıtlayabilirsiniz.