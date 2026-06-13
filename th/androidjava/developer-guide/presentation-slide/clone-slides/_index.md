---
title: คัดลอกสไลด์การนำเสนอบน Android
linktitle: คัดลอกสไลด์
type: docs
weight: 35
url: /th/androidjava/clone-slides/
keywords:
- คัดลอกสไลด์
- สำเนาสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำสำเนาสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android. ปฏิบัติตามตัวอย่างโค้ด Java ที่ชัดเจนของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาทีและขจัดงานมือ."
---
## **บทนำ**

การทำสำเนา (Cloning) คือกระบวนการสร้างสำเนาที่เหมือนกันหรือสำเนาที่เที่ยงตรงของบางสิ่ง Aspose.Slides for Android via Java ยังทำให้สามารถสร้างสำเนาหรือคัดลอกสไลด์ใด ๆ แล้วแทรกสไลด์ที่คัดลอกนั้นเข้าสู่การนำเสนอที่กำลังเปิดอยู่หรือการนำเสนออื่นที่เปิดอยู่ กระบวนการคัดลอกสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีที่สามารถคัดลอกสไลด์ได้:

- คัดลอกที่ท้ายภายในการนำเสนอ
- คัดลอกที่ตำแหน่งอื่นภายในการนำเสนอ
- คัดลอกที่ท้ายในการนำเสนออื่น
- คัดลอกที่ตำแหน่งอื่นในการนำเสนออื่น
- คัดลอกที่ตำแหน่งเฉพาะในการนำเสนออื่น

ใน Aspose.Slides for Android via Java, (คอลเลกชันของ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlide) objects) ที่เปิดให้เข้าถึงโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) มีเมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) และ [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) เพื่อทำการคัดลอกสไลด์ตามประเภทข้างต้น

## **คัดลอกสไลด์ที่ท้ายของการนำเสนอ**
หากคุณต้องการคัดลอกสไลด์แล้วใช้ภายในไฟล์การนำเสนอเดียวกันที่ตำแหน่งท้ายของสไลด์ที่มีอยู่ ให้ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดให้เข้าถึงโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดให้เข้าถึงโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคัดลอเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. บันทึกไฟล์การนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (ที่อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของการนำเสนอ) ไปยังท้ายของการนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // คัดลอกสไลด์ที่ต้องการไปยังท้ายของคอลเลกชันสไลด์ในการนำเสนอเดียวกัน
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คัดลอกสไลด์ไปยังตำแหน่งอื่นภายในการนำเสนอ**
หากคุณต้องการคัดลอกสไลด์แล้วใช้ภายในไฟล์การนำเสนอเดียวกันแต่ในตำแหน่งอื่น ให้ใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. สร้างอินสแตนซ์ของคลาสโดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดให้เข้าถึงโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) ที่เปิดให้เข้าถึงโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคัดลอกพร้อมกับดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (ที่อยู่ที่ดัชนีศูนย์ – ตำแหน่ง 1 – ของการนำเสนอ) ไปยังดัชนี 1 – ตำแหน่ง 2 – ของการนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // คัดลอกสไลด์ที่ต้องการไปยังท้ายของคอลเลกชันสไลด์ในการนำเสนอเดียวกัน
    ISlideCollection slds = pres.getSlides();

    // คัดลอกสไลด์ที่ต้องการไปยังดัชนีที่ระบุในการนำเสนอเดียวกัน
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คัดลอกสไลด์ที่ท้ายของการนำเสนออื่น**
หากคุณต้องการคัดลอกสไลด์จากการนำเสนอหนึ่งและใช้ในไฟล์การนำเสนออื่นที่ตำแหน่งท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มีการนำเสนอซึ่งสไลด์จะถูกคัดลอกจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มีการนำเสนอปลายทางซึ่งสไลด์จะถูกเพิ่มเข้าไป
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection) โดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดให้เข้าถึงโดยวัตถุ Presentation ของการนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดให้เข้าถึงโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่มเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. บันทึกไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (จากดัชนีแรกของการนำเสนอแหล่งที่มา) ไปยังท้ายของการนำเสนอปลายทาง

```java
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกคัดลอก)
    Presentation destPres = new Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาพไปยังท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
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

## **คัดลอกสไลด์ไปยังตำแหน่งอื่นในการนำเสนออื่น**
หากคุณต้องการคัดลอกสไลด์จากการนำเสนอหนึ่งและใช้ในไฟล์การนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มีการนำเสนอแหล่งที่ซึ่งสไลด์จะถูกคัดลอกจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มีการนำเสนอปลายทางซึ่งสไลด์จะถูกเพิ่มเข้าไป
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ของการนำเสนอปลายทาง
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) ที่เปิดให้เข้าถึงโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่มาพร้อมกับตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)
1. บันทึกไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (จากดัชนีศูนย์ของการนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของการนำเสนอปลายทาง

```java
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกคัดลอก)
    Presentation destPres = new Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาพไปยังท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
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

## **คัดลอกสไลด์ที่ตำแหน่งเฉพาะในการนำเสนออื่น**
หากคุณต้องการคัดลอกสไลด์พร้อมมาสเตอร์สไลด์จากการนำเสนอหนึ่งและใช้ในการนำเสนออื่น คุณต้องคัดลอกมาสเตอร์สไลด์ที่ต้องการจากแหล่งที่มาสู่การนำเสนอปลายทางก่อน แล้วใช้มาสเตอร์สไลด์นั้นเพื่อคัดลอกสไลด์พร้อมมาสเตอร์ เมธอด [**addClone(ISlide,IMasterSlide,boolean)**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) คาดหวังมาสเตอร์สไลด์จากการนำเสนอปลายทาง ไม่ใช่จากแหล่งที่มา เพื่อคัดลอกสไลด์พร้อมมาสเตอร์ กรุณาปฏิบัติตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มีการนำเสนอแหล่งที่ซึ่งสไลด์จะถูกคัดลอกจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มีการนำเสนอปลายทางซึ่งสไลด์จะถูกคัดลอกไป
1. เข้าถึงสไลด์ที่ต้องการคัดลอกพร้อมกับมาสเตอร์สไลด์
1. สร้างอินสแตนซ์ของคลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดให้เข้าถึงโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ของการนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดให้เข้าถึงโดยวัตถุ [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterSlideCollection) และส่งมาสเตอร์จาก PPTX แหล่งที่มาที่ต้องการคัดลอเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) โดยกำหนดอ้างอิงไปยังคอลเลกชัน Slides ของวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ของการนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดให้เข้าถึงโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากการนำเสนอแหล่งที่มาที่ต้องการคัดลอกพร้อมมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. บันทึกไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์พร้อมมาสเตอร์ (ที่อยู่ที่ดัชนีศูนย์ของการนำเสนอแหล่งที่มา) ไปยังท้ายของการนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```java
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับการนำเสนอปลายทาง (ที่สไลด์จะถูกคัดลอก)
    Presentation destPres = new Presentation();
    try {
        // สร้างอินสแตนซ์ของ ISlide จากคอลเลกชันสไลด์ในการนำเสนอแหล่งที่มาพร้อมกับ
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

        // คัดลอกสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังท้ายของ
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

## **คัดลอกสไลด์ที่ท้ายของส่วนที่ระบุ**
หากคุณต้องการคัดลอกสไลด์แล้วใช้ภายในไฟล์การนำเสนอเดียวกันแต่ในส่วนที่ต่างกัน ให้ใช้เมธอด [**addClone**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) ที่เปิดให้เข้าถึงโดยอินเทอร์เฟซ [**ISlideCollection**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection) Aspose.Slides for Android via Java ทำให้สามารถคัดลอกสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่คัดลอกนั้นไปยังส่วนที่สองของการนำเสนอเดียวกัน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีคัดลอกสไลด์และแทรกสไลด์ที่คัดลอกเข้าไปในส่วนที่ระบุ

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

**บันทึกผู้บรรยายและความคิดเห็นของผู้ตรวจสอบจะถูกคัดลอกหรือไม่?**

ใช่. หน้าบันทึกและความคิดเห็นการตรวจสอบจะถูกรวมในสำเนา หากคุณไม่ต้องการให้พวกมันอยู่ ให้ [remove them](/slides/th/androidjava/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของมันจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิลิงก์กับแหล่งข้อมูลภายนอก (เช่น แฟ้มงานที่ฝัง OLE) การเชื่อมโยงนั้นจะคงไว้เป็น [OLE object](/slides/th/androidjava/manage-ole/) หลังจากย้ายระหว่างไฟล์ ควรตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งแทรกและส่วนต่าง ๆ ของสำเนาได้หรือไม่?**

ได้. คุณสามารถแทรกสำเนาที่ดัชนีสไลด์เฉพาะและใส่ลงใน [section](/slides/th/androidjava/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างส่วนนั้นก่อนแล้วค่อยย้ายสไลด์เข้าไป