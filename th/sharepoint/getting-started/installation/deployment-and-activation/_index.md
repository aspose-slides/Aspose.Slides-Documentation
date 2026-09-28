---
title: การปรับใช้และการเปิดใช้งาน
type: docs
weight: 20
url: /th/sharepoint/deployment-and-activation/
description: "สิ่งที่โซลูชัน Aspose.Slides for SharePoint ติดตั้งบนฟาร์มเมื่อทำการปรับใช้และสิ่งที่ฟีเจอร์คอลเลกชันไซต์ของมันเพิ่มเมื่อทำการเปิดใช้งาน."
---
## **การปรับใช้**

ในระหว่างการปรับใช้ โซลูชัน Aspose.Slides for SharePoint:

- ติดตั้ง assembly ของมันลงใน Global Assembly Cache และเพิ่มรายการ SafeControl ลงในไฟล์ **web.config**. บน SharePoint 2010 และเวอร์ชันต่อมา จะเป็น *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* หรือ *Aspose.Slides.SharePoint2016.dll* (แพคเกจ SharePoint 2019 ยังติดตั้ง *Aspose.Slides.SharePoint2016.dll*). บน SharePoint 2007 จะเป็น *Aspose.Slides.SharePointUI.dll* ร่วมกับ *Aspose.Slides.SharePoint.Deployment.dll*.
- คัดลอกหน้าแปลงและภาพของมันรวมถึงไฟล์สนับสนุนอื่น ๆ ไปยังโฟลเดอร์การติดตั้งของ SharePoint.
- ติดตั้งฟีเจอร์และทำให้พร้อมสำหรับการเปิดใช้งานในคอลเลกชันไซต์.

## **การเปิดใช้งาน**

Aspose.Slides for SharePoint ถูกบรรจุเป็นฟีเจอร์คอลเลกชันไซต์และสามารถเปิดหรือปิดใช้งานในคอลเลกชันไซต์ได้. เมื่อเปิดใช้งานในคอลเลกชันไซต์ ฟีเจอร์จะเพิ่ม:

- บน SharePoint 2010 และเวอร์ชันต่อมา:
  - รายการ **Convert via Aspose.Slides** ไปยังเมนูเอกสารในไลบรารีเอกสาร;
  - แท็บริบบอน **Aspose Tools** ที่มีปุ่ม **Convert Slides** ซึ่งจะแปลงเอกสารที่เลือก;
  - รายการ **View Slides** ไปยังเมนูของไฟล์ PPT, PPTX, PPS และ PPSX.
- บน SharePoint 2007:
  - รายการ **Convert with Aspose.Slides** ไปยังเมนูเอกสารในไลบรารีเอกสาร;
  - รายการ **Convert All with Aspose.Slides** ไปยังเมนู **Actions** ของไลบรารีเอกสาร.

บน SharePoint 2007 การเปิดใช้งานยังทำการเปลี่ยนแปลงในไดเรกทอรีเสมือนของเว็บแอปพลิเคชันแม่ของคอลเลกชันไซต์. มัน:

- เพิ่มหน้าการตั้งค่าแปลงไปยังไฟล์ sitemap.
- คัดลอกไฟล์ทรัพยากรที่จำเป็นไปยังโฟลเดอร์ App_GlobalResources ในไดเรกทอรีเสมือน.

โปรแกรมติดตั้งจะเปิดใช้งานฟีเจอร์ในคอลเลกชันไซต์ที่คุณเลือกระหว่าง [การติดตั้ง](/slides/th/sharepoint/installing-aspose-slides-for-sharepoint/).