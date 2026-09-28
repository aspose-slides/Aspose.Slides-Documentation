---
title: Triển khai dễ dàng và nhẹ
type: docs
weight: 50
url: /vi/reportingservices/easy-and-lightweight-deployment/
description: "Tìm hiểu cách Aspose.Slides for Reporting Services được triển khai: một assembly trong thư mục bin của máy chủ báo cáo, được đăng ký trong cấu hình máy chủ báo cáo."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services là một [tiện ích hiển thị](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) cho Microsoft SQL Server Reporting Services và Power BI Report Server.  
Aspose.Slides for Reporting Services được cung cấp dưới dạng một trình cài đặt MSI duy nhất có thể cài đặt trên các máy tính chạy máy chủ báo cáo được hỗ trợ, 32-bit hoặc 64-bit; xem [Yêu cầu hệ thống](/slides/vi/reportingservices/system-requirements/).

Ngoài ra, việc triển khai và quản lý Aspose.Slides for Reporting Services một cách thủ công cũng rất dễ dàng, vì nó chỉ bao gồm một assembly .NET duy nhất *Aspose.Slides* *.ReportingServices.dll*, được viết hoàn toàn bằng C#, tuân thủ CLS và chỉ chứa mã quản lý an toàn.

{{% /alert %}}

Bản tải xuống ZIP bao gồm hai phiên bản của Aspose.Slides.ReportingServices.dll cho máy chủ báo cáo:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – được xây dựng cho Microsoft SQL Server 2005 và .NET Framework 2.0 (sử dụng cho x86 và x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – được xây dựng cho Microsoft SQL Server 2008 trở lên, Power BI Report Server và .NET Framework 2.0 (sử dụng cho x86 và x64)

Trình cài đặt MSI cài đặt cả hai phiên bản này và chọn phiên bản phù hợp cho mỗi thể hiện của máy chủ báo cáo. [Cài đặt thủ công](/slides/vi/reportingservices/install-manually/) liệt kê mọi tệp trong bản tải xuống ZIP.

Khi cài đặt, Aspose.Slides.ReportingServices.dll được sao chép vào thư mục ReportServer\bin và tệp cấu hình được cập nhật để Reporting Services nhận biết tiện ích hiển thị mới. Các bước này được trình cài đặt Aspose.Slides for Reporting Services thực hiện, nhưng bạn cũng có thể thực hiện chúng một cách thủ công như mô tả sau trong tài liệu này.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Hình**: Aspose.Slides.ReportingServices.dll được sao chép vào thư mục **ReportServer\bin**.