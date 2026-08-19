---
title: "Terapkan Rumus Lembar Kerja Diagram dalam Presentasi dengan Python"
linktitle: "Rumus Lembar Kerja"
type: docs
weight: 70
url: /id/python-net/chart-worksheet-formulas/
keywords:
- spreadsheet diagram
- lembar kerja diagram
- rumus diagram
- rumus lembar kerja
- rumus spreadsheet
- buku kerja data diagram
- perhitungan rumus
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
- Aspose.Slides
description: "Terapkan rumus bergaya Excel di lembar kerja diagram Aspose.Slides untuk Python via .NET, hitung ulang nilai, dan gunakan hasilnya dalam diagram PowerPoint."
---
## **Gambaran Umum**

Diagram PowerPoint biasanya menyimpan data sumbernya di lembar kerja yang tersemat. Dalam Aspose.Slides untuk Python via .NET, Anda dapat mengakses lembar kerja tersebut melalui **buku kerja data diagram**, menulis nilai masukan, menetapkan rumus ke sel, menghitung rumus yang didukung, dan menggunakan sel yang telah dihitung sebagai data diagram.

Artikel ini menjelaskan alur kerja rumus secara lengkap: membuat diagram, mengisi lembar kerja, menetapkan rumus gaya A1 atau R1C1, menghitung ulang, membaca nilai yang dihitung, menghubungkan sel tersebut ke seri diagram, dan menyimpan presentasi. Artikel ini juga menggambarkan sintaks rumus yang didukung, subset fungsi bawaan, nilai yang di‑cache, rumus yang tidak didukung, dan kesalahan spesifik spreadsheet.

## **Lembar Kerja Diagram dan Rumus**

Lembar kerja diagram berisi kategori, nama seri, dan nilai yang digunakan oleh diagram. Di PowerPoint, Anda dapat memeriksa lembar kerja dengan membuka editor data diagram:

![Diagram PowerPoint dengan lembar kerja tersemat terbuka, menampilkan data kategori dan seri](chart-worksheet-formulas_1.png)

Di Aspose.Slides, lembar kerja diekspos melalui [buku kerja data diagram](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdataworkbook/). Gunakan properti [formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/formula/) untuk rumus gaya A1 dan properti [r1c1_formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) untuk rumus gaya R1C1. Setelah mengubah sel masukan atau rumus, panggil [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) untuk menghitung ulang rumus yang didukung dan memperbarui nilai sel yang bersesuaian.

Sebuah sel yang telah dihitung tetap mengekspos hasilnya melalui properti [value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/value/). Ini penting saat Anda perlu memeriksa hasil rumus dalam kode atau menggunakan sel sebagai titik data diagram.

## **Membuat Diagram dan Menghitung Rumus Lembar Kerja**

Contoh berikut memperlihatkan alur kerja menyeluruh. Ia membuat diagram kolom berkelompok, menghapus data contoh, menulis nilai pendapatan dan biaya kuartalan, menghitung laba dengan rumus, membaca hasilnya, menggunakan sel yang dihitung sebagai nilai diagram, dan menyimpan presentasi.

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

Titik data diagram merujuk ke `D2:D4`, sehingga diagram menggunakan nilai laba yang dihitung. Tidak ada pemanggilan penyegaran diagram terpisah dalam alur kerja ini: hitung ulang buku kerja terlebih dahulu, kemudian gunakan atau simpan data diagram yang menunjuk ke sel yang telah dihitung.

## **Menggunakan Rumus Gaya A1**

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

Referensi relatif dapat berubah ketika rumus dipindahkan atau disalin oleh aplikasi spreadsheet. Referensi absolut menjaga kedua koordinat tetap, sementara referensi campuran memperbaiki hanya baris atau kolom saja.

## **Menggunakan Rumus Gaya R1C1**

Notasi R1C1 mengidentifikasi baris dan kolom secara numerik. Referensi relatif menggunakan offset dalam tanda kurung siku. Tetapkan sintaks ini melalui [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

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

Sebagai contoh, di sel `D2`, `RC[-2]` berarti sel pada baris yang sama dua kolom ke kiri (`B2`).

## **Konstanta dan Operator Rumus**

Evaluator rumus bawaan mendukung nilai logika, literal numerik, string, nilai kesalahan spreadsheet, operator aritmetika, dan operator perbandingan.

### **Konstanta dan Literal**

| Tipe | Contoh | Catatan |
|---|---|---|
| Logika | `TRUE`, `FALSE` | Dapat digunakan langsung dalam ekspresi logika seperti `A2=TRUE`. |
| Numerik | `1`, `0.5`, `.3`, `1E-2` | Notasi umum dan ilmiah didukung. |
| String | `"abc"`, `"2/3/2020 12:00"` | Literal teks ditempatkan dalam tanda kutip ganda di dalam rumus. |
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

| Operator | Arti | Contoh |
|---|---|---|
| `+` | Penjumlahan atau plus unari | `2+3` |
| `-` | Pengurangan atau negasi | `2-3`, `-3` |
| `*` | Perkalian | `2*3` |
| `/` | Pembagian | `2/3` |
| `%` | Persen | `30%` |
| `^` | Pangkat | `2^3` |

Gunakan tanda kurung untuk membuat urutan evaluasi eksplisit, misalnya `(A2+B2)*C2`.

### **Operator Perbandingan**

Ekspresi perbandingan mengembalikan nilai logika.

| Operator | Arti | Contoh |
|---|---|---|
| `=` | Sama dengan | `A2=3` |
| `<>` | Tidak sama dengan | `A2<>3` |
| `>` | Lebih besar dari | `A2>3` |
| `>=` | Lebih besar atau sama dengan | `A2>=3` |
| `<` | Lebih kecil dari | `A2<3` |
| `<=` | Lebih kecil atau sama dengan | `A2<=3` |

## **Fungsi Bawaan yang Didukung**

Aspose.Slides menyertakan evaluator rumus bawaan untuk lembar kerja diagram, tetapi bukan mesin kalkulasi Excel yang lengkap. Set fungsi yang terdokumentasi terbatas pada fungsi di bawah ini. Jangan mengasumsikan bahwa fungsi Excel arbitrer dapat dihitung ulang oleh [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Fungsi | Tujuan atau bentuk yang didukung | Contoh |
|---|---|---|
| `ABS` | Nilai absolut | `ABS(A2)` |
| `AVERAGE` | Rata‑rata aritmetika | `AVERAGE(B2:B5)` |
| `CEILING` | Membulatkan angka ke atas ke kelipatan | `CEILING(A2,5)` |
| `CHOOSE` | Memilih nilai berdasarkan indeks | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Menggabungkan nilai teks | `CONCAT(A2,B2)` |
| `CONCATENATE` | Menggabungkan nilai teks | `CONCATENATE(A2," ",B2)` |
| `DATE` | Membuat nilai tanggal menggunakan sistem tanggal 1900 | `DATE(2026,8,19)` |
| `DAYS` | Mengembalikan jumlah hari antar tanggal | `DAYS(B2,A2)` |
| `FIND` | Menemukan satu nilai teks di dalam yang lain | `FIND("-",A2)` |
| `FINDB` | Pencarian teks berbasis byte | `FINDB("a",A2)` |
| `IF` | Hasil bersyarat | `IF(A2>0,A2,0)` |
| `INDEX` | Bentuk referensi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Bentuk vektor | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Bentuk vektor | `MATCH(A2,B2:B5,0)` |
| `MAX` | Nilai maksimum | `MAX(B2:B5)` |
| `SUM` | Menjumlahkan nilai | `SUM(B2:B5)` |
| `VLOOKUP` | Pencarian vertikal | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Pembatasan dalam tabel tersebut signifikan: `INDEX` didokumentasikan dalam bentuk referensi, sementara `LOOKUP` dan `MATCH` didokumentasikan dalam bentuk vektornya. `DATE` menggunakan sistem tanggal 1900. Fitur dan fungsi yang tidak tercantum di sini harus dianggap tidak didukung oleh evaluator rumus Aspose.Slides kecuali mereka didokumentasikan secara terpisah.

## **Perhitungan Ulang dan Nilai yang Di‑Cache**

File spreadsheet biasanya menyimpan baik rumus maupun nilai terakhir yang dihitung. Aspose.Slides dapat membaca nilai yang di‑cache dari [IChartDataCell.value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/value/) ketika presentasi dimuat dan data diagram terkait belum diubah.

Setelah mengubah sel masukan atau rumus, jangan mengandalkan hasil cache lama. Panggil [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) sebelum membaca nilai yang dihitung atau menyimpan data diagram yang bergantung padanya.

Untuk rumus di luar subset yang didukung, Aspose.Slides mungkin tidak dapat mengurai rumus atau menentukan dependensinya. Jika buku kerja telah dimodifikasi, nilai cache sebelumnya tidak lagi dapat diandalkan. Dalam situasi tersebut, membaca nilai sel dengan data yang tidak didukung dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Jika diagram Anda bergantung pada fungsi Excel yang tidak dievaluasi oleh Aspose.Slides, hitung rumus tersebut dengan mesin spreadsheet yang mendukungnya dan tulis kembali nilai hasil ke buku kerja diagram. Jangan mengganti rumus yang tidak didukung dengan nilai tebak‑tebakan.

## **Menangani Kesalahan Rumus**

Ada dua jenis masalah yang perlu dibedakan.

Sebuah rumus dapat valid tetapi menghasilkan nilai kesalahan spreadsheet seperti `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, atau `#VALUE!`. Dalam kasus ini, token kesalahan adalah hasil sel dan dapat dikembalikan melalui `value`.

Sebuah rumus juga dapat gagal pada level parsing, referensi, dependensi, atau data yang didukung. Aspose.Slides menyediakan pengecualian spesifik spreadsheet untuk kasus ini: [CellInvalidFormulaException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), dan [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ketika rumus berasal dari templat atau masukan pengguna, tangani pengecualian ini di sekitar perhitungan ulang dan akses nilai:

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

Dukungan rumus dalam lembar kerja diagram ditujukan untuk subset perhitungan spreadsheet yang terdefinisi, bukan kompatibilitas Excel penuh. Ingat batasan ini saat merancang alur kerja pelaporan:

- Gunakan hanya konstanta, operator, referensi, dan fungsi yang terdokumentasi ketika Anda memerlukan Aspose.Slides untuk menghitung ulang rumus.
- Hitung ulang setelah mengubah sel yang memengaruhi hasil rumus.
- Anggap nilai yang di‑cache dari presentasi yang dimuat sebagai snapshot, bukan pengganti perhitungan ulang setelah penyuntingan.
- Uji rumus dari templat yang ada sebelum mengandalkan nilai yang dihitung, terutama bila mereka menggunakan fungsi di luar daftar yang terdokumentasi.
- Untuk rumus yang memerlukan mesin perhitungan spreadsheet lengkap, hitunglah secara eksternal lalu perbarui buku kerja diagram dengan nilai hasil.

## **FAQ**

**Apa perbedaan antara `formula` dan `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/formula/) menyimpan ekspresi gaya A1 seperti `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) menyimpan ekspresi gaya R1C1 seperti `RC[-2]-RC[-1]`. Gunakan notasi yang paling sesuai dengan cara Anda menghasilkan atau menyalin rumus.

**Apakah saya perlu membaca sel itu sendiri atau nilai setelah perhitungan?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) mengembalikan sebuah `IChartDataCell`. Untuk memperoleh hasil yang dihitung, baca properti [value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichartdatacell/value/) sel tersebut setelah perhitungan ulang.

**Kapan saya harus memanggil `calculate_formulas`?**

Panggil [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) setelah mengubah nilai masukan atau rumus dan sebelum Anda bergantung pada hasil yang dihitung. Ini memperbarui nilai rumus yang didukung oleh evaluator bawaan.

**Apakah Aspose.Slides mendukung setiap fungsi Excel?**

Tidak. Evaluator bawaan mendukung subset fungsi yang terdokumentasi. Fungsi di luar subset tersebut tidak boleh dianggap dapat dihitung ulang dengan benar. Jika kompatibilitas rumus Excel penuh diperlukan, lakukan perhitungan dengan mesin spreadsheet yang sesuai dan tulis nilai akhir ke buku kerja diagram.

**Apa yang terjadi jika presentasi yang dimuat berisi rumus yang tidak didukung?**

Jika data diagram tidak berubah, buku kerja mungkin masih berisi nilai cache yang dihitung sebelumnya. Setelah data terkait diubah, nilai cache tersebut mungkin tidak lagi valid. Mengakses sel yang rumusnya tidak dapat ditangani dapat memicu [CellUnsupportedDataException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Apakah nilai kesalahan rumus sama dengan pengecualian Python?**

Tidak. Nilai seperti `#DIV/0!` adalah nilai spreadsheet yang dihasilkan oleh perhitungan yang valid. Pengecualian seperti [CellInvalidFormulaException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) atau [CellCircularReferenceException](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) menunjukkan bahwa rumus tidak dapat diproses secara normal.

**Apakah diagram memperbarui otomatis ketika sel rumus berubah?**

Seri diagram dapat merujuk ke sel buku kerja. Hitung ulang buku kerja terlebih dahulu, lalu simpan atau render presentasi. Jika titik data diagram merujuk ke sel yang dihitung, diagram akan menggunakan nilai sel yang telah diperbarui; tidak diperlukan metode penyegaran diagram terpisah untuk alur kerja ini.

**Dapatkah diagram menggunakan buku kerja Excel eksternal?**

Ya, data diagram dapat dikonfigurasi untuk menggunakan buku kerja eksternal melalui API data diagram. Namun, alur kerja perhitungan rumus yang dijelaskan dalam artikel ini berkaitan dengan buku kerja data diagram dan subset rumus yang dievaluasi oleh Aspose.Slides. Jangan mengasumsikan bahwa [calculate_formulas](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) menyediakan perhitungan lengkap untuk rumus arbitrer dalam file XLSX eksternal.

**Bisakah saya menggunakan rumus yang merujuk ke lembar kerja atau buku kerja lain?**

Referensi gaya Excel dapat muncul dalam buku kerja diagram, tetapi evaluasi rumus terbatas pada parser dan set fungsi yang didukung. Jika referensi silang lembar atau eksternal penting, validasi rumus tersebut dengan versi Aspose.Slides yang Anda gunakan. Untuk alur kerja yang memerlukan kompatibilitas referensi Excel yang luas, hitung buku kerja secara eksternal dan tulis kembali nilai yang terurai ke data diagram.

**Apakah string rumus harus diawali dengan `=`?**

Contoh API Aspose.Slides menetapkan ekspresi seperti `B2-C2` atau `SUM(B2:B5)` tanpa `=` di depannya. Menggunakan bentuk itu menjaga konsistensi rumus yang dihasilkan dengan contoh API yang terdokumentasi.