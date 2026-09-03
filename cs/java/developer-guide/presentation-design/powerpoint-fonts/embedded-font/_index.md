---
title: Vkládání písem do prezentací v Javě
linktitle: Vložená písma
type: docs
weight: 40
url: /cs/java/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vložení písma
- získat vložené písmo
- přidat vložené písmo
- odstranit vložené písmo
- komprimovat vložené písmo
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Spravujte vložená písma v PowerPointu pomocí Aspose.Slides pro Java. Přidejte, načtěte, odstraňte a komprimujte písma, abyste zachovali vzhled textu a snížili velikost souboru."
---
## **Úvod**

Vkládání písem ukládá data písem uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložená písma, může zobrazit text s těmito písmy i když nejsou nainstalována v cílovém systému. To pomáhá zachovat zalomení řádků, rozestupy textu a rozvržení snímků.

Aspose.Slides for Java vám umožňuje získávat, přidávat a odstraňovat vložená písma prostřednictvím rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/), které je vráceno metodou [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getFontsManager--). Velikost vložených dat písem můžete také zmenšit odebráním znaků, které prezentace nepoužívá.

Níže uvedené příklady pracují se soubory PPTX. Před vložením písma se ujistěte, že data písma jsou k dispozici pro Aspose.Slides a že licence umožňuje vložení.

## **Získání a odebrání vložených písem**

Použijte [getEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) k vylistování písem uložených v prezentaci. Pro odebrání jednoho předejte písmo z tohoto seznamu metodě [removeEmbeddedFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), poté prezentaci uložte.

Následující příklad vypisuje vložená písma v souboru `EmbeddedFonts.pptx` a pokud je přítomno, odstraňuje Calibri:

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

Odstranění vloženého písma odstraní jeho uložená data; nezmění to písmo přiřazené textu. Pokud je písmo nainstalováno v cílovém systému, může jej text i nadále používat. V opačném případě může renderování vyžadovat [nahrazení písma](/slides/cs/java/font-substitution/), což může ovlivnit rozvržení.

## **Prozkoumání dat písma a oprávnění k vložení**

Použijte rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/) k prozkoumání písem před jejich vložením. Zavolejte [IFontsManager.getFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getFonts--) k získání písem použitých v prezentaci. Pro každé písmo předáte objekt [IFontData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontstyletype/) metodě [IFontsManager.getFontBytes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Metoda vrací binární data daného stylu písma, nebo `null`, pokud požadované písmo nebo styl nejsou dostupné. Nepředávejte výsledek `null` metodě [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), protože tato metoda vyžaduje pole bajtů.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/embeddinglevel/) je výčtová bitová maska, která uvádí omezení vložení uložená v písmu:

- `Installable` povoluje vložení a trvalou instalaci na jiném systému, s předpokladem dodržení licence písma.
- `Restricted` zakazuje vložení, pokud není získáno povolení od právního vlastníka písma, když je to jediný příznak povolení používání.
- `PreviewPrint` povoluje dočasné používání při prohlížení a tisku; dokument obsahující písmo musí být jen pro čtení.
- `Editable` povoluje dočasné používání a umožňuje dokument upravovat a ukládat.
- `NoSubsetting` je další omezení, které zakazuje vložit pouze podmnožinu glifů. V takovém případě vložte všechny znaky.
- `BitmapOnly` je další omezení, které povoluje vložit jen bitmapové řady, ne data obrysů. Pokud písmo nemá bitmapové řady, nelze jej vložit.

Prvních čtyři hodnoty popisují oprávnění k používání, zatímco `NoSubsetting` a `BitmapOnly` lze s nimi kombinovat. Modifikátory kontrolujte pomocí bitových operací. Protože `Installable` je nula, maskujte bity oprávnění k používání a porovnejte výsledek s `Installable` místo kontrolování jako příznaku. Aktuální písma by měla nastavit nejvýše jeden bit oprávnění k používání. Pro kompatibilitu se staršími písmy, která nastavují více než jeden, níže uvedený pomocník vybere nejméně omezující oprávnění: `Editable`, pak `PreviewPrint`, pak `Restricted`.

Následující příklad provádí audit běžných, tučných, kurzívních a tučně kurzívních dat dostupných pro každé písmo vrácené metodou `getFonts`. Přeskakuje nedostupné styly, omezená písma, písma jen s bitmapou, písma omezena na náhled a tisk, protože výstup zůstává upravitelný, a písma, která jsou již vložena. Pokud má kterýkoli dostupný styl příznak `NoSubsetting`, vloží se všechny znaky pro danou rodinu písem.

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

Toto prozkoumání hlásí omezení zakódovaná v každém souboru písma. Neposkytuje licenci, neprokazuje, že jste písmo získali legálně, a nenahrazuje kontrolu licenční smlouvy písma před distribucí vložené kopie.

## **Přidání vložených písem**

Použijte [addEmbeddedFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) k vložení písma. Jeho přetížení přijímají buď objekt [IFontData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontdata/) nebo pole bajtů obsahující data písma. Výčet [EmbedFontCharacters](https://reference.aspose.com/slides/cs/java/com.aspose.slides/embedfontcharacters/) určuje, které znaky budou zahrnuty:

- [All](https://reference.aspose.com/slides/cs/java/com.aspose.slides/embedfontcharacters/) vloží všechny znaky písma. Použijte tuto volbu, pokud příjemci potřebují upravovat prezentaci a zadávat nový text.
- [OnlyUsed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/embedfontcharacters/) vloží pouze znaky použité v prezentaci, aby se snížila velikost souboru. Zvolte tuto možnost pro finální prezentaci, která je primárně určena k prohlížení.

Následující příklad používá [getFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getFonts--) k získání písem použitých v souboru `Fonts.pptx` a vloží ty, která ještě nejsou vložena. Písma k přidání musí být dostupná na počítači, na kterém kód běží. Existující vložená písma si zachovají své aktuální sady znaků.

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

## **Komprese vložených písem**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) zmenšuje vložená data písem odebráním nepoužitých znaků. Operuje na písmenech, která jsou již vložena, takže míra zmenšení závisí na množství nepoužitých dat písem, která prezentace obsahuje.

Následující příklad komprimuje písma v souboru `EmbeddedFonts.pptx` a výsledek uloží jako samostatný soubor:

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

Ponechte původní soubor, pokud příjemci mohou později potřebovat přidávat text. Znaky odebrané během komprese již nejsou dostupné z vloženého písma, i když jste původně vložili všechny znaky.

## **Často kladené otázky**

**Jak mohu zjistit, zda bude vložené písmo během renderování stále nahrazeno?**

Zavolejte [getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) v prostředí, kde prezentaci renderujete, abyste viděli, která písma Aspose.Slides nahradí. Také zkontrolujte nastavení [nahrazení písma](/slides/cs/java/font-substitution/) a pravidla [náhradní písmo](/slides/cs/java/fallback-font/). Náhrada řeší chybějící znaky, takže vložení písma nevyřeší znaky, které samotné písmo neobsahuje.

**Mám vložit běžná písma jako Arial a Calibri?**

Rozhodnutí se opírejte o cílové prostředí. Pokud jsou požadovaná písma dostupná na každém počítači, který prezentaci otevírá nebo renderuje, může jejich vložení jen zbytečně navýšit velikost souboru. Pokud mohou příjemci nebo servery tato písma postrádat, může jejich vložení pomoci zachovat zamýšlený vzhled, za předpokladu, že licence to umožňují.