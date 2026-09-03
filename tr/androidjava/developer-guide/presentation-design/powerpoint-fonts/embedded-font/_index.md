---
title: Android'de Sunumlarda Yazı Tipi Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/androidjava/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömmesi
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint’te gömülü yazı tiplerini yönetin. Yazı tiplerini ekleyin, alın, kaldırın ve sıkıştırın; metin görünümünü koruyun ve dosya boyutunu azaltın."
---
## **Giriş**

Gömülü yazı tipleri, yazı tipi verilerini bir PowerPoint sunumunun içinde depolar. Bir görüntüleyici gömülü yazı tiplerini destekliyorsa, bu yazı tipleri hedef sistemde yüklü olmasa bile metni o yazı tipleriyle gösterebilir. Bu, satır sonları, metin boşlukları ve slayt düzeninin korunmasına yardımcı olur.

Aspose.Slides for Android via Java, [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getFontsManager--) yöntemiyle dönen [IFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/) arayüzü üzerinden gömülü yazı tiplerini almanıza, eklemenize ve kaldırmanıza olanak tanır. Ayrıca sunumun kullanmadığı karakterleri kaldırarak gömülü yazı tipi verilerinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir yazı tipi gömmeden önce, yazı tipi verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansının gömmeye izin verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Alma ve Kaldırma**

Sunumda saklanan yazı tiplerini listelemek için [getEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) yöntemini kullanın. Birini kaldırmak için listeden bir yazı tipini alıp [removeEmbeddedFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) yöntemine gönderin, ardından sunumu kaydedin.

Aşağıdaki örnek `EmbeddedFonts.pptx` dosyasındaki gömülü yazı tiplerini listeler ve Calibri mevcutsa kaldırır:

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

Bir gömülü yazı tipinin kaldırılması, saklanan yazı tipi verisini siler; metne atanmış yazı tipini değiştirmez. Yazı tipi hedef sistemde yüklüyse, metin hâlâ onu kullanabilir. Aksi takdirde, renderlama [font substitution](/slides/tr/androidjava/font-substitution/) gerektirebilir ve bu da düzeni etkileyebilir.

## **Yazı Tipi Verisini ve Gömme İzinlerini İnceleme**

Gömmeden önce yazı tiplerini incelemek için [IFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/) arayüzünü kullanın. Sunumda kullanılan yazı tiplerini almak için [IFontsManager.getFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) yöntemini çağırın. Her yazı tipi için bir [IFontData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontdata/) nesnesi ve gerekli [FontStyleType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontstyletype/) değerini [IFontsManager.getFontBytes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) yöntemine gönderin. Yöntem, ilgili yazı tipi stilinin ikili verisini döndürür; istenen yazı tipi veya stil bulunamazsa `null` döner. `null` sonucu [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) yöntemine göndermeyin, çünkü bu yöntem bir bayt dizisi bekler.

[EmbeddingLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/embeddinglevel/) yazı tipinde saklanan gömme kısıtlamalarını raporlayan bir bayrak enum’ıdır:

- `Installable` gömmeye ve başka bir sisteme kalıcı kurulum izni verir; bu, yazı tipi lisansına tabidir.
- `Restricted` yalnızca tek kullanım-izin bayrağı olduğunda, yazı tipinin yasal sahibinden izin alınmadıkça gömme yasaktır.
- `PreviewPrint` geçici olarak görüntüleme ve yazdırma izni verir; yazı tipini içeren belge yalnızca okuma izniyle açılmalıdır.
- `Editable` geçici kullanım izni verir ve belgenin düzenlenip kaydedilmesine izin verir.
- `NoSubsetting` yalnızca bir alt küme karakterin gömülmesini yasaklayan ek bir kısıtlamadır. Bu bayrak varsa tüm karakterler gömülmelidir.
- `BitmapOnly` yalnızca bitmap vuruşlarının gömülmesine izin veren ek bir kısıtlamadır; kontur verileri gömülemez. Yazı tipinde bitmap vuruş yoksa gömülemez.

İlk dört değer kullanım iznini tanımlar, `NoSubsetting` ve `BitmapOnly` bunlarla birlikte kullanılabilir. Modifikasyonları bit düzeyinde işlemlerle kontrol edin. `Installable` sıfır olduğu için kullanım-izin bitlerini maskeleyin ve sonucu `Installable` ile karşılaştırın; bayrak olarak kontrol etmeyin. Güncel yazı tipleri en fazla bir kullanım-izin biti ayarlamalıdır. Daha eski, birden fazla izin biti ayarlayan yazı tipleriyle uyumluluk sağlamak için aşağıdaki yardımcı, en az kısıtlayıcı izni seçer: önce `Editable`, ardından `PreviewPrint`, son olarak `Restricted`.

Aşağıdaki örnek, `getFonts` tarafından döndürülen her yazı tipi için normal, kalın, italik ve kalın‑italik verilerini denetler. Kullanılamayan stilleri, kısıtlı yazı tiplerini, yalnızca bitmap olanları, sadece ön izleme ve yazdırma izni verilen (çünkü çıktı hâlâ düzenlenebilir) ve zaten gömülü olanları atlar. Herhangi bir mevcut stil `NoSubsetting` içeriyorsa, o yazı tipi ailesi için tüm karakterler gömülür.

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

Bu inceleme, her yazı tipi dosyasında kodlanmış kısıtlamaları rapor eder. Lisans vermez, yazı tipini yasal olarak elde ettiğinizi kanıtlamaz ve gömülü bir kopyayı dağıtmadan önce lisans anlaşmasını kontrol etmenizin yerini tutmaz.

## **Gömülü Yazı Tipi Ekleme**

Bir yazı tipini gömmek için [addEmbeddedFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) yöntemini kullanın. Aşırı yüklemeleri, bir [IFontData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontdata/) nesnesi ya da yazı tipi verisini içeren bir bayt dizisi alabilir. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/embedfontcharacters/) enum’ı, hangi karakterlerin dahil edileceğini kontrol eder:

- [All](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/embedfontcharacters/) yazı tipindeki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin eklemesi gerekiyorsa bu seçeneği kullanın.
- [OnlyUsed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/embedfontcharacters/) yalnızca sunumda kullanılan karakterleri gömer ve dosya boyutunu azaltır. Tamamlanmış ve öncelikle görüntülenmesi amaçlanan bir sunum için bu seçeneği tercih edin.

Aşağıdaki örnek, `Fonts.pptx` içinde kullanılan yazı tiplerini almak için [getFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) yöntemini kullanır ve hâlâ gömülmemiş olanları gömer. Eklenmesi gereken yazı tipleri Android cihazında bulunmalı veya Aspose.Slides ile kayıtlı olmalıdır. Mevcut gömülü yazı tipleri karakter setlerini korur.

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

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) yöntemi, kullanılmayan karakterleri kaldırarak gömülü yazı tipi verilerini küçültür. Zaten gömülü olan yazı tipleri üzerinde çalışır; bu nedenle boyut azalması, sunumun ne kadar kullanılmayan yazı tipi verisi içerdiğine bağlıdır.

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

Alıcıların daha sonra metin eklemesi gerekebileceği durumlarda orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, gömülü yazı tipinden artık erişilemez; baştan tüm karakterleri gömmüş olsanız bile.

## **SSS**

**Bir gömülü yazı tipinin renderlama sırasında hâlâ değiştirileceğini nasıl kontrol edebilirim?**

Sunumu renderladığınız ortamda [getSubstitutions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) yöntemini çağırarak Aspose.Slides’in hangi yazı tiplerini değiştireceğini görebilirsiniz. Ayrıca [font substitution](/slides/tr/androidjava/font-substitution/) ayarlarını ve [font fallback](/slides/tr/androidjava/fallback-font/) kurallarını kontrol edin. Fallback eksik karakterleri ele alır; bu nedenle bir yazı tipini gömmek, yazı tipinin kendisinde bulunmayan karakterleri çözmez.