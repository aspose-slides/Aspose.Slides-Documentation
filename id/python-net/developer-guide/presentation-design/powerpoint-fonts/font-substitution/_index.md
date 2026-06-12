---
title: Konfigurasi Penggantian Font dalam Presentasi dengan Python
linktitle: Penggantian Font
type: docs
weight: 70
url: /id/python-net/font-substitution/
keywords:
- font
- font substitusi
- penggantian font
- ganti font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Aktifkan substitusi font optimal di Aspose.Slides untuk Python via .NET saat mengonversi presentasi PowerPoint & OpenDocument ke format file lain."
---
## **Overview**

Penggantian font memungkinkan Aspose.Slides menggunakan font lain ketika font presentasi asli tidak tersedia selama proses rendering atau konversi. Anda dapat memeriksa font mana yang digantikan dengan menggunakan metode `get_substitutions` dari kelas `FontsManager`.

Aspose.Slides juga memungkinkan Anda mendefinisikan aturan penggantian font. Misalnya, Anda dapat menentukan bahwa font yang tidak dapat diakses harus diganti dengan font lain yang tersedia dan kemudian menerapkan aturan tersebut melalui font manager presentasi.

## **Set Substitution Rules**

Aspose.Slides memungkinkan Anda mengatur aturan untuk font yang menentukan apa yang harus dilakukan dalam kondisi tertentu (misalnya, ketika font tidak dapat diakses) dengan cara berikut:

1. Muat presentasi yang relevan.
2. Muat font yang akan diganti.
3. Muat font baru.
4. Tambahkan aturan untuk penggantian.
5. Tambahkan aturan ke koleksi aturan penggantian font presentasi.
6. Hasilkan gambar slide untuk mengamati efeknya.

Kode Python ini menunjukkan proses penggantian font:

```python
import aspose.slides as slides

# Muat presentasi
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Muat font sumber yang akan diganti
    sourceFont = slides.FontData("SomeRareFont")

    # Muat font baru
    destFont = slides.FontData("Arial")

    # Tambahkan aturan font untuk penggantian font
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Tambahkan aturan ke koleksi aturan substitusi font
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Tambahkan koleksi aturan font ke daftar aturan
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial font akan digunakan menggantikan SomeRareFont ketika yang terakhir tidak dapat diakses
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Simpan gambar ke disk dalam format JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
Anda mungkin ingin melihat [**Penggantian Font**](/slides/id/python-net/font-replacement/). 
{{% /alert %}}

## **Limitations for Math Equation Fonts**

Aturan penggantian font berpartisipasi dalam proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka cocok untuk skenario teks biasa di mana Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font lain yang tersedia sesuai dengan aturan yang dikonfigurasi.

Namun, persamaan matematika Office memiliki batasan penting. Jika sebuah persamaan dibuat dengan **Cambria Math**, Aspose.Slides mungkin masih memerlukan font **Cambria Math** asli untuk menghitung dan merender tata letak persamaan dengan benar. Karena hal ini, menggantikan **Cambria Math** dengan font matematika lain, seperti **STIX Two Math**, tidak didukung untuk rendering persamaan dan masih dapat menghasilkan pengecualian yang menunjukkan bahwa **Cambria Math** diperlukan.

Untuk mengonversi presentasi semacam itu dengan sukses, pastikan **Cambria Math** tersedia untuk Aspose.Slides pada saat runtime. Anda dapat menginstal font di sistem operasi atau menyediakannya sebagai [font eksternal](/slides/id/python-net/custom-font/) sehingga dapat berpartisipasi dalam proses pemilihan font normal selama rendering dan konversi.

Batasan ini khusus untuk rendering persamaan. Aturan penggantian font standar yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa ketika font asli tidak dapat diakses.

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Replacement](/slides/id/python-net/font-replacement/) adalah penimpaan paksa satu font dengan font lain di seluruh presentasi. Substitusi adalah aturan yang dipicu di bawah kondisi tertentu, misalnya ketika font asli tidak tersedia, dan kemudian font cadangan yang ditentukan digunakan.

**When exactly are substitution rules applied?**

Aturan tersebut berpartisipasi dalam urutan [font selection](/slides/id/python-net/font-selection-sequence/) standar yang dievaluasi selama pemuatan, rendering, dan konversi; jika font yang dipilih tidak tersedia, penggantian atau substitusi akan diterapkan.

**What is the default behavior if neither replacement nor substitution is configured and the font is missing on the system?**

Pustaka akan mencoba memilih font sistem terdekat yang tersedia, mirip dengan cara PowerPoint berperilaku.

**Can I attach custom external fonts at runtime to avoid substitution?**

Ya. Anda dapat [add external fonts](/slides/id/python-net/custom-font/) pada runtime sehingga pustaka mempertimbangkannya untuk pemilihan dan rendering, termasuk untuk konversi berikutnya.

**Does Aspose distribute any fonts with the library?**

Tidak. Aspose tidak mendistribusikan font berbayar maupun gratis; Anda menambahkan dan menggunakan font atas kebijaksanaan dan tanggung jawab Anda sendiri.

**Are there differences in substitution behavior on Windows, Linux, and macOS?**

Ya. Penemuan font dimulai dari direktori font sistem operasi. Set font default yang tersedia dan jalur pencarian berbeda di tiap platform, yang memengaruhi ketersediaan dan kebutuhan substitusi.

**How should I prepare the environment to minimize unexpected substitution during batch conversions?**

Sinkronkan set font di seluruh mesin atau kontainer, [add the external fonts](/slides/id/python-net/custom-font/) yang diperlukan untuk dokumen output, dan [embed fonts](/slides/id/python-net/embedded-font/) dalam presentasi bila memungkinkan sehingga font yang dipilih tersedia selama rendering.