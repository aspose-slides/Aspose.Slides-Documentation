---
title: Animasi Teks PowerPoint di Python via Java
linktitle: Teks Animasi
type: docs
weight: 60
url: /id/python-java/animated-text/
keywords:
- teks animasi
- animasi teks
- paragraf animasi
- animasi paragraf
- efek animasi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat teks animasi dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via Java, dengan contoh kode Python yang mudah diikuti dan dioptimalkan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan teks animasi di Aspose.Slides dengan menerapkan efek animasi pada paragraf individu dan mengambil efek yang sudah ditetapkan pada paragraf dalam sebuah frame teks. Fokusnya pada metode API yang digunakan untuk menambahkan animasi tingkat paragraf dan memeriksa efek animasi paragraf yang sudah ada dalam sebuah presentasi.

## **Menambahkan Efek Animasi ke Paragraf**

Metode [addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect) dari kelas [Sequence](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/) memungkinkan Anda menambahkan efek animasi ke satu paragraf. Kode contoh ini menunjukkan cara menambahkan efek animasi ke satu paragraf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Pilih paragraf untuk menambahkan efek.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Tambahkan efek animasi Fly ke paragraf yang dipilih.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mendapatkan Efek Animasi Paragraf**

Anda mungkin ingin mengetahui efek animasi yang ditambahkan ke sebuah paragraf—misalnya, dalam satu skenario, Anda ingin mendapatkan efek animasi dalam sebuah paragraf karena Anda berencana menerapkan efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides for Python via Java memungkinkan Anda mendapatkan semua efek animasi yang diterapkan pada paragraf yang terdapat dalam sebuah frame teks (shape). Kode contoh ini menunjukkan cara mendapatkan efek animasi dalam sebuah paragraf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**Bagaimana perbedaan animasi teks dengan transisi slide, dan dapatkah keduanya digabungkan?**

Animasi teks mengendalikan perilaku objek seiring waktu pada sebuah slide, sementara [transitions](/slides/id/python-java/slide-transition/) mengendalikan cara slide berpindah. Kedua hal tersebut independen dan dapat digunakan bersamaan; urutan pemutaran diatur oleh garis waktu animasi dan pengaturan transisi.

**Apakah animasi teks dipertahankan saat diekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, sehingga Anda hanya akan melihat satu keadaan slide tanpa gerakan. Untuk mempertahankan pergerakan, gunakan ekspor [video](/slides/id/python-java/convert-powerpoint-to-video/) atau [HTML](/slides/id/python-java/export-to-html5/).

**Apakah animasi teks berfungsi pada tata letak dan master slide?**

Efek yang diterapkan pada objek tata letak/master diwariskan ke slide, namun timing dan interaksinya dengan animasi tingkat slide tergantung pada urutan akhir pada slide.