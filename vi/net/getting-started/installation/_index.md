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
description: "Tìm hiểu cách cài đặt nhanh Aspose.Slides cho .NET. Hướng dẫn từng bước, yêu cầu hệ thống và mẫu mã — bắt đầu làm việc với các bản trình chiếu PowerPoint ngay hôm nay!"
---
## **Tổng quan**

Bài viết này giải thích cách cài đặt Aspose.Slides cho .NET trên Windows, Linux và macOS. Nó tập trung vào việc cài đặt dựa trên NuGet và cho biết cách thêm thư viện qua NuGet Package Manager hoặc Package Manager Console trên Windows, vào dự án .NET trên Linux, và vào dự án Visual Studio trên macOS. Bài viết cũng mô tả cách cập nhật gói và cài đặt các bản phát hành trước khi cần.

Trước khi cài đặt, hãy xem lại các hệ điều hành được hỗ trợ, các triển khai .NET và các phụ thuộc bổ sung trong [Yêu cầu Hệ thống](/slides/vi/net/system-requirements/).

## **Windows**
NuGet cung cấp con đường dễ nhất để tải xuống và cài đặt các API Aspose cho .NET trên PC.

### **Phương pháp 1: Cài đặt hoặc Cập nhật Aspose.Slides từ NuGet Package Manager**

1. Mở Microsoft Visual Studio.  
2. Tạo một ứng dụng console đơn giản hoặc mở dự án hiện có.  
3. Vào **Tools** > **NuGet package manager**.  
4. Trong **Browse**, tìm *Aspose Slides* trong ô nhập.  
{{% image img="installation_1.png" alt="Cài đặt Aspose.Slides từ NuGet Package Manager - 1" %}}
5. Nhấp **Aspose.Slides.NET** rồi nhấp **Install**.  
   * Nếu bạn muốn cập nhật Aspose.Slides—giả sử đã cài đặt rồi—hãy nhấp **Update** thay vì vậy.  

API đã chọn sẽ được tải xuống và tham chiếu trong dự án của bạn.

### **Phương pháp 2: Cài đặt hoặc Cập nhật Aspose.Slides qua Package Manager Console**

Đây là cách bạn tham chiếu [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) qua console quản lý gói:

1. Mở Microsoft Visual Studio.  
2. Tạo một ứng dụng console đơn giản hoặc mở dự án hiện có.  
3. Vào **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Chạy lệnh này: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
Bản phát hành đầy đủ mới nhất sẽ được cài đặt trong ứng dụng của bạn.  

* Ngoài ra, bạn có thể thêm hậu tố `-prerelease` vào lệnh để chỉ định rằng bản phát hành mới nhất (kể cả các bản sửa lỗi) cũng phải được cài đặt.

Mẹo **Installing Aspose.Slides.NET** sẽ xuất hiện ở phía dưới cửa sổ.  
![todo:image_alt_text](installation_4.png)

Khi quá trình tải xuống hoàn tất, bạn sẽ thấy một số thông báo xác nhận.

Nếu bạn chưa quen với [Aspose EULA](https://about.aspose.com/legal/eula), bạn có thể muốn đọc giấy phép được tham chiếu trong URL.  
![todo:image_alt_text](installation_5.png)

Trong ứng dụng của bạn, bạn sẽ thấy Aspose.Slides đã được thêm và tham chiếu thành công.  
![todo:image_alt_text](installation_6.png)

Trong Package Manager Console, bạn có thể chạy lệnh `Update-Package Aspose.Slides.NET` để kiểm tra các bản cập nhật cho gói Aspose.Slides. Các bản cập nhật (nếu có) sẽ được cài đặt tự động. Bạn cũng có thể sử dụng hậu tố `-prerelease` để cập nhật bản phát hành mới nhất.

#### **Lưu ý Khi Chạy trên Môi Trường Máy Chủ Chia Sẻ**
Chúng tôi khuyên bạn nên chạy tất cả các thành phần Aspose .NET với thiết lập quyền **Full Trust** vì các thành phần Aspose đôi khi cần truy cập các cài đặt registry và các tệp nằm ở các vị trí ngoài thư mục ảo—ví dụ, khi các thành phần Aspose phải đọc phông chữ.

Hơn nữa, các thành phần Aspose.NET dựa trên các lớp hệ thống .NET cốt lõi—và một số lớp đó cũng yêu cầu quyền Full Trust cho các thao tác nhất định.

Các nhà cung cấp dịch vụ Internet, những người lưu trữ nhiều ứng dụng của các công ty khác nhau, thường áp dụng mức bảo mật Medium Trust. Trong trường hợp .NET 2.0, mức bảo mật này có thể gây ra các ràng buộc ảnh hưởng đến hoạt động của Aspose.Slides:

- **RegistryPermission** không khả dụng. Điều này có nghĩa là bạn không thể truy cập registry, cần thiết để liệt kê các phông chữ đã cài đặt khi render tài liệu.  
- **FileIOPermission** bị hạn chế. Điều này có nghĩa là bạn chỉ có thể truy cập các tệp trong cây thư mục ảo của ứng dụng. Điều này cũng có thể khiến việc đọc phông chữ trong quá trình xuất bị lỗi.  

Vì những lý do trên, chúng tôi mạnh mẽ khuyến nghị bạn chạy Aspose.Slides với quyền **Full Trust**. Nếu bạn sử dụng **Medium trust**, bạn có thể gặp các bất thường—một số tính năng của thư viện (như render) có thể không hoạt động khi thực hiện một số tác vụ.

## **Linux**

NuGet cung cấp con đường dễ nhất để tải xuống và cài đặt Aspose.Slides cho .NET trên Linux. Thêm gói [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) vào dự án .NET của bạn.

## **macOS**

NuGet cung cấp con đường dễ nhất để tải xuống và cài đặt Aspose.Slides cho .NET trên máy Mac.

### **Cài đặt Aspose.Slides**

1. Mở Visual Studio.  
2. Tạo một ứng dụng console đơn giản hoặc mở dự án hiện có.  
3. Vào **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Gõ *Aspose.Slides* vào ô nhập.  
5. Nhấp **Aspose.Slides for .NET** rồi nhấp **Add Package**.  
6. Thêm một đoạn mã đơn giản.  
   * Bạn có thể sao chép mã trên [trang này](/slides/vi/net/create-presentation/).  
7. Chạy ứng dụng.  
8. Mở *folder/bin/Debug/presentation_file_name* của dự án bạn.

## **FAQ**

**Có phiên bản miễn phí hoặc giới hạn dùng thử không?**

Có, mặc định Aspose.Slides chạy ở chế độ đánh giá, sẽ hiển thị watermark và có thể có các giới hạn khác. Để loại bỏ các hạn chế, bạn cần áp dụng một [giấy phép](/slides/vi/net/licensing/) hợp lệ.