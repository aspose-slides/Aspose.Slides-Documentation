---
title: Cập nhật đối tượng OLE tự động bằng Add-In PowerPoint
type: docs
weight: 10
url: /vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- Đối tượng OLE
- Cập nhật OLE
- Tự động
- Add-In
- PowerPoint
- Bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tự động cập nhật biểu đồ và đối tượng OLE trong PowerPoint bằng một Add-In và Aspose.Slides cho .NET, bao gồm mã thực tế và các mẹo tối ưu hoá."
---
## **Giới thiệu**

Một trong những câu hỏi thường gặp nhất từ khách hàng của Aspose.Slides cho .NET là cách tạo hoặc chỉnh sửa biểu đồ có thể chỉnh sửa (hoặc các đối tượng OLE khác) sao cho chúng tự động cập nhật khi bản trình bày được mở. Thật không may, PowerPoint không hỗ trợ macro tự động giống như Excel và Word. Các macro duy nhất có sẵn là `Auto_Open` và `Auto_Close`, và chúng chỉ chạy tự động từ một add-in. Mẹo kỹ thuật ngắn này sẽ chỉ ra cách thực hiện điều đó.

## **Cập nhật đối tượng OLE tự động**

Đầu tiên, có một số add-in miễn phí cho phép thêm tính năng macro Auto_Open vào PowerPoint, ví dụ như [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) và [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Sau khi cài đặt một trong các add-in này, chỉ cần thêm macro `Auto_Open()` (hoặc `OnPresentationOpen()` nếu bạn đang sử dụng Event Generator) vào bản trình bày mẫu của bạn như bên dưới:

```cs
public void Auto_Open()
{
    // Lặp qua mỗi slide trong bản trình bày.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Lặp qua tất cả các hình trên slide hiện tại.
        foreach (var oShape in oSlide.Shapes)
        {
            // Kiểm tra xem hình có phải là đối tượng OLE không.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Đã tìm thấy đối tượng OLE. Lấy tham chiếu đối tượng và sau đó cập nhật nó.
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
}
```

Mọi thay đổi nào được thực hiện đối với các đối tượng OLE bằng Aspose.Slides cho .NET sẽ tự động được cập nhật khi PowerPoint mở bản trình bày. Nếu bạn có nhiều đối tượng OLE và không muốn cập nhật tất cả, chỉ cần thêm một thẻ tùy chỉnh vào các hình dạng bạn cần xử lý và kiểm tra nó trong macro.