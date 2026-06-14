---
title: Tổng quan sản phẩm
type: docs
weight: 10
url: /vi/jasperreports/product-overview/
---
![Aspose.Slides cho JasperReports](product-overview_1.png)

## **Chào mừng đến với Aspose.Slides cho JasperReports!**

Aspose.Slides cho JasperReports là một thư viện được thiết kế và phát triển đặc biệt cho các nhà phát triển cần dễ dàng xuất báo cáo từ JasperReports sang định dạng Microsoft PowerPoint Presentation (PPT) và Microsoft PowerPoint Show (PPS) trong các ứng dụng Java của họ. Tất cả các tính năng của báo cáo được chuyển đổi với độ chính xác cao nhất sang các bản trình bày Microsoft PowerPoint. Aspose.Slides cho JasperReports bao gồm hỗ trợ cho JasperReports 5+.

## **Mô tả sản phẩm**
JasperReports và JasperServer không có khả năng tích hợp để xuất báo cáo dưới dạng bản trình bày Microsoft PowerPoint, nhưng Aspose.Slides cho JasperReports cung cấp cho bạn hai định dạng xuất bổ sung: 

- PPT – Bản trình bày PowerPoint thông qua Aspose.Slides
- PPS – Trình chiếu PowerPoint thông qua Aspose.Slides
- PPTX – Bản trình bày PowerPoint thông qua Aspose.Slides
- PPSX – Trình chiếu PowerPoint thông qua Aspose.Slides

Aspose.Slides cho JasperReports bên trong sử dụng các thư viện Java thuần túy 100% của chúng tôi là Aspose.Slides cho Java và Aspose.Metafiles cho Java, những thư viện hàng đầu thế giới cho việc xử lý bản trình bày và metafile phía máy chủ.

Aspose.Slides cho JasperReports cho phép xuất bất kỳ báo cáo nào ở định dạng PPT hoặc PPS.

### **Ví dụ đầu ra**
Lớp ASPptExporter kế thừa lớp ASAbstractExporter nên có thể được sử dụng giống như bất kỳ trình xuất tiêu chuẩn nào khác. Ví dụ ngắn này hiển thị mã mẫu và ảnh chụp màn hình của một báo cáo được xem trong MS PowerPoint. Các ví dụ chi tiết có thể được tìm thấy trong các báo cáo demo được cung cấp. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Bản trình bày được tạo bằng demo JasperReports xmldatasource** 

![Bản trình bày được tạo bằng JasperReports](product-overview_2.png)