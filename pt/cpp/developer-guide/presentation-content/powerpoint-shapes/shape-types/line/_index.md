---
title: Adicionar formas de linha a apresentações em C++
linktitle: Linha
type: docs
weight: 50
url: /pt/cpp/line/
keywords:
- linha
- criar linha
- adicionar linha
- linha simples
- configurar linha
- personalizar linha
- estilo de traço
- ponta de seta
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações do PowerPoint com Aspose.Slides para C++. Descubra propriedades, métodos e exemplos."
---
## **Visão geral**

O Aspose.Slides permite que você adicione formas de linha a slides do PowerPoint programaticamente. Este artigo mostra como criar uma linha simples e como personalizar uma linha para que ela apareça como uma seta.

Você aprenderá como adicionar uma forma de linha a um slide, ajustar sua aparência visual e salvar a apresentação atualizada. Os exemplos se concentram em configurações práticas de formatação de linha, como estilo, largura, padrão de traço, opções de ponta de seta e cor de preenchimento.

## **Criar uma Linha Simples**
Para adicionar uma linha simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da [Presentation class](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Linha usando o método [AddAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addautoshape/) exposto pelo objeto Shapes.
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Criar uma Linha em Formato de Seta**
O Aspose.Slides para C++ também permite que os desenvolvedores configurem algumas propriedades da linha para torná‑la mais atraente. Vamos tentar configurar algumas propriedades da linha para que ela pareça uma seta. Siga as etapas abaixo:

- Crie uma instância da [Presentation class](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes.
- Defina o Estilo da Linha para um dos estilos oferecidos pelo Aspose.Slides para C++.
- Defina a Largura da linha.
- Defina o [Dash Style](https://reference.aspose.com/slides/pt/cpp/aspose.slides/linedashstyle/) da linha para um dos estilos oferecidos pelo Aspose.Slides para C++.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/cpp/aspose.slides/lineformat/) e o Comprimento do ponto inicial da linha.
- Defina o Estilo da Ponta de Seta e o Comprimento do ponto final da linha.
- Grave a apresentação modificada como um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **Perguntas Frequentes**

**Posso converter uma linha regular em um conector para que ela “encaixe” nas formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/autoshape/) do tipo [Line](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapetype/)) não se transforma automaticamente em um conector. Para que ela se encaixe nas formas, use o tipo [Connector](https://reference.aspose.com/slides/pt/cpp/aspose.slides/connector/) e as [corresponding APIs](/slides/pt/cpp/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha forem herdadas do tema e for difícil determinar os valores finais?**

[Leia as propriedades efetivas](/slides/pt/cpp/shape-effective-properties/) através das interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilinefillformateffectivedata/) — elas já consideram a herança e os estilos do tema.

**Posso bloquear uma linha contra edição (movimento, redimensionamento)?**

Sim. As formas fornecem [lock objects](https://reference.aspose.com/slides/pt/cpp/aspose.slides/autoshape/get_autoshapelock/) que permitem [disallow editing operations](/slides/pt/cpp/applying-protection-to-presentation/).