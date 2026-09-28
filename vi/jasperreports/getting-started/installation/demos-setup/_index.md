---
title: Cài đặt Demo
type: docs
weight: 70
url: /vi/jasperreports/demos-setup/
description: "Thiết lập các dự án demo từ bản tải về Aspose.Slides for JasperReports, thay đổi lớp exporter mà chúng sử dụng, và biên dịch chúng bằng Ant."
---
## **Các demo là gì**

Thư mục *samples* của bản tải về Aspose.Slides for JasperReports có tám dự án demo: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* và *xmldatasource*. Chúng là các demo tiêu chuẩn của JasperReports, được chỉnh sửa để thêm mục tiêu biên dịch `ppt` xuất báo cáo đã điền sang PPT. Bản tải về không chứa các bản trình bày đã xuất; bạn tạo chúng bằng cách biên dịch một demo.

## **Thay đổi lớp exporter trước khi biên dịch**

Như được cung cấp, mã Java của các demo sử dụng `com.aspose.slides.jasperreports.JRPptExporter`, một lớp không có trong các jar hiện tại, vì vậy các demo không biên dịch. Trong lớp ứng dụng của demo (ví dụ, *ShapesApp.java* trong demo *shapes*), thay thế `JRPptExporter` bằng `ASPptExporter`, lớp exporter PPT trong cùng gói. Demo *fonts* nhập toàn bộ gói, vì vậy chỉ cần thay đổi tên lớp trong mã của nó.

Các demo cũng sử dụng các lớp JasperReports mà các phiên bản JasperReports sau này đã loại bỏ, như `JExcelApiExporter` và `JRExporterParameter.FONT_MAP`. Với thay đổi ở trên, các demo biên dịch như sau:

| Phiên bản JasperReports | Các demo biên dịch được |
| :- | :- |
| 5.5.1 | tất cả tám |
| 5.5.2 và 6.4.0 | *charts*, *images*, *landscape*, *shapes* và *xmldatasource* |
| 6.16.0 | *charts* |

## **Biên dịch một demo**

Mỗi *build.xml* của demo mong đợi cấu trúc thư mục của một dự án JasperReports: nó biên dịch dựa trên *../../../build/classes* và các jar trong *../../../lib*, tính tương đối so với thư mục demo.

1. Sao chép thư mục demo vào *demo/samples* trong thư mục dự án JasperReports của bạn.  
2. Sao chép *aspose.slides.jasperreports.library-xx.x.jar* từ thư mục *lib* của bản tải về phù hợp với phiên bản JasperReports của bạn vào thư mục *lib* của dự án JasperReports. Xem [Installing Aspose.Slides for JasperReports](/slides/vi/jasperreports/installing-aspose-slides-for-jasperreports/).  
3. Đặt jar của phiên bản JasperReports của bạn và các jar phụ thuộc của nó vào cùng thư mục *lib*. Ngoài các tệp demo, *build.xml* chỉ đưa *build/classes* và các jar trong *lib* vào classpath, và *build/classes* chỉ chứa các lớp JasperReports sau khi bạn biên dịch JasperReports từ mã nguồn.  
4. Các demo *charts*, *subreport* và *text* đọc cơ sở dữ liệu mẫu HSQLDB của JasperReports (`jdbc:hsqldb:hsql://localhost`), vì vậy hãy khởi động máy chủ của nó trước, như mô tả trong *samples/Readme.txt* của bản tải về. Các demo khác không cần cơ sở dữ liệu.  
5. Trong thư mục demo, biên dịch ứng dụng, biên dịch thiết kế báo cáo, điền dữ liệu và xuất ra PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Mục tiêu `ppt` ghi bản trình bày cạnh báo cáo đã điền, đặt tên giống báo cáo (ví dụ, *LandscapeReport.ppt*).

Hai demo cần thực hiện thêm các bước sau:

- Demo *images* tải một hình ảnh từ `http://jasperreports.sourceforge.net/jasperreports.png` khi xuất. Địa chỉ này hiện chuyển hướng sang HTTPS, vì vậy bước `ppt` sẽ không tạo bản trình bày cho đến khi bạn thay đổi địa chỉ thành `https://` trong *ImagesReport.jrxml*. Với JasperReports 6.4.0, việc xuất hình ảnh này sẽ thất bại ngay cả khi sử dụng HTTPS.  
- Báo cáo *xmldatasource* sử dụng phông Arial. Trên hệ thống không có Arial, lệnh `ant fill` sẽ thông báo rằng phông "không khả dụng cho JVM" và không tạo báo cáo đã điền, do đó `ant ppt` không có gì để xuất. Quá trình biên dịch vẫn báo thành công, vì vậy hãy kiểm tra đầu ra của từng bước.