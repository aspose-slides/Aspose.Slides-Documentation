---
title: การสนับสนุนไลบรารีที่สามารถขัดจังหวะได้
type: docs
weight: 150
url: /th/net/support-for-interruptable-library/
keywords:
- ไลบรารีที่สามารถขัดจังหวะได้
- โทเค็นการขัดจังหวะ
- โทเค็นการยกเลิก
- งานที่ใช้เวลานาน
- ขัดจังหวะงาน
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำให้งานที่ใช้เวลานานสามารถยกเลิกได้ด้วย Aspose.Slides for .NET. ขัดจังหวะการเรนเดอร์และการแปลงไฟล์สำหรับ PowerPoint และ OpenDocument อย่างปลอดภัย พร้อมตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides for .NET มีกลไกการประมวลผลที่สามารถขัดจังหวะได้สำหรับงานพรีเซนเทชันที่ใช้เวลานาน เช่น การถอดรหัส การเข้ารหัส และการเรนเดอร์ กลไกนี้อิงตามคลาส `InterruptionToken` และ `InterruptionTokenSource`  

`InterruptionToken` สามารถกำหนดให้กับ `LoadOptions` และส่งต่อไปยังคอนสตรัคเตอร์ของ `Presentation` เมื่อเรียก `InterruptionTokenSource.Interrupt()` งานที่ใช้เวลานานที่เกี่ยวข้องจะถูกขัดจังหวะ บทความนี้ยังแสดงวิธีใช้กลไกนี้ร่วมกับ `CancellationToken` ของ .NET มาตรฐานโดยตรวจสอบคำขอยกเลิกและเรียก `Interrupt()` เมื่อมีการร้องขอยกเลิก

## **ไลบรารีที่สามารถขัดจังหวะได้**

ใน [Aspose.Slides 18.4](https://releases.aspose.com/slides/th/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) เราได้แนะนำคลาส [InterruptionToken](https://reference.aspose.com/slides/th/net/aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/th/net/aspose.slides/interruptiontokensource/) ซึ่งช่วยให้คุณสามารถขัดจังหวะงานที่ใช้เวลานาน เช่น การถอดรหัส การเข้ารหัส และการเรนเดอร์ได้  

- [InterruptionTokenSource](https://reference.aspose.com/slides/th/net/aspose.slides/interruptiontokensource/) คือแหล่งที่มาของโทเค็นที่ส่งให้กับ [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/th/net/aspose.slides/iloadoptions/interruptiontoken/)  
- เมื่อกำหนดค่า [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/th/net/aspose.slides/iloadoptions/interruptiontoken/) และส่งอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) ไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) การเรียกใช้ [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/th/net/aspose.slides/interruptiontokensource/interrupt/) จะขัดจังหวะงานใด ๆ ที่ใช้เวลานานและเชื่อมโยงกับ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) นั้น

โค้ดตัวอย่างต่อไปนี้แสดงการขัดจังหวะงานที่กำลังทำงานอยู่:

```c#
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
    Run(action, tokenSource.Token); // เรียกการทำงานในเธรดแยก
    Thread.Sleep(10000);            // หมดเวลา
    tokenSource.Interrupt();        // หยุดการแปลง
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **CancellationToken ของ .NET และไลบรารีที่สามารถขัดจังหวะได้**

เมื่อคุณต้องการใช้ [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) ร่วมกับไลบรารี Interruptible ของ Aspose.Slides ให้ห่อการประมวลผลของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และขัดจังหวะ [InterruptionToken](https://reference.aspose.com/slides/th/net/aspose.slides/interruptiontoken/) เมื่อ [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) เป็น `true`

โค้ด C# ด้านล่างนี้แสดงการทำงาน:

```cs
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
    Task task = Run(action, tokenSource.Token); // เรียกการทำงานในเธรดแยก

    while (!task.Wait(500)) // รอและตรวจสอบว่ามีการตั้งค่า cancellationToken.IsCancellationRequested หรือไม่
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

## **FAQ**

**วัตถุประสงค์ของไลบรารีขัดจังหวะ Aspose.Slides คืออะไร?**

ให้กลไกในการขัดจังหวะการดำเนินการที่ใช้เวลานาน — เช่น การโหลด การบันทึก หรือการเรนเดอร์พรีเซนเทชัน — ก่อนที่จะเสร็จสมบูรณ์ ซึ่งเป็นประโยชน์เมื่อเวลาการประมวลผลต้องถูกจำกัดหรือไม่ต้องการทำงานต่อ

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/th/net/aspose.slides/interruptiontoken/) กับ [InterruptionTokenSource](https://reference.aspose.com/slides/th/net/aspose.slides/iinterruptiontokensource/) คืออะไร?**

- `InterruptionToken` ถูกส่งให้กับ API ของ Aspose.Slides และจะถูกตรวจสอบระหว่างการดำเนินการที่ใช้เวลานาน  
- `InterruptionTokenSource` ใช้ในโค้ดของคุณเพื่อสร้างโทเค็นและทำให้เกิดการขัดจังหวะโดยการเรียก `Interrupt()`

**ฉันสามารถใช้ .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) ร่วมกับไลบรารีขัดจังหวะได้หรือไม่?**

ได้ คุณสามารถตรวจสอบ [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) ในตรรกะของแอปพลิเคชันและเรียก [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/th/net/aspose.slides/iinterruptiontokensource/interrupt/) เมื่อมีการร้องขอยกเลิก ซึ่งทำให้ Aspose.Slides สามารถทำงานร่วมกับขั้นตอนการยกเลิกมาตรฐานของ .NET

**งานใดบ้างที่สามารถขัดจังหวะได้?**

งานใด ๆ ของ Aspose.Slides ที่รับ [InterruptionToken](https://reference.aspose.com/slides/th/net/aspose.slides/interruptiontoken/) — เช่น การโหลดพรีเซนเทชันด้วย `Presentation(path, loadOptions)` หรือการบันทึกด้วย `Presentation.Save(...)` — สามารถถูกขัดจังหวะได้

**การขัดจังหวะเกิดขึ้นทันทีหรือไม่?**

ไม่ การขัดจังหวะเป็นแบบร่วมมือ: การดำเนินการจะตรวจสอบโทเค็นเป็นระยะ ๆ และหยุดเมื่อพบว่าได้เรียก [Interrupt()](https://reference.aspose.com/slides/th/net/aspose.slides/iinterruptiontokensource/interrupt/) แล้ว

**ถ้าฉันเรียก [Interrupt()](https://reference.aspose.com/slides/th/net/aspose.slides/iinterruptiontokensource/interrupt/) หลังจากงานเสร็จแล้ว จะเกิดอะไรขึ้น?**

ไม่เกิดอะไร — การเรียกนี้ไม่มีผลหากงานที่เกี่ยวข้องได้เสร็จแล้ว

**ฉันสามารถใช้ [InterruptionTokenSource](https://reference.aspose.com/slides/th/net/aspose.slides/iinterruptiontokensource/) เดียวกันสำหรับหลายงานได้หรือไม่?**

ได้ — แต่หลังจากคุณเรียก [Interrupt()](https://reference.aspose.com/slides/th/net/aspose.slides/iinterruptiontokensource/interrupt/) บนแหล่งนั้น งานทั้งหมดที่ใช้โทเค็นจากแหล่งนั้นจะถูกขัดจังหวะ แนะนำให้ใช้แหล่งโทเค็นแยกกันเพื่อจัดการงานอย่างอิสระ