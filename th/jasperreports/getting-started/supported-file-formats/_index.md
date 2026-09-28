---
title: รูปแบบไฟล์ที่รองรับ
type: docs
weight: 20
url: /th/jasperreports/supported-file-formats/
description: "ดูว่า Aspose.Slides for JasperReports รับเป็นอินพุตอะไรและส่งออกรายงานเป็นรูปแบบไฟล์ใด"
---
## **ข้อมูลเข้า**

Aspose.Slides for JasperReports ส่งออกรายงาน; ไม่ได้แปลงงานนำเสนอที่มีอยู่แล้ว ผู้ส่งออกของมันรับรายงาน JasperReports ที่เติมเต็ม (`JasperPrint`) เช่น ผลลัพธ์ของ `JasperFillManager` หรือรายงานที่เติมเต็มที่โหลดจากไฟล์ *.jrprint*.

## **รูปแบบผลลัพธ์**

The following table lists the formats that Aspose.Slides for JasperReports exports a report to, and the exporter class that writes each one.

|**รูปแบบ**|**คำอธิบาย**|**ผู้ส่งออก**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|งานนำเสนอ PowerPoint 97–2003; หนึ่งสไลด์ต่อหนึ่งหน้ารายงาน|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|งานนำเสนอ PowerPoint (Office Open XML); หนึ่งสไลด์ต่อหนึ่งหน้ารายงาน|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; หนึ่งหน้ PDF ต่อหนึ่งหน้ารายงาน|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|ไฟล์ HTML เดียวที่มีภาพ SVG หนึ่งภาพต่อหนึ่งหน้ารายงาน|`ASHtmlExporter`|

There is no exporter for the PPS and PPSX slide show formats. Giving a PPTX export a *.ppsx* file name still produces a PPTX presentation, not a slide show. To see how each exporter is used, see [PPT, PPTX, PDF and HTML Export](/slides/th/jasperreports/ppt-pptx-pdf-and-html-export/).