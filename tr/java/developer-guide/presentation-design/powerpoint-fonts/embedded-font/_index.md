---
title: Java'da Sunumlarda Yazı Tiplerini Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/java/embedded-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint'te gömülü yazı tiplerini yönetin. Metin görünümünü korumak ve dosya boyutunu azaltmak için yazı tiplerini ekleyin, alın, kaldırın ve sıkıştırın."
---
## **Giriş**

Yazı tiplerini gömmek, yazı tipi verilerini bir PowerPoint sunumunun içinde depolar. Bir görüntüleyici gömülü yazı tiplerini desteklediğinde, hedef sistemde yüklü olmasa bile metni bu yazı tipleriyle görüntüleyebilir. Bu, satır kırılmalarını, metin aralığını ve slayt düzenini korumaya yardımcı olur.

Aspose.Slides for Java, [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getFontsManager--) tarafından döndürülen [IFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/) arayüzü üzerinden gömülü yazı tiplerini almanıza, eklemenize ve kaldırmanıza olanak tanır. Ayrıca, sunumun kullanmadığı karakterleri kaldırarak gömülü yazı tipi verisinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir yazı tipini gömmeden önce, yazı tipi verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansının gömmeye izin verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

[ getEmbeddedFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) kullanarak bir sunumda depolanan yazı tiplerini listeleyin. Birini kaldırmak için, listeden bir yazı tipini [removeEmbeddedFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) metoduna iletin ve ardından sunumu kaydedin.

Aşağıdaki örnek, `EmbeddedFonts.pptx` dosyasındaki gömülü yazı tiplerini listeler ve Calibri mevcutsa kaldırır:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Bir gömülü yazı tipini kaldırmak, onun depolanmış veri setini siler; metnin atadığı yazı tipini değiştirmez. Yazı tipi hedef sistemde kuruluysa, metin hâlâ bu yazı tipini kullanabilir. Aksi takdirde, render sırasında [font substitution](/slides/tr/java/font-substitution/) gerçekleşebilir ve bu da düzeni etkileyebilir.

## **Yazı Tipi Verisini ve Gömme İzinlerini İnceleme**

Gömmeden önce yazı tiplerini incelemek için [IFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/) arayüzünü kullanın. Sunumda kullanılan yazı tiplerini almak için [IFontsManager.getFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getFonts--) metodunu çağırın. Her yazı tipi için bir [IFontData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontdata/) nesnesi ve gereken [FontStyleType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontstyletype/) değerini [IFontsManager.getFontBytes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) metoduna iletin. Metod, ilgili yazı tipi stilinin ikili verisini döndürür; istenen yazı tipi veya stil mevcut değilse `null` döner. `null` sonucu [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) metoduna geçirmeyin, çünkü bu metod bir bayt dizisi bekler.

[EmbeddingLevel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/embeddinglevel/) gömme kısıtlamalarını raporlayan bir bayrak (flags) enum’udur:

- `Installable` gömülmeye ve başka bir sistemde kalıcı kuruluma izin verir; bu, yazı tipi lisansına tabidir.
- `Restricted` yalnızca tek kullanım‑izin bayrağı olduğunda, yasal sahibinden izin alınmadıkça gömme yapılmasını yasaklar.
- `PreviewPrint` geçici olarak görüntüleme ve yazdırma için kullanım izni verir; yazı tipini içeren belge yalnızca okuma‑yalnız (read‑only) olmalıdır.
- `Editable` geçici kullanım izni verir ve belgenin düzenlenip kaydedilmesine izin tanır.
- `NoSubsetting` sadece bir alt küme (subsetting) gömme yapılmasını yasaklayan ek bir kısıtlamadır. Bu bayrak varsa tüm karakterler gömülmelidir.
- `BitmapOnly` sadece bitmap darbeleri (bitmap strikes) gömülmesine izin veren ek bir kısıtlamadır; kontur (outline) verisi gömülemez. Yazı tipinin bitmap darbeleri yoksa gömülemez.

İlk dört değer kullanım iznini tanımlarken, `NoSubsetting` ve `BitmapOnly` bu izinlerle birleştirilebilir. Bayrakları bit‑düzeyi (bitwise) işlemlerle kontrol edin. `Installable` değeri sıfır olduğundan, kullanım‑izin bitlerini maskeleyip sonuçları `Installable` ile karşılaştırın; doğrudan bir bayrak olarak kontrol etmeyin. Güncel yazı tipleri en fazla bir kullanım‑izin bayrağı ayarlamalıdır. Birden fazla ayarlayan eski yazı tipleriyle uyumluluk için aşağıdaki yardımcı, en az kısıtlayıcı izni seçer: `Editable`, ardından `PreviewPrint`, ardından `Restricted`.

Aşağıdaki örnek, `getFonts` tarafından döndürülen her yazı tipinin normal, kalın, italik ve kalın‑italik verilerini denetler. Kullanılamayan stilleri, kısıtlı yazı tiplerini, yalnızca bitmap‑only yazı tiplerini, sadece ön izleme‑yazdırma izinli (çünkü çıktı hâlâ düzenlenebilir) yazı tiplerini ve zaten gömülü olanları atlar. Herhangi bir kullanılabilir stil `NoSubsetting` içeriyorsa, o yazı tipi ailesi için tüm karakterler gömülür.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu denetim, her bir yazı tipi dosyasına kodlanmış kısıtlamaları raporlar. Lisans vermek, yazı tipini yasal olarak temin ettiğinizi kanıtlamak ya da gömülü bir kopyayı dağıtmadan önce lisans sözleşmesini kontrol etmek yerine kullanılmaz.

## **Gömülü Yazı Tipi Ekleme**

[addEmbeddedFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) metodunu kullanarak bir yazı tipini gömebilirsiniz. Aşırı yüklemeleri (overloads) ya bir [IFontData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontdata/) nesnesi ya da yazı tipi verisini içeren bir bayt dizisi kabul eder. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/java/com.aspose.slides/embedfontcharacters/) enum’u, hangi karakterlerin dahil edileceğini kontrol eder:

- [All](https://reference.aspose.com/slides/tr/java/com.aspose.slides/embedfontcharacters/) yazı tipindeki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin eklemesi gerektiğinde bu seçeneği kullanın.
- [OnlyUsed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/embedfontcharacters/) sunumda kullanılan karakterleri yalnızca gömer; dosya boyutunu azaltır. Sunum esas olarak görüntülenmek üzere tamamlandıysa bu seçeneği tercih edin.

Aşağıdaki örnek, `Fonts.pptx` dosyasında kullanılan yazı tiplerini almak için [getFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getFonts--) metodunu çağırır ve hâlâ gömülü olmayanları gömer. Eklenmesi gereken yazı tiplerinin kodun çalıştığı makinede mevcut olması gerekir. Mevcut gömülü yazı tipleri mevcut karakter setlerini korur.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gömülü Yazı Tiplerini Sıkıştırma**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) metoduyla kullanılmayan karakterleri kaldırarak gömülü yazı tipi verisini küçültebilirsiniz. Metod, zaten gömülü olan yazı tipleri üzerinde çalışır; bu yüzden boyut düşüşü, sunumda ne kadar kullanılmayan yazı tipi verisi bulunduğuna bağlıdır.

Aşağıdaki örnek, `EmbeddedFonts.pptx` dosyasındaki yazı tiplerini sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alıcıların ileride metin eklemesi gerekebileceği durumlarda orijinal dosyayı tutun. Sıkıştırma sırasında kaldırılan karakterler, gömülü yazı tipinden artık erişilemez; başlangıçta tüm karakterler gömülmüş olsa bile.

## **SSS**

**Gömülü bir yazı tipinin render sırasında hâlâ değiştirilip değiştirilmeyeceğini nasıl kontrol edebilirim?**

Sunumu render ettiğiniz ortamda [getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) metodunu çağırarak Aspose.Slides’ın hangi yazı tiplerini değiştireceğini görebilirsiniz. Ayrıca [font substitution](/slides/tr/java/font-substitution/) ayarlarını ve [font fallback](/slides/tr/java/fallback-font/) kurallarını kontrol edin. Fallback, eksik karakterleri ele alır; bu yüzden bir yazı tipini gömmek, o yazı tipinin içermediği karakterleri çözmez.

**Arial ve Calibri gibi yaygın yazı tiplerini gömmeli miyim?**

Karar, hedef ortamına göre verilmelidir. Gerekli yazı tipleri, sunumu açan veya render eden her makinede mevcutsa, gömmek gereksiz dosya büyüklüğü ekler. Alıcıların veya sunucuların bu yazı tiplerine sahip olmama ihtimali varsa, lisansları izin veriyorsa gömmek görünümün korunmasına yardımcı olur.