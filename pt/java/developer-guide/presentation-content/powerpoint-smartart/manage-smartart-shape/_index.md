---
title: Gerenciar Gráficos SmartArt em Apresentações Usando Java
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /pt/java/manage-smartart-shape/
keywords:
- objeto SmartArt
- gráfico SmartArt
- estilo SmartArt
- cor SmartArt
- criar SmartArt
- adicionar SmartArt
- editar SmartArt
- alterar SmartArt
- acessar SmartArt
- tipo de layout SmartArt
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint em Java usando Aspose.Slides, com exemplos de código concisos e orientações focadas em desempenho."
---
## **Visão geral**

Aspose.Slides permite criar e gerenciar gráficos SmartArt em apresentações do PowerPoint programaticamente. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, encontrar SmartArt por um tipo específico de layout e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide da apresentação, verificar se uma forma é SmartArt e então modificar ou inspecionar suas propriedades.

## **Criar uma Forma SmartArt**
Aspose.Slides for Java fornece uma API para criar formas SmartArt. Para criar uma forma SmartArt em um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu Index.
1. [Adicione uma forma SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) definindo seu [LayoutType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtLayoutType).
1. Salve a apresentação modificada como um arquivo PPTX.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adicionar forma SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Salvar apresentação
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt adicionada ao slide**|

## **Acessar uma Forma SmartArt em um Slide**
O código a seguir será usado para acessar as formas SmartArt adicionadas no slide da apresentação. No código de exemplo, percorreremos todas as formas dentro do slide e verificaremos se ela é uma forma [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt). Se a forma for do tipo SmartArt, faremos um cast para a instância [**SmartArt**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt).

```java
// Carregar a apresentação desejada
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar uma Forma SmartArt com um Tipo de Layout Específico**
O código de exemplo a seguir ajudará a acessar a forma [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt) com um LayoutType específico. Observe que não é possível alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt) é adicionada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) e carregue a apresentação com Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Index.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt) e faça cast da forma selecionada para SmartArt se for SmartArt.
1. Verifique a forma SmartArt com o LayoutType específico e execute o que for necessário em seguida.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Verificando o layout do SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alterar o Estilo de uma Forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo rápido de qualquer forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) e carregue a apresentação com Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Index.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt) e faça cast da forma selecionada para SmartArt se for SmartArt.
1. Encontre a forma SmartArt com o Estilo específico.
1. Defina o novo Estilo para a forma SmartArt.
1. Salve a apresentação.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verificando o estilo do SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Alterando o estilo do SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Salvar apresentação
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt com Estilo alterado**|

## **Alterar o Estilo de Cor de uma Forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo de cor de qualquer forma SmartArt. No código de exemplo, acessaremos a forma SmartArt com um estilo de cor específico e alteraremos seu estilo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) e carregue a apresentação com Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Index.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt) e faça cast da forma selecionada para SmartArt se for SmartArt.
1. Encontre a forma SmartArt com o Estilo de Cor específico.
1. Defina o novo Estilo de Cor para a forma SmartArt.
1. Salve a apresentação.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verificando o tipo de cor do SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Alterando o tipo de cor do SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Salvar apresentação
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt com Estilo de Cor alterado**|

## **FAQ**

**Posso animar SmartArt como um único objeto?**  
Sim. SmartArt é uma forma, portanto você pode aplicar [animações padrão](/slides/pt/java/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, caminhos de movimento) assim como em outras formas.

**Como posso encontrar um SmartArt específico em um slide se não conheço seu ID interno?**  
Defina e use o Texto Alternativo (AltText) e procure a forma por esse valor — esta é uma maneira recomendada de localizar a forma alvo.

**Posso agrupar SmartArt com outras formas?**  
Sim. Você pode agrupar SmartArt com outras formas (imagens, tabelas, etc.) e então [manipular o grupo](/slides/pt/java/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para uma pré‑visualização ou relatório)?**  
Exporte uma miniatura/imagem da forma; a biblioteca pode [renderizar formas individuais](/slides/pt/java/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter a apresentação inteira para PDF?**  
Sim. O motor de renderização visa alta fidelidade para a [exportação para PDF](/slides/pt/java/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.