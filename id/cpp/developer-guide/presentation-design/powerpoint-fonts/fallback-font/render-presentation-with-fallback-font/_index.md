---
title: Render Presentasi dengan Font Fallback di C++
linktitle: Render Presentasi
type: docs
weight: 30
url: /id/cpp/render-presentation-with-fallback-font/
keywords:
- font fallback
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Render presentasi dengan font fallback di Aspose.Slides untuk C++ – menjaga konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode C++ langkah demi langkah."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font fallback. Artikel ini menunjukkan cara membuat koleksi aturan font fallback, memodifikasi aturannya dengan menghapus atau menambahkan font fallback, dan menetapkan koleksi tersebut menggunakan metode `FontsManager::set_FontFallBackRulesCollection`.

Setelah koleksi aturan font fallback ditetapkan ke `FontsManager` presentasi, aturan tersebut diterapkan selama operasi seperti penyimpanan, perenderan, dan konversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar PNG.

## **Render Slide Menggunakan Aturan Font Fallback**

Contoh berikut mencakup langkah-langkah ini:

1. Kami [membuat koleksi aturan font fallback](/slides/id/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/remove/) sebuah aturan font fallback dan [AddFallBackFonts()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) menambah font fallback ke aturan lain.
1. Melewatkan koleksi aturan ke metode [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Dengan metode [Presentation::Save()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) kami dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font fallback diatur ke FontsManager, aturan-aturan ini diterapkan selama operasi apa pun pada presentasi: simpan, render, konversi, dll.

``` cpp
// Membuat instance baru dari koleksi aturan
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Membuat sejumlah aturan
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
	fallBackRule->Remove(u"Tahoma");

	// Dan memperbarui aturan untuk rentang yang ditentukan
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Juga kita dapat menghapus aturan yang ada dari daftar
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Menetapkan daftar aturan yang telah dipersiapkan untuk digunakan
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpannya ke PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Baca lebih lanjut tentang cara [Mengonversi Slide PowerPoint ke PNG dalam C++](/slides/id/cpp/convert-powerpoint-to-png/).
{{% /alert %}}