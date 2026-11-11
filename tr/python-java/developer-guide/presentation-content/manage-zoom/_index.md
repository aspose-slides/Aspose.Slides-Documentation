---
title: Python üzerinden Java ile Sunum Yakınlaştırmasını Yönet
linktitle: Yakınlaştırmayı Yönet
type: docs
weight: 60
url: /tr/python-java/manage-zoom/
keywords:
- yakınlaştırma
- yakınlaştırma çerçevesi
- slayt yakınlaştırması
- bölüm yakınlaştırması
- özet yakınlaştırma
- yakınlaştırma ekle
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile Yakınlaştırma oluşturun ve özelleştirin — bölümler arasında geçiş yapın, PowerPoint sunumlarına küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint yakınlaştırmaları, bir slayt gösterisi sırasında belirli slaytlar ve bölümler arasında gezinmenizi sağlar. Aspose.Slides for Python via Java ile slayt, bölüm ve özet yakınlaştırmaları oluşturabilir ve ön izlemelerini, kenarlıklarını ve geçişlerini özelleştirebilirsiniz.

![PowerPoint yakınlaştırma genel bakışı](overview.png)

* Tek bir slaytta tüm sunumu özetlemek için bir [Özet Yakınlaştırma](#summary-zoom) kullanın.
* Yalnızca seçili slaytları göstermek için bir [Slayt Yakınlaştırma](#slide-zoom) kullanın.
* Yalnızca tek bir bölümü göstermek için bir [Bölüm Yakınlaştırma](#section-zoom) kullanın.

## **Slayt Yakınlaştırma**

Bir slayt yakınlaştırması, sunumunuzu daha dinamik hâle getirir ve sunum akışını kesintiye uğratmadan istediğiniz sırayla slaytlar arasında özgürce gezinmenizi sağlar. Slayt yakınlaştırmaları, çok bölümlü olmayan kısa sunumlar için harikadır, ancak farklı sunum senaryolarında da kullanılabilir.

Slayt yakınlaştırmaları, tek bir genel bakış slaytından ilişkili bilgileri keşfetmenizi sağlar.

![Slayt yakınlaştırması için slaytların seçilmesi](slidezoomsel.png)

Slayt yakınlaştırma nesneleri için Aspose.Slides, [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) enumunu, [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) sınıfındaki yöntemleri sağlar.

### **Zoom Çerçeveleri Oluşturma**

Bireysel slaytlara bağlantılar eklemek için [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) kullanın. Bu örnek, farklı arka planlara ve etiketlere sahip iki hedef slayt oluşturur, ardından her birinin ön izlemesini ilk slayta ekler ve sunumu PPTX olarak kaydeder. Çerçeve konumları ve boyutları puan (point) cinsinden belirtilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Özel Görsellerle Zoom Çerçeveleri Oluşturma**

Hedef slaydın varsayılan ön izlemesini değiştirmek için [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) yöntemine özel bir görsel geçirin. Bu örnek yerel bir görsel gerektirir, görseli [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) ile yükler ve [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) aracılığıyla sunuma ekler. Oluşan çerçeve, ikinci slayta hâlâ bağlanırken bu görseli gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zoom Çerçevelerini Biçimlendirme**

Bu örnek iki slayt yakınlaştırma çerçevesini özelleştirir. İlk çerçeveye yerel bir görseli [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) aracılığıyla atar ve ikinci çerçeveye [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) kullanarak beş puanlık, tire‑nokta pembe bir kenarlık verir. [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) metoduna `False` geçirerek ikinci çerçevenin arka planını gizler. Özel ön izleme için yerel bir görsel gerekir; her iki çerçeve de kaydedilen PPTX’te slayt hedeflerini korur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bölüm Yakınlaştırma**

Bir bölüm yakınlaştırması, sunumunuzdaki bir bölüme bağlanır. Konuyu yeniden gözden geçirmek veya sunumun farklı bölümlerinin nasıl bağlandığını göstermek için kullanın.

![Bölüm yakınlaştırması için bir bölümün seçilmesi](seczoomsel.png)

Bölüm yakınlaştırma nesneleri için Aspose.Slides, [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) sınıfındaki yöntemleri sağlar.

### **Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

[SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection) ile bir bölüm oluşturun, ardından döndürülen bölümü [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) metoduna iletin. Bu örnek, ilk slayta bir bölüm yakınlaştırması ekler ve onu renkli bir slaytla başlayan bir bölüme bağlar. Çerçeve konumu ve boyutları puan cinsinden belirtilir ve sunum PPTX olarak kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Özel Görsellerle Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

[ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) yönteminin görsel aşırı yüklemesi, hedef bölümü değiştirmeden özel bir ön izleme görüntülemenizi sağlar. Bu örnek yerel bir görsel gerektirir, görseli [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) ile yükler ve [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) aracılığıyla ekler. Kaydedilen sunum, yeni oluşturulan bölüme bağlanan bir bölüm yakınlaştırmasını ilk slayta içerir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bir Bölüm Yakınlaştırmasının Hedef Bölümünü Değiştirme**

Mevcut bir bölüm yakınlaştırmasını yeniden oluşturmak zorunda kalmadan yönlendirmek için [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) kullanın. Aynı sunumdaki [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) koleksiyonundan doldurulmuş bir bölümü seçin. Boş bir bölüm atamak mevcut hedefi değiştirmez; bu yüzden atamadan önce [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) kontrol edin. Bölümler hakkında daha fazla bilgi için [Slayt Bölümlerini Yönet](/slides/tr/python-java/slide-section/) sayfasına bakın.

Aşağıdaki örnek, birden çok doldurulmuş bölümü, `Section navigation` adlı mevcut bir bölüm yakınlaştırmasını ve `Results` adında benzersiz bir bölümü içeren bir sunum dosyasını yükler. Yakınlaştırmayı tüm slaytlarda arar ve bölümü adla bulur; bölüm indeksleri yeniden sıralandığında değişebileceği için bu yöntem tercih edilir. İsimler benzersiz değilse, hedefi belirlemek için [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bölüm Yakınlaştırma Çerçevelerini Biçimlendirme**

Bu örnek bir bölüm yakınlaştırmasını 100 × 75 puana yeniden boyutlandırır, yerel bir görseli [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) aracılığıyla atar ve 2,5 puanlık, tire‑nokta kahverengi bir kenarlık uygular. Bölüm sonlandığında kaynak slayta dönmek için [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) etkinleştirilir, arka plan gizlenir ([ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground)), ve geçiş süresi [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) 1,5 saniye olarak ayarlanır. Özel ön izleme için yerel bir görsel gerekir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Özet Yakınlaştırma**

Bir özet yakınlaştırması, sunum bölümlerinin genel bir görünümünü sunar. Slayt gösterisi sırasında bir bölüme atlamak, ileri atlamak veya bir konuyu yeniden gözden geçirmek için, slayt sırasını takip etmeksizin kullanabilirsiniz.

![Özet yakınlaştırma için bölümlerin seçilmesi](sumzoomsel.png)

Özet yakınlaştırma nesneleri için Aspose.Slides, [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) ve [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) sınıflarını ve [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) sınıfındaki yöntemleri sağlar.

### **Özet Yakınlaştırma Oluşturma**

Sunumun bölümlerinin bir genel görünümünü oluşturmak için [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) kullanın. Bu örnek, farklı slayt arka planlarına sahip dört bölüm oluşturur ve ilk slayta bir özet yakınlaştırma ekler. Çerçeve konumu ve boyutları puan cinsinden belirtilir ve ortaya çıkan genel bakış PPTX sunumuna kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Özet Yakınlaştırma Bölümü Ekleme ve Kaldırma**

Bir özet yakınlaştırma, [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) içinde [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) nesnelerini saklar. Bu örnek iki bölümün bir genel görünümünü oluşturur, üçüncü bölümü [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) ile ekler ve ilk bölümün girdisini [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) ile kaldırır. Girdinin kaldırılması, sunum bölümünü ve slaytlarını etkilenmemiş bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Özet Yakınlaştırma Bölümlerini Biçimlendirme**

Bu örnek, [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) içinde sıfır‑tabanlı `0` indeksli ilk girdiyi biçimlendirir. [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) için yerel bir görsel gerekir, 1,5 puanlık tire‑nokta siyah bir kenarlık uygulanır ve geçiş süresi [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) 1,5 saniye olarak ayarlanır. Bu girdi için otomatik olarak özet slayta dönüşü devre dışı bırakmak üzere [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) `False` olarak ayarlanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Hedef gösterildikten sonra 'ana' slayta dönmeyi kontrol edebilir miyim?**

Evet. Hedef içerik gösterildikten sonra kaynak slayta dönmek için [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) metodunu `True` ile çağırın.

**Yakınlaştırma geçişinin 'hızını' ya da süresini ayarlayabilir miyim?**

Evet. Geçiş süresini saniye cinsinden kontrol etmek için [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) metodunu kullanın.

**Bir sunum kaç tane Yakınlaştırma nesnesi içerebilir konusunda sınırlamalar var mı?**

Belgelenmiş katı bir API sınırlaması yoktur. Pratik sınırlar, sunumun genel karmaşıklığına ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutu ve oluşturma süresini göz önünde bulundurun.