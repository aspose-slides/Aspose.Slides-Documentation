---
title: Java ile Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/java/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- bölüm slaytlarını al
- bölüm slaytlarını işleme
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile slayt bölümlerini yönetin: PPTX sunumlarında bölüm slaytlarını oluştur, yeniden adlandır, yeniden sırala, al ve işle."
---
## **Giriş**

Bölümler, ardışık slaytları içeriklerini değiştirmeden adlandırılmış gruplar halinde organize eder. Aspose.Slides for Java ile [Presentation.getSections](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSections--) yöntemi aracılığıyla bölümler oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve kaldırabilirsiniz.

Bölümler özellikle aşağıdaki durumlarda faydalıdır:

- büyük bir sunum, mantıksal konulara ya da bölümlere ayrılması gerektiğinde;
- slaytların farklı grupları farklı iş ortaklarına atanmış olduğunda;
- slaytların grup olarak işlenmesi, taşınması veya birleştirilmesi gerektiğinde.

Grup slaytların amacını tanımlayan kısa bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, üye olmayı slayt konumlarından türetmek yerine bölüm API’lerini kullanarak belirleyin.

## **Bölümleri Oluşturma ve Yönetme**

[ISectionCollection.addSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) kullanarak bölüm adını ve başlangıç slaytını belirterek bir bölüm oluşturabilirsiniz. Aspose.Slides, mevcut bölüm yapısına göre hangi slaytların bölüme ait olduğunu belirler.

Aynı [ISectionCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectioncollection/) ayrıca şunları yapmanıza olanak tanır:

- [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) kullanarak bir bölümü slaytlarıyla birlikte taşıyın;
- yalnızca bölüm tanımını tutup slaytları koruyan [ISectionCollection.removeSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) ile bölümü kaldırın;
- bölüm ve slaytlarını birlikte kaldırmak için [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) kullanın;
- [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) ile listenin sonuna boş bir bölüm ekleyin.

Aşağıdaki örnek iki bölüm oluşturur, birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

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

Bu işlemlerden sonra sunum, slaytlarıyla birlikte `Introduction` bölümünü ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölüm Adlarını Yeniden Adlandırma**

Bir bölümü yeniden adlandırmak için onun [ISection.setName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#setName-java.lang.String-) yöntemini çağırın. Bölümün slaytları ve konumu değişmeden kalır.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```java
import com.aspose.slides.ISection;
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

## **Bölümlerden Slaytları Almak**

[Presentation.getSections](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSections--) yöntemi, üzerinde yineleme yapabileceğiniz bir [ISectionCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectioncollection/) döndürür. Her bir [ISection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/) için, o an o bölüme ait slaytları elde etmek üzere [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getSlidesListOfSection--) çağrısı yapılır. Bu yöntem bir [ISectionSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectionslidecollection/) döndürür; bu koleksiyon öğe sayısı, indeksli erişim ve yineleme sağlar.

Aşağıdaki örnek iki dolu bölümü ve bir boş bölümü oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getStartedFromSlide--), slayt sayısı ve slayt numaralarını yazdırır. İlk slaytı okumak için [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) kullanılır ve her slaytı işlemek için gelişmiş bir `for` ifadesi kullanılır. Boş bölüm için döndürülen koleksiyonun boyutu sıfırdır; yöntem çağrılmaz ve yineleme hiçbir işlem yapmaz.

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

Bölüm üyeliği, sunumun bölüm yapısına göre belirlenir. Bölüm aralığını [ISection.getStartedFromSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getStartedFromSlide--) ve slayt indekslerinden, bir sonraki bölümün başlangıç slaytından manuel olarak hesaplamayın.

Yapısal düzenlemeler, bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Bu, slaytların yeniden sıralanması, bir slaytın bir bölüme kopyalanması, bir bölümün slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılmasını içerir. Sonraki örnek, bölüm sınırları hakkında varsayımlarda bulunmak yerine, her değişiklikten sonra [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getSlidesListOfSection--) metodunu tekrar çağırır.

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

Slaytlar veya bölümler yeniden sıralandığında, kopyalandığında, taşındığında veya kaldırıldığında her zaman [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getSlidesListOfSection--) metodunu tekrar çağırın. Bu, sonraki işlemlerin mevcut sunum yapısıyla uyumlu olmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm meta verilerini korumaz. Bölüm destekleyen bir format (ör. PPTX) ile bu iş akışını kullanın; PPT’ye dönüştürmek, sonraki yinelemeler için gerekli bölüm yapısını kaldırır.

## **SSS**

**Bölümler, PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez; bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm “gizlenebilir” mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için bölümdeki her slayt için [ISlide.setHidden](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#setHidden-boolean-) yöntemi çağrılmalıdır.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

[Presentation.getSections](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSections--) tarafından döndürülen koleksiyon üzerinde yineleme yapın, her bölüm için [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getSlidesListOfSection--) çağırın ve dönen slaytları hedef slaytla karşılaştırın. Boş olmayan bir bölüm için [ISection.getStartedFromSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getStartedFromSlide--) ilk slaytını verir; boş bir bölüm için `null` döner.