---
title: Gerenciar gráficos SmartArt em apresentações no Android
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /pt/androidjava/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Cor SmartArt
- Criar SmartArt
- Adicionar SmartArt
- Editar SmartArt
- Alterar SmartArt
- Acessar SmartArt
- Tipo de layout SmartArt
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint usando Aspose.Slides para Android, com exemplos concisos de código Java e orientações focadas em desempenho."
---
## **Visão geral**

Aspose.Slides permite criar e gerenciar gráficos SmartArt em apresentações PowerPoint programaticamente. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, encontrar SmartArt por um tipo de layout específico e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide de apresentação, verificar se uma forma é SmartArt e, em seguida, modificar ou inspecionar suas propriedades.

## **Criar uma forma SmartArt**
Aspose.Slides for Android via Java fornece uma API para criar formas SmartArt. Para criar uma forma SmartArt em um slide, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu Índice.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) definindo seu [LayoutType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Salve a apresentação modificada como um arquivo PPTX.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adicionar forma SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Salvando a apresentação
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt adicionada ao slide**|

## **Acessar uma forma SmartArt em um slide**
O código a seguir será usado para acessar as formas SmartArt adicionadas no slide da apresentação. No código de exemplo percorreremos cada forma dentro do slide e verificaremos se ela é uma forma [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArt). Se a forma for do tipo SmartArt, então a converteremos para uma instância [**SmartArt**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArt).

```java
// Carregar a apresentação desejada
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Percorrer cada forma dentro do primeiro slide
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

## **Acessar uma forma SmartArt com um tipo de layout específico**
O código de exemplo a seguir ajuda a acessar a forma [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArt) com um LayoutType específico. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma SmartArt é adicionada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Índice.
1. Percorra cada forma dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArt) e converta a forma selecionada para SmartArt se for SmartArt.
1. Verifique a forma SmartArt com o LayoutType específico e execute o que for necessário posteriormente.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Percorrer cada forma dentro do primeiro slide
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

## **Alterar o estilo de uma forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo rápido de qualquer forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Índice.
1. Percorra cada forma dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArt) e converta a forma selecionada para SmartArt se for SmartArt.
1. Encontre a forma SmartArt com o estilo específico.
1. Defina o novo Estilo para a forma SmartArt.
1. Salve a Apresentação.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Percorrer cada forma dentro do primeiro slide
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
    // Salvando a apresentação
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt com estilo alterado**|

## **Alterar o estilo de cor de uma forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo de cor de qualquer forma SmartArt. No código de exemplo a seguir, acessaremos a forma SmartArt com um estilo de cor específico e alteraremos seu estilo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Índice.
1. Percorra cada forma dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArt) e converta a forma selecionada para SmartArt se for SmartArt.
1. Encontre a forma SmartArt com o Estilo de Cor específico.
1. Defina o novo Estilo de Cor para a forma SmartArt.
1. Salve a Apresentação.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Percorrer cada forma dentro do primeiro slide
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
    // Salvando a apresentação
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt com estilo de cor alterado**|

## **FAQ**

**Posso animar o SmartArt como um único objeto?**

Sim. SmartArt é uma forma, portanto você pode aplicar [animações padrão](/slides/pt/androidjava/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, trajetórias) assim como para outras formas.

**Como posso encontrar um SmartArt específico em um slide se não conheço seu ID interno?**

Defina e use o Texto Alternativo (AltText) e procure a forma por esse valor — esta é uma maneira recomendada de localizar a forma-alvo.

**Posso agrupar o SmartArt com outras formas?**

Sim. Você pode agrupar o SmartArt com outras formas (imagens, tabelas, etc.) e então [manipular o grupo](/slides/pt/androidjava/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para uma visualização ou relatório)?**

Exporte uma miniatura/imagem da forma; a biblioteca pode [renderizar formas individuais](/slides/pt/androidjava/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter a apresentação inteira para PDF?**

Sim. O motor de renderização visa alta fidelidade para a [exportação PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.