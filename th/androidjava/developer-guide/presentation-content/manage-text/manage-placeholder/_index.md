---
title: จัดการ Placeholder ของการนำเสนอบน Android
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/androidjava/manage-placeholder/
keywords:
- ตำแหน่งตัวแทน
- ตำแหน่งตัวแทนข้อความ
- ตำแหน่งตัวแทนภาพ
- ตำแหน่งตัวแทนแผนภูมิ
- ข้อความเตือน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการ placeholder ใน Aspose.Slides สำหรับ Android ผ่าน Java อย่างง่ายดาย: แทนที่ข้อความ ปรับแต่งข้อความเตือน และตั้งค่าความโปร่งใสของภาพใน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการ placeholder ของงานนำเสนอได้ด้วยโปรแกรม บทความนี้อธิบายวิธีค้นหา placeholder บนสไลด์และเปลี่ยนข้อความของมัน ตั้งค่าข้อความ prompt แบบกำหนดเองสำหรับ layout ของ placeholder และปรับความโปร่งใสของภาพที่ใช้เป็นพื้นหลังของ placeholder นอกจากนี้ยังมี FAQ สั้น ๆ ที่ชี้แจงความแตกต่างระหว่าง base placeholder กับ local shape อธิบายวิธีการนำการเปลี่ยนแปลงของ placeholder ไปใช้ผ่าน layout หรือ master และชี้ไปที่การจัดการ placeholder ของ header และ footer

## **เปลี่ยนข้อความใน Placeholder**
โดยใช้ [Aspose.Slides for Android via Java](/slides/th/androidjava/), คุณสามารถค้นหาและแก้ไข placeholder บนสไลด์ในงานนำเสนอได้ Aspose.Slides อนุญาตให้คุณเปลี่ยนแปลงข้อความใน placeholder

**ข้อกำหนดเบื้องต้น**: คุณต้องการงานนำเสนอที่มี placeholder คุณสามารถสร้างงานนำเสนอเช่นนั้นในแอป Microsoft PowerPoint มาตรฐาน

นี่คือวิธีที่คุณใช้ Aspose.Slides เพื่อแทนที่ข้อความใน placeholder ของงานนำเสนนั้น:

1. สร้างอินสแตนซ์ของคลาส [`Presentation`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) และส่งงานนำเสนอเป็นอาร์กิวเมนต์
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. วนซ้ำผ่าน shapes เพื่อค้นหา placeholder
4. แปลงประเภทของ shape placeholder เป็น [`AutoShape`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AutoShape) แล้วเปลี่ยนข้อความโดยใช้ [`TextFrame`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrame) ที่เชื่อมโยงกับ [`AutoShape`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AutoShape)
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีเปลี่ยนข้อความใน placeholder:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // วนลูปผ่าน shapes เพื่อค้นหา placeholder
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // เปลี่ยนข้อความในแต่ละ placeholder
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าข้อความ Prompt ใน Placeholder**
เลเอาต์มาตรฐานและที่สร้างล่วงหน้ามีข้อความ prompt ของ placeholder เช่น ***Click to add a title*** หรือ ***Click to add a subtitle*** คุณสามารถแทรกข้อความ prompt ที่คุณต้องการลงในเลเอาต์ของ placeholder ด้วย Aspose.Slides

โค้ด Java นี้แสดงวิธีตั้งค่าข้อความ prompt ใน placeholder:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // วนลูปผ่านสไลด์
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint แสดง "คลิกเพื่อเพิ่มชื่อเรื่อง"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // เพิ่มหัวเรื่องย่อย
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าความโปร่งใสของภาพ Placeholder**

Aspose.Slides ช่วยให้คุณตั้งค่าความโปร่งใสของภาพพื้นหลังใน placeholder ของข้อความ โดยการปรับความโปร่งใสของภาพในกรอบดังกล่าว คุณสามารถทำให้ข้อความหรือภาพเด่นชัดขึ้น (ขึ้นอยู่กับสีของข้อความและภาพ)

โค้ด Java นี้แสดงวิธีตั้งค่าความโปร่งใสสำหรับภาพพื้นหลัง (ภายใน shape):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**Base placeholder คืออะไร และแตกต่างจาก local shape บนสไลด์อย่างไร?**

Base placeholder คือ shape เดิมบน layout หรือ master ที่ shape ของสไลด์สืบทอด—ประเภท, ตำแหน่งและการจัดรูปแบบบางส่วนมาจากมัน ส่วน local shape เป็นอิสระ; หากไม่มี base placeholder การสืบทอดจะไม่เกิดขึ้น

**ฉันจะอัปเดตหัวเรื่องหรือคำอธิบายทั้งหมดทั่วทั้งงานนำเสนอโดยไม่ต้องวนลูปทุกสไลด์ได้อย่างไร?**

แก้ไข placeholder ที่สอดคล้องบน layout หรือ master สไลด์ที่ใช้ layout/ master เหล่านั้นจะสืบทอดการเปลี่ยนแปลงโดยอัตโนมัติ

**ฉันจะควบคุม placeholder ของ header/footer มาตรฐาน—วันที่และเวลา, หมายเลขสไลด์, และข้อความ footer ได้อย่างไร?**

ใช้ผู้จัดการ HeaderFooter ที่ระดับที่เหมาะสม (สไลด์ปกติ, layout, master, notes/handouts) เพื่อเปิดหรือปิด placeholder เหล่านั้นและตั้งค่าขอบเนื้อหา