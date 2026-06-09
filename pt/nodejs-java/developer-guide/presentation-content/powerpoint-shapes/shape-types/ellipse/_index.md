---
title: Adicionar Elipses a Apresentações em JavaScript
linktitle: Elipse
type: docs
weight: 30
url: /pt/nodejs-java/ellipse/
keywords:
- elipse
- forma
- adicionar elipse
- criar elipse
- desenhar elipse
- elipse formatada
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a criar, formatar e manipular formas de elipse no Aspose.Slides para Node.js em apresentações PPT e PPTX — exemplos de código JavaScript incluídos."
---
## **Visão geral**

Este artigo mostra como adicionar formas de elipse aos slides do PowerPoint usando Aspose.Slides. Ele abrange a criação de uma elipse simples, a criação de uma elipse formatada e a gravação da apresentação atualizada como um arquivo PPTX. Também aborda questões relacionadas, como trabalhar com a posição e o tamanho da elipse, controlar a ordem de empilhamento e aplicar efeitos de animação.

## **Criar Elipse**
Para adicionar uma elipse simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Ellipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse ao primeiro slide

```javascript
// Instanciar a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar AutoShape do tipo elipse
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Gravar o arquivo PPTX no disco
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Criar Elipse Formatada**
Para adicionar uma elipse melhor formatada a um slide, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Ellipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).
- Defina o Tipo de Preenchimento da Elipse como Sólido.
- Defina a Cor da Elipse usando a propriedade SolidFillColor.Color exposta pelo objeto [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FillFormat) associado ao objeto [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape).
- Defina a Cor das linhas da Elipse.
- Defina a Largura das linhas da Elipse.
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse formatada ao primeiro slide da apresentação.

```javascript
// Instanciar a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar AutoShape do tipo elipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Aplicar alguma formatação à forma de elipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Aplicar alguma formatação à linha da elipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Gravar o arquivo PPTX no disco
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **FAQ**

**Como definir a posição e o tamanho exatos de uma elipse em relação às unidades do slide?**

As coordenadas e os tamanhos são normalmente especificados **em pontos**. Para resultados previsíveis, baseie seus cálculos no tamanho do slide e converta milímetros ou polegadas necessários para pontos antes de atribuir os valores.

**Como posso posicionar uma elipse acima ou abaixo de outros objetos (controlar ordem de empilhamento)?**

Ajuste a ordem de desenho do objeto trazendo‑o para a frente ou enviando‑o para trás. Isso permite que a elipse sobreponha outros objetos ou revele os que estão abaixo dela.

**Como animar a aparição ou ênfase de uma elipse?**

[Aplicar](/slides/pt/nodejs-java/shape-animation/) efeitos de entrada, ênfase ou saída à forma, e configure gatilhos e temporização para orquestrar quando e como a animação será executada.