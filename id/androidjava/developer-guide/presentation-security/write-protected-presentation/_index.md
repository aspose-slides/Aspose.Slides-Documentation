---
title: Presentasi dengan Perlindungan Penulisan pada Android
linktitle: Perlindungan Penulisan
type: docs
weight: 25
url: /id/androidjava/write-protected-presentation/
keywords:
- perlindungan penulisan
- perlindungan penulisan PowerPoint
- kata sandi untuk mengubah
- batasi pengeditan presentasi
- hapus perlindungan penulisan
- validasi kata sandi modifikasi
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Atur, deteksi, validasi, dan hapus kata sandi perlindungan penulisan pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk Android melalui Java."
---
## **Pendahuluan**

Kata sandi perlindungan penulisan membatasi modifikasi presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi penulisan tanpa kata sandi. Tergantung pada aplikasi, mereka mungkin juga dapat mengedit konten dan menyimpannya dengan nama yang berbeda, sehingga perlindungan penulisan tidak boleh dianggap sebagai mekanisme kerahasiaan.

Sebaliknya, kata sandi pembuka memiliki tujuan yang berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi presentasi atau memvalidasi kata sandi pembuka, lihat [Presentasi yang Dilindungi Kata Sandi](/slides/id/androidjava/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; saat menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang sesuai.

## **Atur Perlindungan Penulisan pada Presentasi**

Gunakan [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) untuk menetapkan kata sandi yang mengizinkan modifikasi presentasi. Menyimpan presentasi akan mempertahankan pengaturan perlindungan.

Contoh berikut mengatur perlindungan penulisan pada presentasi PPTX:

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

## **Muat Presentasi yang Dilindungi Penulisan**

Karena perlindungan penulisan tidak mengenkripsi konten presentasi, tidak diperlukan kata sandi untuk memuat presentasi. Kata sandi hanya relevan saat memvalidasi otorisasi untuk memodifikasi presentasi yang dilindungi.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Jangan mengirimkan kata sandi perlindungan penulisan ke [ILoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Metode tersebut menerima kata sandi pembuka untuk konten yang terenkripsi. Jika sebuah presentasi memiliki kedua jenis perlindungan, berikan kata sandi pembuka untuk memuatnya dan tangani kata sandi perlindungan penulisan secara terpisah.

## **Hapus Perlindungan Penulisan dari Presentasi**

Gunakan [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) untuk menghapus pembatasan modifikasi, lalu simpan presentasi.

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

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) lengkap, panggil [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) dan periksa [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metode ini menggunakan [NullableBool](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/nullablebool/) dan mengembalikan `NullableBool.True` ketika perlindungan penulisan terdeteksi.

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

Overload stream dari [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) menyediakan informasi yang sama untuk presentasi yang diberikan sebagai aliran.

## **Validasi Kata Sandi Perlindungan Penulisan**

Gunakan [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) untuk memvalidasi kata sandi modifikasi tanpa memuat presentasi lengkap. Periksa [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) terlebih dahulu agar aplikasi meminta atau memvalidasi kata sandi hanya ketika perlindungan penulisan ada.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) memvalidasi hanya kata sandi perlindungan penulisan. Ia tidak memvalidasi kata sandi pembuka atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) memvalidasi hanya kata sandi pembuka. Jika sebuah presentasi lengkap sudah dimuat, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) menyediakan pemeriksaan perlindungan penulisan yang setara melalui manajer perlindungannya.

Pada aplikasi produksi, jangan mencatat kata sandi atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, dan simpan kata sandi dalam memori hanya selama diperlukan.

{{% alert color="info" title="Lihat juga" %}}
- [Presentasi yang Dilindungi Kata Sandi](/slides/id/androidjava/password-protected-presentation/)
- [Presentasi Hanya Baca](/slides/id/androidjava/read-only-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apakah perlindungan penulisan mengenkripsi presentasi?**

Tidak. Ia membatasi modifikasi tetapi tetap membuat konten presentasi tersedia untuk dimuat dan dilihat.

**Apakah kata sandi perlindungan penulisan diperlukan untuk membuka presentasi?**

Tidak. Hanya kata sandi pembuka yang diperlukan untuk memuat konten presentasi yang terenkripsi.

**Apakah sebuah presentasi dapat memiliki kata sandi pembuka dan kata sandi perlindungan penulisan sekaligus?**

Ya. Berikan kata sandi pembuka melalui opsi pemuatan untuk membuka presentasi yang terenkripsi, dan validasi kata sandi perlindungan penulisan secara terpisah ketika otorisasi modifikasi diperlukan.