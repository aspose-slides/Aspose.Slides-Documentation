---
title: Hỗ trợ nhúng video vào bản trình bày
type: docs
weight: 80
url: /vi/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services không có khả năng tích hợp sẵn để xuất báo cáo có video nhúng sang bản trình bày PowerPoint. Aspose.Slides for Reporting Services phiên bản 4.10 trở lên hỗ trợ nhúng video vào trong bản trình bày. 

{{% /alert %}} 

Để nhúng video vào các slide, vui lòng chèn vào báo cáo một hộp văn bản có nội dung: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Tính năng này hoạt động với SQL Server phiên bản 2008 trở lên. Tính năng chỉ được hỗ trợ cho việc xuất dưới dạng PPTX.