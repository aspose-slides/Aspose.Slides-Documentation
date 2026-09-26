---
title: Cài đặt
type: docs
weight: 70
url: /vi/net/installation/
keywords:
- cài đặt Aspose.Slides
- tải xuống Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Cài đặt Aspose.Slides cho .NET từ NuGet trên Windows, Linux và macOS: chọn một trong hai gói, thêm một gói bằng .NET CLI hoặc Visual Studio, và cài đặt các điều kiện tiên quyết cho Linux."
---
## **Tổng quan**

Bài viết này giải thích cách thêm Aspose.Slides cho .NET vào dự án trên Windows, Linux và macOS. Aspose.Slides được phân phối qua NuGet. Bạn có thể thêm nó bằng .NET CLI trên bất kỳ hệ điều hành nào, hoặc bằng NuGet Package Manager hoặc Package Manager Console trong Visual Studio trên Windows. Bài viết cũng giải thích nên chọn gói NuGet nào và những gì Linux cần thêm.

Trước khi cài đặt, hãy xem xét các hệ điều hành được hỗ trợ, các triển khai .NET và các phụ thuộc bổ sung trong [Yêu cầu hệ thống](/slides/vi/net/system-requirements/).

## **Chọn gói**

Aspose.Slides cho .NET được phát hành dưới dạng hai gói NuGet. Cả hai đều cung cấp các không gian tên và lớp Aspose.Slides giống nhau, vì vậy mã của bạn sẽ không thay đổi khi chuyển đổi giữa chúng; chỉ có tham chiếu gói và yêu cầu nền tảng khác nhau.

| Gói | Dùng cho | Yêu cầu bổ sung |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows và các ứng dụng .NET Framework | Trên Linux và macOS: thư viện `libgdiplus`, và bật tùy chọn `System.Drawing.EnableUnixSupport` khi khởi động ứng dụng |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 trở lên trên Windows, Linux và macOS | Trên Linux: thư viện `fontconfig`, nếu chưa được cài đặt |

Nếu không chắc chắn, hãy sử dụng Aspose.Slides.NET trên Windows và Aspose.Slides.NET6.CrossPlatform trên Linux và macOS. Trên Alpine Linux, và trên các hệ thống Linux có glibc cũ hơn 2.23 (x64) hoặc 2.39 (ARM64), hãy dùng Aspose.Slides.NET thay thế. [Yêu cầu hệ thống](/slides/vi/net/system-requirements/) liệt kê các nền tảng được hỗ trợ của mỗi gói.

## **Cài đặt bằng .NET CLI**

Các bước này hoạt động trên Windows, Linux và macOS với .NET SDK 6 trở lên. Tạo một ứng dụng console:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Sau đó thêm gói cho nền tảng của bạn. Chỉ thêm một trong hai gói vào dự án.

- Trên Windows: `dotnet add package Aspose.Slides.NET`
- Trên Linux và macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (trên Linux, cài đặt trước điều kiện tiên quyết; xem [Linux](#linux))

Để kiểm tra gói hoạt động, thay thế nội dung của *Program.cs* bằng ví dụ đầu tiên trong [Create Presentations](/slides/vi/net/create-presentation/) và chạy `dotnet run`. Nó sẽ lưu *hello.pptx* trong thư mục dự án.

## **Windows**

### **Phương pháp 1: Cài đặt hoặc Cập nhật Aspose.Slides từ NuGet Package Manager**

1. Mở Microsoft Visual Studio.
2. Tạo một ứng dụng console hoặc mở một dự án hiện có.
3. Trong **Solution Explorer**, nhấp chuột phải vào dự án và chọn **Manage NuGet Packages** (hoặc vào **Project** > **Manage NuGet Packages**).
4. Dưới **Browse**, tìm kiếm *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Nhấp vào **Aspose.Slides.NET** rồi nhấn **Install**.
   * Nếu bạn đã cài đặt Aspose.Slides và muốn cập nhật, hãy nhấn **Update** thay thế.

Gói sẽ được tải xuống và tham chiếu trong dự án của bạn.

### **Phương pháp 2: Cài đặt hoặc Cập nhật Aspose.Slides qua Package Manager Console**

Đây là cách tham chiếu gói [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) qua Package Manager Console:

1. Mở Microsoft Visual Studio.
2. Tạo một ứng dụng console hoặc mở một dự án hiện có.
3. Vào **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Opening the Package Manager Console](installation_2.png)
4. Chạy lệnh sau: `Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
Phiên bản mới nhất sẽ được cài đặt trong dự án của bạn.

Thông báo **Installing Aspose.Slides.NET** xuất hiện ở dưới cùng của cửa sổ.
![Installation progress in the Package Manager Console](installation_4.png)

Khi tải xuống hoàn tất, các thông báo xác nhận sẽ xuất hiện. Gói được phân phối theo [Aspose EULA](https://about.aspose.com/legal/eula).
![Installation confirmation messages](installation_5.png)

Aspose.Slides hiện đã được thêm vào dự án và được tham chiếu.
![Aspose.Slides referenced in the project](installation_6.png)

Để cập nhật gói, chạy `Update-Package Aspose.Slides.NET` trong Package Manager Console.

## **Linux**

Sử dụng các bước .NET CLI ở trên. Chọn gói và cài đặt điều kiện tiên quyết bằng trình quản lý gói của bản phân phối của bạn. Trên Debian và Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: cài đặt `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: cài đặt `libgdiplus`, và bật hỗ trợ Unix cho System.Drawing trước khi ứng dụng của bạn sử dụng Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Thêm câu lệnh này vào đầu ứng dụng, trước bất kỳ lời gọi nào đến Aspose.Slides. Trong một *Program.cs* có top-level statements, đặt nó sau các chỉ thị `using`:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Sử dụng gói này trên Alpine Linux, và trên các hệ thống có glibc quá cũ để dùng Aspose.Slides.NET6.CrossPlatform.

Các phông chữ được dùng trong bản trình chiếu của bạn, hoặc các phông chữ thay thế phù hợp, phải được cài đặt trên hệ thống để văn bản hiển thị đúng. [Yêu cầu hệ thống](/slides/vi/net/system-requirements/) mô tả các gói mà Aspose.Slides.NET cần trên Alpine Linux, bao gồm phông chữ.

## **macOS**

Sử dụng các bước .NET CLI ở trên với gói **Aspose.Slides.NET6.CrossPlatform**, hỗ trợ cả máy Mac Intel (x86_64) và Apple silicon (ARM64):

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Có phiên bản miễn phí hoặc giới hạn đánh giá không?**

Có. Nếu không có giấy phép, Aspose.Slides chạy ở chế độ đánh giá: nó sẽ chèn dấu mực đánh giá vào mỗi slide được lưu và cắt ngắn văn bản đọc từ bản trình chiếu. Để loại bỏ các giới hạn này, hãy áp dụng một [giấy phép](/slides/vi/net/licensing/) hợp lệ.