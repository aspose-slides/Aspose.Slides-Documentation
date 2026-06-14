---
title: Triển khai dễ dàng và nhẹ
type: docs
weight: 50
url: /vi/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services là một [phần mở rộng hiển thị](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) cho Microsoft SQL Server Reporting Services. 
Aspose.Slides for Reporting Services được cung cấp dưới dạng một file cài đặt MSI duy nhất có thể cài đặt trên các máy tính chạy một trong các môi trường sau: 

- Microsoft SQL Server 2005 Reporting Services (32-bit và 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit và 64-bit)

Ngoài ra, việc triển khai và quản lý Aspose.Slides for Reporting Services một cách thủ công cũng rất đơn giản, vì nó chỉ bao gồm một .NET assembly *Aspose.Slides* *.ReportingServices.dll* , được viết hoàn toàn bằng C#, tuân thủ CLS và chỉ chứa mã quản lý an toàn. 

{{% /alert %}} 

Bộ cài đặt MSI và tệp ZIP tải về bao gồm Aspose.Slides for ReportingServices: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – được biên dịch cho Microsoft SQL Server 2005 và .NET Framework 2.0 (sử dụng cho x86 và x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – được biên dịch cho Microsoft SQL Server 2008 và .NET Framework 2.0 (sử dụng cho x86 và x64)

Khi cài đặt, Aspose.Slides.ReportingServices.dll sẽ được sao chép vào thư mục ReportServer\bin và tệp cấu hình sẽ được cập nhật để Reporting Services nhận biết phần mở rộng hiển thị mới. Các bước này được thực hiện bởi trình cài đặt Aspose.Slides for Reporting Services, nhưng bạn cũng có thể thực hiện chúng theo cách thủ công như được mô tả chi tiết trong tài liệu này. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Hình**: Aspose.Slides.ReportingServices.dll được sao chép vào thư mục **ReportServer\bin**.