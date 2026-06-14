---
title: Giới thiệu và Cài đặt Môi trường
type: docs
weight: 10
url: /vi/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

Đã có các yêu cầu trong quá khứ về Aspose.Slides cho việc Tích hợp Dịch vụ Báo cáo với SharePoint. Trong bài viết này, chúng tôi sẽ tập trung vào SharePoint 2010. Giả định rằng bạn đã có môi trường SharePoint Farm được thiết lập. Các ví dụ chúng tôi sẽ theo trong bài viết này sẽ là một SharePoint Cloud hoàn chỉnh, nhưng các bước sẽ tương tự đối với SharePoint Foundation Server. Trước khi tiến hành, hãy bắt đầu với một số tài liệu quan trọng mà bạn có thể tham khảo khi thực hiện:

- [Overview of Reporting Services and SharePoint Technology Integration](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Configuring Reporting Services for SharePoint 2010 Integration](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Cài đặt môi trường**
Cấu hình mà chúng ta sẽ có bao gồm **4 máy chủ**. Điều này bao gồm một **Domain Controller**, một **SQL Server**, một **SharePoint Server** và một máy chủ cho **Reporting Services**. Bạn có thể chọn đặt SharePoint và Reporting Services trên cùng một máy.