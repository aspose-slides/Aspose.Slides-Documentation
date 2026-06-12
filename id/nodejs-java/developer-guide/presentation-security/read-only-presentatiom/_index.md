---
title: Simpan Presentasi dalam Mode Baca Saja Menggunakan JavaScript
linktitle: Presentasi Baca Saja
type: docs
weight: 30
url: /id/nodejs-java/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah pengeditan
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Muat dan simpan file PowerPoint dalam mode baca saja dengan Aspose.Slides untuk Node.js via Java, menawarkan pratinjau slide yang tepat tanpa mengubah presentasi Anda."
---
## **Introduction**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah pengeditan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *To prevent accidental changes, the author has set this file to open as read-only.*

Rekomendasi Read-Only adalah pencegah yang sederhana namun efektif yang menghalangi pengeditan karena pengguna harus melakukan tindakan untuk menghilangkannya sebelum diizinkan mengedit presentasi. Jika Anda tidak menginginkan pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka tentang hal ini dengan cara yang sopan, maka rekomendasi Read-Only dapat menjadi opsi yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** diabaikan (presentasi dibuka secara normal).

## **Apply Read-Only Mode**

Aspose.Slides for Node.js via Java memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) akan melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam JavaScript menggunakan Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
**Catatan**: Rekomendasi **Read-Only** dimaksudkan semata-mata untuk menghalangi pengeditan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang bermotivasi—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar-benar perlu mencegah pengeditan tidak sah, lebih baik menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/nodejs-java/password-protected-presentation/).
{{% /alert %}} 

## **FAQ**

**Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?**

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah untuk dilewati. [Password protection](/slides/id/nodejs-java/password-protected-presentation/) sebenarnya membatasi pembukaan atau pengeditan dan sesuai ketika Anda memerlukan kontrol keamanan yang nyata.

**Apakah 'Read-Only recommended' dapat digabungkan dengan watermark untuk lebih menghalangi pengeditan?**

Ya. Rekomendasi tersebut dapat dipasangkan dengan [watermarks](/slides/id/nodejs-java/watermark/) sebagai pencegah visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama-sama.

**Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?**

Ya. Rekomendasi tidak memblokir perubahan secara programatik. Untuk mencegah pengeditan otomatis, gunakan [passwords and encryption](/slides/id/nodejs-java/password-protected-presentation/).

**Bagaimana 'Read-Only recommended' berhubungan dengan flag 'IsEncrypted' dan 'IsWriteProtected'?**

Mereka adalah sinyal yang berbeda. 'Read-Only recommended' adalah prompt lembut yang opsional; [isWriteProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) dan [isEncrypted](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/isencrypted/) menunjukkan pembatasan penulisan atau pembacaan yang sebenarnya yang bergantung pada kata sandi atau enkripsi.