---
title: โคลนสไลด์การนำเสนอใน .NET
linktitle: โคลนสไลด์
type: docs
weight: 40
url: /th/net/clone-slides/
keywords:
- โคลนสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำซ้ำสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ .NET. ทำตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่ออัตโนมัติกระบวนการสร้าง PPT ภายในไม่กี่วินาทีและขจัดการทำงานด้วยตนเอง."
---
## **บทนำ**

การโคลนคือกระบวนการทำสำเนาที่ตรงกันหรือสำเนาเหมือนของบางอย่าง Aspose.Slides ยังอนุญาตให้คุณคัดลอก (โคลน) สไลด์ใด ๆ แล้วแทรกสไลด์ที่ถูกโคลนเข้าไปในงานนำเสนอปัจจุบันหรือในงานนำเสนอที่เปิดอยู่อื่น ๆ การโคลนสไลด์สร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีในการโคลนสไลด์:

- โคลนที่ส่วนท้ายของงานนำเสนอ
- โคลนที่ตำแหน่งอื่นภายในงานนำเสนอ
- โคลนที่ส่วนท้ายของงานนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในงานนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในงานนำเสนออื่น

In Aspose.Slides for .NET คอลเลกชันสไลด์ (คอลเลกชันของวัตถุ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) ) ที่เปิดให้เข้าถึงโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) และ [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/insertclone/) เพื่อทำการโคลนสไลด์ตามที่อธิบายข้างต้น.

## **โคลนสไลด์ที่ส่วนท้ายของงานนำเสนอ**

หากคุณต้องการโคลนสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันที่ส่วนท้ายของสไลด์ที่มีอยู่ ให้ใช้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
3. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์ที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index)
4. บันทึกไฟล์งานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้ทำการโคลนสไลด์ (อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของงานนำเสนอ) ไปยังส่วนท้ายของงานนำเสนอ

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // โคลนสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นภายในงานนำเสนอ**

หากคุณต้องการโคลนสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันแต่ในตำแหน่งอื่น ให้ใช้เมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. สร้างอินสแตนซ์ของคลาสโดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
3. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1) ที่เปิดโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์ที่ต้องการโคลนพร้อมด้วยดัชนีของตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1)
4. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ทำการโคลนสไลด์ (อยู่ที่ดัชนีศูนย์ – ตำแหน่ง 1 – ของงานนำเสนอ) ไปยังดัชนี 1 – ตำแหน่ง 2 – ของงานนำเสนอ

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // โคลนสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเดียวกัน
    ISlideCollection slds = pres.Slides;

    // โคลนสไลด์ที่ต้องการไปยังดัชนีที่ระบุในงานนำเสนอเดียวกัน
    slds.InsertClone(2, pres.Slides[1]);

    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **โคลนสไลด์ที่ส่วนท้ายของงานนำเสนออื่น**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอซึ่งสไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอปลายทางซึ่งสไลด์จะถูกเพิ่มเข้าไป
3. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดโดยวัตถุ Presentation ของงานนำเสนอปลายทาง
4. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index)
5. บันทึกไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้ทำการโคลนสไลด์ (จากดัชนีแรกของงานนำเสนอแหล่งที่มา) ไปยังส่วนท้ายของงานนำเสนอปลายทาง

```c#
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    using (Presentation destPres = new Presentation())
    {
        // โคลนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาถึงส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นในงานนำเสนออื่น**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอแหล่งที่สไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอปลายทางซึ่งสไลด์จะถูกเพิ่มเข้าไป
3. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดโดยวัตถุ Presentation ของงานนำเสนอปลายทาง
4. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1) ที่เปิดโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์จากงานนำเสนอแหล่งที่มาพร้อมกับตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/insertclone/methods/1)
5. บันทึกไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้ทำการโคลนสไลด์ (จากดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของงานนำเสนอปลายทาง

```c#
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **โคลนสไลด์ที่ตำแหน่งเฉพาะในงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์พร้อมมาสเตอร์สไลด์จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น คุณต้องโคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มามาไปยังงานนำเสนอปลายทางก่อน แล้วจึงใช้มาสเตอร์สไลด์นั้นสำหรับโคลนสไลด์ที่มีมาสเตอร์สไลด์ เมธอด **AddClone(ISlide, IMasterSlide)** ต้องการมาสเตอร์สไลด์จากงานนำเสนอปลายทาง ไม่ใช่จากงานนำเสนอแหล่งที่มา เพื่อโคลนสไลด์พร้อมมาสเตอร์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอแหล่งที่สไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีงานนำเสนอปลายทางที่สไลด์จะถูกโคลนไป
3. เข้าถึงสไลด์ที่ต้องการโคลนพร้อมกับมาสเตอร์สไลด์
4. สร้างอินสแตนซ์ของคลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection)โดยอ้างอิงคอลเลกชัน Masters ที่เปิดโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ของงานนำเสนอปลายทาง
5. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดโดยวัตถุ [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection) และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่มาที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index)
6. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) โดยตั้งค่าการอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ของงานนำเสนอปลายทาง
7. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) ที่เปิดโดยวัตถุ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่ต้องการโคลนพร้อมกับมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index)
8. บันทึกไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้ทำการโคลนสไลด์ที่มีมาสเตอร์ (อยู่ที่ดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```c#
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกโคลน)
    using (Presentation destPres = new Presentation())
    {

        // สร้างอินสแตนซ์ของ ISlide จากคอลเลกชันสไลด์ในงานนำเสนอแหล่งที่มาพร้อมกับ
        // มาสเตอร์สไลด์
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาลงในคอลเลกชันมาสเตอร์ใน
        // งานนำเสนอปลายทาง
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาลงในคอลเลกชันมาสเตอร์ใน
        // งานนำเสนอปลายทาง
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังส่วนท้ายของ
        // คอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาลงในคอลเลกชันมาสเตอร์ใน // งานนำเสนอปลายทาง
        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **โคลนสไลด์ที่ส่วนท้ายของส่วนที่ระบุ**

ด้วย Aspose.Slides for .NET คุณสามารถโคลนสไลด์จากส่วนหนึ่งของงานนำเสนอและแทรกสไลด์นั้นลงในส่วนอื่นในงานนำเสนอเดียวกัน ในกรณีนี้คุณต้องใช้เมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/methods/addclone/index) จากอินเทอร์เฟซ [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection)

โค้ด C# นี้แสดงวิธีการโคลนสไลด์และแทรกสไลด์ที่โคลนลงในส่วนที่ระบุ:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // เพื่อโคลน
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**บันทึกผู้บรรยายและความคิดเห็นของผู้ตรวจสอบจะถูกโคลนหรือไม่?**

ใช่ หน้าโน๊ตและความคิดเห็นการตรวจสอบจะถูกรวมอยู่ในคลอน หากคุณไม่ต้องการให้มันอยู่ ให้[ลบออก](/slides/th/net/presentation-notes/) หลังจากการแทรก.

**กราฟและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**

วัตถุกราฟ, การจัดรูปแบบ และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากกราฟเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น เวิร์กบุ๊กที่ฝังใน OLE) การเชื่อมโยงนั้นจะถูกรักษาเป็น[วัตถุ OLE](/slides/th/net/manage-ole/). หลังจากย้ายไฟล์ระหว่างกัน ควรตรวจสอบว่าข้อมูลยังพร้อมใช้งานและพฤติกรรมการรีเฟรช.

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของคลอนได้หรือไม่?**

ใช่ คุณสามารถแทรกคลอนที่ดัชนีสไลด์ที่ระบุและใส่ลงใน[ส่วน](/slides/th/net/slide-section/) ที่เลือกได้ หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างส่วนนั้นก่อนแล้วจึงย้ายสไลด์ไปยังส่วนนั้น.