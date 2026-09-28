---
title: Placeholder Xem Trước Đối Tượng Khi Thêm OleObjectFrame
linktitle: Placeholder Xem Trước OLE
type: docs
weight: 10
url: /vi/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- trình giữ chỗ xem trước
- theo thiết kế
- đối tượng nhúng
- tệp nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- bản trình chiếu
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Tại sao một đối tượng OLE được thêm bằng Aspose.Slides for .NET lại hiển thị trình giữ chỗ EMBEDDED OLE OBJECT cho đến khi bản xem trước của nó được cập nhật, và cách đặt hình ảnh xem trước của riêng bạn."
---
## **Giới thiệu**

Khi sử dụng Aspose.Slides for .NET, khi bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe/) vào một slide, một thông báo "EMBEDDED OLE OBJECT" sẽ được hiển thị trên slide đầu ra. Thông báo này là có chủ đích và KHÔNG phải là lỗi.

Để biết thêm thông tin về cách làm việc với các đối tượng OLE, xem [Manage OLE](/slides/vi/net/manage-ole/).

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo "EMBEDDED OLE OBJECT" để thông báo rằng đối tượng OLE đã được thay đổi và hình ảnh xem trước cần được cập nhật.

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe/) vào một slide (để biết chi tiết, xem bài viết "Manage OLE") và sau đó mở bản trình chiếu trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![OLE object message](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE của bạn đã được thêm vào slide, bạn phải nhấp đúp vào thông báo "EMBEDDED OLE OBJECT", hoặc có thể nhấp chuột phải vào nó và chọn tùy chọn **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint sẽ mở đối tượng OLE nhúng.

![OLE object data](OLE_object_data.png)

Slide có thể vẫn giữ lại thông báo "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, bản xem trước của slide sẽ được cập nhật và thông báo "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE.

![OLE object preview](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình chiếu để đảm bảo hình ảnh cho Đối tượng OLE được cập nhật đúng cách. Như vậy, sau khi lưu bản trình chiếu, khi mở lại bản trình chiếu, bạn sẽ KHÔNG thấy thông báo "EMBEDDED OLE OBJECT".

## **Các giải pháp khác**

### **Giải pháp 1: Thay thế thông báo "Embedded OLE Object" bằng hình ảnh**

Nếu bạn không muốn loại bỏ thông báo "EMBEDDED OLE OBJECT" bằng cách mở bản trình chiếu trong PowerPoint và sau đó lưu lại, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn muốn. Các dòng mã sau minh họa quá trình này:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Slide chứa `OleObjectFrame` sẽ thay đổi thành như sau:

![New OLE object image](OLE_object_new_image.png)

### **Giải pháp 2: Tạo Add-On cho PowerPoint**

Bạn cũng có thể tạo một add-on cho Microsoft PowerPoint để cập nhật tất cả các đối tượng OLE khi mở bản trình chiếu trong chương trình.