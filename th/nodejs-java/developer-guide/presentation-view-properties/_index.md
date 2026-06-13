---
title: ดึงและอัปเดตคุณสมบัติวิวของการนำเสนอใน JavaScript
linktitle: คุณสมบัติวิว
type: docs
weight: 80
url: /th/nodejs-java/presentation-view-properties/
keywords:
- คุณสมบัติวิว
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแนปตัวแยกแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสมบัติวิวเพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับเลย์เอาต์ ระดับซูม และการตั้งค่าการแสดงผล"
---
## **คำนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน ได้แก่ สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติเกี่ยวกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหาเหล่านี้. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองไปยังไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกับที่บันทึกล่าสุดของการนำเสนอ.

เมธอด [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) ถูกเพิ่มขึ้นเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.  

[NormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties) คลาสและคลาสที่สืบทอด, [SplitterBarStateType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType) enum ถูกเพิ่มขึ้น.

## **เกี่ยวกับ NormalViewProperties**

แสดงถึงคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในหนึ่งในพื้นที่เนื้อหาของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าตัวแยกแนวตั้งควรสแนปไปยังสถานะย่อเมื่อพื้นที่ด้านข้างเล็กพอ.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบตัวแยกแนวตั้งหรือแนวนอนควรแสดง. แถบตัวแยกแนวนอนจะแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์, แถบตัวแยกแนวตั้งจะแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าได้แก่: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) ระบุการกำหนดขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อใช้ค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Restored) กับ [getVerticalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการกู้คืน NormalViewProperties**

ระบุการกำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่กู้คืนได้แบบแปรผัน (ไม่อยู่ในสถานะย่อหรือขยาย).  

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).  

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับให้สอดคล้องกับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.  

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติของ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) สำหรับการนำเสนอ.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // คืนค่าคุณสมบัติการแสดงผลของการนำเสนอ
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ตั้งค่า Zoom เริ่มต้น**

{{% alert color="primary" %}} 

Aspose.Slides สำหรับ Node.js ผ่าน Java ตอนนี้รองรับการตั้งค่าค่า zoom เริ่มต้นสำหรับการนำเสนอเพื่อให้เมื่อเปิดการนำเสนอ zoom จะถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของการนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าโดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) ใน [Aspose.Slides](/slides/th/).

{{% /alert %}} 

เพื่อกำหนดคุณสมบัตุมุมมอง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. เขียนการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)  
   ในตัวอย่างที่ให้ไว้ด้านล่าง เราได้ตั้งค่าค่า zoom สำหรับมุมมุมมองสไลด์และมุมมองบันทึก.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // ตั้งค่าคุณสมบัติวิวของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึก
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getviewproperties/) ถูกกำหนดที่ระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), ไม่ได้ตามส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้แต่ละคนล่วงหน้าได้หรือไม่?**

ไม่. การตั้งค่านี้ถูกบันทึกในไฟล์และใช้ร่วมกัน. แอปพลิเคชันการดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัตุมุมมองเดียว.

**ฉันสามารถเตรียมแม่แบบที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getviewproperties/) ถูกจัดเก็บที่ระดับการนำเสนอ, คุณสามารถฝังไว้ในแม่แบบและสร้างเอกสารใหม่จากมันโดยมีการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.