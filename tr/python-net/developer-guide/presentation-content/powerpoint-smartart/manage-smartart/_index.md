---
title: Python Kullanarak PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- yerleşim türü
- gizli özelliği
- organizasyon şeması
- resim organizasyon şeması
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint SmartArt'ı net kod örnekleriyle oluşturmayı ve düzenlemeyi öğrenin; bu, slayt tasarımını ve otomasyonu hızlandırır."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşim ile oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for Python via .NET ile SmartArt oluşturabilir, düğümlerindeki metni okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resim organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Al**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Düğüm şekillerindeki metni okumak için [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/) üzerinde yineleme yapın, ardından [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) öğesini okuyun.

Örnek, en az bir slaytı ve o slayttaki ilk şekil olarak bir SmartArt nesnesi içeren bir sunum gerektirir. Her kullanılabilir metin çerçevesini konsola yazar.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **SmartArt Nesnesinin Yerleşim Türünü Değiştirme**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BASIC_PROCESS` değerine değiştirir ve sunumu kaydeder. [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) yöntemine geçirilen konum ve boyut değerleri puan cinsindendir. Yerleşimi değiştirmek için [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) ayarlayın.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etme**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Gizli düğümler, seçilen yerleşim onları görünür diyagram öğeleri olarak göstermese bile yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve eklenen düğümün gizli durumunu kontrol eder. Düğüm gizli ise bir mesaj yazdırır ve diyagramı kaydeder.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Organizasyon Şeması Yerleşimini Alıp Ayarlama**

Organizasyon şeması yerleşimi kullanan SmartArt diyagramları için [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) ebeveyn düğümün altındaki çocuk düğümlerin nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) değerine bağlı olarak çocuk düğümler soldan, sağdan veya iki taraftan sarkıtılabilir.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` değerine ayarlar. Sıfır‑bazlı indis `0` ilk üst‑seviye düğümü seçer; onun çocuk düğümleri seçilen düzeni kullanır. Değiştirilen sunum daha sonra kaydedilir.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Resim Organizasyon Şeması Oluşturma**

Resim organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. Slayta SmartArt nesnesi eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` değerini kullanın. Bu örnek, görüntü yer tutucularına sahip bir diyagramı kaydeder; yer tutuculara görüntü eklemez.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Eski Diyagramları Şekil Gruplarına Dönüştürme**

Mevcut bir sunumu modernize ederken, PowerPoint 97–2003’te oluşturulmuş bir organizasyon şemasını güncellemeniz gerekebilir. Aspose.Slides bu eski diyagramları [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) nesneleri olarak temsil eder. Bir diyagramı bireysel görsel öğeleri düzenleyebilmek için bir şekil grubu haline getirmek üzere [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) kullanın. Ayrıntılar için [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) sayfasına bakın.

Dönüşüm, orijinal diyagramı kaldırmadan şekil koleksiyonuna yeni bir grup ekler. Dönüşüm başarılı olduğunda, kopya içeriği önlemek için orijinali [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) ile kaldırın. Şekilleri ekleme ve kaldırma sırasında yineleme bozulmasın diye dönüştürmeden önce eski diyagramları bir listeye toplayın.

Aşağıdaki örnek bir sunumu açar, her slaytı tarar, diyagramları şekil gruplarına dönüştürür ve güncellenmiş sunumu PPTX olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

Kaydedilen sunum, dönüştürülmüş eski diyagramların yerine düzenlenebilir şekil grupları içerir; orijinal diyagramlar artık bulunmaz. PPTX dosyasını PowerPoint’te açarak her grup içinde metin, dolgu veya konum gibi bireysel öğeleri düzenleyebilirsiniz.

## **SSS**

**SmartArt RTL dilleri için yansıtma veya tersine çevirme destekliyor mu?**

Evet. [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) özelliği, seçilen SmartArt yerleşimi tersine çevirmeyi desteklediğinde diyagram yönünü soldan sağa’dan sağdan sola veya tersine değiştirir.

**Aynı slayta ya da başka bir sunuma biçimlendirmeyi koruyarak SmartArt nasıl kopyalanır?**

[SmartArt şekli kopyala](/slides/tr/python-net/shape-manipulations/) için [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) yöntemini veya SmartArt içeren slaytı [tüm slaytı kopyala](/slides/tr/python-net/clone-slides/) yöntemini kullanabilirsiniz. Her iki yaklaşım da boyut, konum ve biçimlendirmeyi korur.

**SmartArt ön izleme veya web dışa aktarımı için nasıl raster görüntüye dönüştürülür?**

[Slaytı render et](/slides/tr/python-net/convert-powerpoint-to-png/) veya tüm sunumu PNG veya JPEG olarak dışa aktarın. SmartArt slaytın bir parçası olarak işlenir.

**Bir slaytta birden fazla SmartArt nesnesi varsa belirli bir nesneyi nasıl bulurum?**

SmartArt şekline ayırt edici bir [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) veya [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) değeri atayın, bu değeri [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) içinde arayın ve eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) olduğundan emin olun.