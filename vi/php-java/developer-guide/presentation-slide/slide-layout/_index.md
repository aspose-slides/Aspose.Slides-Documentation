---
title: Áp dụng hoặc Thay đổi bố cục slide trong PHP
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/php-java/slide-layout/
keywords:
  - bố cục slide
  - bố cục nội dung
  - chỗ giữ chỗ
  - thiết kế bản trình bày
  - thiết kế slide
  - bố cục không sử dụng
  - hiển thị chân trang
  - slide tiêu đề
  - tiêu đề và nội dung
  - tiêu đề phần
  - hai nội dung
  - so sánh
  - chỉ tiêu đề
  - bố cục trống
  - nội dung có chú thích
  - hình ảnh có chú thích
  - tiêu đề và văn bản dọc
  - tiêu đề dọc và văn bản
  - PowerPoint
  - OpenDocument
  - bản trình bày
  - PHP
  - Aspose.Slides
description: "Quản lý và tùy chỉnh bố cục slide trong Aspose.Slides cho PHP thông qua Java. Khám phá các loại bố cục, kiểm soát chỗ giữ chỗ và hiển thị chân trang qua các ví dụ mã."
---
## **Giới thiệu**

Bố cục slide xác định cách sắp xếp các hộp chỗ giữ chỗ và định dạng cho nội dung trên một slide. Nó kiểm soát các chỗ giữ chỗ nào khả dụng và chúng xuất hiện ở đâu. Bố cục slide giúp bạn thiết kế bản trình bày nhanh chóng và nhất quán—dù bạn đang tạo một thứ đơn giản hay phức tạp hơn. Một số bố cục slide phổ biến nhất trong PowerPoint bao gồm:

**Bố cục Slide Tiêu đề** – Bao gồm hai chỗ giữ chỗ văn bản: một cho tiêu đề và một cho phụ đề.

**Bố cục Tiêu đề và Nội dung** – Có chỗ giữ chỗ tiêu đề nhỏ hơn ở trên cùng và chỗ giữ chỗ lớn hơn bên dưới cho nội dung chính (như văn bản, dấu đầu dòng, biểu đồ, hình ảnh và hơn nữa).

**Bố cục Trống** – Không chứa chỗ giữ chỗ nào, cho phép bạn kiểm soát hoàn toàn để thiết kế slide từ đầu.

Bố cục slide là một phần của slide master, là slide cấp cao nhất xác định kiểu bố cục cho bản trình bày. Bạn có thể truy cập và sửa đổi các slide bố cục thông qua slide master—bằng kiểu, tên hoặc ID duy nhất. Ngoài ra, bạn có thể chỉnh sửa một slide bố cục cụ thể trực tiếp trong bản trình bày.

Để làm việc với bố cục slide trong Aspose.Slides for PHP, bạn có thể sử dụng:
- Các phương thức như [getLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getLayoutSlides) và [getMasters](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getMasters) trong lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) 
- Các kiểu như [LayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/), và [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Để tìm hiểu thêm về cách làm việc với slide master, hãy xem bài viết [Slide Master](/slides/vi/php-java/slide-master/).
{{% /alert %}}

## **Thêm Bố cục Slide vào Bản Trình Bày**

Để tùy chỉnh giao diện và cấu trúc của các slide, bạn có thể cần thêm các slide bố cục mới vào bản trình bày. Aspose.Slides for PHP cho phép bạn kiểm tra xem một bố cục cụ thể đã tồn tại chưa, thêm mới nếu cần, và sử dụng nó để chèn các slide dựa trên bố cục đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Truy cập vào [MasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterlayoutslidecollection/).
1. Kiểm tra xem slide bố cục mong muốn đã tồn tại trong bộ sưu tập hay chưa. Nếu chưa, thêm slide bố cục bạn cần.
1. Thêm một slide trống dựa trên slide bố cục mới.
1. Lưu bản trình bày.

Đoạn mã PHP sau đây minh họa cách thêm một bố cục slide vào bản trình bày PowerPoint:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Duyệt các loại slide bố cục để chọn một slide bố cục.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Trường hợp bản trình bày không chứa mọi loại bố cục.
        // Tệp bản trình bày chỉ chứa các loại bố cục Blank và Custom.
        // Tuy nhiên, các slide bố cục với loại tùy chỉnh có thể có tên nhận dạng được,
        // chẳng hạn như "Title", "Title and Content", v.v., có thể dùng để lựa chọn slide bố cục.
        // Bạn cũng có thể dựa vào một tập hợp các loại hình dạng chỗ giữ chỗ.
        // Ví dụ, một slide Title chỉ nên có loại chỗ giữ chỗ Title, và tương tự.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Thêm một slide trống sử dụng slide bố cục đã thêm.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Lưu bản trình bày vào đĩa.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Xóa Các Slide Bố Cục Không Sử Dụng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) từ lớp [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/) để cho phép bạn xóa các slide bố cục không mong muốn và không được sử dụng.

Đoạn mã PHP sau đây cho thấy cách xóa một slide bố cục khỏi bản trình bày PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thêm Chỗ Giữ Chỗ Vào Bố Cục Slide**

Aspose.Slides cung cấp phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getPlaceholderManager) cho phép bạn thêm các chỗ giữ chỗ mới vào một slide bố cục.

Trình quản lý này chứa các phương thức cho các loại chỗ giữ chỗ sau:

| Chỗ giữ chỗ PowerPoint | Phương thức [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/) |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Đoạn mã PHP sau đây minh họa cách thêm các hình dạng chỗ giữ chỗ mới vào slide bố cục Trống:

```php
$presentation = new Presentation();
try {
    // Lấy slide bố cục Blank.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Lấy trình quản lý chỗ giữ chỗ của slide bố cục.
    $placeholderManager = $layout->getPlaceholderManager();

    // Thêm các chỗ giữ chỗ khác nhau vào slide bố cục Blank.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Thêm một slide mới với bố cục Blank.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các chỗ giữ chỗ trên slide bố cục](add_placeholders.png)

## **Đặt Hiển Thị Chân Trang cho Slide Bố Cục**

Trong bản trình bày PowerPoint, các thành phần chân trang như ngày tháng, số slide và văn bản tùy chỉnh có thể được hiển thị hoặc ẩn tùy thuộc vào bố cục slide. Aspose.Slides for PHP cho phép bạn điều khiển việc hiển thị của các chỗ giữ chỗ chân trang này. Điều này hữu ích khi bạn muốn một số bố cục hiển thị thông tin chân trang trong khi các bố cục khác giữ sạch sẽ và tối giản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu slide bố cục bằng chỉ mục của nó.
1. Đặt chỗ giữ chỗ chân trang slide thành hiển thị.
1. Đặt chỗ giữ chỗ số slide thành hiển thị.
1. Đặt chỗ giữ chỗ ngày‑giờ thành hiển thị.
1. Lưu bản trình bày.

Đoạn mã PHP sau đây cho thấy cách đặt hiển thị của chân trang slide và thực hiện các tác vụ liên quan:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Đặt Hiển Thị Chân Trang Con cho Slide**

Trong bản trình bày PowerPoint, các thành phần chân trang như ngày tháng, số slide và văn bản tùy chỉnh có thể được kiểm soát ở mức slide master để đảm bảo tính nhất quán trên tất cả các slide bố cục. Aspose.Slides for PHP cho phép bạn đặt hiển thị và nội dung của các chỗ giữ chỗ chân trang này trên slide master và lan truyền các thiết lập này tới tất cả các slide bố cục con. Cách tiếp cận này đảm bảo thông tin chân trang đồng nhất trong suốt bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide master bằng chỉ mục của nó.
1. Đặt các chỗ giữ chỗ chân trang của master và tất cả các slide con thành hiển thị.
1. Đặt các chỗ giữ chỗ số slide của master và tất cả các slide con thành hiển thị.
1. Đặt các chỗ giữ chỗ ngày‑giờ của master và tất cả các slide con thành hiển thị.
1. Lưu bản trình bày.

Đoạn mã PHP sau đây minh họa thao tác này:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **CÂU HỎI THƯỜNG GẶP**

**Sự khác nhau giữa slide master và slide bố cục là gì?**

Slide master xác định chủ đề tổng thể và định dạng mặc định, trong khi các slide bố cục xác định cách sắp xếp cụ thể các chỗ giữ chỗ cho các loại nội dung khác nhau.

**Tôi có thể sao chép một slide bố cục từ bản trình bày này sang bản trình bày khác không?**

Đúng, bạn có thể sao chép một slide bố cục từ bộ sưu tập slide bố cục của một bản trình bày, có thể truy cập thông qua phương thức [getLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getLayoutSlides), và chèn nó vào một bản trình bày khác bằng phương thức `addClone`.

**Điều gì xảy ra nếu tôi xóa một slide bố cục mà vẫn đang được một slide khác sử dụng?**

Nếu bạn cố gắng xóa một slide bố cục vẫn được ít nhất một slide trong bản trình bày tham chiếu, Aspose.Slides sẽ ném ra một ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/). Để tránh điều này, hãy sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), phương thức này sẽ an toàn xóa chỉ các slide bố cục không được sử dụng.