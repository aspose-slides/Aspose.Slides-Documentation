---
title: Merender Presentasi dengan Font Fallback di .NET
linktitle: Merender Presentasi
type: docs
weight: 30
url: /id/net/render-presentation-with-fallback-font/
keywords:
- font fallback
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Merender presentasi dengan font fallback di Aspose.Slides untuk .NET – menjaga konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode C# langkah demi langkah."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font fallback. Artikel ini menunjukkan cara membuat koleksi aturan font fallback, memodifikasi aturannya dengan menghapus atau menambahkan font fallback, dan menetapkan koleksi tersebut ke properti `FontsManager.FontFallBackRulesCollection`.

Setelah koleksi aturan font fallback ditetapkan ke `FontsManager` presentasi, aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar PNG.

## **Merender Slide Menggunakan Aturan Font Fallback**

Contoh berikut mencakup langkah-langkah ini:

1. Kami [membuat koleksi aturan font fallback](/slides/id/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrule/methods/remove) sebuah aturan font fallback dan [AddFallBackFonts()](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ke aturan lain.
1. Tetapkan koleksi aturan ke properti [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Dengan metode [Presentation.Save()](https://reference.aspose.com/slides/id/net/aspose.slides.presentation/save/methods/4) kami dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font fallback ditetapkan ke FontsManager, aturan ini diterapkan selama operasi apa pun pada presentasi: menyimpan, merender, mengonversi, dll.

```c#
// Buat instance baru dari koleksi aturan
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
	fallBackRule.Remove("Tahoma");

	// Dan memperbarui aturan untuk rentang yang ditentukan
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//	Kita juga dapat menghapus aturan yang ada dari daftar
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Menetapkan daftar aturan yang telah disiapkan untuk digunakan
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpannya ke PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="primary" %}} 
Baca lebih lanjut tentang [Simpan dan Konversi dalam Presentasi](/slides/id/net/convert-powerpoint-to-png/).
{{% /alert %}}