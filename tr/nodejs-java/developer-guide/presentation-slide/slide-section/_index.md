---
title: Sunumlarda JavaScript ile Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/nodejs-java/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- bölüm slaytlarını getir
- bölüm slaytlarını işle
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile slayt bölümlerini yönetin: PPTX sunumlarında bölüm slaytlarını oluşturun, yeniden adlandırın, yeniden sıralayın, getirin ve işleyin."
---
## **Giriş**

Bölümler, ardışık slaytları kaydırma içeriğini değiştirmeden adlandırılmış gruplar halinde düzenler. Aspose.Slides for Node.js via Java ile, bölümleri [Presentation.getSections](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSections) metodunu kullanarak oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve kaldırabilirsiniz.

Bölümler özellikle şu durumlarda yararlıdır:

- büyük bir sunum mantıksal konulara veya bölümlere ayrılması gerektiğinde;
- farklı slayt grupları farklı iş ortaklarına atanmış olduğunda;
- slaytların grup olarak işlenmesi, taşınması veya birleştirilmesi gerektiğinde.

Grup içindeki slaytların amacını tanımlayan özlü bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, üye olmayı slayt konumlarından türetmek yerine bölüm API'lerini kullanarak belirleyin.

## **Bölümleri Oluşturma ve Yönetme**

[SectionCollection.addSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectioncollection/#addSection) metodunu kullanarak bölüm adını ve başlangıç slaytını belirterek bir bölüm oluşturun. Aspose.Slides, bölüme ait slaytları sunumun mevcut bölüm yapısından belirler.

Aynı [SectionCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectioncollection/) ayrıca şunları yapmanıza olanak tanır:

- [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) kullanarak bölümü slaytlarıyla birlikte taşıyın;
- sadece bölüm tanımını [SectionCollection.removeSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectioncollection/#removeSection) ile kaldırın, slaytları tutulur;
- bölümü ve slaytlarını [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) ile kaldırın;
- sonunda boş bir bölüm eklemek için [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) kullanın.

Aşağıdaki örnek iki bölüm oluşturur, birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Bu işlemlerden sonra sunum, slaytlarıyla birlikte `Introduction` bölümünü ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölümleri Yeniden Adlandırma**

Bir bölümü yeniden adlandırmak için onun [Section.setName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#setName) metodunu çağırın. Bölümün slaytları ve konumu değişmez.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Bölümlerden Slaytları Almak**

[Presentation.getSections](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSections) metodu, indeksle erişebileceğiniz bir [SectionCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectioncollection/) döndürür. Her bir [Section](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/) için mevcut olarak ona ait slaytları elde etmek üzere [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metodunu çağırın. Metod, bir [SectionSlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectionslidecollection/) döndürür; bu koleksiyon sayım ve indeksli erişim sağlar.

Aşağıdaki örnek iki doldurulmuş bölüm ve bir boş bölüm oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getStartedFromSlide), slayt sayısı ve slayt numaralarını yazdırır. İlk slaytı ve koleksiyondaki tüm slaytları okumak için [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) kullanır. Boş bölüm için döndürülen koleksiyonun boyutu sıfırdır, indeksli erişim atlanır ve döngü işlem yapmaz.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Bölüm üyeliği, sunumun bölüm yapısına göre belirlenir. Bölüm aralığını [Section.getStartedFromSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getStartedFromSlide), slayt indeksleri ve bir sonraki bölümün başlangıç slaytından elle hesaplamayın.

Yapısal düzenlemeler, bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Buna slaytların yeniden sıralanması, bir slaytın bir bölüme kopyalanması, bir bölümün slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılması dahildir. Bir sonraki örnek, önceki sınır varsayımlarını korumak yerine her değişiklikten sonra [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metodunu çağırır.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Slaytlar veya bölümler yeniden sıralandığında, kopyalandığında, taşındığında veya kaldırıldığında her zaman [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metodunu tekrar çağırın. Bu, sonraki işleme mevcut sunum yapısına uyumlu kalmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm meta verilerini korumaz. Bölüm desteği olan bir formatla, örneğin PPTX, bu iş akışını kullanın; PPT'ye dönüştürmek, sonraki yineleme için gerekli bölüm yapısını kaldırır.

## **SSS**

**Bölümler, PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu yüzden .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için bölümdeki her slayt için [Slide.setHidden](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#setHidden) metodunu çağırın.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

[Presentation.getSections](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSections) tarafından döndürülen koleksiyondaki her bölüme erişin, her bölüm için [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metodunu çağırın ve döndürülen slaytları hedef slaytla karşılaştırın. Boş olmayan bir bölüm için [Section.getStartedFromSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getStartedFromSlide) ilk slaytını döndürür; boş bir bölüm için `null` döner.