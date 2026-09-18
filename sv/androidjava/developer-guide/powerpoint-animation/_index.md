---
title: Förbättra PowerPoint-presentationer med animationer på Android
linktitle: PowerPoint‑animation
type: docs
weight: 150
url: /sv/androidjava/powerpoint-animation/
keywords:
- lägga till animation
- uppdatera animation
- ändra animation
- ta bort animation
- hantera animation
- styra animation
- animationseffekt
- PowerPoint‑animation
- animationstidslinje
- interaktiv animation
- anpassad animation
- formanimation
- animerat diagram
- animerad text
- animerad form
- animerat OLE‑objekt
- animerad bild
- animerad tabell
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Utforska möjligheterna i Aspose.Slides för Android via Java när det gäller hantering av PowerPoint‑animationer. Denna allmänna översikt lyfter fram viktiga funktioner."
---
## **Introduktion**

Eftersom presentationer är avsedda att visa något, tas deras visuella utseende och interaktiva beteende alltid i beaktande under skapandet.

**PowerPoint‑animation** spelar en viktig roll i att göra en presentation iögonfallande och engagerande för betraktaren. Aspose.Slides erbjuder ett brett urval av alternativ för att lägga till animationer i PowerPoint‑presentationer:

- Tilldela olika typer av PowerPoint‑animationseffekter till former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- Använd flera PowerPoint‑animationseffekter på en enda form.
- Använd animeringstidslinjen för att styra animationseffekter.
- Skapa anpassade animationer.

I Aspose.Slides kan olika animationseffekter tillämpas på former. Eftersom varje element på en bild, inklusive text, bilder, OLE‑objekt och tabeller, betraktas som en form, kan animationseffekter tillämpas på vilket element som helst på bilden.

## **Animationseffekter**
Aspose.Slides stödjer **150+ animationseffekter**, inklusive grundläggande effekter som Bounce, PathFootball och Zoom, samt specifika effekter som OLEObjectShow och OLEObjectOpen. Du hittar en fullständig lista i klassen [EffectType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effecttype/).

Dessa animationseffekter kan dessutom kombineras med följande beteenden:

- [ColorEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SetEffect)

## **Anpassad animation**
För kompletta Java‑exempel som skapar, inspekterar och modifierar beteenden samt redigerbara rörelsevägar, se [Anpassad animation](/slides/sv/java/custom-animation/).

Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[Behavior](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/behavior/) är en byggsten i en PowerPoint‑animationseffekt. Kombinera beteenden för att anpassa en effekt, eller lägg till ett beteende för att utöka en fördefinierad effekt. Upprepning konfigureras via tidinställningar istället för ett separat repeat‑beteende.

[Animation Point](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/point/) är en punkt där ett beteende ska tillämpas.

## **Animationstidslinje**
[Sequence](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sequence/) är en samling av animationseffekter som kan rikta sig mot olika former.

[Timeline](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/animationtimeline/) är en uppsättning sekvenser som används i en specifik bild. Det är en animeringsmotor som introducerades i PowerPoint 2002. I tidigare versioner av PowerPoint var det svårt att lägga till animationseffekter i presentationer och kunde endast uppnås med olika lösningar. Tidslinjen ger en tydligare objektmodell för PowerPoint‑animationer. En bild kan endast ha en animeringstidslinje.

## **Interaktiv animation**
[Trigger](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effecttriggertype/) låter dig definiera användaråtgärder, som ett knappklick, som startar en specifik animation.

## **Formanimation**
Aspose.Slides låter dig lägga till animationer på former, vilket kan inkludera text, rektanglar, linjer, ramar, OLE‑objekt och mer.

{{% alert color="info" title="Note" %}}
Läs mer [**Om formanimation**](/slides/sv/androidjava/shape-animation/).
{{% /alert %}}

## **Animerade diagram**
För att skapa animerade diagram bör du använda samma klasser som för former. Däremot kan PowerPoint‑animationer endast appliceras på diagramkategorier eller diagramserier. Du kan även applicera animationseffekter på ett kategorielement eller ett serierelement.

{{% alert color="info" title="Note" %}}
Läs mer [**Om animerade diagram**](/slides/sv/androidjava/animated-charts/).
{{% /alert %}}

## **Animerad text**
Förutom att animera text kan du också applicera animation på ett stycke.

{{% alert color="info" title="Note" %}}
Läs mer [**Om animerad text**](/slides/sv/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Kommer animationer att bevaras vid export till PDF?**

Nej. PDF är ett statiskt format, så animationer och [slide transitions](/slides/sv/androidjava/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera istället till [HTML5](/slides/sv/androidjava/export-to-html5/), [animated GIF](/slides/sv/androidjava/convert-powerpoint-to-animated-gif/), eller [video](/slides/sv/androidjava/convert-powerpoint-to-video/).

**Kan jag omvandla en animerad presentation till en video och styra bildfrekvensen och bildstorleken?**

Ja. Du kan [rendera presentationen som ramar](/slides/sv/androidjava/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), genom att välja FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

**Kommer animationer att förbli intakta när man arbetar med ODP (inte bara PPTX)?**

PPT, PPTX och ODP stöds för [reading](/slides/sv/androidjava/open-presentation/) och [writing](/slides/sv/androidjava/save-presentation/), men detta garanterar inte att animationer bevaras. Anpassad animationsdata kan gå förlorad vid konvertering till ODP. Se [Custom Animation for Java](/slides/sv/java/custom-animation/) för exempel och vägledning om hur du kontrollerar formatkompatibilitet.