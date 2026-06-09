---
title: Simplificar a Substituição de Fontes em Apresentações no Android
linktitle: Substituição de Fontes
type: docs
weight: 60
url: /pt/androidjava/font-replacement/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- alterar fonte
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Substitua fontes de forma contínua no Aspose.Slides para Android via Java para garantir tipografia consistente em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite substituir uma fonte por outra em toda a apresentação. Quando uma fonte é substituída, todas as ocorrências da fonte original são alteradas para a nova fonte.

Para realizar a substituição de fonte, carregue a apresentação, defina a fonte de origem e a fonte de substituição, chame o método de substituição de fonte e salve a apresentação modificada como um arquivo PPTX. Essa abordagem é útil quando você deseja mudar intencionalmente de uma família de fontes para outra em toda a apresentação.

## **Substituir fontes**

Se você mudar de ideia sobre o uso de uma fonte, pode substituí‑la por outra fonte. Todas as ocorrências da fonte antiga serão substituídas pela nova fonte.

Aspose.Slides permite substituir uma fonte da seguinte forma:

1. Carregue a apresentação relevante.  
2. Carregue a fonte que será substituída.  
3. Carregue a nova fonte.  
4. Substitua a fonte.  
5. Grave a apresentação modificada como um arquivo PPTX.

Este código Java demonstra a substituição de fonte:

```java
// Carrega uma apresentação
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carrega a fonte de origem que será substituída
    IFontData sourceFont = new FontData("Arial");
    
    // Carrega a nova fonte
    IFontData destFont = new FontData("Times New Roman");
    
    // Substitui as fontes
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Salva a apresentação
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Para definir regras que determinam o que acontece em determinadas condições (por exemplo, se uma fonte não puder ser acessada), veja [**Substituição de Fonte**](/slides/pt/androidjava/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre "substituição de fonte", "substituição" e "fontes de fallback"?**

A substituição é uma mudança intencional de uma família para outra em todo o documento. [Substituição](/slides/pt/androidjava/font-substitution/) é uma regra como "se a fonte não estiver disponível, use X". [Fallback](/slides/pt/androidjava/fallback-font/) é aplicada de forma pontual para glifos ausentes quando a fonte base está instalada, mas não contém os caracteres necessários.

**A substituição se aplica a slides mestres, layouts, notas e comentários?**

Sim. A substituição afeta todos os objetos da apresentação que utilizam a fonte original, incluindo slides mestres e notas; comentários também fazem parte do documento e são considerados pelo mecanismo de fontes.

**A fonte será alterada dentro de objetos OLE incorporados (por exemplo, Excel)?**

Não. O [conteúdo OLE](/slides/pt/androidjava/manage-ole/) é controlado pelo seu próprio aplicativo. A substituição na apresentação não reformata os dados internos do OLE; eles podem ser exibidos como imagem ou como conteúdo editável externamente.

**Posso substituir uma fonte apenas em parte da apresentação (por slides ou regiões)?**

A substituição direcionada é possível se você alterar a fonte no nível dos objetos/faixas necessários, em vez de aplicar uma substituição global a todo o documento. A lógica geral de seleção de fontes durante a renderização permanece a mesma.

**Como posso determinar antecipadamente quais fontes a apresentação usa?**

Use o [gerenciador de fontes](/reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/) da apresentação: ele fornece uma lista das [famílias em uso](/reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/#getFonts--) e informações sobre [substituições/"fontes desconhecidas"](/reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), o que ajuda a planejar a substituição.

**A substituição de fonte funciona ao converter para PDF/imagens?**

Sim. Durante a exportação, Aspose.Slides aplica a mesma [sequência de seleção/substituição de fontes](/slides/pt/androidjava/font-selection-sequence/), portanto uma substituição feita previamente será respeitada durante a conversão.

**Preciso instalar a fonte de destino no sistema ou posso anexar uma pasta de fontes?**

A instalação não é obrigatória: a biblioteca permite [carregar fontes externas](/slides/pt/androidjava/custom-font/) de pastas do usuário para uso durante a [renderização e exportação](/slides/pt/androidjava/convert-powerpoint/).

**A substituição corrigirá "tofu" (quadrados) em vez de caracteres?**

Somente se a fonte de destino realmente contiver os glifos necessários. Caso contrário, [configure o fallback](/slides/pt/androidjava/fallback-font/) para cobrir os caracteres ausentes.