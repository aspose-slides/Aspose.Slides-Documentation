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
- Android
- Java
- Aspose.Slides
description: "Utforska möjligheterna i Aspose.Slides för Android via Java när du hanterar PowerPoint-animationer. Denna allmänna översikt lyfter fram nyckelfunktioner."
---
## **Introduktion**

Eftersom presentationer är avsedda att presentera något, beaktas deras visuella utseende och interaktiva beteende alltid vid skapandet.

**PowerPoint‑animation** spelar en viktig roll för att göra presentationen iögonfallande och attraktiv för tittarna. Aspose.Slides för Android via Java erbjuder ett brett utbud av alternativ för att lägga till animation i en PowerPoint‑presentation:

- tillämpa olika typer av PowerPoint‑animationseffekter på former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- använd flera PowerPoint‑animationseffekter på en form.
- använd animationstidslinje för att kontrollera animationseffekter.
- skapa anpassad animation.

I Aspose.Slides för Android via Java kan olika animationseffekter tillämpas på formerna. Eftersom varje element på bilden, inklusive text, bilder, OLE‑objekt, tabeller osv, betraktas som en form innebär det att vi kan applicera animationseffekter på varje element i en bild.

## **Animationseffekter**
Aspose.Slides stöder **150+ animationseffekter**, inklusive grundläggande animationseffekter som Bounce, PathFootball, Zoom‑effekt och specifika animationseffekter som OLEObjectShow, OLEObjectOpen. Du kan hitta en komplett lista över animationseffekter i [**EffectType**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effecttype/)-enumerationen.

Dessutom kan dessa animationseffekter användas i kombination med dem:

- [ColorEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SetEffect)

## **Anpassad animation**
Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås om du kombinerar flera beteenden till en ny anpassad animation.

[**Behavior**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Behavior) är en byggsten för varje PowerPoint‑animationseffekt. Alla animationseffekter är faktiskt en uppsättning beteenden sammansatta till en strategi. Du kan kombinera beteenden till en anpassad animation en gång och återanvända den i andra presentationer. Om du lägger till ett nytt beteende i en standard‑PowerPoint‑animationseffekt blir det en ny anpassad animation. Till exempel kan du lägga till ett upprepningsbeteende i en animation så att den upprepas ett fåtal gånger.

[**Animation Point**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Point) är en punkt där beteendet ska tillämpas.

## **Animationstidslinje**
[**Sequence**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Sequence) är en samling animationseffekter som tillämpas på en specifik form.

[**Timeline**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AnimationTimeLine) är en uppsättning sekvenser som används i en specifik bild. Det är en animationmotor som har funnits sedan PowerPoint 2002. I tidigare PowerPoint‑versioner var det svårt att lägga till animationseffekter i en presentation, vilket bara gick att åstadkomma med olika lösningar. Timeline ersätter den gamla AnimationSettings‑klassen och ger en tydligare objektmodell för PowerPoint‑animation. En bild kan bara ha en animationstidslinje.

## **Interaktiv animation**
[**Trigger**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/EffectTriggerType) gör det möjligt att definiera användaråtgärder (t.ex. knappklick), som får en viss animation att starta. Triggers har endast lagts till i den senaste PowerPoint‑versionen.

## **Formanimation**
Aspose.Slides tillåter att applicera animation på former, som kan vara text, rektangel, linje, ram, OLE‑objekt osv.

{{% alert color="primary" %}} 
Läs mer [**Om formanimation**](/slides/sv/androidjava/shape-animation/).
{{% /alert %}}

## **Animerade diagram**
För att skapa animerade diagram bör du använda samma klasser som för former. Det är dock möjligt att använda PowerPoint‑animation endast på diagramkategorier eller diagramserier. Du kan också tillämpa en animationseffekt på ett kategori‑element eller serie‑element.

{{% alert color="primary" %}} 
Läs mer [**Om animerade diagram**](/slides/sv/androidjava/animated-charts/).
{{% /alert %}}

## **Animerad text**
Förutom animerad text är det också möjligt att applicera animation på ett stycke.

{{% alert color="primary" %}} 
Läs mer [**Om animerad text**](/slides/sv/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Behålls animationer vid export till PDF?**

Nej. PDF är ett statiskt format, så animationer och [bildövergångar](/slides/sv/androidjava/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera istället till [HTML5](/slides/sv/androidjava/export-to-html5/), [animerad GIF](/slides/sv/androidjava/convert-powerpoint-to-animated-gif/) eller [video](/slides/sv/androidjava/convert-powerpoint-to-video/).

**Kan jag konvertera en animerad presentation till en video och kontrollera bildhastigheten och bildstorleken?**

Ja. Du kan [rendera presentationen som bildrutor](/slides/sv/androidjava/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), välja FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

**Behåller animationer sin integritet när man arbetar med ODP (inte bara PPTX)?**

PPT, PPTX och ODP stöds för [läsning](/slides/sv/androidjava/open-presentation/) och [skrivning](/slides/sv/androidjava/save-presentation/), men formatskillnader innebär att vissa effekter kan se annorlunda ut eller fungera något annorlunda. Validera kritiska fall med riktiga exempel.