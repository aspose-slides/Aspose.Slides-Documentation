---
title: "Áp dụng hoặc Thay đổi Bố cục Slide trong PHP"
linktitle: "Bố cục Slide"
type: docs
weight: 60
url: /vi/php-java/slide-layout/
keywords:
- "bố cục slide"
- "bố cục nội dung"
- "trình giữ chỗ"
- "thiết kế bản trình chiếu"
- "thiết kế slide"
- "bố cục không sử dụng"
- "khả năng hiển thị footer"
- "slide tiêu đề"
- "tiêu đề và nội dung"
- "đầu mục phần"
- "hai nội dung"
- "so sánh"
- "chỉ tiêu đề"
- "bố cục trống"
- "nội dung với chú thích"
- "hình ảnh với chú thích"
- "tiêu đề và văn bản dọc"
- "tiêu đề dọc và văn bản"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "PHP"
- "Aspose.Slides"
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho PHP qua Java, thêm trình giữ chỗ, xóa các bố cục không sử dụng và kiểm soát khả năng hiển thị footer."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các placeholder như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục sẽ mang lại cho các slide cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các placeholder tiêu đề và phụ đề.
- **Title and Content**: Chứa một placeholder tiêu đề và một placeholder nội dung đa mục đích.
- **Blank**: Không chứa placeholder nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình chiếu có ba mức liên quan:

1. A [slide chủ đề](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) định nghĩa chủ đề, định dạng chung, nền và các đối tượng chung.
2. A [slide bố cục](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) thuộc về một slide chủ đề và xác định một phối trí cụ thể của các placeholder.
3. A [slide thường](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/) sử dụng một bố cục và lưu trữ nội dung đã nhập cho slide đó.

Một slide thường kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục kế thừa từ slide chủ đề. Giá trị được đặt trực tiếp trên slide thường sẽ ghi đè lên giá trị kế thừa ở cấp độ đó. Khi một slide thường được tạo, các hình dạng placeholder của nó được tạo từ bố cục đã chọn, trong khi nội dung nhập vào các placeholder ấy thuộc về slide thường.

Thêm các placeholder cần thiết vào bố cục trước khi tạo slide từ nó. Thêm một placeholder khác vào bố cục sau này sẽ không tự động thêm hình dạng placeholder tương ứng vào các slide thường đã tồn tại.

Mối quan hệ này có hai hệ quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của placeholder hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem lại bản trình chiếu kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Đầu tiên hãy gán lại các slide phụ thuộc của nó sang một bố cục khác, hoặc chỉ xóa các bố cục không được sử dụng.

For more information about the top level of this hierarchy, see [Slide Master](/slides/vi/php-java/slide-master/).

Ví dụ so sánh hai slide sử dụng cùng một master.

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng loại bố cục khi bản trình chiếu tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được bản địa hoá, do đó việc lựa chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ dưới đây tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không khả dụng, nó sẽ cố tình quay lại **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình chiếu có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide thường đầu tiên thông qua phương thức [Slide.setLayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#setLayoutSlide) method.

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

Thay đổi bố cục của một slide không loại bỏ các hình dạng thông thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí placeholder, định dạng kế thừa và sự tương đồng giữa các placeholder hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các bố cục khác nhau đáng kể.

## **Thêm một Bố cục Slide**

Việc chọn và tạo là các thao tác riêng biệt. Ví dụ trước đã chọn một bố cục hiện có; nó không tạo ra một bố cục mới. Để tạo bố cục, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterlayoutslidecollection/#add) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ dưới đây luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

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

Chỉ thêm bố cục khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã có một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Placeholder vào Bố cục Slide**

Phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getPlaceholderManager) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng placeholder vào một bố cục.

| Placeholder PowerPoint              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Nội dung](content.png)            | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Nội dung (Dọc)](contentV.png)     | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Văn bản](text.png)                | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Văn bản (Dọc)](textV.png)         | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Hình ảnh](picture.png)            | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Biểu đồ](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Bảng](table.png)                  | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Phương tiện](media.png)           | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Ví dụ dưới đây xác minh rằng bố cục **Blank** tồn tại, thêm bốn placeholder vào nó, và sau đó tạo một slide thường sử dụng bố cục đã chỉnh sửa. Thứ tự này có chủ đích: các placeholder được thêm trước khi slide thường được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng placeholder tương ứng trên slide đó.

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

![Các placeholder trên bố cục slide](add_placeholders.png)

{{% alert color="warning" title="Cảnh báo" %}}
Thay đổi định dạng kế thừa hoặc hình học của các placeholder bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Placeholder bố cục mới được thêm sẽ không được tự động điền vào các slide thường đã tồn tại. Hãy thử các thay đổi bố cục trên một bản sao của bản trình chiếu và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Bố cục Slide Không được Sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) để xóa các bố cục mà không có slide thường nào tham chiếu. Phương thức này giữ nguyên các bố cục vẫn đang được sử dụng.

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

Để xóa một bố cục cụ thể, trước tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#hasDependingSlides) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getDependingSlides) của nó. Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#remove). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/).

## **Kiểm soát Khả năng hiển thị Footer trên Bố cục Slide**

Một bố cục có các placeholder footer, số slide và ngày‑giờ riêng. Sử dụng phương thức [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) để kiểm soát các placeholder này cho một bố cục. Điều này hữu ích khi, ví dụ, bố cục nội dung cần hiển thị footer nhưng bố cục tiêu đề không.

Ví dụ dưới đây chọn một bố cục một cách an toàn và làm cho các thành phần footer của nó hiển thị:

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

## **Kiểm soát Khả năng hiển thị Footer trên Master và các Bố cục Con của nó**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cây master, sử dụng phương thức [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Các phương thức lan truyền của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslideheaderfootermanager/) hoạt động trên master và các slide bố cục và slide thường phụ thuộc; chúng không chỉ nhắm mục tiêu một slide thường duy nhất.

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

## **Câu hỏi Thường gặp**

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Một master slide định nghĩa chủ đề và định dạng chung của bản trình chiếu. Một layout slide thuộc về một master và xác định một phối trí placeholder có thể tái sử dụng. Các slide thường sử dụng các bố cục này và lưu trữ nội dung riêng của mỗi slide.

**Tôi có thể sao chép một Layout Slide từ một bản trình chiếu sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/globallayoutslidecollection/#addClone). Khi sao chép giữa các bản trình chiếu, cũng cần xác minh phông chữ, chủ đề, hình ảnh và các tài nguyên khác được bố cục nguồn sử dụng.

**Điều gì xảy ra khi tôi sửa đổi một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng liên quan ở mức cục bộ. Vì vậy hình học placeholder và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getDependingSlides) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/). Đầu tiên hãy gán lại các slide phụ thuộc, hoặc sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) để chỉ xóa các bố cục không được tham chiếu.