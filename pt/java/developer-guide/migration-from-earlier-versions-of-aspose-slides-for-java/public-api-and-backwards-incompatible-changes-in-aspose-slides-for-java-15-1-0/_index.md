---
title: API Pública e Alterações Incompatíveis com Versões Anteriores no Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações que quebram compatibilidade no Aspose.Slides for Java para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}}

Esta página lista todas as [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) classes, methods, properties e assim por diante, quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introduzidas com a API Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="info" %}}

Existem problemas conhecidos com alguns marcadores de imagem e objetos WordArt, que serão corrigidos no Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Funcionalidade de substituição de fontes foi adicionada**
A possibilidade de substituir fontes globalmente em toda a apresentação e temporariamente durante a renderização foi adicionada.

Foi introduzido o novo método **getFontsManager()** da classe **Presentation**. A classe **FontsManager** possui os seguintes membros:

**IFontSubstRuleCollection getFontSubstRuleList**() método

Esta é a coleção de instâncias **IFontSubstRule** usadas para substituir fontes durante a renderização. **IFontSubstRule** tem os métodos **getSourceFont()** e **getDestFont()**, que implementam a interface **IFontData**, e o método **getReplaceFontCondition()**, que permite escolher a condição de substituição (“WhenInaccessible” ou “Always”).

**IFontData[] getFonts()** método pode ser usado para recuperar todas as fontes usadas na apresentação atual.

**replaceFont(...)** métodos podem ser usados para substituir permanentemente uma fonte em uma apresentação.

O exemplo a seguir mostra como substituir uma fonte em uma apresentação:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Outro exemplo demonstra a substituição de fonte para renderização quando ela está inacessível:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // A fonte Arial será usada em vez da SomeRareFont quando inacessível.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```