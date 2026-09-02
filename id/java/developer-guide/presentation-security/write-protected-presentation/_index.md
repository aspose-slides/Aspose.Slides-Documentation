---
title: Presentasi dengan Proteksi Tulis di Java
linktitle: Proteksi Tulis
type: docs
weight: 25
url: /id/java/write-protected-presentation/
keywords:
- proteksi tulis
- proteksi tulis PowerPoint
- kata sandi untuk memodifikasi
- batasi penyuntingan presentasi
- hapus proteksi tulis
- validasi kata sandi modifikasi
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Atur, deteksi, validasi, dan hapus kata sandi proteksi tulis pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk Java."
---
## **Pendahuluan**

Kata sandi proteksi-tulis membatasi modifikasi presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi proteksi tulis tanpa kata sandi. Bergantung pada aplikasi, mereka juga mungkin dapat mengedit konten dan menyimpannya dengan nama yang berbeda, jadi proteksi tulis tidak boleh dianggap sebagai mekanisme kerahasiaan.

Kata sandi pembuka memiliki tujuan yang berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi presentasi atau memvalidasi kata sandi pembuka, lihat [Password-Protect Presentations](/slides/id/java/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; saat menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang sesuai.

## **Atur Proteksi Tulis pada Presentasi**

Gunakan [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) untuk menetapkan kata sandi untuk memodifikasi presentasi. Menyimpan presentasi akan mempertahankan pengaturan proteksi.

Contoh berikut mengatur proteksi tulis pada presentasi PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Muat Presentasi yang Dilindungi Proteksi Tulis**

Karena proteksi tulis tidak mengenkripsi konten presentasi, tidak diperlukan kata sandi untuk memuat presentasi. Kata sandi hanya relevan ketika memvalidasi otorisasi untuk memodifikasi presentasi yang dilindungi.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Jangan mengirimkan kata sandi proteksi-tulis ke [ILoadOptions.setPassword](https://reference.aspose.com/slides/id/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Metode itu menerima kata sandi pembuka untuk konten yang dienkripsi. Jika sebuah presentasi memiliki kedua jenis proteksi, berikan kata sandi pembuka untuk memuatnya dan tangani kata sandi proteksi-tulis secara terpisah.

## **Hapus Proteksi Tulis dari Presentasi**

Gunakan [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) untuk menghapus pembatasan modifikasi, lalu simpan presentasi.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Periksa Apakah Presentasi Dilindungi Proteksi Tulis**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) lengkap, panggil [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) dan periksa [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metode ini menggunakan [NullableBool](https://reference.aspose.com/slides/id/java/com.aspose.slides/nullablebool/) dan mengembalikan `NullableBool.True` ketika proteksi tulis terdeteksi.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Overload berbasis stream dari [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) memberikan informasi yang sama untuk presentasi yang disediakan sebagai stream.

## **Validasi Kata Sandi Proteksi Tulis**

Gunakan [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) untuk memvalidasi kata sandi modifikasi tanpa memuat presentasi lengkap. Periksa [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) terlebih dahulu sehingga aplikasi meminta atau memvalidasi kata sandi hanya ketika proteksi tulis hadir.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) hanya memvalidasi kata sandi proteksi tulis. Ia tidak memvalidasi kata sandi pembuka atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) hanya memvalidasi kata sandi pembuka. Jika sebuah presentasi lengkap sudah dimuat, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) menyediakan pemeriksaan proteksi tulis yang setara melalui manajer proteksinya.

Dalam aplikasi produksi, jangan mencatat kata sandi atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak diperlukan, dan pertahankan kata sandi dalam memori hanya selama diperlukan.

{{% alert color="info" title="Lihat juga" %}}
- [Presentasi dengan Proteksi Kata Sandi](/slides/id/java/password-protected-presentation/)
- [Presentasi Hanya Baca](/slides/id/java/read-only-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apakah proteksi tulis mengenkripsi presentasi?**

Tidak. Ia membatasi modifikasi tetapi membiarkan konten presentasi tersedia untuk dimuat dan dilihat.

**Apakah kata sandi proteksi tulis diperlukan untuk membuka presentasi?**

Tidak. Hanya kata sandi pembuka yang diperlukan untuk memuat konten presentasi yang dienkripsi.

**Bisakah sebuah presentasi memiliki kata sandi pembuka dan kata sandi proteksi tulis sekaligus?**

Ya. Berikan kata sandi pembuka melalui opsi pemuatan untuk membuka presentasi yang dienkripsi, dan validasi kata sandi proteksi tulis secara terpisah ketika otorisasi modifikasi diperlukan.