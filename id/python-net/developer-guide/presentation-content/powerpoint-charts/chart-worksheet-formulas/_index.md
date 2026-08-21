---
title: Menerapkan Rumus Lembar Kerja Grafik dalam Presentasi dengan Python
linktitle: Rumus Lembar Kerja
type: docs
weight: 70
url: /id/python-net/chart-worksheet-formulas/
keywords:
- spreadsheet grafik
- lembar kerja grafik
- rumus grafik
- rumus lembar kerja
- rumus spreadsheet
- buku kerja data grafik
- perhitungan rumus
- budaya yang diutamakan
- rumus spesifik budaya
- DBCS
- konstanta logika
- konstanta numerik
- konstanta string
- konstanta kesalahan
- operator aritmetika
- operator perbandingan
- gaya A1
- gaya R1C1
- fungsi pradefinisi
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Menerapkan rumus gaya Excel pada lembar kerja grafik Aspose.Slides untuk Python via .NET, menghitung ulang nilai, dan menggunakan hasilnya dalam grafik PowerPoint."
---
## **Gambaran Umum**

Grafik PowerPoint biasanya menyimpan data sumbernya dalam lembar kerja yang disisipkan. Dalam Aspose.Slides untuk Python via .NET, Anda dapat mengakses lembar kerja tersebut melalui buku kerja data grafik, menulis nilai masukan, menetapkan rumus ke sel, menghitung rumus yang didukung, dan menggunakan sel yang dihitung sebagai data grafik.

Artikel ini menjelaskan alur kerja rumus secara lengkap: membuat grafik, mengisi lembar kerjanya, menetapkan rumus gaya A1 atau R1C1, menghitung ulang rumus, membaca nilai yang dihitung, menghubungkan sel‑sel tersebut ke seri grafik, dan menyimpan presentasi. Artikel ini juga menjelaskan sintaks rumus yang didukung, subset fungsi bawaan, nilai cache, rumus yang tidak didukung, dan kesalahan khusus spreadsheet.

## **Lembar Kerja Grafik dan Rumus**

Lembar kerja grafik berisi kategori, nama seri, dan nilai yang digunakan oleh grafik. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data grafik:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui [chart data workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdataworkbook/). Gunakan properti [formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/formula/) untuk rumus gaya A1 dan properti [r1c1_formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) untuk rumus gaya R1C1. Setelah mengubah sel masukan atau rumus, panggil [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) untuk menghitung ulang rumus yang didukung dan memperbarui nilai sel yang bersangkutan.

Sel yang dihitung tetap mengekspos hasilnya melalui properti [value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/value/). Ini penting bila Anda perlu memeriksa hasil rumus dalam kode atau menggunakan sel sebagai titik data grafik.

## **Buat Grafik dan Hitung Rumus Lembar Kerja**

Contoh berikut mendemonstrasikan alur kerja ujung‑ke‑ujung. Ia membuat grafik kolom berkelompok, membersihkan data contoh, menulis nilai pendapatan dan pengeluaran kuartalan, menghitung laba dengan rumus, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai grafik, dan menyimpan presentasi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Poin data grafik mereferensikan `D2:D4`, sehingga grafik menggunakan nilai laba yang dihitung. Tidak ada panggilan penyegaran grafik terpisah dalam alur kerja ini: hitung ulang buku kerja terlebih dahulu, lalu gunakan atau simpan data grafik yang menunjuk ke sel yang dihitung.

## **Gunakan Rumus Gaya A1**

Notasi A1 mengidentifikasi kolom dengan huruf dan baris dengan angka. Tetapkan ekspresi gaya A1 melalui [IChartDataCell.formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Bentuk referensi A1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `A2` | `$A$2` | `A$2`, `$A2` |
| Baris | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Rentang | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Referensi relatif dapat berubah ketika rumus dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap tetap, sementara referensi campuran hanya mengunci baris atau kolom saja.

## **Gunakan Rumus Gaya R1C1**

Notasi R1C1 mengidentifikasi baik baris maupun kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Bentuk referensi R1C1 yang umum adalah:

| Referensi | Relatif | Absolut | Campuran |
|---|---|---|---|
| Sel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Baris | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Rentang | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Sebagai contoh, dalam sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Rumus**

Pengevaluasi rumus bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks dikelilingi tanda kutip ganda di dalam rumus. |
| Hasil kesalahan | `#DIV/0!`, `#N/A`, `#REF!` | Rumus yang valid dapat menghasilkan nilai kesalahan spreadsheet alih‑alih hasil normal. |

Contoh ini menggunakan beberapa tipe konstanta:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Salah
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Operator Aritmetika**

| Operator | Makna | Contoh |
|---|---|---|
| `+` | Penjumlahan atau plus unary | `2+3` |
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

## **Fungsi Pradefinisi yang Didukung**

Aspose.Slides menyertakan pengevaluasi rumus bawaan untuk lembar kerja grafik, tetapi bukan mesin perhitungan Excel lengkap. Set fungsi yang didokumentasikan terbatas pada fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel arbitrer dapat dihitung kembali oleh [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata‑rata aritmetika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan angka ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal menggunakan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antara tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu nilai teks di dalam teks lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan yang ditunjukkan dalam tabel signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sedangkan `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektor mereka. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh pengevaluasi rumus Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Hitung Rumus dengan Budaya yang Diutamakan**

Beberapa fungsi buku kerja grafik menafsirkan teks menurut aturan budaya tertentu. Ini terutama penting untuk fungsi yang ditujukan bagi bahasa yang menggunakan set karakter ganda (DBCS). Untuk menghitung rumus semacam itu dengan benar, buat [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/), atur [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/id/python-net/aspose.slides/spreadsheetoptions/) melalui [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/spreadsheet_options/), lalu muat presentasi.

Contoh berikut memilih budaya Jepang, membuka presentasi dengan opsi muat yang dikonfigurasi, dan memanggil [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) untuk setiap buku kerja grafik:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

Budaya yang diutamakan merupakan bagian dari konfigurasi pemuatan presentasi, jadi tentukan sebelum membuat instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Gunakan budaya yang diharapkan oleh rumus buku kerja; misalnya, gunakan `ja-JP` untuk rumus yang harus mengikuti aturan perhitungan DBCS Jepang.

## **Rekalkulasi dan Nilai Cache**

File spreadsheet biasanya menyimpan baik rumus maupun nilai terakhir yang dihitung. Aspose.Slides dapat membaca nilai cache dari [IChartDataCell.value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/value/) ketika presentasi dimuat dan data grafik yang bersangkutan belum diubah.

Setelah mengubah sel masukan atau rumus, jangan mengandalkan hasil cache lama. Panggil [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) sebelum membaca nilai yang dihitung atau menyimpan data grafik yang bergantung padanya.

Untuk rumus di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai rumus atau menentukan dependensinya. Jika buku kerja telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat dianggap dapat diandalkan. Dalam situasi tersebut, membaca nilai sel dengan data yang tidak didukung dapat memunculkan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jika grafik Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung rumus tersebut dengan mesin spreadsheet yang mendukungnya dan tulis kembali nilai yang dihasilkan ke buku kerja grafik. Jangan mengganti rumus yang tidak didukung dengan nilai yang ditebak.

## **Menangani Kesalahan Rumus**

Ada dua jenis masalah yang berbeda untuk dibedakan.

Sebuah rumus dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan adalah hasil sel dan dapat dikembalikan melalui `value`.

Sebuah rumus juga dapat gagal pada tingkat parsing, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian khusus spreadsheet untuk kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ketika rumus berasal dari templat atau masukan pengguna, tangani pengecualian ini di sekitar rekalkulasi dan akses nilai:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Batasan Praktis**

Dukungan rumus di lembar kerja grafik ditujukan untuk subset perhitungan spreadsheet yang terdefinisi, bukan untuk kompatibilitas Excel penuh. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang didokumentasikan saat Anda memerlukan Aspose.Slides untuk menghitung ulang rumus.
- Hitung ulang setelah mengubah sel yang memengaruhi hasil rumus.
- Anggap nilai cache dari presentasi yang dimuat sebagai snapshot, bukan sebagai pengganti rekalkulasi setelah penyuntingan.
- Uji rumus dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang didokumentasikan.
- Untuk rumus yang memerlukan mesin perhitungan spreadsheet lengkap, hitung secara eksternal lalu perbarui buku kerja grafik dengan nilai yang dihasilkan.

## **FAQ**

**Apa perbedaan antara `formula` dan `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/formula/) menyimpan ekspresi gaya A1 seperti `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling sesuai dengan cara Anda menghasilkan atau menyalin rumus.

**Apakah saya perlu membaca sel itu sendiri atau nilai sel setelah perhitungan?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) mengembalikan sebuah `IChartDataCell`. Untuk memperoleh hasil yang dihitung, baca properti [value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/value/) sel tersebut setelah rekalkulasi.

**Kapan saya harus memanggil `calculate_formulas`?**

Panggil [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) setelah mengubah nilai masukan atau rumus dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai rumus yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang didokumentasikan. Fungsi di luar subset tersebut tidak boleh diasumsikan dapat dihitung ulang dengan benar. Jika kompatibilitas rumus Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke buku kerja grafik.

**Apa yang terjadi jika presentasi yang dimuat berisi rumus yang tidak didukung?**

Jika data grafik belum diubah, buku kerja masih dapat berisi nilai cache yang telah dihitung sebelumnya. Setelah data terkait diubah, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang rumusnya tidak dapat ditangani dapat memunculkan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Apakah nilai kesalahan rumus sama dengan pengecualian Python?**

Tidak. Nilai seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) menunjukkan bahwa rumus tidak dapat diproses secara normal.

**Apakah grafik diperbarui secara otomatis ketika sel rumus berubah?**

Seri grafik dapat merujuk ke sel buku kerja. Hitung ulang buku kerja terlebih dahulu, lalu simpan atau render presentasi. Jika poin data grafik merujuk ke sel yang dihitung, grafik akan menggunakan nilai sel yang telah diperbarui; tidak diperlukan metode penyegaran grafik terpisah untuk alur kerja ini.

**Dapatkah grafik menggunakan buku kerja Excel eksternal?**

Ya, data grafik dapat dikonfigurasi untuk menggunakan buku kerja eksternal melalui API data grafik. Namun, alur kerja perhitungan rumus yang dibahas dalam artikel ini berhubungan dengan buku kerja data grafik dan subset rumus yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) menyediakan perhitungan penuh untuk rumus arbitrer dalam file XLSX eksternal.

**Bisakah saya menggunakan rumus yang merujuk ke lembar kerja atau buku kerja lain?**

Referensi gaya Excel mungkin ada dalam buku kerja grafik, tetapi evaluasi rumus dibatasi oleh parser dan set fungsi yang didukung. Jika referensi lintas lembar atau eksternal penting, pastikan rumus tersebut tepat dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel luas, hitung buku kerja secara eksternal dan tulis kembali nilai yang telah diselesaikan ke data grafik.

**Apakah string rumus harus diawali dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa awalan `=`. Menggunakan bentuk tersebut membuat rumus yang dihasilkan konsisten dengan contoh API yang didokumentasikan.