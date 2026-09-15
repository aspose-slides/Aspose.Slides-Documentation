---
title: Vấn đề Xem trước Đối tượng Khi Thêm OleObjectFrame
linktitle: Vấn đề Đối tượng OLE
type: docs
weight: 10
url: /vi/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- đối tượng nhúng
- tệp nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- PowerPoint
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu lý do tại sao EMBEDDED OLE OBJECT xuất hiện khi thêm OleObjectFrame trong Aspose.Slides cho Java và cách khắc phục các vấn đề xem trước trong các bản thuyết trình PPT, PPTX và ODP."
---
## **Giới thiệu**

Khi sử dụng Aspose.Slides cho Java, nếu bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/oleobjectframe/) vào một slide, một thông điệp "EMBEDDED OLE OBJECT" sẽ được hiển thị trên slide đầu ra. Thông điệp này là có ý định và KHÔNG phải là lỗi.

Để biết thêm thông tin về cách làm việc với các đối tượng OLE, xem [Quản lý OLE](/slides/vi/java/manage-ole/).

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông điệp "EMBEDDED OLE OBJECT" để thông báo cho bạn rằng đối tượng OLE đã được thay đổi và ảnh xem trước cần được cập nhật. 

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/oleobjectframe/) vào một slide (để biết thêm chi tiết, xem bài viết "Quản lý OLE") và sau đó mở bản thuyết trình trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![Thông báo đối tượng OLE](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE của bạn đã được thêm vào slide, bạn phải nhấp đúp vào thông điệp "EMBEDDED OLE OBJECT", hoặc bạn có thể nhấp chuột phải vào nó và chọn tùy chọn **Object > Edit**.

![Đối tượng OLE > Chỉnh sửa](OLE_object_edit.png)

PowerPoint sau đó sẽ mở đối tượng OLE nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ lại thông điệp "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, bản xem trước của slide sẽ được cập nhật và thông điệp "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE. 

![Xem trước đối tượng OLE](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản thuyết trình để đảm bảo rằng hình ảnh cho Đối tượng OLE được cập nhật đúng cách. Khi đó, sau khi lưu bản thuyết trình, khi bạn mở lại bản thuyết trình, bạn sẽ NOT see the "EMBEDDED OLE OBJECT" message. 

## **Giải pháp khác**

Nếu bạn không muốn loại bỏ thông điệp "EMBEDDED OLE OBJECT" bằng cách mở bản thuyết trình trong PowerPoint và sau đó lưu lại, bạn có thể thay thế thông điệp bằng ảnh xem trước mà bạn muốn. Các dòng mã sau đây minh họa quy trình:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Thêm hình ảnh vào tài nguyên bản trình bày.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Đặt tiêu đề và hình ảnh cho bản xem trước đối tượng OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Slide chứa `OleObjectFrame` sau đó sẽ thay đổi thành:

![Hình ảnh đối tượng OLE mới](OLE_object_new_image.png)