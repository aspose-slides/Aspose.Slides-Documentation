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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách cài đặt nhanh Aspose.Slides cho .NET. Hướng dẫn từng bước, yêu cầu hệ thống và mẫu mã — bắt đầu làm việc với các bài thuyết trình PowerPoint ngay hôm nay!"
---
## **Tổng quan**

Bài viết này giải thích cách cài đặt Aspose.Slides cho .NET trên Windows và macOS. Nội dung tập trung vào việc cài đặt dựa trên NuGet và chỉ ra cách thêm thư viện vào dự án Visual Studio thông qua NuGet Package Manager hoặc Package Manager Console trên Windows. Ngoài ra, bài viết còn mô tả cách cập nhật gói và cài đặt các bản prerelease khi cần.

## **Windows**
NuGet cung cấp con đường dễ nhất để tải xuống và cài đặt các API Aspose cho .NET trên máy tính.

### **Phương pháp 1: Cài đặt hoặc Cập nhật Aspose.Slides từ NuGet Package Manager**

1. Mở Microsoft Visual Studio.  
2. Tạo một ứng dụng console đơn giản hoặc mở một dự án hiện có.  
3. Đi tới **Tools** > **NuGet package manager**.  
4. Trong mục **Browse**, tìm kiếm *Aspose Slides* trong ô văn bản.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Nhấn vào **Aspose.Slides.NET** và sau đó nhấn **Install**.  
   * Nếu bạn muốn cập nhật Aspose.Slides—giả sử bạn đã cài đặt nó—hãy nhấn **Update** thay vì.  

API được chọn sẽ được tải xuống và tham chiếu trong dự án của bạn.

### **Phương pháp 2: Cài đặt hoặc Cập nhật Aspose.Slides qua Package Manager Console**

Đây là cách bạn tham chiếu [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) qua console của trình quản lý gói:

1. Mở Microsoft Visual Studio.  
2. Tạo một ứng dụng console đơn giản hoặc mở một dự án hiện có.  
3. Đi tới **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Chạy lệnh này: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
Phiên bản đầy đủ mới nhất sẽ được cài đặt trong ứng dụng của bạn.  

* Ngoài ra, bạn có thể thêm hậu tố `-prerelease` vào lệnh để chỉ định rằng phiên bản mới nhất (bao gồm cả các bản sửa lỗi) cũng phải được cài đặt.  

Mẹo **Installing Aspose.Slides.NET** xuất hiện ở phía dưới của cửa sổ.  
![todo:image_alt_text](installation_4.png)

Khi quá trình tải xuống hoàn tất, bạn sẽ thấy một số thông báo xác nhận.  

Nếu bạn chưa quen thuộc với [Aspose EULA](https://about.aspose.com/legal/eula), bạn có thể muốn đọc giấy phép được đề cập trong URL.  
![todo:image_alt_text](installation_5.png)

Trong ứng dụng của bạn, bạn sẽ thấy Aspose.Slides đã được thêm và tham chiếu thành công.  
![todo:image_alt_text](installation_6.png)

Trong Package Manager Console, bạn có thể chạy lệnh `Update-Package Aspose.Slides.NET` để kiểm tra cập nhật cho gói Aspose.Slides. Các bản cập nhật (nếu có) sẽ được cài đặt tự động. Bạn cũng có thể sử dụng hậu tố `-prerelease` để cập nhật phiên bản mới nhất.  

#### **Các lưu ý khi chạy trên môi trường máy chủ chia sẻ**
Chúng tôi mạnh mẽ khuyên bạn chạy tất cả các thành phần Aspose .NET với bộ quyền **Full Trust** vì các thành phần Aspose đôi khi cần truy cập cài đặt registry và các tệp nằm ở những vị trí ngoài thư mục ảo—ví dụ, khi các thành phần Aspose phải đọc phông chữ.  

Hơn nữa, các thành phần Aspose.NET dựa trên các lớp hệ thống .NET cốt lõi—và một số lớp đó cũng yêu cầu quyền Full Trust cho các hoạt động trong một số trường hợp.  

Các nhà cung cấp dịch vụ Internet, những người lưu trữ nhiều ứng dụng từ các công ty khác nhau, thường áp dụng mức bảo mật Medium Trust. Trong trường hợp .NET 2.0, mức bảo mật này có thể gây ra các ràng buộc ảnh hưởng đến hoạt động của Aspose.Slides:

- **RegistryPermission** không khả dụng. Điều này có nghĩa là bạn không thể truy cập registry, điều cần thiết để liệt kê các phông chữ đã cài đặt khi render tài liệu.  
- **FileIOPermission** bị hạn chế. Điều này có nghĩa là bạn chỉ có thể truy cập các tệp trong cây thư mục ảo của ứng dụng. Điều này cũng có thể ngăn việc đọc phông chữ trong quá trình xuất.  

Vì những lý do trên, chúng tôi mạnh mẽ khuyên bạn chạy Aspose.Slides với quyền **Full Trust**. Nếu bạn sử dụng **Medium trust**, có thể gặp các bất thường—một số tính năng của thư viện (ví dụ render) có thể không hoạt động khi thực hiện một số tác vụ nhất định.  

## **macOS**

NuGet cung cấp con đường dễ nhất để tải xuống và cài đặt Aspose.Slides cho .NET trên máy Mac.  

**Cài đặt yêu cầu trước**

Không gian tên `System.Drawing` hoạt động khác nhau trên macOS, vì vậy bạn phải cài đặt mono-libgdiplus.  

> Trong .NET 5 và các phiên bản trước, gói NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) hoạt động trên Windows, Linux và macOS. Tuy nhiên, có một số khác biệt về nền tảng. Trên Linux và macOS, chức năng GDI+ được triển khai bởi thư viện [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/). Thư viện này không được cài đặt mặc định trên hầu hết các bản phân phối Linux và không hỗ trợ đầy đủ chức năng GDI+ trên Windows và macOS. Cũng có những nền tảng mà libgdiplus không khả dụng. Để sử dụng các kiểu từ gói System.Drawing.Common trên Linux và macOS, bạn phải cài đặt libgdiplus riêng. Để biết thêm thông tin, xem [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) hoặc [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).  

Để cài đặt mono-libgdiplus riêng trên máy Mac của bạn, xem [bài viết này](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) từ tài liệu .NET.  

### **Cài đặt Aspose.Slides**

1. Mở Visual Studio.  
2. Tạo một ứng dụng console đơn giản hoặc mở một dự án hiện có.  
3. Đi tới **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Nhập *Aspose.Slides* vào ô văn bản.  
5. Nhấn vào **Aspose.Slides for .NET** và sau đó nhấn **Add Package.**  
6. Thêm một đoạn mã đơn giản.  
   * Bạn có thể sao chép mã trên [trang này](/slides/vi/net/create-presentation/).  
7. Chạy ứng dụng.  
8. Mở *folder/bin/Debug/presentation_file_name* của dự án của bạn.  

## **FAQ**

**Có phiên bản miễn phí hoặc giới hạn dùng thử không?**

Có, mặc định Aspose.Slides chạy ở chế độ đánh giá, sẽ hiển thị dấu bản quyền và có thể có các hạn chế khác. Để loại bỏ các hạn chế, bạn cần áp dụng một [giấy phép](/slides/vi/net/licensing/) hợp lệ.