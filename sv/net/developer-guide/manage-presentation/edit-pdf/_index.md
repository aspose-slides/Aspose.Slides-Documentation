---
title: Redigera PDF‑dokument i .NET
linktitle: Redigera PDF
type: docs
weight: 65
url: /sv/net/edit-pdf/
keywords:
- redigera PDF
- ersätta PDF‑text
- PDF till PPTX
- PPTX till PDF
- .NET
- C#
- Aspose.Slides
description: "Redigera PDF‑dokument i C# genom att importera dem till Aspose.Slides, ersätta text och spara den modifierade presentationen tillbaka till PDF."
---
## **Översikt**

Aspose.Slides for .NET låter dig redigera PDF‑innehåll genom att importera dess sidor som bilder, modifiera presentationen och exportera den tillbaka till PDF. Den här artikeln visar ett enkelt textutbyte. Presentationen finns kvar i minnet, så att spara en mellansteg PPTX‑fil är valfritt.

## **Ersätt text i en PDF**

Använd [AddFromPdf](https://reference.aspose.com/slides/sv/net/aspose.slides/slidecollection/addfrompdf/) för att importera sidorna, [ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replacetext/) för att uppdatera texten och [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) för att exportera resultatet.

Följande exempel förutsätter att `input.pdf` innehåller ordet "Draft" som redigerbar text efter import. Det ersätter det ordet med "Final" och skriver `edited.pdf`. Att rensa den första bilden innan import förhindrar en extra tom sida i resultatet. Sökningen matchar hela ord med samma skiftläge; `null` betyder att ingen resultatrücknings‑funktion behövs.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

För fler alternativ, se [Sök och ersätt text](/slides/sv/net/search-and-replace-text/) och [Konvertera PowerPoint till PDF](/slides/sv/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Textutbyte fungerar på importerad text, inte på text i skannade bilder. Konverteringen kan påverka layout och formatering, så granska resultatet, särskilt när den ersatta texten är längre än originalet.
{{% /alert %}}

## **FAQ**

**Behöver jag spara en PPTX‑fil innan jag exporterar PDF‑filen?**

Nej. Du kan redigera och exportera samma presentation i minnet. Spara en PPTX‑kopia endast om du också vill fortsätta redigera den i PowerPoint; se [Spara presentationer](/slides/sv/net/save-presentation/).

**Varför kan viss text förbli oförändrad?**

Exemplet matchar hela ordet "Draft" med exakt skiftläge. Text som importeras som en bild eller som är uppdelad i separata textramar matchar inte nödvändigtvis sökningen. Kontrollera det importerade innehållet och justera sökningen för ditt dokument.