---
title: Configurar Substituição de Fonte em Apresentações Usando Java
linktitle: Substituição de Fonte
type: docs
weight: 70
url: /pt/java/font-substitution/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- trocar fonte
- substituição de fonte
- regra de substituição
- regra de substituição
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Habilite a substituição ótima de fontes no Aspose.Slides para Java ao converter apresentações PowerPoint e OpenDocument para outros formatos de arquivo."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use outra fonte quando a fonte original da apresentação não está disponível durante a renderização ou conversão. Você pode verificar quais fontes foram substituídas usando o método `getSubstitutions` da interface `IFontsManager`.

O Aspose.Slides também permite definir regras de substituição de fontes. Por exemplo, você pode especificar que uma fonte inacessível seja substituída por outra fonte disponível e então aplicar essas regras através do gerenciador de fontes da apresentação.

## **Definir regras de substituição de fontes**

O Aspose.Slides permite definir regras para fontes que determinam o que deve ser feito em determinadas condições (por exemplo, quando uma fonte não pode ser acessada) da seguinte maneira:

1. Carregue a apresentação relevante.
2. Carregue a fonte que será substituída.
3. Carregue a nova fonte.
4. Adicione uma regra para a substituição.
5. Adicione a regra à coleção de regras de substituição de fontes da apresentação.
6. Gere a imagem do slide para observar o efeito.

Este código Java demonstra o processo de substituição de fontes:

```java
// Carrega uma apresentação
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carrega a fonte de origem que será substituída
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Carrega a nova fonte
    IFontData destFont = new FontData("Arial");
    
    // Adiciona uma regra de fonte para substituição
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Adiciona a regra à coleção de regras de substituição de fontes
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Adiciona uma coleção de regras de fonte à lista de regras
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // A fonte Arial será usada no lugar da SomeRareFont quando esta estiver inacessível
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Salva a imagem no disco no formato JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Você pode querer ver [**Font Replacement**](/slides/pt/java/font-replacement/). 
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes participam do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas são adequadas para cenários de texto regular onde o Aspose.Slides pode substituir uma fonte inacessível por outra fonte disponível de acordo com a regra configurada.

Entretanto, as equações matemáticas do Office têm uma limitação importante. Se uma equação foi criada com **Cambria Math**, o Aspose.Slides pode ainda exigir a fonte original **Cambria Math** para calcular e renderizar corretamente o layout da equação. Por causa disso, substituir **Cambria Math** por outra fonte matemática, como **STIX Two Math**, não é suportado para a renderização de equações e ainda pode resultar em uma exceção indicando que **Cambria Math** é necessária.

Para converter essas apresentações com sucesso, certifique‑se de que **Cambria Math** esteja disponível para o Aspose.Slides em tempo de execução. Você pode instalar a fonte no sistema operacional ou fornecê‑la como uma [external font](/slides/pt/java/custom-font/) para que ela participe do processo normal de seleção de fontes durante a renderização e conversão.

Esta limitação é específica para a renderização de equações. As regras padrão de substituição de fontes descritas acima ainda se aplicam ao texto regular da apresentação quando a fonte original está inacessível.

## **Perguntas Frequentes**

**Qual é a diferença entre substituição de fonte e substituição de fonte?**

[Replacement](/slides/pt/java/font-replacement/) é uma sobrescrição forçada de uma fonte por outra em toda a apresentação. Substituição é uma regra que é acionada sob uma condição específica, por exemplo quando a fonte original não está disponível, e então uma fonte de fallback designada é usada.

**Quando exatamente as regras de substituição são aplicadas?**

As regras participam da sequência padrão de [font selection](/slides/pt/java/font-selection-sequence/) que é avaliada durante o carregamento, renderização e conversão; se a fonte escolhida não estiver disponível, a substituição ou substituição forçada é aplicada.

**Qual é o comportamento padrão se nem substituição nem substituição de fonte estiverem configuradas e a fonte estiver ausente no sistema?**

A biblioteca tentará escolher a fonte do sistema mais próxima disponível, similar ao comportamento do PowerPoint.

**Posso anexar fontes externas personalizadas em tempo de execução para evitar a substituição?**

Sim. Você pode [add external fonts](/slides/pt/java/custom-font/) em tempo de execução para que a biblioteca as considere na seleção e renderização, inclusive para conversões subsequentes.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. A Aspose não distribui fontes pagas ou gratuitas; você adiciona e usa fontes por sua conta e risco.

**Existem diferenças no comportamento de substituição entre Windows, Linux e macOS?**

Sim. A descoberta de fontes inicia a partir dos diretórios de fontes do sistema operacional. O conjunto padrão de fontes disponíveis e os caminhos de pesquisa diferem entre as plataformas, o que afeta a disponibilidade e a necessidade de substituição.

**Como devo preparar o ambiente para minimizar substituições inesperadas durante conversões em lote?**

Sincronize o conjunto de fontes entre máquinas ou contêineres, [add the external fonts](/slides/pt/java/custom-font/) necessários para os documentos de saída e [embed fonts](/slides/pt/java/embedded-font/) nas apresentações sempre que possível, para que as fontes escolhidas estejam disponíveis durante a renderização.