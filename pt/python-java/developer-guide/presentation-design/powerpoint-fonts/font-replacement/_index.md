---
title: Simplifique a substituição de fontes em apresentações usando Python via Java
linktitle: Substituição de Fontes
type: docs
weight: 60
url: /pt/python-java/font-replacement/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- mudar fonte
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Substitua fontes de forma contínua no Aspose.Slides para Python via Java para garantir tipografia consistente em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

O Aspose.Slides permite substituir uma fonte por outra em toda a apresentação. Quando uma fonte é substituída, todas as ocorrências da fonte original são alteradas para a nova fonte.

Para executar a substituição de fonte, carregue a apresentação, defina a fonte de origem e a fonte de substituição, chame o método de substituição de fonte e salve a apresentação modificada como um arquivo PPTX. Essa abordagem é útil quando você deseja intencionalmente trocar uma família de fontes por outra em toda a apresentação.

## **Substituir fontes**

Se você mudar de ideia sobre o uso de uma fonte, pode substituir essa fonte por outra. Todas as ocorrências da fonte antiga serão substituídas pela nova fonte. 

O Aspose.Slides permite substituir uma fonte da seguinte maneira:

1. Carregue a apresentação relevante. 
2. Carregue a fonte que será substituída. 
3. Carregue a nova fonte. 
4. Substitua a fonte. 
5. Salve a apresentação modificada como um arquivo PPTX. 

Este código Python demonstra a substituição de fontes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Carregar uma apresentação.
presentation = Presentation("Fonts.pptx")
try:
    # Carregar a fonte de origem que será substituída.
    source_font = FontData("Arial")

    # Carregar a nova fonte.
    destination_font = FontData("Times New Roman")

    # Substituir a fonte.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Salvar a apresentação.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Nota" color="info" %}} 
Para definir regras que determinam o que acontece em determinadas condições (por exemplo, se uma fonte não puder ser acessada), veja [Substituição de Fonte](/slides/pt/python-java/font-substitution/). 
{{% /alert %}}

## **Perguntas frequentes**

**Qual é a diferença entre "font replacement", "font substitution" e "fallback fonts"?**

A substituição é uma troca intencional de uma família por outra em todo o documento. [Substitution](/slides/pt/python-java/font-substitution/) é uma regra como "se a fonte não estiver disponível, use X". [Fallback](/slides/pt/python-java/fallback-font/) é aplicada a glifos ausentes individuais quando a fonte base está instalada, mas não contém os caracteres necessários.

**A substituição se aplica a slides mestres, layouts, anotações e comentários?**

Sim. A substituição afeta todos os objetos da apresentação que utilizam a fonte original, incluindo slides mestres e anotações; os comentários também fazem parte do documento e são considerados pelo mecanismo de fontes.

**A fonte será alterada dentro de objetos OLE incorporados (por exemplo, Excel)?**

Não. [OLE content](/slides/pt/python-java/manage-ole/) é controlado pela sua própria aplicação. A substituição na apresentação não reformata os dados internos do OLE; eles podem ser exibidos como imagem ou como conteúdo editável externamente.

**Posso substituir uma fonte apenas em parte da apresentação (por slides ou regiões)?**

A substituição direcionada é possível se você alterar a fonte no nível dos objetos/faixas necessários, em vez de aplicar uma substituição global em todo o documento. A lógica geral de seleção de fontes durante a renderização permanece a mesma.

**Como posso determinar antecipadamente quais fontes a apresentação utiliza?**

Use o [gerenciador de fontes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/): ele fornece uma lista das [famílias em uso](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getFonts) e informações sobre [substituições/"desconhecidos" fonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getSubstitutions), o que ajuda a planejar a substituição.

**A substituição de fonte funciona ao converter para PDF/imagens?**

Sim. Durante a exportação, o Aspose.Slides aplica a mesma [sequência de seleção/substituição de fontes](/slides/pt/python-java/font-selection-sequence/), de modo que uma substituição feita antecipadamente será respeitada durante a conversão.

**Preciso instalar a fonte de destino no sistema ou posso anexar uma pasta de fontes?**

A instalação não é necessária: a biblioteca permite [carregar fontes externas](/slides/pt/python-java/custom-font/) a partir de pastas do usuário para uso durante a [renderização e exportação](/slides/pt/python-java/convert-powerpoint/).

**A substituição corrigirá "tofu" (quadrados) em vez de caracteres?**

Somente se a fonte de destino realmente contiver os glifos necessários. Caso contrário, [configure fallback](/slides/pt/python-java/fallback-font/) para cobrir os caracteres ausentes.