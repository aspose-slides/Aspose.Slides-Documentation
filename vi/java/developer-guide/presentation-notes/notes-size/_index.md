---
title: Thay đổi kích thước và hướng trang ghi chú trong Java
linktitle: Kích thước trang ghi chú
type: docs
weight: 10
url: /vi/java/notes-size/
keywords:
- kích thước trang ghi chú
- hướng ghi chú
- ghi chú ngang
- ghi chú dọc
- kích thước handout
- PowerPoint
- bản trình chiếu
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Đọc và thay đổi kích thước trang ghi chú trong Aspose.Slides cho Java, chuyển hướng, xác minh kích thước đã lưu, và xuất ghi chú hoặc handout thành PDF và hình ảnh."
---
## **Tổng quan**

Sử dụng [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getNotesSize--) để truy cập cài đặt trang ghi chú của bản trình chiếu. Phương thức này trả về một đối tượng [INotesSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/inotessize/) mà phương thức [setSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) đặt kích thước trang. Mặc dù không thể thay thế đối tượng cài đặt này, bạn vẫn có thể chỉ định kích thước mới thông qua phương thức đó.

Chiều rộng và chiều cao được chỉ định bằng **điểm**, với 72 điểm bằng một inch. Ví dụ, 900 × 600 điểm tương đương 12,5 × 8⅓ inch. Các cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho ghi chú của một slide riêng lẻ.

| Thiết lập | Mục đích |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getNotesSize--) | Kiểm soát kích thước trang ghi chú và kích thước trang được sử dụng khi xuất handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlideSize--) | Kiểm soát kích thước slide chuẩn của bản trình chiếu thông qua [ISlideSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidesize/). |

Thay đổi một trong hai thiết lập sẽ không tự động thay đổi thiết lập còn lại. Thay đổi hướng của trang ghi chú cũng không xoay các slide chuẩn. Xem [Slide Size](/slides/vi/java/slide-size/) để thay đổi kích thước slide chuẩn.

Các ví dụ dưới đây sử dụng một tệp `sample.pptx` hiện có. Đối với các ví dụ xuất, hãy sử dụng một bản trình chiếu có ít nhất một slide chứa ghi chú người thuyết trình. Mỗi ví dụ có thể chạy độc lập.

## **Đọc kích thước và hướng của trang ghi chú**

Đọc chiều rộng và chiều cao và so sánh chúng để xác định hướng: trang rộng hơn là ngang, trang cao hơn là dọc, và kích thước bằng nhau là trang vuông. Ví dụ này in ra kích thước thực tế bằng điểm, mà không giả định kích thước giấy tiêu chuẩn.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Chuyển sang ngang mà không thay đổi kích thước giấy**

Để chỉ thay đổi hướng, hoán đổi chiều rộng và chiều cao hiện tại. Điều này giữ nguyên độ dài của cả hai cạnh, kể cả khi sử dụng kích thước giấy tùy chỉnh. Điều kiện dưới đây ngăn một trang đã ở chế độ ngang bị chuyển lại thành dọc và để trang vuông không thay đổi.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với hướng dọc, sử dụng cùng một phép gán khi `size.getWidth() > size.getHeight()`. Không thay thế kích thước A4 hoặc Letter trừ khi bạn cũng muốn thay đổi kích thước giấy.

## **Đặt và xác minh kích thước trang ghi chú tùy chỉnh**

Gán cả hai kích thước đồng thời, sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi bản trình chiếu. Ví dụ này đặt trang ngang 900 × 600 điểm, lưu dưới dạng PPTX và mở lại tệp đã lưu để kiểm tra các giá trị đã được lưu. So sánh cho phép sai số 0,01 điểm cho các giá trị số thực; không đảm bảo độ chính xác cho mọi định dạng tệp.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kết quả mong đợi là `900.0 x 600.0 points` và `Size preserved: true`. Kiểm tra một bản trình chiếu mới mở xác nhận tệp đã lưu, thay vì chỉ kiểm tra các cài đặt trong bộ nhớ.

## **Xuất ghi chú và handout**

Kích thước trang xác định khu vực có sẵn cho bố cục ghi chú hoặc handout. Chúng không tự động kích hoạt các bố cục này: cần cấu hình các tùy chọn xuất thêm. Xuất slide chuẩn vẫn sử dụng kích thước slide.

### **Xuất ghi chú sang PDF và PNG**

Gán [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) cho [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) để bao gồm ghi chú trong PDF. Ví dụ này cũng render slide đầu tiên có ghi chú thành PNG bằng [Slide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) và [RenderingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/renderingoptions/).

Chế độ [BottomTruncated](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notespositions/) giữ ghi chú trên một trang; các ghi chú không vừa sẽ bị cắt bớt. PDF sử dụng trang 900 × 600 điểm. Với tỷ lệ hình ảnh 1 × 1 được sử dụng dưới đây, PNG có kích thước 900 × 600 pixel. Điểm mô tả hình học trang; pixel mô tả kết quả raster, kích thước pixel cũng phụ thuộc vào tỷ lệ render.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Đối với xuất PDF với ghi chú dài, [BottomFull](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notespositions/) cho phép tạo thêm các trang nếu cần. Không sử dụng chế độ này với lời gọi tạo ảnh một slide đơn ở trên, vì nó không hỗ trợ. Sau khi thay đổi kích thước, kiểm tra đầu ra để xem ghi chú có bị cắt và vị trí của các đối tượng notes‑master hiện có; việc chỉ thay đổi kích thước trang không đồng nghĩa với việc mọi nội dung sẽ vừa. Xem [Convert PowerPoint to PDF with Notes](/slides/vi/java/convert-powerpoint-to-pdf-with-notes/) để biết thêm về xuất ghi chú.

### **Xuất handout sang PDF**

Sử dụng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handoutlayoutingoptions/) để đặt nhiều ảnh thu nhỏ slide trên một trang. Ví dụ sau đặt trang 900 × 600 điểm và sử dụng [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handouttype/) để sắp xếp tối đa bốn slide mỗi trang. Cài đặt ngang quy định thứ tự slide; hướng trang được lấy từ chiều rộng và chiều cao.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Thay đổi kích thước trang thay đổi khu vực có sẵn cho lưới handout mà không ảnh hưởng đến kích thước slide nguồn. Đối với ảnh handout, sử dụng [Presentation.getImages](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) cùng với bố cục handout, thay vì phương pháp tạo ảnh từng slide riêng lẻ. Trong Aspose.Slides, việc render handout ở mức bản trình chiếu sử dụng kích thước trang ghi chú, trong khi lời gọi tạo ảnh slide riêng lẻ không tạo ra trang handout. Xem [Handout Mode](/slides/vi/java/convert-powerpoint-in-handout-mode/) để biết các tùy chọn bố cục.

## **Kích thước trang trong trình xem, xuất và in**

Giữ riêng biệt kích thước bản trình chiếu được lưu, kích thước trang xuất và kích thước giấy in:

- **Trình xem bản trình chiếu:** Trình xem có thể hiển thị hoặc in ghi chú theo quy tắc bố cục riêng của nó. Nếu một ứng dụng khác lưu tệp, hãy mở lại và kiểm tra lại kích thước; quá trình chuyển đổi định dạng của ứng dụng đó có thể chuẩn hoá chúng.
- **Định dạng xuất:** Các ví dụ PDF ghi chú và handout ở trên sử dụng kích thước trang đã cấu hình. Ảnh raster sử dụng kích thước pixel nguyên và tỷ lệ render, vì vậy các giá trị điểm thập phân có thể được làm tròn trong đầu ra ảnh. Xuất slide chuẩn không áp dụng kích thước trang ghi chú.
- **Trình điều khiển máy in:** Lựa chọn giấy, xoay tự động và cài đặt vừa trang có thể thay đổi kết quả vật lý mà không thay đổi kích thước được lưu trong bản trình chiếu hoặc PDF. Đối với một kích thước giấy cụ thể, hãy khớp cài đặt máy in và kiểm tra bản xem trước khi in.

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước ghi chú chỉ cho một slide duy nhất không?**

Kích thước trang ghi chú là cài đặt ở mức bản trình chiếu. Các slide riêng lẻ có thể có nội dung ghi chú khác nhau, nhưng thuộc tính này không cung cấp kích thước trang riêng cho từng slide.

**Tại sao việc thay đổi hướng ghi chú không làm thay đổi slide của tôi?**

Trang ghi chú và slide chuẩn có kích thước độc lập. Sử dụng cài đặt kích thước slide chuẩn khi bạn muốn thay đổi kích thước các slide.

**Tại sao kết quả đã lưu hoặc đã in của tôi có kích thước khác?**

Đầu tiên mở lại bản trình chiếu đã lưu và so sánh kích thước ghi chú. Nếu chúng thay đổi, kiểm tra xem việc lưu hoặc chuyển đổi tệp trong ứng dụng khác có thay đổi cài đặt trang không. Nếu không, hãy kiểm tra bố cục xuất, tỷ lệ ảnh, cài đặt trình xem và lựa chọn giấy của máy in.