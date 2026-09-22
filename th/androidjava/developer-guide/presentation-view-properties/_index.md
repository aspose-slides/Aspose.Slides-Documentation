---
title: ดึงและอัปเดตคุณสมบัติวิวของการนำเสนอบน Android
linktitle: คุณสมบัติวิว
type: docs
weight: 80
url: /th/androidjava/presentation-view-properties/
keywords:
- คุณสมบัติวิว
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- ล็อคตัวแบ่งแนวตั้ง
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติวิวของ Aspose.Slides for Android via Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับเค้าโครง ระดับการซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติประกอบด้วยสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่าง ๆ. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้, เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสถานะเดียวกับที่บันทึกครั้งสุดท้ายของการนำเสนอ.

เมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.

[INormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties) อินเทอร์เฟซและคลาสที่สืบทอดจากมัน, [SplitterBarStateType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType) enum ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

เป็นตัวแทนของคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) กำหนดว่าต้องแสดงไอคอนหรือไม่ หากแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) กำหนดว่าตัวแบ่งแนวตั้งควรล็อกเป็นสถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอหรือไม่.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) กำหนดว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุตำแหน่งที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดงอยู่. แถบแบ่งแนวนอนจะแยกสไลด์จากพื้นที่เนื้อหาด้านล่าง, แถบแบ่งแนวตั้งจะแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ เมื่อใช้ค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored) กับ [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการกู้คืน INormalViewProperties**

กำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ เมื่อพื้นที่มีขนาดกู้คืนที่เปลี่ยนแปลงได้ (ไม่ย่อและไม่ขยาย).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับตัวเพื่อรองรับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) ของการนำเสนอ.

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

## **ตั้งค่าค่าการซูมเริ่มต้น**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java ตอนนี้สนับสนุนการตั้งค่าค่าการซูมเริ่มต้นสำหรับการนำเสนอ เพื่อให้เมื่อเปิดการนำเสนอแล้ว การซูมจะถูกตั้งล่วงหน้า สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของการนำเสนอ การตั้งค่า [getSlideViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถทำได้ผ่านโปรแกรม ในหัวข้อนี้ เราจะดูตัวอย่างการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) ใน Aspose.Slides.

{{% /alert %}} 

เพื่อกำหนดคุณสมบัตุมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
1. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) .
   ในตัวอย่างด้านล่าง เราได้ตั้งค่าการซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // ตั้งค่าคุณสมบัติวิวของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการเว้นระยะตาราง**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่าแบบมุมมองทั่วทั้งการนำเสนอ เมธอด [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) และ [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) ใช้อ่านหรือเปลี่ยนช่วงของตารางแก้ไขพื้นฐาน การตั้งค่านี้จะนำไปใช้กับการนำเสนอทั้งหมด ไม่ใช่สไลด์แต่ละสไลด์ การเว้นระยะตารางระบุเป็นพอยต์ โดยที่ 72 พอยต์เท่ากับหนึ่งนิ้ว ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่แล้ว พิมพ์ค่าเว้นระยะตารางปัจจุบัน ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว และบันทึกผลลัพธ์.

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

ตารางแตกต่างจาก [drawing guides](/slides/th/androidjava/drawing-guides/). การเว้นระยะตารางควบคุมช่วงปกติ ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งเป็นรายบุคคล การเพิ่ม, ย้าย หรือเคลียร์ drawing guides จะไม่เปลี่ยนแปลงการเว้นระยะตาราง.

ทั้งตารางและ drawing guides เป็นเครื่องมือช่วยการแก้ไข ไม่ได้แสดงเป็นเนื้อหาในสไลด์ใน PDF, รูปภาพ, SVG หรือการแสดงสไลด์ การเก็บค่าการเว้นระยะตารางไม่รับประกันว่าโปรแกรมแก้ไขจะแสดงตาราง: การมองเห็นยังขึ้นกับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไข.

## **คำถามที่พบบ่อย**

**ทำไมตารางไม่ปรากฏหลังจากฉันเปิดการนำเสนอใหม่?**

ไฟล์บันทึกค่าการเว้นระยะตารางไว้ แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่าจะมแสดงตารางหรือไม่ ตรวจสอบการตั้งค่าการมองเห็นตารางของโปรแกรมแก้ไข.

**การเคลียร์ drawing guides จะเปลี่ยนการเว้นระยะตารางหรือไม่?**

ไม่. drawing guides และการเว้นระยะตารางเป็นการตั้งค่าที่แยกจากกัน การเคลียร์ guides จะไม่ได้เปลี่ยนช่วงตารางที่เก็บไว้.

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), ไม่ได้ระดับส่วน ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับทั้งเอกสารเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน แอปพลิเคชันผู้ดูอาจเคารพการตั้งค่าผู้ใช้ แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถสร้างเทมเพลตที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) ถูกเก็บระดับการนำเสนอ คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นโดยมีการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.