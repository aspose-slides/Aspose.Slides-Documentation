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

Setelah koleksi aturan font fallback ditetapkan ke `FontsManager` presentasi, aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini mendemonstrasikan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar JPEG.

## **Render Slide Menggunakan Aturan Font Fallback**

Contoh berikut mencakup langkah‑langkah ini:

1. Kami [buat koleksi aturan font fallback](/slides/id/java/create-fallback-fonts-collection/).
2. [Hapus](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) aturan font fallback dan [addFallBackFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke aturan lain.
3. Tetapkan koleksi aturan ke metode [getFontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
4. Dengan metode [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#save-java.lang.String-int-) kami dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font fallback diatur ke [FontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsManager), aturan‑aturan ini diterapkan selama operasi apa pun pada presentasi: menyimpan, merender, mengonversi, dll.

```java
import com.aspose.slides.*;

// Buat instance baru dari koleksi aturan
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// buat sejumlah aturan
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
    fallBackRule.remove("Tahoma");

    //Dan memperbarui aturan untuk rentang yang ditentukan
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Selain itu kita dapat menghapus aturan yang ada dari daftar, sambil mempertahankan setidaknya satu aturan untuk merender
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Menetapkan daftar aturan yang telah disiapkan untuk digunakan
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpannya ke JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Simpan gambar ke disk dalam format JPEG
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
Baca lebih lanjut tentang cara [Mengonversi PPT dan PPTX ke JPG di Java](/slides/id/java/convert-powerpoint-to-jpg/).
{{% /alert %}}