---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF แบบเคลื่อนไหวบน Android
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/androidjava/convert-powerpoint-to-animated-gif/
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
- การตั้งค่าที่กำหนดเอง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF แบบเคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java ผลลัพธ์เร็วและคุณภาพสูง"
---
## **Overview**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF แบบเคลื่อนไหวได้เพียงไม่กี่บรรทัดของโค้ด ซึ่งเป็นประโยชน์เมื่อคุณต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่เบา รองรับอย่างกว้างขวางและสามารถฝังในเว็บเพจ แชทเมสเซนเจอร์ หรือเอกสารได้ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF ด้วยการตั้งค่าเริ่มต้นและวิธีปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกต่าง ๆ เช่น ขนาดเฟรม เวลาหน่วงสไลด์ และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/gifoptions/).

## **Convert Presentations to Animated GIF Using Default Settings**

This sample code in Java shows you how to convert a presentation to animated GIF using standard settings:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GifOptions) class. See the sample code below.

{{% /alert %}} 

## **Convert Presentations to Animated GIF Using Custom Settings**

This sample code shows you how to convert a presentation to animated GIF using custom settings in Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // ขนาดของ GIF ที่ได้  
	gifOptions.setDefaultDelay(2000); // ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนเปลี่ยนไปสไลด์ถัดไป
	gifOptions.setTransitionFps(35); // เพิ่ม FPS เพื่อคุณภาพการเคลื่อนไหวระหว่างการเปลี่ยนหน้าที่ดียิ่งขึ้น
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

You may want to check out a FREE [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) converter developed by Aspose. 

{{% /alert %}}

## **FAQ**

**What if the fonts used in the presentation aren’t installed on the system?**

Install the missing fonts or [configure fallback fonts](/slides/th/androidjava/powerpoint-fonts/). Aspose.Slides will substitute, but the appearance may differ. For branding, always ensure the required typefaces are explicitly available.

**Can I overlay a watermark on the GIF frames?**

Yes. [Add a semi-transparent object/logo](/slides/th/androidjava/watermark/) to the master slide or to individual slides before export — the watermark will appear on every frame.