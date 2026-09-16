---
title: ส่งออกงานนำเสนอเป็น XAML ใน .NET
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/net/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน .NET ด้วย Aspose.Slides—โซลูชันที่เร็วและไม่ต้องใช้ Office ช่วยคงรูปแบบการออกแบบของคุณไว้ทั้งหมด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีส่งออกงานนำเสนอ PowerPoint เป็น XAML ด้วย Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีปรับแต่งการส่งออกผ่าน XamlOptions รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนท์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษามาร์กอัปที่อิงจาก XML ใช้เพื่ออธิบายส่วนติดต่อผู้ใช้ในเฟรมเวิร์กเช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms.

คุณสามารถทำงานกับไฟล์ XAML ในเครื่องมือออกแบบแบบกรูฟ หรือเขียนและแก้ไขมาร์กอัปโดยตรง.

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง C# ด้านล่างแสดงวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

โดยค่าเริ่มต้น สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `pres` ของไดเรกทอรีทำงานปัจจุบันของกระบวนการ ซึ่งได้จาก Directory.GetCurrentDirectory โฟลเดอร์จะถูกสร้างโดยอัตโนมัติและภาพที่จำเป็นทั้งหมดจะถูกบันทึกไว้ที่นั่นเช่นกัน

ชื่อโฟลเดอร์ผลลัพธ์จะมาจากชื่อไฟล์ต้นทางโดยไม่รวมส่วนขยาย สำหรับ `pres.pptx` ไฟล์ผลลัพธ์จะชื่อ `pres/Slide_1.xaml`, `pres/Slide_2.xaml` เป็นต้น แม้คุณจะระบุเส้นทางแบบเต็มสำหรับไฟล์นำเข้าก็ตาม โฟลเดอร์ผลลัพธ์จะถูกสร้างสัมพันธ์กับไดเรกทอรีทำงานปัจจุบัน ไม่ได้อยู่เคียงข้างไฟล์อินพุต

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

ใช้ interface IXamlOptions เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML

เพื่อบันทึกผลลัพธ์ไปยังตำแหน่งที่กำหนดเอง ให้ทำการสร้างคลาสที่ 구현 IXamlOutputSaver และกำหนดอินสแตนซ์ของการใช้งานนั้นให้กับคุณสมบัติ OutputSaver ของ XamlOptions

เพื่อรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ XAML ให้ตั้งค่า ExportHiddenSlides เป็น true ดังแสดงในตัวอย่าง C# ด้านล่าง:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **จับทุกแอสเซท XAML ที่สร้างขึ้น**

การส่งออก XAML สามารถสร้างเอกสาร XAML สำหรับแต่ละสไลด์ที่ส่งออก รวมถึงภาพและทรัพยากรสนับสนุนแยกต่างหาก ให้กำหนด IXamlOutputSaver แบบกำหนดเองให้กับ XamlOptions.OutputSaver เพื่อรับแอสเซทเหล่านี้แทนการใช้ตัวบันทึกไฟล์เริ่มต้น เริ่มการส่งออกด้วยเมธอด overload ของ Presentation.Save ที่รับพารามิเตอร์ XAML options

### **ทำความเข้าใจวงจรชีวิตของ Callback**

ตัวส่งออกจะเรียก IXamlOutputSaver.Save แยกกันสำหรับแต่ละแอสเซทที่สร้างขึ้น:

- `path` ระบุตัวแอสเซทและอาจรวมไดเรกทอรีสัมพันธ์ เก็บข้อมูลนี้ไว้เพราะ XAML อาจอ้างอิงทรัพยากรด้วยเส้นทางสัมพันธ์
- `data` มีไบต์ของแอสเซท ภาพและทรัพยากรไบนารีอื่น ๆ ไม่ควรถอดรหัสเป็นข้อความ
- ตัวบันทึกต้องรับผิดชอบในการเก็บหรือบันทึกข้อมูลก่อนคืนค่า ตัวอย่างจะคัดลอกอาร์เรย์ไบต์แต่ละอันไปยังหน่วยความจำของแอปพลิเคชัน
- พิจารณาการส่งออกสำเร็จก็ต่อเมื่อการบันทึกงานนำเสร็จและทุก callback ทำงานสำเร็จ อย่าลบข้อผิดพลาดการจัดเก็บหรือเริ่มการเขียนในพื้นหลังโดยไม่ตรวจสอบ หากการบันทึกเกิดขึ้นภายหลัง ให้รายงานความสำเร็จโดยรวมหลังจากขั้นตอนนั้นสำเร็จเช่นกัน

XamlOptions.ExportHiddenSlides ยังใช้กับตัวบันทึกแบบกำหนดเองด้วย ค่าเริ่มต้น false จะละเว้นเอกสาร XAML ของสไลด์ที่ซ่อนอยู่ การตั้งค่าเป็น true จะรวมสไลด์เหล่านั้นและทรัพยากรที่จำเป็นสำหรับการส่งออก จำนวนทรัพยากรขึ้นอยู่กับงานนำเสนอ; อย่าสมมติว่ามี callback หนึ่งต่อสไลด์หรือเรียงลำดับคงที่

### **ส่งออกไปยังหน่วยความจำและตรวจสอบแอสเซท**

ตัวอย่างเต็มนี้โหลด `pres.pptx` รวบรวมทุกแอสเซทใน Dictionary<string, byte[]> แล้วพิมพ์ชื่อ ประเภท และจำนวนไบต์ของแต่ละรายการ โดยรักษาชื่อที่ให้มาอย่างเดิม ชื่อซ้ำจะทำให้การรวบรวมล้มเหลวแทนที่จะเขียนทับแอสเซทอย่างเงียบ

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // ถอดรหัสเฉพาะ XAML และทำเฉพาะเมื่อจำเป็นต้องตรวจสอบข้อความ.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

เรียก InMemoryXamlExample.Run จากแอปพลิเคชันของคุณ การตรวจสอบส่วนขยายเป็นประโยชน์สำหรับการตรวจสอบ; เก็บแอสเซททั้งหมดรวมถึงประเภททรัพยากรที่ไม่คุ้นเคย อย่าเปลี่ยนแปลงไบต์เมื่อเก็บหรือส่งต่อ ใช้ Encoding.UTF8.GetString เฉพาะกับ XAML ที่ต้องการการประมวลผลเป็นข้อความ

### **บรรจุแอสเซทที่รวบรวมไว้ในไฟล์ ZIP**

ตัวอย่างอิสระนี้รวบรวมการส่งออก ตรวจสอบชื่อและเขียนไบต์ต้นฉบับลงในไฟล์ ZIP ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะแยกงานส่งออกพร้อมกัน รายการใน ZIP ใช้เครื่องหมายสแลชหน้าด้านหน้าและรักษาไดเรกทอรีสัมพันธ์ ชื่อที่ไม่ปลอดภัยหรือชื่อที่ชนกันหลังการทำให้เป็นมาตรฐานจะทำให้แพ็กเกจทั้งหมดถูกปฏิเสธก่อนเขียน

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // ไดเรกทอรี ZIP ได้รับการสรุปเรียบร้อยโดยการทำลายก่อนรายงานความสำเร็จ.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

เรียก ZipXamlExample.Run จากแอปพลิเคชันของคุณ ตัวอย่างใช้ ZipArchive เพื่อเขียนไฟล์ ZIP หนึ่งไฟล์; ตัวส่งออกไม่ได้เขียนไฟล์ XAML หรือรูปภาพแยกออก สำหรับการจัดเก็บระยะไกล ให้แทนที่ขั้นตอนการเขียน ZIP ด้วยการอัปโหลดอาร์เรย์ไบต์ที่รวบรวม ใช้ตัวระบุงานส่งออกร่วมกับชื่อแอสเซทสัมพันธ์เต็มเป็นคีย์บล็อบ หรือเก็บตัวระบุงาน ชื่อสัมพันธ์ และข้อมูลไบนารีในแถวฐานข้อมูล เผยแพร่งานหลังจากการอัปโหลดทั้งหมดเสร็จหรือการทำธุรกรรมฐานข้อมูลคอมมิทแล้ว ทำความสะอาดผลลัพธ์บางส่วนหากการบันทึกล้มเหลว

สำหรับงานนำเสนอขนาดใหญ่ ตัวบันทึกแบบกำหนดเองสามารถบันทึกแต่ละแอสเซทโดยตรงสู่ที่จัดเก็บของแอปพลิเคชันเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำ ตัวส่งออกยังคงรวบรวมแอสเซททั้งหมดในหน่วยความจำก่อนเรียกตัวบันทึก ให้ทำให้แต่ละ callback ทำงานแบบซิงโครนัสจากมุมมองของตัวส่งออก: คืนค่าหลังที่ปลายทางยอมรับไบต์และให้อีกกับข้อผิดพลาดส่งถึงผู้เรียกใช้

### **รักษาชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ทำให้เครื่องหมายแยกส่วนของเส้นทางเป็นมาตรฐานเมื่อปลายทางต้องการ แต่คงไดเรกทอรีสัมพันธ์ไว้ อย่าใช้เพียง Path.GetFileName ยกเว้นแต่ละชื่อที่สร้างเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อตามลักษณะของปลายทาง เมื่อเขียนไฟล์แยก ให้ปฏิเสธเส้นทางที่เริ่มต้นด้วย root และส่วนที่ทำการเดินทางย้อนกลับ แก้ไขปลายทางด้วย Path.GetFullPath และตรวจสอบว่ามันอยู่ภายใต้ไดเรกทอรีส่งออกที่กำหนด รวมถึงเครื่องหมายแยกไดเรกทอรีในตรวจสอบการครอบคลุม ใช้ไดเรกทอรีที่ควบคุมโดยแอปพลิเคชันโดยไม่มีลิงก์สัญลักษณ์ที่อาจเปลี่ยนเส้นทางการเขียน
- ใช้ตัวบันทึกและเนมสเปซการจัดเก็บแยกต่างหากสำหรับแต่ละงานส่งออก ตรวจจับการชนกันหลังจากทำให้เครื่องหมายแยกส่วนเป็นมาตรฐานและตามกฎการแยกแยะตัวพิมพ์ใหญ่-เล็กของปลายทาง
- ก่อนเผยแพร่ ให้แยกวิเคราะห์แต่ละเอกสาร XAML เป็น XML และตรวจสอบการอ้างอิงทรัพยากรแบบไฟล์ เช่น แอตทริบิวต์ Source หรือ ImageSource ของรูปภาพ แก้ไขแต่ละ URI สัมพันธ์เทียบกับไดเรกทอรีของแอสเซท XAML ที่บรรจุ ปรับให้เป็นมาตรฐานชื่อการจัดเก็บที่ได้และยืนยันว่าคีย์ในดิกชันนารี, รายการ ZIP หรืออ็อบเจ็กต์ที่เก็บมีอยู่ พิจารณา URI ภายนอกและนิพจน์มาร์กอัป XAML แยกต่างหากจากชื่อไฟล์สัมพันธ์

เช่น หาก `pres/Slide_1.xaml` อ้างอิง `images/image1.png` ทรัพยากรที่เก็บต้องมีอยู่เป็น `pres/images/image1.png` การเก็บเฉพาะ `image1.png` จะทำให้ความสัมพันธ์นี้หลุด การจัดเก็บแบบอ็อบเจ็กต์ ควรรักษาโครงสร้างเดียวกันใต้คำนำหน้างานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้สำหรับผู้ใช้ XAML เปิด ZIP ที่เสร็จสมบูรณ์ใหม่เพื่อตรวจสอบชื่อรายการและไบต์ของทรัพยากร และโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML เป้าหมายเพื่อยืนยันว่าภาพได้แก้ไขอย่างถูกต้อง

## **FAQ**

**ฉันจะทำให้ฟอนท์คาดการณ์ได้อย่างไรหากฟอนท์ต้นแบบไม่มีในเครื่อง?**

ตั้ง DefaultRegularFont ใน XamlOptions — จะถูกใช้เป็นฟอนท์สำรองระหว่างการส่งออกเมื่อฟอนท์ต้นแบบไม่มี อย่างไรก็ตาม ไม่ได้รับประกันว่า XAML ที่สร้างจะอ้างอิงฟอนท์สำรองหรือว่าฟอนท์นั้นมีในเครื่องเป้าหมาย ตรวจสอบให้แน่ใจว่าฟอนท์ที่ XAML อ้างอิงมีอยู่ในสภาพแวดล้อมที่แสดงผล

**XAML ที่ส่งออกออกแบบมาเฉพาะสำหรับ WPF หรือสามารถใช้กับสแตก XAML อื่นได้ด้วยหรือไม่?**

Aspose.Slides ส่งออก WPF XAML ผ่าน API สาธารณะของมัน ความเข้ากันได้กับสแตก XAML อื่น เช่น UWP หรือ Xamarin.Forms ไม่ได้รับการรับประกัน ควรทดสอบมาร์กอัปที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้ส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกรวม คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน ExportHiddenSlides ใน XamlOptions — ปิดการใช้งานหากไม่ต้องการส่งออกสไลด์เหล่านั้น.