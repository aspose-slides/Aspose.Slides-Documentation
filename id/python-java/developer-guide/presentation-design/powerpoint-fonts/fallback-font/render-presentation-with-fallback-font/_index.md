---
title: Render Presentasi dengan Font Fallback di Python via Java
linktitle: Render Presentasi
type: docs
weight: 30
url: /id/python-java/render-presentation-with-fallback-font/
keywords:
- font fallback
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Render presentasi dengan font fallback di Aspose.Slides untuk Python via Java – pertahankan konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode Python langkah demi langkah."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font fallback. Artikel ini menunjukkan cara membuat koleksi aturan font fallback, memodifikasi aturannya dengan menghapus atau menambahkan font fallback, dan menetapkan koleksi tersebut menggunakan metode [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Setelah koleksi aturan font fallback ditetapkan ke [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) presentasi, aturan-aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini memperlihatkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar JPEG.

## **Merender Slide Menggunakan Aturan Font Fallback**

Contoh berikut mencakup langkah-langkah ini:

1. [Buat koleksi aturan font fallback](/slides/id/python-java/create-fallback-fonts-collection/).
1. [Hapus](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/#remove) font fallback dari sebuah aturan dan [tambahkan font fallback](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) ke aturan lain.
1. Tetapkan koleksi aturan menggunakan [setFontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) pada font manager yang dikembalikan oleh [getFontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getFontsManager).
1. Gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk menyimpan presentasi dalam format yang sama atau format lain. Setelah koleksi aturan font fallback ditetapkan ke [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/), aturan-aturan ini diterapkan selama operasi pada presentasi: menyimpan, merender, mengonversi, dan sebagainya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Buat koleksi aturan baru.
fallback_rules = FontFallBackRulesCollection()

# Buat beberapa aturan.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Coba menghapus font fallback "Tahoma" dari aturan.
    fallback_rule.remove("Tahoma")

    # Perbarui aturan untuk rentang yang ditentukan.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Hapus aturan yang ada, mempertahankan setidaknya satu aturan untuk rendering.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Tetapkan koleksi aturan yang disiapkan.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Render thumbnail menggunakan koleksi aturan yang dikonfigurasi.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Simpan gambar ke disk dalam format JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Catatan" %}}
Baca lebih lanjut tentang cara [mengonversi PPT dan PPTX ke JPG di Python via Java](/slides/id/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}