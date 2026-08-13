---
title: Simpan Presentasi dalam Mode Hanya Baca Menggunakan Java
linktitle: Presentasi Hanya Baca
type: docs
weight: 30
url: /id/java/read-only-presentation/
keywords:
- hanya baca
- melindungi presentasi
- mencegah penyuntingan
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode hanya baca dengan Aspose.Slides untuk Java, memberikan pratinjau slide yang akurat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Pada PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi presentasi ketika

- Anda ingin mencegah penyuntingan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, saat pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin akan melihat pesan seperti berikut: *To prevent accidental changes, the author has set this file to open as read-only.*

Rekomendasi Read-Only merupakan pencegah sederhana namun efektif yang menghalangi penyuntingan karena pengguna harus melakukan suatu tindakan untuk menghilangkannya sebelum mereka diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna mengubah presentasi dan ingin memberi tahu mereka dengan cara yang sopan, maka rekomendasi Read-Only dapat menjadi opsi yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Read-Only**

Aspose.Slides for Java memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam Java menggunakan Aspose.Slides:

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

**Catatan**: Rekomendasi **Read-Only** hanya dimaksudkan untuk menghalangi penyuntingan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang berpengalaman—yang tahu apa yang dilakukannya—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar‑benar perlu mencegah penyuntingan tidak sah, lebih baik gunakan [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/id/java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Bagaimana 'Read-Only recommended' berbeda dari perlindungan password penuh?

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah dihindari. [Password protection](/slides/id/java/password-protected-presentation/) sebenarnya membatasi pembukaan atau penyuntingan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

### Bisakah 'Read-Only recommended' digabungkan dengan watermark untuk lebih menghalangi penyuntingan?

Ya. Rekomendasi dapat dipasangkan dengan [watermarks](/slides/id/java/watermark/) sebagai pencegah visual; keduanya adalah mekanisme terpisah dan bekerja dengan baik bersama.

### Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?

Ya. Rekomendasi tidak memblokir perubahan programatis. Untuk mencegah penyuntingan otomatis, gunakan [passwords and encryption](/slides/id/java/password-protected-presentation/).

### Bagaimana 'Read-Only recommended' berhubungan dengan metode 'isEncrypted' dan 'isWriteProtected'?

Mereka merupakan sinyal yang berbeda. 'Read-Only recommended' adalah prompt lunak dan opsional; [isWriteProtected](https://reference.aspose.com/slides/id/java/com.aspose.slides/protectionmanager/#isWriteProtected--) dan [isEncrypted](https://reference.aspose.com/slides/id/java/com.aspose.slides/protectionmanager/#isEncrypted--) menunjukkan pembatasan tulis atau baca yang sebenarnya yang bergantung pada password atau enkripsi.