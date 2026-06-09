---
title: Gerenciar Sobrescrito e Subscrito em Apresentações Usando JavaScript
linktitle: Sobrescrito e Subscrito
type: docs
weight: 80
url: /pt/nodejs-java/superscript-and-subscript/
keywords:
- sobrescrito
- subscrito
- adicionar sobrescrito
- adicionar subscrito
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine sobrescrito e subscrito no Aspose.Slides para Node.js via Java e eleve suas apresentações com formatação de texto profissional para máximo impacto."
---
## **Visão geral**

Aspose.Slides oferece recursos para integrar texto em sobrescrito e subscrito em suas apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP). Seja para destacar fórmulas químicas, equações matemáticas ou anotar conteúdo com notas de rodapé, essas opções de formatação especial ajudam a manter clareza e precisão. Neste artigo, você aprenderá como aplicar estilos de sobrescrito e subscrito de forma contínua e garantir resultados profissionais em cada slide.

## **Gerenciar Texto em Sobrescrito e Subscrito**

Você pode adicionar texto em sobrescrito e subscrito dentro de qualquer porção de parágrafo. Para adicionar texto em Sobrescrito ou Subscrito em um quadro de texto do Aspose.Slides, deve‑se usar o método [**setEscapement**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) da classe [PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PortionFormat).

Esta propriedade retorna ou define o texto em sobrescrito ou subscrito (valor de -100% (subscrito) a 100% (sobrescrito)). Por exemplo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) do tipo [Rectangle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeType#Rectangle) ao slide.
- Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame) associado ao [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape).
- Limpe os Parágrafos existentes
- Crie um novo objeto de parágrafo para conter texto em sobrescrito e adicione‑o à [Paragraphs collection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame#getParagraphs--) do [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame).
- Crie um novo objeto de porção
- Defina a propriedade Escapement para a porção entre 0 e 100 para adicionar sobrescrito. (0 significa sem sobrescrito)
- Defina algum texto para [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Portion) e então adicione‑o na coleção de porções do parágrafo.
- Crie um novo objeto de parágrafo para conter texto em subscrito e adicione‑o à coleção IParagraphs do ITextFrame.
- Crie um novo objeto de porção
- Defina a propriedade Escapement para a porção entre 0 e -100 para adicionar subscrito. (0 significa sem subscrito)
- Defina algum texto para [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Portion) e então adicione‑o na coleção de porções do parágrafo.
- Salve a apresentação como um arquivo PPTX.

A implementação dos passos acima está apresentada a seguir.

```javascript
// Instanciar uma classe Presentation que representa um PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o slide
    var slide = pres.getSlides().get_Item(0);
    // Criar caixa de texto
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Criar parágrafo para texto em sobrescrito
    var superPar = new aspose.slides.Paragraph();
    // Criar porção com texto comum
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Criar porção com texto em sobrescrito
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Criar parágrafo para texto em subscrito
    var paragraph2 = new aspose.slides.Paragraph();
    // Criar porção com texto comum
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Criar porção com texto em subscrito
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Adicionar parágrafos à caixa de texto
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**A formatação em sobrescrito e subscrito será preservada ao exportar para PDF ou outros formatos?**

Sim, o Aspose.Slides preserva corretamente a formatação em sobrescrito e subscrito ao exportar apresentações para PDF, PPT/PPTX, imagens e outros formatos suportados. A formatação especializada permanece intacta em todos os arquivos de saída.

**É possível combinar sobrescrito e subscrito com outros estilos de formatação, como negrito ou itálico?**

Sim, o Aspose.Slides permite misturar vários estilos de texto dentro de uma única porção. Você pode ativar negrito, itálico, sublinhado e aplicar simultaneamente sobrescrito ou subscrito configurando as propriedades correspondentes em [PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/).

**A formatação em sobrescrito e subscrito funciona para texto dentro de tabelas, gráficos ou SmartArt?**

Sim, o Aspose.Slides oferece suporte à formatação na maioria dos objetos, incluindo tabelas e elementos de gráficos. Ao trabalhar com SmartArt, é necessário acessar os elementos apropriados (como [SmartArtNode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartnode/)) e seus contêineres de texto e, em seguida, configurar as propriedades [PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/) de maneira semelhante.