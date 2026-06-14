---
title: Cập nhật đối tượng OLE tự động bằng add‑in PowerPoint
type: docs
weight: 10
url: /vi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- đối tượng OLE
- cập nhật OLE
- tự động
- add‑in
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá cách tự động cập nhật biểu đồ và đối tượng OLE trong PowerPoint bằng một add‑in và Aspose.Slides for Java, với mã thực tế và mẹo tối ưu hóa."
---
## **Giới thiệu**

Một trong những câu hỏi thường gặp nhất từ khách hàng sử dụng Aspose.Slides for Java là cách tạo hoặc chỉnh sửa các biểu đồ có thể chỉnh sửa (hoặc các đối tượng OLE khác) để chúng tự động cập nhật khi mở bản trình chiếu. Thật không may, PowerPoint không hỗ trợ macro tự động giống như Excel và Word. Các macro duy nhất có sẵn là `Auto_Open` và `Auto_Close`, và chúng chỉ chạy tự động khi được tích hợp trong một add‑in. Mẹo kỹ thuật ngắn này sẽ chỉ cho bạn cách thực hiện điều đó.

## **Cập nhật đối tượng OLE tự động**

Đầu tiên, có một số add‑in miễn phí cho phép thêm tính năng macro Auto_Open vào PowerPoint, ví dụ như [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) và [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Sau khi cài đặt một trong các add‑in này, chỉ cần thêm macro `Auto_Open()` (hoặc `OnPresentationOpen()` nếu bạn đang sử dụng Event Generator) vào bản trình chiếu mẫu của mình như minh họa bên dưới:

```java
// Duyệt qua từng slide trong bản trình chiếu.
for (var oSlide : ActivePresentation.Slides) {
    // Duyệt qua tất cả các shape trên slide hiện tại.
    for (var oShape : oSlide.Shapes) {
        // Kiểm tra xem shape có phải là đối tượng OLE không.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Đã tìm thấy một đối tượng OLE. Lấy tham chiếu đối tượng và sau đó cập nhật nó.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Bây giờ, thoát khỏi chương trình máy chủ OLE.
            // Điều này giải phóng bộ nhớ và ngăn ngừa bất kỳ vấn đề nào.
            // Ngoài ra, đặt oObject thành Nothing để giải phóng đối tượng.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Bất kỳ thay đổi nào đối với các đối tượng OLE bằng Aspose.Slides for Java sẽ được tự động cập nhật khi PowerPoint mở bản trình chiếu. Nếu bạn có nhiều đối tượng OLE và không muốn cập nhật chúng全部, chỉ cần thêm một thẻ tùy chỉnh vào các shape cần xử lý và kiểm tra thẻ này trong macro.