---
title: "Áp dụng hoặc Thay đổi Bố cục Slide trong PHP"
linktitle: "Bố cục Slide"
type: docs
weight: 60
url: /vi/php-java/slide-layout/
keywords:
- "bố cục slide"
- "bố cục nội dung"
- "phần giữ chỗ"
- "thiết kế bản trình bày"
- "thiết kế slide"
- "bố cục không sử dụng"
- "hiển thị chân trang"
- "slide tiêu đề"
- "tiêu đề và nội dung"
- "đầu mục phần"
- "hai nội dung"
- "so sánh"
- "chỉ tiêu đề"
- "bố cục trống"
- "nội dung có chú thích"
- "hình ảnh có chú thích"
- "tiêu đề và văn bản dọc"
- "tiêu đề dọc và văn bản"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "PHP"
- "Aspose.Slides"
description: "Áp dụng, tạo và sửa đổi bố cục slide trong Aspose.Slides cho PHP qua Java, thêm phần giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các phần giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục mang lại cấu trúc nhất quán cho các slide đồng thời cho phép mỗi slide chứa nội dung riêng của nó.

- **Title Slide**: Chứa các phần giữ chỗ tiêu đề và phụ đề.
- **Title and Content**: Chứa một phần giữ chỗ tiêu đề và một phần giữ chỗ nội dung đa mục đích.
- **Blank**: Không chứa phần giữ chỗ nội dung và hữu ích khi mọi hình dạng sẽ được định vị thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình bày có ba cấp độ liên quan:

1. A [master slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) xác định chủ đề, định dạng chung, nền và các đối tượng chung.
1. A [layout slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) thuộc về master và xác định một bố trí cụ thể của các phần giữ chỗ.
1. A [normal slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/) sử dụng một bố cục và lưu trữ nội dung đã nhập cho slide đó.

Một normal slide kế thừa chủ đề và định dạng từ layout của nó, và layout kế thừa từ master. Giá trị được đặt trực tiếp trên normal slide sẽ ghi đè giá trị kế thừa ở mức đó. Khi một normal slide được tạo, các hình dạng phần giữ chỗ của nó được tạo ra từ layout đã chọn, trong khi nội dung nhập vào các phần giữ chỗ thuộc về normal slide.

Thêm các phần giữ chỗ cần thiết vào một layout trước khi tạo slide từ nó. Thêm một phần giữ chỗ khác vào layout sau này không tự động thêm hình dạng phần giữ chỗ tương ứng vào các normal slide hiện có.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của phần giữ chỗ hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, kiểm tra các slide phụ thuộc và xem xét bản trình bày kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Hãy chuyển các slide phụ thuộc sang một bố cục khác trước, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cấu trúc này, xem [Slide Master](/slides/vi/php-java/slide-master/).

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng một loại layout khi bản trình bày tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên layout có thể chỉnh sửa bởi người dùng và có thể được bản địa hoá, vì vậy việc chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu layout đó không có, nó sẽ cố ý quay lại **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình bày có thể chỉ chứa các layout tùy chỉnh. Layout đã chọn sau đó được áp dụng cho normal slide đầu tiên thông qua phương thức [Slide.setLayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Thay đổi layout của một slide không xóa các hình dạng thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí phần giữ chỗ, định dạng kế thừa và sự tương ứng giữa các phần giữ chỗ hiện có và layout mới có thể thay đổi, vì vậy hãy kiểm tra đầu ra khi chuyển đổi giữa các layout khác nhau đáng kể.

## **Thêm Bố cục Slide**

Việc lựa chọn và tạo mới là các thao tác riêng biệt. Ví dụ trước chọn một layout có sẵn; nó không tạo ra một layout mới. Để tạo một layout, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterlayoutslidecollection/#add) trên bộ sưu tập layout của master mục tiêu.

Ví dụ sau luôn thêm một layout **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một normal slide dựa trên nó. Tên layout phải là duy nhất trong bộ sưu tập.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Chỉ thêm layout khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã tồn tại một layout phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao trùng lặp.

## **Thêm Phần giữ chỗ vào Bố cục Slide**

Phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getPlaceholderManager) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng phần giữ chỗ vào layout.

| Phần giữ chỗ PowerPoint | `LayoutPlaceholderManager` Method |
| ----------------------- | --------------------------------- |
| ![Nội dung](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Nội dung (Dọc)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Văn bản](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Văn bản (Dọc)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Hình ảnh](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Biểu đồ](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Bảng](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Phương tiện](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Ví dụ sau xác nhận rằng layout **Blank** tồn tại, thêm bốn phần giữ chỗ vào nó, và sau đó tạo một normal slide sử dụng layout đã sửa đổi. Thứ tự này có chủ đích: các phần giữ chỗ được thêm trước khi normal slide được tạo, vì Aspose.Slides có thể tạo các hình dạng phần giữ chỗ tương ứng trên slide đó.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các phần giữ chỗ trên bố cục slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Thay đổi định dạng kế thừa hoặc hình học của các phần giữ chỗ layout hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một phần giữ chỗ layout mới được thêm vào sẽ không tự động được đưa vào các normal slide hiện có. Hãy thử các thay đổi layout trên một bản sao của bản trình bày và kiểm tra mọi slide phụ thuộc.

{{% /alert %}}

## **Xóa Bố cục Slide không sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) để xóa các layout mà không có normal slide nào tham chiếu. Phương thức này giữ nguyên các layout vẫn đang được sử dụng.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để xóa một layout cụ thể, trước hết sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#hasDependingSlides) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getDependingSlides). Chuyển các slide phụ thuộc sang layout khác trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#remove). Cố gắng xóa một layout đang được sử dụng sẽ gây ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Chân trang trên Bố cục Slide**

Một layout có các phần giữ chỗ chân trang, số slide và ngày‑giờ riêng. Sử dụng phương thức [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) để kiểm soát các phần giữ chỗ này cho một layout. Điều này hữu ích khi, ví dụ, các layout nội dung nên hiển thị chân trang nhưng các layout tiêu đề không.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm soát Hiển thị Chân trang trên Master và các Bố cục Con của nó**

Để áp dụng cài đặt chân trang nhất quán trên toàn bộ cấu trúc master, sử dụng phương thức [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Các phương thức truyền đạt của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslideheaderfootermanager/) hoạt động trên master và các layout slide và normal slide phụ thuộc; chúng không chỉ nhắm tới một normal slide duy nhất.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Master slide định nghĩa chủ đề và định dạng chung của bản trình bày. Layout slide thuộc về master và xác định một cách bố trí phần giữ chỗ có thể tái sử dụng. Normal slide sử dụng những layout này và lưu trữ nội dung riêng của từng slide.

**Tôi có thể sao chép Layout Slide từ một bản trình bày sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/globallayoutslidecollection/#addClone). Khi sao chép giữa các bản trình bày, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác mà layout nguồn sử dụng.

**Điều gì xảy ra khi tôi sửa đổi một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi layout trừ khi chúng đã ghi đè định dạng hoặc đối tượng ảnh hưởng ở mức local. Vì vậy hình học phần giữ chỗ và kiểu dáng kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getDependingSlides) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa layout.

**Điều gì xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/). Hãy chuyển các slide phụ thuộc sang layout khác trước, hoặc dùng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) để chỉ xóa các layout không được tham chiếu.