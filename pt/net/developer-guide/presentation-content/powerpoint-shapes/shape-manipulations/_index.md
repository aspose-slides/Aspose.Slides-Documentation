---
title: Gerenciar Formas de Apresentação em .NET
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/net/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de apresentação
- Forma no slide
- Localizar forma
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
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a criar, editar e otimizar formas no Aspose.Slides para .NET e oferecer apresentações PowerPoint de alto desempenho."
---
## **Visão geral**

Este artigo explica como trabalhar com formas em apresentações usando Aspose.Slides. Ele mostra como localizar uma forma em um slide, cloná‑la, removê‑la, ocultá‑la, alterar sua ordem, obter seu ID de forma Interop e definir texto alternativo para identificação e processamento posterior.

Também aborda como acessar formatos de layout para formas, renderizar uma forma como SVG, alinhar formas em um slide e usar propriedades de espelhamento horizontal e vertical. Além disso, o artigo inclui um breve FAQ sobre combinação de formas, ordem de empilhamento e bloqueio de formas.

## **Localizar uma forma em um slide**
Este tópico descreve uma técnica simples para facilitar a localização de uma forma específica em um slide sem usar seu Id interno. É importante saber que os arquivos de apresentação do PowerPoint não possuem nenhum meio de identificar formas em um slide, exceto um Id interno único. Parece ser difícil para os desenvolvedores localizar uma forma usando seu Id interno único. Todas as formas adicionadas aos slides têm algum Texto Alternativo. Sugerimos que os desenvolvedores usem texto alternativo para encontrar uma forma específica. Você pode usar o MS PowerPoint para definir o texto alternativo para objetos que planeja alterar no futuro.

Depois de definir o texto alternativo da forma desejada, você pode abrir essa apresentação usando Aspose.Slides for .NET e percorrer todas as formas adicionadas a um slide. Em cada iteração, você pode verificar o texto alternativo da forma; a forma com o texto alternativo correspondente será a forma necessária. Para demonstrar essa técnica de forma mais clara, criamos um método, [FindShape](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/findshape/#findshape_1) que faz a busca de uma forma específica em um slide e simplesmente retorna essa forma.

```c#
public static void Run()
{
    // Instanciar uma classe Presentation que representa o arquivo de apresentação
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Texto alternativo da forma a ser encontrada
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Implementação do método para encontrar uma forma em um slide usando seu texto alternativo
public static IShape FindShape(ISlide slide, string alttext)
{
    // Iterando por todas as formas dentro do slide
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Se o texto alternativo do slide corresponder ao requerido então
        // Retornar a forma
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Clonar uma forma**
Para clonar uma forma em um slide usando Aspose.Slides for .NET:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse a coleção de formas do slide de origem.
1. Adicione um novo slide à apresentação.
1. Clone as formas da coleção de formas do slide de origem para o novo slide.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

```c#
// Instanciar a classe Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Gravar o arquivo PPTX no disco
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Remover uma forma**
Aspose.Slides for .NET permite que os desenvolvedores removam qualquer forma. Para remover a forma de um slide, siga os passos abaixo:

1. Crie uma instância da classe `Presentation`.
1. Acesse o primeiro slide.
1. Encontre a forma com o TextoAlternativo específico.
1. Remova a forma.
1. Salve o arquivo no disco.

```c#
// Criar objeto Presentation
Presentation pres = new Presentation();

// Obter o primeiro slide
ISlide sld = pres.Slides[0];

// Adicionar autoshape do tipo retângulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Salvar a apresentação no disco
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **Ocultar uma forma**
Aspose.Slides for .NET permite que os desenvolvedores ocultem qualquer forma. Para ocultar a forma de um slide, siga os passos abaixo:

1. Crie uma instância da classe `Presentation`.
1. Acesse o primeiro slide.
1. Encontre a forma com o TextoAlternativo específico.
1. Oculte a forma.
1. Salve o arquivo no disco.

```c#
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();

// Obter o primeiro slide
ISlide sld = pres.Slides[0];

// Adicionar autoshape do tipo retângulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Salvar a apresentação no disco
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **Alterar a ordem das formas**
Aspose.Slides for .NET permite que os desenvolvedores reorganizem as formas. Reordenar a forma especifica qual forma está à frente ou atrás. Para reordenar as formas de um slide, siga os passos abaixo:

1. Crie uma instância da classe `Presentation`.
1. Acesse o primeiro slide.
1. Adicione uma forma.
1. Adicione algum texto ao quadro de texto da forma.
1. Adicione outra forma com as mesmas coordenadas.
1. Reordene as formas.
1. Salve o arquivo no disco.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Obter o ID da forma Interop**
Aspose.Slides for .NET permite que os desenvolvedores obtenham um identificador único de forma no escopo do slide, em contraste com a propriedade UniqueId, que fornece um identificador único no escopo da apresentação. A propriedade OfficeInteropShapeId foi adicionada às interfaces IShape e à classe Shape. O valor retornado pela propriedade OfficeInteropShapeId corresponde ao valor do Id do objeto Microsoft.Office.Interop.PowerPoint.Shape. Abaixo está um exemplo de código.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Obtendo o identificador único de forma no escopo do slide
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **Definir texto alternativo para uma forma**
Aspose.Slides for .NET permite que os desenvolvedores definam AlternateText de qualquer forma. 
Formas em uma apresentação podem ser distinguidas pelo TextoAlternativo ou pela propriedade Nome da Forma. 
A propriedade AlternativeText pode ser lida ou definida usando Aspose.Slides assim como o Microsoft PowerPoint. 
Usando essa propriedade, você pode marcar uma forma e executar diferentes operações, como remover, ocultar ou reordenar formas em um slide.
Para definir o AlternateText de uma forma, siga os passos abaixo:

1. Crie uma instância da classe `Presentation`.
1. Acesse o primeiro slide.
1. Adicione qualquer forma ao slide.
1. Execute alguma operação com a forma recém‑adicionada.
1. Percorra as formas para encontrar uma forma.
1. Defina o TextoAlternativo.
1. Salve o arquivo no disco.

```c#
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();

// Obter o primeiro slide
ISlide sld = pres.Slides[0];

// Adicionar autoshape do tipo retângulo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Salvar a apresentação no disco
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Acessar formatos de layout para uma forma**
Aspose.Slides for .NET fornece uma API simples para acessar formatos de layout de uma forma. Este artigo demonstra como acessar esses formatos.

Abaixo está um exemplo de código.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Renderizar uma forma como SVG**
Agora o Aspose.Slides for .NET oferece suporte à renderização de uma forma como SVG. O método WriteAsSvg (e suas sobrecargas) foi adicionado à classe Shape e à interface IShape. Esse método permite salvar o conteúdo da forma como um arquivo SVG. O trecho de código abaixo mostra como exportar a forma de um slide para um arquivo SVG.

```c#
public static void Run()
{
    string outSvgFileName = "SingleShape.svg";
    using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
    {
        using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
        {
            pres.Slides[0].Shapes[0].WriteAsSvg(stream);
        }
    }
}
```

## **Alinhar uma forma**

Por meio do método sobrecarregado [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/methods/alignshapes/index), você pode 

* alinhar formas em relação às margens de um slide. Veja o Exemplo 1. 
* alinhar formas em relação umas às outras. Veja o Exemplo 2. 

A enumeração [ShapesAlignmentType](https://reference.aspose.com/slides/pt/net/aspose.slides/shapesalignmenttype) define as opções de alinhamento disponíveis.

**Exemplo 1**

Este código C# mostra como alinhar as formas com índices 1, 2 e 4 ao longo da borda superior de um slide:
O código‑fonte abaixo alinha as formas com índices 1, 2 e 4 ao longo da borda superior do slide. 

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Exemplo 2**

Este código C# mostra como alinhar uma coleção inteira de formas em relação à forma inferior da coleção:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Propriedades de espelhamento**

No Aspose.Slides, a classe [ShapeFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/shapeframe/) fornece controle sobre o espelhamento horizontal e vertical de formas por meio de suas propriedades `FlipH` e `FlipV`. Ambas as propriedades são do tipo [NullableBool](https://reference.aspose.com/slides/pt/net/aspose.slides/nullablebool/), permitindo valores `True` para indicar espelhamento, `False` para nenhum espelhamento ou `NotDefined` para usar o comportamento padrão. Esses valores são acessíveis a partir do [Frame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/frame/) de uma forma. 

Para modificar as configurações de espelhamento, uma nova instância de [ShapeFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/shapeframe/) é construída com a posição e o tamanho atuais da forma, os valores desejados para `FlipH` e `FlipV` e o ângulo de rotação. Atribuir essa instância ao [Frame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/frame/) da forma e salvar a apresentação aplica as transformações de espelhamento e as grava no arquivo de saída.

Suponha que tenhamos um arquivo sample.pptx em que o primeiro slide contém uma única forma com configurações de espelhamento padrão, como mostrado abaixo.

![The shape to be flipped](shape_to_be_flipped.png)

O exemplo de código a seguir obtém as propriedades de espelhamento atuais da forma e as inverte horizontalmente e verticalmente.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Recuperar a propriedade de espelhamento horizontal da forma.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Recuperar a propriedade de espelhamento vertical da forma.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Espelhar horizontalmente.
    NullableBool flipV = NullableBool.True; // Espelhar verticalmente.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

O resultado:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Posso combinar formas (unir/intersectar/subtrair) em um slide como em um editor de desktop?**

Não existe uma API integrada de operações booleanas. Você pode aproximar isso construindo o contorno desejado manualmente — por exemplo, calculando a geometria resultante (via [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath/)) e criando uma nova forma com esse contorno, opcionalmente removendo as originais.

**Como posso controlar a ordem de empilhamento (z‑order) para que uma forma fique sempre “no topo”?**

Altere a ordem de inserção/movimento dentro da coleção de [shapes](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslide/shapes/) do slide. Para resultados previsíveis, finalize o z‑order após todas as demais modificações do slide.

**Posso “travar” uma forma para impedir que usuários a editem no PowerPoint?**

Sim. Defina as [flags de proteção ao nível da forma](/slides/pt/net/applying-protection-to-presentation/) (por exemplo, bloquear seleção, movimentação, redimensionamento, edição de texto). Se necessário, reflita as restrições no mestre ou layout. Observe que isso é proteção a nível de UI, não um recurso de segurança; para proteção mais robusta, combine com restrições ao nível do arquivo, como recomendações de somente‑leitura ou senhas ([read‑only recommendations or passwords](/slides/pt/net/password-protected-presentation/)).