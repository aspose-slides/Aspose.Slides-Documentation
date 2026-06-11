---
title: Hantera fallback‑typsnitt för presentationer i PHP
linktitle: Fallback‑typsnitt
type: docs
weight: 50
url: /sv/php-java/fallback-font/
keywords:
- fallback‑typsnitt
- tillgängligt typsnitt
- teckenersättning
- ange typsnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Se hur Aspose.Slides för PHP använder fallback‑typsnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originaltypsnitten inte är tillgängliga."
---
## **Introduktion**

Fallback‑typsnitt används när den typsnitt som anges för texten finns i systemet men inte innehåller ett nödvändigt tecken. I så fall kan Aspose.Slides använda ett av de angivna fallback‑typsnitten för att ersätta det saknade tecknet.

## **Fallback‑typsnitt**
Fallback‑typsnitt används när det typsnitt som angivits för texten finns i systemet, men detta typsnitt inte innehåller ett nödvändigt tecken. I så fall går det att använda ett av de angivna fallback‑typsnitten för att ersätta tecknet.

Aspose.Slides gör det möjligt att skapa fallback‑typsnitt, lägga till dem i en samling av fallback‑typsnitt, ange en fallback‑typsnittssamling för en viss presentation, ta bort fallback‑typsnitt från en presentation, specificera regler för att använda fallback‑typsnitt och annat.

För att bli bekant med dessa funktioner, använd följande länkar:

- [Skapa fallback‑typsnitt](/slides/sv/php-java/create-fallback-font)
- [Skapa samling av fallback‑typsnitt](/slides/sv/php-java/create-fallback-fonts-collection)
- [Rendera presentation med fallback‑typsnitt](/slides/sv/php-java/render-presentation-with-fallback-font)

## **FAQ**

**Hur skiljer sig fallback‑typsnitt från typsnittsbyte?**

Fallback tillämpas per tecken eller per Unicode‑intervall när det primära typsnittet saknar specifika tecken; det fyller endast i de saknade tecknen. [Substitution](/slides/sv/php-java/font-substitution/) ersätter ett saknat eller otillgängligt typsnitt för ett helt textsegment eller en del av texten med ett annat typsnitt. De kan kombineras, men deras omfattning och urvalslogik är olika.

**Sparas fallback‑inställningarna i presentationsfilen?**

Nej. Fallback‑konfigurationen existerar endast vid bearbetning/rendering i biblioteket och serialiseras inte till PPTX‑filen. Presentationen lagrar inte dina fallback‑regler.

**Påverkar fallback element som skapats av PowerPoint‑objekt (SmartArt, diagram, WordArt)?**

Ja. Texten i dessa objekt går igenom samma renderingspipeline, så samma fallback‑regler gäller för den som för vanlig text.