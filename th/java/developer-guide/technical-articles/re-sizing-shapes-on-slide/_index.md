---
title: ปรับขนาดรูปร่างบนสไลด์การนำเสนอใน Java
type: docs
weight: 130
url: /th/java/resizing-shapes-on-slide/
aliases:
  - /th/java/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายด้วย Aspose.Slides สำหรับ Java—อัตโนมัติการปรับแต่งเลเอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณอาจต้องปรับขนาดและตำแหน่งของรูปร่างให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีการปรับขนาดรูปร่างด้วยตนเองและวิธีการจัดการตารางบนสไลด์ มาสเตอร์ และเลเอาต์

## **ปรับขนาดรูปร่าง**

เพื่อคงตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม แล้วนำอัตราส่วนความสูงที่สอดคล้องไปคูณพิกัดแนวตั้งและความสูง

ตัวอย่างแรกโหลดงานนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 แล้วบันทึกผลลัพธ์ ใช้ [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) ร่วมกับ [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) เพื่อให้ลูปถัดไปควบคุมการสเกล อัตราส่วนเป็นค่าที่ไม่มีหน่วย; ตำแหน่งและมิติของรูปร่างวัดเป็นพอยต์ อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปร่างบิดเบือน และการเปลี่ยนแปลงมิติของรูปร่างไม่ได้สเกลขนาดฟอนต์

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // คำนวณปัจจัยสเกลแนวนอนและแนวตั้งที่อิสระ.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
ตารางต้องการการจัดการแยกต่างหาก: ปรับความกว้างคอลัมน์และความสูงแถวแทนการกำหนดความกว้างและความสูงรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่เพิ่ม
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปร่างบนมาสเตอร์และเลเอาต์ รวมทั้งสไลด์แต่ละสไลด์ก่อนบันทึกงานนำเสนอที่ปรับขนาดแล้ว ตัวช่วยของมันจัดการกับแต่ละ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ด้วยการสเกลความกว้างคอลัมน์ผ่าน [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) และความสูงแถวขั้นต่ำผ่าน [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) จากนั้นสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมแยกต่างหาก

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // มิติของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // คำนวณปัจจัยสเกลแนวนอนและแนวตั้งที่อิสระ.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลเอาต์รวมถึงสไลด์แต่ละสไลด์.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ทำไมรูปร่างจึงบิดเบือนหรือถูกตัดออกหลังจากการปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่าง รูปร่างจะคงตำแหน่งและมิติเดิมและอาจล้นออกจากสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปร่างบิดเบือนได้เช่นกัน

**โค้ดที่ให้มาทำงานกับประเภทรูปร่างทั้งหมดหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและมุ่งเป้าไปที่สไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก โปรดตรวจสอบเลเอาต์ที่ได้ โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

สเกลความกว้างคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงแถวขั้นต่ำด้วยอัตราส่วนความสูง แล้วสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้ทำงานกับสไลด์มาสเตอร์และสไลด์เลเอาต์หรือไม่?**

ใช่ ตัวอย่างที่สองวนผ่าน [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) และ [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) ของแต่ละมาสเตอร์ และใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกมัน

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ได้ เรียกใช้ [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ค่าปัจจัยสเกลสะท้อนทิศทางสุดท้าย

**มีขีดจำกัดของขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถระบุมิติสไลด์แบบกำหนดเองด้วย [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) มิติที่รองรับขึ้นอยู่กับรูปแบบงานนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์ด้วย

**จะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบือนได้อย่างไร?**

ใช้ปัจจัยสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้แผนผังเดิมพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าอัตราส่วนที่น้อยกว่าระหว่างความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้จะคงสัดส่วนแต่บางครั้งอาจทำให้เหลือพื้นที่ว่างที่ขอบหนึ่งของสไลด์