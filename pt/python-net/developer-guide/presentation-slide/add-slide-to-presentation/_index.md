---
title: Adicionar slides a apresentações com Python
linktitle: Adicionar slide
type: docs
weight: 10
url: /pt/python-net/add-slide-to-presentation/
keywords:
- adicionar slide
- criar slide
- slide vazio
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Adicione slides facilmente às suas apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET—inserção de slides contínua e eficiente em segundos."
---
## **Visão geral**

Antes de adicionar slides a uma apresentação, é útil entender como o PowerPoint os organiza. Cada apresentação contém um slide mestre, slides de layout opcionais e um ou mais slides normais. Cada slide tem um ID exclusivo e os slides normais são ordenados por um índice baseado em zero. Este artigo mostra como usar o Aspose.Slides para Python para criar slides e escolher layouts adequados.

## **Adicionar slides a apresentações**

Aspose.Slides permite acrescentar novos slides com base em slides de layout existentes. O exemplo abaixo itera por cada layout na apresentação, adiciona um slide que usa esse layout e, em seguida, salva o arquivo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Acesse a [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/).
1. Para cada item em `presentation.layout_slides`, chame `add_empty_slide` para acrescentar um slide que usa esse layout.
1. Opcionalmente, modifique os slides recém‑adicionados.
1. Salve a apresentação como um arquivo PPTX.

```py
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:
    # Acessar a coleção de slides.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Adicionar um slide vazio à coleção de slides.
        slides.add_empty_slide(layout_slide)

    # Executar algum trabalho nos slides recém‑adicionados.

    # Salvar a apresentação no disco.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Posso inserir um novo slide em uma posição específica, não apenas no final?**

Sim. A biblioteca oferece suporte a coleções de slides e às operações [insert](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/insert_clone/), permitindo adicionar um slide no índice desejado em vez de apenas no final.

**Os temas/estilos são preservados ao adicionar um slide baseado em um layout?**

Sim. Um layout herda a formatação do seu mestre, e o novo slide herda do layout selecionado e de seu mestre associado.

**Qual slide está presente em uma nova apresentação "vazia" antes de adicionar slides?**

Uma apresentação recém‑criada já contém um slide em branco com índice zero. Isso é importante considerar ao calcular os índices de inserção.

**Como escolher o layout "correto" para um novo slide se o mestre tem muitas opções?**

Geralmente escolha o [LayoutSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/) que corresponde à estrutura necessária ([Título e Conteúdo, Dois Conteúdos, etc.](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidelayouttype/)). Se esse layout estiver ausente, você pode [adicionar ao mestre](/slides/pt/python-net/slide-layout/) e então usá‑lo.