---
title: แปลงสไลด์ PowerPoint เป็น PNG บน Android
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/androidjava/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- การนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- Android
- Java
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **Overview**

บทความนี้อธิบายวิธีแปลงการนำเสนอ PowerPoint เป็นรูปภาพ PNG ด้วย Aspose.Slides. แสดงวิธีโหลดไฟล์การนำเสนอในรูปแบบต่าง ๆ เช่น PPT, PPTX, และ ODP, เรนเดอร์สไลด์เป็นภาพ, และบันทึกผลลัพธ์เป็นรูปแบบ PNG

บทความยังสาธิตวิธีปรับแต่งภาพ PNG ที่สร้างขึ้นโดยการตั้งค่าขนาดสเกลหรือระบุความกว้างและความสูงที่ต้องการ

## **Convert PowerPoint to PNG**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. ดึงวัตถุสไลด์จากคอลเลกชัน [Presentation.getSlides()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) ภายใต้อินเตอร์เฟซ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlide)
3. ใช้เมธอด [ISlide.getImage()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlide) เพื่อรับภาพย่อของแต่ละสไลด์
4. ใช้เมธอด [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) เพื่อบันทึกรูปภาพย่อของสไลด์เป็นรูปแบบ PNG

โค้ด Java นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to PNG with Custom Dimensions**

หากต้องการได้รับไฟล์ PNG ที่มีสเกลตามที่กำหนด คุณสามารถตั้งค่าตัวแปร `desiredX` และ `desiredY` ซึ่งกำหนดมิติของภาพย่อที่ได้

โค้ดใน Java นี้สาธิตการดำเนินการที่อธิบายไว้:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to PNG with Custom Size**

หากต้องการได้รับไฟล์ PNG ที่มีขนาดตามต้องการ คุณสามารถส่งค่า `width` และ `height` ที่ต้องการให้กับ `ImageSize`

โค้ดนี้แสดงวิธีแปลง PowerPoint เป็น PNG พร้อมระบุขนาดของภาพ:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันจะส่งออกเฉพาะรูปทรงที่กำหนด (เช่น แผนภูมิหรือรูปภาพ) แทนที่จะส่งออกทั้งสไลด์ได้อย่างไร?**

Aspose.Slides รองรับการสร้างภาพย่อสำหรับรูปทรงแต่ละรูปแบบ; คุณสามารถเรนเดอร์รูปทรงเป็นภาพ PNG

**การแปลงแบบขนานสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่, แต่[อย่าแชร์](/slides/th/androidjava/multithreading/)อินสแตนซ์การนำเสนอเดียวกันระหว่างเธรด. ใช้อินสแตนซ์แยกกันต่อแต่ละเธรดหรือกระบวนการ

**ข้อจำกัดของรุ่นทดลองเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินผลจะใส่น้ำตราบนภาพผลลัพธ์และบังคับใช้[ข้อจำกัดอื่น](/slides/th/androidjava/licensing/)จนกว่าจะมีการใช้ใบอนุญาต.