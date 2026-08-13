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
description: "Khám phá yêu cầu hệ thống của Aspose.Slides for .NET. Đảm bảo hỗ trợ liền mạch PowerPoint và OpenDocument trên Windows, Linux và macOS."
---
## **Giới thiệu**

Aspose.Slides for .NET không yêu cầu cài đặt Microsoft PowerPoint vì Aspose.Slides là một engine độc lập để tạo, chuyển đổi, bố cục trang và render tài liệu Microsoft PowerPoint.

## **Hệ điều hành được hỗ trợ**

Aspose.Slides for .NET hỗ trợ mọi hệ điều hành 32‑bit hoặc 64‑bit có .NET hoặc Mono framework được cài đặt, bao gồm (nhưng không giới hạn ở):

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine và các bản phân phối khác)

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

## **Các bản dựng chính của Aspose.Slides**

Hiện tại có hai bản dựng chính của Aspose.Slides — Aspose.Slides.NET và Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Đây là phiên bản chính của sản phẩm. Nó sử dụng engine đồ họa .NET tiêu chuẩn.
- Trên các nền tảng không phải Windows, bạn có thể cần cài đặt thư viện `libgdiplus` và các phụ thuộc của nó.
- Trước phiên bản Aspose.Slides 25.3, trên các nền tảng không phải Windows, cần sử dụng DLL .NET Standard 2.0 từ gói ZIP Aspose.Slides.
- Bắt đầu từ phiên bản Aspose.Slides 25.3, gói NuGet có thể được sử dụng trực tiếp ngay trên các hệ thống không phải Windows.
- Khi chạy trên hệ thống không phải Windows, ứng dụng của bạn phải bao gồm dòng sau khi khởi động:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Bắt đầu từ phiên bản 25.3, bạn có thể dùng gói này trên các nền tảng hỗ trợ .NET, chẳng hạn Linux aarch64 (ARM64).**

#### **Các gói bổ sung cho Linux Alpine**

Khi chạy Aspose.Slides for .NET trong container Alpine Linux, việc chỉ cài đặt `libgdiplus` có thể không đủ. Các container Alpine thường không có font mặc định. Nếu không có font, các thao tác render hoặc chuyển đổi có thể thất bại với lỗi giống như:

```text
System.ArgumentException: Font '?' cannot be found
```
Để sử dụng Aspose.Slides trên Alpine, cần cài đặt `libgdiplus` cùng với ít nhất một gói font.

**Tùy chọn 1: Font DejaVu**

Khuyến nghị là cài đặt gói ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Gói `ttf-dejavu` tự động cài đặt các phụ thuộc liên quan tới font, như `fontconfig`, `encodings`, `mkfontscale` và `mkfontdir`. Hầu hết các trường hợp không cần thêm gói font nào khác.

**Tùy chọn 2: Microsoft Core Fonts**

Nếu bản trình chiếu của bạn sử dụng các font đặc trưng của Microsoft như Arial, Times New Roman, Courier New hoặc Verdana, hãy cài đặt Microsoft Core Fonts thay thế:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Chỉ sử dụng tùy chọn này khi các bản trình chiếu yêu cầu các font của Microsoft. Trong đa số trường hợp, việc cài đặt `ttf-dejavu` đơn giản và đáng tin cậy hơn.

**Yêu cầu bổ sung cho globalization**

Để bật hỗ trợ globalization đúng cách trên Alpine, cài đặt gói `icu-libs` và tắt chế độ invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Đây là phiên bản Aspose.Slides sử dụng engine đồ họa đa nền tảng tùy chỉnh do đội ngũ Aspose.Slides phát triển.  
Trên các nền tảng không phải Windows, có thể cần thư viện `fontconfig`.

**Nền tảng được hỗ trợ**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nền tảng không được hỗ trợ**
- *Windows 11 ARM* (ARM64) — *Hiện không được xem xét*

{{%  alert  title="Ghi chú"  color="info"  %}}  
Đối với Linux x64, yêu cầu GLIBC 2.23+; đối với Linux ARM64, yêu cầu GLIBC 2.39+. Các hệ thống như CentOS 7 (GLIBC 2.14) không được hỗ trợ. Nếu bạn cần chạy Aspose.Slides trên CentOS 7 hoặc các hệ thống không tương thích (ví dụ Alpine), hãy sử dụng gói tiêu chuẩn: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Câu hỏi thường gặp**

### Tôi có phải cài đặt Microsoft PowerPoint để chuyển đổi và render không?

Không, không cần PowerPoint; Aspose.Slides là engine độc lập để [tạo](/slides/vi/net/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/net/convert-presentation/) và [render](/slides/vi/net/convert-powerpoint-to-png/) các bản trình chiếu.

### Cần những font nào để render đúng?

Các font được sử dụng trong bản trình chiếu, hoặc các font thay thế phù hợp, phải có sẵn trong hệ điều hành. Trên Linux và macOS, hãy cài đặt các gói font phổ biến để đảm bảo render nhất quán.

Đối với container Alpine Linux, cần cài đặt ít nhất một gói font bổ sung ngoài `libgdiplus`. Cấu hình tối thiểu được khuyến nghị là `libgdiplus` cùng với `ttf-dejavu`. Nếu cần các font của Microsoft như Arial, Times New Roman, Courier New hoặc Verdana, hãy sử dụng `msttcorefonts-installer` cùng với `fontconfig`.

### Tại sao một font tùy chỉnh lại hiển thị dưới dạng fallback hoặc văn bản bị thiếu trên Linux?

Nếu bảng name-table của file font không nhất quán hoặc bị hỏng, stack font-matching của Linux (FreeType/fontconfig) có thể chọn một bản ghi không hợp lệ, dẫn đến font không được nhận diện. Sử dụng phiên bản font đã được sửa chữa name-table hoặc cài đặt một font thay thế đồng nhất sẽ giải quyết vấn đề.