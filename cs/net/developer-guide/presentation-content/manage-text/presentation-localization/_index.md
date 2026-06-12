---
title: Automatizace lokalizace prezentací v .NET
linktitle: Lokalizace prezentací
type: docs
weight: 100
url: /cs/net/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- ID jazyka
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Automatizujte lokalizaci snímků PowerPoint a OpenDocument v .NET pomocí Aspose.Slides, s praktickými ukázkami kódu v C# a tipy pro rychlejší globální nasazení."
---
## **Přehled**

Tento článek vysvětluje, jak nastavit `LanguageId` pro text v prezentaci pomocí Aspose.Slides. Ukazuje, jak otevřít prezentaci, přidat tvar s textem, přiřadit identifikátor jazyka k textové části a uložit výsledek jako soubor PPTX.

## **Změna jazyka pro prezentaci a text tvaru**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
- Získejte referenci snímku pomocí jeho Indexu.
- Přidejte AutoShape typu Rectangle na snímek.
- Přidejte nějaký text do TextFrame.
- Nastavte Language Id pro text.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je demonstrována níže v příkladu.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Vyvolává LanguageId automatický překlad textu?**

Ne. [LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/languageid/) v Aspose.Slides ukládá jazyk pro kontrolu pravopisu a gramatiky, ale nepřekládá ani nemění obsah textu. Jedná se o metadata, která PowerPoint rozumí pro kontrolu.

**Má LanguageId vliv na dělení slov a zalomení řádků během vykreslování?**

V Aspose.Slides je [LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/languageid/) určeno pro kontrolu. Kvalita dělení slov a zalamování řádků závisí především na dostupnosti [správných fontů](/slides/cs/net/powerpoint-fonts/) a nastaveních rozvržení/zalamování řádků pro daný psací systém. Pro zajištění správného vykreslení zajistěte dostupnost požadovaných fontů, nakonfigurujte [pravidla náhrady fontů](/slides/cs/net/font-substitution/) a/nebo [vložte fonty](/slides/cs/net/embedded-font/) do prezentace.

**Mohu nastavit různé jazyky v rámci jednoho odstavce?**

Ano. [LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/languageid/) se aplikuje na úrovni textové části, takže jeden odstavec může kombinovat více jazyků s odlišnými nastaveními kontroly.