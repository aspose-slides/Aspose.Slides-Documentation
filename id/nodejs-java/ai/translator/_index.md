---
title: Penerjemah Presentasi Bertenaga AI
linktitle: Penerjemah Bertenaga AI
type: docs
weight: 20
url: /id/nodejs-java/ai/translator/
keywords:
- Penerjemah presentasi AI
- Penerjemah slide AI
- Fitur bertenaga AI
- Presentasi multibahasa
- Slide multibahasa
- Terjemahan presentasi
- Terjemahan slide
- Fitur berbasis AI
- Kemampuan AI
- Agen AI
- Klien web
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk Node.js. Lokalkan PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Cobalah."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatik. Selain membuat, mengedit, dan mengonversi slide, API ini menawarkan fitur berbasis AI - seperti Presentation Translation API untuk konten slide multibahasa.

## **Cara Kerja**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi terintegrasi dengan model AI eksternal melalui internet. Fungsionalitas ini diekspos melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesaiagent/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan untuk terhubung ke API OpenAI.

Aspose.Slides menangani komunikasi, mengurai respons AI, dan secara cerdas menyisipkan konten terjemahan sambil mempertahankan tata letak dan format slide asli.

{{% alert color="info" title="Catatan" %}}
Perlu diingat bahwa API OpenAI adalah layanan berbayar, jadi Anda harus membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan.
{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke dalam bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan dengan [model](https://platform.openai.com/docs/models) OpenAI yang telah ditentukan.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Muat presentasi untuk diterjemahkan.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Buat klien AI dengan OpenAIWebClient, menentukan model dan kunci API Anda.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inisialisasi SlidesAIAgent dengan klien AI.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Terjemahkan presentasi ke bahasa Jepang.
    aiAgent.translate(presentation, "japanese");

    // Simpan presentasi yang diterjemahkan sebagai PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya sendiri, menangani siklus hidupnya secara otomatis. Namun, jika Anda lebih suka mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) secara manual — terutama untuk mengonfigurasi pengaturan penting seperti proxy, atau menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) yang berbeda untuk manajemen sumber daya dan kinerja yang lebih baik — Anda dapat menyediakan instance `HttpURLConnection` milik Anda sendiri saat membangun [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Buat dan pra-konfigurasikan sebuah instance HttpURLConnection (misalnya, dengan batas waktu khusus, pengaturan proxy, dll.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Contoh Azure OpenAI**

Anda dapat mengonfigurasi penerjemah untuk menggunakan penyebaran Azure OpenAI Anda dengan [OpenAICompatibleWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Cuplikan ini memperlihatkan cara menerjemahkan sebuah presentasi menggunakan endpoint Azure OpenAI Anda. Ganti nilai placeholder dengan nama penyebaran, kunci API, dan URL endpoint Anda.

## **Manfaat Utama**

Aspose.Slides Presentation Translation API menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatisasi terjemahan sambil mempertahankan tata letak dan desain, API ini menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Baik Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global — memperluas jangkauan Anda dan meningkatkan komunikasi.