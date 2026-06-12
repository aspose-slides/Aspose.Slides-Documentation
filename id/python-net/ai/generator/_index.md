---
title: Generator Slide Multibahasa Berbasis AI
linktitle: Generator Berbasis AI
type: docs
weight: 40
url: /id/python-net/ai/generator/
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
- Python
- Aspose.Slides
description: "Hasilkan slide multibahasa dari teks menggunakan Aspose.Slides untuk Python. Terapkan templat Anda dan ekspor deck yang dipoles ke PowerPoint dan OpenDocument. Pelajari lebih lanjut."
---
## **Pendahuluan**

Aspose.Slides memperkenalkan fitur baru berbasis AI, Presentation Generator, yang memungkinkan pengembang secara otomatis membuat presentasi PowerPoint yang terstruktur dengan baik dari masukan teks sederhana seperti deskripsi topik, ringkasan, kutipan, atau poin-poin.

Pengguna dapat menyesuaikan tingkat detail konten dan secara opsional menerapkan templat presentasi khusus untuk menentukan desain visual.

Saat ini, AI Presentation Generator menyusun konten menggunakan blok teks, daftar poin, dan tabel. Generasi gambar belum didukung; namun, gambar dapat dengan mudah ditambahkan setelahnya menggunakan alat Aspose.Slides atau secara manual.

Outputnya adalah presentasi PowerPoint lengkap yang dapat digunakan apa adanya atau diekspor ke format apa pun yang didukung oleh API Aspose.Slides. Meskipun generator menghasilkan hasil berkualitas tinggi, penyuntingan kecil pasca-pembuatan mungkin diperlukan untuk memenuhi persyaratan spesifik.

## **Cara Kerja**

Aspose.Slides tidak menyertakan model AI bawaan; sebaliknya, ia terintegrasi dengan layanan AI eksternal melalui internet. Integrasi ini ditangani oleh kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/slidesaiagent/) yang menggunakan implementasi kelas [IAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/iaiwebclient/) untuk berkomunikasi dengan model AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/openaiwebclient/) bawaan, yang terhubung ke API OpenAI, atau menyediakan implementasi khusus dari [IAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/iaiwebclient/) untuk bekerja dengan penyedia AI lain atau model bahasa. Aspose.Slides mengelola semua komunikasi dengan layanan AI dan memproses respons AI untuk menghasilkan slide. Perlu dicatat bahwa API OpenAI merupakan layanan berbayar, sehingga akun dan kunci API diperlukan ketika menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/openaiwebclient/) bawaan.

## **Mari Kita Kode**

### **Contoh 1**

Contoh ini menunjukkan cara menghasilkan presentasi dengan topik Aspose.Slides menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/openaiwebclient/) bawaan.

```py
# Buat instance OpenAIWebClient, implementasi bawaan dari klien web OpenAI.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Buat instance SlidesAIAgent, yang menyediakan akses ke fitur berbasis AI.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Tentukan instruksi untuk menghasilkan presentasi.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Hasilkan presentasi dengan jumlah konten sedang berdasarkan instruksi.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Simpan presentasi yang dihasilkan ke disk lokal sebagai file PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Contoh 2**

Contoh berikut menunjukkan overload dari metode [generate_presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). Dalam kasus ini, `master presentation` milik pengguna digunakan.

```py
# Lewati HttpClient ke konstruktor OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Buat instance SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Tentukan instruksi untuk menghasilkan presentasi.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Muat presentasi master dari disk lokal untuk digunakan sebagai templat desain.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Hasilkan presentasi terperinci menggunakan instruksi dan templat master.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Simpan presentasi yang dihasilkan sebagai PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Manfaat Utama**

AI Presentation Generator baru di Aspose.Slides menyediakan cara yang cepat dan fleksibel untuk menghasilkan deck slide terstruktur dari prompt teks sederhana. Dengan dukungan untuk templat khusus, ia dapat terintegrasi secara mulus ke dalam berbagai aplikasi.

Kasus penggunaan umum meliputi pembuatan presentasi pemasaran, materi pendidikan, laporan klien, dan deck slide internal. Meskipun generasi gambar belum didukung, alat ini sudah menawarkan dasar yang kuat untuk mengotomatisasi pembuatan presentasi, dengan peningkatan lebih lanjut yang diharapkan di masa depan.