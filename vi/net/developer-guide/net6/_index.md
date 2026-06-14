---
title: Hỗ trợ .NET 6
type: docs
weight: 235
url: /vi/net/net6/
keywords:
- hỗ trợ .NET 6
- giải pháp đám mây
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Cấu hình Aspose.Slides cho .NET 6 để tạo, chỉnh sửa và chuyển đổi các bản trình bày PowerPoint PPT, PPTX và ODP trong các ứng dụng C# hiện đại, đa nền tảng."
---
## **Giới thiệu**

Bắt đầu từ [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), đã triển khai hỗ trợ .NET6. Đặc điểm của hỗ trợ này là .NET6 không còn hỗ trợ System.Drawing.Common cho Linux ([thay đổi gây phá vỡ](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) và Slides tự triển khai hệ thống đồ họa này dưới dạng thành phần C++.

Aspose.Slides cho .NET hiện hoạt động mà không phụ thuộc vào GDI/libgdiplus trên:
* Windows
* Linux

Hỗ trợ _MacOS_ đang được triển khai.

## **Sử dụng Slides cho .NET 6 trên AWS và Azure**

.NET6 là phiên bản ưu tiên cho Aspose.Slides được sử dụng trên đám mây (AWS, Azure hoặc các giải pháp đám mây khác).

Trước đây, khi Aspose.Slides được dùng trên máy chủ Linux, cần cài đặt các phụ thuộc bổ sung (libgdiplus) và việc này thường bất tiện hoặc không thực tế (ví dụ, khi sử dụng [AWS Lambda](https://aws.amazon.com/lambda)). Với Slides cho .NET6, những phụ thuộc này không còn cần thiết, do đó việc triển khai trở nên dễ dàng hơn nhiều.

Một yếu tố khác là các vấn đề xảy ra khi Aspose.Slides được sử dụng trên giải pháp đám mây với máy chủ Windows. Ví dụ, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) có giới hạn cho quy trình và gây ra vấn đề trong quá trình xuất PDF (xem [đây](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Việc sử dụng Aspose.Slides cho .NET6 giải quyết vấn đề này.

## **Sử dụng gói System.Drawing.Common và các lớp Slides cho .NET 6 (Lỗi CS0433: Kiểu tồn tại trong cả Slides và System.Drawing.Common)**

Đôi khi, cả System.Drawing và các phụ thuộc của Slides cho .NET6 đều phải được sử dụng trong một dự án (ví dụ, khi dự án .NET6 phụ thuộc vào các gói khác, mà chúng lại phụ thuộc vào System.Drawing). Điều này có thể gây ra các lỗi phức tạp như sau:

* CS0433: Kiểu 'Image' tồn tại trong cả 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' và 'System.Drawing.Common, Version=6.0.0.0
* CS0433: Kiểu 'Graphics' tồn tại trong cả 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' và 'System.Drawing.Common, Version=6.0.0.0

Trong trường hợp này, bạn có thể sử dụng [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) cho Aspose.Slides (phiên bản nhỏ hơn 24.8):
1) Chọn assembly Aspose.Slides từ các phụ thuộc của dự án rồi nhấp **Properties**.
  ![Thuộc tính gói Aspose Slides](package_properties.png)
2) Đặt một bí danh (ví dụ, "Slides").
  ![Bí danh Aspose Slides](set_alias.png)

Bây giờ, các kiểu từ System.Drawing.Common sẽ được sử dụng mặc định. Bí danh assembly bên ngoài cần được chỉ định ở nơi cần các kiểu Aspose.Slides.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Ví dụ đầy đủ:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

Bắt đầu từ phiên bản 24.8, API công cộng đã lỗi thời có phụ thuộc vào System.Drawing đã bị loại bỏ. Đối với ví dụ mã ở trên, bạn có thể lấy hình ảnh slide như sau.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
API mới được mô tả chi tiết hơn trong [Modern API](/slides/vi/net/modern-api/).