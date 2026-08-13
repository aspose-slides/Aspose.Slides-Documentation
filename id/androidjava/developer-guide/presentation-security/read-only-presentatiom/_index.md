---
title: Simpan Presentasi dalam Mode Baca-Saja di Android
linktitle: Presentasi Baca-Saja
type: docs
weight: 30
url: /id/androidjava/read-only-presentation/
keywords:
- baca saja
- lindungi presentasi
- mencegah penyuntingan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Simpan file PowerPoint (PPT, PPTX) dalam mode baca-saja dengan Aspose.Slides untuk Android via Java, menawarkan pratinjau slide yang akurat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah penyuntingan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini untuk dibuka sebagai read-only.*

Rekomendasi Read-Only adalah penangkal sederhana namun efektif yang menghalangi penyuntingan karena pengguna harus melakukan suatu tindakan untuk menghapusnya sebelum mereka diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna mengubah presentasi dan ingin memberi tahu mereka tentang hal ini dengan cara yang sopan, maka rekomendasi Read-Only mungkin menjadi opsi yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru-baru ini diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Read-Only**

Aspose.Slides for Android via Java memungkinkan Anda menetapkan sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara menetapkan sebuah presentasi menjadi **Read-Only** dalam Java menggunakan Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Catatan**: Rekomendasi **Read-Only** hanya dimaksudkan untuk menghalangi penyuntingan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang termotivasi—yang mengetahui apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar‑benar perlu mencegah penyuntingan yang tidak sah, Anda sebaiknya menggunakan [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/id/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

### Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah diabaikan. [Password protection](/slides/id/androidjava/password-protected-presentation/) sebenarnya membatasi pembukaan atau penyuntingan dan cocok ketika Anda membutuhkan kontrol keamanan yang nyata.

### Dapatkah 'Read-Only recommended' digabungkan dengan watermark untuk lebih menghalangi penyuntingan?

Ya. Rekomendasi tersebut dapat dipasangkan dengan [watermarks](/slides/id/androidjava/watermark/) sebagai penangkal visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama.

### Dapatkah makro atau alat eksternal tetap memodifikasi file ketika rekomendasi diaktifkan?

Ya. Rekomendasi tidak memblokir perubahan secara programatik. Untuk mencegah penyuntingan otomatis, gunakan [passwords and encryption](/slides/id/androidjava/password-protected-presentation/).

### Bagaimana 'Read-Only recommended' terkait dengan metode 'isEncrypted' dan 'isWriteProtected'?

Mereka merupakan sinyal yang berbeda. 'Read-Only recommended' adalah prompt lembut dan opsional; [isWriteProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) dan [isEncrypted](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) menunjukkan pembatasan penulisan atau pembacaan yang sebenarnya yang bergantung pada kata sandi atau enkripsi.