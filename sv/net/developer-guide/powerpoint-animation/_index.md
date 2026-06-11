---
title: Förbättra PowerPoint-presentationer med animationer i .NET
linktitle: PowerPoint-animation
type: docs
weight: 150
url: /sv/net/powerpoint-animation/
keywords:
- lägga till animation
- uppdatera animation
- ändra animation
- ta bort animation
- hantera animation
- styra animation
- animationseffekt
- PowerPoint-animation
- animations-tidslinje
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
description: "Utforska möjligheterna i Aspose.Slides för .NET när det gäller hantering av PowerPoint-animationer. Denna allmänna översikt belyser viktiga funktioner och ger insikter för att förbättra dina presentationer."
---
## **Introduktion**

Eftersom presentationer är avsedda att presentera något tas deras visuella utseende och interaktiva beteende alltid i beaktande under skapandet.

**PowerPoint‑animation** spelar en viktig roll för att göra en presentation iögonfallande och engagerande för tittarna. Aspose.Slides for .NET erbjuder ett brett urval av alternativ för att lägga till animationer i PowerPoint‑presentationer:

- Tillämpa olika typer av PowerPoint‑animationseffekter på former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- Använd flera PowerPoint‑animationseffekter på en enda form.
- Använd animationstidslinjen för att styra animationseffekter.
- Skapa anpassade animationer.

I Aspose.Slides for .NET kan olika animationseffekter tillämpas på former. Eftersom varje element på en bild, inklusive text, bilder, OLE‑objekt och tabeller, betraktas som en form, kan animationseffekter tillämpas på vilket element som helst på bilden.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/) namespace tillhandahåller klasser för att arbeta med PowerPoint‑animationer.

## **Animationseffekter**

Aspose.Slides stödjer **150+ animationseffekter**, inklusive grundläggande effekter som Bounce, PathFootball och Zoom, samt specifika effekter som OLEObjectShow och OLEObjectOpen. En komplett lista över animationseffekter finns i uppräkningen [EffectType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttype).

Dessutom kan dessa animationseffekter användas i kombination med följande:

- [ColorEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/seteffect)

## **Anpassad animation**

Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[Behaviour](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/behavior) är en byggsten i alla PowerPoint‑animationseffekter. Alla animationseffekter är i huvudsak en samling beteenden sammansatta till en strategi. Du kan kombinera beteenden till en anpassad animation en gång och återanvända den i andra presentationer. Om du lägger till ett nytt beteende till en standard‑PowerPoint‑animationseffekt blir det en annan anpassad animation. Till exempel kan du lägga till ett upprepningsbeteende till en animation för att få den att upprepa sig några gånger.

[Animation Point](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/point) är en punkt där ett beteende ska tillämpas.

## **Animationstidslinje**

[Sequence](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/sequence) är en samling av animationseffekter som tillämpas på en specifik form.

[Timeline](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animationtimeline) är en uppsättning sekvenser som används i en specifik bild. Det är en animationsmotor som introducerades i PowerPoint 2002. I tidigare versioner av PowerPoint var det svårt att lägga till animationseffekter i presentationer och kunde bara uppnås med olika lösningar. Tidslinjen ersätter den gamla AnimationSettings‑klassen och ger en tydligare objektmodell för PowerPoint‑animationer. En bild kan bara ha en animations‑tidslinje.

## **Interaktiv animation**

[Trigger](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttriggertype) låter dig definiera användaråtgärder (t.ex. ett knappklick) som startar en specifik animation. Triggers introducerades i den senaste versionen av PowerPoint.

## **Formanimation**

Aspose.Slides låter dig applicera animationer på former, vilket kan inkludera text, rektanglar, linjer, ramar, OLE‑objekt och mer.

{{% alert color="primary" %}} 
Läs mer [**Om formanimation**](/slides/sv/net/shape-animation/).
{{% /alert %}}

## **Animerade diagram**

För att skapa animerade diagram bör du använda samma klasser som för former. Däremot kan PowerPoint‑animationer endast tillämpas på diagramkategorier eller diagramserier. Du kan också applicera animationseffekter på ett kategori‑element eller ett serie‑element.

{{% alert color="primary" %}} 
Läs mer [**Om animerade diagram**](/slides/sv/net/animated-charts/).
{{% /alert %}}

## **Animerad text**

Förutom animerad text är det också möjligt att applicera animation på ett stycke.

{{% alert color="primary" %}} 
Läs mer [**Om animerad text**](/slides/sv/net/animated-text/).
{{% /alert %}}

## **Vanliga frågor**

**Kommer animationer att bevaras vid export till PDF?**

Nej. PDF är ett statiskt format, så animationer och [bildövergångar](/slides/sv/net/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera i stället till [HTML5](/slides/sv/net/export-to-html5/), [animated GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/) eller [video](/slides/sv/net/convert-powerpoint-to-video/).

**Kan jag omvandla en animerad presentation till en video och kontrollera bildfrekvens och bildstorlek?**

Ja. Du kan [rendera presentationen som bildrutor](/slides/sv/net/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg) och välja FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

**Kommer animationer att förbli intakta när du arbetar med ODP (inte bara PPTX)?**

PPT, PPTX och ODP stöds för [läsning](/slides/sv/net/open-presentation/) och [skrivning](/slides/sv/net/save-presentation/), men format‑skillnader innebär att vissa effekter kan se annorlunda ut eller fungera lite annorlunda. Validera kritiska fall med riktiga exempel.