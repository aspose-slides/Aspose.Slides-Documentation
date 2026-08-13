---
title: ตัวแปลการนำเสนอด้วย AI
linktitle: ตัวแปลที่ใช้ AI
type: docs
weight: 20
url: /th/java/ai/translator/
keywords:
- ตัวแปลการนำเสนอด้วย AI
- ตัวแปลสไลด์ด้วย AI
- คุณลักษณะที่ใช้ AI
- การนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลการนำเสนอ
- การแปลสไลด์
- คุณลักษณะขับเคลื่อนด้วย AI
- ความสามารถของ AI
- เอเจนต์ AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Java. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นพร้อมคงรูปแบบเดิม—เร็วและเป็นมิตรต่อผู้พัฒนา. ทดลองใช้งาน."
---
## **บทนำ**

Aspose.Slides เป็น API ที่มีประสิทธิภาพสำหรับการจัดการไฟล์นำเสนอ PowerPoint อย่างโปรแกรมเมติก นอกเหนือจากการสร้าง แก้ไข และแปลงสไลด์แล้ว ยังมีฟีเจอร์ที่ใช้ AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้มีความสามารถ AI ในตัว แต่รวมเข้ากับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ความสามารถนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesaiagent/) ซึ่งใช้การนำไปใช้งานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่มาพร้อมเพื่อเชื่อมต่อกับ API ของ OpenAI หรือทำการนำไปใช้ของคุณเองของ [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) เพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่าง

Aspose.Slides จะจัดการการสื่อสาร แยกวิเคราะห์การตอบกลับของ AI และแทรกเนื้อหาที่แปลอย่างชาญฉลาดโดยคงรูปแบบและการจัดวางสไลด์เดิมไว้

{{% alert color="info" %}}
โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจะต้องสร้างบัญชีและใส่คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/)
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราจะแปลไฟล์นำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) พร้อมกับ [model](https://platform.openai.com/docs/models) ของ OpenAI ที่ระบุ

```java
import com.aspose.slides.*;

// โหลดการนำเสนอเพื่อแปล.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // เริ่มต้น SlidesAIAgent ด้วยไคลเอนต์ AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // แปลการนำเสนอเป็นภาษาญี่ปุ่น.
    aiAgent.translate(presentation, "japanese");

    // บันทึกการนำเสนอที่แปลเป็น PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่มาพร้อมจะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — ส่วนใหญ่เพื่อกำหนดค่าที่สำคัญเช่นพร็อกซี หรือเพื่อใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) อื่นเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า — คุณสามารถให้ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/)

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// กำหนดค่าอินสแตนซ์ HttpURLConnection ด้วยตนเอง (การตั้งค่า timeout, การตั้งค่าพร็อกซี ฯลฯ).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API นำเสนอวิธีแก้ปัญหาที่ขับเคลื่อนด้วย AI สำหรับการส่งมอบไฟล์นำเสนอ PowerPoint หลายภาษา โดยการทำการแปลอัตโนมัติพร้อมคงการจัดวางและการออกแบบไว้ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำด้วยตนเอง ไม่ว่าคุณจะเป็นนักพัฒนา ผู้สอน หรือมืออาชีพด้านธุรกิจ API นี้ทำให้คุณสร้างการนำเสนอที่ดึงดูดและเป็นภาษาท้องถิ่นสำหรับผู้ชมทั่วโลก — ขยายขอบเขตการเข้าถึงและปรับปรุงการสื่อสาร