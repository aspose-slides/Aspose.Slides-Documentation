---
title: เปลี่ยนขนาดสไลด์ของงานนำเสนอใน Java
linktitle: ขนาดสไลด์
type: docs
weight: 70
url: /th/java/slide-size/
keywords:
  - ขนาดสไลด์
  - อัตราส่วนภาพ
  - มาตรฐาน
  - หน้าจอกว้าง
  - 4:3
  - 16:9
  - ตั้งค่าขนาดสไลด์
  - เปลี่ยนขนาดสไลด์
  - ขนาดสไลด์แบบกำหนดเอง
  - ขนาดสไลด์พิเศษ
  - ขนาดสไลด์ที่เป็นเอกลักษณ์
  - สไลด์ขนาดเต็ม
  - ประเภทหน้าจอ
  - ไม่ปรับขนาด
  - ให้พอดี
  - ขยายให้เต็ม
  - PowerPoint
  - OpenDocument
  - presentation
  - Java
  - Aspose.Slides
description: "เรียนรู้วิธีปรับขนาดสไลด์อย่างรวดเร็วในไฟล์ PPT, PPTX และ ODP ด้วย Java และ Aspose.Slides, ปรับแต่งงานนำเสนอให้เหมาะกับทุกหน้าจอโดยไม่สูญเสียคุณภาพ."
---
## **Introduction**

Aspose.Slides มีเครื่องมือที่ครบถ้วนสำหรับปรับขนาดสไลด์และอัตราส่วนภาพในงานนำเสนอ PowerPoint ซึ่งสำคัญทั้งสำหรับการพิมพ์และการแสดงผลบนหน้าจอ  

ขนาดสไลด์และอัตราส่วนที่นิยม:

- **Standard (4:3 Aspect Ratio)**: เหมาะสำหรับหน้าจอและอุปกรณ์รุ่นเก่า
- **Widescreen (16:9 Aspect Ratio)**: แนะนำสำหรับเครื่องฉายภาพและจอแสดงผลสมัยใหม่

ควรรักษาความสอดคล้องตลอดงานนำเสนอโดยใช้ขนาดสไลด์และอัตราส่วนภาพเดียวกันสำหรับทุกสไลด์ เพื่อผลลัพธ์ที่ดีที่สุด ควรกำหนดขนาดสไลด์ตั้งแต่เริ่มสร้างงานนำเสนอเพื่อหลีกเลี่ยงปัญหาในภายหลัง

{{% alert color="primary" %}} 
โดยค่าเริ่มต้น งานนำเสนอที่สร้างด้วย Aspose.Slides จะใช้อัตราส่วน 4:3 มาตรฐาน
{{% /alert %}}

## **Change the Slide Size in Presentations**

 ตัวอย่างโค้ดนี้แสดงวิธีการเปลี่ยนขนาดสไลด์ในงานนำเสนอด้วย Java และ Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specify Custom Slide Sizes in Presentations**

หากขนาดสไลด์ทั่วไป (4:3 และ 16:9) ไม่เหมาะกับงานของคุณ คุณอาจต้องการใช้ขนาดสไลด์ที่กำหนดเองหรือเป็นเอกลักษณ์ ตัวอย่างเช่น หากคุณต้องการพิมพ์สไลด์เต็มขนาดจากงานนำเสนอบนรูปแบบหน้ากระดาษที่กำหนดเอง หรือหากต้องการแสดงงานนำเสนอบนประเภทหน้าจอบางประเภท การตั้งค่าขนาดสไลด์ที่กำหนดเองจะช่วยให้คุณได้ประโยชน์มากขึ้น

ตัวอย่างโค้ดนี้แสดงวิธีการใช้ Aspose.Slides for Java เพื่อกำหนดขนาดสไลด์ที่กำหนดเองสำหรับงานนำเสนอใน Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // ขนาดกระดาษ A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Handle Slide Content After Resizing**

หลังจากคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ เนื้อหาในสไลด์ (เช่น ภาพหรือวัตถุ) อาจเกิดการบิดเบี้ยว โดยค่าเริ่มต้น วัตถุจะถูกปรับขนาดโดยอัตโนมัติเพื่อให้พอดีกับขนาดสไลด์ใหม่ อย่างไรก็ตาม เมื่อเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณสามารถกำหนดการตั้งค่าที่กำหนดวิธีการที่ Aspose.Slides จัดการกับเนื้อหาในสไลด์ได้

ขึ้นอยู่กับสิ่งที่คุณต้องการทำหรือบรรลุ คุณสามารถใช้ตั้งค่าเหล่านี้ได้:

- `DoNotScale`

  ถ้าคุณ **ไม่ต้องการ** ให้วัตถุในสไลด์ถูกปรับขนาด ให้ใช้การตั้งค่านี้

- `EnsureFit`

  หากคุณต้องการปรับสัดส่วนให้เล็กลงและต้องการให้ Aspose.Slides ย่อวัตถุในสไลด์เพื่อให้ทั้งหมดพอดีบนสไลด์ (ช่วยหลีกเลี่ยงการสูญเสียเนื้อหา) ให้ใช้การตั้งค่านี้

- `Maximize`

  หากคุณต้องการปรับสัดส่วนให้ใหญ่ขึ้นและต้องการให้ Aspose.Slides ขยายวัตถุในสไลด์ให้สัดส่วนตรงกับขนาดสไลด์ใหม่ ให้ใช้การตั้งค่านี้

ตัวอย่างโค้ดนี้แสดงวิธีการใช้การตั้งค่า `Maximize` เมื่อเปลี่ยนขนาดสไลด์ของงานนำเสนอ:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

Yes. Aspose.Slides uses points internally, where 1 point equals 1/72 of an inch. You can convert any unit (such as millimeters or centimeters) to points and use the converted values to define slide width and height.

**Will a very large custom slide size affect performance and memory usage during rendering?**

Yes. Larger slide dimensions (in points) combined with higher rendering scale lead to increased memory consumption and longer processing times. Aim for a practical slide size and adjust rendering scale only as needed to achieve the desired output quality.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

You can’t [merge presentations](/slides/th/java/merge-presentation/) while they have different slide sizes — first, resize one presentation to match the other. When changing the slide size, you can choose how existing content is handled via the [SlideSizeScaleType](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesizescaletype/) option. After aligning sizes, you can merge slides while preserving formatting.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

Yes. Aspose.Slides can render thumbnails for [entire slides](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) as well as for [selected shapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-). The resulting images reflect the current slide size and aspect ratio, ensuring consistent framing and geometry.