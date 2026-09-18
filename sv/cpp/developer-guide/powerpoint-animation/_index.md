---
title: Förbättra PowerPoint-presentationer med animationer i C++
linktitle: PowerPoint-animation
type: docs
weight: 150
url: /sv/cpp/powerpoint-animation/
keywords:
- lägga till animation
- uppdatera animation
- ändra animation
- ta bort animation
- hantera animation
- styra animation
- animeringseffekt
- PowerPoint-animation
- animeringstidslinje
- interaktiv animation
- anpassad animation
- formanimation
- animerat diagram
- animerad text
- animerad form
- animerat OLE-objekt
- animerad bild
- animerad tabell
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du lägger till och styr avancerade animeringseffekter i Aspose.Slides för C++ för att skapa dynamiska PowerPoint- och OpenDocument-presentationer."
---
## **Introduktion**

Eftersom presentationer är avsedda att presentera något, tas deras visuella utseende och interaktiva beteende alltid i beaktande under skapandet.

**PowerPoint‑animation** spelar en viktig roll för att göra en presentation iögonfallande och engagerande för tittarna. Aspose.Slides erbjuder ett brett utbud av alternativ för att lägga till animationer i PowerPoint‑presentationer:

- Applicera olika typer av PowerPoint‑animeringseffekter på former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- Använd flera PowerPoint‑animeringseffekter på en enda form.
- Utnyttja animeringstidslinjen för att kontrollera animeringseffekter.
- Skapa anpassade animationer.

I Aspose.Slides kan olika animeringseffekter appliceras på former. Eftersom varje element på en bild, inklusive text, bilder, OLE‑objekt och tabeller, betraktas som en form, kan animeringseffekter appliceras på vilket element som helst på bilden.

Namnutrymmet [Aspose::Slides::Animation](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/) tillhandahåller klasser för att arbeta med PowerPoint‑animationer.

## **Animeringseffekter**
Aspose.Slides stödjer **150+ animeringseffekter**, inklusive grundläggande effekter som Bounce, PathFootball och Zoom, samt specifika effekter som OLEObjectShow och OLEObjectOpen. Du hittar en fullständig förteckning i uppräkningen [EffectType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effecttype/).

Dessutom kan dessa animeringseffekter användas i kombination med följande beteenden:

- [ColorEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/seteffect/)

## **Anpassad animation**
För kompletta C++‑exempel som skapar, granskar och ändrar beteenden samt redigerbara rörelsespår, se [Anpassad animation](/slides/sv/cpp/custom-animation/).

Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[Behavior](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/behavior/) är en byggsten i en PowerPoint‑animeringseffekt. Kombinera beteenden för att anpassa en effekt, eller lägg till ett beteende för att utöka en fördefinierad effekt. Upprepning konfigureras via tidinställningar snarare än ett separat upprepningsbeteende.

[Animation Point](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/point/) är en punkt där ett beteende ska tillämpas.

## **Animeringstidslinje**
[Sequence](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/sequence/) är en samling animeringseffekter som kan rikta sig mot olika former.

[IAnimationTimeLine](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ianimationtimeline/) är en uppsättning sekvenser som används i en specifik bild. Det är en animeringsmotor som introducerades i PowerPoint 2002. I tidigare versioner av PowerPoint var det svårt att lägga till animeringseffekter i presentationer och kunde endast göras med diverse lösningar. Tidslinjen ger en tydligare objektmodell för PowerPoint‑animationer. En bild kan bara ha en animeringstidslinje.

## **Interaktiv animation**
[Trigger](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effecttriggertype/) låter dig definiera användaråtgärder, som ett knappklick, som startar en specifik animation.

## **Formanimation**
Aspose.Slides låter dig applicera animationer på former, vilket kan inkludera text, rektanglar, linjer, ramar, OLE‑objekt och mer.

{{% alert color="info" title="Note" %}}
Läs mer [**Om formanimation**](/slides/sv/cpp/shape-animation/).
{{% /alert %}}

## **Animerade diagram**
För att skapa animerade diagram bör du använda samma klasser som för former. Dock kan PowerPoint‑animationer endast tillämpas på diagramkategorier eller diagramserier. Du kan också applicera animeringseffekter på ett kategori‑element eller ett serie‑element.

{{% alert color="info" title="Note" %}}
Läs mer [**Om animerade diagram**](/slides/sv/cpp/animated-charts/).
{{% /alert %}}

## **Animerad text**
Förutom att animera text kan du även applicera animation på ett stycke.

{{% alert color="info" title="Note" %}}
Läs mer [**Om animerad text**](/slides/sv/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Kommer animationer att bevaras vid export till PDF?**

Nej. PDF är ett statiskt format, så animationer och [bildövergångar](/slides/sv/cpp/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera istället till [HTML5](/slides/sv/cpp/export-to-html5/), [animated GIF](/slides/sv/cpp/convert-powerpoint-to-animated-gif/), eller [video](/slides/sv/cpp/convert-powerpoint-to-video/).

**Kan jag konvertera en animerad presentation till en video och kontrollera bildfrekvensen och bildstorleken?**

Ja. Du kan [rendera presentationen som bildrutor](/slides/sv/cpp/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), där du väljer FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

**Kommer animationer att förbli intakta när man arbetar med ODP (inte bara PPTX)?**

PPT, PPTX och ODP stöds för [läsning](/slides/sv/cpp/open-presentation/) och [skrivning](/slides/sv/cpp/save-presentation/), men detta garanterar inte att animationer bevaras. Anpassade animeringsdata kan gå förlorade vid konvertering till ODP. Se [Anpassad animation](/slides/sv/cpp/custom-animation/) för exempel och vägledning om hur man kontrollerar formatkompatibilitet.