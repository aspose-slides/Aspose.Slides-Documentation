---
title: Vấn đề Xem trước Đối tượng Khi Thêm OleObjectFrame
linktitle: Vấn đề Đối tượng OLE
type: docs
weight: 10
url: /vi/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- đối tượng nhúng
- tệp nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- bản trình chiếu
- PowerPoint
- Python
- Aspose.Slides
description: "Tìm hiểu vì sao thông báo EMBEDDED OLE OBJECT xuất hiện khi thêm OleObjectFrame trong Aspose.Slides cho Python và cách khắc phục các vấn đề xem trước trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Giới thiệu**

Khi sử dụng Aspose.Slides cho Python qua .NET, khi bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/oleobjectframe/) vào một slide, một thông báo “EMBEDDED OLE OBJECT” sẽ hiển thị trên slide đầu ra. Thông báo này có mục đích và KHÔNG phải là lỗi.

Để biết thêm thông tin về làm việc với các đối tượng OLE, xem [Manage OLE](/slides/vi/python-net/manage-ole/). 

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo “EMBEDDED OLE OBJECT” để thông báo cho bạn rằng đối tượng OLE đã bị thay đổi và hình ảnh xem trước cần được cập nhật. 

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/oleobjectframe/) vào một slide (để biết chi tiết hơn, xem bài viết “Manage OLE”) và sau đó mở bản trình chiếu trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![Thông báo đối tượng OLE](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE của bạn đã được thêm vào slide, bạn phải nhấp đúp vào thông báo “EMBEDDED OLE OBJECT”, hoặc bạn có thể nhấp chuột phải vào nó và chọn tùy chọn **Object > Edit**.

![Đối tượng OLE > Chỉnh sửa](OLE_object_edit.png)

PowerPoint sau đó sẽ mở đối tượng OLE được nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ lại thông báo “EMBEDDED OLE OBJECT”. Khi bạn nhấp vào đối tượng OLE, bản xem trước slide sẽ được cập nhật và thông báo “EMBEDDED OLE OBJECT” sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE. 

![Xem trước đối tượng OLE](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình chiếu để đảm bảo hình ảnh cho OLE Object được cập nhật đúng cách. Như vậy, sau khi lưu bản trình chiếu, khi bạn mở lại bản trình chiếu, bạn sẽ KHÔNG thấy thông báo “EMBEDDED OLE OBJECT”. 

## **Các Giải pháp Khác**

### **Giải pháp 1: Thay thế thông báo “Embedded OLE Object” bằng một Hình ảnh**

Nếu bạn không muốn loại bỏ thông báo “EMBEDDED OLE OBJECT” bằng cách mở bản trình chiếu trong PowerPoint và sau đó lưu lại, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn muốn. Các dòng mã sau đây minh họa quá trình:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Đặt tiêu đề và hình ảnh cho phần xem trước đối tượng OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

Slide chứa `OleObjectFrame` sau đó sẽ thay đổi thành này:

![Hình ảnh mới cho đối tượng OLE](OLE_object_new_image.png)

### **Giải pháp 2: Tạo một Add‑On cho PowerPoint**

Bạn cũng có thể tạo một add‑on cho Microsoft PowerPoint để cập nhật tất cả các đối tượng OLE khi bạn mở bản trình chiếu trong chương trình.