---
title: Cài đặt bằng Trình cài đặt MSI
type: docs
weight: 20
url: /vi/reportingservices/install-with-msi-installer/
keywords:
- Trình cài đặt MSI
- cài đặt
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Cài đặt Aspose.Slides for Reporting Services bằng trình cài đặt MSI của nó: những yêu cầu của trình cài đặt, những thay đổi trên mỗi thể hiện máy chủ báo cáo, và cách kiểm tra kết quả."
---
## **Cài đặt**

Trình cài đặt MSI là cách đơn giản nhất để cài đặt Aspose.Slides for Reporting Services. Nó yêu cầu .NET Framework 3.5 và quyền quản trị trên máy chủ báo cáo; xem [Yêu cầu hệ thống](/slides/vi/reportingservices/system-requirements/).

1. Tải xuống trình cài đặt MSI, *Aspose.Slides for Reporting Services XX.XX*, từ [trang tải xuống](https://releases.aspose.com/slides/reportingservices/) và sao chép nó vào máy chủ báo cáo.
1. Chạy với quyền quản trị. Nếu .NET Framework 3.5 thiếu, trình cài đặt sẽ dừng và hiện thông báo; cài đặt các tính năng .NET Framework 3.5 rồi chạy lại.
1. Chấp nhận thỏa thuận giấy phép.
1. Trên trang **Cài đặt tùy chỉnh**, cây tính năng liệt kê mỗi thể hiện SQL Server Reporting Services và Power BI Report Server mà trình cài đặt phát hiện trên máy. Để giữ nguyên một thể hiện, nhấp vào biểu tượng của nó và chọn **Toàn bộ tính năng sẽ không khả dụng**. Các phiên bản Express không hỗ trợ phần mở rộng render, vì vậy không chọn thể hiện Express. Trình cài đặt ẩn các thể hiện Express của SQL Server 2016 và trước đó.
1. Chọn **Tiếp theo**, sau đó **Cài đặt**.

Tính năng tùy chọn **Rpl Export** không được chọn theo mặc định. Nó thêm một phần mở rộng ẩn để lưu báo cáo ở định dạng RPL, hữu ích khi bạn gửi báo cáo sự cố cho Aspose; xem [Xuất báo cáo sang định dạng RPL](/slides/vi/reportingservices/exporting-reports-to-rpl-format/).

## **Những gì trình cài đặt thay đổi**

Trình cài đặt giữ các tệp của mình trong *Aspose\Aspose.Slides for Reporting Services* dưới thư mục Program Files — *Program Files (x86)* trên Windows 64-bit, vì trình cài đặt là gói 32-bit. Sau đó, đối với mỗi thể hiện đã chọn, nó:

- sao chép *Aspose.Slides.ReportingServices.dll* vào thư mục *ReportServer\bin* của thể hiện — bản dựng cho SQL Server 2005, hoặc bản dựng cho SQL Server 2008 trở lên và Power BI Report Server;
- thêm sáu phần mở rộng render — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS và ASODP — vào phần tử `<Render>` của *rsreportserver.config*;
- thêm một nhóm mã cấp quyền tin cậy đầy đủ cho assembly vào *rssrvpolicy.config*;
- lưu bản sao của mỗi tệp cấu hình đã thay đổi, với phần *.bak* được nối vào tên tệp.

[Cài đặt thủ công](/slides/vi/reportingservices/install-manually/) hiển thị các thay đổi này từng bước.

Nếu một thể hiện không thể được cấu hình, trình cài đặt sẽ ghi tên nó trong một thông báo và ghi chi tiết vào *rserrors<date>.log* trong thư mục cài đặt. Hãy cài đặt phần mở rộng trên thể hiện đó một cách thủ công.

## **Kiểm tra cài đặt**

Mở báo cáo phân trang trong cổng web (Report Manager trên SQL Server 2014 và các phiên bản trước) và mở danh sách **Export**. Giờ đây nó bao gồm các định dạng sau:

- PPT - PowerPoint Presentation via Aspose.Slides
- PPS - PowerPoint SlideShow via Aspose.Slides
- PPTX - PowerPoint 2007 Presentation via Aspose.Slides
- PPSX - PowerPoint 2007 SlideShow via Aspose.Slides
- ODP - OpenDocument Presentation via Aspose.Slides
- XPS - via Aspose.Slides

Nếu không có giấy phép, các tệp đã xuất sẽ có watermark đánh giá; xem [Cấp phép](/slides/vi/reportingservices/license-aspose-slides-for-reporting-services/).

## **Khi nào nên cài đặt thủ công**

Cài đặt phần mở rộng [bằng tay](/slides/vi/reportingservices/install-manually/) thay vì khi:

- trình cài đặt không thể cấu hình một thể hiện, ví dụ do cài đặt bảo mật trên máy chủ;
- sau khi nâng cấp, bạn muốn chỉ thay thế assembly mà không cần gỡ bỏ phiên bản cũ và chạy trình cài đặt mới.

Gỡ cài đặt sản phẩm sẽ xóa assembly và các mục cấu hình khỏi mỗi thể hiện.