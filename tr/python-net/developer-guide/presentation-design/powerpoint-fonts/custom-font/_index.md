---
title: "Python'da PowerPoint Yazı Tiplerini Özelleştir"
linktitle: "Özel Yazı Tipi"
type: docs
weight: 20
url: /tr/python-net/custom-font/
keywords:
- yazı tipi
- özel yazı tipi
- harici yazı tipi
- yazı tipi yükle
- yazı tiplerini yönet
- yazı tipi klasörü
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: ".NET üzerinden Python için Aspose.Slides ile PowerPoint slaytlarına özel yazı tipleri ekleyerek sunumlarınızın her cihazda net ve tutarlı kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides for Python, gerektiğinde sistemde yüklü olmasa bile sunumların doğru şekilde görüntülenmesini sağlamak için çalışma zamanında özel yazı tipleri sağlamanıza izin verir. PDF veya görüntülere dışa aktarırken, metin düzenini, glif ölçümlerini ve tipografiyi korumak için yazı tipi klasörleri veya bellek içi yazı tipi verileri temin edebilirsiniz. Bu, sunucu tarafı renderlamayı farklı ortamlar arasında öngörülebilir hâle getirir, işletim sistemi düzeyindeki yazı tipi bağımlılıklarını ortadan kaldırır ve istenmeyen yedekleme veya yeniden akışları önler. Bu makale, yazı tipi kaynaklarını nasıl kaydedileceğini gösterir.

Bir sunum teması, bireysel yazı sistemleri için farklı yazı tipi ailelerine başvurabilir. Bu eşlemeler yalnızca yazı tipi adlarını saklar, ancak yazı tipi dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/python-net/script-specific-font-mappings/) sayfasına bakın ve aşağıdaki yükleme seçeneklerini kullanarak başvurulan yazı tiplerinin tutarlı renderlanması için erişilebilir olmasını sağlayın.

Aspose.Slides, [FontsLoader](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/) sınıfının `load_external_font` ve `load_external_fonts` yöntemlerini kullanarak aşağıdaki yazı tiplerini yüklemenize olanak tanır:

- TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Özel Yazı Tiplerini Yükle**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize izin verir. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/load_external_fonts/) yöntemini çağırın.
3. Sunumu yükleyin ve render/dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clear_cache](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/clear_cache/) yöntemini çağırın.

```py
import aspose.slides as slides

# Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
font_folders = ["fonts", "external_fonts"]

# Belirtilen klasörlerden özel yazı tiplerini yükleyin.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktar (ör. PDF, görüntüler veya diğer formatlar).
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# İş bittiğinde yazı tipi önbelleğini temizleyin.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Not" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/load_external_fonts/) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörünü Al**

Aspose.Slides, `get_font_folders` yöntemini sağlayarak eklenen ve sistemin yazı tipi klasörlerini döndürür. Bu, `load_external_fonts` aracılığıyla eklenen klasörleri ve sistem yazı tipi klasörlerini içerir.

```python
import aspose.slides as slides

# Bu çağrı, yazı tipi dosyaları için denetlenen klasörleri döndürür.
# Bunlar, load_external_fonts yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini içerir.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Bir Sunum İçin Özel Yazı Tiplerini Belirle**

Aspose.Slides, `document_level_font_sources` özelliği aracılığıyla bir sunumla kullanılacak dış yazı tiplerini belirlemenize olanak tanır.

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Sunumla çalış.
    # CustomFont1, CustomFont2 ve assets\fonts ve global\fonts klasörlerinden (ve alt klasörlerinden) gelen yazı tipleri sunum için kullanılabilir.
    # ...
    print(len(presentation.slides))
```

## **İkili Veriden Harici Yazı Tiplerini Yükle**

Aspose.Slides, `load_external_font` yöntemini kullanarak harici yazı tiplerini ikili veriden yüklemenizi sağlar.

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Harici yazı tiplerini bayt dizilerinden yükle.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Harici yazı tipleri bu sunum örneği ömrü boyunca kullanılabilir.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **SSS**

### Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?

Evet. Bağlı yazı tipleri, renderlayıcı tarafından tüm dışa aktarım formatlarında kullanılır.

### Are custom fonts automatically embedded into the resulting PPTX?

Hayır. Bir yazı tipini renderlamak için kaydetmek, onu PPTX'e gömmekle aynı şey değildir. Yazı tipinin sunum dosyasının içinde taşınmasını istiyorsanız, açık [gömme özellikleri](/slides/tr/python-net/embedded-font/) kullanmalısınız.

### Can I control fallback behavior when a custom font lacks certain glyphs?

Evet. [font substitution](/slides/tr/python-net/font-substitution/), [replacement rules](/slides/tr/python-net/font-replacement/) ve [fallback sets](/slides/tr/python-net/fallback-font/) yapılandırarak eksik glif olduğunda hangi yazı tipinin kullanılacağını tam olarak tanımlayabilirsiniz.

### Can I use fonts in Linux/Docker containers without installing them system-wide?

Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine herhangi bir bağımlılığı ortadan kaldırır.

### What about licensing—can I embed any custom font without restrictions?

Yazı tipi lisans uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişebilir; bazı lisanslar gömme veya ticari kullanımını yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA’sını gözden geçirin.