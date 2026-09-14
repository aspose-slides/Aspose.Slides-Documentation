---
title: Simpan Presentasi dalam Mode Baca Saja Menggunakan Python
linktitle: Presentasi Baca Saja
type: docs
weight: 30
url: /id/python-java/read-only-presentation/
keywords:
- baca saja
- melindungi presentasi
- mencegah penyuntingan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Muat dan simpan file PowerPoint (PPT, PPTX) dalam mode baca saja dengan Aspose.Slides untuk Python via Java, menawarkan preview slide yang tepat tanpa mengubah presentasi Anda."
---
## **Pendahuluan**

Di PowerPoint 2019, Microsoft memperkenalkan pengaturan **Always Open Read-Only** sebagai salah satu opsi yang dapat digunakan pengguna untuk melindungi presentasi mereka. Anda mungkin ingin menggunakan pengaturan Read-Only ini untuk melindungi sebuah presentasi ketika:

- Anda ingin mencegah penyuntingan tidak sengaja dan menjaga konten presentasi tetap aman. 
- Anda ingin memberi tahu orang bahwa presentasi yang Anda berikan adalah versi final. 

Setelah Anda memilih opsi **Always Open Read-Only** untuk sebuah presentasi, ketika pengguna membuka presentasi tersebut, mereka akan melihat rekomendasi **Read-Only** dan mungkin melihat pesan dalam bentuk berikut: *Untuk mencegah perubahan tidak sengaja, penulis telah mengatur file ini agar dibuka sebagai read-only.*

Rekomendasi Read-Only adalah cara sederhana namun efektif untuk menghalangi penyuntingan karena pengguna harus melakukan suatu tindakan untuk menghapusnya sebelum diizinkan mengedit presentasi. Jika Anda tidak ingin pengguna membuat perubahan pada presentasi dan ingin menyampaikannya dengan cara yang sopan, maka rekomendasi Read-Only dapat menjadi opsi yang baik untuk Anda. 

> Jika sebuah presentasi dengan perlindungan **Read-Only** dibuka di aplikasi Microsoft PowerPoint yang lebih lama—yang tidak mendukung fungsi yang baru diperkenalkan—rekomendasi **Read-Only** akan diabaikan (presentasi dibuka secara normal).

## **Terapkan Mode Baca Saja**

Aspose.Slides for Python via Java memungkinkan Anda mengatur sebuah presentasi menjadi **Read-Only**, yang berarti pengguna (setelah mereka membuka presentasi) akan melihat rekomendasi **Read-Only**. Kode contoh ini menunjukkan cara mengatur sebuah presentasi menjadi **Read-Only** dalam Python menggunakan Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Rekomendasi **Read-Only** memang dimaksudkan untuk menghalangi penyuntingan atau menghentikan pengguna membuat perubahan tidak sengaja pada sebuah presentasi PowerPoint. Jika seseorang yang berpengalaman—yang tahu apa yang ia lakukan—memutuskan untuk menyunting presentasi Anda, ia dapat dengan mudah menghapus pengaturan Read-Only. Jika Anda benar‑benar perlu mencegah penyuntingan tidak sah, Anda sebaiknya menggunakan [perlindungan yang lebih ketat yang melibatkan enkripsi dan kata sandi](/slides/id/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **Tanya Jawab**

**Bagaimana perbedaan antara ‘Read-Only recommended’ dengan perlindungan kata sandi penuh?**  
‘Read-Only recommended’ hanya menampilkan saran untuk membuka file dalam mode read-only dan mudah diabaikan. [Perlindungan kata sandi](/slides/id/python-java/password-protected-presentation/) sebenarnya membatasi pembukaan atau penyuntingan dan cocok ketika Anda memerlukan kontrol keamanan yang nyata.

**Apakah ‘Read-Only recommended’ dapat digabungkan dengan watermark untuk lebih menghalangi penyuntingan?**  
Ya. Rekomendasi dapat dipasangkan dengan [watermark](/slides/id/python-java/watermark/) sebagai deterrent visual; keduanya merupakan mekanisme terpisah dan bekerja baik bersama.

**Apakah macro atau alat eksternal masih dapat memodifikasi file ketika rekomendasi diaktifkan?**  
Ya. Rekomendasi tidak memblokir perubahan programatik. Untuk mencegah penyuntingan otomatis, gunakan [kata sandi dan enkripsi](/slides/id/python-java/password-protected-presentation/).

**Bagaimana ‘Read-Only recommended’ berhubungan dengan metode [isEncrypted](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#isEncrypted) dan [isWriteProtected](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**  
Mereka adalah sinyal yang berbeda. ‘Read-Only recommended’ adalah prompt lunak dan opsional; [isWriteProtected](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#isWriteProtected) dan [isEncrypted](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#isEncrypted) menunjukkan pembatasan tulis atau baca yang sebenarnya yang bergantung pada kata sandi atau enkripsi.