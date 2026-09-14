---
title: Python ile Sunumlarda Çizim Kılavuzlarını Yönet
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/python-java/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- dikey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- layout slayt
- not master
- el kitabı master
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında yatay ve dikey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, PowerPoint’te bir sunumu düzenlerken şekilleri tutarlı bir şekilde hizalamaya yardımcı olan ayarlanabilir yatay ve dikey çizgilerdir. Özellikle bir uygulama, daha sonra manuel olarak iyileştirilecek bir sunum ürettiğinde faydalıdır: uygulama, yazarların içerik eklerken veya taşırken takip etmeleri gereken aynı hizalama yardımcılarını kaydedebilir.

Çizim kılavuzları düzenleme yardımcılarıdır, slayt içeriği değildir. Slayt gösterisinde veya oluşturulan çıktıda görünmezler. Aspose.Slides for Python via Java, bunları [DrawingGuidesCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguidescollection/) sınıfı aracılığıyla sunar. Bir kılavuz, [DrawingGuide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguide/) ile temsil edilir ve bir yönelim, bir konum ve bir renge sahiptir.

Konum, ilgili slayt veya master’ın sol üst köşesinden ölçülen puan cinsindendir. Dikey bir kılavuz, genellikle sıfır ile slayt genişliği arasında bir yatay koordinat kullanır. Yatay bir kılavuz, genellikle sıfır ile slayt yüksekliği arasında bir dikey koordinat kullanır.

## **Slayt Görünümüne Kılavuz Ekleme**

Normal slaytları düzenlerken görüntülenen kılavuzları yönetmek için [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) kullanın. [DrawingGuidesCollection.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguidescollection/#add) metodunu bir [Orientation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/orientation/) değeri ve puan cinsinden bir konum ile çağırın.

Aşağıdaki örnek, slayt ortasının sağında bir dikey kılavuz ve altında bir yatay kılavuz ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Çizim Kılavuzlarına Erişim**

Mevcut kılavuzlara erişmek için [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguidescollection/#getCount) ve [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguidescollection/#get_Item) metodlarını kullanın. [DrawingGuide.getOrientation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguide/#getPosition) ve [DrawingGuide.getColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguide/#getColor) metodları değer döndürür; bu değerler ilgili ayarlayıcı metodlar kullanılarak da değiştirilebilir.

Aşağıdaki örnek, yukarıda oluşturulan sunumun slayt‑görünüm kılavuzlarını okur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Master ve Layout Slaytlarına Kılavuz Ekleme**

Bir slide master ve her bir layout slaytı kendi çizim‑kılavuz koleksiyonlarına sahip olabilir. Master slayt için [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getDrawingGuides), layout slayt için ise [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getDrawingGuides) kullanın.

Aşağıdaki örnek, ilk master slayta bir dikey kılavuz ve ilk layout slayta bir yatay kılavuz ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Not ve El Kitabı Masterlarına Kılavuz Ekleme**

Not masterları ve el kitabı masterları da çizim kılavuzlarını destekler. Kolleksiyonlarına erişmek için [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masternotesslide/#getDrawingGuides) ve [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) kullanın. Bir sunum bu masterlardan birini içermiyorsa, `MasterNotesSlideManager.setDefaultMasterNotesSlide` veya `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` varsayılan masterı oluşturur ve döndürür.

Aşağıdaki örnek, bir not masterına bir yatay kılavuz ve bir el kitabı masterına bir dikey kılavuz ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Çizim Kılavuzlarını Temizleme**

Belirli bir koleksiyondaki tüm kılavuzları kaldırmak için [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguidescollection/#clear) metodunu çağırın. Bir koleksiyonun temizlenmesi, başka bir kapsamda depolanan kılavuzları etkilemez.

Aşağıdaki örnek, slayt‑görünüm kılavuzlarını ve slayt masterları, layout slaytlar, not master ve el kitabı masterındaki tüm kılavuzları eksik masterlar oluşturmadan temizler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Çizim kılavuzları slayt gösterisinde veya dışa aktarılan görüntülerde görünür mü?**

Hayır. Çizim kılavuzları, düzenleme için hizalama yardımcılarıdır ve sunum içeriği olarak işlenmez.

**Bir çizim kılavuzu doğrudan bireysel normal bir slayta eklenebilir mi?**

Normal slayt düzenleme kılavuzları, sunumun slayt‑görünüm özelliklerinde depolanır. Slide masterları, layout slaytlar, not masterları ve el kitabı masterları için ayrı kılavuz koleksiyonları mevcuttur.

**Kılavuz konumları için hangi birimler kullanılır?**

Konumlar puan cinsinden belirtilir; 72 puan bir inçtir. Dikey konumlar sol kenardan, yatay konumlar üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri veya slayt içeriğini değiştirir mi?**

Hayır. [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/drawingguidescollection/#clear) metodu yalnızca seçilen koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içeriği değişmeden kalır.