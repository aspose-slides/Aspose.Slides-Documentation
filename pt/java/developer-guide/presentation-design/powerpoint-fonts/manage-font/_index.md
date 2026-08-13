---
title: Gerenciar fontes em apresentações usando Java
linktitle: Gerenciar fontes
type: docs
weight: 10
url: /pt/java/manage-fonts/
keywords:
- gerenciar fontes
- propriedades de fonte
- parágrafo
- formatação de texto
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Controlar fontes em Java com Aspose.Slides: incorporar, substituir e carregar fontes personalizadas para manter apresentações PPT, PPTX e ODP claras, seguras para a marca e consistentes."
---
## **Visão geral**

Aspose.Slides permite que você gerencie propriedades de fonte no texto de apresentações diretamente a partir do seu código. Você pode acessar o texto nos slides por meio de shapes, quadros de texto, parágrafos e porções, e então aplicar formatação ao texto selecionado.

Este artigo explica como configurar propriedades relacionadas a fontes para texto existente em uma apresentação, incluindo família da fonte, estilos negrito e itálico, alinhamento de parágrafo e cor da fonte. Também mostra como criar uma caixa de texto, adicionar texto a ela e definir propriedades de fonte como família da fonte, negrito, itálico, sublinhado, tamanho da fonte e cor antes de salvar o resultado como um arquivo PPTX.

## **Gerenciar Propriedades Relacionadas à Fonte**
{{% alert color="info" %}} 

Apresentações geralmente contêm texto e imagens. O texto pode ser formatado de várias maneiras, seja para destacar seções e palavras específicas ou para atender a estilos corporativos. A formatação de texto ajuda os usuários a variar a aparência do conteúdo da apresentação. Este artigo mostra como usar Aspose.Slides for Java para configurar as propriedades de fonte dos parágrafos de texto nos slides.

{{% /alert %}} 

Para gerenciar as propriedades de fonte de um parágrafo usando Aspose.Slides for Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse os shapes [Placeholder](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholder/) no slide e faça cast para [AutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/).
1. Recupere o [Paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/paragraph/) a partir do [TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframe/) exposto por [AutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/).
1. Justifique o parágrafo.
1. Acesse o [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/) de texto de um [Paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/paragraph/).
1. Defina a fonte usando [FontData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontdata/) e configure a **Font** do [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/) de acordo.
   1. Defina a fonte como negrito.
   1. Defina a fonte como itálico.
1. Defina a cor da fonte usando o [FillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fillformat/) exposto pelo objeto [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/).
1. Salve a apresentação modificada em um arquivo PPTX.

A implementação dos passos acima é apresentada a seguir. Ela recebe uma apresentação sem formatação e aplica formatações de fonte em um dos slides. As capturas de tela abaixo mostram o arquivo de entrada e como os trechos de código o modificam. O código altera a fonte, a cor e o estilo da fonte.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: O texto no arquivo de entrada**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: O mesmo texto com formatação atualizada**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar um objeto Presentation que representa um arquivo PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Acessando um slide usando sua posição
	ISlide slide = pres.getSlides().get_Item(0);

	// Acessando o primeiro e o segundo placeholder no slide e convertendo para AutoShape
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

	// Definir fonte como Negrito
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Definir fonte como Itálico
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
{{% alert color="info" %}} 

Conforme mencionado em **Gerenciar Propriedades Relacionadas à Fonte**, um [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/) é usado para conter texto com estilo de formatação semelhante em um parágrafo. Este artigo mostra como usar Aspose.Slides for Java para criar uma caixa de texto com algum texto e, em seguida, definir uma fonte específica e várias outras propriedades da categoria de família de fontes.

{{% /alert %}} 

Para criar uma caixa de texto e definir as propriedades de fonte do texto nela:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/) do tipo **Rectangle** ao slide.
1. Remova o estilo de preenchimento associado ao [AutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/).
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframe/) do [AutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/).
1. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframe/).
1. Acesse o objeto [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/) associado ao [TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframe/).
1. Defina a fonte a ser usada para o [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/).
1. Defina outras propriedades de fonte, como negrito, itálico, sublinhado, cor e altura, usando as propriedades relevantes expostas pelo objeto [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/).
1. Grave a apresentação modificada como um arquivo PPTX.

A implementação dos passos acima é apresentada a seguir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto com algumas propriedades de fonte definidas pelo Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar um objeto Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
	// Obter o primeiro slide
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Adicionar um AutoShape do tipo Retângulo
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
	
	// Definir a propriedade Negrito da fonte
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Definir a propriedade Itálico da fonte
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Definir a propriedade Sublinhado da fonte
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