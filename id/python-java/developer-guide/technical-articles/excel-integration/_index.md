---
title: Integrasikan Data Excel ke dalam Presentasi PowerPoint
linktitle: Integrasi Excel
type: docs
weight: 330
url: /id/python-java/excel-integration/
keywords:
- Excel
- buku kerja
- baca Excel
- integrasikan Excel
- sumber data
- gabungan surat
- impor tabel
- Excel ke PowerPoint
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Baca data dari buku kerja Excel dalam Aspose.Slides untuk Python melalui Java menggunakan API ExcelDataWorkbook. Muat lembar kerja dan sel, lalu gunakan nilainya untuk menghasilkan presentasi PowerPoint yang didorong oleh data."
---
## **Pendahuluan**

Presentasi PowerPoint adalah cara yang kuat untuk menampilkan dan menyampaikan informasi. Mereka sering digunakan bersama dengan buku kerja Excel, di mana Excel berfungsi sebagai sumber data terstruktur yang sangat baik dan PowerPoint unggul dalam memvisualisasikan data tersebut bagi audiens.

Ada banyak skenario praktis di mana menggabungkan Excel dan PowerPoint sangat penting: mail merge, mengisi tabel data, menghasilkan satu slide per catatan data (pembuatan slide batch), membuat materi pelatihan, dan mengkonsolidasikan beberapa laporan Excel menjadi satu presentasi, antara lain.

Sampai saat ini, mengimplementasikan fitur semacam itu dengan API Aspose.Slides memerlukan ketergantungan pada solusi pihak ketiga seperti Aspose.Cells. Meskipun alat-alat ini kuat, mereka dapat menjadi terlalu kompleks dan mahal bagi pengguna yang hanya membutuhkan fungsionalitas integrasi data dasar.

## **Cara Kerja**

Untuk mempermudah dan menyederhanakan kerja dengan data Excel, Aspose.Slides telah memperkenalkan kelas baru untuk membaca data dari buku kerja Excel dan mengimpor konten ke dalam presentasi. Fitur ini membuka kemungkinan baru yang kuat bagi pengguna API yang ingin memanfaatkan Excel sebagai sumber data dalam alur kerja presentasi mereka.

Fungsionalitas baru ini dirancang untuk akses data tujuan umum dan tidak terintegrasi ke dalam Presentation Document Object Model (DOM). Artinya *tidak memungkinkan pengeditan atau penyimpanan file Excel* — tujuan tunggalnya adalah membuka buku kerja dan menavigasi kontennya untuk mengambil data sel.

Inti dari fitur ini adalah kelas baru [ExcelDataWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/exceldataworkbook/). Kelas ini memungkinkan Anda memuat buku kerja Excel dari file lokal atau aliran data. Setelah dimuat, ia menyediakan beberapa overload dari metode [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/exceldataworkbook/#getCell), yang dapat Anda gunakan untuk mengambil sel tertentu berdasarkan posisinya (misalnya indeks baris dan kolom atau rentang bernama).

Setiap pemanggilan [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/exceldataworkbook/#getCell) mengembalikan objek [ExcelDataCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/exceldatacell/). Objek ini mewakili satu sel dalam buku kerja Excel dan memberi Anda akses ke nilainya dengan cara yang sederhana dan intuitif.

#### **Impor Diagram Excel**

Langkah berikutnya untuk memperluas fungsionalitas adalah kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/python-java/aspose.slides/excelworkbookimporter/). Kelas utilitas ini menyediakan fungsi untuk mengimpor konten dari buku kerja Excel ke dalam presentasi. Ia berisi beberapa overload dari metode [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), yang membantu Anda mengambil diagram yang dipilih dari buku kerja Excel yang ditentukan dan menambahkannya ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

#### **Impor Tabel Excel**

Kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/python-java/aspose.slides/excelworkbookimporter/) juga berisi beberapa overload dari metode [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Metode-metode ini memungkinkan Anda mengimpor rentang sel tertentu dari lembar kerja yang ditentukan dan menambahkannya sebagai tabel ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

Singkatnya, ini adalah API yang ringan dan sederhana untuk membaca data Excel — tepat apa yang dibutuhkan banyak pengembang tanpa beban tambahan dari perpustakaan pemrosesan spreadsheet lengkap.

## **Mari Kita Kode**

### **Contoh Skenario Mail Merge**

Pada contoh berikut, kami akan mengimplementasikan skenario mail merge sederhana dengan menghasilkan beberapa presentasi berdasarkan data yang disimpan dalam buku kerja Excel.

Untuk memulai, kita membutuhkan dua hal:

1. Buku kerja Excel yang berisi data
![Contoh data Excel](example1_image0.png)

2. Template presentasi PowerPoint
![Contoh template PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Muat buku kerja Excel dengan data karyawan.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Muat templat presentasi.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Loop melalui baris Excel (kecuali header pada baris 0).
    for row_index in range(1, 5):

        # Buat presentasi untuk setiap catatan karyawan.
        employee_presentation = Presentation()

        try:
            # Hapus slide kosong default.
            employee_presentation.getSlides().removeAt(0)

            # Kloning slide templat ke dalam presentasi.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Dapatkan paragraf dari shape target (mengasumsikan indeks shape 1 digunakan).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Ganti placeholder dengan data dari Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Simpan presentasi yang dipersonalisasi ke file terpisah.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Hasil](example1_image2.png)

### **Contoh Tabel Excel**

Pada contoh kedua, kami cukup menyalin data dari tabel Excel dan menampilkannya pada slide PowerPoint dalam format yang lebih menarik secara visual.

Pada contoh ini, kami menggunakan kembali buku kerja Excel yang sama dari contoh pertama, yang berisi tabel karyawan sederhana.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Muat buku kerja Excel yang berisi data karyawan.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Buat presentasi PowerPoint.
presentation = Presentation()

try:
    # Tambahkan shape tabel ke slide pertama.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Isi tabel PowerPoint dengan data dari buku kerja Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Simpan presentasi hasil ke file.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hasil](example2_image0.png)

### **Contoh Impor Diagram Excel**

Pada contoh ini, kami mengimpor diagram dari lembar kerja pertama buku kerja Excel yang digunakan pada contoh sebelumnya. Diagram tersebut akan terhubung ke buku kerja eksternal dalam presentasi yang dihasilkan.

Pertama, kami menambahkan diagram pai ke buku kerja Excel berdasarkan tabel karyawan.

![Contoh Diagram Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Buat presentasi PowerPoint.
presentation = Presentation()
try:
    # Dapatkan koleksi shape dari slide pertama.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Impor diagram bernama "Chart 1" dari lembar pertama buku kerja dan tambahkan ke koleksi shape.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Simpan presentasi hasil ke file.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hasil](example3_image1.png)

### **Contoh Impor Semua Diagram Excel**

Bayangkan Anda memiliki buku kerja Excel yang penuh dengan diagram dan Anda perlu mengimpor semuanya ke dalam sebuah presentasi. Setiap diagram harus ditempatkan pada slide baru.

Kode berikut mengulangi semua lembar kerja dalam file Excel sumber, mengekstrak diagram dari setiap lembar kerja, dan menambahkan setiap diagram ke slide terpisah menggunakan tata letak slide kosong. Pada presentasi yang dihasilkan, hanya data diagram yang akan disematkan, bukan seluruh buku kerja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Muat buku kerja Excel yang berisi data karyawan.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Buat presentasi PowerPoint.
presentation = Presentation()
try:
    # Ambil tata letak slide kosong.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Hapus slide default sehingga hasil berisi satu slide per diagram.
    presentation.getSlides().removeAt(0)

    # Dapatkan nama semua lembar kerja yang terdapat dalam buku kerja Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Ambil peta yang memetakan indeks diagram ke nama diagram untuk lembar kerja.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Tambahkan slide menggunakan tata letak kosong.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Impor diagram yang ditentukan dari buku kerja Excel ke dalam koleksi shape slide.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Simpan presentasi hasil ke file.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Contoh Impor Tabel Excel**

Pada contoh ini, kami mengimpor tabel yang diformat dari lembar kerja Excel langsung ke dalam presentasi PowerPoint.

Lembar kerja Excel sumber berisi tabel yang diformat dengan data karyawan:

![Contoh Tabel Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Buat presentasi PowerPoint.
presentation = Presentation()
try:
    # Dapatkan slide pertama dan koleksi shape-nya.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Impor tabel dari lembar pertama buku kerja dan tambahkan ke koleksi shape.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Simpan presentasi hasil ke file.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hasil](example4_image1.png)

## **Ringkasan**

Mekanisme ini, yang tersedia langsung di Aspose.Slides, menggabungkan pekerjaan dengan data Excel dan presentasi dalam satu tempat. Ini memungkinkan Anda membuat slide dengan diagram visual dan data yang disajikan sebagai tabel Excel—tanpa perpustakaan tambahan atau integrasi yang kompleks.