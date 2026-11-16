---
title: ดึงและอัปเดตคุณสมบัติการแสดงผลของงานนำเสนอใน Java
linktitle: คุณสมบัติการแสดงผล
type: docs
weight: 80
url: /th/java/presentation-view-properties/
keywords:
- คุณสมบัติการแสดงผล
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแนปตัวแบ่งแนวตั้ง
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides for Java เพื่อกำหนดค่าการจัดวางมุมมองปกติ, การซูมของสไลด์และโน้ต, ระยะห่างของกริด, และการแสดงคอมเมนต์ในงานนำเสนอ PowerPoint."
---
## **บทนำ**

ในมุมมองปกติของ PowerPoint สไลด์จะแสดงอยู่ระหว่างแผงด้านข้างสำหรับภาพย่อหรือเค้าโครงและแผงโน้ตด้านล่าง Aspose.Slides for Java แสดงค่าการตั้งค่าการแก้ไขที่บันทึกไว้ของงานนำเสนอผ่าน [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). ค่าต่างๆ รวมถึงการจัดวางแผง, ระดับการซูม, ระยะห่างของกริด, และการแสดงคอมเมนต์

## **เกี่ยวกับ INormalViewProperties**

ใช้ [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) เพื่อเข้าถึงอินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/) [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) ควบคุมว่าจะให้ไอคอนปรากฏข้างชื่อสไลด์ในเค้าโครงหรือไม่ [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) ทำให้แผงด้านข้างสแนปไปยังสถานะย่อเมื่อผู้ใช้ลดขนาดแผง [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) ระบุความต้องการให้แสดงเพียงแผงเดียวในหน้าต่างเต็ม

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) ควบคุมตัวแบ่งระหว่างแผงด้านข้างและสไลด์ [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) ควบคุมตัวแบ่งเหนือแผงโน้ต ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) ที่เป็น `Minimized`, `Maximized`, หรือ `Restored`

## **เกี่ยวกับการกู้คืน INormalViewProperties**

เมื่อตัวแบ่งถูกกู้คืน [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) ให้ขนาดที่บันทึกของแผงด้านข้างและ [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) ให้ขนาดที่บันทึกของพื้นที่สไลด์ด้านบน ทั้งสองเปิดเผย [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/) วิธี [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) รับค่าร้อยละตั้งแต่ 0 ถึง 100 และ [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) ควบคุมว่าโปรแกรมแก้ไขจะปรับขนาดเมื่อหน้าต่างถูกเปลี่ยนขนาดหรือไม่

ตัวอย่างนี้อัปเดตงานนำเสนอที่มีอยู่ มันกู้คืนตัวแบ่งแนวนอน ตั้งค่าขนาดที่ได้จาก [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) เป็น 80% พร้อมเปิดใช้งานการปรับอัตโนมัติ และขยายตัวแบ่งแนวตั้งให้เต็ม นอกจากนี้ยังเรียก [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) เพื่อแสดงไอคอนในมุมมองเค้าโครง

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

## **ตั้งค่าค่าการซูมเริ่มต้น**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) เก็บการตั้งค่าการซูมแบบอิสระสำหรับโปรแกรมแก้ไข การตั้งค่าเหล่านี้ไม่ส่งผลต่อมิติของสไลด์ การแสดงสไลด์โชว์ หรือความละเอียดการส่งออกภาพ

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเรียก [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) เพื่อให้สไลด์พอดีกับหน้าต่างการแก้ไข สำหรับหน้าบันทึกโน้ต จะปิดการปรับสเกลอัตโนมัติและเรียก [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) เพื่อตั้งค่าการซูมคงที่ที่ 80%

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

## **ตั้งค่าการเว้นระยะกริด**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) กำหนดระยะห่างระหว่างเส้นกริดการแก้ไขทั่วทั้งงานนำเสนอ รับค่าบวกเป็นหน่วยพ้อยต์ ที่มี 72 พ้อยต์ต่อหนึ่งนิ้ว ตัวอย่างนี้พิมพ์ระยะห่างปัจจุบันในงานนำเสนอที่มีอยู่และบันทึกกริดหนึ่งไตรมาสนิ้วโดยตั้งช่วงเป็น 18 พ้อยต์

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

กริดจะทำซ้ำที่ช่วงเวลาคงที่ [แนววาด](/slides/th/java/drawing-guides/) ระบุตำแหน่งแนวนอนหรือแนวตั้งแต่ละจุด ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและปรากฏเฉพาะในโปรแกรมแก้ไขที่แสดงมัน การแสดงสไลด์โชว์และการส่งออกเป็น PDF, ภาพ หรือ SVG จะละเว้นส่วนนี้

## **แสดงหรือซ่อนคอมเมนต์เมื่อเปิดงานนำเสนอ**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) เก็บค่ากำหนดที่โปรแกรมแก้ไขที่เข้ากันได้ใช้เมื่อต้องเปิดงานนำเสนอ สำหรับงานนำเสนอที่มีคอมเมนต์อยู่แล้ว ตัวอย่างนี้พิมพ์ค่าตั้งค่าปัจจุบันและบันทึกสำเนาที่ซ่อนคอมเมนต์ นอกจากนี้ยังเรียก [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) พร้อมกับ [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) เพื่อให้สำเนาเปิดในมุมมองสไลด์

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

การซ่อนคอมเมนต์จะคงข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะของคอมเมนต์ไว้ หากต้องการเปลี่ยนคอมเมนต์เอง ให้ดูที่ [คอมเมนต์ของงานนำเสนอ](/slides/th/java/presentation-comments/) การตั้งค่าการส่งออกจะกำหนดว่าคอมเมนต์จะแสดงใน PDF, HTML, ภาพ, โน้ต, หรือเอกสารแจกหรือไม่

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงหายไปเมื่อเปิดงานนำเสนอใหม่?**  
งานนำเสนอเก็บช่วงเวลากริด เพื่อดูกริดให้เปิดการมองเห็นกริดในโปรแกรมแก้ไข

**การลบแนววาดจะทำให้ระยะห่างของกริดเปลี่ยนไหม?**  
ไม่ การเพิ่ม, ย้าย หรือ ลบแนววาดไม่ทำให้ช่วงเวลากริดเปลี่ยน

**สามารถตั้งค่าการมุมมองที่แตกต่างกันในส่วนต่าง ๆ ของงานนำเสนอได้หรือไม่?**  
ไม่ [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) ใช้กับงานนำเสนอทั้งหมด

**ฉันสามารถบันทึกการตั้งค่าการมุมมองที่ต่างกันสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**  
ไฟล์บันทึกชุดการตั้งค่าการมุมมองเดียวสำหรับทุกคน โปรแกรมแก้ไขอาจใช้ค่ากำหนดส่วนตัวของผู้ใช้เพิ่มเติม

**ฉันสามารถบันทึกการตั้งค่าการมุมมองในเทมเพลตได้หรือไม่?**  
ใช่ งานนำเสนอที่สร้างจากเทมเพลตจะสืบทอดการตั้งค่าการมุมมองที่บันทึกไว้