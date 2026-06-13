---
title: คำถามที่พบบ่อย
type: docs
weight: 110
url: /th/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

หน้านี้รวบรวมคำถามที่พบบ่อยหลายข้อเกี่ยวกับ:

- [รูปแบบไฟล์ที่รองรับ](#Supported-File-Formats).
- [การสนับสนุนสำหรับ Power BI Reporting services](#Support-for-Power-BI-Reporting-services).
- [การติดตั้ง](#Installation).
- [การกำหนดค่าการส่งออก](#Export-Configuration).

{{% /alert %}} 
### **รูปแบบไฟล์ที่รองรับ**
#### **Q: ฟอร์แมตใดบ้างที่คุณสามารถส่งออกรายงานโดยใช้ Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services ทำให้สามารถส่งออกรายงานใด ๆ เป็นรูปแบบ PPT, PPS, PPTX, PPSX, XPS หรือ RPL ได้
### **การสนับสนุนสำหรับ Power BI Reporting services**
#### **Q: Aspose.Slides for Reporting Services รองรับ Power BI หรือไม่?**
**A**: ใช่. Aspose.Slides for Reporting Services รองรับการส่งออกรายงานแบบแบ่งหน้า (RDL) ใน Power BI.
### **การติดตั้ง**
#### **Q: โปรแกรมติดตั้งไม่เริ่มทำงาน การติดตั้งด้วยมือไม่ได้นำไปสู่ผลลัพธ์ที่ต้องการ.**
**A** : ตรวจสอบให้แน่ใจว่า .NET Framework 3.5 ติดตั้งอยู่ในระบบของคุณ.
#### **Q: ตัวเลือกรายการส่งออกหายไปหลังการติดตั้ง Aspose.Slides for Reporting Services.**
**A**: หากมี CodeGroup ใดใน rssrvpolicy.config ไม่ทำงานอย่างถูกต้อง ตัวแยกวิเคราะห์ไฟล์กำหนดค่าอาจข้ามส่วนสุดท้ายของกลุ่ม ดังนั้นให้ย้าย CodeGroup ทั้งหมดที่เกี่ยวข้องกับ Aspose.Slides for Reporting Services ไปยังด้านบนของบล็อกที่มี Aspose.Slides for Reporting Services CodeGroups.
#### **Q: ไม่สามารถโหลดไฟล์หรือแอสเซมบลี Aspose.Slides.ReportingServices (ไม่สามารถรับสิทธิ์การดำเนินการ \ Exception from HRESULT: 0x80131418).**
**A**: รหัสข้อผิดพลาด (0x80131418) บ่งชี้ว่าโมดูล dll ไม่มีสิทธิ์เพียงพอ สิ่งนี้อาจเกิดจากคุณสมบัติความปลอดภัยที่บล็อกการเข้าถึงเต็มของไฟล์ .dll หากไฟล์มาจากคอมพิวเตอร์เครื่องอื่น สามารถแก้ไขได้โดยเปิดหน้าต่างคุณสมบัติของไฟล์ dll แล้วคลิกปุ่ม “Unblock” ในแผง “Security”.
#### **Q: ไม่พบไฟล์ใบอนุญาต 'Aspose.Slides.Reporting.Services.lic'.**
**A**: ไฟล์ใบอนุญาตต้องอยู่ใกล้กับ dll หรือในไดเรกทอรี Program Files(x86)\\Aspose\\Slides\\.
### **การกำหนดค่าการส่งออก**
#### **Q: ฉันจะเปลี่ยนสีของลิงก์ในรายงานที่ส่งออกได้อย่างไร?**
**A**: แต่ละส่วนขยายการแสดงผลของ Aspose.Slides for Reporting Services ใน rsreportserver.config มีการกำหนดค่าของตนเอง เพื่อเปลี่ยนสีของลิงก์ ให้ตั้งค่าที่ต้องการในส่วน <HyperlinkColor>.
#### **Q: ในงานนำเสนอที่ส่งออก ข้อความในตารางจะถูกยืดในแนวตั้ง.**
**A**: สิ่งนี้ทำเพื่อให้เอกสารอ่านง่ายขึ้น หากต้องการแสดงข้อความในตารางตามที่ปรากฏในรายงาน ให้ตั้งค่าส่วนขยาย Aspose.Slides for Reporting Services ที่ต้องการเป็น “Normal” ในไฟล์การกำหนดค่า rsreportserver.config.