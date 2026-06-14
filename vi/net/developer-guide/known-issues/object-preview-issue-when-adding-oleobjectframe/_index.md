---
title: Vấn đề Xem trước Đối tượng Khi Thêm OleObjectFrame
linktitle: Vấn đề Đối tượng OLE
type: docs
weight: 10
url: /vi/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- đối tượng nhúng
- tập tin nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- bản trình bày
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu lý do tại sao thông báo EMBEDDED OLE OBJECT xuất hiện khi thêm OleObjectFrame trong Aspose.Slides cho .NET và cách khắc phục các vấn đề xem trước trong các bản trình bày PPT, PPTX và ODP."
---
## **Giới thiệu**

Khi sử dụng Aspose.Slides for .NET, khi bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) vào một slide, thông báo "EMBEDDED OLE OBJECT" sẽ được hiển thị trên slide đầu ra. Thông báo này là có chủ đích và NOT a bug.

Để biết thêm thông tin về làm việc với các đối tượng OLE, xem [Manage OLE](/slides/vi/net/manage-ole/).

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo "EMBEDDED OLE OBJECT" để thông báo cho bạn rằng đối tượng OLE đã bị thay đổi và hình ảnh xem trước cần được cập nhật.

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) vào một slide (để biết chi tiết hơn, xem bài viết "Manage OLE") và sau đó mở bản trình bày trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![Thông báo đối tượng OLE](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE của mình đã được thêm vào slide, bạn phải nhấp đúp vào thông báo "EMBEDDED OLE OBJECT", hoặc bạn có thể nhấp chuột phải vào nó và chọn tùy chọn **Object > Edit**.

![Đối tượng OLE > Chỉnh sửa](OLE_object_edit.png)

PowerPoint sau đó sẽ mở đối tượng OLE nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ lại thông báo "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, bản xem trước của slide sẽ được cập nhật và thông báo "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực của đối tượng OLE.

![Xem trước đối tượng OLE](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình bày để đảm bảo hình ảnh cho đối tượng OLE được cập nhật đúng cách. Như vậy, sau khi lưu bản trình bày, khi bạn mở lại bản trình bày, bạn sẽ NOT see the "EMBEDDED OLE OBJECT" message.

## **Các giải pháp khác**

### **Giải pháp 1: Thay thế thông báo "Embedded OLE Object" bằng một hình ảnh**

Nếu bạn không muốn loại bỏ thông báo "EMBEDDED OLE OBJECT" bằng cách mở bản trình bày trong PowerPoint và sau đó lưu lại, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn ưa thích. Các dòng mã sau trình bày quy trình:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Thêm một hình ảnh vào tài nguyên của bản trình bày.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Đặt tiêu đề và hình ảnh cho phần xem trước đối tượng OLE.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Slide chứa `OleObjectFrame` sau đó sẽ thay đổi thành:

![Hình ảnh đối tượng OLE mới](OLE_object_new_image.png)

### **Giải pháp 2: Tạo một Add-On cho PowerPoint**

Bạn cũng có thể tạo một add-on cho Microsoft PowerPoint để cập nhật tất cả các đối tượng OLE khi bạn mở bản trình bày trong chương trình.