---
title: Trình giữ chỗ Xem trước Đối tượng Khi Thêm OleObjectFrame
linktitle: Trình giữ chỗ Xem trước OLE
type: docs
weight: 10
url: /vi/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- vấn đề xem trước
- trình giữ chỗ xem trước
- theo thiết kế
- đối tượng nhúng
- tệp tin nhúng
- đối tượng đã thay đổi
- xem trước đối tượng
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Vì sao một đối tượng OLE được thêm bằng Aspose.Slides cho Java lại hiển thị trình giữ chỗ EMBEDDED OLE OBJECT cho tới khi hình ảnh xem trước được cập nhật, và làm thế nào để đặt hình ảnh xem trước của bạn."
---
## **Giới thiệu**

Khi sử dụng Aspose.Slides for Java, nếu bạn thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/oleobjectframe/) vào một slide, một thông báo "EMBEDDED OLE OBJECT" sẽ được hiển thị trên slide đầu ra. Thông báo này có mục đích và KHÔNG phải là lỗi.

Để biết thêm thông tin về cách làm việc với các đối tượng OLE, xem [Manage OLE](/slides/vi/java/manage-ole/).

## **Giải thích và Giải pháp**

Aspose.Slides hiển thị thông báo "EMBEDDED OLE OBJECT" để thông báo cho bạn rằng đối tượng OLE đã được thay đổi và hình ảnh xem trước cần được cập nhật.

Ví dụ, nếu bạn thêm một biểu đồ Microsoft Excel dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/oleobjectframe/) vào một slide (để biết chi tiết, xem bài viết "Manage OLE") và sau đó mở bản trình chiếu trong Microsoft PowerPoint, bạn sẽ thấy hình ảnh này trên slide:

![Thông báo đối tượng OLE](OLE_object_message.png)

Nếu bạn muốn kiểm tra và xác nhận rằng đối tượng OLE của bạn đã được thêm vào slide, bạn phải nhấp đúp vào thông báo "EMBEDDED OLE OBJECT", hoặc bạn có thể nhấp chuột phải vào nó và chọn **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint sẽ mở đối tượng OLE được nhúng.

![Dữ liệu đối tượng OLE](OLE_object_data.png)

Slide có thể vẫn giữ thông báo "EMBEDDED OLE OBJECT". Khi bạn nhấp vào đối tượng OLE, hình thu nhỏ của slide sẽ được cập nhật và thông báo "EMBEDDED OLE OBJECT" sẽ được thay thế bằng hình ảnh thực tế của đối tượng OLE.

![Xem trước đối tượng OLE](OLE_object_preview.png)

Bây giờ, bạn có thể muốn lưu bản trình chiếu để đảm bảo hình ảnh cho Đối tượng OLE được cập nhật đúng cách. Khi đó, sau khi lưu bản trình chiếu, khi bạn mở lại bản trình chiếu, bạn sẽ KHÔNG thấy thông báo "EMBEDDED OLE OBJECT".

## **Giải pháp Khác**

Nếu bạn không muốn loại bỏ thông báo "EMBEDDED OLE OBJECT" bằng cách mở bản trình chiếu trong PowerPoint và sau đó lưu lại, bạn có thể thay thế thông báo bằng hình ảnh xem trước mà bạn ưa thích. Các dòng mã sau minh họa quá trình này. Chúng giả định rằng hình dạng đầu tiên trên slide đầu tiên của *embeddedOLE.pptx* là khung đối tượng OLE và *myImage.png* chứa hình ảnh cần hiển thị, và chúng lưu kết quả dưới tên *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Đặt hình ảnh cho phần xem trước của đối tượng OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Slide chứa `OleObjectFrame` sau đó sẽ thay đổi như sau:

![Hình ảnh OLE mới](OLE_object_new_image.png)