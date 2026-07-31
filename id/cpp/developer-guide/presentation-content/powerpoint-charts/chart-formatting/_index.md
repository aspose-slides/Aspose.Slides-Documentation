---
title: Format Grafik Presentasi dalam C++
linktitle: Pemformatan Grafik
type: docs
weight: 60
url: /id/cpp/chart-formatting/
keywords:
- format grafik
- pemformatan grafik
- entitas grafik
- properti grafik
- pengaturan grafik
- opsi grafik
- properti font
- border melengkung
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari pemformatan grafik di Aspose.Slides untuk C++ dan tingkatkan presentasi PowerPoint Anda dengan gaya profesional yang menarik perhatian."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat grafik dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen grafik utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isian dinding untuk meningkatkan penampilan dan keterbacaan data grafik.

Artikel ini juga mendemonstrasikan cara mengatur properti font untuk teks grafik, menerapkan format numerik bawaan dan khusus pada data grafik, serta mengaktifkan sudut melengkung untuk area grafik. Bersama-sama, contoh-contoh ini menunjukkan cara mengendalikan baik gaya visual maupun penyajian data grafik dalam sebuah presentasi.

## **Format Entitas Grafik**

Aspose.Slides untuk C++ memungkinkan pengembang menambahkan grafik khusus ke slide mereka dari awal. Artikel ini menjelaskan cara memformat berbagai entitas grafik termasuk sumbu kategori dan nilai grafik.

Aspose.Slides untuk C++ menyediakan API sederhana untuk mengelola berbagai entitas grafik dan memformatnya menggunakan nilai kustom:

1. Buat sebuah instance dari kelas **Presentation**.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan grafik dengan data default bersama dengan salah satu tipe yang diinginkan (dalam contoh ini kita akan menggunakan ChartType.LineWithMarkers).
1. Akses Axis Nilai grafik dan atur properti berikut:
   1. Mengatur **Line format** untuk Garis Kisi Utama Axis Nilai
   1. Mengatur **Line format** untuk Garis Kisi Minor Axis Nilai
   1. Mengatur **Number Format** untuk Axis Nilai
   1. Mengatur **Min, Max, Major and Minor units** untuk Axis Nilai
   1. Mengatur **Text Properties** untuk data Axis Nilai
   1. Mengatur **Title** untuk Axis Nilai
   1. Mengatur **Line Format** untuk Axis Nilai
1. Akses Axis Kategori grafik dan atur properti berikut:
   1. Mengatur **Line format** untuk Garis Kisi Utama Axis Kategori
   1. Mengatur **Line format** untuk Garis Kisi Minor Axis Kategori
   1. Mengatur **Text Properties** untuk data Axis Kategori
   1. Mengatur **Title** untuk Axis Kategori
   1. Mengatur **Label Positioning** untuk Axis Kategori
   1. Mengatur **Rotation Angle** untuk label Axis Kategori
1. Akses Legenda grafik dan atur **Text Properties** untuknya
1. Tampilkan Legenda grafik tanpa menimpa grafik
1. Akses **Secondary Value Axis** grafik dan atur properti berikut:
   1. Aktifkan **Value Axis** Sekunder
   1. Mengatur **Line Format** untuk Secondary Value Axis
   1. Mengatur **Number Format** untuk Secondary Value Axis
   1. Mengatur **Min, Max, Major and Minor units** untuk Secondary Value Axis
1. Sekarang plot seri grafik pertama pada Secondary Value Axis
1. Atur warna isian dinding belakang grafik
1. Atur warna isian area plot grafik
1. Tuliskan presentasi yang dimodifikasi ke file PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Atur Properti Font untuk Grafik**

Aspose.Slides untuk C++ mendukung pengaturan properti terkait font untuk grafik. Silakan ikuti langkah-langkah di bawah ini untuk mengatur properti font grafik.

- Instansiasi objek kelas Presentation.
- Tambahkan grafik pada slide.
- Atur tinggi font.
- Simpan presentasi yang dimodifikasi.

Contoh sampel di bawah ini diberikan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Atur Properti Font untuk Tabel Data Grafik**

Aspose.Slides untuk C++ mendukung perubahan warna kategori dalam warna seri.

1. Instansiasi objek kelas Presentation.
1. Tambahkan grafik pada slide.
1. Atur tabel grafik.
1. Atur tinggi font.
1. Simpan presentasi yang dimodifikasi.

Contoh sampel di bawah ini diberikan. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Atur Bingkai Bulat pada Area Grafik**

Aspose.Slides untuk C++ mendukung pengaturan area grafik. Properti **IChart.HasRoundedCorners** dan **Chart.HasRoundedCorners** telah ditambahkan dalam Aspose.Slides. 

1. Instansiasi objek kelas Presentation.
1. Tambahkan grafik pada slide.
1. Atur jenis isian dan warna isian grafik
1. Atur properti sudut melengkung menjadi True.
1. Simpan presentasi yang dimodifikasi. 

Contoh sampel di bawah ini diberikan. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Atur Format Numerik**

Aspose.Slides untuk C++ menyediakan API sederhana untuk mengelola format data grafik:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan grafik dengan data default bersama dengan salah satu tipe yang diinginkan (contoh ini menggunakan **ChartType.ClusteredColumn**).
1. Atur format angka bawaan dari nilai preset yang tersedia.
1. Telusuri setiap sel data grafik dalam setiap seri grafik dan atur format angka data grafik.
1. Simpan presentasi.
1. Atur format angka khusus.
1. Telusuri setiap sel data grafik dalam setiap seri grafik dan atur format angka data grafik yang berbeda.
1. Simpan presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Nilai format angka preset yang mungkin beserta indeks presetnya dan dapat digunakan diberikan di bawah ini:**|
| :- | :- |

|**0**|Umum|
| :- | :- |
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

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil mempertahankan tepi tetap tidak transparan?**

Ya. Transparansi isian dan tepi diatur secara terpisah. Hal ini berguna untuk meningkatkan keterbacaan grid dan data pada visualisasi yang padat.

**Bagaimana saya dapat menangani label data ketika mereka tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya, kategori), atur offset/posisi label, tampilkan label hanya untuk poin yang dipilih jika diperlukan, atau ubah format menjadi "value + legend".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Baik isian solid maupun gradien/pola biasanya tersedia. Pada praktiknya, gunakan gradien secara hemat dan hindari kombinasi yang mengurangi kontras dengan grid dan teks.