---
title: Triển khai và Kích hoạt
type: docs
weight: 20
url: /vi/sharepoint/deployment-and-activation/
---
## **Triển khai**
Trong quá trình triển khai, Aspose.Slides for SharePoint: 

- Cài đặt **Aspose.Slides.SharePoint.dll** vào Global Assembly Cache và thêm mục SafeControl vào tệp **web.config**.
- Cài đặt manifest tính năng và các tệp cần thiết khác vào các thư mục thích hợp.
- Đăng ký tính năng trong cơ sở dữ liệu SharePoint và làm cho nó khả dụng để kích hoạt ở phạm vi tính năng.
## **Kích hoạt**
Aspose.Slides for SharePoint được đóng gói dưới dạng tính năng cấp site (site collection) và có thể được kích hoạt hoặc vô hiệu hoá trên các site collection. Khi kích hoạt, tính năng sẽ thực hiện một số thay đổi đối với thư mục ảo của ứng dụng web cha của site collection. Nó: 

- Thêm trang cài đặt chuyển đổi vào tệp sitemap.
- Sao chép các tệp tài nguyên cần thiết vào thư mục App_GlobalResources trong thư mục ảo.