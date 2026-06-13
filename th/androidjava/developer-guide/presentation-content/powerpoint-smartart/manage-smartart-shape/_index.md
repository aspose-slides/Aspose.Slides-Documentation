---
title: จัดการกราฟิก SmartArt ในงานนำเสนอบน Android
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/androidjava/manage-smartart-shape/
keywords:
- อ็อบเจ็กต์ SmartArt
- กราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยน SmartArt
- เข้าถึง SmartArt
- ประเภทการจัดวาง SmartArt
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "อัตโนมัติการสร้าง, แก้ไข และจัดสไตล์ SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด Java ที่สั้นกระชับและคำแนะนำที่มุ่งเน้นประสิทธิภาพ."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสร้างและจัดการกราฟิก SmartArt ในงานนำเสนอ PowerPoint ด้วยโปรแกรม บทความนี้อธิบายวิธีเพิ่มรูปแบบ SmartArt ลงในสไลด์, เข้าถึงรูปแบบ SmartArt ที่มีอยู่, ค้นหา SmartArt ตามประเภทการจัดรูปแบบเฉพาะ, และอัปเดตลักษณะการแสดงผลโดยการเปลี่ยนสไตล์หรือสไตล์สีของ SmartArt

ตัวอย่างแสดงวิธีทำงานกับรูปแบบ SmartArt ผ่านคอลเลกชันรูปร่างของสไลด์ในงานนำเสนอ, ตรวจสอบว่ารูปร่างเป็น SmartArt หรือไม่ แล้วทำการแก้ไขหรือสอบสอบคุณสมบัติต่าง ๆ ของมัน

## **สร้างรูปแบบ SmartArt**
Aspose.Slides สำหรับ Android ผ่าน Java ได้จัดเตรียม API สำหรับสร้างรูปแบบ SmartArt เพื่อสร้างรูปแบบ SmartArt ในสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) .
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน .
3. [Add a SmartArt shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) โดยกำหนด [LayoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType) .
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX .

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปแบบ Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // บันทึกงานนำเสนอ
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**รูปภาพ: รูปแบบ SmartArt ถูกเพิ่มลงในสไลด์**|

## **เข้าถึงรูปแบบ SmartArt บนสไลด์**
โค้ดต่อไปนี้จะใช้เพื่อเข้าถึงรูปแบบ SmartArt ที่เพิ่มในสไลด์ของงานนำเสนอ ในตัวอย่างโค้ดเราจะวนตรวจสอบทุกรูปภายในสไลด์และตรวจสอบว่ามันเป็นรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) หรือไม่ หากเป็นประเภท SmartArt เราจะทำการแคสท์เป็นอินสแตนซ์ของ [**SmartArt**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) .

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // วนตรวจสอบทุกรูปร่างภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt)
        {
            // แคสท์รูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงรูปแบบ SmartArt ที่มี LayoutType เฉพาะ**
ตัวอย่างโค้ดต่อไปนี้จะช่วยเข้าถึงรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) ที่มี LayoutType เฉพาะ โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นค่าอ่านอย่างเดียวและจะถูกกำหนดเฉพาะเมื่อเพิ่มรูปแบบ SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปแบบ SmartArt .
2. รับอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน .
3. วนตรวจสอบทุกรูปภายในสไลด์แรก .
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) และแคสท์รูปที่เลือกเป็น SmartArt หากเป็น SmartArt .
5. ตรวจสอบรูปแบบ SmartArt ด้วย LayoutType เฉพาะและทำสิ่งที่ต้องทำต่อไป .

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // วนตรวจสอบทุกรูปร่างภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt)
        {
            // แคสท์รูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // ตรวจสอบการจัดวาง SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนสไตล์ของรูปแบบ SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การเปลี่ยนสไตล์เร็วสำหรับรูปแบบ SmartArt ใด ๆ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปแบบ SmartArt .
2. รับอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน .
3. วนตรวจสอบทุกรูปภายในสไลด์แรก .
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) และแคสท์รูปที่เลือกเป็น SmartArt หากเป็น SmartArt .
5. ค้นหารูปแบบ SmartArt ด้วยสไตล์เฉพาะ .
6. ตั้งค่าสไตล์ใหม่สำหรับรูปแบบ SmartArt .
7. บันทึกงานนำเสนอ .

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // รับสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนตรวจสอบทุกรูปร่างภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสท์รูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // ตรวจสอบสไตล์ SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // เปลี่ยนสไตล์ SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // บันทึกงานนำเสนอ
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**รูปภาพ: รูปแบบ SmartArt ที่มีสไตล์ที่เปลี่ยนแปลง**|

## **เปลี่ยนสไตล์สีของรูปแบบ SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การเปลี่ยนสไตล์สีสำหรับรูปแบบ SmartArt ใด ๆ ในตัวอย่างโค้ดต่อไปนี้จะเข้าถึงรูปแบบ SmartArt ด้วยสไตล์สีเฉพาะและจะเปลี่ยนสไตล์ของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปแบบ SmartArt .
2. รับอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน .
3. วนตรวจสอบทุกรูปภายในสไลด์แรก .
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) และแคสท์รูปที่เลือกเป็น SmartArt หากเป็น SmartArt .
5. ค้นหารูปแบบ SmartArt ด้วยสไตล์สีเฉพาะ .
6. ตั้งค่าสไตล์สีใหม่สำหรับรูปแบบ SmartArt .
7. บันทึกงานนำเสนอ .

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // รับสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนตรวจสอบทุกรูปร่างภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสท์รูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // ตรวจสอบประเภทสีของ SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // เปลี่ยนประเภทสีของ SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // บันทึกงานนำเสนอ
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**รูปภาพ: รูปแบบ SmartArt ที่มีสไตล์สีที่เปลี่ยนแปลง**|

## **FAQ**

**ฉันสามารถทำแอนิเมชัน SmartArt เป็นวัตถุเดียวได้หรือไม่?**

ได้ครับ SmartArt เป็นรูปร่าง ดังนั้นคุณจึงสามารถใช้ [standard animations](/slides/th/androidjava/powerpoint-animation/) ผ่าน API การแอนิเมชัน (การเข้ามา, การออก, การเน้น, เส้นทางการเคลื่อนที่) เช่นเดียวกับรูปร่างอื่น ๆ

**ฉันจะค้นหา SmartArt เฉพาะบนสไลด์ได้อย่างไรหากไม่ทราบ ID ภายในของมัน?**

ตั้งค่าและใช้ข้อความแทน (AltText) แล้วค้นหารูปร่างตามค่าดังกล่าว—นี่เป็นวิธีที่แนะนำในการค้นหารูปร่างเป้าหมาย

**ฉันสามารถจัดกลุ่ม SmartArt กับรูปร่างอื่นได้หรือไม่?**

ได้ คุณสามารถจัดกลุ่ม SmartArt กับรูปร่างอื่น (รูปภาพ, ตาราง ฯลฯ) แล้ว [manipulate the group](/slides/th/androidjava/group/)

**ฉันจะได้รูปภาพของ SmartArt เฉพาะ (เช่น สำหรับการแสดงตัวอย่างหรือรายงาน) อย่างไร?**

ส่งออกรูปย่อ/ภาพของรูปร่าง; ไลบรารีสามารถ [render individual shapes](/slides/th/androidjava/create-shape-thumbnails/) ไปยังไฟล์เรสเตอร์ (PNG/JPG/TIFF)

**ลักษณะของ SmartArt จะคงเดิมเมื่อแปลงงานนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ได้ เครื่องมือการเรนเดอร์มุ่งเน้นความละเอียดสูงสำหรับ [PDF export](/slides/th/androidjava/convert-powerpoint-to-pdf/), พร้อมตัวเลือกคุณภาพและความเข้ากันได้ต่าง ๆ