---
title: Menambahkan Tanda Tangan Digital ke Presentasi dalam C++
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/cpp/digital-signature-in-powerpoint/
keywords:
- tanda tangan digital
- sertifikat digital
- otoritas sertifikat
- sertifikat PFX
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menandatangani secara digital file PowerPoint & OpenDocument dengan Aspose.Slides untuk C++. Amankan slide Anda dalam hitungan detik dengan contoh kode yang jelas."
---
## **Introduction**

**Sertifikat digital** digunakan untuk membuat presentasi PowerPoint yang dilindungi kata sandi, ditandai sebagai dibuat oleh organisasi atau orang tertentu. Sertifikat digital dapat diperoleh dengan menghubungi organisasi yang berwenang – otoritas sertifikat. Setelah menginstal sertifikat digital ke dalam sistem, sertifikat tersebut dapat digunakan untuk menambahkan tanda tangan digital ke presentasi melalui File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Presentasi dapat berisi lebih dari satu tanda tangan digital. Setelah tanda tangan digital ditambahkan ke presentasi, pesan khusus akan muncul di PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Untuk menandatangani presentasi atau memeriksa keaslian tanda tangan presentasi, **Aspose.Slides API** menyediakan [**IDigitalSignature**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_digital_signature) interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_digital_signature_collection) interface, dan [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) method. Saat ini, tanda tangan digital hanya didukung untuk format PPTX.

## **Add a Digital Signature from a PFX Certificate**

Contoh kode di bawah ini menunjukkan cara menambahkan tanda tangan digital dari sertifikat PFX:

1. Buka file PFX dan berikan kata sandi PFX ke [**DigitalSignature**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.digital_signature) object.
1. Tambahkan tanda tangan yang dibuat ke objek presentasi.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Buat objek DigitalSignature dengan file PFX dan kata sandi PFX
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Komentari tanda tangan digital baru
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Tambahkan tanda tangan digital ke presentasi
pres->get_DigitalSignatures()->Add(signature);

// Simpan presentasi
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Sekarang Anda dapat memeriksa apakah presentasi telah ditandatangani secara digital dan belum dimodifikasi:

``` cpp
// Buka presentasi
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Periksa apakah semua tanda tangan digital valid
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Apakah saya dapat menghapus tanda tangan yang ada dari file?**

Ya. Koleksi tanda tangan digital mendukung [menghapus item individual](https://reference.aspose.com/slides/id/cpp/aspose.slides/digitalsignaturecollection/removeat/) dan [mengosongkannya sepenuhnya](https://reference.aspose.com/slides/id/cpp/aspose.slides/digitalsignaturecollection/clear/); setelah Anda menyimpan file, presentasi tidak akan memiliki tanda tangan.

**Apakah file menjadi "read-only" setelah ditandatangani?**

Tidak. Tanda tangan menjaga integritas dan kepengarangan tetapi tidak menghalangi penyuntingan. Untuk membatasi penyuntingan, kombinasikan dengan ["Read-only" atau kata sandi](/slides/id/cpp/password-protected-presentation/).

**Apakah tanda tangan akan ditampilkan dengan benar di versi PowerPoint yang berbeda?**

Tanda tangan dibuat untuk kontainer OOXML (PPTX). Versi PowerPoint modern yang mendukung tanda tangan OOXML menampilkan status tanda tangan tersebut dengan benar.