---
title: Các thao tác trình chiếu Low-Code trên Android
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/androidjava/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- duyệt các slide
- duyệt các shape
- duyệt văn bản
- thu thập shape
- nén trình chiếu
- loại bỏ master slide không dùng
- loại bỏ layout slide không dùng
- nén phông chữ được nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trên Android để chuyển đổi và hợp nhất các trình chiếu, duyệt nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

Gói [com.aspose.slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/) cung cấp các lớp trợ giúp tĩnh cho các hoạt động thường gặp trên bản trình chiếu. Những tiện ích này gói các quy trình làm việc trên mô hình đối tượng thường dùng vào các phương pháp tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các thành phần của bản trình chiếu, thu thập các shape và loại bỏ nội dung không dùng tới với ít mã hơn.

Các trợ giúp low‑code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bản trình chiếu và quy trình mặc định đáp ứng yêu cầu của bạn. Sử dụng mô hình đối tượng đầy đủ của [Aspose.Slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/) khi cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất hoặc quan hệ giữa các thành phần của bản trình chiếu.

Bảng sau tóm tắt các helper có sẵn:

| Helper | Mục đích sử dụng |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/) | Chuyển đổi một bản trình chiếu sang định dạng khác bằng cách gọi trực tiếp từ tệp này sang tệp khác. |
| [Merger](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/merger/) | Kết hợp các tệp bản trình chiếu hoàn chỉnh cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/) | Thực hiện một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) | Loại bỏ các master và layout không dùng tới và giảm dữ liệu phông chữ được nhúng. |

## **Chuyển đổi bản trình chiếu**

Sử dụng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức này mở bản trình chiếu nguồn, xác định định dạng yêu cầu dựa trên đường dẫn đầu ra và ghi kết quả.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/) cũng cung cấp các phương pháp chuyên biệt cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi cần kiểm tra hoặc chỉnh sửa bản trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất mà helper không cung cấp. Xem [Convert Presentation](/androidjava/convert-presentation/) để biết quy trình và tùy chọn theo định dạng.

## **Kết hợp các bản trình chiếu**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) để kết hợp các tệp bản trình chiếu hoàn chỉnh chỉ với một lời gọi. Các bản trình chiếu đầu vào phải có cùng định dạng tệp.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Tiện ích này phù hợp khi tất cả các slide cần được nối vào một kết quả mà không cần chọn hoặc ánh xạ lại từng slide. Sử dụng mô hình đối tượng đầy đủ khi cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, giữ nguyên các section một cách rõ ràng, hoặc đồng bộ các kích thước slide khác nhau. Xem [Merge Presentations](/androidjava/merge-presentation/) cho các kịch bản này.

## **Duyệt qua các thành phần của bản trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/) gọi một callback cho mỗi loại thành phần bản trình chiếu được yêu cầu. Nó tránh các vòng lặp thu thập lồng nhau và tiện lợi cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bản trình chiếu.

Ví dụ sau sử dụng [ForEach.slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), và [ForEach.portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) để kiểm tra các yếu tố tương ứng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Mặc định, việc duyệt shape và văn bản trên toàn bộ bản trình chiếu bao gồm các slide bình thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp thu thập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết quan hệ cha‑con là quan trọng.

## **Thu thập các shape**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một bộ sưu tập tất cả các shape trong bản trình chiếu thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) nếu mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung bản trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) có thể loại bỏ các yếu tố cấu trúc không dùng tới và giảm dữ liệu phông chữ được nhúng:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) loại bỏ các slide layout mà không có slide bình thường nào tham chiếu.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) loại bỏ các slide master không còn được sử dụng.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) loại bỏ các ký tự không dùng trong phông chữ được nhúng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hãy xóa các layout không dùng trước các master không dùng, để một master trở nên không tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bản trình chiếu đã tối ưu vào tệp mới nếu bạn có thể cần lại các master, layout hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/androidjava/slide-master/) và [Embedded Font](/androidjava/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low‑code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các helper low‑code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc bản trình chiếu và không yêu cầu kiểm soát chi tiết từng phần tử. Sử dụng mô hình đối tượng đầy đủ khi cần chọn các slide cụ thể, điều khiển quan hệ giữa master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà helper không cung cấp.

**Merger có thể kết hợp các bản trình chiếu ở các định dạng tệp khác nhau không?**

Không. [Merger.process](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) yêu cầu các bản trình chiếu đầu vào có cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào về cùng một định dạng, ví dụ bằng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), rồi mới hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và ghi chú không?**

[ForEach.slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) duyệt các slide trình chiếu bình thường. Các hoạt động [ForEach.shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), và [ForEach.portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) bao gồm slide bình thường, master và layout theo mặc định. Dùng các overload với `includeNotes` được đặt là `true` để bao gồm slide ghi chú.

**Sự khác biệt giữa ForEach.shape và Collect.shapes là gì?**

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) để xử lý mỗi shape ngay lập tức qua callback. Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một kết quả có thể được giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress có luôn làm tệp bản trình chiếu nhỏ hơn không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bản trình chiếu có chứa các layout không dùng, master không dùng, hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có những yếu tố này, các thao tác [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) tương ứng có thể không giảm được kích thước tệp.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các helper này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các phần tử trong callback của [ForEach](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/) hoặc thực thi [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/), hãy gọi [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi kết quả.

## **Bài viết liên quan**

- [Convert Presentation](/androidjava/convert-presentation/)
- [Merge Presentations](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Manage Text Box](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)