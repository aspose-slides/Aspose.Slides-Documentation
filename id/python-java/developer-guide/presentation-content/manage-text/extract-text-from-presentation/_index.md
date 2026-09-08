---
title: Ekstraksi Teks Tingkat Lanjut dari Presentasi di Python via Java
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/python-java/extract-text-from-presentation/
keywords:
- ekstrak teks
- ekstrak teks dari slide
- ekstrak teks dari presentasi
- ekstrak teks dari PowerPoint
- ekstrak teks dari OpenDocument
- ekstrak teks dari PPT
- ekstrak teks dari PPTX
- ekstrak teks dari ODP
- ambil teks
- ambil teks dari slide
- ambil teks dari presentasi
- ambil teks dari PowerPoint
- ambil teks dari OpenDocument
- ambil teks dari PPT
- ambil teks dari PPTX
- ambil teks dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Dengan cepat mengekstrak teks dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via Java. Ikuti panduan sederhana langkah demi langkah kami untuk menghemat waktu."
---
## **Gambaran Umum**

Men­ek­strak te­ks da­ri pre­sen­ta­si mer­eku­pak tugas yan­g um­um nam­un per­ta­ngan bag­i peng­embang yang ber­ker­ja den­gan kon­ten slide. Ba­ik an­da men­a­ng­ga­li file Microsoft PowerPoint da­lam format PPT atau PPTX, ma­tu pre­sen­ta­si OpenDocument (ODP), meng­a­kses dan men­ga­mbil da­ta teks da­pat men­jan­di krusial un­tuk an­a­lis, oto­ma­si, peng­in­de­ksan, a­ta tu­ju­an migrasi kon­ten.

Ar­ti­kel in­i mem­be­ri­ka­n pa­ndan kom­pre­hen­si­f tentang cara men­gek­strak te­ks sec­ara ef­fi­si en da­ri ber­ba­gi format pre­sen­ta­si, ter­ma­suk PPT, PPTX, dan ODP, meng­gu­na​k Aspose.Slides un­tuk Python via Java. An­da a­kan be­la­ju men­ga­ji cara men­elusuri ele­men‑pre­sen­ta­si sec­ara sis­te­ma­ti­k untuk men­gan­tuk kon­te­n teks yan­g an­da butuh­kan da­lam­nya akurat.

## **Mengekstrak Teks dari Slide**

Aspose.Slides untuk Python via Java menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/). Kelas ini menyediakan be­ra­pa me­tho­de sta­tik yan­g o­ver­load un­tuk men­gek­strak se­mu­ah teks da­ri se­bu­ah pre­sen­ta­si a­ta slide. Un­tuk men­gek­strak teks da­ri slide da­lam pre­sen­ta­si, guna­kan me­tho­de [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/#getAllTextBoxes). Me­tho­de in­i men­ge­ri obyek be­rti­pe [BaseSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/) se­ba­gi pa­ra­me­ter. Sa­tai dijalankan, me­tho­de ini men­scan sel­uruh slide un­tuk teks dan men­ge­kembal­ikan ar­ray ob­yek be­rti­pe [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/), meme­ri­kah pem­for­ma­si teks apa pun.

Potongan kode berikut mengekstrak semua teks dari slide pertama presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Mengekstrak Teks dari Presentasi**

Un­tuk memindai teks da­ri se­mu­ah pre­sen­ta­si, guna­kan me­tho­de sta­tik [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/#getAllTextFrames) yan­g disedi­akan o­leh kla­sa [SlideUtil](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/). Me­tho­de in­i men­terima dua pa­ra­me­ter:

1. Pert­ama, ob­yek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yan­g me­wakili pre­sen­ta­si PowerPoint a­ta OpenDocument dar­i mana te­ks akan diekstrak.
1. Kedua, na­ila `bool` yan­g men­unjuk apa slide ma­ster per­lu di­si­mpul pas mem­indai teks da­ri pre­sen­ta­si.

Me­tho­de in­i mengembalikan ar­ray ob­yek be­rti­pe [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/), ter­masuk in­for­ma­si pem­for­ma­si teks. Kode di bawah ini memindai teks dan detail pemformatan dari sebuah presentasi, termasuk slide master.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Ekstraksi Teks Terkategorisasi dan Cepat**

Kla­sa [PresentationFactory](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/) juga menyediakan me­tho­de un­tuk men­gek­strak se­mu­ah teks da­ri pre­sen­ta­si:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Mengambil teks dari sebuah file.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Mengambil teks dari sebuah aliran.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Mengambil teks dari sebuah aliran menggunakan opsi pemuatan.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Argumen enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/textextractionarrangingmode/) men­unjuk mode un­tuk mengatu­r hasil ek­strak teks dan dapat di­at­ur ke nilai ber­ikut:

- [Unarranged](https://reference.aspose.com/slides/id/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - Teks mentah tanpa memperhatikan posisinya pada slide.
- [Arranged](https://reference.aspose.com/slides/id/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - Teks diatur dalam urutan yang sama dengan pada slide.

Mode unarranged dapat digunakan ketika kecepatan menjadi kritis; mode ini lebih cepat daripada mode arranged.

[PresentationText](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationtext/) mewakili teks mentah yang diekstrak dari presentasi. Metode [getSlidesText](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationtext/#getSlidesText) mengembalikan array objek bertipe `SlideText`. Setiap objek mewakili teks pada slide yang bersangkutan. Objek bertipe `SlideText` memiliki metode berikut:

- `getText` - Teks dalam bentuk slide.
- `getMasterText` - Teks dalam bentuk slide master yang terkait dengan slide ini.
- `getLayoutText` - Teks dalam bentuk slide tata letak yang terkait dengan slide ini.
- `getNotesText` - Teks dalam bentuk slide catatan yang terkait dengan slide ini.
- `getCommentsText` - Teks dalam komentar yang terkait dengan slide ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**Seberapa cepat Aspose.Slides memproses presentasi besar saat ekstraksi teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [presentasi besar](/slides/id/python-java/open-presentation/), sehingga cocok untuk skenario pemrosesan waktu nyata atau dalam jumlah besar.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan grafik dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait grafik, sehingga Anda dapat mengakses dan menganalisis konten teks dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi percobaan gratis Aspose.Slides, meskipun akan memiliki [batasan tertentu](/slides/id/python-java/licensing/), seperti memproses hanya sejumlah slide terbatas. Untuk penggunaan tanpa batas dan menangani presentasi yang lebih besar, disarankan membeli lisensi penuh.