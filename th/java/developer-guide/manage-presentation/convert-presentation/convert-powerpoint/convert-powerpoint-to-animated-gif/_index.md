---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF แบบเคลื่อนไหวใน Java
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/java/convert-powerpoint-to-animated-gif/
keywords:
- GIF แบบเคลื่อนไหว
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
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF แบบเคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Java. ผลลัพธ์รวดเร็วและคุณภาพสูง."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF แบบเคลื่อนไหวได้ด้วยเพียงไม่กี่บรรทัดของโค้ด นี้มีประโยชน์เมื่อคุณต้องการแชร์เนื้อหาแบบสไลด์ในรูปแบบที่มีน้ำหนักเบาและรองรับอย่างกว้างขวางซึ่งสามารถฝังลงในหน้าเว็บ, แอปแชท หรือเอกสารได้ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF ด้วยการตั้งค่าเริ่มต้นและวิธีการปรับแต่งผลลัพธ์โดยกำหนดค่าตัวเลือกต่าง ๆ เช่น ขนาดเฟรม, ความหน่วงของสไลด์, และอัตราเฟรมของการเปลี่ยนผ่าน ผ่าน [GifOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/gifoptions/).

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

GIF แบบเคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น 

{{%  alert  title="TIP"  color="info"  %}} 

หากคุณต้องการปรับแต่งพารามิเตอร์สำหรับ GIF คุณสามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/GifOptions) ได้ ดูโค้ดตัวอย่างด้านล่าง. 

{{% /alert %}} 

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ากำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ากำหนดเองใน Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // ขนาดของ GIF ที่ได้  
	gifOptions.setDefaultDelay(2000); // ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนเปลี่ยนเป็นสไลด์ถัดไป
	gifOptions.setTransitionFps(35); // เพิ่ม FPS เพื่อปรับปรุงคุณภาพการเคลื่อนไหวของการเปลี่ยนผ่าน
	
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

ติดตั้งฟอนต์ที่ขาดหายไปหรือ [กำหนดค่าฟอนต์สำรอง](/slides/th/java/powerpoint-fonts/). Aspose.Slides จะทำการแทนที่ แต่รูปแบบอาจแตกต่างกัน สำหรับการสร้างแบรนด์ควรตรวจสอบให้แน่ใจว่าฟอนต์ที่ต้องการพร้อมใช้งานอย่างชัดเจน.

### ฉันสามารถใส่ลายน้ำบนเฟรมของ GIF ได้หรือไม่?

ได้. [เพิ่มวัตถุ/โลโก้กึ่งโปร่งใส](/slides/th/java/watermark/) ไปยังสไลด์หลักหรือสไลด์แต่ละสไลด์ก่อนการส่งออก — ลายน้ำจะปรากฏบนทุกเฟรม.