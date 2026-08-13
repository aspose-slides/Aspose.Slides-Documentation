---
title: "Hur man lägger till sidhuvuden och sidfötter i presentationer i Java"
linktitle: "Lägg till sidhuvud och sidfot"
type: docs
weight: 20
url: /sv/java/how-to-add-header-footer-in-a-presentation/
keywords:
- migration
- lägg till sidhuvud
- lägg till sidfot
- äldre kod
- modern kod
- äldre tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till sidhuvuden och sidfötter i PowerPoint PPT-, PPTX- och ODP-presentationer i Java med både äldre och moderna Aspose.Slides‑API:er."
---
{{% alert color="info" %}}
En ny [Aspose.Slides for Java API](https://docs.aspose.com/slides/sv/java/) har släppts och nu stöder detta enda produkt möjligheten att generera PowerPoint‑dokument från grunden och redigera befintliga.
{{% /alert %}}
## **Support for Legacy Code**
För att kunna använda den äldre koden som utvecklats med Aspose.Slides for Java versioner tidigare än 13.x måste du göra några mindre ändringar i din kod så att den fungerar som tidigare. Alla klasser som fanns i den gamla Aspose.Slides for Java under Aspose.Slide‑ och Aspose.Slides.Pptx‑rymden har nu slagits samman i ett enda Aspose.Slides‑namespace. Se följande enkla kodexempel för att lägga till sidhuvud och sidfot i en presentation i det äldre Aspose.Slides‑API:t och följ stegen som beskriver hur du migrerar till det nya sammanslagna API:t.
## **Legacy Aspose.Slides for Java Approach**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **New Aspose.Slides for Java 13.x Approach**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}