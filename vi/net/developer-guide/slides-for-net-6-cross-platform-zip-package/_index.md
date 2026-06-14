---
title: Aspose.Slides cho .NET 6 Cross-Platform (Gói ZIP)
type: docs
weight: 237
url: /vi/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- đa nền tảng
- .NET 6
- GLIBC
- csproj
- đường dẫn mục tiêu
- thư viện phụ thuộc
- Aspose.Slides.dll
- System.Drawing.Common
- xung đột tên
- bí danh extern
- CS0433
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho .NET 6 để xây dựng các ứng dụng C# đa nền tảng trên Windows, Linux và macOS, cho phép tạo, chỉnh sửa và chuyển đổi các tệp PowerPoint PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách sử dụng Aspose.Slides cho .NET 6 Cross-Platform từ một gói ZIP. Nó mô tả cách tải gói, giải nén các tệp từ thư mục `net6.0/crossplatform`, thêm tham chiếu đến `Aspose.Slides.dll`, và cấu hình tệp dự án sao cho các thư viện phụ thuộc cần thiết được sao chép tới thư mục đầu ra của ứng dụng.

Bài viết cũng mô tả nội dung của gói cross‑platform, bao gồm assembly .NET chính của Aspose.Slides và các thư viện hệ thống đồ họa đặc thù cho Windows, Linux và macOS.

{{% alert title="Lưu ý" color="primary" %}}

Aspose.Slides cho .NET 6 Cross-Platform cũng có sẵn trên [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Sử dụng Aspose.Slides Cross-Platform từ gói ZIP**

1. Tải xuống gói ZIP của Aspose.Slides mới nhất từ [Release Page](https://releases.aspose.com/slides/vi/net/).

2. Giải nén các tệp từ *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* và đặt chúng vào thư mục sẽ được sử dụng làm phụ thuộc trong dự án của bạn.

3. Thêm tham chiếu đến Aspose.Slides.dll.

   ![thêm-tham-chiếu-dự-án-visual-studio](add-project-reference-visual-studio.png)

   Trong ví dụ của chúng tôi (bên dưới), các thư viện nằm trong thư mục dự án theo đường dẫn này: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![duyệt-ứng-dụng-console](browse-console-app.jpg)

4. Đặt các tệp còn lại (mà Aspose.Slides phụ thuộc) vào thư mục đầu ra bằng cách thêm hướng dẫn vào tệp dự án csproj theo cách này:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Chú ý đến `TargetPath`.

   Mặc định, `<CopyToOutputDirectory>` sao chép các tệp đồng thời giữ nguyên đường dẫn tương đối, nhưng chúng ta cần các thư viện phụ thuộc được đưa vào cùng một thư mục nơi tệp đầu ra được tạo (vị trí của Aspose.Slides.dll).

## **Ghi chú**

### **Hệ thống Đồ họa Sở hữu**

Aspose.Slides cross‑platform là một tập hợp các thư viện:

| Aspose.Slides.dll                                          | Assembly .NET Chính Chịu Trách Nhiệm Tất Cả Logic của Aspose.Slides |
| ---------------------------------------------------------- | ------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Phụ thuộc: triển khai hệ thống đồ họa cho Win x64                    |
| aspose.slides.drawing.capi_vc14x86.dll                     | Phụ thuộc: triển khai hệ thống đồ họa cho Win x64                    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Phụ thuộc: triển khai hệ thống đồ họa cho Linux (x86/x64)           |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Phụ thuộc: triển khai hệ thống đồ họa cho macOS AMD64 (x86-64/x64)  |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Phụ thuộc: triển khai hệ thống đồ họa cho macOS ARM64 (AArch64)     |

Aspose.Slides.dll sử dụng thư viện mà hệ thống đang chạy yêu cầu. Các thư viện thường nằm cùng vị trí với Aspose.Slides.dll trong bất kỳ hệ thống tập tin nào.

### **Cấu trúc Gói ZIP**

Gói ZIP chứa cấu trúc thư mục sau:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Mỗi thư mục chứa các assembly cho phiên bản .NET tương ứng. Có hai phiên bản cho net6.0: default và crossplatform. Phiên bản sau chứa Aspose.Slides.dll đa nền tảng và tất cả các phụ thuộc của nó. Nội dung đã giải nén của thư mục này có thể được sử dụng làm phụ thuộc trong dự án cho phát triển đa nền tảng và các trường hợp sử dụng Aspose.Slides khác.

## **Xem Thêm**

- [Yêu cầu Hệ thống](/slides/vi/net/system-requirements/)