---
title: คัดลอกสไลด์นำเสนอใน Java
linktitle: คัดลอกสไลด์
type: docs
weight: 35
url: /th/java/clone-slides/
keywords:
- คัดลอกสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "คัดลอกสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for Java. ปฏิบัติตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาทีและขจัดงานที่ต้องทำด้วยมือ."
---
## **บทนำ**

การคัดลอกเป็นกระบวนการสร้างสำเนาแบบสมบูรณ์ของบางอย่าง Aspose.Slides for Java ยังทำให้สามารถสร้างสำเนาหรือคัดลอกสไลด์ใด ๆ แล้วแทรกสไลด์ที่คัดลอกนั้นเข้าสู่การนำเสนอปัจจุบันหรือการนำเสนอที่เปิดอยู่ใด ๆ กระบวนการคัดลอกสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบสไลด์ต้นฉบับ มีวิธีการคัดลอกสไลด์หลายวิธีดังต่อไปนี้:

- คัดลอกจากตำแหน่งสุดท้ายภายในงานนำเสนอ
- คัดลอกไปยังตำแหน่งอื่นภายในงานนำเสนอ
- คัดลอกจากตำแหน่งสุดท้ายในงานนำเสนออื่น
- คัดลอกไปยังตำแหน่งอื่นในงานนำเสนออื่น
- คัดลอกพร้อมกับสไลด์หลักของมันเข้าสู่งานนำเสนออื่น

ใน Aspose.Slides for Java, (a collection of [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) objects) ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) นั้น มีเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) และ [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) เพื่อดำเนินการคัดลอกสไลด์ตามประเภทที่กล่าวข้างต้น

## **คัดลอกสไลด์ไปยังตำแหน่งสุดท้ายของงานนำเสนอ**
หากคุณต้องการคัดลอกสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่แล้ว ให้ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. สร้างอ็อบเจ็กต์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
3. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคัดลอกเป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
4. บันทึกไฟล์งานนำเสนอที่ได้รับการแก้ไข

ในตัวอย่างต่อไปนี้ เราได้คัดลอกสไลด์ (ซึ่งอยู่ในตำแหน่งแรก – ดัชนีศูนย์ – ของงานนำเสนอ) ไปยังตำแหน่งสุดท้ายของงานนำเสนอ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // บันทึกงานนำเสนอที่แก้ไขลงดิสก์
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คัดลอกสไลด์ไปยังตำแหน่งอื่นภายในงานนำเสนอ**
หากคุณต้องการคัดลอกสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันแต่ตำแหน่งต่างออกไป ให้ใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. สร้างอ็อบเจ็กต์โดยอ้างอิงคอลเลกชัน [**Slides**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคัดลอกพร้อมดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้กับเมธอด [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างต่อไปนี้ เราได้คัดลอกสไลด์ (ซึ่งอยู่ในดัชนี 1 – ตำแหน่ง 2 – ของงานนำเสนอ) ไปยังดัชนี 2 – ตำแหน่ง 3 – ของงานนำเสนอ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // รับคอลเลกชันของสไลด์ในงานนำเสนอ
    ISlideCollection slds = pres.getSlides();

    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งที่ระบุในงานนำเสนอเดียวกัน
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // บันทึกงานนำเสนอที่แก้ไขลงดิสก์
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คัดลอกสไลด์ไปยังตำแหน่งสุดท้ายของงานนำเสนออื่น**
หากคุณต้องการคัดลอกสไลด์จากงานนำเสนอหนึ่งและใช้ในไฟล์งานนำเสนออื่นที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นแหล่งที่มาของสไลด์ที่จะคัดลอก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นไฟล์ปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
1. สร้างอ็อบเจ็กต์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection) โดยอ้างอิงคอลเลกชัน [**Slides**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) ที่เปิดโดยอ็อบเจ็กต์ Presentation ของงานนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มเป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. บันทึกไฟล์งานนำเสนอปลายทางที่ได้รับการแก้ไข

ในตัวอย่างต่อไปนี้ เราได้คัดลอกสไลด์ (จากดัชนีแรกของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทาง

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกคัดลอก)
    Presentation destPres = new Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาที่ตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **คัดลอกสไลด์ไปยังตำแหน่งอื่นในงานนำเสนออื่น**
หากคุณต้องการคัดลอกสไลด์จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นแหล่งที่มาของสไลด์ที่จะคัดลอก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นงานนำเสนอปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
1. สร้างอ็อบเจ็กต์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดโดยอ็อบเจ็กต์ Presentation ของงานนำเสนอปลายทาง
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มาพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้กับเมธอด [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)
1. บันทึกไฟล์งานนำเสนอปลายทางที่ได้รับการแก้ไข

ในตัวอย่างต่อไปนี้ เราได้คัดลอกสไลด์ (จากดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของงานนำเสนอปลายทาง

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกคัดลอก)
    Presentation destPres = new Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาที่ตำแหน่งที่ระบุในงานนำเสนอปลายทาง
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **คัดลอกสไลด์พร้อมสไลด์หลักไปยังงานนำเสนออื่น**
หากคุณต้องการคัดลอกสไลด์พร้อมสไลด์หลักจากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น คุณต้องคัดลอกสไลด์หลักที่ต้องการจากงานนำเสนอแหล่งที่มามาไว้ในงานนำเสนอปลายทางก่อน แล้วจึงใช้สไลด์หลักนั้นสำหรับการคัดลอกสไลด์พร้อมสไลด์หลัก เมธอด [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ต้องการสไลด์หลักจากงานนำเสนอปลายทาง ไม่ใช่จากแหล่งที่มา เพื่อคัดลอกสไลด์พร้อมสไลด์หลัก ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นแหล่งที่มาของสไลด์ที่จะคัดลอก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่เป็นงานนำเสนอปลายทางที่สไลด์จะถูกคัดลอกไป
1. เข้าถึงสไลด์ที่จะคัดลอกพร้อมสไลด์หลัก
1. สร้างอ็อบเจ็กต์ของคลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ของงานนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [IMasterSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMasterSlideCollection) และส่ง master จากไฟล์ PPTX แหล่งที่มาที่จะคัดลอกเป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)
1. สร้างอ็อบเจ็กต์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ของงานนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่เปิดโดยอ็อบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่จะคัดลอกพร้อมสไลด์หลักเป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)
1. บันทึกไฟล์งานนำเสนอปลายทางที่ได้รับการแก้ไข

ในตัวอย่างต่อไปนี้ เราได้คัดลอกสไลด์พร้อมสไลด์หลัก (อยู่ในดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทางโดยใช้สไลด์หลักจากสไลด์ต้นฉบับ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกคัดลอก)
    Presentation destPres = new Presentation();
    try {
        // สร้างอ็อบเจ็กต์ ISlide จากคอลเลกชันสไลด์ในงานนำเสนอแหล่งที่มาพร้อม
        // สไลด์หลัก
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // คัดลอกสไลด์หลักที่ต้องการจากงานนำเสนอแหล่งที่มาลงในคอลเลกชันสไลด์หลักของ
        // งานนำเสนอปลายทาง
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาโดยใช้สไลด์หลักที่ต้องการไปยังตำแหน่งสุดท้ายของ
        // คอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **คัดลอกสไลด์ไปยังตำแหน่งสุดท้ายของส่วนที่ระบุ**
หากคุณต้องการคัดลอกสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันแต่ในส่วนต่างออกไป ให้ใช้เมธอด [**addClone**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) ที่เปิดโดยอินเทอร์เฟซ [**ISlideCollection**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection) Aspose.Slides for Java ทำให้สามารถคัดลอกสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่คัดลอกไปยังส่วนที่สองของงานนำเสนอเดียวกันได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีคัดลอกสไลด์และแทรกสไลด์ที่คัดลอกไปยังส่วนที่ระบุ

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // บันทึกงานนำเสนอปลายทางลงดิสก์
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบให้ขนาดสไลด์ตรงกัน**

เมื่อต้องคัดลอกสไลด์ไปยังงานนำเสนออื่น ให้ตรวจสอบให้แน่ใจว่าขนาดสไลด์ของงานนำหน้าเป้าหมายตรงกับงานนำแหล่งที่มา หากขนาดสไลด์แตกต่างกัน Aspose.Slides จะไม่ปรับสเกลวัตถุที่คัดลอกโดยอัตโนมัติ – พิกัดและขนาดเดิมจะคงไว้ซึ่งอาจทำให้เนื้อหาแสดงไม่ตรงหรือติดออกนอกขอบสไลด์

คุณสามารถตั้งค่าขนาดสไลด์ของงานนำเสนอปลายทางให้ตรงกับแหล่งที่มีก่อนทำการคัดลอกสไลด์และมาสเตอร์ได้:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

ทำเช่นนี้ก่อนทำการคัดลอกมาสเตอร์และสไลด์

## **FAQ**

**บันทึกเสียงประกอบและความคิดเห็นของรีวิวจะถูกคัดลอกหรือไม่?**

ใช่ หน้าบันทึกและความคิดเห็นของรีวิวจะรวมอยู่ในสำเนา หากคุณไม่ต้องการ ให้ [remove them](/slides/th/java/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของแผนภูมิจะถูกจัดการอย่างไร?**

ออบเจ็กต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังจะถูกคัดลอก หากแผนภูมิเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น ไฟล์เวิร์กบุ๊กที่ฝังในรูปแบบ OLE) การเชื่อมโยงนั้นจะยังคงอยู่เป็น [OLE object](/slides/th/java/manage-ole/) หลังจากย้ายไฟล์ ตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของสำเนาได้หรือไม่?**

ใช่ คุณสามารถแทรกสำเนาที่ตำแหน่งดัชนีสไลด์เฉพาะและวางไว้ใน [section](/slides/th/java/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วจึงย้ายสไลด์เข้าไปในส่วนนั้น