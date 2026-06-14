---
title: Cài đặt Aspose.Slides cho SharePoint
type: docs
weight: 10
url: /vi/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint được tải xuống dưới dạng tệp lưu trữ Aspose.Slides.SharePoint.zip. Tệp lưu trữ chứa: 

- **Aspose.Slides.SharePoint.wsp**: tệp giải pháp SharePoint. Aspose.Slides for SharePoint được đóng gói dưới dạng giải pháp SharePoint để thuận tiện cho việc kích hoạt và hủy kích hoạt trên toàn bộ farm máy chủ.
- **Aspose_LicenseAgreement.rtf**: Thỏa thuận cấp phép người dùng cuối.
- **Setup.exe**: chương trình cài đặt.
- **Setup.exe.config**: tệp cấu hình cài đặt.

{{% /alert %}} 
## **Quy trình cài đặt**
Trước khi chạy quá trình cài đặt, chương trình cài đặt sẽ kiểm tra rằng:

- WSS 3.0 hoặc MOSS 2007 đã được cài đặt.
- Người dùng có quyền cài đặt các giải pháp SharePoint.
- Cơ sở dữ liệu SharePoint đang hoạt động.
- Dịch vụ Quản trị WSS đã được khởi động.
- Dịch vụ Bộ định thời WSS đã được khởi động.

Các dịch vụ Quản trị và Bộ định thời WSS là cần thiết vì một số hành động cài đặt dựa vào công việc định thời để lan truyền tới tất cả các máy chủ trong farm. 
### **Chạy quá trình cài đặt**
Để cài đặt Aspose.Slides for SharePoint: 

1. Giải nén tệp Aspose.Slides.SharePoint zip vào ổ đĩa cục bộ trên máy chủ MOSS 7.0 hoặc WSS 3.0.
2. Chạy setup.exe và làm theo các hướng dẫn trên màn hình.
   Chương trình cài đặt thực hiện các hành động sau: 
   1. Kiểm tra các điều kiện tiên quyết cài đặt. Cài đặt sẽ không tiếp tục nếu bất kỳ kiểm tra nào không thành công. 

      **Thực hiện kiểm tra hệ thống** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Hiển thị Thỏa thuận Cấp phép Người dùng Cuối (EULA). Bạn phải chấp nhận thỏa thuận để tiếp tục. 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Hiển thị lựa chọn mục tiêu triển khai. Chọn các ứng dụng web và bộ sưu tập trang mà tính năng sẽ được kích hoạt. 

   **Chọn mục tiêu triển khai** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Triển khai tính năng lên farm máy chủ. 

   **Thanh tiến trình cài đặt** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Kích hoạt Aspose.Slides cho các bộ sưu tập trang đã chọn và cấu hình các ứng dụng web cha của chúng.
7. Hiển thị danh sách các ứng dụng web và bộ sưu tập trang mà tính năng đã được triển khai và kích hoạt. 

   **Cài đặt thành công** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)