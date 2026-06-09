---
title: Configurar substituição de fontes em apresentações usando JavaScript
linktitle: Substituição de fontes
type: docs
weight: 70
url: /pt/nodejs-java/font-substitution/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- trocar fonte
- substituição de fonte
- regra de substituição
- regra de troca
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Habilite a substituição ótima de fontes no Aspose.Slides para Node.js ao converter apresentações PowerPoint e OpenDocument para outros formatos de arquivo em JavaScript."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use outra fonte quando a fonte original da apresentação não está disponível durante a renderização ou conversão. Você pode verificar quais fontes foram substituídas usando o método `getSubstitutions` da classe `FontsManager`.

O Aspose.Slides também permite definir regras de substituição de fontes. Por exemplo, você pode especificar que uma fonte inacessível deve ser substituída por outra fonte disponível e, em seguida, aplicar essas regras através do gerenciador de fontes da apresentação.

## **Definir regras de substituição de fontes**

O Aspose.Slides permite definir regras para fontes que determinam o que deve ser feito em determinadas condições (por exemplo, quando uma fonte não pode ser acessada) da seguinte forma:

1. Carregue a apresentação relevante.  
2. Carregue a fonte que será substituída.  
3. Carregue a nova fonte.  
4. Adicione uma regra para a substituição.  
5. Adicione a regra à coleção de regras de substituição de fonte da apresentação.  
6. Gere a imagem do slide para observar o efeito.

Este código JavaScript demonstra o processo de substituição de fontes:

```javascript
// Carrega uma apresentação
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Carrega a fonte de origem que será substituída
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Carrega a nova fonte
    var destFont = new aspose.slides.FontData("Arial");
    // Adiciona uma regra de fonte para substituição de fonte
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Adiciona a regra à coleção de regras de substituição de fontes
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Adiciona a coleção de regras de fonte à lista de regras
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // A fonte Arial será usada no lugar da SomeRareFont quando esta estiver inacessível
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Salva a imagem no disco no formato JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Você pode querer ver [**Font Replacement**](/slides/pt/nodejs-java/font-replacement/).

{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes participam do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas são adequadas para cenários de texto comum, nos quais o Aspose.Slides pode substituir uma fonte inacessível por outra fonte disponível de acordo com a regra configurada.

Entretanto, as equações matemáticas do Office têm uma limitação importante. Se uma equação foi criada com **Cambria Math**, o Aspose.Slides ainda pode exigir a fonte original **Cambria Math** para calcular e renderizar o layout da equação corretamente. Por causa disso, substituir **Cambria Math** por outra fonte matemática, como **STIX Two Math**, não é suportado para a renderização de equações e pode ainda resultar em uma exceção indicando que **Cambria Math** é necessária.

Para converter tais apresentações com sucesso, certifique‑se de que **Cambria Math** esteja disponível para o Aspose.Slides em tempo de execução. Você pode instalar a fonte no sistema operacional ou fornecê‑la como uma [external font](/slides/pt/nodejs-java/custom-font/) para que ela participe do processo normal de seleção de fontes durante a renderização e conversão.

Essa limitação é específica para a renderização de equações. As regras padrão de substituição de fontes descritas acima continuam válidas para o texto regular da apresentação quando a fonte original está inacessível.

## **FAQ**

**Qual é a diferença entre substituição de fonte e substituição de fonte (font replacement)?**

[Replacement](/slides/pt/nodejs-java/font-replacement/) é uma sobrescrita forçada de uma fonte por outra em toda a apresentação. Substituição (substitution) é uma regra que é acionada sob uma condição específica, por exemplo quando a fonte original está indisponível, e então uma fonte de reserva designada é usada.

**Quando exatamente as regras de substituição são aplicadas?**

As regras participam da sequência padrão de [font selection](/slides/pt/nodejs-java/font-selection-sequence/) que é avaliada durante o carregamento, renderização e conversão; se a fonte escolhida estiver indisponível, a substituição ou substituição forçada é aplicada.

**Qual é o comportamento padrão se nem substituição nem substituição (replacement) estiverem configuradas e a fonte estiver faltando no sistema?**

A biblioteca tentará escolher a fonte do sistema mais próxima disponível, similar ao comportamento do PowerPoint.

**Posso anexar fontes externas personalizadas em tempo de execução para evitar substituição?**

Sim. Você pode [add external fonts](/slides/pt/nodejs-java/custom-font/) em tempo de execução para que a biblioteca as considere na seleção e renderização, inclusive para conversões subsequentes.

**A Aspose distribui alguma fonte com a biblioteca?**

Não. A Aspose não distribui fontes pagas ou gratuitas; você adiciona e usa fontes por sua própria conta e responsabilidade.

**Existem diferenças no comportamento de substituição em Windows, Linux e macOS?**

Sim. A descoberta de fontes começa a partir dos diretórios de fontes do sistema operacional. O conjunto de fontes padrão disponíveis e os caminhos de pesquisa diferem entre as plataformas, o que afeta a disponibilidade e a necessidade de substituição.

**Como devo preparar o ambiente para minimizar substituições inesperadas durante conversões em lote?**

Sincronize o conjunto de fontes entre máquinas ou contêineres, [add the external fonts](/slides/pt/nodejs-java/custom-font/) necessárias para os documentos de saída e [embed fonts](/slides/pt/nodejs-java/embedded-font/) nas apresentações quando possível, para que as fontes escolhidas estejam disponíveis durante a renderização.