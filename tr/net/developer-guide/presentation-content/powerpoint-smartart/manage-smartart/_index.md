---
title: .NET'te PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/net/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- yerleşim türü
- gizli özellik
- organizasyon şeması
- resimli organizasyon şeması
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint SmartArt'ı net C# kod örnekleriyle oluşturmayı ve düzenlemeyi öğrenin; bu, slayt tasarımını ve otomasyonu hızlandırır."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşimden oluşan bir PowerPoint diyagramıdır. Aspose.Slides for .NET ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Almak**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [ISmartArt.AllNodes](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartart/allnodes/) üzerinden yineleme yapın, ardından [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartartshape/textframe/) tarafından döndürülen [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) öğesini okuyun.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **SmartArt Nesnesinin Yerleşim Türünü Değiştirmek**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etmek**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartartnode/ishidden/) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen yerleşim, düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğüler yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Organizasyon Şeması Yerleşimini Almak veya Ayarlamak**

Organizasyon şeması yerleşimi kullanan SmartArt diyagramları için [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) alt düğümlerin bir üst düğümün altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/organizationchartlayouttype/) değerine göre alt düğümleri soldan, sağdan veya her iki taraftan sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` değerine ayarlar.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Resimli Organizasyon Şeması Oluşturmak**

Resimli organizasyon şeması, görüntü yer tutucularını içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**SmartArt RTL dilleri için yansıtma veya tersine çevirme destekliyor mu?**

Evet. [IsReversed](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartart/isreversed/) özelliği, seçilen SmartArt yerleşimi tersine çevirmeyi desteklediğinde diyagram yönünü soldan sağa’dan sağa sola’ya değiştirir, ya da tersine.

**Biçimlendirmeyi koruyarak SmartArt'ı aynı slayta veya başka bir sunuma nasıl kopyalarım?**

SmartArt şeklinin [kopyasını alabilirsiniz](/slides/tr/net/shape-manipulations/) [ShapeCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/shapecollection/addclone/) ile veya SmartArt içeren tüm slaytı [kopyalayabilirsiniz](/slides/tr/net/clone-slides/). Her iki yöntem de boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için bir raster görüntüye nasıl render ederim?**

[Slaytı render edin](/slides/tr/net/convert-powerpoint-to-png/) veya tüm sunumu PNG veya JPEG olarak dışa aktarın. SmartArt, slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa, belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline belirgin bir [AlternativeText](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/alternativetext/) veya [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/name/) değeri atayın, bu değeri [Slide.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslide/shapes/) içinde arayın ve ardından eşleşen şeklin bir [ISmartArt](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartart/) olup olmadığını kontrol edin.