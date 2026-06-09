---
title: Adicionar Formas de Linha a Apresentações em JavaScript
linktitle: Linha
type: docs
weight: 50
url: /pt/nodejs-java/line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações PowerPoint com JavaScript e Aspose.Slides para Node.js. Descubra propriedades, métodos e exemplos."
---
## **Visão geral**

Aspose.Slides permite adicionar formas de linha aos slides do PowerPoint programaticamente. Este artigo mostra como criar uma linha simples e como personalizar uma linha para que apareça como uma seta.

Você aprenderá como adicionar uma forma de linha a um slide, ajustar sua aparência visual e salvar a apresentação atualizada. Os exemplos focam em configurações práticas de formatação de linha, como estilo, espessura, padrão de traço, opções de ponta de seta e cor de preenchimento.

## **Criar linha simples**

Para adicionar uma linha simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```javascript
// Instanciar a classe PresentationEx que representa o arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar um AutoShape do tipo linha
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Gravar o PPTX no disco
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Criar linha em forma de seta**

Aspose.Slides for Node.js via Java também permite que os desenvolvedores configurem algumas propriedades da linha para torná‑la mais atraente. Vamos tentar configurar algumas propriedades de uma linha para que ela se pareça com uma seta. Siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection).
- Defina o [Line Style](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LineStyle) para um dos estilos oferecidos pelo Aspose.Slides for Node.js via Java.
- Defina a Largura da linha.
- Defina o [Dash Style](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LineDashStyle) da linha para um dos estilos oferecidos pelo Aspose.Slides for Node.js via Java.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LineArrowheadStyle) e o [Length](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LineArrowheadLength) do ponto inicial da linha.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LineArrowheadStyle) e o [Length](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LineArrowheadLength) do ponto final da linha.
- Grave a apresentação modificada como um arquivo PPTX.

```javascript
// Instanciar a classe PresentationEx que representa o arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar um AutoShape do tipo linha
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Aplicar alguma formatação na linha
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Gravar o PPTX no disco
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso converter uma linha regular em um conector para que ela “encaixe” em formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) do tipo [Line](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapetype/)) não se transforma automaticamente em um conector. Para fazer com que ela encaixe em formas, use o tipo dedicado [Connector](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/connector/) e as [APIs correspondentes](/slides/pt/nodejs-java/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha forem herdadas do tema e for difícil determinar os valores finais?**

[Leia as propriedades efetivas](/slides/pt/nodejs-java/shape-effective-properties/) através das classes `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — elas já consideram herança e estilos de tema.

**Posso bloquear uma linha contra edição (movimento, redimensionamento)?**

Sim. As formas fornecem [objetos de bloqueio](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/getautoshapelock/) que permitem impedir operações de edição.