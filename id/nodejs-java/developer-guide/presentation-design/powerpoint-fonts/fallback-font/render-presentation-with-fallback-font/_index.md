---
title: Render Presentasi dengan Fallback Font dalam JavaScript
linktitle: Render Presentasi
type: docs
weight: 30
url: /id/nodejs-java/render-presentation-with-fallback-font/
keywords:
- fallback font
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Render presentasi dengan fallback font di Aspose.Slides untuk Node.js - menjaga konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode JavaScript langkah demi langkah."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan fallback font. Artikel ini menunjukkan cara membuat koleksi aturan fallback font, memodifikasi aturannya dengan menghapus atau menambahkan fallback font, dan menetapkan koleksi tersebut menggunakan metode `FontsManager.setFontFallBackRulesCollection`.

Setelah koleksi aturan fallback font ditetapkan ke `FontsManager` presentasi, aturan-aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang telah dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar PNG.

## **Render Slide Menggunakan Aturan Fallback Font**

Contoh berikut mencakup langkah-langkah ini:

1. Kami [membuat koleksi aturan fallback font](/slides/id/nodejs-java/create-fallback-fonts-collection/).
2. [Hapus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) aturan fallback font dan [addFallBackFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke aturan lain.
3. Setel koleksi aturan ke metode [getFontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metode.
4. Dengan metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) kami dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan fallback font ditetapkan ke [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontsManager), aturan-aturan ini diterapkan selama operasi apa pun pada presentasi: menyimpan, merender, mengonversi, dll.

```javascript
// Buat instance baru dari koleksi aturan
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// buat sejumlah aturan
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
    fallBackRule.remove("Tahoma");
    // Dan memperbarui aturan untuk rentang yang ditentukan
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Kita juga dapat menghapus aturan yang ada dari daftar
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Menetapkan daftar aturan yang telah dipersiapkan untuk digunakan
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpannya ke JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Simpan gambar ke disk dalam format JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Baca lebih lanjut tentang cara [Mengonversi PPT dan PPTX ke JPG dalam JavaScript](/slides/id/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}