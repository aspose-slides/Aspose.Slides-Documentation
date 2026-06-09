---
title: Sequência de Seleção de Fonte no Aspose.Slides para Android via Java
linktitle: Seleção de Fonte
type: docs
weight: 80
url: /pt/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Android via Java seleciona fontes, garantindo uma apresentação nítida e consistente de arquivos PPT, PPTX e ODP — melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, o Aspose.Slides verifica se as fontes usadas na apresentação estão disponíveis no sistema operacional. Se uma fonte necessária estiver ausente, o Aspose.Slides seleciona uma fonte de substituição que seja o mais próximo possível da que o PowerPoint usaria.

O Aspose.Slides primeiro procura a fonte selecionada no sistema operacional. Se a fonte for encontrada, ela é usada. Caso não seja encontrada, uma substituição adequada é aplicada. Quando regras de substituição de fonte são definidas através de `FontSubstRule`, essas regras também são consideradas.

Você também pode adicionar fontes em tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de Fonte**

Certas regras se aplicam às fontes de uma apresentação quando ela é carregada, renderizada ou convertida para outro formato. Por exemplo, ao tentar converter uma apresentação (seus slides) em imagens, as fontes da apresentação são verificadas para confirmar se as fontes escolhidas estão disponíveis no sistema operacional. Se as fontes forem confirmadas como ausentes, elas são substituídas — veja [**Substituição de Fonte**](https://docs.aspose.com/slides/pt/androidjava/font-replacement/) e [**Substituição de Fonte**](https://docs.aspose.com/slides/pt/androidjava/font-substitution/).

Este é o processo que o Aspose.Slides segue ao lidar com fontes:

1. O Aspose.Slides procura fontes no sistema operacional para encontrar a fonte que corresponde à fonte escolhida na apresentação. 
2. Se a fonte escolhida for encontrada, o Aspose.Slides a utiliza. Caso contrário, o Aspose.Slides usa uma fonte de substituição que seja o mais próximo possível do que o PowerPoint usaria.
3. Se regras de substituição de fonte foram definidas através de [FontSubstRule](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsubstrule/), elas são aplicadas.

O Aspose.Slides permite que você adicione fontes em tempo de execução da aplicação e depois use essas fontes. Veja [**Fontes personalizadas**](https://docs.aspose.com/slides/pt/androidjava/custom-font/).

Quando fontes adicionais são inseridas dentro de uma apresentação, elas são chamadas de [**Fontes incorporadas**](https://docs.aspose.com/slides/pt/androidjava/embedded-font/).

O Aspose.Slides permite que você adicione fontes que são aplicadas *somente* a documentos de saída. Por exemplo, se uma apresentação que você deseja converter para PDF contém fontes ausentes do seu sistema e fontes incorporadas, você pode adicionar ou carregar as fontes necessárias como **fontes externas**. 

{{% alert title="Note" color="primary" %}} 
Não distribuímos nenhuma fonte, seja paga ou gratuita. Nossa API permite que você carregue fontes externas e as incorpore em documentos, mas você faz isso com as fontes sob sua discrição e responsabilidade.
{{% /alert %}}

## **Perguntas frequentes**

**Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?**

O Aspose.Slides permite que você inspecione as fontes usadas através do [gerenciador de fontes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/), para que possa decidir se [incorpora](/slides/pt/androidjava/embedded-font/), [substitui](/slides/pt/androidjava/font-replacement/) ou adiciona [fontes externas](/slides/pt/androidjava/custom-font/). Isso ajuda a prevenir substituições indesejadas durante a renderização e exportação.

**Posso adicionar diretórios de fontes extras sem instalá‑los no sistema operacional?**

Sim. Você pode registrar [fontes externas](/slides/pt/androidjava/custom-font/) como pastas ou streams em memória para renderização e exportação. Isso remove a dependência das fontes do sistema host e mantém o layout previsível.

**Como evitar um fallback silencioso para uma fonte inadequada quando um glifo está ausente?**

Defina explicitamente [substituição de fonte](/slides/pt/androidjava/font-replacement/) e [regras de fallback de fonte](/slides/pt/androidjava/fallback-font/) antecipadamente. Ao analisar as fontes usadas e definir uma prioridade controlada para substitutos, você garante tipografia consistente e evita resultados inesperados.