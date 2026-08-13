---
title: Cài đặt Demo
type: docs
weight: 70
url: /vi/jasperreports/demos-setup/
---
Tất cả các bản demo được cung cấp với Aspose.Slides cho JasperReports đều là các bản demo tiêu chuẩn đã được thay đổi. Tốt hơn nên sao chép tất cả các bản demo vào thư mục demo của JasperReports:
...\jasperreports-x.x.x\demo\samples\

Sử dụng chuỗi lệnh tiêu chuẩn để xây dựng và xuất báo cáo:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
Vui lòng không quên chạy HSQLDB với cơ sở dữ liệu thử nghiệm để điền dữ liệu vào các báo cáo và sao chép tệp aspose.slides.jasperreports.library-xx.x.jar từ \lib\JasperReports X.X.X - X.X.X của aspose-slides-xx.x-jasperreports.zip tới &#60;InstallDir&#62;\lib directory.
{{% /alert %}} 

Hầu hết các bản demo (ngoại trừ Charts) đã có sẵn các bản trình chiếu đã được tạo, vì vậy bạn có thể bỏ qua tất cả các bước “ant” và kiểm tra kết quả ngay lập tức.