---
title: Instalasi
type: docs
weight: 70
url: /id/python-java/installation/
keywords:
- unduh Aspose.Slides
- instal Aspose.Slides
- instalasi Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Instal Aspose.Slides untuk Python via Java di Windows, Linux, atau macOS, konfigurasikan Java dan JPype, dan verifikasi pengaturan dengan contoh yang berfungsi."
---
Aspose.Slides untuk Python via Java berjalan di Windows, Linux, dan macOS. Ia menggunakan JPype untuk mengakses pustaka Java dari Python. Microsoft PowerPoint tidak diperlukan.

## **Prasyarat**

Sebelum menginstal paket Python, instal Python dan JDK yang memenuhi [System Requirements](/slides/id/python-java/system-requirements/). Halaman tersebut mencantumkan versi yang kompatibel, persyaratan arsitektur, dan dependensi apa pun yang diperlukan untuk membangun JPype dari sumber.

Setel `JAVA_HOME` ke direktori instalasi JDK, bukan subdirektori `bin`-nya, dan tambahkan direktori `bin` JDK ke `PATH`. Buka terminal baru setelah mengubah variabel lingkungan.

## **Instal dari PyPI**

Jalankan perintah berikut di terminal, bukan di prompt interaktif Python. Buat direktori proyek dan lingkungan virtual untuk menjaga paket terisolasi dari proyek lain.

### **Windows**

Dengan interpreter Python pilihan Anda tersedia sebagai `python` di `PATH`, jalankan perintah berikut di Command Prompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux dan macOS**

Dengan versi Python pilihan Anda tersedia sebagai `python3`, jalankan perintah berikut di Bash atau zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Pada Debian atau Ubuntu, jika pembuatan lingkungan gagal karena `ensurepip` tidak tersedia, instal paket `python3-venv` dengan `sudo apt-get install python3-venv`, lalu ulangi perintah pembuatan lingkungan. Versi Python yang diinstal secara terpisah mungkin memerlukan paket `venv` yang sesuai dengan versinya.

### **Instal Paket**

Dengan lingkungan virtual aktif, instal JPype dan Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Menggunakan `python -m pip` memastikan paket diinstal untuk interpreter yang digunakan menjalankan aplikasi Anda.

Untuk memperbarui instalasi Aspose.Slides yang ada, jalankan `python -m pip install --upgrade aspose-slides-java` di lingkungan yang sama.

## **Instal dari Arsip ZIP**

Anda juga dapat menggunakan perpustakaan dari [Aspose.Slides downloads page](https://releases.aspose.com/slides/id/python-java/):

1. Instal Python dan Java seperti yang dijelaskan di [Prasyarat](#prerequisites).
2. Buat dan aktifkan lingkungan virtual menggunakan instruksi di atas.
3. Instal JPype dengan `python -m pip install JPype1`.
4. Unduh dan ekstrak arsip ZIP Aspose.Slides untuk Python via Java.
5. Temukan direktori paket `asposeslides` yang telah diekstrak. Simpan isinya, termasuk direktori `lib` dan file JAR, bersama-sama.
6. Tempatkan `example.py` dari bagian berikut di samping direktori `asposeslides` agar Python dapat mengimpor paket tersebut.

## **Verifikasi Instalasi**

Simpan kode berikut sebagai `example.py`. Kode ini membuat presentasi dengan kotak teks dan menyimpannya sebagai `out.pptx` di direktori kerja saat ini.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Dengan lingkungan virtual aktif, jalankan contoh dari direktori yang berisi `example.py`:

```sh
python example.py
```

Impor `asposeslides` mendaftarkan pustaka Java yang dibundel sebelum JVM dimulai. Impor `asposeslides.api` setelah memulai JVM, dan lepaskan sumber daya presentasi sebelum mematikannya.

{{% alert color="info" title="Note" %}}
Tanpa lisensi, output akan menyertakan watermark evaluasi. Lihat [Evaluate Aspose.Slides](/slides/id/python-java/evaluate-aspose-slides/) untuk batasan evaluasi dan informasi lisensi sementara.
{{% /alert %}}

## **FAQ**

**Mengapa Python melaporkan bahwa JVM tidak dapat ditemukan atau dimuat?**

Pastikan `JAVA_HOME` mengarah ke JDK yang kompatibel dengan instalasi Python dan JPype Anda, seperti dijelaskan di [System Requirements](/slides/id/python-java/system-requirements/). Lihat [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) untuk pemeriksaan tambahan.

**Mengapa Python melaporkan bahwa `asposeslides` hilang setelah instalasi?**

Paket tersebut mungkin telah diinstal untuk interpreter Python yang berbeda. Aktifkan lingkungan virtual yang digunakan untuk instalasi dan jalankan `python -m pip show aspose-slides-java`. Untuk instalasi ZIP, pastikan direktori `asposeslides` berada di samping skrip Anda atau tersedia pada jalur pencarian modul Python.

**Apakah saya dapat menjalankan contoh berulang kali di notebook?**

Contoh ini ditujukan untuk proses Python mandiri. Sebelum menyesuaikannya untuk eksekusi notebook berulang, lihat [Limitations and API Differences](/slides/id/python-java/limitations-and-api-differences/#import-the-library) untuk siklus hidup JVM dan panduan notebook.

**Mengapa pip gagal dengan `CERTIFICATE_VERIFY_FAILED`?**

Jika jaringan Anda menggunakan proxy inspeksi HTTPS, pip harus mempercayai otoritas sertifikatnya. Konfigurasikan bundel CA tepercaya menggunakan opsi `--cert` pip atau variabel lingkungan `PIP_CERT`, mengikuti [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). Konfigurasi yang diperlukan tergantung pada jaringan dan versi pip Anda.