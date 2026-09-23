---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน Java
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- แบ่งแนวตั้งแบบสแนป
- มุมมองเดียว
- สภาวะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides for Java เพื่อปรับแต่งสไลด์รูปแบบ PPT, PPTX และ ODP — ปรับการจัดวาง, ระดับซูม, และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติเกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่าง ๆ. ข้อมูลนี้ทำให้แอปพลิเคชันบันทึกสถานะมุมมองไปยังไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสภาพเดียวกับเมื่อการนำเสนอถูกบันทึกล่าสุด.

เมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) ถูกเพิ่มเข้ามาเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.  

เพิ่มอินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties) และทายาทของมัน, รวมถึง enum [SplitterBarStateType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType).

## **เกี่ยวกับ INormalViewProperties**

แทนคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่ากับแถบแบ่งแนวตั้งควรสแนปเป็นสถานะย่อเมื่อพื้นที่ด้านข้างเล็กพอ.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างเหนือมุมมองปกติที่มี 3 พื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาที่อยู่ด้านล่าง, ส่วนแถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่ด้านข้าง. ค่าที่เป็นไปได้ได้แก่ [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติเมื่อค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored) ถูกใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการกู้คืน INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองปกติเมื่อพื้นที่นั้นมีขนาดที่กู้คืนได้ (ไม่ย่อและไม่ขยาย).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าพื้นที่เนื้อหาด้านข้างควรปรับตามขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่มีมุมมองนี้หรือไม่.

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) ของการนำเสนอ.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // กู้คืนคุณสมบัติมุมมองของการนำเสนอ
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ตั้งค่ามาตรการซูมเริ่มต้น**

{{% alert color="info" %}} 

Aspose.Slides for Java ตอนนี้สนับสนุนการตั้งค่ามาตรการซูมเริ่มต้นสำหรับการนำเสนอเพื่อให้เมื่อเปิดการนำเสนอซูมจะถูกตั้งค่าแล้ว. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของการนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าโดยโปรแกรม. ในหัวข้อนี้เราจะดูตัวอย่างการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) ใน Aspose.Slides. 

{{% /alert %}} 

เพื่อกำหนดค่าคุณสมบัติมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/). ตัวอย่างต่อไปนี้เราได้ตั้งค่ามาตรการซูมสำหรับมุมมองสไลด์และมุมมองบันทึกหมายเหตุ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกหมายเหตุ 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการเว้นระยะของกริด**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอ. เมธอด [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/iviewproperties/#getGridSpacing--) และ [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) อ่านหรือเปลี่ยนช่วงของกริดสำหรับการแก้ไข. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด, ไม่ใช่สไลด์เดี่ยว. การเว้นระยะกริดระบุเป็นพอยต์, โดย 72 พอยต์เท่ากับ 1 นิ้ว. ใช้ค่าเป็นบวกตามที่เอกสาร API ระบุ.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่, พิมพ์ค่าการเว้นระยะกริดปัจจุบัน, ตั้งค่าเป็นช่วงหนึ่งในสี่นิ้ว, แล้วบันทึกผลลัพธ์.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

กริดแตกต่างจาก [drawing guides](/slides/th/java/drawing-guides/). การเว้นระยะกริดควบคุมช่วงแบบสม่ำเสมอ, ส่วน drawing guides เป็นเส้นแนวตั้งหรือแนวนอนที่ตำแหน่งกำหนดเอง. การเพิ่ม, ย้าย หรือ ลบ drawing guides ไม่เปลี่ยนการเว้นระยะของกริด.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยแก้ไข. พวกมันไม่ถูกเรนเดอร์เป็นเนื้อหาสไลด์ใน PDF, ภาพ, SVG, หรือการแสดงสไลด์โชว์. การจัดเก็บการเว้นระยะกริดไม่ได้รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด: ความมองเห็นขึ้นอยู่กับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไข.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอ. ใช้ [IViewProperties.getShowComments](https://reference.aspose.com/slides/th/java/com.aspose.slides/iviewproperties/#getShowComments--) และ [IViewProperties.setShowComments](https://reference.aspose.com/slides/th/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) อ่านหรือเปลี่ยนการตั้งค่าที่บันทึกไว้ว่าความคิดเห็นควรแสดงเมื่อการนำเสนอเปิดใน PowerPoint หรือโปรแกรมที่เข้ากันได้อื่นหรือไม่.

การตั้งค่านี้ควบคุมเพียงการมุมมองที่บันทึกไว้. ไม่ได้เพิ่ม, ลบ, แก้ไข หรือแก้ไขความเห็น. การซ่อนความเห็นจะคงเนื้อหา, ผู้เขียน, ตำแหน่ง, การตอบกลับและสถานะไว้. ดู [Presentation Comments](/slides/th/java/presentation-comments/) สำหรับการดำเนินการที่เปลี่ยนแปลงความคิดเห็นเอง.

ตัวอย่างต่อไปนี้ต้องมีไฟล์ `comments.pptx` ที่มีความคิดเห็นอยู่แล้ว. ตัวอย่างพิมพ์การตั้งค่าการมองเห็นปัจจุบัน, สั่งให้ซ่อนความคิดเห็น, แล้วบันทึกไฟล์ PPTX ใหม่โดยไม่ลบความคิดเห็นใด ๆ. ตัวอย่างยังใช้ [IViewProperties.setLastView](https://reference.aspose.com/slides/th/java/com.aspose.slides/iviewproperties/#setLastView-int-) กับ [ViewType.SlideView](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewtype/#SlideView) เพื่อกำหนดมุมมองการแก้ไขเริ่มต้นพร้อมกับการมองเห็นความคิดเห็น.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตั้งค่านี้ไม่ได้กำหนดว่าความคิดเห็นจะรวมอยู่ในไฟล์ PDF, HTML, ภาพ, โน้ต หรือเอกสารแจกจ่ายหรือไม่. โปรดกำหนดตัวเลือกการส่งออกที่เกี่ยวข้องแยกต่างหาก.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงไม่แสดงหลังจากเปิดการนำเสนอใหม่?**

ไฟล์บันทึกค่าการเว้นระยะของกริด, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมการแสดงกริด. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การลบ drawing guides จะเปลี่ยนการเว้นระยะของกริดหรือไม่?**

ไม่. drawing guides และการเว้นระยะของกริดเป็นการตั้งค่าที่อิสระกัน. การลบ guides ไม่ทำให้ช่วงกริดที่บันทึกไว้เปลี่ยนแปลง.

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[การตั้งค่ามุมมอง](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), ไม่ได้กำหนดต่อแต่ละส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. โปรแกรมดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตพร้อมคุณสมบัติมุมมองที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดด้วยการตั้งค่าเดียวกันหรือไม่?**

ทำได้. เนื่องจาก [คุณสมบัติมุมมอง](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกเก็บระดับการนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นเพื่อให้มีการตั้งค่ามุมมองเริ่มต้นเดียวกัน.