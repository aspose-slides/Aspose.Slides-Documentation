---
title: Adicionar Slides a Apresentações em PHP
linktitle: Adicionar Slide
type: docs
weight: 10
url: /pt/php-java/add-slide-to-presentation/
keywords:
- adicionar slide
- criar slide
- slide vazio
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Adicione slides facilmente às suas apresentações PowerPoint e OpenDocument usando Aspose.Slides para PHP via Java — inserção de slides fluida e eficiente em segundos."
---
## **Visão geral**

Aspose.Slides permite que você adicione slides a apresentações do PowerPoint programaticamente. Uma apresentação contém slides mestre/layout e slides normais, e os slides normais são organizados por um índice baseado em zero. Cada slide tem um ID exclusivo, e arquivos de apresentação sem slides não são suportados.

Este artigo explica como criar um objeto `Presentation`, acessar sua coleção de slides, adicionar um slide vazio, trabalhar com o slide recém‑adicionado e salvar a apresentação atualizada. Também aborda pontos relacionados, como inserir slides em uma posição específica, usar layouts e entender o slide em branco que existe em uma apresentação recém‑criada.

## **Adicionar um Slide a uma Apresentação**

Antes de falar sobre a adição de slides aos arquivos de apresentação, vamos discutir alguns fatos sobre os slides. Cada arquivo de apresentação do PowerPoint contém slide **Master / Layout** e outros slides **Normal**. Isso significa que um arquivo de apresentação contém pelo menos um ou mais slides. É importante saber que arquivos de apresentação sem slides não são suportados pelo Aspose.Slides for PHP via Java. Cada slide possui um Id exclusivo e todos os Slides Normais são organizados em uma ordem especificada por um índice baseado em zero.

Aspose.Slides for PHP via Java permite que desenvolvedores adicionem slides vazios à sua apresentação. Para adicionar um slide vazio na apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
- Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/) usando o método [getSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#getSlides--) (coleção de objetos Slide de conteúdo) exposto pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
- Adicione um slide vazio à apresentação no final da coleção de slides de conteúdo chamando o método [**addEmptySlide**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/#addEmptySlide) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/).
- Execute algumas operações com o slide vazio recém‑adicionado.
- Finalmente, grave o arquivo de apresentação usando o objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).

```php
  # Instanciar a classe Presentation que representa o arquivo de apresentação
  $pres = new Presentation();
  try {
    # Instanciar a classe SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Adicionar um slide vazio à coleção de Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Executar algumas operações no slide recém‑adicionado
    # Salvar o arquivo PPTX no disco
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Perguntas Frequentes**

**Posso inserir um novo slide em uma posição específica, não apenas no final?**

Sim. A biblioteca suporta coleções de slides e as operações [insert](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/insertclone/) , portanto você pode adicionar um slide no índice desejado em vez de apenas no final.

**Os temas/estilos são preservados ao adicionar um slide baseado em um layout?**

Sim. Um layout herda a formatação do seu mestre, e o novo slide herda do layout selecionado e do mestre associado.

**Qual slide está presente em uma nova apresentação "vazia" antes de adicionar slides?**

Uma apresentação recém‑criada já contém um slide em branco com índice zero. Isso é importante considerar ao calcular índices de inserção.

**Como escolher o layout "correto" para um novo slide se o mestre tem muitas opções?**

Normalmente escolha o [LayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/) que corresponda à estrutura necessária ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidelayouttype/)). Se esse layout estiver ausente, você pode [adicione ao mestre](/slides/pt/php-java/slide-layout/) e então usá‑lo.