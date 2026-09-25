---
title: Hantera presentationstillgänglighet på Android
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/androidjava/presentation-accessibility/
keywords:
- presentationstillgänglighet
- alternativ text
- alternativ texttitel
- alternativ textbeskrivning
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Android via Java hjälper till att automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer—förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Introduktion**

Alternativ text hjälper personer som använder hjälpmedel att förstå innebörden av bilder, diagram och andra informativa former. Denna artikel förklarar hur man läser och uppdaterar alternativa texttitlar och beskrivningar med Aspose.Slides för Android via Java, särskiljer tillgänglighetsbeskrivningar från formnamn som används i kod och kontrollerar om en form är markerad som dekorativ.  

Dessa funktioner stödjer presentationens tillgänglighet, men garanterar den inte. Läsordning, färgkontrast, textläsbarhet och andra tillgänglighetskrav måste också granskas.

## **Hantera alternativa texttitlar och beskrivningar**

Använd alternativ text för att förklara innebörden av bilder, diagram och andra informativa former för personer som inte kan se dem. Följande metoder och innehåll har olika syften:

| Metod eller innehåll | Syfte |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | En kort titel för den alternativa beskrivningen. |
| [getAlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | En meningsfull beskrivning av formens innehåll eller syfte i bildens sammanhang. |
| [getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getName--) | Formens namn, som kod kan använda för att hitta en specifik form i presentationen. |
| Visible text | Innehåll som visas på bilden, till exempel en forms text eller ett diagrammets titel och etiketter. Att uppdatera alternativ text ändrar inte detta innehåll. |

När en presentation återanvänds som mall kan kod hitta en form genom namnet som returneras av [getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getName--) innan den uppdateras. Detta namn har ett annat syfte än alternativ text, som förklarar vad den visuella delen kommunicerar till läsaren. Sökning efter namn gör det möjligt för författare att förbättra eller översätta beskrivningar utan att ändra hur koden hittar formen. Namn kan redigeras och är inte garanterade att vara unika, så kontrollera att namnet matchar den avsedda formen; se [Identify and Find Shapes](/slides/sv/androidjava/shape-manipulations/#identify-and-find-shapes).

Följande exempel kräver `input.pptx` med en bild av en kontorsentré som den första formen på den första bilden. Bilden bör inte vara markerad som dekorativ. Exemplet läser och skriver ut dess nuvarande alternativa texttitel och beskrivning, uppdaterar båda värdena och sparar presentationen som `output.pptx`. Anpassa formuleringen till den faktiska bilden och den information den förmedlar.

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

Att enbart lägga till alternativ text garanterar inte presentationens tillgänglighet eller efterlevnad av tillgänglighetsstandarder. Granska beskrivningarna för korrekthet och relevans, och kontrollera även läsordning, färgkontrast, läsbar text och andra tillgänglighetskrav. Informativa visuella element bör inte markeras som dekorativa; nästa avsnitt visar hur man kontrollerar [isDecorative](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Markera som dekorativ**

Markera som dekorativ flaggar rent ornamentala visuella element så att skärmläsare hoppar över dem, vilket minskar brus och behåller fokus på meningsfullt innehåll. Använd det på bakgrunder, utsmyckningar och avståndshållare—aldrig på diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för upptäckt och validering, vilket möjliggör automatiska tillgänglighetskontroller och rensning.

![Mark as Decorative](mark_as_decorative.png)

Följande kodexempel visar hur man avgör om en form är markerad som dekorativ.

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

## **Vanliga frågor**

**Vad ska jag ange i den alternativa texttiteln och beskrivningen?**

Använd en kort titel för att identifiera ämnet och en beskrivning för att förklara den information som den visuella delen förmedlar i bildens sammanhang. För ett diagram, beskriv den relevanta trenden eller jämförelsen istället för att bara säga "diagram".

**Ska jag använda alternativ text för att lokalisera former i en mall?**

Föredra att hitta formen via namnet som returneras av [getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getName--) och kontrollera att det är den förväntade formen. Alternativ text kan redigeras eller översättas, vilket kan bryta kod som söker efter en exakt beskrivning; se [Identify and Find Shapes](/slides/sv/androidjava/shape-manipulations/).

**När bör en form markeras som dekorativ?**

Använd den dekorativa flaggan för visuella element som inte tillför någon information, såsom ornamentala utsmyckningar. Bilder och diagram som förmedlar betydelse behöver en lämplig beskrivning istället.

**Gör tillägg av alternativ text en presentation helt tillgänglig?**

Nej. Alternativ text täcker endast en del av tillgängligheten. Granska även läsordning, färgkontrast, textläsbarhet och andra tillämpliga krav; att bara sätta dessa egenskaper etablerar inte efterlevnad.