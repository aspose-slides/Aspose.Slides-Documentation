---
title: Sequência de Seleção de Fontes no Aspose.Slides para C++
linktitle: Seleção de Fontes
type: docs
weight: 80
url: /pt/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Descubra como o Aspose.Slides para C++ seleciona fontes, garantindo uma apresentação nítida e consistente de arquivos PPT, PPTX e ODP — melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, o Aspose.Slides verifica se as fontes usadas na apresentação estão disponíveis no sistema operacional. Se uma fonte necessária estiver ausente, o Aspose.Slides seleciona uma fonte de substituição que seja o mais próximo possível da que o PowerPoint usaria.

O Aspose.Slides primeiro procura a fonte selecionada no sistema operacional. Se a fonte for encontrada, ela é usada. Caso não seja encontrada, uma substituição adequada é aplicada. Quando regras de substituição de fontes são definidas através de `FontSubstRule`, essas regras também são consideradas.

Você também pode adicionar fontes em tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de Fontes**

Certas regras se aplicam às fontes em uma apresentação quando ela é carregada, renderizada ou convertida para outro formato. Por exemplo, ao tentar converter uma apresentação (seus slides) em imagens, as fontes da apresentação são verificadas para confirmar que as fontes escolhidas estão disponíveis no sistema operacional. Se as fontes forem confirmadas como ausentes, elas são substituídas — veja [**Font Replacement**](https://docs.aspose.com/slides/pt/cpp/font-replacement/) e [**Font Substitution**](https://docs.aspose.com/slides/pt/cpp/font-substitution/).

Este é o processo que o Aspose.Slides segue ao lidar com fontes:

1. O Aspose.Slides procura fontes no sistema operacional para encontrar a fonte que corresponde à fonte escolhida na apresentação. 
2. Se a fonte escolhida for encontrada, o Aspose.Slides a utiliza. Caso contrário, o Aspose.Slides usa uma fonte de substituição que seja o mais próximo possível do que o PowerPoint usaria.
3. Se regras de substituição de fontes foram definidas através de [FontSubstRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsubstrule/), elas são aplicadas. 

O Aspose.Slides permite adicionar fontes em tempo de execução da aplicação e, em seguida, usar essas fontes. Veja [**Custom fonts**](https://docs.aspose.com/slides/pt/cpp/custom-font/). 

Quando fontes adicionais são inseridas em uma apresentação, elas são chamadas de [**Embedded fonts**](https://docs.aspose.com/slides/pt/cpp/embedded-font/).

O Aspose.Slides permite adicionar fontes que são aplicadas *apenas* a documentos de saída. Por exemplo, se uma apresentação que você deseja converter para PDF contém fontes ausentes do seu sistema e fontes incorporadas, você pode adicionar ou carregar as fontes necessárias como **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Não distribuímos nenhuma fonte, seja paga ou gratuita. Nossa API permite que você carregue fontes externas e as incorpore em documentos, mas você o faz com fontes a seu critério e responsabilidade.
{{% /alert %}}

## **FAQ**

**Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?**

O Aspose.Slides permite inspecionar as fontes usadas através do [font manager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_fontsmanager/), para que você possa decidir se [embed](/slides/pt/cpp/embedded-font/), [replace](/slides/pt/cpp/font-replacement/) ou adicionar [external sources](/slides/pt/cpp/custom-font/). Isso ajuda a evitar substituições indesejadas durante a renderização e exportação.

**Posso adicionar diretórios de fontes extras sem instalá‑los no sistema operacional?**

Sim. Você pode registrar [external font sources](/slides/pt/cpp/custom-font/) como pastas ou fluxos em memória para renderização e exportação. Isso elimina a dependência das fontes do sistema host e mantém o layout previsível.

**Como impedir um fallback silencioso para uma fonte inadequada quando um glifo está ausente?**

Defina explicitamente [font replacement](/slides/pt/cpp/font-replacement/) e [fallBack rules](/slides/pt/cpp/fallback-font/) de fontes antecipadamente. Ao analisar as fontes usadas e definir uma prioridade controlada para os substitutos, você garante tipografia consistente e evita resultados inesperados.