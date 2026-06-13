---
title: ลบสไลด์จากงานนำเสนอใน .NET
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/net/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ลบสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET. รับตัวอย่างโค้ด C# ที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **บทนำ**

หากสไลด์ (หรือเนื้อหาของมัน) กลายเป็นซ้ำซ้อนคุณสามารถลบได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ที่รวบรวม [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) ซึ่งเป็นที่เก็บสไลด์ทั้งหมดในงานนำเสนอ โดยใช้ตัวชี้ (อ้างอิงหรือดัชนี) ของวัตถุ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) ที่ทราบ คุณสามารถระบุสไลด์ที่ต้องการลบได้ 

## **ลบสไลด์โดยอ้างอิง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) .
2. รับอ้างอิงของสไลด์ที่ต้องการลบโดยใช้ ID หรือดัชนีของมัน.
3. ลบสไลด์ที่อ้างอิงออกจากงานนำเสนอ.
4. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

```c#
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{
    // เข้าถึงสไลด์ผ่านดัชนีในคอลเลกชันสไลด์
    ISlide slide = pres.Slides[0];

    // ลบสไลด์ผ่านอ้างอิงของมัน
    pres.Slides.Remove(slide);

    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ลบสไลด์โดยดัชนี**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) .
2. ลบสไลด์ออกจากงานนำเสนอโดยใช้ตำแหน่งดัชนีของมัน.
3. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

```c#
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // ลบสไลด์ผ่านดัชนีของสไลด์
    pres.Slides.RemoveAt(0);

    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (จากคลาส [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/)) เพื่อให้คุณลบสไลด์เค้าโครงที่ไม่ต้องการและไม่ได้ใช้ โค้ด C# นี้แสดงวิธีลบสไลด์เค้าโครงจากงานนำเสนอ PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (จากคลาส [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/)) เพื่อให้คุณลบสไลด์มาสเตอร์ที่ไม่ต้องการและไม่ได้ใช้ โค้ด C# นี้แสดงวิธีลบสไลด์มาสเตอร์จากงานนำเสนอ PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**อะไรเกิดขึ้นกับดัชนีของสไลด์หลังจากที่ฉันลบสไลด์?**

หลังจากลบแล้ว, [คอลเลกชัน](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/) จะทำการจัดดัชนีใหม่: สไลด์ต่อ ๆ ไปจะเลื่อนตำแหน่งไปทางซ้ายหนึ่งตำแหน่ง, ทำให้หมายเลขดัชนีก่อนหน้าเก่าและใช้ไม่ได้. หากต้องการอ้างอิงที่คงที่ ให้ใช้ ID คงที่ของสไลด์แต่ละอันแทนการใช้ดัชนี.

**ID ของสไลด์แตกต่างจากดัชนีหรือไม่, และมันจะเปลี่ยนแปลงเมื่อสไลด์ข้างเคียงถูกลบหรือไม่?**

ใช่. ดัชนีคือตำแหน่งของสไลด์และจะเปลี่ยนเมื่อสไลด์ถูกเพิ่มหรือถูกลบ. ID ของสไลด์เป็นตัวระบุคงที่และจะไม่เปลี่ยนแปลงเมื่อสไลด์อื่นถูกลบ.

**การลบสไลด์มีผลต่อส่วนของสไลด์อย่างไร?**

หากสไลด์เป็นส่วนหนึ่งของเซกชัน, เซกชันนั้นจะมีสไลด์น้อยลงหนึ่งสไลด์. โครงสร้างของเซกชันคงอยู่; หากเซกชันว่างเปล่า, คุณสามารถ [ลบหรือจัดระเบียบเซกชัน](/slides/th/net/slide-section/) ได้ตามต้องการ.

**เกิดอะไรขึ้นกับบันทึกและความคิดเห็นที่แนบกับสไลด์เมื่อมันถูกลบ?**

[บันทึก](/slides/th/net/presentation-notes/) และ [ความคิดเห็น](/slides/th/net/presentation-comments/) ถูกผูกกับสไลด์นั้นและจะถูกลบพร้อมกับสไลด์นั้น. เนื้อหาในสไลด์อื่นไม่มีผลกระทบ.

**การลบสไลด์แตกต่างจากการทำความสะอาดเค้าโครง/มาสเตอร์ที่ไม่ได้ใช้อย่างไร?**

การลบจะเอาสไลด์ปกติที่ระบุออกจากชุดสไลด์. การทำความสะอาดเค้าโครง/มาสเตอร์ที่ไม่ได้ใช้จะลบสไลด์เค้าโครงหรือมาสเตอร์ที่ไม่มีการอ้างอิง, ลดขนาดไฟล์โดยไม่เปลี่ยนแปลงเนื้อหาสไลด์ที่เหลือ. การกระทำเหล่านี้เสริมกัน: โดยทั่วไปลบก่อน, แล้วค่อยทำความสะอาด.