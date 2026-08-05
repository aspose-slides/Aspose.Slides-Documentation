---
title: Adicionar formas de linha a apresentações no Android
linktitle: Linha
type: docs
weight: 50
url: /pt/androidjava/line/
keywords:
- linha
- criar linha
- adicionar linha
- linha simples
- configurar linha
- personalizar linha
- estilo de traço
- ponta de seta
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações PowerPoint com Aspose.Slides para Android. Descubra propriedades, métodos e exemplos em Java."
---
## **Visão geral**

Aspose.Slides permite adicionar formas de linha a slides PowerPoint programaticamente. Este artigo mostra como criar uma linha simples e como personalizar uma linha para que apareça como uma seta.

Você aprenderá como adicionar uma forma de linha a um slide, ajustar sua aparência visual e salvar a apresentação atualizada. Os exemplos se concentram em configurações práticas de formatação de linha, como estilo, largura, padrão de traço, opções de ponta de seta e cor de preenchimento.

## **Criar uma Linha Simples**

Para adicionar uma linha simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```java
// Instanciar a classe PresentationEx que representa o arquivo PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Adicionar um AutoShape do tipo linha
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Gravar o PPTX no disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Criar uma Linha em Forma de Seta**

Aspose.Slides for Android via Java também permite que os desenvolvedores configurem algumas propriedades da linha para torná‑la mais atraente. Vamos tentar configurar algumas propriedades de uma linha para que ela se pareça com uma seta. Siga as etapas abaixo para isso:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).
- Defina o [Line Style](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LineStyle) para um dos estilos oferecidos pelo Aspose.Slides for Android via Java.
- Defina a Width da linha.
- Defina o [Dash Style](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LineDashStyle) da linha para um dos estilos oferecidos pelo Aspose.Slides for Android via Java.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LineArrowheadStyle) e [Length](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LineArrowheadLength) do ponto inicial da linha.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LineArrowheadStyle) e [Length](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LineArrowheadLength) do ponto final da linha.
- Grave a apresentação modificada como um arquivo PPTX.

```java
// Instanciar a classe PresentationEx que representa o arquivo PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar um AutoShape do tipo linha
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplicar alguma formatação na linha
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Gravar o PPTX no disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Posso converter uma linha regular em um conector para que ela “encaixe” nas formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/) do tipo [Line](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapetype/)) não se torna automaticamente um conector. Para fazer com que ela encaixe nas formas, use o tipo dedicado [Connector](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/connector/) e as [corresponding APIs](/slides/pt/androidjava/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha forem herdadas do tema e for difícil determinar os valores finais?**

[Leia as propriedades efetivas](/slides/pt/androidjava/shape-effective-properties/) através das interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — essas já consideram herança e estilos de tema.

**Posso bloquear uma linha contra edição (movimentação, redimensionamento)?**

Sim. As formas fornecem [lock objects](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) que permitem impedir operações de edição.