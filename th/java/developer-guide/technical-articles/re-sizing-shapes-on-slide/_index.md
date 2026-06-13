---
title: ปรับขนาดรูปร่างบนสไลด์พรีเซนเทชัน
type: docs
weight: 110
url: /th/java/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument ได้อย่างง่ายดายด้วย Aspose.Slides for Java—ทำการปรับเลเอาต์สไลด์อัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides for Java คือวิธีปรับขนาดรูปร่างเพื่อให้เมื่อขนาดสไลด์เปลี่ยนแปลง ข้อมูลไม่ได้ถูกตัดออก บทความทางเทคนิคสั้นนี้แสดงวิธีทำเช่นนั้น

## **ปรับขนาดรูปร่าง**

เพื่อป้องกันไม่ให้รูปร่างเลื่อนตำแหน่งเมื่อขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและขนาดของแต่ละรูปร่างให้สอดคล้องกับเลเอาต์สไลด์ใหม่

```java
// โหลดไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation("sample.ppt");
try {
    // รับขนาดสไลด์เดิม.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างเดิม.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // รับขนาดสไลด์ใหม่.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // ปรับขนาดและเปลี่ยนตำแหน่งรูปร่างบนสไลด์ทุกหน้า.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // สเกลขนาดรูปร่าง.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // สเกลตำแหน่งรูปร่าง.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 
หากสไลด์มีตาราง โค้ดข้างต้นจะทำงานไม่ถูกต้อง ในกรณีนั้นต้องปรับขนาดเซลล์แต่ละเซลล์ในตาราง
{{% /alert %}} 

ใช้โค้ดต่อไปนี้ในส่วนของคุณเพื่อปรับขนาดสไลด์ที่มีตาราง สำหรับตาราง การตั้งค่าความกว้างหรือความสูงเป็นกรณีพิเศษ: คุณต้องปรับความสูงของแถวและความกว้างของคอลัมน์แต่ละอันเพื่อเปลี่ยนขนาดโดยรวมของตาราง

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // รับขนาดสไลด์เดิม.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างเดิม.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // รับขนาดสไลด์ใหม่.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // สเกลขนาดรูปร่าง.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // สเกลตำแหน่งรูปร่าง.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // สเกลขนาดรูปร่าง.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // สเกลตำแหน่งรูปร่าง.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // สเกลขนาดรูปร่าง.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // สเกลตำแหน่งรูปร่าง.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ทำไมรูปร่างถึงเสียรูปหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**

เมื่อปรับขนาดสไลด์ รูปร่างจะคงตำแหน่งและขนาดเดิมไว้ เว้นแต่จะเปลี่ยนสเกลโดยเจตนา ซึ่งอาจทำให้เนื้อหาถูกตัดหรือลูกศรเสียตำแหน่ง

**โค้ดที่ให้ทำงานได้กับทุกประเภทของรูปร่างหรือไม่?**

ตัวอย่างพื้นฐานทำงานกับรูปแบบรูปร่างส่วนใหญ่ (กล่องข้อความ, รูปภาพ, แผนภูมิ เป็นต้น) อย่างไรก็ตาม สำหรับตาราง คุณต้องจัดการแถวและคอลัมน์แยกกัน เนื่องจากความสูงและความกว้างของตารางกำหนดโดยขนาดของเซลล์แต่ละเซลล์

**ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**

คุณต้องวนลูปผ่านทุกแถวและคอลัมน์ของตารางและปรับความสูงและความกว้างของพวกมันให้สัดส่วนตามที่แสดงในตัวอย่างโค้ดที่สอง

**การปรับขนาดนี้จะทำงานกับสไลด์แม่และสไลด์เลเอาต์หรือไม่?**

ใช่ แต่คุณควรวนลูปผ่าน [Masters](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getMasters--) และ [Layout slides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getLayoutSlides--) แล้วใช้ตรรกะการสเกลเดียวกันกับรูปร่างของพวกมันเพื่อให้แน่ใจว่าการนำเสนอทั้งหมดสอดคล้องกัน

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ใช่ คุณสามารถใช้ [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidesize/#setOrientation-int-) เพื่อเปลี่ยนทิศทาง อย่าลืมตั้งค่าตรรกะการสเกลให้เหมาะสมเพื่อรักษาเลเอาต์

**มีขีดจำกัดของขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

Aspose.Slides รองรับขนาดที่กำหนดเอง แต่ขนาดที่ใหญ่เกินไปอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับบางเวอร์ชันของ PowerPoint

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่เสียรูปได้อย่างไร?**

คุณสามารถตรวจสอบเมธอด `getAspectRatioLocked` ของรูปร่างก่อนทำการสเกล หากถูกล็อก ให้ปรับความกว้างหรือความสูงอย่างสัดส่วนแทนการสเกลแยกกัน