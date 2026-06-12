---
title: Simpan Presentasi dalam Mode Baca Saja Menggunakan PHP
linktitle: Presentasi Baca Saja
type: docs
weight: 30
url: /id/php-java/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah pengeditan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode baca saja dengan Aspose.Slides untuk PHP, menawarkan pratinjau slide yang tepat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah pengeditan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini untuk dibuka sebagai read-only.*

Rekomendasi Read-Only adalah pencegah yang sederhana namun efektif yang menghalangi pengeditan karena pengguna harus melakukan suatu tugas untuk menghilangkannya sebelum mereka diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka tentang hal ini secara sopan, maka rekomendasi Read-Only mungkin menjadi opsi yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru-baru ini diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Baca Saja**

Aspose.Slides for PHP via Java memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** menggunakan Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Catatan**: Rekomendasi **Read-Only** hanya dimaksudkan untuk menghalangi pengeditan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang berpengalaman—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda memang perlu mencegah pengeditan yang tidak sah, lebih baik menggunakan [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/id/php-java/password-protected-presentation/).

{{% /alert %}} 

## **Tanya Jawab**

**Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?**

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah diabaikan. [Password protection](/slides/id/php-java/password-protected-presentation/) sebenarnya membatasi pembukaan atau pengeditan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

**Bisa 'Read-Only recommended' digabungkan dengan watermark untuk lebih menghalangi pengeditan?**

Ya. Rekomendasi dapat dipasangkan dengan [watermarks](/slides/id/php-java/watermark/) sebagai pencegah visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama.

**Bisa macro atau alat eksternal tetap memodifikasi file ketika rekomendasi diaktifkan?**

Ya. Rekomendasi tidak memblokir perubahan secara programatik. Untuk mencegah edit otomatis, gunakan [passwords and encryption](/slides/id/php-java/password-protected-presentation/).

**Bagaimana 'Read-Only recommended' terkait dengan metode 'isEncrypted' dan 'isWriteProtected'?**

Mereka merupakan sinyal yang berbeda. 'Read-Only recommended' adalah prompt yang lembut dan opsional; [isWriteProtected](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/iswriteprotected/) dan [isEncrypted](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/isencrypted/) menunjukkan pembatasan menulis atau membaca yang sebenarnya yang bergantung pada kata sandi atau enkripsi.