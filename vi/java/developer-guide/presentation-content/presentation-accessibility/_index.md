---
title: Quản lý khả năng truy cập bài thuyết trình trong Java
linktitle: Khả năng truy cập bài thuyết trình
type: docs
weight: 30
url: /vi/java/presentation-accessibility/
keywords:
- khả năng truy cập bài thuyết trình
- văn bản thay thế
- tiêu đề văn bản thay thế
- mô tả văn bản thay thế
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Java giúp tự động kiểm tra khả năng truy cập bài thuyết trình trong các tệp PPT, PPTX và ODP—nâng cao trải nghiệm người dùng trình đọc màn hình và tăng cường tính tuân thủ."
---
## **Giới thiệu**

Văn bản thay thế giúp người dùng công nghệ hỗ trợ hiểu ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin khác. Bài viết này giải thích cách đọc và cập nhật tiêu đề và mô tả văn bản thay thế bằng Aspose.Slides for Java, phân biệt mô tả khả năng truy cập với tên hình được sử dụng trong mã, và kiểm tra xem một hình có được đánh dấu là trang trí hay không.

Các tính năng này hỗ trợ khả năng truy cập cho bản trình bày, nhưng không đảm bảo hoàn toàn. Thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu truy cập khác cũng cần được xem xét.

## **Quản lý Tiêu đề và Mô tả Văn bản Thay thế**

Sử dụng văn bản thay thế để giải thích ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin cho những người không thể nhìn thấy chúng. Các phương thức và nội dung sau phục vụ các mục đích khác nhau:

| Phương thức hoặc nội dung | Mục đích |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Tiêu đề ngắn cho mô tả thay thế. |
| [getAlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getAlternativeText--) | Mô tả có ý nghĩa về nội dung hoặc mục đích của hình trong ngữ cảnh của slide. |
| [getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) | Tên của hình, mà mã có thể dùng để tìm một hình cụ thể trong bài thuyết trình. |
| Văn bản hiển thị | Nội dung hiển thị trên slide, chẳng hạn như văn bản của hình hoặc tiêu đề và nhãn của biểu đồ. Cập nhật văn bản thay thế không thay đổi nội dung này. |

Khi một bài thuyết trình được tái sử dụng làm mẫu, mã có thể tìm một hình bằng tên trả về bởi [getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) trước khi cập nhật nó. Tên này có mục đích khác với văn bản thay thế, vốn giải thích những gì hình ảnh truyền tải cho người xem. Tìm kiếm theo tên cho phép người viết cải thiện hoặc dịch mô tả mà không thay đổi cách mã tìm hình. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy kiểm tra tên khớp với hình mong muốn; xem [Identify and Find Shapes](/slides/vi/java/shape-manipulations/#identify-and-find-shapes).

Ví dụ dưới đây yêu cầu `input.pptx` có một hình ảnh của lối vào văn phòng làm hình đầu tiên trên slide đầu tiên. Hình ảnh không nên được đánh dấu là trang trí. Ví dụ đọc và in tiêu đề và mô tả văn bản thay thế hiện tại, cập nhật cả hai giá trị, và lưu bài thuyết trình thành `output.pptx`. Điều chỉnh nội dung mô tả cho phù hợp với hình ảnh thực tế và thông tin nó truyền tải.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chỉ thêm văn bản thay thế không đảm bảo khả năng truy cập cho bản trình bày hoặc tuân thủ các tiêu chuẩn truy cập. Hãy xem xét độ chính xác và tính liên quan của mô tả, đồng thời kiểm tra thứ tự đọc, độ tương phản màu, văn bản dễ đọc và các yêu cầu truy cập khác. Các hình ảnh thông tin không nên được đánh dấu là trang trí; phần tiếp theo cho thấy cách kiểm tra [isDecorative](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#isDecorative--).

## **Đánh dấu là Trang trí**

Đánh dấu là trang trí gắn cờ cho các hình ảnh chỉ mang tính trang trí để trình đọc màn hình bỏ qua chúng, giảm tiếng ồn và tập trung vào nội dung có ý nghĩa. Áp dụng cho nền, họa tiết, và khoảng trống—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền tải thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra tự động khả năng truy cập và dọn dẹp.

![Mark as Decorative](mark_as_decorative.png)

Mã mẫu dưới đây cho thấy cách xác định một hình có được đánh dấu là trang trí hay không.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi nên đặt gì trong tiêu đề và mô tả văn bản thay thế?**

Sử dụng tiêu đề ngắn để xác định chủ đề và mô tả để giải thích thông tin mà hình ảnh truyền tải trong ngữ cảnh của slide. Đối với biểu đồ, mô tả xu hướng hoặc so sánh liên quan thay vì chỉ nói “biểu đồ”.

**Tôi có nên dùng văn bản thay thế để xác định vị trí các hình trong mẫu không?**

Ưu tiên tìm hình bằng tên trả về bởi [getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) và kiểm tra rằng đó là hình mong muốn. Văn bản thay thế có thể được chỉnh sửa hoặc dịch, có thể làm hỏng mã tìm kiếm mô tả chính xác; xem [Identify and Find Shapes](/slides/vi/java/shape-manipulations/).

**Khi nào một hình nên được đánh dấu là trang trí?**

Sử dụng cờ trang trí cho các hình ảnh không cung cấp thông tin, chẳng hạn như họa tiết trang trí. Hình ảnh và biểu đồ truyền tải ý nghĩa cần có mô tả thích hợp thay vì được đánh dấu là trang trí.

**Việc thêm văn bản thay thế có làm cho bản trình bày hoàn toàn khả năng truy cập không?**

Không. Văn bản thay thế chỉ giải quyết một phần của khả năng truy cập. Cũng cần xem xét thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu áp dụng khác; chỉ thiết lập các thuộc tính này không tạo nên sự tuân thủ.