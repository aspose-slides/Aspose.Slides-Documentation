---
title: Yêu cầu hệ thống
type: docs
weight: 60
url: /vi/net/system-requirements/
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá yêu cầu hệ thống của Aspose.Slides for .NET. Đảm bảo hỗ trợ PowerPoint và OpenDocument liền mạch trên Windows, Linux và macOS."
---
## **Giới thiệu**

Aspose.Slides for .NET không yêu cầu cài đặt Microsoft PowerPoint vì Aspose.Slides là một công cụ độc lập tạo, chuyển đổi, bố trí trang và hiển thị tài liệu Microsoft PowerPoint.

## **Hệ điều hành được hỗ trợ**

Aspose.Slides for .NET hỗ trợ bất kỳ hệ điều hành 32-bit hoặc 64-bit nào có cài đặt .NET hoặc Mono framework, bao gồm (nhưng không giới hạn ở):

### **Windows**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine và các bản khác)

### **Mac**

- Mac OS X

## **Framework được hỗ trợ**

Aspose.Slides for .NET hỗ trợ các framework .NET và Mono:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**

- MONO Support in MAC and Linux platforms

## **Môi trường phát triển**

Aspose.Slides for .NET có thể được sử dụng để phát triển ứng dụng trong bất kỳ môi trường phát triển nào nhắm tới nền tảng .NET, nhưng những môi trường sau được hỗ trợ rõ ràng:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Các bản dựng chính của Aspose.Slides**

Hiện tại, có hai bản dựng chính của Aspose.Slides — Aspose.Slides.NET và Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Đây là phiên bản chính của sản phẩm. Nó sử dụng engine đồ họa .NET tiêu chuẩn.
- Trên các nền tảng không phải Windows, bạn có thể cần cài đặt thư viện `libgdiplus` và các phụ thuộc của nó.
- Trước phiên bản Aspose.Slides 25.3, trên các nền tảng không phải Windows, cần sử dụng DLL .NET Standard 2.0 từ gói ZIP Aspose.Slides.
- Bắt đầu từ phiên bản Aspose.Slides 25.3, gói NuGet có thể được sử dụng trực tiếp ngay cả trên các hệ thống không phải Windows.
- Khi chạy trên các hệ thống không phải Windows, ứng dụng của bạn phải bao gồm dòng sau khi khởi động:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Bắt đầu từ phiên bản 25.3, bạn có thể sử dụng gói này trên các nền tảng hỗ trợ .NET, như Linux aarch64 (ARM64).**

#### **Gói bổ sung cho Linux Alpine**

Khi chạy Aspose.Slides for .NET trong một container Alpine Linux, việc chỉ cài đặt `libgdiplus` có thể không đủ. Các container Alpine thường không bao gồm phông chữ mặc định. Nếu không có phông chữ, các thao tác hiển thị hoặc chuyển đổi có thể thất bại với lỗi tương tự như:

```text
System.ArgumentException: Font '?' cannot be found
```
Để sử dụng Aspose.Slides trên Alpine, hãy cài đặt `libgdiplus` cùng với ít nhất một gói phông chữ.

**Tùy chọn 1: Phông DejaVu**

Khuyến nghị cài đặt gói ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Gói `ttf-dejavu` tự động cài đặt các phụ thuộc liên quan đến phông chữ cần thiết, như `fontconfig`, `encodings`, `mkfontscale` và `mkfontdir`. Không cần gói phông chữ bổ sung cho hầu hết các trường hợp.

**Tùy chọn 2: Microsoft Core Fonts**

Nếu bản trình bày của bạn sử dụng các phông chữ đặc thù của Microsoft, như Arial, Times New Roman, Courier New hoặc Verdana, hãy cài đặt Microsoft Core Fonts thay thế:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Chỉ sử dụng tùy chọn này khi các bản trình bày cần các phông chữ của Microsoft. Đối với hầu hết các tình huống, việc cài đặt `ttf-dejavu` đơn giản và đáng tin cậy hơn.

**Yêu cầu bổ sung cho toàn cục hoá**

Để bật hỗ trợ toàn cục hoá đúng cách trên Alpine, cài đặt gói `icu-libs` và tắt chế độ invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Đây là phiên bản Aspose.Slides sử dụng một engine đồ họa tùy chỉnh đa nền tảng được phát triển bởi nhóm Aspose.Slides.  
Trên các nền tảng không phải Windows, thư viện `fontconfig` có thể được yêu cầu.

**Nền tảng được hỗ trợ**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nền tảng không được hỗ trợ**
- *Windows 11 ARM* (ARM64) — *Chưa được xem xét hiện tại*

{{%  alert  title="Notes"  color="primary"  %}}  
Đối với Linux x64, cần GLIBC 2.23+; đối với Linux ARM64, cần GLIBC 2.39+. Các hệ thống như CentOS 7 (GLIBC 2.14) không được hỗ trợ. Nếu bạn cần chạy Aspose.Slides trên CentOS 7 hoặc các hệ thống không tương thích khác (ví dụ: Alpine), hãy sử dụng gói tiêu chuẩn: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint để chuyển đổi và hiển thị không?**

Không, không cần PowerPoint; Aspose.Slides là một engine độc lập để [tạo](/slides/vi/net/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/net/convert-presentation/), và [hiển thị](/slides/vi/net/convert-powerpoint-to-png/) các bản trình bày.

**Các phông chữ nào cần cho việc hiển thị chính xác?**

Các phông chữ được sử dụng trong bản trình bày, hoặc các phông chữ thay thế phù hợp, phải có sẵn trong hệ điều hành. Trên Linux và macOS, hãy cài đặt các gói phông chữ phổ biến để đảm bảo hiển thị nhất quán.

Đối với các container Alpine Linux, cài đặt ít nhất một gói phông chữ ngoài `libgdiplus`. Cấu hình tối thiểu được khuyến nghị là `libgdiplus` cùng với `ttf-dejavu`. Nếu cần các phông chữ của Microsoft như Arial, Times New Roman, Courier New hoặc Verdana, hãy dùng `msttcorefonts-installer` cùng với `fontconfig`.

**Tại sao một phông chữ tùy chỉnh lại hiển thị như dự phòng hoặc thiếu văn bản trên Linux?**

Nếu tệp phông chữ có các mục bảng tên không nhất quán hoặc bị hỏng, stack khớp phông chữ của Linux (FreeType/fontconfig) có thể chọn một bản ghi không hợp lệ, khiến phông chữ không được nhận diện. Sử dụng phiên bản phông chữ với bảng tên đã được sửa chữa hoặc cài đặt một bản thay thế nhất quán sẽ giải quyết vấn đề.