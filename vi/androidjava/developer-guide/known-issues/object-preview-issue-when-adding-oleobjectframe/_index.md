---
title: Vấn đề Xem Trước Đối Tượng Khi Thêm OleObjectFrame
linktitle: Vấn đề Đối Tượng OLE
type: docs
weight: 10
url: /vi/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- đối tượng nhúng
- tệp nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu tại sao thông báo EMBEDDED OLE OBJECT xuất hiện khi thêm OleObjectFrame trong Aspose.Slides cho Android thông qua Java và cách khắc phục các vấn đề xem trước trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Giới thiệu**

Khi sử dụng Aspose.Slides cho Android thông qua Java, nếu bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/oleobjectframe/) vào một slide, một thông báo "EMBEDDED OLE OBJECT" sẽ được hiển thị trên slide đầu ra. Thông báo này là có chủ đích và KHÔNG phải là lỗi.

Để biết thêm thông tin về cách làm việc với các đối tượng OLE, xem [Quản lý OLE](/slides/vi/androidjava/manage-ole/). 

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo "EMBEDDED OLE OBJECT" để thông báo rằng đối tượng OLE đã được thay đổi và hình ảnh xem trước cần được cập nhật. 

Ví dụ, nếu bạn thêm một đồ thị Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/oleobjectframe/) vào một slide (để biết chi tiết, xem bài viết "Quản lý OLE") và sau đó mở bản trình chiếu trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![Thông báo đối tượng OLE](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE của bạn đã được thêm vào slide, bạn phải nhấp đúp vào thông báo "EMBEDDED OLE OBJECT", hoặc bạn có thể nhấp chuột phải vào nó và chọn **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint sau đó mở đối tượng OLE nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ thông báo "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, bản xem trước của slide sẽ được cập nhật và thông báo "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE. 

![Xem trước đối tượng OLE](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình chiếu để đảm bảo hình ảnh cho Đối tượng OLE được cập nhật đúng cách. Như vậy, sau khi lưu bản trình chiếu, khi bạn mở lại bản trình chiếu, bạn sẽ KHÔNG thấy thông báo "EMBEDDED OLE OBJECT". 

## **Các giải pháp khác**

### **Giải pháp 1: Thay thế thông báo "Embedded OLE Object" bằng một hình ảnh**

Nếu bạn không muốn loại bỏ thông báo "EMBEDDED OLE OBJECT" bằng cách mở bản trình chiếu trong PowerPoint rồi lưu lại, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn ưa thích. Các dòng mã sau minh họa quy trình:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Thêm một hình ảnh vào tài nguyên của bài thuyết trình.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Đặt tiêu đề và hình ảnh cho phần xem trước đối tượng OLE.
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

### **Giải pháp 2: Tạo Add-On cho PowerPoint**

Bạn cũng có thể tạo một tiện ích mở rộng cho Microsoft PowerPoint để cập nhật tất cả các đối tượng OLE khi mở bản trình chiếu trong chương trình.