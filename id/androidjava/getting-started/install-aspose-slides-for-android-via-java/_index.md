---
title: Instal Aspose.Slides untuk Android via Java
type: docs
weight: 90
url: /id/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- instal Aspose.Slides
- unduh Aspose.Slides
- gunakan Aspose.Slides
- instalasi Aspose.Slides
- Gradle
- repositori Maven
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Tambahkan Aspose.Slides untuk Android via Java ke proyek Android Studio dengan Gradle dari repositori Maven Aspose, atau tambahkan file JAR secara manual."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan Aspose.Slides for Android via Java ke proyek Android. Cara yang direkomendasikan adalah membiarkan Gradle mengunduh perpustakaan dari repositori Maven Aspose. Anda juga dapat mengunduh file JAR dan menambahkannya ke proyek Anda secara manual.

Perpustakaan ini tidak dipublikasikan ke Maven Central atau repositori Maven Google. Itu tersedia dari repositori milik Aspose, sebagai artefak `aspose-slides` dengan classifier `android.via.java`.

## **Instal dari Repositori Maven Aspose**

### **Langkah 1: Tambahkan Repository**

Proyek Android Studio baru mendeklarasikan repositori mereka dalam blok `dependencyResolutionManagement` pada *settings.gradle.kts*, dan Gradle menolak repositori yang ditambahkan oleh file build modul. Tambahkan baris `maven` yang ditampilkan di bawah ke dalam blok `repositories` di dalam blok yang sudah ada itu, bukan menempelkan blok `dependencyResolutionManagement` kedua:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Langkah 2: Tambahkan Dependensi**

Tambahkan perpustakaan ke dalam blok `dependencies` pada file build modul aplikasi, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Bagian terakhir dari koordinat, `android.via.java`, adalah classifier yang memilih build Android dari perpustakaan. Tanpa itu, Gradle tidak dapat menemukan artefak.

Kemudian sinkronkan proyek dengan file Gradle, sehingga Gradle mengunduh perpustakaan.

### **Pilih Versi**

Aspose.Slides for Android via Java tidak dibangun untuk setiap versi di repositori. Build‑nya hanya dipublikasikan untuk beberapa versi Aspose.Slides for Java, dan versi tanpa build Android tidak dapat diselesaikan. Pilih versi yang terdaftar pada [halaman unduhan Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/).

### **Skrip Build Groovy**

Jika proyek Anda menggunakan skrip build Groovy, tambahkan baris `maven` ke dalam blok `repositories` di dalam blok `dependencyResolutionManagement` yang ada pada *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

Dan tambahkan dependensi ke *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Tambahkan File JAR Secara Manual**

Jika Anda tidak dapat menggunakan repositori Maven, tambahkan file JAR ke proyek Anda:

1. Unduh file JAR dari folder versi di [repositori Maven Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Untuk versi 26.9, file tersebut adalah *aspose-slides-26.9-android.via.java.jar* di folder *26.9*.
2. Salin file ke dalam folder *app/libs* pada proyek Anda. Buat folder tersebut jika belum ada.
3. Tambahkan file ke dalam blok `dependencies` pada *app/build.gradle.kts*, lalu sinkronkan proyek:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Buat Presentasi Pertama Anda**

Setelah proyek disinkronkan, lanjutkan dengan [Buat Presentasi](/slides/id/androidjava/create-presentation/). Contoh pertamanya menambahkan kotak teks ke slide dan menyimpan presentasi ke penyimpanan privat aplikasi Anda, yang tidak memerlukan izin penyimpanan. Tanpa lisensi, Aspose.Slides menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Lisensi](/slides/id/androidjava/licensing/).

## **Versi**

Sejak 2018, penomoran versi Aspose.Slides for Android via Java telah sesuai dengan Aspose.Slides for Java. Build Android tidak dipublikasikan untuk setiap versi Java; lihat [Pilih Versi](#choose-a-version).

## **FAQ**

### Bagaimana saya dapat memverifikasi bahwa Aspose.Slides terintegrasi dengan benar?

Buat proyek Anda, buat instance [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) kosong dan simpan dengan nama baru. Jika file dibuat tanpa melemparkan pengecualian, perpustakaan telah berhasil diintegrasikan.

### Bagaimana saya dapat membatasi konsumsi memori saat memproses presentasi besar?

Panggil metode [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) pada setiap instance [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) dalam blok `finally` untuk melepaskan sumber dayanya dengan cepat, dan proses satu presentasi besar pada satu waktu. Ini membantu mencegah kesalahan out-of-memory dan menjaga penggunaan memori secara keseluruhan tetap dapat diprediksi selama operasi batch.

### Bisakah saya mengecualikan format ekspor yang tidak diinginkan untuk memperkecil ukuran JAR akhir?

Rilis Aspose.Slides saat ini dikirim sebagai satu perpustakaan monolitik, sehingga Anda tidak dapat menonaktifkan ekspor tertentu seperti PDF atau SVG pada saat build.