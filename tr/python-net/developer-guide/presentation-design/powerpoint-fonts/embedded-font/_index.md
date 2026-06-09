---
title: Python ile Sunumlarda Yazı Tipi Yerleştirme
linktitle: Yazı Tipi Yerleştirme
type: docs
weight: 40
url: /tr/python-net/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi yerleştir
- yazı tipi yerleştirme
- yerleştirilmiş yazı tipini al
- yerleştirilmiş yazı tipi ekle
- yerleştirilmiş yazı tipini kaldır
- yerleştirilmiş yazı tipini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: ".NET üzerinden Python için Aspose.Slides ile PowerPoint ve OpenDocument sunumlarına TrueType yazı tiplerini yerleştirerek tüm platformlarda doğru render alınmasını sağlar."
---
## **Giriş**

**PowerPoint'ta yazı tiplerini yerleştirmek**, sunumunuzun farklı sistemlerde bile hedeflenen görünümünü korumasını sağlar. Yaratıcılık için benzersiz ya da standart yazı tipleri kullanıyor olun, yazı tiplerini yerleştirmek metin ve düzen bozulmasını önler.

Eğer çalışmanızda yaratıcılık nedeniyle üçüncü taraf veya standart dışı bir yazı tipi kullandıysanız, yazı tipinizi yerleştirmeniz için daha da fazla nedeniniz olur. Aksi takdirde (yerleştirilmiş yazı tipleri olmadan), slaytlarınızdaki metinler veya sayılar, düzen, stil vb. değişebilir veya karışık dikdörtgenlere dönüşebilir.

Yerleştirilmiş yazı tiplerini yönetmek için [FontsManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontdata/) ve [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) sınıflarını kullanın.

## **Yerleştirilmiş Yazı Tiplerini Al ve Kaldır**

Bir sunumdan yerleştirilmiş yazı tiplerini kolayca almak veya kaldırmak için [get_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ve [remove_embedded_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/remove_embedded_font/) yöntemlerini kullanın.

Bu Python kodu, bir sunumdan yerleştirilmiş yazı tiplerini nasıl alıp kaldıracağınızı gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekle.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Gömülü 'FunSized' yazı tipini kullanan bir metin çerçevesi içeren slaytı render et.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Tüm gömülü yazı tiplerini al.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # 'Calibri' yazı tipini bul.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # 'Calibri' yazı tipini kaldır.
    fonts_manager.remove_embedded_font(font_data)

    # Slaytı render et; 'Calibri' yazı tipi mevcut bir yazı tipine değiştirilecek.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Gömülü 'Calibri' yazı tipi olmadan sunumu diske kaydet.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Yerleştirilmiş Yazı Tipi Ekle**

[EmbedFontCharacters](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/embedfontcharacters/) enumunu ve [add_embedded_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/add_embedded_font/) yönteminin iki aşırı yüklemesini kullanarak, bir sunuma yazı tiplerini yerleştirmek için tercih ettiğiniz (yerleştirme) kuralı seçebilirsiniz. Bu Python kodu, bir sunuma yazı tiplerini nasıl yerleştireceğinizi ve ekleyeceğinizi gösterir:

```python
import aspose.slides as slides

# Sunumu yükle.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Sunumu diske kaydet.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Yerleştirilmiş Yazı Tiplerini Sıkıştır**

[compress_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) kullanarak yerleştirilmiş yazı tiplerini sıkıştırarak dosya boyutunu optimize edin.

Sıkıştırma için örnek kod:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Yerleştirme yapılmış olsa bile sunumdaki belirli bir yazı tipinin yine de render sırasında değiştirilip değiştirilmeyeceğini nasıl anlayabilirim?**

Yazı tipi yöneticisindeki [substitution information](/slides/tr/python-net/font-substitution/) ve [fallback/substitution rules](/slides/tr/python-net/fallback-font/) sayfalarına bakın: yazı tipi mevcut değilse veya kısıtlıysa bir yedek (fallback) kullanılacaktır.

**Arial/Calibri gibi "sistem" yazı tiplerini yerleştirmek değerli mi?**

Genellikle hayır—neredeyse her zaman mevcuttur. Ancak "ince" ortamlarda (Docker, önceden yüklü yazı tipleri olmayan bir Linux sunucusu) tam taşınabilirlik için sistem yazı tiplerini yerleştirmek beklenmedik değişim riskini ortadan kaldırabilir.