---
title: Hantera fallback-typsnitt för presentationer i С++
linktitle: Fallback-typsnitt
type: docs
weight: 50
url: /sv/cpp/fallback-font/
keywords:
- fallback-typsnitt
- tillgängligt typsnitt
- teckenersättning
- ange typsnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Se hur Aspose.Slides för С++ använder fallback-typsnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originaltypsnitt inte är tillgängliga."
---
## **Introduktion**

Fallback-typsnitt används när det typsnitt som anges för text finns i systemet men inte innehåller ett nödvändigt tecken. I sådana fall kan Aspose.Slides använda ett av de angivna fallback-typsnitten för att ersätta det saknade tecknet.

## **Fallback-typsnitt**
Fallback-typsnitt används när det typsnitt som anges för text finns i systemet, men detta typsnitt inte innehåller ett nödvändigt tecken. I sådana fall är det möjligt att använda ett av de angivna fallback-typsnitten för teckenersättning.

Aspose.Slides tillåter att skapa fallback-typsnitt, lägga till dem i en samling av fallback-typsnitt, ange en fallback-typsnittssamling för en viss presentation, ta bort fallback-typsnitt från en presentation, specificera regler för att tillämpa fallback-typsnitt och annat.

För att bli bekant med dessa funktioner, använd följande länkar:

- [Skapa fallback-typsnitt](/slides/sv/cpp/create-fallback-font)
- [Skapa samling av fallback-typsnitt](/slides/sv/cpp/create-fallback-fonts-collection)
- [Rendera presentation med fallback-typsnitt](/slides/sv/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Hur skiljer sig fallback-typsnitt från typsnittssubstitution?**

Fallback tillämpas per tecken eller per område av Unicode när huvudtypsnittet saknar specifika tecken; det fyller endast de saknade tecknen. [Substitution](/slides/sv/cpp/font-substitution/) ersätter ett saknat eller otillgängligt typsnitt för ett helt löp eller en textdel med ett annat typsnitt. De kan kombineras, men deras omfång och urvallogik är olika.

**Sparas fallback-inställningarna i presentationsfilen?**

Nej. Fallback‑konfigurationen finns endast under bearbetning/rendering i biblioteket och serialiseras inte till PPTX. Presentationen lagrar inte dina fallback‑regler.

**Påverkar fallback element som skapats av PowerPoint‑objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går igenom samma renderingspipeline, så samma fallback‑regler gäller för den som för vanlig text.