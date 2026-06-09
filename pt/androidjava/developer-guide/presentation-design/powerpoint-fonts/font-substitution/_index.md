---
title: Configurar Substituição de Fonte em Apresentações no Android
linktitle: Substituição de Fonte
type: docs
weight: 70
url: /pt/androidjava/font-substitution/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- substituir fonte
- substituição de fonte
- regra de substituição
- regra de substituição
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Habilite a substituição de fonte ideal no Aspose.Slides para Android via Java ao converter apresentações PowerPoint e OpenDocument para outros formatos de arquivo."
---
## **Visão geral**

A substituição de fonte permite que o Aspose.Slides use outra fonte quando a fonte original da apresentação não está disponível durante a renderização ou conversão. Você pode verificar quais fontes foram substituídas usando o método `getSubstitutions` da interface `IFontsManager`.

O Aspose.Slides também permite que você defina regras de substituição de fontes. Por exemplo, você pode especificar que uma fonte inacessível deve ser substituída por outra fonte disponível e, em seguida, aplicar essas regras por meio do gerenciador de fontes da apresentação.

## **Definir regras de substituição de fontes**

O Aspose.Slides permite que você defina regras para fontes que determinam o que deve ser feito em certas condições (por exemplo, quando uma fonte não pode ser acessada) da seguinte forma:

1. Carregue a apresentação relevante.
2. Carregue a fonte que será substituída.
3. Carregue a nova fonte.
4. Adicione uma regra para a substituição.
5. Adicione a regra à coleção de regras de substituição de fonte da apresentação.
6. Gere a imagem do slide para observar o efeito.

Este código Java demonstra o processo de substituição de fonte:

```java
// Carrega uma apresentação
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carrega a fonte de origem que será substituída
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Carrega a nova fonte
    IFontData destFont = new FontData("Arial");
    
    // Adiciona uma regra de fonte para substituição de fonte
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Adiciona a regra à coleção de regras de substituição de fonte
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Adiciona uma coleção de regras de fonte à lista de regras
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // A fonte Arial será usada no lugar de SomeRareFont quando esta última estiver inacessível
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
Você pode querer ver [**Substituição de Fonte**](/slides/pt/androidjava/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes participam do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas são adequadas para cenários de texto regular em que o Aspose.Slides pode substituir uma fonte inacessível por outra fonte disponível de acordo com a regra configurada.

No entanto, as equações matemáticas do Office têm uma limitação importante. Se uma equação foi criada com **Cambria Math**, o Aspose.Slides ainda pode exigir a fonte original **Cambria Math** para calcular e renderizar o layout da equação corretamente. Por causa disso, substituir **Cambria Math** por outra fonte matemática, como **STIX Two Math**, não é suportado para renderização de equações e ainda pode resultar em uma exceção indicando que **Cambria Math** é necessária.

Para converter essas apresentações com sucesso, certifique‑se de que **Cambria Math** esteja disponível para o Aspose.Slides em tempo de execução. Você pode instalar a fonte no sistema operacional ou fornecê‑la como uma [fonte externa](/slides/pt/androidjava/custom-font/) para que ela participe do processo normal de seleção de fontes durante a renderização e conversão.

Essa limitação é específica para a renderização de equações. As regras padrão de substituição de fontes descritas acima ainda se aplicam ao texto regular da apresentação quando a fonte original está inacessível.

## **Perguntas Frequentes**

**Qual é a diferença entre substituição de fonte e substituição de fonte?**

[Substituição](/slides/pt/androidjava/font-replacement/) é uma substituição forçada de uma fonte por outra em toda a apresentação. Substituição é uma regra que é acionada sob uma condição específica, por exemplo quando a fonte original não está disponível, e então uma fonte alternativa designada é usada.

**Quando exatamente as regras de substituição são aplicadas?**

As regras participam da sequência padrão de [seleção de fonte](/slides/pt/androidjava/font-selection-sequence/) que é avaliada durante o carregamento, renderização e conversão; se a fonte escolhida não estiver disponível, a substituição ou substituição é aplicada.

**Qual é o comportamento padrão se nem substituição nem substituição estiverem configuradas e a fonte estiver ausente no sistema?**

A biblioteca tentará escolher a fonte de sistema mais próxima disponível, semelhante ao comportamento do PowerPoint.

**Posso anexar fontes externas personalizadas em tempo de execução para evitar a substituição?**

Sim. Você pode [adicionar fontes externas](/slides/pt/androidjava/custom-font/) em tempo de execução para que a biblioteca as considere na seleção e renderização, inclusive em conversões subsequentes.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. A Aspose não distribui fontes pagas ou gratuitas; você adiciona e usa fontes por sua própria conta e responsabilidade.

**Existem diferenças no comportamento de substituição no Windows, Linux e macOS?**

Sim. A descoberta de fontes começa a partir dos diretórios de fontes do sistema operacional. O conjunto de fontes padrão disponíveis e os caminhos de busca diferem entre as plataformas, o que afeta a disponibilidade e a necessidade de substituição.

**Como devo preparar o ambiente para minimizar substituições inesperadas durante conversões em lote?**

Sincronize o conjunto de fontes entre máquinas ou contêineres, [adicione as fontes externas](/slides/pt/androidjava/custom-font/) necessárias para os documentos de saída e [incorpore fontes](/slides/pt/androidjava/embedded-font/) nas apresentações quando possível, para que as fontes selecionadas estejam disponíveis durante a renderização.