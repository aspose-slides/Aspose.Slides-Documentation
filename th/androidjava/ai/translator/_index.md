---
title: ตัวแปลงานนำเสนอด้วย AI
linktitle: ตัวแปลด้วย AI
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
- ฟีเจอร์ขับเคลื่อนด้วย AI
- ความสามารถของ AI
- เอเย่นต์ AI
- ไคลเอ็นต์เว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลสไลด์ PowerPoint ด้วย AI โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. ทำให้ PPT, PPTX และ ODP เป็นภาษาท้องถิ่นโดยคงรูปแบบเดิม—เร็วและเป็นมิตรต่อผู้พัฒนา. ลองใช้งาน."
---
## **บทนำ**

Aspose.Slides เป็น API ที่มีประสิทธิภาพสำหรับการจัดการงานนำเสนอ PowerPoint ด้วยโปรแกรม นอกจากนี้ยังสามารถสร้าง แก้ไข และแปลงสไลด์ได้ อีกทั้งยังมีฟีเจอร์ขับเคลื่อนด้วย AI เช่น Presentation Translation API สำหรับเนื้อหาสไลด์หลายภาษา

## **วิธีการทำงาน**

Aspose.Slides ไม่ได้รวมความสามารถ AI ภายใน แต่ทำการเชื่อมต่อกับโมเดล AI ภายนอกผ่านอินเทอร์เน็ต ฟังก์ชันนี้เปิดให้ใช้งานผ่านคลาส [SlidesAIAgent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidesaiagent/) ซึ่งใช้การทำงานของอินเทอร์เฟซ [IAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaiwebclient/) เพื่อสื่อสารกับบริการ AI

คุณสามารถใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ในตัวเพื่อเชื่อมต่อกับ API ของ OpenAI หรือสร้างการนำเข้าเองของ [IAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaiwebclient/) เพื่อใช้ผู้ให้บริการ AI หรือโมเดลภาษาต่างๆ

Aspose.Slides จัดการการสื่อสาร วิเคราะห์การตอบกลับของ AI และแทรกเนื้อหาที่แปลอย่างชาญฉลาดในขณะที่คงรูปแบบและการจัดวางสไลด์เดิมไว้

{{% alert color="info" title="Note" %}}
หมายเหตุว่า API ของ OpenAI เป็นบริการที่ต้องชำระเงิน ดังนั้นคุณจึงต้องสร้างบัญชีและใส่คีย์ API ของคุณเมื่อใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **ตัวอย่าง**

ในตัวอย่างนี้ เราแปลงานนำเสนอ PowerPoint เป็นภาษาญี่ปุ่นโดยใช้ [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ที่มีอยู่พร้อมกับระบุ OpenAI [โมเดล](https://platform.openai.com/docs/models)

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

    // บันทึกงานนำเสนอที่แปลเป็น PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

โดยค่าเริ่มต้น [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) จะสร้างและจัดการอินสแตนซ์ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ภายในของตนเองโดยอัตโนมัติ อย่างไรก็ตาม หากคุณต้องการจัดการ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ด้วยตนเอง — โดยส่วนใหญ่เพื่อกำหนดค่าตั้งค่าที่สำคัญเช่นพร็อกซี หรือเพื่อใช้ [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) หรือ [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) ที่แตกต่างสำหรับการจัดการทรัพยากรและประสิทธิภาพที่ดีขึ้น — คุณสามารถให้อินสแตนซ์ `HttpURLConnection` ของคุณเองเมื่อสร้าง [OpenAIWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaiwebclient/) ได้

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // กำหนดค่าอินสแตนซ์ HttpURLConnection ด้วยตนเอง (เช่น ตั้งค่า timeout ที่กำหนดเอง, การตั้งค่าพร็อกซี, ฯลฯ).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // ส่งการเชื่อมต่อไปยังคอนสตรัคเตอร์ของ OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **ตัวอย่าง Azure OpenAI**

คุณสามารถกำหนดค่าตัวแปลเพื่อใช้การปรับใช้ Azure OpenAI ของคุณด้วย [OpenAICompatibleWebClient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/openaicompatiblewebclient/)

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

โค้ดสั้นนี้แสดงการแปลงานนำเสนอโดยใช้จุดสิ้นสุด Azure OpenAI ของคุณ แทนที่ค่าตัวแปรตั๋วด้วยชื่อการปรับใช้ คีย์ API และ URL จุดสิ้นสุดของคุณ

## **ประโยชน์หลัก**

Aspose.Slides Presentation Translation API ให้โซลูชันที่ขับเคลื่อนด้วย AI สำหรับการจัดทำงานนำเสนอ PowerPoint หลากหลายภาษา โดยการทำการแปลโดยอัตโนมัติในขณะที่คงการจัดวางและการออกแบบไว้ ช่วยประหยัดเวลาและลดข้อผิดพลาดเมื่อเทียบกับกระบวนการทำงานด้วยมือ ไม่ว่าคุณจะเป็นนักพัฒนา นักการศึกษา หรือมืออาชีพด้านธุรกิจ API นี้ทำให้คุณสร้างงานนำเสนอที่ดึงดูดและท้องถิ่นสำหรับผู้ชมทั่วโลก เพิ่มขอบเขตการเข้าถึงและปรับปรุงการสื่อสาร