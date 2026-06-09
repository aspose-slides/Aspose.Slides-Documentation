---
title: Gerenciar Formas de Apresentação em JavaScript
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/nodejs-java/shape-manipulations/
keywords:
- Forma PowerPoint
- forma de apresentação
- forma no slide
- encontrar forma
- clonar forma
- remover forma
- ocultar forma
- alterar ordem da forma
- obter ID da forma Interop
- texto alternativo da forma
- formatos de layout da forma
- forma como SVG
- forma para SVG
- alinhar forma
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a criar, editar e otimizar formas usando JavaScript e Aspose.Slides for Node.js via Java e entregar apresentações PowerPoint de alto desempenho."
---
## **Visão Geral**

Este artigo explica como trabalhar com formas em apresentações usando Aspose.Slides. Ele mostra como encontrar uma forma em um slide, cloná‑la, removê‑la, ocultá‑la, alterar sua ordem, obter seu ID de forma Interop e definir texto alternativo para identificação e processamento posterior.

Também aborda como acessar formatos de layout para formas, renderizar uma forma como SVG, alinhar formas em um slide e usar propriedades de espelhamento horizontal e vertical. Além disso, o artigo inclui um breve FAQ sobre combinação de formas, ordem de empilhamento e bloqueio de forma.

## **Encontrar Forma no Slide**
Este tópico descreve uma técnica simples para facilitar que desenvolvedores encontrem uma forma específica em um slide sem usar seu Id interno. É importante saber que arquivos de apresentação do PowerPoint não possuem nenhum modo de identificar formas em um slide exceto por um Id interno único. Parece ser difícil para desenvolvedores encontrar uma forma usando esse Id interno único. Todas as formas adicionadas aos slides têm algum Texto Alternativo. Sugerimos que os desenvolvedores usem texto alternativo para encontrar uma forma específica. Você pode usar o MS PowerPoint para definir o texto alternativo para objetos que planeja alterar no futuro.

Depois de definir o texto alternativo da forma desejada, você pode abrir essa apresentação usando Aspose.Slides for Node.js via Java e iterar por todas as formas adicionadas a um slide. Em cada iteração, você pode verificar o texto alternativo da forma e a forma com o texto alternativo correspondente será a forma requerida. Para demonstrar essa técnica de forma mais clara, criamos um método, [findShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) que faz o truque de encontrar uma forma específica em um slide e então simplesmente retorna essa forma.

```javascript
// Instancie uma classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Texto alternativo da forma a ser encontrada
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Clonar Forma**
Para clonar uma forma para um slide usando Aspose.Slides for Node.js via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse a coleção de formas do slide de origem.
1. Adicione um novo slide à apresentação.
1. Clone as formas da coleção de formas do slide de origem para o novo slide.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

```javascript
// Instanciar a classe Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Gravar o arquivo PPTX no disco
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remover Forma**
Aspose.Slides for Node.js via Java permite que desenvolvedores removam qualquer forma. Para remover a forma de um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Encontre a forma com um TextoAlternativo específico.
1. Remova a forma.
1. Salve o arquivo em disco.

```javascript
// Criar objeto Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar autoshape do tipo retângulo
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Salvar a apresentação no disco
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ocultar Forma**
Aspose.Slides for Node.js via Java permite que desenvolvedores ocultem qualquer forma. Para ocultar a forma de um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Encontre a forma com um TextoAlternativo específico.
1. Oculte a forma.
1. Salve o arquivo em disco.

```javascript
// Instanciar a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar autoshape do tipo retângulo
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Salvar a apresentação no disco
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterar Ordem das Formas**
Aspose.Slides for Node.js via Java permite que desenvolvedores reordenem as formas. Reordenar a forma especifica qual forma está à frente ou qual está atrás. Para reordenar as formas de um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione uma forma.
1. Adicione texto ao quadro de texto da forma.
1. Adicione outra forma com as mesmas coordenadas.
1. Reordene as formas.
1. Salve o arquivo em disco.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obter ID da Forma Interop**
Aspose.Slides for Node.js via Java permite que desenvolvedores obtenham um identificador único de forma no escopo do slide, em contraste com o método [getUniqueId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getUniqueId--) que permite obter um identificador único no escopo da apresentação. O método [getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) foi adicionado à classe [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape) e à classe [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape) respectivamente. O valor retornado por [getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) corresponde ao valor do Id do objeto Microsoft.Office.Interop.PowerPoint.Shape. A seguir, um exemplo de código é apresentado.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Obtendo o identificador único de forma no escopo do slide
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Texto Alternativo para Forma**
Aspose.Slides for Node.js via Java permite que desenvolvedores definam AlternateText de qualquer forma. Formas em uma apresentação podem ser diferenciadas pelo método [AlternativeText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) ou [Shape Name](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). Os métodos [setAlternativeText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) e [getAlternativeText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getAlternativeText--) podem ser lidos ou definidos usando Aspose.Slides assim como o Microsoft PowerPoint. Usando este método, você pode marcar uma forma e executar diferentes operações, como remover uma forma, ocultar uma forma ou reordenar formas em um slide. Para definir o AlternateText de uma forma, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione qualquer forma ao slide.
1. Execute alguma operação com a forma recém‑adicionada.
1. Percorra as formas para encontrar uma forma.
1. Defina o AlternativeText.
1. Salve o arquivo em disco.

```javascript
// Instanciar a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar autoshape do tipo retângulo
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Salvar a apresentação no disco
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar Formatos de Layout para Forma**
Aspose.Slides for Node.js via Java fornece uma API simples para acessar formatos de layout de uma forma. Este artigo demonstra como você pode acessar formatos de layout.

Abaixo, um exemplo de código é apresentado.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Renderizar Forma como SVG**
Agora o Aspose.Slides for Node.js via Java suporta renderização de uma forma como SVG. O método [writeAsSvg](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (e sua sobrecarga) foi adicionado à classe [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape) e à classe [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape). Este método permite salvar o conteúdo da forma como um arquivo SVG. O trecho de código abaixo mostra como exportar a forma de um slide para um arquivo SVG.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinhamento de Formas**
Aspose.Slides permite alinhar formas tanto em relação às margens do slide quanto em relação umas às outras. Para esse fim, o método sobrecarregado [SlidesUtil.alignShape()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) foi adicionado. A enumeração [ShapesAlignmentType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapesAlignmentType) define as opções de alinhamento possíveis.

**Exemplo 1**

O código fonte abaixo alinha as formas com índices 1, 2 e 4 ao longo da borda superior do slide.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Exemplo 2**

O exemplo abaixo mostra como alinhar toda a coleção de formas em relação à forma mais inferior da coleção.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Propriedades de Espelhamento**

No Aspose.Slides, a classe [ShapeFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapeframe/) fornece controle sobre o espelhamento horizontal e vertical das formas por meio de suas propriedades `flipH` e `flipV`. Ambas as propriedades são do tipo `byte`, permitindo valores `1` para indicar espelhamento, `0` para nenhum espelhamento ou `-1` para usar o comportamento padrão. Esses valores são acessíveis a partir do [Frame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getFrame) de uma forma.

Para modificar as configurações de espelhamento, uma nova instância de [ShapeFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapeframe/) é construído com a posição e tamanho atuais da forma, os valores desejados para `flipH` e `flipV` e o ângulo de rotação. Atribuir essa instância ao [Frame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getFrame) da forma e salvar a apresentação aplica as transformações de espelhamento e as grava no arquivo de saída.

Suponha que tenhamos um arquivo sample.pptx no qual o primeiro slide contém uma única forma com configurações de espelhamento padrão, conforme mostrado abaixo.

![The shape to be flipped](shape_to_be_flipped.png)

O exemplo de código a seguir recupera as propriedades de espelhamento atuais da forma e a espelha tanto horizontal quanto verticalmente.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Recuperar a propriedade de espelhamento horizontal da forma.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Recuperar a propriedade de espelhamento vertical da forma.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Espelhar horizontalmente.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Espelhar verticalmente.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Posso combinar formas (união/interseção/subtração) em um slide como em um editor desktop?**

Não há uma API de operação booleana incorporada. Você pode aproximar isso construindo o contorno desejado manualmente — por exemplo, calculando a geometria resultante (via [GeometryPath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/geometrypath/)) e criando uma nova forma com esse contorno, opcionalmente removendo as originais.

**Como posso controlar a ordem de empilhamento (z‑order) para que uma forma permaneça sempre “no topo”?**

Altere a ordem de inserção/movimento dentro da coleção de [shapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getShapes) do slide. Para resultados previsíveis, finalize o z‑order após todas as demais modificações do slide.

**Posso "bloquear" uma forma para impedir que usuários a editem no PowerPoint?**

Sim. Defina flags de proteção ao nível da forma (por exemplo, bloquear seleção, movimentação, redimensionamento, edição de texto). Se necessário, espelhe as restrições no mestre ou no layout. Observe que isso é proteção no nível da UI, não um recurso de segurança; para proteção mais forte, combine com restrições ao nível do arquivo, como [recomendações de leitura‑somente ou senhas](/slides/pt/nodejs-java/password-protected-presentation/).