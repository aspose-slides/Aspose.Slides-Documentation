---
title: จัดการโหนดรูปร่าง SmartArt ในงานนำเสนอบน Android
linktitle: โหนดรูปร่าง SmartArt
type: docs
weight: 30
url: /th/androidjava/manage-smartart-shape-node/
keywords:
- โหนด SmartArt
- โหนดย่อย
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
- Android
- Java
- Aspose.Slides
description: "จัดการโหนดรูปร่าง SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides สำหรับ Android รับตัวอย่างโค้ด Java ที่ชัดเจนและเคล็ดลับเพื่อทำให้งานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

กราฟิก SmartArt ในการนำเสนอ PowerPoint ถูกจัดระเบียบผ่านโหนดที่มีข้อความและกำหนดโครงสร้างของแผนผัง Aspose.Slides ให้คุณทำงานกับโหนด SmartArt เหล่านี้โดยโปรแกรม: เพิ่มโหนดและโหนดย่อยใหม่, แทรกโหนดย่อยในตำแหน่งที่กำหนด, เข้าถึงโหนดที่มีอยู่, และอ่านข้อความ, ระดับ, และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปแบบ SmartArt มันแสดงวิธีลบโหนด, ทำงานกับโหนดย่อยโดยใช้ดัชนีหรือสถานที่, เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ, ปรับตำแหน่ง, ขนาด, และการหมุนของรูปร่างโหนด SmartArt, ตั้งค่าการเติมสีของโหนด, และสร้างภาพตัวอย่างขนาดย่อสำหรับโหนด SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for Android via Java มี API ที่ง่ายที่สุดสำหรับจัดการรูปร่าง SmartArt อย่างง่ายที่สุด ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เพิ่มโหนดและโหนดย่อยภายในรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างเลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. [Add a new Node](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) ในรูปร่าง SmartArt [**NodeCollection**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) และใส่ข้อความใน TextFrame
1. ตอนนี้, [Add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ในโหนด SmartArt ที่เพิ่มใหม่และใส่ข้อความใน TextFrame
1. บันทึกงานนำเสนอ

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
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
    
            // เพิ่มโหนดย่อยใหม่ในโหนดแม่ จะถูกเพิ่มลงท้ายของคอลเลกชัน
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
ในตัวอย่างโค้ดต่อไปนี้ เราได้อธิบายวิธีเพิ่มโหนดย่อยที่เป็นของโหนดแต่ละโหนดของรูปร่าง SmartArt ในตำแหน่งที่กำหนด

1. สร้างอินสแตนซ์ของคลาส Presentation
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. เพิ่มรูปร่าง [**StackedList**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) ประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt) ในสไลด์ที่เข้าถึง
1. เข้าถึงโหนดแรกในรูปร่าง SmartArt ที่เพิ่ม
1. ตอนนี้, เพิ่ม [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) สำหรับ [**Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode) ที่เลือกที่ตำแหน่ง 2 และใส่ข้อความของมัน
1. บันทึกงานนำเสนอ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์ของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // เข้าถึงโหนด SmartArt ที่ดัชนี 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // เพิ่มโหนดย่อยใหม่ที่ตำแหน่ง 2 ในโหนดแม่
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
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงโหนดภายในรูปร่าง SmartArt โปรดทราบว่า LayoutType ของ SmartArt ถูกเลือกเมื่อเพิ่มรูปร่าง; การเปลี่ยนภายหลังด้วย **setLayout** จะสร้างแผนผังทั้งหมดใหม่ ทำให้ตำแหน่งและขนาดของโหนดที่คุณตั้งค่าไว้ถูกคำนวณใหม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างเลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. วนผ่าน [**Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt#getAllNodes--) ทั้งหมดภายในรูปร่าง SmartArt
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนด SmartArt, ระดับและข้อความ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
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

## **เข้าถึงโหนดย่อยของ SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงโหนดย่อยที่เป็นของโหนดแต่ละโหนดของรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างเลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. วนผ่าน [**Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArt#getAllNodes--) ทั้งหมดภายในรูปร่าง SmartArt
1. สำหรับแต่ละ [**Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode) ที่เลือก, วนผ่าน [**Child Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) ทั้งหมดภายในโหนดนั้น
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งของ [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ระดับและข้อความ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // วนผ่านโหนดทั้งหมดภายใน SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // เข้าถึงโหนด SmartArt ที่ดัชนี i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // วนผ่านโหนดย่อยในโหนด SmartArt ที่ดัชนี i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // เข้าถึงโหนดย่อยในโหนด SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // พิมพ์พารามิเตอร์ของโหนดย่อย SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงโหนดย่อยของ SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้การเข้าถึงโหนดย่อยที่อยู่ในตำแหน่งเฉพาะของโหนดแต่ละโหนดของรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. เพิ่มรูปร่าง SmartArt ประเภท [**StackedList**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)
1. เข้าถึงรูปร่าง SmartArt ที่เพิ่ม
1. เข้าถึงโหนดที่ดัชนี 0 ของรูปร่าง SmartArt ที่เข้าถึง
1. ตอนนี้, เข้าถึง [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ที่ตำแหน่ง 1 ของโหนด SmartArt ที่เข้าถึงโดยใช้เมธอด **get_Item()**
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งของ [**Child Node**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ระดับและข้อความ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปร่าง SmartArt ในสไลด์แรก
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // เข้าถึงโหนด SmartArt ที่ดัชนี 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // เข้าถึงโหนดย่อยที่ตำแหน่ง 1 ในโหนดแม่
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // พิมพ์พารามิเตอร์ของโหนดย่อย SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโหนด SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างเลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. ตรวจสอบว่า [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) มีโหนดมากกว่า 0 หรือไม่
1. เลือกโหนด SmartArt ที่จะลบ
1. ตอนนี้, ลบโหนดที่เลือกโดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)
1. บันทึกงานนำเสนอ

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
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
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปร่าง SmartArt ที่ตำแหน่งที่กำหนด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างเลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. เลือกโหนดรูปร่าง SmartArt ที่ดัชนี 0
1. ตอนนี้, ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดย่อยมากกว่า 2 หรือไม่
1. ตอนนี้, ลบโหนดที่ตำแหน่ง **1** โดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)
1. บันทึกงานนำเสนอ

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
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
                    // ลบโหนดย่อยที่ตำแหน่ง 1
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

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโหนดย่อยในวัตถุ SmartArt**
ตอนนี้ Aspose.Slides for Android via Java รองรับการตั้งค่าคุณสมบัติ [SmartArtShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#setX-float-) และ [Y](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#setY-float-) โค้ดสแนปด้านล่างแสดงวิธีตั้งค่าตำแหน่ง, ขนาด และการหมุนของ SmartArtShape อย่างกำหนดเอง โปรดทราบว่าการเพิ่มโหนดใหม่ทำให้ตำแหน่งและขนาดของโหนดทั้งหมดถูกคำนวณใหม่ อีกทั้งด้วยการตั้งตำแหน่งกำหนดเอง ผู้ใช้สามารถตั้งค่าโหนดตามความต้องการได้

```java
import com.aspose.slides.*;

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
{{% alert color="info" %}} 

ในบทความนี้เราจะสำรวจคุณสมบัติเพิ่มเติมของรูปร่าง SmartArt ที่เพิ่มในสไลด์การนำเสนอโดยโปรแกรมด้วย Aspose.Slides for Android via Java

{{% /alert %}} 

เราจะใช้รูปร่าง SmartArt ต้นแบบต่อไปนี้สำหรับการตรวจสอบในส่วนต่าง ๆ ของบทความ

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**รูปภาพ: รูปร่าง SmartArt ต้นฉบับในสไลด์**|

ในตัวอย่างโค้ดต่อไปนี้ เราจะตรวจสอบวิธีระบุ **Assistant Nodes** ในคอลเลกชันโหนด SmartArt และเปลี่ยนแปลงพวกมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงของสไลด์แรกโดยใช้ดัชนีของมัน
1. วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หรือไม่และแปลงประเภทรูปร่างเลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) หากเป็น SmartArt
1. วนผ่านโหนดทั้งหมดภายในรูปร่าง SmartArt และตรวจสอบว่าพวกมันเป็น [**Assistant Nodes**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) หรือไม่
1. เปลี่ยนสถานะของ Assistant Node เป็นโหนดปกติ
1. บันทึกงานนำเสนอ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แปลงประเภทรูปร่างเป็น SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // วนผ่านโหนดทั้งหมดของรูปร่าง SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ตรวจสอบว่าโหนดเป็นโหนดผู้ช่วยหรือไม่
                if (node.isAssistant()) 
                {
                    // ตั้งค่าโหนดผู้ช่วยเป็น false และทำให้เป็นโหนดปกติ
                    node.setAssistant(false);
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
|**รูปภาพ: Assistant Nodes ที่เปลี่ยนแปลงในรูปร่าง SmartArt ในสไลด์**|

## **ตั้งค่าการเติมสีของโหนด**
Aspose.Slides for Android via Java ทำให้สามารถเพิ่มรูปร่าง SmartArt ที่กำหนดเองและตั้งค่าการเติมสีของมันได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปร่าง SmartArt และตั้งค่าการเติมสีของโหนดโดยใช้ Aspose.Slides for Android via Java

โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. ดึงอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มรูปร่าง [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArt) โดยกำหนด [**LayoutType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)
1. ตั้งค่า [**FillFormat**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getFillFormat--) สำหรับโหนดรูปร่าง SmartArt
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปร่าง SmartArt และโหนด
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // ตั้งค่าสีการเติมของโหนด
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

## **สร้างภาพตัวอย่างขนาดย่อของโหนด SmartArt**
นักพัฒนาสามารถสร้างภาพตัวอย่างขนาดย่อของโหนดใน SmartArt ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. [Add SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)
1. ดึงอ้างอิงของโหนดโดยใช้ดัชนีของมัน
1. รับภาพตัวอย่างขนาดย่อ
1. บันทึกภาพตัวอย่างขนาดย่อในรูปแบบภาพที่ต้องการใด ๆ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX 
Presentation pres = new Presentation();
try {
    // เพิ่ม SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // ดึงอ้างอิงของโหนดโดยใช้ดัชนีของมัน  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // ดึงภาพย่อ
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

### รองรับการเคลื่อนไหวของ SmartArt หรือไม่?

ใช่. SmartArt ถูกพิจารณาเป็นรูปทรงธรรมดา ดังนั้นคุณสามารถ [ใช้การเคลื่อนไหวมาตรฐาน](/slides/th/androidjava/shape-animation/) (การเข้ามา, การออก, การเน้น, เส้นทางการเคลื่อนที่) และปรับเวลาได้ คุณยังสามารถทำการเคลื่อนไหวรูปทรงภายในโหนด SmartArt เมื่อจำเป็น

### จะค้นหา SmartArt ที่เฉพาะเจาะจงบนสไลด์ได้อย่างแม่นยำหากไม่ทราบ ID ภายในได้อย่างไร?

กำหนดและค้นหาโดยใช้ [ข้อความแทนภาพ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getAlternativeText--) การตั้งค่า AltText ที่โดดเด่นบน SmartArt จะทำให้คุณค้นพบมันโดยโปรแกรมโดยไม่ต้องพึ่งพาตัวระบุภายใน

### รูปแบบของ SmartArt จะคงอยู่เมื่อแปลงงานนำเสนอเป็น PDF หรือไม่?

ใช่. Aspose.Slides แสดงผล SmartArt ด้วยความแม่นยำสูงในระหว่าง [การส่งออกเป็น PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) คงรักษาเลย์เอาต์, สี, และเอฟเฟกต์

### สามารถสกัดภาพของ SmartArt ทั้งหมด (เพื่อพรีวิวหรือรายงาน) ได้หรือไม่?

ใช่. คุณสามารถเรนเดอร์รูปร่าง SmartArt เป็น [รูปแบบเรสเตอร์](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) หรือเป็น [SVG](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) เพื่อรับผลลัพธ์เวกเตอร์ที่ขยายได้ ทำให้เหมาะสำหรับภาพขนาดย่อ, รายงาน, หรือการใช้งานบนเว็บ