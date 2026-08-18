---
title: โคลนสไลด์การนำเสนอบน Android
linktitle: โคลนสไลด์
type: docs
weight: 35
url: /th/androidjava/clone-slides/
keywords:
- โคลนสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำสำเนาสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android. ทำตามตัวอย่างโค้ด Java ที่ชัดเจนของเราเพื่อสร้าง PPT อัตโนมัติในไม่กี่วินาทีและขจัดงานทำด้วยตนเอง."
---
## **บทนำ**

การทำสำเนาคือกระบวนการสร้างสำเนาที่ตรงกันหรือสำเนาที่เหมือนกันของสิ่งใดสิ่งหนึ่ง. Aspose.Slides สำหรับ Android ผ่าน Java ยังทำให้สามารถสร้างสำเนาหรือโคลนของสไลด์ใด ๆ แล้วแทรกสไลด์ที่โคลนไว้ลงในงานนำเสนอปัจจุบันหรือในงานนำเสนอที่เปิดอยู่อื่น ๆ ได้. กระบวนการโคลนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ. มีหลายวิธีที่สามารถใช้โคลนสไลด์ได้:

- โคลนที่ตำแหน่งท้ายภายในการนำเสนอหนึ่ง
- โคลนที่ตำแหน่งอื่นภายในการนำเสนอ
- โคลนที่ตำแหน่งท้ายในการนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในการนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในการนำเสนออื่น

ใน Aspose.Slides สำหรับ Android ผ่าน Java, (a collection of [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlide) objects) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) และ [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) เพื่อทำการโคลนสไลด์ตามประเภทข้างต้น

## **โคลนสไลด์ที่ตำแหน่งท้ายของการนำเสนอ**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) method according to the steps listed below:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
1. เรียกใช้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่จะทำการโคลนเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. เขียนไฟล์การนำเสนอที่แก้ไขแล้ว.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // โคลนสไลด์ที่ต้องการไปยังตำแหน่งท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นภายในการนำเสนอ**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) method:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
1. สร้างอินสแตนซ์ของคลาสโดยอ้างอิงคอลเลกชัน [**Slides**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
1. เรียกใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่จะทำการโคลนพร้อมกับดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

In the example given below, we have cloned a slide (lying at index 1 – position 2 – of the presentation) to index 2 – Position 3 – of the presentation.

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // ดึงคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    ISlideCollection slds = pres.getSlides();

    // โคลนสไลด์ที่ต้องการไปยังตำแหน่งดัชนีที่ระบุในงานนำเสนอเดียวกัน
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **โคลนสไลด์ที่ตำแหน่งท้ายของการนำเสนออื่น**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่บรรจุการนำเสนอซึ่งสไลด์จะถูกโคลนจากนั้น.
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่บรรจุการนำเสนอปลายทางซึ่งสไลด์จะถูกเพิ่มเข้ามา.
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection) โดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ Presentation ของการนำเสนอปลายทาง.
1. เรียกใช้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่เป็นต้นแบบเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอ็อบเจกต์ Presentation สำหรับไฟล์ PPTX ปลายทาง (ซึ่งสไลด์จะถูกโคลน)
    Presentation destPres = new Presentation();
    try {
        // โคลนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาที่ตำแหน่งท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // บันทึกการนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นในการนำเสนออื่น**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่บรรจุการนำเสนอแหล่งที่สไลด์จะถูกโคลนจาก.
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่บรรจุการนำเสนอซึ่งสไลด์จะถูกเพิ่มเข้ามา.
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ Presentation ของการนำเสนอปลายทาง.
1. เรียกใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่เป็นต้นแบบพร้อมกับตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอ็อบเจกต์ Presentation สำหรับไฟล์ PPTX ปลายทาง (ซึ่งสไลด์จะถูกโคลน)
    Presentation destPres = new Presentation();
    try {
        // โคลนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาที่ตำแหน่งดัชนีที่ระบุในการนำเสนอปลายทาง
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // บันทึกการนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **โคลนสไลด์ที่ตำแหน่งเฉพาะในการนำเสนออื่น**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่บรรจุการนำเสนอแหล่งที่สไลด์จะถูกโคลนจาก.
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่บรรจุการนำเสนอปลายทางที่สไลด์จะถูกโคลนไป.
1. เข้าถึงสไลด์ที่จะโคลนพร้อมกับมาสเตอร์สไลด์.
1. สร้างอินสแตนซ์ของคลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ของการนำเสนอปลายทาง.
1. เรียกใช้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterSlideCollection) และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่เป็นต้นแบบเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) โดยตั้งค่าให้อ้างอิงคอลเลกชัน Slides ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ของการนำเสนอปลายทาง.
1. เรียกใช้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) ที่เปิดให้ใช้งานผ่านอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่เป็นต้นแบบพร้อมกับมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว.

In the example given below, we have cloned a slide with a master (lying at the zero index of the source presentation) to the end of the destination presentation using a master from source slide.

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // สร้างอ็อบเจกต์ Presentation สำหรับการนำเสนอปลายทาง (ซึ่งสไลด์จะถูกโคลน)
    Presentation destPres = new Presentation();
    try {
        // สร้าง ISlide จากคอลเลกชันสไลด์ในการนำเสนอแหล่งที่มาพร้อมกับ
        // มาสเตอร์สไลด์
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // โคลนมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาลงในคอลเลกชันมาสเตอร์ของ
        // การนำเสนอปลายทาง
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // โคลนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังตำแหน่งท้ายของ
        // คอลเลกชันสไลด์ในการนำเสนอปลายทาง
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // บันทึกการนำเสนอปลายทางลงดิสก์
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **โคลนสไลด์ที่ตำแหน่งท้ายของส่วนที่ระบุ**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**addClone**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) method exposed by the [**ISlideCollection**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection) interface. Aspose.Slides for Android via Java makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// บันทึกการนำเสนอปลายทางลงดิสก์
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบขนาดสไลด์ตรงกัน**

When cloning slides into another presentation, make sure the destination presentation has the same slide size as the source. If the slide sizes differ, Aspose.Slides does not automatically rescale the cloned shapes—their original coordinates and dimensions are preserved, which may cause the content to appear misaligned or extend beyond the slide boundaries.

You can set the destination presentation's slide size to match the source before cloning the master and slide:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Do this before cloning the master and the slide.

## **คำถามที่พบบ่อย**

**บันทึกผู้บรรยายและความคิดเห็นของผู้ตรวจสอบถูกโคลนหรือไม่?**

ใช่. หน้าบันทึกและความคิดเห็นการตรวจสอบจะรวมอยู่ในคลอน หากคุณไม่ต้องการให้มีอยู่ ให้ [ลบออก](/slides/th/androidjava/presentation-notes/) หลังจากแทรก.

**แผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น workbook ที่ฝังด้วย OLE) การเชื่อมต่อนั้นจะถูกเก็บไว้เป็น [วัตถุ OLE](/slides/th/androidjava/manage-ole/). หลังจากย้ายระหว่างไฟล์ ควรตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช.

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของคลอนได้หรือไม่?**

ได้. คุณสามารถแทรกคลอนที่ดัชนีสไลด์เฉพาะและวางลงใน [ส่วน](/slides/th/androidjava/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วจึงย้ายสไลด์เข้าไป.