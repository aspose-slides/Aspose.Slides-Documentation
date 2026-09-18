---
title: Förbättra PowerPoint-presentationer med animationer i PHP
linktitle: PowerPoint-animation
type: docs
weight: 150
url: /sv/php-java/powerpoint-animation/
keywords:
- lägg till animation
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
description: "Utforska möjligheterna i Aspose.Slides för PHP via Java när det gäller hantering av PowerPoint‑animationer. Nyckelfunktioner och insikter för att förbättra dina presentationer."
---
## **Introduktion**

Eftersom presentationer är avsedda att presentera något, tas deras visuella utseende och interaktiva beteenden alltid i beaktande under skapandet.

**PowerPoint‑animation** spelar en viktig roll för att göra en presentation iögonfallande och engagerande för tittarna. Aspose.Slides for PHP via Java erbjuder ett brett urval av alternativ för att lägga till animationer i PowerPoint‑presentationer:

- Tilldela olika typer av PowerPoint‑animationseffekter till former, diagram, tabeller, OLE‑objekt och andra presentationselement.
- Använd flera PowerPoint‑animationseffekter på en enda form.
- Utnyttja animationstidslinjen för att styra animationseffekter.
- Skapa anpassade animationer.

I Aspose.Slides for PHP via Java kan olika animationseffekter appliceras på former. Eftersom varje element på en bild, inklusive text, bilder, OLE‑objekt och tabeller, betraktas som en form, kan animationseffekter appliceras på vilket element som helst på bilden.

## **Animations‑effekter**
Aspose.Slides stöder **150+ animationseffekter**, inklusive grundläggande effekter som Bounce, PathFootball och Zoom, samt specifika effekter som OLEObjectShow och OLEObjectOpen. Du kan hitta en fullständig lista i klassen [EffectType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttype/).

Dessutom kan dessa animationseffekter kombineras med följande beteenden:

- [ColorEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SetEffect)

## **Anpassad animation**
För kompletta PHP‑exempel som skapar, granskar och modifierar beteenden samt redigerbara rörelsebanor, se [Custom Animation](/slides/sv/php-java/custom-animation/).

Det är möjligt att skapa egna **anpassade animationer** i Aspose.Slides. Detta kan uppnås genom att kombinera flera beteenden till en ny anpassad animation.

[Behavior](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behavior/) är en byggsten i en PowerPoint‑animationseffekt. Kombinera beteenden för att anpassa en effekt, eller lägg till ett beteende för att utöka en fördefinierad effekt. Upprepning konfigureras via tidsinställningar snarare än ett separat upprepningsbeteende.

[Animation Point](https://reference.aspose.com/slides/sv/php-java/aspose.slides/point/) är en punkt där ett beteende ska tillämpas.

## **Animations‑tidslinje**
[Sequence](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/) är en samling av animationseffekter som kan rikta sig mot olika former.

[Timeline](https://reference.aspose.com/slides/sv/php-java/aspose.slides/animationtimeline/) är en uppsättning sekvenser som används i en specifik bild. Det är en animationsmotor som introducerades i PowerPoint 2002. I tidigare versioner av PowerPoint var det svårt att lägga till animationseffekter i presentationer och krävde olika lösningar. Tidslinjen ger en tydligare objektmodell för PowerPoint‑animationer. En bild kan bara ha en animations‑tidslinje.

## **Interaktiv animation**
[Trigger](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttriggertype/) låter dig definiera användaråtgärder, såsom ett knappklick, som startar en viss animation.

## **Formanimation**
Aspose.Slides låter dig applicera animationer på former, vilket kan inkludera text, rektanglar, linjer, ramar, OLE‑objekt och mer.

{{% alert color="info" title="Note" %}}
Läs mer [**Om formanimation**](/slides/sv/php-java/shape-animation/).
{{% /alert %}}

## **Animerade diagram**
För att skapa animerade diagram bör du använda samma klasser som för former. Dock kan PowerPoint‑animationer endast tillämpas på diagramkategorier eller diagramserier. Du kan också applicera animationseffekter på ett kategori‑element eller ett serie‑element.

{{% alert color="info" title="Note" %}}
Läs mer [**Om animerade diagram**](/slides/sv/php-java/animated-charts/).
{{% /alert %}}

## **Animerad text**
Förutom att animera text kan du applicera animation på ett stycke.

{{% alert color="info" title="Note" %}}
Läs mer [**Om animerad text**](/slides/sv/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Kommer animationer att bevaras vid export till PDF?**

Nej. PDF är ett statiskt format, så animationer och [slide transitions](/slides/sv/php-java/slide-transition/) spelas inte upp. Om du behöver rörelse, exportera i stället till [HTML5](/slides/sv/php-java/export-to-html5/), [animated GIF](/slides/sv/php-java/convert-powerpoint-to-animated-gif/), eller [video](/slides/sv/php-java/convert-powerpoint-to-video/).

**Kan jag omvandla en animerad presentation till en video och kontrollera bildhastigheten och bildstorleken?**

Ja. Du kan [rendera presentationen som bildrutor](/slides/sv/php-java/convert-powerpoint-to-video/) och koda dem till en video (t.ex. via ffmpeg), välja FPS och upplösning. Animationer och bildövergångar spelas upp under rendering.

**Kommer animationer att förbli intakta när man arbetar med ODP (inte bara PPTX)?**

PPT, PPTX och ODP stödjs för [reading](/slides/sv/php-java/open-presentation/) och [writing](/slides/sv/php-java/save-presentation/), men detta garanterar inte att animationer bevaras. Anpassade animationsdata kan gå förlorade vid konvertering till ODP. Se [Custom Animation](/slides/sv/php-java/custom-animation/) för exempel och vägledning om hur man kontrollerar formatkompatibilitet.