---
title: Förbättra PowerPoint-presentationer med animationer i .NET
linktitle: PowerPoint-animation
type: docs
weight: 150
url: /sv/net/powerpoint-animation/
keywords:
- lägg till animation
- uppdatera animation
- ändra animation
- ta bort animation
- hantera animation
- kontrollera animation
- animationseffekt
- PowerPoint-animation
- animationstidslinje
- interaktiv animation
- anpassad animation
- formanimation
- animerat diagram
- animerad text
- animerad form
- animerat OLE-objekt
- animerad bild
- animerad tabell
- PowerPoint-presentation
- .NET
- C#
- Aspose.Slides
description: "Utforska funktionerna i Aspose.Slides för .NET när du hanterar PowerPoint‑animationer. Denna allmänna översikt belyser viktiga funktioner och ger insikter för att förbättra dina presentationer."
---
## **Introduktion**

Eftersom presentationer är avsedda att presentera något, tas deras visuella utseende och interaktiva beteende alltid i beaktande under skapandet.

**PowerPoint‑animation** spelar en viktig roll för att göra en presentation iögonfallande och engagerande för tittarna. Aspose.Slides for .NET erbjuder ett brett utbud av alternativ för att lägga till animationer i PowerPoint‑presentationer:

- Använd olika typer av PowerPoint‑animationseffekter på former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- Använd flera PowerPoint‑animationseffekter på en och samma form.
- Använd animationstidslinjen för att kontrollera animationseffekter.
- Skapa anpassade animationer.

I Aspose.Slides for .NET kan olika animationseffekter tillämpas på former. Eftersom varje element på en bild, inklusive text, bilder, OLE‑objekt och tabeller, betraktas som en form, kan animationseffekter appliceras på vilket element som helst på bilden.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/) namnutrymmet tillhandahåller klasser för att arbeta med PowerPoint‑animationer.

## **Animations‑effekter**

Aspose.Slides stödjer **150+ animationseffekter**, inklusive grundläggande effekter som Bounce, PathFootball och Zoom, samt specifika effekter som OLEObjectShow och OLEObjectOpen. Du kan hitta en fullständig lista över animationseffekter i uppräkningen [EffectType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttype).

Dessa animationseffekter kan dessutom kombineras med följande:
- [ColorEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/seteffect)

## **Anpassad animation**

För kompletta C#‑exempel som skapar, inspekterar och ändrar beteenden samt redigerbara rörelsebanor, se [Custom Animation](/slides/sv/net/custom-animation/).

Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[Behavior](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/behavior) är en byggsten i en PowerPoint‑animationseffekt. Kombinera beteenden för att anpassa en effekt, eller lägg till ett beteende för att utöka en fördefinierad effekt. Upprepning konfigureras via tidsinställningar snarare än ett separat upprepningsbeteende.

[Animation Point](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/point) är en punkt där ett beteende ska tillämpas.

## **Animations‑tidslinje**

[Sequence](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/sequence) är en samling av animationseffekter som kan rikta sig mot olika former.

[Timeline](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animationtimeline) är en samling av sekvenser som används i en specifik bild. Det är en animationmotor som introducerades i PowerPoint 2002. I tidigare versioner av PowerPoint var det svårt att lägga till animationseffekter i presentationer och kunde endast göras med olika lösningar. Tidslinjen ersätter den gamla AnimationSettings‑klassen och ger en tydligare objektmodell för PowerPoint‑animationer. En bild kan endast ha en animations‑tidslinje.

## **Interaktiv animation**

[Trigger](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttriggertype) låter dig definiera användaråtgärder (t.ex. ett knappklick) som initierar en specifik animation. Trigger‑funktioner introducerades i den senaste versionen av PowerPoint.

## **Formanimation**

Aspose.Slides låter dig applicera animationer på former, som kan inkludera text, rektanglar, linjer, ramar, OLE‑objekt och mer.

{{% alert color="info" title="Note" %}}
Läs mer [**About Shape Animation**](/slides/sv/net/shape-animation/).
{{% /alert %}}

## **Animerade diagram**

För att skapa animerade diagram bör du använda samma klasser som för formerna. Dock kan PowerPoint‑animationer endast tillämpas på diagramkategorier eller diagramserier. Du kan också applicera animationseffekter på ett kategorielement eller ett serietelement.

{{% alert color="info" title="Note" %}}
Läs mer [**About Animated Charts**](/slides/sv/net/animated-charts/).
{{% /alert %}}

## **Animerad text**

Förutom att animera text kan du applicera animation på ett stycke.

{{% alert color="info" title="Note" %}}
Läs mer [**About Animated Text**](/slides/sv/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Kommer animationer att bevaras vid export till PDF?**

Nej. PDF är ett statiskt format, så animationer och [slide transitions](/slides/sv/net/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera istället till [HTML5](/slides/sv/net/export-to-html5/), [animated GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/), eller [video](/slides/sv/net/convert-powerpoint-to-video/).

**Kan jag omvandla en animerad presentation till en video och kontrollera bildhastigheten och bildstorleken?**

Ja. Du kan [render the presentation as frames](/slides/sv/net/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), genom att välja FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

**Kommer animationer att förbli intakta när du arbetar med ODP (inte bara PPTX)?**

PPT, PPTX och ODP stöds för [reading](/slides/sv/net/open-presentation/) och [writing](/slides/sv/net/save-presentation/), men detta garanterar inte att animationer bevaras. Anpassade animationsdata kan gå förlorade vid konvertering till ODP. Se [Custom Animation](/slides/sv/net/custom-animation/) för ett testat exempel och formatbegränsningar.