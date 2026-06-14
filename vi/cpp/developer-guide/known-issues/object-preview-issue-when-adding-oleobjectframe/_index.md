---
title: Vấn đề Xem trước Đối tượng Khi Thêm OleObjectFrame
linktitle: Vấn đề Đối tượng OLE
type: docs
weight: 10
url: /vi/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- đối tượng nhúng
- tệp nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu lý do tại sao thông báo EMBEDDED OLE OBJECT xuất hiện khi thêm OleObjectFrame trong Aspose.Slides cho C++ và cách khắc phục các vấn đề xem trước trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Giới thiệu**

Khi bạn sử dụng Aspose.Slides cho C++ và thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) vào một slide, một tin nhắn "EMBEDDED OLE OBJECT" sẽ xuất hiện trên slide kết quả. Tin nhắn này là có chủ đích và KHÔNG phải là lỗi.

Để biết thêm thông tin về cách làm việc với các đối tượng OLE, hãy xem [Manage OLE](/slides/vi/cpp/manage-ole/). 

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị tin nhắn "EMBEDDED OLE OBJECT" để thông báo rằng đối tượng OLE đã bị thay đổi và hình ảnh xem trước cần được cập nhật. 

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) vào một slide (để biết chi tiết, xem bài viết "Manage OLE") và sau đó mở bản trình chiếu bằng Microsoft PowerPoint, bạn sẽ thấy hình ảnh sau trên slide:

![Tin nhắn đối tượng OLE](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE đã được thêm vào slide, bạn phải nhấp đúp vào tin nhắn "EMBEDDED OLE OBJECT", hoặc nhấp chuột phải vào nó và chọn **Object > Edit**.

![Đối tượng OLE > Chỉnh sửa](OLE_object_edit.png)

PowerPoint sẽ mở đối tượng OLE được nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ lại tin nhắn "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, hình ảnh xem trước của slide sẽ được cập nhật và tin nhắn "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE. 

![Xem trước đối tượng OLE](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình chiếu để đảm bảo hình ảnh cho Đối tượng OLE được cập nhật đúng cách. Khi lưu bản trình chiếu và mở lại lần nữa, bạn sẽ KHÔNG thấy tin nhắn "EMBEDDED OLE OBJECT". 

## **Các giải pháp khác**

### **Giải pháp 1: Thay thế tin nhắn "Embedded OLE Object" bằng một hình ảnh**

Nếu bạn không muốn loại bỏ tin nhắn "EMBEDDED OLE OBJECT" bằng cách mở bản trình chiếu trong PowerPoint rồi lưu lại, bạn có thể thay thế tin nhắn bằng hình ảnh xem trước mà bạn muốn. Các dòng mã sau minh họa quy trình:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Slide chứa `OleObjectFrame` sẽ thay đổi thành:

![Hình ảnh đối tượng OLE mới](OLE_object_new_image.png)

### **Giải pháp 2: Tạo Add-On cho PowerPoint**

Bạn cũng có thể tạo một add‑on cho Microsoft PowerPoint để cập nhật tất cả các đối tượng OLE khi mở bản trình chiếu trong chương trình.