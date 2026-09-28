---
title: การติดตั้งใบอนุญาต Aspose.Slides สำหรับ SharePoint
type: docs
weight: 10
url: /th/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "ติดตั้งใบอนุญาต Aspose.Slides สำหรับ SharePoint บนฟาร์ม SharePoint: เพิ่มโซลูชันใบอนุญาตลงในที่เก็บโซลูชัน, ปรับใช้, และตรวจสอบว่าไฟล์ที่แปลงแล้วไม่แสดงลายน้ำการประเมินอีกต่อไป"
---
{{% alert color="info" title="Note" %}}
เมื่อคุณพอใจกับการประเมินแล้ว คุณสามารถ [ซื้อใบอนุญาต](https://purchase.aspose.com/pricing/slides/sharepoint/) ได้ ก่อนทำการซื้อ โปรดตรวจสอบว่าคุณเข้าใจและยอมรับเงื่อนไขการสมัครสมาชิกของใบอนุญาต ใบอนุญาตจะถูกส่งทางอีเมลให้คุณเมื่อคำสั่งซื้อได้รับการชำระเงิน

ใบอนุญาตเป็นไฟล์ ZIP ที่บรรจุแพ็คเกจโซลูชัน SharePoint ธรรมดา ไฟล์ ZIP มีเนื้อหาดังต่อไปนี้:

- Aspose.Slides.SharePoint.License.wsp – ไฟล์แพ็คเกจโซลูชัน SharePoint. ใบอนุญาตถูกบรรจุเป็นโซลูชัน SharePoint เพื่อทำให้การปรับใช้และการดึงออกในฟาร์มเซิร์ฟเวอร์ทำได้ง่าย
- readme.txt – คำแนะนำการติดตั้งใบอนุญาต
{{% /alert %}}

## **การปรับใช้ใบอนุญาต**

การติดตั้งใบอนุญาตทำจากคอนโซลของเซิร์ฟเวอร์ผ่าน **stsadm.exe**.

{{% alert color="info" title="Note" %}}
เส้นทางจะถูกละเว้นในส่วนต่อไปนี้เพื่อความชัดเจน.
{{% /alert %}}

ทำตามขั้นตอนต่อไปนี้เพื่อปรับใช้ใบอนุญาต Aspose.Slides for SharePoint:

1. เรียกใช้ stsadm เพื่อเพิ่มโซลูชันเข้าสู่ที่เก็บโซลูชันของ SharePoint:
   
   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. ปรับใช้โซลูชันไปยังเซิร์ฟเวอร์ทั้งหมดในฟาร์ม:
   
   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. ดำเนินการงานตัวจับเวลาแบบผู้ดูแลเพื่อให้การปรับใช้เสร็จสมบูรณ์ทันที:
   
   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

`addsolution` รับพาธของไฟล์โซลูชันใน `-filename`; `deploysolution` รับชื่อของโซลูชันที่มีอยู่แล้วในที่เก็บโซลูชันใน `-name`.

{{% alert color="info" title="Note" %}}
คุณจะได้รับคำเตือนเมื่อทำขั้นตอนการปรับใช้หากบริการ SharePoint Administration ไม่ทำงาน **stsadm.exe** พึ่งพาบริการนี้และบริการ SharePoint Timer เพื่อทำสำเนาข้อมูลโซลูชันทั่วฟาร์ม หากบริการเหล่านี้ไม่ทำงานในฟาร์มเซิร์ฟเวอร์ของคุณ คุณอาจต้องปรับใช้ใบอนุญาตบนแต่ละเซิร์ฟเวอร์
{{% /alert %}}

{{% alert color="info" title="Note" %}}
บน SharePoint 2010 และรุ่นต่อมา คำสั่งของ SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` และ `Start-SPAdminJob` สอดคล้องกับการดำเนินการ `addsolution`, `deploysolution` และ `execadmsvcjobs` ดูที่ [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).
{{% /alert %}}

## **ทดสอบใบอนุญาต**

เพื่อตรวจสอบว่าใบอนุญาตติดตั้งอย่างถูกต้อง ให้แปลงงานนำเสนอใด ๆ ไปเป็นรูปแบบใหม่ หากไม่มีลายน้ำการประเมินในไฟล์ที่แปลงแล้ว ใบอนุญาตจะทำงาน