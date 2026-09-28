---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /vi/jasperreports/
keywords:
- tài liệu
- JasperReports
- JasperReports Server
- xuất báo cáo
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides for JasperReports, xuất báo cáo đầu tiên sang PowerPoint, và tìm các hướng dẫn về xuất, tích hợp JasperReports Server và hỗ trợ."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports bổ sung các công cụ xuất PowerPoint cho JasperReports Library và JasperReports Server, cho phép các ứng dụng Java và máy chủ báo cáo lưu các báo cáo đã điền dưới dạng bản trình chiếu mà không cần Microsoft PowerPoint.

Nó xuất một báo cáo đã điền sang PPT và PPTX, một slide cho mỗi trang báo cáo, và cũng hỗ trợ PDF và HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/jasperreports/installing-aspose-slides-for-jasperreports/">Cài đặt</a></li>
<li><a href="/slides/vi/jasperreports/product-overview/">Tổng quan sản phẩm</a></li>
<li><a href="/slides/vi/jasperreports/system-requirements/">Yêu cầu hệ thống</a></li>
<li><a href="/slides/vi/jasperreports/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/jasperreports/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/jasperreports/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/jasperreports/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>XUẤT</p>
<ul>
<li><a href="/slides/vi/jasperreports/ppt-pptx-pdf-and-html-export/">Xuất sang PPT, PPTX, PDF và HTML</a></li>
<li><a href="/slides/vi/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Ánh xạ phông chữ</a></li>
<li><a href="/slides/vi/jasperreports/integration-with-jasperserver/">Tích hợp JasperReports Server</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/jasperreports/demos-setup/">Dự án mẫu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Ghi chú phát hành</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Lần xuất đầu tiên của bạn**

Các bước này biên dịch một báo cáo một dòng, điền dữ liệu và xuất nó ra PPTX bằng JasperReports 6.16.0 từ Maven Central. Bạn cần JDK 11 trở lên và Apache Maven.

1. Tải xuống tệp ZIP từ [trang tải xuống](https://releases.aspose.com/slides/jasperreport/) và giải nén. Thư mục *lib* của nó có một thư mục con cho mỗi dải phiên bản JasperReports, và mỗi thư mục chứa jar tương ứng. Đối với JasperReports 6.16.0, sao chép *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* vào một thư mục dự án trống.

2. Jar có trong tệp ZIP thay vì từ một kho Maven, vì vậy cài đặt nó vào kho Maven nội bộ của bạn. Chạy lệnh sau trong thư mục dự án:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Lưu *pom.xml* này vào thư mục dự án. Nó thêm JasperReports 6.16.0 và jar bạn đã cài đặt, và chỉ định lớp để chạy. JasperReports 6.16.0 khai báo một bản iText đã được vá mà không có trên Maven Central, vì vậy tệp loại trừ nó; các trình xuất Aspose không cần nó.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
        </dependency>
    </dependencies>

    <build>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

4. Lưu thiết kế báo cáo này dưới tên *hello.jrxml* trong thư mục dự án. Nó in một dòng văn bản trong dải tiêu đề:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. Lưu mã này dưới tên *src/main/java/HelloExport.java*. Nó biên dịch thiết kế, điền một bản ghi trống và xuất kết quả bằng `ASPptxExporter`:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // Biên dịch thiết kế báo cáo và điền một bản ghi trống.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Xuất báo cáo đã điền sang PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Chạy lệnh này trong thư mục dự án:

```bash
mvn compile exec:java
```

Chương trình lưu *hello.pptx* trong thư mục dự án, với một slide chứa văn bản của báo cáo. Trình biên dịch ghi chú rằng mã sử dụng API đã lỗi thời: các trình xuất nhận đầu vào và đầu ra thông qua `JRExporterParameter`, và chúng không chấp nhận cấu hình mới `setExporterInput` và `setExporterOutput`. Trên Linux, phải cài đặt fontconfig và ít nhất một phông chữ, nếu không việc điền báo cáo sẽ thất bại. Không có giấy phép, mỗi slide sẽ có dấu nước đánh giá ở trung tâm — xem [Cấp phép](/slides/vi/jasperreports/licensing/). Để xuất sang PPT, PDF hoặc HTML, xem [Xuất PPT, PPTX, PDF và HTML](/slides/vi/jasperreports/ppt-pptx-pdf-and-html-export/).