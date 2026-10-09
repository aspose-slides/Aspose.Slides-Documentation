---
title: Deklarasi
type: docs
weight: 60
url: /id/java/artifact-classifier-change/
keywords:
- pengklasifikasi Aspose.Slides
- pengklasifikasi artefak
- gunakan Aspose.Slides
- instalasi Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Aspose.Slides untuk Java kini menggunakan pengklasifikasi jdk8 alih-alih jdk16. Pelajari mengapa dan cara memperbarui dependensi Anda."
---
## **Perubahan Pengklasifikasi Artefak dari `jdk16` ke `jdk8`**

Mulai dari versi **26.10**, kami telah mengubah pengklasifikasi yang digunakan dalam artefak yang dipublikasikan dari **`jdk16`** (Java 6) ke **`jdk8`** (Java 8).

### **Apa yang berubah**

| | Sebelum | Sesudah |
|---|---|---|
| Pengklasifikasi | `jdk16` | `jdk8` |
| Versi Java minimum | Java 1.6 | Java 8 |

**Sebelum:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Sesudah:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Mengapa kami melakukan perubahan ini**

Setelah tinjauan internal, kami memutuskan untuk **menghentikan dukungan untuk versi Java lama** yang tidak lagi memberikan nilai dan secara aktif menghambat pemeliharaan. Java 8 dipilih sebagai dasar baru yang aman untuk semua konsumen.

Sebagai bagian dari ini, pengklasifikasi diperbarui untuk mencerminkan versi minimum yang sebenarnya didukung. Kami juga menyelaraskan dengan konvensi penamaan Oracle saat ini, di mana produk secara resmi disebut **JDK 8** (bukan format legasi `1.8`).

### **Apa yang perlu Anda lakukan**

1. **Perbarui pengklasifikasi** dalam deklarasi dependensi Anda dari `jdk16` ke `jdk8`.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Verifikasi lingkungan runtime Anda** menggunakan Java 8 atau lebih tinggi.

3. **Segarkan semua file kunci** atau cache dependensi yang mengunci pengklasifikasi lama.

### **Catatan Migrasi: jdk16 dan jdk8**

Mulai versi 26.10, kedua pengklasifikasi jdk16 dan jdk8 akan menyediakan JAR yang kompatibel dengan Java 8 (dibangun dengan kompatibilitas source/target diatur ke Java 8).

 - `jdk16` → tetap dipublikasikan untuk kompatibilitas mundur (integrasi yang ada).
 - `jdk8` → diperkenalkan sebagai pengklasifikasi baru yang disarankan untuk lingkungan Java 8.

⚠️ Catatan: Fase publikasi ganda ini dijadwalkan berakhir pada 31 Maret 2027. Setelah tanggal ini, pengklasifikasi jdk16 akan dihentikan, dan hanya jdk8 yang akan didukung.

### **Catatan kompatibilitas**

- Pengklasifikasi `jdk16` **tidak lagi dipublikasikan** setelah **31 Maret 2027**.
- Jika Anda masih memerlukan dukungan Java 1.6, silakan tetap pada jalur versi utama sebelumnya sampai Anda dapat bermigrasi.

### **Butuh bantuan?**

Jika Anda mengalami masalah selama migrasi, silakan hubungi [Aspose support](https://forum.aspose.com/) untuk bantuan lebih lanjut.