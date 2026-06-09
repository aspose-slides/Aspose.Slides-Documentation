---
title: Criar apresentações em .NET
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Crie apresentações em .NET com Aspose.Slides — produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar conteúdo simples a um slide e salvar o resultado como um arquivo. Também demonstra como criar e salvar uma nova apresentação, abrir uma apresentação existente em um formato suportado e salvá‑la em outro formato. Além disso, o artigo inclui um FAQ curto que cobre perguntas comuns relacionadas a formatos, modelos, dimensionamento de slides, unidades, uso de memória, paralelismo, licenciamento, assinaturas digitais e suporte a VBA.

## **Criar uma Apresentação PowerPoint**
Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

1. Crie uma instância da classe Presentation.
2. Obtenha a referência de um slide usando seu índice.
3. Adicione um AutoShape do tipo Line usando o método AddAutoShape exposto pelo objeto Shapes.
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```c#
// Instanciar um objeto Presentation que representa um arquivo de apresentação
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide
    ISlide slide = presentation.Slides[0];

    // Adicionar um autoshape do tipo linha
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Criar e Salvar uma Apresentação**

<a name="csharp-create-save-presentation"><strong>Etapas: criar e salvar apresentação em C#</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Salve _Presentation_ em qualquer formato suportado por [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Abrir e Salvar uma Apresentação**

<a name="csharp-open-save-presentation"><strong>Etapas: abrir e salvar apresentação em C#</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) com qualquer formato, ou seja, PPT, PPTX, ODP etc.
2. Salve _Presentation_ em qualquer formato suportado por [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/)

```c#
// Carregue qualquer arquivo suportado no Presentation, por exemplo ppt, pptx, odp etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/net/save-presentation/), e exportar para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), [XPS](/slides/pt/net/convert-powerpoint-to-xps/), [HTML](/slides/pt/net/convert-powerpoint-to-html/), [SVG](/slides/pt/net/convert-powerpoint-to-png/) e [imagens](/slides/pt/net/convert-powerpoint-to-png/), entre outros.

**Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX normal?**

Sim. Carregue o modelo e salve no formato desejado; formatos como POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/net/supported-file-formats/).

**Como controlo o tamanho/ proporção do slide ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/net/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em quais unidades são medidos tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/net/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de somente streams em memória.

**Posso criar/salvar apresentações em paralelo?**

Você não pode operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/net/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como remover a marca d’água de avaliação e as limitações?**

[Aplicar uma licença](/slides/pt/net/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado e a configuração da licença deve ser sincronizada se houver várias threads.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/net/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/net/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.