---
title: Solusi Praktis untuk Mengubah Ukuran Lembar Kerja
type: docs
weight: 20
url: /id/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- pengubahan ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—skala bingkai atau lembar kerja—di semua format PPT dan PPTX."
---
{{% alert color="info" title="Note" %}}

Worksheet Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran secara tak terduga setelah aktivasi pertama. Perilaku ini menciptakan perbedaan visual yang terlihat antara objek OLE sebelum dan sesudah aktivasi. Artikel ini menjelaskan masalah tersebut dan menggambarkan dua cara untuk mengatasinya.

{{% /alert %}}

## **Latar Belakang**

Dalam artikel [Kelola OLE](/slides/id/python-java/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/python-java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Pada presentasi output, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar lembar kerja, buku kerja Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun pada buku kerja Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar buku kerja Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran aslinya saat aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran sendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala bingkai OLE dalam presentasi PowerPoint agar sesuai dengan total tinggi dan lebar baris serta kolom yang dipilih.
- Pertahankan ukuran bingkai OLE tetap konstan dan skala baris serta kolom yang dipilih agar pas di dalamnya.

### **Skala Ukuran Bingkai OLE**

Pendekatan ini menetapkan ukuran bingkai OLE agar sesuai dengan total tinggi dan lebar baris serta kolom yang dipilih dalam lembar kerja Excel yang disematkan.

Contoh memuat buku kerja Excel yang sudah ada dan memilih 10 baris pertama serta 13 kolom pertama pada lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) menentukan rentang yang ditampilkan. Pratinjau dirender pada 96 DPI, dan dimensi pikselnya dikonversi ke poin menggunakan 72 poin per inci. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) menanamkan buku kerja yang telah dimodifikasi ke dalam bingkai dengan dimensi tersebut. Pratinjau ditetapkan melalui [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) untuk menggantikan placeholder "EMBEDDED OLE OBJECT" dalam presentasi yang disimpan.

Pembantu pratinjau menetapkan [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) ke rentang yang dipilih dan menghapus margin, header, serta footer. Dengan [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) diaktifkan, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) merender rentang sebagai gambar PNG. Pembantu mengembalikan aliran masuk baru yang berisi gambar PNG, diposisikan pada awalnya untuk penggunaan dalam presentasi.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Atur ukuran tampilan ketika buku kerja digunakan sebagai objek OLE di PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Dapatkan lebar dan tinggi gambar OLE dalam satuan poin.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Gunakan buku kerja yang telah dimodifikasi.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Tambahkan gambar OLE ke sumber daya presentasi.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Buat bingkai objek OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Skala Ukuran Rentang Sel**

Pendekatan ini menskalakan tinggi baris yang dipilih dan lebar kolom yang dipilih agar sesuai dengan ukuran bingkai OLE khusus.

Contoh memuat buku kerja Excel yang sudah ada dan memilih 10 baris pertama serta 13 kolom pertama pada lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) menentukan rentang yang ditampilkan, dan pembantu scale_cell_range menskalakan rentang tersebut agar cocok dengan bingkai seluas 400 poin lebar dan 100 poin tinggi. Setelah menyimpan buku kerja yang dimodifikasi ke aliran, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) menanamkannya pada ukuran yang ditentukan. Pratinjau yang dirender pada 96 DPI ditetapkan melalui [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), sehingga presentasi yang disimpan menampilkan sel yang dipilih alih-alih placeholder default.

Pembantu skala menghitung rasio lebar dan tinggi terpisah untuk rentang yang dipilih, mempertahankan lebar relatif kolomnya dan tinggi relatif barisnya. Ia mengonversi dimensi yang dihitung dari poin ke inci sebelum menerapkannya dengan [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) dan [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Rentang yang dipilih harus memiliki lebar dan tinggi yang tidak nol.

Pembantu pratinjau ini merender rentang yang diubah ukurannya menggunakan [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Ia membatasi [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) pada rentang tersebut, menghapus margin, header, dan footer, serta mengembalikan aliran PNG yang diposisikan pada awalnya.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpage.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # Lebar dan tinggi yang diharapkan dari rentang sel dalam poin.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Atur ukuran tampilan ketika buku kerja digunakan sebagai objek OLE di PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skala rentang sel agar sesuai dengan ukuran bingkai.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Gunakan buku kerja yang telah dimodifikasi.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Tambahkan gambar OLE ke sumber daya presentasi.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Buat bingkai objek OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Kesimpulan**

{{% alert color="info" title="Note" %}} 

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pilih pendekatan yang paling sesuai dengan kebutuhan dan kasus penggunaan Anda. Kedua pendekatan bekerja dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan pada ukuran bingkai objek OLE dalam solusi ini.

{{% /alert %}}

## **FAQ**

**Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela aslinya saat diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk menjaga rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan menskalakan bingkai OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran bingkai OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang sebaiknya saya gunakan, skala bingkai OLE atau skala rentang sel?**

Pilih **skala bingkai OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk bingkai OLE dalam presentasi Anda.

**Apakah solusi ini akan berfungsi jika presentasi saya berbasis templat?**

Ya. Kedua solusi berfungsi untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai OLE saat menggunakan metode ini?**

Tidak. Anda dapat membuat bingkai objek OLE dengan ukuran berapa pun selama Anda menetapkan skala dengan tepat.

**Apakah ada cara untuk menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**

Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder bingkai OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.

## **Artikel Terkait**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/id/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)