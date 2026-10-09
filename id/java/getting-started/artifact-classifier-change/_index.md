---
title: Perubahan Klasifier Artefak
type: docs
weight: 60
url: /id/java/artifact-classifier-change/
keywords:
- klasifier Aspose.Slides
- klasifier artefak
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
description: "Aspose.Slides untuk Java sekarang menggunakan klasifier jdk8 alih-alih jdk16. Pelajari mengapa dan cara memperbarui dependensi Anda."
---
## **Perubahan Klasifier Artefak dari `jdk16` ke `jdk8`**

Mulai dengan versi **26.10**, kami telah mengubah klasifier yang digunakan dalam artefak yang dipublikasikan dari **`jdk16`** (Java 6) ke **`jdk8`** (Java 8).

### **Apa yang berubah**

| | Sebelum | Setelah |
|---|---|---|
| Klasifier | `jdk16` | `jdk8` |
| Versi Java Minimum | Java 1.6 | Java 8 |

**Sebelum:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Setelah:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Mengapa kami membuat perubahan ini**

Setelah tinjauan internal, kami memutuskan untuk **menghentikan dukungan untuk versi Java lama** yang tidak lagi memberikan nilai dan secara aktif menghambat pemeliharaan. Java 8 dipilih sebagai dasar baru yang aman untuk semua pengguna.

Sebagai bagian dari ini, klasifier diperbarui untuk mencerminkan versi minimum yang sebenarnya didukung. Kami juga menyesuaikan dengan konvensi penamaan Oracle saat ini, di mana produk secara resmi disebut **JDK 8** (bukan format warisan `1.8`).

### **Apa yang perlu Anda lakukan**

1. **Perbarui klasifier** dalam deklarasi ketergantungan Anda dari `jdk16` ke `jdk8`.

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

2. **Verifikasi lingkungan runtime** Anda adalah Java 8 atau lebih tinggi.

3. **Segarkan file lock** apa pun atau cache ketergantungan yang mengunci klasifier lama.

### **Catatan Migrasi: jdk16 dan jdk8**

Mulai versi 26.10​, kedua klasifier jdk16 dan jdk8 akan menyediakan JAR yang kompatibel dengan Java 8 (dibangun dengan kompatibilitas source/target disetel ke Java 8).

- `jdk16` → terus dipublikasikan untuk kompatibilitas mundur (integrasi yang ada).
- `jdk8` → diperkenalkan sebagai klasifier pilihan baru untuk lingkungan Java 8.

⚠️ Catatan: Fase publikasi ganda ini dijadwalkan berakhir pada 31 Maret 2027​. Setelah tanggal tersebut, klasifier jdk16 akan dihentikan, dan hanya jdk8 yang akan didukung.

### **Catatan kompatibilitas**

- `jdk16` klasifier **tidak lagi dipublikasikan** setelah **31 Maret 2027**.
- Jika Anda masih memerlukan dukungan Java 1.6, harap tetap pada lini versi mayor sebelumnya hingga Anda dapat bermigrasi.

### **Butuh bantuan?**

Jika Anda mengalami masalah saat migrasi, silakan hubungi [Dukungan Aspose](https://forum.aspose.com/) untuk bantuan lebih lanjut.