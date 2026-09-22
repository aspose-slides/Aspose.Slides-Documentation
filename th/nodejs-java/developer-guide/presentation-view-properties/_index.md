---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน JavaScript
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/nodejs-java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- ดึงตัวแยกแนวตั้งให้สแนป
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
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่านคุณสมบัติมุมมอง Java เพื่อปรับแต่งสไลด์ในรูปแบบ PPT, PPTX และ ODP—ปรับเค้าร่าง, ระดับซูม, และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้ ดังนั้นเมื่อเปิดใหม่มุมมองจะอยู่ในสถานะเดียวกับที่ไฟล์การนำเสนอบันทึกครั้งสุดท้าย.

Method [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) ได้เพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.

ได้เพิ่มคลาส [NormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties) และบุตรสายของมัน, enum [SplitterBarStateType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType) ได้เพิ่ม.

## **เกี่ยวกับ NormalViewProperties**

แทนคุณสมบัติมุมมองปกติ.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) and [setShowOutlineIcons](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าควรให้แอปพลิเคชันแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) and [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าตัวแยกแนวตั้งควรสแนปไปสู่สถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอหรือไม่.

Property [getPreferSingleView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) and [setPreferSingleView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างเหนือมุมมองปกติที่มีสามพื้นที่เนื้อหาหรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาในหน้าต่างทั้งหมด.

Methods [getVerticalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) and [getHorizontalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) ระบุสถานะที่บาร์แยกแนวนอนหรือแนวตั้งควรแสดง. บาร์แยกแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่าง, บาร์แยกแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Methods [getRestoredLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) and [getRestoredTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) ระบุการกำหนดขนาดของด้านบนหรือด้านข้างของสไลด์ในมุมมองปกติ, เมื่อค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการกู้คืน NormalViewProperties**

ระบุการกำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ [getRestoredTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นบุตรของ [getRestoredLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่กู้คืนได้แบบแปรผัน (ไม่ย่อและไม่ขยาย).

Method [getDimensionSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ restoredTop, ความสูงเมื่อเป็นบุตรของ restoredLeft).

Method [getAutoAdjust](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับชดเชยกับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) ของการนำเสนอ.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // กู้คืนคุณสมบัติมุมมองของการนำเสนอ
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ตั้งค่าค่าการซูมเริ่มต้น**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java ตอนนี้รองรับการตั้งค่าซูมเริ่มต้นสำหรับการนำเสนอ ทำให้เมื่อเปิดการนำเสนอซูมจะตั้งไว้แล้ว. สามารถทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของการนำเสนอ. [getSlideViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) รวมถึง [getNotesViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าได้โดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) ใน Aspose.Slides.

{{% /alert %}} 

เพื่อกำหนดคุณสมบัติมุมมอง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation).
1. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/).
   ในตัวอย่างด้านล่าง เราได้ตั้งค่าซูมสำหรับการดูสไลด์และการดูโน้ต.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าระยะห่างของกริด**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองทั้งหมดของการนำเสนอ. วิธีการ [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) และ [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด, ไม่ได้ใช้กับสไลด์แต่ละอัน. ระยะห่างของกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่, พิมพ์ระยะห่างกริดปัจจุบัน, ตั้งค่าช่วงเป็นหนึ่งส่วนของนิ้ว, แล้วบันทึกผลลัพธ์.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

กริดแตกต่างจาก [drawing guides](/slides/th/nodejs-java/drawing-guides/). ระยะห่างกริดควบคุมช่วงปกติ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งแบบแยกกัน. การเพิ่ม, ย้าย, หรือเคลียร์ drawing guides ไม่เปลี่ยนระยะห่างกริด.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ได้ถูกเรนเดอร์เป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG, หรือการแสดงสไลด์. การบันทึกระยะห่างกริดไม่ได้รับประกันว่าโปรแกรมแก้ไขจะทำให้กริดแสดง: ความมองเห็นขึ้นอยู่กับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไข.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงไม่แสดงเมื่อฉันเปิดการนำเสนออีกครั้ง?**

ไฟล์บันทึกระยะห่างกริดไว้, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การเคลียร์ drawing guides จะเปลี่ยนระยะห่างกริดหรือไม่?**

ไม่มี. drawing guides และระยะห่างกริดเป็นการตั้งค่าอิสระกัน. การเคลียร์ guides จะไม่เปลี่ยนช่วงกริดที่บันทึกไว้.

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

การตั้งค่า [View settings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getviewproperties/) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), ไม่ได้แยกตามส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดล่วงหน้าสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**

ได้. เพราะ [view properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getviewproperties/) ถูกเก็บระดับการนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดมุมมองเริ่มต้นเดียวกัน.