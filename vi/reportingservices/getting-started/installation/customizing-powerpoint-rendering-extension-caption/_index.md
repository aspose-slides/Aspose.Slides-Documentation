---
title: Tùy chỉnh chú thích phần mở rộng render PowerPoint
type: docs
weight: 60
url: /vi/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Bài viết này hướng dẫn cách tùy chỉnh chú thích các tùy chọn render của Aspose.Slides cho Reporting Services. 

{{% /alert %}} 
## **Ví dụ**
Khi cài đặt Aspose.Slides cho Reporting Services, 4 tùy chọn xuất bổ sung sẽ được thêm vào menu thả xuống của các tùy chọn xuất:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Cách sửa đổi văn bản chú thích**
Các chú thích mặc định của các phần mở rộng này có thể được thay đổi bằng cách ghi đè tên mặc định. Các bước sau sẽ hướng dẫn bạn cách thay đổi chú thích từ “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” thành “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Bước 1:** Xác định tệp **rsreportserver.config** thường nằm trong thư mục này: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Bước** **2:** Tìm các dòng này trong tệp rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Bước** **3:** Thay thế tham số mở rộng bằng đoạn sau: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Các tùy chọn xuất bây giờ sẽ hiển thị như sau: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)