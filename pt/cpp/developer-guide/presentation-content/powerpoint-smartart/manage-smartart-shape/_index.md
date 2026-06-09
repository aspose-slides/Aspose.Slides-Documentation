---
title: Gerenciar Gráficos SmartArt em Apresentações Usando C++
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /pt/cpp/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Cor SmartArt
- Criar SmartArt
- Adicionar SmartArt
- Editar SmartArt
- Alterar SmartArt
- Acessar SmartArt
- Tipo de layout SmartArt
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint em C++ usando Aspose.Slides, com exemplos de código concisos e orientações focadas em desempenho."
---
## **Visão geral**

Aspose.Slides permite criar e gerenciar gráficos SmartArt em apresentações do PowerPoint programaticamente. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, encontrar SmartArt por um tipo de layout específico e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide da apresentação, verificar se uma forma é SmartArt e então modificar ou inspecionar suas propriedades.

## **Criar uma Forma SmartArt**
Aspose.Slides para C++ agora facilita a adição de formas SmartArt personalizadas em seus slides do zero. Aspose.Slides para C++ fornece a API mais simples para criar formas SmartArt da maneira mais fácil. Para criar uma forma SmartArt em um slide, siga os passos abaixo:

- Crie uma instância da [Apresentação](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) classe.
- Obtenha a referência de um slide usando seu Índice.
- Adicione uma forma SmartArt definindo seu LayoutType.
- Salve a apresentação modificada como um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Acessar uma Forma SmartArt em um Slide**
O código a seguir será usado para acessar as formas SmartArt adicionadas na apresentação. No código de exemplo percorreremos cada forma dentro do slide e verificaremos se é uma forma SmartArt. Se a forma for do tipo SmartArt, então a converteremos para uma instância SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Acessar uma Forma SmartArt com um Tipo de Layout Particular**
O código de exemplo a seguir ajudará a acessar a forma SmartArt com um LayoutType específico. Observe que não é possível alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma SmartArt é adicionada.

- Crie uma instância da `Presentation` classe e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra cada forma dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArt se for SmartArt.
- Verifique a forma SmartArt com o LayoutType específico e execute o que for necessário fazer em seguida.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **Alterar o Estilo de uma Forma SmartArt**
O código de exemplo a seguir ajudará a acessar a forma SmartArt com um LayoutType específico.

- Crie uma instância da `Presentation` classe e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra cada forma dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArt se for SmartArt.
- Encontre a forma SmartArt com um Estilo específico.
- Defina o novo Estilo para a forma SmartArt.
- Salve a Apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **Alterar o Estilo de Cor de uma Forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo de cor para qualquer forma SmartArt. No código de exemplo a seguir, acessaremos a forma SmartArt com um estilo de cor específico e alteraremos seu estilo.

- Crie uma instância da `Presentation` classe e carregue a apresentação com a Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra cada forma dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArt se for SmartArt.
- Encontre a forma SmartArt com um Estilo de Cor específico.
- Defina o novo Estilo de Cor para a forma SmartArt.
- Salve a Apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Posso animar o SmartArt como um único objeto?**

Sim. SmartArt é uma forma, portanto você pode aplicar [animações padrão](/slides/pt/cpp/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, trajetórias de movimento) como em outras formas.

**Como posso encontrar um SmartArt específico em um slide se não conheço seu ID interno?**

Defina e use o Texto Alternativo (AltText) e procure a forma por esse valor — esta é uma maneira recomendada de localizar a forma alvo.

**Posso agrupar SmartArt com outras formas?**

Sim. Você pode agrupar SmartArt com outras formas (imagens, tabelas etc.) e então [manipular o grupo](/slides/pt/cpp/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para visualização ou relatório)?**

Exporte uma miniatura/imagem da forma; a biblioteca pode [renderizar formas individuais](/slides/pt/cpp/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter a apresentação inteira para PDF?**

Sim. O mecanismo de renderização visa alta fidelidade para [exportação PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.