---
title: ดึงและอัปเดตคุณสมบัติมุมมองงานนำเสนอใน PHP
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/php-java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาเค้าโครง
- ไอคอนเค้าโครง
- การซ้บแถบแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การขยายเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อกำหนดค่าการจัดวางมุมมองปกติ การขยายสไลด์และบันทึก การตั้งค่าระยะห่างของตาราง และการแสดงความเห็นในงานนำเสนอ PowerPoint."
---
## **บทนำ**

ในมุมมองปกติของ PowerPoint สไลด์จะแสดงระหว่างแผงด้านข้างสำหรับภาพย่อหรือเค้าโครงและแผงบันทึกด้านล่าง Aspose.Slides for PHP ผ่าน Java เปิดเผยการตั้งค่าการแก้ไขที่บันทึกไว้ของงานนำเสนอผ่าน [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). การตั้งค่าเหล่านี้รวมถึงการจัดวางแผง ระดับการขยาย ระยะห่างของตาราง และการแสดงความเห็น

## **เกี่ยวกับ NormalViewProperties**

ใช้ [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) เพื่อเข้าถึงคลาส [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) . [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) ควบคุมว่ามีไอคอนแสดงข้างชื่อสไลด์ในเค้าโครงหรือไม่. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) ทำให้แผงด้านข้างสลับไปยังสถานะย่อเมื่อผู้ใช้ทำให้แคบลง. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) บ่งบอกถึงความต้องการให้แสดงเพียงแผงเดียวในหน้าต่างเต็ม

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) ควบคุมตัวแบ่งระหว่างแผงด้านข้างและสไลด์. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) ควบคุมตัวแบ่งเหนือแผงบันทึก. ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) ที่เป็น `Minimized`, `Maximized`, หรือ `Restored`.

## **เกี่ยวกับการคืนค่า NormalViewProperties**

เมื่อตัวแบ่งถูกคืนค่า, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) ให้ขนาดที่บันทึกของแผงด้านข้างและ [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) ให้ขนาดที่บันทึกของพื้นที่สไลด์ส่วนบน. ทั้งสองเปิดเผย [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). วิธี [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) ของมันรับเปอร์เซ็นต์จาก 0 ถึง 100, และ [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) ควบคุมว่าตัวแก้ไขจะปรับขนาดเมื่อหน้าต่างเปลี่ยนขนาดหรือไม่

ตัวอย่างนี้อัปเดตงานนำเสนอที่มีอยู่. มันคืนค่าตัวแบ่งแนวราบ, ตั้งค่าขนาดที่ได้จาก [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) เป็น 80% พร้อมเปิดการปรับอัตโนมัติ, และขยายตัวแบ่งแนวตั้งเต็ม. มันยังเรียก [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) เพื่อแสดงไอคอนในมุมมองเค้าโครง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กำหนดค่าการซูมเริ่มต้น**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) และ [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) เก็บการตั้งค่าการซูมแยกกันสำหรับตัวแก้ไข. การตั้งค่าเหล่านี้ไม่กระทบต่อมิติของสไลด์, การเล่นสไลด์โชว์, หรือความละเอียดของการส่งออกภาพ

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเรียก [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) เพื่อตั้งให้สไลด์พอดีกับหน้าต่างการแก้ไข. สำหรับหน้าบันทึก, มันปิดการปรับขนาดอัตโนมัติและเรียก [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) เพื่อตั้งค่าเป็นการซูมคงที่ 80%

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าระยะห่างของตาราง**

เมธอด `setGridSpacing` ของ [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) กำหนดระยะห่างระหว่างเส้นตารางการแก้ไขทั่วทั้งงานนำเสนอ. มันรับค่าบวกเป็นหน่วยจุด, โดย 72 จุดต่อหนึ่งนิ้ว. ตัวอย่างนี้พิมพ์ค่าระยะห่างปัจจุบันในงานนำเสนอที่มีอยู่และบันทึกตารางความกว้างหนึ่งในสี่นิ้วโดยตั้งค่าเป็นช่วง 18 จุด

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ตารางจะทำซ้ำที่ช่วงเวลาคงที่. [แนวทางการวาด](/slides/th/php-java/drawing-guides/) ทำเครื่องหมายตำแหน่งแนวนอนหรือแนวตั้งแต่ละตำแหน่ง. ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและปรากฏเฉพาะในตัวแก้ไขที่แสดงพวกมัน. การแสดงสไลด์และการส่งออกเป็น PDF, ภาพ, หรือ SVG จะไม่รวมสิ่งเหล่านี้

## **แสดงหรือซ่อนความเห็นเมื่อเปิดงานนำเสนอ**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) จัดเก็บค่าตั้งค่าที่ตัวแก้ไขที่รองรับจะใช้เมื่อเปิดงานนำเสนอ. สำหรับงานนำเสนอที่มีความเห็นอยู่, ตัวอย่างนี้พิมพ์การตั้งค่าปัจจุบันและบันทึกสำเนาที่ซ่อนความเห็น. มันยังเรียก [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) กับ [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) เพื่อให้สำเนาเปิดในมุมมองสไลด์

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การซ่อนความเห็นจะคงรักษาข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะของความเห็นไว้. หากต้องการเปลี่ยนความเห็นเอง, ดูที่ [ความเห็นของงานนำเสนอ](/slides/th/php-java/presentation-comments/). การตั้งค่าการส่งออกจะกำหนดว่าความเห็นจะแสดงใน PDF, HTML, ภาพ, บันทึก, หรือเอกสารแจกจ่ายหรือไม่

## **คำถามที่พบบ่อย**

**ทำไมตารางถึงซ่อนเมื่อฉันเปิดงานนำเสนอใหม่อีกครั้ง?**  
งานนำเสนอจะบันทึกช่วงระยะของตาราง. เพื่อดูตาราง, ให้เปิดการแสดงตารางในตัวแก้ไข.

**การลบ drawing guides มีผลต่อระยะห่างของตารางหรือไม่?**  
ไม่. การเพิ่ม, ย้าย, หรือการลบ guide จะไม่เปลี่ยนช่วงระยะของตาราง.

**แต่ละส่วนของงานนำเสนอสามารถมีการตั้งค่าการมองเห็นที่แตกต่างกันได้หรือไม่?**  
ไม่. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) ใช้กับงานนำเสนอทั้งหมด.

**ฉันสามารถบันทึกการตั้งค่าการมองเห็นที่แตกต่างสำหรับผู้ใช้ที่แตกต่างกันได้หรือไม่?**  
ไฟล์จะบันทึกชุดการตั้งค่าการมองเห็นเดียวสำหรับทุกคน. ตัวแก้ไขอาจใช้ค่าการตั้งค่าท้องถิ่นของผู้ใช้ด้วย.

**ฉันสามารถบันทึกการตั้งค่าการมองเห็นในเทมเพลตได้หรือไม่?**  
ได้. งานนำเสนอที่สร้างจากเทมเพลตจะสืบทอดการตั้งค่าการมองเห็นที่บันทึกไว้.