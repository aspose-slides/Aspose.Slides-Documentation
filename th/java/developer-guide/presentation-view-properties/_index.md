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
- สแน็ปตัวแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมค่าเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides for Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX, และ ODP — ปรับการจัดวางระดับการซูมและการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวข้องกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหาเหล่านี้. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้, เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสภาพเดียวกับที่การนำเสนอถูกบันทึกครั้งล่าสุด.

เมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) ได้ถูกเพิ่มเข้ามาเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.

อินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties) และ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType) ได้ถูกเพิ่มเข้ามา.

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าทแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าตัวแบ่งแนวตั้งควรสแน็ปไปสู่สถานะย่อต่างเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอหรือไม่.

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาในทั้งหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่าง, แถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่ด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุการกำหนดขนาดของส่วนบนหรือด้านข้างของสไลด์ในมุมมองปกติ, เมื่อค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/java/com.aspose.slides/SplitterBarStateType#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่ถูกกู้คืนแบบเปลี่ยนแปลงได้ (ไม่ย่อหรือขยาย).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับให้เข้ากับขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) ของการนำเสนอ.

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

## **ตั้งค่าการซูมค่าเริ่มต้น**

{{% alert color="info" %}} 
Aspose.Slides for Java ตอนนี้สนับสนุนการตั้งค่าค่าการซูมเริ่มต้นสำหรับการนำเสนอ เพื่อให้เมื่อเปิดการนำเสนอ การซูมจะถูกตั้งไว้แล้ว. สิ่งนี้ทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของการนำเสนอ. ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งโปรแกรมได้. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) ใน [Aspose.Slides](/slides/th/).
{{% /alert %}} 

เพื่อกำหนดคุณสมบัตุมุมมอง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/).
   ในตัวอย่างด้านล่าง เราได้ตั้งค่าการซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

### ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?

การตั้งค่า [View settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกกำหนดระดับการนำเสนอ (Normal View/Slide View) ไม่ได้ระดับส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

### ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าของผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียวเท่านั้น.

### ฉันสามารถเตรียมแม่แบบที่มี View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดด้วยวิธีเดียวกันได้หรือไม่?

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getViewProperties--) ถูกเก็บระดับการนำเสนอ, คุณสามารถฝังไว้ในแม่แบบและสร้างเอกสารใหม่จากแม่แบบนั้นด้วยการกำหนดมุมมองเริ่มต้นเดียวกัน.