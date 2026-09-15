---
title: Penerjemah Presentasi Berbasis AI
linktitle: Penerjemah Berbasis AI
type: docs
weight: 20
url: /id/python-net/ai/translator/
keywords:
- penerjemah presentasi AI
- penerjemah slide AI
- fitur berbasis AI
- presentasi multibahasa
- slide multibahasa
- terjemahan presentasi
- terjemahan slide
- fitur yang didorong AI
- kemampuan AI
- agen AI
- klien web
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Terjemahkan slide PowerPoint dengan AI menggunakan Aspose.Slides untuk Python. Lokalisasi PPT, PPTX, dan ODP sambil mempertahankan tata letak—cepat dan ramah pengembang. Coba sekarang."
---
## **Pendahuluan**

Aspose.Slides adalah API yang kuat untuk mengelola presentasi PowerPoint secara programatik. Selain membuat, mengedit, dan mengonversi slide, ia menawarkan fitur berbasis AI—seperti [Presentation Translation API](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/) untuk konten slide multibahasa.

## **Cara Kerja**

Aspose.Slides tidak menyertakan kemampuan AI bawaan tetapi terintegrasi dengan model AI eksternal melalui internet. Fungsionalitas ini diungkapkan melalui kelas [SlidesAIAgent](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/slidesaiagent/), yang menggunakan subclass [IAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/iaiwebclient/) untuk berkomunikasi dengan layanan AI.

Anda dapat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/openaiwebclient/) bawaan untuk terhubung ke API OpenAI atau mengimplementasikan [IAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/iaiwebclient/) Anda sendiri untuk menggunakan penyedia AI atau model bahasa lain.

Aspose.Slides menangani komunikasi, mengurai respons AI, dan secara cerdas menyisipkan konten terjemahan sambil mempertahankan tata letak dan pemformatan slide asli.

{{% alert color="info" %}}
Perhatikan bahwa API OpenAI merupakan layanan berbayar, sehingga Anda harus membuat akun dan menyediakan kunci API Anda saat menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Contoh**

Dalam contoh ini, kami menerjemahkan presentasi PowerPoint ke bahasa Jepang menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/openaiwebclient/) bawaan dengan [model](https://platform.openai.com/docs/models) OpenAI yang ditentukan.

```py
import aspose.slides as slides

# Muat presentasi untuk diterjemahkan.
with slides.Presentation("sample.pptx") as presentation:

    # Buat klien AI dengan OpenAIWebClient, menentukan model dan kunci API Anda.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Inisialisasi SlidesAIAgent dengan klien AI.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Terjemahkan presentasi ke bahasa Jepang.
        ai_agent.translate(presentation, "japanese")

        # Simpan presentasi yang diterjemahkan sebagai PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Contoh Azure OpenAI**

Sejak versi **26.7.0**, Aspose.Slides untuk Python via .NET mendukung penyedia yang kompatibel dengan OpenAI, termasuk Azure OpenAI. Anda dapat mengonfigurasi penerjemah untuk menggunakan penyebaran Azure internal Anda dengan [OpenAICompatibleWebClient](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Potongan kode ini menunjukkan cara menerjemahkan presentasi menggunakan endpoint Azure OpenAI Anda. Ganti nilai placeholder dengan nama penyebaran, kunci API, dan URL endpoint Anda.

## **Manfaat Utama**

[Presentation Translation API](https://reference.aspose.com/slides/id/python-net/aspose.slides.ai/) Aspose.Slides menawarkan solusi berbasis AI untuk menyajikan presentasi PowerPoint multibahasa. Dengan mengotomatiskan terjemahan sambil mempertahankan tata letak dan desain, solusi ini menghemat waktu dan meminimalkan kesalahan dibandingkan alur kerja manual. Baik Anda seorang pengembang, pendidik, atau profesional bisnis, API ini memungkinkan Anda membuat presentasi yang menarik dan terlokalisasi untuk audiens global—memperluas jangkauan dan meningkatkan komunikasi.