---
title: Adicionar formas de linha às apresentações em Java
linktitle: Linha
type: docs
weight: 50
url: /pt/java/Line/
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
- Java
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações PowerPoint com Aspose.Slides para Java. Descubra propriedades, métodos e exemplos."
---
## **Visão geral**

Aspose.Slides permite que você adicione formas de linha aos slides do PowerPoint programaticamente. Este artigo mostra como criar uma linha simples e como personalizar uma linha para que ela apareça como uma seta.

Você aprenderá como adicionar uma forma de linha a um slide, ajustar sua aparência visual e salvar a apresentação atualizada. Os exemplos concentram‑se em configurações práticas de formatação de linha, como estilo, largura, padrão de traço, opções de ponta de seta e cor de preenchimento.

## **Criar uma linha simples**

Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection).
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

## **Criar uma linha em forma de seta**

Aspose.Slides for Java também permite que os desenvolvedores configurem algumas propriedades da linha para torná‑la mais atraente. Vamos tentar configurar algumas propriedades da linha para que ela se pareça com uma seta. Siga os passos abaixo para isso:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [IShapeCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection).
- Defina o [Line Style](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LineStyle) para um dos estilos oferecidos pelo Aspose.Slides for Java.
- Defina a largura da linha.
- Defina o [Dash Style](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LineDashStyle) da linha para um dos estilos oferecidos pelo Aspose.Slides for Java.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LineArrowheadStyle) e o [Length](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LineArrowheadLength) do ponto inicial da linha.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LineArrowheadStyle) e o [Length](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LineArrowheadLength) do ponto final da linha.
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

## **FAQ**

**Posso converter uma linha regular em um conector para que ela “encaixe” nas formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/) do tipo [Line](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapetype/)) não se torna automaticamente um conector. Para que ela encaixe nas formas, use o tipo dedicado [Connector](https://reference.aspose.com/slides/pt/java/com.aspose.slides/connector/) e as [APIs correspondentes](/slides/pt/java/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha são herdadas do tema e é difícil determinar os valores finais?**

Consulte as [Leia as propriedades efetivas](/slides/pt/java/shape-effective-properties/) através das interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilinefillformateffectivedata/) — essas já consideram a herança e os estilos do tema.

**Posso bloquear uma linha contra edição (movimento, redimensionamento)?**

Sim. As formas fornecem [objetos de bloqueio](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/#getAutoShapeLock--) que permitem [impedir operações de edição](/slides/pt/java/applying-protection-to-presentation/).