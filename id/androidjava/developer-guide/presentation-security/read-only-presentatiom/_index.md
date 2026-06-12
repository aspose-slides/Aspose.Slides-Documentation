---
title: Simpan Presentasi dalam Mode Read-Only di Android
linktitle: Presentasi Read-Only
type: docs
weight: 30
url: /id/androidjava/read-only-presentation/
keywords:
- baca saja
- lindungi presentasi
- cegah pengeditan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Simpan file PowerPoint (PPT, PPTX) dalam mode read-only dengan Aspose.Slides untuk Android via Java, menyediakan pratinjau slide yang tepat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah pengeditan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini untuk dibuka sebagai read-only.*

Rekomendasi Read-Only merupakan penangkal yang sederhana namun efektif yang menghalangi pengeditan karena pengguna harus melakukan suatu tindakan untuk menghapusnya sebelum mereka diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka tentang hal ini dengan cara yang sopan, maka rekomendasi Read-Only dapat menjadi pilihan yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Read-Only**

Aspose.Slides for Android via Java memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) akan melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam Java menggunakan Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Catatan**: Rekomendasi **Read-Only** semata-mata dimaksudkan untuk menghalangi pengeditan atau menghentikan pengguna membuat perubahan tidak sengaja pada sebuah presentasi PowerPoint. Jika seseorang yang berpengalaman—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar‑benar perlu mencegah pengeditan tidak sah, Anda sebaiknya menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Bagaimana perbedaan 'Read-Only recommended' dengan perlindungan kata sandi penuh?**

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah dilewati. [Password protection](/slides/id/androidjava/password-protected-presentation/) sebenarnya membatasi pembukaan atau pengeditan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

**Apakah 'Read-Only recommended' dapat digabungkan dengan watermark untuk lebih menghalangi pengeditan?**

Ya. Rekomendasi tersebut dapat dipasangkan dengan [watermarks](/slides/id/androidjava/watermark/) sebagai penangkal visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama-sama.

**Apakah macro atau alat eksternal masih dapat memodifikasi file saat rekomendasi diaktifkan?**

Ya. Rekomendasi tersebut tidak memblokir perubahan secara programatik. Untuk mencegah pengeditan otomatis, gunakan [passwords and encryption](/slides/id/androidjava/password-protected-presentation/).

**Bagaimana hubungan 'Read-Only recommended' dengan metode 'isEncrypted' dan 'isWriteProtected'?**

Mereka adalah sinyal yang berbeda. 'Read-Only recommended' adalah prompt yang lembut dan opsional; [isWriteProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) dan [isEncrypted](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) menunjukkan pembatasan tulis atau baca yang sebenarnya yang bergantung pada kata sandi atau enkripsi.