---
title: Gerenciar gráficos SmartArt em apresentações usando JavaScript
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /pt/nodejs-java/manage-smartart-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint usando JavaScript com Aspose.Slides, apresentando exemplos de código concisos e orientações focadas em desempenho."
---
## **Visão geral**

Aspose.Slides permite criar e gerenciar gráficos SmartArt em apresentações do PowerPoint programaticamente. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, encontrar SmartArt por um tipo de layout específico e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide da apresentação, verificar se uma forma é SmartArt e então modificar ou inspecionar suas propriedades.

## **Criar forma SmartArt**
Aspose.Slides for Node.js via Java forneceu uma API para criar formas SmartArt. Para criar uma forma SmartArt em um slide, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu Índice.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) definindo seu [LayoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtLayoutType).
1. Salve a apresentação modificada como um arquivo PPTX.

```javascript
// Instanciar a classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionar forma SmartArt
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Salvar a apresentação
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt adicionada ao slide**|

## **Acessar forma SmartArt no slide**
O código a seguir será usado para acessar as formas SmartArt adicionadas no slide da apresentação. No código de exemplo percorreremos cada forma dentro do slide e verificaremos se ela é uma forma [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt). Se a forma for do tipo SmartArt, então a converteremos para uma instância de [**SmartArt**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt).

```javascript
// Carregar a apresentação desejada
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Converter a forma para SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar forma SmartArt com LayoutType específico**
O código de exemplo a seguir ajudará a acessar a forma [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) com um LayoutType específico. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e definido apenas quando a forma SmartArt é adicionada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Índice.
1. Percorra cada forma dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e converta a forma selecionada para SmartArt se for SmartArt.
1. Verifique a forma SmartArt com o LayoutType específico e execute o que for necessário posteriormente.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Converter a forma para SmartArtEx
            var smart = shape;
            // Verificando o layout do SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterar estilo da forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo rápido para qualquer forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Índice.
1. Percorra cada forma dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e converta a forma selecionada para SmartArt se for SmartArt.
1. Encontre a forma SmartArt com o estilo específico.
1. Defina o novo estilo para a forma SmartArt.
1. Salve a apresentação.

```javascript
// Instanciar a classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Obter o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Converter a forma para SmartArtEx
            var smart = shape;
            // Verificando o estilo do SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Alterando o estilo do SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Salvando a apresentação
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt com estilo alterado**|

## **Alterar estilo de cor da forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo de cor para qualquer forma SmartArt. No código de exemplo a seguir, acessaremos a forma SmartArt com um estilo de cor específico e alteraremos seu estilo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu Índice.
1. Percorra cada forma dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e converta a forma selecionada para SmartArt se for SmartArt.
1. Encontre a forma SmartArt com o estilo de cor específico.
1. Defina o novo estilo de cor para a forma SmartArt.
1. Salve a apresentação.

```javascript
// Instanciar a classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Obter o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Converter a forma para SmartArtEx
            var smart = shape;
            // Verificando o tipo de cor do SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Alterando o tipo de cor do SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Salvando a apresentação
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt com estilo de cor alterado**|

## **Perguntas frequentes**

**Posso animar SmartArt como um único objeto?**

Sim. SmartArt é uma forma, portanto você pode aplicar [animações padrão](/slides/pt/nodejs-java/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, caminhos de movimento) assim como em outras formas.

**Como posso encontrar um SmartArt específico em um slide se eu não conheço seu ID interno?**

Defina e use o Texto Alternativo (AltText) e procure a forma por esse valor — esta é uma forma recomendada de localizar a forma-alvo.

**Posso agrupar SmartArt com outras formas?**

Sim. Você pode agrupar SmartArt com outras formas (imagens, tabelas, etc.) e então [manipular o grupo](/slides/pt/nodejs-java/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para pré‑visualização ou relatório)?**

Exporte uma miniatura/imagem da forma; a biblioteca pode [renderizar formas individuais](/slides/pt/nodejs-java/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter a apresentação inteira para PDF?**

Sim. O motor de renderização visa alta fidelidade para [exportação PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.