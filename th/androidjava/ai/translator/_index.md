---
title: ตัวแปลงานนำเสนอที่ขับเคลื่อนด้วย AI
linktitle: ตัวแปลที่ขับเคลื่อนด้วย AI
type: docs
weight: 20
url: /th/androidjava/ai/translator/
keywords:
- ตัวแปลงานนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- ฟีเจอร์ขับเคลื่อนด้วย AI
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลงานนำเสนอ
- การแปลสไลด์
- ฟีเจอร์ที่ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- เอเจนต์ AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นพร้อมคงรูปแบบเดิม—รวดเร็วและเป็นมิตรต่อผู้พัฒนา. ทดลองดู."
---
## **บทนำ**

Aspose.Slides เป็น API ที่ทรงพลังสำหรับการจัดการงานนำเสนอ PowerPoint อย่างอัตโนมัติ นอกจากการสร้าง, แก้ไข และแปลงสไลด์แล้ว ยังมีฟีเจอร์ที่ขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ภายใน แต่ทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ความสามารถนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidesaiagent/) ซึ่งใช้การทำงานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่รวมมาแล้วเพื่อเชื่อมต่อกับ API ของ OpenAI หรือสร้างการทำงานของคุณเองของ [IAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaiwebclient/) เพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่าง

Aspose.Slides จัดการการสื่อสาร, วิเคราะห์การตอบกลับของ AI, และแทรกเนื้อหาที่แปลอย่างชาญฉลาดโดยคงรูปแบบและการจัดวางสไลด์เดิมไว้

{{% alert color="info" %}}

โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจำเป็นต้องสร้างบัญชีและจัดเตรียมคีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/)

{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่รวมมาแล้วพร้อมระบุ OpenAI [โมเดล](https://platform.openai.com/docs/models)

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอเพื่อแปล.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // แปลงานนำเสนอเป็นภาษาญี่ปุ่น.
    aiAgent.translate(presentation, "japanese");

    // บันทึกงานนำเสนอที่แปลเป็นไฟล์ PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่รวมมาแล้วจะสร้างและจัดการอินสแตนซ์ของ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — ส่วนใหญ่เพื่อกำหนดค่าที่สำคัญเช่นพร็อกซี หรือเพื่อใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) ที่แตกต่างเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า — คุณสามารถให้อินสแตนซ์ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/)

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // กำหนดค่าอินสแตนซ์ HttpURLConnection ด้วยตนเอง (เช่น ตั้งค่า timeout ที่กำหนดเอง, การตั้งค่า proxy เป็นต้น).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // ส่งการเชื่อมต่อไปยังคอนสตรัคเตอร์ของ OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API นำเสนอวิธีแก้ปัญหาที่ใช้ AI เพื่อส่งมอบงานนำเสนอ PowerPoint หลายภาษา โดยอัตโนมัติการแปลพร้อมคงรูปแบบและการออกแบบเดิม ซึ่งช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา, นักการศึกษา, หรือผู้เชี่ยวชาญด้านธุรกิจ API นี้ทำให้คุณสามารถสร้างงานนำเสนอที่น่าสนใจและปรับให้เหมาะกับท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายขอบเขตการเข้าถึงและปรับปรุงการสื่อสาร