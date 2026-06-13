---
title: การติดตั้งใบอนุญาต Aspose.Slides สำหรับ SharePoint
type: docs
weight: 10
url: /th/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

เมื่อคุณพอใจกับการประเมินของคุณแล้ว คุณสามารถ [ซื้อใบอนุญาต](https://purchase.aspose.com/buy). ก่อนทำการซื้อ กรุณาแน่ใจว่าคุณเข้าใจและยอมรับเงื่อนไขการสมัครสมาชิกของใบอนุญาต. ใบอนุญาตจะถูกส่งทางอีเมลให้คุณเมื่อคำสั่งซื้อได้รับการชำระเงินแล้ว.

ใบอนุญาตเป็นไฟล์ ZIP ที่บรรจุแพคเกจโซลูชัน SharePoint ธรรมดา ไฟล์ ZIP นี้ประกอบด้วย:

- Aspose.Slides.SharePoint.License.wsp – ไฟล์แพคเกจโซลูชัน SharePoint ใบอนุญาตถูกบรรจุเป็นโซลูชัน SharePoint เพื่อให้ง่ายต่อการปรับใช้และถอนออกในฟาร์มเซิร์ฟเวอร์
- readme.txt – คำแนะนำการติดตั้งใบอนุญาต.

{{% /alert %}} 
## **การปรับใช้ใบอนุญาต**
การติดตั้งใบอนุญาตทำจากคอนโซลเซิร์ฟเวอร์ผ่าน **stsadm.exe**.

{{% alert color="primary" %}} 

เส้นทางถูกละเว้นในส่วนต่อไปนี้เพื่อความกระชับ.

{{% /alert %}} 

ทำตามขั้นตอนต่อไปนี้เพื่อปรับใช้ใบอนุญาต Aspose.Slides สำหรับ SharePoint:

1. Run stsadm to add the solution to the SharePoint solution store: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Deploy the solution to all servers in the farm: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Execute administrative timer jobs to complete the deployment immediately: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

คุณจะได้รับคำเตือนเมื่อดำเนินการขั้นตอนการปรับใช้ หากบริการ Windows SharePoint Services Administration ไม่ทำงาน **stsadm.exe** พึ่งพาบริการนี้และ Windows SharePoint Timer Service เพื่อทำซ้ำข้อมูลโซลูชันทั่วฟาร์ม หากบริการเหล่านี้ไม่ได้ทำงานในฟาร์มเซิร์ฟเวอร์ของคุณ คุณอาจต้องปรับใช้ใบอนุญาตบนเซิร์ฟเวอร์แต่ละเครื่อง. 

{{% /alert %}} 
## **ทดสอบใบอนุญาต**
เพื่อทดสอบว่าใบอนุญาตติดตั้งอย่างถูกต้องหรือไม่ ให้แปลงเอกสารใด ๆ ไปเป็นรูปแบบใหม่ หากไม่มีลายน้ำการประเมินในเอกสาร แสดงว่าใบอนุญาตได้เปิดใช้งานสำเร็จ.