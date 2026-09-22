---
title: ดึงและอัปเดตคุณสมบัติวิวการนำเสนอใน Java
linktitle: คุณสมบัติวิว
type: docs
weight: 80
url: /th/java/presentation-view-properties/
keywords:
- คุณสมบัติวิว
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- ตัวแบ่งแนวตั้งสแนป
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติวิวของ Aspose.Slides สำหรับ Java เพื่อปรับแต่งสไลด์รูปแบบ PPT, PPTX, และ ODP — ปรับเลย์เอาต์ ระดับซูม และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวข้องกับการจัดตำแหน่งของพื้นที่เนื้อหาต่างๆ นี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้, เพื่อเมื่อเปิดใหม่มุมมองจะอยู่ในสถานะเดียวกับที่บันทึกการนำเสนอครั้งสุดท้าย.

เพิ่มเมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) เพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ. 

[INormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties) อินเทอร์เฟซและส่วนสืบทอดของมัน, และ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType) ถูกเพิ่มเข้ามา.

## **เกี่ยวกับ INormalViewProperties**

แสดงถึงคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าระบบควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใดๆ ของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าตัวแบ่งแนวตั้งควรสแนปไปยังสถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบตัวแบ่งแนวนอนหรือแนวตั้งควรแสดง. แถบตัวแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์, แถบตัวแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Maximized), และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อค่าของ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่คืนค่าได้แบบแปรผัน (ไม่ย่อและไม่ขยาย).  

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับตามขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่มีมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) ของการนำเสนอ.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // คืนค่าคุณสมบัติวิวของการนำเสนอ
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ตั้งค่าค่าซูมเริ่มต้น**

{{% alert color="info" %}} 

Aspose.Slides for Java ขณะนี้รองรับการตั้งค่าค่าซูมเริ่มต้นสำหรับการนำเสนอ โดยที่เมื่อเปิดการนำเสนอ ซูมจะถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของการนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าได้ด้วยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) ใน Aspose.Slides.

{{% /alert %}} 

เพื่อกำหนดคุณสมบัติมุมมอง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) class.
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) file.   ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // ตั้งค่าคุณสมบัติวิวของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการเว้นระยะกริด**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอทั้งหมด. เมธอด [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/iviewproperties/#getGridSpacing--) และ [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด ไม่ใช่สไลด์เดี่ยว. การเว้นระยะกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่แล้ว, พิมพ์การเว้นระยะกริดปัจจุบัน, ตั้งช่วงเป็นหนึ่งในสี่นิ้ว, และบันทึกผลลัพธ์.

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

กริดแตกต่างจาก [drawing guides](/slides/th/java/drawing-guides/). การเว้นระยะกริดควบคุมช่วงที่สม่ำเสมอ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งเป็นรายตัว. การเพิ่ม, ย้าย, หรือลบ drawing guides ไม่ส่งผลต่อการเว้นระยะกริด.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันจะไม่ถูกแสดงเป็นเนื้อหาสไลด์ใน PDF, ภาพ, SVG หรือการแสดงสไลด์. การจัดเก็บการเว้นระยะกริดไม่ได้รับประกันว่าโปรแกรมแก้ไขจะทำการแสดงกริด: ความมองเห็นขึ้นอยู่กับการตั้งค่าของผู้ชมหรือโปรแกรมแก้ไข.

## **คำถามที่พบบ่อย**

**ทำไมกริดไม่แสดงหลังจากฉันเปิดการนำเสนอใหม่?**

ไฟล์บันทึกการเว้นระยะกริดไว้, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การลบ drawing guides จะทำให้การเว้นระยะกริดเปลี่ยนหรือไม่?**

ไม่. drawing guides และการเว้นระยะกริดเป็นการตั้งค่าอิสระกัน. การลบ guides จะไม่เปลี่ยนช่วงกริดที่จัดเก็บ.

**ฉันสามารถตั้งค่ามุมมองต่างๆ สำหรับส่วนต่างๆ ของการนำเสนอได้หรือไม่?**

การตั้งค่า [View settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), ไม่ได้เป็นระดับส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดล่วงหน้าสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่างๆ ได้หรือไม่?**

ไม่. การตั้งค่าถูกจัดเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตพร้อม View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดด้วยวิธีเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกจัดเก็บระดับการนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นโดยมีการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.