---
title: Hantera reservtypsnitt för presentationer i Java
linktitle: Reservtypsnitt
type: docs
weight: 50
url: /sv/java/fallback-font/
keywords:
- reservtypsnitt
- tillgängligt typsnitt
- teckengrafikbyte
- ange typsnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Se hur Aspose.Slides for Java använder reservtypsnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originaltypsnitten inte är tillgängliga."
---
## **Introduktion**

Reservtypsnitt används när det typsnitt som anges för text finns i systemet men saknar en nödvändig teckengrafik. I så fall kan Aspose.Slides använda ett av de angivna reservtypsnitten för att ersätta den saknade teckengrafiken.

## **Reservtypsnitt**

Aspose.Slides möjliggör att skapa reservtypsnitt, lägga till dem i en samling av reservtypsnitt, ange en samling av reservtypsnitt för en viss presentation, ta bort reservtypsnitt från presentationen, specificera reglerna för att använda reservtypsnitt och annat.

För att bli bekant med dessa funktioner, använd följande länkar:

- [Skapa reservtypsnitt](/slides/sv/java/create-fallback-font)
- [Skapa samling av reservtypsnitt](/slides/sv/java/create-fallback-fonts-collection)
- [Rendera presentation med reservtypsnitt](/slides/sv/java/render-presentation-with-fallback-font)

## **FAQ**

**Hur skiljer sig reservtypsnitt från typsnittsbyte?**

Reservtypsnitt tillämpas per tecken eller per Unicode‑intervall när huvudtypsnittet saknar specifika teckengrafiker; det fyller endast de saknade tecknen. [Substitution](/slides/sv/java/font-substitution/) ersätter ett saknat eller otillgängligt typsnitt för ett helt löp eller en textdel med ett annat typsnitt. De kan kombineras, men deras omfattning och urvalsslogik är olika.

**Sparas reservtypsnittsinställningar i presentationsfilen?**

Nej. Reservtypsnittskonfigurationen finns endast under bearbetning/rendering i biblioteket och serialiseras inte till PPTX. Presentationen lagrar inte dina reservtypsnittsregler.

**Påverkar reservtypsnitt element skapade av PowerPoint‑objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går igenom samma renderingspipeline, så samma reservtypsnittsregler gäller för den som för vanlig text.