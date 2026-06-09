---
title: Adicionar Retângulos a Apresentações em Java
linktitle: Retângulo
type: docs
weight: 80
url: /pt/java/rectangle/
keywords:
- adicionar retângulo
- criar retângulo
- forma de retângulo
- retângulo simples
- retângulo formatado
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Impulsione suas apresentações PowerPoint adicionando retângulos com Aspose.Slides para Java — projete e modifique formas programaticamente com facilidade."
---
## **Visão geral**

Este artigo mostra como adicionar formas de retângulo aos slides do PowerPoint usando Aspose.Slides. Ele aborda a criação de um retângulo simples, a criação de um retângulo formatado e a gravação da apresentação atualizada como um arquivo PPTX.

Você também verá como aplicar formatação básica ao retângulo, como cor de preenchimento sólido, cor da linha e largura da linha. Além disso, o FAQ do artigo aponta para tarefas relacionadas ao retângulo, incluindo cantos arredondados, preenchimentos de imagem, efeitos visuais, hiperlinks, bloqueios de forma, opções de exportação e propriedades efetivas.

## **Adicionar um Retângulo a um Slide**
Para adicionar um retângulo simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape) do tipo Rectangle usando o método [addAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um retângulo simples ao primeiro slide da apresentação.

```java
// Instanciar a classe Prseetation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar AutoShape do tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Gravar o arquivo PPTX no disco
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar um Retângulo Formatado a um Slide**
Para adicionar um retângulo formatado a um slide, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape) do tipo Rectangle usando o método [addAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection).
- Defina o [Fill Type](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FillType) do retângulo como Solid.
- Defina a Cor do Retângulo usando [SolidFillColor.setColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) exposto pelo objeto [IFillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IFillFormat) associado ao objeto [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape).
- Defina a Cor das linhas do Retângulo.
- Defina a Largura das linhas do Retângulo.
- Grave a apresentação modificada como arquivo PPTX.

As etapas acima são implementadas no exemplo abaixo.

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar AutoShape do tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Aplicar alguma formatação à forma elipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Aplicar alguma formatação à linha da elipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Gravar o arquivo PPTX no disco
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Como adicionar um retângulo com cantos arredondados?**

Use o [shape type](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapetype/) de canto arredondado e ajuste o raio do canto nas propriedades da forma; o arredondamento também pode ser aplicado por canto via ajustes de geometria.

**Como preencho um retângulo com uma imagem (textura)?**

Selecione o [fill type](https://reference.aspose.com/slides/pt/java/com.aspose.slides/filltype/) de imagem, forneça a origem da imagem e configure os modos de [stretching/tiling](https://reference.aspose.com/slides/pt/java/com.aspose.slides/picturefillmode/).

**Um retângulo pode ter sombra e brilho?**

Sim. [Outer/inner shadow, glow, and soft edges](/slides/pt/java/shape-effect/) estão disponíveis com parâmetros ajustáveis.

**Posso transformar um retângulo em um botão com hiperlink?**

Sim. [Assign a hyperlink](/slides/pt/java/manage-hyperlinks/) ao clique da forma (ir para um slide, arquivo, endereço web ou e‑mail).

**Como posso proteger um retângulo contra movimentação e alterações?**

[Use shape locks](/slides/pt/java/applying-protection-to-presentation/): você pode impedir movimentação, redimensionamento, seleção ou edição de texto para preservar o layout.

**Posso converter um retângulo em imagem raster ou SVG?**

Sim. Você pode [render the shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getImage-int-float-float-) para uma imagem com tamanho/escala especificados ou [exportá‑la como SVG](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para uso vetorial.

**Como obter rapidamente as propriedades reais (efetivas) de um retângulo considerando tema e herança?**

[Use the shape’s effective properties](/slides/pt/java/shape-effective-properties/): a API retorna valores computados que levam em conta estilos de tema, layout e configurações locais, simplificando a análise de formatação.