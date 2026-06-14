---
title: Câu hỏi thường gặp
type: docs
weight: 110
url: /vi/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Trang này tổng hợp một số câu hỏi thường gặp về:

- [Định dạng tệp được hỗ trợ](#Supported-File-Formats).
- [Hỗ trợ cho Power BI Reporting services](#Support-for-Power-BI-Reporting-services).
- [Cài đặt](#Installation).
- [Cấu hình xuất](#Export-Configuration).

{{% /alert %}} 
### **Định dạng tệp được hỗ trợ**
#### **Q: Bạn có thể xuất báo cáo sang định dạng nào bằng Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services cho phép xuất bất kỳ báo cáo nào ở định dạng PPT, PPS, PPTX, PPSX, XPS hoặc RPL.

### **Hỗ trợ cho Power BI Reporting services**
#### **Q: Aspose.Slides for Reporting Services có hỗ trợ Power BI không?**
**A**: Có. Aspose.Slides for Reporting Services hỗ trợ xuất các báo cáo phân trang (RDL) trong Power BI.

### **Cài đặt**
#### **Q: Chương trình cài đặt không khởi động. Cài đặt thủ công không đưa tới kết quả mong muốn.**
**A** : Đảm bảo rằng .NET Framework 3.5 đã được cài đặt trên hệ thống của bạn.
#### **Q: Các tùy chọn xuất không xuất hiện sau khi cài đặt Aspose.Slides for Reporting Services.**
**A**: Nếu bất kỳ CodeGroup nào trong rssrvpolicy.config không hoạt động đúng, bộ phân tích tệp cấu hình có thể bỏ qua các phần cuối của nhóm. Vì vậy, hãy di chuyển tất cả các CodeGroup liên quan tới Aspose.Slides for Reporting Services lên đầu khối chứa các CodeGroup của Aspose.Slides for Reporting Services.
#### **Q: Không thể tải tệp hoặc assembly Aspose.Slides.ReportingServices (Không thể lấy quyền thực thi \ Exception from HRESULT: 0x80131418).**
**A**: Mã lỗi (0x80131418) cho biết mô-đun dll không có đủ quyền. Điều này có thể do tính năng bảo mật chặn quyền truy cập đầy đủ vào tệp .dll nếu tệp được lấy từ máy tính khác. Bạn có thể khắc phục bằng cách mở cửa sổ thuộc tính của tệp dll và nhấn nút "Unblock" trong tab "Security".
#### **Q: Không thể tìm thấy giấy phép 'Aspose.Slides.Reporting.Services.lic'.**
**A**: Tệp giấy phép phải nằm bên cạnh dll hoặc trong thư mục Program Files (x86)\Aspose\Slides\.

### **Cấu hình xuất**
#### **Q: Làm thế nào để thay đổi màu của hyperlink trong báo cáo đã xuất?**
**A**: Mỗi phần mở rộng render của Aspose.Slides for Reporting Services trong rsreportserver.config có cấu hình riêng. Để thay đổi màu của hyperlink, đặt giá trị cần thiết trong phần <HyperlinkColor>.
#### **Q: Trong các bản trình chiếu đã xuất, văn bản trong bảng bị kéo dọc.**
**A**: Điều này được thực hiện để làm cho tài liệu dễ đọc hơn. Để hiển thị văn bản trong bảng như trong báo cáo, đặt phần mở rộng Aspose.Slides for Reporting Services thành "Normal" trong tệp cấu hình rsreportserver.config.