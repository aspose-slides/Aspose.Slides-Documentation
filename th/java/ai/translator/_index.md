---
title: เครื่องมือแปลงานนำเสนอแบบใช้ AI
linktitle: เครื่องมือแปลแบบใช้ AI
type: docs
weight: 20
url: /th/java/ai/translator/
keywords:
- เครื่องมือแปลงานนำเสนอด้วย AI
- เครื่องมือแปลสไลด์ด้วย AI
- ฟีเจอร์ขับเคลื่อนด้วย AI
- งานนำเสนอหลายภาษา
- สไลด์หลายภาษา
- การแปลงานนำเสนอ
- การแปลสไลด์
- คุณลักษณะขับเคลื่อนด้วย AI
- ความสามารถของ AI
- เอเจนต์ AI
- ไคลเอนต์เว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Java. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นพร้อมคงเลย์เอาต์—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้งานเลย."
---
## **บทนำ**

Aspose.Slides เป็น API ที่มีประสิทธิภาพสำหรับการจัดการงานนำเสนอ PowerPoint ผ่านโปรแกรม นอกจากการสร้าง, แก้ไข, และแปลงสไลด์แล้ว ยังมีคุณลักษณะขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ไว้ในตัว แต่ทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ความสามารถนี้เปิดให้ใช้ผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesaiagent/) ซึ่งใช้การนำไปใช้ของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่มาพร้อมให้เชื่อมต่อกับ API ของ OpenAI หรือทำการนำไปใช้ของ [IAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaiwebclient/) ของคุณเองเพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาที่แตกต่างกัน

Aspose.Slides จะจัดการการสื่อสาร, แยกวิเคราะห์การตอบกลับจาก AI, และแทรกเนื้อหาที่แปลแล้วอย่างฉลาดโดยคงรูปแบบและการจัดหน้าสไลด์เดิมไว้

{{% alert color="info" title="Note" %}}

โปรดทราบว่า API ของ OpenAI เป็นบริการที่ต้องเสียค่าใช้จ่าย ดังนั้นคุณจะต้องสร้างบัญชีและใส่คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/)

{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราจะแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) ที่มาพร้อมพร้อมระบุ [model](https://platform.openai.com/docs/models) ของ OpenAI

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

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/) จะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง—เช่นเพื่อกำหนดค่าพร็อกซี่, หรือใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) ที่แตกต่างเพื่อการจัดการทรัพยากรและประสิทธิภาพที่ดีกว่า—คุณสามารถส่งอินสแตนซ์ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaiwebclient/)

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// กำหนดค่าอินสแตนซ์ HttpURLConnection ด้วยตนเอง (ตั้งค่า timeout ที่กำหนดเอง, การตั้งค่าพร็อกซี ฯลฯ).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **ตัวอย่าง Azure OpenAI**

คุณสามารถกำหนดค่าเครื่องแปลให้ใช้การปรับใช้ Azure OpenAI ของคุณด้วย [OpenAICompatibleWebClient](https://reference.aspose.com/slides/th/java/com.aspose.slides/openaicompatiblewebclient/)

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

โค้ดสั้นนี้จะแสดงการแปลงานนำเสนอโดยใช้จุดสิ้นสุด Azure OpenAI ของคุณ แทนค่าตัวแปรตายตัวด้วยชื่อการปรับใช้, คีย์ API, และ URL ของจุดสิ้นสุดของคุณ

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API ให้โซลูชันที่ขับเคลื่อนด้วย AI สำหรับการส่งมอบงานนำเสนอ PowerPoint หลายภาษา โดยอัตโนมัติการแปลพร้อมคงรูปแบบและการออกแบบไว้ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา, ครูผู้สอน, หรือผู้ประกอบการธุรกิจ API นี้จะทำให้คุณสร้างงานนำเสนอที่ดึงดูดและเป็นภาษาท้องถิ่นสำหรับผู้ชมทั่วโลก เพิ่มขอบเขตการเข้าถึงและปรับปรุงการสื่อสารของคุณ