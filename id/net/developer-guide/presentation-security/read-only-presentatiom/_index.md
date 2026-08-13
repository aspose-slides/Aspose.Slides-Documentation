---
title: Simpan Presentasi dalam Mode Read-Only di .NET
linktitle: Presentasi Read-Only
type: docs
weight: 30
url: /id/net/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah penyuntingan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode read-only dengan Aspose.Slides untuk .NET, memberikan pratinjau slide yang tepat tanpa mengubah presentasi Anda."
---
## **Pengantar**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah penyuntingan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini agar dibuka sebagai read-only.*

Rekomendasi Read-Only adalah pencegahan yang sederhana namun efektif yang menghalangi penyuntingan karena pengguna harus melakukan suatu tugas untuk menghapusnya sebelum mereka diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka tentang hal ini dengan cara yang sopan, maka rekomendasi Read-Only dapat menjadi pilihan yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Read-Only**

Aspose.Slides untuk .NET memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam C# menggunakan Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Catatan**: Rekomendasi **Read-Only** memang dimaksudkan untuk menghalangi penyuntingan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang berkemauan—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar‑benar perlu mencegah penyuntingan tidak sah, Anda lebih baik menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah diabaikan. [Password protection](/slides/id/net/password-protected-presentation/) sebenarnya membatasi pembukaan atau penyuntingan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

### Apakah 'Read-Only recommended' dapat digabungkan dengan watermark untuk lebih menghalangi penyuntingan?

Ya. Rekomendasi dapat dipasangkan dengan [watermarks](/slides/id/net/watermark/) sebagai pencegahan visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama-sama.

### Apakah makro atau alat eksternal masih dapat memodifikasi file saat rekomendasi diaktifkan?

Ya. Rekomendasi tidak memblokir perubahan secara programatik. Untuk mencegah penyuntingan otomatis, gunakan [kata sandi dan enkripsi](/slides/id/net/password-protected-presentation/).

### Bagaimana 'Read-Only recommended' berhubungan dengan flag 'IsEncrypted' dan 'IsWriteProtected'?

Mereka adalah sinyal yang berbeda. 'Read-Only recommended' adalah prompt yang lembut dan opsional; [IsWriteProtected](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/iswriteprotected/) dan [IsEncrypted](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/isencrypted/) menunjukkan pembatasan tulis atau baca yang sebenarnya yang bergantung pada kata sandi atau enkripsi.