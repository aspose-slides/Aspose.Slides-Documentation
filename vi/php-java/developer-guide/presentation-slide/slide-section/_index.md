---
title: Quản lý các phần slide trong bản trình bày bằng PHP
linktitle: Phần Slide
type: docs
weight: 90
url: /vi/php-java/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- lấy slide của phần
- xử lý slide của phần
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý các phần slide với Aspose.Slides cho PHP qua Java: tạo, đổi tên, sắp xếp lại, lấy và xử lý các slide của phần trong bản trình bày PPTX."
---
## **Giới thiệu**

Các phần tổ chức các slide liên tiếp thành các nhóm có tên mà không thay đổi nội dung slide. Với Aspose.Slides cho PHP thông qua Java, bạn có thể tạo, sắp xếp lại, đổi tên, kiểm tra và xóa các phần thông qua phương thức [Presentation::getSections](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSections).

Các phần đặc biệt hữu ích khi:

- một bản trình bày lớn cần được chia thành các chủ đề hoặc chương logic;
- các nhóm slide khác nhau được giao cho các cộng tác viên khác nhau;
- các slide cần được xử lý, di chuyển hoặc hợp nhất theo nhóm.

Chọn các tên phần ngắn gọn mô tả mục đích của các slide đã nhóm. Vì các phần là một phần của cấu trúc bản trình bày, hãy sử dụng API phần để xác định thành viên thay vì suy ra từ vị trí slide.

## **Tạo và quản lý các phần**

Sử dụng [SectionCollection::addSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/#addSection) để tạo một phần bằng cách chỉ định tên và slide bắt đầu. Aspose.Slides xác định các slide thuộc phần từ cấu trúc phần hiện tại của bản trình bày.

Cùng với [SectionCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/) bạn cũng có thể:
- di chuyển một phần cùng với các slide của nó bằng cách sử dụng [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- xóa chỉ định nghĩa phần bằng [SectionCollection::removeSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/#removeSection), mà vẫn giữ các slide của nó;
- xóa một phần và các slide của nó bằng [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- thêm một phần trống ở cuối bằng [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Ví dụ sau tạo hai phần, di chuyển một trong số chúng, xóa nó cùng với các slide, và thêm một phần trống:

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

Sau các thao tác này, bản trình bày chứa phần `Introduction` cùng các slide và một phần `Appendix` trống. Phần `Results` và các slide của nó đã bị xóa.

## **Đổi tên các phần**

Để đổi tên một phần, gọi phương thức [Section::setName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#setName). Các slide và vị trí của phần không thay đổi.

Ví dụ sau tạo một phần và thay đổi tên của nó:

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

## **Lấy slide từ các phần**

Phương thức [Presentation::getSections](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSections) trả về một [SectionCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/) mà bạn có thể xử lý theo chỉ mục. Đối với mỗi [Section](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/), gọi [Section::getSlidesListOfSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getSlidesListOfSection) để lấy các slide hiện đang thuộc về nó. Phương thức này trả về một [SectionSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionSlideCollection/), cung cấp số lượng và truy cập theo chỉ mục.

Ví dụ sau tạo hai phần đã được điền nội dung và một phần trống, sau đó in ra [name](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getStartedFromSlide), số lượng slide và số thứ tự slide của mỗi phần. Nó sử dụng [SectionCollection::get_Item](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionCollection/#get_Item) và [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SectionSlideCollection/#get_Item) để truy cập theo chỉ mục. Đối với phần trống, bộ sưu tập trả về có kích thước bằng không và không gọi `get_Item`.

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

Thành viên của phần được xác định bởi cấu trúc phần của bản trình bày. Không tự tính phạm vi của một phần bằng cách lấy [Section::getStartedFromSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getStartedFromSlide), chỉ mục slide và slide bắt đầu của phần tiếp theo.

Các chỉnh sửa cấu trúc có thể thay đổi cả các slide trả về cho một phần và số thứ tự slide của chúng. Điều này bao gồm sắp xếp lại slide, sao chép một slide vào một phần, di chuyển một phần cùng với các slide của nó, xóa slide và xóa phần. Ví dụ tiếp theo gọi [Section::getSlidesListOfSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getSlidesListOfSection) sau mỗi thay đổi như vậy thay vì giữ các giả định về ranh giới trước đây của phần.

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

Gọi [Section::getSlidesListOfSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getSlidesListOfSection) lại bất cứ khi nào slide hoặc phần được sắp xếp lại, sao chép, di chuyển hoặc xóa. Điều này giúp quá trình xử lý tiếp theo phù hợp với cấu trúc bản trình bày hiện tại.

Định dạng PPT (PowerPoint 97–2003) không lưu siêu dữ liệu phần. Hãy sử dụng quy trình này với định dạng hỗ trợ phần, chẳng hạn PPTX; việc chuyển đổi sang PPT sẽ loại bỏ cấu trúc phần cần thiết cho các vòng lặp sau.

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, do đó việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Một phần không có trạng thái hiển thị. Để ẩn nội dung của nó, hãy gọi [Slide::setHidden](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Slide/#setHidden) cho mỗi slide trong phần.

**Làm thế nào để tìm phần chứa một slide?**

Duyệt qua bộ sưu tập trả về bởi [Presentation::getSections](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSections), gọi [Section::getSlidesListOfSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getSlidesListOfSection) cho mỗi phần, và so sánh các slide trả về với slide mục tiêu. Đối với một phần không rỗng, [Section::getStartedFromSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Section/#getStartedFromSlide) trả về slide đầu tiên; đối với một phần rỗng, nó trả về `null`.