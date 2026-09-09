---
title: Mengambil dan Memperbarui Informasi Presentasi dengan Python via Java
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/python-java/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- ambil properti
- baca properti
- ubah properti
- modifikasi properti
- perbarui properti
- periksa PPTX
- periksa PPT
- periksa ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Python via Java untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Gambaran Umum**

Aspose.Slides dapat mengidentifikasi format presentasi dan membaca metadata dokumen tanpa membuat model objek presentasi yang lengkap. Hal ini berguna ketika Anda perlu mengklasifikasikan file, membuat inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Contoh-contoh memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Setiap contoh memulai JVM jika belum berjalan. Sediakan file presentasi yang ada pada path yang digunakan dalam contoh.

Artikel ini menunjukkan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/) dan [PresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/), serta pembaruan terarah melalui [DocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/).

## **Periksa Format Presentasi**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Metode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#getLoadFormat) melaporkan format yang terdeteksi, seperti PPTX, PPT, atau ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Bangun Inventaris Presentasi Ringan**

Ketika Anda memproses banyak file presentasi, Anda mungkin memerlukan inventaris kompak untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk memperoleh objek [PresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/), kemudian panggil [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#readDocumentProperties) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) atau memaksa Anda menelusuri model objek presentasi yang lengkap.

Properti tambahan yang diekspos oleh [DocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/) menyediakan nilai inventaris berikut:

| Metode | Nilai inventaris |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getSlides) | Jumlah total slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Jumlah slide tersembunyi. |
| [getNotes](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getNotes) | Jumlah slide yang berisi catatan. |
| [getParagraphs](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getParagraphs) | Jumlah total paragraf, bila tersedia. |
| [getWords](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getWords) | Jumlah total kata. |
| [getMultimediaClips](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Jumlah total klip audio dan video. |

Contoh berikut membaca nilai-nilai tersebut tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan mencetak inventaris kompak. Ia juga menggabungkan [getHeadingPairs](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getHeadingPairs) dengan [getTitlesOfParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getTitlesOfParts) untuk menampilkan grup konten seperti font, tema, dan judul slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Setiap [HeadingPair](https://reference.aspose.com/slides/id/python-java/aspose.slides/headingpair/) menyediakan nama grup dan jumlah item dalam grup tersebut. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getTitlesOfParts) mengembalikan array datar berurutan, sehingga konsumsi jumlah judul berturut-turut yang ditentukan oleh setiap heading pair.

### **Metadata Tersimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#readDocumentProperties) mencerminkan metadata yang tersedia dalam dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung ulang nilai-nilai ini pada pemanggilan ini. Properti yang hilang direpresentasikan dengan nilai default, dan nilai yang disimpan mungkin usang jika aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen tambahan untuk hitungan slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta heading pair dan judul bagian. Ketersediaannya tergantung pada properti mana yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang sesuai. Jika suatu properti tidak ada atau tidak diperbarui oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang tersimpan atau nilai default alih-alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik dokumen umum, seperti hitungan halaman, paragraf, dan kata, tetapi nilai-nilai ini tidak selalu cocok dengan setiap properti tambahan khusus PowerPoint. Metadata slide tersembunyi, slide catatan, multimedia, heading‑pair, dan judul bagian mungkin tidak tersedia, dan properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau array kosong sebagai bukti otoritatif bahwa konten terkait tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan awal. Muat presentasi dan inspeksi model objek secara langsung ketika hasil harus mencerminkan perubahan dalam memori atau ketika Anda perlu memverifikasi konten presentasi yang sebenarnya.

## **Perbarui Properti Presentasi**

Properti yang dikembalikan oleh [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#readDocumentProperties) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Terapkan perubahan dengan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), lalu tulis presentasi terikat dengan [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Gambar berikut menampilkan properti dokumen asli dari presentasi PowerPoint.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh berikut mengubah judul dan waktu terakhir disimpan serta menulis hasilnya ke file baru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Gambar berikut menampilkan properti dokumen yang diubah dari presentasi PowerPoint.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan terkait dan pengaturan perlindungan, lihat artikel berikut:

- [Presentasi dengan Proteksi Sandi](/slides/id/python-java/password-protected-presentation/)
- [Presentasi dengan Proteksi Penulisan](/slides/id/python-java/write-protected-presentation/)

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font tersemat dan yang mana?**

Muat presentasi dan gunakan [Presentation.getFontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getFontsManager). Panggil [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) untuk memperoleh font yang tersemat dan [FontsManager.getFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getFonts) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk rendering tetapi tidak tersemat.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Ketika metadata dokumen yang disimpan cukup, baca [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getHiddenSlides) melalui [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) dan [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi dalam memori, metadata yang disimpan mungkin hilang atau usang, atau Anda perlu memverifikasi nilai hidup, iterasi melalui [Presentation.getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides) dan periksa metode [Slide.getHidden](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getHidden) pada setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Muat presentasi dan panggil [Presentation.getSlideSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlideSize). Gunakan [SlideSize.getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesize/#getSize), dan [SlideSize.getOrientation](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesize/#getOrientation) untuk membandingkan pengaturan saat ini dengan preset dan dimensi yang diharapkan.

**Apakah ada cara cepat untuk melihat apakah diagram merujuk ke sumber data eksternal?**

Ya. Temukan setiap [Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/) dan panggil [ChartData.getDataSourceType](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getDataSourceType). Untuk workbook eksternal, panggil [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Jenis sumber data dan path mengidentifikasi referensi eksternal, tetapi verifikasi ketersediaan target memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat rendering atau ekspor PDF?**

Tidak ada properti kompleksitas tunggal. Telusuri [Presentation.getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides) dan koleksi [BaseSlide.getShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getShapes) pada setiap slide. Gunakan jumlah shape serta kehadiran gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukur rendering atau ekspor representatif sebelum menganggap slide sebagai bottleneck kinerja yang terkonfirmasi.