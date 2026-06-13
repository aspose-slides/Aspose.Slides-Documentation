---
title: การปรับใช้และการเปิดใช้งาน
type: docs
weight: 20
url: /th/sharepoint/deployment-and-activation/
---
## **การปรับใช้**
ในระหว่างการปรับใช้, Aspose.Slides for SharePoint: 

- ติดตั้ง **Aspose.Slides.SharePoint.dll** ไปยัง Global Assembly Cache และเพิ่มรายการ SafeControl ลงในไฟล์ **web.config**.
- ติดตั้งไฟล์ feature manifest และไฟล์ที่จำเป็นอื่น ๆ ไปยังไดเรกทอรีที่เหมาะสม.
- ลงทะเบียนฟีเจอร์ในฐานข้อมูล SharePoint และทำให้พร้อมใช้งานสำหรับการเปิดใช้งานตามขอบเขตของฟีเจอร์.
## **การเปิดใช้งาน**
Aspose.Slides for SharePoint ถูกบรรจุเป็นฟีเจอร์ระดับไซต์ (site collection) และสามารถเปิดหรือปิดใช้งานได้บน site collection. ในระหว่างการเปิดใช้งาน, ฟีเจอร์จะทำการเปลี่ยนแปลงบางอย่างในไดเรกทอรีเสมือนของเว็บแอปพลิเคชันแม่ของ site collection. ฟีเจอร์ทำดังต่อไปนี้: 

- เพิ่มหน้าการตั้งค่าแปลงลงในไฟล์ sitemap.
- คัดลอกไฟล์ทรัพยากรที่จำเป็นไปยังโฟลเดอร์ App_GlobalResources ในไดเรกทอรีเสมือน.