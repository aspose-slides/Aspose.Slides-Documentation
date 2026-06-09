---
title: Gerenciar sobrescrito e subscrito em apresentações em .NET
linktitle: Sobrescrito e Subscrito
type: docs
weight: 80
url: /pt/net/superscript-and-subscript/
keywords:
- sobrescrito
- subscrito
- adicionar sobrescrito
- adicionar subscrito
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine sobrescrito e subscrito no Aspose.Slides para .NET e eleve suas apresentações com formatação de texto profissional para máximo impacto."
---
## **Visão geral**

Aspose.Slides for .NET oferece recursos para integrar texto em sobrescrito e subscrito em suas apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP). Seja para destacar fórmulas químicas, equações matemáticas ou anotar o conteúdo com notas de rodapé, essas opções de formatação especial ajudam a manter clareza e precisão. Neste artigo, você aprenderá a aplicar estilos de sobrescrito e subscrito de forma contínua e garantir resultados profissionais em cada slide.

## **Adicionar Texto em Sobrescrito e Subscrito**

Você pode adicionar texto em sobrescrito e subscrito dentro de qualquer parágrafo em uma apresentação. Para conseguir isso com Aspose.Slides, você deve usar a propriedade `Escapement` da classe [PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/portionformat/).

Essa propriedade permite definir texto em sobrescrito ou subscrito, com valores que variam de -100% (subscrito) a 100% (sobrescrito).

Etapas de implementação:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide usando seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) do tipo `Rectangle` ao slide.
1. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) associado ao [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/).
1. Limpe os parágrafos existentes.
1. Crie um novo [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/) para texto em sobrescrito e adicione‑o à coleção de parágrafos do [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/).
1. Crie um novo objeto de porção de texto.
1. Defina a propriedade `Escapement` para a porção de texto entre 0 e 100 para aplicar sobrescrito (0 significa sem sobrescrito).
1. Defina algum texto para a [Portion](https://reference.aspose.com/slides/pt/net/aspose.slides/portion/) e adicione‑o à coleção de porções do parágrafo.
1. Crie outro [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/) para texto em subscrito e adicione‑o à coleção de parágrafos.
1. Crie um novo objeto de porção de texto.
1. Defina a propriedade `Escapement` para a porção de texto entre 0 e -100 para aplicar subscrito (0 significa sem subscrito).
1. Defina algum texto para a [Portion](https://reference.aspose.com/slides/pt/net/aspose.slides/portion/) e adicione‑o à coleção de porções do parágrafo.
1. Salve a apresentação como um arquivo PPTX.

O código C# a seguir implementa essas etapas:

```c#
using (Presentation presentation = new Presentation())
{
    // Obtenha o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Crie uma caixa de texto.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Crie um parágrafo para texto em sobrescrito.
    IParagraph superPar = new Paragraph();

    // Crie uma porção de texto com texto regular.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Crie uma porção de texto com texto em sobrescrito.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Crie um parágrafo para texto em subscrito.
    IParagraph paragraph2 = new Paragraph();

    // Crie uma porção de texto com texto regular.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Crie uma porção de texto com texto em subscrito.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Adicione os parágrafos à caixa de texto.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

O resultado:

![Sobrescrito e Subscrito](superscript_and_subscript.png)

## **Perguntas frequentes**

**A formatação de sobrescrito e subscrito será preservada ao exportar para PDF ou outros formatos?**

Sim, Aspose.Slides for .NET mantém corretamente a formatação de sobrescrito e subscrito ao exportar apresentações para PDF, PPT/PPTX, imagens e outros formatos suportados. A formatação especializada permanece intacta em todos os arquivos de saída.

**É possível combinar sobrescrito e subscrito com outros estilos de formatação, como negrito ou itálico?**

Sim, Aspose.Slides permite mesclar vários estilos de texto dentro de uma única porção. Você pode ativar negrito, itálico, sublinhado e, simultaneamente, aplicar sobrescrito ou subscrito configurando as propriedades correspondentes em [PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/portionformat/).

**A formatação de sobrescrito e subscrito funciona para texto dentro de tabelas, gráficos ou SmartArt?**

Sim, Aspose.Slides for .NET suporta formatação na maioria dos objetos, incluindo tabelas e elementos de gráficos. Ao trabalhar com SmartArt, você precisa acessar os elementos apropriados (como [SmartArtNode](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartartnode/)) e seus contêineres de texto, e então configurar as propriedades de [PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/portionformat/) de maneira similar.