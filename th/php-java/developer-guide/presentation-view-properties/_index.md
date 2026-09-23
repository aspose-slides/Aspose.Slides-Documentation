---
title: ดึงและอัปเดตคุณสมบัติมุมมองของการนำเสนอใน PHP
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/php-java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแนปตัวแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides for PHP via Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับเลย์เอาต์ระดับซูมและการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติมีสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่าง ๆ. ข้อมูลนี้ช่วยให้แอปพลิเคชันบันทึกสถานะการมองเห็นลงในไฟล์ เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสภาพเดียวกับเมื่อบันทึกการนำเสนอครั้งสุดท้าย.

Method [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.  

คลาส [NormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties) และคลาสลูกของมัน, เอง enum [SplitterBarStateType](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType) ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

แทนคุณสมบัติมุมมองปกติ.

Method [getShowOutlineIcons](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

Method [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) ระบุว่าตัวแบ่งแนวตั้งควรสแนปไปสู่สถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กรุนแรงพอ.

Property [getPreferSingleView](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) และ [setPreferSingleView](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) ระบุว่าผู้ใช้ต้องการเห็นพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนการมองเห็นปกติแบบสามพื้นที่หรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาให้เต็มหน้าต่าง.

Method [getVerticalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์, แถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Maximized) และ [SplitterBarStateType::Restored](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Restored).

Method [getRestoredLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) และ [getRestoredTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties#getRestoredTop) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ เมื่อค่ [SplitterBarStateType::Restored](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) ของมุมมองปกติ เมื่อพื้นที่นั้นมีขนาดที่คืนค่าได้แบบแปรเปลี่ยน (ไม่ย่อและไม่ขยายสูงสุด).

Method [getDimensionSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

Method [getAutoAdjust](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับให้สอดคล้องกับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติของ [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) สำหรับการนำเสนอ.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # กู้คืนคุณสมบัตุมุมมองของการนำเสนอ
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **ตั้งค่าค่าซูมเริ่มต้น**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java ตอนนี้รองรับการตั้งค่าค่าซูมเริ่มต้นสำหรับการนำเสนอโดยที่เมื่อเปิดการนำเสนอแล้ว ซูมจะถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของการนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) สามารถตั้งค่าได้โดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) ใน Aspose.Slides.

{{% /alert %}} 

เพื่อกำหนดคุณสมบัติมุมมอง กรุณาปฏิบัติตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
1. บันทึกการนำเสนอเป็นไฟล์ [PPTX ](https://docs.fileformat.com/presentation/pptx/) ในตัวอย่างด้านล่าง เราได้ตั้งค่าซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```php
  $presentation = new Presentation();
  try {
    # ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // ค่า Zoom เป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // ค่า Zoom เป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **ตั้งค่าการเว้นระยะกริด**

ใช้ [Presentation::getViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getViewProperties) เพื่อเข้าถึงการตั้งค่ามุมมองทั่วทั้งการนำเสนอ. เมธอด [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/#getGridSpacing) และ [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/#setGridSpacing) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด ไม่ใช่สไลด์เดี่ยว. การเว้นระยะกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าเป็นบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปเปิดไฟล์ `demo.pptx` ที่มีอยู่, พิมพ์ค่าการเว้นระยะกริดปัจจุบัน, ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว, แล้วบันทึกผลลัพธ์.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

กริดแตกต่างจาก [drawing guides](/slides/th/php-java/drawing-guides/). การเว้นระยะกริดควบคุมช่วงเวลาปกติ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งแยกกัน. การเพิ่ม, ย้ายหรือลบ drawing guides ไม่ทำให้การเว้นระยะกริดเปลี่ยนแปลง.

กริดและ drawing guides ทั้งสองเป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ถูกเรนเดอร์เป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG หรือการแสดงสไลด์โชว์. การบันทึกการเว้นระยะกริดไม่รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด: การมองเห็นขึ้นอยู่กับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไขด้วย.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ**

ใช้ [Presentation::getViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getviewproperties/) เพื่อเข้าถึงการตั้งค่ามุมมองทั่วการนำเสนอ. ใช้ [ViewProperties::getShowComments](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/getshowcomments/) และ [ViewProperties::setShowComments](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/setshowcomments/) เพื่ออ่านหรือเปลี่ยนค่าตั้งที่บันทึกว่าควรแสดงความคิดเห็นเมื่อการนำเสนอเปิดใน PowerPoint หรือโปรแกรมที่เข้ากันได้อื่น.

การตั้งค่านี้ควบคุมเพียงค่าตั้งมุมมองที่บันทึกไว้เท่านั้น. มันไม่ได้เพิ่ม, ลบ, แก้ไข หรือแก้ไขความขัดแย้งของความคิดเห็น. การซ่อนความคิดเห็นจะคงเนื้อหา, ผู้เขียน, ตำแหน่ง, การตอบกลับและสถานะของความคิดเห็นไว้. ดู [Presentation Comments](/slides/th/php-java/presentation-comments/) สำหรับการดำเนินการที่เปลี่ยนความคิดเห็นเอง.

ตัวอย่างต่อไปต้องมีไฟล์ `comments.pptx` ที่มีความคิดเห็นอยู่. มันพิมพ์ค่าการมองเห็นปัจจุบัน, ขอให้ซ่อนความคิดเห็น, แล้วบันทึก PPTX ใหม่โดยไม่ลบความคิดเห็นใด ๆ. มันยังใช้ [ViewProperties::setLastView](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/setlastview/) ร่วมกับ [ViewType::SlideView](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewtype/#SlideView) เพื่อตั้งค่ามุมมองแก้ไขเริ่มต้นพร้อมกับการมองเห็นของความคิดเห็น.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การตั้งค่านี้ไม่ได้กำหนดว่าความคิดเห็นจะรวมอยู่ในการส่งออกเป็น PDF, HTML, รูปภาพ, โน้ต หรือเอกสารสรุปหรือไม่. คอนฟิกตัวเลือกเฉพาะการส่งออกที่เกี่ยวข้องแยกต่างหาก.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงไม่ปรากฏหลังจากที่เปิดการนำเสนอใหม่?**

ไฟล์บันทึกการเว้นระยะกริดไว้ แต่โปรแกรมแก้ไขจะควบคุมว่ากริดจะแสดงหรือไม่ ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การลบ drawing guides จะทำให้การเว้นระยะกริดเปลี่ยนหรือไม่?**

ไม่มี. drawing guides และการเว้นระยะกริดเป็นการตั้งค่าที่แยกจากกัน การลบ guides ไม่ทำให้ช่วงกริดที่บันทึกเปลี่ยนแปลง.

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างกันสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

การตั้งค่า [View settings](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getviewproperties/) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/getslideviewproperties/)), ไม่ใช่ต่อส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่ต่างกันสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในวิธีเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getviewproperties/) ถูกเก็บระดับการนำเสนอ, คุณจึงสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการตั้งค่ามุมมองเริ่มต้นเดียวกัน.