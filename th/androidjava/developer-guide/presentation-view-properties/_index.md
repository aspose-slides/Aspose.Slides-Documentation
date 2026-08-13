---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอบน Android
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/androidjava/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- ดักตัวแบ่งแนวตั้ง
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP—ปรับการจัดวาง, ระดับซูม, และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองแบบปกติมีพื้นที่เนื้อหา 3 ส่วน ได้แก่ สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวข้องกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหา ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงไฟล์ได้ เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสภาพเดียวกับที่บันทึกการนำเสนอครั้งสุดท้าย.

เมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) ได้รับการเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองแบบปกติของการนำเสนอ

อินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties) และ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType) ได้ถูกเพิ่ม

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองแบบปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่ใด ๆ ของมุมมองแบบปกติ

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าตัวแบ่งแนวตั้งควรล็อคเป็นสถานะย่อเมื่อพื้นที่ด้านข้างเล็กพอหรือไม่

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองแบบปกติมาตรฐานที่มีสามพื้นที่หรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง แถบแบ่งแนวนอนแยกสไลด์ออกจากพื้นที่เนื้อหาด้านล่างสไลด์, ส่วนแถบแบ่งแนวตั้งแยกสไลด์ออกจากพื้นที่เนื้อหาด้านข้าง ค่าที่เป็นไปได้คือ [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุขนาดของส่วนบนหรือด้านข้างของสไลด์ในมุมมองแบบปกติเมื่อมีค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ

## **เกี่ยวกับการกู้คืน INormalViewProperties**

ระบุขนาดของส่วนสไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองแบบปกติเมื่อส่วนนั้นมีขนาดที่ถูกคืนค่าตัวแปร (ไม่ย่อและไม่ขยาย).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของส่วนสไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับให้สอดคล้องกับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) สำหรับการนำเสนอ

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // เรียกคืนคุณสมบัติมุมมองของการนำเสนอ
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

Aspose.Slides for Android via Java ตอนนี้รองรับการตั้งค่าซูมเริ่มต้นสำหรับการนำเสนอโดยที่เมื่อเปิดการนำเสนอแล้วซูมจะถูกตั้งไว้แล้ว สามารถทำได้โดยการกำหนด [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของการนำเสนอ ทั้ง [getSlideViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าได้ด้วยโปรแกรม ในหัวข้อนี้เราจะดูตัวอย่างวิธีการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) ใน Aspose.Slides

{{% /alert %}} 

เพื่อกำหนดคุณสมบัติมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
2. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
3. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) ในตัวอย่างด้านล่าง เราได้ตั้งค่าซูมสำหรับมุมมองสไลด์และมุมมองบันทึกย่อ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกย่อ 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

### ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?

การตั้งค่ามุมมองถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)) ไม่ได้ตามส่วน ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

### ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ที่ต่างกันได้หรือไม่?

ไม่ การตั้งค่าถูกบันทึกในไฟล์และใช้ร่วมกัน แอปพลิเคชันผู้ดูอาจเคารพการตั้งค่าของผู้ใช้ แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว

### ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?

ได้ เนื่องจาก [view properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) ถูกเก็บระดับการนำเสนอ คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดมุมมองเริ่มต้นเดียวกัน