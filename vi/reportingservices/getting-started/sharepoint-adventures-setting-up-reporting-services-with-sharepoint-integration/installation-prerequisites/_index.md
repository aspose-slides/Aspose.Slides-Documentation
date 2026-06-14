---
title: Yêu cầu cài đặt
type: docs
weight: 20
url: /vi/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

Các yêu cầu tiên quyết sau cần được đáp ứng trước khi chúng ta tiến hành cài đặt. 

{{% /alert %}} 
## **Bổ trợ Dịch vụ Báo cáo cho SharePoint**
Bổ trợ **Reporting Services Add-In for SharePoint** là một trong những thành phần then chốt để tích hợp hoạt động đúng cách. Bổ trợ phải được cài đặt trên bất kỳ **Web Front Ends (WFE)** nào trong farm SharePoint của bạn cùng với máy chủ Central Admin. Một trong những thay đổi mới với SQL 2008 R2 & SharePoint 2010 là Bổ trợ 2008 R2 bây giờ là yêu cầu trước cho việc cài đặt SharePoint. Điều này có nghĩa là Bổ trợ RS sẽ tự động được cài đặt khi bạn cài đặt SharePoint. Nó đã được hiển thị và đánh dấu trong hình dưới đây. Thực tế điều này tránh được nhiều vấn đề mà chúng tôi gặp với SP 2007 và RS 2008 khi cài đặt Bổ trợ. 

![todo:image_alt_text](installation-prerequisites_1.png)

**Hình 1**: Bổ trợ Dịch vụ Báo cáo cho SharePoint 
## **Xác thực SharePoint**
Trước khi chuyển sang các phần tích hợp RS, một điều quan trọng cần lưu ý là cách bạn cấu hình **Site** trong SharePoint Farm. Cụ thể hơn, cách bạn thiết lập xác thực cho Site; liệu nó sẽ là **Classic** hay **Claims**. Lựa chọn này quan trọng ở giai đoạn đầu. Tôi không tin rằng bạn có thể thay đổi tùy chọn này một khi đã thiết lập. Nếu có thể thay đổi, quá trình sẽ không đơn giản. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 KHÔNG hỗ trợ Claims 

{{% /alert %}} 

Ngay cả khi bạn chọn site SharePoint sử dụng **Claims**, Reporting Services bản thân không hỗ trợ Claims. Điều này ảnh hưởng đến cách xác thực hoạt động với Reporting Services. Vậy sự khác biệt từ góc nhìn của Reporting Services là gì? Nó liên quan đến việc bạn có muốn chuyển tiếp Thông tin xác thực người dùng tới datasource hay không. 

***Classic*** - Có thể sử dụng Kerberos và chuyển thông tin xác thực của người dùng tới nguồn dữ liệu back end của bạn (cần sử dụng Kerberos cho việc này). 

***Claims*** ** - Một token Claims được sử dụng thay vì token Windows. RS sẽ luôn sử dụng Trusted Authentication trong trường hợp này và chỉ có quyền truy cập vào token SPUser. Bạn sẽ cần lưu trữ thông tin xác thực của mình trong nguồn dữ liệu. 

Hiện tại, chúng ta chỉ muốn tập trung vào việc thiết lập RS. Tại thời điểm này SharePoint đã được cài đặt trên SharePoint Box và cấu hình với một **Classic Auth Site** trên **port 80**. Hơn nữa, trên máy chủ RS tôi **vừa mới cài đặt Reporting Services** và là xong.