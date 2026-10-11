---
title: Thay đổi kích thước và định hướng trang ghi chú trên Android
linktitle: Kích thước trang ghi chú
type: docs
weight: 10
url: /vi/androidjava/notes-size/
keywords:
- kích thước trang ghi chú
- định hướng ghi chú
- ghi chú ngang
- ghi chú dọc
- kích thước handout
- PowerPoint
- bản trình chiếu
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Đọc và thay đổi kích thước trang ghi chú trong Aspose.Slides cho Android bằng Java, chuyển đổi định hướng, xác minh kích thước đã lưu, và xuất ghi chú hoặc handout sang PDF và hình ảnh."
---
## **Tổng quan**

Sử dụng [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getNotesSize--) để truy cập cài đặt trang ghi chú của bản trình chiếu. Nó trả về một đối tượng [INotesSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotessize/) mà phương thức [setSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) thiết lập kích thước trang. Mặc dù đối tượng cài đặt này không thể được thay thế, bạn có thể gán kích thước mới thông qua phương thức này.

Chiều rộng và chiều cao được xác định bằng **points**, với 72 points mỗi inch. Ví dụ, 900 × 600 points tương đương 12.5 × 8⅓ inches. Các cài đặt này áp dụng cho toàn bộ bản trình chiếu, chứ không phải cho ghi chú của một slide riêng lẻ.

| Cài đặt | Mục đích |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Kiểm soát kích thước trang ghi chú và kích thước trang được sử dụng cho việc xuất bản handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Kiểm soát kích thước slide bản trình chiếu thông thường thông qua [ISlideSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidesize/). |

Việc thay đổi một trong hai cài đặt không tự động thay đổi cái còn lại. Thay đổi định hướng trang ghi chú cũng không làm quay các slide thông thường. Xem [Kích Thước Slide](/slides/vi/androidjava/slide-size/) để thay đổi kích thước slide thông thường.

Các ví dụ bên dưới sử dụng một tệp `sample.pptx` hiện có. Đối với các ví dụ xuất, hãy sử dụng một bản trình chiếu có ít nhất một slide chứa ghi chú người thuyết trình. Mỗi ví dụ có thể chạy độc lập.

## **Đọc Kích Thước và Định Hướng Trang Ghi Chú**

Đọc chiều rộng và chiều cao và so sánh chúng để xác định định hướng: trang rộng hơn là landscape, trang cao hơn là portrait, và kích thước bằng nhau mô tả một trang vuông. Ví dụ này in ra kích thước thực tế bằng points, mà không giả định kích thước giấy tiêu chuẩn.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Chuyển Sang Landscape Khi Không Thay Đổi Kích Thước Giấy**

Để chỉ thay đổi định hướng, hoán đổi chiều rộng và chiều cao hiện có. Điều này giữ nguyên độ dài của cả hai cạnh, bao gồm cả kích thước giấy tùy chỉnh. Điều kiện dưới đây ngăn một trang đã ở dạng landscape bị chuyển lại thành portrait và giữ nguyên một trang vuông.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với định hướng portrait, sử dụng cùng một phép gán khi `size.getWidth() > size.getHeight()`. Đừng thay thế kích thước A4 hoặc Letter trừ khi bạn cũng muốn thay đổi kích thước giấy.

## **Đặt và Xác Thực Kích Thước Trang Ghi Chú Tùy Chỉnh**

Gán cả hai kích thước cùng lúc, sau đó dùng [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi bản trình chiếu. Ví dụ này đặt một trang landscape 900 × 600 point, lưu dưới dạng PPTX và mở lại tệp đã lưu để kiểm tra các giá trị đã được lưu. So sánh cho phép sai số 0.01 point đối với các giá trị floating‑point; đây không phải là cam kết về độ chính xác cho mọi định dạng tệp.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Kết quả mong đợi là `900.0 x 600.0 points` và `Size preserved: true`. Kiểm tra một bản trình chiếu mới mở sẽ xác nhận tệp đã lưu, thay vì chỉ kiểm tra các cài đặt trong bộ nhớ.

## **Xuất Ghi Chú và Handout**

Các kích thước trang xác định khu vực khả dụng cho bố cục ghi chú hoặc handout. Chúng không kích hoạt các bố cục này một mình: cần cấu hình các tùy chọn xuất thêm. Việc xuất slide thông thường vẫn sử dụng kích thước slide.

### **Xuất Ghi Chú ra PDF và PNG**

Gán [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) cho [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) để bao gồm ghi chú trong PDF. Ví dụ này cũng vẽ slide đầu tiên có ghi chú ra PNG bằng [Slide.getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) và [RenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/renderingoptions/).

Chế độ [BottomTruncated](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notespositions/) giữ ghi chú trên một trang; những ghi chú không vừa sẽ bị cắt ngắn. PDF sử dụng các trang 900 × 600 point. Với tỷ lệ ảnh 1 × 1 được dùng dưới đây, PNG có kích thước 900 × 600 pixel. Points mô tả hình học trang; pixel mô tả đầu ra raster, kích thước của chúng cũng phụ thuộc vào tỷ lệ render.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Đối với xuất PDF với ghi chú dài, [BottomFull](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notespositions/) cho phép tạo thêm các trang khi cần. Đừng dùng chế độ này với lời gọi tạo ảnh slide đơn ở trên, vì nó không hỗ trợ. Sau khi thay đổi kích thước, kiểm tra đầu ra để xem có ghi chú bị cắt không và vị trí của các đối tượng notes‑master hiện có; việc chỉ thay đổi kích thước trang không nên được coi là bảo đảm mọi nội dung sẽ vừa. Xem [Convert PowerPoint to PDF with Notes](/slides/vi/androidjava/convert-powerpoint-to-pdf-with-notes/) để biết thêm về xuất ghi chú.

### **Xuất Handout ra PDF**

Sử dụng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handoutlayoutingoptions/) để đặt nhiều hình thu nhỏ slide trên một trang. Ví dụ sau đặt một trang 900 × 600 point và dùng [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handouttype/) để sắp xếp tối đa bốn slide trên mỗi trang. Cài đặt ngang kiểm soát thứ tự slide; định hướng trang được lấy từ chiều rộng và chiều cao của nó.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Thay đổi kích thước trang thay đổi khu vực khả dụng cho lưới handout mà không thay đổi kích thước của các slide nguồn. Đối với hình ảnh handout, dùng [Presentation.getImages](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) với bố cục handout, thay vì phương thức tạo ảnh cho slide riêng lẻ. Trong Aspose.Slides, việc render handout ở cấp độ bản trình chiếu sử dụng kích thước trang ghi chú, trong khi lời gọi tạo ảnh slide riêng không tạo ra trang handout. Xem [Handout Mode](/slides/vi/androidjava/convert-powerpoint-in-handout-mode/) để biết các tùy chọn bố cục.

## **Kích Thước Trang trong Trình Xem, Xuất và In**

Giữ riêng biệt kích thước bản trình chiếu được lưu, kích thước trang được xuất và kích thước giấy được in:

- **Trình xem bản trình chiếu:** Trình xem có thể hiển thị hoặc in ghi chú theo quy tắc bố cục riêng của nó. Nếu một ứng dụng khác lưu tệp, hãy mở lại và kiểm tra kích thước lần nữa; quá trình chuyển đổi định dạng của ứng dụng đó có thể chuẩn hoá chúng.
- **Định dạng xuất:** Các ví dụ PDF ghi chú và handout ở trên sử dụng kích thước trang đã cấu hình. Hình ảnh raster dùng kích thước pixel nguyên và tỷ lệ render, vì vậy các giá trị point phân số có thể được làm tròn trong đầu ra ảnh. Xuất slide thông thường không áp dụng kích thước trang ghi chú.
- **Trình điều khiển máy in:** Lựa chọn giấy, tự động xoay và cài đặt vừa trang có thể thay đổi kết quả vật lý mà không thay đổi các kích thước được lưu trong bản trình chiếu hoặc PDF. Đối với một kích thước giấy cụ thể, hãy khớp cài đặt máy in và kiểm tra bản xem trước khi in.

## **Câu Hỏi Thường Gặp**

**Tôi có thể đặt kích thước ghi chú cho chỉ một slide không?**

Kích thước trang ghi chú là cài đặt ở mức bản trình chiếu. Các slide riêng lẻ có thể có nội dung ghi chú khác nhau, nhưng thuộc tính này không cung cấp kích thước trang riêng cho mỗi slide.

**Tại sao việc thay đổi định hướng ghi chú không làm thay đổi các slide của tôi?**

Trang ghi chú và slide thông thường có kích thước độc lập. Hãy sử dụng cài đặt kích thước slide thông thường khi bạn muốn thay đổi kích thước các slide.

**Kết quả đã lưu hoặc đã in của tôi có kích thước khác tại sao?**

Đầu tiên mở lại bản trình chiếu đã lưu và so sánh kích thước ghi chú. Nếu chúng đã thay đổi, kiểm tra xem việc lưu hoặc chuyển đổi tệp trong ứng dụng khác có thay đổi cài đặt trang hay không. Nếu không, kiểm tra bố cục xuất, tỷ lệ ảnh, cài đặt trình xem và lựa chọn giấy của máy in.