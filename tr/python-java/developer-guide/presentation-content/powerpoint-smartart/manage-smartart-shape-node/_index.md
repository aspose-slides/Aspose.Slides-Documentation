---
title: Presentasyonlarda Python Kullanarak SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/python-java/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüm erişimi
- düğüm kaldırma
- özel konum
- asistan düğüm
- dolgu biçimi
- düğüm işleme
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PPT ve PPTX dosyalarındaki SmartArt şekil düğümlerini yönetin. Sunumlarınızı kolaylaştırmak için açık kod örnekleri ve ipuçları alın."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikler, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleme, alt düğümleri belirli bir konuma ekleme, mevcut düğümlere erişme ve bunların metnini, seviyesini ve konumunu okuma.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğüm kaldırma, alt düğümlerle indeks veya konum üzerinden çalışma, bir asistan düğümünü normal düğüm haline getirme, SmartArt düğüm şekillerinin konum, boyut ve döndürmesini ayarlama, düğüm dolgu biçimlerini ayarlama ve bir SmartArt alt düğümünün küçük resim görüntüsü oluşturma konularını gösterir.

## **SmartArt Düğümü Ekle**
Aspose.Slides for Python via Java, SmartArt şekillerini yönetmek için bir API sağlar. Aşağıdaki örnek bir SmartArt şekline bir düğüm ve bir alt düğüm ekler.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) instance.
1. [Yeni bir düğüm ekle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnodecollection/#addNode) to the SmartArt shape’s [düğüm koleksiyonu](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/#getAllNodes) and set its text through [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/).
1. [Alt bir düğüm ekle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnodecollection/#addNode) to the new node and set its text through [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/).
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Belirli Bir Konumda SmartArt Düğümü Ekle**
Aşağıdaki örnek bir SmartArt düğümünde belirli bir konumda bir alt düğüm ekler.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class.
1. Get the first slide by its index.
1. Add a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) shape with the [StackedList](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartlayouttype/#StackedList) layout to the slide.
1. Access the first node in the added SmartArt shape.
1. Add a child node to the selected node at position 2 using [addNodeByPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) and set its text.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt Düğümüne Erişme**
Aşağıdaki örnek bir SmartArt şeklinin düğümlerine erişir. [getLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/#getLayout) tarafından döndürülen düzen yalnızca okunur ve SmartArt şekli eklendiğinde ayarlanır.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) instance.
1. Iterate through all [düğümler](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/#getAllNodes) in the SmartArt shape.
1. Read and display each SmartArt node’s position, level, and text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt Alt Düğümüne Erişme**
Aşağıdaki örnek bir SmartArt şeklinin her düğümünün alt düğümlerine erişir.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) instance.
1. Iterate through all [düğümler](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/#getAllNodes) in the SmartArt shape.
1. For each node, iterate through its [alt düğümler](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/#getChildNodes).
1. Read and display the [alt düğüm](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/#getChildNodes) position, level, and text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Belirli Bir Konumda SmartArt Alt Düğümüne Erişme**
Aşağıdaki örnek bir alt düğümün ebeveyn düğüm koleksiyonundaki belirli bir indeksine erişir.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class.
1. Get the first slide by its index.
1. Add a SmartArt shape with the [StackedList](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartlayouttype/#StackedList) layout.
1. Access the added SmartArt shape.
1. Access the node at index 0 in the SmartArt shape.
1. Access the child node at index 1 using [get_Item](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnodecollection/#get_Item).
1. Read and display the [alt düğüm](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/#getChildNodes) position, level, and text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt Düğümünü Kaldırma**
Aşağıdaki örnek bir SmartArt şekline ait bir düğümü kaldırır.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) instance.
1. Check that the [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) shape contains at least one node.
1. Select the SmartArt node to be deleted.
1. Remove the selected node using [removeNode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Belirli Bir Konumdan SmartArt Düğümünü Kaldırma**
Aşağıdaki örnek bir SmartArt düğümünün koleksiyonundaki belirli bir indeksdeki alt düğümü kaldırır.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) instance.
1. Access the SmartArt node at index 0 if it exists.
1. Check that the selected SmartArt node has at least two child nodes.
1. Remove the child node at index 1 using [removeNode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt Nesnesindeki Alt Düğüm İçin Özel Konum Ayarlama**
Aspose.Slides for Python via Java, [SmartArtShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartshape/) konumunu [setX](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setX) ve [setY](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setY) kullanarak ayarlamayı destekler. Aşağıdaki örnek SmartArt düğüm şekilleri için özel bir konum, boyut ve döndürme ayarlar. Yeni düğüm eklemek tüm düğümlerin konum ve boyutlarını yeniden hesaplar. Özel konumlandırma, düğümleri gerektiği gibi düzenlemenizi sağlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Asistan Düğümünü Kontrol Etme**
{{% alert color="info" title="Note" %}} 

Bu bölüm, Aspose.Slides for Python via Java kullanılarak programlı olarak sunum slaytlarına eklenen SmartArt şekillerini inceler.

{{% /alert %}} 

Aşağıdaki kaynak SmartArt şekli bu örnekte kullanılmıştır.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Şekil: Slaytta Kaynak SmartArt şekli**|

Aşağıdaki örnek bir SmartArt düğüm koleksiyonundaki asistan düğümlerini tespit eder ve bunları normal düğümlere dönüştürür.

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) instance.
1. Iterate through all nodes in the SmartArt shape and check whether they are [Assistant Nodes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartnode/#isAssistant).
1. Change each assistant node to a normal node.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Şekil: Slaytta bir SmartArt şekline eklenen asistan düğümlerinin değişimi**|

## **Bir Düğümün Dolgu Biçimini Ayarlama**
Aspose.Slides for Python via Java, özel SmartArt şekilleri eklemeyi ve dolgu biçimlerini ayarlamayı mümkün kılar. Bu makale, SmartArt şekillerinin nasıl oluşturulup erişileceğini ve dolgu biçimlerinin nasıl ayarlanacağını Aspose.Slides for Python via Java kullanarak açıklar.

Lütfen aşağıdaki adımları izleyin:

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class.
1. Get a slide by its index.
1. Add a [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) shape with the [ClosedChevronProcess](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) layout.
1. Set the [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getFillFormat) for the SmartArt shape nodes.
1. Write the modified presentation as a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir SmartArt Alt Düğümünün Küçük Resmini Oluşturma**
Bir SmartArt alt düğümünün küçük resmini oluşturmak için şu adımları izleyin:

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) class.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addSmartArt).
1. Get a node by its index.
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **SSS**

**SmartArt animasyonu destekleniyor mu?**

Evet. SmartArt normal bir şekil olarak ele alınır, bu nedenle [standart animasyonlar](/slides/tr/python-java/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulanabilir ve zamanlamalar ayarlanabilir. Gerektiğinde SmartArt düğümleri içindeki şekiller de animasyonlandırılabilir.

**İç kimliği bilinmeyen bir SmartArt'ı slaytta güvenilir bir şekilde nasıl bulabilirim?**

[Alternatif metin](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getAlternativeText) atayarak ve bu metne göre arama yaparak. SmartArt üzerine ayırt edici alternatif metin ayarlamak, iç kimliklere güvenmeden programlı olarak bulunmasını sağlar.

**Sunumu PDF'ye dönüştürürken SmartArt görünümü korunur mu?**

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/python-java/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel doğrulukla işler, düzeni, renkleri ve efektleri korur.

**Tüm SmartArt'ın bir görüntüsünü (ön izlemeler veya raporlar için) çıkarabilir miyim?**

Evet. Bir SmartArt şekli, [raster biçimlerde]https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) ya da ölçeklenebilir vektör çıkışı için [SVG]https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#writeAsSvgToBytes) olarak render edilebilir; bu, küçük resimler, raporlar veya web kullanımı için uygundur.