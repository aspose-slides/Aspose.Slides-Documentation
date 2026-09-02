---
title: Cara Menjalankan Aspose.Slides di Docker
linktitle: Aspose.Slides di Docker
type: docs
weight: 150
url: /id/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides di Docker
- Kontainer Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Jalankan Aspose.Slides for Python via .NET di Docker: Dockerfile yang berfungsi, pustaka native yang dibutuhkan paket, penyiapan font, dan lisensi di dalam kontainer."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET berjalan di dalam container Linux, tetapi paket ini merupakan wrapper Python di atas runtime .NET Core 3.1 yang sudah dibundel. Runtime tersebut memerlukan tiga pustaka native yang tidak disertakan pada image Python slim, dan versi pustaka tersebut harus tepat. Artikel ini menyediakan Dockerfile yang berfungsi, menjelaskan alasan keberadaan setiap dependensi, serta menunjukkan cara menambahkan font dan lisensi.

## **Dockerfile yang Berfungsi**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Build and run:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Mengapa image dasar adalah Debian 11**

Wheel `aspose.slides` membundel runtime **.NET Core 3.1**, dan runtime tersebut lebih dulu daripada versi pustaka yang disertakan pada rilis Debian saat ini. Pada Debian 12 dan 13 container berhasil dibangun tetapi gagal pada pemanggilan pertama `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Pesan tersebut menyesatkan — ICU * memang* terpasang pada image tersebut, tetapi versinya ICU 72 atau 76, sedangkan .NET Core 3.1 hanya mengenali versi mayor yang lebih lama. Debian 12 juga menyertakan OpenSSL 3, yang menimbulkan kegagalan kedua:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` adalah Debian 11, yang menyediakan kedua versi yang diharapkan runtime yang dibundel:

| Package | Version on Debian 11 | Mengapa diperlukan |
|---|---|---|
| `libgdiplus` | 6.0.4 | Implementasi GDI+ yang digunakan untuk merender bentuk, teks, dan gambar |
| `libicu67` | 67.1 | Data globalisasi. Versi mayor yang lebih baru tidak dikenali oleh .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Kriptografi. Sudah terpasang pada Debian 11; tidak ada pada Debian 12+ |
| `libfontconfig1` | — | Penemuan font |

`libssl1.1` sudah ada di image dasar, jadi tidak perlu dicantumkan dalam `apt-get install`.

Jika Anda harus menggunakan image dasar yang lebih baru, atur `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` untuk melewati kebutuhan ICU. Ini menonaktifkan format budaya spesifik dan **tidak** menyelesaikan masalah OpenSSL, sehingga Debian 11 tetap pilihan yang lebih sederhana.

## **Font**

Image slim tidak berisi font sama sekali. Tanpa setidaknya satu font terpasang, teks akan dirender sebagai kotak kosong pada output PDF, gambar, dan HTML. `fonts-dejavu-core` merupakan titik awal umum yang kecil.

Untuk mencocokkan tampilan yang diinginkan pada presentasi, salin font yang digunakannya ke dalam image dan arahkan Aspose.Slides ke font tersebut:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Lisensi di dalam container**

Jangan menyertakan file lisensi ke dalam image — siapa pun yang menarik image akan mendapatkan lisensinya. Pasanglah pada saat runtime:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Tanpa lisensi, perpustakaan berjalan dalam mode evaluasi, yang menambahkan watermark dan membatasi jumlah slide yang diproses. Lihat [Licensing](/slides/id/python-net/licensing/) untuk detail.

## **Memori**

Merender ke PDF atau gambar membutuhkan memori lebih besar dibandingkan membaca file. Container dengan batas memori ketat dapat dihentikan oleh OOM killer di tengah proses konversi, biasanya tampak sebagai proses yang menghilang tanpa traceback Python. Jika hal itu terjadi, naikkan batas memori container sebelum menyelidiki kode.