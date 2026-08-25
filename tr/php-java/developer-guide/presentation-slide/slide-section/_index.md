---
title: PHP ile Sunumlarda Slayt Bölümlerini Yönetin
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/php-java/slide-section/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile slayt bölümlerini yönetin: PPTX sunumlarında bölüm slaytlarını oluşturun, yeniden adlandırın, yeniden sıralayın, alın ve işleyin."
---
## **Giriş**

Bölümler, ardışık slaytları içeriği değiştirmeden adlandırılmış gruplar halinde düzenler. Aspose.Slides for PHP via Java ile, bölümleri [Presentation::getSections](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSections) yöntemiyle oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve kaldırabilirsiniz.

Bölümler özellikle şu durumlarda faydalıdır:

- büyük bir sunumun mantıksal konulara veya bölümlere ayrılması gerekir;
- slaytların farklı grupları farklı iş ortaklarına atanır;
- slaytların grup olarak işlenmesi, taşınması veya birleştirilmesi gerekir.

Grup slaytların amacını anlatan özlü bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, üye olmayı slayt konumlarından türetmek yerine bölüm API’lerini kullanarak belirleyin.

## **Bölümleri Oluşturma ve Yönetme**

[SectionCollection::addSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/#addSection) metodunu kullanarak bölümün adını ve başlangıç slaytını belirterek bir bölüm oluşturun. Aspose.Slides, bölümün hangi slaytlara ait olduğunu sunumun mevcut bölüm yapısından belirler.

Aynı [SectionCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/) ayrıca şunları yapmanıza olanak tanır:

- bir bölümü slaytlarıyla birlikte taşımak için [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides) metodunu kullanın;
- yalnızca bölüm tanımını kaldırmak, slaytlarını korumak için [SectionCollection::removeSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/#removeSection) metodunu kullanın;
- bir bölümü ve slaytlarını birlikte kaldırmak için [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides) metodunu kullanın;
- sonuna boş bir bölüm eklemek için [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/#appendEmptySection) metodunu kullanın.

Aşağıdaki örnek iki bölüm oluşturur, birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

Bu işlemlerden sonra sunum, slaytlarıyla birlikte `Introduction` bölümünü ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölümleri Yeniden Adlandırma**

Bir bölümü yeniden adlandırmak için onun [Section::setName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#setName) metodunu çağırın. Bölümün slaytları ve konumu değişmeden kalır.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **Bölümlerden Slaytları Getirme**

[Presentation::getSections](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSections) metodu, indeksle işleyebileceğiniz bir [SectionCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/) döndürür. Her [Section](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/) için, o anda ona ait slaytları elde etmek üzere [Section::getSlidesListOfSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getSlidesListOfSection) metodunu çağırın. Metod, bir [SectionSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionSlideCollection/) döndürür; bu koleksiyon sayım ve indeksli erişim sağlar.

Aşağıdaki örnek iki dolu bölüm ve bir boş bölüm oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getStartedFromSlide), slayt sayısı ve slayt numaralarını yazdırır. İndeksli erişim için [SectionCollection::get_Item](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionCollection/#get_Item) ve [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SectionSlideCollection/#get_Item) kullanılır. Boş bölüm için döndürülen koleksiyonun boyutu sıfırdır ve `get_Item` çağrılmaz.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Bölüm üyeliği, sunumun bölüm yapısı tarafından belirlenir. Bir bölümün aralığını [Section::getStartedFromSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getStartedFromSlide), slayt indeksleri ve bir sonraki bölümün başlangıç slaytı üzerinden manuel olarak hesaplamayın.

Yapısal düzenlemeler, bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Bu, slaytların yeniden sıralanması, bir slaytın bir bölüme klonlanması, bir bölümü slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılmasını içerir. Sonraki örnek, bölümlerin önceki sınırlarıyla ilgili varsayımları tutmak yerine her değişiklikten sonra [Section::getSlidesListOfSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getSlidesListOfSection) metodunu çağırır.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

Slaytlar veya bölümler yeniden sıralandığında, klonlandığında, taşındığında veya kaldırıldığında [Section::getSlidesListOfSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getSlidesListOfSection) metodunu tekrar çağırın. Bu, sonraki işleme geçerli sunum yapısıyla uyumlu kalmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm üst verilerini korumaz. Bölüm desteği sunan bir formatla, örneğin PPTX, çalışın; PPT’ye dönüştürmek, daha sonraki yineleme için gereken bölüm yapısını kaldırır.

## **SSS**

**Bölümler PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm üst verilerini desteklemez, bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Tüm bir bölüm “gizlenebilir” mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için bölümdeki her slayt için [Slide::setHidden](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Slide/#setHidden) metodunu çağırın.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

[Presentation::getSections](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSections) tarafından döndürülen koleksiyonu dolaşın, her bölüm için [Section::getSlidesListOfSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getSlidesListOfSection) metodunu çağırın ve dönen slaytları hedef slayt ile karşılaştırın. Boş olmayan bir bölüm için [Section::getStartedFromSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getStartedFromSlide) ilk slaytını verir; boş bir bölüm için `null` döner.