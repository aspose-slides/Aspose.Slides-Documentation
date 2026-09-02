---
title: คัดลอกสไลด์การนำเสนอใน .NET
linktitle: คัดลอกสไลด์
type: docs
weight: 40
url: /th/net/clone-slides/
keywords:
- คัดลอกสไลด์
- ทำสำเนาสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำซ้ำสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ .NET. ปฏิบัติตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่ออัตโนมัติกระบวนการสร้าง PPT ในไม่กี่วินาทีและขจัดการทำงานด้วยมือ."
---
## **บทนำ**

การทำสำเนา (คลอน) คือกระบวนการทำสำเนาที่ตรงกันหรือทำซ้ำของบางอย่าง Aspose.Slides ยังอนุญาตให้คุณคัดลอก (คลอน) สไลด์ใด ๆ แล้วแทรกสไลด์ที่ถูกคลอนเข้าไปในงานนำเสนอปัจจุบันหรือในงานนำเสนออื่นที่เปิดอยู่ การคลอนสไลด์สร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขโดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีในการคลอนสไลด์:

- คลอนที่ส่วนท้ายของงานนำเสนอ
- คลอนที่ตำแหน่งอื่นภายในงานนำเสนอ
- คลอนที่ส่วนท้ายของงานนำเสนออื่น
- คลอนที่ตำแหน่งอื่นในงานนำเสนออื่น
- คลอนพร้อมกับสไลด์มาสเตอร์ของมันไปยังงานนำเสนออื่น

ใน Aspose.Slides for .NET, คอลเลกชันสไลด์ (คอลเลกชันของ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) objects) ที่เปิดให้บริการโดยออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) และ [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/insertclone/) เพื่อดำเนินการคลอนสไลด์ตามที่อธิบายข้างต้น

## **คลอนสไลด์ที่ส่วนท้ายของงานนำเสนอ**

หากคุณต้องการคลอนสไลด์แล้วใช้มันในไฟล์งานนำเสนอเดียวกันที่ส่วนท้ายของสไลด์ที่มีอยู่แล้ว ใช้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดให้บริการโดยออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดให้บริการโดยออบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์ที่ต้องการคลอนเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) 
1. บันทึกไฟล์งานนำเสนอที่ปรับปรุงแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของงานนำเสนอ) ไปยังส่วนท้ายของงานนำเสนอ

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // คัดลอกสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // เขียนงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **คลอนสไลด์ไปยังตำแหน่งอื่นภายในงานนำเสนอ**

หากคุณต้องการคลอนสไลด์แล้วใช้มันในไฟล์งานนำเสนอเดียวกันแต่ที่ตำแหน่งอื่น ใช้เมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
1. สร้างอินสแตนซ์โดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดให้บริการโดยออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
1. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1) ที่เปิดให้บริการโดยออบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์ที่ต้องการคลอนพร้อมกับดัชนีของตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1) 
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (อยู่ที่ดัชนี 1 – ตำแหน่ง 2 – ของงานนำเสนอ) ไปยังดัชนี 2 – ตำแหน่ง 3 – ของงานนำเสนอ

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // คัดลอกสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    ISlideCollection slds = pres.Slides;

    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งที่ระบุในงานนำเสนอเดียวกัน
    slds.InsertClone(2, pres.Slides[1]);

    // เขียนงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **คลอนสไลด์ที่ส่วนท้ายของงานนำเสนออื่น**

หากคุณต้องการคลอนสไลด์จากงานนำเสนอหนึ่งแล้วใช้ในไฟล์งานนำเสนออื่นที่ส่วนท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอซึ่งสไลด์จะถูกคลอนไปจากนั้น 
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอปลายทางที่จะเพิ่มสไลด์เข้าไป 
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดให้บริการโดยออบเจ็กต์ Presentation ของงานนำเสนอปลายทาง 
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดให้บริการโดยออบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์จากงานนำเสนอแหล่งที่มเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) 
1. บันทึกไฟล์งานนำเสนอปลายทางที่ปรับปรุงแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (จากดัชนีแรกของงานนำเสนอแหล่งที่มา) ไปยังส่วนท้ายของงานนำเสนอปลายทาง

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกคลอน)
    using (Presentation destPres = new Presentation())
    {
        // คลอนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // เขียนงานนำเสนอปลายทางลงดิสก์
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **คลอนสไลด์ไปยังตำแหน่งอื่นในงานนำเสนออื่น**

หากคุณต้องการคลอนสไลด์จากงานนำเสนอหนึ่งแล้วใช้ในงานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอแหล่งที่มาที่สไลด์จะถูกคลอนไปจากนั้น 
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอที่จะเพิ่มสไลด์เข้าไป 
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดให้บริการโดยออบเจ็กต์ Presentation ของงานนำเสนอปลายทาง 
1. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1) ที่เปิดให้บริการโดยออบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์จากงานนำเสนอแหล่งที่มาพร้อมกับตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1) 
1. บันทึกไฟล์งานนำเสนอปลายทางที่ปรับปรุงแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์ (จากดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของงานนำเสนอปลายทาง

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกคลอน)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // เขียนงานนำเสนอปลายทางลงดิสก์
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **คลอนสไลด์พร้อมสไลด์มาสเตอร์ไปยังงานนำเสนออื่น**

หากคุณต้องการคลอนสไลด์พร้อมสไลด์มาสเตอร์จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น คุณต้องคลอนสไลด์มาสเตอร์ที่ต้องการจากงานนำเสนอแหล่งที่มาลงในงานนำเสนอปลายทางก่อน แล้วจึงใช้สไลด์มาสเตอร์นั้นในการคลอนสไลด์พร้อมมาสเตอร์ เมธอด **AddClone(ISlide, IMasterSlide)** คาดหวังสไลด์มาสเตอร์จากงานนำเสนอปลายทางไม่ใช่จากแหล่งที่มา เพื่อคลอนสไลด์พร้อมมาสเตอร์ กรุณาทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอแหล่งที่มาที่สไลด์จะถูกคลอนไปจากนั้น 
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอปลายทางที่สไลด์จะถูกคลอนไป 
1. เข้าถึงสไลด์ที่ต้องการคลอนพร้อมกับสไลด์มาสเตอร์ 
1. สร้างอินสแตนซ์ของคลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดให้บริการโดยออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ของงานนำเสนอปลายทาง 
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดให้บริการโดยออบเจ็กต์ [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection) และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่มาที่ต้องการคลอนเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) 
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยตั้งค่าการอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดให้บริการโดยออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ของงานนำเสนอปลายทาง 
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดให้บริการโดยออบเจ็กต์ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่ต้องการคลอนพร้อมกับสไลด์มาสเตอร์เป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) 
1. บันทึกไฟล์งานนำเสนอปลายทางที่ปรับปรุงแล้ว

ในตัวอย่างด้านล่าง เราได้คลอนสไลด์พร้อมมาสเตอร์ (อยู่ที่ดัชนีศูนย์ของงานนำเสนอแหล่งที่ม) ไปยังส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกคลอน)
    using (Presentation destPres = new Presentation())
    {

        // สร้างอินสแตนซ์ของ ISlide จากคอลเลกชันสไลด์ในงานนำเสนอแหล่งที่มากับ
        // สไลด์มาสเตอร์
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // คลอนสไลด์มาสเตอร์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังคอลเลกชันมาสเตอร์ใน
        // งานนำเสนอปลายทาง
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // คลอนสไลด์มาสเตอร์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังคอลเลกชันมาสเตอร์ใน
        // งานนำเสนอปลายทาง
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // คลอนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังส่วนท้ายของ
        // คอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // คลอนสไลด์มาสเตอร์ที่ต้องการจากงานนำเสนอแหล่งที่มไปยังคอลเลกชันมาสเตอร์ใน // งานนำเสนอปลายทาง
        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **คลอนสไลด์ที่ส่วนท้ายของส่วนที่กำหนด**

ด้วย Aspose.Slides for .NET คุณสามารถคลอนสไลด์จากส่วนหนึ่งของงานนำเสนอแล้วแทรกสไลด์นั้นเข้าไปในส่วนอื่นของงานนำเสนอเดียวกัน ในกรณีนี้ต้องใช้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) จากอินเทอร์เฟซ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection)

โค้ด C# นี้แสดงวิธีคลอนสไลด์และแทรกสไลด์ที่คลอนไปยังส่วนที่กำหนด:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // เพื่อคลอน
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **ตรวจสอบขนาดสไลด์ที่ตรงกัน**

เมื่อคลอนสไลด์ไปยังงานนำเสนออื่น ให้แน่ใจว่าขนาดสไลด์ของงานนำเสนอปลายทางเท่ากับงานนำเสนอแหล่งที่มา หากขนาดสไลด์ต่างกัน Aspose.Slides จะไม่ปรับสเกลรูปร่างที่ถูกคลอนโดยอัตโนมัติ—พิกัดและมิติเดิมจะยังคงอยู่ ซึ่งอาจทำให้เนื้อหาแสดงไม่ตรงตำแหน่งหรือเกินขอบสไลด์

คุณสามารถตั้งค่าขนาดสไลด์ของงานนำเสนอปลายทางให้ตรงกับแหล่งที่มาก่อนการคลอนมาสเตอร์และสไลด์:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

ทำเช่นนี้ก่อนการคลอนมาสเตอร์และสไลด์

## **FAQ**

**บันทึกผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกคลอนหรือไม่?**

ใช่. หน้าโน๊ตและความคิดเห็นการตรวจสอบจะถูกรวมอยู่ในคลอน หากคุณไม่ต้องการให้มันอยู่, [ลบออก](/slides/th/net/presentation-notes/) หลังจากแทรก

**ข้อมูลกราฟและแหล่งข้อมูลของมันจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิมีการเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น สมุดงานที่ฝัง OLE) การเชื่อมโยงนั้นจะคงไว้เป็น [OLE object](/slides/th/net/manage-ole/). หลังการย้ายไฟล์ระหว่างงานนำเสนอ ควรตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนต่างๆ ของคลอนได้หรือไม่?**

ใช่. คุณสามารถแทรกคลอนที่ดัชนีสไลด์เฉพาะและใส่ลงใน [section](/slides/th/net/slide-section/) ที่เลือกไว้ หากส่วนปลายทางไม่มีอยู่ ให้สร้างส่วนนั้นก่อนแล้วจึงย้ายสไลด์ไปยังส่วนนั้น