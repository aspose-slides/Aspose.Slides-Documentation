---
title: Python ile Sunum Slaytlarını Klonlama
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/python-java/clone-slides/
keywords:
- slayt klonlama
- slayt kopyalama
- slayt kaydetme
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint slaytlarını hızlı bir şekilde çoğaltın. Açık kod örneklerimizi izleyerek PPT oluşturmayı saniyeler içinde otomatikleştirin ve manuel işi ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides for Python via Java ayrıca herhangi bir slaytın bir kopyasını veya klonunu oluşturmayı ve ardından bu klonlanmış slaytı mevcut sunuma ya da başka bir açık sunuma eklemeyi mümkün kılar. Slayt klonlama süreci, orijinal slaytı değiştirmeden geliştiricilerin değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde sonuna klonlamak.
- Sunum içinde başka bir konuma klonlamak.
- Başka bir sunumda sonuna klonlamak.
- Başka bir sunumda başka bir konuma klonlamak.
- Ana slaytıyla birlikte başka bir sunuma klonlamak.

Aspose.Slides for Python via Java'da, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi tarafından sunulan slayt koleksiyonu (bir [Slayt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) nesnesi koleksiyonu), yukarıdaki slayt klonlama türlerini gerçekleştirmek için [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) ve [insertClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertClone) metodlarını sağlar.

## **Sunum Sonuna Slayt Klonlamak**

Aynı sunum dosyasında mevcut slaytların sonuna bir slaytı klonlamak ve ardından kullanmak istiyorsanız, aşağıdaki adımlara uygun olarak [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) metodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesini alın.
3. [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) metodunu çağırın ve klonlanacak slaytı bu metoda parametre olarak geçin.
4. Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte, sunumun ilk konumunda (sıfır indeksinde) bulunan bir slaytı sunumun sonuna klonladık.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Değiştirilmiş sunumu diske yazın
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sunum İçinde Başka Bir Konuma Slayt Klonlamak**

Aynı sunum dosyasında farklı bir konuma bir slaytı klonlamak ve ardından kullanmak istiyorsanız, [insertClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertClone) metodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi üzerinde [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) metodundan dönen slayt koleksiyonuna bir referans alın.
3. [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertClone) metodunu çağırın ve klonlanacak slaytı yeni konumun indeksini de parametre olarak geçin.
4. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun 1. indeksinde (2. konum) bulunan bir slaytı 2. indeksine (3. konum) klonladık.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Sunumdaki slayt koleksiyonunu alın
    slides = presentation.getSlides()

    # İstenen slaytı aynı sunumda belirtilen indekse klonlayın
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Değiştirilmiş sunumu diske yazın
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Başka Bir Sunumun Sonuna Slayt Klonlamak**

Bir sunumdan bir slaytı başka bir sunuma, mevcut slaytların sonuna klonlamak istiyorsanız:

1. Kaynak slaytı içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
3. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi üzerindeki [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) metodundan dönen slayt koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesini alın.
4. [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) metodunu çağırın ve kaynak sunumdan slaytı parametre olarak geçin.
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun 0. indeksindeki bir slaytı hedef sunumun sonuna klonladık.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    destination_presentation = Presentation()
    try:
        # İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Hedef sunumu diske yazın
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Başka Bir Sunumda Başka Bir Konuma Slayt Klonlamak**

Bir sunumdan bir slaytı başka bir sunuma belirli bir konuma klonlamak istiyorsanız:

1. Kaynak slaytı içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytı ekleyeceğiniz sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
3. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesini alın.
4. [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertClone) metodunu çağırın ve kaynak slaytı istenen konumla birlikte parametre olarak geçin.
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı hedef sunumun 1. indeksine (2. konuma) klonladık.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    destination_presentation = Presentation()
    try:
        # İstenen slaytı kaynak sunumdan hedef sunumdaki belirtilen indexe klonlayın
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Hedef sunumu diske yazın
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Ana Slaytıyla Birlikte Slaytı Başka Bir Sunuma Klonlamak**

Bir slaytı ana slaytıyla birlikte başka bir sunuma klonlamak istiyorsanız, önce kaynak sunumdan istenen ana slaytı hedef sunuma klonlamalısınız. Ardından slaytı klonlarken bu klonlanmış ana slaytı kullanmalısınız. [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) metodu, kaynak sunumdan değil, hedef sunumdan bir ana slayt bekler. Aşağıdaki adımları izleyin:

1. Kaynak slaytı içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
3. Klonlanacak slaytı ve onun ana slaytını alın.
4. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi tarafından sunulan Masters koleksiyonuna başvurarak [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/) nesnesini alın.
5. [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/#addClone) metodunu çağırın ve kaynak PPTX'ten klonlanacak ana slaytı parametre olarak geçin.
6. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesini alın.
7. [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) metodunu çağırın ve kaynak slaytı ve ana slaytı parametre olarak geçin.
8. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı, kaynak slaytın ana slaytıyla birlikte hedef sunumun sonuna klonladık.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Hedef sunum için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    destination_presentation = Presentation()
    try:
        # Kaynak sunumdaki slayt koleksiyonundan slaytı ana slayt ile birlikte örnekleyin
        # Ana slayt
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # İstenen ana slaytı kaynak sunumdan hedef sunumun ana slayt koleksiyonuna klonlayın
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # İstenen slaytı istediği ana slayt ile kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Hedef sunumu diske kaydedin
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Belirli Bir Bölümün Sonuna Slayt Klonlamak**

Aynı sunum dosyasında farklı bir bölümde bir slaytı klonlamak ve ardından kullanmak istiyorsanız, [**addClone**](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) metodunu [**SlideCollection**](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) sınıfı üzerinden kullanın. Aspose.Slides for Python via Java, bir slaytı ilk bölüme klonlamayı ve ardından bu klonlanmış slaytı aynı sunumun ikinci bölümüne eklemeyi mümkün kılar.

Aşağıdaki kod parçacığı, bir slaytı nasıl klonlayıp belirli bir bölüme ekleyeceğinizi gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Hedef sunumu diske kaydedin
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slayt Boyutunun Eşleştiğinden Emin Olun**

Slaytları başka bir sunuma klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Boyutlar farklıysa, Aspose.Slides klonlanmış şekilleri otomatik olarak yeniden ölçeklendirmez; orijinal koordinat ve boyutları korunur ve içerik kayma ya da slayt sınırlarının dışına taşma gibi sorunlar ortaya çıkabilir.

Ana slaytı ve slaytı klonlamadan önce hedef sunumun slayt boyutunu kaynakla eşleştirebilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Bunu ana slaytı ve slaytı klonlamadan önce yapın.

## **SSS**

**Konuşmacı notları ve inceleme yorumları klonlanır mı?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/python-java/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirme ve yerleşik veri kopyalanır. Grafik harici bir kaynağa (ör. OLE‑ekli bir çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE nesnesi](/slides/tr/python-java/manage-ole/) olarak korunur. Dosyalar arasında taşıdıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/python-java/slide-section/) taşıyabilirsiniz. Hedef bölüm mevcut değilse, önce bölümü oluşturun ve ardından slaytı ona taşıyın.