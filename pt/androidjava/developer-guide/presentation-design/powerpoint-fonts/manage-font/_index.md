---
title: Gerenciar fontes em apresentações no Android
linktitle: Gerenciar fontes
type: docs
weight: 10
url: /pt/androidjava/manage-fonts/
keywords:
- gerenciar fontes
- propriedades de fonte
- parágrafo
- formatação de texto
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Controle fontes em Java com Aspose.Slides para Android: incorpore, substitua e carregue fontes personalizadas para manter apresentações PPT, PPTX e ODP claras, seguras para a marca e consistentes."
---
## **Visão geral**

Aspose.Slides permite que você gerencie propriedades de fonte no texto da apresentação diretamente a partir do seu código. Você pode acessar o texto nos slides através de formas, quadros de texto, parágrafos e porções, e então aplicar formatação ao texto selecionado.

Este artigo explica como configurar propriedades relacionadas a fontes para texto existente em uma apresentação, incluindo família de fontes, estilos negrito e itálico, alinhamento de parágrafo e cor da fonte. Também demonstra como criar uma caixa de texto, adicionar texto a ela e definir propriedades de fonte como família de fontes, negrito, itálico, sublinhado, tamanho da fonte e cor antes de salvar o resultado como um arquivo PPTX.

## **Gerenciar Propriedades Relacionadas a Fontes**
{{% alert color="primary" %}} 

Apresentações geralmente contêm tanto texto quanto imagens. O texto pode ser formatado de várias maneiras, seja para destacar seções e palavras específicas ou para atender aos estilos corporativos. A formatação de texto ajuda os usuários a variar a aparência e a sensação do conteúdo da apresentação. Este artigo mostra como usar Aspose.Slides for Android via Java para configurar as propriedades de fonte dos parágrafos de texto nos slides.

{{% /alert %}} 

Para gerenciar propriedades de fonte de um parágrafo usando Aspose.Slides for Android via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse as formas [Placeholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholder/) no slide e faça cast para [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/).
1. Obtenha o [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/) exposto por [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/).
1. Justifique o parágrafo.
1. Acesse a [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) de texto de um [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/).
1. Defina a fonte usando [FontData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontdata/) e ajuste a **Font** da [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) de texto de acordo.
   1. Defina a fonte como negrito.
   1. Defina a fonte como itálico.
1. Defina a cor da fonte usando o [FillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/) exposto pelo objeto [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/).
1. Salve a apresentação modificada em um arquivo PPTX.

A implementação das etapas acima é apresentada a seguir. Ela recebe uma apresentação sem formatação e formata as fontes em um dos slides. As capturas de tela a seguir mostram o arquivo de entrada e como os trechos de código o alteram. O código altera a fonte, a cor e o estilo da fonte.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: The text in the input file**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: The same text with updated formatting**|

```java
// Instanciar um objeto Presentation que representa um arquivo PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Acessando um slide usando sua posição
	ISlide slide = pres.getSlides().get_Item(0);

	// Acessando o primeiro e o segundo placeholder no slide e convertendo-o para AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Acessando o primeiro Parágrafo
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justificar o parágrafo
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Acessando a primeira porção
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definir novas fontes
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Atribuir novas fontes à porção
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Definir fonte como negrito
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Definir fonte como itálico
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Definir cor da fonte
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Salvar o PPTX no disco
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Definir Propriedades de Fonte do Texto**
{{% alert color="primary" %}} 

Conforme mencionado em **Gerenciar Propriedades Relacionadas a Fontes**, um [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) é usado para conter texto com estilo de formatação semelhante em um parágrafo. Este artigo mostra como usar Aspose.Slides for Android via Java para criar uma caixa de texto com algum conteúdo e, em seguida, definir uma fonte específica e várias outras propriedades da categoria de família de fontes.

{{% /alert %}} 

Para criar uma caixa de texto e definir propriedades de fonte do texto nela:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/) do tipo **Rectangle** ao slide.
1. Remova o estilo de preenchimento associado ao [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/).
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/) do [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/).
1. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/).
1. Acesse o objeto [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) associado ao [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/).
1. Defina a fonte a ser usada para o [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/).
1. Defina outras propriedades da fonte como negrito, itálico, sublinhado, cor e altura usando as propriedades relevantes expostas pelo objeto [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/).
1. Grave a apresentação modificada como um arquivo PPTX.

A implementação das etapas acima é apresentada a seguir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Text with some font properties set by Aspose.Slides for Android via Java**|

```java
// Instanciar um objeto Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
	// Obter o primeiro slide
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Adicionar um AutoShape do tipo Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Remover qualquer estilo de preenchimento associado ao AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Acessar o TextFrame associado ao AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Acessar a Portion associada ao TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Definir a fonte para a Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Definir a propriedade negrito da fonte
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Definir a propriedade itálico da fonte
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Definir a propriedade sublinhado da fonte
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Definir a altura da fonte
	port.getPortionFormat().setFontHeight(25);
	
	// Definir a cor da fonte
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Salvar a apresentação no disco
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```