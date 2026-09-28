---
title: Cài đặt thủ công
type: docs
weight: 30
url: /vi/reportingservices/install-manually/
keywords:
- cài đặt thủ công
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Cài đặt Aspose.Slides for Reporting Services bằng tay từ gói ZIP chỉ chứa DLLs: xác định assembly cần sao chép và những gì cần thêm vào rsreportserver.config và rssrvpolicy.config."
---
## **Tổng quan**

Thực hiện các bước sau để cài đặt Aspose.Slides for Reporting Services mà không dùng trình cài đặt MSI, từ gói ZIP *Aspose.Slides for Reporting Services XX.XX (Chỉ DLL)* trên [trang tải xuống](https://releases.aspose.com/slides/vi/reportingservices/). Các bước này đăng ký cùng các phần mở rộng như [trình cài đặt MSI](/slides/vi/reportingservices/install-with-msi-installer/). Lặp lại chúng cho mỗi phiên bản máy chủ báo cáo.

Trước khi bắt đầu, hãy kiểm tra [yêu cầu hệ thống](/slides/vi/reportingservices/system-requirements/). Bạn cần quyền quản trị viên cục bộ trên máy chủ báo cáo.

## **Chọn Assembly**

Gói ZIP chứa một vài bản dựng. Sao chép **chỉ một** tệp *Aspose.Slides.ReportingServices.dll* tới máy chủ báo cáo:

| Tệp trong gói ZIP | Sử dụng cho |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 trở lên Reporting Services và Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Không dành cho máy chủ báo cáo: các ứng dụng xuất từ điều khiển ReportViewer 2010 hoặc 2012, xem [Sử dụng Aspose.Slides với ReportViewer 2010 và 2012](/slides/vi/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Tùy chọn: lưu báo cáo dưới định dạng RPL để báo cáo sự cố, xem [Xuất báo cáo sang định dạng RPL](/slides/vi/reportingservices/exporting-reports-to-rpl-format/) |

## **Tìm Thư Mục Máy Chủ Báo Cáo**

Các bước dưới đây đề cập đến thư mục *ReportServer* của máy chủ báo cáo, nơi chứa *rsreportserver.config* và *rssrvpolicy.config*. Trong cài đặt mặc định, nó là:

| Máy chủ báo cáo | Thư mục *ReportServer* mặc định |
| :- | :- |
| SQL Server 2017 và các phiên bản Reporting Services sau này | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 và các phiên bản Reporting Services trước đó | `C:\Program Files\Microsoft SQL Server\<thư mục instance>\Reporting Services\ReportServer`, trong đó thư mục instance có thể là `MSRS13.MSSQLSERVER` cho SQL Server 2016 hoặc `MSSQL.x` cho SQL Server 2005 |

Để biết thêm vị trí, xem bài viết của Microsoft về [tệp cấu hình RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Cài Đặt Phần Mở Rộng**

1. Sao chép assembly bạn đã chọn vào thư mục con *bin* của thư mục *ReportServer*.

   Tệp đã sao chép không được có quyền NTFS được gán rõ ràng, nếu không máy chủ báo cáo sẽ bị từ chối truy cập khi tải assembly và các định dạng xuất mới sẽ không xuất hiện. Nhấp chuột phải vào tệp, chọn **Properties**, và ở tab **Security** xóa mọi quyền được gán rõ ràng, chỉ để lại các quyền kế thừa. Nếu tab **General** hiển thị tùy chọn **Unblock**, chọn nó.

2. Lưu một bản sao của *rsreportserver.config*, sau đó mở tệp trong trình soạn thảo văn bản. Thêm các mục này vào bên trong phần tử `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Mỗi mục đăng ký một định dạng xuất; `Name` phải là duy nhất trong số các phần mở rộng hiển thị. Trình cài đặt MSI đăng ký cùng sáu tên và kiểu. Bỏ qua mục nếu bạn không muốn định dạng đó xuất hiện trong danh sách.

3. Lưu một bản sao của *rssrvpolicy.config*, sau đó mở tệp trong trình soạn thảo văn bản. Tìm nhóm mã có `Description` là "This code group grants MyComputer code Execution permission." và thêm nhóm mã này làm con cuối cùng của nó:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` là khóa công khai của assembly Aspose.Slides.ReportingServices. Giữ nó trên một dòng duy nhất.

4. Lưu cả hai tệp. Máy chủ báo cáo sẽ đọc lại các tệp cấu hình mỗi khi chúng được lưu. Nếu tệp chứa XML không hợp lệ, máy chủ báo cáo sẽ bỏ qua hoặc không khởi động, vì vậy hãy khôi phục bản sao của bạn nếu xảy ra lỗi.

## **Kiểm Tra Cài Đặt**

Mở một báo cáo phân trang trong cổng web (Report Manager trên SQL Server 2014 và các phiên bản trước) và mở danh sách **Export**. Bây giờ nó sẽ bao gồm các định dạng sau:

- PPT - PowerPoint Presentation via Aspose.Slides
- PPS - PowerPoint SlideShow via Aspose.Slides
- PPTX - PowerPoint 2007 Presentation via Aspose.Slides
- PPSX - PowerPoint 2007 SlideShow via Aspose.Slides
- ODP - OpenDocument Presentation via Aspose.Slides
- XPS - via Aspose.Slides

Chọn một trong số chúng để xuất báo cáo. Tệp sẽ mở bằng ứng dụng được liên kết với định dạng đó.

![A report exported to PowerPoint by Aspose.Slides for Reporting Services](install-manually_2.png)

Nếu các định dạng không xuất hiện, kiểm tra quyền NTFS của assembly đã sao chép. Nếu không có giấy phép, các tệp xuất sẽ có dấu nước đánh giá; xem [Cấp phép](/slides/vi/reportingservices/license-aspose-slides-for-reporting-services/).