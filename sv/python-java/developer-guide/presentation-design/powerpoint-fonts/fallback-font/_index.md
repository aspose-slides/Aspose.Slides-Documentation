---
title: Hantera fallback-teckensnitt för presentationer i Python via Java
linktitle: Fallback-teckensnitt
type: docs
weight: 50
url: /sv/python-java/fallback-font/
keywords:
- fallback-teckensnitt
- tillgängligt teckensnitt
- glyfutbyte
- ange teckensnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Se hur Aspose.Slides för Python via Java använder fallback-teckensnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originalteckensnitt inte är tillgängliga."
---
## **Introduktion**

Fallback-teckensnitt används när det teckensnitt som angivits för text finns i systemet men saknar en nödvändig glyf. I så fall kan Aspose.Slides använda ett av de angivna fallback-teckensnitten för att ersätta den saknade glyfen.

## **Fallback-teckensnitt**

Aspose.Slides låter dig skapa fallback-teckensnitt, lägga till dem i en fallback-teckensnittssamling, ange fallback-teckensnittssamlingen för en viss presentation, ta bort fallback-teckensnitt från presentationen, specificera reglerna för att tillämpa fallback-teckensnitt och utföra andra relaterade operationer.

För att bli bekant med dessa funktioner, använd följande länkar:

- [Skapa fallback-teckensnitt](/slides/sv/python-java/create-fallback-font/)
- [Skapa samling av fallback-teckensnitt](/slides/sv/python-java/create-fallback-fonts-collection/)
- [Rendera presentation med fallback-teckensnitt](/slides/sv/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**Hur skiljer sig fallback-teckensnitt från teckensnittsbyte?**

Fallback tillämpas per tecken eller per Unicode-område när det primära teckensnittet saknar specifika glyfer; det fyller bara i de saknade tecknen. [Substitution](/slides/sv/python-java/font-substitution/) ersätter ett saknat eller otillgängligt teckensnitt för ett helt segment eller en textdel med ett annat teckensnitt. De kan kombineras, men deras omfattning och urvallogik är olika.

**Sparas fallback-inställningar i presentationsfilen?**

Nej. Fallback-konfigurationen existerar vid bearbetning/rendering i biblioteket och serialiseras inte till PPTX. Presentationen lagrar inte dina fallback-regler.

**Påverkar fallback element skapade av PowerPoint-objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går igenom samma renderingspipeline, så samma fallback-regler gäller för den som för vanlig text.