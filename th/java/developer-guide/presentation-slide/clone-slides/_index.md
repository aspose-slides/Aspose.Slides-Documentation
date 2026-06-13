---
title: "คัดลอกสไลด์การนำเสนอใน Java"
linktitle: "คัดลอกสไลด์"
type: docs
weight: 35
url: /th/java/clone-slides/
keywords:
- "คัดลอกสไลด์"
- "ทำสำเนาสไลด์"
- "บันทึกสไลด์"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "ทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Java. ปฏิบัติตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาทีและลบงานที่ต้องทำด้วยมือออก."
---
## **บทนำ**

การทำสำเนา (Cloning) คือกระบวนการสร้างสำเนาที่ตรงกันหรือเลียนแบบของบางอย่าง Aspose.Slides for Java ยังทำให้สามารถสร้างสำเนาหรือคลอนของสไลด์ใดก็ได้และจากนั้นแทรกสไลด์ที่คลอนไว้ไปยังการนำเสนอปัจจุบันหรือการนำเสนออื่นที่เปิดอยู่ กระบวนการคลอนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่ทำให้สไลด์ต้นฉบับเปลี่ยนแปลง มีหลายวิธีที่เป็นไปได้ในการคลอนสไลด์:

- คลอนที่ส่วนท้ายภายในการนำเสนอ
- คลอนที่ตำแหน่งอื่นภายในการนำเสนอ
- คลอนที่ส่วนท้ายในการนำเสนออื่น
- คลอนที่ตำแหน่งอื่นในการนำเสนออื่น
- คลอนที่ตำแหน่งเฉพาะในการนำเสนออื่น

ใน Aspose.Slides for Java (คอลเลกชันของอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide)) ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) จะให้วิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) และ [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) เพื่อดำเนินการคลอนสไลด์ตามประเภทที่กล่าวข้างต้น

## **คลอนสไลด์ที่ส่วนท้ายของการนำเสนอ**
หากคุณต้องการคลอนสไลด์แล้วใช้ในไฟล์การนำเสนอเดียวกันที่ส่วนท้ายของสไลด์ที่มีอยู่แล้ว ให้ใช้วิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เรียกใช้คลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เรียกวิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคลอนเป็นพารามิเตอร์ให้กับวิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. เขียนไฟล์การนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (ซึ่งอยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของการนำเสนอ) ไปยังส่วนท้ายของการนำเสนอ

```java
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // คลอนสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในการนำเสนอเดียวกัน
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คลอนสไลด์ไปยังตำแหน่งอื่นภายในการนำเสนอ**
หากคุณต้องการคลอนสไลด์แล้วใช้ในไฟล์การนำเสนอเดียวกันแต่ที่ตำแหน่งต่างออกไป ให้ใช้วิธีการ [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เรียกใช้คลาสโดยอ้างอิงคอลเลกชัน [**Slides**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เรียกวิธีการ [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคลอนพร้อมกับดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้กับวิธีการ [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)
1. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (ซึ่งอยู่ที่ดัชนีศูนย์ – ตำแหน่ง 1 – ของการนำเสนอ) ไปที่ดัชนี 1 – ตำแหน่ง 2 – ของการนำเสนอ

```java
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // คลอนสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในการนำเสนอเดียวกัน
    ISlideCollection slds = pres.getSlides();

    // คลอนสไลด์ที่ต้องการไปยังดัชนีที่กำหนดในการนำเสนอเดียวกัน
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คลอนสไลด์ที่ส่วนท้ายของการนำเสนออื่น**
หากคุณต้องการคลอนสไลด์จากการนำเสนอหนึ่งแล้วใช้ในไฟล์การนำเสนออีกไฟล์หนึ่งที่ส่วนท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่มีการนำเสนอซึ่งสไลด์จะถูกคลอนจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นการนำเสนอปลายทางซึ่งสไลด์จะถูกเพิ่มเข้าไป
1. เรียกใช้คลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection) โดยอ้างอิงคอลเลกชัน [**Slides**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) ที่เปิดโดยอ็อบเจ็กต์ Presentation ของการนำเสนอปลายทาง
1. เรียกวิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่มเป็นพารามิเตอร์ให้กับวิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (จากดัชนีแรกของการนำเสนอแหล่งที่มา) ไปยังส่วนท้ายของการนำเสนอปลายทาง

```java
// สร้างอ็อบเจ็กต์ Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอ็อบเจ็กต์ Presentation สำหรับไฟล์ PPTX ปลายทาง (ซึ่งสไลด์จะถูกคลอน)
    Presentation destPres = new Presentation();
    try {
        // คลอนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาถึงส่วนท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
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

## **คลอนสไลด์ไปยังตำแหน่งอื่นในการนำเสนออื่น**
หากคุณต้องการคลอนสไลด์จากการนำเสนอหนึ่งและใช้ในการนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่มีการนำเสนอแหล่งที่มาซึ่งสไลด์จะถูกคลอนจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นการนำเสนอที่สไลด์จะถูกเพิ่มเข้าไป
1. เรียกใช้คลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดโดยอ็อบเจ็กต์ Presentation ของการนำเสนอปลายทาง
1. เรียกวิธีการ [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่มาพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้กับวิธีการ [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (จากดัชนีศูนย์ของการนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของการนำเสนอปลายทาง

```java
// สร้างอ็อบเจ็กต์ Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอ็อบเจ็กต์ Presentation สำหรับไฟล์ PPTX ปลายทาง (ซึ่งสไลด์จะถูกคลอน)
    Presentation destPres = new Presentation();
    try {
        // คลอนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาถึงส่วนท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // บันทึกการนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **คลอนสไลด์ที่ตำแหน่งเฉพาะในการนำเสนออื่น**
หากคุณต้องการคลอนสไลด์พร้อมมาสเตอร์สไลด์จากการนำเสนอหนึ่งและใช้ในการนำเสนออื่น คุณต้องคลอนมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งที่มายังการนำเสนอปลายทางก่อน แล้วจึงใช้มาสเตอร์สไลด์นั้นเพื่อคลอนสไลด์พร้อมมาสเตอร์สไลด์วิธีการ [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) คาดว่ามาสเตอร์สไลด์จะมาจากการนำเสนอปลายทาง ไม่ใช่จากแหล่งที่มา เพื่อตรวจสอบขั้นตอนต่อไป:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่มีการนำเสนอแหล่งที่มาซึ่งสไลด์จะถูกคลอนจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นการนำเสนอปลายทางซึ่งสไลด์จะถูกคลอนไปยังนั้น
1. เข้าถึงสไลด์ที่ต้องการคลอนพร้อมกับมาสเตอร์สไลด์
1. เรียกใช้คลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ของการนำเสนอปลายทาง
1. เรียกวิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [IMasterSlideCollection] และส่งมาสเตอร์จาก PPTX แหล่งที่มาที่จะคลอนเป็นพารามิเตอร์ให้กับวิธีการ [addClone]
1. เรียกใช้คลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) โดยตั้งค่าอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ของการนำเสนอปลายทาง
1. เรียกวิธีการ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection] และส่งสไลด์จากการนำเสนอแหล่งที่มาไปคลอนพร้อมมาสเตอร์สไลด์เป็นพารามิเตอร์ให้กับวิธีการ [addClone]
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์พร้อมมาสเตอร์ (ซึ่งอยู่ที่ดัชนีศูนย์ของการนำเสนอแหล่งที่มา) ไปยังส่วนท้ายของการนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```java
// สร้างอ็อบเจ็กต์ Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // สร้างอ็อบเจ็กต์ Presentation สำหรับการนำเสนอปลายทาง (ซึ่งสไลด์จะถูกคลอน)
    Presentation destPres = new Presentation();
    try {
        // สร้างอ็อบเจ็กต์ ISlide จากคอลเลกชันสไลด์ในการนำเสนอแหล่งที่มาพร้อมกับ
        // มาสเตอร์สไลด์
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาสู่คอลเลกชันมาสเตอร์ใน
        // การนำเสนอปลายทาง
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาสู่คอลเลกชันมาสเตอร์ใน
        // การนำเสนอปลายทาง
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // คัดลอกสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังส่วนท้ายของ
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

## **คลอนสไลด์ที่ส่วนท้ายของส่วนที่กำหนด**
หากคุณต้องการคลอนสไลด์แล้วใช้ในไฟล์การนำเสนอเดียวกันแต่ที่ส่วนต่างกัน ให้ใช้วิธีการ [**addClone**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) ที่เปิดโดยอินเทอร์เฟซ [**ISlideCollection**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection) Aspose.Slides for Java ทำให้สามารถคลอนสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่คลอนไปยังส่วนที่สองของการนำเสนอเดียวกันได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีคลอนสไลด์และแทรกสไลด์ที่คลอนไปยังส่วนที่กำหนด

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// บันทึกการนำเสนอปลายทางลงดิสก์
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**บันทึกผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกคลอนไหม?**

ใช่ หน้าโน้ตและความคิดเห็นการตรวจสอบจะรวมอยู่ในคลอน หากคุณไม่ต้องการให้มีอยู่ ให้[ลบออก](/slides/th/java/presentation-notes/)หลังจากแทรก

**กราฟและแหล่งข้อมูลของมันจะจัดการอย่างไร?**

อ็อบเจ็กต์กราฟ, การจัดรูปแบบและข้อมูลที่ฝังอยู่จะถูกคัดลอก หากกราฟเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่นเวิร์กบุ๊กที่ฝัง OLE) การเชื่อมโยงนั้นจะคงอยู่เป็น[อ็อบเจ็กต์ OLE](/slides/th/java/manage-ole/) หลังจากย้ายไฟล์ตรวจสอบความพร้อมใช้งานของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของคลอนได้หรือไม่?**

ได้ คุณสามารถแทรกคลอนที่ดัชนีสไลด์เฉพาะและวางลงใน[ส่วน](/slides/th/java/slide-section/)ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วย้ายสไลด์เข้าไปในส่วนนั้น