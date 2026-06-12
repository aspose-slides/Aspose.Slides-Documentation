---
title: Penerjemah Presentasi Berbasis AI
linktitle: Penerjemah Berbasis AI
type: docs
weight: 20
url: /id/androidjava/ai/translator/
keywords:
- penerjemah presentasi AI
- penerjemah slide AI
- fitur berbasis AI
- presentasi multibahasa
- slide multibahasa
- terjemahan presentasi
- terjemahan slide
- fitur yang digerakkan AI
- kemampuan AI
- agen AI
- klien web
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk Android melalui Java. Lokalisasi PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Coba sekarang."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatis. Selain membuat, mengedit, dan mengonversi slide, ia menawarkan fitur berbasis AI — seperti Presentation Translation API untuk konten slide multibahasa.

## **Cara Kerja**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi terintegrasi dengan model AI eksternal melalui internet. Fungsionalitas ini disajikan melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesaiagent/) yang menggunakan implementasi antarmuka [IAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaiwebclient/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/) bawaan untuk terhubung ke API OpenAI atau mengimplementasikan [IAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaiwebclient/) Anda sendiri untuk menggunakan penyedia AI atau model bahasa yang berbeda.

Aspose.Slides menangani komunikasi, mengurai respons AI, dan secara cerdas menyisipkan konten terjemahan sambil mempertahankan tata letak dan format slide asli.

{{% alert color="primary" %}}

Perhatikan bahwa API OpenAI adalah layanan berbayar, sehingga Anda perlu membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/) bawaan dengan [model](https://platform.openai.com/docs/models) OpenAI yang ditentukan.

```java
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

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya, menangani siklus hidupnya secara otomatis. Namun, jika Anda lebih suka mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sendiri — terutama untuk mengonfigurasi pengaturan penting seperti proxy, atau untuk menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) yang berbeda demi manajemen sumber daya dan kinerja yang lebih baik — Anda dapat menyediakan instance `HttpURLConnection` Anda sendiri saat membangun [OpenAIWebClient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/openaiwebclient/).

```java
// Anggap Anda memiliki instance HttpURLConnection yang telah dikonfigurasi sebelumnya (mis., dengan timeout khusus, pengaturan proxy, dll.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Manfaat Utama**

Presentation Translation API Aspose.Slides menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatisasi terjemahan sambil mempertahankan tata letak dan desain, API ini menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Baik Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global — memperluas jangkauan Anda dan meningkatkan komunikasi.