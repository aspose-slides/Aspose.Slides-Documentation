---
title: ดึงข้อมูลและอัปเดตคุณสมบัติมุมมองการนำเสนอใน JavaScript
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/nodejs-java/presentation-view-properties/
keywords: 
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแนปตัวแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- การปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่านคุณสมบัติมุมมอง Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับเลย์เอาต์ ระดับการซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติประกอบด้วยสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวข้องกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองไปยังไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสภาพเดียวกับที่การนำเสนอถูกบันทึกครั้งสุดท้าย.

Method [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) ได้เพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ. 

ได้เพิ่มคลาส [NormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties) และคลาสลูกของมัน, และ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType) 

## **เกี่ยวกับ NormalViewProperties**

แทนคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าควรแสดงไอคอนเมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติหรือไม่.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean--) ระบุว่าตัวแบ่งแนวตั้งควรสแนปไปสภาวะย่อส่วนเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน, แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาในหน้าต่างทั้งหมด.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์, แถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้ ได้แก่ [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) ระบุการกำหนดขนาดของพื้นที่ส่วนบนหรือด้านข้างของมุมมองปกติ, เมื่อใช้ค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SplitterBarStateType#Restored) กับ [getVerticalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการกู้คืน NormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่กู้คืนได้ (ไม่ย่อส่วนและไม่ขยายเต็ม). 

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) ระบุว่าพื้นที่เนื้อหาด้านข้างควรปรับขนาดให้ชดเชยขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) สำหรับการนำเสนอ.

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

Aspose.Slides สำหรับ Node.js ผ่าน Java ขณะนี้รองรับการตั้งค่าค่าการซูมเริ่มต้นสำหรับการนำเสนอโดยที่เมื่อเปิดการนำเสนอแล้ว การซูมจะถูกตั้งไว้แล้ว. สิ่งนี้สามารถทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของการนำเสนอ. สามารถตั้งค่า [getSlideViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) ด้วยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) ใน Aspose.Slides.

{{% /alert %}} 

เพื่อทำการตั้งค่าคุณสมบัติมุมมอง, กรุณาทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
1. เขียนการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) 
   ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าซูมสำหรับมุมมองสไลด์และมุมมองบันทึกบันทึก (notes view).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซนต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซนต์สำหรับมุมมองบันทึก
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าระยะห่างของ Grid**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอทั้งหมด. เมธอด [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) และ [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) ใช้เพื่ออ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด, ไม่ใช่กับสไลด์แต่ละสไลด์. ระยะห่างของกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API ระบุ.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่, พิมพ์ระยะห่างกริดปัจจุบัน, ตั้งช่วงหนึ่งในสี่นิ้ว, และบันทึกผลลัพธ์.

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

กริดแตกต่างจาก [drawing guides](/slides/th/nodejs-java/drawing-guides/). ระยะห่างของกริดควบคุมช่วงเวลาปกติ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่วางตำแหน่งแต่ละเส้นโดยอิสระ. การเพิ่ม, ย้าย, หรือล้าง drawing guides จะไม่ทำให้ระยะห่างของกริดเปลี่ยนแปลง.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ได้ถูกแสดงเป็นเนื้อหาสไลด์ใน PDF, ภาพ, SVG หรือการแสดงสไลด์โชว์. การบันทึกระยะห่างของกริดไม่รับประกันว่าโปรแกรมแก้ไขจะเผยกริด: ความมองเห็นยังขึ้นอยู่กับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไข.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอทั้งหมด. ใช้ [ViewProperties.getShowComments](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#getShowComments--) และ [ViewProperties.setShowComments](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) เพื่ออ่านหรือเปลี่ยนการตั้งค่าที่บันทึกไว้ว่าความคิดเห็นควรแสดงเมื่อการนำเปิดใน PowerPoint หรือโปรแกรมที่เข้ากันได้อื่นหรือไม่.

การตั้งค่านี้ควบคุมเพียงการตั้งค่ามุมมองที่บันทึกไว้. มันไม่ได้เพิ่ม, ลบ, แก้ไข, หรือแก้ไขความเห็น. การซ่อนความคิดเห็นจะคงเนื้อหา, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะของความคิดเห็นไว้. ดูที่ [Presentation Comments](/slides/th/nodejs-java/presentation-comments/) สำหรับการดำเนินการที่เปลี่ยนแปลงความคิดเห็นเอง.

ตัวอย่างต่อไปนี้ต้องมีไฟล์ `comments.pptx` ที่มีความคิดเห็นอยู่. มันพิมพ์การตั้งค่าการมองเห็นปัจจุบัน, ขอให้ซ่อนความคิดเห็น, และบันทึกไฟล์ PPTX ใหม่โดยไม่ลบความคิดเห็นใด ๆ. นอกจากนี้ยังใช้ [ViewProperties.setLastView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) ร่วมกับ [ViewType.SlideView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewtype/#SlideView) เพื่อกำหนดมุมมองการแก้ไขเริ่มต้นพร้อมกับการมองเห็นความคิดเห็น.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตั้งค่านี้ไม่ได้กำหนดว่าความคิดเห็นจะรวมอยู่ในการส่งออกเป็น PDF, HTML, ภาพ, โน๊ต, หรือเอกสารแจกหรือไม่. ควรกำหนดตัวเลือกการส่งออกระหว่างประเภทนั้นแยกกัน.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงไม่แสดงหลังจากฉันเปิดการนำเสนอใหม่?**

ไฟล์บันทึกระยะห่างของกริดไว้, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การล้าง drawing guides จะทำให้ระยะห่างของกริดเปลี่ยนแปลงหรือไม่?**

ไม่. drawing guides และระยะห่างของกริดเป็นการตั้งค่าอิสระกัน. การล้าง guides จะไม่เปลี่ยนช่วงของกริดที่บันทึกไว้.

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getviewproperties/) ถูกกำหนดในระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), ไม่ได้ระดับแต่ละส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ที่ต่างกันได้หรือไม่?**

ไม่. การตั้งค่าถูกเก็บไว้ในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดด้วยวิธีเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getviewproperties/) ถูกเก็บในระดับการนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดมุมมองเริ่มต้นเดียวกัน.