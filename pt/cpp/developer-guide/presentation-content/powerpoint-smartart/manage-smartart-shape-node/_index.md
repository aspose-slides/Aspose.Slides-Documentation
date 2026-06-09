---
title: Gerenciar nós de forma SmartArt em apresentações usando C++
linktitle: Nó de forma SmartArt
type: docs
weight: 30
url: /pt/cpp/manage-smartart-shape-node/
keywords:
- nó SmartArt
- nó filho
- adicionar nó
- posição do nó
- acessar nó
- remover nó
- posição personalizada
- nó assistente
- formato de preenchimento
- renderizar nó
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gerencie nós de forma SmartArt em PPT e PPTX com Aspose.Slides para C++. Obtenha exemplos de código claros e dicas para simplificar suas apresentações."
---
## **Visão geral**

Os gráficos SmartArt em apresentações do PowerPoint são organizados por nós que contêm texto e definem a estrutura do diagrama. Aspose.Slides permite trabalhar com esses nós SmartArt programaticamente: adicionar novos nós e nós filhos, inserir nós filhos em uma posição específica, acessar nós existentes e ler seu texto, nível e posição.

Este artigo explica como gerenciar nós de forma SmartArt. Ele mostra como remover nós, trabalhar com nós filhos por índice ou posição, alterar um nó assistente para um nó normal, ajustar a posição, tamanho e rotação das formas dos nós SmartArt, definir formatos de preenchimento dos nós e gerar uma imagem em miniatura para um nó filho SmartArt.

## **Adicionar um Nó SmartArt**
O Aspose.Slides para C++ fornece a API mais simples para gerenciar as formas SmartArt da maneira mais fácil. O código de exemplo a seguir ajudará a adicionar nó e nó filho dentro da forma SmartArt.

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e carregue a apresentação com Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArt, se for SmartArt.
- Adicione um novo Nó na coleção NodeCollection da forma SmartArt e defina o texto no TextFrame.
- Agora, adicione um Nó Filho no Nó SmartArt recém‑adicionado e defina o texto no TextFrame.
- Salve a Apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Adicionar um Nó SmartArt em uma Posição Específica**
No código de exemplo a seguir explicamos como adicionar os nós filhos pertencentes a nós específicos da forma SmartArt em uma posição determinada.

- Crie uma instância da classe `Presentation`.
- Obtenha a referência do primeiro slide usando seu Índice.
- Adicione uma forma SmartArt do tipo StackedList no slide acessado.
- Acesse o primeiro nó na forma SmartArt adicionada.
- Agora, adicione o Nó Filho para o Nó selecionado na posição 2 e defina seu texto.
- Salve a Apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Acessar um Nó SmartArt**
O código de exemplo a seguir ajudará a acessar nós dentro da forma SmartArt. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma SmartArt é adicionada.

- Crie uma instância da classe `Presentation` e carregue a apresentação com Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArt, se for SmartArt.
- Percorra todos os Nós dentro da Forma SmartArt.
- Acesse e exiba informações como posição do Nó SmartArt, nível e Texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Acessar um Nó Filho SmartArt**
O código de exemplo a seguir ajudará a acessar os nós filhos pertencentes a nós específicos da forma SmartArt.

- Crie uma instância da classe PresentationEx e carregue a apresentação com Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArtEx, se for SmartArt.
- Percorra todos os Nós dentro da Forma SmartArt.
- Para cada Nó da forma SmartArt selecionada, percorra todos os Nós Filhos dentro desse nó específico.
- Acesse e exiba informações como posição do Nó Filho, nível e Texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Acessar um Nó Filho SmartArt em uma Posição Específica**
Neste exemplo, aprenderemos a acessar os nós filhos em uma posição específica pertencentes a nós correspondentes da forma SmartArt.

- Crie uma instância da classe `Presentation`.
- Obtenha a referência do primeiro slide usando seu Índice.
- Adicione uma forma SmartArt do tipo StackedList.
- Acesse a forma SmartArt adicionada.
- Acesse o nó no índice 0 da forma SmartArt acessada.
- Agora, acesse o Nó Filho na posição 1 do nó SmartArt acessado usando o método GetNodeByPosition().
- Acesse e exiba informações como posição do Nó Filho, nível e Texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Remover um Nó SmartArt**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt.

- Crie uma instância da classe `Presentation` e carregue a apresentação com Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArt, se for SmartArt.
- Verifique se o SmartArt possui mais de 0 nós.
- Selecione o nó SmartArt a ser excluído.
- Agora, remova o nó selecionado usando o método RemoveNode() * Salve a Apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Remover um Nó SmartArt em uma Posição Específica**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt em uma posição específica.

- Crie uma instância da classe `Presentation` e carregue a apresentação com Forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArt, se for SmartArt.
- Selecione o nó da forma SmartArt no índice 0.
- Agora, verifique se o nó SmartArt selecionado possui mais de 2 nós filhos.
- Agora, remova o nó na Posição 1 usando o método RemoveNodeByPosition().
- Salve a Apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Definir uma Posição Personalizada para um Nó Filho SmartArt**
Agora o Aspose.Slides oferece suporte para definir as propriedades X e Y da SmartArtShape. O trecho de código abaixo mostra como definir a posição, tamanho e rotação personalizados da SmartArtShape; observe também que a adição de novos nós provoca um recálculo das posições e tamanhos de todos os nós.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Verificar um Nó Assistente**
No código de exemplo a seguir investigaremos como identificar Nodos Assistentes na coleção de nós SmartArt e alterá‑los.

- Crie uma instância da classe PresentationEx e carregue a apresentação com Forma SmartArt.
- Obtenha a referência do segundo slide usando seu Índice.
- Percorra todas as formas dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArtEx, se for SmartArt.
- Percorra todos os nós dentro da forma SmartArt e verifique se são Nodos Assistentes.
- Altere o status do Nó Assistente para nó normal.
- Salve a Apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Definir o Formato de Preenchimento de um Nó**
O Aspose.Slides para C++ possibilita adicionar formas SmartArt personalizadas e definir seus formatos de preenchimento. Este artigo explica como criar e acessar formas SmartArt e definir seu formato de preenchimento usando Aspose.Slides para C++.

Siga os passos abaixo:

- Crie uma instância da classe `Presentation`.
- Obtenha a referência de um slide usando seu índice.
- Adicione uma forma SmartArt definindo seu LayoutType.
- Defina o FillFormat para os nós da forma SmartArt.
- Grave a apresentação modificada como um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Gerar uma Miniatura de um Nó Filho SmartArt**
Os desenvolvedores podem gerar uma miniatura do nó filho de um SmartArt seguindo os passos abaixo:

1. Instancie a classe `Presentation` que representa o arquivo PPTX.
2. Adicione SmartArt.
3. Obtenha a referência de um nó usando seu Índice
4. Obtenha a imagem em miniatura.
5. Salve a imagem em miniatura em qualquer formato de imagem desejado.

O exemplo abaixo gera uma miniatura do nó filho do SmartArt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**A animação SmartArt é suportada?**

Sim. SmartArt é tratado como uma forma regular, portanto você pode [aplicar animações padrão](/slides/pt/cpp/shape-animation/) (entrada, saída, ênfase, caminhos de movimento) e ajustar o tempo. Você também pode animar formas dentro dos nós SmartArt quando necessário.

**Como posso localizar de forma confiável um SmartArt específico em um slide se seu ID interno for desconhecido?**

Atribua e pesquise por [texto alternativo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/set_alternativetext/). Definir um AltText distinto no SmartArt permite encontrá‑lo programaticamente sem depender de identificadores internos.

**A aparência do SmartArt será preservada ao converter a apresentação para PDF?**

Sim. Aspose.Slides renderiza o SmartArt com alta fidelidade visual durante a [exportação para PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), preservando layout, cores e efeitos.

**Posso extrair uma imagem de todo o SmartArt (para pré‑visualizações ou relatórios)?**

Sim. Você pode renderizar uma forma SmartArt para [formatos raster](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) ou para [SVG](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/writeassvg/) para saída vetorial escalável, tornando-a adequada para miniaturas, relatórios ou uso na web.