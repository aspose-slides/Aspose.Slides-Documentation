---
title: จัดการโหนดรูปร่าง SmartArt ในงานนำเสนอด้วย Java
linktitle: โหนดรูปร่าง SmartArt
type: docs
weight: 30
url: /th/java/manage-smartart-shape-node/
keywords:
- โหนด SmartArt
- โหนดลูก
- เพิ่มโหนด
- ตำแหน่งโหนด
- เข้าถึงโหนด
- ลบโหนด
- ตำแหน่งกำหนดเอง
- โหนดผู้ช่วย
- รูปแบบการเติม
- เรนเดอร์โหนด
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการโหนดรูปร่าง SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides for Java. รับตัวอย่างโค้ดที่ชัดเจนและคำแนะนำเพื่อปรับปรุงงานนำเสนอของคุณ."
---
## **ภาพรวม**

กราฟิก SmartArt ในงานนำเสนอ PowerPoint ถูกจัดระเบียบผ่านโหนดที่มีข้อความและกำหนดโครงสร้างของแผนผัง Aspose.Slides ให้คุณทำงานกับโหนด SmartArt เหล่านี้แบบโปรแกรมเมติก: เพิ่มโหนดและโหนดลูกใหม่, แทรกโหนดลูกในตำแหน่งที่กำหนด, เข้าถึงโหนดที่มีอยู่, และอ่านข้อความ, ระดับ, และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปแบบ SmartArt แสดงวิธีการลบโหนด, ทำงานกับโหนดลูกโดยใช้ดัชนีหรือตำแหน่ง, เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ, ปรับตำแหน่ง, ขนาดและการหมุนของรูปโหนด SmartArt, ตั้งค่ารูปแบบการเติมของโหนด, และสร้างภาพตัวอย่างขนาดเล็กสำหรับโหนดลูกของ SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for Java มี API ที่ง่ายที่สุดเพื่อจัดการรูปร่าง SmartArt อย่างง่าย ด้านล่างเป็นตัวอย่างโค้ดที่ช่วยให้เพิ่มโหนดและโหนดลูกภายในรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index
3. วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. [เพิ่มโหนดใหม่](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) ในรูปร่าง SmartArt [**NodeCollection**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt#getAllNodes--) และกำหนดข้อความใน TextFrame
6. ตอนนี้, [เพิ่ม](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**โหนดลูก**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ในโหนด [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) ที่เพิ่งเพิ่มและกำหนดข้อความใน TextFrame
7. บันทึกงานนำเสนอ

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof SmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // เพิ่มโหนด SmartArt ใหม่
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // เพิ่มข้อความ
            TemNode.getTextFrame().setText("Test");
    
            // เพิ่มโหนดลูกใหม่ในโหนดหลัก จะถูกเพิ่มที่ส่วนท้ายของคอลเลกชัน
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // เพิ่มข้อความ
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // บันทึกงานนำเสนอ
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มโหนด SmartArt ในตำแหน่งเฉพาะ**
ในตัวอย่างโค้ดต่อไปนี้อธิบายวิธีเพิ่มโหนดลูกที่เป็นของโหนดแต่ละโหนดของรูปร่าง SmartArt ในตำแหน่งที่กำหนด

1. สร้างอินสแตนซ์ของคลาส Presentation
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index
3. เพิ่มรูปร่าง [**StackedList**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) ในสไลด์ที่เข้าถึง
4. เข้าถึงโหนดแรกในรูปร่าง SmartArt ที่เพิ่ม
5. ตอนนี้, เพิ่ม [**โหนดลูก**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) สำหรับ [**โหนด**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode) ที่เลือกที่ตำแหน่ง 2 และกำหนดข้อความ
6. บันทึกงานนำเสนอ

```java
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์ของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // เข้าถึงโหนด SmartArt ที่ดัชนี 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // เพิ่มโหนดลูกใหม่ที่ตำแหน่ง 2 ในโหนดหลัก
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // เพิ่มข้อความ
    chNode.getTextFrame().setText("Sample Text Added");

    // บันทึกงานนำเสนอ
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงโหนด SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงโหนดภายในรูปร่าง SmartArt โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้เนื่องจากเป็นค่าอ่านอย่างเดียวและตั้งค่าเฉพาะเมื่อตัวรูปร่าง SmartArt ถูกเพิ่ม

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index
3. วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. วนลูปผ่าน [**โหนดทั้งหมด**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt#getAllNodes--) ภายในรูปร่าง SmartArt
6. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนด SmartArt, ระดับและข้อความ

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // วนลูปผ่านโหนดทั้งหมดภายใน SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // เข้าถึงโหนด SmartArt ที่ตำแหน่ง i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // พิมพ์พารามิเตอร์ของโหนด SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงโหนดลูกของ SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงโหนดลูกที่เป็นของโหนดแต่ละโหนดของรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index
3. วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. วนลูปผ่าน [**โหนดทั้งหมด**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt#getAllNodes--) ภายในรูปร่าง SmartArt
6. สำหรับแต่ละ [**โหนด**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode) ที่เลือก, วนลูปผ่าน [**โหนดลูกทั้งหมด**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode#getChildNodes--) ภายในโหนดนั้น
7. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่ง, ระดับและข้อความของ [**โหนดลูก**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--)

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // วนลูปผ่านโหนดทั้งหมดภายใน SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // เข้าถึงโหนด SmartArt ที่ดัชนี i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // วนลูปผ่านโหนดลูกในโหนด SmartArt ที่ดัชนี i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // เข้าถึงโหนดลูกในโหนด SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // พิมพ์พารามิเตอร์ของโหนดลูก SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงโหนดลูกของ SmartArt ในตำแหน่งเฉพาะ**
ในตัวอย่างนี้เราจะเรียนรู้วิธีเข้าถึงโหนดลูกในตำแหน่งบางตำแหน่งที่เป็นของโหนดแต่ละโหนดของรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index
3. เพิ่มรูปร่าง SmartArt ประเภท [**StackedList**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType#StackedList)
4. เข้าถึงรูปร่าง SmartArt ที่เพิ่ม
5. เข้าถึงโหนดที่ตำแหน่งดัชนี 0 ของรูปร่าง SmartArt ที่เข้าถึง
6. ตอนนี้, เข้าถึง [**โหนดลูก**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ที่ตำแหน่ง 1 ของโหนด SmartArt ที่เข้าถึงโดยใช้เมธอด **get_Item()**
7. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่ง, ระดับและข้อความของ [**โหนดลูก**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--)

```java
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปร่าง SmartArt ในสไลด์แรก
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // เข้าถึงโหนด SmartArt ที่ดัชนี 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // เข้าถึงโหนดลูกที่ตำแหน่ง 1 ในโหนดหลัก
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // พิมพ์พารามิเตอร์ของโหนดลูก SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโหนด SmartArt**
ในตัวอย่างนี้เราจะเรียนรู้วิธีลบโหนดภายในรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index
3. วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. ตรวจสอบว่า [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) มีโหนดมากกว่า 0 หรือไม่
6. เลือกโหนด SmartArt ที่จะลบ
7. ตอนนี้, ลบโหนดที่เลือกโดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)
8. บันทึกงานนำเสนอ

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // เข้าถึงโหนด SmartArt ที่ดัชนี 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // ลบโหนดที่เลือก
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // บันทึกงานนำเสนอ
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโหนด SmartArt จากตำแหน่งเฉพาะ**
ในตัวอย่างนี้เราจะเรียนรู้วิธีลบโหนดภายในรูปร่าง SmartArt ที่ตำแหน่งที่กำหนด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index
3. วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. เลือกโหนดรูปร่าง SmartArt ที่ดัชนี 0
6. ตอนนี้, ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดลูกมากกว่า 2 หรือไม่
7. ตอนนี้, ลบโหนดที่ตำแหน่ง **1** โดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)
8. บันทึกงานนำเสนอ

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof SmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // เข้าถึงโหนด SmartArt ที่ดัชนี 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // ลบโหนดลูกที่ตำแหน่ง 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // บันทึกงานนำเสนอ
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโหนดลูกในวัตถุ SmartArt**
ตอนนี้ Aspose.Slides for Java รองรับการตั้งค่า [SmartArtShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtShape) คุณสมบัติ [X](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#setX-float-) และ [Y](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#setY-float-) โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าตำแหน่ง, ขนาดและการหมุนของ SmartArtShape แบบกำหนดเอง อีกทั้งโปรดทราบว่าการเพิ่มโหนดใหม่จะทำให้ตำแหน่งและขนาดของโหนดทั้งหมดถูกคำนวณใหม่ด้วย การตั้งค่าตำแหน่งแบบกำหนดเองช่วยให้ผู้ใช้สามารถกำหนดโหนดตามความต้องการ

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // ย้ายรูปร่าง SmartArt ไปยังตำแหน่งใหม่
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // เปลี่ยนความกว้างของรูปร่าง SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // เปลี่ยนความสูงของรูปร่าง SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // เปลี่ยนการหมุนของรูปร่าง SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **ตรวจสอบโหนดผู้ช่วย**
{{% alert color="primary" %}} 

ในบทความนี้เราจะสำรวจคุณลักษณะเพิ่มเติมของรูปร่าง SmartArt ที่เพิ่มในสไลด์งานนำเสนอโดยใช้ Aspose.Slides for Java อย่างโปรแกรมเมติก

{{% /alert %}} 

เราจะใช้รูปร่าง SmartArt ต้นฉบับต่อไปนี้สำหรับการสำรวจในแต่ละส่วนของบทความ

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**รูปที่ 1: รูป SmartArt ต้นฉบับในสไลด์**|

ในตัวอย่างโค้ดต่อไปนี้เราจะตรวจสอบวิธีระบุ **โหนดผู้ช่วย** ในคอลเลกชันโหนด SmartArt และการเปลี่ยนแปลงของพวกมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
2. รับอ้างอิงของสไลด์ที่สองโดยใช้ Index
3. วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. วนลูปผ่านโหนดทั้งหมดภายในรูปร่าง SmartArt และตรวจสอบว่าพวกมันเป็น [**โหนดผู้ช่วย**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode#isAssistant--) หรือไม่
6. เปลี่ยนสถานะของโหนดผู้ช่วยให้เป็นโหนดปกติ
7. บันทึกงานนำเสนอ

```java
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // วนลูปผ่านรูปร่างทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // วนลูปผ่านโหนดทั้งหมดของรูปร่าง SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ตรวจสอบว่าโหนดเป็นโหนดผู้ช่วยหรือไม่
                if (node.isAssistant()) 
                {
                    // ตั้งค่าโหนดผู้ช่วยเป็น false และทำให้เป็นโหนดปกติ
                    node.isAssistant();
                }
            }
        }
    }
    
    // บันทึกงานนำเสนอ
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**รูปที่ 2: โหนดผู้ช่วยที่เปลี่ยนแปลงในรูปร่าง SmartArt ภายในสไลด์**|

## **ตั้งค่ารูปแบบการเติมของโหนด**
Aspose.Slides for Java ทำให้สามารถเพิ่มรูปร่าง SmartArt แบบกำหนดเองและตั้งค่ารูปแบบการเติมของโหนดเหล่านั้นได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปร่าง SmartArt และตั้งค่ารูปแบบการเติมโดยใช้ Aspose.Slides for Java

โปรดทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนี
3. เพิ่มรูปร่าง [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) โดยกำหนด [**LayoutType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)
4. ตั้งค่า [**FillFormat**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getFillFormat--) สำหรับโหนดรูปร่าง SmartArt
5. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปร่าง SmartArt และโหนด
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // ตั้งค่าสีเติมของโหนด
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // บันทึกงานนำเสนอ
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างภาพตัวอย่างขนาดเล็กของโหนดลูก SmartArt**
นักพัฒนาสามารถสร้างภาพตัวอย่างของโหนดลูกของ SmartArt ได้ตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
2. [เพิ่ม SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)
3. รับอ้างอิงของโหนดโดยใช้ Index
4. รับภาพตัวอย่าง
5. บันทึกภาพตัวอย่างในรูปแบบภาพที่ต้องการ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX 
Presentation pres = new Presentation();
try {
    // เพิ่ม SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // รับอ้างอิงของโหนดโดยใช้ Index ของมัน  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // ดึงภาพตัวอย่าง
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // บันทึกภาพตัวอย่าง
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการเคลื่อนไหวหรือไม่?**

ใช่. SmartArt ถูกจัดการเป็นรูปร่างทั่วไป ดังนั้นคุณสามารถ [ใช้การเคลื่อนไหวมาตรฐาน](/slides/th/java/shape-animation/) (การเข้า, การออก, การเน้น, เส้นทางเคลื่อนที่) และปรับเวลาได้ คุณยังสามารถทำให้รูปร่างภายในโหนด SmartArt มีการเคลื่อนไหวได้เมื่อจำเป็น

**ถ้าฉันไม่มีรหัสภายในของ SmartArt บนสไลด์ จะค้นหา SmartArt เฉพาะได้อย่างไร?**

กำหนดและค้นหาด้วย [ข้อความแทนภาพ](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getAlternativeText--) การตั้งค่า AltText ที่แตกต่างบน SmartArt จะทำให้คุณค้นพบได้โดยโปรแกรมเมติกโดยไม่ต้องอาศัยรหัสภายใน

**การแปลงงานนำเสนอเป็น PDF จะรักษาลักษณะของ SmartArt ไว้หรือไม่?**

ใช่. Aspose.Slides เรนเดอร์ SmartArt ด้วยความแม่นยำสูงในการ [ส่งออกเป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/) ทำให้รักษาโครงสร้าง, สีและเอฟเฟกต์ไว้ทั้งหมด

**ฉันสามารถดึงภาพของ SmartArt ทั้งหมด (เพื่อแสดงตัวอย่างหรือรายงาน) ได้หรือไม่?**

ใช่. คุณสามารถเรนเดอร์รูปร่าง SmartArt เป็น [รูปแบบเรสเตอร์](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-) หรือเป็น [SVG](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) เพื่อให้ได้ผลลัพธ์เวกเตอร์ที่ปรับขนาดได้ เหมาะสำหรับภาพตัวอย่าง, รายงาน หรือการใช้บนเว็บ