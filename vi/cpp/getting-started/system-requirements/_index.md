---
title: Yêu cầu Hệ thống
type: docs
weight: 80
url: /vi/cpp/system-requirements/
keywords:
- yêu cầu hệ thống
- hệ điều hành
- cài đặt
- phụ thuộc
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bản thuyết trình
- C++
- Aspose.Slides
description: "Khám phá yêu cầu hệ thống của Aspose.Slides cho C++. Đảm bảo hỗ trợ liền mạch PowerPoint và OpenDocument trên Windows, Linux và macOS."
---
## **Giới thiệu**

Aspose.Slides không yêu cầu cài đặt Microsoft PowerPoint vì Aspose.Slides là một động cơ độc lập để tạo, chuyển đổi, bố trí trang và hiển thị tài liệu Microsoft PowerPoint.

## **Hệ điều hành được hỗ trợ**
Aspose.Slides for C++ là một thư viện C++ gốc. Aspose.Slides for C++ hỗ trợ các hệ điều hành và nền tảng 64-bit và 32-bit sau:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- Hệ điều hành Ubuntu 16.04 hoặc mới hơn.
- CentOS 8 hoặc mới hơn.
- Fedora 24 hoặc mới hơn.
- Và các bản Linux x86_64 khác với glibc 2.23 hoặc mới hơn.

### **macOS**
- macOS Monterey 12.1 hoặc mới hơn.

## **Môi trường phát triển**
Bạn có thể sử dụng Aspose.Slides for C++ khi phát triển ứng dụng cho Windows, Linux hoặc macOS.

### **Windows**
- Microsoft Visual Studio 2017 hoặc mới hơn.
- CMake 3.18 hoặc mới hơn.

### **Linux**
- Clang 3.9 hoặc mới hơn.
- GCC 6.1 hoặc mới hơn.
- CMake 3.18 hoặc mới hơn.

### **macOS**
- Xcode 13.4 hoặc mới hơn.

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint để thực hiện chuyển đổi và hiển thị không?**

Không, không cần PowerPoint; Aspose.Slides là một động cơ độc lập để [tạo](/slides/vi/cpp/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/cpp/convert-presentation/), và [hiển thị](/slides/vi/cpp/convert-powerpoint-to-png/) các bài thuyết trình.

**Cần những phông chữ nào để hiển thị đúng?**

Thực tế, các phông chữ được sử dụng trong bài thuyết trình hoặc các [phông thay thế](/slides/vi/cpp/font-substitution/) phù hợp phải có sẵn. Để đảm bảo việc hiển thị nhất quán trên Linux/macOS, nên cài đặt các gói phông chữ phổ biến.

**Tại sao một phông chữ tùy chỉnh lại hiển thị dưới dạng phông dự phòng hoặc văn bản bị thiếu trên Linux?**

Nếu tệp phông chữ có các mục trong bảng tên không nhất quán hoặc bị hỏng, ngăn xếp khớp phông chữ trên Linux (FreeType/fontconfig) có thể chọn một mục không hợp lệ, khiến phông chữ không được xác định. Sử dụng phiên bản phông chữ có bảng tên đã được sửa chữa hoặc cài đặt một bản thay thế đồng nhất sẽ giải quyết vấn đề.