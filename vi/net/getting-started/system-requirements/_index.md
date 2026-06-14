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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá yêu cầu hệ thống của Aspose.Slides cho .NET. Đảm bảo hỗ trợ liền mạch PowerPoint và OpenDocument trên Windows, Linux và macOS."
---
## **Giới thiệu**

Aspose.Slides for .NET không cần cài đặt Microsoft PowerPoint vì Aspose.Slides là một công cụ độc lập để tạo, chuyển đổi, bố cục trang và hiển thị tài liệu Microsoft PowerPoint.

## **Hệ điều hành được hỗ trợ**

Aspose.Slides for .NET hỗ trợ mọi hệ điều hành 32‑bit hoặc 64‑bit có .NET hoặc Mono framework được cài đặt, bao gồm (nhưng không giới hạn ở):

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

Aspose.Slides for .NET hỗ trợ .NET và Mono framework:

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
- Hỗ trợ COM Interop (COM, C++, VBScript)

### **Mono Framework**

- Hỗ trợ MONO trên nền tảng MAC và Linux

## **Môi trường phát triển**

Aspose.Slides for .NET có thể được sử dụng để phát triển ứng dụng trong bất kỳ môi trường nào nhắm tới .NET, nhưng các môi trường sau được hỗ trợ chính thức:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Các bản phát hành chính của Aspose.Slides**

Hiện tại có hai bản chính của Aspose.Slides — Aspose.Slides.NET và Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Đây là phiên bản chính của sản phẩm. Nó sử dụng engine đồ họa .NET tiêu chuẩn.
- Trên các nền tảng không phải Windows, bạn có thể cần cài đặt thư viện `libgdiplus` và các phụ thuộc của nó.
- Trước phiên bản Aspose.Slides 25.3, trên các nền tảng không phải Windows, cần sử dụng DLL .NET Standard 2.0 từ gói ZIP Aspose.Slides.
- Bắt đầu từ phiên bản Aspose.Slides 25.3, gói NuGet có thể được sử dụng trực tiếp ngay trên hệ thống không Windows.
- Khi chạy trên hệ thống không Windows, ứng dụng của bạn phải bao gồm dòng sau khi khởi động:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Bắt đầu từ phiên bản 25.3, bạn có thể sử dụng gói này trên các nền tảng hỗ trợ .NET, chẳng hạn Linux aarch64 (ARM64).**

#### **Các gói bổ sung cho Linux Alpine**

Khi chạy Aspose.Slides for .NET trong container Alpine Linux, chỉ cài đặt `libgdiplus` có thể không đủ. Các container Alpine thường không bao gồm phông chữ mặc định. Nếu không có phông chữ, các thao tác render hoặc chuyển đổi có thể thất bại với lỗi tương tự:

```text
System.ArgumentException: Font '?' cannot be found
```
Để sử dụng Aspose.Slides trên Alpine, hãy cài đặt `libgdiplus` cùng với ít nhất một gói phông chữ.

**Tùy chọn 1: Phông chữ DejaVu**

Khuyến nghị cài đặt gói `ttf-dejavu`:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Gói `ttf-dejavu` tự động cài đặt các phụ thuộc liên quan đến phông chữ, chẳng hạn `fontconfig`, `encodings`, `mkfontscale` và `mkfontdir`. Hầu hết các trường hợp không cần gói phông chữ bổ sung.

**Tùy chọn 2: Microsoft Core Fonts**

Nếu bản trình chiếu của bạn sử dụng các phông chữ của Microsoft, chẳng hạn Arial, Times New Roman, Courier New hoặc Verdana, hãy cài đặt Microsoft Core Fonts thay thế:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Chỉ sử dụng tùy chọn này khi các bản trình chiếu yêu cầu các phông chữ Microsoft. Trong hầu hết các kịch bản, cài đặt `ttf-dejavu` đơn giản và đáng tin cậy hơn.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Đây là phiên bản Aspose.Slides sử dụng engine đồ họa đa nền tảng tùy chỉnh do nhóm Aspose.Slides phát triển.  
Trên các nền tảng không phải Windows, có thể cần thư viện `fontconfig`.

**Nền tảng được hỗ trợ**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nền tảng không hỗ trợ**
- *Windows 11 ARM* (ARM64) — *Hiện chưa được xem xét*

{{%  alert  title="Notes"  color="primary"  %}}  
Đối với Linux x64, yêu cầu GLIBC 2.23+; đối với Linux ARM64, yêu cầu GLIBC 2.39+. Các hệ thống như CentOS 7 (GLIBC 2.14) không được hỗ trợ. Nếu bạn cần chạy Aspose.Slides trên CentOS 7 hoặc các hệ thống không tương thích khác (ví dụ Alpine), hãy sử dụng gói tiêu chuẩn: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Có cần cài đặt Microsoft PowerPoint để thực hiện chuyển đổi và render không?**

Không, không cần PowerPoint; Aspose.Slides là một engine độc lập để [tạo](/slides/vi/net/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/net/convert-presentation/) và [render](/slides/vi/net/convert-powerpoint-to-png/) các bản trình chiếu.

**Cần những phông chữ nào để render đúng?**

Các phông chữ được sử dụng trong bản trình chiếu, hoặc các phông chữ thay thế phù hợp, phải có sẵn trong hệ điều hành. Trên Linux và macOS, hãy cài đặt các gói phông chữ phổ biến để đảm bảo việc render đồng nhất.

Đối với container Alpine Linux, cần cài đặt ít nhất một gói phông chữ bổ sung ngoài `libgdiplus`. Thiết lập tối thiểu được khuyến nghị là `libgdiplus` kết hợp với `ttf-dejavu`. Nếu cần các phông chữ Microsoft như Arial, Times New Roman, Courier New hoặc Verdana, hãy sử dụng `msttcorefonts-installer` cùng với `fontconfig`.

**Tại sao một phông chữ tùy chỉnh lại hiển thị dưới dạng fallback hoặc ký tự bị thiếu trên Linux?**

Nếu tệp phông chữ có các mục trong bảng name không nhất quán hoặc bị hỏng, stack khớp phông chữ của Linux (FreeType/fontconfig) có thể chọn một bản ghi không hợp lệ, dẫn đến việc phông chữ không được giải quyết. Sử dụng phiên bản phông chữ có bảng name đã được sửa hoặc cài đặt một phông chữ thay thế đồng nhất sẽ khắc phục vấn đề.