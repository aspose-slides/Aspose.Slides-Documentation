---
title: Gerenciar Acessibilidade de Apresentações em .NET
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/net/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- texto alternativo
- título de texto alternativo
- descrição de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Automatize verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP com Aspose.Slides para .NET—melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Introdução**

Texto alternativo ajuda pessoas que utilizam tecnologias assistivas a entender o significado de imagens, gráficos e outras formas informativas. Este artigo explica como ler e atualizar títulos e descrições de texto alternativo com Aspose.Slides para .NET, diferenciar descrições de acessibilidade dos nomes de formas usados no código e verificar se uma forma está marcada como decorativa.

Esses recursos suportam a acessibilidade de apresentações, mas não a garantem. Ordem de leitura, contraste de cores, legibilidade do texto e outros requisitos de acessibilidade também precisam ser revisados.

## **Gerenciar Títulos e Descrições de Texto Alternativo**

Use texto alternativo para explicar o significado de imagens, gráficos e outras formas informativas para pessoas que não podem vê‑las. As propriedades a seguir atendem a diferentes propósitos:

| Propriedade ou conteúdo | Finalidade |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/alternativetexttitle/) | Um título curto para a descrição alternativa. |
| [AlternativeText](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/alternativetext/) | Uma descrição significativa do conteúdo ou finalidade da forma no contexto do slide. |
| [Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/name/) | O nome da forma, que o código pode usar para localizar uma forma específica na apresentação. |
| Texto visível | Conteúdo exibido no slide, como o texto de uma forma ou o título e rótulos de um gráfico. Atualizar o texto alternativo não altera esse conteúdo. |

Quando uma apresentação é reutilizada como modelo, o código pode localizar uma forma pelo seu [Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/name/) antes de atualizá‑la. Esse nome tem um propósito diferente do texto alternativo, que explica o que o visual comunica ao leitor. Pesquisar pelo nome permite que os autores melhorem ou traduzam descrições sem mudar a forma como o código localiza a forma. Nomes podem ser editados e não são garantidos como únicos, portanto verifique se o nome corresponde à forma pretendida; veja [Identify and Find Shapes](/slides/pt/net/shape-manipulations/#identify-and-find-shapes).

O exemplo a seguir requer `input.pptx` com uma imagem de entrada de escritório como a primeira forma no primeiro slide. A imagem não deve estar marcada como decorativa. O exemplo lê e imprime o título e a descrição atuais do texto alternativo, atualiza ambos os valores e salva a apresentação como `output.pptx`. Adapte a redação à imagem real e às informações que ela transmite.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Adicionar apenas texto alternativo não garante a acessibilidade da apresentação nem a conformidade com normas de acessibilidade. Revise as descrições quanto à precisão e relevância e também verifique a ordem de leitura, contraste de cores, legibilidade do texto e outros requisitos de acessibilidade. Visuais informativos não devem ser marcados como decorativos; a próxima seção mostra como ler [IsDecorative](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/isdecorative/).

## **Marcar como Decorativo**

Marcar como decorativo sinaliza visuais puramente ornamentais para que leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique isso a fundos, enfeites e espaçadores — nunca a gráficos, ícones ou imagens que transmitam informação. Aspose.Slides expõe essa sinalização para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Mark as Decorative](mark_as_decorative.png)

O código a seguir demonstra como determinar se uma forma está marcada como decorativa.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**O que devo colocar no título e na descrição do texto alternativo?**

Use um título curto para identificar o assunto e uma descrição para explicar a informação que o visual transmite no contexto do slide. Para um gráfico, descreva a tendência ou comparação relevante em vez de apenas dizer “gráfico”.

**Devo usar texto alternativo para localizar formas em um modelo?**

Prefira localizar a forma pelo seu [Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/name/) e verificar se é a forma esperada. O texto alternativo pode ser editado ou traduzido, o que pode quebrar o código que procura por uma descrição exata; veja [Identify and Find Shapes](/slides/pt/net/shape-manipulations/).

**Quando uma forma deve ser marcada como decorativa?**

Use a sinalização decorativa para visuais que não agregam informação, como enfeites ornamentais. Imagens e gráficos que comunicam significado precisam de uma descrição apropriada.

**Adicionar texto alternativo torna uma apresentação totalmente acessível?**

Não. Texto alternativo cobre apenas parte da acessibilidade. Também revise a ordem de leitura, contraste de cores, legibilidade do texto e outros requisitos aplicáveis; definir essas propriedades sozinhas não estabelece conformidade.