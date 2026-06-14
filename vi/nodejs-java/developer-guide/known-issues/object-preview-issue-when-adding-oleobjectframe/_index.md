---
title: Vấn đề xem trước đối tượng khi thêm OleObjectFrame
linktitle: Vấn đề đối tượng OLE
type: docs
weight: 10
url: /vi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- đối tượng nhúng
- tập tin nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu vì sao thông báo EMBEDDED OLE OBJECT xuất hiện khi thêm OleObjectFrame trong Aspose.Slides cho Node.js và cách khắc phục các vấn đề xem trước trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Giới thiệu**

Sử dụng Aspose.Slides for Java, khi bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/) vào một slide, một thông báo “EMBEDDED OLE OBJECT” sẽ được hiển thị trên slide kết quả. Thông báo này có chủ đích và KHÔNG phải là lỗi.

Để biết thêm thông tin về làm việc với các đối tượng OLE, xem [Quản lý OLE](/slides/vi/nodejs-java/manage-ole/). 

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo “EMBEDDED OLE OBJECT” để thông báo rằng đối tượng OLE đã được thay đổi và hình ảnh xem trước cần được cập nhật. 

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/) vào một slide (để biết chi tiết, xem bài viết “Quản lý OLE”) và sau đó mở bản trình chiếu trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![OLE object message](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE đã được thêm vào slide, bạn phải nhấp đúp vào thông báo “EMBEDDED OLE OBJECT”, hoặc bạn có thể nhấp chuột phải vào nó và chọn **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint sẽ mở đối tượng OLE nhúng.

![OLE object data](OLE_object_data.png)

Slide có thể giữ lại thông báo “EMBEDDED OLE OBJECT”. Khi bạn nhấp vào đối tượng OLE, bản xem trước của slide sẽ được cập nhật và thông báo “EMBEDDED OLE OBJECT” sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE. 

![OLE object preview](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình chiếu để đảm bảo hình ảnh của OLE Object được cập nhật đúng cách. Khi lưu bản trình chiếu, mở lại lần sau, bạn sẽ KHÔNG thấy thông báo “EMBEDDED OLE OBJECT”. 

## **Các giải pháp khác**

### **Giải pháp 1: Thay thế thông báo “Embedded OLE Object” bằng hình ảnh**

Nếu bạn không muốn loại bỏ thông báo “EMBEDDED OLE OBJECT” bằng cách mở bản trình chiếu trong PowerPoint và sau đó lưu lại, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn ưa thích. Các dòng mã dưới đây minh họa quy trình:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Thêm một hình ảnh vào tài nguyên bản trình chiếu.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Đặt tiêu đề và hình ảnh cho bản xem trước đối tượng OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Slide chứa `OleObjectFrame` sẽ thay đổi như sau:

![New OLE object image](OLE_object_new_image.png)

### **Giải pháp 2: Tạo Add‑On cho PowerPoint**

Bạn cũng có thể tạo một add‑on cho Microsoft PowerPoint để cập nhật tất cả các đối tượng OLE khi mở bản trình chiếu trong chương trình.