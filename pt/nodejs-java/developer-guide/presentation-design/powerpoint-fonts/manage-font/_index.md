---
title: Gerenciar fontes em apresentações usando JavaScript
linktitle: Gerenciar fontes
type: docs
weight: 10
url: /pt/nodejs-java/manage-fonts/
keywords:
- gerenciar fontes
- propriedades de fonte
- parágrafo
- formatação de texto
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Controle fontes com Aspose.Slides for Node.js via Java: incorpore, substitua e carregue fontes personalizadas para manter apresentações PPT, PPTX e ODP claras e consistentes."
---
## **Introdução**

Apresentações geralmente contêm texto e imagens. O texto pode ser formatado de várias maneiras, seja para destacar seções e palavras específicas ou para seguir estilos corporativos. A formatação de texto ajuda os usuários a variar a aparência do conteúdo da apresentação. Este artigo mostra como usar Aspose.Slides for Node.js via Java para configurar as propriedades de fonte de parágrafos de texto nos slides.

## **Gerenciar Propriedades Relacionadas à Fonte**

Para gerenciar as propriedades de fonte de um parágrafo usando Aspose.Slides for Node.js via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse as formas [Placeholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholder/) no slide e faça o casting para [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).
1. Recupere o [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) da [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) exposta por [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).
1. Justifique o parágrafo.
1. Acesse o [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) de texto de um [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/).
1. Defina a fonte usando [FontData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontdata/) e ajuste a **Font** do [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) de texto adequadamente.
   1. Defina a fonte como negrito.
   1. Defina a fonte como itálico.
1. Defina a cor da fonte usando o [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/) exposto pelo objeto [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/).
1. Salve a apresentação modificada em um arquivo PPTX.

A implementação das etapas acima é fornecida abaixo. Ela recebe uma apresentação simples e formata as fontes em um dos slides. As capturas de tela a seguir mostram o arquivo de entrada e como os trechos de código o alteram. O código altera a fonte, a cor e o estilo da fonte.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: O texto no arquivo de entrada**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: O mesmo texto com formatação atualizada**|

```javascript
// Instanciar um objeto Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Acessando um slide usando sua posição
    var slide = pres.getSlides().get_Item(0);
    // Acessando o primeiro e o segundo placeholder no slide e fazendo cast para AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Acessando o primeiro Parágrafo
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Justificar o parágrafo
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Acessando a primeira porção
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Definir novas fontes
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Atribuir novas fontes à porção
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Definir fonte como negrito
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Definir fonte como itálico
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Definir cor da fonte
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Salvar o PPTX no disco
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Propriedades de Fonte do Texto**
{{% alert color="primary" %}} 

Conforme mencionado em **Gerenciar Propriedades Relacionadas à Fonte**, um [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) é usado para conter texto com estilo de formatação semelhante em um parágrafo. Este artigo mostra como usar Aspose.Slides for Node.js via Java para criar uma caixa de texto com algum texto e então definir uma fonte específica, bem como várias outras propriedades da categoria de família de fontes.

{{% /alert %}} 

Para criar uma caixa de texto e definir as propriedades de fonte do texto nela:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) do tipo **Rectangle** ao slide.
1. Remova o estilo de preenchimento associado ao [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) do [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).
1. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
1. Acesse o objeto [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) associado ao [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
1. Defina a fonte a ser usada para o [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/).
1. Defina outras propriedades da fonte, como negrito, itálico, sublinhado, cor e altura, usando as propriedades relevantes expostas pelo objeto [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/).
1. Grave a apresentação modificada como um arquivo PPTX.

A implementação das etapas acima é fornecida abaixo.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto com algumas propriedades de fonte definidas pelo Aspose.Slides for Node.js via Java**|

```javascript
// Instanciar um objeto Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar um AutoShape do tipo Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Remover qualquer estilo de preenchimento associado ao AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Acessar o TextFrame associado ao AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Acessar a Portion associada ao TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Definir a Fonte para a Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Definir a propriedade Negrito da Fonte
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Definir a propriedade Itálico da Fonte
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Definir a propriedade Sublinhado da Fonte
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Definir a Altura da Fonte
    port.getPortionFormat().setFontHeight(25);
    // Definir a cor da Fonte
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Salvar a apresentação no disco
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```