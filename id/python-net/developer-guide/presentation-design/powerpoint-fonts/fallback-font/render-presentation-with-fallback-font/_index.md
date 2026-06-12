---
title: Render Presentasi dengan Font Cadangan di Python
linktitle: Render Presentasi
type: docs
weight: 30
url: /id/python-net/render-presentation-with-fallback-font/
keywords:
- font cadangan
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Render presentasi dengan font cadangan di Aspose.Slides untuk Python via .NET – pertahankan konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode langkah demi langkah."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font cadangan. Artikel ini menunjukkan cara membuat koleksi aturan font cadangan, memodifikasi aturannya dengan menghapus atau menambahkan font cadangan, dan menetapkan koleksi tersebut ke properti `FontsManager.font_fall_back_rules_collection`.

Setelah koleksi aturan font cadangan ditetapkan ke `fonts_manager` presentasi, aturan-aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar PNG.

## **Render Slide Menggunakan Aturan Font Cadangan**

Contoh berikut mencakup langkah-langkah ini:

1. Kami [membuat koleksi aturan font cadangan](/slides/id/python-net/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontfallbackrule/remove/) sebuah aturan font cadangan dan [add_fall_back_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) ke aturan lain.
1. Tetapkan koleksi aturan ke properti [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
1. Dengan metode [Presentation.save()](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) kita dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font cadangan ditetapkan ke FontsManager, aturan-aturan ini diterapkan selama operasi apa pun pada presentasi: simpan, render, konversi, dll.

```py
import aspose.slides as slides

# Buat instance baru dari koleksi aturan
rulesList = slides.FontFallBackRulesCollection()

# buat sejumlah aturan
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
	fallBackRule.remove("Tahoma")

	# Dan memperbarui aturan untuk rentang yang ditentukan
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Juga kita dapat menghapus aturan yang ada dari daftar
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Menetapkan daftar aturan yang disiapkan untuk digunakan
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpan ke PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Baca lebih lanjut tentang cara [Mengonversi Slide PowerPoint ke PNG di Python](/slides/id/python-net/convert-powerpoint-to-png/).
{{% /alert %}}