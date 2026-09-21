---
title: Redigera PDF-dokument i Python
linktitle: Redigera PDF
type: docs
weight: 65
url: /sv/python-net/edit-pdf/
keywords:
- redigera PDF
- ersätta PDF-text
- PDF till PPTX
- PPTX till PDF
- Python
- Aspose.Slides
description: "Redigera PDF-dokument i Python genom att importera dem till Aspose.Slides, ersätta text och spara den modifierade presentationen tillbaka till PDF."
---
## **Översikt**

Aspose.Slides for Python via .NET låter dig redigera PDF‑innehåll genom att importera dess sidor som bilder, modifiera presentationen och exportera den tillbaka till PDF. Denna artikel visar ett enkelt textbyte. Presentationen finns kvar i minnet, så att spara en mellanliggande PPTX‑fil är valfritt.

## **Ersätt text i en PDF**

Använd [add_from_pdf](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/add_from_pdf/) för att importera sidorna, [replace_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/replace_text/) för att uppdatera texten och [save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) för att exportera resultatet.

Det följande exemplet förväntar sig att `input.pdf` innehåller ordet "Draft" som redigerbar text efter import. Det ersätter det ordet med "Final" och skriver `edited.pdf`. Att rensa den första bilden innan import förhindrar en extra tom sida i resultatet. Sökningen matchar hela ord med exakt skiftläge; `None` betyder att ingen resultatrückanrop behövs.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

För fler alternativ, se [Sök och ersätt text](/slides/sv/python-net/search-and-replace-text/) och [Konvertera PowerPoint till PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Textbyte fungerar på importerad text, inte på text i skannade bilder. Konverteringen kan påverka layout och formatering, så granska resultatet, särskilt när den ersatta texten är längre än originalet.
{{% /alert %}}

## **FAQ**

**Behöver jag spara en PPTX‑fil innan jag exporterar PDF‑filen?**

Nej. Du kan redigera och exportera samma presentation i minnet. Spara en PPTX‑kopia endast om du också vill fortsätta redigera den i PowerPoint; se [Spara presentationer](/slides/sv/python-net/save-presentation/).

**Varför kan viss text förbli oförändrad?**

Exemplet matchar hela ordet "Draft" med exakt skiftläge. Text som importerats som en bild eller som delats upp i separata textramar kommer inte nödvändigtvis att matcha sökningen. Kontrollera det importerade innehållet och justera sökningen för ditt dokument.