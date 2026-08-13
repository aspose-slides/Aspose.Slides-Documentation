---
title: Förbättra PowerPoint-presentationer med animationer på Android
linktitle: PowerPoint-animation
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
- Android
- Java
- Aspose.Slides
description: "Utforska möjligheterna i Aspose.Slides för Android via Java när det gäller att hantera PowerPoint-animationer. Denna allmänna översikt framhäver nyckelfunktioner."
---
## **Introduktion**

Eftersom presentationer är avsedda att visa något, beaktas deras visuella utseende och interaktiva beteende alltid när de skapas.

**PowerPoint‑animation** spelar en viktig roll för att göra presentationen iögonfallande och attraktiv för tittarna. Aspose.Slides för Android via Java erbjuder ett brett utbud av alternativ för att lägga till animation i PowerPoint‑presentationer:

- tillämpa olika typer av PowerPoint‑animationseffekter på former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- använd flera PowerPoint‑animationseffekter på en form.
- använd animations‑tidslinje för att styra animationseffekter.
- skapa anpassad animation.

I Aspose.Slides för Android via Java kan olika animationseffekter tillämpas på formerna. Eftersom varje element på bilden, inklusive text, bilder, OLE‑objekt, tabell osv., betraktas som en form betyder det att vi kan tillämpa animationseffekter på varje element i en bild.

## **Animationseffekter**
Aspose.Slides stödjer **150+ animationseffekter**, inklusive grundläggande animationseffekter som Bounce, PathFootball, Zoom‑effekt och specifika animationseffekter som OLEObjectShow, OLEObjectOpen. Du kan hitta en fullständig lista över animationseffekter i [**EffectType**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effecttype/)‑enumerationen.

Dessutom kan dessa animationseffekter användas i kombination med:

- [ColorEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SetEffect)

## **Anpassad animation**
Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[**Behavior**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Behavior) är en byggsten i alla PowerPoint‑animationseffekter. Alla animationseffekter är i själva verket en samling beteenden sammansatta till en strategi. Du kan kombinera beteenden till en anpassad animation en gång och återanvända den i andra presentationer. Om du lägger till ett nytt beteende i en standard‑PowerPoint‑animationseffekt blir det en annan anpassad animation. Till exempel kan du lägga till ett upprepningsbeteende i en animation för att få den att upprepas flera gånger.

[**Animation Point**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Point) är den punkt där beteendet ska tillämpas.

## **Animations‑tidslinje**
[**Sequence**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Sequence) är en samling av animationseffekter som tillämpas på en specifik form.

[**Timeline**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AnimationTimeLine) är en uppsättning sekvenser som används i en specifik bild. Det är en animationsmotor som har funnits sedan PowerPoint 2002. I tidigare versioner av PowerPoint var det svårt att lägga till animationseffekter i en presentation, vilket bara kunde göras med olika lösningar. Tidslinjen ersätter den gamla AnimationSettings‑klassen och ger en tydligare objektmodell för PowerPoint‑animationer. En bild kan endast ha en animations‑tidslinje.

## **Interaktiv animation**
[**Trigger**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/EffectTriggerType) låter dig definiera användaråtgärder (t.ex. knapprtryck) som får en viss animation att starta. Triggers har endast lagts till i den senaste PowerPoint‑versionen.

## **Formanimation**
Aspose.Slides möjliggör att applicera animation på former, som kan vara text, rektangel, linje, ram, OLE‑objekt osv.

{{% alert color="info" %}} 
Läs mer [**Om formanimation**](/slides/sv/androidjava/shape-animation/).
{{% /alert %}}

## **Animera diagram**
För att skapa animerade diagram bör du använda samma klasser som för formerna. Det är dock möjligt att använda PowerPoint‑animation endast på diagramkategorier eller diagramserier. Du kan även tillämpa animationseffekt på ett kategorielement eller serieelement.

{{% alert color="info" %}} 
Läs mer [**Om animerade diagram**](/slides/sv/androidjava/animated-charts/).
{{% /alert %}}

## **Animerad text**
Förutom animerad text är det även möjligt att applicera animation på ett stycke.

{{% alert color="info" %}} 
Läs mer [**Om animerad text**](/slides/sv/androidjava/animated-text/).
{{% /alert %}}

## **Vanliga frågor**

### Kommer animationer att bevaras vid export till PDF?

Nej. PDF är ett statiskt format, så animationer och [bildövergångar](/slides/sv/androidjava/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera istället till [HTML5](/slides/sv/androidjava/export-to-html5/), [animert GIF](/slides/sv/androidjava/convert-powerpoint-to-animated-gif/) eller [video](/slides/sv/androidjava/convert-powerpoint-to-video/).

### Kan jag omvandla en animerad presentation till en video och kontrollera bildfrekvensen och bildstorleken?

Ja. Du kan [rendera presentationen som bildrutor](/slides/sv/androidjava/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), genom att välja FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

### Kommer animationer att förbli intakta vid arbete med ODP (inte bara PPTX)?

PPT, PPTX och ODP stöds för [läsning](/slides/sv/androidjava/open-presentation/) och [skrivning](/slides/sv/androidjava/save-presentation/), men formatskillnader innebär att vissa effekter kan se lite annorlunda ut eller fungera annorlunda. Validera kritiska fall med riktiga exempel.