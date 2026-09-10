---
title: Terapkan Rumus Lembar Kerja Diagram dalam Presentasi dengan Python via Java
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/python-java/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- rumus diagram
- rumus lembar kerja
- rumus spreadsheet
- buku kerja data diagram
- perhitungan rumus
- budaya yang dipilih
- rumus khusus budaya
- DBCS
- konstanta logika
- konstanta numerik
- konstanta string
- konstanta kesalahan
- operator aritmetika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi bawaan
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Terapkan rumus bergaya Excel dalam lembar kerja diagram Aspose.Slides untuk Python via Java, hitung ulang nilai, dan gunakan hasilnya dalam diagram PowerPoint."
---
## **Ikhtisar**

Diagram PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang disematkan. Pada Aspose.Slides untuk Python via Java, Anda dapat mengakses lembar kerja tersebut melalui workbook data diagram, menulis nilai masukan, menetapkan rumus ke sel, menghitung rumus yang didukung, dan menggunakan sel yang dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja rumus secara lengkap: membuat diagram, mengisi lembar kerja, menetapkan rumus gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel‑sel tersebut ke seri diagram, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks rumus yang didukung, subset fungsi bawaan, nilai yang di‑cache, rumus yang tidak didukung, serta kesalahan khusus spreadsheet.

## **Lembar Kerja Diagram dan Rumus**

Lembar kerja diagram berisi kategori, nama seri, dan nilai yang digunakan oleh diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data diagram:

![Diagram PowerPoint dengan lembar kerja yang disematkan terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja dijadikan tersedia melalui kelas [ChartDataWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/). Gunakan [ChartDataCell.setFormula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setFormula) untuk rumus gaya A1 dan [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setR1C1Formula) untuk rumus gaya R1C1. Setelah mengubah sel masukan atau rumus, panggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) untuk menghitung ulang rumus yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang telah dihitung tetap dapat mengakses hasilnya melalui [ChartDataCell.getValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#getValue). Ini penting ketika Anda perlu memeriksa hasil rumus dalam kode atau menggunakan sel sebagai titik data diagram.

## **Buat Diagram dan Hitung Rumus Lembar Kerja**

Contoh berikut mendemonstrasikan alur kerja ujung‑ke‑ujung. Ia membuat diagram kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan biaya kuartalan, menghitung laba dengan rumus, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poin data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai laba yang dihitung. Tidak ada pemanggilan penyegaran diagram terpisah dalam alur kerja ini: hitung ulang workbook terlebih dahulu, kemudian gunakan atau simpan data diagram yang menunjuk ke sel yang dihitung.

## **Gunakan Rumus Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [ChartDataCell.setFormula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Bentuk referensi A1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika rumus dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sementara referensi campuran hanya mengikat satu baris atau satu kolom.

## **Gunakan Rumus Gaya R1C1**

Notasi R1C1 mengidentifikasi baik baris maupun kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Bentuk referensi R1C1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Baris | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Rentang | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Sebagai contoh, pada sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta Rumus dan Operator**

Evaluator rumus bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmatika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks ditulis dalam tanda kutip ganda di dalam rumus. |
| Hasil kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Rumus yang valid dapat menghasilkan nilai kesalahan spreadsheet alih‑alih hasil normal. |

Contoh ini menggunakan beberapa tipe konstanta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # False
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Operator Aritmatika**

| Operator | Makna | Contoh |
|---|---|---|
| `+` | Penjumlahan atau tanda plus unary | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Pangkat | `2^3` |

Gunakan tanda kurung untuk membuat urutan evaluasi eksplisit, misalnya `(A2+B2)*C2`.

### **Operator Perbandingan**

Ekspresi perbandingan mengembalikan nilai logika.

| Operator | Makna | Contoh |
|---|---|---|
| `=` | Sama dengan | `A2=3` |
| `<>` | Tidak sama dengan | `A2<>3` |
| `>` | Lebih besar dari | `A2>3` |
| `>=` | Lebih besar atau sama dengan | `A2>=3` |
| `<` | Lebih kecil dari | `A2<3` |
| `<=` | Lebih kecil atau sama dengan | `A2<=3` |

## **Fungsi Bawaan yang Didukung**

Aspose.Slides menyertakan evaluator rumus bawaan untuk lembar kerja diagram, namun bukan mesin perhitungan Excel yang lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi-fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel apa pun dapat dihitung ulang oleh [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata‑rata aritmetika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal dengan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antara dua tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu teks di dalam teks lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Jumlah nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator rumus Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Hitung Rumus dengan Budaya yang Diutamakan**

Beberapa fungsi workbook diagram menafsirkan teks sesuai aturan budaya tertentu. Hal ini terutama penting untuk fungsi yang ditujukan bagi bahasa yang menggunakan set karakter ganda (DBCS). Untuk menghitung rumus tersebut dengan benar, buat [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/), tetapkan budaya yang diutamakan dengan [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/id/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), berikan opsi spreadsheet melalui [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), lalu muat presentasi.

Contoh berikut memilih budaya Jepang, membuka presentasi dengan opsi muat yang dikonfigurasi, dan memanggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) untuk setiap workbook diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Budaya yang diutamakan merupakan bagian dari konfigurasi pemuatan presentasi, sehingga harus ditentukan sebelum membuat instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Gunakan budaya yang diharapkan oleh rumus workbook; misalnya, gunakan `ja-JP` untuk rumus yang harus mengikuti aturan perhitungan DBCS Jepang.

## **Perhitungan Ulang dan Nilai yang Di‑cache**

File spreadsheet biasanya menyimpan baik rumus maupun nilai terhitung terakhirnya. Aspose.Slides dapat membaca nilai yang di‑cache dari [ChartDataCell.getValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#getValue) ketika presentasi dimuat dan data diagram yang bersangkutan belum diubah.

Setelah mengubah sel masukan atau rumus, jangan mengandalkan hasil cache lama. Panggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung padanya.

Untuk rumus di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai rumus atau menelusuri dependensinya. Jika workbook telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi itu, membaca nilai sel dengan data yang tidak didukung dapat memunculkan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung rumus tersebut dengan mesin spreadsheet yang mendukungnya dan tulis kembali nilai yang dihasilkan ke workbook diagram. Jangan mengganti rumus yang tidak didukung dengan nilai tebakan.

## **Tangani Kesalahan Rumus**

Ada dua jenis masalah yang berbeda untuk dibedakan.

Sebuah rumus dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Pada kasus ini, token kesalahan merupakan hasil sel dan dapat dikembalikan melalui [ChartDataCell.getValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#getValue).

Sebuah rumus juga dapat gagal pada tingkat penguraian, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus‑kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellunsupporteddataexception/).

Ketika rumus berasal dari templat atau masukan pengguna, tangani pengecualian‑pengecualian ini di sekitar perhitungan ulang dan akses nilai:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Batasan Praktis**

Dukungan rumus dalam lembar kerja diagram ditujukan untuk subset kalkulasi spreadsheet yang terdefinisi, bukan untuk kompatibilitas penuh dengan Excel. Ingatlah batasan‑batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan ketika Anda memerlukan Aspose.Slides untuk menghitung ulang rumus.
- Hitung ulang setelah mengubah sel‑sel yang menjadi dependensi hasil rumus.
- Anggap nilai yang di‑cache dari presentasi yang dimuat sebagai snapshot, bukan pengganti perhitungan ulang setelah penyuntingan.
- Uji rumus dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka memakai fungsi di luar daftar yang didokumentasikan.
- Untuk rumus yang memerlukan mesin kalkulasi spreadsheet penuh, hitung secara eksternal lalu perbarui workbook diagram dengan nilai yang dihasilkan.

## **FAQ**

**Apa perbedaan antara [ChartDataCell.setFormula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setFormula) dan [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setFormula) menyimpan ekspresi gaya A1 seperti `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setR1C1Formula) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling sesuai dengan cara Anda menghasilkan atau menyalin rumus.

**Apakah saya harus membaca sel itu sendiri atau nilainya setelah perhitungan?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#getCell) mengembalikan sebuah [ChartDataCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/). Untuk memperoleh hasil yang dihitung, panggil metode [ChartDataCell.getValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#getValue) pada sel tersebut setelah perhitungan ulang.

**Kapan saya harus memanggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Panggil [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) setelah mengubah nilai masukan atau rumus dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai rumus yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang terdokumentasi. Fungsi di luar subset tersebut tidak boleh dianggap dapat dihitung ulang dengan benar. Jika kompatibilitas rumus Excel lengkap diperlukan, lakukan perhitungan dengan mesin spreadsheet yang tepat dan tulis nilai akhir ke workbook diagram.

**Apa yang terjadi jika presentasi yang dimuat berisi rumus yang tidak didukung?**

Jika data diagram tidak berubah, workbook mungkin masih menyimpan nilai cache yang pernah dihitung sebelumnya. Setelah data terkait dimodifikasi, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang rumusnya tidak dapat ditangani dapat memunculkan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellunsupporteddataexception/).

**Apakah nilai kesalahan rumus sama dengan pengecualian?**

Tidak. Hasil seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellcircularreferenceexception/) menunjukkan bahwa rumus tidak dapat diproses secara normal.

**Apakah diagram memperbarui secara otomatis ketika sel rumus berubah?**

Seri diagram dapat merujuk ke sel workbook. Hitung ulang workbook terlebih dahulu, kemudian simpan atau render presentasi. Jika poin data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang diperbarui; tidak diperlukan metode penyegaran diagram terpisah untuk alur kerja ini.

**Dapatkah diagram menggunakan workbook Excel eksternal?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan workbook eksternal melalui API data diagram. Namun, alur kerja perhitungan rumus yang dibahas dalam artikel ini berkaitan dengan workbook data diagram dan subset rumus yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) memberikan perhitungan penuh untuk rumus apa pun dalam file XLSX eksternal.

**Dapatkah saya menggunakan rumus yang merujuk ke lembar kerja atau workbook lain?**

Referensi gaya Excel mungkin ada dalam workbook diagram, tetapi evaluasi rumus dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas lembar atau eksternal penting, verifikasi rumus tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel yang luas, hitung workbook secara eksternal dan tulis kembali nilai yang sudah diselesaikan ke data diagram.

**Apakah string rumus harus diawali dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depan. Menggunakan bentuk ini menjaga konsistensi rumus yang dihasilkan dengan contoh API yang terdokumentasi.