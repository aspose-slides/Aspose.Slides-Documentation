---
title: Integrasi Data Excel ke dalam Presentasi PowerPoint
linktitle: Integrasi Excel
type: docs
weight: 330
url: /id/python-net/excel-integration/
keywords:
- Excel
- buku kerja
- baca Excel
- integrasikan Excel
- sumber data
- mail merge
- impor tabel
- Excel ke PowerPoint
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Baca data dari workbook Excel di Aspose.Slides menggunakan API ExcelDataWorkbook. Muat sheet dan sel serta gunakan nilai-nilai untuk menghasilkan presentasi PowerPoint berbasis data."
---
## **Pendahuluan**

Presentasi PowerPoint adalah cara yang kuat untuk menampilkan dan menyampaikan informasi. Mereka sering digunakan bersama dengan workbook Excel, di mana Excel berfungsi sebagai sumber data terstruktur yang sangat baik dan PowerPoint unggul dalam memvisualisasikan data tersebut untuk audiens.

Ada banyak skenario praktis di mana menggabungkan Excel dan PowerPoint menjadi penting: mail merge, mengisi tabel data, menghasilkan satu slide per catatan data (generasi slide batch), membuat materi pelatihan, dan mengkonsolidasikan beberapa laporan Excel menjadi satu presentasi, antara lain.

Sebelumnya, mengimplementasikan fitur semacam ini dengan API Aspose.Slides memerlukan ketergantungan pada solusi pihak ketiga seperti Aspose.Cells. Meskipun alat-alat tersebut kuat, mereka dapat menjadi terlalu kompleks dan mahal bagi pengguna yang hanya membutuhkan fungsionalitas integrasi data dasar.

## **Cara Kerjanya**

Untuk mempermudah dan memperlancar kerja dengan data Excel, Aspose.Slides telah memperkenalkan kelas baru untuk membaca data dari workbook Excel dan mengimpor konten ke dalam presentasi. Fitur ini membuka peluang baru yang kuat bagi pengguna API yang ingin memanfaatkan Excel sebagai sumber data dalam alur kerja presentasi mereka.

Fungsionalitas baru ini dirancang untuk akses data umum dan tidak terintegrasi ke dalam Presentation Document Object Model (DOM). Itu berarti *tidak memungkinkan pengeditan atau penyimpanan file Excel* — tujuan utamanya hanya membuka workbook dan menavigasi isinya untuk mengambil data sel.

Inti dari fitur ini adalah kelas baru [ExcelDataWorkbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.excel/exceldataworkbook/). Kelas ini memungkinkan Anda memuat workbook Excel dari file lokal atau aliran. Setelah dimuat, ia menyediakan beberapa overload dari metode [get_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides.excel/exceldataworkbook/get_cell/), yang dapat Anda gunakan untuk mengambil sel tertentu berdasarkan posisinya (misalnya indeks baris dan kolom atau rentang bernama).

Setiap panggilan ke [get_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) mengembalikan instance dari kelas [ExcelDataCell](https://reference.aspose.com/slides/id/python-net/aspose.slides.excel/exceldatacell/). Objek ini mewakili satu sel dalam workbook Excel dan memberi Anda akses ke nilainya dengan cara yang sederhana dan intuitif.

#### **Impor Diagram Excel**

Langkah selanjutnya untuk memperluas fungsionalitas adalah kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/python-net/aspose.slides.importing/excelworkbookimporter/). Kelas utilitas ini menyediakan fungsionalitas untuk mengimpor konten dari workbook Excel ke dalam presentasi. Ia berisi beberapa overload dari metode [add_chart_from_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/), yang membantu Anda mengambil diagram yang dipilih dari workbook Excel yang ditentukan dan menambahkannya ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

Singkatnya, ini adalah API yang ringan dan langsung untuk membaca data Excel — tepat apa yang dibutuhkan banyak pengembang tanpa beban library pemrosesan spreadsheet penuh.

## **Mari Kita Kode**

### **Contoh Skenario Mail Merge**

Dalam contoh berikut, kami akan mengimplementasikan skenario Mail Merge sederhana dengan menghasilkan beberapa presentasi berdasarkan data yang disimpan dalam workbook Excel.

Untuk memulai, kami membutuhkan dua hal:
1. Workbook Excel yang berisi data

![Contoh data Excel](example1_image0.png)

2.  Templat presentasi PowerPoint

![Contoh templat PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# Muat workbook Excel dengan data karyawan.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Muat templat presentasi.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Loop melalui baris Excel (mengecualikan header pada baris 0).
    for row_index in range(1, 5):

        # Buat presentasi baru untuk setiap catatan karyawan.
        with slides.Presentation() as employee_presentation:

            # Hapus slide kosong default.
            employee_presentation.slides.remove_at(0)

            # Gandakan slide templat ke dalam presentasi baru.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Dapatkan paragraf dari shape target (asumsikan indeks shape 1 yang digunakan).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Ganti placeholder dengan data dari Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Simpan presentasi yang dipersonalisasi ke file terpisah.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Hasil](example1_image2.png)

### **Contoh Tabel Excel**

Pada contoh kedua, kami cukup menyalin data dari tabel Excel dan menampilkannya pada slide PowerPoint dalam format yang lebih menarik secara visual.

Dalam contoh ini, kami menggunakan kembali workbook Excel yang sama dari contoh pertama, yang berisi tabel karyawan sederhana.

```py
# Muat workbook Excel yang berisi data karyawan.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Buat presentasi PowerPoint baru.
with slides.Presentation() as presentation:

    # Tambahkan bentuk tabel ke slide pertama.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Isi tabel PowerPoint dengan data dari workbook Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Simpan presentasi yang dihasilkan ke file.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Hasil](example2_image0.png)

### **Contoh Impor Diagram Excel**

Pada contoh ini, kami mengimpor diagram dari lembar kerja pertama workbook Excel yang digunakan pada contoh sebelumnya. Diagram tersebut akan terhubung ke workbook eksternal dalam presentasi yang dihasilkan.

Pertama, kami menambahkan diagram Pie ke workbook Excel berdasarkan tabel karyawan.

![Contoh Diagram Excel](example3_image0.png)

```py
# Buat presentasi PowerPoint baru.
with slides.Presentation() as presentation:
    # Dapatkan koleksi shape dari slide pertama.
    shapes = presentation.slides[0].shapes

    # Impor diagram bernama "Chart 1" dari lembar pertama workbook dan tambahkan ke koleksi shape.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Simpan presentasi hasil ke file.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Hasil](example3_image1.png)

### **Contoh Impor Semua Diagram Excel**

Bayangkan Anda memiliki workbook Excel yang penuh dengan diagram dan Anda perlu mengimpor semuanya ke dalam satu presentasi. Setiap diagram harus ditempatkan pada slide baru.

Kode berikut mengiterasi semua lembar kerja dalam file Excel sumber, mengekstrak diagram dari setiap lembar kerja, dan menambahkan masing‑masing diagram ke slide terpisah menggunakan tata letak slide kosong. Dalam presentasi yang dihasilkan, hanya data diagram yang akan disematkan, bukan seluruh workbook.

```py
# Muat workbook Excel yang berisi data karyawan.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Buat presentasi PowerPoint baru.
with slides.Presentation() as presentation:
    # Ambil tata letak slide kosong.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Dapatkan nama semua lembar kerja yang terdapat dalam workbook Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Ambil kamus yang memetakan indeks diagram ke nama diagram untuk lembar kerja tersebut.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Tambahkan slide baru menggunakan tata letak kosong.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Impor diagram yang ditentukan dari workbook Excel ke dalam koleksi shape slide.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Simpan presentasi yang dihasilkan ke file.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Ringkasan**

Mekanisme ini, tersedia langsung di Aspose.Slides, menggabungkan kerja dengan data Excel dan presentasi dalam satu tempat. Ini memungkinkan Anda membuat slide dengan diagram visual dan data yang disajikan sebagai tabel Excel — tanpa library tambahan atau integrasi yang rumit.