---
title: PowerPoint Sunumlarında Python Kullanarak SmartArt Yönetimi
linktitle: SmartArt'ı Yönet
type: docs
weight: 10
url: /tr/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- düzen türü
- gizli özelliği
- organizasyon şeması
- resim organizasyon şeması
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi, slayt tasarımı ve otomasyonunu hızlandıran net kod örnekleriyle öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir düzen kullanılarak oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for Python via Java ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, düzenini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması düzenlerini yapılandırabilir ve resim organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Almak**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [SmartArt.getAllNodes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/#getAllNodes) üzerinden yineleyin, ardından [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartshape/#getTextFrame) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) öğesini okuyun.

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

## **SmartArt Nesnesinin Düzen Türünü Değiştirmek**

SmartArt düzeni, düğümlerin nasıl yerleştirildiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etmek**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/#isHidden) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen düzen, düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğüller yapıda var olabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Organizasyon Şeması Düzenini Almak veya Ayarlamak**

Organizasyon şeması düzeni kullanan SmartArt diyagramları için [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) ve [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) çocuk düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/organizationchartlayouttype/)’a bağlı olarak çocuk düğümler sol, sağ ya da her iki taraftan sarkıtılabilir.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün düzenini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` değerine ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Resim Organizasyon Şeması Oluşturma**

Resim organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt düzenidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**SmartArt RTL dilleri için aynalama veya ters çevirmeyi destekliyor mu?**

Evet. [SmartArt.setReversed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/#setReversed) yöntemi, seçilen SmartArt düzeni ters çevirmeyi desteklediğinde diyagram yönünü soldan sağa’dan sağa sola (right-to-left) değiştirir veya geri alır.

**Biçimlendirmeyi koruyarak SmartArt'ı aynı slayta veya başka bir sunuma nasıl kopyalarım?**

SmartArt şeklinin [kopyasını oluşturabilirsiniz](/slides/tr/python-java/shape-manipulations/) [ShapeCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addClone) ile veya SmartArt'ı içeren tüm slaytı [klonlayabilirsiniz](/slides/tr/python-java/clone-slides/) . Her iki yöntem de boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı ön izleme veya web dışa aktarma için raster görüntüye nasıl render ederim?**

[Render the slide](/slides/tr/python-java/convert-powerpoint-to-png/) veya tüm sunumu PNG ya da JPEG olarak render edin. SmartArt slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir [Shape.getAlternativeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getAlternativeText) ya da [Shape.getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getName) değeri atayın, bu değeri [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getShapes) içinde arayın ve ardından eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) olduğunu kontrol edin.