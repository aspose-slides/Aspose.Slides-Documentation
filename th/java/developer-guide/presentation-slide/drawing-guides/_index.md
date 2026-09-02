---
title: จัดการไกด์การวาดในงานนำเสนอด้วย Java
linktitle: ไกด์การวาด
type: docs
weight: 85
url: /th/java/drawing-guides/
keywords:
- ไกด์การวาด
- ไกด์แนวนอน
- ไกด์แนวตั้ง
- ไกด์การจัดแนว
- มุมมองสไลด์
- สไลด์มาสเตอร์
- สไลด์เลย์เอาต์
- โน้ตมาสเตอร์
- แฮนด์เอาท์มาสเตอร์
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "เพิ่ม, เข้าถึง, และลบไกด์การวาดแนวนอนและแนวตั้งในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

ไกด์การวาดเป็นเส้นแนวนอนและแนวตั้งที่ปรับได้ซึ่งช่วยให้ผู้ใช้จัดแนวรูปร่างได้อย่างสม่ำเสมอขณะแก้ไขงานนำเสนอใน PowerPoint พวกมันมีประโยชน์เป็นพิเศษเมื่อแอปพลิเคชันสร้างงานนำเสนอที่ภายหลังจะต้องปรับแต่งด้วยตนเอง: แอปพลิเคชันสามารถบันทึกไกด์การจัดแนวเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อต้องเพิ่มหรือย้ายเนื้อหา

ไกด์การวาดเป็นเครื่องมือช่วยแก้ไข ไม่ใช่เนื้อหาในสไลด์ พวกมันไม่ปรากฏในการนำเสนอแบบสไลด์โชว์หรือผลลัพธ์ที่เรนเดอร์ Aspose.Slides for Java เปิดเผยพวกมันผ่านอินเทอร์เฟซ [IDrawingGuidesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguidescollection/) ไกด์หนึ่งถูกแทนด้วย [IDrawingGuide](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguide/) และมีการกำหนดแนว, ตำแหน่ง, และสี

ตำแหน่งจะวัดเป็นจุด (points) จากมุมบนซ้ายของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง ไกด์แนวตั้งใช้พิกัดแนวนอน ซึ่งโดยทั่วไปอยู่ระหว่างศูนย์ถึงความกว้างของสไลด์ ไกด์แนวนอนใช้พิกัดแนวตั้ง ซึ่งโดยทั่วไปอยู่ระหว่างศูนย์ถึงความสูงของสไลด์

## **เพิ่มไกด์ไปยังมุมมองสไลด์**

ใช้ [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/th/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) เพื่อจัดการไกด์ที่แสดงขณะแก้ไขสไลด์ปกติ เรียกใช้ [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) พร้อมค่าของ [Orientation](https://reference.aspose.com/slides/th/java/com.aspose.slides/orientation/) และตำแหน่งเป็นจุด

ตัวอย่างต่อไปนี้เพิ่มไกด์แนวตั้งหนึ่งเส้นทางขวาของจุดกึ่งกลางสไลด์และไกด์แนวนอนหนึ่งเส้นด้านล่างของมัน:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึงไกด์การวาด**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguidescollection/#getCount--) และ [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguidescollection/#get_Item-int--) ให้เข้าถึงไกด์ที่มีอยู่ ส่วนเมธอด [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguide/#getPosition--), และ [IDrawingGuide.getColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguide/#getColor--) จะคืนค่า ซึ่งสามารถเปลี่ยนได้ผ่านเมธอด setter ที่สอดคล้องกัน

ตัวอย่างต่อไปนี้อ่านไกด์ของมุมมองสไลด์จากงานนำเสนอที่สร้างขึ้นข้างต้น:

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

## **เพิ่มไกด์ไปยังสไลด์มาสเตอร์และเลย์เอาต์**

สไลด์มาสเตอร์และสไลด์เลย์เอาต์แต่ละอันสามารถมีคอลเลคชันไกด์การวาดของตนเอง ใช้ [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/#getDrawingGuides--) สำหรับสไลด์มาสเตอร์และ [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) สำหรับสไลด์เลย์เอาต์

ตัวอย่างต่อไปนี้เพิ่มไกด์แนวตั้งหนึ่งเส้นในสไลด์มาสเตอร์แรกและไกด์แนวนอนหนึ่งเส้นในสไลด์เลย์เอาต์แรก:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มไกด์ไปยังโน้ตมาสเตอร์และแฮนด์เอาท์มาสเตอร์**

โน้ตมาสเตอร์และแฮนด์เอาท์มาสเตอร์ก็รองรับไกด์การวาดเช่นกัน ใช้ [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) และ [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) เพื่อเข้าถึงคอลเลคชันของพวกมัน หากงานนำเสนอไม่มีมาสเตอร์เหล่านี้ใดหนึ่ง [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) หรือ [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) จะสร้างมาสเตอร์เริ่มต้นและคืนค่า

ตัวอย่างต่อไปนี้เพิ่มไกด์แนวนอนหนึ่งเส้นในโน้ตมาสเตอร์และไกด์แนวตั้งหนึ่งเส้นในแฮนด์เอาท์มาสเตอร์:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบไกด์การวาด**

เรียกใช้ [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguidescollection/#clear--) เพื่อลบไกด์ทั้งหมดออกจากคอลเลคชันเฉพาะหนึ่ง การลบคอลเลคชันหนึ่งไม่ได้ส่งผลต่อไกด์ที่เก็บไว้ในสโคปอื่น

ตัวอย่างต่อไปนี้ลบไกด์ของมุมมองสไลด์และไกด์ทั้งหมดในสไลด์มาสเตอร์, สไลด์เลย์เอ็ท, โน้ตมาสเตอร์, และแฮนด์เอาท์มาสเตอร์โดยไม่สร้างมาสเตอร์ที่หายไป:

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

**ไกด์การวาดปรากฏในสไลด์โชว์หรือภาพที่ส่งออกหรือไม่?**

ไม่ ไกด์การวาดเป็นเครื่องมือช่วยจัดแนวสำหรับการแก้ไขและไม่ได้เรนเดอร์เป็นเนื้อหาของงานนำเสนอ

**สามารถเพิ่มไกด์การวาดโดยตรงลงในสไลด์ปกติแต่ละสไลด์ได้หรือไม่?**

ไกด์การแก้ไขสไลด์ปกติเก็บในคุณสมบัติของมุมมองสไลด์ของงานนำเสนอ มีคอลเลคชันไกด์แยกต่างหากสำหรับสไลด์มาสเตอร์, สไลด์เลย์เอาต์, โน้ตมาสเตอร์, และแฮนด์เอาท์มาสเตอร์

**หน่วยใดที่ใช้สำหรับตำแหน่งไกด์?**

ตำแหน่งระบุเป็นจุด (points) โดย 72 จุดเท่ากับหนึ่งนิ้ว ตำแหน่งแนวตั้งวัดจากขอบซ้ายและตำแหน่งแนวนอนวัดจากขอบบน

**การลบไกด์การวาดทำให้รูปทรงหายหรือเปลี่ยนแปลงเนื้อหาในสไลด์หรือไม่?**

ไม่ เมธอด [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/idrawingguidescollection/#clear--) จะลบเฉพาะไกด์ในคอลเลคชันที่เลือก รูปทรงและเนื้อหาอื่น ๆ ของสไลด์จะคงเดิม