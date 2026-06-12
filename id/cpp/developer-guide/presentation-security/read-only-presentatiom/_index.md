---
title: Simpan Presentasi dalam Mode Read-Only Menggunakan C++
linktitle: Presentasi Read-Only
type: docs
weight: 30
url: /id/cpp/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah pengeditan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode read-only dengan Aspose.Slides untuk C++, menyediakan pratinjau slide yang akurat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah pengeditan tidak sengaja dan menjaga isi presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk ini: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini untuk dibuka sebagai read-only.*

Rekomendasi Read-Only adalah pencegah sederhana namun efektif yang menghalangi pengeditan karena pengguna harus melakukan suatu tindakan untuk menghilangkannya sebelum mereka diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin memberi tahu mereka tentang hal ini dengan cara yang sopan, maka rekomendasi Read-Only mungkin menjadi pilihan yang baik bagi Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Menerapkan Mode Read-Only**

Aspose.Slides untuk C++ memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) akan melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** di C++ menggunakan Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Catatan**: Rekomendasi **Read-Only** hanya dimaksudkan untuk menghalangi pengeditan atau menghentikan pengguna membuat perubahan tidak sengaja pada presentasi PowerPoint. Jika seseorang yang berpengalaman—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar‑benar perlu mencegah pengeditan yang tidak sah, Anda lebih baik menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?**

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah untuk diabaikan. [Password protection](/slides/id/cpp/password-protected-presentation/) sebenarnya membatasi pembukaan atau pengeditan dan cocok ketika Anda membutuhkan kontrol keamanan yang nyata.

**Apakah 'Read-Only recommended' dapat digabungkan dengan watermark untuk lebih menghalangi pengeditan?**

Ya. Rekomendasi dapat dipasangkan dengan [watermark](/slides/id/cpp/watermark/) sebagai pencegah visual; keduanya adalah mekanisme terpisah dan bekerja dengan baik bersama.

**Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?**

Ya. Rekomendasi tidak memblokir perubahan secara programatis. Untuk mencegah pengeditan otomatis, gunakan [kata sandi dan enkripsi](/slides/id/cpp/password-protected-presentation/).

**Bagaimana 'Read-Only recommended' berhubungan dengan flag 'is encrypted' dan 'is write protected'?**

Mereka merupakan sinyal yang berbeda. 'Read-Only recommended' adalah prompt lembut dan opsional; [get_IsWriteProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) dan [get_IsEncrypted](https://reference.aspose.com/slides/id/cpp/aspose.slides/protectionmanager/get_isencrypted/) menunjukkan pembatasan menulis atau membaca yang sebenarnya yang bergantung pada kata sandi atau enkripsi.