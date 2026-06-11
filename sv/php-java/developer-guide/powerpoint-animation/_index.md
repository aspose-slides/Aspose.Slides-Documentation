---
title: Förbättra PowerPoint-presentationer med animationer i PHP
linktitle: PowerPoint-animation
type: docs
weight: 150
url: /sv/php-java/powerpoint-animation/
keywords:
- lägga till animation
- uppdatera animation
- ändra animation
- ta bort animation
- hantera animation
- styra animation
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
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Utforska möjligheterna i Aspose.Slides för PHP via Java att hantera PowerPoint-animationer. Nyckelfunktioner och insikter för att förbättra dina presentationer."
---
## **Introduktion**

Eftersom presentationer är avsedda att presentera något, beaktas alltid deras visuella utseende och interaktiva beteende när de skapas.

**PowerPoint‑animation** spelar en viktig roll för att göra presentationen iögonfallande och attraktiv för tittarna. Aspose.Slides för PHP via Java erbjuder ett brett utbud av alternativ för att lägga till animation i PowerPoint‑presentationer:

- tillämpa olika typer av PowerPoint‑animationseffekter på former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- använda flera PowerPoint‑animationseffekter på en form.
- använda animationstidslinjen för att kontrollera animationseffekterna.
- skapa anpassad animation.

I Aspose.Slides för PHP via Java kan olika animationseffekter tillämpas på formerna. Eftersom varje element på bilden, inklusive text, bilder, OLE‑objekt, tabell osv., betraktas som en form, betyder det att vi kan applicera animationseffekt på varje element i en bild.

## **Animationseffekter**
Aspose.Slides stödjer **150+ animationseffekter**, inklusive grundläggande animationseffekter som Bounce, PathFootball, Zoom‑effekt och specifika animationseffekter som OLEObjectShow, OLEObjectOpen. Du kan hitta en fullständig lista över animationseffekter i uppräkningen [**EffectType**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttype/).

Dessutom kan dessa animationseffekter kombineras med:

- [ColorEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SetEffect)

## **Anpassad animation**
Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[**Behavior**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Behavior) är en byggsten för varje PowerPoint‑animationseffekt. Alla animationseffekter är i själva verket en samling beteenden sammansatta till en strategi. Du kan kombinera beteenden till en anpassad animation en gång och återanvända den i andra presentationer. Om du lägger till ett nytt beteende i en standard‑PowerPoint‑animationseffekt blir det en ny anpassad animation. Till exempel kan du lägga till ett upprepningsbeteende till en animation så att den upprepas ett par gånger.

[**Animation Point**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Point) är en punkt där beteendet ska tillämpas.

## **Animations tidslinje**
[**Sequence**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Sequence) är en samling av animationseffekter som tillämpas på en specifik form.

[**Timeline**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/AnimationTimeLine) är en uppsättning sekvenser som används i en specifik bild. Det är en animationsmotor som finns sedan PowerPoint 2002. I tidigare PowerPoint‑versioner var det svårt att lägga till animationseffekter i en presentation, vilket bara gick att lösa med olika kringlösningar. Timeline ersätter den gamla AnimationSettings‑klassen och ger en tydligare objektmodell för PowerPoint‑animation. En bild kan bara ha en animations‑tidslinje.

## **Interaktiv animation**
[**Trigger**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/EffectTriggerType) möjliggör att definiera användaråtgärder (t.ex. knappklick), som startar en viss animation. Triggers har endast lagts till i den senaste PowerPoint‑versionen.

## **Formanimation**
Aspose.Slides låter dig applicera animation på former, som kan vara text, rektangel, linje, ram, OLE‑objekt etc.

{{% alert color="primary" %}} 
Läs mer [**Om formanimation**](/slides/sv/php-java/shape-animation/).
{{% /alert %}}

## **Animerade diagram**
För att skapa animerade diagram bör du använda samma klasser som för former. Det är dock möjligt att använda PowerPoint‑animation endast på diagramelementens kategorier eller serier. Du kan också applicera en animationseffekt på ett kategorieklement eller serieelement.

{{% alert color="primary" %}} 
Läs mer [**Om animerade diagram**](/slides/sv/php-java/animated-charts/).
{{% /alert %}}

## **Animerad text**
Förutom animerad text är det också möjligt att applicera animation på ett stycke.

{{% alert color="primary" %}} 
Läs mer [**Om animerad text**](/slides/sv/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Kommer animationer att bevaras vid export till PDF?**

Nej. PDF är ett statiskt format, så animationer och [slide transitions](/slides/sv/php-java/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera istället till [HTML5](/slides/sv/php-java/export-to-html5/), [animated GIF](/slides/sv/php-java/convert-powerpoint-to-animated-gif/), eller [video](/slides/sv/php-java/convert-powerpoint-to-video/).

**Kan jag konvertera en animerad presentation till en video och kontrollera bildhastigheten och bildstorleken?**

Ja. Du kan [render the presentation as frames](/slides/sv/php-java/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), där du väljer FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

**Kommer animationer att förbli intakta när du arbetar med ODP (inte bara PPTX)?**

PPT, PPTX och ODP stöds för [reading](/slides/sv/php-java/open-presentation/) och [writing](/slides/sv/php-java/save-presentation/), men formatskillnader innebär att vissa effekter kan se annorlunda ut eller fungera något annorlunda. Validera kritiska fall med riktiga exempel.