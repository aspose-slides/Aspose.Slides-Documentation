---
title: Vkládání fontů do prezentací v Androidu
linktitle: Vložené fonty
type: docs
weight: 40
url: /cs/androidjava/embedded-font/
keywords:
- přidat font
- vložit font
- vkládání fontu
- získat vložený font
- přidat vložený font
- odebrat vložený font
- komprimovat vložený font
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte vložené fonty v PowerPointu pomocí Aspose.Slides pro Android prostřednictvím Javy. Přidávejte, získávejte, odstraňujte a komprimujte fonty, abyste zachovali vzhled textu a snížili velikost souboru."
---
## **Úvod**

Vkládání fontů ukládá data fontu uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložené fonty, může zobrazovat text pomocí těchto fontů, i když nejsou nainstalovány na cílovém systému. To pomáhá zachovat zalomení řádků, mezery mezi textem a rozvržení snímků.

Aspose.Slides pro Android prostřednictvím Javy umožňuje získávat, přidávat a odstraňovat vložené fonty pomocí rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/) vráceného metodou [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getFontsManager--). Také můžete zmenšit velikost dat vložených fontů odstraněním znaků, které prezentace nepoužívá.

Níže uvedené příklady pracují se soubory PPTX. Před vložením fontu se ujistěte, že data fontu jsou k dispozici pro Aspose.Slides a že jeho licence umožňuje vkládání.

## **Získání a odebrání vložených fontů**

Pro výpis fontů uložených v prezentaci použijte [getEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--). Chcete‑li odebrat některý, předáte font z tohoto seznamu metodě [removeEmbeddedFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), a poté prezentaci uložíte.

Následující příklad vypíše vložené fonty v souboru `EmbeddedFonts.pptx` a odstraní Calibri, pokud je přítomen:

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

Odstranění vloženého fontu odstraní jeho uložená data fontu; nemění to font přiřazený textu. Pokud je font nainstalován v cílovém systému, může jej text stále používat. V opačném případě může při vykreslování být vyžadována [font substitution](/slides/cs/androidjava/font-substitution/), což může ovlivnit rozložení.

## **Kontrola dat fontu a oprávnění k vkládání**

Pro kontrolu fontů před jejich vložením použijte rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/). Zavolejte [IFontsManager.getFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) , abyste získali fonty použité v prezentaci. Pro každý font předáte objekt [IFontData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontstyletype/), metodě [IFontsManager.getFontBytes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Metoda vrací binární data pro daný styl fontu, nebo `null`, pokud požadovaný font či styl není k dispozici. Nepředávejte výsledek `null` metodě [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), protože tato metoda vyžaduje pole bytů.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/embeddinglevel/) je výčtová příznaková enumerace, která uvádí omezení vkládání uložená ve fontu:

- `Installable` umožňuje vkládání a trvalou instalaci na jiném systému, za předpokladu licence fontu.
- `Restricted` zakazuje vkládání, pokud není získáno povolení od právního vlastníka fontu, a to jen když je to jediný příznak oprávnění k používání.
- `PreviewPrint` povoluje dočasné použití pro prohlížení a tisk; dokument obsahující font musí být jen pro čtení.
- `Editable` povoluje dočasné použití a umožňuje dokument upravovat a ukládat.
- `NoSubsetting` je další omezení, které zakazuje vkládání pouze podmnožiny glifů. Když je tento příznak přítomen, vložte všechny znaky.
- `BitmapOnly` je další omezení, které umožňuje vložit jen bitmapové verze, nikoli obrysová data. Pokud font nemá bitmapové verze, nemůže být vložen.

Prvních čtyři hodnoty popisují oprávnění k používání, zatímco `NoSubsetting` a `BitmapOnly` lze s nimi kombinovat. Modifikátory kontrolujte pomocí bitových operací. Protože `Installable` má hodnotu nula, maskujte bity oprávnění k používání a porovnávejte výsledek s `Installable` místo kontrole jako příznaku. Aktuální fonty by měly nastavit nejvíce jeden bit oprávnění k používání. Pro kompatibilitu se staršími fonty, které nastaveny více než jeden bit, níže uvedený pomocník vybírá nejméně restriktivní oprávnění: `Editable`, pak `PreviewPrint`, pak `Restricted`.

Následující příklad prověří běžná, tučná, kurzívní a tučně‑kurzívní data dostupná pro každý font vrácený metodou `getFonts`. Přeskakuje nedostupné styly, omezené fonty, fonty pouze bitmapové, fonty omezené na náhled a tisk, protože výstup zůstává editovatelný, a také fonty, které jsou již vloženy. Pokud má kterýkoli dostupný styl příznak `NoSubsetting`, vloží všechny znaky pro tuto rodinu fontů.

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

Tato kontrola uvádí omezení zakódovaná v každém souboru fontu. Neposkytuje licenci, neprokazuje, že jste font získali legálně, ani nenahrazuje kontrolu licenční smlouvy fontu před distribucí vložené kopie.

## **Přidání vložených fontů**

Pro vložení fontu použijte [addEmbeddedFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-). Jeho přetížení přijímají buď objekt [IFontData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontdata/) , nebo pole bytů obsahující data fontu. Výčtová hodnota [EmbedFontCharacters](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/embedfontcharacters/) řídí, které znaky jsou zahrnuty:

- `All` vloží všechny znaky fontu. Tuto možnost použijte, když příjemci potřebují prezentaci upravovat a zadávat nový text.
- `OnlyUsed` vloží jen znaky použité v prezentaci, čímž se sníží velikost souboru. Zvolte tuto možnost pro hotovou prezentaci, která je převážně určena k prohlížení.

Následující příklad použije [getFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) , aby získal fonty použité v souboru `Fonts.pptx`, a vloží ty, které ještě nejsou vloženy. Fonty k přidání musí být dostupné na zařízení Android nebo zaregistrované v Aspose.Slides. Existující vložené fonty si zachovají své aktuální sady znaků.

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

## **Komprimace vložených fontů**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) zmenšuje data vložených fontů odstraněním nepoužitých znaků. Operuje na již vložených fontech, takže míra zmenšení velikosti závisí na množství nepoužitých dat fontu, která prezentace obsahuje.

Následující příklad komprimuje fonty v souboru `EmbeddedFonts.pptx` a výsledek uloží jako samostatný soubor:

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

Ponechte původní soubor, pokud budou příjemci později potřebovat přidávat text. Znaky odstraněné během komprese již nejsou k dispozici z vloženého fontu, i když jste původně vložili všechny znaky.

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda bude vložený font během vykreslování stále nahrazen?**

Zavolejte [getSubstitutions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) v prostředí, kde prezentaci renderujete, abyste zjistili, které fonty Aspose.Slides nahradí. Také zkontrolujte nastavení [font substitution](/slides/cs/androidjava/font-substitution/) a pravidla [font fallback](/slides/cs/androidjava/fallback-font/). Fallback řeší chybějící znaky, takže vložení fontu nevyřeší znaky, které v samotném fontu nejsou.

**Mám vkládat běžné fonty jako Arial a Calibri?**

Rozhodnutí odvoďte od cílového prostředí. Pokud jsou požadované fonty k dispozici na každém zařízení, které prezentaci otevírá nebo renderuje, jejich vkládání může přidat zbytečnou velikost souboru. Pokud mohou příjemci nebo servery tyto fonty postrádat, jejich vkládání může pomoci zachovat zamýšlený vzhled, pokud to licence fontu povolují.