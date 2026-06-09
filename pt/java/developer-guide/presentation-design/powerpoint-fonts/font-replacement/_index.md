---
title: Simplifique a substituição de fontes em apresentações usando Java
linktitle: Substituição de Fontes
type: docs
weight: 60
url: /pt/java/font-replacement/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- alterar fonte
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Substitua fontes de forma transparente no Aspose.Slides para Java para garantir tipografia consistente em apresentações PowerPoint e OpenDocument."
---
## **Visão Geral**

Aspose.Slides permite substituir uma fonte por outra em toda a apresentação. Quando uma fonte é substituída, todas as ocorrências da fonte original são alteradas para a nova fonte.

Para realizar a substituição de fonte, carregue a apresentação, defina a fonte de origem e a fonte de substituição, chame o método de substituição de fonte e salve a apresentação modificada como um arquivo PPTX. Essa abordagem é útil quando você deseja trocar intencionalmente uma família de fontes por outra em toda a apresentação.

## **Substituir Fontes**

Se mudar de ideia sobre o uso de uma fonte, você pode substituí‑la por outra. Todas as ocorrências da fonte antiga serão trocadas pela nova fonte.

Aspose.Slides permite substituir uma fonte desta forma:

1. Carregue a apresentação relevante.  
2. Carregue a fonte que será substituída.  
3. Carregue a nova fonte.  
4. Substitua a fonte.  
5. Grave a apresentação modificada como um arquivo PPTX.

Este código Java demonstra a substituição de fontes:

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

{{% alert title="Observação" color="warning" %}} 
Para definir regras que determinam o que acontece em determinadas condições (por exemplo, se uma fonte não puder ser acessada), veja [**Font Substitution**](/slides/pt/java/font-substitution/). 
{{% /alert %}}

## **Perguntas Frequentes**

**Qual é a diferença entre "font replacement", "font substitution" e "fallback fonts"?**

A substituição é uma troca intencional de uma família por outra em todo o documento. [Substitution](/slides/pt/java/font-substitution/) é uma regra como “se a fonte não estiver disponível, use X”. [Fallback](/slides/pt/java/fallback-font/) é aplicada de forma cirúrgica para glifos ausentes individuais quando a fonte base está instalada, mas não contém os caracteres necessários.

**A substituição se aplica a slides mestres, layouts, notas e comentários?**

Sim. A substituição afeta todos os objetos da apresentação que usam a fonte original, incluindo slides mestres e notas; comentários também fazem parte do documento e são considerados pelo mecanismo de fontes.

**A fonte será alterada dentro de objetos OLE incorporados (por exemplo, Excel)?**

Não. O [conteúdo OLE](/slides/pt/java/manage-ole/) é controlado pelo seu próprio aplicativo. A substituição na apresentação não reformatará os dados internos do OLE; eles podem ser exibidos como imagem ou como conteúdo editável externamente.

**Posso substituir uma fonte apenas em parte da apresentação (por slides ou regiões)?**

A substituição direcionada é possível se você mudar a fonte no nível dos objetos/intervalos necessários, em vez de aplicar uma substituição global a todo o documento. A lógica geral de seleção de fontes durante a renderização permanece a mesma.

**Como posso determinar antecipadamente quais fontes a apresentação usa?**

Use o [gerenciador de fontes](/slides/pt/java/font-manager/) da apresentação: ele fornece uma lista das [famílias em uso](/slides/pt/java/font-manager/#getFonts--) e informações sobre [substituições/\"unknown\" fontes](/slides/pt/java/font-manager/#getSubstitutions--), o que ajuda a planejar a substituição.

**A substituição de fonte funciona ao converter para PDF/imagens?**

Sim. Durante a exportação, Aspose.Slides aplica a mesma [sequência de seleção/substituição de fontes](/slides/pt/java/font-selection-sequence/), portanto, uma substituição feita previamente será respeitada na conversão.

**Preciso instalar a fonte alvo no sistema ou posso anexar uma pasta de fontes?**

Instalação não é necessária: a biblioteca permite [carregar fontes externas](/slides/pt/java/custom-font/) de pastas do usuário para uso durante a [renderização e exportação](/slides/pt/java/convert-powerpoint/).

**A substituição corrigirá “tofu” (quadros) em vez de caracteres?**

Só se a fonte alvo realmente contiver os glifos necessários. Caso contrário, [configure fallback](/slides/pt/java/fallback-font/) para cobrir os caracteres ausentes.