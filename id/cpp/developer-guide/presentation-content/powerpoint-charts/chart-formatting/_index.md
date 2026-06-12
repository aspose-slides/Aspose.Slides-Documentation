---
title: Format Diagram Presentasi di C++
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/cpp/chart-formatting/
keywords:
- format diagram
- pemformatan diagram
- entitas diagram
- properti diagram
- pengaturan diagram
- opsi diagram
- properti font
- bingkai melengkung
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk C++ dan tingkatkan presentasi PowerPoint Anda dengan gaya profesional yang menarik perhatian."
---
## **Ikhtisar**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan pengisian dinding untuk meningkatkan tampilan dan keterbacaan data diagram.

Artikel ini juga mendemonstrasikan cara mengatur properti font untuk teks diagram, menerapkan format numerik bawaan dan kustom ke data diagram, serta mengaktifkan sudut melengkung untuk area diagram. Bersama-sama, contoh-contoh ini menunjukkan cara mengendalikan baik gaya visual maupun penyajian data diagram dalam sebuah presentasi.

## **Format Entitas Diagram**
Aspose.Slides untuk C++ memungkinkan pengembang menambahkan diagram kustom ke slide mereka dari awal. Artikel ini menjelaskan cara memformat berbagai entitas diagram termasuk kategori diagram dan sumbu nilai.

Aspose.Slides untuk C++ menyediakan API sederhana untuk mengelola berbagai entitas diagram dan memformatnya menggunakan nilai kustom:

1. Buat instance dari kelas **Presentation**.
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default bersama dengan salah satu tipe yang diinginkan (dalam contoh ini kita akan menggunakan ChartType.LineWithMarkers).
4. Akses sumbu Nilai (Value Axis) diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis Kisi Besar (Major Grid) pada sumbu Nilai
   2. Mengatur **Line format** untuk garis Kisi Kecil (Minor Grid) pada sumbu Nilai
   3. Mengatur **Number Format** untuk sumbu Nilai
   4. Mengatur **Min, Max, Major and Minor units** untuk sumbu Nilai
   5. Mengatur **Text Properties** untuk data sumbu Nilai
   6. Mengatur **Title** untuk sumbu Nilai
   7. Mengatur **Line Format** untuk sumbu Nilai
5. Akses sumbu Kategori (Category Axis) diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis Kisi Besar pada sumbu Kategori
   2. Mengatur **Line format** untuk garis Kisi Kecil pada sumbu Kategori
   3. Mengatur **Text Properties** untuk data sumbu Kategori
   4. Mengatur **Title** untuk sumbu Kategori
   5. Mengatur **Label Positioning** untuk sumbu Kategori
   6. Mengatur **Rotation Angle** untuk label sumbu Kategori
6. Akses Legenda diagram dan atur **Text Properties** untuknya
7. Atur tampilan Legenda diagram agar tidak tumpang tindih dengan diagram
8. Akses **Secondary Value Axis** diagram dan atur properti berikut:
   1. Aktifkan **Value Axis** Sekunder
   2. Mengatur **Line Format** untuk Secondary Value Axis
   3. Mengatur **Number Format** untuk Secondary Value Axis
   4. Mengatur **Min, Max, Major and Minor units** untuk Secondary Value Axis
9. Sekarang plot seri diagram pertama pada Secondary Value Axis
10. Atur dinding belakang diagram dengan warna isian
11. Atur warna isian area plot diagram
12. Tulis presentasi yang dimodifikasi ke file PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Atur Properti Font untuk Diagram**
Aspose.Slides untuk C++ mendukung pengaturan properti terkait font untuk diagram. Silakan ikuti langkah-langkah berikut untuk mengatur properti font diagram.

- Membuat objek kelas Presentation.
- Menambahkan diagram pada slide.
- Mengatur tinggi font.
- Menyimpan presentasi yang dimodifikasi.

Contoh sampel di bawah diberikan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Atur Properti Font untuk Tabel Data Diagram**
Aspose.Slides untuk C++ mendukung perubahan warna kategori dalam warna seri.

1. Membuat objek kelas Presentation.
1. Menambahkan diagram pada slide.
1. Mengatur tabel diagram.
1. Mengatur tinggi font.
1. Menyimpan presentasi yang dimodifikasi.

Contoh sampel di bawah diberikan. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Atur Bingkai Sudut Membulat Area Diagram**
Aspose.Slides untuk C++ mendukung pengaturan area diagram. Properti **IChart.HasRoundedCorners** dan **Chart.HasRoundedCorners** telah ditambahkan di Aspose.Slides. 

1. Membuat objek kelas Presentation.
1. Menambahkan diagram pada slide.
1. Mengatur tipe isian dan warna isian diagram
1. Mengatur properti sudut melengkung menjadi True.
1. Menyimpan presentasi yang dimodifikasi. 

Contoh sampel di bawah diberikan. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Atur Format Numerik**
Aspose.Slides untuk C++ menyediakan API sederhana untuk mengelola format data diagram:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default bersama dengan salah satu tipe yang diinginkan (contoh ini menggunakan **ChartType.ClusteredColumn**).
4. Atur format angka bawaan dari nilai preset yang tersedia.
5. Telusuri setiap sel data diagram dalam setiap seri diagram dan atur format angka data diagram.
6. Simpan presentasi.
7. Atur format angka kustom.
8. Telusuri sel data diagram di dalam setiap seri diagram dan atur format angka data diagram yang berbeda.
9. Simpan presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Nilai format angka preset yang mungkin beserta indeks presetnya dan dapat digunakan diberikan di bawah:**|
| :- | :- |
|**0**|Umum|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **FAQ**

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil mempertahankan garis batas tidak tembus pandang?**

Ya. Transparansi isian dan garis batas dikonfigurasi secara terpisah. Ini berguna untuk meningkatkan keterbacaan kisi dan data pada visualisasi yang padat.

**Bagaimana cara menangani label data ketika mereka tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya, kategori), atur offset/posisi label, tampilkan label hanya untuk titik yang dipilih jika diperlukan, atau ubah format menjadi "value + legend".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Isian padat dan gradien/pola biasanya tersedia. Dalam praktiknya, gunakan gradien secara terbatas dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.