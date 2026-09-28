---
title: Yêu cầu mức độ tin cậy
type: docs
weight: 190
url: /vi/net/declaration/
keywords:
- mức độ tin cậy
- Quyền tin cậy đầy đủ
- tin cậy một phần
- Tin cậy trung bình
- bảo mật truy cập mã
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Mức độ tin cậy của bảo mật truy cập mã mà Aspose.Slides cho .NET yêu cầu: tin cậy đầy đủ trên .NET Framework và không cần cài đặt mức tin cậy trên .NET 6 và các phiên bản sau."
---
## **Tổng quan**

Mức độ tin cậy của Code Access Security (CAS) chỉ tồn tại trong .NET Framework. Bài viết này giải thích ý nghĩa của chúng đối với Aspose.Slides cho .NET: thư viện cần quyền tin cậy đầy đủ trên .NET Framework, và trên .NET 6 và các phiên bản sau không có mức độ tin cậy nào để cấu hình.

## **.NET Framework**

Aspose.Slides yêu cầu quyền tin cậy đầy đủ trên .NET Framework. Nó không chạy dưới quyền tin cậy một phần, chẳng hạn như một ứng dụng ASP.NET được cấu hình cho Medium Trust (`<trust level="Medium" />`): việc tạo đối tượng [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sẽ thất bại với một `SecurityException`.

Microsoft không còn coi Partial Trust của ASP.NET là cách để cô lập các ứng dụng với nhau, và khuyến nghị chạy các ứng dụng trong các pool ứng dụng riêng biệt. Xem [ASP.NET Partial Trust không đảm bảo cô lập ứng dụng](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 và các phiên bản sau**

Code Access Security không khả dụng trên .NET 6 và các phiên bản sau, vì vậy không có mức độ tin cậy nào để cấp. Aspose.Slides chạy với quyền của tài khoản chạy ứng dụng của bạn. Để hạn chế những gì một ứng dụng có thể truy cập, Microsoft khuyến nghị sử dụng ranh giới hệ điều hành, chẳng hạn như tài khoản người dùng, container hoặc máy ảo. Xem [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng Aspose.Slides với nhà cung cấp hosting chạy các ứng dụng ASP.NET ở Medium Trust không?**

Không được trong Medium Trust. Trên .NET Framework, ứng dụng sử dụng Aspose.Slides phải chạy với quyền tin cậy đầy đủ.