---
title: Simplificar a Substituição de Fonte em Apresentações Usando Python
linktitle: Substituição de Fonte
type: docs
weight: 60
url: /pt/python-net/font-replacement/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- alterar fonte
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Substitua fontes de forma fluida no Aspose.Slides Python via .NET para garantir tipografia consistente em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite substituir uma fonte por outra em toda a apresentação. Quando uma fonte é substituída, todas as ocorrências da fonte original são alteradas para a nova fonte.

Para realizar a substituição de fonte, carregue a apresentação, defina a fonte de origem e a fonte de substituição, chame o método de substituição de fonte e salve a apresentação modificada como um arquivo PPTX. Essa abordagem é útil quando você deseja intencionalmente trocar uma família de fontes por outra em toda a apresentação.

## **Substituir fontes**

Se mudar de ideia sobre o uso de uma fonte, você pode substituí‑la por outra fonte. Todas as ocorrências da fonte antiga serão substituídas pela nova fonte.

Aspose.Slides permite substituir uma fonte da seguinte forma:

1. Carregue a apresentação relevante.  
2. Carregue a fonte que será substituída.  
3. Carregue a nova fonte.  
4. Substitua a fonte.  
5. Grave a apresentação modificada como um arquivo PPTX.

Este código Python demonstra a substituição de fonte:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Carrega uma apresentação
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carrega a fonte de origem que será substituída
    sourceFont = slides.FontData("Arial")

    # Carrega a nova fonte
    destFont = slides.FontData("Times New Roman")

    # Substitui as fontes
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Salva a apresentação
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Para definir regras que determinam o que acontece em determinadas condições (por exemplo, se uma fonte não puder ser acessada), veja [**Substituição de Fonte**](/slides/pt/python-net/font-substitution/). 
{{% /alert %}}

## **Perguntas frequentes**

**Qual a diferença entre "substituição de fonte", "substituição automática" e "fonts de fallback"?**

A substituição é uma troca intencional de uma família por outra em todo o documento. [Substituição](/slides/pt/python-net/font-substitution/) é uma regra como "se a fonte não estiver disponível, use X". [Fallback](/slides/pt/python-net/fallback-font/) é aplicada de forma puntual para glifos ausentes quando a fonte base está instalada, mas não contém os caracteres necessários.

**A substituição se aplica a slides mestre, layouts, notas e comentários?**

Sim. A substituição afeta todos os objetos da apresentação que utilizam a fonte original, incluindo slides mestre e notas; os comentários também fazem parte do documento e são considerados pelo mecanismo de fontes.

**A fonte será alterada dentro de objetos OLE incorporados (por exemplo, Excel)?**

Não. O [conteúdo OLE](/slides/pt/python-net/manage-ole/) é controlado pelo seu próprio aplicativo. A substituição na apresentação não reformata os dados internos do OLE; eles podem ser exibidos como imagem ou como conteúdo editável externamente.

**Posso substituir uma fonte apenas em parte da apresentação (por slides ou regiões)?**

A substituição direcionada é possível se você alterar a fonte no nível dos objetos/faixas necessários, em vez de aplicar uma substituição global a todo o documento. A lógica geral de seleção de fonte durante a renderização permanece a mesma.

**Como posso determinar antecipadamente quais fontes a apresentação utiliza?**

Use o [gerenciador de fontes] (https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/) da apresentação: ele fornece uma lista das [famílias em uso] (https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_fonts/) e informações sobre [substituições/"fontes desconhecidas"] (https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_substitutions/), o que ajuda a planejar a substituição.

**A substituição de fonte funciona ao converter para PDF/imagens?**

Sim. Durante a exportação, Aspose.Slides aplica a mesma [sequência de seleção/substituição de fontes](/slides/pt/python-net/font-selection-sequence/), portanto uma substituição feita previamente será respeitada na conversão.

**Preciso instalar a fonte de destino no sistema ou posso anexar uma pasta de fontes?**

A instalação não é necessária: a biblioteca permite [carregar fontes externas](/slides/pt/python-net/custom-font/) de pastas do usuário para uso durante a [renderização e exportação](/slides/pt/python-net/convert-powerpoint/).

**A substituição corrigirá o "tofu" (quadrados) em vez de caracteres?**

Somente se a fonte de destino realmente contiver os glifos necessários. Caso contrário, [configure o fallback](/slides/pt/python-net/fallback-font/) para cobrir os caracteres ausentes.