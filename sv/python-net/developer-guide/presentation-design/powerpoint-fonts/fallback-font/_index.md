---
title: Hantera fallback-typsnitt för presentationer i Python
linktitle: Fallback-typsnitt
type: docs
weight: 50
url: /sv/python-net/fallback-font/
keywords:
- fallback-typsnitt
- tillgängligt typsnitt
- teckenersättning
- ange typsnitt
- ange regel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Se hur Aspose.Slides för Python via .NET använder fallback-typsnitt för att hålla text läsbar i PowerPoint- och OpenDocument-presentationer när originaltypsnitten inte är tillgängliga."
---
## **Introduktion**

Fallback-typsnitt används när det typsnitt som specificerats för text finns i systemet men saknar ett behövt tecken. I så fall kan Aspose.Slides använda ett av de angivna fallback-typsnitten för att ersätta det saknade tecknet.

## **Fallback-typsnitt**

Aspose.Slides gör det möjligt att skapa fallback-typsnitt, lägga till dem i en samling av fallback-typsnitt, ange fallback-typsnittssamling för en viss presentation, ta bort fallback-typsnitt från en presentation, specificera regler för att tillämpa fallback-typsnitt och annat.

För att bli bekant med dessa funktioner, använd följande länkar:

- [Skapa fallback-typsnitt](/slides/sv/python-net/create-fallback-font)
- [Skapa samling av fallback-typsnitt](/slides/sv/python-net/create-fallback-fonts-collection)
- [Rendera presentation med fallback-typsnitt](/slides/sv/python-net/render-presentation-with-fallback-font)

## **Vanliga frågor**

**Hur skiljer sig fallback-typsnitt från teckensnittsbyte?**

Fallback tillämpas per tecken eller per Unicode‑intervall när huvudtypsnittet saknar specifika tecken; det fyller bara i de saknade tecknen. [Substitution](/slides/sv/python-net/font-substitution/) ersätter ett saknat eller otillgängligt typsnitt för ett helt löp eller en textdel med ett annat typsnitt. De kan kombineras, men deras räckvidd och urvalslogik är olika.

**Sparas fallback‑inställningarna i presentationsfilen?**

Nej. Fallback‑konfigurationen lever endast under bearbetning/rendering i biblioteket och serialiseras inte till PPTX‑filen. Presentationen lagrar inte dina fallback‑regler.

**Påverkar fallback element skapade av PowerPoint‑objekt (SmartArt, diagram, WordArt)?**

Ja. Text i dessa objekt går igenom samma renderingspipeline, så samma fallback‑regler gäller för dem som för vanlig text.