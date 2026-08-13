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
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du lägger till och styr avancerade animationseffekter i Aspose.Slides för C++ för att skapa dynamiska PowerPoint- och OpenDocument-presentationer."
---
## **Introduktion**

Eftersom presentationer är avsedda att presentera något, beaktas deras visuella utseende och interaktiva beteende alltid när de skapas.

**PowerPoint‑animation** spelar en viktig roll för att göra presentationen iögonfallande och attraktiv för tittarna. Aspose.Slides för C++ erbjuder ett brett sortiment av alternativ för att lägga till animation i PowerPoint‑presentationer:

- tillämpa olika typer av PowerPoint‑animationseffekter på former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- använd flera PowerPoint‑animationseffekter på en form.
- använd animationstidslinjen för att styra animationseffekter.
- skapa anpassad animation.

I Aspose.Slides för C++ kan olika animationseffekter tillämpas på formerna. Eftersom varje element på bilden, inklusive text, bilder, OLE‑objekt, tabell osv, betraktas som en form, betyder det att vi kan applicera animationseffekter på varje element i en bild.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation) **namespace** tillhandahåller klasser för att arbeta med PowerPoint‑animationer.

## **Animationseffekter**

Aspose.Slides stödjer **150+ animationseffekter**, inklusive grundläggande animationseffekter som Bounce, PathFootball, Zoom‑effekt och specifika animationseffekter som OLEObjectShow, OLEObjectOpen. Du kan hitta en fullständig lista över animationseffekter i [**EffectType**](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)enum.

Dessutom kan dessa animationseffekter kombineras med dem:

- [ColorEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.set_effect)

## **Anpassad animation**
Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[**Behavior**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.behavior) är en byggsten i varje PowerPoint‑animationseffekt. Alla animationseffekter är i själva verket en samling beteenden sammansatta till en strategi. Du kan kombinera beteenden till en anpassad animation en gång och återanvända den i andra presentationer. Om du lägger till ett nytt beteende i en standard‑PowerPoint‑animationseffekt blir det en ytterligare anpassad animation. Till exempel kan du lägga till ett repetitionsbeteende i en animation så att den upprepas några gånger.

[**Animation Point**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.point) är en punkt där beteendet ska tillämpas.

## **Animations‑tidslinje**
[**Sequence**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.sequence) är en samling av animationseffekter som tillämpas på en specifik form.

[**AnimationTimeLine**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.animation_time_line) är en samling av Sekvenser som används i en specifik bild. Det är en animationsmotor som finns sedan PowerPoint 2002. I tidigare versioner av PowerPoint var det svårt att lägga till animationseffekter i en presentation, vilket bara gick att lösa med olika kringgående metoder. Tidslinjen ersätter den gamla AnimationSettings‑klassen och ger en tydligare objektmodell för PowerPoint‑animation. En bild kan ha endast en animations‑tidslinje.

## **Interaktiv animation**
[**EffectTriggerType**](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) låter dig definiera användaråtgärder (t.ex. knappklick), som får en viss animation att starta. Utlösare har endast lagts till i den senaste versionen av PowerPoint.

## **Formanimation**
Aspose.Slides gör det möjligt att applicera animation på former, som kan vara text, rektangel, linje, ram, OLE‑objekt osv.

{{% alert color="info" %}} 
Läs mer [**Om formanimation**](/slides/sv/cpp/shape-animation/).
{{% /alert %}}

## **Animerade diagram**
För att skapa animerade diagram bör du använda samma klasser som för formerna. Det är dock möjligt att använda PowerPoint‑animation endast på diagramkategorier eller diagramserier. Du kan också applicera animationseffekt på ett kategorielement eller serieelement.

{{% alert color="info" %}} 
Läs mer [**Om animerade diagram**](/slides/sv/cpp/animated-charts/).
{{% /alert %}}

## **Animerad text**
Förutom animerad text är det också möjligt att applicera animation på ett stycke.

{{% alert color="info" %}} 
Läs mer [**Om animerad text**](/slides/sv/cpp/animated-text/).
{{% /alert %}}

## **Vanliga frågor**

### Kommer animationer att bevaras när man exporterar till PDF?

Nej. PDF är ett statiskt format, så animationer och [bildövergångar](/slides/sv/cpp/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera istället till [HTML5](/slides/sv/cpp/export-to-html5/), [animerad GIF](/slides/sv/cpp/convert-powerpoint-to-animated-gif/) eller [video](/slides/sv/cpp/convert-powerpoint-to-video/).

### Kan jag omvandla en animerad presentation till en video och kontrollera bildhastigheten och bildstorleken?

Ja. Du kan [rendera presentationen som bildrutor](/slides/sv/cpp/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), genom att välja FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

### Kommer animationer att förbli intakta när man arbetar med ODP (inte bara PPTX)?

PPT, PPTX och ODP stöds för [läsning](/slides/sv/cpp/open-presentation/) och [skrivning](/slides/sv/cpp/save-presentation/), men formatskillnader innebär att vissa effekter kan se annorlunda ut eller bete sig något annorlunda. Validera kritiska fall med riktiga exempel.