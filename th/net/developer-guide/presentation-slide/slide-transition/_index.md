---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอใน .NET
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 90
url: /th/net/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยนแบบ Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides for .NET พร้อมคำแนะนำทีละขั้นตอนสำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการการเปลี่ยนสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีใช้ประเภทการเปลี่ยนสไลด์บนสไลด์, กำหนดค่าพฤติกรรมการเปลี่ยนเช่น การก้าวต่อไปเมื่อคลิกหรือหลังจากเวลาที่กำหนด, ตรวจสอบและปิดการก้าวอัตโนมัติ, ใช้การเปลี่ยนแบบ Morph และประเภทต่างๆ, และตั้งค่าตัวเลือกเอฟเฟกต์การเปลี่ยน ตัวอย่างจะแสดงวิธีโหลดหรือสร้างงานนำเสนอ, แก้ไขการตั้งค่าการเปลี่ยนสำหรับสไลด์ที่เลือก, และบันทึกผลเป็นไฟล์ PPTX บทความยังตอบคำถามทั่วไปเกี่ยวกับความเร็วของการเปลี่ยน, เสียงการเปลี่ยน, การใช้การเปลี่ยนเดียวกันกับหลายสไลด์, และการตรวจสอบการเปลี่ยนที่ตั้งอยู่ในสไลด์ปัจจุบัน

## **เพิ่มการเปลี่ยนสไลด์**
เพื่ออธิบายให้เข้าใจง่าย เราได้สาธิตการใช้ Aspose.Slides for .NET เพื่อจัดการการเปลี่ยนสไลด์แบบง่าย นักพัฒนาสามารถไม่เพียงแค่ใช้เอฟเฟกต์การเปลี่ยนสไลด์ต่างๆ บนสไลด์เท่านั้น แต่ยังปรับแต่งพฤติกรรมของเอฟเฟกต์เหล่านั้นได้ เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์แบบง่าย ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for .NET มีให้ผ่าน enum TransitionType
3. เขียนไฟล์งานนำเสนอที่ถูกแก้ไข

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอต้นฉบับ
 using (Presentation presentation = new Presentation("AccessSlides.pptx"))
 {
     // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
     presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

     // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
     presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

     // บันทึกงานนำเสนอลงดิสก์
     presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนก่อนหน้า เราได้ใช้เอฟเฟกต์การเปลี่ยนแบบง่ายบนสไลด์แล้ว ตอนนี้เพื่อทำให้เอฟเฟกต์การเปลี่ยนนั้นดีขึ้นและควบคุมได้ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for .NET มีให้
3. คุณยังสามารถตั้งค่าการเปลี่ยนให้เป็น Advance On Click, หลังจากระยะเวลาที่กำหนด หรือทั้งสองอย่าง
4. หากการเปลี่ยนสไลด์เปิดใช้งาน Advance On Click การเปลี่ยนจะทำงานก็ต่อเมื่อลูกคลิกเมาส์ นอกจากนี้ หากตั้งค่า Advance After Time ไว้ การเปลี่ยนจะทำอัตโนมัติหลังจากเวลาที่กำหนดผ่านไป
5. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์งานนำเสนอ

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
 using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
 {

     // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
     pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


     // ตั้งค่าเวลาการเปลี่ยนเป็น 3 วินาที
     pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

     // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
     pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


     // ตั้งค่าเวลาการเปลี่ยนเป็น 5 วินาที
     pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

     // ใช้การเปลี่ยนแบบซูมบนสไลด์ที่ 3
     pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


     // ตั้งค่าเวลาการเปลี่ยนเป็น 7 วินาที
     pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

     // บันทึกงานนำเสนอลงดิสก์
     pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```

นอกจากนี้โดยใช้คุณสมบัติ[AdvanceAfter](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/advanceafter/) คุณสามารถตรวจสอบได้ว่าการเปลี่ยนสไลด์ได้ถูกกำหนดให้ย้ายไปสไลด์ถัดไปหรือถูกปิดการตั้งค่านั้นหรือไม่

โค้ด C# นี้สาธิตการทำงาน:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // รับการเปลี่ยนสไลด์
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // ตรวจสอบว่าการตั้งค่า Advance After Time ถูกเปิดใช้งานหรือไม่
        if (slideTransition.AdvanceAfter)
        {
            // พิมพ์ค่าของ Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // ปิดการทำงานของการเปลี่ยนหลังจากเวลาที่กำหนดหากค่าของ AdvancedAfterTime มากกว่า 2 วินาที
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **การเปลี่ยนแบบ Morph**
Aspose.Slides for .NET ตอนนี้สนับสนุน[Morph Transition](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/imorphtransition) ซึ่งเป็นการเปลี่ยนแบบ Morph ใหม่ที่นำเข้ามาใน PowerPoint 2019 การเปลี่ยนแบบ Morph ช่วยให้คุณสร้างการเคลื่อนไหวราบรื่นจากสไลด์หนึ่งไปยังสไลด์ต่อไป บทความนี้อธิบายแนวคิดและวิธีใช้การเปลี่ยนแบบ Morph เพื่อใช้การเปลี่ยนแบบ Morph อย่างมีประสิทธิภาพ คุณจะต้องมีสไลด์สองสไลด์ที่มีออบเจกต์อย่างน้อยหนึ่งออบเจกต์ที่เหมือนกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์แล้วย้ายออบเจกต์บนสไลด์ที่สองไปยังตำแหน่งที่ต่างออกไป

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มสำเนาสไลด์ที่มีข้อความบางส่วนไปยังงานนำเสนอและตั้งค่าการเปลี่ยนเป็น[morph type](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/imorphtransition/properties/morphtype)บนสไลด์ที่สอง

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **ประเภทการเปลี่ยนแบบ Morph**
ได้เพิ่ม enum[Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionmorphtype) ใหม่ ซึ่งแสดงประเภทต่างๆ ของการเปลี่ยนสไลด์แบบ Morph

Enum TransitionMorphType มีสมาชิกสามตัว:

- ByObject: การเปลี่ยน Morph จะดำเนินการโดยพิจารณา shapes เป็นออบเจกต์ที่ไม่แยกย่อย
- ByWord: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความตามคำเมื่อเป็นไปได้
- ByChar: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความตามอักขระเมื่อเป็นไปได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าการเปลี่ยน Morph ให้กับสไลด์และเปลี่ยนประเภท Morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**
Aspose.Slides for .NET รองรับการตั้งค่าเอฟเฟกต์การเปลี่ยน เช่น from black, from left, from right เป็นต้น เพื่อกำหนดเอฟเฟกต์การเปลี่ยน โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
- รับอ้างอิงของสไลด์
- ตั้งค่าเอฟเฟกต์การเปลี่ยน
- เขียนงานนำเสนอเป็นไฟล์[PPTX](https://docs.fileformat.com/presentation/pptx/)

ในตัวอย่างด้านล่าง เราได้ตั้งค่าเอฟเฟกต์การเปลี่ยนแล้ว

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// ตั้งค่าเอฟเฟกต์
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// บันทึกงานนำเสนอลงดิสก์
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. ตั้งค่า[Speed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/speed/) ของการเปลี่ยนโดยใช้การตั้งค่า[TransitionSpeed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionspeed/) (เช่น slow/medium/fast)

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ใช่. คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่า เช่น [Sound](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/soundloop/), พร้อมเมตาดาต้าเช่น [SoundIsBuiltIn](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) และ [SoundName](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/soundname/)

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

กำหนดประเภทการเปลี่ยนที่ต้องการในการตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนจะถูกเก็บแยกตามสไลด์ ดังนั้นการใช้ประเภทเดียวกันกับทุกสไลด์จะให้ผลลัพธ์ที่สอดคล้องกัน

**ฉันจะตรวจสอบการเปลี่ยนที่ตั้งอยู่ในสไลด์ปัจจุบันได้อย่างไร?**

ตรวจสอบ[การตั้งค่าการเปลี่ยน](https://reference.aspose.com/slides/th/net/aspose.slides/baseslide/slideshowtransition/)ของสไลด์และอ่าน[ประเภทการเปลี่ยน](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/type/)ของมัน; ค่าดังกล่าวบอกคุณได้อย่างชัดเจนว่าเอฟเฟกต์ใดถูกนำไปใช้