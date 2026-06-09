---
title: Simplifique a Substituição de Fontes em Apresentações Usando JavaScript
linktitle: Substituição de Fonte
type: docs
weight: 60
url: /pt/nodejs-java/font-replacement/
keywords:
  - fonte
  - substituir fonte
  - substituição de fonte
  - alterar fonte
  - PowerPoint
  - OpenDocument
  - apresentação
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Substitua fontes de forma contínua em JavaScript com Aspose.Slides para Node.js via Java para garantir tipografia consistente em apresentações PowerPoint e OpenDocument."
---
## **Visão Geral**

O Aspose.Slides permite substituir uma fonte por outra em toda a apresentação. Quando uma fonte é substituída, todas as instâncias da fonte original são alteradas para a nova fonte.

Para executar a substituição de fonte, carregue a apresentação, defina a fonte de origem e a fonte de substituição, chame o método de substituição de fonte e salve a apresentação modificada como um arquivo PPTX. Essa abordagem é útil quando você deseja alterar intencionalmente de uma família de fontes para outra em toda a apresentação.

## **Substituir Fontes**

Se mudar de ideia sobre o uso de uma fonte, pode substituir essa fonte por outra. Todas as instâncias da fonte antiga serão substituídas pela nova fonte. 

O Aspose.Slides permite substituir uma fonte desta forma:

1. Carregue a apresentação relevante. 
2. Carregue a fonte que será substituída.
3. Carregue a nova fonte. 
4. Substitua a fonte. 
5. Grave a apresentação modificada como um arquivo PPTX.

Este código JavaScript demonstra a substituição de fonte:

```javascript
// Carrega uma apresentação
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Carrega a fonte de origem que será substituída
    var sourceFont = new aspose.slides.FontData("Arial");
    // Carrega a nova fonte
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Substitui as fontes
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Salva a apresentação
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Para definir regras que determinem o que acontece em certas condições (por exemplo, se uma fonte não puder ser acessada), consulte [**Substituição de Fonte**](/slides/pt/nodejs-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre "substituição de fonte", "substituição de fonte" e "fontes de fallback"?**

A substituição é uma troca intencional de uma família para outra em todo o documento. [Substituição](/slides/pt/nodejs-java/font-substitution/) é uma regra do tipo "se a fonte não estiver disponível, use X". [Fallback](/slides/pt/nodejs-java/fallback-font/) é aplicado de forma pontual para glifos ausentes individuais quando a fonte base está instalada, mas não contém os caracteres necessários.

**A substituição se aplica a slides mestre, layouts, notas e comentários?**

Sim. A substituição afeta todos os objetos da apresentação que utilizam a fonte original, incluindo slides mestre e notas; comentários também fazem parte do documento e são considerados pelo mecanismo de fontes.

**A fonte será alterada dentro de objetos OLE incorporados (por exemplo, Excel)?**

Não. [Conteúdo OLE](/slides/pt/nodejs-java/manage-ole/) é controlado por sua própria aplicação. A substituição na apresentação não reformata os dados internos OLE; eles podem ser exibidos como uma imagem ou como conteúdo editável externamente.

**Posso substituir uma fonte apenas em parte da apresentação (por slides ou regiões)?**

A substituição direcionada é possível se você mudar a fonte no nível dos objetos/faixas necessários, em vez de aplicar uma substituição global a todo o documento. A lógica geral de seleção de fonte durante a renderização permanece a mesma.

**Como posso determinar antecipadamente quais fontes a apresentação usa?**

Use o [gerenciador de fontes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/): ele fornece uma lista das [famílias em uso](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getfonts/) e informações sobre [substituições/"fontes desconhecidas"](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), o que ajuda a planejar a substituição.

**A substituição de fonte funciona ao converter para PDF/imagens?**

Sim. Durante a exportação, o Aspose.Slides aplica a mesma [sequência de seleção/substituição de fontes](/slides/pt/nodejs-java/font-selection-sequence/), portanto uma substituição feita previamente será mantida durante a conversão.

**Preciso instalar a fonte de destino no sistema ou posso anexar uma pasta de fontes?**

A instalação não é necessária: a biblioteca permite [carregar fontes externas](/slides/pt/nodejs-java/custom-font/) de pastas do usuário para uso durante a [renderização e exportação](/slides/pt/nodejs-java/convert-powerpoint/).

**A substituição corrigirá o "tofu" (quadrados) em vez de caracteres?**

Somente se a fonte de destino realmente contiver os glifos necessários. Caso contrário, [configure o fallback](/slides/pt/nodejs-java/fallback-font/) para cobrir os caracteres ausentes.