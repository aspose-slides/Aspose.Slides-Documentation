---
title: Triển khai và Kích hoạt
type: docs
weight: 20
url: /vi/sharepoint/deployment-and-activation/
description: "Giải pháp Aspose.Slides for SharePoint cài đặt gì trên farm khi được triển khai, và tính năng bộ sưu tập site của nó thêm gì khi được kích hoạt."
---
## **Triển khai**

Trong quá trình triển khai, giải pháp Aspose.Slides for SharePoint:

- Cài đặt assembly của nó vào Global Assembly Cache và thêm các mục SafeControl vào tệp **web.config**. Trên SharePoint 2010 trở lên, đây là *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* hoặc *Aspose.Slides.SharePoint2016.dll* (gói SharePoint 2019 cũng cài đặt *Aspose.Slides.SharePoint2016.dll*). Trên SharePoint 2007, nó là *Aspose.Slides.SharePointUI.dll*, cùng với *Aspose.Slides.SharePoint.Deployment.dll*.
- Sao chép trang chuyển đổi và các hình ảnh cùng các tệp hỗ trợ khác vào các thư mục cài đặt của SharePoint.
- Cài đặt tính năng và làm cho nó khả dụng để kích hoạt trên các bộ sưu tập site.

## **Kích hoạt**

Aspose.Slides for SharePoint được đóng gói dưới dạng tính năng bộ sưu tập site và có thể được kích hoạt hoặc hủy kích hoạt trên các bộ sưu tập site. Khi nó được kích hoạt trên một bộ sưu tập site, tính năng sẽ thêm:

- Trên SharePoint 2010 trở lên:
  - mục **Convert via Aspose.Slides** vào menu tài liệu trong các thư viện tài liệu;
  - tab ribbon **Aspose Tools** với nút **Convert Slides**, chuyển đổi các tài liệu đã chọn;
  - mục **View Slides** vào menu của các tệp PPT, PPTX, PPS và PPSX.
- Trên SharePoint 2007:
  - mục **Convert with Aspose.Slides** vào menu tài liệu trong các thư viện tài liệu;
  - mục **Convert All with Aspose.Slides** vào menu **Actions** của các thư viện tài liệu.

Trên SharePoint 2007, việc kích hoạt cũng tạo ra các thay đổi đối với thư mục ảo của ứng dụng web cha của bộ sưu tập site. Nó:

- Thêm trang cài đặt chuyển đổi vào tệp sitemap.
- Sao chép các tệp tài nguyên cần thiết vào thư mục App_GlobalResources trong thư mục ảo.

Chương trình cài đặt kích hoạt tính năng trên các bộ sưu tập site mà bạn chọn trong quá trình [installation](/slides/vi/sharepoint/installing-aspose-slides-for-sharepoint/).