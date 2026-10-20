---
title: ปรับขนาดรูปร่างบนสไลด์งานนำเสนอใน Android
type: docs
weight: 130
url: /th/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/ปรับ-ขนาด-รูปร่างบน-สไลด์/
  - /th/androidjava/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายด้วย Aspose.Slides สำหรับ Android ผ่าน Java—อัตโนมัติการปรับเลเอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณอาจจำเป็นต้องปรับขนาดและเปลี่ยนตำแหน่งของรูปร่างเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีปรับขนาดรูปร่างด้วยตนเองและวิธีจัดการตารางบนสไลด์ ไมสเตอร์ และเลเอาต์

## **ปรับขนาดรูปร่าง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างของมันด้วยอัตราส่วนของความกว้างสไลด์ใหม่เทียบกับความกว้างเดิม แล้วใช้ค่าอัตราส่วนความสูงที่สอดคล้องกันกับพิกัดแนวตั้งและความสูงของมัน

ตัวอย่างแรกโหลดงานนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ มันใช้ [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) พร้อมกับ [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) เพื่อให้ลูปต่อมาควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและมิติของรูปร่างวัดเป็นพอยต์ อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปร่างบิดเบี้ยว และการเปลี่ยนขนาดของรูปร่างจะไม่สเกลขนาดตัวอักษร

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // คำนวณตัวคูณสเกลแนวนอนและแนวตั้งที่อิสระ.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงโดยรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ต้องการหากเนื้อหาในเซลล์ต้องการพื้นที่มากกว่า
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและดำเนินการกับรูปร่างบนมาสเตอร์และเลเอาต์ รวมทั้งสไลด์เดี่ยว ก่อนบันทึกงานนำเสนอที่ปรับขนาดแล้ว ตัวช่วยของมันจัดการ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) แต่ละรายการโดยสเกลความกว้างของคอลัมน์ด้วย [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) และความสูงขั้นต่ำของแถวด้วย [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) จากนั้นสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมของมันแยกออก

```java
import com.aspose.slides.*;

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
    // คำนวณตัวคูณสเกลแนวนอนและแนวตั้งที่อิสระ.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลเอาต์รวมถึงสไลด์แต่ละอัน.
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

**ทำไมรูปร่างจึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่ได้สเกลรูปร่าง พวกมันจะคงตำแหน่งและมิติเดิมและอาจยืดออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปร่างบิดเบี้ยวเช่นกัน

**โค้ดที่ให้มาทำงานได้กับทุกประเภทของรูปร่างหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเลเอาต์ที่ได้ โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**

สเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวด้วยอัตราส่วนความสูง จากนั้นสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลเอาต์สไลด์หรือไม่?**

ใช่ ตัวอย่างที่สองวนลูปผ่าน [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) และ [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) ของแต่ละมาสเตอร์และใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกเขา

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ใช่ เรียกใช้ [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ค่าอัตราส่วนสอดคล้องกับทิศทางสุดท้าย

**มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถระบุขนาดสไลด์ที่กำหนดเองได้ด้วย [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) มิติที่รองรับขึ้นอยู่กับรูปแบบงานนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์ด้วย

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

ใช้ค่าอัตราส่วนเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลเอาต์เดิมพอดีกับมิติใหม่ของสไลด์ ให้ใช้ค่าอัตราส่วนที่เล็กกว่าระหว่างความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้จะรักษาสัดส่วนไว้ แต่บางครั้งอาจทิ้งพื้นที่ว่างที่ขอบหนึ่ง