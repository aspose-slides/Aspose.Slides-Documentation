---
title: ตัวแปลการนำเสนอด้วย AI
linktitle: ตัวแปลด้วย AI
type: docs
weight: 20
url: /th/php-java/ai/translator/
keywords:
- ตัวแปลการนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลการนำเสนอ
- การแปลสไลด์
- คุณลักษณะขับเคลื่อนด้วย AI
- ความสามารถของ AI
- ตัวแทน AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ PHP. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นพร้อมคงรูปแบบเดิม—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองเลย."
---
## **บทนำ**

Aspose.Slides คือ API ที่ทรงพลังสำหรับการจัดการงานนำเสนอ PowerPoint อย่างอัตโนมัติ นอกจากการสร้าง, แก้ไขและแปลงสไลด์แล้ว ยังมีคุณสมบัติที่ขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา.

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้มีความสามารถ AI ภายใน แต่รวมเข้ากับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต หน้าที่นี้ถูกเปิดเผยผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesaiagent/) เพื่อสื่อสารกับบริการ AI.

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/) ในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI.

Aspose.Slides จัดการการสื่อสาร, แยกวิเคราะห์การตอบกลับจาก AI, และแทรกเนื้อหาแปลอย่างฉลาดในขณะที่คงรูปแบบและการจัดวางสไลด์ต้นฉบับไว้.

{{% alert color="info" title="Note" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจะต้องสร้างบัญชีและระบุคีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราจะแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/) ในตัวพร้อมกับโมเดล [model](https://platform.openai.com/docs/models) ของ OpenAI ที่กำหนด.

```php
// โหลดงานนำเสนอเพื่อแปล.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // แปลงานนำเสนอเป็นภาษาญี่ปุ่น.
    $aiAgent->translate($presentation, "japanese");

    // บันทึกงานนำเสนอที่แปลเป็นไฟล์ PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/) ในตัวจะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — โดยส่วนใหญ่เพื่อกำหนดค่าที่สำคัญเช่นพร็อกซี, หรือใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) ที่แตกต่างเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า — คุณสามารถส่งอินสแตนซ์ `HttpURLConnection` ของคุณเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/).

```php
// สร้างและตั้งค่าล่วงหน้าอินสแตนซ์ HttpURLConnection ของคุณ (การตั้งค่า timeout แบบกำหนดเอง, การตั้งค่า proxy ฯลฯ).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// ส่งการเชื่อมต่อไปยังไคลเอนต์ AI.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **ตัวอย่าง Azure OpenAI**

คุณสามารถกำหนดค่าเครื่องแปลให้ใช้การปรับใช้ Azure OpenAI ของคุณด้วย [OpenAICompatibleWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

โค้ดนี้แสดงการแปลงานนำเสนอโดยใช้จุดปลาย Azure OpenAI ของคุณ แทนที่ค่าตัวแปรที่เป็น placeholder ด้วยชื่อการปรับใช้ของคุณ, คีย์ API, และ URL ของจุดปลาย.

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API มอบโซลูชันที่ขับเคลื่อนด้วย AI สำหรับการนำเสนอ PowerPoint หลายภาษา ด้วยการทำงานอัตโนมัติในการแปลพร้อมคงรูปแบบและการออกแบบไว้ ทำให้ประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา, นักการศึกษา หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ช่วยให้คุณสร้างงานนำเสนอที่ดึงดูดและปรับให้เป็นท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายการเข้าถึงและปรับปรุงการสื่อสาร.