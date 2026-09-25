---
title: Správa přístupnosti prezentací v Javě
linktitle: Přístupnost prezentace
type: docs
weight: 30
url: /cs/java/presentation-accessibility/
keywords:
- přístupnost prezentace
- alternativní text
- titulek alternativního textu
- popis alternativního textu
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Javu pomáhá automatizovat kontroly přístupnosti prezentací v souborech PPT, PPTX a ODP – zlepšete zkušenost čteček obrazovky a zvýšte soulad."
---
## **Úvod**

Alternativní text pomáhá lidem používajícím asistivní technologie pochopit význam obrázků, grafů a dalších informačních tvarů. Tento článek vysvětluje, jak pomocí Aspose.Slides for Java číst a aktualizovat titulky a popisy alternativního textu, rozlišovat popisy přístupnosti od názvů tvarů používaných v kódu a zkontrolovat, zda je tvar označen jako dekorativní.

Tyto funkce podporují přístupnost prezentace, ale nezaručují ji. Pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost také vyžadují kontrolu.

## **Správa titulů a popisů alternativního textu**

Použijte alternativní text k vysvětlení významu obrázků, grafů a dalších informačních tvarů lidem, kteří je nemohou vidět. Následující metody a obsah slouží různým účelům:

| Metoda nebo obsah | Účel |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Krátký název pro alternativní popis. |
| [getAlternativeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getAlternativeText--) | Smysluplný popis obsahu nebo účelu tvaru v kontextu snímku. |
| [getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getName--) | Název tvaru, který může kód použít k nalezení konkrétního tvaru v prezentaci. |
| Viditelný text | Obsah zobrazený na snímku, například text tvaru nebo název a popisky grafu. Aktualizace alternativního textu tento obsah nemění. |

Když je prezentace znovu použita jako šablona, kód může před aktualizací najít tvar podle názvu vráceného metodou [getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getName--). Tento název slouží jinému účelu než alternativní text, který vysvětluje, co vizuál sděluje čtenáři. Vyhledávání podle názvu umožňuje autorům vylepšovat nebo překládat popisy, aniž by se změnil způsob, jakým kód tvar najde. Názvy lze upravovat a nejsou zaručeny jako jedinečné, proto zkontrolujte, že název odpovídá zamýšlenému tvaru; viz [Identifikace a vyhledání tvarů](/slides/cs/java/shape-manipulations/#identify-and-find-shapes).

Následující příklad vyžaduje soubor `input.pptx` s obrázkem vstupních dveří kanceláře jako prvním tvarem na prvním snímku. Obrázek by neměl být označen jako dekorativní. Příklad načte a vypíše aktuální titulek a popis alternativního textu, aktualizuje oba hodnoty a uloží prezentaci jako `output.pptx`. Přizpůsobte text skutečnému obrázku a informacím, které předává.

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

Přidání alternativního textu samo o sobě nezaručuje přístupnost prezentace ani shodu se standardy přístupnosti. Zkontrolujte popisy z hlediska přesnosti a relevance a také prověřte pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost. Informační vizuály by neměly být označeny jako dekorativní; následující sekce ukazuje, jak zkontrolovat [isDecorative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#isDecorative--).

## **Označit jako dekorativní**

Označení jako dekorativní slouží k označení čistě ozdobných vizuálů, aby je čtečky obrazovky přeskočily, snížily tak šum a udržely pozornost na smysluplném obsahu. Použijte jej u pozadí, ozdob a odsad – nikdy u grafů, ikon ani obrázků, které předávají informace. Aspose.Slides tuto vlajku zpřístupňuje pro detekci a validaci, což umožňuje automatické kontroly a úklid přístupnosti.

![Mark as Decorative](mark_as_decorative.png)

Následující ukázka kódu ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

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

**Co mám uvést v titulku a popisu alternativního textu?**

Použijte krátký titulek k identifikaci subjektu a popis k vysvětlení informací, které vizuál sděluje v kontextu snímku. U grafu popište relevantní trend nebo srovnání místo pouhého označení „graf“.

**Mám používat alternativní text k nalezení tvarů v šabloně?**

Doporučuje se najít tvar podle názvu vráceného metodou [getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getName--) a ověřit, že se jedná o očekávaný tvar. Alternativní text může být upravován nebo překladán, což může narušit kód, který vyhledává přesný popis; viz [Identifikace a vyhledání tvarů](/slides/cs/java/shape-manipulations/).

**Kdy by měl být tvar označen jako dekorativní?**

Použijte vlajku dekorativní pro vizuály, které nepřidávají žádné informace, například ozdobné prvky. Obrázky a grafy, které nesou význam, potřebují místo toho vhodný popis.

**Zajišťuje přidání alternativního textu plnou přístupnost prezentace?**

Ne. Alternativní text řeší jen část přístupnosti. Také je třeba prověřit pořadí čtení, kontrast barev, čitelnost textu a další relevantní požadavky; nastavení těchto vlastností samo o sobě nezaručuje soulad.