---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 15.1.0
linktitle: Aspose.Slides para Java 15.1.0
type: docs
weight: 100
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e etc. [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) , quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introduzidas com a API Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Existem problemas conhecidos com alguns marcadores de imagem e objetos WordArt que serão corrigidos no Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **A funcionalidade de substituição de fontes foi adicionada**
A possibilidade de substituir fontes globalmente em toda a apresentação e temporariamente para renderização foi adicionada.

Foi introduzido o novo método **getFontsManager()** da classe Presentation. A classe FontsManager possui os seguintes membros:

**IFontSubstRuleCollection getFontSubstRuleList**() método

Esta é a coleção de instâncias IFontSubstRule usadas para substituir fontes durante a renderização. IFontSubstRule possui os métodos **getSourceFont()** e **getDestFont()** que implementam a interface IFontData e o método **getReplaceFontCondition()** que permite escolher a condição de substituição ("WhenInaccessible" ou "Always").

**IFontData[] getFonts()** método pode ser usado para recuperar todas as fontes usadas na apresentação atual.

**replaceFont(...)** métodos podem ser usados para substituir persistentemente uma fonte em uma apresentação.  

O exemplo a seguir mostra como substituir uma fonte em uma apresentação:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Outro exemplo mostra a substituição de fontes para renderização quando a fonte está inacessível:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// A fonte Arial será usada em vez da SomeRareFont quando inacessível

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```