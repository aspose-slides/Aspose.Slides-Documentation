---
title: مترجم ارائه مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/androidjava/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- ویژگی مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- ویژگی‌های مبتنی بر هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Android از طریق Java ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که چیدمان حفظ می‌شود — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی مانند API ترجمه ارائه برای محتوای چندزبانه اسلایدها را ارائه می‌دهد.

## **چگونه کار می‌کند**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت ادغام می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesaiagent/) در دسترس است که از پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی برای اتصال به API شرکت OpenAI استفاده کنید یا پیاده‌سازی خودتان از [IAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaiwebclient/) را برای استفاده از ارائه‌دهنده یا مدل زبانی هوش مصنوعی دیگری پیاده‌سازی کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌صورت هوشمند محتویات ترجمه‌شده را درج می‌نماید در حالی که طرح‌بندی و قالب‌بندی اصلی اسلاید را حفظ می‌کند.

{{% alert color="info" %}}

توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را فراهم کنید.

{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را به زبان ژاپنی با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی و یک [مدل](https://platform.openai.com/docs/models) OpenAI مشخص ترجمه می‌کنیم.

```java
import com.aspose.slides.*;

// یک ارائه برای ترجمه بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با مشتری AI مقداردهی اولیه کنید.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ارائه را به ژاپنی ترجمه کنید.
    aiAgent.translate(presentation, "japanese");

    // ارائه ترجمه‌شده را به‌عنوان PDF ذخیره کنید.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی یک نمونه [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) داخلی خود را ایجاد و مدیریت می‌کند و چرخه حیات آن را به‌صورت خودکار کنترل می‌نماید. اما اگر مایل باشید که [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را خودتان مدیریت کنید — به‌خصوص برای پیکربندی تنظیمات ضروری مانند پروکسی، یا برای استفاده از یک [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای مدیریت منابع و عملکرد بهتر — می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/)، نمونه `HttpURLConnection` خود را ارائه دهید.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // یک نمونه HttpURLConnection را خودتان پیکربندی کنید (مثلاً با تنظیم زمان‌سنجی‌های سفارشی، تنظیمات پروکسی و غیره).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // اتصال را به سازنده OpenAIWebClient پاس دهید.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **فواید کلیدی**

API ترجمه ارائه Aspose.Slides یک راهکار مبتنی بر هوش مصنوعی برای ارائه PowerPointهای چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که طرح‌بندی و طراحی را حفظ می‌کند، زمان را صرفه‌جویی کرده و خطاها را نسبت به جریان‌های کاری دستی به حداقل می‌رساند. چه توسعه‌دهنده، معلم یا متخصص کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید — دسترسی خود را گسترش داده و ارتباطات را بهبود بخشید.