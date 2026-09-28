---
title: Xuất PPT, PPTX, PDF và HTML
type: docs
weight: 20
url: /vi/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Chọn trình xuất Aspose.Slides cho JasperReports cho đầu ra PPT, PPTX, PDF hoặc HTML, xuất một báo cáo đã được điền bằng nó, và ánh xạ phông chữ của báo cáo sang phông chữ của bản trình chiếu."
---
## **Trình xuất**

Aspose.Slides cho JasperReports bổ sung bốn trình xuất vào JasperReports. Mỗi trình xuất nhận một báo cáo đã được điền (`JasperPrint`) và xuất mỗi trang báo cáo: dưới dạng một slide trong PPT và PPTX, dưới dạng một trang trong PDF, và dưới dạng một hình ảnh SVG trong một tệp HTML duy nhất.

| Định dạng đầu ra | Lớp trình xuất |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Các lớp nằm trong gói `com.aspose.slides.jasperreports` của tệp jar thư viện, và chúng không sử dụng Microsoft PowerPoint. Gửi báo cáo và tệp đầu ra cho một trình xuất bằng cách sử dụng `setParameter` và `JRExporterParameter`, mà JasperReports đánh dấu là đã lỗi thời: các trình xuất không chấp nhận cấu hình mới hơn `setExporterInput` và `setExporterOutput`.

## **Xuất báo cáo sang cả bốn định dạng**

Chương trình dưới đây dựa trên dự án từ [Your first export](/slides/vi/jasperreports/#your-first-export). Nó biên dịch và điền *hello.jrxml* một lần, sau đó truyền báo cáo đã điền cho từng trình xuất theo thứ tự. Lưu nó thành *src/main/java/ExportAllFormats.java* trong dự án đó:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // Biên dịch và điền báo cáo một lần.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Xuất cùng một báo cáo đã điền bằng mỗi trình xuất.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

Chạy nó từ thư mục dự án:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Chương trình lưu *hello.ppt*, *hello.pptx*, *hello.pdf* và *hello.html* trong thư mục dự án. Phương thức trợ giúp nhận `ASAbstractExporter`, lớp cơ sở của cả bốn trình xuất. Nếu không có giấy phép, mỗi tệp đầu ra sẽ có dấu nước đánh giá — xem [Evaluate Aspose.Slides](/slides/vi/jasperreports/evaluate-aspose-slides/).

![Một báo cáo được xuất thành bản trình chiếu mà không có giấy phép](ppt-pptx-pdf-and-html-export_1.png)

## **Ánh xạ phông chữ**

Các trình xuất PPT và PPTX ghi tên phông chữ của thiết kế báo cáo vào bản trình chiếu mà không thay đổi. Khi một phần tử văn bản không chỉ định phông chữ, JasperReports sử dụng phông chữ mặc định của nó, `SansSerif`, là tên phông chữ logic của Java chứ không phải phông chữ đã cài đặt. Để thay thế các tên này, truyền một bản đồ từ tên phông chữ trong báo cáo sang tên phông chữ bạn muốn trong bản trình chiếu qua tham số `ASExporterParameters.PPT_FONT_MAP`. Các khóa phải khớp chính xác với tên phông chữ trong báo cáo, bao gồm cả chữ hoa/thường. Mỗi giá trị phải là một phông chữ mà Java tìm thấy trên máy thực hiện việc xuất; các trình xuất sẽ bỏ qua mục mà Java không thể tìm thấy phông chữ.

Lưu chương trình này thành *src/main/java/MapFonts.java* trong cùng dự án. Nó xuất *hello.jrxml* sang PPTX với `SansSerif` được thay thế bằng Arial:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Ánh xạ tên phông chữ của báo cáo sang tên phông chữ sẽ ghi vào bản trình chiếu.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

Chạy nó từ thư mục dự án:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

Trong *hello-arial.pptx* đã lưu, văn bản của báo cáo sử dụng Arial thay vì `SansSerif`. Trên một máy mà Java không tìm thấy Arial, chẳng hạn một hệ thống Linux không có nó, văn bản sẽ giữ lại `SansSerif`. Trên JasperReports Server, thiết lập cùng bản đồ thông qua thuộc tính `fontMap` của bean tham số xuất — xem [Integration with JasperServer](/slides/vi/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).