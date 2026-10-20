---
title: ปรับขนาดรูปทรมาณบนสไลด์การนำเสนอใน Android
type: docs
weight: 130
url: /th/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปทรง
- เปลี่ยนขนาดรูปทรง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Aspose.Slides
description: "ปรับขนาดรูปทรงบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java—การปรับแต่งเลย์เอาต์สไลด์อัตโนมัติและเพิ่มประสิทธิภาพการทำงาน"
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณอาจต้องปรับขนาดและตำแหน่งของรูปทรงเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีปรับขนาดรูปทรงด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลย์เอาต์

## **ปรับขนาดรูปทรง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปทรง ให้คูณพิกัดแนวนอนและความกว้างของรูปทรงด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างต้นฉบับ ใช้อัตราส่วนความสูงที่สอดคล้องกันกับพิกัดแนวตั้งและความสูงของรูปทรง

ตัวอย่างแรกโหลดงานนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ มันใช้ [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) พร้อมกับ [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) เพื่อให้ลูปถัดไปควบคุมการสเกล อัตราส่วนเป็นค่าที่ไม่มีหน่วย; ตำแหน่งและมิติของรูปทรงวัดเป็นจุด อัตราส่วนความกว้างและความสูงที่แตกต่างกันอาจทำให้รูปทรงบิดเบี้ยว และการเปลี่ยนแปลงมิติของรูปทรงจะไม่สเกลขนาดฟอนต์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // คำนวณตัวคูณสเกลแนวนอนและแนวตั้งแบบอิสระ.
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
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่มากขึ้น
{{% /alert %}}

ตัวอย่างที่สองสนับสนุนตารางและประมวลผลรูปทรงบนมาสเตอร์และเลย์เอาต์ รวมถึงสไลด์แต่ละอันก่อนบันทึกงานนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการแต่ละ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) โดยสเกลความกว้างของคอลัมน์ด้วย [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) และความสูงขั้นต่ำของแถวด้วย [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) จากนั้นสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมของตารางแยกต่างหาก

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
    // คำนวณตัวคูณสเกลแนวนอนและแนวตั้งแบบอิสระ.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // ปรับขนาดรูปทรงที่กำหนดบนมาสเตอร์และเลย์เอาต์รวมทั้งสไลด์แต่ละอัน.
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

หากคุณเปลี่ยนขนาดสไลด์โดยไม่สเกลรูปทรง รูปทรงจะคงตำแหน่งและมิติเดิมและอาจยืดออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปทรงบิดเบี้ยวได้

**โค้ดที่ให้มาทำงานกับรูปทรงทุกประเภทหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปทรงโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเลย์เอาต์ที่ได้โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**

สเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวด้วยอัตราส่วนความสูง แล้วสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลย์เอาต์สไลด์หรือไม่?**

ใช่ ตัวอย่างที่สองวนผ่าน [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) และ [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) ของแต่ละมาสเตอร์และใช้ตรรกะการปรับขนาดเดียวกันกับรูปทรงของพวกมัน

**ฉันสามารถเปลี่ยนแนวสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ได้ เรียก [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิตุตามเป้าหมาย เพื่อให้ค่าสเกลสะท้อนแนวสไลด์สุดท้าย

**มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถระบุขนาดสไลด์ที่กำหนดเองด้วย [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) การรองรับขนาดยังขึ้นอยู่กับรูปแบบของงานนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์

**ฉันจะป้องกันไม่ให้รูปทรงที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

ใช้ค่าสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลย์เอาต์ต้นฉบับพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าที่น้อยกว่าระหว่างอัตราส่วนความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้รักษาอัตราส่วนไว้แต่บางครั้งอาจทำให้เหลือพื้นที่ว่างที่ขอบหนึ่งของสไลด์