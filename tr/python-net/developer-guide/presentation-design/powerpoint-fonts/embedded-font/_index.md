---
title: Python ile Sunumlarda Fontları Gömme
linktitle: Gömülü Fontlar
type: docs
weight: 40
url: /tr/python-net/embedded-font/
keywords:
- font ekle
- font göm
- font gömme
- gömülü font al
- gömülü font ekle
- gömülü font kaldır
- gömülü font sıkıştır
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint'te gömülü fontları yönetin. Fontları eklemek, almak, kaldırmak ve sıkıştırmak için Python kullanın; metin görünümünü koruyun ve dosya boyutunu küçültün."
---
## **Giriş**

Gömülü fontlar, font verilerini bir PowerPoint sunumunun içine depolar. Görüntüleyici gömülü fontları desteklediğinde, hedef sistemde yüklü olmasalar bile metni bu fontlarla görüntüleyebilir. Bu, satır sonlarını, metin aralığını ve slayt düzenini korumaya yardımcı olur.

Aspose.Slides for Python via .NET, bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesinin [fonts_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/fonts_manager/) özelliği aracılığıyla gömülü fontları almanıza, eklemenize ve kaldırmanıza olanak tanır. Ayrıca sunumun kullanmadığı karakterleri kaldırarak gömülü font verisinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir fontu gömmeden önce, font verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansının gömme izni verdiğinden emin olun.

## **Gömülü Fontları Al ve Kaldır**

[get_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) metodunu kullanarak bir sunumda depolanan fontları listeleyin. Bir fontu kaldırmak için, listedeki bir fontu [remove_embedded_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/remove_embedded_font/) metoduna geçirin ve ardından sunumu kaydedin.

Aşağıdaki örnek, `EmbeddedFonts.pptx` dosyasındaki gömülü fontları listeler ve Calibri mevcutsa kaldırır:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Gömülü bir fontu kaldırmak, onun depolanmış font verisini siler; metne atanan fontu değiştirmez. Font hedef sistemde yüklüyse, metin hâlâ onu kullanabilir. Aksi takdirde, renderleme [font substitution](/slides/tr/python-net/font-substitution/) gerektirebilir ve bu da düzeni etkileyebilir.

## **Font Verisini ve Gömme İzinlerini İncele**

[FontsManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/) sınıfını kullanarak fontları gömmeden önce inceleyin. Sunumda kullanılan fontları almak için [get_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_fonts/) metodunu çağırın. Her bir font için bir [FontData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontdata/) nesnesi ve gerekli [FontStyleType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontstyletype/) değerini [get_font_bytes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_font_bytes/) metoduna geçirin. Metod, o font stilinin ikili verisini döndürür; istenen font veya stil bulunamazsa `None` döner. `None` sonucunu [get_font_embedding_level](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_font_embedding_level/) metoduna geçirmeyin, çünkü bu metod bir bayt dizisi gerektirir.

[EmbeddingLevel](https://reference.aspose.com/slides/tr/python-net/aspose.slides/embeddinglevel/) fontta depolanan gömme kısıtlamalarını raporlayan bir bayrak enumerasyonudur:
- `INSTALLABLE` gömmeye ve başka bir sistemde kalıcı kuruluma izin verir; bu, font lisansına tabidir.
- `RESTRICTED` tek kullanım‑izin bayrağı olduğunda, fontun yasal sahibinden izin alınmadan gömülmesini yasaklar.
- `PREVIEW_PRINT` görüntüleme ve yazdırma için geçici kullanımına izin verir; fontu içeren belge yalnızca okuma‑yazma iznine sahip olmalıdır.
- `EDITABLE` geçici kullanımına izin verir ve belgenin düzenlenip kaydedilmesine olanak tanır.
- `NO_SUBSETTING` ek bir kısıtlamadır; sadece karakter alt kümesini gömmeyi yasaklar. Bu bayrak mevcutsa tüm karakterler gömülmelidir.
- `BITMAP_ONLY` ek bir kısıtlamadır; yalnızca bitmap vuruşlarının gömülmesine izin verir, vektör verisi gömülmez. Fontta bitmap vuruşu yoksa gömülemez.

İlk dört değer kullanım iznini tanımlar, `NO_SUBSETTING` ve `BITMAP_ONLY` ise onlarla birleştirilebilir. Modifikatörleri bit‑düzeyinde işlemlerle kontrol edin. `INSTALLABLE` sıfır olduğu için, kullanım‑izin bitlerini maskelayıp sonucu `INSTALLABLE` ile karşılaştırın. Güncel fontlar en fazla bir kullanım‑izin biti ayarlamalıdır. Birden fazla izin biti ayarlayan eski fontlarla uyumluluk için aşağıdaki yardımcı, en az kısıtlayıcı izni seçer: önce `EDITABLE`, ardından `PREVIEW_PRINT`, ardından `RESTRICTED`.

Aşağıdaki örnek, `get_fonts` tarafından döndürülen her font için normal, koyu, eğik ve koyu‑eğik verileri denetler. Kullanılamayan stilleri, kısıtlı fontları, yalnızca bitmap olan fontları, ön izleme ve yazdırma ile sınırlı (çünkü çıktı hâlâ düzenlenebilir) fontları ve zaten gömülü olan fontları atlar. Kullanılabilir bir stilde `NO_SUBSETTING` varsa, o font ailesi için tüm karakterler gömülür.
```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Bu inceleme, her font dosyasında kodlanmış kısıtlamaları rapor eder. Bir lisans vermek, fontu yasal olarak edindiğinizi kanıtlamak ya da gömülü bir kopya dağıtmadan önce font lisans sözleşmesini kontrol etmeyi yerine geçmez.

## **Gömülü Fontlar Ekle**

Bir fontu gömmek için [add_embedded_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/add_embedded_font/) metodunu kullanın. Aşırı yüklemeleri ya bir [FontData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontdata/) nesnesi ya da font verisini içeren bir bayt dizisi kabul eder. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/embedfontcharacters/) enumerasyonu, hangi karakterlerin dahil edileceğini kontrol eder:
- [ALL](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/embedfontcharacters/) fonttaki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin girmesi gerektiğinde bu seçenek kullanılır.
- [ONLY_USED](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/embedfontcharacters/) sadece sunumda kullanılan karakterleri gömer, dosya boyutunu azaltır. Sunumun öncelikle görüntülenmesi amaçlandığında bu seçenek seçilir.

Aşağıdaki örnek, `Fonts.pptx` içinde kullanılan fontları almak için [get_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_fonts/) metodunu kullanır ve hâlâ gömülmemiş olanları gömer. Eklenmek istenen fontların kodu çalıştıran makinede mevcut olması gerekir. Mevcut gömülü fontlar mevcut karakter setlerini korur.
```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Gömülü Fontları Sıkıştır**

[compress_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) kullanılmayan karakterleri kaldırarak gömülü font verisini azaltır. Zaten gömülü fontlar üzerinde çalıştığından, boyut azalması sunumdaki kullanılmayan font verisinin miktarına bağlıdır.

Aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki fontları sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Alıcıların ileride metin eklemesi gerekebileceği durumlar için orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, başlangıçta tüm karakterler gömülmüş olsa bile, gömülü fonttan artık kullanılamaz.

## **SSS**

**Bir gömülü fontun renderleme sırasında hâlâ değiştirileceğini nasıl kontrol edebilirim?**

Sunumu renderlediğiniz ortamda [get_substitutions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_substitutions/) metodunu çağırarak Aspose.Slides'in hangi fontları değiştireceğini görebilirsiniz. Ayrıca [font substitution](/slides/tr/python-net/font-substitution/) ayarlarını ve [font fallback](/slides/tr/python-net/fallback-font/) kurallarını kontrol edin. Fallback eksik karakterleri ele alır, bu yüzden bir fontu gömmek, fontun kendisinde bulunmayan karakterleri çözmez.

**Arial ve Calibri gibi yaygın fontları gömmeli miyim?**

Kararı hedef ortama göre verin. Gerekli fontlar, sunumu açan veya renderleyen her makinede mevcutsa, gömmek gereksiz dosya boyutu ekleyebilir. Alıcıların veya sunucuların bu fontları bulundurmama ihtimali varsa ve lisansları izin veriyorsa, gömmek istenen görünümü korumaya yardımcı olur.