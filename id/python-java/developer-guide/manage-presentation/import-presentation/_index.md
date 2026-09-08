---
title: Impor Presentasi dari PDF atau HTML dalam Python via Java
linktitle: Impor Presentasi
type: docs
weight: 60
url: /id/python-java/import-presentation/
keywords:
- impor presentasi
- impor slide
- impor PDF
- impor HTML
- PDF ke presentasi
- PDF ke PPT
- PDF ke PPTX
- PDF ke ODP
- HTML ke presentasi
- HTML ke PPT
- HTML ke PPTX
- HTML ke ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengimpor konten PDF dan HTML ke dalam presentasi PowerPoint dalam Python via Java dengan Aspose.Slides dan menyimpan hasilnya sebagai file PPTX."
---
## **Pendahuluan**

Aspose.Slides untuk Python via Java dapat mengubah halaman PDF atau konten HTML menjadi slide PowerPoint tanpa Microsoft PowerPoint. Kelas [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) menyediakan [addFromPdf](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addFromPdf) dan [addFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addFromHtml) untuk menambahkan konten yang diimpor ke sebuah presentasi.

Untuk kontrol lebih besar atas penempatan HTML, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertFromHtml) dapat menyisipkan slide yang dihasilkan pada indeks koleksi atau mulai mengisi ruang yang tersedia pada slide yang ada. HTML panjang dipaginasi secara otomatis ke slide tambahan, sumber dapat diberikan sebagai string atau stream, dan aset eksternal dapat dimuat melalui [ExternalResourceResolver](https://reference.aspose.com/slides/id/python-java/aspose.slides/externalresourceresolver/) dengan URI dasar. Array [Slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/) yang dikembalikan mengidentifikasi slide yang terdampak dan yang baru dibuat.

## **Impor dari PDF**

Untuk mengonversi dokumen PDF menjadi presentasi PowerPoint, impor kontennya ke dalam koleksi slide dan simpan hasilnya sebagai file PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Buat objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) baru.  
2. Panggil [addFromPdf](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addFromPdf) dengan path ke file PDF.  
3. Panggil [save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Pptx) untuk menulis presentasi ke file PPTX.

Contoh Python berikut mengimpor dokumen PDF dan menyimpan slide yang dihasilkan sebagai presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Slide kosong default tetap ada dalam presentasi karena impor menambahkan slide. Untuk mempertahankan hanya halaman yang diimpor, kosongkan koleksi slide dengan [SlideCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#clear) sebelum mengimpor.

Metode [addFromPdf](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addFromPdf) mengembalikan slide yang ditambahkannya, yang berguna bila Anda perlu memproses hanya slide yang diimpor.

{{% alert title="Tip" color="success" %}}
Coba aplikasi web gratis [PDF to PowerPoint](https://products.aspose.app/slides/id/import/pdf-to-powerpoint) untuk melihat alur kerja konversi ini secara langsung.
{{% /alert %}}

## **Impor dari HTML**

Aspose.Slides juga dapat membuat slide dari dokumen HTML. Sumber dapat diberikan sebagai teks HTML atau stream. Langkah-langkah berikut menggunakan file stream:

1. Buat objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) baru.  
2. Buka file HTML untuk dibaca dan berikan stream ke [addFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addFromHtml).  
3. Panggil [save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Pptx) untuk menulis hasil ke file PPTX.

Contoh Python berikut mengimpor dokumen HTML dan menyimpan slide yang dihasilkan sebagai presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sisipkan Konten HTML**

Gunakan [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertFromHtml) bila slide yang dihasilkan dari HTML harus ditempatkan pada posisi tertentu alih-alih ditambahkan. Indeks dimulai dari nol dan mengidentifikasi posisi tempat impor dimulai.

Argumen `useSlideWithIndexAsStart` mengontrol bagaimana pengimpor menggunakan posisi tersebut:

- Ketika `False`, pengimpor membuat slide baru pada indeks yang ditentukan dan menggeser slide yang mengikutinya.  
- Ketika `True`, pengimpor mulai menempatkan konten di ruang yang tersedia pada slide yang ada pada indeks tersebut. Jika HTML tidak muat, Aspose.Slides memaginasi secara otomatis dan menyisipkan slide tambahan segera setelah slide awal.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertFromHtml) mengembalikan array objek [Slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/). Ketika penyisipan dimulai pada slide baru, setiap item yang dikembalikan merupakan slide yang baru dibuat. Ketika slide yang ada digunakan sebagai awal, array tersebut mencakup slide yang terdampak diikuti oleh slide overflow baru. Anda dapat memeriksa array ini alih-alih menghitung rentang yang terdampak dari jumlah slide presentasi.

### **Sisipkan HTML sebagai Slide Baru**

Contoh berikut menyediakan HTML sebagai string dan menyisipkan slide yang dihasilkan pada indeks koleksi `1`. Menetapkan `False` membiarkan slide yang ada tidak berubah kecuali digeser untuk memberi ruang.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Mulai pada Slide yang Ada**

Contoh berikutnya menyediakan HTML melalui stream. Ia mempertahankan bentuk header pada slide templat yang ada, memulai impor di bawah area yang ditempati, dan membiarkan isi panjang berlanjut ke slide baru.

HTML juga berisi URL gambar relatif. Sebuah [ExternalResourceResolver](https://reference.aspose.com/slides/id/python-java/aspose.slides/externalresourceresolver/) memperoleh sumber daya tersebut, sementara URI dasar memberi tahu pengimpor cara menyelesaikan `images/logo.png`. Pada contoh ini, file tersebut diharapkan berada di `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Resolver sumber daya eksternal yang tidak dibatasi dapat membaca sumber daya lokal atau jaringan yang direferensikan oleh HTML. Untuk masukan yang tidak dipercaya, validasi dan sanitasi URL sumber daya terhadap daftar izinkan skema, direktori, dan host yang diizinkan sebelum mengimpor HTML.
{{% /alert %}}

## **FAQ**

**Can Aspose.Slides detect tables when importing a PDF?**

Ya. Buat objek [PdfImportOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfimportoptions/) , panggil [setDetectTables](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfimportoptions/#setDetectTables) dengan `True`, dan berikan opsi tersebut ke [addFromPdf](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addFromPdf). Kualitas pengenalan tabel bergantung pada struktur dan kompleksitas PDF sumber.

{{% alert title="Note" color="info" %}}
Setelah mengimpor HTML, Anda juga dapat mengekspor slide ke [images](/slides/id/python-java/convert-powerpoint-to-png/), [TIFF](/slides/id/python-java/convert-powerpoint-to-tiff/), atau [SVG](/slides/id/python-java/render-slide-as-svg/).
{{% /alert %}}