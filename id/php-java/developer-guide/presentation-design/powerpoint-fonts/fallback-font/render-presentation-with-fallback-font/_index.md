---
title: Render Presentasi dengan Font Fallback di PHP
linktitle: Render Presentasi
type: docs
weight: 30
url: /id/php-java/render-presentation-with-fallback-font/
keywords:
- font fallback
- render PowerPoint
- render presentasi
- render slide
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Render presentasi dengan font fallback di Aspose.Slides untuk PHP via Java – jaga konsistensi teks di seluruh PPT, PPTX, dan ODP dengan contoh kode langkah demi langkah."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda merender presentasi menggunakan aturan font fallback. Artikel ini menunjukkan cara membuat koleksi aturan font fallback, memodifikasi aturannya dengan menghapus atau menambahkan font fallback, dan menetapkan koleksi tersebut ke metode `FontsManager::setFontFallBackRulesCollection`.

Setelah koleksi aturan font fallback ditetapkan ke `FontsManager` presentasi, aturan‑aturan tersebut diterapkan selama operasi seperti menyimpan, merender, dan mengonversi presentasi. Contoh ini menunjukkan cara menggunakan aturan yang dikonfigurasi saat merender thumbnail slide dan menyimpannya sebagai gambar PNG.

## **Merender Slide Menggunakan Aturan Font Fallback**

1. Kami [membuat koleksi aturan font fallback](/slides/id/php-java/create-fallback-fonts-collection/).
1. [Hapus](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) sebuah aturan font fallback dan [addFallBackFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke aturan lain.
1. Tetapkan koleksi aturan ke metode [getFontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. Dengan metode [Presentation.save](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation#save-java.lang.String-int-) kita dapat menyimpan presentasi dalam format yang sama, atau menyimpannya dalam format lain. Setelah koleksi aturan font fallback ditetapkan ke [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontsManager), aturan‑aturan ini diterapkan selama operasi apa pun pada presentasi: menyimpan, merender, mengonversi, dll.

```php
  # Membuat instance baru dari koleksi aturan
  $rulesList = new FontFallBackRulesCollection();
  # membuat sejumlah aturan
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Mencoba menghapus font FallBack "Tahoma" dari aturan yang dimuat
    $fallBackRule->remove("Tahoma");
    # Dan memperbarui aturan untuk rentang yang ditentukan
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Selain itu kita dapat menghapus aturan yang ada dari daftar
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Menetapkan daftar aturan yang telah disiapkan untuk digunakan
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Merender thumbnail dengan menggunakan koleksi aturan yang diinisialisasi dan menyimpannya ke JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Menyimpan gambar ke disk dalam format JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Baca lebih lanjut tentang cara [Mengonversi PPT dan PPTX ke JPG dalam PHP](/slides/id/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}