---
title: Android'de Komut Dosyası-Özel Tema Yazı Tiplerini Yönet
linktitle: Komut Dosyası-Özel Tema Yazı Tipleri
type: docs
weight: 15
url: /tr/androidjava/script-specific-font-mappings/
keywords:
- komut dosyası-özel yazı tipi
- tema yazı tipi eşlemesi
- çok dilli sunum
- yazı sistemi
- Kiril yazı tipi
- Arapça yazı tipi
- Japonca yazı tipi
- Gürcüce yazı tipi
- Thaana yazı tipi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden PowerPoint temalarında komut dosyası-özel yazı tipi eşlemelerini inceleyin, ekleyin, değiştirin ve kaldırın."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi ailelerini seçebilir. Bu, tema yazı tiplerini kullanan çok dilli metnin, Kiril, Arapça, Japonca, Gürcüce, Thaana ve diğer yazı sistemleri için uygun yazı tiplerini kullanırken tek bir koordineli yazı tipi şemasını takip etmesini sağlar.

Temanın [IFontScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/) bir ana yazı tipi koleksiyonunu içerir; genellikle başlıklar için kullanılır ve bir yan yazı tipi koleksiyonunu; genellikle gövde metni için kullanılır. Latin ve Doğu Asya yazı tipi ayarlarına ek olarak, her iki koleksiyon da yazı sistemi etiketlerinden yazı tipi aile adlarına eşlemeleri [IFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifonts/) arayüzü aracılığıyla sunar.

Bu makale, sunumun ana temasındaki bu eşlemeleri nasıl inceleyeceğinizi ve değiştireceğinizi ve değişikliklerin kaydetme-ve-yeniden yükleme döngüsünden sonra da korunduğunu nasıl doğrulayacağınızı gösterir.

## **Yazı Sistemi Etiketlerini Anlamak**

Komut dosyası yazı tipi yöntemleri, yazı sistemlerini tanımlamak için dört harfli BCP 47 komut dosyası alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Komut Dosyası Etiketi | Yazı Sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arapça |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcüce |
| `Thaa` | Thaana |

Bu eşlemeler tema yazı tipi şemasına aittir, tek tek metin bölümlerine değil. Bir sunum, ana ve yan koleksiyonlar için farklı eşlemeler tanımlayabilir ve bazı yazı sistemleri için eşlemeleri atlayabilir.

## **Yazı Sistemi Yazı Tipi Eşlemelerine Erişme ve İnceleme**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getMasterTheme--) kullanarak sunum düzeyindeki temaya erişin. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/#getMajor--) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/#getMinor--) metodları iki [IFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifonts/) koleksiyonunu döndürür.

[IFonts.getScriptFontMap](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) çağırarak bir koleksiyondaki tüm eşlemeleri alın. Tek bir yazı sistemini aramak için, ilgili script etiketini kullanarak [IFonts.getScriptFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) çağırın. `getScriptFont` istenen eşleme o koleksiyonda tanımlı değilse `null` döndürür.

## **Eşlemeleri Değiştir ve Kalıcılığı Doğrula**

[IFonts.setScriptFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) kullanarak bir eşleme oluşturabilir veya mevcut yazı tipi ailesini değiştirebilirsiniz. [IFonts.removeScriptFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) kullanarak bir eşlemeyi kaldırabilirsiniz.

İşte aşağıdaki uçtan uca örnek, mevcut tüm ana ve yan eşlemeleri okur, Japonca ana yazı tipini bulur, Kiril ana yazı tipini değiştirir, Thaana yan eşlemesini kaldırır, sunumu kaydeder ve her iki değişikliği doğrulamak için yeniden açar. Kaldırma adımını başlangıç temasından bağımsız kılmak için örnek, bir Thaana eşlemesi zaten tanımlı değilse önce bir Thaana eşlemesi oluşturur.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Doğrulama, normal bir arama gibi aynı `null` davranışını kullanır: kaldırma kaydedildikten sonra, `getScriptFont("Thaa")` yan koleksiyon için `null` döndürür.

## **Tema Eşlemelerini Diğer Yazı Tipi Ayarlarından Ayrımak**

Komut dosyası özel tema eşlemeleri yazı tipi seçiminde yer alır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüş gibi farklı bir sorunu çözer:

| Mekanizma | Amaç | Tema eşlemesinin değiştirilmesinin etkisi |
|---|---|---|
| Komut dosyası özel tema yazı tipi eşlemesi | Bir yazı sistemi için ana ya da yan tema yazı tipini seçer. | İlgili tema yazı tipini hâlâ kullanan metin, yeni eşlenen aileye yönlendirilebilir. |
| Metin bölümüne açıkça atanmış yazı tipi | Tema yerine o bölüme istenen yazı tipi ailesini sabitler. | Bölüm, doğrudan biçimlendirmesi temanın seçimini geçersiz kıldığı için değişmeden kalabilir. |
| Yazı tipi ikamesi | İstenen yazı tipi mevcut olmadığında veya bir ikame kuralı uygulandığında onu değiştirir. | Yazı tipi istendikten sonra devreye girer; temanın script eşlemesini yeniden tanımlamaz. |
| Yazı tipi geri dönüşü | Seçilen yazı tipinin içermediği, genellikle belirli Unicode aralıkları için glyph'leri sağlar. | Eksik glyph kapsamını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/androidjava/font-substitution/) ve [Fallback Fonts](/slides/tr/androidjava/fallback-font/) sayfalarına bakın.

[Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getMasterTheme--) içinde bir eşlemenin değiştirilmesi, yalnızca etkili biçimlendirmesi hâlâ o temaya bağlı olan içeriği etkiler. Metin, bir master, düzen veya slayttan tema geçersiz kılmasını devralabilir ya da açıkça atanmış bir yazı tipi kullanabilir. Görünür sonuç sunum düzeyindeki eşlemeyi takip etmediğinde bu seviyeleri inceleyin.

## **Eşlenen Yazı Tiplerini Kullanılabilir Hale Getir ve Sonucu Doğrula**

Bir script eşlemesi bir yazı tipi aile adını saklar; ilgili yazı tipi dosyasını kurmaz veya yüklemez. Tutarlı render ve dışa aktarma için, her eşlenen yazı tipinin ortamda kurulu olması ya da Aspose.Slides'e [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) veya [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) gibi özelleştirilmiş bir kaynak aracılığıyla sağlanması gerekir. Kullanılabilir yükleme seçenekleri için [Custom Fonts](/slides/tr/androidjava/custom-font/) sayfasına bakın.

Kayıtlı eşlemeyi doğrulamak yalnızca tema tanımının korunduğunu gösterir. Yazı tipinin mevcut olduğunu, gerekli tüm glyph'leri içerdiğini veya istenen düzeni ürettiğini kanıtlamaz. Her gerekli yazı sistemi için temsilci bir metni görüntü veya PDF olarak render edip çıktıyı inceleyin. Bu, eksik yazı tiplerini, yetersiz glyph kapsamını, geri dönüş davranışını ve sunum dağıtılmadan önceki düzen değişikliklerini yakalar. Render ve dışa aktarma örnekleri için [Convert PowerPoint Presentations](/slides/tr/androidjava/convert-powerpoint/) sayfasına bakın.

## **SSS**

**Bir script eşlenmediğinde `getScriptFont` ne döndürür?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) istenen script eşlemesi o ana ya da yan yazı tipi koleksiyonunda tanımlı olmadığında `null` döndürür.

**`setScriptFont` script zaten mevcutsa ikinci bir eşleme ekler mi?**

Hayır. [IFonts.setScriptFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) eksik olduğunda eşleme oluşturur ve aynı script etiketi zaten mevcutsa eşlenen yazı tipi ailesini değiştirir.

**Neden bir tema eşlemesinin değiştirilmesi bazı metinleri etkilemedi?**

Metin, açıkça atanmış bir yazı tipine sahip olabilir, bir geçersiz kılma yoluyla farklı bir temayı devralabilir veya render sırasında ikame ya da geri dönüşten etkilenebilir. Sunum düzeyindeki bir script eşlemesi, sadece etkili biçimlendirmesi hâlâ o tema yazı tipi koleksiyonuna başvuran metni kontrol eder.

**Kaydetmek ve yeniden açmak çok dilli çıktıyı doğrulamak için yeterli mi?**

Hayır. Yeniden açmak tema verisinin kalıcılığını doğrular. Ayrıca, her gerekli yazı sisteminden temsilci metni render ederek eşlenen yazı tiplerinin erişilebilir olduğunu ve gerekli glyph'leri içerdiğini doğrulamalısınız.