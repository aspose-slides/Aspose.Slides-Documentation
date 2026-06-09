---
title: Sequência de Seleção de Fontes no Aspose.Slides para Java
linktitle: Seleção de Fontes
type: docs
weight: 80
url: /pt/java/font-selection-sequence/
keywords:
- seleção de fontes
- substituição de fontes
- substituição de fontes
- regra de substituição
- fonte disponível
- fonte ausente
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Java seleciona fontes, garantindo apresentação nítida e consistente de arquivos PPT, PPTX e ODP — melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, o Aspose.Slides verifica se as fontes usadas na apresentação estão disponíveis no sistema operacional. Se uma fonte necessária estiver ausente, o Aspose.Slides seleciona uma fonte de substituição que seja o mais próximo possível da que o PowerPoint utilizaria.

O Aspose.Slides primeiro procura a fonte selecionada no sistema operacional. Se a fonte for encontrada, ela é usada. Caso não seja encontrada, uma substituição adequada é aplicada. Quando regras de substituição de fontes são definidas através de `FontSubstRule`, essas regras também são consideradas.

Você também pode adicionar fontes em tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de fontes**

Certas regras se aplicam às fontes em uma apresentação quando esta é carregada, renderizada ou convertida para outro formato. Por exemplo, ao tentar converter uma apresentação (seus slides) em imagens, as fontes da apresentação são verificadas para garantir que as fontes escolhidas estejam disponíveis no sistema operacional. Se as fontes forem confirmadas como ausentes, elas são substituídas — veja [**Substituição de fontes**](https://docs.aspose.com/slides/pt/java/font-replacement/) e [**Substituição de fontes**](https://docs.aspose.com/slides/pt/java/font-substitution/).

Este é o processo que o Aspose.Slides segue ao lidar com fontes:

1. O Aspose.Slides procura fontes no sistema operacional para encontrar a fonte que corresponde à fonte escolhida na apresentação. 
2. Se a fonte escolhida for encontrada, o Aspose.Slides a usa. Caso contrário, o Aspose.Slides usa uma fonte de substituição que seja o mais próximo possível do que o PowerPoint utilizaria.
3. Se regras de substituição de fontes foram definidas através do [FontSubstRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsubstrule/), elas são aplicadas. 

O Aspose.Slides permite que você adicione fontes em tempo de execução da aplicação e, em seguida, use essas fontes. Consulte [**Fontes personalizadas**](https://docs.aspose.com/slides/pt/java/custom-font/). 

Quando fontes adicionais são incluídas dentro de uma apresentação, elas são chamadas de [**Fontes incorporadas**](https://docs.aspose.com/slides/pt/java/embedded-font/).

O Aspose.Slides permite que você adicione fontes que são aplicadas *apenas* a documentos de saída. Por exemplo, se uma apresentação que você deseja converter para PDF contém fontes ausentes do seu sistema e fontes incorporadas, você pode adicionar ou carregar as fontes necessárias como **fontes externas**. 

{{% alert title="Note" color="primary" %}} 
Não distribuímos nenhuma fonte, seja paga ou gratuita. Nossa API permite que você carregue fontes externas e as incorpore em documentos, mas isso deve ser feito com fontes de sua escolha e responsabilidade.
{{% /alert %}}

## **Perguntas frequentes**

**Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?**

O Aspose.Slides permite inspecionar as fontes usadas via o [gerenciador de fontes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsmanager/), para que você possa decidir se [incorpora](/slides/pt/java/embedded-font/), [substitui](/slides/pt/java/font-replacement/) ou adiciona [fontes externas](/slides/pt/java/custom-font/). Isso ajuda a evitar substituições indesejadas durante a renderização e exportação.

**Posso adicionar diretórios de fontes extras sem instalá‑los no sistema operacional?**

Sim. Você pode registrar [fontes externas](/slides/pt/java/custom-font/) como pastas ou streams em memória para renderização e exportação. Isso elimina a dependência das fontes do host e mantém o layout previsível.

**Como impedir que ocorra um fallback silencioso para uma fonte inadequada quando um glifo está ausente?**

Defina antecipadamente [substituição de fontes](/slides/pt/java/font-replacement/) e [regras de fallback](/slides/pt/java/fallback-font/). Ao analisar as fontes usadas e definir uma prioridade controlada para os substitutos, você garante tipografia consistente e evita resultados inesperados.