---
title: ดึงและอัปเดตคุณสมบัติมุมมองงานนำเสนอบน Android
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/androidjava/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาเค้าโครง
- ไอคอนเค้าโครง
- แยกแนวตั้งแบบสแนป
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides for Android ผ่าน Java เพื่อกำหนดค่าเลย์เอาต์ของมุมมองปกติ, การซูมของสไลด์และบันทึก, ระยะห่างของกริด, และการแสดงความเห็นในงานนำเสนอ PowerPoint"
---
## **Introduction**

ในมุมมองปกติของ PowerPoint สไลด์จะแสดงระหว่างแผงด้านข้างสำหรับรูปย่อหรือเค้าโครงและแผงบันทึกด้านล่าง Aspose.Slides for Android via Java เปิดเผยการตั้งค่าการแก้ไขที่บันทึกของงานนำเสนอผ่าน [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). ทั้งนี้รวมถึงการจัดเรียงแผง ระดับการซูม ระยะห่างของกริด และการแสดงความเห็น

## **About INormalViewProperties**

ใช้ [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) เพื่อเข้าถึงอินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) . [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) ควบคุมว่าจะให้ไอคอนปรากฏข้างชื่อสไลด์ในเค้าโครงหรือไม่. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) ทำให้แผงด้านข้างถูกยึดให้อยู่ในสถานะย่อเมื่อผู้ใช้ทำให้แคบลง. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) ระบุความต้องการให้แสดงเพียงแผงเดียวในหน้าต่างเต็ม.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) ควบคุมตัวแบ่งระหว่างแผงด้านข้างและสไลด์. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) ควบคุมตัวแบ่งเหนือแผงบันทึก. ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) ที่เป็น `Minimized`, `Maximized` หรือ `Restored`.

## **About Restoring INormalViewProperties**

เมื่อมีการกู้คืนตัวแบ่ง, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) ให้ขนาดที่บันทึกของแผงด้านข้างและ [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) ให้ขนาดที่บันทึกของพื้นที่สไลด์ด้านบน. ทั้งสองเปิดเผย [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). วิธีการ [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) ของมันรับเปอร์เซ็นต์ตั้งแต่ 0 ถึง 100, และ [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) ควบคุมว่าจะให้โปรแกรมแก้ไขปรับขนาดเมื่อหน้าต่างถูกปรับขนาดหรือไม่.

ตัวอย่างนี้อัปเดตงานนำเสนอที่มีอยู่แล้ว. มันกู้คืนตัวแบ่งแนวนอน, ตั้งค่าขนาดที่ได้จาก [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) เป็น 80% พร้อมเปิดการปรับอัตโนมัติ, และขยายตัวแบ่งแนวดิ่งให้เต็ม. นอกจากนี้ยังเรียก [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) เพื่อแสดงไอคอนในมุมมองเค้าโครง.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Default Zoom Value**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) เก็บการตั้งค่าซูมแยกกันสำหรับโปรแกรมแก้ไข. การตั้งค่าเหล่านี้ไม่ส่งผลต่อมิติของสไลด์, การเล่นสไลด์โชว์, หรือความละเอียดการส่งออกภาพ.

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเรียก [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) เพื่อให้สไลด์พอดีกับหน้าต่างแก้ไข. สำหรับหน้าบันทึก, มันปิดการปรับสเกลอัตโนมัติและเรียก [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) เพื่อตั้งค่าซูมคงที่ที่ 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Grid Spacing**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) ตั้งค่าระยะห่างระหว่างเส้นกริดการแก้ไขทั่วงานนำเสนอ. ค่าที่รับต้องเป็นค่าบวกในหน่วย points, โดยมี 72 points ต่อหนึ่งนิ้ว. ตัวอย่างนี้พิมพ์ระยะห่างปัจจุบันในงานนำเสนอที่มีอยู่และบันทึกกริดสี่ส่วนของนิ้วโดยตั้งช่วงเป็น 18 points.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

กริดจะทำซ้ำที่ช่วงเวลาคงที่. [คู่มือการวาด](/slides/th/androidjava/drawing-guides/) ทำเครื่องหมายตำแหน่งแนวนอนหรือแนวตั้งแต่ละตำแหน่ง. ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและปรากฏเฉพาะในโปรแกรมแก้ไขที่แสดงมัน. การนำเสนอและการส่งออกเป็น PDF, รูปภาพ หรือ SVG จะละเว้นมัน.

## **Show or Hide Comments When Opening a Presentation**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) เก็บค่าการตั้งค่าที่โปรแกรมแก้ไขที่เข้ากันได้ใช้เมื่อเปิดงานนำเสนอ. สำหรับงานนำเสนอที่มีคอมเมนต์อยู่แล้ว, ตัวอย่างนี้พิมพ์ค่าการตั้งค่าปัจจุบันและบันทึกสำเนาที่ซ่อนคอมเมนต์. นอกจากนี้ยังเรียก [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) พร้อมกับ [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) เพื่อให้สำเนาเปิดในมุมมองสไลด์.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การซ่อนคอมเมนต์จะคงข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะของคอมเมนต์ไว้. เพื่อเปลี่ยนคอมเมนต์เอง, ดูที่ [คอมเมนต์งานนำเสนอ](/slides/th/androidjava/presentation-comments/). การตั้งค่าการส่งออกควบคุมว่าจะให้คอมเมนต์ปรากฏใน PDF, HTML, รูปภาพ, โน้ต หรือเอกสารแจก.

## **FAQ**

**ทำไมกริดถึงถูกซ่อนไว้เมื่อฉันเปิดงานนำเสนอใหม่?**

งานนำเสนอเก็บช่วงกริดไว้. เพื่อดูกริด, ให้เปิดการมองเห็นกริดในโปรแกรมแก้ไข.

**การลบ drawing guides จะทำให้ระยะห่างของกริดเปลี่ยนไหม?**

ไม่. การเพิ่ม, ย้าย, หรือทำความสะอาดไกด์ไม่ทำให้ช่วงกริดเปลี่ยนแปลง.

**ส่วนต่าง ๆ ของงานนำเสนอสามารถมีการตั้งค่ามุมมองที่แตกต่างกันได้หรือไม่?**

ไม่. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) ใช้กับงานนำเสนอทั้งหมด.

**ฉันสามารถบันทึกการตั้งค่ามุมมองที่แตกต่างกันสำหรับผู้ใช้ต่าง ๆ ได้ไหม?**

ไฟล์เก็บชุดการตั้งค่ามุมมองเดียวสำหรับทุกคน. โปรแกรมแก้ไขอาจใช้ค่าการตั้งค่าท้องถิ่นของผู้ใช้ด้วย.

**ฉันสามารถบันทึกการตั้งค่ามุมมองในเทมเพลตได้หรือไม่?**

ใช่. งานนำเสนอที่สร้างจากเทมเพลตจะสืบทอดการตั้งค่ามุมมองที่บันทึกไว้.