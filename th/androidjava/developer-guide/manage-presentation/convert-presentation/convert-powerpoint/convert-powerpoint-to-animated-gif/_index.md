---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF แบบเคลื่อนไหวบน Android
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- GIF เคลื่อนไหว
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น GIF
- งานนำเสนอเป็น GIF
- สไลด์เป็น GIF
- PPT เป็น GIF
- PPTX เป็น GIF
- บันทึก PPT เป็น GIF
- บันทึก PPTX เป็น GIF
- ส่งออก PPT เป็น GIF
- ส่งออก PPTX เป็น GIF
- การตั้งค่าเริ่มต้น
- การตั้งค่ากำหนดเอง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF เคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ผลลัพธ์ที่รวดเร็วและคุณภาพสูง."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF แบบเคลื่อนไหวได้ด้วยเพียงไม่กี่บรรทัดของโค้ด สิ่งนี้เป็นประโยชน์เมื่อต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่มีขนาดเล็ก รองรับอย่างกว้างขวางและสามารถฝังในหน้าเว็บ แอปแชท หรือเอกสารได้ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF ด้วยการตั้งค่าเริ่มต้นและวิธีปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกต่าง ๆ เช่น ขนาดเฟรม, ความล่าช้าของสไลด์, และอัตราเฟรมของการเปลี่ยนผ่าน ผ่าน [GifOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/gifoptions/)  

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

โค้ดตัวอย่างนี้ใน Java แสดงวิธีแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

GIF แบบเคลื่อนไหวจะถูกสร้างด้วยค่าพารามิเตอร์เริ่มต้น  

{{%  alert  title="TIP"  color="info"  %}} 
หากคุณต้องการปรับแต่งพารามิเตอร์ของ GIF, คุณสามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GifOptions) ได้ ดูโค้ดตัวอย่างด้านล่าง.  
{{% /alert %}} 

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าแบบกำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าแบบกำหนดเองใน Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // ขนาดของ GIF ที่ได้
	gifOptions.setDefaultDelay(2000); // ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนเปลี่ยนเป็นสไลด์ถัดไป
	gifOptions.setTransitionFps(35); // เพิ่ม FPS เพื่อคุณภาพการเคลื่อนไหวของการเปลี่ยนผ่านที่ดียิ่งขึ้น

	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
คุณอาจต้องการลองใช้ตัวแปลง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ฟรีที่พัฒนาโดย Aspose.  
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ถ้าฟอนต์ที่ใช้ในงานนำเสนอไม่ได้ติดตั้งในระบบจะทำอย่างไร?

ให้ติดตั้งฟอนต์ที่ขาดหายไปหรือ[กำหนดฟอนต์สำรอง](/slides/th/androidjava/powerpoint-fonts/). Aspose.Slides จะทำการแทนที่ แต่การแสดงผลอาจแตกต่างกัน สำหรับการสร้างแบรนด์ ควรตรวจสอบให้แน่ใจว่าฟอนต์ที่จำเป็นพร้อมให้ใช้งานอย่างชัดเจน  

### ฉันสามารถใส่วอทมาร์คทับบนเฟรมของ GIF ได้หรือไม่?

ได้. [เพิ่มออบเจ็กต์/โลโก้ที่มีความโปร่งใสบางส่วน](/slides/th/androidjava/watermark/) ไปยังสไลด์มาสเตอร์หรือสไลด์แต่ละสไลด์ก่อนส่งออก — วอทมาร์คจะปรากฏบนทุกเฟรม  