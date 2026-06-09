---
title: Adicionar Elipses a Apresentações no Android
linktitle: Elipse
type: docs
weight: 30
url: /pt/androidjava/ellipse/
keywords:
- elipse
- forma
- adicionar elipse
- criar elipse
- desenhar elipse
- elipse formatada
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Saiba como criar, formatar e manipular formas de elipse no Aspose.Slides para Android em apresentações PPT e PPTX — exemplos de código Java incluídos."
---
## **Visão geral**

Este artigo mostra como adicionar formas de elipse aos slides do PowerPoint usando Aspose.Slides. Ele abrange a criação de uma elipse simples, a criação de uma elipse formatada e a gravação da apresentação atualizada como um arquivo PPTX. Também aborda questões relacionadas, como trabalhar com a posição e o tamanho da elipse, controlar a ordem de empilhamento e aplicar efeitos de animação.

## **Criar uma Elipse**
Para adicionar uma elipse simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Elipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse ao primeiro slide

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Adicionar AutoShape do tipo elipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Gravar o arquivo PPTX no disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Criar uma Elipse Formatada**
Para adicionar uma elipse melhor formatada a um slide, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Elipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).
- Defina o Tipo de Preenchimento da Elipse como Sólido.
- Defina a Cor da Elipse usando a propriedade SolidFillColor.Color exposta pelo objeto [FillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IFillFormat) associado ao objeto [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShape).
- Defina a Cor das linhas da Elipse.
- Defina a Largura das linhas da Elipse.
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse formatada ao primeiro slide da apresentação.

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar AutoShape do tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Aplicar alguma formatação à forma de elipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Aplicar alguma formatação à linha da elipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Gravar o arquivo PPTX no disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Como definir a posição exata e o tamanho de uma elipse em relação às unidades do slide?**

As coordenadas e tamanhos são tipicamente especificados **em pontos**. Para resultados previsíveis, baseie seus cálculos no tamanho do slide e converta os milímetros ou polegadas necessários para pontos antes de atribuir os valores.

**Como colocar uma elipse acima ou abaixo de outros objetos (controlar a ordem de empilhamento)?**

Ajuste a ordem de desenho do objeto trazendo-o para frente ou enviando-o para trás. Isso permite que a elipse sobreponha outros objetos ou revele os que estão abaixo dela.

**Como animar a aparição ou ênfase de uma elipse?**

[Apply](/slides/pt/androidjava/shape-animation/) efeitos de entrada, ênfase ou saída à forma e configure disparadores e temporizações para orquestrar quando e como a animação será reproduzida.