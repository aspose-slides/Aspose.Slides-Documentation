---
title: Cấu hình SharePoint cho Reporting Services
type: docs
weight: 50
url: /vi/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Bây giờ SharePoint đã được cài đặt và cấu hình trên máy chủ RS và RS đã được thiết lập thông qua Reporting Services Configuration Manager, chúng ta có thể chuyển sang cấu hình trong Central Admin. RS 2008 R2 thực sự đã đơn giản hóa quy trình này. Trước đây chúng ta phải thực hiện một quy trình 3 bước để làm cho nó hoạt động. Giờ chỉ còn một bước duy nhất.  

Chúng ta muốn truy cập trang web Central Administrator rồi vào General Application Settings. Ở phía dưới, chúng ta sẽ thấy Reporting Services.  

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Figure 17**: Cấu hình SharePoint 

{{% alert color="primary" %}} 

Nhấp vào "**Reporting Services Integration**".  

{{% /alert %}} 
## **URL Dịch vụ Web**
Chúng ta sẽ cung cấp URL cho Report Server mà chúng ta đã tìm thấy trong Reporting Services Configuration Manager. 
## **Chế độ Xác thực**
Chúng ta cũng sẽ chọn một Chế độ Xác thực. Liên kết MSDN sau sẽ mô tả chi tiết các tùy chọn này. 
[<span>Tổng quan Bảo mật cho Reporting Services trong chế độ tích hợp SharePoint</span>](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Tóm lại, nếu trang của bạn đang sử dụng **Claims Authentication**, bạn sẽ luôn sử dụng Trusted Authentication bất kể bạn chọn gì ở đây. Nếu bạn muốn truyền thông tin xác thực Windows, bạn nên chọn Windows Authentication. Đối với Trusted Authentication, chúng ta sẽ truyền token SPUser và không dựa vào thông tin xác thực Windows.  

Bạn cũng nên sử dụng Trusted Authentication nếu bạn đã cấu hình các trang Classic Mode của mình cho NTLM và RS được thiết lập cho NTLM. Kerberos sẽ cần thiết để sử dụng Windows Authentication và truyền qua cho nguồn dữ liệu của bạn.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Figure 18**: Đặt thông tin xác thực cho Reporting Services Integration 
## **Kích hoạt tính năng**
Tùy chọn này cho phép bạn kích hoạt Reporting Services cho tất cả các Site collection, hoặc bạn có thể chọn những site mà bạn muốn kích hoạt. Điều này thực sự nghĩa là các site nào sẽ có thể sử dụng Reporting Services.  
Khi hoàn tất, bạn sẽ thấy hình dưới đây.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Figure 19**: Tích hợp Reporting Services thành công với môi trường SharePoint 

Quay lại URL của Report Server như trong Hình 14, chúng ta sẽ thấy một hình tương tự như hình dưới đây.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Figure 20**: Xác minh Reporting Services thành công với môi trường SharePoint 

{{% alert color="primary" %}} 

Nếu site SharePoint của bạn được cấu hình cho SSL, nó sẽ không hiển thị trong danh sách này. Đây là một vấn đề đã biết và không có nghĩa là có lỗi. Các báo cáo của bạn vẫn sẽ hoạt động.  

{{% /alert %}} 

Bây giờ, chúng ta đã sẵn sàng sử dụng Reporting Services trong SharePoint 2010. Giống như phiên bản trước, chúng ta có một tính năng (được kích hoạt khi cấu hình Reporting Services Integration) trong “Site Collection Feature”. Ngoài ra, quá trình cài đặt đã thêm 3 content type vào site của chúng ta. Trong Hình 21, chúng ta có thể thấy 2 trong số các content type được thêm vào một thư viện tài liệu để tạo báo cáo tùy chỉnh, như thấy trong Hình 21.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Figure 21**: Trình tạo báo cáo 

“**Reporter Builder**” là một ActiveX mà chúng ta cần tải về trên server, như thấy trong Hình 22.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Figure 22**: Tải xuống và Cài đặt Report Builder 

Khi tải xuống hoàn tất, chạy **“Report Builder”**. Bây giờ, chúng ta đã sẵn sàng thiết kế báo cáo đầu tiên của mình, như thấy trong Hình 23.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figure 23**: Trình hướng dẫn tạo báo cáo mới của Report Builder 

Sau khi tạo báo cáo, chúng ta có thể lưu nó vào thư viện tài liệu đã tạo để đặt các báo cáo trong SharePoint 2010.  

Content type còn lại phải được sử dụng để tạo kết nối chia sẻ làm nguồn dữ liệu và lưu chúng trong một thư viện tài liệu trên SharePoint. Chúng ta có thể tạo một thư viện tài liệu, thêm content type này và sau đó sẽ có các kết nối sẵn sàng để thay đổi nguồn dữ liệu của các báo cáo.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Figure 24**: Xuất báo cáo thành công tới Report Server