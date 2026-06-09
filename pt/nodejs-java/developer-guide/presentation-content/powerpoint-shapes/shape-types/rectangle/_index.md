---
title: Adicionar Retângulos a Apresentações em JavaScript
linktitle: Retângulo
type: docs
weight: 80
url: /pt/nodejs-java/rectangle/
keywords:
- adicionar retângulo
- criar retângulo
- forma de retângulo
- retângulo simples
- retângulo formatado
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Impulsione suas apresentações PowerPoint adicionando retângulos com JavaScript e Aspose.Slides para Node.js - projete e modifique formas programaticamente com facilidade."
---
## **Visão geral**

Este artigo mostra como adicionar formas de retângulo aos slides do PowerPoint usando o Aspose.Slides. Ele cobre a criação de um retângulo simples, a criação de um retângulo formatado e a gravação da apresentação atualizada como um arquivo PPTX.

Você também verá como aplicar formatação básica de retângulo, como cor de preenchimento sólido, cor da linha e largura da linha. Além disso, o FAQ do artigo aponta para tarefas relacionadas ao retângulo, incluindo cantos arredondados, preenchimentos de imagem, efeitos visuais, hyperlinks, bloqueios de forma, opções de exportação e propriedades efetivas. 

## **Adicionar Retângulo ao Slide**

Assim como nos tópicos anteriores, este também trata de adicionar uma forma e, desta vez, a forma que vamos discutir é Retângulo. Neste tópico, descrevemos como os desenvolvedores podem adicionar retângulos simples ou formatados aos seus slides usando o Aspose.Slides. 

Para adicionar um retângulo simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) do tipo Rectangle usando o método [addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um retângulo simples ao primeiro slide da apresentação.

```javascript
// Instanciar a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar AutoShape do tipo elipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Gravar o arquivo PPTX no disco
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionar Retângulo Formatado ao Slide**
Para adicionar um retângulo formatado a um slide, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) do tipo Rectangle usando o método [addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).
- Defina o [Fill Type](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FillType) do retângulo como Solid.
- Defina a Cor do Retângulo usando o método [SolidFillColor.setColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) exposto pelo objeto [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FillFormat) associado ao objeto [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape).
- Defina a Cor das linhas do Retângulo.
- Defina a Largura das linhas do Retângulo.
- Grave a apresentação modificada como um arquivo PPTX.

As etapas acima são implementadas no exemplo abaixo.

```javascript
// Instanciar a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar AutoShape do tipo elipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Aplicar alguma formatação à forma elipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Aplicar alguma formatação à linha da elipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Gravar o arquivo PPTX no disco
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Como adicionar um retângulo com cantos arredondados?**

Use o [shape type](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapetype/) de cantos arredondados e ajuste o raio do canto nas propriedades da forma; o arredondamento também pode ser aplicado por canto via ajustes de geometria.

**Como preencher um retângulo com uma imagem (textura)?**

Selecione o [fill type](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) de imagem, forneça a fonte da imagem e configure os [modos de esticamento/azulejo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillmode/).

**Um retângulo pode ter sombra e brilho?**

Sim. [Outer/inner shadow, glow, and soft edges](/slides/pt/nodejs-java/shape-effect/) estão disponíveis com parâmetros ajustáveis.

**Posso transformar um retângulo em um botão com hyperlink?**

Sim. [Assign a hyperlink](/slides/pt/nodejs-java/manage-hyperlinks/) ao clique da forma (ir para um slide, arquivo, endereço web ou e‑mail).

**Como posso proteger um retângulo contra movimentação e alterações?**

Use bloqueios de forma: você pode impedir movimentação, redimensionamento, seleção ou edição de texto para preservar o layout.

**Posso converter um retângulo em imagem raster ou SVG?**

Sim. Você pode [render the shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage) para uma imagem com tamanho/escala especificados ou [exportá‑la como SVG](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/writeassvg/) para uso vetorial.

**Como obter rapidamente as propriedades reais (efetivas) de um retângulo considerando tema e herança?**

[Use the shape’s effective properties](/slides/pt/nodejs-java/shape-effective-properties/): a API retorna valores calculados que consideram estilos de tema, layout e configurações locais, simplificando a análise de formatação.