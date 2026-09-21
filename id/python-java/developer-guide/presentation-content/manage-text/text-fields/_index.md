---
title: Kelola Field Teks di Presentasi PowerPoint dengan Python melalui Java
linktitle: Field Teks
type: docs
weight: 52
url: /id/python-java/text-fields/
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
- Java
- Aspose.Slides
description: "Buat, inspeksi, modifikasi, dan hapus field teks dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java. Pertahankan pemformatan dan verifikasi file PPTX dan PPT yang disimpan."
---
## **Ikhtisar**

Sebuah paragraf teks terdiri dari bagian. Sebuah [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) biasa berisi teks literal; sebuah bagian [Field](https://reference.aspose.com/slides/id/python-java/aspose.slides/field/) juga memiliki tipe yang mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Dua bagian dapat menampilkan karakter yang sama sementara hanya satu yang berisi field.

Gunakan [Portion.getField](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getField) untuk membedakannya: nilai yang dikembalikan adalah `None` untuk teks biasa. [Portion.addField](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#addField) mengubah bagian yang ada menjadi field. Simpan label dan nilai dinamisnya dalam bagian terpisah sehingga mengubah nilai tidak juga menggantikan label.

Panduan ini mencakup field di dalam teks, pemformatannya, dan penyimpanannya dalam PPTX dan PPT. Untuk bingkai teks dan paragraf, lihat [Manage Text](/slides/id/python-java/manage-text/).

## **Buat Field Nomor Slide**

Contoh lengkap berikut membuat kotak teks yang berisi label literal `Slide ` diikuti oleh nomor yang diperbarui secara otomatis. Itu mengatur ukuran, ketebalan, dan warna nomor sebelum menambahkan field, lalu membuka kembali presentasi yang disimpan dan memeriksa tipe field, teks, dan pemformatannya. Tidak diperlukan file input.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Presentasi baru dimulai dengan nomor slide 1, sehingga teksnya adalah `Slide 1`, dan kedua pemeriksaan mencetak `True`. Nomor tersebut tetap menjadi field setelah dibuka kembali; itu bukan literal `1`. Indeks dalam verifikasi mengacu pada shape dan bagian yang dibuat oleh contoh ini.

## **Pilih Tipe Field**

[FieldType](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/) menyediakan metode berikut untuk memperoleh nilai yang sudah ditentukan. Berikan nilai yang sesuai ke [addField](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#addField).

| Metode | Tujuan |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getSlideNumber) | Nomor slide saat ini. |
| [getDateTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getDateTime) | Tanggal/waktu dalam format default aplikasi rendering. |
| [getDateTime1](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getDateTime9) | Format tanggal atau kombinasi tanggal/waktu yang sudah ditentukan. |
| [getDateTime10](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getDateTime13) | Format waktu yang sudah ditentukan, dengan pilihan detik dan jam 12-jam. |
| [getHeader](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getHeader) | Field header; lihat batasan placeholder dan format di bawah. |
| [getFooter](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getFooter) | Field footer. |

Sebagai contoh, [getDateTime3](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getDateTime3) mewakili hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format field yang telah ditentukan, bukan string format tanggal Python arbitrer. Bahasa yang diatur dengan [setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) dan aplikasi yang memproses presentasi dapat mempengaruhi hasil yang ditampilkan.

## **Buat Field dari String Internal**

Overload string dari [addField](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#addField) menerima identifier field internal. Gunakan ini saat mempertahankan identifier yang diberikan oleh aplikasi lain yang tidak memiliki nilai yang telah ditentukan. Anda juga dapat membuat [FieldType](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#FieldType) dari identifier tersebut. [FieldType.getInternalString](https://reference.aspose.com/slides/id/python-java/aspose.slides/fieldtype/#getInternalString) menampilkan identifier itu untuk inspeksi.

Contoh ini menyimpan field `custom-report-id` spesifik aplikasi dengan teks cadangan `Report-042`. Identifier tersebut tidak mendaftarkan perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak diketahui. Aplikasi yang memahami identifier ini harus menyediakan maknanya dan memperbarui nilainya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Setelah siklus PPTX ini, tipe menjadi `custom-report-id` dan teksnya `Report-042`. Mengirimkan string seperti `yyyy-MM-dd` akan memberi nama tipe field; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format arbitrer, gunakan teks biasa.

## **Periksa, Modifikasi, dan Hapus Field Tanggal/Waktu**

Ganti field yang ada melalui [Field.setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/field/#setType). Periksa bahwa field ada sebelum mengakses tipenya. Untuk menghentikan pembaruan otomatis, panggil [Portion.removeField](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#removeField). Ini mempertahankan bagian dan teksnya saat ini sambil menghapus asosiasi field. Jika Anda memerlukan nilai tetap tertentu, tetapkan teks itu setelah menghapus field.

Untuk pengaturan API yang terkait dengan pemrosesan field tanggal/waktu, lihat [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#setCurrentDateTime). Contoh di bawah menggunakan tanggal persetujuan eksplisit saat mengubah field menjadi teks biasa.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja. File tersebut berisi dua shape teks bernama, `UpdatedAt` dan `ApprovedDate`, masing-masing dengan field tanggal/waktu, serta label teks biasa. Contoh berikut menelusuri shape teks tingkat atas pada slide reguler. Ia mengubah field tanggal/waktu menjadi format tanggal panjang dan membuatnya miring, sambil mempertahankan pemformatan lainnya. Hanya field di `ApprovedDate` yang menjadi teks tetap.

Contoh ini mengenali identifier internal bawaan `datetime` dan `datetime1` sampai `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran kontainer teks mereka sendiri dan berada di luar ruang lingkup contoh ini.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Gunakan nama bulan bahasa Inggris terlepas dari locale sistem.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Setelah dibuka kembali, `UpdatedAt` memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` tidak memiliki field dan berisi `05 April 2030`. Kedua bagian tanggal berformat miring, dan ukuran font, penebalan, serta warna aslinya tetap utuh. Label teks biasa tidak berubah. Verifikasi membaca bagian pertama dari dua shape yang dikenal dalam contoh yang disediakan.

## **Pertahankan Pemformatan Teks**

Bekerja dengan bagian yang ada saat menambahkan field, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan bagian tersebut. Gunakan [Portion.getPortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getPortionFormat) untuk mengubah hanya properti yang diperlukan, seperti contoh untuk warna atau miring.

Hindari membangun ulang seluruh bingkai teks hanya untuk memperbarui satu field: melakukannya dapat kehilangan batas bagian asli dan pemformatannya masing-masing. Juga bedakan pemformatan yang disetel secara eksplisit dari pemformatan yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/python-java/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Field dan Placeholder Header/Footer**

Field merupakan bagian dari bagian teks. Placeholder adalah shape dengan peran presentasi, seperti footer atau nomor slide. Menambahkan field ke kotak teks biasa tidak mengubah shape tersebut menjadi placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitas pada slide, tata letak, dan master, termasuk penyebaran ke slide tergantung. Field nomor dalam kotak teks kustom dapat berguna bahkan ketika Anda tidak menggunakan placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus field dari kotak teks yang tidak terkait.

Tipe header dan footer yang telah ditentukan tidak membuat placeholder yang sesuai atau menyediakan kontennya. Khususnya, slide PowerPoint biasa tidak memiliki placeholder header; header berada pada halaman catatan dan handout. Jangan mengasumsikan bahwa field header atau footer dalam shape apa pun akan otomatis memperoleh teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja tersebut, lihat [Presentation Headers and Footers](/slides/id/python-java/presentation-header-and-footer/).

## **Batasan PPTX dan PPT**

Periksa baik tipe field maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan identifier tidak membuktikan bahwa aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Perilaku dan keterbatasan field |
|---|---|
| PPTX | Menyimpan identifier field internal bersamaan dengan teks field. Dalam pemeriksaan putar balik, tipe yang telah ditentukan dan identifier khusus yang digunakan di atas tetap ada setelah menyimpan dan membuka kembali. Tipe khusus yang tidak dikenal mempertahankan teks cadangannya; ia tidak memperoleh logika perhitungan otomatis. Aplikasi lain mungkin memperlakukan identifier yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi field warisan dan memiliki kompatibilitas yang lebih terbatas. Dalam pemeriksaan putar balik, field nomor slide dan field tanggal/waktu yang telah ditentukan tetap ada setelah menyimpan dan membuka kembali. Field khusus dalam kotak teks slide biasa dibuka kembali dengan identifiernya tetapi dengan teks `*`; field header dalam konteks yang sama juga menghasilkan `*`. Jangan bergantung pada field khusus atau konteks field yang tidak didukung untuk mempertahankan teks yang terlihat. |

Untuk output yang dapat dipindahkan dan tetap, ubah field yang tidak didukung menjadi teks biasa dan secara eksplisit tetapkan nilai yang Anda inginkan sebelum menyimpan. Ini mempertahankan teks yang dipilih tetapi secara sengaja menghentikan pembaruan otomatis. Uji aplikasi target juga ketika perhitungan ulang field-nya menjadi bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya dapat mengetahui apakah nomor atau tanggal yang ditampilkan adalah field?**

Periksa [Portion.getField](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getField). Nilai selain `None` mengidentifikasi sebuah field; teks yang ditampilkan saja tidak dapat memberi tahu Anda.

**Apakah menghapus field menghapus teks atau pemformatannya?**

Tidak. [removeField](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#removeField) mengubah bagian yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya jika Anda memerlukan tanggal beku tertentu atau nilai cadangan.

**Apakah string internal dapat mendefinisikan format tanggal atau formula baru?**

Tidak. Itu mengidentifikasi tipe field. Identifier yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal Python. Gunakan tipe yang didukung atau format nilai secara manual sebagai teks biasa.

**Mengapa memeriksa kembali presentasi setelah menyimpannya?**

Identifier field, teks yang dihitung, dan pemformatan adalah hal terpisah yang perlu diverifikasi. Konversi format dapat mengubah hasil yang terlihat meskipun identifier field masih ada.