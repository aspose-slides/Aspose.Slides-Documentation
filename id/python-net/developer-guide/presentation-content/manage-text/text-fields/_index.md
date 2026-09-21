---
title: Kelola Field Teks dalam Presentasi PowerPoint dengan Python
linktitle: Field Teks
type: docs
weight: 52
url: /id/python-net/text-fields/
keywords:
- field teks
- teks otomatis
- nomor slide
- tanggal dan waktu
- header
- footer
- bagian teks
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Buat, inspeksi, modifikasi, dan hapus field teks dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET. Pertahankan pemformatan dan verifikasi file PPTX serta PPT yang disimpan."
---
## **Ikhtisar**

Sebuah paragraf teks terdiri dari bagian-bagian. Sebuah [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) biasa berisi teks literal; sebuah bagian field juga memiliki [Field](https://reference.aspose.com/slides/id/python-net/aspose.slides/field/) yang tipenya mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Dua bagian dapat menampilkan karakter yang sama sementara hanya satu yang berisi field.

Gunakan [Portion.field](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/field/) untuk membedakannya: nilainya `None` untuk teks biasa. [Portion.add_field](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/add_field/) mengubah sebuah bagian yang ada menjadi field. Simpan label dan nilai dinamisnya dalam bagian terpisah sehingga mengubah nilai tidak juga menggantikan label.

Panduan ini mencakup field di dalam teks, pemformatannya, dan penyimpanan dalam PPTX dan PPT. Untuk frame teks dan paragraf, lihat [Manage Text](/slides/id/python-net/manage-text/).

## **Buat Field Nomor Slide**

Contoh lengkap berikut membuat sebuah kotak teks yang berisi label literal `Slide ` diikuti oleh nomor yang diperbarui secara otomatis. Ia mengatur ukuran, ketebalan, dan warna nomor sebelum menambahkan field, kemudian membuka kembali presentasi yang disimpan dan memeriksa tipe field, teks, dan pemformatannya. Tidak diperlukan file input.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Presentasi baru dimulai dengan nomor slide 1, sehingga teksnya adalah `Slide 1`, dan kedua pemeriksaan mencetak `True`. Nomor tersebut tetap menjadi field setelah dibuka kembali; itu bukan literal `1`. Indeks dalam verifikasi merujuk pada shape dan bagian-bagian yang dibuat oleh contoh ini.

## **Pilih Tipe Field**

[FieldType](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/) menyediakan nilai-nilai bawaan berikut. Berikan nilai yang sesuai ke [add_field](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/add_field/).

| Value | Purpose |
|---|---|
| [slide_number](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/slide_number/) | Nomor slide saat ini. |
| [date_time](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/date_time/) | Tanggal/waktu dalam format default aplikasi perender. |
| [date_time1](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/date_time9/) | Format tanggal bawaan atau kombinasi tanggal/waktu. |
| [date_time10](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/date_time13/) | Format waktu bawaan, dengan opsi detik dan jam 12‑jam. |
| [header](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/header/) | Field header; lihat batas placeholder dan format di bawah. |
| [footer](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/footer/) | Field footer. |

Sebagai contoh, [date_time3](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/date_time3/) mewakili hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format field bawaan, bukan string format tanggal Python yang arbitrer. [language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/language_id/) dan aplikasi yang memproses presentasi dapat memengaruhi hasil yang ditampilkan.

## **Buat Field dari String Internal**

Beban string dari [add_field](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/add_field/) menerima sebuah pengidentifikasi field internal. Gunakan ini ketika mempertahankan pengidentifikasi yang diberikan oleh aplikasi lain yang tidak memiliki nilai bawaan. Anda juga dapat membuat sebuah [FieldType](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/__init__/) dari pengidentifikasi tersebut. [FieldType.internal_string](https://reference.aspose.com/slides/id/python-net/aspose.slides/fieldtype/internal_string/) menampilkan pengidentifikasi itu untuk inspeksi.

Contoh ini menyimpan field `custom-report-id` khusus aplikasi dengan teks cadangan `Report-042`. Pengidentifikasi tidak mendaftarkan perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak dikenal. Aplikasi yang memahami pengidentifikasi ini harus menyediakan maknanya dan memperbarui nilainya.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Setelah siklus PPTX ini, tipe adalah `custom-report-id` dan teksnya adalah `Report-042`. Menyertakan string seperti `%Y-%m-%d` akan memberi nama tipe field; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format apa pun, gunakan teks biasa.

## **Periksa, Modifikasi, dan Hapus Field Tanggal/Waktu**

Baca dan ubah field yang ada melalui [Field.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/field/type/). Periksa bahwa field ada sebelum mengakses tipenya. Untuk menghentikan pembaruan otomatis, panggil [Portion.remove_field](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/remove_field/). Ini mempertahankan bagian dan teksnya saat ini sambil menghapus asosiasi field. Jika Anda memerlukan nilai tetap tertentu, tetapkan teks tersebut setelah menghapus field.

Untuk pengaturan API yang terkait dengan pemrosesan field tanggal/waktu, lihat [Presentation.current_date_time](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/current_date_time/). Contoh di bawah menggunakan tanggal persetujuan eksplisit saat mengonversi field menjadi teks biasa. Tuple nama bulan dalam bahasa Inggris menjaga tanggal tetap terlepas dari locale sistem.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja. File ini berisi dua shape teks bernama, `UpdatedAt` dan `ApprovedDate`, masing-masing dengan field tanggal/waktu, plus label teks biasa. Contoh berikut melintasi shape teks level atas pada slide biasa. Ia mengubah field tanggal/waktu menjadi format tanggal panjang dan membuatnya miring, sambil mempertahankan pemformatan lainnya. Hanya field di `ApprovedDate` yang menjadi teks tetap.

Contoh mengenali pengidentifikasi internal bawaan `datetime` dan `datetime1` hingga `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran kontainer teks mereka sendiri dan berada di luar lingkup contoh ini.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Setelah dibuka kembali, `UpdatedAt` memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` tidak memiliki field dan berisi `05 April 2030`. Kedua bagian tanggal tersebut miring, dan ukuran font, pengaturan tebal, serta warna aslinya tetap utuh. Label teks biasa tidak berubah. Verifikasi membaca bagian pertama dari dua shape yang dikenal dalam contoh yang diberikan.

## **Pertahankan Pemformatan Teks**

Bekerja dengan bagian yang ada saat menambahkan field, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan bagian tersebut. Gunakan [Portion.portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/portion_format/) untuk mengubah hanya properti yang diperlukan, seperti contoh untuk warna atau italic.

Hindari membangun kembali seluruh frame teks hanya untuk memperbarui satu field: hal itu dapat menghilangkan batas bagian asli dan pemformatannya masing-masing. Juga bedakan pemformatan yang diatur secara eksplisit dari pemformatan yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/python-net/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Field dan Placeholder Header/Footer**

Sebuah field adalah bagian dari bagian teks. Sebuah placeholder adalah shape dengan peran presentasi, seperti footer atau nomor slide. Menambahkan field ke kotak teks biasa tidak mengubah shape tersebut menjadi placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitas pada slide, tata letak, dan master, termasuk propagasi ke slide yang bergantung. Sebuah field nomor pada kotak teks khusus dapat berguna bahkan ketika Anda tidak menggunakan placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus field dari kotak teks yang tidak terkait.

Tipe header dan footer bawaan tidak membuat placeholder yang sesuai atau menyediakan kontennya. Khususnya, slide PowerPoint reguler tidak memiliki placeholder header; header berada pada halaman catatan dan handout. Jangan menganggap bahwa field header atau footer pada shape apa pun akan otomatis memperoleh teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja tersebut, lihat [Presentation Headers and Footers](/slides/id/python-net/presentation-header-and-footer/).

## **Keterbatasan PPTX dan PPT**

Periksa baik tipe field maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan identifier tidak membuktikan bahwa sebuah aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Menyimpan identifier field internal bersamaan dengan teks field. Dalam pemeriksaan siklus, tipe bawaan dan identifier khusus yang digunakan di atas bertahan setelah menyimpan dan membuka kembali. Tipe khusus yang tidak dikenal mempertahankan teks cadangannya; tidak memperoleh logika perhitungan otomatis. Aplikasi lain mungkin memperlakukan identifier yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi field legacy dan memiliki kompatibilitas yang lebih terbatas. Dalam pemeriksaan siklus, field nomor slide dan field tanggal/waktu bawaan bertahan setelah menyimpan dan membuka kembali. Sebuah field khusus dalam kotak teks slide biasa dibuka kembali dengan identifiernya tetapi dengan teks `*`; field header dalam konteks yang sama juga menghasilkan `*`. Jangan mengandalkan field khusus atau konteks field yang tidak didukung mempertahankan teks yang terlihat. |

Untuk output yang dapat dipindahkan dan tetap, ubah field yang tidak didukung menjadi teks biasa dan tetapkan secara eksplisit nilai yang Anda inginkan sebelum menyimpan. Ini mempertahankan teks yang dipilih tetapi sengaja menghentikan pembaruan otomatis. Uji aplikasi target juga ketika perhitungan ulang fieldnya menjadi bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya dapat mengetahui apakah nomor atau tanggal yang ditampilkan adalah field?**

Periksa [Portion.field](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/field/). Nilai selain `None` menandakan sebuah field; teks yang ditampilkan saja tidak dapat memberi tahu Anda.

**Apakah menghapus field menghapus teks atau pemformatannya?**

Tidak. [remove_field](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/remove_field/) mengubah bagian yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya jika Anda memerlukan tanggal beku tertentu atau nilai cadangan.

**Apakah string internal dapat mendefinisikan format tanggal atau formula baru?**

Tidak. Itu mengidentifikasi tipe field. Identifier yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal Python. Gunakan tipe bawaan yang didukung atau format nilai sendiri sebagai teks biasa.

**Mengapa memeriksa kembali presentasi setelah menyimpannya?**

Identifier field, teks yang dihitung, dan pemformatan adalah hal terpisah yang harus diverifikasi. Konversi format dapat mengubah hasil yang terlihat bahkan ketika identifier field masih ada.