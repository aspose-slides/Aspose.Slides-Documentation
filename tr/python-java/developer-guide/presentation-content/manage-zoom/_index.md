---
title: Python üzerinden Java ile Sunum Zoom'unu Yönet
linktitle: Zoom'u Yönet
type: docs
weight: 60
url: /tr/python-java/manage-zoom/
keywords:
- yakınlaştırma
- yakınlaştırma çerçevesi
- slayt yakınlaştırması
- bölüm yakınlaştırması
- özet yakınlaştırması
- yakınlaştırma ekle
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile Zoom oluşturun ve özelleştirin — bölümler arasında atlayın, PPT, PPTX ve ODP sunumları içinde küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint'teki Zoom'lar, sunumunuzun belirli slaytları, bölümleri ve parçaları arasında atlamanızı sağlar. Sunum yaparken, içeriği hızlıca gezme yeteneği çok faydalı olabilir.

![overview_image](overview.png)

* Tek bir slaytta tüm sunumu özetlemek için bir [Özet Zoom](#summary-zoom) kullanın.
* Yalnızca seçili slaytları göstermek için bir [Slayt Zoom](#slide-zoom) kullanın.
* Yalnızca tek bir bölümü göstermek için bir [Bölüm Zoom](#section-zoom) kullanın.

## **Slayt Zoom**
Slayt zoom, sunumunuzu daha dinamik hâle getirir, istediğiniz sırayla slaytlar arasında kesintisiz gezinmenizi sağlar. Slayt zoom, çok fazla bölümü olmayan kısa sunumlar için idealdir, ancak farklı sunum senaryolarında da kullanılabilir.

Slayt zoomlar, tek bir tuval üzerindeymiş gibi birden fazla bilgi parçasına derinlemenize yardımcı olur.

![overview_image](slidezoomsel.png)

Slayt zoom nesneleri için Aspose.Slides, ZoomImageType enumarasyonunu, ZoomFrame sınıfını ve ShapeCollection sınıfındaki bazı yöntemleri sağlar.

### **Zoom Çerçeveleri Oluşturma**

Bir slayta zoom çerçevesi aşağıdaki şekilde eklenebilir:

1. Presentation sınıfının bir örneğini oluşturun.
2. Zoom çerçevelerini bağlamayı amaçladığınız yeni slaytlar oluşturun.
3. Oluşturulan slaytlara tanımlayıcı metin ve arka plan ekleyin.
4. Zoom çerçevelerini (oluşturulan slaytlara referansları içeren) ilk slayta ekleyin.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir slayta zoom çerçevesi oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni slaytlar ekler
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  İkinci slayt için bir arka plan oluşturur
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  İkinci slayt için bir metin kutusu oluşturur
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Üçüncü slayt için bir arka plan oluşturur
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Üçüncü slayt için bir metin kutusu oluşturur
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # ZoomFrame nesneleri ekler
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Özel Görsellerle Zoom Çerçeveleri Oluşturma**
Aspose.Slides for Python via Java kullanarak, farklı bir slayt önizleme görseliyle zoom çerçevesi aşağıdaki şekilde oluşturabilirsiniz:
1. Presentation sınıfının bir örneğini oluşturun.
2. Zoom çerçevesini bağlamayı amaçladığınız yeni bir slayt oluşturun.
3. Slayta tanımlayıcı metin ve arka plan ekleyin.
4. Presentation nesnesine bağlı görsel koleksiyonuna bir görüntü ekleyerek bir PPImage nesnesi oluşturun; bu, çerçeveyi doldurmak için kullanılacaktır.
5. Zoom çerçevelerini (oluşturulan slayta referans içeren) ilk slayta ekleyin.
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, farklı bir görsel ile zoom çerçevesi oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  İkinci slayt için bir arka plan oluşturur
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  İkinci slayt için bir metin kutusu oluşturur
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # ZoomFrame nesnesini ekler
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Zoom Çerçevelerinin Biçimlendirilmesi**
Önceki bölümlerde basit zoom çerçevelerinin nasıl oluşturulacağını gösterdik. Daha karmaşık zoom çerçeveleri oluşturmak için basit bir çerçevenin biçimini değiştirmek gerekir. Zoom çerçevesine uygulanabilecek çeşitli biçimlendirme seçenekleri vardır.

Bir slaytta bir zoom çerçevesinin biçimini aşağıdaki şekilde kontrol edebilirsiniz:

1. Presentation sınıfının bir örneğini oluşturun.
2. Zoom çerçevelerini bağlamayı amaçladığınız yeni slaytlar oluşturun.
3. Oluşturulan slaytlara tanımlayıcı metin ve arka plan ekleyin.
4. Zoom çerçevelerini (oluşturulan slaytlara referansları içeren) ilk slayta ekleyin.
5. Presentation nesnesine bağlı görsel koleksiyonuna bir görüntü ekleyerek bir PPImage nesnesi oluşturun; bu, çerçeveyi doldurmak için kullanılacaktır.
6. İlk zoom çerçevesi nesnesi için özel bir görsel ayarlayın.
7. İkinci zoom çerçevesi nesnesinin çizgi biçimini değiştirin.
8. İkinci zoom çerçevesi nesnesinin görüntüsünden arka planı kaldırın.
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir slaytta zoom çerçevesinin biçimini değiştirmenizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni slaytlar ekler
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  İkinci slayt için bir arka plan oluşturur
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  İkinci slayt için bir metin kutusu oluşturur
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Üçüncü slayt için bir arka plan oluşturur
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Üçüncü slayt için bir metin kutusu oluşturur
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # ZoomFrame nesneleri ekler
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  first_zoom_frame nesnesi için özel görsel ayarlar
    first_zoom_frame.setZoomImage(picture)

    #  second_zoom_frame nesnesi için bir zoom çerçeve biçimi ayarlar
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  second_zoom_frame nesnesi için arka planı gösterme ayarı
    second_zoom_frame.setShowBackground(False)

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bölüm Zoom**

Bölüm zoomu, sunumunuzdaki bir bölüme bağlantıdır. Gerçekten vurgulamak istediğiniz bölümlere geri dönmek için bölüm zoomlarını kullanabilirsiniz. Veya sunumunuzun belirli bölümlerinin nasıl bağlandığını vurgulamak için de kullanabilirsiniz.

![overview_image](seczoomsel.png)

Bölüm zoom nesneleri için Aspose.Slides, SectionZoomFrame sınıfını ve ShapeCollection sınıfındaki bazı yöntemleri sağlar.

### **Bölüm Zoom Çerçeveleri Oluşturma**
Bir slayta bölüm zoom çerçevesi aşağıdaki şekilde eklenebilir:

1. Presentation sınıfının bir örneğini oluşturun.
2. Yeni bir slayt oluşturun.
3. Oluşturulan slayta ayırt edici bir arka plan ekleyin.
4. Zoom çerçevesini bağlamayı düşündüğünüz yeni bir bölüm oluşturun.
5. Bölüm zoom çerçevesini (oluşturulan bölüme referansları içeren) ilk slayta ekleyin.
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir slayta zoom çerçevesi oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir Bölüm ekler
    presentation.getSections().addSection("Section 1", slide)

    #  SectionZoomFrame nesnesi ekler
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Özel Görsellerle Bölüm Zoom Çerçeveleri Oluşturma**
Aspose.Slides for Python via Java kullanarak, farklı bir slayt önizleme görseliyle bölüm zoom çerçevesi aşağıdaki şekilde oluşturabilirsiniz:

1. Presentation sınıfının bir örneğini oluşturun.
2. Yeni bir slayt oluşturun.
3. Oluşturulan slayta ayırt edici bir arka plan ekleyin.
4. Zoom çerçevesini bağlamayı düşündüğünüz yeni bir bölüm oluşturun.
5. Presentation nesnesine bağlı görsel koleksiyonuna bir görüntü ekleyerek bir PPImage nesnesi oluşturun; bu, çerçeveyi doldurmak için kullanılacaktır.
6. Bölüm zoom çerçevesini (oluşturulan bölüme referans içeren) ilk slayta ekleyin.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, farklı bir görsel ile zoom çerçevesi oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni Bir Bölüm ekler
    presentation.getSections().addSection("Section 1", slide)

    #  Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  SectionZoomFrame nesnesi ekler
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Bölüm Zoom Çerçevelerinin Biçimlendirilmesi**
Daha karmaşık bölüm zoom çerçeveleri oluşturmak için basit bir çerçevenin biçimini değiştirmeniz gerekir. Bir bölüm zoom çerçevesine uygulanabilecek çeşitli biçimlendirme seçenekleri vardır.

Bir slaytta bir bölüm zoom çerçevesinin biçimini aşağıdaki şekilde kontrol edebilirsiniz:

1. Presentation sınıfının bir örneğini oluşturun.
2. Yeni bir slayt oluşturun.
3. Oluşturulan slayta ayırt edici bir arka plan ekleyin.
4. Zoom çerçevesini bağlamayı düşündüğünüz yeni bir bölüm oluşturun.
5. Bölüm zoom çerçevesini (oluşturulan bölüme referansları içeren) ilk slayta ekleyin.
6. Oluşturulan bölüm zoom nesnesinin boyut ve konumunu değiştirin.
7. Presentation nesnesine bağlı görsel koleksiyonuna bir görüntü ekleyerek bir PPImage nesnesi oluşturun; bu, çerçeveyi doldurmak için kullanılacaktır.
8. Oluşturulan bölüm zoom çerçevesi nesnesi için özel bir görsel ayarlayın.
9. Bağlantılı bölüme geri dönüş (orijinal slayta dönüş) özelliğini ayarlayın.
10. Bölüm zoom çerçevesi nesnesinin görüntüsünden arka planı kaldırın.
11. Bölüm zoom çerçevesi nesnesinin çizgi biçimini değiştirin.
12. Geçiş süresini değiştirin.
13. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir bölüm zoom çerçevesinin biçimini değiştirmenizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir Bölüm ekler
    presentation.getSections().addSection("Section 1", slide)

    #  SectionZoomFrame nesnesi ekler
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  SectionZoomFrame için biçimlendirme
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Özet Zoom**

Özet zoom, sunumunuzun tüm bölümlerinin bir arada gösterildiği bir başlangıç sayfası gibidir. Sunum yaparken, zoomu kullanarak sunumunuzdaki bir konumdan başka bir konuma istediğiniz sırayla gidebilirsiniz. Yaratıcı olabilir, ileri atlayabilir veya slayt gösterinizin bölümlerine akışı bozmayacak şekilde yeniden göz atabilirsiniz.

![overview_image](sumzoomsel.png)

Özet zoom nesneleri için Aspose.Slides, SummaryZoomFrame, SummaryZoomSection ve SummaryZoomSectionCollection sınıflarını ve ShapeCollection sınıfındaki bazı yöntemleri sağlar.

### **Bir Özet Zoom Oluşturma**
Bir slayta özet zoom çerçevesi aşağıdaki şekilde eklenebilir:

1. Presentation sınıfının bir örneğini oluşturun.
2. Oluşturulan slaytlar için ayırt edici bir arka plan ve yeni bölümlerle yeni slaytlar oluşturun.
3. Özet zoom çerçevesini ilk slayta ekleyin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir slayta özet zoom çerçevesi oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 1", slide)

    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 2", slide)

    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 3", slide)

    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 4", slide)

    #  SummaryZoomFrame nesnesi ekler
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Özet Zoom Bölümü Ekleme ve Kaldırma**
Özet zoom çerçevesindeki tüm bölümler SummaryZoomSection nesneleriyle temsil edilir ve SummaryZoomSectionCollection nesnesinde depolanır. SummaryZoomSectionCollection sınıfı aracılığıyla bir özet zoom bölümü nesnesi ekleyebilir veya kaldırabilirsiniz:

1. Presentation sınıfının bir örneğini oluşturun.
2. Oluşturulan slaytlar için ayırt edici bir arka plan ve yeni bölümlerle yeni slaytlar oluşturun.
3. İlk slayta bir özet zoom çerçevesi ekleyin.
4. Sunuma yeni bir slayt ve bölüm ekleyin.
5. Oluşturulan bölümü özet zoom çerçevesine ekleyin.
6. İlk bölümü özet zoom çerçevesinden kaldırın.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir özet zoom çerçevesine bölümler ekleme ve kaldırma işlemini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 1", slide)

    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 2", slide)

    #  SummaryZoomFrame nesnesi ekler
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Summary Zoom'a bir bölüm ekler
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Summary Zoom'dan bölümü kaldırır
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Özet Zoom Bölümlerinin Biçimlendirilmesi**
Daha karmaşık özet zoom bölüm nesneleri oluşturmak için basit bir çerçevenin biçimini değiştirmeniz gerekir. Özet zoom bölüm nesnesine uygulanabilecek çeşitli biçimlendirme seçenekleri vardır.

Bir özet zoom çerçevesinde bir özet zoom bölüm nesnesinin biçimini aşağıdaki şekilde kontrol edebilirsiniz:

1. Presentation sınıfının bir örneğini oluşturun.
2. Oluşturulan slaytlar için ayırt edici bir arka plan ve yeni bölümlerle yeni slaytlar oluşturun.
3. İlk slayta bir özet zoom çerçevesi ekleyin.
4. SummaryZoomSectionCollection'dan ilk özet zoom bölüm nesnesini alın.
5. Presentation nesnesine bağlı görsel koleksiyonuna bir görüntü ekleyerek bir PPImage nesnesi oluşturun; bu, çerçeveyi doldurmak için kullanılacaktır.
6. Özet zoom bölüm nesnesi için özel bir görsel ayarlayın.
7. Bağlantılı bölüme geri dönüş (orijinal slayta dönüş) özelliğini ayarlayın.
8. Özet zoom bölüm nesnesinin çizgi biçimini değiştirin.
9. Geçiş süresini değiştirin.
10. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir özet zoom bölüm nesnesinin biçimini değiştirmenizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 1", slide)

    # Sunuma yeni bir slayt ekler
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Sunuma yeni bir bölüm ekler
    presentation.getSections().addSection("Section 2", slide)

    #  SummaryZoomFrame nesnesi ekler
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  İlk SummaryZoomSection nesnesini alır
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  SummaryZoomSection nesnesi için biçimlendirme
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Sunumu kaydeder
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Hedef gösterildikten sonra 'ana' slayta dönüşü kontrol edebilir miyim?**

Evet. ZoomFrame veya SectionZoomFrame, setReturnToParent aracılığıyla orijinal slayta dönüşü destekler; etkinleştirildiğinde izleyicileri hedef içeriği ziyaret ettikten sonra geri gönderir.

**Zoom geçişinin 'hızını' veya süresini ayarlayabilir miyim?**

Evet. Zoom, setTransitionDuration ile bir geçiş süresi ayarlamayı destekler; böylece atlama animasyonunun ne kadar süreceğini kontrol edebilirsiniz.

**Bir sunumun içerebileceği Zoom nesnesi sayısıyla ilgili sınırlamalar var mı?**

Belirtilen sabit bir API sınırı yoktur. Pratik sınırlamalar, genel sunum karmaşıklığına ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutu ve render süresini göz önünde bulundurun.