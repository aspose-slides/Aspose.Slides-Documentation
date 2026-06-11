---
title: Hantera fallback-typsnitt för presentationer i JavaScript
linktitle: Fallback-typsnitt
type: docs
weight: 50
url: /sv/nodejs-java/fallback-font/
keywords:
- fallback-typsnitt
- tillgängligt typsnitt
- glyfbyte
- ange typsnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Se hur Aspose.Slides för Node.js använder fallback-typsnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originaltypsnitt inte är tillgängliga."
---
## **Introduktion**

Fallback-typsnitt används när det typsnitt som anges för text finns i systemet men inte innehåller en nödvändig glyf. I detta fall kan Aspose.Slides använda ett av de angivna fallback-typsnitten för att ersätta den saknade glyfen.

## **Fallback-typsnitt**

Aspose.Slides möjliggör att skapa fallback-typsnitt, lägga till dem i en samling av fallback-typsnitt, ange fallback-typsnittssamling för en viss presentation, ta bort fallback-typsnitt från presentationen, specificera reglerna för att tillämpa fallback-typsnitt och annat.

För att lära dig dessa funktioner, använd följande länkar:

- [Skapa fallback-typsnitt](/slides/sv/nodejs-java/create-fallback-font)
- [Skapa samling av fallback-typsnitt](/slides/sv/nodejs-java/create-fallback-fonts-collection)
- [Rendera presentation med fallback-typsnitt](/slides/sv/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Hur skiljer sig fallback-typsnitt från typsnittssubstitution?**

Fallback tillämpas per tecken eller per Unicode-intervall när det primära typsnittet saknar specifika glyfer; det fyller endast i de saknade tecknen. [Substitution](/slides/sv/nodejs-java/font-substitution/) ersätter ett saknat eller otillgängligt typsnitt för ett helt körsegment eller textavsnitt med ett annat typsnitt. De kan kombineras, men deras räckvidd och urvalsloggik är olika.

**Sparas fallback-inställningarna i presentationsfilen?**

Nej. Fallback-konfigurationen existerar bara under bearbetnings-/renderingstid i biblioteket och serialiseras inte till PPTX. Presentationen lagrar inte dina fallback-regler.

**Påverkar fallback element som skapats av PowerPoint-objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går igenom samma renderingspipeline, så samma fallback-regler gäller för den som för vanlig text.