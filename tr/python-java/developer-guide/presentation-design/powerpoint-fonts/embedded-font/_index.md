---
title: Python via Java ile Sunumlarda Yazı Tiplerini Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/python-java/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi göm
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "PowerPoint'ta Aspose.Slides for Python via Java ile gömülü yazı tiplerini yönetin. Yazı tiplerini ekleyin, alın, kaldırın ve sıkıştırın; metin görünümünü koruyun ve dosya boyutunu azaltın."
---
## **Giriş**

Yazı tiplerini gömmek, yazı tipi verilerini bir PowerPoint sunumunun içinde saklar. Bir görüntüleyici gömülü yazı tiplerini desteklediğinde, hedef sistemde yüklü olmasalar bile metni bu yazı tipleriyle gösterebilir. Bu, satır sonları, metin aralığı ve slayt düzeninin korunmasına yardımcı olur.

Aspose.Slides for Python via Java, [FontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) sınıfını [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getFontsManager) üzerinden dönen sınıf aracılığıyla gömülü yazı tiplerini almanıza, eklemenize ve kaldırmanıza izin verir. Ayrıca, sunumun kullanmadığı karakterleri kaldırarak gömülü yazı tipi verisinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir yazı tipini gömmeden önce, yazı tipi verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansının gömmeye izin verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Bir sunumda depolanan yazı tiplerini listelemek için [getEmbeddedFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) kullanın. Birini kaldırmak için, listedeki bir yazı tipini [removeEmbeddedFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) metoduna aktarın ve ardından sunumu kaydedin.

Aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki gömülü yazı tiplerini listeler ve Calibri mevcutsa kaldırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Bir gömülü yazı tipini kaldırmak, saklanan yazı tipi verisini siler; metne atanmış yazı tipini değiştirmez. Yazı tipi hedef sistemde kuruluysa, metin hâlâ bu yazı tipini kullanabilir. Aksi takdirde, renderlama yazı tipi ikamesi gerektirebilir ve bu da düzeni etkileyebilir.

## **Yazı Tipi Verisini ve Gömme İzinlerini İnceleme**

Yazı tiplerini gömmeden önce incelemek için [FontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) sınıfını kullanın. Sunumda kullanılan yazı tiplerini almak için [FontsManager.getFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getFonts) çağırın. Her bir yazı tipi için bir [FontData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontdata/) nesnesi ve gerekli [FontStyleType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontstyletype/) değerini [FontsManager.getFontBytes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getFontBytes) metoduna geçirin. Metod, o yazı tipi stilinin ikili verisini döndürür; istenen yazı tipi veya stil bulunamazsa `None` döner. `None` sonucunu [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) metoduna göndermeyin, çünkü bu metod bir bayt dizisi bekler.

[EmbeddingLevel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/embeddinglevel/) yazı tipinde depolanan gömme kısıtlamalarını raporlayan bir bayrak enumeration’ıdır:

- `Installable` gömmeye ve başka bir sistemde kalıcı kuruluma izin verir; bu, yazı tipi lisansına tabidir.
- `Restricted` yalnızca tek kullanım‑izin bayrağı olduğunda, yazı tipinin yasal sahibinden izin alınmadıkça gömme yasaktır.
- `PreviewPrint` geçici olarak görüntüleme ve yazdırma için izin verir; yazı tipini içeren belge salt‑okunur olmalıdır.
- `Editable` geçici kullanım izni verir ve belgenin düzenlenip kaydedilmesine izin tanır.
- `NoSubsetting` yalnızca bir alt küme karakterin gömülmesini yasaklayan ek bir kısıtlamadır. Bu bayrak mevcutsa tüm karakterler gömülmelidir.
- `BitmapOnly` yalnızca bitmap vuruşlarının gömülmesine izin veren ek bir kısıtlamadır; kontur verisi gömülemez. Font bitmap vuruşu içermiyorsa gömülemez.

İlk dört değer kullanım iznini tanımlarken, `NoSubsetting` ve `BitmapOnly` bunlarla birlikte kullanılabilir. Modifikasyonları bit‑düzeyi işlemlerle kontrol edin. `Installable` sıfır olduğundan, kullanım‑izin bitlerini maskeleyip sonucu `Installable` ile karşılaştırın; bayrak olarak doğrudan kontrol etmeyin. Geçerli fontlar en fazla bir kullanım‑izin biti ayarlamalıdır. Birden fazla ayarlayan eski fontlarla uyumluluk için aşağıdaki yardımcı, en az kısıtlayıcı izni seçer: `Editable`, ardından `PreviewPrint`, ardından `Restricted`.

Aşağıdaki örnek, `getFonts` tarafından döndürülen her font için normal, kalın, eğik ve kalın‑eğik verilerini denetler. Kullanılamayan stilleri, kısıtlı fontları, sadece bitmap‑only olanları, sadece önizleme‑yazdırma izni olanları (çünkü çıktı hâlâ düzenlenebilir), ve zaten gömülmüş fontları atlar. Eğer herhangi bir kullanılabilir stil `NoSubsetting` içeriyorsa, o font ailesi için tüm karakterler gömülür:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu denetim, her font dosyasındaki kodlanmış kısıtlamaları raporlar. Bir lisans temini, yasal olarak font edinildiğinin kanıtı sağlamak veya gömülü bir kopya dağıtmadan önce font lisans sözleşmesini kontrol etmek yerine geçmez.

## **Gömülü Yazı Tipi Ekleme**

Bir font gömmek için [addEmbeddedFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) kullanın. Aşırı yüklemeleri, bir [FontData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontdata/) nesnesi ya da font verisini içeren bir bayt dizisi alır. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/embedfontcharacters/) enumeration’ı, hangi karakterlerin dahil edileceğini kontrol eder:

- [All](https://reference.aspose.com/slides/tr/python-java/aspose.slides/embedfontcharacters/) fonttaki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin eklemesi gerektiğinde bu seçenek kullanılır.
- [OnlyUsed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/embedfontcharacters/) sadece sunumda kullanılan karakterleri gömer; dosya boyutunu azaltır. Tamamlanmış ve öncelikle görüntülenmesi amaçlanan sunumlar için bu seçenek tercih edilmelidir.

Aşağıdaki örnek, `Fonts.pptx` içinde kullanılan fontları [getFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getFonts) ile alır ve hâlâ gömülmemiş olanları gömer. Eklemek istenen fontların kodun çalıştığı makinede bulunması gerekir. Mevcut gömülü fontlar karakter setlerini korur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gömülü Yazı Tiplerini Sıkıştırma**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#compressEmbeddedFonts) kullanılmayan karakterleri kaldırarak gömülü font verisini azaltır. Zaten gömülmüş fontlar üzerinde çalıştığından, boyut azalması sunumdaki kullanılmayan font verisinin miktarına bağlıdır.

Aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki fontları sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alıcıların ileride metin eklemesi gerekebileceği durumlarda orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, gömülü font üzerinden artık kullanılamaz; başlangıçta tüm karakterler gömülmüş olsa bile.

## **SSS**

**Bir gömülü fontun renderlama sırasında yine de ikame edilip edilmeyeceğini nasıl kontrol edebilirim?**

Sunumu renderladığınız ortamda [getSubstitutions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getSubstitutions) metodunu çağırarak Aspose.Slides’in hangi fontları değiştireceğini görebilirsiniz. Ayrıca font ikamesi ayarlarını ve font geri dönüş kurallarını kontrol edin. Geri dönüş, eksik karakterleri ele alır; bu nedenle bir fontu gömmek, fontun içinde bulunmayan karakterleri çözmez.

**Arial ve Calibri gibi yaygın fontları gömmeli miyim?**

Karar, hedef ortamına göre verilmelidir. Gerekli fontlar, sunumu açan veya renderlayan her makinede mevcutsa, gömmek gereksiz dosya büyüklüğü ekler. Alıcıların ya da sunucuların bu fontları bulundurma ihtimali düşükse, lisansları izin veriyorsa gömmek görünümün korunmasına yardımcı olur.