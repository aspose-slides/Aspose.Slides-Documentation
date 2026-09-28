---
title: Các định dạng tệp được hỗ trợ
type: docs
weight: 20
url: /vi/jasperreports/supported-file-formats/
description: "Xem Aspose.Slides for JasperReports nhận gì làm đầu vào và các định dạng tệp nào nó xuất khẩu báo cáo sang."
---
## **Đầu vào**

Aspose.Slides for JasperReports xuất khẩu báo cáo; nó không chuyển đổi các bản trình bày hiện có. Các trình xuất khẩu của nó nhận một báo cáo JasperReports đã được điền (`JasperPrint`), chẳng hạn như kết quả của `JasperFillManager` hoặc một báo cáo đã điền được tải từ tệp *.jrprint*.

## **Định dạng đầu ra**

Bảng dưới đây liệt kê các định dạng mà Aspose.Slides for JasperReports xuất khẩu báo cáo sang, và lớp trình xuất khẩu ghi mỗi định dạng.

|**Định dạng**|**Mô tả**|**Trình xuất khẩu**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Bản trình chiếu PowerPoint 97–2003; một slide cho mỗi trang báo cáo|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Bản trình chiếu PowerPoint (Office Open XML); một slide cho mỗi trang báo cáo|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Định dạng Tài liệu Di động; một trang PDF cho mỗi trang báo cáo|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Một tệp HTML duy nhất với một hình ảnh SVG cho mỗi trang báo cáo|`ASHtmlExporter`|

Không có trình xuất khẩu cho các định dạng trình chiếu PPS và PPSX. Đặt tên tệp *.ppsx* cho xuất khẩu PPTX vẫn tạo ra một bản trình chiếu PPTX, không phải trình chiếu. Để xem cách mỗi trình xuất khẩu được sử dụng, xem [PPT, PPTX, PDF and HTML Export](/slides/vi/jasperreports/ppt-pptx-pdf-and-html-export/).