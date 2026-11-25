---
title: Interupsi Operasi Presentasi yang Memakan Waktu Lama di Python
linktitle: Interupsi Operasi Presentasi
type: docs
weight: 150
url: /id/python-net/support-for-interruptable-library/
keywords:
- operasi yang dapat diinterupsi
- token interupsi
- batalkan ekspor PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Pelajari cara membatalkan konversi presentasi di Python dan mengembalikan daftar slide yang selesai diekspor sebelum pembatalan."
---
## **Gambaran Umum**

Aspose.Slides untuk Python via .NET mendukung pembatalan kooperatif selama operasi yang memakan waktu lama seperti memuat, menyimpan, dan merender presentasi. Saat Anda mengekspor slide secara individual, Anda juga dapat memeriksa pembatalan antar slide dan mengembalikan nomor slide yang selesai diekspor.

## **Batalkan Konversi Presentasi**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), tetapkan [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) ke [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), dan berikan opsi tersebut ke [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Token tersebut berlaku untuk presentasi selama masa hidupnya. Untuk meminta pembatalan dari aplikasi Anda, panggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

Contoh ini mengonversi `sample.pptx` menjadi `sample.pdf`. Sebuah [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) memanggil `source.interrupt` setelah 20 detik. Memulai timer sebelum membuka file membuat batas waktu berlaku untuk memuat dan menyimpan. Aplikasi dengan tombol Cancel dapat memanggil metode yang sama dari penangkap peristiwanya.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

Pemeriksaan eksplisit setelah pemuatan melewatkan ekspor jika batas waktu telah berakhir. Jika pemuatan atau penyimpanan memperhatikan permintaan, pengecualian pembatalan akan sampai ke pemanggil. Penyimpanan juga dapat selesai sebelum memperhatikan permintaan, dalam hal ini PDF lengkap.

## **Hentikan Sebelum Memproses Slide Berikutnya**

Periksa [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) sebelum setiap ekspor. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) menerima daftar nomor slide mulai dari 1. Tambahkan nomor ke dalam daftar yang selesai hanya setelah PDF-nya berhasil disimpan.

Gunakan file bernama `sample.pptx` dengan setidaknya dua slide. Agar hasil dapat direproduksi, contoh meminta pembatalan segera setelah slide 1 selesai. Dalam aplikasi, permintaan dapat datang dari thread lain saat slide sedang disimpan.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Contoh ini menulis `slide-1.pdf` dan mencetak `Starting slide 1` diikuti oleh `Completed: [1]`. Iterasi berikutnya melihat permintaan sebelum memulai slide 2. Jika pembatalan menginterupsi penyimpanan, penangkap pengecualian mengembalikan nomor yang dicatat oleh iterasi sebelumnya. Kesalahan ekspor lainnya sampai ke pemanggil.

Jika pemanggil harus menangani pembatalan sebagai pengecualian, gantilah pemeriksaan dan `break`-nya di bagian atas loop dengan [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Hapus juga `try`/`except` di sekitar penyimpanan. Dengan input yang sama, slide 1 disimpan dan iterasi kedua memunculkan pengecualian pembatalan sebelum memulai slide 2.

## **FAQ**

**Kapan permintaan pembatalan berlaku?**

Operasi yang dapat diinterupsi memeriksa tokennya secara berkala. Operasi berhenti ketika memperhatikan permintaan. Operasi yang sudah selesai tetap mempertahankan hasilnya.

**Apa perbedaan antara source dan token?**

Source memungkinkan aplikasi Anda meminta pembatalan. Token memungkinkan baik presentasi maupun kode Anda memeriksa permintaan tersebut.

**Apakah beberapa operasi dapat berbagi source?**

Ya. Memanggil `interrupt` meminta pembatalan untuk setiap operasi yang menggunakan token dari source tersebut. Berikan setiap operasi source-nya sendiri jika Anda perlu membatalkannya secara independen.