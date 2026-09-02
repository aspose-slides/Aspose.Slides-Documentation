---
title: Mengambil dan Memperbarui Informasi Presentasi dengan Python
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/python-net/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- mengambil properti
- membaca properti
- mengubah properti
- memodifikasi properti
- memperbarui properti
- memeriksa PPTX
- memeriksa PPT
- memeriksa ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Python untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Ikhtisar**

Aspose.Slides dapat mengidentifikasi format presentasi dan membaca metadata dokumen tanpa membuat model objek presentasi yang lengkap. Ini berguna ketika Anda perlu mengklasifikasikan file, membuat inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Artikel ini menunjukkan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/) dan [PresentationInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/), serta pembaruan terarah melalui [DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/).

## **Periksa Format Presentasi**

Gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Properti [PresentationInfo.load_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/load_format/) melaporkan format yang terdeteksi, seperti PPTX, PPT, atau ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Buat Inventaris Presentasi Ringan**

Ketika Anda memproses banyak file presentasi, mungkin Anda memerlukan inventaris ringkas untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) untuk mendapatkan objek [PresentationInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/), lalu panggil [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/read_document_properties/) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) atau mengharuskan Anda menelusuri model objek presentasi secara lengkap.

Properti tambahan yang disediakan oleh [DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/) memberikan nilai inventaris berikut:

| Properti | Nilai inventaris |
| --- | --- |
| [slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/slides/id/) | Jumlah total slide. |
| [hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/hidden_slides/) | Jumlah slide tersembunyi. |
| [notes](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/notes/) | Jumlah slide yang berisi catatan. |
| [paragraphs](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/paragraphs/) | Jumlah total paragraf, bila tersedia. |
| [words](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/words/) | Jumlah total kata. |
| [multimedia_clips](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/multimedia_clips/) | Jumlah total klip audio dan video. |

Contoh berikut membaca nilai‑nilai ini tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan mencetak inventaris ringkas. Ia juga menggabungkan [heading_pairs](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/heading_pairs/) dengan [titles_of_parts](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/titles_of_parts/) untuk menampilkan grup konten seperti font, tema, dan judul slide.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Setiap [HeadingPair](https://reference.aspose.com/slides/id/python-net/aspose.slides/headingpair/) menyediakan nama grup dan jumlah item dalam grup tersebut. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/titles_of_parts/) adalah koleksi datar berurutan, sehingga konsumsi jumlah judul berurutan yang ditentukan oleh setiap heading pair.

### **Metadata Tersimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/read_document_properties/) mencerminkan metadata yang tersedia dalam dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung ulang nilai‑nilai ini pada pemanggilan ini. Properti yang tidak ada diwakili oleh nilai default, dan nilai yang disimpan dapat usang jika aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen tambahan untuk jumlah slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta heading pair dan judul bagian. Ketersediaannya tergantung pada properti mana yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang bersesuaian. Jika suatu properti tidak ada atau tidak diperbarui oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang disimpan atau nilai default alih‑alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik umum dokumen, seperti jumlah halaman, paragraf, dan kata, tetapi nilai‑nilai ini tidak selalu dapat dipetakan ke setiap properti tambahan khusus PowerPoint. Metadata slide tersembunyi, slide catatan, multimedia, heading‑pair, dan judul bagian mungkin tidak tersedia, dan properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau koleksi kosong sebagai bukti otoritatif bahwa konten yang bersangkutan tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan awal. Muat presentasi dan periksa model objeknya yang hidup ketika hasil harus mencerminkan perubahan dalam memori atau ketika Anda perlu memverifikasi konten presentasi yang sebenarnya.

## **Perbarui Properti Presentasi**

Properti yang dikembalikan oleh [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/read_document_properties/) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Terapkan perubahan dengan [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/update_document_properties/), lalu tulis presentasi yang terikat dengan [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Gambar berikut menunjukkan properti dokumen asli.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh berikut mengubah judul dan waktu terakhir disimpan serta menulis hasilnya ke file baru:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Gambar berikut menunjukkan properti dokumen yang telah diubah.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan terkait dan pengaturan perlindungan, lihat artikel berikut:

- [Presentasi dengan Perlindungan Kata Sandi](/slides/id/python-net/password-protected-presentation/)
- [Presentasi dengan Perlindungan Penulisan](/slides/id/python-net/write-protected-presentation/)

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font disematkan dan yang mana?**

Muat presentasi dan gunakan [Presentation.fonts_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/fonts_manager/). Panggil [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) untuk memperoleh font yang disematkan dan [FontsManager.get_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_fonts/) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk merender tetapi tidak disematkan.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Ketika metadata dokumen yang disimpan cukup, baca [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/hidden_slides/) melalui [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) dan [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/read_document_properties/). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi dalam memori, metadata yang disimpan mungkin hilang atau usang, atau Anda perlu memverifikasi nilai hidup, iterasikan melalui [Presentation.slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slides/id/) dan periksa properti [Slide.hidden](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/hidden/) pada setiap slide sebagai gantinya.

**Bisakah saya mendeteksi apakah ukuran slide khusus dan orientasi digunakan, serta apakah mereka berbeda dari default?**

Ya. Muat presentasi dan baca [Presentation.slide_size](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slide_size/). Periksa [SlideSize.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidesize/size/), dan [SlideSize.orientation](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidesize/orientation/) untuk membandingkan pengaturan saat ini dengan preset dan dimensi yang diharapkan.

**Apakah ada cara cepat untuk melihat apakah grafik merujuk ke sumber data eksternal?**

Ya. Temukan setiap [Chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/) dan periksa [ChartData.data_source_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/). Untuk buku kerja eksternal, baca [ChartData.external_workbook_path](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Jenis sumber data dan jalur mengidentifikasi referensi eksternal, tetapi memverifikasi apakah target tersedia memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya dapat menilai slide “berat” yang mungkin memperlambat rendering atau ekspor PDF?**

Tidak ada properti kompleksitas tunggal. Telusuri [Presentation.slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slides/id/) dan koleksi [BaseSlide.shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/shapes/) setiap slide. Gunakan hitungan bentuk dan keberadaan gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukur rendering atau ekspor perwakilan sebelum menganggap slide sebagai bottleneck kinerja yang terkonfirmasi.