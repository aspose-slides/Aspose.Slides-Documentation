---
title: ดึงข้อมูลและอัปเดตคุณสมบัติมุมมองของงานนำเสนอใน JavaScript
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/nodejs-java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาเค้าโครง
- ไอคอนเค้าโครง
- ตัวแยกแนวตั้งสแนป
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้ Aspose.Slides for Node.js via Java เพื่อกำหนดค่าเลย์เอาต์มุมมองปกติ, การซูมสไลด์และบันทึก, ระยะห่างของกริด, และการแสดงความเห็นในงานนำเสนอ PowerPoint."
---
## **บทนำ**

ในมุมมองปกติของ PowerPoint สไลด์จะแสดงระหว่างแผงด้านข้างสำหรับภาพย่อหรือเค้าโครงและแผงบันทึกด้านล่าง Aspose.Slides for Node.js ผ่าน Java เปิดเผยการตั้งค่าการแก้ไขที่บันทึกไว้ของงานนำเสนอผ่าน [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) ซึ่งรวมถึงการจัดวางแผง ระดับการซูม ระยะห่างของกริด และการแสดงความเห็น

## **เกี่ยวกับ NormalViewProperties**

ใช้ [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) เพื่อเข้าถึงคลาส [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) . [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ควบคุมว่ามีไอคอนปรากฏข้างชื่อสไลด์ในเค้าโครงหรือไม่. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ทำให้แผงด้านข้างสแนปไปยังสถานะย่อเมื่อผู้ใช้ทำให้แคบลง. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) ระบุความต้องการให้แสดงแผงเดียวในหน้าต่างเต็ม.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) ควบคุมตัวแบ่งระหว่างแผงด้านข้างและสไลด์. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) ควบคุมตัวแบ่งเหนือแผงบันทึก. ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) ที่เป็น `Minimized`, `Maximized`, หรือ `Restored`.

## **เกี่ยวกับการคืนค่า NormalViewProperties**

เมื่อมีการคืนค่าตัวแบ่ง, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) ให้ขนาดที่บันทึกของแผงด้านข้างและ [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) ให้ขนาดที่บันทึกของพื้นที่สไลด์ด้านบน. ทั้งสองเผยให้เห็น [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). วิธี [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) ของมันรับเปอร์เซ็นต์ตั้งแต่ 0 ถึง 100, และ [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) ควบคุมว่ามีการปรับขนาดโดยอัตโนมัติเมื่อหน้าต่างถูกปรับขนาดหรือไม่.

ตัวอย่างนี้อัปเดตงานนำเสนอที่มีอยู่. มันคืนค่าตัวแบ่งแนวนอน, ตั้งค่าขนาดที่ได้จาก [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) เป็น 80% พร้อมเปิดการปรับอัตโนมัติ, 그리고 ขยายตัวแบ่งแนวตั้งเต็ม. นอกจากนี้ยังเรียก [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) เพื่อแสดงไอคอนในมุมมองเค้าโครง.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการซูมเริ่มต้น**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) เก็บการตั้งค่าการซูมแยกต่างหากสำหรับตัวแก้ไข. การตั้งค่าเหล่านี้ไม่ได้ส่งผลต่อมิติของสไลด์, การเล่นการนำเสนอ, หรือความละเอียดการส่งออกภาพ.

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเรียก [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) เพื่อให้สไลด์พอดีกับหน้าต่างแก้ไข. สำหรับหน้าบันทึก, มันปิดการปรับขนาดอัตโนมัติและเรียก [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) เพื่อตั้งค่าการซูมคงที่ที่ 80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าระยะห่างของกริด**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) ตั้งค่าระยะห่างระหว่างเส้นกริดการแก้ไขทั่วทั้งงานนำเสนอ. มันรับค่าบวกเป็นจุด, โดยมี 72 จุดต่อหนึ่งนิ้ว. ตัวอย่างนี้พิมพ์ค่าระยะห่างปัจจุบันในงานนำเสนอที่มีอยู่และบันทึกกริดหนึ่งในสี่นิ้วโดยตั้งค่าเป็น 18 จุด.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

กริดจะทำซ้ำที่ช่วงเวลาคงที่. [Drawing guides](/slides/th/nodejs-java/drawing-guides/) ทำเครื่องหมายตำแหน่งแนวนอนหรือแนวตั้งแต่ละตำแหน่ง. ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและปรากฏเฉพาะในตัวแก้ไขที่แสดงมัน. การนำเสนอและการส่งออกเป็น PDF, ภาพ หรือ SVG จะไม่แสดง.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอ**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) เก็บค่าตั้งค่าที่ตัวแก้ไขที่เข้ากันได้ใช้เมื่อเปิดงานนำเสนอ. สำหรับงานนำเสนอที่มีความคิดเห็น, ตัวอย่างนี้พิมพ์การตั้งค่าปัจจุบันและบันทึกสำเนาที่ซ่อนความคิดเห็น. นอกจากนี้ยังเรียก [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) พร้อมกับ [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) เพื่อให้สำเนาเปิดในมุมมองสไลด์.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การซ่อนความคิดเห็นจะเก็บข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับและสถานะของมันไว้. เพื่อเปลี่ยนแปลงความคิดเห็นเอง, ดูที่ [Presentation Comments](/slides/th/nodejs-java/presentation-comments/). การตั้งค่าการส่งออกจะควบคุมว่าความคิดเห็นปรากฏใน PDF, HTML, ภาพ, บันทึกหรือเอกสารแจกหรือไม่.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงหายไปเมื่อฉันเปิดงานนำเสนอใหม่?**

งานนำเสนอเก็บค่าช่วงเวลาของกริด. เพื่อดูกริด, เปิดการแสดงกริดในตัวแก้ไข.

**การลบ drawing guides มีผลต่อระยะห่างของกริดหรือไม่?**

ไม่มี. การเพิ่ม, ย้าย หรือ ลบ guide ไม่ทำให้ช่วงเวลาของกริดเปลี่ยนแปลง.

**แต่ละส่วนของงานนำเสนอสามารถมีการตั้งค่ามุมมองที่ต่างกันได้หรือไม่?**

ไม่มี. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) ใช้กับงานนำเสนอทั้งหมด.

**ฉันสามารถบันทึกการตั้งค่ามุมมองที่แตกต่างสำหรับผู้ใช้ที่ต่างกันได้หรือไม่?**

ไฟล์จะเก็บชุดการตั้งค่ามุมมองเดียวสำหรับทุกคน. ตัวแก้ไขอาจใช้ค่าตั้งค่าท้องถิ่นของผู้ใช้ด้วย.

**ฉันสามารถบันทึกการตั้งค่ามุมมองในเทมเพลตได้หรือไม่?**

ได้. งานนำเสนอที่สร้างจากเทมเพลตจะสืบทอดการตั้งค่ามุมมองที่บันทึกไว้.