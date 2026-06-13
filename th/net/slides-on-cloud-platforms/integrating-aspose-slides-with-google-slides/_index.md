---
title: การรวม Aspose.Slides กับ Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /th/net/integrating-aspose-slides-with-google-slides/
keywords:
- แพลตฟอร์มคลาวด์
- การรวมคลาวด์
- Google Slides
- Google Drive
- Google API
- บัญชีบริการ Google
- การรวม SaaS
- OAuth 2.0
- PPT เป็น PDF
- การทำงานอัตโนมัติของ PowerPoint
- การประมวลผลงานนำเสนอ
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "เชื่อมต่อ Aspose.Slides กับ Google Slides เพื่อทำการนำเข้า, ซิงค์, และแปลงงานนำเสนอ, ทำงานอัตโนมัติของกระบวนการ, และทำให้ PowerPoint และ OpenDocument อยู่ในไพพ์ไลน์เดียวกัน."
---
## **บทนำ**

Aspose.Slides ตอนนี้ให้การรวมกับ Google Slides และ Google Drive ผ่าน [API การรวม SaaS](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) ของมัน การรวมนี้ทำให้แอป .NET สามารถแปลง, แก้ไข, ดาวน์โหลด, และอัปโหลดงานนำเสนอ Google Slides ได้

## **Google Slides คืออะไร?**
[Google Slides](https://workspace.google.com/products/slides/th/) เป็นซอฟต์แวร์การนำเสนอแบบเว็บฟรีที่พัฒนาโดย Google มันช่วยให้ผู้ใช้สร้าง, แก้ไข, และแชร์งานนำเสนอสไลด์ออนไลน์ได้คล้ายกับ Microsoft PowerPoint รองรับการทำงานร่วมกันแบบเรียลไทม์, การจัดเก็บบนคลาวด์, และทำงานได้บนอุปกรณ์ใดก็ได้ที่เชื่อมต่ออินเทอร์เน็ต

## **Google API**
ก่อนเริ่มทำงานกับงานนำเสนอ Google Slides ของคุณผ่าน Aspose.Slides คุณต้องสร้างโครงการ Google API และสร้าง [โครงการ Google Cloud](https://developers.google.com/workspace/guides/create-project) แล้วเปิดใช้ API ที่ต้องการ  

จากนั้นคุณต้องเลือกวิธีที่คุณจะเข้าถึง Google API - [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) รองรับสองวิธีในการเข้าถึง Google API:
- `Google Service Account`
- `OAuth 2.0` กับการโต้ตอบของผู้ใช้ผ่านเบราว์เซอร์

### **Google Service Account**
บัญชีบริการเป็นบัญชี Google พิเศษที่แอปพลิเคชันหรือเซิร์ฟเวอร์ใช้เพื่อเข้าถึง Google API อย่างโปรแกรมโดยไม่ต้องมีการโต้ตอบของผู้ใช้ มักใช้สำหรับระบบแบ็กเอนด์หรือภารกิจอัตโนมัติ บัญชีบริการได้รับการตรวจสอบด้วยไฟล์คีย์ JSON และมีที่อยู่อีเมลของตนเอง สามารถกำหนดสิทธิ์เฉพาะผ่าน [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) และมักใช้ร่วมกับ API เช่น Google Drive, Sheets, หรือ BigQuery สำหรับการเข้าถึงทรัพยากรอย่างปลอดภัยและอัตโนมัติ

### **OAuth 2.0**
อีกวิธีทั่วไปหนึ่งในการเข้าถึง Google API คือผ่าน OAuth 2.0 โดยมีการโต้ตอบของผู้ใช้ผ่านเบราว์เซอร์ ในขั้นตอนนี้ผู้ใช้จะถูกเปลี่ยนเส้นทางไปยังหน้าเข้าสู่ระบบของ Google เพื่อให้สิทธิ์แก่แอป หลังจากได้รับการอนุมัติ แอปจะได้รับโค้ดอนุญาตซึ่งจะแลกเปลี่ยนเป็นโทเค็นการเข้าถึงและโทเค็นรีเฟรช  

โทเค็นการเข้าถึงให้สิทธิ์ชั่วคราวในการใช้ Google API ส่วนโทเค็นรีเฟรชสามารถเก็บไว้และนำมาใช้ใหม่เพื่อรับโทเค็นการเข้าถึงใหม่โดยไม่ต้องให้ผู้ใช้ล็อกอินอีกครั้ง ซึ่งหมายความว่าการโต้ตอบผ่านเบราว์เซอร์ต้องทำเพียงครั้งเดียว ทำให้การเข้าถึง API หลังจากนั้นเป็นอัตโนมัติโดยสมบูรณ์ วิธีนี้มักใช้กับแอปที่ต้องเข้าถึงข้อมูลของผู้ใช้ (เช่น Gmail, Calendar, หรือ Drive) ด้วยความยินยอมของผู้ใช้

## **เริ่มเขียนโค้ด**
ก่อนอื่นให้เพิ่ม [แพคเกจ NuGet Aspose.Slides SaaS Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) ลงในโครงการของคุณ:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **ตัวอย่าง 1**
ในตัวอย่างต่อไปนี้ เราจะดาวน์โหลดงานนำเสนอ Google Slides จาก Google Drive และบันทึกลงดิสก์ในรูปแบบไฟล์ PDF เราจะใช้ `Google Service Account` สำหรับการยืนยันตัวตน โดยสมมติว่ามีไฟล์ JSON ของบัญชีบริการพร้อมข้อมูลประจำตัวแล้ว

```csharp
// สร้าง HttpClient ที่จัดการโดยภายนอก
HttpClient httpClient = new HttpClient();

// สร้างผู้ให้การรับรองโดยใช้ไฟล์ JSON ของบัญชีบริการ
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// เริ่มต้นบริการการรวม Google Slides ด้วยผู้ให้การรับรอง
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Load a presentation from Google Drive by its file ID into an Aspose.Slides IPresentation instance
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// แก้ไขงานนำเสนอหากจำเป็น (เช่น ลบสไลด์ที่สอง)
pres.Slides.RemoveAt(1);

// บันทึกงานนำเสนอในเครื่องเป็นไฟล์ PDF
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

เพื่อความสะดวก Aspose.Slides SaaS Integration มีเมธอดที่ช่วยแสดงรายการไฟล์ทั้งหมดที่ผู้ใช้สามารถเข้าถึงได้ ข้อมูลที่ส่งกลับรวมถึงชื่อไฟล์, ชนิด MIME, และ ID ของไฟล์

```csharp
// ดึงรายการไฟล์ที่บัญชีบริการที่ระบุสามารถเข้าถึงได้
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

วิธีอื่นหนึ่งในการค้นหา ID ของไฟล์คือเปิดงานนำเสนอในแอปเว็บ Google Slides แล้วดูจาก URL  

เช่นใน URL ต่อไปนี้:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

ID ของไฟล์คือ:

```
1A2B3C4D5E6F7G8H9I0J
```

## **ตัวอย่าง 2**
ในตัวอย่างต่อไป เราจะสร้างงานนำเสนอ PowerPoint ตั้งแต่ต้นแล้วอัปโหลดไปยัง Google Drive ในรูปแบบ Google Slides สำหรับการยืนยันตัวตน เราจะใช้ OAuth 2.0

```csharp
// สร้าง HttpClient ที่จัดการโดยภายนอก
HttpClient httpClient = new HttpClient();

// สร้างผู้ให้การรับรองโดยใช้ OAuth พร้อม client ID และ client secret
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// เริ่มต้นบริการการรวม Google Slides ด้วยผู้ให้การรับรอง
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// สร้างงานนำเสนอตัวอย่าง
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // บันทึกงานนำเสนอไปยังโฟลเดอร์รูทของ Google Drive ในรูปแบบ Google Slides
    // คุณสามารถเลือกรูปแบบการส่งออกอื่นใดที่สนับสนุนโดย Aspose.Slides ได้เช่นกัน
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

หากคุณใช้วิธีการยืนยันตัวตนแบบนี้ในแอปของคุณ `interaction with the browser is required` คุณจะต้องเลือกบัญชีของคุณและยืนยันว่าอนุญาตให้แอปเข้าถึง Google Drive API ของคุณ นั่นแค่นั้น—การดำเนินการนี้จำเป็นเพียงครั้งแรกเท่านั้น

### **ตัวอย่าง 3**
ในตัวอย่างต่อไปนี้ เราจะใช้โทเค็นการเข้าถึงที่ได้มาล่วงหน้า `GoogleAccessTokenAuthProvider` เป็นการนำเสนอของอินเตอร์เฟซ `IGoogleAuthorizationProvider` ที่ใช้โทเค็น OAuth 2.0 ที่มีอยู่เพื่อยืนยันคำขอไปยัง Google API ต่างๆ ไม่เหมือนกับผู้ให้บริการที่จัดการกระบวนการ OAuth ตัวนี้พึ่งพาผู้เรียกให้ส่งโทเค็นที่ถูกต้องมา

ผู้ให้บริการนี้มีประโยชน์ในระบบที่โทเค็นการเข้าถึงถูกดึงมาจากภายนอก—ส่วนใหญ่จากแอปฝั่งหน้าเว็บไซต์หรือเซอร์วิสอื่น—and ส่งต่อไปยังแบ็กเอนด์ มันเหมาะอย่างยิ่งสำหรับสภาพแวดล้อมแบบกระจายที่การจัดการโทเค็นรีเฟรชบนเซิร์ฟเวอร์อาจทำให้ซับซ้อนหรือเสี่ยงต่อการทำให้โทเค็นใช้งานไม่ได้เนื่องจากการรีเฟรชพร้อมกันหลายครั้ง  

ตัวอย่างนี้แสดงวิธีการแทนที่ไฟล์และอัปเดตชื่อไฟล์บน Google Drive ในขณะที่ยังคงรักษา ID ของไฟล์เดิมไว้

```csharp
// สร้าง HttpClient สำหรับทำคำขอ
using HttpClient httpClient = new HttpClient();

// ตั้งค่าการยืนยันตัวตน Google Drive ด้วยโทเค็นการเข้าถึง
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// เริ่มต้นการรวมกับ Google Slides/Drive ด้วยการยืนยันตัวตนและ HttpClient
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// สร้างงานนำเสนอตัวอย่างโดยใช้ Aspose.Slides
using (var presentation = new Presentation())
{
    // เพิ่มรูปสี่เหลี่ยมผืนผ้าไปยังสไลด์แรกและกำหนดข้อความ
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // กำหนดตัวเลือกการบันทึก PDF พร้อมคุณภาพและการปฏิบัติตามที่กำหนด
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // บันทึก (แทนที่) ไฟล์ที่มีอยู่บน Google Drive โดยใช้ไฟล์ ID, อัปเดตชื่อ, และส่งออกเป็น PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID ของไฟล์ที่มีอยู่บน Google Drive
        GoogleSaveFormatType.Pdf,         // รูปแบบที่ต้องการบันทึกเป็น
        saveOptions,           
        "NewFileName.pdf"                 // ชื่อใหม่ที่จะกำหนดให้ไฟล์
    );
}
```

## **สรุป**
Aspose.Slides ตอนนี้รองรับรูปแบบไฟล์เพิ่มเติมสำหรับการจัดการ ทำให้การทำงานอัตโนมัติของกระบวนการคลาวด์สำหรับการสร้าง, แชร์, และแก้ไขงานนำเสนอเป็นเรื่องง่ายขึ้น  

บทความนี้ได้ครอบคลุมคุณสมบัติพื้นฐาน คุณยังสามารถบันทึกไฟล์ลงในโฟลเดอร์ย่อย, แทนที่ไฟล์ที่มีอยู่, และส่งออกไปยัง Google Drive ในรูปแบบต่างๆ ไม่จำกัดเฉพาะงานนำเสนอ Google Slides  

Aspose.Slides SaaS Integration จะยังคงขยายการสนับสนุนแพลตฟอร์ม SaaS สำหรับงานนำเสนอ ดังนั้นตรวจสอบการอัปเดตในอนาคตได้เสมอ

## **คำถามที่พบบ่อย**

**ต้องมีบัญชี Google Workspace จึงจะใช้การรวมนี้ได้หรือไม่?**  
ไม่จำเป็น คุณสามารถใช้บัญชี Google ฟรีหรือบัญชี Google Workspace ได้เลย การเข้าถึงที่ต้องการขึ้นอยู่กับสิทธิ์ใน Google Drive และ Slides ของคุณ

**ควรเลือกวิธีการรับรองตัวตนแบบไหน—Service Account หรือ OAuth 2.0?**  
ใช้ **Service Account** สำหรับกระบวนการแบ็กเอนด์หรือเวิร์คโฟลว์อัตโนมัติที่ไม่มีการโต้ตอบของผู้ใช้  
ใช้ **OAuth 2.0** หากต้องการเข้าถึงไฟล์ Google Slides หรือ Drive ของผู้ใช้เฉพาะด้วยความยินยอมของผู้ใช้

**สามารถทำงานกับรูปแบบอื่นนอกจาก Google Slides ได้หรือไม่?**  
ได้ Aspose.Slides รองรับการบันทึกงานนำเสนอเป็นหลายรูปแบบ (เช่น PDF, PPTX, HTML) ก่อนอัปโหลดไปยัง Google Drive

**จะหา ID ของไฟล์ Google Slides ได้อย่างไร?**  
คุณสามารถดึงได้โดยใช้เมธอด `GetDriveFileInfosAsync()` หรือคัดลอกจาก URL ของงานนำเสนอใน Google Slides

**การรวมนี้รองรับการแทนที่ไฟล์ที่มีอยู่บน Google Drive หรือไม่?**  
ใช่ ใช้เมธอด `SavePresentationToExistingFileAsync` เพื่ออัปเดตไฟล์โดยคง ID ของไฟล์เดิมไว้

**ต้องโต้ตอบผ่านเบราว์เซอร์ทุกครั้งเมื่ใช้ OAuth 2.0 หรือไม่?**  
ไม่ จำเป็นต้องโต้ตอบผ่านเบราว์เซอร์เพียงครั้งแรกเท่านั้น หลังจากนั้นโทเค็นรีเฟรชที่เก็บไว้จะทำให้การเข้าถึงเป็นอัตโนมัติได้.