---
title: "Hantera fallback‑teckensnitt för presentationer i C++"
linktitle: "Fallback‑teckensnitt"
type: docs
weight: 50
url: /sv/cpp/fallback-font/
keywords:
- fallback‑teckensnitt
- tillgängligt teckensnitt
- glyf‑ersättning
- specificera teckensnitt
- specificera regel
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Se hur Aspose.Slides för C++ använder fallback‑teckensnitt för att hålla text läsbar i PowerPoint‑ och OpenDocument‑presentationer när originalteckensnitt inte är tillgängliga."
---
## **Introduktion**

Fallback‑teckensnitt används när det teckensnitt som är specificerat för text är tillgängligt i systemet men saknar en nödvändig glyf. I så fall kan Aspose.Slides använda ett av de angivna fallback‑teckensnitten för att ersätta den saknade glyfen.

## **Fallback‑teckensnitt**
Fallback‑teckensnitt används när det teckensnitt som är specificerat för text är tillgängligt i systemet, men detta teckensnitt saknar en nödvändig glyf. I så fall är det möjligt att använda ett av de angivna fallback‑teckensnitten för glyf‑ersättningen.

Aspose.Slides gör det möjligt att skapa fallback‑teckensnitt, lägga till dem i en fallback‑teckensnittssamling, ange fallback‑teckensnittssamling för en viss presentation, ta bort fallback‑teckensnitt från presentationen, specificera regler för att tillämpa fallback‑teckensnitt och mer.

För att bli bekant med dessa funktioner, använd följande länkar:

- [Skapa fallback‑teckensnitt](/slides/sv/cpp/create-fallback-font)
- [Skapa samling av fallback‑teckensnitt](/slides/sv/cpp/create-fallback-fonts-collection)
- [Rendera presentation med fallback‑teckensnitt](/slides/sv/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Hur skiljer sig fallback‑teckensnitt från teckensnittssubstitution?**

Fallback tillämpas per tecken eller per Unicode‑intervall när det primära teckensnittet saknar specifika glyfer; det fyller endast de saknade tecknen. [Substitution](/slides/sv/cpp/font-substitution/) ersätter ett saknat eller otillgängligt teckensnitt för en hel körning eller textavsnitt med ett annat teckensnitt. De kan kombineras, men deras omfattning och urvallogik är olika.

**Sparas fallback‑inställningarna i presentationsfilen?**

Nej. Fallback‑konfigurationen lever under bearbetnings‑/renderingstid i biblioteket och serialiseras inte till PPTX. Presentationen lagrar inte dina fallback‑regler.

**Påverkar fallback element som skapats av PowerPoint‑objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går igenom samma renderingspipeline, så samma fallback‑regler gäller för den som för vanlig text.