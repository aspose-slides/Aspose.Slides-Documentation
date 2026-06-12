---
title: Beheer dia‑overgangen in presentaties met C++
linktitle: Dia‑overgang
type: docs
weight: 80
url: /nl/cpp/slide-transition/
keywords:
- dia-overgang
- dia-overgang toevoegen
- dia-overgang toepassen
- geavanceerde dia-overgang
- morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe u dia‑overgangen kunt aanpassen in Aspose.Slides voor C++, met stap‑voor‑stap begeleiding voor PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u dia-overgangen in presentaties kunt beheren met Aspose.Slides. Het laat zien hoe u overgangstypen op dia's toepast, het gedrag van de overgang configureert, zoals voortzetten bij klikken of na een gespecificeerde tijd, automatische voortzetting controleert en uitschakelt, de Morph-overgang en de soorten ervan gebruikt, en overgangseffectopties instelt. De voorbeelden tonen hoe u een presentatie laadt of maakt, de overgangsinstellingen voor geselecteerde dia's wijzigt, en het resultaat opslaat als een PPTX-bestand. Het artikel beantwoordt ook veelgestelde vragen over overgangssnelheid, overgangsgeluiden, dezelfde overgang op meerdere dia's toepassen en controleren welke overgang momenteel op een dia is ingesteld.

## **Diaovergang toevoegen**

Om het makkelijker te maken, hebben we het gebruik van Aspose.Slides for C++ gedemonstreerd om eenvoudige dia-overgangen te beheren. Ontwikkelaars kunnen niet alleen verschillende overgangseffecten op de dia's toepassen, maar ook het gedrag van deze effecten aanpassen. Volg de onderstaande stappen om een eenvoudig dia-overgangseffect te maken:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Pas een Slide Transition Type toe op de dia vanuit één van de overgangseffecten die door Aspose.Slides for C++ worden aangeboden via de enum TransitionType.
3. Schrijf het gewijzigde presentatiebestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Geavanceerde diaovergang toevoegen**

In de bovenstaande sectie hebben we slechts een eenvoudig overgangseffect op de dia toegepast. Om dat eenvoudige effect nu beter en beter te beheersen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Pas een Slide Transition Type toe op de dia vanuit één van de overgangseffecten die door Aspose.Slides for C++ worden aangeboden.
3. U kunt de overgang ook instellen op Advance On Click, na een specifieke tijdsperiode of beide.
4. Als de dia-overgang is ingeschakeld op Advance On Click, zal de overgang alleen doorgaan wanneer iemand klikt met de muis. Bovendien, als de eigenschap Advance After Time is ingesteld, gaat de overgang automatisch verder nadat de opgegeven tijd is verstreken.
5. Schrijf de gewijzigde presentatie weg als een presentatiebestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph-overgang**

Aspose.Slides for C++ ondersteunt nu de Morph-overgang. Deze vertegenwoordigt de nieuwe morph-overgang die in PowerPoint 2019 werd geïntroduceerd. De Morph-overgang maakt het mogelijk om een vloeiende beweging van de ene dia naar de volgende te animeren. Dit artikel beschrijft het concept en hoe u de Morph-overgang gebruikt. Om de Morph-overgang effectief te gebruiken, moet u twee dia's hebben met minstens een gemeenschappelijk object. De eenvoudigste manier is de dia te dupliceren en vervolgens het object op de tweede dia naar een andere plaats te verplaatsen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph-overgangstypen**

Er is een nieuwe enum Aspose.Slides.SlideShow.TransitionMorphType toegevoegd. Deze vertegenwoordigt verschillende typen Morph-dia-overgang.

De enum TransitionMorphType heeft drie leden:

- ByObject: De Morph-overgang wordt uitgevoerd met inachtneming van vormen als ondeelbare objecten.
- ByWord: De Morph-overgang wordt uitgevoerd door tekst per woord over te dragen waar mogelijk.
- ByChar: De Morph-overgang wordt uitgevoerd door tekst per teken over te dragen waar mogelijk.

De volgende codefragment toont hoe u een morph-overgang op een dia instelt en het morph-type wijzigt:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Overgangseffecten instellen**

Aspose.Slides for C++ ondersteunt het instellen van overgangseffecten, zoals van zwart, van links, van rechts enz. Om het overgangseffect in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de klasse Presentation.
- Verkrijg een referentie naar de dia.
- Stel het overgangseffect in.
- Schrijf de presentatie weg als een PPTX-bestand.

In het onderstaande voorbeeld hebben we de overgangseffecten ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Kan ik de afspeelsnelheid van een dia-overgang regelen?**

Ja. Stel de [speed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) van de overgang in met de instelling [TransitionSpeed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionspeed/) (bijvoorbeeld langzaam/middelhoog/snel).

**Kan ik audio aan een overgang toevoegen en laten herhalen?**

Ja. U kunt een geluid aan de overgang embedden en het gedrag sturen via instellingen zoals geluidsmodus en herhalen (bijv. [set_Sound](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), plus metadata zoals [set_SoundIsBuiltIn](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) en [set_SoundName](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Stel het gewenste overgangstype in op de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus door hetzelfde type op alle dia's toe te passen krijgt u een consistent resultaat.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Inspecteer de [transition settings](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseslide/get_slideshowtransition/) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); die waarde geeft precies aan welk effect is toegepast.