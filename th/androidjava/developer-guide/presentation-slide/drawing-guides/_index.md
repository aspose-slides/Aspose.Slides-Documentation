---
title: จัดการแนวทางการวาดในงานนำเสนอบน Android
linktitle: แนวทางการวาด
type: docs
weight: 85
url: /th/androidjava/drawing-guides/
keywords:
- แนวทางการวาด
- แนวทางแนวนอน
- แนวทางแนวตั้ง
- แนวการจัดตำแหน่ง
- มุมมองสไลด์
- มาสเตอร์สไลด์
- สไลด์เลย์เอาต์
- มาสเตอร์โน้ต
- มาสเตอร์เอกสารแจกจ่าย
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่ม, เข้าถึง, และลบแนวทางการวาดแนวนอนและแนวตั้งในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for Android ผ่าน Java."
---
## **ภาพรวม**

แนวทางการวาดเป็นเส้นแนวนอนและแนวตั้งที่ปรับได้ซึ่งช่วยให้ผู้ใช้จัดตำแหน่งรูปร่างอย่างสม่ำเสมอขณะแก้ไขงานนำเสนอใน PowerPoint มันมีประโยชน์อย่างยิ่งเมื่อแอปพลิเคชันสร้างงานนำเสนอแล้วจะต้องมีการปรับแต่งด้วยมือภายหลัง: แอปพลิเคชันสามารถบันทึกเครื่องมือจัดตำแหน่งเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อต้องเพิ่มหรือย้ายเนื้อหา

แนวทางการวาดเป็นเครื่องมือช่วยการแก้ไข ไม่ใช่เนื้อหาในสไลด์ พวกมันไม่ปรากฏในการแสดงสไลด์หรือผลลัพธ์ที่เรนเดอร์ Aspose.Slides for Android ผ่าน Java เปิดเผยพวกมันผ่านอินเตอร์เฟส [IDrawingGuidesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguidescollection/) แนวทางหนึ่งจะแสดงโดย [IDrawingGuide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguide/) และมีการกำหนดแนวทาง, ตำแหน่งและสี

ตำแหน่งวัดเป็นหน่วยจุดจากมุมซ้ายบนของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง แนวตั้งใช้ค่าพิกัดแนวนอน ซึ่งปกติอยู่ระหว่างศูนย์ถึงความกว้างของสไลด์ แนวนอนใช้ค่าพิกัดแนวดิ่ง ซึ่งปกติอยู่ระหว่างศูนย์ถึงความสูงของสไลด์

## **เพิ่มแนวทางในมุมมองสไลด์**

ใช้ [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) เพื่อจัดการแนวทางที่แสดงขณะแก้ไขสไลด์ปกติ เรียก [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) พร้อมค่าของ [Orientation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/orientation/) และตำแหน่งเป็นหน่วยจุด

ตัวอย่างต่อไปนี้เพิ่มแนวตั้งหนึ่งเส้นที่ด้านขวาของจุดกึ่งกลางสไลด์และแนวนอนหนึ่งเส้นใต้จุดนั้น:
```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึงแนวทางการวาด**

เมธอด [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) และ [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) ให้การเข้าถึงแนวทางที่มีอยู่ เมธอด [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguide/#getPosition--), และ [IDrawingGuide.getColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguide/#getColor--) คืนค่าที่สามารถเปลี่ยนแปลงได้ผ่านเมธอด setter ที่สอดคล้องกัน

ตัวอย่างต่อไปนี้อ่านแนวทางของมุมมองสไลด์จากงานนำเสนอที่สร้างขึ้นข้างต้น:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **เพิ่มแนวทางในมาสเตอร์และสไลด์เลย์เอาต์**

มาสเตอร์สไลด์และสไลด์เลย์เอาต์แต่ละอันสามารถมีคอลเลกชันแนวทางการวาดของตนเองได้ ใช้ [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) สำหรับมาสเตอร์สไลด์และ [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) สำหรับสไลด์เลย์เอาต์

ตัวอย่างต่อไปนี้เพิ่มแนวตั้งหนึ่งเส้นไปยังมาสเตอร์สไลด์แรกและแนวนอนหนึ่งเส้นไปยังสไลด์เลย์เอาต์แรก:
```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มแนวทางในมาสเตอร์โน้ตและมาสเตอร์เอกสารแจกจ่าย**

มาสเตอร์โน้ตและมาสเตอร์เอกสารแจกจ่ายก็รองรับแนวทางการวาดเช่นกัน ใช้ [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) และ [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) เพื่อเข้าถึงคอลเลกชันของพวกมัน หากงานนำเสนอไม่มีมาสเตอร์เหล่านี้ใดอย่างหนึ่ง [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) หรือ [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) จะสร้างมาสเตอร์เริ่มต้นและส่งคืนมัน

ตัวอย่างต่อไปนี้เพิ่มแนวนอนหนึ่งเส้นไปยังมาสเตอร์โน้ตและแนวตั้งหนึ่งเส้นไปยังมาสเตอร์เอกสารแจกจ่าย:
```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบแนวทางการวาด**

เรียก [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) เพื่อเอาแนวทางทั้งหมดออกจากคอลเลกชันที่ระบุ การลบคอลเลกชันหนึ่งจะไม่ส่งผลต่อแนวทางที่เก็บไว้ในสโคปอื่น

ตัวอย่างต่อไปนี้ลบแนวทางของมุมมองสไลด์และแนวทางทั้งหมดบนมาสเตอร์สไลด์, สไลด์เลย์เอาต์, มาสเตอร์โน้ต, และมาสเตอร์เอกสารแจกจ่ายโดยไม่สร้างมาสเตอร์ที่หายไป:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**แนวทางการวาดปรากฏในสไลด์โชว์หรือภาพที่ส่งออกหรือไม่?**

ไม่ แนวทางการวาดเป็นเครื่องมือช่วยจัดตำแหน่งสำหรับการแก้ไขและไม่ได้ถูกเรนเดอร์เป็นเนื้อหาของงานนำเสนอ

**สามารถเพิ่มแนวทางการวาดโดยตรงไปยังสไลด์ปกติแต่ละอันได้หรือไม่?**

แนวทางการแก้ไขสไลด์ปกติจะถูกเก็บในคุณสมบัติมุมมองสไลด์ของงานนำเสนอ คอลเลกชันแนวทางแยกกันพร้อมใช้งานสำหรับมาสเตอร์สไลด์, สไลด์เลย์เอาต์, มาสเตอร์โน้ต, และมาสเตอร์เอกสารแจกจ่าย

**หน่วยใดใช้สำหรับตำแหน่งของแนวทาง?**

ตำแหน่งกำหนดเป็นหน่วยจุด ซึ่ง 72 จุดเท่ากับหนึ่งนิ้ว ตำแหน่งแนวตั้งวัดจากด้านซ้าย และตำแหน่งแนวนอนวัดจากด้านบน

**การลบแนวทางการวาดจะทำให้รูปทรงหายหรือเปลี่ยนแปลงเนื้อหาสไลด์หรือไม่?**

ไม่ เมธอด [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) จะลบเฉพาะแนวทางในคอลเลกชันที่เลือก รูปร่างและเนื้อหาอื่น ๆ ของสไลด์ยังคงไม่เปลี่ยนแปลง