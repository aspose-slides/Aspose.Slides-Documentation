---
title: Simpan Presentasi dalam Mode Baca Saja Menggunakan C++
linktitle: Presentasi Baca Saja
type: docs
weight: 30
url: /id/cpp/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah penyuntingan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode baca saja dengan Aspose.Slides untuk C++, memberikan pratinjau slide yang tepat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Baca Saja ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah penyuntingan tidak sengaja dan menjaga konten presentasi tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *To prevent accidental changes, the author has set this file to open as read-only.*

Rekomendasi **Read-Only** adalah pencegahan sederhana namun efektif yang menghalangi penyuntingan karena pengguna harus melakukan suatu tindakan untuk menghapusnya sebelum mereka dapat menyunting presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka secara sopan, maka rekomendasi **Read-Only** dapat menjadi opsi yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Baca Saja**

Aspose.Slides for C++ memungkinkan Anda menetapkan sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) akan melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** di C++ menggunakan Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Catatan**: Rekomendasi **Read-Only** dimaksudkan hanya untuk menghalangi penyuntingan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang termotivasi—yang tahu apa yang mereka lakukan—memutuskan untuk menyunting presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Baca Saja. Jika Anda benar‑benar perlu mencegah penyuntingan tidak sah, Anda sebaiknya menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **Tanya Jawab**

### Bagaimana perbedaan antara 'Read-Only recommended' dengan perlindungan kata sandi penuh?

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode baca saja dan mudah diabaikan. [Perlindungan kata sandi](/slides/id/cpp/password-protected-presentation/) sebenarnya membatasi pembukaan atau penyuntingan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

### Apakah 'Read-Only recommended' dapat digabungkan dengan watermark untuk lebih menghalangi penyuntingan?

Ya. Rekomendasi tersebut dapat dipasangkan dengan [watermark](/slides/id/cpp/watermark/) sebagai pencegah visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama.

### Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?

Ya. Rekomendasi tidak memblokir perubahan secara programatik. Untuk mencegah penyuntingan otomatis, gunakan [kata sandi dan enkripsi](/slides/id/cpp/password-protected-presentation/).

### Bagaimana 'Read-Only recommended' terkait dengan flag 'is encrypted' dan 'is write protected'?

Mereka adalah sinyal yang berbeda. 'Read-Only recommended' adalah prompt lunak dan opsional; [get_IsWriteProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) dan [get_IsEncrypted](https://reference.aspose.com/slides/id/cpp/aspose.slides/protectionmanager/get_isencrypted/) menunjukkan pembatasan tulis atau baca nyata yang bergantung pada kata sandi atau enkripsi.