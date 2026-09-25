---
title: Správa přístupnosti prezentací na Androidu
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/androidjava/presentation-accessibility/
keywords:
- přístupnost prezentací
- alternativní text
- nadpis alternativního textu
- popis alternativního textu
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Android prostřednictvím Javy pomáhá automatizovat kontroly přístupnosti prezentací v souborech PPT, PPTX a ODP — zlepšuje zážitek čteček obrazovky a zvyšuje soulad."
---
## **Úvod**

Alternativní text pomáhá lidem používajícím asistenční technologie pochopit význam obrázků, grafů a dalších informačních tvarů. Tento článek vysvětluje, jak číst a aktualizovat alternativní textové nadpisy a popisy pomocí Aspose.Slides for Android via Java, jak rozlišovat popisy přístupnosti od názvů tvarů používaných v kódu a jak zjistit, zda je tvar označen jako dekorativní.

Tyto funkce podporují přístupnost prezentace, ale nezaručují její úplnou přístupnost. Pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost také vyžadují revizi.

## **Správa alternativních textových nadpisů a popisů**

Použijte alternativní text k vysvětlení významu obrázků, grafů a dalších informačních tvarů lidem, kteří je nemohou vidět. Níže uvedené metody a obsah slouží různým účelům:

| Metoda nebo obsah | Účel |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Krátký nadpis pro alternativní popis. |
| [getAlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Významný popis obsahu nebo účelu tvaru v kontextu snímku. |
| [getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getName--) | Název tvaru, který může kód použít k nalezení konkrétního tvaru v prezentaci. |
| Viditelný text | Obsah zobrazený na snímku, například text tvaru nebo název a popisky grafu. Aktualizace alternativního textu tento obsah nemění. |

Když je prezentace použita jako šablona, může kód najít tvar podle názvu vráceného metodou [getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getName--) před jeho aktualizací. Tento název slouží jinému účelu než alternativní text, který vysvětluje, co vizuál sděluje čtenáři. Vyhledávání podle názvu umožňuje autorům upravit nebo přeložit popisy, aniž by se změnil způsob, jakým kód tvar najde. Názvy lze upravovat a nejsou zaručeně jedinečné, takže je třeba zkontrolovat, že název odpovídá zamýšlenému tvaru; viz [Identify and Find Shapes](/slides/cs/androidjava/shape-manipulations/#identify-and-find-shapes).

Následující příklad požaduje soubor `input.pptx` s obrázkem vstupních dveří kanceláře jako prvním tvarem na prvním snímku. Obrázek by neměl být označen jako dekorativní. Příklad přečte a vypíše aktuální alternativní textový nadpis a popis, aktualizuje obě hodnoty a uloží prezentaci jako `output.pptx`. Přizpůsobte text aktuálnímu obrázku a informacím, které předává.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pouze přidání alternativního textu nezaručuje přístupnost prezentace ani shodu s normami přístupnosti. Zkontrolujte popisy z hlediska přesnosti a relevance a také prověřte pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost. Informační vizuály by neměly být označeny jako dekorativní; další sekce ukazuje, jak zkontrolovat [isDecorative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Označit jako dekorativní**

Označit jako dekorativní flaguje čistě ozdobné vizuály, aby je čtečky obrazovky přeskočily, čímž se sníží šum a udrží pozornost na smysluplném obsahu. Použijte jej na pozadí, ozdoby a oddělovače — nikdy však na grafy, ikony nebo obrázky, které předávají informace. Aspose.Slides tento flag poskytuje pro detekci a validaci, což umožňuje automatizované kontroly přístupnosti a úklid.

![Označit jako dekorativní](mark_as_decorative.png)

Níže uvedený ukázkový kód ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Co mám uvést do alternativního textového nadpisu a popisu?**

Použijte krátký nadpis k identifikaci předmětu a popis k vysvětlení informací, které vizuál předává v kontextu snímku. U grafu popište relevantní trend nebo srovnání místo pouhého uvedení „graf“.

**Mám používat alternativní text k vyhledávání tvarů v šabloně?**

Upřednostněte vyhledání tvaru podle názvu vráceného metodou [getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getName--) a ověřte, že jde o očekávaný tvar. Alternativní text může být upravován nebo překládán, což může rozbít kód hledající přesný popis; viz [Identify and Find Shapes](/slides/cs/androidjava/shape-manipulations/).

**Kdy by měl být tvar označen jako dekorativní?**

Použijte dekorativní flag pro vizuály, které nepřidávají žádné informace, například ozdobné motivy. Obrázky a grafy, které komunikují význam, vyžadují vhodný popis místo označení jako dekorativní.

**Zajišťuje přidání alternativního textu plnou přístupnost prezentace?**

Ne. Alternativní text řeší pouze část přístupnosti. Je také nutné zkontrolovat pořadí čtení, kontrast barev, čitelnost textu a další relevantní požadavky; nastavení těchto vlastností samo o sobě neznamená shodu s normami.