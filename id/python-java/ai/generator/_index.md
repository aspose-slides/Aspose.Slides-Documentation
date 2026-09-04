---
title: Generator Slide Multibahasa Berbasis AI
linktitle: Generator Berbasis AI
type: docs
weight: 40
url: /id/python-java/ai/generator/
keywords:
- presentasi multibahasa
- slide multibahasa
- generator presentasi AI
- generator slide AI
- template presentasi
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Hasilkan presentasi multibahasa dari teks dengan Aspose.Slides untuk Python via Java. Pilih tingkat detail konten, terapkan template, dan ekspor ke PowerPoint atau PDF."
---
## **Pendahuluan**

AI Presentation Generator di Aspose.Slides untuk Python via Java membuat presentasi dari deskripsi topik, ringkasan, kutipan, atau poin-poin. Tentukan bahasa yang diperlukan dalam prompt Anda, pilih jumlah konten, dan secara opsional sediakan template presentasi untuk menentukan tata letak dan desain.

Generator menstrukturkan konten menggunakan blok teks, daftar berpoin, dan tabel. Ia tidak menghasilkan gambar; Anda dapat menambahkannya ke presentasi yang dihasilkan kemudian. Tinjau konten dan tata letak yang dihasilkan sebelum membagikan presentasi.

## **Cara Kerja**

[SlidesAIAgent](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesaiagent/) menggunakan klien AI untuk berkomunikasi dengan model eksternal. Contoh di bawah menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-java/aspose.slides/openaiwebclient/) bawaan. Aspose.Slides memproses respons model dan membangun presentasi yang dapat Anda edit atau ekspor.

Gunakan [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesaiagent/#generatePresentation) dengan deskripsi teks dan nilai [PresentationContentAmountType](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationcontentamounttype/). Overload dengan argumen ketiga menerima presentasi yang akan digunakan sebagai template desain.

## **Prasyarat**

Ikuti [Installation](/slides/id/python-java/installation/) untuk mengonfigurasi Python, Java, JPype, dan Aspose.Slides. Tetapkan variabel lingkungan `OPENAI_API_KEY` dan `OPENAI_MODEL` sebelum menjalankan contoh. Pilih model yang didukung oleh klien bawaan dan tersedia untuk akun API Anda.

{{% alert color="info" title="Note" %}}
Layanan AI memerlukan koneksi internet dan akses API terpisah. Prompt dikirim ke layanan yang dikonfigurasi, dan biaya penggunaannya berlaku secara terpisah dari lisensi Aspose.Slides Anda.
{{% /alert %}}

Setiap contoh memulai JVM hanya jika belum berjalan dan membiarkannya tersedia untuk operasi selanjutnya. Lihat [JVM lifecycle guidance](/slides/id/python-java/limitations-and-api-differences/#import-the-library) saat menyesuaikan kode untuk notebook.

## **Buat Presentasi dari Teks**

Contoh ini menghasilkan presentasi berbahasa Inggris dengan jumlah konten [Medium](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationcontentamounttype/#Medium) dan menyimpannya sebagai file PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Buat Presentasi Menggunakan Template**

Letakkan `masterPresentation.pptx` di direktori kerja. Contoh ini memuatnya dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), menghasilkan presentasi berbahasa Spanyol dengan konten [Detailed](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationcontentamounttype/#Detailed), dan mengekspornya ke PDF. Baik template maupun presentasi yang dihasilkan dibebaskan, bahkan jika proses generasi atau penyimpanan gagal.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Jika Anda perlu mengonfigurasi proxy atau batas waktu koneksi, lihat [Configure the HTTP Connection](/slides/id/python-java/ai/translator/#configure-the-http-connection). Anda juga dapat melewatkan klien yang dihasilkan ke generator.

## **Manfaat Utama**

Generasi dapat mengurangi pekerjaan drafting awal untuk materi pelatihan, ikhtisar produk, laporan klien, dan presentasi internal. Prompt mengontrol topik dan bahasa, sementara template memungkinkan Anda menggunakan kembali desain presentasi yang sudah ada.

## **FAQ**

**Bagaimana cara saya mengontrol panjang presentasi yang dihasilkan?**

Pilih [Brief](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationcontentamounttype/#Medium), atau [Detailed](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Pengaturan ini memengaruhi baik jumlah slide maupun detail pada setiap slide; mereka tidak menentukan jumlah slide yang pasti.

**Apakah saya dapat menghasilkan slide dalam bahasa lain?**

Ya. Sertakan bahasa yang diminta dalam deskripsi teks. Hasilnya bergantung pada kemampuan bahasa model yang dipilih.

**Apakah saya dapat mempertahankan versi yang dapat diedit saat mengekspor ke PDF?**

Ya. Sebelum membuang presentasi yang dihasilkan, juga simpan sebagai PPTX menggunakan pendekatan pada contoh pertama.