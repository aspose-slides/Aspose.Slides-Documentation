---
title: Quản lý khả năng truy cập bản trình chiếu trên Android
linktitle: Khả năng truy cập bản trình chiếu
type: docs
weight: 30
url: /vi/androidjava/presentation-accessibility/
keywords:
- khả năng truy cập bản trình chiếu
- văn bản thay thế
- tiêu đề văn bản thay thế
- mô tả văn bản thay thế
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Android qua Java giúp tự động hoá việc kiểm tra khả năng truy cập bản trình chiếu trong các tệp PPT, PPTX và ODP—nâng cao trải nghiệm cho trình đọc màn hình và tăng cường tuân thủ."
---
## **Giới thiệu**

Văn bản thay thế giúp người dùng công nghệ hỗ trợ hiểu ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin khác. Bài viết này giải thích cách đọc và cập nhật tiêu đề và mô tả văn bản thay thế bằng Aspose.Slides cho Android qua Java, phân biệt mô tả khả năng truy cập với tên hình dạng được sử dụng trong mã, và kiểm tra xem một hình dạng có được đánh dấu là trang trí hay không.

Các tính năng này hỗ trợ khả năng truy cập cho bản trình chiếu, nhưng không đảm bảo hoàn toàn. Cần xem xét thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu khả năng truy cập khác.

## **Quản lý tiêu đề và mô tả văn bản thay thế**

Sử dụng văn bản thay thế để giải thích ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin cho những người không thể nhìn thấy chúng. Các phương thức và nội dung sau phục vụ các mục đích khác nhau:

| Phương thức hoặc nội dung | Mục đích |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Tiêu đề ngắn cho mô tả thay thế. |
| [getAlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Mô tả có nghĩa về nội dung hoặc mục đích của hình dạng trong ngữ cảnh của slide. |
| [getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getName--) | Tên của hình dạng, mà mã có thể sử dụng để tìm một hình dạng cụ thể trong bản trình chiếu. |
| Visible text | Nội dung hiển thị trên slide, chẳng hạn như văn bản của hình dạng hoặc tiêu đề và nhãn của biểu đồ. Cập nhật văn bản thay thế không thay đổi nội dung này. |

Khi một bản trình chiếu được sử dụng lại làm mẫu, mã có thể tìm một hình dạng bằng tên trả về bởi [getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getName--) . Tên này có mục đích khác với văn bản thay thế, cái mà giải thích nội dung hình ảnh truyền đạt cho người đọc. Tìm kiếm theo tên cho phép tác giả cải thiện hoặc dịch mô tả mà không thay đổi cách mã tìm hình dạng. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy kiểm tra rằng tên khớp với hình dạng mong muốn; xem [Identify and Find Shapes](/slides/vi/androidjava/shape-manipulations/#identify-and-find-shapes).

Ví dụ dưới đây yêu cầu tệp `input.pptx` có một hình ảnh của lối vào văn phòng làm hình dạng đầu tiên trên slide đầu tiên. Hình ảnh không được đánh dấu là trang trí. Ví dụ này đọc và in tiêu đề và mô tả văn bản thay thế hiện tại của nó, cập nhật cả hai giá trị, và lưu bản trình chiếu dưới tên `output.pptx`. Điều chỉnh câu chữ cho phù hợp với hình ảnh thực tế và thông tin mà nó truyền đạt.

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

Việc chỉ thêm văn bản thay thế không đảm bảo khả năng truy cập cho bản trình chiếu hoặc tuân thủ các tiêu chuẩn khả năng truy cập. Hãy xem xét lại mô tả để đảm bảo độ chính xác và liên quan, đồng thời kiểm tra thứ tự đọc, độ tương phản màu, văn bản dễ đọc và các yêu cầu khả năng truy cập khác. Các hình ảnh mang tính thông tin không nên được đánh dấu là trang trí; phần tiếp theo sẽ chỉ cách kiểm tra [isDecorative](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Đánh dấu là trang trí**

Đánh dấu là trang trí gắn cờ cho các hình ảnh chỉ mang tính trang trí để trình đọc màn hình bỏ qua chúng, giảm tiếng ồn và giữ tập trung vào nội dung có ý nghĩa. Áp dụng cho nền, họa tiết và khoảng trống—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền tải thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra và làm sạch khả năng truy cập tự động.

![Mark as Decorative](mark_as_decorative.png)

Mẫu mã dưới đây cho thấy cách xác định một hình dạng có được đánh dấu là trang trí hay không.

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

Sử dụng tiêu đề ngắn để xác định chủ đề và mô tả để giải thích thông tin mà hình ảnh truyền đạt trong ngữ cảnh của slide. Đối với biểu đồ, mô tả xu hướng hoặc so sánh liên quan thay vì chỉ nói "biểu đồ".

**Có nên sử dụng văn bản thay thế để xác định vị trí các hình dạng trong mẫu không?**

Ưu tiên tìm hình dạng bằng tên trả về bởi [getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getName--) và kiểm tra xem nó có phải là hình dạng mong muốn không. Văn bản thay thế có thể được chỉnh sửa hoặc dịch, điều này có thể gây lỗi cho mã tìm kiếm mô tả chính xác; xem [Identify and Find Shapes](/slides/vi/androidjava/shape-manipulations/).

**Khi nào nên đánh dấu một hình dạng là trang trí?**

Sử dụng cờ trang trí cho các hình ảnh không cung cấp thông tin, chẳng hạn như họa tiết trang trí. Hình ảnh và biểu đồ truyền tải ý nghĩa cần có mô tả phù hợp thay vì đánh dấu là trang trí.

**Việc thêm văn bản thay thế có làm cho bản trình chiếu hoàn toàn khả năng truy cập không?**

Không. Văn bản thay thế chỉ giải quyết một phần của khả năng truy cập. Cũng cần xem xét thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu áp dụng khác; việc chỉ thiết lập các thuộc tính này không tạo nên sự tuân thủ.