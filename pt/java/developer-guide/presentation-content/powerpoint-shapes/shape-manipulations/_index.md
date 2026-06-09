---
title: Gerenciar Formas de Apresentação em Java
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID da forma Interop
- Texto alternativo da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- PowerPoint
- Apresentação
- Java
- Aspose.Slides
description: "Aprenda a criar, editar e otimizar formas no Aspose.Slides for Java e a gerar apresentações PowerPoint de alto desempenho."
---
## **Visão geral**

Este artigo explica como trabalhar com formas em apresentações usando Aspose.Slides. Ele mostra como encontrar uma forma em um slide, cloná‑la, removê‑la, ocultá‑la, alterar sua ordem, obter seu ID de forma Interop e definir texto alternativo para identificação e processamento posterior.

Também aborda como acessar formatos de layout para formas, renderizar uma forma como SVG, alinhar formas em um slide e usar propriedades de espelhamento horizontal e vertical. Além disso, o artigo inclui um FAQ curto sobre combinação de formas, ordem de empilhamento e bloqueio de forma.

## **Encontrar uma forma em um slide**
Este tópico descreve uma técnica simples para facilitar aos desenvolvedores a localização de uma forma específica em um slide sem usar seu Id interno. É importante saber que arquivos de apresentação do PowerPoint não têm nenhum meio de identificar formas em um slide, exceto um Id interno único. Parece ser difícil para os desenvolvedores encontrar uma forma usando seu Id interno único. Todas as formas adicionadas aos slides têm algum Texto Alternativo. Sugerimos que os desenvolvedores usem texto alternativo para encontrar uma forma específica. Você pode usar o MS PowerPoint para definir o texto alternativo para objetos que planeja alterar no futuro.

Depois de definir o texto alternativo de qualquer forma desejada, você pode abrir a apresentação usando Aspose.Slides for Java e iterar por todas as formas adicionadas a um slide. Em cada iteração, verifique o texto alternativo da forma; a forma com o texto alternativo correspondente será a forma que você precisa. Para demonstrar essa técnica de forma mais clara, criamos o método [findShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) que realiza a busca de uma forma específica em um slide e simplesmente retorna essa forma.

```java
// Instanciar uma classe Presentation que representa o arquivo de apresentação
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Texto alternativo da forma a ser encontrada
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Implementação do método para encontrar uma forma em um slide usando seu texto alternativo
public static IShape findShape(ISlide slide, String alttext)
{
    // Iterando por todas as formas dentro do slide
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Se o texto alternativo da forma coincide com o solicitado então
        // Retornar a forma
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Clonar uma forma**
Para clonar uma forma em um slide usando Aspose.Slides for Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse a coleção de formas do slide de origem.
1. Adicione um novo slide à apresentação.
1. Clone as formas da coleção de formas do slide de origem para o novo slide.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Gravar o arquivo PPTX no disco
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remover uma forma**
Aspose.Slides for Java permite que os desenvolvedores removam qualquer forma. Para remover a forma de um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Encontre a forma com o Texto Alternativo específico.
1. Remova a forma.
1. Salve o arquivo no disco.

```java
// Criar objeto Presentation
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar autoshape do tipo retângulo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Salvar a apresentação no disco
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ocultar uma forma**
Aspose.Slides for Java permite que os desenvolvedores ocultem qualquer forma. Para ocultar a forma de um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Encontre a forma com o Texto Alternativo específico.
1. Oculte a forma.
1. Salve o arquivo no disco.

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar autoshape do tipo retângulo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Salvar a apresentação no disco
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alterar a ordem das formas**
Aspose.Slides for Java permite que os desenvolvedores reordenem as formas. Reordenar a forma especifica qual forma está na frente ou qual está no fundo. Para reordenar a forma em um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione uma forma.
1. Adicione algum texto na caixa de texto da forma.
1. Adicione outra forma com as mesmas coordenadas.
1. Reordene as formas.
1. Salve o arquivo no disco.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obter o ID da forma Interop**
Aspose.Slides for Java permite que os desenvolvedores obtenham um identificador único de forma no escopo do slide, em contraste com o método [getUniqueId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#getUniqueId--) que permite obter um identificador único no escopo da apresentação. O método [getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) foi adicionado às interfaces [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape) e à classe [Shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Shape). O valor retornado por [getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) corresponde ao valor do Id do objeto Microsoft.Office.Interop.PowerPoint.Shape. A seguir, um exemplo de código é apresentado.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtendo identificador único de forma no escopo do slide
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir texto alternativo para uma forma**
Aspose.Slides for Java permite que os desenvolvedores definam o AlternateText de qualquer forma. As formas em uma apresentação podem ser distinguidas pelo método [AlternativeText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ou [Shape Name](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#setName-java.lang.String-). Os métodos [setAlternativeText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) e [getAlternativeText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#getAlternativeText--) podem ser lidos ou definidos usando Aspose.Slides assim como o Microsoft PowerPoint. Usando este método, você pode marcar uma forma e executar diferentes operações, como remover uma forma, ocultar uma forma ou reordenar formas em um slide. Para definir o AlternateText de uma forma, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione qualquer forma ao slide.
1. Execute alguma operação com a forma recém‑adicionada.
1. Percorra as formas para encontrar uma forma.
1. Defina o AlternativeText.
1. Salve o arquivo no disco.

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar autoshape do tipo retângulo
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Salvar a apresentação no disco
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar formatos de layout para uma forma**
Aspose.Slides for Java fornece uma API simples para acessar formatos de layout para uma forma. Este artigo demonstra como acessar esses formatos.

Abaixo, um exemplo de código é apresentado.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Renderizar uma forma como SVG**
Agora o Aspose.Slides for Java oferece suporte à renderização de uma forma como SVG. O método [writeAsSvg](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (e sua sobrecarga) foi adicionado à classe [Shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Shape) e à interface [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape). Este método permite salvar o conteúdo da forma como um arquivo SVG. O trecho de código abaixo mostra como exportar a forma de um slide para um arquivo SVG.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinhar uma forma**
Aspose.Slides permite alinhar formas tanto em relação às margens do slide quanto em relação umas às outras. Para esse propósito, o método sobrecarregado [SlidesUtil.alignShape()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) foi adicionado. A enumeração [ShapesAlignmentType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapesAlignmentType) define as opções de alinhamento possíveis.

**Exemplo 1**

O código-fonte abaixo alinha as formas com índices 1, 2 e 4 ao longo da borda superior do slide.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Exemplo 2**

O exemplo abaixo mostra como alinhar toda a coleção de formas em relação à forma mais baixa da coleção.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Propriedades de espelhamento**

No Aspose.Slides, a classe [ShapeFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapeframe/) fornece controle sobre o espelhamento horizontal e vertical das formas por meio de suas propriedades `flipH` e `flipV`. Ambas as propriedades são do tipo `byte`, permitindo valores `1` para indicar espelhamento, `0` para nenhum espelhamento ou `-1` para usar o comportamento padrão. Esses valores são acessíveis a partir do [Frame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getFrame--) de uma forma.

Para modificar as configurações de espelhamento, cria‑se uma nova instância de [ShapeFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapeframe/) com a posição e tamanho atuais da forma, os valores desejados para `flipH` e `flipV` e o ângulo de rotação. Ao atribuir essa instância ao [Frame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getFrame--) da forma e salvar a apresentação, as transformações de espelhamento são aplicadas e gravadas no arquivo de saída.

Suponha que tenhamos um arquivo sample.pptx em que o primeiro slide contém uma única forma com configurações de espelhamento padrão, conforme mostrado abaixo.

![A forma a ser espelhada](shape_to_be_flipped.png)

O exemplo de código a seguir obtém as propriedades de espelhamento atuais da forma e a espelha tanto horizontal quanto verticalmente.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Recuperar a propriedade de espelhamento horizontal da forma.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Recuperar a propriedade de espelhamento vertical da forma.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Espelhar horizontalmente.
    byte flipV = NullableBool.True; // Espelhar horizontalmente.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma espelhada](flipped_shape.png)

## **FAQ**

**Posso combinar formas (união/interseção/subtração) em um slide como em um editor de desktop?**

Não existe uma API de operação booleana incorporada. Você pode aproximar isso construindo o contorno desejado manualmente — por exemplo, calculando a geometria resultante (via [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/geometrypath/)) e criando uma nova forma com esse contorno, opcionalmente removendo as originais.

**Como posso controlar a ordem de empilhamento (z‑order) para que uma forma permaneça sempre “no topo”?**

Altere a ordem de inserção/movimento dentro da coleção de [shapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslide/#getShapes--) do slide. Para resultados previsíveis, finalize o z‑order após todas as outras modificações do slide.

**Posso “travar” uma forma para impedir que usuários a editem no PowerPoint?**

Sim. Defina as [flags de proteção ao nível da forma](/slides/pt/java/applying-protection-to-presentation/) (por exemplo, bloquear seleção, movimentação, redimensionamento, edição de texto). Se necessário, reflita restrições no mestre ou layout. Observe que isso é proteção ao nível da UI, não um recurso de segurança; para proteção mais forte, combine com restrições ao nível do arquivo, como recomendações de somente‑leitura ou senhas ([read‑only recommendations or passwords](/slides/pt/java/password-protected-presentation/)).