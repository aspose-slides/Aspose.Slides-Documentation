---
title: Penerjemah Presentasi Berbasis AI
linktitle: Penerjemah AI
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
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk PHP. Lokalkan PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Coba sekarang."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatis. Selain membuat, menyunting, dan mengonversi slide, ia menawarkan fitur berbasis AI—seperti Presentation Translation API untuk konten slide multibahasa.

## **Cara Kerja**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi terintegrasi dengan model AI eksternal melalui internet. Fungsionalitas ini tersedia melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesaiagent/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan untuk terhubung ke API OpenAI.

Aspose.Slides mengelola komunikasi, mengurai respons AI, dan secara cerdas menyisipkan konten terjemahan sambil mempertahankan tata letak dan format slide asli.

{{% alert color="info" title="Note" %}}
Perhatikan bahwa API OpenAI adalah layanan berbayar, jadi Anda harus membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan.
{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke dalam bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan dengan [model](https://platform.openai.com/docs/models) OpenAI yang ditentukan.

```php
// Muat presentasi untuk diterjemahkan.
$presentation = new Presentation("sample.pptx");

// Buat klien AI dengan OpenAIWebClient, menentukan model dan kunci API Anda.
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

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya sendiri, menangani siklus hidupnya secara otomatis. Namun, jika Anda lebih memilih mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sendiri — terutama untuk mengonfigurasi pengaturan penting seperti proxy, atau untuk menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) yang berbeda demi pengelolaan sumber daya dan kinerja yang lebih baik — Anda dapat menyediakan instance `HttpURLConnection` milik Anda saat membangun [OpenAIWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaiwebclient/).

```php
// Buat dan pra-konfigurasikan instance HttpURLConnection Anda sendiri (timeout khusus, pengaturan proxy, dll.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Berikan koneksi ke klien AI.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Contoh Azure OpenAI**

Anda dapat mengonfigurasi penerjemah untuk menggunakan penyebaran Azure OpenAI Anda dengan [OpenAICompatibleWebClient](https://reference.aspose.com/slides/id/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Potongan kode ini memperlihatkan cara menerjemahkan presentasi menggunakan endpoint Azure OpenAI Anda. Ganti nilai placeholder dengan nama penyebaran, kunci API, dan URL endpoint Anda.

## **Manfaat Utama**

Aspose.Slides Presentation Translation API menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatiskan terjemahan sambil mempertahankan tata letak dan desain, API ini menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Baik Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global—memperluas jangkauan Anda dan meningkatkan komunikasi.