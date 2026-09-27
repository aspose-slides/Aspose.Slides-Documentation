---
title: Tạo bản trình chiếu trong Java
linktitle: Tạo bản trình chiếu
type: docs
weight: 10
url: /vi/java/create-presentation/
keywords:
- tạo bản trình chiếu
- bản trình chiếu mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "Tạo bản trình chiếu trong Java với Aspose.Slides—tạo file PPT, PPTX và ODP, tận dụng hỗ trợ OpenDocument, và lưu chúng bằng chương trình để đạt được kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bản trình chiếu trong Aspose.Slides, thêm một hình dạng có văn bản vào slide đầu tiên và lưu kết quả dưới dạng file PPTX. Để mở một bản trình chiếu hiện có và lưu nó sang định dạng khác, xem [Open Presentations](/slides/vi/java/open-presentation/) và [Save Presentations](/slides/vi/java/save-presentation/). Một phần FAQ ngắn ở cuối sẽ trả lời các câu hỏi thường gặp về định dạng, mẫu, kích thước slide, đơn vị, sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

Trước khi bắt đầu, thêm Aspose.Slides for Java vào dự án của bạn từ kho Maven của Aspose. Xem [Installation](/slides/vi/java/installation/) để biết cách thiết lập Maven và những yêu cầu bổ sung cho Linux.

## **Tạo một Bản trình chiếu**

Việc tạo một file PowerPoint từ đầu trong Aspose.Slides for Java bắt đầu bằng một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Hàm khởi tạo cung cấp một bản trình chiếu trống với một slide duy nhất, sẵn sàng cho các hình dạng, văn bản, biểu đồ hoặc bất kỳ nội dung nào khác mà ứng dụng của bạn cần. Sau khi bạn chỉnh sửa slide đó, hoặc thêm các slide mới, bạn có thể lưu kết quả dưới dạng PPTX, PPT cũ, hoặc định dạng OpenDocument.

Để tạo một bản trình chiếu và đặt một hình dạng có văn bản lên slide đầu tiên, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Một bản trình chiếu mới đã chứa sẵn một slide trống.
2. Lấy slide đó theo chỉ mục 0 từ bộ sưu tập mà phương thức [getSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlides--) trả về.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) loại `Cloud` bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), và đặt văn bản cho nó bằng [setText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#setText-java.lang.String-).
4. Lưu bản trình chiếu dưới dạng file PPTX bằng phương thức [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

Ví dụ dưới đây là một chương trình hoàn chỉnh. Trong dự án Maven từ [Installation](/slides/vi/java/installation/), lưu nó dưới *src/main/java/HelloSlides.java* và chạy `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Tạo một bản trình chiếu. Nó đã chứa sẵn một slide trống.
        Presentation presentation = new Presentation();
        try {
            // Lấy slide đầu tiên.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Thêm một hình dạng đám mây và đặt văn bản vào trong.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Lưu bản trình chiếu dưới dạng file PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Góc trên‑trái của hình đám mây cách lề trái 20 điểm và cách lề trên 20 điểm của slide, và hình có chiều rộng 200 điểm, chiều cao 80 điểm. Chương trình lưu *new_presentation.pptx* với một slide chứa đám mây và văn bản của nó. Khi không có giấy phép, Aspose.Slides cũng sẽ thêm một dấu bản quyền đánh giá vào mỗi slide được lưu; xem [Licensing](/slides/vi/java/licensing/).

Kết quả:

![The new presentation](new_presentation.png)

## **Câu hỏi thường gặp**

### Tôi có thể lưu bản trình chiếu mới dưới định dạng nào?

Bạn có thể lưu dưới [PPTX, PPT và ODP](/slides/vi/java/save-presentation/), và xuất ra [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/java/convert-powerpoint-to-xps/), [HTML](/slides/vi/java/convert-powerpoint-to-html/), [SVG](/slides/vi/java/render-a-slide-as-an-svg-image/), và [hình ảnh](/slides/vi/java/convert-powerpoint-to-png/), cùng các định dạng khác.

### Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/java/supported-file-formats/).

### Làm sao để kiểm soát kích thước/tỷ lệ khung hình khi tạo bản trình chiếu?

Đặt [kích thước slide](/slides/vi/java/slide-size/) (bao gồm các preset như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được co giãn.

### Đơn vị đo kích thước và tọa độ là gì?

Bằng điểm: 1 inch tương đương 72 đơn vị.

### Làm sao để xử lý các bản trình chiếu rất lớn (có nhiều tệp media) nhằm giảm việc sử dụng bộ nhớ?

Sử dụng [các chiến lược quản lý BLOB](/slides/vi/java/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm, và ưu tiên quy trình làm việc dựa trên tệp thay vì chỉ dùng các luồng trong bộ nhớ.

### Tôi có thể tạo/lưu các bản trình chiếu song song không?

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/java/multithreading/). Hãy chạy các thể hiện riêng biệt, cách ly cho mỗi luồng hoặc quy trình.

### Làm sao để loại bỏ dấu bản quyền dùng thử và các giới hạn?

[Áp dụng giấy phép](/slides/vi/java/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị thay đổi, và thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng tham gia.

### Tôi có thể ký số PPTX mà tôi tạo không?

Có. [Chữ ký số](/slides/vi/java/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bản trình chiếu.

### Các macro (VBA) có được hỗ trợ trong các bản trình chiếu được tạo không?

Có. Bạn có thể [tạo/chỉnh sửa các dự án VBA](/slides/vi/java/presentation-via-vba/) và lưu các tệp có macro như PPTM/PPSM.