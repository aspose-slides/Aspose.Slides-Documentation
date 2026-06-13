---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอบน Android
linktitle: คุณสมบัตุมุมมอง
type: docs
weight: 80
url: /th/androidjava/presentation-view-properties/
keywords:
- คุณสมบัตุมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนไครงร่าง
- แยกแนวตั้งสแนป
- มุมมองเดียว
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
description: "ค้นพบคุณสมบัตุมุมมองของ Aspose.Slides สำหรับ Android via Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX, และ ODP — ปรับการจัดวาง, ระดับซูม, และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่าง ๆ นี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสภาพเดียวกับเมื่อบันทึกงานนำเสนอครั้งล่าสุด.

เมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) ถูกเพิ่มเข้ามาเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของงานนำเสนอ. 

[INormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties) อินเตอร์เฟซและทายาทของมัน, [SplitterBarStateType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType) enum ได้รับการเพิ่มเข้ามา.

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าแยกแนวตั้งควรสแนปเป็นสถานะย่อเมื่อพื้นที่ด้านข้างเล็กพอ.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการเห็นพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบแยกแนวนอนหรือแนวตั้งควรแสดง. แถบแยกแนวนอนแยกสไลด์ออกจากพื้นที่เนื้อหาด้านล่างสไลด์, แถบแยกแนวตั้งแยกสไลด์ออกจากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Maximized), และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ เมื่อค่ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่คืนค่าตัวแปร (ไม่ย่อและไม่ขยายเต็ม).  

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับตัวเพื่อชดเชยขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) สำหรับงานนำเสนอ.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // คืนค่าคุณสมบัติมุมมองของงานนำเสนอ
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

Aspose.Slides for Android via Java ตอนนี้รองรับการตั้งค่าค่าซูมเริ่มต้นสำหรับงานนำเสนอเพื่อให้เมื่องานนำเสนอเปิดขึ้น ซูมจะถูกตั้งไว้แล้ว. สิ่งนี้ทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของงานนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าโดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) ใน [Aspose.Slides](/slides/th/).

{{% /alert %}} 

เพื่อกำหนดคุณสมบัติมุมมอง กรุณาทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
2. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
3. บันทึกงานนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าซูมสำหรับมุมมองสไลด์และมุมมองบันทึกย่อ

```java
Presentation presentation = new Presentation();
try {
    // ตั้งค่าคุณสมบัติมุมมองของงานนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่า Zoom เป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่า Zoom เป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกย่อ 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของงานนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) ถูกกำหนดในระดับงานนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), ไม่ได้ต่อส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับทั้งเอกสารเมื่อเปิด.

**ฉันสามารถกำหนดล่วงหน้าสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่. การตั้งค่าถูกจัดเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเพียงชุดเดียว.

**ฉันสามารถเตรียมแม่แบบที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้การเปิดงานนำเสนอใหม่เป็นแบบเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) ถูกจัดเก็บในระดับงานนำเสนอ, คุณสามารถฝังมันในแม่แบบและสร้างเอกสารใหม่จากมันด้วยการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.