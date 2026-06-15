---
title: Gerenciar marcadores de posição de apresentações em JavaScript
linktitle: Gerenciar marcadores
type: docs
weight: 10
url: /pt/nodejs-java/manage-placeholder/
keywords:
- marcador de posição
- marcador de posição de texto
- marcador de posição de imagem
- marcador de posição de gráfico
- texto de prompt
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie marcadores de posição no Aspose.Slides para Node.js via Java de forma simples: substitua texto, personalize prompts e defina transparência de imagem no PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você gerencie marcadores de posição de apresentações programaticamente. Este artigo explica como encontrar marcadores de posição nos slides e alterar seu texto, definir textos de prompt personalizados para layouts de marcadores e ajustar a transparência de uma imagem usada como plano de fundo de um marcador. Também inclui um FAQ breve que esclarece a diferença entre marcadores de posição base e formas locais, explica como as alterações de marcadores podem ser aplicadas através de layouts ou mestres e aponta para o gerenciamento de marcadores de cabeçalho e rodapé.

## **Alterar texto no marcador**

Usando [Aspose.Slides for Node.js via Java](/slides/pt/nodejs-java/), você pode encontrar e modificar marcadores de posição nos slides de apresentações. Aspose.Slides permite que você faça alterações no texto de um marcador de posição.

**Pré-requisito**: Você precisa de uma apresentação que contenha um marcador de posição. Você pode criar essa apresentação no aplicativo padrão Microsoft PowerPoint.

Esta é a forma de usar Aspose.Slides para substituir o texto no marcador de posição nessa apresentação:

1. Instancie a classe [`Presentation`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) e passe a apresentação como argumento.
2. Obtenha uma referência ao slide pelo seu índice.
3. Itere sobre as formas para encontrar o marcador de posição.
4. Converta a forma do marcador de posição para um [`AutoShape`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) e altere o texto usando o [`TextFrame`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame) associado ao [`AutoShape`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape).
5. Salve a apresentação modificada.

Este código JavaScript mostra como alterar o texto em um marcador de posição:

```javascript
// Instancia uma classe Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Itera pelas formas para encontrar o marcador de posição
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Altera o texto em cada marcador de posição
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Salva a apresentação no disco
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir texto de prompt no marcador**

Layouts padrão e pré-construídos contêm textos de prompt de marcador como ***Clique para adicionar um título*** ou ***Clique para adicionar um subtítulo***. Usando Aspose.Slides, você pode inserir seus textos de prompt preferidos nos layouts de marcadores.

Este código JavaScript mostra como definir o texto de prompt em um marcador de posição:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Itera pelo slide
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // O PowerPoint exibe "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Adiciona subtítulo
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir transparência da imagem do marcador**

Aspose.Slides permite definir a transparência da imagem de fundo em um marcador de texto. Ao ajustar a transparência da imagem nesse quadro, você pode fazer o texto ou a imagem se destacarem (dependendo das cores do texto e da imagem).

Este código JavaScript mostra como definir a transparência para um fundo de imagem (dentro de uma forma):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**O que é um marcador de posição base e como ele difere de uma forma local em um slide?**

Um marcador de posição base é a forma original em um layout ou mestre de que a forma do slide herda—tipo, posição e algumas formatações provêm dela. Uma forma local é independente; se não houver um marcador de posição base, a herança não se aplica.

**Como posso atualizar todos os títulos ou legendas em uma apresentação sem percorrer cada slide?**

Edite o marcador de posição correspondente no layout ou no mestre. Slides baseados nesses layouts ou naquele mestre herdarão a alteração automaticamente.

**Como controlo os marcadores de posição padrão de cabeçalho/rodapé—data e hora, número do slide e texto do rodapé?**

Use os gerenciadores HeaderFooter no escopo adequado (slides normais, layouts, mestre, notas/folhetos) para ativar ou desativar esses marcadores de posição e definir seu conteúdo.