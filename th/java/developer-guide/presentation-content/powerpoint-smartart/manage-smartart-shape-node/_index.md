---
title: จัดการโหนดรูปทรง SmartArt ในการนำเสนอโดยใช้ Java
linktitle: โหนดรูปทรง SmartArt
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
- รูปแบบการเติมสี
- เรนเดอร์โหนด
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "จัดการโหนดรูปทรง SmartArt ใน PPT และ PPTX ด้วย Aspose.Slides for Java. รับตัวอย่างโค้ดที่ชัดเจนและเคล็ดลับเพื่อทำให้การนำเสนอของคุณราบรื่นขึ้น."
---
## **ภาพรวม**

กราฟิก SmartArt ในการนำเสนอ PowerPoint ถูกจัดระเบียบผ่านโหนดที่มีข้อความและกำหนดโครงสร้างของแผนภาพ Aspose.Slides ให้คุณทำงานกับโหนด SmartArt เหล่านี้โดยโปรแกรมได้: เพิ่มโหนดใหม่และโหนดลูก, แทรกโหนดลูกในตำแหน่งที่ระบุ, เข้าถึงโหนดที่มีอยู่, และอ่านข้อความ ระดับ และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปทรง SmartArt แสดงวิธีลบโหนด, ทำงานกับโหนดลูกโดยใช้ดัชนีหรือตำแหน่ง, เปลี่ยนโหนดผู้ช่วยให้เป็นโหนดปกติ, ปรับตำแหน่ง, ขนาด, และการหมุนของรูปทรงโหนด SmartArt, กำหนดรูปแบบการเติมสีของโหนด, และสร้างภาพขนาดย่อของโหนดลูก SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for Java มี API ที่ง่ายที่สุดในการจัดการรูปทรง SmartArt อย่างง่ายที่สุด ตัวอย่างโค้ดต่อไปนี้จะช่วยเพิ่มโหนดและโหนดลูกภายในรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และทำการแคสต์ชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. [Add a new Node](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) ใน SmartArt shape [**NodeCollection**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt#getAllNodes--) และตั้งข้อความใน TextFrame
6. ตอนนี้, [Add](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ใน [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) Node ที่เพิ่งเพิ่มใหม่และตั้งข้อความใน TextFrame
7. บันทึก Presentation

```java
import com.aspose.slides.*;

// โหลดการนำเสนอที่ต้องการ
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof SmartArt) 
        {
            // แคสต์ชนิดรูปทรงเป็น SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // เพิ่มโหนด SmartArt ใหม่
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // เพิ่มข้อความ
            TemNode.getTextFrame().setText("Test");
    
            // เพิ่มโหนดลูกใหม่ในโหนดแม่ มันจะถูกเพิ่มที่ตำแหน่งสุดท้ายของคอลเลกชัน
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // เพิ่มข้อความ
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // บันทึกการนำเสนอ
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มโหนด SmartArt ในตำแหน่งเฉพาะ**
ในตัวอย่างโค้ดต่อไปนี้เราจะอธิบายวิธีเพิ่มโหนดลูกที่เป็นส่วนของโหนดต่าง ๆ ของรูปทรง SmartArt ในตำแหน่งที่กำหนด

1. สร้างอินสแตนซ์ของคลาส Presentation
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. เพิ่มรูปทรง [**StackedList**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt) ในสไลด์ที่เข้าถึงได้
4. เข้าถึงโหนดแรกในรูปทรง SmartArt ที่เพิ่มใหม่
5. ตอนนี้, เพิ่ม [**Child Node**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) สำหรับ [**Node**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode) ที่เลือกที่ตำแหน่ง 2 และตั้งค่าข้อความของมัน
6. บันทึก Presentation

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของการนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์การนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // เข้าถึงโหนด SmartArt ที่ดัชนี 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // เพิ่มโหนดลูกใหม่ที่ตำแหน่ง 2 ในโหนดแม่
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // เพิ่มข้อความ
    chNode.getTextFrame().setText("Sample Text Added");

    // บันทึกการนำเสนอ
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงโหนด SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงโหนดภายในรูปทรง SmartArt โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นเพียงการอ่านอย่างเดียวและจะตั้งค่าเฉพาะเมื่อเพิ่มรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และทำการแคสต์ชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. วนผ่าน [**Nodes**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt#getAllNodes--) ทั้งหมดภายใน SmartArt Shape
6. เข้าถึงและแสดงข้อมูลเช่นตำแหน่งโหนด SmartArt, ระดับ และข้อความ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสต์ชนิดรูปทรงเป็น SmartArt
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

## **เข้าถึงโหนดลูก SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงโหนดลูกที่เป็นส่วนของโหนดต่าง ๆ ของรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และทำการแคสต์ชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. วนผ่าน [**Nodes**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArt#getAllNodes--) ทั้งหมดภายใน SmartArt Shape
6. สำหรับแต่ละ [**Node**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode) ที่เลือกของรูปทรง SmartArt, วนผ่าน [**Child Nodes**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode#getChildNodes--) ทั้งหมดภายในโหนดโดยเฉพาะ
7. เข้าถึงและแสดงข้อมูลเช่นตำแหน่งของ [**Child Node**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ระดับและข้อความ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
    for (IShape shape : slide.getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสต์ชนิดรูปทรงเป็น SmartArt
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

## **เข้าถึงโหนดลูก SmartArt ในตำแหน่งเฉพาะ**
ในตัวอย่างนี้เราจะเรียนรู้การเข้าถึงโหนดลูกในตำแหน่งบางอย่างของโหนดต่าง ๆ ของรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. เพิ่มรูปทรง [**StackedList**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType#StackedList) type SmartArt
4. เข้าถึงรูปทรง SmartArt ที่เพิ่มแล้ว
5. เข้าถึงโหนดที่ดัชนี 0 ของรูปทรง SmartArt ที่เข้าถึงได้
6. ตอนนี้, เข้าถึง [**Child Node**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ที่ตำแหน่ง 1 ของโหนด SmartArt ที่เข้าถึงโดยใช้เมธอด **get_Item()**
7. เข้าถึงและแสดงข้อมูลเช่นตำแหน่งของ [**Child Node**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ระดับและข้อความ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของการนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปทรง SmartArt ในสไลด์แรก
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
ในตัวอย่างนี้เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และทำการแคสต์ชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. ตรวจสอบว่า [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) มีโหนดมากกว่า 0 หรือไม่
6. เลือกโหนด SmartArt ที่ต้องการลบ
7. ตอนนี้, ลบโหนดที่เลือกโดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 
8. บันทึก Presentation

```java
import com.aspose.slides.*;

// โหลดการนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสต์ชนิดรูปทรงเป็น SmartArt
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
    
    // บันทึกการนำเสนอ
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโหนด SmartArt จากตำแหน่งเฉพาะ**
ในตัวอย่างนี้เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt ที่ตำแหน่งเฉพาะ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และทำการแคสต์ชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. เลือกโหนดรูปทรง SmartArt ที่ดัชนี 0
6. ตอนนี้, ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดลูกมากกว่า 2 หรือไม่
7. ตอนนี้, ลบโหนดที่ตำแหน่ง **1** โดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)
8. บันทึก Presentation

```java
import com.aspose.slides.*;

// โหลดการนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof SmartArt) 
        {
            // แคสต์ชนิดรูปทรงเป็น SmartArt
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
    
    // บันทึกการนำเสนอ
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดตำแหน่งแบบกำหนดเองสำหรับโหนดลูกในวัตถุ SmartArt**
ตอนนี้ Aspose.Slides for Java รองรับการตั้งค่าคุณสมบัติ [SmartArtShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#setX-float-) และ [Y](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#setY-float-) โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าตำแหน่ง, ขนาด และการหมุนของ SmartArtShape อย่างกำหนดเอง โปรดทราบว่าการเพิ่มโหนดใหม่จะทำให้ตำแหน่งและขนาดของทุกโหนดถูกคำนวณใหม่ อีกทั้งด้วยการตั้งค่าตำแหน่งแบบกำหนดเอง ผู้ใช้สามารถกำหนดโหนดตามความต้องการ

```java
import com.aspose.slides.*;

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
{{% alert color="info" %}} 

ในบทความนี้เราจะสำรวจคุณลักษณะเพิ่มเติมของรูปทรง SmartArt ที่เพิ่มในสไลด์การนำเสนอโดยโปรแกรมโดยใช้ Aspose.Slides for Java

{{% /alert %}} 

เราจะใช้รูปทรง SmartArt ต้นฉบับต่อไปนี้สำหรับการสำรวจในส่วนต่าง ๆ ของบทความนี้

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**รูป: รูปทรง SmartArt ต้นฉบับในสไลด์**|

ในตัวอย่างโค้ดต่อไปนี้เราจะสำรวจวิธีระบุ **Assistant Nodes** ในคอลเลกชันโหนด SmartArt และการเปลี่ยนแปลงพวกมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์ที่สองโดยใช้ Index ของมัน
3. วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หรือไม่และทำการแคสต์ชนิดรูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) หากเป็น SmartArt
5. วนผ่านโหนดทั้งหมดภายในรูปทรง SmartArt และตรวจสอบว่าพวกมันเป็น [**Assistant Nodes**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtNode#isAssistant--) หรือไม่
6. เปลี่ยนสถานะของ Assistant Node ให้เป็นโหนดปกติ
7. บันทึก Presentation

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของการนำเสนอ
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดภายในสไลด์แรก
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (shape instanceof ISmartArt) 
        {
            // แคสต์ชนิดรูปทรงเป็น SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // วนผ่านโหนดทั้งหมดของรูปทรง SmartArt
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
    
    // บันทึกการนำเสนอ
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**รูป: Assistant Nodes ถูกเปลี่ยนในรูปทรง SmartArt ภายในสไลด์**|

## **ตั้งค่ารูปแบบการเติมสีของโหนด**
Aspose.Slides for Java ทำให้สามารถเพิ่มรูปทรง SmartArt ที่กำหนดเองและตั้งค่ารูปแบบการเติมสีของมันได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปทรง SmartArt และตั้งค่ารูปแบบการเติมสีโดยใช้ Aspose.Slides for Java

กรุณาปฏิบัติตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มรูปทรง [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArt) โดยตั้งค่า [**LayoutType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)
4. ตั้งค่า [**FillFormat**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getFillFormat--) สำหรับโหนดรูปทรง SmartArt
5. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของการนำเสนอ
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มรูปทรง SmartArt และโหนด
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // ตั้งค่าสีเติมของโหนด
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // บันทึกการนำเสนอ
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างภาพย่อของโหนดลูก SmartArt**
นักพัฒนาสามารถสร้างภาพย่อของโหนดลูกของ SmartArt โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
2. [Add SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. รับอ้างอิงของโหนดโดยใช้ Index ของมัน
4. รับภาพย่อ
5. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX 
Presentation pres = new Presentation();
try {
    // เพิ่ม SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // รับอ้างอิงของโหนดโดยใช้ Index ของมัน  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // ดึงภาพขนาดย่อ
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // บันทึกภาพขนาดย่อ
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

### รองรับการทำแอนิเมชันของ SmartArt หรือไม่?

ใช่ SmartArt ถูกจัดเป็นรูปทรงปกติ ดังนั้นคุณสามารถ [ใช้แอนิเมชันมาตรฐาน](/slides/th/java/shape-animation/) (เข้ามา, ออกจาก, เน้น, เส้นทางการเคลื่อนที่) และปรับเวลาได้ คุณยังสามารถทำแอนิเมชันรูปทรงภายในโหนด SmartArt เมื่อจำเป็น

### จะหาตำแหน่ง SmartArt ใดโดยเฉพาะบนสไลด์ได้อย่างไรหาก ID ภายในไม่ทราบ?

กำหนดและค้นหาด้วย [ข้อความทางเลือก]https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getAlternativeText--) การตั้งค่า AltText ที่โดดเด่นบน SmartArt จะทำให้คุณค้นพบได้โดยโปรแกรมโดยไม่ต้องอ้างอิงตัวระบุภายใน

### รูปแบบของ SmartArt จะคงที่เมื่อแปลงการนำเสนอเป็น PDF หรือไม่?

ใช่ Aspose.Slides ทำการเรนเดอร์ SmartArt ด้วยคุณภาพภาพสูงในระหว่างการ [ส่งออกเป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/) คงการจัดวาง, สี, และเอฟเฟ็กต์

### สามารถสกัดภาพของ SmartArt ทั้งหมด (สำหรับตัวอย่างหรือรายงาน) ได้หรือไม่?

ใช่ คุณสามารถเรนเดอร์รูปทรง SmartArt ไปเป็น [รูปแบบเรสเตอร์]https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-) หรือเป็น [SVG](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) เพื่อให้ได้ผลลัพธ์เวกเตอร์ที่ปรับขนาดได้เหมาะสำหรับภาพย่อ, รายงาน หรือการใช้งานบนเว็บ