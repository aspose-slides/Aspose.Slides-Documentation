---
title: Gerenciar Caixas de Texto em Apresentações no Android
linktitle: Gerenciar Caixa de Texto
type: docs
weight: 20
url: /pt/androidjava/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hiperlink
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java facilita a criação, edição e clonagem de caixas de texto em arquivos PowerPoint e OpenDocument, aprimorando a automação de suas apresentações."
---
## **Introdução**

Os textos em slides normalmente existem em caixas de texto ou formas. Portanto, para adicionar um texto a um slide, você precisa adicionar uma caixa de texto e então inserir algum texto dentro da caixa. Aspose.Slides for Android via Java fornece a interface [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAutoShape) que permite adicionar uma forma contendo texto.

{{% alert title="Info" color="info" %}}
Aspose.Slides também fornece a interface [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShape) que permite adicionar formas aos slides. No entanto, nem todas as formas adicionadas através da interface `IShape` podem conter texto. Mas as formas adicionadas através da interface [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAutoShape) podem conter texto.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Portanto, ao lidar com uma forma à qual você deseja adicionar texto, pode ser necessário verificar e confirmar que ela foi convertida através da interface `IAutoShape`. Só então você poderá trabalhar com [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrame), que é uma propriedade de `IAutoShape`. Veja a seção [Update Text](https://docs.aspose.com/slides/pt/androidjava/manage-textbox/#update-text) nesta página.
{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2. Obtenha uma referência para o primeiro slide na apresentação recém‑criada. 
3. Adicione um objeto [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAutoShape) com [ShapeType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) definido como `Rectangle` em uma posição especificada no slide e obtenha a referência para o objeto `IAutoShape` recém‑adicionado.
4. Adicione a propriedade `TextFrame` ao objeto `IAutoShape` que conterá um texto. No exemplo abaixo, adicionamos este texto: *Aspose TextBox*
5. Por fim, grave o arquivo PPTX através do objeto `Presentation`. 

Este código Java — uma implementação das etapas acima — mostra como adicionar texto a um slide:

```java
// Instancia a Presentation
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide da apresentação
    ISlide sld = pres.getSlides().get_Item(0);

    // Adiciona um AutoShape com o tipo definido como Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adiciona TextFrame ao Rectangle
    ashp.addTextFrame(" ");

    // Acessa o quadro de texto
    ITextFrame txtFrame = ashp.getTextFrame();

    // Cria o objeto Paragraph para o quadro de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Cria um objeto Portion para o parágrafo
    IPortion portion = para.getPortions().get_Item(0);

    // Define o texto
    portion.setText("Aspose TextBox");

    // Salva a apresentação no disco
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verificar uma Forma de Caixa de Texto**

Aspose.Slides fornece o método [isTextBox](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/#isTextBox--) da interface [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) que permite examinar formas e identificar caixas de texto.

![Caixa de texto e forma](istextbox.png)

Este código Java mostra como verificar se uma forma foi criada como caixa de texto: 

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Observe que se você simplesmente adicionar uma forma automática usando o método `addAutoShape` da interface [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/) , o método `isTextBox` da forma automática retornará `false`. No entanto, depois de adicionar texto à forma automática usando o método `addTextFrame` ou o método `setText`, a propriedade `isTextBox` retornará `true`.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() retorna false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() retorna true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() retorna false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() retorna true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() retorna false
shape3.addTextFrame("");
// shape3.isTextBox() retorna false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() retorna false
shape4.getTextFrame().setText("");
// shape4.isTextBox() retorna false
```

## **Adicionar Colunas a uma Caixa de Texto**

Aspose.Slides fornece as propriedades [ColumnCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) e [ColumnSpacing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (da interface [ITextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrameFormat) e da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrameFormat)) que permitem adicionar colunas a caixas de texto. Você pode especificar o número de colunas em uma caixa de texto e definir o espaçamento em pontos entre as colunas.

Este código em Java demonstra a operação descrita: 

```java
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide da apresentação
    ISlide slide = pres.getSlides().get_Item(0);

    // Adiciona um AutoShape com o tipo definido como Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Adiciona TextFrame ao Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Obtém o formato de texto do TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Especifica o número de colunas no TextFrame
    format.setColumnCount(3);

    // Especifica o espaçamento entre colunas
    format.setColumnSpacing(10);

    // Salva a apresentação
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Adicionar Colunas a um Quadro de Texto**
Aspose.Slides for Android via Java fornece a propriedade [ColumnCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (da interface [ITextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITextFrameFormat)) que permite adicionar colunas em quadros de texto. Por meio dessa propriedade, você pode especificar o número desejado de colunas em um quadro de texto.

Este código Java mostra como adicionar uma coluna dentro de um quadro de texto:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atualizar Texto**

Aspose.Slides permite alterar ou atualizar o texto contido em uma caixa de texto ou todos os textos contidos em uma apresentação. 

Este código Java demonstra uma operação onde todos os textos em uma apresentação são atualizados ou alterados:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // Verifica se a forma suporta quadro de texto (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // Itera pelos parágrafos no quadro de texto
                {
                    for (IPortion portion : paragraph.getPortions()) // Itera por cada porção no parágrafo
                    {
                        portion.setText(portion.getText().replace("years", "months")); // Altera o texto
                        portion.getPortionFormat().setFontBold(NullableBool.True); // Altera a formatação
                    }
                }
            }
        }
    }

    // Salva a apresentação modificada
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar uma Caixa de Texto com um Hyperlink** 

Você pode inserir um link dentro de uma caixa de texto. Quando a caixa de texto é clicada, os usuários são direcionados para abrir o link. 

Para adicionar uma caixa de texto contendo um link, siga estas etapas:

1. Crie uma instância da classe `Presentation`. 
2. Obtenha uma referência para o primeiro slide na apresentação recém‑criada. 
3. Adicione um objeto `AutoShape` com `ShapeType` definido como `Rectangle` em uma posição especificada no slide e obtenha a referência do objeto AutoShape recém‑adicionado.
4. Adicione um `TextFrame` ao objeto `AutoShape` que contém *Aspose TextBox* como texto padrão. 
5. Instancie a classe `IHyperlinkManager`. 
6. Atribua o objeto `IHyperlinkManager` à propriedade [HyperlinkClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) associada à parte desejada do `TextFrame`.
7. Por fim, grave o arquivo PPTX através do objeto `Presentation`. 

Este código Java — uma implementação das etapas acima — mostra como adicionar uma caixa de texto com hyperlink a um slide:

```java
// Instancia uma classe Presentation que representa um PPTX
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide da apresentação
    ISlide slide = pres.getSlides().get_Item(0);

    // Adiciona um objeto AutoShape com o tipo definido como Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Converte a forma para AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Acessa a propriedade ITextFrame associada ao AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Adiciona algum texto ao quadro
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Define o hyperlink para o texto da porção
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Salva a apresentação PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um placeholder de texto ao trabalhar com slides mestres?**

Um [placeholder](/slides/pt/androidjava/manage-placeholder/) herda o estilo/posição do [master](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/masterslide/) e pode ser sobrescrito nos [layouts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/layoutslide/), enquanto uma caixa de texto regular é um objeto independente em um slide específico e não muda quando você altera os layouts.

**Como posso executar uma substituição em massa de texto em toda a apresentação sem alterar o texto dentro de gráficos, tabelas e SmartArt?**

Limite sua iteração a auto‑shapes que possuam quadros de texto e exclua objetos incorporados ([charts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/smartart/)) percorrendo suas coleções separadamente ou ignorando esses tipos de objeto.