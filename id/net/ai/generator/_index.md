---
title: Generator Slide Multibahasa Berbasis AI
linktitle: Generator Berbasis AI
type: docs
weight: 40
url: /id/net/ai/generator/
keywords:
- presentasi multibahasa
- slide multibahasa
- generator presentasi AI
- generator slide AI
- fitur berbasis AI
- agen AI
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat slide multibahasa dari teks dengan Aspose.Slides untuk .NET. Terapkan template Anda dan ekspor dek yang dipoles ke PowerPoint dan OpenDocument. Pelajari lebih lanjut."
---
## **Pengantar**

Aspose.Slides memperkenalkan fitur baru berbasis AI, Presentation Generator, yang memungkinkan pengembang secara otomatis membuat presentasi PowerPoint yang terstruktur dengan baik dari input teks sederhana seperti deskripsi topik, ringkasan, kutipan, atau poin-poin.

Pengguna dapat menyesuaikan tingkat detail konten dan secara opsional menerapkan template presentasi khusus untuk menentukan desain visual.

Saat ini, AI Presentation Generator menyusun konten menggunakan blok teks, daftar poin, dan tabel. Pembuatan gambar belum didukung; namun, gambar dapat dengan mudah ditambahkan kemudian menggunakan alat Aspose.Slides atau secara manual.

Outputnya adalah presentasi PowerPoint lengkap yang dapat digunakan apa adanya atau diekspor ke format apa pun yang didukung oleh API Aspose.Slides. Meskipun generator menghasilkan hasil berkualitas tinggi, penyuntingan kecil setelahnya mungkin diperlukan untuk memenuhi persyaratan tertentu.

## **Cara Kerjanya**

Aspose.Slides tidak menyertakan model AI bawaan; sebaliknya, ia mengintegrasikan dengan layanan AI eksternal melalui internet. Integrasi ini ditangani oleh kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/net/aspose.slides.ai/slidesaiagent/) yang menggunakan implementasi antarmuka [IAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/iaiwebclient/) untuk berkomunikasi dengan model AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/) bawaan, yang terhubung ke API OpenAI, atau menyediakan implementasi khusus dari [IAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/iaiwebclient/) untuk bekerja dengan penyedia AI lain atau model bahasa. Aspose.Slides mengelola semua komunikasi dengan layanan AI dan memproses respons AI untuk menghasilkan slide. Perlu dicatat bahwa API OpenAI adalah layanan berbayar, jadi akun dan kunci API diperlukan saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/) bawaan.

## **Mari Kode**

### **Contoh 1**

Contoh ini menunjukkan cara menghasilkan presentasi dengan topik Aspose.Slides menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/) bawaan.

```csharp
// Buat sebuah instance OpenAIWebClient, implementasi bawaan dari klien web OpenAI.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Buat sebuah instance SlidesAIAgent, yang menyediakan akses ke fitur berbasis AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Tentukan instruksi untuk menghasilkan presentasi.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Hasilkan presentasi dengan jumlah konten menengah berdasarkan instruksi.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Simpan presentasi yang dihasilkan ke disk lokal sebagai file PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Contoh 2**

Contoh berikut menunjukkan overload dari metode [GeneratePresentation](https://reference.aspose.com/slides/id/net/aspose.slides.ai/slidesaiagent/generatepresentation/). Dalam kasus ini, instance [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) yang dikelola secara eksternal dan `master presentation` pengguna digunakan.

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/) bawaan membuat dan mengelola instance [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) internalnya sendiri, menangani siklus hidup dan pembuangannya secara otomatis. Namun, jika Anda lebih suka mengelola [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) sendiri—misalnya, saat menggunakan [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) untuk peningkatan manajemen sumber daya dan kinerja—Anda dapat menyediakan instance [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) Anda saat membangun [OpenAIWebClient](https://reference.aspose.com/slides/id/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Buat sebuah instance HttpClient yang dikelola secara eksternal.
using var httpClient = new HttpClient();

// Lewatkan HttpClient ke konstruktor OpenAIWebClient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Buat sebuah instance SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Tentukan instruksi untuk menghasilkan presentasi.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Muat presentasi master dari disk lokal untuk digunakan sebagai template desain.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Hasilkan presentasi terperinci menggunakan instruksi dan template master.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Simpan presentasi yang dihasilkan sebagai PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Perlu dicatat bahwa banyak pelanggan menggunakan Aspose.Slides dalam konteks sinkron. Untuk mendukung hal ini, kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/net/aspose.slides.ai/slidesaiagent/) menyediakan metode sinkron dan asinkron, memungkinkan Anda memilih pendekatan yang paling sesuai dengan alur kerja aplikasi Anda.

## **Manfaat Utama**

AI Presentation Generator baru di Aspose.Slides menyediakan cara cepat dan fleksibel untuk menghasilkan dek slide terstruktur dari perintah teks sederhana. Dengan dukungan untuk template khusus, instance [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) yang dikelola secara eksternal, serta alur kerja sinkron dan asinkron, ia dapat diintegrasikan secara mulus ke dalam berbagai aplikasi.

Kasus penggunaan umum meliputi pembuatan presentasi pemasaran, materi pendidikan, laporan klien, dan dek slide internal. Meskipun pembuatan gambar belum didukung, alat ini sudah menawarkan fondasi yang kuat untuk otomatisasi pembuatan presentasi, dengan peningkatan lebih lanjut yang diharapkan di masa depan.