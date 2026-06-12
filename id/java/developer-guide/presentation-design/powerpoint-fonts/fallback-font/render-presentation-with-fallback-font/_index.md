---
title: Render Presentasi dengan Font Fallback di Java
linktitle: Render Presentasi
type: docs
weight: 30
url: /id/java/render-presentation-with-fallback-font/
keywords:
- font fallback
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Render presentasi dengan font fallback di Aspose.Slides untuk Java – menjaga konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode Java langkah demi langkah."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font fallback. Artikel ini menunjukkan cara membuat koleksi aturan font fallback, memodifikasi aturannya dengan menghapus atau menambahkan font fallback, dan menetapkan koleksi tersebut menggunakan metode `FontsManager.setFontFallBackRulesCollection`.

Setelah koleksi aturan font fallback ditetapkan ke `FontsManager` presentasi, aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar PNG.

## **Render Slide Menggunakan Aturan Font Fallback**

1. Kami [membuat koleksi aturan font fallback](/slides/id/java/create-fallback-fonts-collection/).
1. [Hapus](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) sebuah aturan font fallback dan [addFallBackFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke aturan lain.
1. Tetapkan koleksi aturan ke metode [getFontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) method.
1. Dengan metode [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#save-java.lang.String-int-) kita dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font fallback ditetapkan ke [FontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsManager), aturan-aturan ini diterapkan selama semua operasi pada presentasi: menyimpan, merender, mengonversi, dll.

```java
// Buat instance baru dari koleksi aturan
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// buat sejumlah aturan
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
    fallBackRule.remove("Tahoma");

    // Dan memperbarui aturan untuk rentang yang ditentukan
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Juga kita dapat menghapus aturan yang ada dari daftar
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Menetapkan daftar aturan yang dipersiapkan untuk digunakan
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpannya ke JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Simpan gambar ke disk dalam format JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Baca lebih lanjut tentang cara [Mengonversi PPT dan PPTX ke JPG di Java](/slides/id/java/convert-powerpoint-to-jpg/).
{{% /alert %}}