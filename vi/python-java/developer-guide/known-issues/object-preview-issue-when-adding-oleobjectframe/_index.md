---
title: "Vấn đề Xem Trước Đối Tượng Khi Thêm OleObjectFrame"
linktitle: "Vấn đề Đối Tượng OLE"
type: docs
weight: 10
url: /vi/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- nhúng đối tượng
- nhúng tệp
- đối tượng đã thay đổi
- xem trước đối tượng
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu tại sao thông báo EMBEDDED OLE OBJECT hiện ra khi thêm OleObjectFrame trong Aspose.Slides cho Python thông qua Java và cách khắc phục các vấn đề xem trước trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Giới thiệu**

Khi bạn sử dụng Aspose.Slides cho Python thông qua Java để thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) vào một slide, thông báo "EMBEDDED OLE OBJECT" sẽ được hiển thị trên slide xuất ra. Thông báo này là có chủ đích và không phải là lỗi.

Để biết thêm thông tin về làm việc với các đối tượng OLE, hãy xem [Manage OLE](/slides/vi/python-java/manage-ole/).

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo "EMBEDDED OLE OBJECT" để thông báo rằng đối tượng OLE đã bị thay đổi và hình ảnh xem trước cần được cập nhật.

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) vào một slide (để biết thêm chi tiết, xem bài viết "Manage OLE") và sau đó mở bản trình chiếu trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![Thông báo đối tượng OLE](OLE_object_message.png)

Để xác nhận rằng đối tượng OLE của bạn đã được thêm vào slide, hãy nhấp đúp vào thông báo "EMBEDDED OLE OBJECT", hoặc nhấp chuột phải và chọn **Object > Edit**.

![Đối tượng OLE > Chỉnh sửa](OLE_object_edit.png)

PowerPoint sau đó sẽ mở đối tượng OLE được nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ thông báo "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, hình ảnh xem trước của slide sẽ được cập nhật và thông báo "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE.

![Xem trước đối tượng OLE](OLE_object_preview.png)

Lưu bản trình chiếu của bạn để lưu lại hình ảnh xem trước đối tượng OLE đã được cập nhật. Khi bạn mở lại bản trình chiếu, bạn sẽ không còn thấy thông báo "EMBEDDED OLE OBJECT" nữa.

## **Giải pháp khác**

Nếu bạn không muốn loại bỏ thông báo "EMBEDDED OLE OBJECT" bằng cách mở bản trình chiếu trong PowerPoint và sau đó lưu lại, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn muốn. Đoạn mã sau minh họa quy trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Đặt tiêu đề và hình ảnh cho bản xem trước của đối tượng OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Slide chứa [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) sau đó sẽ thay đổi thành:

![Hình ảnh đối tượng OLE mới](OLE_object_new_image.png)

## **Câu hỏi thường gặp**

**Tại sao lại xuất hiện thông báo "EMBEDDED OLE OBJECT"?**

Thông báo cho biết rằng đối tượng OLE đã bị thay đổi và hình ảnh xem trước của nó cần được cập nhật. Hành vi này là có chủ đích.

**Làm thế nào để cập nhật hình xem trước trong PowerPoint?**

Nhấp đúp vào thông báo hoặc chọn **Object > Edit** để mở đối tượng OLE được nhúng. Nhấp vào đối tượng OLE để cập nhật hình xem trước, sau đó lưu bản trình chiếu.

**Tôi có thể thay thế thông báo mà không mở bản trình chiếu trong PowerPoint không?**

Có. Bạn có thể gán một hình ảnh xem trước mà bạn muốn cho đối tượng OLE, như được minh họa trong ví dụ mã ở trên.