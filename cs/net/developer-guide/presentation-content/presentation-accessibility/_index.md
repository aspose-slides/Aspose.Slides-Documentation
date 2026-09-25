---
title: Správa přístupnosti prezentací v .NET
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/net/presentation-accessibility/
keywords:
- přístupnost prezentací
- alternativní text
- titulek alternativního textu
- popis alternativního textu
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Automatizujte kontroly přístupnosti prezentací v souborech PPT, PPTX a ODP pomocí Aspose.Slides pro .NET—zlepšete zkušenost čteček obrazovky a zvýšte shodu."
---
## **Úvod**

Alternativní text pomáhá lidem používajícím asistenční technologie pochopit význam obrázků, grafů a dalších informačních tvarů. Tento článek vysvětluje, jak pomocí Aspose.Slides pro .NET číst a aktualizovat tituly a popisy alternativního textu, rozlišovat popisy přístupnosti od názvů tvarů používaných v kódu a zjistit, zda je tvar označen jako dekorativní.

Tyto funkce podporují přístupnost prezentace, ale není to zárukou. Pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost také vyžadují kontrolu.

## **Správa alternativních textových titulů a popisů**

Použijte alternativní text k vysvětlení významu obrázků, grafů a dalších informačních tvarů lidem, kteří je nemohou vidět. Následující vlastnosti slouží různým účelům:

| Vlastnost nebo obsah | Účel |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/alternativetexttitle/) | Krátký titulek pro alternativní popis. |
| [AlternativeText](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/alternativetext/) | Smysluplný popis obsahu nebo účelu tvaru v kontextu snímku. |
| [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/name/) | Název tvaru, který může kód použít k nalezení konkrétního tvaru v prezentaci. |
| Viditelný text | Obsah zobrazený na snímku, například text tvaru nebo titulek a popisky grafu. Aktualizace alternativního textu tento obsah nemění. |

Když je prezentace znovu použita jako šablona, může kód najít tvar podle jeho [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/name/) před jeho aktualizací. Tento název slouží jinému účelu než alternativní text, který vysvětluje, co vizuál sděluje čtenáři. Vyhledávání podle názvu umožňuje autorům vylepšovat nebo překládat popisy, aniž by se měnila metoda, jakou kód tvar nachází. Názvy lze upravovat a nejsou zaručeně jedinečné, proto zkontrolujte, že název odpovídá požadovanému tvaru; viz [Identifikovat a najít tvary](/slides/cs/net/shape-manipulations/#identify-and-find-shapes).

Následující příklad vyžaduje `input.pptx` s obrázkem vstupu do kanceláře jako první tvar na první snímku. Obrázek by neměl být označen jako dekorativní. Příklad načte a vypíše aktuální titulek a popis alternativního textu, aktualizuje obě hodnoty a uloží prezentaci jako `output.pptx`. Přizpůsobte text skutečnému obrázku a informacím, které předává.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pouze přidání alternativního textu nezaručuje přístupnost prezentace ani shodu se standardy přístupnosti. Zkontrolujte popisy z hlediska přesnosti a relevance a také prověřte pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost. Informační vizuály by neměly být označeny jako dekorativní; následující část ukazuje, jak číst [IsDecorative](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/isdecorative/).

## **Označit jako dekorativní**

Označit jako dekorativní značí čistě ozdobné vizuály, aby je čtečky obrazovky přeskočily, čímž se sníží šum a zachová se pozornost na smysluplném obsahu. Použijte to pro pozadí, ozdoby a oddělovače – nikdy pro grafy, ikony nebo obrázky, které nesou informaci. Aspose.Slides tuto vlajku zpřístupňuje pro detekci a validaci, což umožňuje automatické kontroly a úklid přístupnosti.

![Označit jako dekorativní](mark_as_decorative.png)

Následující ukázka kódu ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **Často kladené otázky**

**Co bych měl/a uvést v titulku a popisu alternativního textu?**

Použijte krátký titulek k identifikaci předmětu a popis k vysvětlení informací, které vizuál předává v kontextu snímku. U grafu popište relevantní trend nebo srovnání místo pouhého označení „graf“.

**Mám použít alternativní text k vyhledávání tvarů v šabloně?**

Upřednostněte hledání tvaru podle jeho [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/name/) a ověřte, že je to očekávaný tvar. Alternativní text může být upravován nebo překládán, což může narušit kód, který hledá přesný popis; viz [Identifikovat a najít tvary](/slides/cs/net/shape-manipulations/).

**Kdy by měl být tvar označen jako dekorativní?**

Použijte dekorativní vlajku pro vizuály, které nepřinášejí žádnou informaci, například ozdobné prvky. Obrázky a grafy, které komunikují význam, potřebují vhodný popis místo označení jako dekorativní.

**Zajišťuje přidání alternativního textu plnou přístupnost prezentace?**

Ne. Alternativní text řeší jen část přístupnosti. Je také nutné prověřit pořadí čtení, kontrast barev, čitelnost textu a další relevantní požadavky; nastavení těchto vlastností samostatně nezaručuje shodu.