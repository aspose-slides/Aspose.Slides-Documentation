---
title: Các thao tác trình chiếu low-code trong Java
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/java/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- lặp qua slide
- lặp qua shape
- lặp qua văn bản
- thu thập shape
- nén trình chiếu
- xóa master slide không sử dụng
- xóa layout slide không sử dụng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong Java để chuyển đổi và hợp nhất các trình chiếu, lặp qua nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

Gói [com.aspose.slides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/) cung cấp các lớp trợ giúp tĩnh cho các thao tác thường gặp với bản trình chiếu. Các trợ giúp này gói gọn các quy trình mô hình đối tượng thường dùng thành các phương thức tập trung, giúp bạn chuyển đổi hoặc hợp nhất tệp, xử lý các phần tử của bản trình chiếu, thu thập các hình dạng và loại bỏ nội dung không sử dụng với ít mã hơn.

Các trợ giúp low‑code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bản trình chiếu và quy trình mặc định đáp ứng nhu cầu của bạn. Sử dụng mô hình đối tượng đầy đủ của [Aspose.Slides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất, hoặc mối quan hệ giữa các phần tử của bản trình chiếu.

Bảng dưới đây tóm tắt các trợ giúp có sẵn:

| Tiện ích | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/) | Chuyển đổi bản trình chiếu sang định dạng khác bằng một lời gọi file‑to‑file trực tiếp. |
| [Merger](https://reference.aspose.com/slides/vi/java/com.aspose.slides/merger/) | Kết hợp các tệp bản trình chiếu hoàn chỉnh có cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/) | Thực thi một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) | Loại bỏ các master và layout không sử dụng và giảm dữ liệu phông chữ được nhúng. |

## **Chuyển đổi bản trình chiếu**

Sử dụng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức sẽ mở bản trình chiếu nguồn, xác định định dạng cần thiết từ đường dẫn đầu ra và ghi kết quả.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/) cũng cung cấp các phương thức riêng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc sửa đổi bản trình chiếu trước khi xuất hoặc cấu hình một tùy chọn xuất mà trợ giúp không cung cấp. Xem [Convert Presentation](/java/convert-presentation/) để biết quy trình và tùy chọn theo định dạng.

## **Hợp nhất bản trình chiếu**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) để kết hợp các tệp bản trình chiếu hoàn chỉnh bằng một lời gọi. Các bản trình chiếu đầu vào phải có cùng định dạng tệp.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối vào một kết quả mà không cần chọn hoặc ánh xạ riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, bảo lưu các phần một cách rõ ràng, hoặc điều chỉnh kích thước slide khác nhau. Xem [Merge Presentations](/java/merge-presentation/) cho các kịch bản đó.

## **Duyệt qua các phần tử của bản trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/) gọi một callback cho mỗi loại phần tử bản trình chiếu được yêu cầu. Nó tránh các vòng lặp thu thập lồng nhau và thuận tiện cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bản trình chiếu.

Ví dụ sau sử dụng [ForEach.slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), và [ForEach.portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) để kiểm tra các phần tử tương ứng:

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

Mặc định, việc duyệt shape và văn bản trên toàn bộ bản trình chiếu bao gồm các slide bình thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp thu thập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết quan hệ cha‑con quan trọng.

## **Thu thập Shapes**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một tập hợp tất cả các shape trong bản trình chiếu thay vì một callback cho từng shape. Điều này hữu ích khi cùng một bộ dữ liệu sẽ được lọc, đếm hoặc xử lý nhiều lần.

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

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) nếu mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung bản trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) có thể loại bỏ các phần tử cấu trúc không sử dụng và giảm dữ liệu phông chữ được nhúng:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) loại bỏ các layout slide mà không có slide bình thường nào tham chiếu.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) loại bỏ các master slide không còn được sử dụng.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) loại bỏ các ký tự không dùng trong phông chữ được nhúng.

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

Hãy loại bỏ các layout không dùng trước các master không dùng để một master trở nên không tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bản trình chiếu đã tối ưu vào tệp mới nếu bạn có thể cần lại các master, layout hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/java/slide-master/) và [Embedded Font](/java/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào nên sử dụng API low‑code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low‑code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc bản trình chiếu và không yêu cầu kiểm soát chi tiết từng phần tử. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn slide cụ thể, kiểm soát mối quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các bản trình chiếu có định dạng tệp khác nhau không?**

Không. [Merger.process](https://reference.aspose.com/slides/vi/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) yêu cầu các bản trình chiếu đầu vào có cùng định dạng. Đầu tiên hãy chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), rồi mới hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và ghi chú không?**

[ForEach.slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) duyệt các slide trình chiếu bình thường. Các thao tác [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), và [ForEach.portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) bao gồm slide bình thường, master và layout theo mặc định. Sử dụng các overload với `includeNotes` đặt thành `true` để bao gồm các slide ghi chú.

**Sự khác nhau giữa ForEach.shape và Collect.shapes là gì?**

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) để xử lý mỗi shape ngay lập tức qua callback. Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một kết quả có thể duy trì, lọc, đếm hoặc duyệt lại nhiều lần.

**Compress có luôn làm giảm kích thước tệp bản trình chiếu không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bản trình chiếu có chứa các layout không dùng, master không dùng hoặc phông chữ nhúng với các ký tự không dùng hay không. Nếu không có những yếu tố này, các thao tác [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) có thể không làm giảm kích thước tệp.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) đã tải vào bộ nhớ. Sau khi thay đổi các phần tử trong callback của [ForEach](https://reference.aspose.com/slides/vi/java/com.aspose.slides/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/), hãy gọi [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi kết quả.

## **Bài viết liên quan**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)