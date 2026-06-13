---
title: การสนับสนุนการฝังวิดีโอในงานนำเสนอ
type: docs
weight: 80
url: /th/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}}

Microsoft SQL Server Reporting Services ไม่ได้มีความสามารถในตัวในการส่งออกรายงานที่มีวิดีโอฝังอยู่ไปยังการนำเสนอ PowerPoint Aspose.Slides for Reporting Services รุ่น 4.10 และเวอร์ชันต่อ ๆ ไปรองรับการฝังวิดีโอในงานนำเสนอ

{{% /alert %}}

เพื่อฝังวิดีโอลงสไลด์ โปรดใส่กล่องข้อความที่มีข้อความดังต่อไปนี้ในรายงาน:

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

ทำงานได้กับ SQL Server รุ่น 2008 ขึ้นไป คุณลักษณะนี้รองรับเฉพาะการส่งออกเป็น PPTX เท่านั้น