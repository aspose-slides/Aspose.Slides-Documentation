---
title: Render Presentasi dengan Font Fallback di Android
linktitle: Render Presentasi
type: docs
weight: 30
url: /id/androidjava/render-presentation-with-fallback-font/
keywords:
- font fallback
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Render presentasi dengan font fallback di Aspose.Slides untuk Android – jaga konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode Java langkah demi langkah."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font fallback. Artikel ini menunjukkan cara membuat koleksi aturan font fallback, memodifikasi aturannya dengan menghapus atau menambahkan font fallback, dan menetapkan koleksi tersebut menggunakan metode `FontsManager.setFontFallBackRulesCollection`.

Setelah koleksi aturan font fallback ditetapkan ke `FontsManager` presentasi, aturan-aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar PNG.

## **Render Slide Menggunakan Aturan Font Fallback**

Contoh berikut mencakup langkah-langkah berikut:

1. Kami [membuat koleksi aturan font fallback](/slides/id/androidjava/create-fallback-fonts-collection/).
2. [Hapus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) aturan font fallback dan [addFallBackFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke aturan lain.
3. Tetapkan koleksi aturan ke metode [getFontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
4. Dengan metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) kita dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font fallback ditetapkan ke [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager), aturan-aturan tersebut diterapkan selama operasi apa pun pada presentasi: menyimpan, merender, mengonversi, dll.

```java
// Buat instance baru dari koleksi aturan
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
    fallBackRule.remove("Tahoma");

    //Dan memperbarui aturan untuk rentang yang ditentukan
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Kita juga dapat menghapus aturan yang ada dari daftar
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Menetapkan daftar aturan yang telah disiapkan untuk digunakan
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Save the image to disk in JPEG format
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
Baca lebih lanjut tentang [Konversi PPT dan PPTX ke JPG di Android](/slides/id/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}