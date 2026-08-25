---
title: Android'de Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/androidjava/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölümü düzenle
- bölümü değiştir
- bölüm adı
- bölüm slaytlarını al
- bölüm slaytlarını işle
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile slayt bölümlerini yönetin: PPTX sunumlarında bölüm slaytlarını oluşturun, yeniden adlandırın, yeniden sıralayın, alın ve işleyin."
---
## **Giriş**

Bölümler, ardışık slaytları slayt içeriğini değiştirmeden adlandırılmış gruplar halinde düzenler. Aspose.Slides for Android via Java ile, bölümleri [Presentation.getSections](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSections--) yöntemiyle oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve kaldırabilirsiniz.

Bölümler özellikle şu durumlarda faydalıdır:
- büyük bir sunum mantıksal konulara veya bölümlere ayrılması gerektiğinde;
- farklı slayt grupları farklı iş ortaklarına atandığında;
- slaytların grup halinde işlenmesi, taşınması veya birleştirilmesi gerektiğinde.

Gruplandırılmış slaytların amacını açıklayan özlü bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, üyeliği slayt konumlarından türetmek yerine bölüm API'lerini kullanarak belirleyin.

## **Bölümleri Oluşturma ve Yönetme**

[ISectionCollection.addSection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) yöntemini kullanarak bölüm adını ve başlangıç slaytını belirterek bir bölüm oluşturabilirsiniz. Aspose.Slides, slaytların hangi bölüme ait olduğunu sunumun mevcut bölüm yapısından belirler.

Aynı [ISectionCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectioncollection/) ayrıca şunları yapmanızı sağlar:
- [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) yöntemiyle bir bölümü slaytlarıyla birlikte taşıyabilirsiniz;
- [ISectionCollection.removeSection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) ile yalnızca bölüm tanımını kaldırabilirsiniz, slaytlar korunur;
- [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) ile bir bölümü ve slaytlarını kaldırabilirsiniz;
- [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) ile sona boş bir bölüm ekleyebilirsiniz.

Aşağıdaki örnek iki bölüm oluşturur, bunlardan birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Bu işlemlerden sonra, sunum `Introduction` bölümünü slaytlarıyla birlikte ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölümleri Yeniden Adlandırma**

Bir bölümü yeniden adlandırmak için, [ISection.setName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) yöntemini çağırın. Bölümün slaytları ve konumu değişmeden kalır.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Bölümlerden Slaytları Alma**

[Presentation.getSections](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSections--) yöntemi, üzerinde yineleme yapabileceğiniz bir [ISectionCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectioncollection/) döndürür. Her bir [ISection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/) için, o bölüme şu anda ait slaytları elde etmek üzere [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) çağırın. Bu yöntem, sayım, indeksli erişim ve yineleme sağlayan bir [ISectionSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectionslidecollection/) döndürür.

Aşağıdaki örnek iki doldurulmuş bölüm ve bir boş bölüm oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getName--) , [identifier](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getSectionId--) , [starting slide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) , slayt sayısı ve slayt numaralarını yazdırır. İlk slaytı okumak için [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) ve her slaytı işlemek için geliştirilmiş bir `for` ifadesi kullanır. Boş bölüm için, döndürülen koleksiyon sıfır elemanlıdır, yöntem çağrılmaz ve yineleme herhangi bir işlem yapmaz.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Bölüm üyeliği, sunumun bölüm yapısı tarafından belirlenir. Bir bölümün aralığını [ISection.getStartedFromSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) , slayt indeksleri ve bir sonraki bölümün başlangıç slaytından manuel olarak hesaplamayın.

Yapısal düzenlemeler, bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Buna slaytların yeniden sıralanması, bir slaytın bölüme kopyalanması, bir bölümün slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılması dahildir. Sonraki örnek, bölümün önceki sınırları hakkında varsayımları tutmak yerine bu değişikliklerden sonra her seferinde [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) yöntemini çağırır.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Slaytlar veya bölümler yeniden sıralandığında, kopyalandığında, taşındığında veya kaldırıldığında, [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) yöntemini tekrar çağırın. Bu, sonraki işlemlerin mevcut sunum yapısına uygun kalmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm meta verilerini korumaz. Bu iş akışını, PPTX gibi bölümleri destekleyen bir formatta kullanın; PPT'ye dönüştürmek, sonraki yineleme için gereken bölüm yapısını kaldırır.

## **SSS**

**PPT (PowerPoint 97–2003) formatına kaydedildiğinde bölümler korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu yüzden .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için, bölümdeki her bir slayt için [ISlide.setHidden](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#setHidden-boolean-) yöntemini çağırın.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

[Presentation.getSections](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSections--) yöntemiyle dönen koleksiyon üzerinde yineleme yapın, her bir bölüm için [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) yöntemini çağırın ve dönen slaytları hedef slayt ile karşılaştırın. Boş olmayan bir bölümde, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) ilk slaytı döndürür; boş bir bölümde ise `null` döner.