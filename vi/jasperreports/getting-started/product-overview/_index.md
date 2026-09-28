---
title: Tổng quan sản phẩm
type: docs
weight: 10
url: /vi/jasperreports/product-overview/
description: "Tìm hiểu Aspose.Slides for JasperReports làm gì, các phiên bản JasperReports và định dạng đầu ra nào nó hỗ trợ, và mục đích của hai file jar."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Mô tả sản phẩm**

Aspose.Slides for JasperReports xuất khẩu các báo cáo từ JasperReports sang bản trình bày PowerPoint, trong các ứng dụng Java và trong JasperReports Server, mà không cần Microsoft PowerPoint. Nó hỗ trợ JasperReports từ phiên bản 3.7.2 đến 6.16.0, với một file jar riêng cho mỗi dải phiên bản — xem [Cài đặt Aspose.Slides for JasperReports](/slides/vi/jasperreports/installing-aspose-slides-for-jasperreports/).

Nó xuất khẩu một báo cáo đã điền dữ liệu sang bốn định dạng, một slide hoặc trang cho mỗi trang báo cáo:

- PPT – Bản trình bày PowerPoint 97–2003
- PPTX – Bản trình bày PowerPoint (Office Open XML)
- PDF
- HTML

Sản phẩm gồm hai phần:

- File jar thư viện thêm các exporter `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` và `ASHtmlExporter` vào JasperReports Library.
- File jar máy chủ cung cấp các hành động xuất khẩu cho cùng bốn định dạng, bạn đăng ký chúng trong JasperReports Server — xem [Tích hợp với JasperServer](/slides/vi/jasperreports/integration-with-jasperserver/).

### **Ví dụ đầu ra**

Các exporter mở rộng các lớp exporter của JasperReports và được sử dụng theo cách tương tự: truyền cho chúng báo cáo đã điền và tệp đầu ra, rồi gọi `exportReport`. Đối với một chương trình hoàn chỉnh điền báo cáo và xuất ra PPTX, xem [Xuất khẩu đầu tiên của bạn](/slides/vi/jasperreports/#your-first-export); đối với cả bốn định dạng, xem [Xuất khẩu PPT, PPTX, PDF và HTML](/slides/vi/jasperreports/ppt-pptx-pdf-and-html-export/).

![Báo cáo được xuất khẩu thành bản trình bày mà không có giấy phép, với hình mờ đánh giá ở trung tâm slide](product-overview_2.png)