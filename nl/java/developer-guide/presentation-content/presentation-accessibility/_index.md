---  
title: Beheer de toegankelijkheid van presentaties in Java  
linktitle: Presentatietoegankelijkheid  
type: docs  
weight: 30  
url: /nl/java/presentation-accessibility/  
keywords:  
- presentatietoegankelijkheid  
- alternatieve tekst  
- alternatieve tekst titel  
- alternatieve tekst beschrijving  
- markeren als decoratief  
- PowerPoint  
- OpenDocument  
- presentatie  
- Java  
- Aspose.Slides  
description: "Ontdek hoe Aspose.Slides for Java helpt bij het automatiseren van controles op presentatietoegankelijkheid in PPT, PPTX en ODP-bestanden - verbeter de ervaring voor schermlezers en verhoog de naleving."  
---
## **Inleiding**

Alternatieve tekst helpt mensen die behulpzame technologieën gebruiken om de betekenis van afbeeldingen, grafieken en andere informatieve vormen te begrijpen. Dit artikel legt uit hoe u alternatieve‑tekst‑titels en‑beschrijvingen kunt lezen en bijwerken met Aspose.Slides for Java, hoe u toegankelijkheidsbeschrijvingen onderscheidt van vormnamen die in code worden gebruikt, en hoe u kunt controleren of een vorm als decoratief is gemarkeerd.

Deze functies ondersteunen de toegankelijkheid van presentaties, maar garanderen deze niet. Leesvolgorde, kleurcontrast, leesbaarheid van tekst en andere toegankelijkheidseisen moeten ook worden beoordeeld.

## **Alternatieve‑tekst‑titels en‑beschrijvingen beheren**

Gebruik alternatieve tekst om de betekenis van afbeeldingen, grafieken en andere informatieve vormen uit te leggen aan personen die ze niet kunnen zien. De volgende methoden en inhoud dienen verschillende doeleinden:

| Methode of inhoud | Doel |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Een korte titel voor de alternatieve beschrijving. |
| [getAlternativeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getAlternativeText--) | Een betekenisvolle beschrijving van de inhoud of het doel van de vorm in de context van de dia. |
| [getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--) | De naam van de vorm, die code kan gebruiken om een specifieke vorm in de presentatie te vinden. |
| Zichtbare tekst | Inhoud die op de dia wordt weergegeven, zoals de tekst van een vorm of de titel en labels van een grafiek. Het bijwerken van alternatieve tekst verandert deze inhoud niet. |

Wanneer een presentatie wordt hergebruikt als sjabloon, kan code een vorm vinden op basis van de naam die door [getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--) wordt geretourneerd voordat deze wordt bijgewerkt. Deze naam dient een ander doel dan alternatieve tekst, die uitlegt wat het visuele aan de lezer communiceert. Zoeken op naam stelt auteurs in staat beschrijvingen te verbeteren of te vertalen zonder de manier waarop code de vorm vindt te wijzigen. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, controleer dus dat de naam overeenkomt met de beoogde vorm; zie [Identificeer en vind vormen](/slides/nl/java/shape-manipulations/#identify-and-find-shapes).

Het volgende voorbeeld vereist `input.pptx` met een afbeelding van een kantooringang als de eerste vorm op de eerste dia. De afbeelding mag niet als decoratief worden gemarkeerd. Het voorbeeld leest en drukt de huidige alternatieve‑tekst‑titel en -beschrijving af, werkt beide waarden bij en slaat de presentatie op als `output.pptx`. Pas de bewoording aan op de feitelijke afbeelding en de informatie die deze overbrengt.

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

Alleen alternatieve tekst toevoegen garandeert geen toegankelijkheid van de presentatie of naleving van toegankelijkheidsnormen. Controleer de beschrijvingen op juistheid en relevantie, en controleer ook leesvolgorde, kleurcontrast, leesbare tekst en andere toegankelijkheidseisen. Informatieve visualisaties mogen niet als decoratief worden gemarkeerd; de volgende sectie toont hoe u [isDecorative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#isDecorative--) kunt controleren.

## **Markeren als decoratief**

Markeren als decoratief geeft puur ornamentale visualisaties een vlag zodat schermlezers ze overslaan, ruis verminderen en de focus op betekenisvolle inhoud houden. Pas het toe op achtergronden, versieringen en spaties – nooit op grafieken, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opschoning mogelijk zijn.

![Markeren als decoratief](mark_as_decorative.png)

De volgende code‑voorbeeld laat zien hoe u kunt bepalen of een vorm als decoratief is gemarkeerd.

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

## **Veelgestelde vragen**

**Wat moet ik invoeren in de alternatieve‑tekst‑titel en -beschrijving?**

Gebruik een korte titel om het onderwerp te identificeren en een beschrijving om de informatie die de visual overbrengt in de context van de dia uit te leggen. Beschrijf voor een grafiek de relevante trend of vergelijking in plaats van alleen “grafiek” te vermelden.

**Moet ik alternatieve tekst gebruiken om vormen in een sjabloon te lokaliseren?**

Geef de voorkeur aan het vinden van de vorm op basis van de naam die door [getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--) wordt geretourneerd en controleer of dit de verwachte vorm is. Alternatieve tekst kan worden bewerkt of vertaald, waardoor code die op een exacte beschrijving zoekt kan breken; zie [Identificeer en vind vormen](/slides/nl/java/shape-manipulations/).

**Wanneer moet een vorm als decoratief worden gemarkeerd?**

Gebruik de decoratieve vlag voor visualisaties die geen informatie toevoegen, zoals sierlijke versieringen. Afbeeldingen en grafieken die betekenis overbrengen hebben een passende beschrijving nodig.

**Zorgt het toevoegen van alternatieve tekst ervoor dat een presentatie volledig toegankelijk is?**

Nee. Alternatieve tekst behandelt slechts een deel van de toegankelijkheid. Controleer ook leesvolgorde, kleurcontrast, leesbaarheid van tekst en andere toepasselijke eisen; deze eigenschappen alleen instellen leidt niet tot naleving.