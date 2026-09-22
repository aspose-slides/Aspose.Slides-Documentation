---
title: Tentukan Format Presentasi Asli dalam Python
linktitle: Format Sumber
type: docs
weight: 35
url: /id/python-net/detect-presentation-source-format/
keywords:
- format sumber
- deteksi format presentasi
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Baca format asli dari presentasi yang dimuat dalam Python dengan Aspose.Slides untuk Python via .NET, bandingkan API deteksi, dan tangani file, stream, serta format legacy."
---
## **Gambaran Umum**

Setelah memuat sebuah presentasi, baca properti hanya‑baca [Presentation.source_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/source_format/) untuk menentukan format aslinya. Gunakan properti ini ketika pemrosesan selanjutnya bergantung pada format dari mana instance saat ini dimuat.

Format sumber berbeda dari [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) yang dipilih untuk file output. Menyimpan ke format lain tidak mengubah format sumber dari instance yang ada.

## **Baca Format Sumber dari File**

Contoh ini memerlukan file `sample.pptx` yang sudah ada. Ia memuat file tersebut dan memilih kebijakan pemrosesan aplikasi menggunakan [Presentation.source_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/source_format/), bukan berdasarkan nama file. Ubah jalur input untuk mencoba format lain. Contoh ini mencetak kebijakan yang dipilih; gantilah pesan dengan logika aplikasi Anda.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Kenali Nilai yang Didukung**

Enumerasi [SourceFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/sourceformat/) membedakan format presentasi berikut. Ekstensi di bawah ini adalah ekstensi konvensional, bukan rekonstruksi nama file asli.

| Nilai SourceFormat | Ekstensi | Format |
| --- | --- | --- |
| `PPT` | `.ppt` | Presentasi PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Presentasi Office Open XML |
| `PPTM` | `.pptm` | Presentasi Office Open XML yang mendukung makro |
| `PPS` | `.pps` | Pertunjukan slide PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Pertunjukan slide Office Open XML |
| `PPSM` | `.ppsm` | Pertunjukan slide Office Open XML yang mendukung makro |
| `POT` | `.pot` | Templat PowerPoint 97–2003 |
| `POTX` | `.potx` | Templat Office Open XML |
| `POTM` | `.potm` | Templat Office Open XML yang mendukung makro |
| `ODP` | `.odp` | Presentasi OpenDocument |
| `OTP` | `.otp` | Templat presentasi OpenDocument |
| `FODP` | `.fodp` | Presentasi Flat XML ODF |
| `XML` | `.xml` | Presentasi PowerPoint XML |

## **Baca Format Sumber dari Stream**

Contoh ini memerlukan file `sample.pps` yang sudah ada. Membaca byte‑nya ke dalam stream memori mensimulasikan masukan yang diterima tanpa nama file, seperti nilai basis data atau array byte yang diunggah. Konstruktor [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) menerima hanya stream tersebut.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS, dan POT menggunakan format biner yang sama. Saat memuat melalui jalur file, ekstensi dapat membantu membedakan pertunjukan slide atau templat. Tanpa nama file, konten legacy PPS dan POT mungkin dilaporkan sebagai `SourceFormat.PPT`; contoh PPS di atas melaporkan `PPT`.

Jika aplikasi Anda harus mempertahankan perbedaan tersebut, simpan nama file asli atau metadata subtipe secara terpisah. Ekstensi merupakan petunjuk yang berguna untuk subtipe legacy ini, tetapi tidak boleh menjadi satu‑satunya dasar untuk mengidentifikasi konten presentasi apa pun.

## **Bandingkan Deteksi Sebelum dan Sesudah Memuat**

Gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) dan [PresentationInfo.load_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/load_format/) ketika Anda perlu memeriksa file sebelum memuat model objek presentasi secara lengkap. Gunakan [Presentation.source_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/source_format/) ketika instance sudah ada.

Contoh ini memerlukan `sample.pptx` dan mencetak `PPTX` untuk kedua pemeriksaan. Pada produksi, pilih API yang sesuai dengan tahap pemrosesan Anda; presentasi yang sudah dimuat tidak memerlukan inspeksi kedua semata‑mata untuk memperoleh format sumbernya.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Hasilnya memiliki tipe enumerasi yang berbeda: [LoadFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadformat/) dan [SourceFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/sourceformat/). Jangan bandingkan keduanya dengan meng‑cast nilai numeriknya atau mengasumsikan bahwa setiap format memiliki hasil deteksi yang identik. Pada pemeriksaan simpan‑lalu‑buka yang dijelaskan di bawah, PowerPoint XML dilaporkan sebagai `LoadFormat.UNKNOWN` sebelum dimuat dan `SourceFormat.XML` setelah dimuat.

## **Pisahkan Format Sumber dan Output**

Contoh ini memerlukan `sample.pptx` dan menulis `converted.odp`. Ia mencetak `PPTX` baik sebelum maupun sesudah menyimpan instance asli. Hanya instance baru yang dimuat dari output ODP yang melaporkan `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Presentasi yang dibuat dari awal dengan `slides.Presentation()` melaporkan `SourceFormat.PPTX`. Ia tidak memiliki file masukan: ini adalah nilai default untuk instance yang baru dibuat, bukan bukti bahwa file PPTX telah dimuat. Lacak apakah aplikasi Anda membuat atau memuat instance secara terpisah jika perbedaan itu penting.

## **Pemetaan Format Sumber ke Ekstensi**

Contoh berikut memerlukan `sample.pptx`. Ia memetakan setiap nilai [SourceFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/sourceformat/) yang saat ini didukung ke ekstensi konvensional, tanpa menguraikan nama file masukan. Fallback menghindari penetapan ekstensi secara diam‑diam pada nilai yang tidak dikenali.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Pemetaan ini tidak mengonversi file atau memulihkan subtipe legacy PPS/POT yang hilang selama pemuatan stream. Untuk penyimpanan aktual, pilih [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) secara eksplisit, atau gunakan konversi yang ditunjukkan dalam [Save Presentations in Their Original Format](/slides/id/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Verifikasi Format dengan Menyimpan dan Membuka Kembali**

Contoh mandiri ini membuat sebuah presentasi dan menulis tiga file di direktori kerja, menimpa file dengan nama yang sama. Ia membuka kembali tiap output baik melalui jalur maupun melalui stream memori. Untuk PPTX dan ODP, kedua jalur melaporkan format yang disimpan. Untuk PPS, memuat melalui jalur melaporkan `PPS`, sementara memuat byte yang sama tanpa nama file melaporkan `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Pemeriksaan yang sama dengan semua format yang tercantum di atas menghasilkan hasil berikut untuk presentasi yang dihasilkan dengan ekstensi yang cocok:

| Format yang Disimpan | SourceFormat dari jalur file | SourceFormat dari stream tanpa nama |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` masing‑masing | Sama dengan jalur file |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` masing‑masing | Sama dengan jalur file |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` masing‑masing | Sama dengan jalur file |
| ODP, OTP | `ODP`, `OTP` masing‑masing | Sama dengan jalur file |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

Dalam pemeriksaan ini, satu‑satunya normalisasi format sumber adalah PPS/POT menjadi `PPT` untuk stream tanpa nama. Tabel ini menggambarkan identifikasi format, bukan preservasi setiap fitur presentasi selama konversi.

## **FAQ**

**Apakah menyimpan ke ODP mengubah format sumber dari presentasi yang dimuat dari PPTX?**

Tidak. Instance yang ada masih melaporkan `PPTX`. Instance yang dimuat dari file ODP yang disimpan melaporkan `ODP`.

**Apakah stream selalu dapat membedakan presentasi lama, pertunjukan slide, dan templat?**

Tidak. PPT, PPS, dan POT berbagi format biner. Simpan nama file atau metadata subtipe secara terpisah ketika perbedaan tersebut diperlukan.

**API mana yang harus saya gunakan jika presentasi sudah dimuat?**

Baca [Presentation.source_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/source_format/). Gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) untuk inspeksi sebelum memuat.