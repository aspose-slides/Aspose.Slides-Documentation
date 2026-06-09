---
title: "Adicionar Slides a Apresentações em .NET"
linktitle: "Adicionar slide"
type: docs
weight: 10
url: /pt/net/add-slide-to-presentation/
keywords:
- "adicionar slide"
- "criar slide"
- "slide vazio"
- "PowerPoint"
- "OpenDocument"
- "apresentação"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Adicione slides facilmente às suas apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET - inserção de slides contínua e eficiente em segundos."
---
## **Visão geral**

Aspose.Slides permite que você adicione slides a apresentações do PowerPoint programaticamente. Uma apresentação contém slides mestre/layout e slides normais, e os slides normais são organizados por um índice baseado em zero. Cada slide tem um ID exclusivo, e arquivos de apresentação sem slides não são suportados.

Este artigo explica como criar um objeto `Presentation`, acessar sua coleção de slides, adicionar um slide vazio, trabalhar com o slide recém‑adicionado e salvar a apresentação atualizada. Também aborda pontos relacionados, como inserir slides em uma posição específica, usar layouts e entender o slide em branco que existe em uma apresentação recém‑criada.

## **Adicionar um slide a uma apresentação**
Antes de falar sobre a adição de slides aos arquivos de apresentação, vamos discutir alguns fatos sobre os slides. Cada arquivo de apresentação do PowerPoint contém slide Mestre / Layout e outros slides Normais. Isso significa que um arquivo de apresentação contém ao menos um slide. É importante saber que arquivos de apresentação sem slides não são suportados pelo Aspose.Slides for .NET. Cada slide tem um Id exclusivo e todos os Slides Normais são organizados em uma ordem especificada pelo índice baseado em zero. Aspose.Slides for .NET permite que os desenvolvedores adicionem slides vazios à sua apresentação. Para adicionar um slide vazio na apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) definindo uma referência à propriedade Slides (coleção de objetos Slide de conteúdo) exposta pelo objeto Presentation.
- Adicione um slide vazio à apresentação ao final da coleção de slides de conteúdo chamando os métodos AddEmptySlide expostos pelo objeto ISlideCollection.
- Execute alguma operação com o slide vazio recém‑adicionado.
- Por fim, grave o arquivo de apresentação usando o objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Posso inserir um novo slide em uma posição específica, não apenas ao final?**

Sim. A biblioteca suporta coleções de slides e operações de [insert](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/insertclone/), de modo que você pode adicionar um slide no índice desejado em vez de somente ao final.

**Os temas/estilos são preservados ao adicionar um slide baseado em um layout?**

Sim. Um layout herda a formatação de seu mestre, e o novo slide herda do layout selecionado e de seu mestre associado.

**Qual slide está presente em uma nova apresentação “vazia” antes de adicionar slides?**

Uma apresentação recém‑criada já contém um slide em branco com índice zero. Isso é importante considerar ao calcular índices de inserção.

**Como escolher o layout “certo” para um novo slide se o mestre tem muitas opções?**

Normalmente escolha o [LayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutslide/) que corresponda à estrutura necessária ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pt/net/aspose.slides/slidelayouttype/)). Se esse layout estiver ausente, você pode [add it to the master](/slides/pt/net/slide-layout/) e então utilizá‑lo.