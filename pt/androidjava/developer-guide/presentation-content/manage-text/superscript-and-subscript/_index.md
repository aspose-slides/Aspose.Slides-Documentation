---
title: Gerenciar sobrescrito e subscrito em apresentações no Android
linktitle: Sobrescrito e Subscrito
type: docs
weight: 80
url: /pt/androidjava/superscript-and-subscript/
keywords:
- sobrescrito
- subscrito
- adicionar sobrescrito
- adicionar subscrito
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Domine sobrescrito e subscrito no Aspose.Slides para Android via Java e eleve suas apresentações com formatação de texto profissional para máximo impacto."
---
## **Visão geral**

Aspose.Slides fornece recursos para integrar texto sobrescrito e subscrito em suas apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP). Seja para destacar fórmulas químicas, equações matemáticas ou anotar conteúdo com notas de rodapé, essas opções de formatação especial ajudam a manter clareza e precisão. Neste artigo, você aprenderá como aplicar estilos de sobrescrito e subscrito de forma contínua e garantir resultados profissionais em cada slide.

## **Gerenciar texto sobrescrito e subscrito**
É possível adicionar texto sobrescrito e subscrito dentro de qualquer porção de parágrafo. Para adicionar texto sobrescrito ou subscrito em um quadro de texto do Aspose.Slides, deve‑se usar o método [**setEscapement**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) da classe [PortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/PortionFormat).

Essa propriedade obtém ou define o texto sobrescrito ou subscrito (valor de -100 % (subscrito) a 100 % (sobrescrito)). Por exemplo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu índice.
- Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAutoShape) do tipo [Rectangle](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ShapeType#Rectangle) ao slide.
- Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrame) associado ao [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAutoShape).
- Limpe os parágrafos existentes
- Crie um novo objeto de parágrafo para conter texto sobrescrito e adicione‑o à coleção [IParagraphs](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) do [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrame).
- Crie um novo objeto de porção
- Defina a propriedade Escapement da porção entre 0 e 100 para adicionar sobrescrito. (0 significa sem sobrescrito)
- Defina algum texto para [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Portion) e então adicione‑o à coleção de porções do parágrafo.
- Crie um novo objeto de parágrafo para conter texto subscrito e adicione‑o à coleção IParagraphs do ITextFrame.
- Crie um novo objeto de porção
- Defina a propriedade Escapement da porção entre 0 e -100 para adicionar subscrito. (0 significa sem subscrito)
- Defina algum texto para [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Portion) e então adicione‑o à coleção de porções do parágrafo.
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

    // Criar parágrafo para texto sobrescrito
    IParagraph superPar = new Paragraph();

    // Criar porção com texto normal
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Criar porção com texto sobrescrito
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Criar parágrafo para texto subscrito
    IParagraph paragraph2 = new Paragraph();

    // Criar porção com texto normal
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Criar porção com texto subscrito
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

## **Perguntas frequentes**

**A formatação sobrescrita e subscrita será preservada ao exportar para PDF ou outros formatos?**

Sim, o Aspose.Slides mantém corretamente a formatação sobrescrita e subscrita ao exportar apresentações para PDF, PPT/PPTX, imagens e outros formatos suportados. A formatação especializada permanece intacta em todos os arquivos de saída.

**É possível combinar sobrescrito e subscrito com outros estilos de formatação, como negrito ou itálico?**

Sim, o Aspose.Slides permite misturar vários estilos de texto dentro de uma única porção. Você pode habilitar negrito, itálico, sublinhado e, simultaneamente, aplicar sobrescrito ou subscrito configurando as propriedades correspondentes em [PortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portionformat/).

**A formatação sobrescrita e subscrita funciona para texto dentro de tabelas, gráficos ou SmartArt?**

Sim, o Aspose.Slides oferece suporte à formatação na maioria dos objetos, incluindo elementos de tabelas e gráficos. Ao trabalhar com SmartArt, é necessário acessar os elementos apropriados (como [SmartArtNode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/smartartnode/)) e seus contêineres de texto, e então configurar as propriedades de [PortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portionformat/) de maneira semelhante.