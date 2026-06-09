---
title: Gerenciar Sobrescrito e Subscrito em Apresentações com Java
linktitle: Sobrescrito e Subscrito
type: docs
weight: 80
url: /pt/java/superscript-and-subscript/
keywords:
- sobrescrito
- subscrito
- adicionar sobrescrito
- adicionar subscrito
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Domine o sobrescrito e o subscrito no Aspose.Slides para Java e eleve suas apresentações com formatação de texto profissional para máximo impacto."
---
## **Visão geral**

Aspose.Slides oferece recursos para integrar texto em sobrescrito e subscrito em suas apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP). Seja para destacar fórmulas químicas, equações matemáticas ou anotar conteúdo com notas de rodapé, essas opções de formatação especial ajudam a manter clareza e precisão. Neste artigo, você aprenderá como aplicar estilos de sobrescrito e subscrito de forma fluida e garantir resultados profissionais em cada slide.

## **Gerenciar Texto em Sobrescrito e Subscrito**
Você pode adicionar texto em sobrescrito e subscrito dentro de qualquer porção de parágrafo. Para adicionar texto em Sobrescrito ou Subscrito em um quadro de texto do Aspose.Slides, deve‑se usar o método [**setEscapement**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) da classe [PortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/PortionFormat).

Esta propriedade retorna ou define o texto em sobrescrito ou subscrito (valor de -100 % (subscrito) a 100 % (sobrescrito)). Por exemplo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape) do tipo [Rectangle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeType#Rectangle) ao slide.
- Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITextFrame) associado ao [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape).
- Limpe os Parágrafos existentes
- Crie um novo objeto de parágrafo para conter texto em sobrescrito e adicione‑o à coleção [IParagraphs](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITextFrame#getParagraphs--) do [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITextFrame).
- Crie um novo objeto de porção
- Defina a propriedade Escapement para a porção entre 0 e 100 para adicionar sobrescrito. (0 significa sem sobrescrito)
- Defina algum texto para [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Portion) e então adicione‑o à coleção de porções do parágrafo.
- Crie um novo objeto de parágrafo para conter texto em subscrito e adicione‑o à coleção IParagraphs do ITextFrame.
- Crie um novo objeto de porção
- Defina a propriedade Escapement para a porção entre 0 e -100 para adicionar subscrito. (0 significa sem subscrito)
- Defina algum texto para [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Portion) e então adicione‑o à coleção de porções do parágrafo.
- Salve a apresentação como um arquivo PPTX.

A implementação das etapas acima é apresentada a seguir.

```java
// Instanciar uma classe Presentation que representa um PPTX
Presentation pres = new Presentation();
try {
    // Obter slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Criar caixa de texto
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Criar parágrafo para texto em sobrescrito
    IParagraph superPar = new Paragraph();

    // Criar porção com texto normal
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Criar porção com texto em sobrescrito
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Criar parágrafo para texto em subscrito
    IParagraph paragraph2 = new Paragraph();

    // Criar porção com texto normal
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Criar porção com texto em subscrito
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Adicionar parágrafos à caixa de texto
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**O sobrescrito e o subscrito serão preservados ao exportar para PDF ou outros formatos?**

Sim, o Aspose.Slides preserva corretamente a formatação de sobrescrito e subscrito ao exportar apresentações para PDF, PPT/PPTX, imagens e outros formatos compatíveis. A formatação especializada permanece intacta em todos os arquivos de saída.

**É possível combinar sobrescrito e subscrito com outros estilos de formatação, como negrito ou itálico?**

Sim, o Aspose.Slides permite misturar vários estilos de texto dentro de uma única porção. Você pode habilitar negrito, itálico, sublinhado e simultaneamente aplicar sobrescrito ou subscrito configurando as propriedades correspondentes em [PortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portionformat/).

**A formatação de sobrescrito e subscrito funciona para texto dentro de tabelas, gráficos ou SmartArt?**

Sim, o Aspose.Slides oferece suporte à formatação na maioria dos objetos, incluindo tabelas e elementos de gráficos. Ao trabalhar com SmartArt, é necessário acessar os elementos apropriados (como [SmartArtNode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/smartartnode/)) e seus contêineres de texto, e então configurar as propriedades de [PortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portionformat/) de maneira similar.