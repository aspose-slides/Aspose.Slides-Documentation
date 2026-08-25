---
title: Java'da Betik‑Özelliği Tema Yazı Tiplerini Yönet
linktitle: Betik‑Özelliği Tema Yazı Tipleri
type: docs
weight: 15
url: /tr/java/script-specific-font-mappings/
keywords:
- betik‑özelliği yazı tipi
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint temalarında betik‑özelliği yazı tipi eşlemelerini inceleyin, ekleyin, değiştirin ve kaldırın."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi aileleri seçebilir. Bu, temanın yazı tiplerini kullanan çok dilli metnin, Kiril, Arapça, Japonca, Gürcüce, Thaana ve diğer yazı sistemleri için uygun yazı tiplerini kullanırken uyumlu bir yazı tipi şemasını izlemesini sağlar.

Temanın [IFontScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/) içinde genellikle başlıklar için kullanılan büyük bir yazı tipi koleksiyonu ve genellikle gövde metni için kullanılan küçük bir yazı tipi koleksiyonu bulunur. Latin ve Doğu Asya yazı tipi ayarlarının yanı sıra, her iki koleksiyon da [IFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifonts/) arayüzü aracılığıyla yazı sistemi etiketlerinden yazı tipi aile adlarına eşlemeler sunar.

Bu makale, sunumun ana temasındaki bu eşlemelerin nasıl inceleneceğini ve değiştirileceğini ve değişikliklerin kaydetme‑yeniden yükleme döngüsünde kalıcı olduğunu nasıl doğrulayacağınızı gösterir.

## **Betik Etiketlerini Anlamak**

Betik yazı tipi yöntemleri, yazı sistemlerini tanımlamak için dört harflik BCP 47 betik alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Betik etiketi | Yazı sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arapça |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcüce |
| `Thaa` | Thaana |

Bu eşlemeler tema yazı tipi şemasına aittir, bireysel metin bölümlerine değil. Bir sunum, büyük ve küçük koleksiyonlar için farklı eşlemeler tanımlayabilir ve bazı betikler için eşlemeleri atlayabilir.

## **Betik Yazı Tipi Eşlemelerine Erişme ve İnceleme**

Sunum seviyesindeki temaya erişmek için [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getMasterTheme--) kullanın. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/#getMajor--) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/#getMinor--) yöntemleri iki [IFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifonts/) koleksiyonunu döndürür.

[IFonts.getScriptFontMap](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fonts/#getScriptFontMap--) çağırarak bir koleksiyondaki tüm eşlemeleri alın. Tek bir yazı sistemi aramak için, betik etiketiyle [IFonts.getScriptFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) çağırın. `getScriptFont` istenen eşlemeyi tanımlamayan koleksiyon için `null` döndürür.

## **Eşlemeleri Değiştir ve Kalıcılığı Doğrula**

[IFonts.setScriptFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) kullanarak bir eşleme oluşturabilir veya mevcut yazı tipi ailesini değiştirebilirsiniz. Bir eşlemeyi kaldırmak için [IFonts.removeScriptFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) kullanın.

Aşağıdaki uçtan uca örnek, mevcut tüm büyük ve küçük eşlemeleri okur, Japonca büyük yazı tipini araştırır, Kiril büyük yazı tipini değiştirir, Thaana küçük eşlemesini kaldırır, sunumu kaydeder ve her iki değişikliği doğrulamak için yeniden açar. Kaldırma adımını başlangıç temasından bağımsız yapmak için örnek, zaten tanımlı değilse önce bir Thaana eşlemesi oluşturur.

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

Doğrulama, sıradan bir arama gibi aynı `null` davranışını kullanır: kaldırma kaydedildikten sonra, `getScriptFont("Thaa")` küçük koleksiyon için `null` döndürür.

## **Tema Eşlemelerini Diğer Yazı Tipi Ayarlarından Ayırma**

Betik‑özelliği tema eşlemeleri, yazı tipi seçiminde yer alır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüşten farklı bir sorunu çözer:

| Mekanizma | Amaç | Tema eşlemesinin değiştirilmesinin etkisi |
|---|---|---|
| Betik‑özelliği tema yazı tipi eşlemesi | Bir yazı sistemi için büyük veya küçük tema yazı tipini seçer. | İlgili tema yazı tipini yine kullanan metin, yeni eşlenen aileye çözülebilir. |
| Metin bölümüne açıkça atanan yazı tipi | Temaya dayanmak yerine, o bölümde istenen yazı tipi ailesini sabitler. | Bölüm, doğrudan biçimlendirmesi temanın seçimini geçersiz kıldığından değişmeden kalabilir. |
| Yazı tipi ikamesi | İstenen yazı tipi mevcut olmadığında veya bir ikame kuralı uygulandığında yazı tipini değiştirir. | Yazı tipi istendiğinden sonra devreye girer; temanın betik eşlemesini yeniden tanımlamaz. |
| Yazı tipi geri dönüşü | Seçilen yazı tipinin içermediği glifleri, genellikle belirli Unicode aralıkları için sağlar. | Eksik glif kapsamını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/java/font-substitution/) ve [Fallback Fonts](/slides/tr/java/fallback-font/) sayfalarına bakın.

[Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getMasterTheme--) içinde bir eşlemenin değiştirilmesi, yalnızca etkili biçimlendirmesi hâlâ o temeye bağlı olan içeriği etkiler. Metin, bir ana, yerleşim veya slayttan tema geçersiz kılmasını devralabilir ya da açıkça atanmış bir yazı tipi kullanabilir. Görünür sonuç sunum‑seviyesi eşlemeyi takip etmediğinde bu seviyeleri inceleyin.

## **Eşlenen Yazı Tiplerini Kullanılabilir Hale Getir ve Sonucu Doğrula**

Bir betik eşlemesi sadece bir yazı tipi ailesi adını saklar; karşılık gelen yazı tipi dosyasını kurmaz veya yüklemez. Tutarlı renderleme ve dışa aktarma için, her eşlenen yazı tipi ortamda kurulmuş olmalı veya Aspose.Slides'e [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) veya [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) gibi özelleştirilmiş bir kaynak aracılığıyla sağlanmalıdır. Mevcut yükleme seçenekleri için [Custom Fonts](/slides/tr/java/custom-font/) sayfasına bakın.

Kaydedilen eşlemenin doğrulanması yalnızca tema tanımının korunduğunu onaylar. Yazı tipinin kullanılabilir olduğunu, gerekli tüm glifleri içerdiğini veya istenen düzeni ürettiğini göstermez. Her gerekli yazı sistemi için temsilci bir metni görüntü veya PDF olarak renderleyin ve çıktıyı inceleyin. Bu, eksik yazı tiplerini, eksik glif kapsamını, geri dönüş davranışını ve sunum dağıtılmadan önceki düzen değişikliklerini yakalar. Renderleme ve dışa aktarma örnekleri için [Convert PowerPoint Presentations](/slides/tr/java/convert-powerpoint/) sayfasına bakın.

## **SSS**

**Bir betik eşlenmediğinde `getScriptFont` ne döndürür?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) istenen betik eşlemesi o büyük veya küçük yazı tipi koleksiyonunda tanımlı değilse `null` döndürür.

**`setScriptFont` betik zaten mevcut olduğunda ikinci bir eşleme ekler mi?**

Hayır. [IFonts.setScriptFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) eksik olduğunda eşlemeyi oluşturur ve aynı betik etiketi zaten varsa eşlenen yazı tipi ailesini değiştirir.

**Neden bir tema eşlemesini değiştirmek bazı metinleri etkilemedi?**

Metin açıkça atanmış bir yazı tipine sahip olabilir, bir geçersiz kılma yoluyla farklı bir temayı devralabilir veya renderleme sırasında ikame veya geri dönüşten etkilenebilir. Sunum‑seviyesi betik eşlemesi yalnızca etkili biçimlendirmesi hâlâ o tema yazı tipi koleksiyonuna başvuran metni kontrol eder.

**Kaydetmek ve yeniden açmak çok dilli çıktıyı doğrulamak için yeterli mi?**

Hayır. Yeniden açmak tema verisinin kalıcılığını doğrular. Ayrıca, her gerekli yazı sisteminden temsilci bir metni renderleyerek eşlenen yazı tiplerinin kullanılabilir olduğunu ve gerekli glifleri içerdiğini doğrulamalısınız.