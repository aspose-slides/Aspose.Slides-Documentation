---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน Java
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ Java เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็นรูปภาพ PNG ด้วย Aspose.Slides โดยแสดงวิธีโหลดไฟล์งานนำเสนอในรูปแบบเช่น PPT, PPTX และ ODP, แสดงสไลด์เป็นภาพ, และบันทึกผลลัพธ์เป็นรูปแบบ PNG

บทความนี้ยังสาธิตวิธีกำหนดค่าภาพ PNG ที่สร้างขึ้นโดยการตั้งค่าค่าการสเกลหรือระบุความกว้างและความสูงที่ต้องการ

## **แปลง PowerPoint เป็น PNG**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับวัตถุสไลด์จากคอลเลกชัน [Presentation.getSlides()](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) ภายใต้อินเตอร์เฟส [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide)  
3. ใช้เมธอด [ISlide.getImage()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) เพื่อรับภาพย่อของแต่ละสไลด์  
4. ใช้เมธอด [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) เพื่อบันทึกภาพย่อของสไลด์เป็นรูปแบบ PNG  

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

## **แปลง PowerPoint เป็น PNG ด้วยมิติที่กำหนดเอง**

หากต้องการได้ไฟล์ PNG ที่มีสเกลเฉพาะ คุณสามารถตั้งค่าตัวแปร `desiredX` และ `desiredY` ซึ่งกำหนดมิตของภาพย่อที่ได้  

โค้ดนี้ใน Java แสดงการดำเนินการตามที่อธิบายไว้:  

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

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

หากต้องการได้ไฟล์ PNG ที่มีขนาดเฉพาะ คุณสามารถส่งอาร์กิวเมนต์ `width` และ `height` ที่ต้องการสำหรับ `ImageSize`  

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

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกเฉพาะรูปทรงที่กำหนด (เช่น แผนภูมิหรือรูปภาพ) แทนที่จะส่งออกทั้งสไลด์ได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างภาพย่อสำหรับรูปทรงแต่ละอัน](/slides/th/java/create-shape-thumbnails/); คุณสามารถแสดงผลรูปทรงเป็นภาพ PNG ได้  

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่, แต่ [อย่าแชร์](/slides/th/java/multithreading/) อินสแตนซ์งานนำเสนอเดียวกันข้ามเธรด. ใช้อินสแตนซ์แยกสำหรับแต่ละเธรดหรือกระบวนการ  

**ข้อจำกัดของเวอร์ชันทดลองเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินผลจะเพิ่มลายน้ำในภาพที่ส่งออกและบังคับใช้ [ข้อจำกัดอื่น](/slides/th/java/licensing/) จนกว่าจะมีการใช้ใบอนุญาต