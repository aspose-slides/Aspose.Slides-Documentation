---
title: Sequência de Seleção de Fonte no Aspose.Slides para Python via Java
linktitle: Seleção de Fonte
type: docs
weight: 80
url: /pt/python-java/font-selection-sequence/
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
- Python
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Python via Java seleciona fontes, garantindo apresentação nítida e consistente de arquivos PPT, PPTX e ODP — melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, o Aspose.Slides verifica se as fontes usadas na apresentação estão disponíveis no sistema operacional. Se uma fonte necessária estiver ausente, o Aspose.Slides seleciona uma fonte de substituição que seja o mais próximo possível da que o PowerPoint utilizaria.

O Aspose.Slides primeiro procura a fonte selecionada no sistema operacional. Se a fonte for encontrada, ela é usada. Caso não seja encontrada, uma substituição adequada é aplicada. Quando regras de substituição de fontes são definidas por meio de [FontSubstRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstrule/), essas regras também são consideradas.

Você também pode adicionar fontes em tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de fontes**

Certas regras se aplicam às fontes de uma apresentação quando ela é carregada, renderizada ou convertida para outro formato. Por exemplo, ao tentar converter uma apresentação (seus slides) em imagens, as fontes da apresentação são verificadas para garantir que as fontes escolhidas estejam disponíveis no sistema operacional. Se as fontes forem confirmadas como ausentes, elas são substituídas — veja [Font Replacement](/slides/pt/python-java/font-replacement/) e [Font Substitution](/slides/pt/python-java/font-substitution/).

Este é o processo que o Aspose.Slides segue ao lidar com fontes:

1. O Aspose.Slides procura fontes no sistema operacional para encontrar a fonte que corresponde à fonte escolhida na apresentação.
2. Se a fonte escolhida for encontrada, o Aspose.Slides a usa. Caso contrário, o Aspose.Slides utiliza uma fonte de substituição que seja o mais próximo possível da que o PowerPoint utilizaria.
3. Se regras de substituição de fontes foram definidas por meio de [FontSubstRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstrule/), elas são aplicadas.

O Aspose.Slides permite que você adicione fontes em tempo de execução da aplicação e, em seguida, use essas fontes. Consulte [Custom fonts](/slides/pt/python-java/custom-font/).

Quando fontes adicionais são inseridas em uma apresentação, elas são chamadas de [Embedded fonts](/slides/pt/python-java/embedded-font/).

O Aspose.Slides permite que você adicione fontes que são aplicadas *apenas* a documentos de saída. Por exemplo, se uma apresentação que você deseja converter para PDF usa fontes que não estão instaladas no seu sistema nem incorporadas na apresentação, você pode adicionar ou carregar as fontes necessárias como **external fonts**.

{{% alert title="Nota" color="info" %}}
Não distribuímos nenhuma fonte, seja paga ou gratuita. Nossa API permite que você carregue fontes externas e as incorpore em documentos, mas isso deve ser feito por sua própria conta e risco.
{{% /alert %}}

## **Perguntas frequentes**

**Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?**

O Aspose.Slides permite inspecionar as fontes usadas por meio do [font manager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/), para que você possa decidir se [embed](/slides/pt/python-java/embedded-font/), [replace](/slides/pt/python-java/font-replacement/) ou adiciona [external sources](/slides/pt/python-java/custom-font/). Isso ajuda a evitar substituições indesejadas durante a renderização e a exportação.

**Posso adicionar diretórios de fontes extras sem instalá‑los no sistema operacional?**

Sim. Você pode registrar [external font sources](/slides/pt/python-java/custom-font/) como pastas ou fluxos em memória para renderização e exportação. Isso elimina a dependência das fontes do sistema host e mantém o layout previsível.

**Como impedir que ocorra um fallback silencioso para uma fonte inadequada quando um glifo está ausente?**

Defina previamente [font replacement](/slides/pt/python-java/font-replacement/) e regras de [fallback font](/slides/pt/python-java/fallback-font/). Ao analisar as fontes usadas e estabelecer uma prioridade controlada para os substitutos, você garante tipografia consistente e evita resultados inesperados.