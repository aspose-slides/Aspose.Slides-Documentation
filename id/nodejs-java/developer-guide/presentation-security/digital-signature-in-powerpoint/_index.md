---
title: Menambahkan Tanda Tangan Digital ke Presentasi dalam JavaScript
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/nodejs-java/digital-signature-in-powerpoint/
keywords:
- tanda tangan digital
- sertifikat digital
- otoritas sertifikat
- sertifikat PFX
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menandatangani secara digital file PowerPoint & OpenDocument dengan Aspose.Slides untuk Node.js melalui Java. Amankan slide Anda dalam hitungan detik dengan contoh kode yang jelas."
---
## **Pendahuluan**

**Sertifikat digital** digunakan untuk membuat presentasi PowerPoint yang dilindungi kata sandi, ditandai sebagai dibuat oleh organisasi atau orang tertentu. Sertifikat digital dapat diperoleh dengan menghubungi organisasi yang berwenang – otoritas sertifikat. Setelah menginstal sertifikat digital ke dalam sistem, sertifikat dapat digunakan untuk menambahkan tanda tangan digital ke presentasi melalui File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Presentasi dapat berisi lebih dari satu tanda tangan digital. Setelah tanda tangan digital ditambahkan ke presentasi, pesan khusus akan muncul di PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Untuk menandatangani presentasi atau memeriksa keaslian tanda tangan presentasi, **Aspose.Slides API** menyediakan kelas [**DigitalSignature**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/DigitalSignature), kelas [**DigitalSignatureCollection**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/DigitalSignatureCollection) dan metode [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) . Saat ini, tanda tangan digital hanya didukung untuk format PPTX.

## **Tambahkan Tanda Tangan Digital dari Sertifikat PFX**
Contoh kode di bawah ini menunjukkan cara menambahkan tanda tangan digital dari sertifikat PFX:

1. Buka file PFX dan berikan kata sandi PFX ke objek [**DigitalSignature**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/DigitalSignature).
2. Tambahkan tanda tangan yang dibuat ke objek presentasi.

```javascript
// Membuka file presentasi
var pres = new aspose.slides.Presentation();
try {
    // Membuat objek DigitalSignature dengan file PFX dan kata sandi PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Komentar tanda tangan digital baru
    signature.setComments("Aspose.Slides digital signing test.");
    // Tambahkan tanda tangan digital ke presentasi
    pres.getDigitalSignatures().add(signature);
    // Simpan presentasi
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Sekarang dimungkinkan untuk memeriksa apakah presentasi telah ditandatangani secara digital dan belum dimodifikasi:

```javascript
// Buka presentasi
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Periksa apakah semua tanda tangan digital valid
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menghapus tanda tangan yang ada dari file?**

Ya. Koleksi tanda tangan digital mendukung [removing individual items](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) dan [clearing it entirely](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); setelah Anda menyimpan file, presentasi tidak akan memiliki tanda tangan.

**Apakah file menjadi “read-only” setelah ditandatangani?**

Tidak. Tanda tangan mempertahankan integritas dan kepenulisan tetapi tidak menghalangi penyuntingan. Untuk membatasi penyuntingan, gabungkan dengan ["Read-only" or a password](/slides/id/nodejs-java/password-protected-presentation/).

**Apakah tanda tangan akan ditampilkan dengan benar di versi PowerPoint yang berbeda?**

Tanda tangan dibuat untuk kontainer OOXML (PPTX). Versi PowerPoint modern yang mendukung tanda tangan OOXML menampilkan status tanda tangan tersebut dengan benar.