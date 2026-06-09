---
title: .NET'te Grup Sunum Şekilleri
linktitle: Şekil Grubu
type: docs
weight: 40
url: /tr/net/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında şekilleri gruplama ve gruptan çıkarma hakkında öğrenin—hızlı, adım adım rehber ve ücretsiz C# kodu."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grup şekilleriyle nasıl çalışılacağını açıklar. Bir slayta grup şekli eklemeyi, içine şekiller yerleştirmeyi ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca bir grup içinde depolanan şekillere nasıl erişileceğini ve bunların `AlternativeText` değerlerini nasıl okunacağını gösterir. Ek olarak, makale iç içe grup, z-sırası ve kilitleme seçenekleri gibi ilgili grup şekli özelliklerine kısaca değinir.

## **Grup Şekli Ekleme**
Aspose.Slides, slaytlarda grup şekilleriyle çalışmayı destekler. Bu özellik, geliştiricilerin daha zengin sunumlar oluşturmasına yardımcı olur. Aspose.Slides for .NET, grup şekilleri eklemeyi veya erişmeyi destekler. Eklenen bir grup şekline şekil ekleyerek onu doldurmak veya grup şeklinin herhangi bir özelliğine erişmek mümkündür. Aspose.Slides for .NET kullanarak bir slayta grup şekli eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Slaydın indeksini kullanarak onun referansını alın
3. Slayta bir grup şekli ekleyin.
4. Eklenen grup şekline şekilleri ekleyin.
5. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir slayta grup şekli ekler.

```c#
// Presentation sınıfını örnekle 
using (Presentation pres = new Presentation())
{
    // İlk slaytı al 
    ISlide sld = pres.Slides[0];

    // Slaytların şekil koleksiyonuna erişme 
    IShapeCollection slideShapes = sld.Shapes;

    // Slayta bir grup şekli ekleme 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Eklenen grup şekli içine şekiller ekleme 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Grup şekli çerçevesi ekleme 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // PPTX dosyasını diske yaz 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **AltText Özelliğine Erişme**
Bu konu, grup şekli eklemek ve slaytlardaki grup şekillerinin AltText özelliğine erişmek için kod örnekleriyle birlikte basit adımları gösterir. Aspose.Slides for .NET kullanarak bir slayttaki grup şeklinin AltText'ine erişmek için:

1. PPTX dosyasını temsil eden `Presentation` sınıfının bir örneğini oluşturun.
2. Slaydın indeksini kullanarak onun referansını alın.
3. Slaydların şekil koleksiyonuna erişin.
4. Grup şekline erişin.
5. AltText özelliğine erişin.

Aşağıdaki örnek grup şeklinin alternatif metnine erişir.

```c#
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("AltText.pptx");

// İlk slaytı al
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Slaytların şekil koleksiyonuna erişme
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Grup şekline erişme.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // AltText özelliğine erişme
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**İç içe gruplama (bir grup içinde grup) destekleniyor mu?**

Evet. [GroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides/groupshape/) sınıfının bir [ParentGroup](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/parentgroup/) özelliği vardır; bu doğrudan hiyerarşi desteğini gösterir (bir grup başka bir grubun çocuğu olabilir).

**Grupun slayttaki diğer nesnelere göre z-sırasını nasıl kontrol edebilirim?**

[GroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides/groupshape/)’nin [ZOrderPosition](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/zorderposition/) özelliğini kullanarak görüntü yığını içindeki konumunu inceleyin.

**Taşıma/düzenleme/grup çözmeyi önleyebilir miyim?**

Evet. Grup kilitleme bölümü, nesne üzerindeki işlemleri kısıtlamanıza olanak sağlayan [GroupShapeLock](https://reference.aspose.com/slides/tr/net/aspose.slides/groupshape/groupshapelock/) aracılığıyla sunulur.