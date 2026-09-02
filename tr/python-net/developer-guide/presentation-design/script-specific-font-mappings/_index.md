---
title: Python'da Betik-Özgü Tema Yazı Tiplerini Yönet
linktitle: Betik-Özgü Tema Yazı Tipleri
type: docs
weight: 15
url: /tr/python-net/script-specific-font-mappings/
keywords:
- betik-özgü yazı tipi
- tema yazı tipi eşlemesi
- çok dilli sunum
- yazı sistemi
- Kiril yazı tipi
- Arap yazı tipi
- Japon yazı tipi
- Gürcü yazı tipi
- Thaana yazı tipi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "PowerPoint temalarında betik-özgü yazı tipi eşlemelerini inceleyin, ekleyin, değiştirin ve kaldırın; Aspose.Slides for Python via .NET kullanarak."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi aileleri seçebilir. Bu, temanın yazı tiplerini kullanan çok dilli metnin, Kiril, Arap, Japon, Gürcü, Thaana ve diğer betimler için uygun yazı tiplerini kullanırken tek bir koordineli yazı tipi şemasını takip etmesini sağlar.

Temanın [FontScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/) öğesi, genellikle başlıklar için kullanılan bir ana yazı tipi koleksiyonu ve genellikle gövde metni için kullanılan bir ikincil yazı tipi koleksiyonu içerir. Latin ve Doğu Asya yazı tipi özelliklerine ek olarak, her iki koleksiyon da [Fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/) sınıfı aracılığıyla yazı sistemi etiketlerinden yazı tipi aile adlarına eşlemeler sunar.

Bu makale, sunumun ana temasındaki bu eşlemeleri nasıl inceleyeceğinizi ve değiştireceğinizi, ardından değişikliklerin kaydetme‑yeniden‑yükleme döngüsünden sonra da korunduğunu nasıl doğrulayacağınızı gösterir.

## **Betik Etiketlerini Anlamak**

Betik yazı tipi yöntemleri, yazı sistemlerini tanımlamak için dört harfli BCP 47 betik alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Betik etiketi | Yazı sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arap |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcü |
| `Thaa` | Thaana |

Bu eşlemeler tema yazı tipi şemasına aittir, tek tek metin bölümlerine değil. Bir sunum, ana ve ikincil koleksiyonlar için farklı eşlemeler tanımlayabilir ve bazı betikler için eşlemeleri atlayabilir.

## **Betik Yazı Tipi Eşlemelerine Erişme ve İnceleme**

[Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) kullanarak sunum seviyesindeki temaya erişin. [FontScheme.major](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.minor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/minor/) özellikleri iki [Fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/) koleksiyonunu döndürür.

[Fonts.get_script_font_map](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/get_script_font_map/) metodunu çağırarak bir koleksiyondaki tüm eşlemeleri alın. Tek bir yazı sistemini bulmak için, betik etiketiyle [Fonts.get_script_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/get_script_font/) metodunu çağırın. `get_script_font` istenen eşleme tanımlı değilse `None` döndürür.

## **Eşlemeleri Değiştir ve Kalıcılığı Doğrula**

[Fonts.set_script_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/set_script_font/) kullanarak bir eşleme oluşturabilir veya mevcut yazı tipi ailesini değiştirebilirsiniz. Bir eşlemeyi kaldırmak için [Fonts.remove_script_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/remove_script_font/) kullanın.

Aşağıdaki uçtan uca örnek, mevcut tüm ana ve ikincil eşlemeleri okur, Japonca ana yazı tipini bulur, Kiril ana yazı tipini değiştirir, Thaana ikincil eşlemeyi kaldırır, sunumu kaydeder ve her iki değişikliği doğrulamak için yeniden açar. Kaldırma adımını başlangıç temasından bağımsız kılmak için örnek, yalnızca bir Thaana eşlemesi tanımlı değilse bir Thaana eşlemesi oluşturur.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Doğrulama, normal bir arama gibi aynı `None` davranışını kullanır: kaldırma kaydedildikten sonra, `get_script_font("Thaa")` ikincil koleksiyon için `None` döndürür.

## **Tema Eşlemelerini Diğer Yazı Tipi Ayarlarından Ayırma**

Betik‑özgü tema eşlemeleri, yazı tipi seçimine katılır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüşten farklı bir sorunu çözer:

| Mekanizma | Amaç | Tema eşlemesini değiştirdiğinizdeki etkisi |
|---|---|---|
| Betik‑özgü tema yazı tipi eşlemesi | Bir yazı sistemi için ana ya da ikincil tema yazı tipini seçer. | İlgili tema yazı tipini kullanan metin, yeni eşlenen aileye yönlendirilebilir. |
| Metin bölümüne açıkça atanan yazı tipi | Tema yerine o bölüme talep edilen yazı tipi ailesini sabitler. | Doğrudan biçimlendirme tema seçimini geçersiz kıldığı için bölüm değişmeden kalabilir. |
| Yazı tipi ikamesi | Talep edilen yazı tipi mevcut olmadığında veya bir ikame kuralı uygulandığında onu değiştirir. | Yazı tipi istendikten sonra devreye girer; tema betik eşlemesini yeniden tanımlamaz. |
| Yazı tipi geri dönüşü | Seçilen yazı tipinin içermediği glifleri, genellikle belirli Unicode aralıkları için sağlar. | Eksik glif kapsamını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/python-net/font-substitution/) ve [Fallback Fonts](/slides/tr/python-net/fallback-font/) sayfalarına bakın.

[Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) içinde bir eşleme değiştirmek, yalnızca etkili biçimlendirmesi hâlâ o temaya bağlı olan içeriği etkiler. Metin, bir ana, yerleşim veya slayttan gelen tema geçersiz kılmasını miras alabilir ya da açıkça atanmış bir yazı tipi kullanabilir. Görünür sonuç sunum‑seviyesi eşlemeyi izlemediğinde bu seviyeleri inceleyin.

## **Eşlenen Yazı Tiplerini Kullanılabilir Hale Getir ve Sonucu Doğrula**

Bir betik eşlemesi, bir yazı tipi aile adını saklar; ilgili yazı tipi dosyasını kurmaz ya da yüklemez. Tutarlı görüntüleme ve dışa aktarma için, her eşlenen yazı tipinin ortamda kurulu olması veya Aspose.Slides'e [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/load_external_fonts/) ya da [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/document_level_font_sources/) gibi özel bir kaynak aracılığıyla sağlanması gerekir. Kullanılabilir yükleme seçenekleri için [Custom Fonts](/slides/tr/python-net/custom-font/) sayfasına bakın.

Kaydedilen eşlemeyi doğrulamak yalnızca tema tanımının korunduğunu onaylar. Yazı tipinin kullanılabilir olduğunu, gerekli tüm glifleri içerdiğini ya da istenen yerleşimi ürettiğini kanıtlamaz. Her gerekli yazı sistemi için temsilci metni bir görüntüye veya PDF'e renderleyin ve çıktıyı inceleyin. Bu, eksik yazı tiplerini, eksik glif kapsamını, geri dönüş davranışını ve sunum dağıtılmadan önceki yerleşim değişikliklerini yakalar. Görüntüleme ve dışa aktarma örnekleri için [Convert PowerPoint Presentations](/slides/tr/python-net/convert-powerpoint/) sayfasına bakın.

## **SSS**

**Bir betik eşlenmediğinde `get_script_font` ne döndürür?**  
[Fonts.get_script_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/get_script_font/) , istenen betik eşlemesi o ana ya da ikincil yazı tipi koleksiyonunda tanımlı değilse `None` döndürür.

**Betik zaten mevcut olduğunda `set_script_font` ikinci bir eşleme ekler mi?**  
Hayır. [Fonts.set_script_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fonts/set_script_font/) eşleme eksik olduğunda oluşturur ve aynı betik etiketi zaten mevcutsa eşlenen yazı tipi ailesini değiştirir.

**Tema eşlemesini değiştirmek neden bazı metinlerde değişiklik yapmadı?**  
Metin açıkça atanmış bir yazı tipi taşıyor olabilir, bir geçersiz kılma aracılığıyla farklı bir temayı devralıyor olabilir veya renderleme sırasında ikame ya da geri dönüşten etkileniyor olabilir. Sunum‑seviyesi betik eşlemesi, yalnızca etkili biçimlendirmesi hâlâ o tema yazı tipi koleksiyonuna referans veren metni kontrol eder.

**Kaydedip yeniden açmak çok dilli çıktıyı doğrulamak için yeterli mi?**  
Hayır. Yeniden açmak tema verilerinin kalıcılığını doğrular. Ayrıca, her gerekli yazı sisteminden temsilci metni renderleyerek eşlenen yazı tiplerinin mevcut olduğunu ve gerekli glifleri içerdiğini onaylayın.