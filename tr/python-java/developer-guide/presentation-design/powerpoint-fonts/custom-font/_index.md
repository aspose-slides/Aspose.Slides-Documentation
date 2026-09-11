---
title: "Java aracılığıyla Python'da PowerPoint Yazı Tiplerini Özelleştir"
linktitle: "Özel Yazı Tipi"
type: docs
weight: 20
url: /tr/python-java/custom-font/
keywords:
- yazı tipi
- özel yazı tipi
- harici yazı tipi
- yazı tipi yükle
- yazı tiplerini yönet
- yazı tipi klasörü
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint slaytlarında yazı tiplerini özelleştirerek sunumlarınızı her cihazda keskin ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tipleri kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge‑seviyesinde yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya ikili veri üzerinden dış yazı tiplerini doğrudan yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum PDF, görüntüler ve diğer desteklenen formatlara aktarılırken kullanılır. Bu, farklı ortamlar arasında sunum çıktısının tutarlı olmasını sağlar. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Özel yazı tiplerini render için kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin sunum içinde saklanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi ailelerine başvurabilir. Bu eşlemeler yalnızca yazı tipi adlarını depolar, ancak yazı tipi dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/python-java/script-specific-font-mappings/) bölümüne bakın ve aşağıdaki yükleme seçeneklerini kullanarak başvurulan yazı tiplerini tutarlı bir render için kullanılabilir hâle getirin.

{{% alert color="info" title="Note" %}}

Aspose.Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadExternalFonts) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, sistemde kurulum yapmadan bir sunumda kullanılan yazı tiplerini yüklemenizi sağlar. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece oluşturulan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadExternalFonts) metodunu çağırarak bu klasörlerden yazı tiplerini yükleyin.
3. Sunumu yükleyin ve render/ dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#clearCache) metodunu çağırın.

Aşağıdaki kod örneği yazı tipi yükleme sürecini göstermektedir:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Özel yazı tipi dosyalarını içeren klasörleri tanımla.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Belirtilen klasörlerden özel yazı tiplerini yükle.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Yüklenen yazı tiplerini kullanarak sunumu render/ dışa aktar.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # İş tamamlandıktan sonra yazı tipi önbelleğini temizle.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadExternalFonts) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Almak**
Aspose.Slides, yazı tipi klasörlerini bulmanızı sağlayan [getFontFolders](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#getFontFolders) metodunu sunar. Bu metod, [loadExternalFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadExternalFonts) yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu Python kodu, [getFontFolders](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#getFontFolders) metodunun nasıl kullanılacağını gösterir:

```python
from asposeslides.api import FontsLoader

# loadExternalFonts yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini al.
font_folders = FontsLoader.getFontFolders()
```

## **Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**
Aspose.Slides, sunumla kullanılacak dış yazı tiplerini belirlemenizi sağlayan [getDocumentLevelFontSources](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) metodunu sunar.

Bu Python kodu, [getDocumentLevelFontSources](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) metodunun nasıl kullanılacağını gösterir:

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Sunumla çalış.
    # CustomFont1, CustomFont2 ve assets/fonts ile global/fonts içindeki yazı tipleri
    # ve alt klasörleri sunuma açıktır.
    pass
finally:
    presentation.dispose()
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, ikili veriden dış yazı tiplerini yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadExternalFont) metodunu sunar.

Bu Python kodu, bayt dizisi ile yazı tipi yükleme sürecini gösterir:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Sunum süresi boyunca dış yazı tipleri yüklenir.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **SSS**

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?**

Evet. Bağlı yazı tipleri, render tarafından tüm dışa aktarma formatlarında kullanılır.

**Özel yazı tipleri otomatik olarak sonuç PPTX dosyasına gömülür mü?**

Hayır. Bir yazı tipini render için kaydetmek, PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasına dahil edilmesi gerekiyorsa, açıkça [gömme özelliklerini](/slides/tr/python-java/embedded-font/) kullanmalısınız.

**Bir özel yazı tipinde bazı glifler eksik olduğunda geri dönüş davranışını kontrol edebilir miyim?**

Evet. [Yazı tipi ikamesi](/slides/tr/python-java/font-substitution/), [değiştirme kuralları](/slides/tr/python-java/font-replacement/) ve [geri dönüş setleri](/slides/tr/python-java/fallback-font/) yapılandırarak istenen glif eksik olduğunda hangi yazı tipinin kullanılacağını tam olarak belirleyebilirsiniz.

**Linux/Docker konteynerlerinde sistem genelinde kurulum yapmadan yazı tiplerini kullanabilir miyim?**

Evet. Kendi yazı tipi klasörlerinize işaret ederek veya bayt dizilerinden yazı tiplerini yükleyerek. Bu, konteyner imajında sistem yazı tipi dizinlerine herhangi bir bağımlılığı ortadan kaldırır.

**Lisanslama açısından—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**

Yazı tipi lisans uyumluluğu sizin sorumluluğunuzdadır. Koşullar değişir; bazı lisanslar gömme veya ticari kullanımı yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını inceleyin.