---
title: Onderbreek langdurige presentatiewerkzaamheden in Python
linktitle: Onderbreek presentatiewerkzaamheden
type: docs
weight: 150
url: /nl/python-net/support-for-interruptable-library/
keywords:
- onderbreekbare operaties
- onderbrekingstoken
- Annuleer PDF-export
- PowerPoint
- Python
- Aspose.Slides
description: "Leer hoe u een presentatieconversie in Python kunt annuleren en de lijst van dia's die vóór de annulering voltooid geëxporteerd zijn, kunt terugkrijgen."
---
## **Overzicht**

Aspose.Slides voor Python via .NET ondersteunt coöperatieve annulering tijdens langdurige bewerkingen zoals het laden, opslaan en renderen van presentaties. Wanneer je dia's één voor één exporteert, kun je ook tussen de dia's controleren op annulering en de nummers van de dia's die de export hebben voltooid retourneren.

## **Een presentatieconversie annuleren**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), wijs zijn [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) toe aan [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), en geef de opties door aan de [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Het token geldt voor de presentatie gedurende de gehele levensduur. Om een annulering aan te vragen vanuit je applicatie, roep je [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

Het voorbeeld converteert `sample.pptx` naar `sample.pdf`. Een [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) roept `source.interrupt` aan na 20 seconden. Het starten van de timer vóór het openen van het bestand zorgt ervoor dat de time‑out geldt voor zowel het laden als het opslaan. Een applicatie met een Annuleren‑knop kan dezelfde methode aanroepen vanuit de gebeurtenishandler.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

De expliciete controle na het laden slaat de export over als de time‑out al verstreken is. Als het laden of opslaan de aanvraag ziet, bereikt de annulerings‑exception de aanroeper. Een opslaan kan ook voltooid zijn voordat het de aanvraag ziet, in dat geval is de PDF compleet.

## **Stoppen vóór het verwerken van de volgende dia**

Controleer [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) vóór elke export. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) accepteert een lijst van diapositienummers beginnend bij 1. Voeg een nummer pas toe aan de lijst van voltooide dia's nadat de PDF ervan succesvol is opgeslagen.

Gebruik een bestand met de naam `sample.pptx` met minstens twee dia's. Om het resultaat reproduceerbaar te maken, vraagt het voorbeeld om annulering zodra dia 1 voltooid is. In een applicatie kan de aanvraag afkomstig zijn van een andere thread terwijl een dia wordt opgeslagen.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Het voorbeeld schrijft `slide-1.pdf` en geeft `Starting slide 1` weer, gevolgd door `Completed: [1]`. De volgende iteratie ziet de aanvraag vóór het starten van dia 2. Als annulering een opslaan onderbreekt, geeft de exceptie‑handler de nummers terug die door eerdere iteraties zijn vastgelegd. Andere exportfouten bereiken de aanroeper.

Als de aanroeper annulering als een exceptie moet afhandelen, vervang dan de controle en de `break` bovenaan de lus door [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Verwijder ook de `try`/`except` rond het opslaan. Met dezelfde invoer wordt dia 1 opgeslagen en gooit de tweede iteratie een annulerings‑exceptie voordat dia 2 wordt gestart.

## **Veelgestelde vragen**

**Wanneer gaat een annuleringsverzoek in werking?**

Een onderbreekbare bewerking controleert periodiek zijn token. Hij stopt wanneer hij de aanvraag constateert. Een bewerking die al voltooid is, behoudt zijn resultaat.

**Wat is het verschil tussen de bron en het token?**

De bron stelt je applicatie in staat om een annulering aan te vragen. Het token stelt zowel de presentatie als jouw eigen code in staat om op die aanvraag te controleren.

**Kunnen meerdere bewerkingen dezelfde bron delen?**

Ja. Het aanroepen van `interrupt` vraagt annulering aan voor elke bewerking die een token van die bron gebruikt. Geef elke bewerking een eigen bron als je deze onafhankelijk wilt annuleren.