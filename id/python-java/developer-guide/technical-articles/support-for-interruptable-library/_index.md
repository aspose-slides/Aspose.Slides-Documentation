---
title: Dukungan untuk Perpustakaan yang Dapat Diinterupsi
type: docs
weight: 120
url: /id/python-java/support-for-interruptable-library/
keywords:
- perpustakaan yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang berjalan lama
- tugas interupsi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat tugas yang berjalan lama dapat dibatalkan dengan Aspose.Slides untuk Python via Java. Interupsi rendering dan konversi untuk PowerPoint dan OpenDocument secara aman, dengan contoh."
---
## **Ikhtisar**

Aspose.Slides menyediakan mekanisme pemrosesan yang dapat diinterupsi untuk tugas presentasi yang memakan waktu lama, seperti deserialisasi, serialisasi, dan rendering. Mekanisme ini didasarkan pada kelas [InterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/).

Sebuah [InterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontoken/) dapat ditetapkan ke [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/) dan diteruskan ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Ketika [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/#interrupt) dipanggil, tugas yang memakan waktu lama terkait akan diinterupsi.

## **Perpustakaan yang Dapat Diinterupsi**

Aspose.Slides untuk Python via Java menyediakan kelas [InterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/). Kelas‑kelas ini memungkinkan Anda menginterupsi tugas yang memakan waktu lama seperti deserialisasi, serialisasi, dan rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/) adalah sumber token yang diteruskan ke [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Ketika [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setInterruptionToken) dipanggil dan instance [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/) diteruskan ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/#interrupt) akan menginterupsi setiap tugas yang memakan waktu lama yang terkait dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).

Potongan kode berikut memperlihatkan cara menginterupsi tugas yang sedang berjalan:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Jalankan aksi dalam thread terpisah.
    time.sleep(10)  # Batas waktu.
    token_source.interrupt()  # Hentikan konversi.
    conversion_task.result()
```

## **FAQ**

**Apa tujuan perpustakaan interupsi Aspose.Slides?**

Perpustakaan ini menyediakan mekanisme untuk menginterupsi operasi yang memakan waktu lama—seperti memuat, menyimpan, atau merender presentasi—sebelum selesai. Hal ini berguna ketika waktu pemrosesan harus dibatasi atau tugas tidak lagi diperlukan.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontoken/) diteruskan ke API Aspose.Slides dan diperiksa selama operasi yang memakan waktu lama.
- [InterruptionTokenSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/) digunakan dalam kode Anda untuk membuat token dan memicu interupsi dengan memanggil [interrupt](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Tugas apa saja yang dapat diinterupsi?**

Setiap tugas Aspose.Slides yang menerima [InterruptionToken](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontoken/)—seperti memuat presentasi dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) atau menyimpan dengan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save)—dapat diinterupsi.

**Apakah interupsi terjadi secara langsung?**

Tidak. Interupsi bersifat kooperatif: operasi secara periodik memeriksa token dan berhenti segera setelah mendeteksi bahwa [interrupt](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/#interrupt) telah dipanggil.

**Apa yang terjadi jika saya memanggil [interrupt](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/#interrupt) setelah tugas selesai?**

Tidak ada yang terjadi—pemanggilan tersebut tidak berpengaruh jika tugas yang bersangkutan sudah selesai.

**Apakah saya dapat menggunakan kembali [InterruptionTokenSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/) yang sama untuk beberapa tugas?**

Ya—tetapi setelah Anda memanggil [interrupt](https://reference.aspose.com/slides/id/python-java/aspose.slides/interruptiontokensource/#interrupt) pada sumber tersebut, semua tugas yang menggunakan token‑nya akan diinterupsi. Gunakan sumber token terpisah untuk mengelola tugas secara independen.