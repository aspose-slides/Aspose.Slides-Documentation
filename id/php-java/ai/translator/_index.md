---
title: Penerjemah Presentasi Berbasis AI
linktitle: Penerjemah Berbasis AI
type: docs
weight: 20
url: /id/php-java/ai/translator/
keywords:
- Penerjemah presentasi AI
- Penerjemah slide AI
- Fitur berbasis AI
- Presentasi multibahasa
- Slide multibahasa
- Terjemahan presentasi
- Terjemahan slide
- Fitur yang digerakkan AI
- Kapabilitas AI
- Agen AI
- Klien Web
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk PHP. Lokalisasi PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Coba sekarang."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatik. Selain membuat, mengedit, dan mengonversi slide, API ini menawarkan fitur berbasis AI — seperti Presentation Translation API untuk konten slide multibahasa.

## **Cara Kerjanya**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi terintegrasi dengan model AI eksternal melalui internet. Fungsionalitas ini tersedia melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesaiagent/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan untuk terhubung ke API OpenAI.

Aspose.Slides menangani komunikasi, menguraikan respons AI, dan secara cerdas menyisipkan konten terjemahan sambil mempertahankan tata letak dan format slide asli.

{{% alert color="primary" %}}

Perhatikan bahwa API OpenAI adalah layanan berbayar, jadi Anda perlu membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan.

{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke dalam bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan dengan [model](https://platform.openai.com/docs/models) OpenAI yang ditentukan.

```php
// Muat presentasi untuk diterjemahkan.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inisialisasi SlidesAIAgent dengan klien AI.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Terjemahkan presentasi ke bahasa Jepang.
    $aiAgent->translate($presentation, "japanese");

    // Simpan presentasi yang diterjemahkan sebagai PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instansi [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya sendiri, menangani siklus hidupnya secara otomatis. Namun, jika Anda lebih memilih mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sendiri — terutama untuk mengonfigurasi pengaturan penting seperti proxy, atau menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) yang berbeda untuk manajemen sumber daya dan kinerja yang lebih baik — Anda dapat menyediakan instansi `HttpURLConnection` milik Anda sendiri saat membangun [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/).

```php
// Asumsikan Anda memiliki instance HttpURLConnection yang telah dikonfigurasi sebelumnya (misalnya, dengan batas waktu khusus, pengaturan proxy, dll.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Manfaat Utama**

API Presentation Translation Aspose.Slides menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatisasi terjemahan sambil mempertahankan tata letak dan desain, API ini menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Baik Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global — memperluas jangkauan Anda dan meningkatkan komunikasi.