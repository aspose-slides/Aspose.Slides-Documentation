---
title: Aspose.Slides cho Dịch vụ Báo cáo
second_title: Aspose.Slides cho Dịch vụ Báo cáo
type: docs
weight: 50
url: /vi/reportingservices/
keywords:
- tài liệu
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- báo cáo phân trang
- RDL
- xuất PowerPoint
- Aspose.Slides
description: "Bắt đầu ở đây: cài đặt Aspose.Slides for Reporting Services, xuất báo cáo đầu tiên sang PowerPoint và tìm các định dạng xuất, yêu cầu hệ thống và hỗ trợ."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Reporting Services" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Reporting Services là một tiện ích mở rộng hiển thị cho Microsoft SQL Server Reporting Services và Power BI Report Server, thêm các định dạng trình chiếu vào danh sách xuất của các báo cáo phân trang (RDL), mà không cần Microsoft PowerPoint trên máy chủ.

Nó xuất báo cáo sang các bản trình chiếu PPT, PPTX, PPS và PPSX, sang ODP và sang XPS.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/reportingservices/installing-aspose-slides-for-reporting-services/">Cài đặt</a></li>
<li><a href="/slides/vi/reportingservices/system-requirements/">Yêu cầu hệ thống</a></li>
<li><a href="/slides/vi/reportingservices/install-with-msi-installer/">Cài đặt bằng trình cài đặt MSI</a></li>
<li><a href="/slides/vi/reportingservices/install-manually/">Cài đặt thủ công</a></li>
<li><a href="/slides/vi/reportingservices/power-bi/">Cài đặt trên Power BI Report Server</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/reportingservices/supported-file-formats/">Định dạng tệp hỗ trợ</a></li>
<li><a href="/slides/vi/reportingservices/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/reportingservices/license-aspose-slides-for-reporting-services/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>XUẤT</p>
<ul>
<li><a href="/slides/vi/reportingservices/support-for-embedding-audio-in-presentation/">Nhúng âm thanh trong đầu ra PPTX</a></li>
<li><a href="/slides/vi/reportingservices/paginated-reports/">Báo cáo phân trang từ Power BI Report Builder</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/reportingservices/sample-reports-gallery/">Bộ sưu tập báo cáo mẫu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://releases.aspose.com/slides/reportingservices/release-notes/">Ghi chú phát hành</a></li>
<li><a href="https://products.aspose.com/slides/reporting-services/">Trang sản phẩm</a></li>
<li><a href="https://releases.aspose.com/slides/reportingservices/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Xuất đầu tiên của bạn**

Không cần viết mã: bạn cài đặt tiện ích mở rộng trên máy chủ báo cáo, và các định dạng của nó xuất hiện trong danh sách xuất của mỗi báo cáo phân trang trên máy chủ đó.

1. Kiểm tra xem máy chủ báo cáo có đáp ứng [yêu cầu hệ thống](/slides/vi/reportingservices/system-requirements/), bao gồm .NET Framework 3.5.
1. Từ [trang tải xuống](https://releases.aspose.com/slides/reportingservices/), tải về trình cài đặt MSI, *Aspose.Slides for Reporting Services*. Để cài đặt thủ công, tải về gói ZIP, *Aspose.Slides for Reporting Services (DLLs Only)*.
1. Cài đặt tiện ích mở rộng trên máy chủ báo cáo: chạy MSI với quyền quản trị, như mô tả trong [Cài đặt bằng trình cài đặt MSI](/slides/vi/reportingservices/install-with-msi-installer/), hoặc làm theo [Cài đặt thủ công](/slides/vi/reportingservices/install-manually/) cho gói ZIP.
1. Trong trình duyệt, mở cổng web của máy chủ báo cáo (Report Manager trên SQL Server 2014 và các phiên bản trước). Theo mặc định, địa chỉ của nó là `https://<ComputerName>/reports`.
1. Mở một báo cáo phân trang. Trong thanh công cụ của báo cáo, mở danh sách **Export** và chọn **PPTX - PowerPoint 2007 Presentation via Aspose.Slides**. Nếu thanh công cụ có nút **Export** riêng, như Report Manager, hãy chọn nó.
1. Mở hoặc lưu tệp PPTX mà trình duyệt tải về.

Nếu không có giấy phép, bản trình chiếu được xuất sẽ có dấu nước đánh giá — xem [Cấp phép](/slides/vi/reportingservices/license-aspose-slides-for-reporting-services/). Đối với các định dạng khác trong danh sách xuất, xem [Định dạng tệp hỗ trợ](/slides/vi/reportingservices/supported-file-formats/).