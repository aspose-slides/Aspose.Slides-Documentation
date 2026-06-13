---
title: จัดการกราฟิก SmartArt ในงานนำเสนอด้วย Java
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/java/manage-smartart-shape/
keywords:
- อ็อบเจ็กต์ SmartArt
- กราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยนแปลง SmartArt
- เข้าถึง SmartArt
- ประเภทการจัดวาง SmartArt
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "อัตโนมัติการสร้าง แก้ไข และตกแต่ง SmartArt ของ PowerPoint ใน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดสั้น ๆ และคำแนะนำที่เน้นประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

Aspose.Slides ให้คุณสร้างและจัดการกราฟิก SmartArt ในงานนำเสนอ PowerPoint แบบโปรแกรมมิ่ง บทความนี้อธิบายวิธีเพิ่มรูปแบบ SmartArt ลงในสไลด์, การเข้าถึงรูปแบบ SmartArt ที่มีอยู่, การหาตำแหน่ง SmartArt ตามประเภทการจัดวางที่เฉพาะเจาะจง, และการอัปเดตลักษณะการแสดงผลโดยการเปลี่ยนสไตล์ SmartArt หรือสไตล์สี

ตัวอย่างจะแสดงวิธีทำงานกับรูปแบบ SmartArt ผ่านคอลเลกชันรูปทรงของสไลด์นำเสนอ ตรวจสอบว่ารูปทรงเป็น SmartArt หรือไม่ แล้วทำการปรับเปลี่ยนหรือวิเคราะห์คุณสมบัติของมัน

## **สร้างรูปแบบ SmartArt**

Aspose.Slides for Java มี API สำหรับสร้างรูปแบบ SmartArt เพื่อสร้างรูปแบบ SmartArt ในสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. [เพิ่มรูปแบบ SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) โดยตั้งค่า [LayoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType)
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์คลาส Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปแบบ Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // บันทึกการนำเสนอ
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **เข้าถึงรูปแบบ SmartArt บนสไลด์**

โค้ดต่อไปนี้จะใช้เพื่อเข้าถึงรูปแบบ SmartArt ที่เพิ่มในสไลด์การนำเสนอ ในตัวอย่างโค้ดเราจะวนผ่านรูปทรงทุกรูปภายในสไลด์และตรวจสอบว่ามันเป็นรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) หรือไม่ หากรูปทรัดเป็นประเภท SmartArt เราจะทำการแคสท์เป็นอินสแตนซ์ของ [**SmartArt**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt)

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // วนผ่านรูปทรงทุกรูปภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt)
        {
            // แคสท์รูปทรงเป็น SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงรูปแบบ SmartArt ด้วย LayoutType เฉพาะ**

ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) ด้วย LayoutType ที่ระบุ โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เพราะเป็นค่าอ่านอย่างเดียวและจะถูกตั้งค่าเมื่อเพิ่มรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) และโหลดการนำเสนอที่มีรูปแบบ SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทุกรูปภายในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
1. ตรวจสอบรูปแบบ SmartArt ด้วย LayoutType ที่ระบุและดำเนินการตามที่ต้องการต่อไป

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // วนผ่านรูปทรงทุกรูปภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt)
        {
            // แคสท์รูปทรงเป็น SmartArtEx
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

ในตัวอย่างนี้ เราจะเรียนรู้วิธีเปลี่ยนสไตล์รวดเร็วสำหรับรูปแบบ SmartArt ใด ๆ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) และโหลดการนำเสนอที่มีรูปแบบ SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทุกรูปภายในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
1. ค้นหารูปแบบ SmartArt ด้วย Style ที่ระบุ
1. ตั้งค่า Style ใหม่ให้กับรูปแบบ SmartArt
1. บันทึกการนำเสนอ

```java
// สร้างอินสแตนซ์คลาส Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปทรงทุกรูปภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสท์รูปทรงเป็น SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // ตรวจสอบสไตล์ SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // เปลี่ยนสไตล์ SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // บันทึกการนำเสนอ
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape with changed Style**|

## **เปลี่ยนสไตล์สีของรูปแบบ SmartArt**

ในตัวอย่างนี้ เราจะเรียนรู้วิธีเปลี่ยนสไตล์สีสำหรับรูปแบบ SmartArt ใด ๆ โค้ดตัวอย่างต่อไปนี้จะเข้าถึงรูปแบบ SmartArt ด้วยสไตล์สีที่ระบุและจะเปลี่ยนสไตล์ของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) และโหลดการนำเสนอที่มีรูปแบบ SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทุกรูปภายในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
1. ค้นหารูปแบบ SmartArt ด้วย Color Style ที่ระบุ
1. ตั้งค่า Color Style ใหม่ให้กับรูปแบบ SmartArt
1. บันทึกการนำเสนอ

```java
// สร้างอินสแตนซ์คลาส Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปทรงทุกรูปภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสท์รูปทรงเป็น SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // ตรวจสอบประเภทสีของ SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // เปลี่ยนประเภทสีของ SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // บันทึกการนำเสนอ
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed Color Style**|

## **คำถามที่พบบ่อย**

**ฉันสามารถทำให้ SmartArt เคลื่อนไหวเป็นวัตถุเดียวได้หรือไม่?**

ได้ครับ SmartArt เป็นรูปทรงหนึ่ง ดังนั้นคุณสามารถใช้ [การเคลื่อนไหวมาตรฐาน](/slides/th/java/powerpoint-animation/) ผ่าน API การเคลื่อนไหว (เข้ามา, ออก, เน้น, เส้นทางการเคลื่อนที่) เหมือนกับรูปทรงอื่น ๆ

**ฉันจะหาตำแหน่ง SmartArt เฉพาะบนสไลด์ได้อย่างไรถ้าฉันไม่รู้ ID ภายในของมัน?**

ตั้งค่าและใช้ Alternative Text (AltText) แล้วค้นหารูปทรงตามค่าดังกล่าว—นี่เป็นวิธีแนะนำในการค้นหารูปทรงเป้าหมาย

**ฉันสามารถจัดกลุ่ม SmartArt กับรูปทรงอื่นได้หรือไม่?**

ได้ครับ คุณสามารถจัดกลุ่ม SmartArt กับรูปทรงอื่น (ภาพ, ตาราง ฯลฯ) แล้ว [จัดการกลุ่ม](/slides/th/java/group/)

**ฉันจะได้ภาพของ SmartArt เฉพาะ (เช่น สำหรับการพรีวิวหรือรายงาน) อย่างไร?**

ส่งออกรูปย่อ/ภาพของรูปทรง; ไลบรารีสามารถ [แสดงรูปทรงแต่ละตัว](/slides/th/java/create-shape-thumbnails/) เป็นไฟล์เรสเตอร์ (PNG/JPG/TIFF)

**รูปลักษณ์ของ SmartArt จะคงเดิมเมื่อแปลงการนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ได้ครับ เครื่องเรนเดอร์มุ่งเน้นความแม่นยำสูงสำหรับ [การส่งออกเป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/) , พร้อมตัวเลือกคุณภาพและความเข้ากันได้หลายแบบ