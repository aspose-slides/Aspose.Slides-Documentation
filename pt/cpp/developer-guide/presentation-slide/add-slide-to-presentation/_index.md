---
title: Adicionar Slides a Apresentações em C++
linktitle: Adicionar Slide
type: docs
weight: 10
url: /pt/cpp/add-slide-to-presentation/
keywords:
- adicionar slide
- criar slide
- slide vazio
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Adicione slides facilmente às suas apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++ — inserção de slides perfeita e eficiente em segundos."
---
## **Visão geral**

Aspose.Slides permite adicionar slides a apresentações PowerPoint programaticamente. Uma apresentação contém slides mestre/layout e slides normais, e os slides normais são organizados por um índice base zero. Cada slide tem um ID exclusivo, e arquivos de apresentação sem slides não são suportados.

Este artigo explica como criar um objeto `Presentation`, acessar sua coleção de slides, adicionar um slide vazio, trabalhar com o slide recém‑adicionado e salvar a apresentação atualizada. Também aborda pontos relacionados, como inserir slides em uma posição específica, usar layouts e entender o slide em branco que existe em uma apresentação recém‑criada.

## **Adicionar um slide a uma apresentação**
Antes de falar sobre a adição de slides aos arquivos de apresentação, vamos discutir alguns fatos sobre os slides. Cada arquivo de apresentação PowerPoint contém slide Mestre / Layout e outros slides Normais. Isso significa que um arquivo de apresentação contém ao menos um ou mais slides. É importante saber que arquivos de apresentação sem slides não são suportados pelo Aspose.Slides for C++. Cada slide tem um Id único e todos os Slides Normais são organizados em uma ordem especificada pelo índice base zero. Aspose.Slides for C++ permite que desenvolvedores adicionem slides vazios à sua apresentação. Para adicionar um slide vazio na apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
- Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) definindo uma referência à propriedade Slides (coleção de objetos Slide de conteúdo) exposta pelo objeto Presentation.
- Adicione um slide vazio à apresentação ao final da coleção de slides de conteúdo chamando os métodos AddEmptySlide expostos pelo objeto ISlideCollection
- Execute algum trabalho com o slide vazio recém‑adicionado.
- Por fim, grave o arquivo de apresentação usando o objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Posso inserir um novo slide em uma posição específica, e não apenas no final?**

Sim. A biblioteca suporta coleções de slides e as operações [insert](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidecollection/insertclone/), permitindo que você adicione um slide no índice requerido em vez de apenas no final.

**Os temas/estilos são preservados ao adicionar um slide baseado em um layout?**

Sim. Um layout herda a formatação do seu mestre, e o novo slide herda do layout selecionado e do seu mestre associado.

**Qual slide está presente em uma nova apresentação "vazia" antes de adicionar slides?**

Uma apresentação recém‑criada já contém um slide em branco com índice zero. Isso é importante considerar ao calcular os índices de inserção.

**Como escolher o layout "correto" para um novo slide se o mestre tem muitas opções?**

Normalmente escolha o [LayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/layoutslide/) que corresponde à estrutura necessária ([Título e Conteúdo, Dois Conteúdos, etc.](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidelayouttype/)). Se esse layout estiver ausente, você pode [adicione‑lo ao mestre](/slides/pt/cpp/slide-layout/) e então usá‑lo.