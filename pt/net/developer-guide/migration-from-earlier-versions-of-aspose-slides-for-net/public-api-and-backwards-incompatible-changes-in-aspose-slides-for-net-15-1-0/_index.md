---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 15.1.0
linktitle: Aspose.Slides para .NET 15.1.0
type: docs
weight: 130
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e semelhantes [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/), e outras mudanças introduzidas com a API do Aspose.Slides for .NET 15.1.0.

{{% /alert %}} 
## **Alterações na API Pública**
#### **Funcionalidade de Substituição de Fontes Foi Adicionada**
Foi adicionada a possibilidade de substituir fontes globalmente em toda a apresentação e temporariamente para renderização.

Foi introduzida a nova propriedade "FontsManager" da classe Presentation. A classe FontsManager possui os seguintes membros:

**IFontSubstRuleCollection FontSubstRuleList** Propriedade

Esta coleção de instâncias IFontSubstRule é usada para substituir fontes durante a renderização. IFontSubstRule possui as propriedades SourceFont e DestFont que implementam a interface IFontData e a propriedade ReplaceFontCondition que permite escolher a condição de substituição ("WhenInaccessible" ou "Always").

**IFontData[] GetFonts()** Método

Usado para recuperar todas as fontes usadas na apresentação atual.

**ReplaceFont** Métodos

Usado para substituir a fonte de forma persistente na apresentação.  

O exemplo a seguir demonstra como substituir a fonte na apresentação:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Outro exemplo demonstra a substituição de fontes para renderização quando inacessível:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // A fonte Arial será usada em vez da SomeRareFont quando inacessível

            pres.Slides[0].GetThumbnail();

```