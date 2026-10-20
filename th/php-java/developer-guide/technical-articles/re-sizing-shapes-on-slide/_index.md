---
title: ปรับขนาดรูปร่างบนสไลด์พรีเซนเทชันใน PHP
type: docs
weight: 130
url: /th/php-java/resizing-shapes-on-slide/
aliases:
  - /th/php-java/re-sizing-shapes-on-slide/
keywords:
  - ปรับขนาดรูปร่าง
  - เปลี่ยนขนาดรูปร่าง
  - PowerPoint
  - OpenDocument
  - การนำเสนอ
  - PHP
  - Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP ผ่าน Java—ทำการปรับการจัดวางสไลด์โดยอัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานพรีเซนเทชัน คุณอาจต้องปรับขนาดและตำแหน่งของรูปร่างเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีสเกลรูปร่างด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลเอาต์

## **ปรับขนาดรูปร่าง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างของรูปร่างด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม ใช้อัตราส่วนความสูงที่สอดคล้องกับพิกัดแนวตั้งและความสูงของรูปร่าง

ตัวอย่างแรกโหลดงานพรีเซนเทชันที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ ใช้ [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) กับ [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) เพื่อให้ลูปต่อไปควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและมิติของรูปร่างวัดเป็นจุด อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปร่างบิดเบี้ยว และการเปลี่ยนขนาดของรูปร่างไม่ได้สเกลขนาดฟอนต์

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // คำนวณอัตราสเกลแนวนอนและแนวตั้งแบบอิสระ
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
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงรวมของตาราง ความสูงของแถวอาจยังคงมากกว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่เพิ่มเติม
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปร่างบนมาสเตอร์และเลเอต์รวมถึงสไลด์แต่ละอันก่อนบันทึกงานพรีเซนเทชันที่ปรับขนาด ตัวช่วยของมันจัดการกับแต่ละ [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) โดยสเกลความกว้างของคอลัมน์ด้วย [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) และความสูงขั้นต่ำของแถวด้วย [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) จากนั้นสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมของตารางแยกออก

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
                // มิติของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
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
    // คำนวณอัตราสเกลแนวนอนและแนวตั้งแบบอิสระ.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลเอาต์พร้อมกับสไลด์แต่ละอัน.
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

## **คำถามที่พบบ่อย**

**ทำไมรูปร่างถึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**  
หากคุณเปลี่ยนขนาดสไลด์โดยไม่ได้สเกลรูปร่าง รูปร่างจะคงตำแหน่งและมิติเดิมอาจล้นออกนอกสไลด์ได้ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่แตกต่างกันก็อาจทำให้รูปร่างบิดเบี้ยวได้เช่นกัน

**โค้ดที่ให้มาทำงานกับรูปแบบรูปร่างทั้งหมดหรือไม่?**  
ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเลเอาต์ที่ได้ โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**  
สเกลความกว้างของคอลัมน์ตามอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวตามอัตราส่วนความสูง จากนั้นสเกลตำแหน่งของตาราง ตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้ทำงานกับมาสเตอร์สไลด์และเลเอาต์สไลด์หรือไม่?**  
ใช่ ตัวอย่างที่สองวนผ่าน [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) และ [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) ของแต่ละมาสเตอร์และใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกมัน

**ฉันสามารถเปลี่ยนแนวตั้ง/แนวนอนของสไลด์พร้อมกับการปรับขนาดได้หรือไม่?**  
ได้ เรียกใช้ [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ปัจจัยสเกลสะท้อนแนวตั้งหรือแนวนอนสุดท้าย

**มีขีดจำกัดขนาดสไลด์ที่สามารถตั้งค่าได้หรือไม่?**  
คุณสามารถระบุขนาดสไลด์แบบกำหนดเองด้วย [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) ได้ ขนาดที่สนับสนุนยังขึ้นกับรูปแบบของพรีเซนเทชันและแอปพลิเคชันที่ใช้เปิดไฟล์

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**  
ใช้ปัจจัยสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลเอาต์เดิมพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าอัตราส่วนที่เล็กกว่าระหว่างความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้จะรักษาสัดส่วนไว้แต่บางครั้งอาจเหลือพื้นที่ว่างที่ขอบหนึ่งของสไลด์