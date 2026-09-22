---
title: ดึงและอัปเดตคุณสมบัติมุมมองของงานนำเสนอใน PHP
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/php-java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- จับบาร์แยกแนวตั้ง
- มุมมองเดียว
- สถานะบาร์
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides for PHP via Java เพื่อปรับแต่งสไลด์รูปแบบ PPT, PPTX และ ODP — ปรับเลย์เอาต์ ระดับซูม และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวข้องกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกับที่บันทึกครั้งล่าสุดของงานนำเสนอ.

Method [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของงานนำเสนอ.

คลาส [NormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties) และคลาสลูกของมัน, enum [SplitterBarStateType](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType) ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองปกติ.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) ระบุว่าบาร์แยกแนวตั้งควรส Snap ไปยังสถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

Property [getPreferSingleView](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) และ [setPreferSingleView](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติที่มีสามพื้นที่เนื้อหรือไม่. หากเปิดใช้ แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาให้เต็มหน้าต่าง.

Methods [getVerticalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) ระบุสถานะที่บาร์แยกแนวนอนหรือแนวตั้งควรแสดง. บาร์แยกแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่าง, บาร์แยกแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Maximized) และ [SplitterBarStateType::Restored](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Restored).

Methods [getRestoredLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) และ [getRestoredTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties#getRestoredTop) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติเมื่อค่า [SplitterBarStateType::Restored](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) ตามลำดับ.

## **เกี่ยวกับการกู้คืน INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ [getRestoredTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), ความสูงเมื่อเป็นบุตรของ [getRestoredLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่สามารถกู้คืนได้ (ไม่ย่อและไม่ขยาย).

Method [getDimensionSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ restoredTop, ความสูงเมื่อเป็นบุตรของ restoredLeft).

Method [getAutoAdjust](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับตามขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองในแอปพลิเคชันหรือไม่.

ตัวอย่างต่อไปนี้แสดงวิธีการเข้าถึงคุณสมบัติ [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) สำหรับงานนำเสนอ.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # กู้คืนคุณสมบัติมุมมองของงานนำเสนอ
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **กำหนดค่าซูมเริ่มต้น**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java ตอนนี้สนับสนุนการตั้งค่าซูมเริ่มต้นสำหรับงานนำเสนอเพื่อให้เมื่อเปิดงานนำเสนอแล้วซูมถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของงานนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) สามารถตั้งค่าได้โดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) ใน Aspose.Slides.

{{% /alert %}} 

เพื่อกำหนดคุณสมบัติมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
1. เขียนงานนำเสนอเป็นไฟล์ [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.
   ในตัวอย่างด้านล่าง เราได้ตั้งค่าซูมสำหรับมุมมองสไลด์และมุมมองบันทึกย่อ.

```php
  $presentation = new Presentation();
  try {
    # ตั้งค่าคุณสมบัติมุมมองของงานนำเสนอ
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกย่อ

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **กำหนดระยะห่างกริด**

ใช้ [Presentation::getViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getViewProperties) เพื่อเข้าถึงการตั้งค่ามุมมองระดับงานนำเสนอ. วิธี [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/#getGridSpacing) และ [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/#setGridSpacing) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับงานนำเสนอทั้งหมด, ไม่ใช่เฉพาะสไลด์เดียว. ระยะห่างกริดกำหนดเป็นพอยท์, โดย 72 พอยท์เท่ากับหนึ่งนิ้ว. ใช้ค่าเป็นบวกตามที่เอกสาร API ระบุ.

ตัวอย่างต่อไปนี้เปิด `demo.pptx` ที่มีอยู่, พิมพ์ระยะห่างกริดปัจจุบัน, ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว, และบันทึกผลลัพธ์.

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

กริดแตกต่างจาก [drawing guides](/slides/th/php-java/drawing-guides/). ระยะห่างกริดควบคุมช่วงแบบสม่ำเสมอ, ขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่วางตำแหน่งตามต้องการ. การเพิ่ม, ย้าย, หรือเคลียร์ drawing guides ไม่ทำให้ระยะห่างกริดเปลี่ยน.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ถูกเรนเดอร์เป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG, หรือการแสดงสไลด์โชว์. การเก็บระยะห่างกริดไม่ได้รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด: ความมองเห็นยังขึ้นกับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไข.

## **FAQ**

**ทำไมกริดถึงไม่แสดงหลังจากเปิดงานนำเสนอใหม่?**

ไฟล์บันทึกระยะห่างกริด, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมการแสดงกริด. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การเคลียร์ drawing guides จะทำให้ระยะห่างกริดเปลี่ยนไหม?**

ไม่. Drawing guides และระยะห่างกริดเป็นการตั้งค่าที่อิสระกัน. การเคลียร์ guides จะไม่ทำให้ช่วงกริดที่เก็บไว้เปลี่ยน.

**ฉันสามารถตั้งค่ามุมมองต่าง ๆ สำหรับส่วนต่าง ๆ ของงานนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getviewproperties/) ถูกกำหนดระดับงานนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/getslideviewproperties/)), ไม่ได้กำหนดต่อส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองล่วงหน้าสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถสร้างเทมเพลตที่มี View Properties กำหนดไว้ล่วงหน้าเพื่อให้งานนำเสนอใหม่เปิดด้วยการตั้งค่าเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getviewproperties/) ถูกเก็บระดับงานนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากมันด้วยการกำหนดมุมมองเริ่มต้นเดียวกัน.