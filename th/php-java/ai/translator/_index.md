---
title: ตัวแปลการนำเสนอที่ขับเคลื่อนด้วย AI
linktitle: ตัวแปลที่ขับเคลื่อนด้วย AI
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
- ฟีเจอร์ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- ตัวแทน AI
- เว็บไคลเอนต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ PHP. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นขณะคงรูปแบบเดิม—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้งานดู."
---
## **บทนำ**

Aspose.Slides เป็น API ที่ทรงพลังสำหรับการจัดการการนำเสนอ PowerPoint ด้วยโปรแกรม. นอกจากการสร้าง, แก้ไข, และแปลงสไลด์แล้ว, มันยังมีฟีเจอร์ที่ขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา.

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ในตัว แต่ทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต. ฟังก์ชันนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesaiagent/) เพื่อสื่อสารกับบริการ AI.

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/) ที่มีในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI.

Aspose.Slides จัดการการสื่อสาร, วิเคราะห์การตอบกลับของ AI, และแทรกเนื้อหาที่แปลอย่างชาญฉลาดในขณะที่คงรูปแบบและการจัดวางสไลด์ต้นฉบับไว้.

{{% alert color="primary" %}}

โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน, ดังนั้นคุณจะต้องสร้างบัญชีและใส่คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/) ที่มีในตัว.

{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้, เราแปลการนำเสนอ PowerPoint ไปเป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/) ที่มีในตัวพร้อมกับ [โมเดล](https://platform.openai.com/docs/models) ของ OpenAI ที่ระบุ.

```php
// โหลดการนำเสนอเพื่อแปล.
$presentation = new Presentation("sample.pptx");

// สร้างไคลเอนท์ AI ด้วย OpenAIWebClient, ระบุโมเดลและคีย์ API ของคุณ.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนท์ AI.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // แปลการนำเสนอเป็นภาษาญี่ปุ่น.
    $aiAgent->translate($presentation, "japanese");

    // บันทึกการนำเสนอที่แปลเป็น PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

โดยค่าเริ่มต้น, [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/) ที่มีในตัวจะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตัวเอง, โดยอัตโนมัติ. อย่างไรก็ตาม, หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — ส่วนใหญ่เพื่อกำหนดการตั้งค่าที่สำคัญเช่นพร็อกซี่, หรือเพื่อใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) ที่แตกต่างเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า — คุณสามารถให้ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/php-java/aspose.slides/openaiwebclient/).

```php
// สมมติว่าคุณมีอินสแตนซ์ HttpURLConnection ที่กำหนดค่าล่วงหน้า (เช่น ตั้งค่า timeout ที่กำหนดเอง, การตั้งค่าพร็อกซี่, ฯลฯ)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API มอบโซลูชันที่ขับเคลื่อนด้วย AI สำหรับการส่งมอบการนำเสนอ PowerPoint แบบหลายภาษา. ด้วยการอัตโนมัติการแปลในขณะที่คงรูปแบบและการออกแบบไว้, มันช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำงานแบบมือ. ไม่ว่าคุณจะเป็นนักพัฒนา, ผู้สอน, หรือผู้เชี่ยวชาญด้านธุรกิจ, API นี้ทำให้คุณสร้างการนำเสนอที่น่าสนใจและปรับให้เป็นภาษาท้องถิ่นสำหรับผู้ชมทั่วโลก - ขยายการเข้าถึงของคุณและปรับปรุงการสื่อสาร.