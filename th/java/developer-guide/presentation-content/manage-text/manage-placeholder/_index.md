---
title: จัดการ Placeholder ของงานนำเสนอใน Java
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/java/manage-placeholder/
keywords:
- ตัวจองตำแหน่ง
- ตัวจองตำแหน่งข้อความ
- ตัวจองตำแหน่งรูปภาพ
- ตัวจองตำแหน่งแผนภูมิ
- ข้อความพรอมต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการตัวจองตำแหน่งใน Aspose.Slides สำหรับ Java อย่างง่ายดาย: แทนที่ข้อความ, ปรับแต่งข้อความพรอมต์ และตั้งค่าความโปร่งใสของรูปภาพใน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ให้คุณจัดการ placeholder ของงานนำเสนอด้วยโปรแกรมได้ บทความนี้อธิบายวิธีค้นหา placeholder บนสไลด์และเปลี่ยนข้อความของมัน ตั้งค่าข้อความพรอมต์แบบกำหนดเองสำหรับ layout ของ placeholder และปรับความโปร่งใสของรูปภาพที่ใช้เป็นพื้นหลังของ placeholder นอกจากนี้ยังมี FAQ สั้น ๆ ที่ชี้แจงความแตกต่างระหว่าง base placeholder กับ local shape อธิบายวิธีที่การเปลี่ยนแปลง placeholder สามารถนำไปใช้ผ่าน layout หรือ master และชี้ไปยังการจัดการ placeholder ของ header และ footer

## **เปลี่ยนข้อความใน Placeholder**
ใช้ [Aspose.Slides for Java](/slides/th/java/) คุณสามารถค้นหาและแก้ไข placeholder บนสไลด์ในงานนำเสนอได้ Aspose.Slides ให้คุณทำการเปลี่ยนแปลงข้อความใน placeholder

**Prerequisite**: คุณต้องมีงานนำเสนอที่มี placeholder คุณสามารถสร้างงานนำเสนอเช่นนั้นด้วยแอป Microsoft PowerPoint มาตรฐาน

นี่คือวิธีการใช้ Aspose.Slides เพื่อแทนที่ข้อความใน placeholder ของงานนำเสนนั้น:

1. สร้างอินสแตนซ์ของคลาส [`Presentation`](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) และส่งพรีเซนเทชันเป็นอากิวเมนต์
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. วนซ้ำผ่านรูปร่างเพื่อค้นหา placeholder
4. แปลงประเภทของรูปร่าง placeholder เป็น [`AutoShape`](https://reference.aspose.com/slides/th/java/com.aspose.slides/AutoShape) แล้วเปลี่ยนข้อความโดยใช้ [`TextFrame`](https://reference.aspose.com/slides/th/java/com.aspose.slides/TextFrame) ที่เชื่อมโยงกับ [`AutoShape`](https://reference.aspose.com/slides/th/java/com.aspose.slides/AutoShape)
5. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีการเปลี่ยนข้อความใน placeholder:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // วนซ้ำผ่านรูปร่างเพื่อค้นหา placeholder
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

## **ตั้งค่าข้อความพรอมต์ใน Placeholder**
Layout มาตรฐานและที่สร้างไว้ล่วงหน้ามีข้อความพรอมต์ของ placeholder เช่น ***Click to add a title*** หรือ ***Click to add a subtitle*** ใช้ Aspose.Slides คุณสามารถแทรกข้อความพรอมต์ที่คุณต้องการลงใน layout ของ placeholder

โค้ด Java นี้แสดงวิธีการตั้งค่าข้อความพรอมต์ใน placeholder:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // วนซ้ำผ่านสไลด์
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint แสดง "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // เพิ่มคำบรรยายย่อย
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

## **ตั้งค่าความโปร่งใสของรูปภาพ Placeholder**

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสของภาพพื้นหลังใน placeholder ของข้อความ โดยการปรับความโปร่งใสของรูปภาพในกรอบดังกล่าว คุณสามารถทำให้ข้อความหรือภาพโดดเด่นขึ้น (ขึ้นอยู่กับสีของข้อความและรูปภาพ)

โค้ด Java นี้แสดงวิธีการตั้งค่าความโปร่งใสสำหรับพื้นหลังของภาพ (ภายในรูปร่าง):

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

**Placeholder พื้นฐานคืออะไรและแตกต่างจากรูปร่างแบบโลคัลบนสไลด์อย่างไร?**

Base placeholder คือรูปร่างต้นฉบับบน layout หรือ master ที่รูปร่างบนสไลด์สืบทอดจาก—ประเภท, ตำแหน่ง, และการจัดรูปแบบบางส่วนมาจากมัน ส่วน local shape นั้นเป็นอิสระ; หากไม่มี base placeholder การสืบทอดจะไม่เกิดขึ้น

**วิธีการอัปเดตหัวเรื่องหรือคาปชันทั้งหมดในงานนำเสนอโดยไม่ต้องวนซ้ำทุกสไลด์คืออะไร?**

แก้ไข placeholder ที่สอดคล้องบน layout หรือ master สไลด์ที่อิงตาม layout/ master นั้นจะสืบทอดการเปลี่ยนแปลงโดยอัตโนมัติ

**ฉันจะควบคุม placeholder มาตรฐานของ header/footer—วันที่และเวลา, หมายเลขสไลด์, และข้อความ footer ได้อย่างไร?**

ใช้ตัวจัดการ HeaderFooter ในระดับที่เหมาะสม (สไลด์ปกติ, layout, master, notes/handouts) เพื่อเปิดหรือปิด placeholder เหล่านั้นและตั้งค่าข้อความของมัน