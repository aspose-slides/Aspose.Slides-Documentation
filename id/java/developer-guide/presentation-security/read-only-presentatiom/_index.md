---
title: Simpan Presentasi dalam Mode Baca Saja Menggunakan Java
linktitle: Presentasi Baca Saja
type: docs
weight: 30
url: /id/java/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah penyuntingan
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode baca saja dengan Aspose.Slides untuk Java, menawarkan pratinjau slide yang tepat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah penyuntingan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *To prevent accidental changes, the author has set this file to open as read-only.*

Rekomendasi Read-Only adalah pencegah sederhana namun efektif yang menghalangi penyuntingan karena pengguna harus melakukan sebuah tindakan untuk menghilangkannya sebelum mereka diizinkan mengedit sebuah presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka tentang hal ini dengan cara yang sopan, maka rekomendasi Read-Only dapat menjadi pilihan yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Read-Only**

Aspose.Slides for Java memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) akan melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam Java menggunakan Aspose.Slides:

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

**Catatan**: Rekomendasi **Read-Only** semata-mata dimaksudkan untuk menghalangi penyuntingan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang termotivasi—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda sangat perlu mencegah penyuntingan tidak sah, Anda lebih baik menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?**

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah diabaikan. [Perlindungan kata sandi](/slides/id/java/password-protected-presentation/) sebenarnya membatasi pembukaan atau penyuntingan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

**Dapatkah 'Read-Only recommended' digabungkan dengan watermark untuk lebih menghalangi penyuntingan?**

Ya. Rekomendasi tersebut dapat dipasangkan dengan [watermark](/slides/id/java/watermark/) sebagai pencegah visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama.

**Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?**

Ya. Rekomendasi tersebut tidak memblokir perubahan programatik. Untuk mencegah penyuntingan otomatis, gunakan [kata sandi dan enkripsi](/slides/id/java/password-protected-presentation/).

**Bagaimana 'Read-Only recommended' terkait dengan metode 'isEncrypted' dan 'isWriteProtected'?**

Mereka adalah sinyal yang berbeda. 'Read-Only recommended' adalah prompt yang lembut dan opsional; [isWriteProtected](https://reference.aspose.com/slides/id/java/com.aspose.slides/protectionmanager/#isWriteProtected--) dan [isEncrypted](https://reference.aspose.com/slides/id/java/com.aspose.slides/protectionmanager/#isEncrypted--) menunjukkan pembatasan penulisan atau pembacaan yang sebenarnya yang bergantung pada kata sandi atau enkripsi.