---
title: Simpan Presentasi dalam Mode Read-Only Menggunakan Python
linktitle: Presentasi Read-Only
type: docs
weight: 30
url: /id/python-net/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah pengeditan
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode read-only dengan Aspose.Slides untuk Python via .NET, menawarkan pratinjau slide yang akurat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika

- Anda ingin mencegah pengeditan tidak sengaja dan menjaga konten presentasi Anda tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan merupakan versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, saat pengguna membuka presentasi, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini untuk dibuka sebagai read-only.*

Rekomendasi Read-Only adalah pencegah sederhana namun efektif yang menghambat pengeditan karena pengguna harus melakukan tindakan untuk menghilangkannya sebelum diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin menyampaikan hal ini secara sopan, maka rekomendasi Read-Only dapat menjadi pilihan yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Read-Only**

Aspose.Slides for Python via .NET memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam Python menggunakan Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Catatan**: Rekomendasi **Read-Only** semata-mata dimaksudkan untuk menghambat pengeditan atau mencegah pengguna melakukan perubahan tidak sengaja pada presentasi PowerPoint. Jika seorang yang termotivasi—yang tahu apa yang mereka lakukan—memutuskan untuk mengedit presentasi Anda, mereka dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar-benar perlu mencegah pengeditan tidak sah, Anda lebih baik menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](https://docs.aspose.com/slides/id/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Bagaimana 'Read-Only recommended' berbeda dari perlindungan kata sandi penuh?**

'Read-Only recommended' hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah diabaikan. [Proteksi kata sandi](/slides/id/python-net/password-protected-presentation/) sebenarnya membatasi pembukaan atau pengeditan dan cocok ketika Anda memerlukan kontrol keamanan yang sebenarnya.

**Apakah 'Read-Only recommended' dapat digabungkan dengan watermark untuk lebih menghambat pengeditan?**

Ya. Rekomendasi tersebut dapat dipasangkan dengan [watermark](/slides/id/python-net/watermark/) sebagai pencegah visual; keduanya merupakan mekanisme terpisah dan bekerja dengan baik bersama-sama.

**Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?**

Ya. Rekomendasi tidak memblokir perubahan secara programatik. Untuk mencegah pengeditan otomatis, gunakan [kata sandi dan enkripsi](/slides/id/python-net/password-protected-presentation/).

**Bagaimana 'Read-Only recommended' berhubungan dengan flag 'is_encrypted' dan 'is_write_protected'?**

Mereka adalah sinyal yang berbeda. 'Read-Only recommended' adalah prompt yang lembut dan opsional; [is_write_protected](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/is_write_protected/) dan [is_encrypted](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/is_encrypted/) menunjukkan pembatasan penulisan atau pembacaan yang sebenarnya yang bergantung pada kata sandi atau enkripsi.