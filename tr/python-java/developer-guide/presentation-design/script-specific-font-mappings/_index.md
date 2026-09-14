---
title: Python üzerinden Java ile Script'e Özgü Tema Yazı Tiplerini Yönet
linktitle: Script'e Özgü Tema Yazı Tipleri
type: docs
weight: 15
url: /tr/python-java/script-specific-font-mappings/
keywords:
- script'e özgü yazı tipi
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
- Java
- Aspose.Slides
description: "PowerPoint temalarında script'e özgü yazı tipi eşlemelerini inceleyin, ekleyin, değiştirin ve kaldırın; Aspose.Slides for Python via Java ile."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi aileleri seçebilir. Bu, temada tanımlı yazı tiplerini kullanan çok dilli metnin, Kiril, Arap, Japon, Gürcü, Thaana ve diğer betikler için uygun yazı tiplerini kullanırken tek bir koordineli yazı tipi şeması izleyebilmesini sağlar.

Temanın [FontScheme](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontscheme/) içinde genellikle başlıklar için kullanılan bir major (büyük) yazı tipi koleksiyonu ve genellikle gövde metni için kullanılan bir minor (küçük) yazı tipi koleksiyonu bulunur. Hem Latin hem de Doğu Asya yazı tipi ayarlarının yanı sıra, her iki koleksiyon da [Fonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fonts/) sınıfı aracılığıyla yazı sistemi etiketlerinden yazı tipi ailesi adlarına eşlemeler sunar.

Bu makale, sunumun ana temasındaki bu eşlemeleri nasıl inceleyeceğinizi ve değiştireceğinizi ve değişikliklerin bir kaydet‑meve‑yeniden‑yükleme döngüsünde korunup korunmadığını nasıl doğrulayacağınızı gösterir.

## **Script Etiketlerini Anlamak**

Script yazı tipi yöntemleri, yazı sistemlerini tanımlamak için dört harfli BCP 47 script alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Script etiketi | Yazı sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arap |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcüce |
| `Thaa` | Thaana |

Bu eşlemeler tema yazı tipi şemasına aittir, bireysel metin bölümlerine değil. Bir sunum, major ve minor koleksiyonlar için farklı eşlemeler tanımlayabilir ve bazı scriptler için eşlemeleri atlayabilir.

## **Script Yazı Tipi Eşlemelerine Erişim ve İnceleme**

Sunum seviyesindeki temaya erişmek için [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasterTheme) kullanın. [FontScheme.getMajor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontscheme/#getMajor) ve [FontScheme.getMinor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontscheme/#getMinor) yöntemleri iki [Fonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fonts/) koleksiyonunu döndürür.

`Fonts.getScriptFontMap` metodunu çağırarak bir koleksiyondaki tüm eşlemeleri alabilirsiniz. Tek bir yazı sistemini bulmak için `Fonts.getScriptFont` metodunu script etiketiyle çağırın. `getScriptFont`, ilgili koleksiyon istenen eşlemeyi tanımlamıyorsa `None` döndürür.

## **Eşlemeleri Değiştir ve Kalıcılığı Doğrula**

`Fonts.setScriptFont` metodunu kullanarak bir eşleme oluşturabilir veya mevcut yazı tipi ailesini değiştirebilirsiniz. Bir eşlemeyi kaldırmak için `Fonts.removeScriptFont` metodunu kullanın.

Aşağıdaki uçtan‑uca örnek, mevcut tüm major ve minor eşlemeleri okur, Japon major yazı tipini bulur, Kiril major yazı tipini değiştirir, Thaana minor eşlemesini kaldırır, sunumu kaydeder ve her iki değişikliği doğrulamak için yeniden açar. Kaldırma adımının ilk temadan bağımsız olmasını sağlamak için örnek, bir Thaana eşlemesi zaten tanımlı değilse önce bir Thaana eşlemesi oluşturur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Doğrulama, normal bir arama gibi aynı `None` davranışını kullanır: kaldırma kaydedildikten sonra, `getScriptFont("Thaa")` minor koleksiyon için `None` döndürür.

## **Tema Eşlemelerini Diğer Yazı Tipi Ayarlarından Ayır**

Script'e özgü tema eşlemeleri, yazı tipi seçiminde yer alır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüş gibi farklı bir sorunu çözer:

| Mekanizma | Amaç | Tema eşlemesinin değiştirilmesinin etkisi |
|---|---|---|
| Script'e özgü tema yazı tipi eşlemesi | Bir yazı sistemi için büyük veya küçük tema yazı tipini seçer. | İlgili tema yazı tipini hâlâ kullanan metin, yeni eşlenen aileye yönlendirilebilir. |
| Metin bölümüne açıkça atanmış yazı tipi | Tema yerine, istenen yazı tipi ailesini o bölüme sabitler. | Bölüm, doğrudan biçimlendirmesi temanın seçimini geçersiz kıldığı için değişmemiş kalabilir. |
| Yazı tipi ikamesi | İstenen yazı tipi mevcut olmadığında veya bir ikame kuralı uygulandığında onu değiştirir. | Yazı tipi istendikten sonra devreye girer; temanın script eşlemesini yeniden tanımlamaz. |
| Yazı tipi geri dönüşü | Seçilen yazı tipinde bulunmayan glifleri, genellikle belirli Unicode aralıkları için sağlar. | Eksik glif kapsamasını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/python-java/font-substitution/) ve [Fallback Fonts](/slides/tr/python-java/fallback-font/) sayfalarına bakın.

[Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasterTheme) içinde bir eşleme değiştirildiğinde, yalnızca etkili biçimlendirmesi hâlâ o temeye bağlı olan içerik etkilenir. Metin, bir master, düzen veya slayttan bir tema geçersiz kılma miras alabilir ya da açıkça atanmış bir yazı tipi kullanabilir. Görünür sonuç sunum‑seviyesi eşlemeyi izlemiyorsa bu seviyeleri inceleyin.

## **Eşlenen Yazı Tiplerini Kullanılabilir Hale Getir ve Sonucu Doğrula**

Bir script eşlemesi yalnızca bir yazı tipi ailesi adını saklar; ilgili yazı tipi dosyasını kurmaz veya yüklemez. Tutarlı render ve dışa aktarma için, her eşlenen yazı tipinin ortamda kurulu olması ya da Aspose.Slides'e [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadExternalFonts) veya [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) gibi özel bir kaynak aracılığıyla sağlanması gerekir. Mevcut yükleme seçenekleri için [Custom Fonts](/slides/tr/python-java/custom-font/) sayfasına bakın.

Kaydedilen eşlemenin doğrulanması yalnızca tema tanımının korunduğunu teyit eder. Yazı tipinin mevcut olduğunu, tüm gerekli glifleri içerdiğini veya istenen düzeni ürettiğini kanıtlamaz. Her gerekli yazı sistemi için temsili bir metni görüntü ya da PDF olarak render edin ve çıktıyı inceleyin. Bu, eksik yazı tiplerini, eksik glif kapsamını, geri dönüş davranışını ve sunum dağıtılmadan önceki düzen değişikliklerini yakalar. Render ve dışa aktarım örnekleri için [Convert PowerPoint Presentations](/slides/tr/python-java/convert-powerpoint/) sayfasına bakın.

## **SSS**

**Bir script eşlenmediğinde `getScriptFont` ne döndürür?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fonts/#getScriptFont) istenen script eşlemesi major veya minor yazı tipi koleksiyonunda tanımlı değilse `None` döndürür.

**Script zaten mevcut olduğunda `setScriptFont` ikinci bir eşleme ekler mi?**

Hayır. [Fonts.setScriptFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fonts/#setScriptFont) eksik olduğunda eşlemeyi oluşturur ve aynı script etiketi zaten mevcutsa eşlenen yazı tipi ailesini değiştirir.

**Neden bir tema eşlemesi değiştirilmesine rağmen bazı metinler değişmedi?**

Metin, açıkça atanmış bir yazı tipine sahip olabilir, bir geçersiz kılma yoluyla farklı bir temayı miras alabilir veya render sırasında ikame ya da geri dönüşten etkileniyor olabilir. Sunum‑seviyesi script eşlemesi yalnızca etkili biçimlendirmesi hâlâ o tema yazı tipi koleksiyonuna referans veren metni kontrol eder.

**Kaydetmek ve yeniden açmak çok dilli çıktıyı doğrulamak için yeterli mi?**

Hayır. Yeniden açmak, tema verilerinin kalıcılığını doğrular. Ayrıca, her gerekli yazı sisteminden temsili bir metni render ederek eşlenen yazı tiplerinin mevcut olduğunu ve gerekli glifleri içerdiğini teyit edin.