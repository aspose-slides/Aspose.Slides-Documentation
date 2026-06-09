---
title: Sequência de Seleção de Fonte no Aspose.Slides para Node.js via Java
linktitle: Seleção de Fonte
type: docs
weight: 80
url: /pt/nodejs-java/font-selection-sequence/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Node.js via Java seleciona fontes, garantindo apresentações nítidas e consistentes de arquivos PPT, PPTX e ODP — melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, Aspose.Slides verifica se as fontes usadas na apresentação estão disponíveis no sistema operacional. Se uma fonte necessária estiver ausente, Aspose.Slides seleciona uma fonte de substituição que seja o mais próximo possível da que o PowerPoint utilizaria.

Aspose.Slides primeiro procura a fonte selecionada no sistema operacional. Se a fonte for encontrada, ela é usada. Se não for encontrada, uma substituição adequada é aplicada. Quando regras de substituição de fonte são definidas através de `FontSubstRule`, essas regras também são consideradas.

Você também pode adicionar fontes no tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de Fonte**

Certas regras se aplicam às fontes de uma apresentação quando ela é carregada, renderizada ou convertida para outro formato. Por exemplo, ao tentar converter uma apresentação (seus slides) em imagens, as fontes da apresentação são verificadas para confirmar que as fontes escolhidas estão disponíveis no sistema operacional. Se as fontes forem confirmadas como ausentes, elas são substituídas — veja [**Font Replacement**](https://docs.aspose.com/slides/pt/nodejs-java/font-replacement/) e [**Font Substitution**](https://docs.aspose.com/slides/pt/nodejs-java/font-substitution/).

Este é o processo que o Aspose.Slides segue ao lidar com fontes:

1. Aspose.Slides procura fontes no sistema operacional para encontrar a fonte que corresponde à fonte escolhida na apresentação. 
2. Se a fonte escolhida for encontrada, o Aspose.Slides a usa. Caso contrário, o Aspose.Slides usa uma fonte de substituição que seja o mais próximo possível do que o PowerPoint usaria.
3. Se regras de substituição de fonte foram definidas através de [FontSubstRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsubstrule/), elas são aplicadas.

Aspose.Slides permite que você adicione fontes ao tempo de execução da aplicação e então as utilize. Veja [**Custom fonts**](https://docs.aspose.com/slides/pt/nodejs-java/custom-font/).

Quando fontes adicionais são inseridas dentro de uma apresentação, elas são chamadas de [**Embedded fonts**](https://docs.aspose.com/slides/pt/nodejs-java/embedded-font/).

Aspose.Slides permite que você adicione fontes que são aplicadas *apenas* a documentos de saída. Por exemplo, se uma apresentação que você pretende converter para PDF contém fontes ausentes do seu sistema e fontes incorporadas, você pode adicionar ou carregar as fontes necessárias como **external fonts**.

{{% alert title="Nota" color="primary" %}} 
Não distribuímos nenhuma fonte, seja paga ou gratuita. Nossa API permite que você carregue fontes externas e as incorpore em documentos, mas isso deve ser feito com fontes sob sua discrição e responsabilidade.
{{% /alert %}}

## **Perguntas Frequentes**

**Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?**

Aspose.Slides permite que você inspecione as fontes usadas via o [font manager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getfontsmanager/), para que você decida se deve [embed](/slides/pt/nodejs-java/embedded-font/), [replace](/slides/pt/nodejs-java/font-replacement/) ou adicionar [external sources](/slides/pt/nodejs-java/custom-font/). Isso ajuda a impedir substituições indesejadas durante a renderização e exportação.

**Posso adicionar diretórios de fontes extras sem instalá-los no sistema operacional?**

Sim. Você pode registrar [external font sources](/slides/pt/nodejs-java/custom-font/) como pastas ou fluxos em memória para renderização e exportação. Isso elimina a dependência de fontes do sistema host e mantém o layout previsível.

**Como evitar um fallback silencioso para uma fonte inadequada quando um glifo está ausente?**

Defina [font replacement](/slides/pt/nodejs-java/font-replacement/) explícito e regras de [fallBack font](/slides/pt/nodejs-java/fallback-font/) antecipadamente. Ao analisar as fontes usadas e definir uma prioridade controlada para os substitutos, você garante tipografia consistente e evita resultados inesperados.