---
title: Gói Đa Nền Tảng cho .NET 6 và các Phiên bản Sau
linktitle: Gói Đa Nền Tảng
type: docs
weight: 235
url: /vi/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- đa nền tảng
- hỗ trợ .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu khi nào nên sử dụng gói Aspose.Slides.NET6.CrossPlatform: lý do tồn tại, các nền tảng mà nó chạy, và những gì nó cần trên Linux thay vì libgdiplus."
---
## **Giới thiệu**

Aspose.Slides for .NET được xuất bản dưới dạng hai gói NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) vẽ các slide bằng thư viện System.Drawing.Common của Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) vẽ chúng bằng công cụ đồ họa riêng của mình. Bài viết này giải thích vì sao gói thứ hai tồn tại, nó chạy ở đâu, cần gì trên Linux, và cách nó tồn tại cùng với System.Drawing.Common trong một dự án.

## **Tại sao phải có gói riêng**

Bắt đầu từ .NET 6, Microsoft chỉ hỗ trợ System.Drawing.Common **trên Windows**(https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Do đó, trên Linux Aspose.Slides.NET cần bật tùy chọn `System.Drawing.EnableUnixSupport` cộng với thư viện `libgdiplus`, và sẽ thất bại nếu dự án tham chiếu System.Drawing.Common phiên bản 7 trở lên. [System Requirements](/slides/vi/net/system-requirements/) mô tả các điều kiện này.

Aspose.Slides.NET6.CrossPlatform không sử dụng System.Drawing.Common hay `libgdiplus`. Công cụ đồ họa của nó là một thư viện gốc mà gói chứa trong một bản dựng cho mỗi nền tảng được hỗ trợ. Cả hai gói đều cung cấp các namespace và lớp Aspose.Slides giống nhau, vì vậy việc chuyển đổi chỉ thay đổi tham chiếu gói, không ảnh hưởng đến mã của bạn.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Đồ họa | System.Drawing.Common | Công cụ đồ họa gốc được bao gồm trong gói |
| Khung nền mục tiêu | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Yêu cầu Linux | `libgdiplus` và tùy chọn `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Được hỗ trợ | Không được hỗ trợ |

## **Nền tảng được hỗ trợ**

Aspose.Slides.NET6.CrossPlatform hoạt động với .NET 6 và các phiên bản sau trên các nền tảng sau:

- **Windows**: x86 và x64. Thư viện gốc sử dụng runtime Microsoft Visual C++; xem [System Requirements](/slides/vi/net/system-requirements/).
- **Linux**: x64 với glibc 2.23 trở lên, và ARM64 với glibc 2.39 trở lên.
- **macOS**: x64 (Intel) và ARM64 (Apple silicon).

Nó không chạy trên Windows ARM64, trên Alpine Linux hoặc các bản phân phối dựa trên musl thay vì glibc, hoặc trên các bản phân phối có glibc cũ hơn, như CentOS 7. Hãy dùng Aspose.Slides.NET trên những hệ thống đó.

## **Cài đặt trên Linux**

Trên Linux, gói yêu cầu thư viện `fontconfig`, nhưng không cần `libgdiplus`. Trên Debian và Ubuntu, cài đặt `fontconfig` rồi thêm gói vào dự án của bạn:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Trên Debian và Ubuntu, `libfontconfig1` cũng đồng thời cài đặt các phông chữ DejaVu, vì vậy văn bản sẽ được hiển thị mà không cần thêm gói phông chữ nào khác. Nếu không có `fontconfig`, việc tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sẽ thất bại với `TypeInitializationException` mà ngoại lệ bên trong `DllNotFoundException` báo rằng không thể mở `libfontconfig.so.1`. [System Requirements](/slides/vi/net/system-requirements/) bao gồm một chương trình ngắn kiểm tra cấu hình.

## **Đám mây và Máy chủ Container**

Vì không cần `libgdiplus`, Aspose.Slides.NET6.CrossPlatform là gói nên dùng trên các máy chủ Linux mà bạn không thể cài đặt `libgdiplus`. Nó vẫn cần `fontconfig` và các phông chữ, mà các hình ảnh cơ bản tối thiểu có thể không có. Ví dụ, hình ảnh cơ bản AWS Lambda cho .NET 8 không chứa cả hai. Trong một hình ảnh container được xây dựng dựa trên nó, chạy `dnf install -y fontconfig`, lệnh này cũng sẽ cài đặt các phông chữ Noto Sans.

Đối với hướng dẫn trên các nền tảng đám mây cụ thể, xem [Aspose.Slides on Cloud Platforms](/slides/vi/net/slides-on-cloud-platforms/).

## **Sử dụng System.Drawing.Common trong cùng một dự án (CS0433)**

Một dự án sử dụng Aspose.Slides.NET6.CrossPlatform vẫn có thể tham chiếu System.Drawing.Common, trực tiếp hoặc thông qua một gói khác. Phiên bản hiện tại của Aspose.Slides không công bố bất kỳ kiểu công khai nào trong các namespace `System`, vì vậy hai thư viện không xung đột, và bạn có thể nhập cả namespace `Aspose.Slides` và `System.Drawing` trong cùng một tệp.

Nếu trình biên dịch báo lỗi CS0433 vì một kiểu như `Image` hoặc `Graphics` tồn tại trong cả Aspose.Slides và System.Drawing.Common, dự án của bạn đang dùng phiên bản Aspose.Slides cũ. Hãy cập nhật gói lên phiên bản mới nhất. Aspose.Slides trả về các hình ảnh được render dưới dạng đối tượng [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), được mô tả trong [Modern API](/slides/vi/net/modern-api/).

## **Câu hỏi thường gặp**

**Có cần thay đổi mã khi chuyển từ Aspose.Slides.NET sang Aspose.Slides.NET6.CrossPlatform không?**

Không. Cả hai gói đều cung cấp các namespace và lớp Aspose.Slides giống nhau, vì vậy bạn chỉ thay thế tham chiếu gói. Aspose.Slides.NET6.CrossPlatform không cần tùy chọn `System.Drawing.EnableUnixSupport`. Chỉ thêm một trong hai gói vào dự án.

**Tôi có thể dùng Aspose.Slides.NET6.CrossPlatform trong dự án .NET Framework không?**

Không. Gói này chỉ nhắm tới .NET 6 và các phiên bản sau. Đối với .NET Framework 4.6.2 trở lên, hãy dùng Aspose.Slides.NET.