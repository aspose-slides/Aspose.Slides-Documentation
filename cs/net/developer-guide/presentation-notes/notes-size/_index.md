---
title: Změna velikosti a orientace stránky poznámek v .NET
linktitle: Velikost stránky poznámek
type: docs
weight: 10
url: /cs/net/notes-size/
keywords:
- velikost stránky poznámek
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost podkladu
- PowerPoint
- prezentace
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Čtěte a měňte rozměry stránky poznámek v Aspose.Slides pro .NET, přepínejte orientaci, ověřujte uložené velikosti a exportujte poznámky nebo podklady do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation.NotesSize](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/notessize/) k přístupu k nastavením stránky poznámek prezentace. Vrací objekt [INotesSize](https://reference.aspose.com/slides/cs/net/aspose.slides/inotessize/) jehož vlastnost [Size](https://reference.aspose.com/slides/cs/net/aspose.slides/inotessize/size/) je zapisovatelná. Přestože je samotný objekt nastavení pouze pro čtení, můžete přiřadit nové rozměry jeho vlastnosti size.

Šířka a výška jsou udávány v **bodech**, přičemž 1 palec = 72 bodů. Například 900 × 600 bodů je 12,5 × 8 ⅓ palce. Tato nastavení se vztahují k celé prezentaci, nikoli k poznámkám konkrétního snímku.

| Nastavení | Účel |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/notessize/) | Řídí rozměry stránky poznámek a rozměry stránky používané při exportu podkladů. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slidesize/) | Řídí rozměry běžných snímků prezentace prostřednictvím [ISlideSize](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/). |

Změna jednoho nastavení automaticky nemění druhé. Změna orientace stránky poznámek také neotočí běžné snímky. Viz [Slide Size](/slides/cs/net/slide-size/) pro změnu velikosti běžných snímků.

Níže uvedené příklady používají existující soubor `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím poznámky řečníka. Každý příklad lze spustit samostatně.

## **Přečtěte velikost a orientaci stránky poznámek**

Přečtěte šířku a výšku a porovnejte je, abyste určili orientaci: širší stránka je na šířku (landscape), vyšší stránka je na výšku (portrait) a stejná rozměry popisují čtvercovou stránku. Tento příklad vypíše skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Přepněte na šířkový režim bez změny velikosti papíru**

Pro změnu pouze orientace vyměňte stávající šířku a výšku. Tím zachováte délky obou stran, včetně těch u vlastní velikosti papíru. Podmínka níže zabraňuje tomu, aby již šířková stránka byla přepnuta zpět na výšku, a ponechává čtvercovou stránku beze změny.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Pro výškovou orientaci použijte stejné přiřazení, když `size.Width > size.Height`. Nepřidávejte rozměry A4 nebo Letter, pokud nechcete také změnit velikost papíru.

## **Nastavte a ověřte vlastní velikost stránky poznámek**

Přiřaďte oba rozměry najednou a pak použijte [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) k uložení prezentace. Tento příklad nastaví šířkovou stránku o rozměrech 900 × 600 bodů, uloží ji jako PPTX a znovu otevře uložený soubor k ověření uložených hodnot. Porovnání povoluje toleranci 0,01 bodu pro hodnoty s plovoucí řádovou čárkou; není to záruka přesnosti pro každý formát souboru.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Očekávaný výsledek je `900 x 600 points` a `Size preserved: True`. Kontrola nově otevřené prezentace ověřuje uložený soubor, nikoli jen nastavení v paměti.

## **Export poznámek a podkladů**

Rozměry stránky určují dostupnou oblast pro rozvržení poznámek nebo podkladů. Samy o sobě neaktivují tato rozvržení: je třeba také nastavit možnosti exportu. Export běžných snímků nadále používá rozměry snímku.

### **Export poznámek do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) k [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) pro zahrnutí poznámek do PDF. Tento příklad také vykreslí první snímek s poznámkami do PNG pomocí [Slide.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/getimage/) a [RenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/renderingoptions/).

Režim [BottomTruncated](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notespositions/) udržuje poznámky na jedné stránce; poznámky, které se nevejdou, mohou být zkráceny. PDF používá stránky o rozměrech 900 × 600 bodů. Při měřítku obrazu 1 × 1 použitém níže má PNG rozměry 900 × 600 pixelů. Body popisují geometriku stránky; pixely popisují rastrový výstup, jehož rozměry také závisí na měřítku renderování.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Pro export PDF s dlouhými poznámkami [BottomFull](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notespositions/) umožňuje podle potřeby další stránky. Tento režim nepoužívejte s voláním obrázku pro jeden snímek výše, které jej nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění existujících objektů notes‑master; změna rozměrů stránky samotná by neměla být považována za záruku, že veškerý obsah bude pasovat. Více o exportu poznámek najdete v [Convert PowerPoint to PDF with Notes](/slides/cs/net/convert-powerpoint-to-pdf-with-notes/).

### **Export podkladů do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handoutlayoutingoptions/) pro více miniatur snímků na jedné stránce. Následující příklad nastaví stránku o rozměrech 900 × 600 bodů a použije [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handouttype/) k uspořádání až čtyř snímků na stránku. Horizontální předvolba řídí pořadí snímků; orientace stránky vychází z její šířky a výšky.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Změna velikosti stránky mění oblast dostupnou pro mřížku podkladů, aniž by změnila rozměry zdrojových snímků. Pro obrázky podkladů použijte [Presentation.GetImages](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/getimages/) s rozvržením podkladů místo metody pro obrázek jednotlivého snímku. V Aspose.Slides se vykreslování podkladů na úrovni prezentace řídí rozměry stránky poznámek, zatímco volání obrázku jednotlivého snímku nevytváří stránku podkladu. Více o možnostech rozvržení najdete v [Handout Mode](/slides/cs/net/convert-powerpoint-in-handout-mode/).

## **Velikost stránky v prohlížečích, exportu a tisku**

Uchovávejte odlišnou velikost uložené prezentace, exportovanou velikost stránky a velikost papíru při tisku:

- **Prohlížeče prezentací:** Prohlížeč může zobrazovat nebo tisknout poznámky podle svých vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, znovu jej otevřete a zkontrolujte rozměry; konverze formátu té aplikace je může normalizovat.
- **Exportní formáty:** Výše uvedené příklady PDF s poznámkami a podklady používají nakonfigurované rozměry stránky. Rastrové obrázky používají celočíselné rozměry v pixelech a měřítko renderování, takže zlomkové hodnoty v bodech mohou být zaokrouhleny ve výstupu obrázku. Export běžných snímků neaplikuje velikost stránky poznámek.
- **Ovladače tiskáren:** Výběr papíru, automatické otáčení a nastavení přizpůsobení stránce mohou změnit fyzický výstup, aniž by změnily rozměry uložené v prezentaci nebo PDF. Pro konkrétní velikost papíru sladťte nastavení tiskárny a zkontrolujte náhled před tiskem.

## **Často kladené otázky**

**Mohu nastavit velikost poznámek pouze pro jeden snímek?**

Velikost stránky poznámek je nastavení na úrovni celé prezentace. Jednotlivé snímky mohou mít různý obsah poznámek, ale tato vlastnost nenabízí samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek neovlivnila mé snímky?**

Stránky poznámek a běžné snímky mají nezávislé rozměry. Použijte nastavení velikosti běžných snímků, pokud chcete změnit velikost samotných snímků.

**Proč má výsledek po uložení nebo tisku jinou velikost?**

Nejprve znovu otevřete uloženou prezentaci a porovnejte její rozměry poznámek. Pokud se změnily, ověřte, zda uložení nebo převod souboru v jiné aplikaci neprovedl změnu nastavení stránky. Pokud ne, zkontrolujte rozvržení exportu, měřítko obrázku, nastavení prohlížeče a výběr papíru tiskárny.