---
title: Aspose.Slides สำหรับ Reporting Services
second_title: Aspose.Slides สำหรับ Reporting Services
type: docs
weight: 50
url: /th/reportingservices/
keywords:
- เอกสาร
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- รายงานแบบหน้า
- RDL
- การส่งออก PowerPoint
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for Reporting Services, ส่งออกรายงานแรกเป็น PowerPoint, และค้นหารูปแบบการส่งออก, ความต้องการของระบบและการสนับสนุน."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Reporting Services" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Reporting Services เป็นส่วนขยายการแสดงผลสำหรับ Microsoft SQL Server Reporting Services และ Power BI Report Server ที่เพิ่มรูปแบบการนำเสนอในรายการส่งออกของรายงานแบบหน้ากระดาษ (RDL) โดยไม่ต้องใช้ Microsoft PowerPoint บนเซิร์ฟเวอร์

มันสามารถส่งออกรายงานเป็นไฟล์นำเสนอ PPT, PPTX, PPS และ PPSX รวมถึงการแสดงสไลด์, ODP, และ XPS

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นการใช้งาน</p>
<ul>
<li><a href="/slides/th/reportingservices/installing-aspose-slides-for-reporting-services/">การติดตั้ง</a></li>
<li><a href="/slides/th/reportingservices/system-requirements/">ความต้องการของระบบ</a></li>
<li><a href="/slides/th/reportingservices/install-with-msi-installer/">ติดตั้งด้วยตัวติดตั้ง MSI</a></li>
<li><a href="/slides/th/reportingservices/install-manually/">ติดตั้งด้วยตนเอง</a></li>
<li><a href="/slides/th/reportingservices/power-bi/">ติดตั้งบน Power BI Report Server</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/reportingservices/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/reportingservices/evaluate-aspose-slides/">ข้อจำกัดของรุ่นทดลอง</a></li>
<li><a href="/slides/th/reportingservices/license-aspose-slides-for-reporting-services/">การให้สิทธิ์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>ส่งออก</p>
<ul>
<li><a href="/slides/th/reportingservices/support-for-embedding-audio-in-presentation/">ฝังเสียงในไฟล์ PPTX</a></li>
<li><a href="/slides/th/reportingservices/paginated-reports/">รายงานแบบหน้ากระดาษจาก Power BI Report Builder</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/reportingservices/sample-reports-gallery/">แกลเลอรีรายงานตัวอย่าง</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและการสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://releases.aspose.com/slides/reportingservices/release-notes/">บันทึกประจำรุ่น</a></li>
<li><a href="https://releases.aspose.com/slides/reportingservices/">ดาวน์โหลด</a></li>
</ul>
<p>สนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรัมสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **การส่งออกครั้งแรกของคุณ**

ไม่มีโค้ดให้เขียน: คุณทำการติดตั้งส่วนขยายบนเซิร์ฟเวอร์รายงาน และรูปแบบต่าง ๆ จะปรากฏในรายการส่งออกรายงานแบบหน้ากระดาษทุกอันบนเซิร์ฟเวอร์นั้น

1. ตรวจสอบว่าเซิร์ฟเวอร์รายงานตรงตาม [ความต้องการของระบบ](/slides/th/reportingservices/system-requirements/), รวมถึง .NET Framework 3.5.
1. จาก [หน้า ดาวน์โหลด](https://releases.aspose.com/slides/reportingservices/), ดาวน์โหลดตัวติดตั้ง MSI, *Aspose.Slides for Reporting Services*. หากต้องการติดตั้งด้วยตนเอง, ดาวน์โหลดแพคเกจ ZIP, *Aspose.Slides for Reporting Services (DLLs Only)*.
1. ติดตั้งส่วนขยายบนเซิร์ฟเวอร์รายงาน: รันไฟล์ MSI ในฐานะผู้ดูแลระบบ ตามที่อธิบายใน [ติดตั้งด้วยตัวติดตั้ง MSI](/slides/th/reportingservices/install-with-msi-installer/), หรือทำตามขั้นตอนใน [ติดตั้งด้วยตนเอง](/slides/th/reportingservices/install-manually/) สำหรับแพคเกจ ZIP.
1. ในเบราว์เซอร์, เปิดพอร์ทัลเว็บของเซิร์ฟเวอร์รายงาน (Report Manager บน SQL Server 2014 และก่อนหน้า). โดยค่าเริ่มต้น, ที่อยู่คือ `https://<ComputerName>/reports`.
1. เปิดรายงานแบบหน้ากระดาษ. บนแถบเครื่องมือของรายงาน, เปิดรายการ **Export** แล้วเลือก **PPTX - PowerPoint 2007 Presentation via Aspose.Slides**. หากแถบเครื่องมือมีปุ่ม **Export** แยกต่างหาก, เช่นเดียวกับ Report Manager, ให้คลิกที่ปุ่มนั้น.
1. เปิดหรือบันทึกไฟล์ PPTX ที่เบราว์เซอร์ดาวน์โหลด.

หากไม่มีใบอนุญาต, การนำเสนอที่ส่งออกจะมีลายน้ำการประเมิน — ดูที่ [การให้สิทธิ์](/slides/th/reportingservices/license-aspose-slides-for-reporting-services/). สำหรับรูปแบบอื่น ๆ ในรายการส่งออก, โปรดดูที่ [รูปแบบไฟล์ที่รองรับ](/slides/th/reportingservices/supported-file-formats/).