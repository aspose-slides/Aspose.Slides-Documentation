---
title: Penerjemah Presentasi Berbasis AI
linktitle: Penerjemah Berbasis AI
type: docs
weight: 20
url: /id/java/ai/translator/
keywords:
- penerjemah presentasi AI
- penerjemah slide AI
- fitur berbasis AI
- presentasi multibahasa
- slide multibahasa
- terjemahan presentasi
- terjemahan slide
- fitur yang didorong AI
- kemampuan AI
- agen AI
- klien web
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk Java. Lokalisasi PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Cobalah."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatis. Selain membuat, mengedit, dan mengonversi slide, API ini menawarkan fitur berbasis AI - seperti Presentation Translation API untuk konten slide multibahasa.

## **Cara Kerja**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi terintegrasi dengan model AI eksternal melalui internet. Fungsionalitas ini tersedia melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidesaiagent/) yang menggunakan implementasi antarmuka [IAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaiwebclient/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan untuk terhubung ke API OpenAI atau mengimplementasikan [IAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaiwebclient/) Anda sendiri untuk menggunakan penyedia AI atau model bahasa lain.

Aspose.Slides menangani komunikasi, menganalisis respons AI, dan secara cerdas menyisipkan konten terjemahan sambil mempertahankan tata letak dan format slide asli.

{{% alert color="info" title="Note" %}}

Perhatikan bahwa API OpenAI adalah layanan berbayar, jadi Anda harus membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan.

{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke dalam bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan dengan [model](https://platform.openai.com/docs/models) OpenAI tertentu.

```java
import com.aspose.slides.*;

// Muat presentasi untuk diterjemahkan.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inisialisasi SlidesAIAgent dengan klien AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Terjemahkan presentasi ke bahasa Jepang.
    aiAgent.translate(presentation, "japanese");

    // Simpan presentasi yang diterjemahkan sebagai PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya sendiri, menangani siklus hidupnya secara otomatis. Namun, jika Anda lebih suka mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sendiri — terutama untuk mengonfigurasi pengaturan penting seperti proxy, atau menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) yang berbeda untuk pengelolaan sumber daya dan kinerja yang lebih baik — Anda dapat menyediakan instance `HttpURLConnection` milik Anda saat membuat [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Konfigurasikan instance HttpURLConnection sendiri (timeout khusus, pengaturan proxy, dll).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Contoh Azure OpenAI**

Anda dapat mengonfigurasi penerjemah untuk menggunakan penyebaran Azure OpenAI Anda dengan [OpenAICompatibleWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaicompatiblewebclient/).

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

Potongan kode ini memperlihatkan cara menerjemahkan presentasi menggunakan endpoint Azure OpenAI Anda. Ganti nilai placeholder dengan nama penyebaran, kunci API, dan URL endpoint Anda.

## **Manfaat Utama**

Aspose.Slides Presentation Translation API menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatiskan terjemahan sambil mempertahankan tata letak dan desain, API ini menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Baik Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global — memperluas jangkauan Anda dan meningkatkan komunikasi.