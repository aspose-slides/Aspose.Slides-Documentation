---
title: ดึงและอัปเดตคุณสมบัติมุมมองพรีเซนเทชันใน Java
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแนปตัวแบ่งแนวตั้ง
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP - ปรับเลย์เอาต์ ระดับซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติมีพื้นที่เนื้อหาสามส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่าง ๆ. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะการมองเห็นลงในไฟล์ได้ เพื่อให้เมื่่อเปิดใหม่มุมมองยังคงอยู่ในสถานะเดียวกับเมื่อทำการบันทึกพรีเซนเทชันครั้งสุดท้าย.

เมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) ได้ถูกเพิ่มเข้ามาเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของพรีเซนเทชัน.  

อินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties) และลูกสืบของมัน, ENUM [SplitterBarStateType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType) ได้ถูกเพิ่มเข้ามา.

## **เกี่ยวกับ INormalViewProperties**

แทนคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าตัวแบ่งแนวตั้งควรสแนปเข้าสู่สถานะย่อเมื่อพื้นที่ด้านข้างเล็กพอ.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาแบบเดี่ยวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง แถบแบ่งแนวนอนจะแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์, แถบแบ่งแนวตั้งจะแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุการกำหนดขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติเมื่อค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการกู้คืน INormalViewProperties**

ระบุการกำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ เมื่อพื้นที่มีขนาดที่เรียกคืนได้แบบเปลี่ยนแปลง (ไม่ได้ย่อหรือขยาย).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับให้เข้ากับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) ของพรีเซนเทชัน.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // กู้คืนคุณสมบัติมุมมองของพรีเซนเทชัน
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ตั้งค่าค่าซูมเริ่มต้น**

{{% alert color="primary" %}} 

Aspose.Slides for Java ตอนนี้รองรับการตั้งค่าค่าซูมเริ่มต้นสำหรับพรีเซนเทชันเพื่อให้เมื่อเปิดพรีเซนเทชันแล้ว ซูมจะถูกตั้งค่าไว้แล้ว. สิ่งนี้ทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของพรีเซนเทชัน. [getSlideViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าได้โดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) ใน [Aspose.Slides](/slides/th/).

{{% /alert %}} 

เพื่อกำหนดคุณสมบัตุมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. บันทึกพรีเซนเทชันเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) . ตัวอย่างด้านล่าง เราได้ตั้งค่าซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```java
Presentation presentation = new Presentation();
try {
    // ตั้งค่าคุณสมบัติมุมมองของพรีเซนเทชัน
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่า Zoom เป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่า Zoom เป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถตั้งค่ามุมมองต่าง ๆ สำหรับส่วนต่าง ๆ ของพรีเซนเทชันได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกกำหนดระดับพรีเซนเทชัน ([Normal View](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), ไม่ได้แยกตามส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะนำไปใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดล่วงหน้าสถานะมุมมองต่าง ๆ สำหรับผู้ใช้แต่ละคนได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกจัดเก็บในไฟล์และใช้ร่วมกัน แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัตุมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้พรีเซนเทชันใหม่เปิดในรูปแบบเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกจัดเก็บระดับพรีเซนเทชัน, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.