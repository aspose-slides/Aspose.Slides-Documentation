---
title: ดึงข้อมูลและอัปเดตคุณสมบัติมุมมองของงานนำเสนอใน PHP
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/php-java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- ตัวแบ่งแนวตั้งสแนป
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- พาวเวอร์พอยท์
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX, และ ODP — ปรับเลย์เอาต์ ระดับการซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติมีทั้งหมดสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาทางด้านล่าง. คุณสมบัติที่เกี่ยวกับตำแหน่งของพื้นที่เนื้อหาต่าง ๆ นี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสภาพเดียวกับที่บันทึกล่าสุดของงานนำเสนอ.

Method [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของงานนำเสนอ.  

[NormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties) classes และคลาสลูกของมัน, [SplitterBarStateType](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType) enum ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

แสดงถึงคุณสมบัติมุมมองปกติ.

Method [getShowOutlineIcons](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) ระบุว่าภายในโหมดมุมมองปกติแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ

Method [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) ระบุว่าตัวแบ่งแนวตั้งควรสแนปไปสภาพย่อเล็กเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ

Property [getPreferSingleView](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) และ [setPreferSingleView](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) ระบุว่าผู้ใช้ต้องการมองเห็นพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติแบบสามพื้นที่หรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาให้เต็มหน้าต่าง

Method [getVerticalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) ระบุสภาพที่แถบแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบแบ่งแนวนอนจะแยกสไลด์ออกจากพื้นที่เนื้อหาด้านล่าง, ส่วนแถบแบ่งแนวตั้งจะแยกสไลด์ออกจากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Maximized) และ [SplitterBarStateType::Restored](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Restored).

Method [getRestoredLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) และ [getRestoredTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties#getRestoredTop) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อค่า [SplitterBarStateType::Restored](https://reference.aspose.com/slides/th/php-java/aspose.slides/SplitterBarStateType/#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) ของมุมมองปกติ, เมื่พื้นที่มีขนาดที่เปลี่ยนแปลงได้ (ไม่ย่อเล็กและไม่ขยายเต็ม).

Method [getDimensionSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

Method [getAutoAdjust](https://reference.aspose.com/slides/th/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับให้สอดคล้องกับขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองในแอปพลิเคชันหรือไม่

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) ของงานนำเสนอ.

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

## **ตั้งค่าค่าการซูมเริ่มต้น**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ตอนนี้สนับสนุนการตั้งค่าค่าการซูมเริ่มต้นสำหรับงานนำเสนอโดยที่เมื่อเปิดงานนำเสนอแล้ว การซูมจะถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของงานนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) สามารถกำหนดค่าได้โดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) ใน [Aspose.Slides](/slides/th/).

{{% /alert %}} 

เพื่อทำการตั้งค่าคุณสมบัติมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
1. เขียนไฟล์งานนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)  ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าการซูมสำหรับมุมมองสไลด์และมุมมองโน๊ตด้วย.

```php
  $presentation = new Presentation();
  try {
    # ตั้งค่าคุณสมบัติมุมมองของงานนำเสนอ
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน๊ต

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getviewproperties/) ถูกกำหนดที่ระดับงานนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/getslideviewproperties/)), ไม่ได้แยกตามส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะนำไปใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดค่าเริ่มต้นของมุมมองสำหรับผู้ใช้คนต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกบันทึกในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ดูอาจให้ความสำคัญกับการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถสร้างเทมเพลตที่มี View Properties ถูกกำหนดล่วงหน้าเพื่อให้งานนำเสนอใหม่เปิดด้วยการตั้งค่าเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getviewproperties/) ถูกจัดเก็บที่ระดับงานนำเสนอ, คุณสามารถฝังมันลงในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นเพื่อให้มีการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.