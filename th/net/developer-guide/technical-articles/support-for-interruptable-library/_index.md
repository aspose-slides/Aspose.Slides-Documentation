---
title: ขัดจังหวะการดำเนินการพรีเซนเทชันที่ใช้เวลานานใน .NET
linktitle: ขัดจังหวะการดำเนินการพรีเซนเทชัน
type: docs
weight: 150
url: /th/net/support-for-interruptable-library/
keywords:
- การดำเนินการที่สามารถขัดจังหวะได้
- โทเค็นการขัดจังหวะ
- โทเค็นการยกเลิก
- งานที่ใช้เวลานาน
- งานขัดจังหวะ
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธียกเลิกการดำเนินการพรีเซนเทชันที่ใช้เวลานานใน Aspose.Slides สำหรับ .NET และคืนผลลัพธ์บางส่วนเมื่อส่งออกสไลด์ในลูป."
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถขัดจังหวะการดำเนินการที่ใช้เวลานาน เช่น การโหลด การบันทึก และการเรนเดอร์งานพรีเซนเทชัน แอปพลิเคชันของคุณสามารถใช้โทเค็นการขัดจังหวะเดียวกันเพื่อหยุดลูปก่อนที่จะเริ่มประมวลผลสไลด์ถัดไป

## **ขัดจังหวะการดำเนินการของงานพรีเซนเทชัน**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), กำหนด [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) ของมันให้กับ [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) และส่งออปชั่นการโหลดไปยัง [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). เพื่อขอการยกเลิก ให้เรียก [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) บนแหล่งข้อมูล การดำเนินการที่สามารถขัดจังหวะได้จะหยุดเมื่อสังเกตเห็นคำขอ

ตัวอย่างเริ่มแปลง `sample.pptx` เป็น `sample.ppt` ในงานเบื้องหลังและขอยกเลิกหลังจาก 10 วินาที หากการแปลงเสร็จก่อนหน้านั้น ผลลัพธ์ก็จะพร้อมอยู่แล้ว

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // เรียกทำงานแอคชันในเธรดแยก
    Thread.Sleep(10000);            // หมดเวลา
    tokenSource.Interrupt();        // หยุดการแปลง
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **เชื่อมต่อการยกเลิกของ .NET กับ Aspose.Slides**

หากแอปพลิเคชันของคุณใช้ .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), ให้ส่งต่อคำขอยกเลิกของมันไปยัง Aspose.Slides ตัวอย่างเริ่มส่งออก `sample.pptx` เป็น `sample.pdf` และตั้งค่าเวลา timeout เป็น 20 วินาที ขณะการส่งกำลังทำงาน จะตรวจสอบ [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) ทุก 500 มิลลิวินาที เมื่อคุณสมบัติเป็น `true` จะเรียก [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // เรียกทำงานแอคชันในเธรดแยก

    while (!task.Wait(500)) // รอและตรวจสอบว่าคุณสมบัติ cancellationToken.IsCancellationRequested ถูกตั้งค่าไว้หรือไม่
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // ขัดจังหวะการประมวลผล Presentation
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **หยุดก่อนประมวลผลสไลด์ถัดไป**

ใช้ [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) เดียวกันสำหรับงานพรีเซนเทชันและลูปที่ส่งออกสไลด์ของมัน ตรวจสอบ [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) ก่อนเริ่มการส่งออกแต่ละครั้ง หากผู้เรียกสามารถใช้ผลลัพธ์บางส่วนได้ ให้คืนหมายเลขสไลด์สำหรับการส่งออกที่สำเร็จแล้ว

ใช้งานพรีเซนเทชันชื่อ `sample.pptx` ที่มีอย่างน้อยสองสไลด์ ตัวอย่างขอยกเลิกทันทีหลังจากบันทึกการส่งออกที่สำเร็จครั้งแรก

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

ตัวอย่างเขียนไฟล์ `slide-1.pdf` และพิมพ์ `Starting slide 1` ตามด้วย `Completed: [1]` ลูปจะเห็นคำขอก่อนเริ่มสไลด์ 2 หากการยกเลิกขัดจังหวะ [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ในระหว่างการส่งออก บล็อก `catch` จะออกจากลูปก่อนที่โค้ดจะบันทึกสไลด์ปัจจุบันเป็นสำเร็จ

หากผู้เรียกต้องการจัดการการยกเลิก ให้แทนที่การตรวจสอบ `if` และ `break` ที่ด้านบนของลูปด้วยการเรียก [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) บนโทเค็น ลบคำสั่ง `try`/`catch` รอบการส่งออก เพื่อให้การยกเลิกระหว่างการบันทึกถึงผู้เรียกได้เช่นกัน โดยใช้อินพุตเดียวกัน ตัวอย่างจะพิมพ์เฉพาะ `Starting slide 1` และเขียน `slide-1.pdf` ที่จุดเริ่มต้นของการวนรอบที่สอง ผู้เรียกจะได้รับ [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) ก่อนการส่งออกเริ่ม วิธีนี้จะไม่คืนรายการ

## **คำถามที่พบบ่อย**

**เมื่อใดควรขอการยกเลิก?**

ให้ขอการยกเลิกเมื่อการดำเนินการเกินเวลาที่กำหนดของคุณหรือเมื่อแอปพลิเคชันของคุณไม่ต้องการผลลัพธ์อีกต่อไป

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) กับ [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) คืออะไร?**

แหล่งข้อมูลทำให้แอปพลิเคชันของคุณสามารถขอการยกเลิกได้ ส่วนโทเค็นทำให้ Aspose.Slides และแอปพลิเคชันของคุณตรวจสอบคำขอนั้น

**ฉันสามารถใช้ .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) กับ Aspose.Slides ได้หรือไม่?**

ได้ครับ เมื่อโทเค็น .NET ของคุณส่งสัญญาณการยกเลิก ให้เรียก [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) บนแหล่งข้อมูลที่เชื่อมโยงกับงานพรีเซนเทชัน

**ฉันสามารถขัดจังหวะการดำเนินการใดได้บ้าง?**

คุณสามารถขัดจังหวะการโหลด การบันทึก และการเรนเดอร์ได้ ส่งโทเค็นไปยัง [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) ผ่าน [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) งานพรีเซนเทชันจะสังเกตการยกเลิกในขั้นตอนต่อไป เช่น [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**การดำเนินการจะหยุดทันทีหรือไม่?**

การยกเลิกทำงานแบบร่วมมือ การดำเนินการจะตรวจสอบโทเค็นเป็นระยะและหยุดเมื่อตรวจพบคำขอ

**จะเกิดอะไรขึ้นหากฉันเรียก [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) หลังจากการดำเนินการเสร็จสิ้น?**

การดำเนินการที่เสร็จแล้วจะคงผลลัพธ์ไว้

**หลายการดำเนินการสามารถใช้ร่วมกัน [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) ได้หรือไม่?**

ได้ครับ การเรียก [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) จะขอการยกเลิกสำหรับทุกการดำเนินการที่ใช้โทเค็นจากแหล่งข้อมูลนั้น ใช้แหล่งข้อมูลแยกสำหรับแต่ละการดำเนินการที่คุณต้องการยกเลิกอย่างอิสระ