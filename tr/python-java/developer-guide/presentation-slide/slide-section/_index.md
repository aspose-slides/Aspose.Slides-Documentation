---
title: Python üzerinden Java ile Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/python-java/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- bölüm slaytlarını al
- bölüm slaytlarını işle
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slayt bölümlerini yönetin: PPTX sunumlarında bölümleri oluşturun, yeniden adlandırın, yeniden sıralayın, alın ve bölüm slaytlarını işleyin."
---
## **Giriş**

Bölümler, ardışık slaytları adlandırılmış gruplar halinde düzenler ve slayt içeriğini değiştirmez. Aspose.Slides for Python via Java ile bir bölümü oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve [Presentation.getSections](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSections) yöntemiyle kaldırabilirsiniz.

Bölümler özellikle şu durumlarda faydalıdır:

- büyük bir sunum mantıksal konulara veya bölümlere ayrılması gerektiğinde;
- farklı slayt grupları farklı işbirlikçilerine atanmış olduğunda;
- slaytların grup olarak işlenmesi, taşınması veya birleştirilmesi gerektiğinde.

Gruplanmış slaytların amacını tanımlayan kısa bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, slayt konumlarından türetmek yerine bölüm API'lerini kullanarak üyeliği belirleyin.

## **Bölümleri Oluşturma ve Yönetme**

Bir bölümün adını ve başlangıç slaytını belirterek bir bölüm oluşturmak için [SectionCollection.addSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectioncollection/#addSection) yöntemini kullanın. Aspose.Slides, bölümlerin hangi slaytlara ait olduğunu sunumun mevcut bölüm yapısına göre belirler.

Aynı [SectionCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectioncollection/) ayrıca şunları yapmanıza olanak tanır:

- [reorderSectionWithSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) kullanarak bir bölümü slaytlarıyla birlikte taşıyın;
- slaytlarını koruyarak yalnızca bölüm tanımını kaldırmak için [removeSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectioncollection/#removeSection) yöntemini kullanın;
- bir bölümü ve slaytlarını birlikte kaldırmak için [removeSectionWithSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectioncollection/#removeSectionwithslides) yöntemini kullanın;
- [appendEmptySection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectioncollection/#appendEmptySection) ile listenin sonuna boş bir bölüm ekleyin.

Aşağıdaki örnek iki bölüm oluşturur, bunlardan birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Bu işlemlerden sonra sunum, slaytlarıyla birlikte `Introduction` bölümünü ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölümlerin Adını Değiştirme**

Bir bölümün adını değiştirmek için onun [Section.setName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#setName) yöntemini çağırın. Bölümün slaytları ve konumu değişmeden kalır.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Bölümlerden Slaytları Alma**

[Presentation.getSections](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSections) yöntemi, üzerinde yineleme yapabileceğiniz bir [SectionCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectioncollection/) döndürür. Her bir [Section](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/) için, o an o bölüme ait slaytları elde etmek üzere [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getSlidesListOfSection) çağırın. Bu yöntem bir [SectionSlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectionslidecollection/) geri döndürür; bu koleksiyon sayım, indeksli erişim ve yineleme sağlar.

Aşağıdaki örnek iki dolu bölüm ve bir boş bölüm oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getStartedFromSlide), slayt sayısı ve slayt numaralarını yazdırır. İlk slaytı okumak için [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectionslidecollection/#get_Item) ve tüm slaytları işlemek için bir `for` ifadesi kullanır. Boş bölüm için döndürülen koleksiyonun boyutu sıfırdır, yöntem çağrılmaz ve yineleme hiçbir işlem yapmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

Bölüm üyeliği, sunumun bölüm yapısına göre belirlenir. Bir bölümün aralığını [Section.getStartedFromSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getStartedFromSlide), slayt indeksleri ve bir sonraki bölümün başlangıç slaytı gibi bilgilerden manuel olarak hesaplamayın.

Yapısal düzenlemeler, bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Bu, slaytların yeniden sıralanması, bir slaytın bir bölüme kopyalanması, bir bölümün slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılması dahil olmak üzere tüm değişiklikleri kapsar. Bir sonraki örnek, bölümün önceki sınırları hakkında varsayımları sürdürmek yerine, her değişiklikten sonra [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getSlidesListOfSection) yöntemini çağırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Slaytlar veya bölümler yeniden sıralandığında, kopyalandığında, taşındığında veya kaldırıldığında [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getSlidesListOfSection) yöntemini tekrar çağırın. Bu, sonraki işlemlerin mevcut sunum yapısıyla uyumlu kalmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm üst verilerini korumaz. Bölümleri destekleyen bir format, örneğin PPTX, ile bu iş akışını kullanın; PPT'ye dönüştürmek bölüm yapısını kaldırır ve sonraki yinelemeler için gerekli bilgiyi kaybeder.

## **SSS**

**Bölümler PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm üst verilerini desteklemez; bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm \"gizli\" yapılabilir mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için bölüme ait her slayt için [Slide.setHidden](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#setHidden) yöntemini çağırın.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

[Presentation.getSections](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSections) tarafından döndürülen koleksiyon üzerinde yineleme yapın, her bölüm için [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getSlidesListOfSection) yöntemini çağırın ve dönen slaytları hedef slayt ile karşılaştırın. Boş olmayan bir bölüm için [Section.getStartedFromSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getStartedFromSlide) ilk slaytını döndürür; boş bir bölüm için `None` döner.