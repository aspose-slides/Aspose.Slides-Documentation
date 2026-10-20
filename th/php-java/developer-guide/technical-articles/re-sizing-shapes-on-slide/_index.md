---
title: ปรับขนาดรูปร่างบนสไลด์การนำเสนอใน PHP
type: docs
weight: 130
url: /th/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /th/php-java/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปทรง
- เปลี่ยนขนาดรูปทรง
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับขนาดรูปทรงบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP ผ่าน Java—อัตโนมัติการปรับแต่งเค้าโครงสไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของการนำเสนอ คุณอาจต้องปรับขนาดและย้ายตำแหน่งรูปทรงเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีการย่อขนาดรูปทรงด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์และเลเอาต์

## **ปรับขนาดรูปทรง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปทรง ให้คูณค่าพิกัดแนวนอนและความกว้างของรูปทรงด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม แล้วใช้ค่าอัตราส่วนความสูงที่สอดคล้องกับพิกัดแนวตั้งและความสูงของรูปทรง

ตัวอย่างแรกโหลดการนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ ใช้ [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) กับ [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) เพื่อให้ลูปต่อมาควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและขนาดของรูปทรงวัดเป็นพอยท์ อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปทรงบิดเบือน และการเปลี่ยนขนาดของรูปทรงไม่ได้สเกลขนาดฟอนต์

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    //    คำนวณตัวประกอบการสเกลแนวนอนและแนวตั้งอย่างอิสระ.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงโดยรวมของตาราง ความสูงของแถวอาจคงใหญ่กว่าที่ต้องการหากเนื้อหาในเซลล์ต้องการพื้นที่มากขึ้น
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปทรงบนมาสเตอร์และเลเอาท์รวมถึงสไลด์บุคคลก่อนบันทึกการนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการแต่ละ [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) โดยสเกลความกว้างของคอลัมน์ด้วย [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) และความสูงขั้นต่ำของแถวด้วย [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) จากนั้นสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมของตารางแยกออก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                //                มิติของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    //    คำนวณตัวประกอบการสเกลแนวนอนและแนวตั้งอย่างอิสระ.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    //    ปรับขนาดรูปทรงที่กำหนดบนมาสเตอร์และเลเอาต์รวมถึงสไลด์แต่ละอัน.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **ถามตอบ**

**ทำไมรูปทรงจึงบิดเบือนหรือถูกตัดเมื่อปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่สเกลรูปทรง รูปทรงจะคงตำแหน่งและขนาดเดิมและอาจขยายออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปทรงบิดเบือนได้

**โค้ดที่ให้มาทำงานกับรูปทรงทุกประเภทหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปทรงโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเค้าโครงที่ได้โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาของตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

สเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวด้วยอัตราส่วนความสูง จากนั้นสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลเอาต์สไลด์หรือไม่?**

ใช่ ตัวอย่างที่สองวนผ่าน [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) และ [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) ของแต่ละมาสเตอร์และใช้ตรรกะการปรับขนาดเดียวกันกับรูปทรงของพวกเขา

**ฉันสามารถเปลี่ยนแนวสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ใช่ เรียก [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ปัจจัยสเกลสะท้อนแนวสุดท้าย

**มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถกำหนดมิติสไลด์ที่กำหนดเองด้วย [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) มิติที่สนับสนุนขึ้นอยู่กับรูปแบบการนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์

**ฉันจะป้องกันไม่ให้รูปทรงที่มีอัตราส่วนคงที่บิดเบือนได้อย่างไร?**

ใช้ปัจจัยสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เค้าโครงเดิมพอดีกับมิติใหม่ของสไลด์ ให้ใช้ค่าอัตราส่วนที่เล็กกว่าระหว่างความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้รักษาอัตราส่วนไว้แต่อาจทำให้มีพื้นที่ว่างเหลืออยู่ที่ขอบหนึ่ง  