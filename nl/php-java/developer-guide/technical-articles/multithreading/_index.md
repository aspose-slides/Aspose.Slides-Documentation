---
title: Multithreading in Aspose.Slides voor PHP via Java
linktitle: Multithreading
type: docs
weight: 310
url: /nl/php-java/multithreading/
keywords:
- multithreading
- meerdere threads
- parallel werk
- slides converteren
- slides naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Aspose.Slides voor PHP via Java multithreading versnelt de verwerking van PowerPoint en OpenDocument. Ontdek best practices voor efficiënte presentatiewerkstromen."
---
## **Inleiding**

Hoewel parallel werken met presentaties mogelijk is (naast het parsen/laden/kopiëren) en meestal alles goed gaat, is er een kleine kans dat je onjuiste resultaten krijgt wanneer je de bibliotheek in meerdere threads gebruikt.

We raden ten zeerste aan om **niet** één enkele [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) instantie te gebruiken in een multi-threading omgeving, omdat dit kan leiden tot onvoorspelbare fouten of storingen die niet gemakkelijk worden gedetecteerd.

Het is **niet** veilig om een instantie van een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse te laden, op te slaan en/of te klonen in meerdere threads. Dergelijke bewerkingen worden **niet** ondersteund. Als je dergelijke taken moet uitvoeren, moet je de bewerkingen parallel uitvoeren met meerdere single‑threaded processen — en elk van deze processen moet zijn eigen presentatie‑instantie gebruiken.

We garanderen geen multithreading in PHP bij het gebruiken van extensies. Als je ze gebruikt, doe dat dan op eigen risico.

## **FAQ**

**Moet ik de licentie‑instelling in elke thread aanroepen?**

Nee. Het is voldoende om dit één keer per proces/app‑domain te doen voordat de threads starten. Als [license setup](/slides/nl/php-java/licensing/) mogelijk gelijktijdig wordt aangeroepen (bijvoorbeeld tijdens lazy initialisatie), synchroniseer die aanroep omdat de licentie‑instellingsmethode zelf niet thread‑safe is.

**Kan ik `Presentation` of `Slide` objecten tussen threads doorgeven?**

Het doorgeven van "live" presentatie‑objecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak van tevoren aparte presentaties/slide‑containers voor elke thread. Deze aanpak volgt de algemene aanbeveling om geen enkele presentatie‑instantie te delen over threads.

**Is het veilig om het exporteren naar verschillende formaten (PDF, HTML, afbeeldingen) te paralleliseren op voorwaarde dat elke thread zijn eigen `Presentation` instantie heeft?**

Ja. Met onafhankelijke instanties en aparte output‑paden paralleliseren dergelijke taken zich meestal correct; vermijd gedeelde presentatie‑objecten en gedeelde I/O‑streams.

**Wat moet ik doen met globale lettertype‑instellingen (mappen, substituties) in multithreading?**

Initialiseer alle globale [font settings](/slides/nl/php-java/powerpoint-fonts/) voordat je de threads start en wijzig ze niet tijdens parallel werk. Dit voorkomt race‑condities bij het benaderen van gedeelde lettertype‑bronnen.