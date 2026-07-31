---
title: Simplifique a substituição de fontes em apresentações usando C++
linktitle: Substituição de Fonte
type: docs
weight: 60
url: /pt/cpp/font-replacement/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- alterar fonte
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Substitua fontes de forma contínua no Aspose.Slides para C++ para garantir tipografia consistente em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite substituir uma fonte por outra em toda a apresentação. Quando uma fonte é substituída, todas as ocorrências da fonte original são alteradas para a nova fonte.

Para executar a substituição de fontes, carregue a apresentação, defina a fonte de origem e a fonte de substituição, chame o método de substituição de fontes e salve a apresentação modificada como um arquivo PPTX. Essa abordagem é útil quando você deseja trocar intencionalmente uma família de fontes por outra em toda a apresentação.

## **Substituir fontes**

Se mudar de ideia sobre o uso de uma fonte, pode substituí‑la por outra fonte. Todas as ocorrências da fonte antiga serão substituídas pela nova fonte.

Aspose.Slides permite substituir uma fonte da seguinte maneira:

1. Carregue a apresentação relevante.  
2. Carregue a fonte que será substituída.  
3. Carregue a nova fonte.  
4. Substitua a fonte.  
5. Grave a apresentação modificada como um arquivo PPTX.

Este código C++ demonstra a substituição de fontes:

``` cpp
// Carrega uma apresentação
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Carrega a fonte de origem que será substituída
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Carrega a nova fonte
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Substitui as fontes
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Salva a apresentação
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Para definir regras que determinam o que acontece em determinadas condições (por exemplo, se uma fonte não puder ser acessada), consulte [**Font Substitution**](/slides/pt/cpp/font-substitution/). 

{{% /alert %}}

## **Perguntas frequentes**

**Qual é a diferença entre “substituição de fonte”, “substituição de fonte” e “fonts de fallback”?**

A substituição é uma troca intencional de uma família por outra em todo o documento. [Substitution](/slides/pt/cpp/font-substitution/) é uma regra como “se a fonte não estiver disponível, use X”. [Fallback](/slides/pt/cpp/fallback-font/) é aplicada de forma cirúrgica para glifos ausentes individuais quando a fonte base está instalada, mas não contém os caracteres necessários.

**A substituição se aplica a slides mestres, layouts, notas e comentários?**

Sim. A substituição afeta todos os objetos da apresentação que utilizam a fonte original, incluindo slides mestres e notas; comentários também fazem parte do documento e são considerados pelo mecanismo de fontes.

**A fonte será alterada dentro de objetos OLE incorporados (por exemplo, Excel)?**

Não. O [conteúdo OLE](/slides/pt/cpp/manage-ole/) é controlado pelo seu próprio aplicativo. A substituição na apresentação não reformata os dados internos do OLE; eles podem ser exibidos como imagem ou como conteúdo editável externamente.

**Posso substituir uma fonte apenas em parte da apresentação (por slides ou regiões)?**

A substituição direcionada é possível se você alterar a fonte no nível dos objetos/faixas necessários, em vez de aplicar uma substituição global em todo o documento. A lógica geral de seleção de fontes durante a renderização permanece a mesma.

**Como posso determinar antecipadamente quais fontes a apresentação usa?**

Use o [gerenciador de fontes] (https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/) da apresentação: ele fornece uma lista das [famílias em uso] (https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/getfonts/) e informações sobre [substituições/"fonts desconhecidas"] (https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/getsubstitutions/), o que ajuda a planejar a substituição.

**A substituição de fonte funciona ao converter para PDF/imagens?**

Sim. Durante a exportação, Aspose.Slides aplica a mesma [sequência de seleção/substituição de fontes](/slides/pt/cpp/font-selection-sequence/), de modo que uma substituição feita previamente será respeitada durante a conversão.

**Preciso instalar a fonte de destino no sistema ou posso anexar uma pasta de fontes?**

A instalação não é necessária: a biblioteca permite [carregar fontes externas](/slides/pt/cpp/custom-font/) de pastas do usuário para uso durante [renderização e exportação](/slides/pt/cpp/convert-powerpoint/).

**A substituição corrigirá “tofu” (quadrados) em vez de caracteres?**

Somente se a fonte de destino realmente contiver os glifos necessários. Caso contrário, [configure o fallback](/slides/pt/cpp/fallback-font/) para cobrir os caracteres ausentes.