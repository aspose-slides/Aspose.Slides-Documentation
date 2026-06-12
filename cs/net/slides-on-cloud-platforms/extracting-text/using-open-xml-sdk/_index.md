---
title: "Jak extrahovat text ze souborů PPT, PPTX a ODP pomocí Open XML SDK v .NET"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /cs/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- cloudové platformy
- integrace cloudu
- Open XML SDK
- extrakce textu z PPTX
- zpracování snímků v .NET
- extrakce textu z prezentace
- hlavní snímek
- poznámky k řečníkovi
- extrahování textu ze snímků
- C#
description: "Naučte se, jak v .NET pomocí Open XML SDK extrahovat text ze souborů PPT, PPTX a ODP, s přístupem založeným na XML, tipy na výkon a řešení převodů pro cloudové aplikace."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Open XML SDK v .NET získat text z prezentačních souborů. Zaměřuje se na přímý přístup k XML pro soubory PPTX, kde lze text získat ze strukturovaných prvků snímků, aniž by bylo nutné snímky vykreslovat nebo používat Microsoft PowerPoint. Článek také popisuje výkonnostní výhody, jako je rychlejší zpracování a nižší spotřeba paměti.

U souborů PPT a ODP článek uvádí, že text nelze přímo extrahovat pomocí Open XML SDK. Místo toho je třeba tyto formáty nejprve převést na PPTX, poté lze text získat z výsledného souboru.

## **Open XML SDK**

**Open XML SDK** poskytuje vysoce strukturovaný a efektivní způsob, jak extrahovat text z prezentačních souborů – zejména **PPTX**, které se řídí standardem Open XML. Poskytnutím přímého přístupu k podkladovému XML tento SDK umožňuje rychlejší a flexibilnější práci s obsahem snímků ve srovnání s tradičními metodami.

## **Přímý přístup k XML**

- **Analyzovat text přímo**: Open XML SDK umožňuje extrahovat text z částí XML bez vykreslování snímků.
- **Strukturované prvky**: Protože je text uložen v dobře definovaných XML značkách, je jeho získání a zpracování jednodušší.

### **Příklad: Přímé získávání textu z XML obsahu snímku**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **Výkonnostní výhody**

- **Rychlejší extrakce**: Obchází režii otevírání PowerPointu nebo jiných vysoceúrovňových API.
- **Nižší využití paměti**: Přistupuje se pouze k relevantním částem XML, čímž se snižuje spotřeba zdrojů.
- **Není potřeba Microsoft PowerPoint**: Uvolňuje vás od dalších požadavků na instalaci.

### **Příklad: Efektivní získávání textu bez načítání celé prezentace**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **Identifikace textových prvků**

### **Specifika získávání textu z prezentací**

Při získávání textu z prezentací zvažte následující faktory:

- **Text může být umístěn v různých sekcích**: běžné snímky, hlavní snímky, rozvržení nebo poznámky k řečníkovi.
- **Výchozí zástupné texty**: Hlavní snímky a rozvržení mohou obsahovat zástupné texty (např. „Klikněte pro úpravu stylu titulku hlavní šablony“), které nejsou skutečným obsahem prezentace.
- **Filtrace prázdného nebo skrytého textu**: Některé prvky mohou být prázdné nebo ne určené k zobrazení.

### **Značky obsahující text**

V souboru **PPTX** je text obecně uložen v:

- `<a:t>` elementy uvnitř `<a:p>` (odstavce)
- `<a:r>` elementy (segmenty textu uvnitř odstavců)

### **Příklad: Extrakce všech textových prvků ze snímku**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP a PPT**

### **Nemožnost přímého získávání textu**

Na rozdíl od **PPTX** nejsou **PPT** (binární formát) a **ODP** (OpenDocument Presentation) **podporovány** Open XML SDK.

- **PPT** ukládá obsah v uzavřeném binárním formátu, což ztěžuje extrakci textu.
- **ODP** se opírá o **OpenDocument XML**, které se strukturálně liší od PPTX.

### **Obchodní řešení: Převod na PPTX**

Pro získání textu z **PPT** nebo **ODP** se doporučuje následující postup:

1. **Převést PPT → PPTX** pomocí PowerPointu nebo nástroje třetí strany.
2. **Převést ODP → PPTX** pomocí LibreOffice nebo PowerPointu.
3. **Extrahovat text** z nového PPTX pomocí Open XML SDK.

### **Příklad: Převod ODP na PPTX pomocí příkazové řádky LibreOffice**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Podporované platformy a frameworky**

- **Windows**: .NET Framework 4.6.1 a novější, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Cloudové prostředí**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker kontejnery.
- **Kompatibilita s kancelářskými aplikacemi**: Nevyžaduje instalaci Microsoft Office.
- **Podporované programovací jazyky**: Open XML SDK lze použít s **C#**, **VB.NET**, **F#** a dalšími jazyky podporovanými .NET.

## **Závěr**

Využití **Open XML SDK** pro **extrakci textu z PPTX** poskytuje jak efektivitu, tak přehlednost, zatímco **PPT a ODP** vyžadují počáteční krok převodu pro hladké zpracování. Přijetím tohoto přístupu se zajistí **vysoký výkon**, **flexibilita** a **široká kompatibilita** s moderními .NET aplikacemi.