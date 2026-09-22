---
title: Menentukan Format Presentasi Asli di Python via Java
linktitle: Format Sumber
type: docs
weight: 35
url: /id/python-java/detect-presentation-source-format/
keywords:
- format sumber
- mendeteksi format presentasi
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Baca format asli dari presentasi yang dimuat di Python via Java dengan Aspose.Slides untuk Python via Java, bandingkan API deteksi, dan tangani file, stream, serta format lama."
---
## **Gambaran Umum**

Setelah memuat sebuah presentasi, panggil metode [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSourceFormat) untuk menentukan format aslinya. Gunakan metode ini ketika pemrosesan selanjutnya bergantung pada format dari mana instance saat ini dimuat.

Format sumber berbeda dari [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) yang dipilih untuk file output. Menyimpan ke format lain tidak mengubah format sumber dari instance yang ada.

Contoh-contoh memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Setiap contoh memulai JVM jika belum berjalan.

## **Baca Format Sumber dari File**

Contoh ini memerlukan file `sample.pptx` yang sudah ada. Ia memuat file tersebut dan memilih kebijakan pemrosesan aplikasi menggunakan [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSourceFormat), bukan berdasarkan nama file. Ubah jalur input untuk mencoba format lain. Contoh ini mencetak kebijakan yang dipilih; ganti pesan dengan logika aplikasi Anda.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Kenali Nilai yang Didukung**

Kelas [SourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/sourceformat/) mendefinisikan konstanta integer yang membedakan format presentasi berikut. Ekstensi di bawah ini adalah ekstensi konvensional, bukan rekonstruksi nama file asli.

| Nilai SourceFormat | Ekstensi | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentasi PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentasi Office Open XML |
| `Pptm` | `.pptm` | Presentasi Office Open XML dengan makro |
| `Pps` | `.pps` | Slide show PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Slide show Office Open XML |
| `Ppsm` | `.ppsm` | Slide show Office Open XML dengan makro |
| `Pot` | `.pot` | Template PowerPoint 97–2003 |
| `Potx` | `.potx` | Template Office Open XML |
| `Potm` | `.potm` | Template Office Open XML dengan makro |
| `Odp` | `.odp` | Presentasi OpenDocument |
| `Otp` | `.otp` | Template presentasi OpenDocument |
| `Fodp` | `.fodp` | Presentasi Flat XML ODF |
| `Xml` | `.xml` | Presentasi PowerPoint XML |

## **Baca Format Sumber dari Stream**

Contoh ini memerlukan file `sample.pps` yang sudah ada. Membaca byte-nya ke dalam stream memori meniru masukan yang diterima tanpa nama file, seperti nilai basis data atau array byte yang diunggah. Konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) menerima hanya stream tersebut. Python membaca byte file, dan JPype mengkonversinya menjadi array byte Java untuk stream memori Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS, dan POT menggunakan format biner yang sama. Saat memuat dengan jalur file, ekstensi dapat membantu membedakan slide show atau template. Tanpa nama file, konten PPS dan POT lama dapat dilaporkan sebagai `SourceFormat.Ppt`; contoh PPS di atas mencetak nilai integer `SourceFormat.Ppt`.

Jika aplikasi Anda harus mempertahankan perbedaan tersebut, simpan nama file asli atau metadata subtipe secara terpisah. Ekstensi merupakan petunjuk yang berguna untuk subtipe lama ini, tetapi tidak boleh menjadi satu‑satunya dasar untuk mengidentifikasi konten presentasi secara arbitrer.

## **Bandingkan Deteksi Sebelum dan Sesudah Memuat**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) dan [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#getLoadFormat) ketika Anda perlu memeriksa file sebelum memuat model objek presentasi lengkapnya. Gunakan [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSourceFormat) ketika instance sudah ada.

Contoh ini memerlukan `sample.pptx` dan mencetak nilai integer `LoadFormat.Pptx` dan `SourceFormat.Pptx`, masing‑masing. Dalam produksi, pilih API yang sesuai dengan tahap pemrosesan Anda; presentasi yang sudah dimuat tidak perlu inspeksi kedua semata‑mata untuk memperoleh format sumbernya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Hasilnya menggunakan konstanta dari kelas yang berbeda: [LoadFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadformat/) dan [SourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/sourceformat/). Jangan bandingkan nilai numeriknya atau mengasumsikan setiap format memiliki hasil deteksi yang identik. PowerPoint XML dapat dilaporkan sebagai `LoadFormat.Unknown` sebelum memuat dan `SourceFormat.Xml` setelah memuat.

## **Jaga Format Sumber dan Output Terpisah**

Contoh ini memerlukan `sample.pptx` dan menulis `converted.odp`. Ia mencetak nilai integer `SourceFormat.Pptx` baik sebelum maupun sesudah menyimpan instance asli. Hanya instance baru yang dimuat dari output ODP yang melaporkan `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Presentasi yang dibuat dari awal dengan `Presentation()` melaporkan `SourceFormat.Pptx`. Ia tidak memiliki file input: ini adalah nilai default untuk instance yang baru dibuat, bukan bukti bahwa file PPTX telah dimuat. Lacak apakah aplikasi Anda membuat atau memuat instance secara terpisah bila perbedaan itu penting.

## **Pemetaan Format Sumber ke Ekstensi**

Contoh berikut memerlukan `sample.pptx`. Ia memetakan setiap nilai [SourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/sourceformat/) yang saat ini didukung ke ekstensi konvensional, tanpa mengurai nama file input. Fallback menghindari penetapan ekstensi secara diam‑diam pada nilai yang tidak dikenali.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Pemetaan ini tidak mengubah file atau memulihkan subtipe PPS/POT lama yang hilang selama pemuatan stream. Untuk penyimpanan sebenarnya, pilih [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) secara eksplisit, atau gunakan konversi yang ditunjukkan di [Save Presentations in Their Original Format](/slides/id/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifikasi Format dengan Menyimpan dan Membuka Kembali**

Contoh mandiri ini membuat sebuah presentasi dan menulis tiga file di direktori kerja, menimpa file dengan nama yang sama. Ia membuka kembali setiap output baik lewat jalur maupun melalui stream memori. Untuk PPTX dan ODP, kedua jalur melaporkan format yang disimpan. Untuk PPS, pemuatan lewat jalur melaporkan `Pps`, sementara pemuatan byte yang sama tanpa nama file melaporkan `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

Tabel berikut merangkum identifikasi format sumber untuk presentasi dengan ekstensi yang cocok. Nama menandakan konstanta; contoh Python mencetak nilai integernya:

| Format yang Disimpan | SourceFormat dari jalur file | SourceFormat dari stream tanpa nama |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` masing‑masing | Sama dengan jalur file |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` masing‑masing | Sama dengan jalur file |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` masing‑masing | Sama dengan jalur file |
| ODP, OTP | `Odp`, `Otp` masing‑masing | Sama dengan jalur file |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Konten PPS/POT diidentifikasi sebagai `Ppt` untuk stream tanpa nama. Tabel menggambarkan identifikasi format, bukan preservasi setiap fitur presentasi selama konversi.

## **FAQ**

**Apakah menyimpan ke ODP mengubah format sumber presentasi yang dimuat dari PPTX?**

Tidak. Instance yang ada tetap melaporkan `Pptx`. Instance yang dimuat dari file ODP yang disimpan melaporkan `Odp`.

**Apakah stream selalu dapat membedakan presentasi lama, slide show, dan template?**

Tidak. PPT, PPS, dan POT berbagi format biner. Simpan nama file atau metadata subtipe secara terpisah bila perbedaan itu diperlukan.

**API mana yang harus saya gunakan jika presentasi sudah dimuat?**

Baca [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSourceFormat). Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk inspeksi sebelum pemuatan.