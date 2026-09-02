---
title: Các hoạt động trình chiếu low-code trong PHP
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/php-java/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- lặp qua slide
- lặp qua shape
- lặp qua văn bản
- thu thập shape
- nén trình chiếu
- xóa slide master không dùng
- xóa slide layout không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- PHP
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong PHP để chuyển đổi và hợp nhất các trình chiếu, lặp qua nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

The [aspose.slides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/) namespace cung cấp các lớp trợ giúp tĩnh cho các thao tác trình chiếu phổ biến. Những trợ giúp này gói gọn các quy trình mô hình đối tượng thường dùng vào các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các thành phần của trình chiếu, thu thập các shape và loại bỏ nội dung không dùng tới với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc trình chiếu và quy trình mặc định phù hợp với yêu cầu của bạn. Sử dụng toàn bộ [Aspose.Slides object model](https://reference.aspose.com/slides/vi/php-java/aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất, hoặc mối quan hệ giữa các thành phần của trình chiếu.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/php-java/aspose.slides/convert/) | Chuyển đổi một trình chiếu sang định dạng khác bằng lời gọi trực tiếp từ tệp này sang tệp khác. |
| [Merger](https://reference.aspose.com/slides/vi/php-java/aspose.slides/merger/) | Kết hợp các tệp trình chiếu hoàn chỉnh cùng định dạng. |
| [ForEach_](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/) | Thực thi một callback cho mỗi slide, shape, paragraph hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/collect/) | Lấy các shape từ toàn bộ trình chiếu để xử lý hoặc phân tích nhiều lần. |
| [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/) | Xóa các master và layout không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một trình chiếu**

Sử dụng [Convert::autoByExtension](https://reference.aspose.com/slides/vi/php-java/aspose.slides/convert/#autoByExtension) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức này mở trình chiếu nguồn, xác định định dạng yêu cầu từ đường dẫn đầu ra và ghi kết quả.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/php-java/aspose.slides/convert/) cũng cung cấp các phương thức riêng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng toàn bộ mô hình đối tượng khi bạn cần kiểm tra hoặc sửa đổi trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất không được trợ giúp này cung cấp. Xem [Chuyển đổi trình chiếu](/slides/vi/php-java/convert-presentation/) để biết quy trình và tùy chọn theo định dạng.

## **Kết hợp các trình chiếu**

Sử dụng [Merger::process](https://reference.aspose.com/slides/vi/php-java/aspose.slides/merger/#process) để kết hợp các tệp trình chiếu hoàn chỉnh trong một lời gọi. Các trình chiếu đầu vào phải có cùng định dạng tệp.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối vào một kết quả mà không cần chọn hoặc ánh xạ lại từng slide. Sử dụng toàn bộ mô hình đối tượng khi bạn cần hợp nhất các slide được chọn, áp dụng master hoặc layout đích, giữ nguyên các phần rõ ràng, hoặc đồng bộ các kích thước slide khác nhau. Xem [Kết hợp các trình chiếu](/slides/vi/php-java/merge-presentation/) cho các kịch bản này.

## **Lặp qua các thành phần của trình chiếu**

Lớp [ForEach_](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/) gọi một callback cho mỗi loại thành phần trình chiếu được yêu cầu. Nó tránh các vòng lặp collection lồng nhau và tiện lợi cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ trình chiếu.

Ví dụ dưới đây sử dụng [ForEach_::slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#paragraph) và [ForEach_::portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#portion) để kiểm tra các phần tử tương ứng:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Mặc định, việc duyệt shape và văn bản trên toàn bộ trình chiếu bao gồm các slide thông thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp collection trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết cha-con là quan trọng.

## **Thu thập Shape**

Sử dụng [Collect::shapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/collect/#shapes) khi bạn cần một tập hợp tất cả các shape trong một trình chiếu thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một bộ sẽ được lọc, đếm hoặc xử lý nhiều lần.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Sử dụng [ForEach_::shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#shape) thay thế khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/) có thể xóa các yếu tố cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) xóa các slide layout mà không có slide thông thường nào tham chiếu.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedMasterSlides) xóa các slide master không còn được sử dụng.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#compressEmbeddedFonts) xóa các ký tự không dùng khỏi phông chữ nhúng.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Xóa các layout không dùng trước các master không dùng để một master mất tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu trình chiếu đã tối ưu vào một tệp mới nếu bạn có thể cần lại các master, layout gốc hoặc toàn bộ dữ liệu phông chữ nhúng sau này. Để biết chi tiết hơn, xem [Slide Master](/slides/vi/php-java/slide-master/) và [Embedded Font](/slides/vi/php-java/embedded-font/).

## **FAQ**

**Khi nào tôi nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc trình chiếu và không yêu cầu kiểm soát chi tiết các thành phần riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát mối quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các trình chiếu ở các định dạng tệp khác nhau không?**

Không. [Merger::process](https://reference.aspose.com/slides/vi/php-java/aspose.slides/merger/#process) yêu cầu các trình chiếu đầu vào cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert::autoByExtension](https://reference.aspose.com/slides/vi/php-java/aspose.slides/convert/#autoByExtension), sau đó hợp nhất các tệp đã chuyển đổi.

**ForEach_ có xử lý các slide master, layout và ghi chú không?**

[ForEach_::slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#slide) lặp qua các slide trình chiếu thông thường. Các thao tác [ForEach_::shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#paragraph) và [ForEach_::portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#portion) trên toàn trình chiếu bao gồm các slide thông thường, master và layout theo mặc định. Sử dụng các overload với `includeNotes` đặt thành `true` để bao gồm các slide ghi chú.

**Sự khác biệt giữa ForEach_::shape và Collect::shapes là gì?**

Sử dụng [ForEach_::shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/#shape) để xử lý mỗi shape ngay lập tức qua một callback. Sử dụng [Collect::shapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/collect/#shapes) khi bạn cần một kết quả có thể lặp lại, giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress luôn làm cho tệp trình chiếu nhỏ hơn không?**

Không nhất thiết. Kết quả phụ thuộc vào việc trình chiếu có chứa các layout không dùng, master không dùng, hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có các yếu tố trên, các thao tác [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/) tương ứng có thể không làm giảm kích thước tệp.

**Các thay đổi do ForEach_ hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các phần tử trong callback của [ForEach_](https://reference.aspose.com/slides/vi/php-java/aspose.slides/foreach_/), hoặc chạy [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/), gọi [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi trình chiếu](/slides/vi/php-java/convert-presentation/)
- [Kết hợp các trình chiếu](/slides/vi/php-java/merge-presentation/)
- [Slide Master](/slides/vi/php-java/slide-master/)
- [Quản lý hộp văn bản](/slides/vi/php-java/manage-textbox/)
- [Embedded Font](/slides/vi/php-java/embedded-font/)