---
title: Generator Slide Multibahasa Berbasis AI
linktitle: Generator Berbasis AI
type: docs
weight: 40
url: /id/java/ai/generator/
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
- Java
- Aspose.Slides
description: "Hasilkan slide multibahasa dari teks dengan Aspose.Slides untuk Java. Terapkan templat Anda dan ekspor dek yang dipoles ke PowerPoint dan OpenDocument. Pelajari lebih lanjut."
---
## **Pendahuluan**

Aspose.Slides memperkenalkan fitur baru berbasis AI, yaitu Presentation Generator, yang memungkinkan pengembang untuk secara otomatis membuat presentasi PowerPoint yang terstruktur dengan baik dari masukan teks sederhana seperti deskripsi topik, ringkasan, kutipan, atau poin-poin bullet.

Pengguna dapat menyesuaikan tingkat detail konten dan secara opsional menerapkan templat presentasi khusus untuk menentukan desain visual.

Saat ini, AI Presentation Generator menyusun konten menggunakan blok teks, daftar bullet, dan tabel. Pembuatan gambar belum didukung; namun, gambar dapat dengan mudah ditambahkan kemudian menggunakan alat Aspose.Slides atau secara manual.

Outputnya adalah presentasi PowerPoint lengkap yang dapat digunakan langsung atau diekspor ke format apa pun yang didukung oleh API Aspose.Slides. Meskipun generator menghasilkan hasil berkualitas tinggi, penyuntingan ringan setelahnya mungkin diperlukan untuk memenuhi persyaratan tertentu.

## **Cara Kerja**

Aspose.Slides tidak menyertakan model AI bawaan; melainkan, ia mengintegrasikan dengan layanan AI eksternal melalui internet. Integrasi ini ditangani oleh kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidesaiagent/) yang menggunakan implementasi dari antarmuka [IAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaiwebclient/) untuk berkomunikasi dengan model AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan, yang terhubung ke API OpenAI, atau menyediakan implementasi khusus dari [IAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaiwebclient/) untuk bekerja dengan penyedia AI lain atau model bahasa. Aspose.Slides mengelola semua komunikasi dengan layanan AI dan memproses respons AI untuk menghasilkan slide. Perlu dicatat bahwa API OpenAI adalah layanan berbayar, sehingga akun dan kunci API diperlukan saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan.

## **Mari Kode**

### **Contoh 1**

Contoh ini menunjukkan cara menghasilkan presentasi tentang topik Aspose.Slides menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan.

```java
// Buat sebuah instance OpenAIWebClient, implementasi bawaan dari klien web OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Buat sebuah instance SlidesAIAgent, yang menyediakan akses ke fitur berbasis AI.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Tentukan instruksi untuk menghasilkan presentasi.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Hasilkan presentasi dengan jumlah konten sedang berdasarkan instruksi.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Simpan presentasi yang dihasilkan ke disk lokal sebagai file PowerPoint (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Contoh 2**

Contoh berikut menunjukkan overload dari metode [generatePresentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). Dalam kasus ini, sebuah instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) yang dikelola secara eksternal dan `master presentation` milik pengguna digunakan.

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/) bawaan membuat dan mengelola instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) internalnya sendiri, mengatur siklus hidupnya secara otomatis. Namun, jika Anda lebih suka mengelola [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sendiri—misalnya, saat menggunakan [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) atau [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) untuk peningkatan manajemen sumber daya dan kinerja—Anda dapat menyediakan instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) Anda sendiri saat mengkonstruksi [OpenAIWebClient](https://reference.aspose.com/slides/id/java/com.aspose.slides/openaiwebclient/).

```java
// Berikan HttpURLConnection ke konstruktor OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Buat sebuah instance SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Tentukan instruksi untuk menghasilkan presentasi.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Muat presentasi master dari disk lokal untuk digunakan sebagai templat desain.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Hasilkan presentasi detail menggunakan instruksi dan templat master.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Simpan presentasi yang dihasilkan sebagai PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Manfaat Utama**

AI Presentation Generator baru di Aspose.Slides menyediakan cara cepat dan fleksibel untuk menghasilkan dek slide terstruktur dari prompt teks sederhana. Dengan dukungan untuk templat khusus dan instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) yang dikelola secara eksternal, ia dapat terintegrasi mulus ke dalam berbagai aplikasi.

Use case umum meliputi pembuatan presentasi pemasaran, materi edukasi, laporan klien, dan dek slide internal. Meskipun pembuatan gambar belum didukung, alat ini sudah menawarkan fondasi yang kuat untuk mengotomatiskan pembuatan presentasi, dengan peningkatan lebih lanjut yang diharapkan di masa depan.