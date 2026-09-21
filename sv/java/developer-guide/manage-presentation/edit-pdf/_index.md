---
title: Redigera PDF‑dokument i Java
linktitle: Redigera PDF
type: docs
weight: 65
url: /sv/java/edit-pdf/
keywords:
- redigera PDF
- ersätta PDF‑text
- PDF till PPTX
- PPTX till PDF
- Java
- Aspose.Slides
description: "Redigera PDF‑dokument i Java genom att importera dem till Aspose.Slides, ersätta text och spara den modifierade presentationen tillbaka till PDF."
---
## **Översikt**

Aspose.Slides for Java låter dig redigera PDF‑innehåll genom att importera dess sidor som bilder, ändra presentationen och exportera den tillbaka till PDF. Denna artikel visar ett enkelt textutbyte. Presentationen finns i minnet, så att spara en mellanliggande PPTX‑fil är valfritt.

## **Ersätt text i en PDF**

Använd [addFromPdf](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) för att importera sidorna, [replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för att uppdatera texten och [save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) för att exportera resultatet.

Följande exempel förväntar sig att `input.pdf` innehåller ordet "Draft" som redigerbar text efter import. Det ersätter ordet med "Final" och skriver `edited.pdf`. Att rensa den första bilden före import förhindrar en extra tom sida i resultatet. Sökningen matchar hela ord med exakt skiftläge; `null` betyder att ingen resultat‑callback behövs.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

För fler alternativ, se [Search and Replace Text](/slides/sv/java/search-and-replace-text/) och [Convert PowerPoint to PDF](/slides/sv/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Textutbyte fungerar på importerad text, inte på text i skannade bilder. Konverteringen kan påverka layout och formatering, så granska resultatet, särskilt när den ersättande texten är längre än den ursprungliga.
{{% /alert %}}

## **Vanliga frågor**

**Behöver jag spara en PPTX‑fil innan jag exporterar PDF‑filen?**

Nej. Du kan redigera och exportera samma presentation i minnet. Spara en PPTX‑kopia endast om du också vill fortsätta redigera den i PowerPoint; se [Save Presentations](/slides/sv/java/save-presentation/).

**Varför kan viss text förbli oförändrad?**

Exemplet matchar hela ordet "Draft" med exakt skiftläge. Text som importeras som en bild eller som är delad i separata textramar matchar inte nödvändigtvis sökningen. Kontrollera det importerade innehållet och anpassa sökningen för ditt dokument.