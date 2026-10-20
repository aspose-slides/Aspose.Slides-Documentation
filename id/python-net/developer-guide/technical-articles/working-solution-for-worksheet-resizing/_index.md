---
title: Solusi Praktis untuk Mengubah Ukuran Lembar Kerja
type: docs
weight: 40
url: /id/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- ubah ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—skala bingkai atau lembar kerja—pada format PPT dan PPTX."
---
{{% alert color="info" title="Note" %}}
Lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat mengubah ukuran secara tak terduga setelah aktivasi pertama. Perilaku ini menghasilkan perbedaan visual yang jelas antara objek OLE sebelum dan setelah aktivasi. Artikel ini menjelaskan masalah tersebut dan menggambarkan dua cara untuk mengatasinya.
{{% /alert %}} 

## **Latar Belakang**

Dalam artikel [Kelola OLE](/slides/id/python-net/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk Python via .NET. Untuk mengatasi [masalah pratinjau objek](/slides/id/python-net/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Dalam presentasi keluaran, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar lembar kerja, buku kerja Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun pada buku kerja Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar buku kerja Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela sendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran tersendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran untuk memastikan proporsi yang benar dipertahankan sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skalakan bingkai OLE dalam presentasi PowerPoint agar cocok dengan total tinggi dan lebar baris serta kolom yang dipilih.
- Pertahankan ukuran bingkai OLE konstan dan skalakan baris serta kolom yang dipilih agar sesuai di dalamnya.

### **Skala Ukuran Bingkai OLE**

Pendekatan ini mengatur ukuran bingkai OLE agar cocok dengan total tinggi dan lebar baris serta kolom yang dipilih dalam lembar kerja Excel yang disematkan.

Contoh ini memuat buku kerja Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertama menggunakan indeks berbasis nol. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) menetapkan rentang yang ditampilkan. Pratinjau dihasilkan pada 96 DPI, dan dimensi pikselnya dikonversi ke poin menggunakan 72 poin per inci. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) menyematkan buku kerja yang dimodifikasi ke dalam bingkai dengan dimensi tersebut. Pratinjau ditetapkan melalui [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) untuk menggantikan placeholder "EMBEDDED OLE OBJECT" dalam presentasi yang disimpan.

Pembantu pratinjau mengatur [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) ke rentang yang dipilih dan menghapus margin, header, serta footer. Dengan [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) diaktifkan, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) merender rentang sebagai gambar PNG. Pembantu tersebut mengatur ulang aliran gambar sebelum mengembalikannya untuk digunakan dalam presentasi.

```py
import io
import aspose.cells as cells

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

Contoh lengkap di bawah ini menggabungkan pembantu dengan penyematan buku kerja dan menyimpan presentasi sebagai `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

Pendekatan ini menskalakan tinggi baris yang dipilih dan lebar kolom yang dipilih agar cocok dengan ukuran bingkai OLE khusus.

Contoh ini memuat buku kerja Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertama menggunakan indeks berbasis nol. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) menetapkan rentang yang ditampilkan, dan pembantu di bawah ini menskalakan rentang tersebut agar cocok dengan bingkai berlebar 400 poin dan tinggi 100 poin. Setelah menyimpan buku kerja yang dimodifikasi ke aliran, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) menyematkannya dengan ukuran yang ditentukan. Pratinjau yang dihasilkan pada 96 DPI ditetapkan melalui [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), sehingga presentasi yang disimpan menampilkan sel yang dipilih alih-alih placeholder default.

Pembantu skala menghitung rasio lebar dan tinggi terpisah untuk rentang yang dipilih, menjaga lebar relatif kolomnya dan tinggi relatif barisnya. Ia mengonversi dimensi yang dihitung dari poin ke inci sebelum menerapkannya dengan [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) dan [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Rentang yang dipilih harus memiliki lebar dan tinggi yang tidak nol.

```py
import aspose.cells as cells

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

Pembantu pratinjau ini merender rentang yang diubah ukuran menggunakan [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Ia membatasi [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) pada rentang tersebut, menghapus margin, header, dan footer, serta mengembalikan aliran PNG yang diposisikan di awalnya.

```py
import io
import aspose.cells as cells

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

Contoh lengkap di bawah ini menggabungkan pembantu dengan penyematan buku kerja dan menyimpan presentasi sebagai `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Atur ukuran tampilan saat file buku kerja digunakan sebagai objek OLE di PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skalakan rentang sel agar sesuai dengan ukuran bingkai.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Kita perlu menggunakan buku kerja yang telah dimodifikasi.
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

{{% alert color="info" title="Note" %}}
Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pilih pendekatan yang paling sesuai dengan kebutuhan dan kasus penggunaan Anda. Kedua pendekatan bekerja dengan cara yang sama, baik presentasi dibuat dari template maupun dari awal. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.
{{% /alert %}}

## **Tanya Jawab**

**Mengapa lembar kerja Excel yang disematkan mengubah ukuran saat pertama kali diaktifkan di PowerPoint?**  
Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensinya sendiri. PowerPoint dan Excel menegosiasikan ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**  
Ya. Dengan menskalakan bingkai OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran bingkai OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala bingkai OLE atau skala rentang sel?**  
Pilih **OLE frame scaling** jika Anda ingin mempertahankan ukuran baris dan kolom Excel yang asli. Pilih **cell range scaling** jika Anda menginginkan ukuran tetap untuk bingkai OLE dalam presentasi Anda.

**Apakah solusi ini akan berfungsi jika presentasi saya berbasis template?**  
Ya. Kedua solusi bekerja untuk presentasi yang dibuat dari template maupun dari awal.

**Apakah ada batasan ukuran bingkai OLE ketika menggunakan metode ini?**  
Tidak. Anda dapat membuat bingkai objek OLE dalam ukuran berapa pun asalkan Anda mengatur skala dengan tepat.

**Apakah ada cara untuk menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**  
Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder bingkai OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.