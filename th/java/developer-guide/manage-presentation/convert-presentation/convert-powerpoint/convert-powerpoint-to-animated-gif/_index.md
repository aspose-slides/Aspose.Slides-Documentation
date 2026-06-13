---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF แบบเคลื่อนไหวใน Java
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/java/convert-powerpoint-to-animated-gif/
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
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF แบบเคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Java ผลลัพธ์เร็วและมีคุณภาพสูง"
---
## **ภาพรวม**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF แบบเคลื่อนไหวด้วยเพียงไม่กี่บรรทัดของโค้ด ซึ่งเป็นประโยชน์เมื่อคุณต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่มีขนาดเล็ก รองรับอย่างกว้างขวาง และสามารถฝังลงในหน้าเว็บ โปรแกรมส่งข้อความ หรือเอกสารได้ บทความนี้อธิบายวิธีการส่งออกงานนำเสนอเป็น GIF โดยใช้การตั้งค่าเริ่มต้นและวิธีการปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกต่าง ๆ เช่น ขนาดเฟรม ความหน่วงของสไลด์ และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/gifoptions/)  

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

โค้ดตัวอย่างนี้ใน Java แสดงวิธีการแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

GIF แบบเคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น.  

{{%  alert  title="TIP"  color="primary"  %}} 
หากคุณต้องการปรับแต่งพารามิเตอร์สำหรับ GIF คุณสามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/GifOptions) ได้ ดูตัวอย่างโค้ดด้านล่าง.  
{{% /alert %}} 

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าแบบกำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีการแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าแบบกำหนดเองใน Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // ขนาดของ GIF ที่ได้  
	gifOptions.setDefaultDelay(2000); // ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนจะเปลี่ยนเป็นสไลด์ถัดไป
	gifOptions.setTransitionFps(35); // เพิ่ม FPS เพื่อคุณภาพการเคลื่อนไหวของการเปลี่ยนภาพที่ดียิ่งขึ้น
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
คุณอาจต้องการลองใช้ตัวแปลง **ฟรี** [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ที่พัฒนาโดย Aspose.  
{{% /alert %}}

## **FAQ**

**หากฟอนต์ที่ใช้ในงานนำเสนอไม่ได้ติดตั้งในระบบจะทำอย่างไร?**

ติดตั้งฟอนต์ที่ขาดหายไปหรือ [กำหนดฟอนต์สำรอง](/slides/th/java/powerpoint-fonts/). Aspose.Slides จะทำการแทนที่ แต่รูปแบบการแสดงผลอาจแตกต่างกัน สำหรับการสร้างแบรนด์ ควรตรวจสอบให้แน่ใจว่าฟอนต์ที่จำเป็นมีให้ใช้อย่างชัดเจน

**ฉันสามารถใส่ลายน้ำบนเฟรมของ GIF ได้หรือไม่?**

ได้. [เพิ่มวัตถุ/โลโก้ที่มีความโปร่งใสบางส่วน](/slides/th/java/watermark/) ลงในสไลด์หลักหรือสไลด์แต่ละสไลด์ก่อนการส่งออก — ลายน้ำจะปรากฏในทุกเฟรม.