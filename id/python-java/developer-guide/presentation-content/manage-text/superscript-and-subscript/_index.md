---
title: Kelola Superskrip dan Subskrip dalam Presentasi Menggunakan Python via Java
linktitle: Superskrip dan Subskrip
type: docs
weight: 80
url: /id/python-java/superscript-and-subscript/
keywords:
- superskrip
- subskrip
- tambah superskrip
- tambah subskrip
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kuasi superskrip dan subskrip di Aspose.Slides untuk Python via Java dan tingkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Gambaran Umum**

Aspose.Slides menyediakan fitur untuk menyisipkan teks superskrip dan subskrip ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Apakah Anda perlu menyorot rumus kimia, persamaan matematika, atau memberi anotasi pada konten dengan catatan kaki, opsi pemformatan khusus ini membantu menjaga kejelasan dan ketepatan. Dalam artikel ini, Anda akan belajar cara menerapkan gaya superskrip dan subskrip secara mulus dan memastikan hasil profesional di setiap slide.

## **Kelola Teks Superskrip dan Subskrip**

Anda dapat menambahkan teks superskrip dan subskrip ke bagian mana pun dari sebuah paragraf. Untuk menerapkan pemformatan ini dalam text frame Aspose.Slides, gunakan metode [setEscapement](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#setEscapement) dari kelas [PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/).

Nilai escapement berkisar dari -100% (subskrip) hingga 100% (superskrip). Misalnya:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
- Dapatkan slide berdasarkan indeksnya.
- Tambahkan [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) berjenis [ShapeType.Rectangle](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#Rectangle) ke slide.
- Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).
- Bersihkan paragraf yang ada.
- Buat paragraf untuk menampung teks superskrip dan tambahkan ke [paragraph collection](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParagraphs) dari text frame.
- Buat sebuah portion.
- Gunakan [setEscapement](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#setEscapement) untuk mengatur nilai dari 0 hingga 100 untuk superskrip (0 berarti tidak ada superskrip).
- Setel teks pada [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) dan tambahkan ke koleksi portion paragraf.
- Buat paragraf untuk menampung teks subskrip dan tambahkan ke [paragraph collection](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParagraphs) dari text frame.
- Buat sebuah portion.
- Gunakan [setEscapement](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#setEscapement) untuk mengatur nilai dari -100 hingga 0 untuk subskrip (0 berarti tidak ada subskrip).
- Setel teks pada [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) dan tambahkan ke koleksi portion paragraf.
- Simpan presentasi sebagai file PPTX.

Contoh berikut mengimplementasikan langkah‑langkah ini:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Buat sebuah presentasi.
presentation = Presentation()
try:
    # Dapatkan slide.
    slide = presentation.getSlides().get_Item(0)

    # Buat sebuah kotak teks.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Buat paragraf untuk teks superskrip.
    superscript_paragraph = Paragraph()

    # Buat sebuah bagian dengan teks normal.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Buat sebuah bagian dengan teks superskrip.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Buat paragraf untuk teks subskrip.
    subscript_paragraph = Paragraph()

    # Buat sebuah bagian dengan teks normal.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Buat sebuah bagian dengan teks subskrip.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Tambahkan paragraf ke kotak teks.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah superskrip dan subskrip akan dipertahankan saat mengekspor ke PDF atau format lain?**

Ya, Aspose.Slides dengan tepat mempertahankan pemformatan superskrip dan subskrip saat mengekspor presentasi ke PDF, PPT/PPTX, gambar, dan format lain yang didukung. Pemformatan khusus tetap utuh pada semua file output.

**Apakah superskrip dan subskrip dapat digabungkan dengan gaya pemformatan lain seperti tebal atau miring?**

Ya, Aspose.Slides memungkinkan Anda mencampur berbagai gaya teks dalam satu portion. Anda dapat mengaktifkan tebal, miring, bergaris bawah, dan sekaligus menerapkan superskrip atau subskrip dengan mengonfigurasi properti yang bersangkutan di [PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/).

**Apakah pemformatan superskrip dan subskrip berfungsi untuk teks di dalam tabel, diagram, atau SmartArt?**

Ya, Aspose.Slides mendukung pemformatan di dalam sebagian besar objek, termasuk tabel dan elemen diagram. Saat bekerja dengan SmartArt, Anda harus mengakses elemen yang sesuai (seperti [SmartArtNode](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartartnode/)) dan kontainer teksnya, kemudian mengonfigurasi properti [PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/) dengan cara yang serupa.