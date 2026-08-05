---
title: Vấn đề Xem trước Đối tượng Khi Thêm OleObjectFrame
linktitle: Vấn đề Đối tượng OLE
type: docs
weight: 10
url: /vi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
  - OLE
  - vấn đề xem trước
  - đối tượng nhúng
  - tệp nhúng
  - đối tượng đã thay đổi
  - xem trước đối tượng
  - PowerPoint
  - bản trình chiếu
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Tìm hiểu vì sao EMBEDDED OLE OBJECT xuất hiện khi thêm OleObjectFrame trong Aspose.Slides cho Node.js và cách khắc phục các vấn đề xem trước trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Giới thiệu**

Sử dụng Aspose.Slides for Java, khi bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/) vào một slide, một thông báo "EMBEDDED OLE OBJECT" được hiển thị trên slide đầu ra. Thông báo này có ý định và NOT a bug.

Để biết thêm thông tin về làm việc với các đối tượng OLE, xem [Manage OLE](/slides/vi/nodejs-java/manage-ole/).

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo "EMBEDDED OLE OBJECT" để thông báo cho bạn rằng đối tượng OLE đã bị thay đổi và ảnh xem trước cần được cập nhật.

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/) vào một slide (để biết chi tiết hơn, xem bài viết "Manage OLE") và sau đó mở bản trình chiếu trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![Thông báo đối tượng OLE](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE của bạn đã được thêm vào slide, bạn phải nhấp đúp vào thông báo "EMBEDDED OLE OBJECT", hoặc bạn có thể nhấp chuột phải vào nó và chọn tùy chọn **Object > Edit**.

![Đối tượng OLE > Chỉnh sửa](OLE_object_edit.png)

PowerPoint sau đó mở đối tượng OLE được nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ thông báo "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, bản xem trước của slide sẽ được cập nhật và thông báo "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE.

![Xem trước đối tượng OLE](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình chiếu để đảm bảo rằng hình ảnh cho Đối tượng OLE được cập nhật chính xác. Bằng cách này, sau khi lưu bản trình chiếu, khi bạn mở lại bản trình chiếu, bạn sẽ NOT see the "EMBEDDED OLE OBJECT" message.

## **Các giải pháp khác**

### **Giải pháp 1: Thay thế thông báo "Embedded OLE Object" bằng một hình ảnh**

Nếu bạn không muốn loại bỏ thông báo "EMBEDDED OLE OBJECT" bằng cách mở bản trình chiếu trong PowerPoint và sau đó lưu nó, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn muốn. Các dòng code sau minh họa quy trình:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Thêm một hình ảnh vào tài nguyên bản trình chiếu.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Đặt tiêu đề và hình ảnh cho bản xem trước của đối tượng OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Slide chứa `OleObjectFrame` sau đó sẽ thay đổi thành như sau:

![Hình ảnh đối tượng OLE mới](OLE_object_new_image.png)

### **Giải pháp 2: Tạo một Add-On cho PowerPoint**

Bạn cũng có thể tạo một add‑on cho Microsoft PowerPoint để cập nhật tất cả các đối tượng OLE khi bạn mở bản trình chiếu trong chương trình.