---
title: Các thao tác trình chiếu low-code trên Android
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/androidjava/low-code-presentation-operations/
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
- Android
- Java
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trên Android để chuyển đổi và hợp nhất các trình chiếu, duyệt nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

Gói [com.aspose.slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/) cung cấp các lớp trợ giúp tĩnh cho các thao tác trình chiếu phổ biến. Những trợ giúp này gói gọn các luồng công việc mô hình đối tượng thường dùng trong các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các yếu tố trình chiếu, thu thập hình dạng, và loại bỏ nội dung không sử dụng với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bài trình chiếu và quy trình mặc định phù hợp với yêu cầu của bạn. Sử dụng đầy đủ [Aspose.Slides object model](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/) khi bạn cần kiểm soát chi tiết các slide riêng lẻ, master, layout, shape, cài đặt xuất, hoặc mối quan hệ giữa các yếu tố trình chiếu.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Dùng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/) | Chuyển đổi một bài trình chiếu sang định dạng khác bằng cuộc gọi trực tiếp file‑to‑file. |
| [Merger](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/merger/) | Kết hợp các tệp trình chiếu hoàn chỉnh cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/) | Thực thi một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/collect/) | Lấy các shape từ toàn bộ bài trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) | Xóa các master và layout không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một Bài trình chiếu**

Sử dụng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức mở bài trình chiếu nguồn, xác định định dạng yêu cầu từ đường dẫn đầu ra và ghi kết quả.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/) cũng cung cấp các phương thức chuyên dụng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc chỉnh sửa bài trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất không được trợ giúp hiện tại cung cấp. Xem [Convert Presentation](/slides/vi/androidjava/convert-presentation/) để biết quy trình và tùy chọn theo định dạng.

## **Kết hợp các Bài trình chiếu**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) để kết hợp các tệp trình chiếu hoàn chỉnh bằng một lần gọi. Các bài trình chiếu đầu vào phải có cùng định dạng tệp.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được thêm vào một kết quả chung mà không cần chọn hoặc ánh xạ lại từng slide riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, bảo toàn các phần một cách rõ ràng, hoặc điều chỉnh kích thước slide khác nhau. Xem [Merge Presentations](/slides/vi/androidjava/merge-presentation/) cho các kịch bản này.

## **Duyệt qua các Yếu tố Trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/) gọi một callback cho mỗi loại yếu tố trình chiếu được yêu cầu. Nó tránh các vòng lặp collection lồng nhau và tiện lợi cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bài trình chiếu.

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

Mặc định, việc duyệt shape và văn bản trên toàn bộ bài trình chiếu bao gồm các slide thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp collection trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết quan hệ cha‑con là quan trọng.

## **Thu thập Shapes**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một tập hợp tất cả các shape trong một bài trình chiếu thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

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

Thay vào đó, sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén Nội dung Bài trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) có thể loại bỏ các yếu tố cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) xóa các slide layout mà không có slide thường nào tham chiếu.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) xóa các slide master không còn được sử dụng.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) xóa các ký tự không dùng khỏi phông chữ nhúng.

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

Xóa các layout không dùng trước các master không dùng để một master trở nên không được tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bài trình chiếu đã tối ưu vào một tệp mới nếu bạn có thể cần các master, layout gốc hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/slides/vi/androidjava/slide-master/) và [Embedded Font](/slides/vi/androidjava/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low-code khi một thao tác chuẩn áp dụng cho toàn bộ tệp hoặc bài trình chiếu và không yêu cầu kiểm soát chi tiết các yếu tố riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát mối quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể hợp nhất các bài trình chiếu ở các định dạng tệp khác nhau không?**

Không. [Merger.process](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) yêu cầu các bài trình chiếu đầu vào có cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang một định dạng chung, ví dụ bằng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), rồi hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và ghi chú không?**

[ForEach.slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) duyệt các slide trình chiếu thường. Các thao tác [ForEach.shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), và [ForEach.portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) trên toàn bộ bài trình chiếu bao gồm các slide thường, master và layout theo mặc định. Sử dụng các overload của chúng với `includeNotes` đặt thành `true` để bao gồm các slide ghi chú.

**Sự khác nhau giữa ForEach.shape và Collect.shapes là gì?**

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) để xử lý mỗi shape ngay lập tức qua một callback. Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) khi bạn cần một kết quả có thể lặp lại, có thể giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress luôn làm giảm kích thước tệp bài trình chiếu không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bài trình chiếu có chứa các layout không dùng, master không dùng, hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có những yếu tố này, các thao tác [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) tương ứng có thể không giảm kích thước tệp.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các yếu tố trong callback của [ForEach](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/), gọi [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi Bài trình chiếu](/slides/vi/androidjava/convert-presentation/)
- [Kết hợp Bài trình chiếu](/slides/vi/androidjava/merge-presentation/)
- [Slide Master](/slides/vi/androidjava/slide-master/)
- [Quản lý Text Box](/slides/vi/androidjava/manage-textbox/)
- [Embedded Font](/slides/vi/androidjava/embedded-font/)