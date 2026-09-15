---
title: Penerjemah Presentasi Berbasis AI
linktitle: Penerjemah Berbasis AI
type: docs
weight: 20
url: /id/net/ai/translator/
keywords:
- penerjemah presentasi AI
- penerjemah slide AI
- fitur berbasis AI
- presentasi multibahasa
- slide multibahasa
- terjemahan presentasi
- terjemahan slide
- fitur AI
- kemampuan AI
- agen AI
- klien Web
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk .NET. Lokalkan PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Coba sekarang."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatik. Selain membuat, mengedit, dan mengonversi slide, ia menawarkan fitur berbasis AI — seperti [Presentation Translation API](https://reference.aspose.com/slides/id/net/aspose.slides.ai/) untuk konten slide multibahasa.

## **Cara Kerjanya**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi terintegrasi dengan model AI eksternal melalui internet. Fungsionalitas ini diekspose melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/net/aspose.slides.ai/slidesaiagent) yang menggunakan implementasi antarmuka [IAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/iaiwebclient/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/) bawaan untuk terhubung ke API OpenAI atau mengimplementasikan [IAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/iaiwebclient/) Anda sendiri untuk memakai penyedia AI atau model bahasa lain.

Aspose.Slides menangani komunikasi, mengurai respons AI, dan secara cerdas menyisipkan konten terjemahan sambil mempertahankan tata letak serta format slide asli.

{{% alert color="info" title="Note" %}}
Catatan bahwa API OpenAI adalah layanan berbayar, jadi Anda harus membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke dalam bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/) bawaan dengan model OpenAI yang ditentukan.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Muat presentasi untuk diterjemahkan.
using var presentation = new Presentation("sample.pptx");

// Buat klien AI dengan OpenAIWebClient, menentukan model dan kunci API Anda.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Inisialisasi SlidesAIAgent dengan klien AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Terjemahkan presentasi ke bahasa Jepang.
await aiAgent.TranslateAsync(presentation, "japanese");

// Simpan presentasi yang diterjemahkan sebagai PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/) bawaan membuat dan mengelola instance [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) internalnya, menangani siklus hidup serta pembuangan secara otomatis. Namun, jika Anda lebih suka mengelola [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) sendiri — misalnya saat menggunakan [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) untuk pengelolaan sumber daya dan kinerja yang lebih baik — Anda dapat menyediakan instance `HttpClient` Anda sendiri saat membuat [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Gunakan HttpClient yang Anda kelola sendiri - misalnya, yang dibuat oleh IHttpClientFactory
// disuntikkan melalui dependency injection.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides biasanya digunakan dalam lingkungan sinkron. Untuk mendukung hal ini, kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/net/aspose.slides.ai/slidesaiagent/) menyediakan metode sinkron dan asinkron — memungkinkan Anda memilih pendekatan yang paling sesuai dengan alur kerja aplikasi Anda.

### **Contoh Azure OpenAI**

Aspose.Slides untuk .NET mendukung penyedia yang kompatibel dengan OpenAI, termasuk Azure OpenAI. Anda dapat mengonfigurasi penerjemah untuk menggunakan penyebaran Azure internal Anda dengan [OpenAICompatibleWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Cuplikan ini menunjukkan cara menerjemahkan presentasi menggunakan endpoint Azure OpenAI Anda. Ganti nilai placeholder dengan nama penyebaran, kunci API, dan URL endpoint Anda.

## **Manfaat Utama**

[Presentation Translation API](https://reference.aspose.com/slides/id/net/aspose.slides.ai/) Aspose.Slides menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatiskan terjemahan sambil mempertahankan tata letak dan desain, ia menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Baik Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global — memperluas jangkauan dan meningkatkan komunikasi.