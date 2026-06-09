---
title: Sequência de Seleção de Fonte no Aspose.Slides para PHP
linktitle: Seleção de Fonte
type: docs
weight: 80
url: /pt/php-java/font-selection-sequence/
keywords:
- seleção de fonte
- substituição de fonte
- troca de fonte
- regra de substituição
- fonte disponível
- fonte ausente
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como o Aspose.Slides para PHP via Java seleciona fontes, garantindo apresentações nítidas e consistentes de arquivos PPT, PPTX e ODP — melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, Aspose.Slides verifica se as fontes usadas na apresentação estão disponíveis no sistema operacional. Se uma fonte necessária estiver ausente, Aspose.Slides seleciona uma fonte de substituição que seja o mais próximo possível da que o PowerPoint utilizaria.

Aspose.Slides primeiro procura a fonte selecionada no sistema operacional. Se a fonte for encontrada, ela é usada. Caso não seja encontrada, uma substituição adequada é aplicada. Quando regras de substituição de fontes são definidas através de `FontSubstRule`, essas regras também são consideradas.

Você também pode adicionar fontes em tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de Fonte**

Certas regras se aplicam às fontes de uma apresentação quando a apresentação é carregada, renderizada ou convertida para outro formato. Por exemplo, ao tentar converter uma apresentação (seus slides) em imagens, as fontes da apresentação são verificadas para garantir que as fontes escolhidas estejam disponíveis no sistema operacional. Se for confirmado que as fontes estão ausentes, elas são substituídas — veja [**Font Replacement**](https://docs.aspose.com/slides/pt/php-java/font-replacement/) e [**Font Substitution**](https://docs.aspose.com/slides/pt/php-java/font-substitution/).

Este é o processo que o Aspose.Slides segue ao lidar com fontes:

1. O Aspose.Slides procura fontes no sistema operacional para encontrar a fonte que corresponde à fonte escolhida na apresentação. 
2. Se a fonte escolhida for encontrada, o Aspose.Slides a utiliza. Caso contrário, o Aspose.Slides usa uma fonte de substituição que seja o mais próximo possível da que o PowerPoint utilizaria. 
3. Se regras de substituição de fontes foram definidas através de [FontSubstRule](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsubstrule/), elas são aplicadas.

O Aspose.Slides permite que você adicione fontes ao runtime da Aspose e então use essas fontes. Veja [**Custom fonts**](https://docs.aspose.com/slides/pt/php-java/custom-font/).

Quando fontes adicionais são inseridas em uma apresentação, elas são chamadas de [**Embedded fonts**](https://docs.aspose.com/slides/pt/php-java/embedded-font/).

O Aspose.Slides permite que você adicione fontes que são aplicadas *apenas* a documentos de saída. Por exemplo, se uma apresentação que você deseja converter para PDF contém fontes ausentes do seu sistema e fontes incorporadas, você pode adicionar ou carregar as fontes necessárias como **External fonts**.

## **Perguntas Frequentes**

**Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?**

O Aspose.Slides permite inspecionar as fontes usadas através do [font manager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/), para que você possa decidir se [incorporar](/slides/pt/php-java/embedded-font/), [substituir](/slides/pt/php-java/font-replacement/) ou adicionar [fontes externas](/slides/pt/php-java/custom-font/). Isso ajuda a evitar substituições indesejadas durante a renderização e exportação.

**Posso adicionar diretórios de fontes extra sem instalá-los no sistema operacional?**

Sim. Você pode registrar [fontes externas](/slides/pt/php-java/custom-font/) como pastas ou fluxos em memória para renderização e exportação. Isso remove a dependência das fontes do sistema host e mantém o layout previsível.

**Como faço para evitar um fallback silencioso para uma fonte inadequada quando um glifo está faltando?**

Defina explicitamente [substituição de fonte](/slides/pt/php-java/font-replacement/) e regras de [fallback de fonte](/slides/pt/php-java/fallback-font/) antecipadamente. Ao analisar as fontes usadas e definir uma prioridade controlada para os substitutos, você garante tipografia consistente e evita resultados inesperados.