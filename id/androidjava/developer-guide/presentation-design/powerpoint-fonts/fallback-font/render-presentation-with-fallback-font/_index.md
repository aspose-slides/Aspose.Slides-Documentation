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
description: "Render presentasi dengan font fallback di Aspose.Slides untuk Android – pertahankan konsistensi teks di PPT, PPTX, dan ODP dengan contoh kode Java langkah demi langkah."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font fallback. Artikel ini menunjukkan cara membuat koleksi aturan font fallback, memodifikasi aturannya dengan menghapus atau menambahkan font fallback, dan menetapkan koleksi tersebut menggunakan metode `FontsManager.setFontFallBackRulesCollection`.

Setelah koleksi aturan font fallback ditetapkan ke `FontsManager` presentasi, aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar JPEG.

## **Render Slide Menggunakan Aturan Font Fallback**

Contoh berikut mencakup langkah‑langkah ini:

1. Kami [membuat koleksi aturan font fallback](/slides/id/androidjava/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) sebuah aturan font fallback dan [addFallBackFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke aturan lain.
1. Tetapkan koleksi aturan ke [getFontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metode.
1. Dengan metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) kita dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font fallback ditetapkan ke [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager), aturan ini diterapkan selama operasi apa pun pada presentasi: menyimpan, merender, mengonversi, dll.

```java
import com.aspose.slides.*;

// Create new instance of a rules collection
// B ​​uat instance baru dari koleksi aturan
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Trying to remove FallBack font "Tahoma" from loaded rules
    // Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
    fallBackRule.remove("Tahoma");

    //And to update of rules for specified range
    // Dan memperbarui aturan untuk rentang yang ditentukan
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list, keeping at least one rule to render with
// Kita juga dapat menghapus aturan yang ada dari daftar, dengan mempertahankan setidaknya satu aturan untuk merender
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Assigning a prepared rules list for using
    // Menetapkan daftar aturan yang dipersiapkan untuk digunakan
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
    // Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpannya ke JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Save the image to disk in JPEG format
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

{{% alert color="info" %}} 
Baca lebih lanjut tentang [Convert PPT and PPTX to JPG on Android](/slides/id/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}