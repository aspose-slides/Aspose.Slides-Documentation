---
title: Hantera bildövergångar i presentationer med C++
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/cpp/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du anpassar bildövergångar i Aspose.Slides för C++, med steg‑för‑steg‑vägledning för PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar bildövergångar i presentationer med Aspose.Slides. Den visar hur du tillämpar övergångstyper på bilder, konfigurerar övergångsbeteende som att gå vidare vid klick eller efter en angiven tid, kontrollerar och inaktiverar automatisk vidaregång, använder Morph‑övergången och dess typer, samt ställer in alternativ för övergångseffekter. Exemplen demonstrerar hur du laddar eller skapar en presentation, ändrar övergångsinställningarna för utvalda bilder och sparar resultatet som en PPTX‑fil. Artikeln svarar också på vanliga frågor om övergångshastighet, övergångsljud, att applicera samma övergång på flera bilder och hur du kontrollerar vilken övergång som för närvarande är inställd på en bild.

## **Lägg till bildövergång**
För att göra det lättare att förstå har vi demonstrerat användningen av Aspose.Slides för C++ för att hantera enkla bildövergångar. Utvecklare kan inte bara tillämpa olika bildövergångseffekter på bilderna, utan också anpassa beteendet för dessa övergångseffekter. För att skapa en enkel bildövergångseffekt, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Tillämpa en Slide Transition Type på bilden från en av de övergångseffekter som erbjuds av Aspose.Slides för C++ genom TransitionType‑enum.
3. Skriv den modifierade presentationsfilen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Lägg till avancerad bildövergång**
I avsnittet ovan applicerade vi bara en enkel övergångseffekt på bilden. Nu, för att göra den enkla övergångseffekten ännu bättre och mer kontrollerad, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Tillämpa en Slide Transition Type på bilden från en av de övergångseffekter som erbjuds av Aspose.Slides för C++.
3. Du kan också ställa in övergången att gå vidare vid klick, efter en specifik tidsperiod eller både och.
4. Om bildövergången är aktiverad för Advance On Click, kommer övergången bara att gå vidare när någon klickar med musen. Dessutom, om egenskapen Advance After Time är inställd, kommer övergången att gå vidare automatiskt efter den angivna tiden har passerat.
5. Skriv den modifierade presentationen som en presentationsfil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph‑övergång**
Aspose.Slides för C++ stöder nu Morph‑övergången. De representerar den nya morph‑övergången som introducerades i PowerPoint 2019. Morph‑övergången gör det möjligt att animera en smidig rörelse från en bild till nästa. Denna artikel beskriver konceptet och hur man använder Morph‑övergången. För att använda Morph‑övergången effektivt behöver du två bilder med åtminstone ett gemensamt objekt. Det enklaste är att duplicera bilden och sedan flytta objektet på den andra bilden till en annan plats.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph‑övergångstyper**
Den nya enum‑typen Aspose.Slides.SlideShow.TransitionMorphType har lagts till. Den representerar olika typer av Morph‑bildövergång.

TransitionMorphType‑enum har tre medlemmar:

- ByObject: Morph‑övergången utförs med hänsyn till former som odelbara objekt.
- ByWord: Morph‑övergången utförs genom att överföra text ord för ord där det är möjligt.
- ByChar: Morph‑övergången utförs genom att överföra text tecken för tecken där det är möjligt.

Följande kodsnutt visar hur du sätter en morph‑övergång på en bild och ändrar morph‑typen:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Ställ in övergångseffekter**
Aspose.Slides för C++ stödjer att ange övergångseffekter såsom från svart, från vänster, från höger osv. För att ställa in övergångseffekten, följ stegen nedan:

- Skapa en instans av Presentation‑klassen.
- Hämta referens till bilden.
- Ställa in övergångseffekten.
- Skriv presentationen som en PPTX‑fil.

I exemplet nedan har vi satt övergångseffekterna.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Ställ in övergångens [speed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) med [TransitionSpeed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionspeed/) (t.ex. slow/medium/fast).

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Du kan bädda in ett ljud för övergången och styra beteendet via inställningar som ljudläge och loopning (t.ex. [set_Sound](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), samt metadata såsom [set_SoundIsBuiltIn](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) och [set_SoundName](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Vad är det snabbaste sättet att applicera samma övergång på varje bild?**

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att applicera samma typ på alla bilder ger ett enhetligt resultat.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Inspektera bildens [transition settings](https://reference.aspose.com/slides/sv/cpp/aspose.slides.baseslide/get_slideshowtransition/) och läs dess [transition type](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); det värdet visar exakt vilken effekt som är tillämpad.