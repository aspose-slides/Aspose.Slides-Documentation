---
title: Hỗ trợ nhúng âm thanh trong bài thuyết trình
type: docs
weight: 90
url: /vi/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}}
Microsoft SQL Server Reporting Services không có khả năng tích hợp để xuất báo cáo có âm thanh nhúng sang bản trình bày PowerPoint. Aspose.Slides for Reporting Services phiên bản 4.10 trở lên hỗ trợ nhúng âm thanh trong bản trình bày đã xuất.
{{% /alert %}}
Để nhúng âm thanh vào các slide, vui lòng thêm vào báo cáo một hộp văn bản có nội dung:
``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```
Tính năng này hoạt động với SQL Server phiên bản 2008 trở lên. Tính năng chỉ được hỗ trợ cho việc xuất PPTX.