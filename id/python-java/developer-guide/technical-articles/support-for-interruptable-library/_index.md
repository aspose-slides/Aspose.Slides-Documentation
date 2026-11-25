---
title: Menginterupsi Operasi Presentasi yang Memakan Waktu Lama di Python
linktitle: Menginterupsi Operasi Presentasi
type: docs
weight: 120
url: /id/python-java/support-for-interruptable-library/
keywords:
- operasi yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang memakan waktu lama
- interupsi tugas
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara membatalkan operasi presentasi yang memakan waktu lama di Aspose.Slides untuk Python via Java dan mengembalikan hasil parsial saat mengekspor slide dalam loop."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java dapat menghentikan operasi yang memakan waktu lama seperti memuat, menyimpan, dan merender presentasi. Aplikasi Anda dapat menggunakan token interupsi yang sama untuk menghentikan loop sebelum memproses slide berikutnya.

## **Menginterupsi Operasi Presentasi**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), dapatkan tokennya dengan [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), dan berikan token tersebut ke [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Berikan opsi muat ke [constructor Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Untuk meminta pembatalan, panggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) pada sumbernya. Operasi yang dapat diinterupsi akan berhenti ketika ia mendeteksi permintaan tersebut. Gunakan `jpype.JClass` untuk menangkap pengecualian Java `com.aspose.slides.exceptions.OperationCanceledException` di Python.

Contoh ini mengonversi `sample.pptx` menjadi `sample.ppt` pada thread latar belakang. Thread pemanggil menunggu hingga 10 detik untuk konversi selesai. Jika konversi masih berjalan, ia meminta pembatalan dan menunggu pekerja keluar.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Menghubungkan Timeout Python ke Aspose.Slides**

Untuk menetapkan batas waktu pada operasi presentasi, gunakan [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) untuk memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) ketika batas waktu berakhir. Contoh ini memberi waktu 20 detik untuk memuat `sample.pptx` dan mengekspornya ke `sample.pdf`. Jika ekspor selesai lebih cepat, aplikasi membatalkan permintaan yang dijadwalkan.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Berhenti Sebelum Memproses Slide Berikutnya**

Gunakan [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) yang sama untuk presentasi dan loop yang mengekspor slide‑nya. Periksa [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) sebelum setiap ekspor. Jika pemanggil dapat menggunakan hasil parsial, kembalikan nomor slide untuk ekspor yang berhasil selesai.

Gunakan presentasi bernama `sample.pptx` dengan setidaknya dua slide. Overload [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yang menerima `int[]` Java menggunakan nomor slide mulai dari 1. Gunakan `jpype.JArray(jpype.JInt)` untuk membangun array tersebut di Python. Contoh ini menyimpan setiap slide ke PDF terpisah dan meminta pembatalan segera setelah mencatat ekspor pertama yang berhasil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Contoh menulis `slide-1.pdf` dan mencetak `Starting slide 1` diikuti oleh `Completed: [1]`. Loop mendeteksi permintaan sebelum memulai slide 2. Jika pembatalan datang selama penyimpanan, loop keluar sebelum mencatat slide tersebut sebagai selesai.

Jika pemanggil perlu menangani pembatalan, gantikan pemeriksaan dan `break`‑nya di bagian atas loop dengan `token.throwIfInterruptionRequested()`. Hapus `try`/`except` di sekitar penyimpanan sehingga pembatalan selama ekspor juga sampai ke pemanggil. Dengan input yang sama, contoh hanya mencetak `Starting slide 1` dan menulis `slide-1.pdf`. Pada awal iterasi kedua, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) memicu `com.aspose.slides.exceptions.OperationCanceledException` sebelum ekspor berikutnya dimulai. Pengecualian tersebut menyebar ke pemanggil sebelum fungsi dapat mengembalikan daftar.

## **FAQ**

**Kapan saya harus meminta pembatalan?**

Minta pembatalan ketika sebuah operasi melebihi batas waktu Anda atau ketika aplikasi tidak lagi memerlukan hasilnya.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Sumber memungkinkan aplikasi Anda meminta pembatalan. Token memungkinkan Aspose.Slides dan aplikasi Anda memeriksa permintaan tersebut.

**Bisakah saya membatalkan operasi dari timer Python?**

Ya. Jadwalkan pemanggilan [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) pada sumber yang terkait dengan presentasi.

**Operasi apa yang dapat saya interupsi?**

Anda dapat menginterupsi pemuatan, penyimpanan, dan perenderan. Berikan token ke [constructor Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) melalui [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Presentasi kemudian dapat mendeteksi pembatalan selama operasi selanjutnya seperti penyimpanan ke PDF.

**Apakah operasi berhenti serta‑merta?**

Pembatalan bersifat kooperatif. Sebuah operasi memeriksa token secara berkala dan berhenti ketika ia mendeteksi permintaan.

**Apa yang terjadi jika saya memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) setelah operasi selesai?**

Operasi yang selesai tetap menyimpan hasilnya.

**Apakah beberapa operasi dapat berbagi [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Ya. Memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) meminta pembatalan untuk setiap operasi yang menggunakan token dari sumber tersebut. Gunakan sumber terpisah untuk setiap operasi yang ingin Anda batalkan secara independen.