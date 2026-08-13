---
title: ปรับขนาดรูปร่างบนสไลด์การนำเสนอ
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
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument ได้อย่างง่ายดายด้วย Aspose.Slides for Java — ทำให้การปรับแต่งเค้าโครงสไลด์อัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้าของ Aspose.Slides for Java คือวิธีการปรับขนาดรูปร่างให้เมื่อขนาดสไลด์เปลี่ยนแปลง ข้อมูลจะไม่ถูกตัดออก บทความเทคนิคสั้นนี้แสดงวิธีทำเช่นนั้น.

## **ปรับขนาดรูปร่าง**

เพื่อป้องกันไม่ให้รูปร่างเสียตำแหน่งเมื่่อขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและขนาดของแต่ละรูปร่างให้สอดคล้องกับเค้าโครงสไลด์ใหม่.

```java
import com.aspose.slides.*;

// โหลดไฟล์การนำเสนอ
Presentation presentation = new Presentation("sample.ppt");
try {
    // ดึงขนาดสไลด์เดิม
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // ดึงขนาดสไลด์ใหม่
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // ปรับขนาดและเปลี่ยนตำแหน่งรูปร่างบนทุกสไลด์
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // สเกลขนาดของรูปร่าง
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // สเกลตำแหน่งของรูปร่าง
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

{{% alert color="info" %}} 
ตารางไม่ต้องการการจัดการพิเศษ: การตั้งค่าความกว้างและความสูงของตารางจะปรับสเกลคอลัมน์และแถวโดยสัดส่วน ดังนั้นการสเกลความสูงของแถวและความกว้างของคอลัมน์อีกครั้งจะทำให้สัดส่วนถูกนำไปใช้สองครั้ง.
{{% /alert %}} 

โค้ดด้านบนเปลี่ยนเฉพาะรูปร่างบนสไลด์เท่านั้น มาสเตอร์สไลด์และเลย์เอาต์สไลด์มีรูปร่างของตนเอง ดังนั้นจึงควรปรับสเกลพวกมันเช่นกันเมื่อคุณต้องการให้การนำเสนอทั้งหมดสอดคล้องกับขนาดสไลด์ใหม่:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // ดึงขนาดสไลด์เดิม.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // ดึงขนาดสไลด์ใหม่.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // สเกลขนาดของรูปร่าง.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // สเกลตำแหน่งของรูปร่าง.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // สเกลขนาดของรูปร่าง.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // สเกลตำแหน่งของรูปร่าง.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // สเกลขนาดของรูปร่าง.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // สเกลตำแหน่งของรูปร่าง.
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

## **คำถามที่พบบ่อย**

### ทำไมรูปร่างจึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?

เมื่อปรับขนาดสไลด์ รูปร่างจะคงตำแหน่งและขนาดเดิมไว้ เว้นแต่สเกลจะถูกเปลี่ยนแปลงอย่างชัดเจน สิ่งนี้อาจทำให้เนื้อหาถูกตัดออกหรือรูปร่างเสียตำแหน่ง.

### โค้ดที่ให้มาทำงานได้กับทุกประเภทของรูปร่างหรือไม่?

ใช่ การตั้งค่าความสูงและความกว้างทำงานได้กับกล่องข้อความ รูปภาพ แผนภูมิ และตารางเช่นกัน.

### ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์ได้อย่างไร?

ปรับสเกลรูปร่างตารางเองเช่นเดียวกับรูปร่างอื่น ๆ แถวและคอลัมน์ของตารางจะตามสัดส่วนโดยอัตโนมัติ ดังนั้นไม่ควรสเกลพวกมันอีกครั้งหลังจากนั้น.

### การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลย์เอาต์สไลด์หรือไม่?

ใช่ แต่คุณควรวนลูปผ่าน [Masters](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getMasters--) และ [Layout slides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getLayoutSlides--) แล้วใช้ตรรกะการสเกลเดียวกันกับรูปร่างของพวกมันเพื่อให้การนำเสนอมีความสอดคล้องกันทั่วทั้งไฟล์.

### ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?

ใช่ คุณสามารถใช้ [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidesize/#setOrientation-int-) เพื่อเปลี่ยนทิศทางได้ ตรวจสอบให้แน่ใจว่าคุณตั้งค่าตรรกะการสเกลให้สอดคล้องเพื่อรักษาเค้าโครง.

### มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?

Aspose.Slides รองรับขนาดที่กำหนดเอง แต่ขนาดที่ใหญ่มากอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับบางเวอร์ชันของ PowerPoint.

### ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?

คุณสามารถตรวจสอบเมธอด `getAspectRatioLocked` ของรูปร่างก่อนทำการสเกล หากถูกล็อก ให้ปรับความกว้างหรือความสูงโดยสัดส่วนแทนการสเกลแยกกัน.