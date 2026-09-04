---
title: Penerjemah Presentasi Bertenaga AI
linktitle: Penerjemah Bertenaga AI
type: docs
weight: 20
url: /id/python-java/ai/translator/
keywords:
- penerjemah presentasi AI
- penerjemah slide AI
- presentasi multibahasa
- terjemahan presentasi
- terjemahan slide
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Terjemahkan presentasi dengan AI menggunakan Aspose.Slides untuk Python via Java. Lokalisasi teks slide dan simpan presentasi yang diterjemahkan sebagai PowerPoint atau PDF."
---
## **Pendahuluan**

Aspose.Slides for Python via Java menyediakan API AI Presentation Translation untuk melokalkan konten slide. Terjemahkan presentasi yang ada ke bahasa yang ditentukan, kemudian simpan versi terjemahan dalam format yang dibutuhkan audiens Anda.

## **Cara Kerja**

[SlidesAIAgent](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesaiagent/) berkomunikasi dengan layanan AI eksternal melalui klien AI. Contoh-contoh menggunakan [OpenAIWebClient](https://reference.aspose.com/slides/id/python-java/aspose.slides/openaiwebclient/) bawaan.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesaiagent/#translate) memperbarui presentasi yang diberikan kepadanya. Aspose.Slides memproses respons AI dan mengganti teks slide sambil mempertahankan tata letak dan pemformatan yang ada. Tinjau hasilnya: teks terjemahan mungkin lebih panjang daripada aslinya dan memerlukan penyesuaian tata letak.

## **Prasyarat**

Ikuti [Installation](/slides/id/python-java/installation/) untuk mengonfigurasi perpustakaan dan runtime-nya. Atur variabel lingkungan `OPENAI_API_KEY` dan `OPENAI_MODEL` sebelum menjalankan contoh. Pilih model yang didukung oleh klien bawaan dan tersedia untuk akun API Anda.

{{% alert color="info" title="Catatan" %}}
Terjemahan memerlukan koneksi internet dan mengirimkan teks presentasi ke layanan AI yang dikonfigurasi. Akses API dan biaya penggunaannya terpisah dari lisensi Aspose.Slides Anda.
{{% /alert %}}

Contoh-contoh menggunakan kembali JVM yang aktif atau memulainya bila diperlukan. Lihat [JVM lifecycle guidance](/slides/id/python-java/limitations-and-api-differences/#import-the-library) untuk penggunaan di notebook.

## **Menerjemahkan Presentasi**

Tempatkan `sample.pptx` di direktori kerja. Contoh ini memuatnya dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), menerjemahkan teksnya ke bahasa Jepang, dan menyimpan hasilnya sebagai PDF. Presentasi akan dilepaskan dan klien AI ditutup meskipun operasi gagal.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Mengonfigurasi Koneksi HTTP**

Secara default, [OpenAIWebClient](https://reference.aspose.com/slides/id/python-java/aspose.slides/openaiwebclient/) mengelola koneksi HTTP-nya secara internal. Konstruktor empat argumennya juga menerima [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) Java yang dikelola secara eksternal. Gunakan overload ini bila Anda perlu mengonfigurasi proxy atau batas waktu koneksi.

Contoh berikut membuat proxy HTTP Java dengan [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) dan membuka koneksi melalui [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Ganti `proxy.example.com` dan port dengan pengaturan proxy Anda. Koneksi diteruskan langsung melalui JPype; sesi HTTP Python tidak dapat digunakan sebagai gantinya.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Manfaat Utama**

Terjemahan otomatis membantu menyiapkan materi pelatihan multibahasa, presentasi produk, dan laporan klien sekaligus menggunakan desain slide yang ada. Simpan presentasi yang dapat diedit untuk peninjauan lebih lanjut atau ekspor ke PDF untuk distribusi.

## **Tanya Jawab**

**Apakah terjemahan membuat objek presentasi terpisah?**

Tidak. [SlidesAIAgent.translate](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesaiagent/#translate) memodifikasi presentasi yang diberikan. Simpan dengan nama file baru untuk menjaga file asli tetap tidak berubah.

**Bagaimana cara menentukan bahasa target?**

Berikan nama bahasa, seperti `"Japanese"` atau `"Spanish"`, sebagai argumen kedua. Kualitas terjemahan dan cakupan bahasa bergantung pada model yang dipilih.

**Apakah saya dapat menerjemahkan tanpa menggunakan proxy?**

Ya. Gunakan konstruktor klien tiga argumen yang ditunjukkan pada contoh pertama. Contoh koneksi khusus hanya diperlukan ketika aplikasi Anda memerlukan pengaturan koneksi eksplisit.