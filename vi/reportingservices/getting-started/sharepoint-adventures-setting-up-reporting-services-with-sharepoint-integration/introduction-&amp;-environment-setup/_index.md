---
title: Giới thiệu &amp; Thiết lập môi trường
type: docs
weight: 10
url: /vi/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}}

Đã có các truy vấn trong quá khứ liên quan đến việc tích hợp Aspose.Slides cho Reporting Services với SharePoint. Trong bài viết này, chúng tôi sẽ tập trung vào SharePoint 2010. Giả sử rằng bạn đã có môi trường SharePoint Farm được thiết lập. Các ví dụ chúng tôi sẽ theo trong bài này sẽ là một SharePoint Cloud đầy đủ, nhưng các bước sẽ tương tự cho SharePoint Foundation Server. Trước khi tiếp tục, hãy bắt đầu với một số tài liệu quan trọng mà bạn có thể tham khảo khi thực hiện:

- [Tổng quan về Tích hợp Dịch vụ Báo cáo và Công nghệ SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Cấu hình Dịch vụ Báo cáo cho Tích hợp SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **Cài đặt Môi trường**
Cài đặt mà chúng ta sẽ có bao gồm **4 máy chủ**. Gồm có **Domain Controller**, **SQL Server**, **SharePoint Server** và một máy chủ cho **Reporting Services**. Bạn có thể chọn đặt SharePoint và Reporting Services trên cùng một máy.