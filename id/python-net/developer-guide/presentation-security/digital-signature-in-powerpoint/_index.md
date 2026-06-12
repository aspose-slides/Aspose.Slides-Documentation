---
title: Menambahkan Tanda Tangan Digital ke Presentasi dengan Python
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/python-net/digital-signature-in-powerpoint/
keywords:
- tanda tangan digital
- sertifikat digital
- otoritas sertifikat
- sertifikat PFX
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menandatangani secara digital file PowerPoint & OpenDocument dengan Aspose.Slides untuk Python via .NET. Amankan slide Anda dalam hitungan detik dengan contoh kode yang jelas."
---
## **Pendahuluan**

**Sertifikat digital** digunakan untuk membuat presentasi PowerPoint yang dilindungi password, ditandai sebagai dibuat oleh organisasi atau orang tertentu. Sertifikat digital dapat diperoleh dengan menghubungi organisasi yang berwenang – otoritas sertifikat. Setelah menginstal sertifikat digital ke dalam sistem, dapat digunakan untuk menambahkan tanda tangan digital ke presentasi melalui File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Presentasi dapat berisi lebih dari satu tanda tangan digital. Setelah tanda tangan digital ditambahkan ke presentasi, pesan khusus akan muncul di PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Untuk menandatangani presentasi atau memeriksa keaslian tanda tangan presentasi, **Aspose.Slides API** menyediakan kelas [**DigitalSignature**](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/) , kelas [**DigitalSignatureCollection**](https://reference.aspose.com/slides/id/python-net/aspose.slides/DigitalSignatureCollection/) dan properti [**Presentation.digital_signatures**](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/digital_signatures/) . Saat ini, tanda tangan digital hanya didukung untuk format PPTX.

## **Menambahkan Tanda Tangan Digital dari Sertifikat PFX**

Contoh kode di bawah menunjukkan cara menambahkan tanda tangan digital dari sertifikat PFX:

1. Buka file PFX dan berikan password PFX ke objek [**DigitalSignature**](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/) .
2. Tambahkan tanda tangan yang dibuat ke objek presentasi.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Buat objek DigitalSignature dengan file PFX dan password PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Komentar tanda tangan digital baru
    signature.comments = "Aspose.Slides digital signing test."

    # Tambahkan tanda tangan digital ke presentasi
    pres.digital_signatures.add(signature)

    # simpan presentasi
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Sekarang dimungkinkan untuk memeriksa apakah presentasi telah ditandatangani secara digital dan belum dimodifikasi:

```py
# Buka presentasi
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Periksa apakah semua tanda tangan digital valid
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**Apakah saya dapat menghapus tanda tangan yang ada dari file?**

Ya. Koleksi tanda tangan digital mendukung [menghapus item individual](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/remove_at/) dan [mengosongkannya sepenuhnya](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/clear/) ; setelah Anda menyimpan file, presentasi tidak akan memiliki tanda tangan.

**Apakah file menjadi "read-only" setelah ditandatangani?**

Tidak. Tanda tangan mempertahankan integritas dan kepengarangan tetapi tidak menghalangi perubahan. Untuk membatasi pengeditan, gabungkan dengan ["Read-only" atau password](/slides/id/python-net/password-protected-presentation/).

**Apakah tanda tangan akan ditampilkan dengan benar di versi PowerPoint yang berbeda?**

Tanda tangan dibuat untuk kontainer OOXML (PPTX). Versi PowerPoint modern yang mendukung tanda tangan OOXML menampilkan status tanda tangan tersebut dengan benar.