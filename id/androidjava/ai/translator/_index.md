---
title: Penerjemah Presentasi Bertenaga AI
linktitle: Penerjemah Bertenaga AI
type: docs
weight: 20
url: /id/androidjava/ai/translator/
keywords:
- penerjemah presentasi AI
- penerjemah slide AI
- fitur bertenaga AI
- presentasi multibahasa
- slide multibahasa
- penerjemahan presentasi
- penerjemahan slide
- fitur berbasis AI
- kemampuan AI
- agen AI
- klien web
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk Android via Java. Lokalisisasi PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Coba sekarang."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatis. Selain membuat, mengedit, dan mengonversi slide, ia menawarkan fitur berbasis AI - seperti Presentation Translation API untuk konten slide multibahasa.

## **Cara Kerja**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi mengintegrasikan dengan model AI eksternal melalui internet. Fungsionalitas ini diekspos melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesaiagent/), yang menggunakan implementasi antarmuka [IAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaiwebclient/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/) bawaan untuk terhubung ke API OpenAI atau mengimplementasikan [IAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaiwebclient/) milik Anda sendiri untuk menggunakan penyedia AI atau model bahasa yang berbeda.

Aspose.Slides menangani komunikasi, mengurai respons AI, dan secara cerdas memasukkan konten yang diterjemahkan sambil mempertahankan tata letak dan format slide asli.

{{% alert color="info" title="Note" %}}
Perlu diingat bahwa API OpenAI adalah layanan berbayar, jadi Anda harus membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/) bawaan.
{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke dalam bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/) bawaan dengan [model](https://platform.openai.com/docs/models) OpenAI yang ditentukan.

```java
import com.aspose.slides.*;

// Muat presentasi untuk diterjemahkan.
Presentation presentation = new Presentation("sample.pptx");

// Buat klien AI dengan OpenAIWebClient, menentukan model dan kunci API Anda.
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

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya sendiri, menangani siklus hidupnya secara otomatis. Namun, jika Anda lebih memilih mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) secara manual — terutama untuk mengonfigurasi pengaturan penting seperti proxy, atau menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) yang berbeda untuk manajemen sumber daya dan kinerja yang lebih baik — Anda dapat menyediakan instance `HttpURLConnection` milik Anda sendiri saat membangun [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Konfigurasikan instance HttpURLConnection secara manual (misalnya, dengan batas waktu khusus, pengaturan proxy, dll.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Berikan koneksi ke konstruktor OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Contoh Azure OpenAI**

Anda dapat mengonfigurasi penerjemah untuk menggunakan penyebaran Azure OpenAI Anda dengan [OpenAICompatibleWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaicompatiblewebclient/).

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

Cuplikan kode ini menunjukkan cara menerjemahkan presentasi menggunakan endpoint Azure OpenAI Anda. Ganti nilai placeholder dengan nama penyebaran, kunci API, dan URL endpoint Anda.

## **Manfaat Utama**

Aspose.Slides Presentation Translation API menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatisasi terjemahan sambil mempertahankan tata letak dan desain, API ini menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Apakah Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global — memperluas jangkauan Anda dan meningkatkan komunikasi.