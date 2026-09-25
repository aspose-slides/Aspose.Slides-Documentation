---
title: Gerenciar Acessibilidade de Apresentação em C++
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/cpp/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- texto alternativo
- título de texto alternativo
- descrição de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Automatize verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP com Aspose.Slides para C++—melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Introdução**

Texto alternativo ajuda pessoas que utilizam tecnologias assistivas a entender o significado de imagens, gráficos e outras formas informativas. Este artigo explica como ler e atualizar títulos e descrições de texto alternativo com Aspose.Slides para C++, distinguir descrições de acessibilidade dos nomes de formas usados no código e verificar se uma forma está marcada como decorativa.

Esses recursos suportam a acessibilidade de apresentações, mas não a garantem. A ordem de leitura, contraste de cores, legibilidade do texto e outros requisitos de acessibilidade também precisam ser revisados.

## **Gerenciar Títulos e Descrições de Texto Alternativo**

Use o texto alternativo para explicar o significado de imagens, gráficos e outras formas informativas para pessoas que não podem vê-los. As propriedades a seguir servem a diferentes propósitos:

| Propriedade ou conteúdo | Propósito |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Um título curto para a descrição alternativa. |
| [AlternativeText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_alternativetext/) | Uma descrição significativa do conteúdo ou propósito da forma no contexto do slide. |
| [Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_name/) | O nome da forma, que o código pode usar para encontrar uma forma específica na apresentação. |
| Texto visível | Conteúdo exibido no slide, como o texto de uma forma ou o título e rótulos de um gráfico. Atualizar o texto alternativo não altera esse conteúdo. |

Quando uma apresentação é reutilizada como modelo, o código pode encontrar uma forma pelo seu [Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_name/) antes de atualizá‑la. Esse nome serve a um propósito diferente do texto alternativo, que explica o que o visual comunica ao leitor. Pesquisar por nome permite que os autores melhorem ou traduzam descrições sem mudar como o código encontra a forma. Nomes podem ser editados e não são garantidos como únicos, portanto verifique se o nome corresponde à forma desejada; veja [Identificar e Encontrar Formas](/slides/pt/cpp/shape-manipulations/#identify-and-find-shapes).

O exemplo a seguir requer `input.pptx` com uma imagem da entrada de um escritório como a primeira forma no primeiro slide. A imagem não deve ser marcada como decorativa. O exemplo lê e imprime o título e a descrição atuais do texto alternativo, atualiza ambos os valores e salva a apresentação como `output.pptx`. Adapte a redação à imagem real e às informações que ela transmite.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Adicionar apenas texto alternativo não garante a acessibilidade da apresentação ou a conformidade com os padrões de acessibilidade. Revise as descrições quanto à precisão e relevância, e também verifique a ordem de leitura, contraste de cores, legibilidade do texto e outros requisitos de acessibilidade. Visuais informativos não devem ser marcados como decorativos; a próxima seção mostra como ler [IsDecorative](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_isdecorative/).

## **Marcar como Decorativo**

A marcação como decorativo sinaliza visuais puramente ornamentais para que os leitores de tela os ignorem, reduzindo o ruído e mantendo o foco no conteúdo significativo. Aplique-a a fundos, enfeites e espaçadores — nunca a gráficos, ícones ou imagens que transmitam informações. Aspose.Slides expõe essa sinalização para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Marcar como Decorativo](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **Perguntas Frequentes**

**O que devo colocar no título e na descrição do texto alternativo?**

Use um título curto para identificar o assunto e uma descrição para explicar as informações que o visual transmite no contexto do slide. Para um gráfico, descreva a tendência ou comparação relevante em vez de apenas dizer "gráfico".

**Devo usar texto alternativo para localizar formas em um modelo?**

Prefira encontrar a forma pelo seu [Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_name/) e verifique se é a forma esperada. O texto alternativo pode ser editado ou traduzido, o que pode quebrar o código que busca uma descrição exata; veja [Identificar e Encontrar Formas](/slides/pt/cpp/shape-manipulations/).

**Quando uma forma deve ser marcada como decorativa?**

Use a sinalização decorativa para visuais que não adicionam informação, como enfeites ornamentais. Imagens e gráficos que comunicam significado precisam de uma descrição apropriada.

**Adicionar texto alternativo torna uma apresentação totalmente acessível?**

Não. O texto alternativo cobre apenas parte da acessibilidade. Também revise a ordem de leitura, contraste de cores, legibilidade do texto e outros requisitos aplicáveis; definir apenas essas propriedades não estabelece conformidade.