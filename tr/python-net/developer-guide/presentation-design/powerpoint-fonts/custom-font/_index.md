---
title: Python'da PowerPoint Fontlarını Özelleştirme
linktitle: Özel Font
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
description: ".NET üzerinden Python için Aspose.Slides ile PowerPoint slaytlarına özel fontları gömerek sunumlarınızın her cihazda net ve tutarlı kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides for Python, özel fontları çalışma zamanında sağlamanıza olanak tanır, böylece gereken fontlar ana sistemde yüklü olmasa bile sunumlar doğru şekilde görüntülenir. PDF veya görüntülere dışa aktarım sırasında, metin düzenini, glif ölçümlerini ve tipografiyi korumak için font klasörleri veya bellek içi font verileri sağlayabilirsiniz. Bu, sunucu tarafı renderlamayı farklı ortamlar arasında öngörülebilir hâle getirir, işletim sistemi düzeyindeki font bağımlılıklarını ortadan kaldırır ve istenmeyen geri dönüşler veya yeniden akışın önüne geçer. Makale, font kaynaklarının nasıl kaydedileceğini gösterir.

Aspose.Slides, aşağıdaki fontları `load_external_font` ve `load_external_fonts` yöntemlerini kullanarak [FontsLoader](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/) sınıfı aracılığıyla yüklemenize olanak tanır:

- TrueType (.ttf) ve TrueType Collection (.ttc) fontları. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) fontları. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Özel Fontları Yükleme**

Aspose.Slides, bir sunumda kullanılan fontları sistemi kurmadan yüklemenizi sağlar. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Fontlar özel dizinlerden yüklenir.

1. Font dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden fontları yüklemek için statik [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/load_external_fonts/) yöntemini çağırın.
3. Sunumu yükleyin ve render/ dışa aktarın.
4. Font önbelleğini temizlemek için [FontsLoader.clear_cache](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/clear_cache/) yöntemini çağırın.

Aşağıdaki kod örneği font yükleme sürecini gösterir:

```py
import aspose.slides as slides

# Özel font dosyalarını içeren klasörleri tanımlayın.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Belirtilen klasörlerden özel fontları yükleyin.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Yüklenen fontları kullanarak sunumu render/ dışa aktarın (ör. PDF, görüntüler veya diğer formatlar).
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# İş tamamlandıktan sonra font önbelleğini temizleyin.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Not" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/load_external_fonts/) ek klasörleri font arama yollarına ekler, ancak font başlatma sırasını değiştirmez. Fontlar şu sırayla başlatılır:

1. Varsayılan işletim sistemi font yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Font Klasörünü Al**

Aspose.Slides, font klasörlerini almak için `get_font_folders` metodunu sunar. Bu yöntem, `load_external_fonts` aracılığıyla eklenen klasörleri ve sistem font klasörlerini birlikte döndürür.

Bu Python kodu `get_font_folders` kullanımını gösterir:

```python
import aspose.slides as slides

# Bu çağrı, font dosyaları için kontrol edilen klasörleri döndürür.
# Bunlar, load_external_fonts yöntemiyle eklenen klasörler ve sistem font klasörlerini içerir.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Bir Sunum İçin Özel Fontları Belirleme**

Aspose.Slides, bir sunumda kullanılacak dış fontları belirlemenize olanak tanıyan `document_level_font_sources` özelliğini sağlar.

Aşağıdaki Python örneği `document_level_font_sources` kullanımını gösterir:

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
    # Sunum ile çalış.
    # CustomFont1, CustomFont2 ve assets\fonts ve global\fonts klasörlerindeki (ve alt klasörlerindeki) fontlar sunum için kullanılabilir.
    # ...
    print(len(presentation.slides))
```

## **İkili Veriden Dış Fontları Yükleme**

Aspose.Slides, ikili veriden dış fontları yüklemek için `load_external_font` metodunu sağlar.

Aşağıdaki Python örneği bir bayt dizisinden font yüklemeyi gösterir:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Dış fontları bayt dizilerinden yükle.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Dış fontlar bu sunum örneği ömrü boyunca kullanılabilir.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Sık Sorulan Sorular**

**Özel fontlar tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?**  
Evet. Bağlı fontlar, renderlayıcı tarafından tüm dışa aktarma formatlarında kullanılır.

**Özel fontlar otomatik olarak sonuç PPTX dosyasına gömülür mü?**  
Hayır. Bir fontu renderlama için kaydetmek, onu bir PPTX dosyasına gömmekle aynı şey değildir. Fontun sunum dosyasının içinde bulunmasını istiyorsanız, kesin [gömme özelliklerini](/slides/tr/python-net/embedded-font/) kullanmalısınız.

**Özel bir font belirli glifleri içermediğinde geri dönüş davranışını kontrol edebilir miyim?**  
Evet. İstenen glif bulunmadığında hangi fontun kullanılacağını tam olarak tanımlamak için [font ikamesi](/slides/tr/python-net/font-substitution/), [yerine koyma kuralları](/slides/tr/python-net/font-replacement/) ve [geri dönüş setleri](/slides/tr/python-net/fallback-font/) yapılandırabilirsiniz.

**Linux/Docker konteynerlerinde fontları sistem genelinde kurmadan kullanabilir miyim?**  
Evet. Kendi font klasörlerinize işaret edebilir veya fontları bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem font dizinlerine olan tüm bağımlılığı ortadan kaldırır.

**Lisanslama konusu ne olacak—herhangi bir özel fontu kısıtlama olmadan gömebilir miyim?**  
Font lisans uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişebilir; bazı lisanslar gömme veya ticari kullanımını yasaklayabilir. Çıktıları dağıtmadan önce fontun EULA’sını her zaman gözden geçirin.