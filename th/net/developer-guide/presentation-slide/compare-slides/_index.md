---
title: เปรียบเทียบสไลด์การนำเสนอใน .NET
linktitle: เปรียบเทียบสไลด์
type: docs
weight: 50
url: /th/net/compare-slides/
keywords:
- เปรียบเทียบสไลด์
- การเปรียบเทียบสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เปรียบเทียบการนำเสนอ PowerPoint และ OpenDocument ด้วยโปรแกรมโดยใช้ Aspose.Slides สำหรับ .NET. ตรวจจับความแตกต่างของสไลด์ในโค้ดอย่างรวดเร็ว."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเปรียบเทียบสไลด์, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์โดยใช้เมธอด `Equals` ที่มาจากอินเทอร์เฟซ `IBaseSlide` และคลาส `BaseSlide`. เมธอดนี้จะคืนค่า `true` เมื่อสไลด์ที่เปรียบเทียบมีโครงสร้างและเนื้อหาแบบคงที่เหมือนกัน

## **เปรียบเทียบสไลด์สองสไลด์**

เมธอด Equals ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IBaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide) และคลาส [BaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/baseslide). เมธอดนี้จะคืนค่า true สำหรับสไลด์/เลย์เอาต์และสไลด์/มาสเตอร์ที่มีโครงสร้างและเนื้อหาแบบคงที่เหมือนกัน

สไลด์สองสไลด์จะถือว่าเท่ากันหากรูปทรง, สไตล์, ข้อความ, แอนิเมชันและการตั้งค่าอื่น ๆ ทั้งหมดเหมือนกัน เป็นต้น การเปรียบเทียบไม่พิจารณาค่าตัวระบุที่ไม่ซ้ำกัน เช่น SlideId และเนื้อหาแบบไดนามิก เช่น ค่าที่เป็นวันที่ปัจจุบันใน Date Placeholder

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **คำถามที่พบบ่อย**

**การที่สไลด์ถูกซ่อนมีผลต่อการเปรียบเทียบสไลด์เองหรือไม่?**

[Hidden status](https://reference.aspose.com/slides/th/net/aspose.slides/slide/hidden/) เป็นคุณสมบัติระดับการนำเสนอ/การเล่น ไม่ใช่เนื้อหาเชิงภาพ ความเท่าเทียมของสไลด์สองสไลด์จะกำหนดโดยโครงสร้างและเนื้อหาแบบคงที่; การที่สไลด์ถูกซ่อนเพียงอย่างเดียวไม่ได้ทำให้สไลด์แตกต่างกัน

**ไฮเปอร์ลิงก์และพารามิเตอร์ของมันถูกพิจารณาหรือไม่?**

ใช่. ลิงก์เป็นส่วนหนึ่งของเนื้อหาแบบคงที่ของสไลด์ หาก URL หรือการกระทำของไฮเปอร์ลิงก์แตกต่างกัน จะถือว่าเป็นความแตกต่างในเนื้อหาแบบคงที่

**หากแผนภูมิเกิดจากไฟล์ Excel ภายนอก เนื้อหาของไฟล์นั้นจะถูกนำมาพิจารณาหรือไม่?**

ไม่. การเปรียบเทียบทำบนพื้นฐานของสไลด์เอง แหล่งข้อมูลภายนอกโดยทั่วไปจะไม่ได้อ่านในขณะที่ทำการเปรียบเทียบ; จะพิจารณาเฉพาะสิ่งที่ปรากฏในโครงสร้างและสถานะแบบคงของสไลด์เท่านั้น