---
title: Python ile Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 100
url: /tr/python-net/slide-section/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile slayt bölümlerini yönetin: PPTX sunumlarında bölümler oluşturun, yeniden adlandırın, yeniden sıralayın, alın ve bölüm slaytlarını işleyin."
---
## **Giriş**

Bölümler, ardışık slaytları kaydırma içeriğini değiştirmeden adlandırılmış gruplar halinde organize eder. Aspose.Slides for Python via .NET ile bölümleri oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve [Presentation.sections](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/sections/) özelliği aracılığıyla kaldırabilirsiniz.

Bölümler özellikle şu durumlarda faydalıdır:

- büyük bir sunumun mantıksal konulara veya bölümlere ayrılması gerektiğinde;
- slaytların farklı grupları farklı iş ortaklarına atanmış olduğunda;
- slaytların grup halinde işlenmesi, taşınması veya birleştirilmesi gerektiğinde.

Gruplanmış slaytların amacını anlatan özlü bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, üyeliği slayt konumlarından türetmek yerine bölüm API'lerini kullanarak belirleyin.

## **Bölümleri Oluşturma ve Yönetme**

[SectionCollection.add_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/add_section/) kullanarak bir bölümün adını ve başlangıç slaytını belirterek oluşturabilirsiniz. Aspose.Slides, slaytların hangi bölüme ait olduğunu sunumun mevcut bölüm yapısından belirler.

Aynı [SectionCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/) ayrıca şunları yapmanızı sağlar:

- [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) kullanarak bir bölümü slaytlarıyla birlikte taşıyabilirsiniz;
- [SectionCollection.remove_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/remove_section/) ile sadece bölüm tanımını kaldırabilirsiniz, slaytları korunur;
- [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) ile bir bölümü ve slaytlarını kaldırabilirsiniz;
- Sona boş bir bölüm eklemek için [SectionCollection.append_empty_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/append_empty_section/) kullanabilirsiniz.

Aşağıdaki örnek iki bölüm oluşturur, bunlardan birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Bu işlemlerden sonra sunum, slaytlarıyla birlikte `Introduction` bölümünü ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölümleri Yeniden Adlandırma**

Bir bölümü yeniden adlandırmak için [Section.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/name/) özelliğini ayarlayın. Bölümün slaytları ve konumu değişmeden kalır.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Bölümlerden Slaytları Getirme**

[Presentation.sections](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/sections/) özelliği üzerinde yineleme yapabileceğiniz bir [SectionCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/) döndürür. Her bir [Section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/) için, o bölüme şu anda ait slaytları almak üzere [Section.get_slides_list_of_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/get_slides_list_of_section/) çağırın. Bu metod bir [SectionSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectionslidecollection/) döndürür; bu koleksiyon sayı, indeksli erişim ve yineleme sağlar.

Aşağıdaki örnek iki doldurulmuş bölüm ve bir boş bölüm oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/started_from_slide/), slayt sayısı ve slayt numaralarını yazdırır. İlk slaytı okumak için indeksli erişim ve tüm slaytları işlemek için bir `for` döngüsü kullanır. Boş bölüm için döndürülen koleksiyonun sayısı sıfırdır, indeks erişilmez ve yineleme hiçbir adım yapmaz.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

Bölüm üyeliği sunumun bölüm yapısı tarafından belirlenir. Bir bölümün aralığını [Section.started_from_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/started_from_slide/), slayt indeksleri ve bir sonraki bölümün başlangıç slaytından manuel olarak hesaplamayın.

Yapısal düzenlemeler bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Buna slaytların yeniden sıralanması, bir slaytın bölüme kopyalanması, bir bölümün slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılması dahildir. Sonraki örnek, bölümün önceki sınırları hakkında varsayımları tutmak yerine her değişiklikten sonra [Section.get_slides_list_of_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/get_slides_list_of_section/) çağırır.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Slaytlar veya bölümler yeniden sıralandığında, kopyalandığında, taşındığında veya kaldırıldığında [Section.get_slides_list_of_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/get_slides_list_of_section/) metodunu tekrar çağırın. Bu, sonraki işlemlerin mevcut sunum yapısına uyumlu kalmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm meta verilerini korumaz. Bu iş akışını bölümleri destekleyen bir formatla, örneğin PPTX ile kullanın; PPT'ye dönüştürmek sonraki yineleme için gerekli bölüm yapısını kaldırır.

## **SSS**

**PPT (PowerPoint 97–2003) formatına kaydederken bölümler korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için bölümdeki her slaytın [Slide.hidden](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/hidden/) özelliğini ayarlayın.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

Her bir [Presentation.sections](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/sections/) üzerinde yineleme yapın, her bölüm için [Section.get_slides_list_of_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/get_slides_list_of_section/) çağırın ve döndürülen slaytları hedef slaytla karşılaştırın. Boş olmayan bir bölüm için [Section.started_from_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/started_from_slide/) ilk slaytını döndürür; boş bir bölüm için `None` döndürür.