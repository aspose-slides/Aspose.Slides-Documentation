---
title: Beheer de toegankelijkheid van presentaties op Android
linktitle: Presentatie-toegankelijkheid
type: docs
weight: 30
url: /nl/androidjava/presentation-accessibility/
keywords:
- presentatie toegankelijkheid
- alternatieve tekst
- alternatieve tekst titel
- alternatieve tekst beschrijving
- markeren als decoratief
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Android via Java helpt bij het automatiseren van controles op de toegankelijkheid van presentaties in PPT-, PPTX- en ODP-bestanden — verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Inleiding**

Alternatieve tekst helpt mensen die behulpzame technologieën gebruiken om de betekenis van afbeeldingen, grafieken en andere informatieve vormen te begrijpen. Dit artikel legt uit hoe u alternatieve teksttitels en -beschrijvingen kunt lezen en bijwerken met Aspose.Slides voor Android via Java, toegankelijkheidsbeschrijvingen kunt onderscheiden van vormnamen die in code worden gebruikt, en kunt controleren of een vorm gemarkeerd is als decoratief.

Deze functies ondersteunen de toegankelijkheid van presentaties, maar garanderen dit niet. Leesvolgorde, kleurcontrast, tekstleesbaarheid en andere toegankelijkheidseisen moeten ook worden gecontroleerd.

## **Beheer alternatieve teksttitels en -beschrijvingen**

Gebruik alternatieve tekst om de betekenis van afbeeldingen, grafieken en andere informatieve vormen uit te leggen aan mensen die ze niet kunnen zien. De volgende methoden en inhoud dienen verschillende doeleinden:

| Methode of inhoud | Doel |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Een korte titel voor de alternatieve beschrijving. |
| [getAlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Een betekenisvolle beschrijving van de inhoud of het doel van de vorm in de context van de dia. |
| [getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getName--) | De naam van de vorm, die code kan gebruiken om een specifieke vorm in de presentatie te vinden. |
| Visible text | Inhoud die op de dia wordt weergegeven, zoals de tekst van een vorm of de titel en labels van een grafiek. Het bijwerken van alternatieve tekst verandert deze inhoud niet. |

Wanneer een presentatie opnieuw wordt gebruikt als sjabloon, kan code een vorm vinden aan de hand van de naam die door [getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getName--) wordt geretourneerd voordat deze wordt bijgewerkt. Deze naam heeft een ander doel dan alternatieve tekst, die uitlegt wat het visuele element aan de lezer communiceert. Zoeken op naam stelt auteurs in staat beschrijvingen te verbeteren of te vertalen zonder te wijzigen hoe code de vorm vindt. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, controleer dus of de naam overeenkomt met de beoogde vorm; zie [Identify and Find Shapes](/slides/nl/androidjava/shape-manipulations/#identify-and-find-shapes).

Het volgende voorbeeld vereist `input.pptx` met een afbeelding van een kantooringang als de eerste vorm op de eerste dia. De afbeelding mag niet gemarkeerd zijn als decoratief. Het voorbeeld leest en toont de huidige alternatieve teksttitel en -beschrijving, werkt beide waarden bij en slaat de presentatie op als `output.pptx`. Pas de bewoording aan op de daadwerkelijke afbeelding en de informatie die deze overbrengt.

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

Alleen het toevoegen van alternatieve tekst garandeert geen toegankelijkheid van de presentatie of naleving van toegankelijkheidsnormen. Controleer de beschrijvingen op nauwkeurigheid en relevantie, en controleer ook leesvolgorde, kleurcontrast, leesbare tekst en andere toegankelijkheidseisen. Informatieve beelden mogen niet gemarkeerd worden als decoratief; de volgende sectie laat zien hoe u [isDecorative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#isDecorative--) kunt controleren.

## **Markeren als decoratief**

Markeren als decoratief geeft puur decoratieve beelden een vlag zodat schermlezers ze overslaan, waardoor ruis wordt verminderd en de focus op betekenisvolle inhoud blijft. Pas het toe op achtergronden, versieringen en spatiëringen — nooit op grafieken, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opruiming mogelijk zijn.

![Mark as Decorative](mark_as_decorative.png)

De volgende codevoorbeeld laat zien hoe u kunt bepalen of een vorm gemarkeerd is als decoratief.

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

## **FAQ**

**Wat moet ik in de alternatieve teksttitel en -beschrijving plaatsen?**

Gebruik een korte titel om het onderwerp te identificeren en een beschrijving om de informatie die het visuele element overbrengt in de context van de dia uit te leggen. Beschrijf bij een grafiek de relevante trend of vergelijking in plaats van alleen “grafiek” te noemen.

**Moet ik alternatieve tekst gebruiken om vormen in een sjabloon te vinden?**

Geef de voorkeur aan het vinden van de vorm op basis van de naam die door [getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getName--) wordt geretourneerd en controleer of het de verwachte vorm is. Alternatieve tekst kan bewerkt of vertaald worden, waardoor code die naar een exacte beschrijving zoekt kan falen; zie [Identify and Find Shapes](/slides/nl/androidjava/shape-manipulations/).

**Wanneer moet een vorm gemarkeerd worden als decoratief?**

Gebruik de decoratieve vlag voor beelden die geen informatie toevoegen, zoals sierlijke versieringen. Afbeeldingen en grafieken die betekenis overbrengen hebben in plaats daarvan een passende beschrijving nodig.

**Zorgt het toevoegen van alternatieve tekst ervoor dat een presentatie volledig toegankelijk is?**

Nee. Alternatieve tekst behandelt slechts een deel van de toegankelijkheid. Controleer tevens de leesvolgorde, kleurcontrast, tekstleesbaarheid en andere relevante eisen; alleen het instellen van deze eigenschappen zorgt niet voor naleving.