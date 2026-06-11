---
title: Hantera fallback-typsnitt för presentationer på Android
linktitle: Fallback-typsnitt
type: docs
weight: 50
url: /sv/androidjava/fallback-font/
keywords:
- fallback-typsnitt
- tillgängligt typsnitt
- glyfbyte
- ange typsnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Se hur Aspose.Slides för Android via Java använder fallback-typsnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originaltypsnitten inte är tillgängliga."
---
## **Introduktion**

Fallback-typsnitt används när det typsnitt som angivits för texten finns i systemet, men detta typsnitt saknar en nödvändig glyf. I så fall kan man använda ett av de angivna fallback-typsnitten för att ersätta glyfen.

## **Fallback-typsnitt**

Aspose.Slides tillåter att skapa fallback-typsnitt, lägga till dem i en fallback-typsnittssamling, ange fallback-typsnittssamling för en viss presentation, ta bort fallback-typsnitt från presentationen, specificera regler för att tillämpa fallback-typsnitt och annat.

För att bli bekant med dessa funktioner, använd följande länkar:

- [Skapa fallback-typsnitt](/slides/sv/androidjava/create-fallback-font)
- [Skapa samling av fallback-typsnitt](/slides/sv/androidjava/create-fallback-fonts-collection)
- [Rendera presentation med fallback-typsnitt](/slides/sv/androidjava/render-presentation-with-fallback-font)

## **Vanliga frågor**

**Hur skiljer sig fallback-typsnitt från teckensnittssubstitution?**

Fallback tillämpas per tecken eller per Unicode-intervall när det primära typsnittet saknar specifika glyfer; den fyller endast i de saknade tecknen. [Substitution](/slides/sv/androidjava/font-substitution/) ersätter ett saknat eller otillgängligt typsnitt för ett helt textflöde eller en textdel med ett annat typsnitt. De kan kombineras, men deras omfattning och urvallogik är olika.

**Sparas fallback-inställningar i presentationsfilen?**

Nej. Fallback-konfigurationen existerar endast under bearbetnings-/renderingstid i biblioteket och serialiseras inte till PPTX. Presentationen lagrar inte dina fallback-regler.

**Påverkar fallback element som skapats av PowerPoint-objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går igenom samma renderingspipeline, så samma fallback-regler gäller för den som för vanlig text.