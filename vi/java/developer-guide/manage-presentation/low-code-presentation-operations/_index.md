---
title: Các hoạt động trình chiếu low-code trong Java
linktitle: API low-code
type: docs
weight: 50
url: /vi/java/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- duyệt slide
- duyệt shape
- duyệt văn bản
- thu thập shape
- nén trình chiếu
- xóa master slide không dùng
- xóa layout slide không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong Java để chuyển đổi và hợp nhất các trình chiếu, duyệt nội dung, thu thập shape và giảm kích thước tệp trình chiếu."
---
## **Tổng quan**

Gói [com.aspose.slides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/) cung cấp các lớp trợ giúp tĩnh cho các thao tác trình chiếu thường gặp. Các trợ giúp này đóng gói các quy trình làm việc với mô hình đối tượng thường được sử dụng vào các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các yếu tố của trình chiếu, thu thập các shape và loại bỏ nội dung không dùng tới với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc trình chiếu và quy trình làm việc mặc định đáp ứng yêu cầu của bạn. Sử dụng toàn bộ [Aspose.Slides object model](https://reference.aspose.com/slides/vi/java/com.aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất hoặc mối quan hệ giữa các yếu tố của trình chiếu.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Mục đích sử dụng |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/) | Chuyển đổi một bài trình chiếu sang định dạng khác bằng gọi trực tiếp file‑to‑file. |
| [Merger](https://reference.aspose.com/slides/vi/java/com.aspose.slides/merger/) | Kết hợp các tệp trình chiếu hoàn chỉnh cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/) | Thực thi một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/collect/) | Lấy các shape từ toàn bộ trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) | Xóa các master và layout không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một trình chiếu**

Sử dụng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức mở trình chiếu nguồn, xác định định dạng yêu cầu từ đường dẫn đầu ra và ghi kết quả.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/) cũng cung cấp các phương thức riêng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng toàn bộ mô hình đối tượng khi bạn cần kiểm tra hoặc sửa đổi trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất không được trợ giúp chọn hiển thị. Xem [Convert Presentation](/slides/vi/java/convert-presentation/) để biết quy trình và tùy chọn riêng cho từng định dạng.

## **Hợp nhất các trình chiếu**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) để kết hợp các tệp trình chiếu hoàn chỉnh chỉ bằng một lời gọi. Các trình chiếu đầu vào phải có cùng định dạng tệp.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối thêm vào một kết quả duy nhất mà không cần chọn hoặc ánh xạ lại chúng riêng lẻ. Sử dụng toàn bộ mô hình đối tượng khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, bảo tồn các phần rõ ràng, hoặc điều chỉnh các kích thước slide khác nhau. Xem [Merge Presentations](/slides/vi/java/merge-presentation/) cho các kịch bản đó.

## **Lặp lại các yếu tố của trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/) gọi một callback cho mỗi loại yếu tố trình chiếu được yêu cầu. Nó tránh các vòng lặp collection lồng nhau và tiện lợi cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ trình chiếu.

Ví dụ sau sử dụng [ForEach.slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), và [ForEach.portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) để kiểm tra các yếu tố tương ứng:

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

Mặc định, việc duyệt shape và văn bản trên toàn bộ trình chiếu bao gồm các slide bình thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp collection trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết cha‑con là quan trọng.

## **Thu thập các Shape**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một collection chứa tất cả các shape trong một trình chiếu thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

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

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) thay thế khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) có thể loại bỏ các phần tử cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) Loại bỏ các layout slide mà không có slide bình thường nào tham chiếu.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) Loại bỏ các master slide không còn được sử dụng.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) Loại bỏ các ký tự không dùng từ phông chữ nhúng.

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

Xóa các layout không dùng trước các master không dùng để một master trở nên không được tham chiếu sau khi làm sạch layout cũng có thể bị xóa. Lưu trình chiếu đã tối ưu vào tệp mới nếu bạn có thể cần lại các master, layout gốc hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/slides/vi/java/slide-master/) và [Embedded Font](/slides/vi/java/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low-code thay vì toàn bộ mô hình đối tượng?**  
Sử dụng các trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc trình chiếu và không yêu cầu kiểm soát chi tiết các yếu tố riêng lẻ. Sử dụng toàn bộ mô hình đối tượng khi bạn cần chọn các slide cụ thể, kiểm soát mối quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể hợp nhất các trình chiếu có định dạng tệp khác nhau không?**  
Không. [Merger.process](https://reference.aspose.com/slides/vi/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) yêu cầu các trình chiếu đầu vào có cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang một định dạng chung, ví dụ bằng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), sau đó hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và notes không?**  
[ForEach.slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) duyệt các slide trình chiếu bình thường. Các thao tác [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), và [ForEach.portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) trên toàn bộ trình chiếu bao gồm các slide bình thường, master và layout theo mặc định. Sử dụng các overload của chúng với `includeNotes` đặt thành `true` để bao gồm các slide ghi chú.

**Sự khác nhau giữa ForEach.shape và Collect.shapes là gì?**  
Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) để xử lý mỗi shape ngay lập tức qua một callback. Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một kết quả có thể lặp lại, có thể giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress luôn làm giảm kích thước tệp trình chiếu không?**  
Không nhất thiết. Kết quả phụ thuộc vào việc trình chiếu có chứa các layout không dùng, master không dùng, hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có những yếu tố này, các thao tác [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) tương ứng có thể không giảm kích thước tệp.

**Các thay đổi được thực hiện bởi ForEach hoặc Compress có được lưu tự động không?**  
Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các yếu tố trong callback của [ForEach](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/), gọi [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi trình chiếu](/slides/vi/java/convert-presentation/)
- [Hợp nhất các trình chiếu](/slides/vi/java/merge-presentation/)
- [Slide Master](/slides/vi/java/slide-master/)
- [Quản lý Text Box](/slides/vi/java/manage-textbox/)
- [Embedded Font](/slides/vi/java/embedded-font/)