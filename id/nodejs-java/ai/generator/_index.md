---
title: Generator Slide Multibahasa Berbasis AI
linktitle: Generator Berbasis AI
type: docs
weight: 40
url: /id/nodejs-java/ai/generator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Hasilkan slide multibahasa dari teks dengan Aspose.Slides untuk Node.js. Terapkan templat Anda dan ekspor deck yang terpolitur ke PowerPoint dan OpenDocument. Pelajari lebih lanjut."
---
## **Pendahuluan**

Aspose.Slides memperkenalkan fitur baru yang didukung AI, yaitu Presentation Generator, yang memungkinkan pengembang untuk secara otomatis membuat presentasi PowerPoint yang terstruktur dengan baik dari input teks sederhana seperti deskripsi topik, ringkasan, kutipan, atau poin-poin.

Pengguna dapat menyesuaikan tingkat detail konten dan secara opsional menerapkan templat presentasi khusus untuk menentukan desain visual.

Saat ini, AI Presentation Generator menyusun konten menggunakan blok teks, daftar poin, dan tabel. Pembuatan gambar belum didukung; namun, gambar dapat dengan mudah ditambahkan kemudian menggunakan alat Aspose.Slides atau secara manual.

Outputnya adalah presentasi PowerPoint lengkap yang dapat digunakan apa adanya atau diekspor ke format apa pun yang didukung oleh API Aspose.Slides. Meskipun generator menghasilkan hasil berkualitas tinggi, sedikit penyuntingan lanjutan mungkin diperlukan untuk memenuhi persyaratan tertentu.

## **Cara Kerja**

Aspose.Slides tidak menyertakan model AI bawaan; sebaliknya, ia terintegrasi dengan layanan AI eksternal melalui internet. Integrasi ini ditangani oleh kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesaiagent/).

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan, yang terhubung ke API OpenAI. Aspose.Slides mengelola semua komunikasi dengan layanan AI dan memproses respons AI untuk menghasilkan slide. Perlu dicatat bahwa API OpenAI adalah layanan berbayar, sehingga akun dan kunci API diperlukan saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan.

## **Mari Menulis Kode**

### **Contoh 1**

Contoh ini menunjukkan cara menghasilkan presentasi tentang topik Aspose.Slides menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan.

```js
// Buat instance OpenAIWebClient, implementasi bawaan klien web OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Buat instance SlidesAIAgent, yang menyediakan akses ke fitur berbasis AI.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Tentukan instruksi untuk menghasilkan presentasi.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Hasilkan presentasi dengan jumlah konten sedang berdasarkan instruksi.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Simpan presentasi yang dihasilkan ke disk lokal sebagai file PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Contoh 2**

Contoh berikut menunjukkan overload dari metode [generatePresentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). Dalam kasus ini, sebuah instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) yang dikelola secara eksternal dan `master presentation` pengguna digunakan.

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya sendiri, menangani siklus hidupnya secara otomatis. Namun, jika Anda lebih suka mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sendiri—misalnya, saat menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) untuk peningkatan manajemen sumber daya dan kinerja—Anda dapat menyediakan instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) milik Anda saat membuat [OpenAIWebClient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Berikan HttpURLConnection ke konstruktor OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Buat instance SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Tentukan instruksi untuk menghasilkan presentasi.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Muat presentasi master dari disk lokal untuk digunakan sebagai templat desain.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Hasilkan presentasi detail menggunakan instruksi dan templat master.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Simpan presentasi yang dihasilkan sebagai PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Manfaat Utama**

AI Presentation Generator baru di Aspose.Slides memberikan cara yang cepat dan fleksibel untuk menghasilkan deck slide terstruktur dari prompt teks sederhana. Dengan dukungan untuk templat khusus dan instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) yang dikelola secara eksternal, ia dapat terintegrasi secara mulus ke dalam beragam aplikasi.

Kasus penggunaan umum meliputi pembuatan presentasi pemasaran, materi edukasi, laporan klien, dan deck slide internal. Meskipun pembuatan gambar belum didukung, alat ini sudah menawarkan fondasi yang kuat untuk mengotomatisasi pembuatan presentasi, dengan peningkatan lebih lanjut yang diharapkan di masa mendatang.