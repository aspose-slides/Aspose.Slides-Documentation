---
title: Pengecualian dan Kesalahan Umum yang Melibatkan Font di Linux
type: docs
weight: 200
url: /id/java/common-errors-involving-fonts/
keywords: "Pengecualian font, Kesalahan font, Linux, Java, Aspose.Slides untuk Java"
description: "Pengecualian dan kesalahan font di Linux"
---
## **Ikhtisar**

Ketika Aspose.Slides digunakan di Linux, masalah terkait font dapat terjadi jika proses Java tidak dapat mengakses folder font yang diperlukan atau direktori sementara, jika tidak ada font yang diinstal pada sistem, atau jika pustaka sistem yang diperlukan seperti fontconfig atau libfreetype tidak ada.

Artikel ini menjelaskan kesalahan dan pengecualian umum yang terkait dengan font di Linux serta menyediakan solusi untuk mengatasinya. Ini menjelaskan cara memeriksa akses ke direktori font dan TEMP, menginstal font serta pustaka yang diperlukan, dan menggunakan `FontsLoader` untuk memuat font tanpa menginstalnya secara sistem.

## **Teks atau Gambar Hilang (EMF atau WMF) Saat Kode Dijalankan di Linux**

Masalah ini terjadi pada sistem dengan pembatasan dalam kasus berikut:

1. Ketika tidak ada font yang diinstal atau ketika folder font untuk proses java tidak dapat diakses
2. Ketika direktori TEMP tidak dapat diakses.

### **Solusi**

Periksa dan pastikan bahwa akses ke direktori TEMP dan folder font telah diberikan. 

{{% alert color="warning" %}}
Dalam beberapa kasus, Anda mungkin tidak dapat memberikan akses ke folder karena pembatasan yang diberlakukan oleh lingkungan atau kebijakan keamanan. Coba solusi berikut: 
{{% /alert %}}

**Solusi Sementara**

Gunakan [FontsLoader](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsLoader) untuk memuat font yang diperlukan tanpa menginstalnya:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Jika direktori TEMP tidak dapat diakses, gunakan kode ini untuk menentukan direktori lain sebagai TEMP untuk Java:
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Pengecualian: InvalidOperationException: Tidak Dapat Menemukan Font yang Diinstal pada Sistem**

Pengecualian ini terjadi ketika

1) proses Java tidak dapat mengakses folder font  
2) tidak ada font yang diinstal.

### **Solusi**

1. Periksa dan pastikan bahwa akses ke folder font untuk proses Java telah diberikan.

2. Instal beberapa font atau gunakan [FontsLoader](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsLoader).

3. Instal font.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```

   * Menggunakan [FontsLoader](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Pengecualian: NoClassDefFoundError: Tidak Dapat Menginisialisasi Kelas com.aspose.slides.internal.ey.this**

Pengecualian ini terjadi pada sistem Linux yang tidak memiliki fontconfig dan font. 

### **Solusi**

Instal fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Selain itu, beberapa versi open-jdk (misalnya, **alpine JDK**) juga **memerlukan font yang diinstal**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```

## **Pengecualian: UnsatisfiedLinkError: libfreetype.so.6: Tidak Dapat Membuka File Objek Bersama: Tidak Ada File atau Direktori**

Pengecualian ini terjadi pada sistem Linux yang tidak memiliki pustaka libfreetype. 

### **Solusi**

Instal libfreetype dan fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="primary" %}} 
Jangan lupa menginstal font atau menggunakan FontsLoader.
{{% /alert %}}