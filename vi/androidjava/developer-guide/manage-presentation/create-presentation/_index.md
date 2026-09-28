---
title: Tạo Bản Trình Bày trên Android
linktitle: Tạo Bản Trình Bày
type: docs
weight: 10
url: /vi/androidjava/create-presentation/
keywords:
- tạo bản trình bày
- bản trình bày mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- trình bày
- Android
- Java
- Aspose.Slides
description: "Tạo các bản trình bày bằng Java với Aspose.Slides cho Android—tạo các tệp PPT, PPTX và ODP, tận hưởng hỗ trợ OpenDocument, và lưu chúng bằng chương trình để đạt được kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bản trình bày trong Aspose.Slides cho Android bằng Java, thêm một hộp văn bản vào slide đầu tiên và lưu kết quả dưới dạng tệp trong bộ nhớ lưu trữ của ứng dụng. Để mở một bản trình bày hiện có hoặc lưu nó ở định dạng khác, xem [Open Presentation](/slides/vi/androidjava/open-presentation/) và [Save Presentation](/slides/vi/androidjava/save-presentation/). Một phần FAQ ngắn ở cuối sẽ giải đáp các câu hỏi thường gặp về định dạng, mẫu, kích thước slide, đơn vị, việc sử dụng bộ nhớ, threading, cấp phép, chữ ký số và hỗ trợ VBA.

Trước khi bắt đầu, thêm Aspose.Slides vào dự án Android của bạn từ kho Maven của Aspose. Xem [Installation](/slides/vi/androidjava/install-aspose-slides-for-android-via-java/).

## **Tạo bản trình bày PowerPoint**

Để tạo một bản trình bày và đặt một hộp văn bản vào slide đầu tiên, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Một bản trình bày mới đã chứa sẵn một slide trống.
2. Lấy slide đó từ [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) bằng chỉ mục 0.
3. Thêm một hình chữ nhật bằng phương thức [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) của [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) và đặt văn bản cho [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) của nó bằng phương thức [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).
4. Lưu bản trình bày dưới dạng tệp PPTX bằng phương thức [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), ở định dạng [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

Mã chạy bên trong một `Activity`, ví dụ trong phương thức `onCreate` của nó. Nó lưu tệp vào thư mục được trả về bởi phương thức [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()): bộ nhớ riêng tư của ứng dụng, nơi có thể ghi mà không cần yêu cầu quyền nào.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Góc trên‑trái của hình chữ nhật cách lề trái 50 point và cách lề trên 50 point của slide, và hình chữ nhật có độ rộng 400 point và chiều cao 100 point. Tệp đã lưu chứa một slide với hình chữ nhật và văn bản của nó. Khi không có giấy phép, Aspose.Slides cũng sẽ thêm dấu nước đánh giá vào mỗi slide được lưu; xem [Licensing](/slides/vi/androidjava/licensing/).

Để xem tệp, mở [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) của Android Studio và tìm *hello.pptx* dưới *data/data/*, trong thư mục *files* của ứng dụng. Trong một ứng dụng thực tế, xử lý các bản trình bày trên một luồng nền để giao diện người dùng luôn phản hồi.

## **FAQ**

### Tôi có thể lưu một bản trình bày mới dưới định dạng nào?

Bạn có thể lưu dưới dạng [PPTX, PPT và ODP](/slides/vi/androidjava/save-presentation/), và xuất sang [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), [SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/) và [hình ảnh](/slides/vi/androidjava/convert-powerpoint-to-png/), trong số các định dạng khác.

### Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu thành PPTX thông thường không?

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/androidjava/supported-file-formats/).

### Làm thế nào để kiểm soát kích thước/tỷ lệ khung hình của slide khi tạo một bản trình bày?

Đặt [slide size](/slides/vi/androidjava/slide-size/) (bao gồm các cài đặt sẵn như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được thu phóng.

### Kích thước và tọa độ được đo bằng đơn vị nào?

Bằng point: 1 inch tương đương 72 đơn vị.

### Làm sao xử lý các bản trình bày rất lớn (có nhiều tệp media) để giảm việc sử dụng bộ nhớ?

Sử dụng [BLOB management strategies](/slides/vi/androidjava/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách khai thác các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp hơn là các luồng chỉ trong bộ nhớ.

### Tôi có thể tạo/lưu các bản trình bày song song không?

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/androidjava/multithreading/). Hãy chạy các thể hiện riêng biệt, độc lập cho mỗi luồng hoặc tiến trình.

### Làm sao loại bỏ dấu nước dùng thử và các giới hạn?

[Apply a license](/slides/vi/androidjava/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị chỉnh sửa, và việc thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng tham gia.

### Tôi có thể ký số PPTX mà tôi tạo không?

Có. [Chữ ký số](/slides/vi/androidjava/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bản trình bày.

### Các macro (VBA) có được hỗ trợ trong các bản trình bày được tạo không?

Có. Bạn có thể [create/edit VBA projects](/slides/vi/androidjava/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.