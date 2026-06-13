---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout บน Android
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารแจก
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารแจกใน Java. ตั้งค่าสไลด์ต่อหน้า, รักษาโน้ต, ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด. ลองใช้ฟรี."
---
## **บทนำ**

Aspose.Slides มีความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารแจกสำหรับพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดวิธีการแสดงสไลด์หลาย ๆ สไลด์ในหนึ่งหน้า ทำให้เหมาะสำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้โดยตั้งค่าเมธอด `setSlidesLayoutOptions` ในอินเทอร์เฟซ [IPdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) 

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหนึ่งหน้าและพารามิเตอร์การแสดงผลอื่น ๆ  

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout  

```java
// โหลดงานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
	// ตั้งค่าตัวเลือกการส่งออก.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 สไลด์ต่อหน้าในแนวนอน
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // พิมพ์หมายเลขสไลด์
	slidesLayoutOptions.setPrintFrameSlide(true);                     // พิมพ์กรอบรอบสไลด์
	slidesLayoutOptions.setPrintComments(false);                      // ไม่มีความคิดเห็น

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// ส่งออกงานนำเสนอเป็น PDF ด้วยการจัดเรียงที่เลือก.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่ามีเมธอด `setSlidesLayoutOptions` มีให้ใช้เฉพาะรูปแบบผลลัพธ์บางประเภท เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ  
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพย่อของสไลด์ต่อหน้าที่มากที่สุดในโหมด Handout คือเท่าใด?**  

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า โดยเรียงตามแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).  

**ฉันสามารถกำหนดกริดแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**  

ไม่มี. จำนวนและการเรียงลำดับของภาพย่อถูกควบคุมโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handouttype/) อย่างเคร่งครัด; ไม่รองรับการจัดเรียงแบบกำหนดเอง.  

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**  

ได้. เปิดใช้งานสไลด์ที่ซ่อนอยู่โดยใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/).