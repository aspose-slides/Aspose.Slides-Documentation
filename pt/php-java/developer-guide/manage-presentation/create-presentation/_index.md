---
title: Criar Apresentações em PHP
linktitle: Criar Apresentação
type: docs
weight: 10
url: /pt/php-java/create-presentation/
keywords:
- criar apresentação
- nova apresentação
- criar PPT
- novo PPT
- criar PPTX
- novo PPTX
- criar ODP
- novo ODP
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Crie apresentações com Aspose.Slides para PHP via Java — produza arquivos PPT, PPTX e ODP e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar conteúdo simples a um slide e salvar o resultado como um arquivo. Também demonstra como criar e salvar uma nova apresentação, abrir uma apresentação existente em um formato suportado e salvá‑la em outro formato. Além disso, o artigo inclui um breve FAQ que cobre perguntas comuns relacionadas a formatos, modelos, dimensionamento de slides, unidades, uso de memória, threads, licenciamento, assinaturas digitais e suporte a VBA.

## **Criar uma Apresentação**

Para adicionar uma linha simples e plana a um slide selecionado da apresentação, siga os passos abaixo:

1. Crie uma instância da classe Presentation.
2. Obtenha a referência de um slide usando seu Index.
3. Adicione um AutoShape do tipo Line usando o método addAutoShape exposto pelo objeto Shapes.
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```php
  # Instanciar um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionar um autoshape do tipo linha
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/php-java/save-presentation/), e exportar para [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/php-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/php-java/convert-powerpoint-to-html/), [SVG](/slides/pt/php-java/convert-powerpoint-to-png/), e [imagens](/slides/pt/php-java/convert-powerpoint-to-png/), entre outros.

**Posso começar a partir de um modelo (POTX/POTM) e salvar como um PPTX comum?**

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e similares [são suportados](/slides/pt/php-java/supported-file-formats/).

**Como controlo o tamanho/ proporção do slide ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/php-java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em quais unidades são medidos tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/php-java/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de streams apenas na memória.

**Posso criar/salvar apresentações em paralelo?**

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/php-java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como remover a marca d'água de avaliação e as limitações?**

[Aplique uma licença](/slides/pt/php-java/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se múltiplas threads estiverem envolvidas.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/php-java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/php-java/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.