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
- ล็อคตัวแบ่งแนวตั้ง
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
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP—ปรับเลย์เอาต์ ระดับการซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติมีพื้นที่เนื้อหา 3 ส่วน ได้แก่ สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่าง ๆ ข้อมูลนี้ช่วยให้แอปพลิเคชันบันทึกสถานะมุมมองลงไฟล์ เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกันกับขณะบันทึกการนำเสนอครั้งสุดท้าย

เมธอด [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ

อินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties) และคลาสลูกของมัน, enum [SplitterBarStateType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType) ได้ถูกเพิ่ม

## **เกี่ยวกับ INormalViewProperties**

แทนคุณสมบัติมุมมองปกติ

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ระบุว่าแอปพลิเคชันจะแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ระบุว่าตัวแบ่งแนวตั้งควรล็อคไปยังสถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ

คุณสมบัติ [getPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) และ [setPreferSingleView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ระบุว่าผู้ใช้ต้องการมองเห็นพื้นที่เนื้อหาเด้งเดียวเต็มหน้าต่างแทนมุมมองปกติแบบมาตรฐานที่มีสามพื้นที่หรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาให้เต็มหน้าต่าง

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง แถบแบ่งแนวนอนจะแยกสไลด์ออกจากพื้นที่เนื้อหาที่อยู่ด้านล่างสไลด์, แถบแบ่งแนวตั้งจะแยกสไลด์ออกจากพื้นที่เนื้อหาด้านข้าง ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) และ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติเมื่อใช้ค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SplitterBarStateType#Restored) กับ [getVerticalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) ตามลำดับ

## **เกี่ยวกับการกู้คืน INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) ของมุมมองปกติเมื่อพื้นที่มีขนาดที่กู้คืนได้แบบเปลี่ยนแปลง (ไม่ย่อและไม่ขยาย)

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับเพื่อชดเชยขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปหรือไม่

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติของ [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) สำหรับการนำเสนอ

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

## **ตั้งค่าค่าซูมเริ่มต้น**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java ตอนนี้รองรับการตั้งค่าซูมเริ่มต้นสำหรับการนำเสนอ เพื่อให้เมื่อเปิดการนำเสนอแล้วซูมถูกตั้งไว้แล้ว สามารถทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของการนำเสนอ [getSlideViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) สามารถตั้งค่าโดยโปรแกรมได้ ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) ใน Aspose.Slides

{{% /alert %}} 

เพื่อกำหนดคุณสมบัติมุมมอง กรุณาปฏิบัติตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ViewProperties) ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. เขียนการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) 
   ในตัวอย่างด้านล่าง เราได้ตั้งค่าซูมสำหรับมุมมองสไลด์และมุมมองบันทึกย่อ

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

## **ตั้งค่าการจัดช่องตาราง**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอ ทั้งหมด เมธอด [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) และ [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด ไม่ใช่กับสไลด์เดี่ยว ๆ การจัดช่องกริดระบุเป็นจุด โดย 72 จุดเท่ากับหนึ่งนิ้ว ใช้ค่าบวกตามที่เอกสาร API ระบุ

ตัวอย่างต่อไปเปิดไฟล์ `demo.pptx` ที่มีอยู่แล้ว แสดงค่าการจัดช่องกริดปัจจุบัน ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว และบันทึกผลลัพธ์

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

กริดแตกต่างจาก [drawing guides](/slides/th/androidjava/drawing-guides/). การจัดช่องกริดควบคุมช่วงที่สม่ำเสมอ ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งแบบแยกกัน การเพิ่ม ย้าย หรือลบ drawing guides จะไม่เปลี่ยนการจัดช่องกริด

กริดและ drawing guides ทั้งสองเป็นเครื่องมือช่วยการแก้ไข พวกมันไม่ถูกแสดงเป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG หรือการนำเสนอ การจัดเก็บการจัดช่องกริดไม่รับประกันว่าโปรแกรมแก้ไขจะทำให้กริดแสดงผล: ความสามารถในการมองเห็นยังขึ้นกับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไข

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอทั้งหมด ใช้ [IViewProperties.getShowComments](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) และ [IViewProperties.setShowComments](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) เพื่ออ่านหรือเปลี่ยนการตั้งค่าที่เก็บไว้เกี่ยวกับการแสดงความคิดเห็นเมื่อการนำเสนอเปิดใน PowerPoint หรือโปรแกรมที่เข้ากันได้อื่น

การตั้งค่านี้ควบคุมเพียงการตั้งค่ามุมมองที่เก็บไว้เท่านั้น ไม่ได้เพิ่ม ลบ แก้ไข หรือแก้ปัญหาความคิดเห็น การซ่อนความคิดเห็นจะคงเนื้อหา ผู้เขียน ตำแหน่ง การตอบกลับ และสถานะของความคิดเห็นไว้ ดูที่ [Presentation Comments](/slides/th/androidjava/presentation-comments/) สำหรับการกระทำที่เปลี่ยนแปลงความคิดเห็นเอง

ตัวอย่างต่อไปต้องมีไฟล์ `comments.pptx` ที่มีความคิดเห็นอยู่แล้ว มันจะแสดงการตั้งค่าการมองเห็นปัจจุบัน, ขอให้ซ่อนความคิดเห็น, และบันทึกไฟล์ PPTX ใหม่โดยไม่ลบความคิดเห็นใด ๆ อีก ทั้งนี้ยังใช้ [IViewProperties.setLastView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) ร่วมกับ [ViewType.SlideView](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewtype/#SlideView) เพื่อกำหนดมุมมองการแก้ไขเริ่มต้นพร้อมกับการมองเห็นความคิดเห็น

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

การตั้งค่านี้ไม่ได้กำหนดว่าความคิดเห็นจะรวมอยู่ในการส่งออกเป็น PDF, HTML, รูปภาพ, โน้ต หรือเอกสารแจกจ่ายหรือไม่ คำสั่งที่เกี่ยวข้องกับการส่งออกแต่ละประเภทต้องกำหนดแยกต่างหาก

## **FAQ**

**ทำไมกริดไม่แสดงหลังจากที่เปิดการนำเสนอใหม่?**

ไฟล์บันทึกค่าการจัดช่องกริดไว้ แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่ ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข

**การลบ drawing guides จะทำให้การจัดช่องกริดเปลี่ยนหรือไม่?**

ไม่. drawing guides และการจัดช่องกริดเป็นการตั้งค่าแยกกัน การลบ guides จะไม่ทำให้ช่วงกริดที่เก็บไว้เปลี่ยนแปลง

**ฉันสามารถตั้งค่ามุมมองต่าง ๆ สำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

การตั้งค่า [View settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)) ไม่ได้ระดับส่วน ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน แอปพลิเคชันตัวดูอาจเคารพการตั้งค่าผู้ใช้ แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเพียงชุดเดียว

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดแบบเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getViewProperties--) ถูกเก็บระดับการนำเสนอ คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากมันโดยมีการตั้งค่ามุมมองเริ่มต้นเดียวกัน