---
title: จัดการโหนดรูปทรง SmartArt ในการนำเสนอบน Android
linktitle: โหนดรูปทรง SmartArt
type: docs
weight: 30
url: /th/androidjava/manage-smartart-shape-node/
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
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการโหนดรูปทรง SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides สำหรับ Android. รับตัวอย่างโค้ด Java ที่ชัดเจนและเคล็ดลับเพื่อทำให้การนำเสนอของคุณเป็นระบบระเบียบ."
---
## **ภาพรวม**

กราฟิก SmartArt ในงานนำเสนอ PowerPoint จะถูกจัดระเบียบผ่านโหนดที่รวมข้อความและกำหนดโครงสร้างของไดอะแกรม Aspose.Slides ให้คุณทำงานกับโหนด SmartArt นี้โดยโปรแกรมได้: เพิ่มโหนดและโหนดลูกใหม่ แทรกโหนดลูกในตำแหน่งที่เจาะจง เข้าถึงโหนดที่มีอยู่และอ่านข้อความ ระดับ และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปทรง SmartArt แสดงวิธีลบโหนด ทำงานกับโหนดลูกโดยใช้ดัชนีหรือตำแหน่ง เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ ปรับตำแหน่ง ขนาด และการหมุนของรูปทรงโหนด SmartArt ตั้งค่ารูปแบบการเติมของโหนด และสร้างภาพตัวอย่างขนาดย่อสำหรับโหนดลูกของ SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for Android via Java ได้ให้ API ที่ง่ายที่สุดสำหรับจัดการรูปทรง SmartArt อย่างง่าย ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเพิ่มโหนดและโหนดลูกภายในรูปทรง SmartArt

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) class และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนลูปผ่านทุกรูปทรงในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. [Add a new Node](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) ในรูปทรง SmartArt [**NodeCollection**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) และกำหนดข้อความใน TextFrame
1. ตอนนี้, [Add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ในโหนด [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) ที่เพิ่งเพิ่มและกำหนดข้อความใน TextFrame
1. บันทึกงานนำเสนอ

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof SmartArt) 
        {
            // แปลงชนิดรูปทรงเป็น SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // เพิ่มโหนด SmartArt ใหม่
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // เพิ่มข้อความ
            TemNode.getTextFrame().setText("Test");
    
            // เพิ่มโหนดลูกใหม่ในโหนดแม่ จะถูกเพิ่มในตำแหน่งสุดท้ายของคอลเลกชัน
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

## **เพิ่มโหนด SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างโค้ดต่อไปนี้ เราอธิบายวิธีเพิ่มโหนดลูกที่เป็นส่วนหนึ่งของโหนดต่าง ๆ ของรูปทรง SmartArt ในตำแหน่งที่กำหนด

1. สร้างอินสแตนซ์ของคลาส Presentation
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. เพิ่มรูปทรง [**StackedList**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) ในสไลด์ที่เข้าถึง
1. เข้าถึงโหนดแรกในรูปทรง SmartArt ที่เพิ่มไว้
1. ตอนนี้, เพิ่ม [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) สำหรับ [**Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode) ที่เลือกที่ตำแหน่ง 2 และกำหนดข้อความของมัน
1. บันทึกงานนำเสนอ

```java
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์ของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม IShape Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // เข้าถึงโหนด SmartArt ที่ดัชนี 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // เพิ่มโหนดลูกใหม่ที่ตำแหน่ง 2 ในโหนดแม่
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
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโหนดภายในรูปทรง SmartArt โปรดทราบว่าไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้เนื่องจากเป็นค่าอ่านอย่างเดียวและจะถูกตั้งค่าเมื่อเพิ่มรูปทรง SmartArt เท่านั้น

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) class และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนลูปผ่านทุกรูปทรงในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. วนลูปผ่านทุก [**Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt#getAllNodes--) ภายในรูปทรง SmartArt
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนด SmartArt, ระดับ และข้อความ

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // รับสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปทรงทุกอันภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงชนิดรูปทร่างเป็น SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // วนผ่านโหนดทั้งหมดภายใน SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // เข้าถึงโหนด SmartArt ที่ดัชนี i
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
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโหนดลูกที่เป็นส่วนหนึ่งของโหนดต่าง ๆ ของรูปทรง SmartArt

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) class และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนลูปผ่านทุกรูปทรงในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. วนลูปผ่านทุก [**Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt#getAllNodes--) ภายในรูปทรง SmartArt
1. สำหรับโหนด SmartArt [**Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode) ที่เลือก, วนลูปผ่านทุก [**Child Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) ภายในโหนดนั้น
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่ง, ระดับ และข้อความของ [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // รับสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปทรงทุกอันภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงชนิดรูปทรงเป็น SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // วนผ่านโหนดทั้งหมดภายใน SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // เข้าถึงโหนด SmartArt ที่ดัชนี i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // วนผ่านโหนดลูกในโหนด SmartArt ที่ดัชนี i
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

## **เข้าถึงโหนดลูกของ SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้การเข้าถึงโหนดลูกที่อยู่ในตำแหน่งเฉพาะของโหนดต่าง ๆ ของรูปทรง SmartArt

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) class
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. เพิ่มรูปทรง SmartArt ประเภท [**StackedList**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)
1. เข้าถึงรูปทรง SmartArt ที่เพิ่มไว้
1. เข้าถึงโหนดที่ดัชนี 0 ของรูปทรง SmartArt ที่เข้าถึง
1. ตอนนี้, เข้าถึง [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ที่ตำแหน่ง 1 ของโหนด SmartArt ที่เข้าถึงโดยใช้เมธอด **get_Item()**
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่ง, ระดับ และข้อความของ [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)

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
    
    // เข้าถึงโหนดลูกที่ตำแหน่ง 1 ในโหนดแม่
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // พิมพ์พารามิเตอร์ของโหนดลูก SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโหนด SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) class และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนลูปผ่านทุกรูปทรงในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. ตรวจสอบว่า SmartArt มีโหนดมากกว่า 0 หรือไม่
1. เลือกโหนด SmartArt ที่ต้องการลบ
1. ตอนนี้, ลบโหนดที่เลือกโดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)
1. บันทึกงานนำเสนอ

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงชนิดรูปทรงเป็น SmartArt
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
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt ที่ตำแหน่งเฉพาะ

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) class และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนลูปผ่านทุกรูปทรงในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. เลือกโหนดรูปทรง SmartArt ที่ดัชนี 0
1. ตอนนี้ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดลูกมากกว่า 2 หรือไม่
1. ตอนนี้, ลบโหนดที่ตำแหน่ง **1** โดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)
1. บันทึกงานนำเสนอ

```java
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof SmartArt) 
        {
            // แปลงชนิดรูปทรงเป็น SmartArt
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

## **กำหนดตำแหน่งแบบกำหนดเองสำหรับโหนดลูกในออบเจ็กต์ SmartArt**
ตอนนี้ Aspose.Slides for Android via Java รองรับการตั้งค่าคุณสมบัติ [SmartArtShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#setX-float-) และ [Y](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#setY-float-) โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าตำแหน่ง, ขนาดและการหมุนของ SmartArtShape แบบกำหนดเอง โปรดทราบว่าการเพิ่มโหนดใหม่จะทำให้ตำแหน่งและขนาดของทุกโหนดถูกคำนวณใหม่ อีกทั้งด้วยการตั้งค่าตำแหน่งแบบกำหนดเอง ผู้ใช้สามารถตั้งค่าโหนดตามความต้องการได้

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // ย้ายรูปทรง SmartArt ไปยังตำแหน่งใหม่
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // เปลี่ยนความกว้างของรูปทรง SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // เปลี่ยนความสูงของรูปทรง SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // เปลี่ยนการหมุนของรูปทรง SmartArt
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

ในบทความนี้เราจะสำรวจคุณสมบัติเสริมของรูปทรง SmartArt ที่เพิ่มลงในสไลด์งานนำเสนอโดยโปรแกรมด้วย Aspose.Slides for Android via Java

{{% /alert %}} 

เราจะใช้รูปทรง SmartArt แหล่งที่มาดังต่อไปนี้สำหรับการสืบค้นในส่วนต่าง ๆ ของบทความ

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**รูปภาพ: รูปทรง SmartArt แหล่งที่มาบนสไลด์**|

ในตัวอย่างโค้ดต่อไปนี้ เราจะสำรวจวิธีระบุ **Assistant Nodes** ในคอลเลกชันโหนด SmartArt และทำการเปลี่ยนแปลง

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) class และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. รับอ้างอิงของสไลด์ที่สองโดยใช้ Index ของมัน
1. วนลูปผ่านทุกรูปทรงในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. วนลูปผ่านทุกโหนดภายในรูปทรง SmartArt และตรวจสอบว่าพวกมันเป็น [**Assistant Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) หรือไม่
1. เปลี่ยนสถานะของ Assistant Node ให้เป็นโหนดปกติ
1. บันทึกงานนำเสนอ

```java
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงชนิดรูปทรงเป็น SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // วนผ่านโหนดทั้งหมดของรูปทรง SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ตรวจสอบว่าโหนดเป็นโหนดผู้ช่วยหรือไม่
                if (node.isAssistant()) 
                {
                    // ตั้งค่าโหนดผู้ช่วยเป็น false และเปลี่ยนเป็นโหนดปกติ
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
|**รูปภาพ: โหนดผู้ช่วยที่เปลี่ยนแปลงในรูปทรง SmartArt บนสไลด์**|

## **กำหนดรูปแบบการเติมของโหนด**
Aspose.Slides for Android via Java ทำให้สามารถเพิ่มรูปทรง SmartArt แบบกำหนดเองและตั้งค่ารูปแบบการเติมของมันได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปทรง SmartArt และตั้งค่ารูปแบบการเติมโดยใช้ Aspose.Slides for Android via Java

โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มรูปทรง [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) โดยกำหนด [**LayoutType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)
1. ตั้งค่า [**FillFormat**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getFillFormat--) สำหรับโหนดรูปทรง SmartArt
1. เขียนไฟล์งานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปทรง SmartArt และโหนด
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // ตั้งค่าสีเติมให้โหนด
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

## **สร้างภาพย่อของโหนดลูก SmartArt**
นักพัฒนาสามารถสร้างภาพย่อของโหนดลูกของ SmartArt ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. [Add SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)
1. รับอ้างอิงของโหนดโดยใช้ Index ของมัน
1. รับภาพย่อ
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เพิ่ม SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // รับอ้างอิงของโหนดโดยใช้ Index ของมัน
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // รับภาพย่อ
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // บันทึกภาพย่อ
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**การทำแอนิเมชันใน SmartArt รองรับหรือไม่?**

ใช่. SmartArt ถือเป็นรูปทรงทั่วไป ดังนั้นคุณสามารถ [apply standard animations](/slides/th/androidjava/shape-animation/) (entrance, exit, emphasis, motion paths) และปรับเวลาได้ คุณยังสามารถทำแอนิเมชันให้รูปทรงภายในโหนด SmartArt เมื่อจำเป็น

**จะค้นหา SmartArt เฉพาะบนสไลด์ได้อย่างไรหากไม่ทราบ ID ภายใน?**

กำหนดและค้นหาโดยใช้ [alternative text](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getAlternativeText--). การตั้งค่า AltText ที่โดดเด่นบน SmartArt จะทำให้คุณค้นพบได้โดยโปรแกรมโดยไม่ต้องอ้างอิง ID ภายใน

**รูปแบบของ SmartArt จะคงอยู่เมื่อตแลงเป็น PDF หรือไม่?**

ใช่. Aspose.Slides จะเรนเดอร์ SmartArt ด้วยความแม่นยำสูงในระหว่าง [PDF export](/slides/th/androidjava/convert-powerpoint-to-pdf/) เพื่อรักษาเลย์เอาต์ สี และเอฟเฟ็กต์

**สามารถเอาภาพของ SmartArt ทั้งหมด (สำหรับตัวอย่างหรือรายงาน) ออกมาได้หรือไม่?**

ใช่. คุณสามารถเรนเดอร์รูปทรง SmartArt เป็น [raster formats](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) หรือเป็น [SVG](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) เพื่อให้ได้ผลลัพธ์แบบเวกเตอร์ที่ขยายได้ ทำให้เหมาะสำหรับภาพย่อ รายงาน หรือการใช้งานบนเว็บ