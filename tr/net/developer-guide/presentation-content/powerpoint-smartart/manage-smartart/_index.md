---
title: PowerPoint Sunumlarında .NET ile SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/net/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- yerleşim türü
- gizli özelliği
- organizasyon şeması
- resim organizasyon şeması
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Net üzerinde Aspose.Slides ile PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi, kaydırak tasarımı ve otomasyonu hızlandıran açık C# kod örnekleri kullanarak öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşimden oluşan bir PowerPoint diyagramıdır. Aspose.Slides for .NET ile SmartArt oluşturabilir, düğümlerindeki metni okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resim organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Almak**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Düğüm şekillerindeki metni okuyabilmek için [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/) üzerinden yineleme yapın, ardından [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) tarafından döndürülen [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) nesnesini okuyun.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **SmartArt Nesnesinin Yerleşim Türünü Değiştirme**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, onu `BasicProcess` değerine değiştirir ve sunumu kaydeder. [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) metoduna geçirilen konum ve boyut değerleri puan (point) cinsindendir. Yerleşimi değiştirmek için [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) özelliğini ayarlayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etme**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) özelliği, düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçili yerleşim, gizli düğümleri görünür diyagram öğeleri olarak göstermese bile, gizli düğümler yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` değerine sahip bir SmartArt nesnesine bir düğüm ekler ve eklenen düğümün gizli durumunu kontrol eder. Düğüm gizli ise bir mesaj yazdırır ve diyagramı kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Organizasyon Şeması Yerleşimini Almak veya Ayarlamak**

Organizasyon şeması yerleşimi kullanan SmartArt diyagramları için, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) özelliği, alt düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) değerine bağlı olarak alt düğümler sol, sağ veya her iki taraftan sarkıtılabilir.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` değeriyle ayarlar. Sıfır‑tabanlı indeks `0`, ilk üst‑seviye düğümü seçer; alt düğümler seçilen düzenlemeyi kullanır. Değiştirilen sunum daha sonra kaydedilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Resim Organizasyon Şeması Oluşturma**

Resim organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın. Bu örnek, görüntü yer tutucularına sahip bir diyagram kaydeder; yer tutucular görüntülerle doldurulmaz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Eski Diyagramları Şekil Gruplarına Dönüştürme**

Mevcut bir sunumu modernleştirirken, PowerPoint 97–2003’te oluşturulmuş bir organizasyon şemasını güncellemeniz gerekebilir. Aspose.Slides, bu eski diyagramları [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) nesneleri olarak temsil eder. Bir diyagramı, bireysel görsel öğeleri düzenleyebilmek için bir şekil grubuna dönüştürmek üzere [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) kullanın. Ayrıntılar için [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) sayfasına bakın.

Dönüşüm, orijinal diyagramı kaldırmadan şekil koleksiyonuna yeni bir grup ekler. Başarılı dönüşümden sonra, kopya içeriği önlemek için orijinali [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) ile kaldırın. Dönüştürmeden önce eski diyagramları bir diziye toplayın; böylece şekil ekleme ve kaldırma, yineleme sırasında bozulmaz.

Aşağıdaki örnek bir sunumu açar, her slaytı tarar, diyagramları şekil gruplarına dönüştürür ve güncellenmiş sunumu PPTX olarak kaydeder.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Kaydedilen sunum, dönüştürülmüş eski diyagramların yerine düzenlenebilir şekil grupları içerir; yanlarında orijinal diyagram kalmaz. PPTX dosyasını PowerPoint’te açarak her grup içindeki metin, dolgu veya konum gibi bireysel öğeleri düzenleyebilirsiniz.

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya ters çevirme özelliğini destekliyor mu?**

Evet. Seçili SmartArt yerleşimi ters çevirme destekliyorsa, [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) özelliği diyagram yönünü soldan sağa’dan sağdan sola’ya veya tersine değiştirir.

**SmartArt'ı aynı slayta veya başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalarım?**

SmartArt şekli [SmartArt şekli kopyalayın](/slides/tr/net/shape-manipulations/) ile [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) ya da SmartArt içeren tüm slaytı [tüm slaytı kopyalayın](/slides/tr/net/clone-slides/) ile kopyalayabilirsiniz. Her iki yaklaşım da boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarma için raster görüntüye nasıl render ederim?**

[Slaytı render edin](/slides/tr/net/convert-powerpoint-to-png/) ya da tüm sunumu PNG veya JPEG formatına render edin. SmartArt, slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa belirli bir nesneyi nasıl bulabilirim?**

SmartArt şekline ayırt edici bir [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) veya [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) değeri atayın, bu değeri [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) içinde arayın ve ardından eşleşen şeklin bir [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) olduğundan emin olun.