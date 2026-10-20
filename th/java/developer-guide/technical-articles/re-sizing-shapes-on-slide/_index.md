---
title: ปรับขนาดรูปร่างบนสไลด์งานนำเสนอใน Java
type: docs
weight: 130
url: /th/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /th/java/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายด้วย Aspose.Slides for Java—อัตโนมัติการปรับเลเอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณอาจต้องปรับขนาดและเปลี่ยนตำแหน่งของรูปทรงเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีปรับสเกลรูปทรงด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลเอาต์

## **ปรับขนาดรูปร่าง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปทรง ให้คูณค่าพิกัดแนวนอนและความกว้างของมันด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม แล้วใช้ค่าอัตราส่วนความสูงที่สอดคล้องกับพิกัดแนวตั้งและความสูงของรูปทรง

ตัวอย่างแรกโหลดงานนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ มันใช้ [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) กับ [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) เพื่อให้ลูปต่อจากนั้นควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและมิติของรูปทรงวัดเป็นจุด อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปทรงบิดเบี้ยวและการเปลี่ยนขนาดรูปทรงจะไม่สเกลขนาดฟอนต์

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // คำนวณตัวประกอบสเกลแนวนอนและแนวตั้งที่เป็นอิสระ.
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
ตารางต้องการการจัดการแยกต่างหาก: สเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่มากขึ้น
{{% /alert %}}

ตัวอย่างที่สองสนับสนุนตารางและประมวลผลรูปทรงบนมาสเตอร์และเลเอาต์รวมถึงสไลด์เดี่ยวก่อนบันทึกงานนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการแต่ละ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) โดยสเกลความกว้างของคอลัมน์ด้วย [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) และความสูงขั้นต่ำของแถวด้วย [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) จากนั้นสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมของตารางแยกออก

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
    // คำนวณตัวประกอบสเกลแนวนอนและแนวตั้งที่เป็นอิสระ.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลเอาต์รวมถึงสไลด์เดี่ยว.
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

**ทำไมรูปทรงถึงบิดเบี้ยวหรือถูกตัดหลังจากปรับขนาดสไลด์?**  
หากคุณเปลี่ยนขนาดสไลด์โดยไม่ได้สเกลรูปทรง รูปทรงจะคงตำแหน่งและมิติเก่าและอาจล้นออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปทรงบิดเบี้ยวได้

**โค้ดที่ให้มาทำงานได้กับทุกประเภทของรูปทรงหรือไม่?**  
ตัวอย่างแรกเปลี่ยนขอบเขตของรูปทรงโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเลเอาต์ผลลัพธ์โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**  
สเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวด้วยอัตราส่วนความสูง แล้วสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลเอาต์สไลด์หรือไม่?**  
ใช่ ตัวอย่างที่สองวนผ่าน [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) และ [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) ของแต่ละมาสเตอร์ แล้วนำตรรกะการปรับขนาดเดียวกันไปใช้กับรูปทรงของพวกมัน

**ฉันสามารถเปลี่ยนการวางแนวของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**  
ใช่ เรียกใช้ [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ปัจจัยสเกลสะท้อนการวางแนวสุดท้าย

**มีขีดจำกัดของขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**  
คุณสามารถกำหนดมิติสไลด์ที่กำหนดเองด้วย [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) ได้ ขนาดที่รองรับยังขึ้นอยู่กับรูปแบบของงานนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์

**ฉันจะป้องกันไม่ให้รูปทรงที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**  
ใช้ปัจจัยสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลเอาต์เดิมพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าอัตราส่วนที่เล็กกว่าระหว่างความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้รักษาส่วนสัดส่วนไว้ แต่อาจทำให้เหลือพื้นที่ว่างที่ขอบหนึ่ง