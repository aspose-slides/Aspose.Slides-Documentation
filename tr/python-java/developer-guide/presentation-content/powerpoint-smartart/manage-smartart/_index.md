---
title: Python Kullanarak PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- düzen türü
- gizli özelliği
- organizasyon şeması
- resimli organizasyon şeması
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint SmartArt oluşturmayı ve düzenlemeyi, slayt tasarımı ve otomasyonunu hızlandıran net kod örnekleriyle öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir düzen kullanılarak oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for Python via Java ile SmartArt oluşturabilir, düğümlerindeki metni okuyabilir, düzenini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması düzenlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Alma**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Düğüm şekillerindeki metni okumak için [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes) üzerinden yineleme yapın, ardından [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) öğesini okuyun.

Örnek, en az bir slaytı ve o slaytta ilk şekil olarak bir SmartArt nesnesi bulunan bir sunum gerektirir. Her kullanılabilir metin çerçevesini konsola yazdırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **SmartArt Nesnesinin Düzen Türünü Değiştirme**

SmartArt düzeni, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder. [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt)'a geçirilen konum ve boyut noktalar cinsindendir. Düzeni değiştirmek için [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etme**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen düzen, düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğümler yapıda var olabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve eklenen düğümün gizli durumunu kontrol eder. Düğüm gizli ise bir mesaj yazdırır ve diyagramı kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Organizasyon Şeması Düzenini Almak veya Ayarlamak**

Organizasyon şeması düzeni kullanan SmartArt diyagramları için, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) ve [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) alt düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) değerine bağlı olarak alt düğümleri sol, sağ veya her iki taraftan sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün düzenini [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` değerine ayarlar. Sıfırdan başlayan `0` dizini, ilk üst düzey düğümü seçer; alt düğümleri seçilen düzeni kullanır. Değiştirilmiş sunum daha sonra kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Resimli Organizasyon Şeması Oluşturma**

Resimli organizasyon şeması, resim yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt düzenidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın. Bu örnek, resim yer tutucuları içeren bir diyagramı kaydeder; yer tutuculara resim eklemez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eski Diyagramları Şekil Gruplarına Dönüştürme**

Mevcut bir sunumu modernleştirirken, PowerPoint 97–2003'te oluşturulmuş bir organizasyon şemasını güncellemeniz gerekebilir. Aspose.Slides bu eski diyagramları [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) nesneleri olarak temsil eder. Bir diyagramı, bireysel görsel öğeleri düzenleyebilmek için şekil grubuna dönüştürmek amacıyla [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) kullanın. Ayrıntılar için [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) bölümüne bakın.

Dönüştürme, orijinal diyagramı kaldırmadan şekil koleksiyonuna yeni bir grup ekler. Başarılı dönüşümden sonra, yinelenen içeriği önlemek için orijinali [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) ile kaldırın. Şekil ekleme ve kaldırma işlemleri yinelemeyi bozmasın diye, dönüştürmeden önce eski diyagramları bir listeye toplayın.

Aşağıdaki örnek bir sunumu açar, her slaytı tarar, diyagramları şekil gruplarına dönüştürür ve güncellenmiş sunumu PPTX olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kaydedilen sunum, dönüştürülmüş eski diyagramların yerine düzenlenebilir şekil grupları içerir ve yanlarında orijinal diyagramlar bulunmaz. PPTX dosyasını PowerPoint'te açarak her grup içindeki metin, dolgu veya konum gibi bireysel öğeleri düzenleyebilirsiniz.

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya tersine çevirme destekliyor mu?**

Evet. Seçilen SmartArt düzeni tersine çevirme destekliyorsa, [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) yöntemi diyagram yönünü soldan sağa’dan sağdan sola’ya veya tersine değiştirir.

**SmartArt'ı aynı slayta ya da başka bir sunuma formatı koruyarak nasıl kopyalarım?**

SmartArt şeklini [SmartArt şekli klonlamasını](/slides/tr/python-java/shape-manipulations/) [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) ile veya SmartArt içeren [tüm slaytı klonlamayı](/slides/tr/python-java/clone-slides/) yaparak klonlayabilirsiniz. Her iki yaklaşım da boyutu, konumu ve biçimlendirmeyi korur.

**SmartArt'ı ön izleme veya web aktarımı için raster görüntüye nasıl render ederim?**

[Slaytı render edin](/slides/tr/python-java/convert-powerpoint-to-png/) veya tüm sunumu PNG ya da JPEG formatına. SmartArt, slaytın bir parçası olarak render edilir.

**Birden fazla SmartArt nesnesi olduğunda, belirli bir SmartArt nesnesini bir slaytta nasıl bulabilirim?**

SmartArt şekline ayırt edilebilir bir alternatif metin veya ad atamak için [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) veya [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) kullanın, bu değeri [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) içinde arayın ve eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) olduğunu kontrol edin.