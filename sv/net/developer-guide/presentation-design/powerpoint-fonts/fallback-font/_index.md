---
title: Hantera reservtypsnitt för presentationer i .NET
linktitle: Reservtypsnitt
type: docs
weight: 50
url: /sv/net/fallback-font/
keywords:
- reservtypsnitt
- tillgängligt typsnitt
- glyf ersättning
- ange typsnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Se hur Aspose.Slides för .NET använder reservtypsnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originaltypsnitten inte är tillgängliga."
---
## **Introduktion**

Reservtypsnitt används när det typsnitt som anges för texten finns i systemet men saknar en nödvändig glyf. I så fall kan Aspose.Slides använda ett av de angivna reservtypsnitten för att ersätta den saknade glyfen.

## **Reservtypsnitt**

Aspose.Slides låter dig skapa reservtypsnitt, lägga till dem i en reservtypsnittssamling, ange reservtypsnittssamling för en viss presentation, ta bort reservtypsnitt från presentationen, specificera reglerna för att tillämpa reservtypsnitt och annat.

För att lära dig mer om dessa funktioner, använd följande länkar:

- [Skapa reservtypsnitt](/slides/sv/net/create-fallback-font)
- [Skapa samling av reservtypsnitt](/slides/sv/net/create-fallback-fonts-collection)
- [Rendera presentation med reservtypsnitt](/slides/sv/net/render-presentation-with-fallback-font)

## **FAQ**

**Hur skiljer sig reservtypsnitt från typsnittssubstitution?**

Reservtypsnitt tillämpas per tecken eller per Unicode‑intervall när huvudtypsnittet saknar specifika glyfer; det fyller bara i de saknade tecknen. [Substitution](/slides/sv/net/font-substitution/) ersätter ett saknat eller otillgängligt typsnitt för ett helt kör eller en textdel med ett annat typsnitt. De kan kombineras, men deras omfattning och urvalsmekanism är olika.

**Sparas reservtypsnittsinställningarna i presentationsfilen?**

Nej. Reservtypsnittskonfigurationen existerar endast under bearbetning/rendering i biblioteket och serialiseras inte till PPTX. Presentationen lagrar inte dina reservtypsnittsregler.

**Påverkar reservtypsnitt element som skapats av PowerPoint-objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går genom samma renderingspipeline, så samma reservtypsnittsregler gäller för den som för vanlig text.