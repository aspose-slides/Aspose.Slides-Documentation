---
title: Cài đặt Demo
type: docs
weight: 70
url: /vi/jasperreports/demos-setup/
---
Tất cả các demo đi kèm với Aspose.Slides cho JasperReports đã được thay đổi thành các demo tiêu chuẩn. Tốt hơn nên sao chép toàn bộ các demo vào thư mục demo của JasperReports:
...\jasperreports-x.x.x\demo\samples\

Sử dụng chuỗi lệnh tiêu chuẩn để biên dịch và xuất báo cáo:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 
Vui lòng không quên chạy HSQLDB với cơ sở dữ liệu thử nghiệm để điền dữ liệu vào báo cáo và sao chép tệp aspose.slides.jasperreports.library-xx.x.jar từ \lib\JasperReports X.X.X - X.X.X folder của aspose-slides-xx.x-jasperreports.zip tới &#60;InstallDir&#62;\lib directory.
{{% /alert %}} 

Hầu hết các demo (ngoại trừ Charts) đã có sẵn các bản trình chiếu được tạo sẵn, vì vậy bạn có thể bỏ qua tất cả các bước “ant” và kiểm tra kết quả ngay lập tức.