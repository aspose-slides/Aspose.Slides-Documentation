---
title: Cài đặt Aspose.Slides cho JasperReports
type: docs
weight: 40
url: /vi/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Chọn các file jar Aspose.Slides cho JasperReports phù hợp với phiên bản JasperReports của bạn, và thêm chúng vào JasperReports, một dự án Maven hoặc JasperReports Server."
---
## **Chọn các file jar cho phiên bản JasperReports của bạn**

Aspose.Slides for JasperReports được phân phối dưới dạng file ZIP trên [trang tải xuống](https://releases.aspose.com/slides/vi/jasperreport/). Thư mục *lib* của nó có một thư mục con cho mỗi dải phiên bản JasperReports. Lấy các file jar từ thư mục con tương ứng với phiên bản JasperReports bạn đang dùng:

| Phiên bản JasperReports | Thư mục con của *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Không có thư mục con cho JasperReports 6.17.0 trở lên, bao gồm cả JasperReports 7. Thư mục con *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* không chứa bất kỳ file jar nào, chỉ có một ghi chú rằng hỗ trợ cho các phiên bản đó đã kết thúc trong Aspose.Slides for JasperReports 17.6.

Mỗi thư mục con chứa hai file jar; *xx.x* trong tên của chúng là phiên bản sản phẩm:

- *aspose.slides.jasperreports.library-xx.x.jar* chứa các exporter cho JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` và `ASHtmlExporter`) và lớp `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* chứa các hành động xuất khẩu cho JasperReports Server. Nó dựa trên file jar thư viện, vì vậy server luôn cần cả hai file jar từ cùng một thư mục con.

## **Thêm file jar thư viện vào JasperReports hoặc ứng dụng của bạn**

Copy *aspose.slides.jasperreports.library-xx.x.jar* từ thư mục con tương ứng vào thư mục *lib* của JasperReports hoặc vào classpath của ứng dụng của bạn. Ứng dụng của bạn sau đó có thể tạo các exporter trong mã.

{{% alert color="info" title="Note" %}}
Trên Linux, JasperReports cần fontconfig và ít nhất một phông chữ đã được cài đặt để thực hiện việc điền báo cáo. Nếu không có phông chữ, việc điền sẽ thất bại với lỗi "Error initializing graphic environment".
{{% /alert %}}

## **Thêm file jar thư viện vào dự án Maven**

File jar được cung cấp trong file ZIP chứ không phải từ kho Maven. Để sử dụng nó trong quá trình xây dựng Maven, cài đặt nó vào kho Maven cục bộ của bạn. Đối với phiên bản 26.6, chạy lệnh này trong thư mục chứa file jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Sau đó thêm nó vào phần dependencies trong *pom.xml*, cùng với một phiên bản JasperReports mà thư mục con của file jar hỗ trợ:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

ID nhóm và artifact là những gì bạn chọn trong lệnh cài đặt; chúng chỉ cần khớp nhau. Một dự án hoàn chỉnh sử dụng JasperReports 6.16.0 có trong [Xuất khẩu đầu tiên của bạn](/slides/vi/jasperreports/#your-first-export).

## **Thêm các file jar vào JasperReports Server**

Sao chép cả hai file jar từ thư mục con tương ứng vào thư mục *WEB-INF/lib* của ứng dụng web JasperReports Server, sau đó đăng ký các exporter như mô tả trong [Tích hợp với JasperServer](/slides/vi/jasperreports/integration-with-jasperserver/).