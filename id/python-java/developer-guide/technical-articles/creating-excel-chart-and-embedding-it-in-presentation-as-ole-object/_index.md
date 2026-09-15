---
title: Buat Bagan Excel dan Sematkan ke Presentasi sebagai Objek OLE
type: docs
weight: 30
url: /id/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Bagan Excel
- sematkan bagan
- objek OLE
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat bagan Excel dan sematkan sebagai objek OLE dalam presentasi PowerPoint dan OpenDocument menggunakan Python. Panduan langkah demi langkah dengan contoh kode."
---
## **Latar Belakang**

Di PowerPoint, menggunakan bagan yang dapat diedit untuk menampilkan data secara grafis adalah praktik umum. Aspose mendukung pembuatan bagan Excel dengan Aspose.Cells for Python via Java, dan bagan ini kemudian dapat disematkan sebagai objek OLE dalam slide PowerPoint melalui Aspose.Slides for Python via Java. Artikel ini membahas langkah‑langkah yang diperlukan dan menyediakan contoh kode Python untuk membuat bagan Excel dan menyematkannya sebagai objek OLE dalam presentasi PowerPoint menggunakan Aspose.Cells dan Aspose.Slides.

## **Langkah-Langkah yang Diperlukan**

Urutan langkah berikut diperlukan untuk membuat dan menyematkan bagan Excel sebagai objek OLE dalam slide PowerPoint:

1. Buat bagan Excel menggunakan Aspose.Cells.
1. Atur ukuran OLE bagan Excel menggunakan Aspose.Cells.
1. Dapatkan gambar bagan Excel dengan Aspose.Cells.
1. Sematkan bagan Excel sebagai objek OLE dalam presentasi PPTX menggunakan Aspose.Slides.
1. Ganti gambar "EMBEDDED OLE OBJECT" dengan gambar yang diperoleh pada langkah 3 untuk mengatasi [masalah pratinjau objek](/slides/id/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. Simpan presentasi ke disk dalam format PPTX.

## **Implementasi Langkah-Langkah yang Diperlukan**

Implementasi Python dari langkah‑langkah di atas adalah sebagai berikut:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Sebuah array nama sel.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Sebuah array data sel.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Tambahkan lembar kerja baru untuk mengisi sel dengan data.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Isi lembar data dengan data.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Tambahkan lembar bagan.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Tambahkan bagan ke lembar bagan dengan rangkaian data dari lembar data.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Atur lembar bagan sebagai lembar aktif.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Deskripsikan buku kerja sebagai data OLE yang disematkan.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Buat buku kerja.
workbook = Workbook()

# Tambahkan bagan Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Atur ukuran OLE bagan.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Dapatkan gambar bagan dan simpan ke aliran.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Simpan buku kerja ke aliran.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Buat presentasi.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan buku kerja ke slide.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Simpan presentasi ke disk.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Presentasi yang dibuat dengan metode di atas akan berisi bagan Excel sebagai objek OLE yang dapat diaktifkan dengan mengklik dua kali frame objek OLE.

## **Kesimpulan**

Dengan menggunakan Aspose.Cells for Python via Java bersama dengan Aspose.Slides for Python via Java, kita dapat membuat bagan Excel apa pun yang didukung oleh Aspose.Cells dan menyematkan bagan tersebut sebagai objek OLE dalam slide PowerPoint. Ukuran OLE bagan Excel juga dapat ditentukan. Pengguna akhir kemudian dapat mengedit bagan Excel seperti objek OLE lainnya.

## **Bagian Terkait**

- [Solusi yang Berhasil untuk Mengubah Ukuran Bagan di PPTX](/slides/id/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Perpustakaan mana yang digunakan untuk membuat dan menyematkan bagan Excel?**

Aspose.Cells for Python via Java membuat bagan Excel, dan Aspose.Slides for Python via Java menyematkannya sebagai objek OLE dalam slide PowerPoint.

**Bagaimana pengguna dapat mengedit bagan Excel yang disematkan?**

Pengguna dapat mengklik dua kali frame objek OLE untuk mengaktifkan bagan dan mengeditnya seperti objek OLE lainnya.

**Bagaimana pratinjau default objek OLE diganti?**

Contoh ini memperoleh gambar bagan Excel dengan Aspose.Cells dan menggunakannya untuk mengganti gambar "EMBEDDED OLE OBJECT".