---
title: Sequência de Seleção de Fonte no Aspose.Slides para .NET
linktitle: Seleção de Fonte
type: docs
weight: 80
url: /pt/net/font-selection-sequence/
keywords:
- seleção de fonte
- substituição de fonte
- substituição de fonte
- regra de substituição
- fonte disponível
- fonte ausente
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como o Aspose.Slides para .NET seleciona fontes, garantindo apresentações nítidas e consistentes de arquivos PPT, PPTX e ODP — melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, o Aspose.Slides verifica se as fontes usadas na apresentação estão disponíveis no sistema operacional. Se uma fonte necessária estiver ausente, o Aspose.Slides seleciona uma fonte de substituição que seja o mais próximo possível da que o PowerPoint usaria.

O Aspose.Slides primeiro procura a fonte selecionada no sistema operacional. Se a fonte for encontrada, ela é usada. Se não for encontrada, uma substituição adequada é aplicada. Quando as regras de substituição de fontes são definidas através de `FontSubstRule`, essas regras também são consideradas.

Você também pode adicionar fontes em tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de Fonte**

Certas regras se aplicam às fontes de uma apresentação quando a apresentação é carregada, renderizada ou convertida para outro formato. Por exemplo, ao tentar converter uma apresentação (seus slides) para imagens, as fontes da apresentação são verificadas para garantir que as fontes escolhidas estejam disponíveis no sistema operacional. Se as fontes forem confirmadas como ausentes, elas são substituídas — veja [**Font Replacement**](https://docs.aspose.com/slides/pt/net/font-replacement/) e [**Font Substitution**](https://docs.aspose.com/slides/pt/net/font-substitution/).

Este é o processo que o Aspose.Slides segue ao lidar com fontes:

1. O Aspose.Slides procura fontes no sistema operacional para encontrar a fonte que corresponde à fonte escolhida da apresentação. 
2. Se a fonte escolhida for encontrada, o Aspose.Slides a utiliza. Caso contrário, o Aspose.Slides usa uma fonte de substituição que seja o mais próximo possível do que o PowerPoint usaria.
3. Se regras de substituição de fontes foram definidas através de [FontSubstRule](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsubstrule/), elas são aplicadas. 

O Aspose.Slides permite adicionar fontes em tempo de execução da aplicação e, em seguida, usar essas fontes. Veja [**Custom fonts**](https://docs.aspose.com/slides/pt/net/custom-font/). 

Quando fontes adicionais são inseridas em uma apresentação, elas são chamadas de [**Embedded fonts**](https://docs.aspose.com/slides/pt/net/embedded-font/).

O Aspose.Slides permite adicionar fontes que são aplicadas *apenas* a documentos de saída. Por exemplo, se uma apresentação que você deseja converter para PDF contém fontes ausentes do seu sistema e fontes incorporadas, você pode adicionar ou carregar as fontes necessárias como **external fonts**. 

{{% alert title="Note" color="info" %}} 
Não distribuímos quaisquer fontes, sejam pagas ou gratuitas. Nossa API permite que você carregue fontes externas e as incorpore em documentos, mas você faz isso com as fontes a seu critério e responsabilidade.
{{% /alert %}}

## **Perguntas Frequentes**

### Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?

O Aspose.Slides permite inspecionar as fontes usadas através do [font manager](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/fontsmanager/), para que você possa decidir se [embed](/slides/pt/net/embedded-font/), [replace](/slides/pt/net/font-replacement/) ou adicionar [external sources](/slides/pt/net/custom-font/). Isso ajuda a evitar substituições indesejadas durante a renderização e exportação.

### Posso adicionar diretórios de fontes extras sem instalá‑los no sistema operacional?

Sim. Você pode registrar [external font sources](/slides/pt/net/custom-font/) como pastas ou fluxos em memória para renderização e exportação. Isso elimina a dependência das fontes do sistema host e mantém o layout previsível.

### Como impedir um fallback silencioso para uma fonte inadequada quando um glifo está ausente?

Defina explicitamente [font replacement](/slides/pt/net/font-replacement/) e [fallBack rules](/slides/pt/net/fallback-font/) de fontes com antecedência. Ao analisar as fontes usadas e definir uma prioridade controlada para substitutos, você garante tipografia consistente e evita resultados inesperados.