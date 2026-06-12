---
title: Solusi yang Berfungsi untuk Mengubah Ukuran Lembar Kerja
type: docs
weight: 40
url: /id/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- pengubahan ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—skala bingkai atau lembar kerja—di format PPT dan PPTX."
---
{{% alert color="primary" %}} 

Telah diamati bahwa lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose mengalami perubahan ukuran ke skala yang tidak teridentifikasi setelah aktivasi pertama. Perilaku ini menghasilkan perbedaan visual yang nyata dalam presentasi antara keadaan objek OLE sebelum dan sesudah aktivasi. Kami telah menyelidiki masalah ini secara mendetail dan menyediakan solusi, yang dibahas dalam artikel ini.

{{% /alert %}} 

## **Latar Belakang**

Dalam artikel [Kelola OLE](/slides/id/python-net/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk Python via .NET. Untuk mengatasi [masalah pratinjau objek](/slides/id/python-net/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Dalam presentasi keluaran, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar lembar kerja, buku kerja Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun yang diinginkan pada buku kerja Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar buku kerja Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan buku kerja Excel yang disematkan. 

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran sendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE. 

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala ukuran bingkai OLE dalam presentasi PowerPoint agar cocok dengan tinggi dan lebar jumlah baris dan kolom yang diinginkan dalam bingkai OLE.
- Pertahankan ukuran bingkai OLE tetap dan skala ukuran baris serta kolom yang berpartisipasi agar sesuai dengan ukuran bingkai OLE yang dipilih.

### **Skala Ukuran Bingkai OLE**

Dalam pendekatan ini, kita akan mempelajari cara mengatur ukuran bingkai OLE dari buku kerja Excel yang disematkan agar cocok dengan ukuran kumulatif baris dan kolom yang berpartisipasi dalam lembar kerja Excel.

Misalkan kita memiliki lembar Excel templat dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Dalam skenario ini, ukuran bingkai objek OLE pertama-tama akan dihitung berdasarkan tinggi baris kumulatif dan lebar kolom kumulatif dari baris dan kolom yang berpartisipasi dalam buku kerja. Kemudian, kita akan mengatur ukuran bingkai OLE ke nilai yang dihitung tersebut. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada bingkai OLE di PowerPoint, kita juga akan menangkap gambar bagian yang diinginkan dari baris dan kolom dalam buku kerja dan menetapkannya sebagai gambar bingkai OLE.

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Atur ukuran tampilan saat file workbook digunakan sebagai objek OLE di PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Dapatkan lebar dan tinggi gambar OLE dalam poin.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Kita perlu menggunakan workbook yang telah dimodifikasi.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Tambahkan gambar OLE ke sumber daya presentasi.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Buat bingkai objek OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Skala Ukuran Rentang Sel**

Dalam pendekatan ini, kita akan mempelajari cara mem-skala tinggi baris yang berpartisipasi dan lebar kolom yang berpartisipasi agar cocok dengan ukuran bingkai OLE khusus.

Misalkan kita memiliki lembar Excel templat dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Dalam skenario ini, kita akan mengatur ukuran bingkai OLE dan mem-skala ukuran baris serta kolom yang berpartisipasi dalam area bingkai OLE. Kemudian, kita akan menyimpan buku kerja ke aliran (stream) untuk menerapkan perubahan dan mengonversinya menjadi array byte untuk menambahkannya ke bingkai OLE. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada bingkai OLE di PowerPoint, kita juga akan menangkap gambar bagian yang diinginkan dari baris dan kolom dalam buku kerja dan menetapkannya sebagai gambar bingkai OLE.

```py
# <param name="width">Lebar yang diharapkan dari rentang sel dalam poin.</param>
# <param name="height">Tinggi yang diharapkan dari rentang sel dalam poin.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Atur ukuran tampilan saat file workbook digunakan sebagai objek OLE di PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skala rentang sel agar cocok dengan ukuran bingkai.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Kita perlu menggunakan workbook yang telah dimodifikasi.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Tambahkan gambar OLE ke sumber daya presentasi.
            ole_image = presentation.images.add_image(image_stream)

            # Buat bingkai objek OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kesimpulan**

{{% alert color="primary" %}}

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pemilihan pendekatan yang tepat tergantung pada kebutuhan spesifik dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.

{{% /alert %}}