---
title: Menambahkan Tanda Tangan Digital ke Presentasi di Java
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/java/digital-signature-in-powerpoint/
keywords:
- tanda tangan digital
- sertifikat digital
- otoritas sertifikat
- sertifikat PFX
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara menandatangani secara digital file PowerPoint & OpenDocument dengan Aspose.Slides untuk Java. Amankan slide Anda dalam hitungan detik dengan contoh kode yang jelas."
---
## **Pengantar**

**Sertifikat digital** digunakan untuk membuat presentasi PowerPoint yang dilindungi kata sandi, ditandai sebagai dibuat oleh organisasi atau orang tertentu. Sertifikat digital dapat diperoleh dengan menghubungi organisasi yang berwenang — otoritas sertifikat. Setelah menginstal sertifikat digital ke dalam sistem, dapat digunakan untuk menambahkan tanda tangan digital ke presentasi melalui File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Presentasi dapat berisi lebih dari satu tanda tangan digital. Setelah tanda tangan digital ditambahkan ke presentasi, pesan khusus akan muncul di PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Untuk menandatangani presentasi atau memeriksa keaslian tanda tangan presentasi, **Aspose.Slides API** menyediakan antarmuka [**IDigitalSignature**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IDigitalSignature), antarmuka [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IDigitalSignatureCollection) dan metode [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . Saat ini, tanda tangan digital hanya didukung untuk format PPTX.

## **Menambahkan Tanda Tangan Digital dari Sertifikat PFX**

Contoh kode di bawah ini menunjukkan cara menambahkan tanda tangan digital dari sertifikat PFX:

1. Buka file PFX dan berikan kata sandi PFX ke objek [**DigitalSignature**](https://reference.aspose.com/slides/id/java/com.aspose.slides/DigitalSignature).
2. Tambahkan tanda tangan yang dibuat ke objek presentasi.

```java
// Membuka file presentasi
// Membuat objek DigitalSignature dengan file PFX dan kata sandi PFX 
// Komentar tanda tangan digital baru
// Menambahkan tanda tangan digital ke presentasi
// Menyimpan presentasi
Presentation pres = new Presentation();
try {
    // Create DigitalSignature object with PFX file and PFX password 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Comment new digital signature
    signature.setComments("Aspose.Slides digital signing test.");

    // Add digital signature to presentation
    pres.getDigitalSignatures().add(signature);

    // Save presentation
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Sekarang dimungkinkan untuk memeriksa apakah presentasi telah ditandatangani secara digital dan tidak dimodifikasi:

```java
// Buka presentasi
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Periksa apakah semua tanda tangan digital valid
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menghapus tanda tangan yang ada dari file?**

Ya. Koleksi tanda tangan digital mendukung [menghapus item individu](https://reference.aspose.com/slides/id/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) dan [mengosongkannya sepenuhnya](https://reference.aspose.com/slides/id/java/com.aspose.slides/digitalsignaturecollection/#clear--); setelah Anda menyimpan file, presentasi tidak akan memiliki tanda tangan.

**Apakah file menjadi "read-only" setelah ditandatangani?**

Tidak. Tanda tangan mempertahankan integritas dan kepenulisan tetapi tidak memblokir pengeditan. Untuk membatasi pengeditan, gabungkan dengan ["Read-only" atau kata sandi](/slides/id/java/password-protected-presentation/).

**Apakah tanda tangan akan ditampilkan dengan benar di versi PowerPoint yang berbeda?**

Tanda tangan dibuat untuk kontainer OOXML (PPTX). Versi PowerPoint modern yang mendukung tanda tangan OOXML menampilkan status tanda tangan tersebut dengan benar.