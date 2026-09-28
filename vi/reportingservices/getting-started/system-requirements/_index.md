---
title: Yêu cầu Hệ thống
type: docs
weight: 15
url: /vi/reportingservices/system-requirements/
keywords:
- yêu cầu hệ thống
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Kiểm tra các máy chủ báo cáo, phiên bản và .NET Framework mà Aspose.Slides for Reporting Services cần trước khi bạn cài đặt."
---
## **Tổng quan**

Aspose.Slides for Reporting Services chạy bên trong máy chủ báo cáo dưới dạng một phần mở rộng hiển thị. Trang này liệt kê những gì máy chủ báo cáo cần trước khi bạn [cài đặt](/slides/vi/reportingservices/installing-aspose-slides-for-reporting-services/) nó. Microsoft PowerPoint và Microsoft Office không bắt buộc.

## **Máy chủ báo cáo được hỗ trợ**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

Cả máy chủ báo cáo 32-bit và 64-bit đều được hỗ trợ. SQL Server 2005 sử dụng bản dựng riêng của phần mở rộng; tất cả các phiên bản sau và Power BI Report Server đều sử dụng cùng một bản dựng. [Cài đặt thủ công](/slides/vi/reportingservices/install-manually/) cho biết tệp nào cần sao chép.

Nếu phiên bản máy chủ báo cáo của bạn không có trong danh sách này, hãy hỏi trên [diễn đàn hỗ trợ miễn phí](https://forum.aspose.com/c/slides/vi/11) trước khi triển khai.

## **Phiên bản máy chủ báo cáo**

Đối với SQL Server 2016 Reporting Services trở lên và Power BI Report Server, Microsoft hỗ trợ các phần mở rộng hiển thị trong các phiên bản Enterprise, Standard, Developer và Evaluation; các phiên bản Web và Express không hỗ trợ chúng. Xem [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Trình cài đặt MSI bỏ qua các phiên bản Express của SQL Server 2016 và trước đó.

## **.NET Framework**

.NET Framework 3.5 phải được cài đặt trên máy chủ báo cáo. Các assembly của phần mở rộng được xây dựng cho runtime .NET Framework 2.0, và trình cài đặt MSI sẽ dừng lại với thông báo nếu .NET Framework 3.5 thiếu. Trên Windows Server, thêm **.NET Framework 3.5 Features** trong Trình hướng dẫn Thêm vai trò và tính năng; xem [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Quyền**

Cài đặt phần mở rộng thay đổi các tệp trong thư mục máy chủ báo cáo, vì vậy cả hai cách cài đặt đều cần quyền quản trị viên cục bộ. Nếu bạn khởi chạy trình cài đặt MSI mà không có quyền này, nó sẽ đề nghị khởi động lại với quyền quản trị viên.

## **Câu hỏi thường gặp**

**Tôi có cần Microsoft PowerPoint trên máy chủ báo cáo không?**

Không. Phần mở rộng tự tạo các bản trình bày; không cần cài đặt PowerPoint hay Microsoft Office.

**Tôi có thể cài đặt phần mở rộng trên phiên bản Express không?**

Không. Các phiên bản Express không hỗ trợ các phần mở rộng hiển thị. Trình cài đặt MSI ẩn các phiên bản Express của SQL Server 2016 và trước đó; trên các phiên bản sau, không chọn một phiên bản Express.

**Phần mở rộng thêm những định dạng nào vào danh sách xuất?**

PPT, PPS, PPTX, PPSX, ODP và XPS. Xem [Định dạng tệp được hỗ trợ](/slides/vi/reportingservices/supported-file-formats/).