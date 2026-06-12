---
title: Simpan Presentasi dalam Mode Baca Saja di .NET
linktitle: Presentasi Baca Saja
type: docs
weight: 30
url: /id/net/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah pengeditan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode baca saja dengan Aspose.Slides for .NET, menyediakan pratinjau slide yang tepat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah pengeditan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, saat pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini untuk dibuka sebagai read-only.*

Rekomendasi Read-Only adalah pencegah sederhana namun efektif yang menghalangi pengeditan karena pengguna harus melakukan tindakan untuk menghapusnya sebelum diizinkan mengedit sebuah presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka tentang hal ini dengan cara yang sopan, maka rekomendasi Read-Only dapat menjadi pilihan yang baik bagi Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Read-Only**

Aspose.Slides for .NET memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) akan melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam C# menggunakan Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Catatan**: Rekomendasi **Read-Only** dimaksudkan hanya untuk menghalangi pengeditan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang termotivasi—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda memang perlu mencegah pengeditan tidak sah, lebih baik menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?**

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah diabaikan. [Password protection](/slides/id/net/password-protected-presentation/) sebenarnya membatasi pembukaan atau pengeditan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

**Apakah 'Read-Only recommended' dapat digabungkan dengan watermark untuk lebih menghalangi pengeditan?**

Ya. Rekomendasi tersebut dapat dipasangkan dengan [watermarks](/slides/id/net/watermark/) sebagai pencegah visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama.

**Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?**

Ya. Rekomendasi tidak memblokir perubahan programatis. Untuk mencegah pengeditan otomatis, gunakan [passwords and encryption](/slides/id/net/password-protected-presentation/).

**Bagaimana 'Read-Only recommended' berhubungan dengan flag 'IsEncrypted' dan 'IsWriteProtected'?**

Mereka adalah sinyal yang berbeda. 'Read-Only recommended' adalah prompt lembut dan opsional; [IsWriteProtected](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/iswriteprotected/) dan [IsEncrypted](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/isencrypted/) menunjukkan pembatasan tulis atau baca yang sebenarnya yang bergantung pada kata sandi atau enkripsi.