---
title: PowerPoint Sunumlarında Python Kullanarak SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt'tan metin
- yerleşim türü
- gizli özellik
- organizasyon şeması
- resim organizasyon şeması
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint SmartArt oluşturmayı ve düzenlemeyi, slayt tasarımı ve otomasyonunu hızlandıran net kod örnekleriyle öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşimden oluşan bir PowerPoint diyagramıdır. Aspose.Slides for Python via .NET ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resim organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Alma**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [SmartArt.all_nodes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/all_nodes/) üzerinden yineleyin, ardından [SmartArtShape.text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartartshape/text_frame/) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) öğesini okuyun.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **SmartArt Nesnesinin Yerleşim Türünü Değiştirme**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BASIC_PROCESS` değerine değiştirir ve sunumu kaydeder.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etme**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartartnode/is_hidden/) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Gizli düğümler, seçilen yerleşim onları görünür diyagram öğeleri olarak göstermese bile yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Organizasyon Şeması Yerleşimini Almak veya Ayarlamak**

Organizasyon şeması yerleşimi kullanan SmartArt diyagramları için [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) çocuk düğümlerin bir ana düğüm altında nasıl düzenlendiğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/organizationchartlayouttype/) değerine bağlı olarak çocuk düğümler sol, sağ veya her iki taraftan sarkıtılabilir.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` değeriyle ayarlar.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Resim Organizasyon Şeması Oluşturma**

Resim organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. Slayta SmartArt nesnesi eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` değerini kullanın.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt RTL dilleri için yansıtma veya tersine çevirme destekliyor mu?**

Evet. [SmartArt.is_reversed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/is_reversed/) özelliği, seçilen SmartArt yerleşimi tersine çevirmeyi destekliyorsa, diyagram yönünü soldan sağa’dan sola veya geri değiştirir.

**SmartArt'ı aynı slayta ya da başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalayabilirim?**

SmartArt şekli [ShapeCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_clone/) ile [/slides/tr/python-net/shape-manipulations/] klonlayabilir veya SmartArt'ı içeren slaytı [/slides/tr/python-net/clone-slides/] klonlayabilirsiniz. Her iki yöntem de boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için raster görüntüye nasıl render edebilirim?**

[/slides/tr/python-net/convert-powerpoint-to-png/] ile slaytı veya tüm sunumu PNG ya da JPEG formatına dönüştürün. SmartArt, slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa, belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir [Shape.alternative_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/alternative_text/) veya [Shape.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/name/) değeri atayın, bu değeri [Slide.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/shapes/) içinde arayın ve ardından eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/) olduğundan emin olun.