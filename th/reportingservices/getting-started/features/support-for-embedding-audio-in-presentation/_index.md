---
title: การสนับสนุนการฝังเสียงในงานนำเสนอ
type: docs
weight: 90
url: /th/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}}

Microsoft SQL Server Reporting Services ไม่มีความสามารถในตัวเพื่อตีกรอกรายงานที่มีเสียงฝังในไฟล์ PowerPoint. Aspose.Slides for Reporting Services รุ่น 4.10 ขึ้นไปรองรับการฝังเสียงภายในงานนำเสนอที่ส่งออก.

{{% /alert %}}

เพื่อฝังเสียงในสไลด์ โปรดใส่กล่องข้อความที่มีข้อความต่อไปนี้ลงในรายงาน:

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

ฟีเจอร์นี้ทำงานได้กับ SQL Server รุ่น 2008 ขึ้นไป และรองรับเฉพาะการส่งออกเป็น PPTX เท่านั้น.