---
title: Gerenciar nós de formas SmartArt em apresentações usando JavaScript
linktitle: Nó de forma SmartArt
type: docs
weight: 30
url: /pt/nodejs-java/manage-smartart-shape-node/
keywords:
- nó SmartArt
- nó filho
- adicionar nó
- posição do nó
- acessar nó
- remover nó
- posição personalizada
- nó assistente
- formato de preenchimento
- renderizar nó
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie nós de formas SmartArt em PPT e PPTX com Aspose.Slides para Node.js. Obtenha exemplos claros de código JavaScript e dicas para otimizar suas apresentações."
---
## **Visão geral**

Os gráficos SmartArt em apresentações PowerPoint são organizados por meio de nós que contêm texto e definem a estrutura do diagrama. Aspose.Slides permite trabalhar com esses nós SmartArt programaticamente: adicionar novos nós e nós filhos, inserir nós filhos em uma posição específica, acessar nós existentes e ler seu texto, nível e posição.

Este artigo explica como gerenciar nós de formas SmartArt. Ele mostra como remover nós, trabalhar com nós filhos por índice ou posição, transformar um nó assistente em um nó normal, ajustar a posição, tamanho e rotação das formas dos nós SmartArt, definir formatos de preenchimento dos nós e gerar uma imagem em miniatura para um nó filho SmartArt.

## **Adicionar nó SmartArt em apresentação PowerPoint usando JavaScript**
Aspose.Slides for Node.js via Java fornece a API mais simples para gerenciar as formas SmartArt da maneira mais fácil. O código de exemplo a seguir ajudará a adicionar nó e nó filho dentro da forma SmartArt.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) e carregue a apresentação com a forma SmartArt.  
1. Obtenha a referência do primeiro slide usando seu Índice.  
1. Percorra todas as formas dentro do primeiro slide.  
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e faça o casting da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) se for SmartArt.  
1. [Adicione um novo Nó](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) na forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt#getAllNodes--) e defina o texto no TextFrame.  
1. Agora, [Adicione](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) um [**Nó Filho**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) ao Nó SmartArt recém‑adicionado e defina o texto no TextFrame.  
1. Salve a apresentação.

```javascript
// Carregar a apresentação desejada
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Fazer cast da forma para SmartArt
            var smart = shape;
            // Adicionar um novo nó SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Adicionar texto
            TemNode.getTextFrame().setText("Test");
            // Adicionar um novo nó filho no nó pai. Ele será adicionado ao final da coleção
            var newNode = TemNode.getChildNodes().addNode();
            // Adicionar texto
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Salvar a apresentação
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionar nó SmartArt em posição específica**
No código de exemplo a seguir explicamos como adicionar os nós filhos pertencentes aos respectivos nós da forma SmartArt em uma posição específica.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).  
1. Obtenha a referência do primeiro slide usando seu Índice.  
1. Adicione uma forma [**StackedList**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) no slide acessado.  
1. Acesse o primeiro nó na forma SmartArt adicionada.  
1. Agora, adicione o [**Nó Filho**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) para o [**Nó**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode) selecionado na posição 2 e defina seu texto.  
1. Salve a apresentação.

```javascript
// Criando uma instância de apresentação
var pres = new aspose.slides.Presentation();
try {
    // Acessar o slide da apresentação
    var slide = pres.getSlides().get_Item(0);
    // Adicionar Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Acessando o nó SmartArt no índice 0
    var node = smart.getAllNodes().get_Item(0);
    // Adicionando novo nó filho na posição 2 no nó pai
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Adicionar texto
    chNode.getTextFrame().setText("Sample Text Added");
    // Salvar apresentação
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar nó SmartArt em apresentação PowerPoint usando JavaScript**
O código de exemplo a seguir ajudará a acessar nós dentro da forma SmartArt. Observe que não é possível alterar o LayoutType do SmartArt, pois ele é somente leitura e definido apenas quando a forma SmartArt é adicionada.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
1. Obtenha a referência do primeiro slide usando seu Índice.  
1. Percorra todas as formas dentro do primeiro slide.  
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e faça o casting da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) se for SmartArt.  
1. Percorra todos os [**Nós**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt#getAllNodes--) dentro da forma SmartArt.  
1. Acesse e exiba informações como posição do Nó SmartArt, nível e Texto.

```javascript
// Instanciar classe Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Obter primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Fazer cast da forma para SmartArt
            var smart = shape;
            // Percorrer todos os nós dentro do SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Acessando nó SmartArt no índice i
                var node = smart.getAllNodes().get_Item(j);
                // Imprimindo os parâmetros do nó SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar nó filho SmartArt**
O código de exemplo a seguir ajudará a acessar os nós filhos pertencentes aos respectivos nós da forma SmartArt.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
1. Obtenha a referência do primeiro slide usando seu Índice.  
1. Percorra todas as formas dentro do primeiro slide.  
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e faça o casting da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) se for SmartArt.  
1. Percorra todos os [**Nós**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt#getAllNodes--) dentro da forma SmartArt.  
1. Para cada [**Nó**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode) da forma SmartArt selecionada, percorra todos os [**Nós Filhos**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) dentro do nó específico.  
1. Acesse e exiba informações como posição, nível e Texto do [**Nó Filho**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Instanciar classe Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Obter primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Percorrer todas as formas dentro do primeiro slide
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Fazer cast da forma para SmartArt
            var smart = shape;
            // Percorrer todos os nós dentro do SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Acessando nó SmartArt no índice i
                var node0 = smart.getAllNodes().get_Item(i);
                // Percorrendo os nós filhos no nó SmartArt no índice i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Acessando o nó filho no nó SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Imprimindo os parâmetros do nó filho SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar nó filho SmartArt em posição específica**
Neste exemplo, aprenderemos a acessar os nós filhos em posições específicas pertencentes aos respectivos nós da forma SmartArt.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
1. Obtenha a referência do primeiro slide usando seu Índice.  
1. Adicione uma forma SmartArt do tipo [**StackedList**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).  
1. Acesse a forma SmartArt adicionada.  
1. Acesse o nó no índice 0 da forma SmartArt acessada.  
1. Agora, acesse o [**Nó Filho**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) na posição 1 para o nó SmartArt acessado usando o método **get_Item()**.  
1. Acesse e exiba informações como posição, nível e Texto do [**Nó Filho**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Instanciar a apresentação
var pres = new aspose.slides.Presentation();
try {
    // Acessando o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionando a forma SmartArt no primeiro slide
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Acessando o nó SmartArt no índice 0
    var node = smart.getAllNodes().get_Item(0);
    // Acessando o nó filho na posição 1 no nó pai
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Imprimindo os parâmetros do nó filho SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remover nó SmartArt em apresentação PowerPoint usando JavaScript**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
1. Obtenha a referência do primeiro slide usando seu Índice.  
1. Percorra todas as formas dentro do primeiro slide.  
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e faça o casting da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) se for SmartArt.  
1. Verifique se o [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) possui mais de 0 nós.  
1. Selecione o nó SmartArt a ser excluído.  
1. Agora, remova o nó selecionado usando o método [**RemoveNode**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).  
1. Salve a apresentação.

```javascript
// Carregar a apresentação desejada
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Fazer cast da forma para SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Acessando nó SmartArt no índice 0
                var node = smart.getAllNodes().get_Item(0);
                // Removendo o nó selecionado
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Salvar apresentação
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remover nó SmartArt em posição específica**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt em uma posição específica.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
1. Obtenha a referência do primeiro slide usando seu Índice.  
1. Percorra todas as formas dentro do primeiro slide.  
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e faça o casting da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) se for SmartArt.  
1. Selecione o nó da forma SmartArt no índice 0.  
1. Agora, verifique se o nó SmartArt selecionado possui mais de 2 nós filhos.  
1. Em seguida, remova o nó na **Posição 1** usando o método [**RemoveNode**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).  
1. Salve a apresentação.

```javascript
// Carregar a apresentação desejada
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Fazer cast da forma para SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Acessando nó SmartArt no índice 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Removendo o nó filho na posição 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Salvar apresentação
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir posição personalizada para nó filho em SmartArt**
Agora Aspose.Slides for Node.js via Java oferece suporte para definir as propriedades [SmartArtShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#setX-float-) e [Y](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#setY-float-). O trecho de código abaixo mostra como definir posição, tamanho e rotação personalizados da SmartArtShape; observe que a adição de novos nós provoca um recálculo das posições e tamanhos de todos os nós. Também, com as configurações de posição personalizada, o usuário pode definir os nós conforme necessário.

```javascript
// Instanciar classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Mover forma SmartArt para nova posição
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Alterar larguras da forma SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Alterar altura da forma SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Alterar rotação da forma SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Verificar nó Assistente**
{{% alert color="primary" %}} 

Neste artigo investigaremos mais a fundo os recursos das formas SmartArt adicionadas em slides de apresentação programaticamente usando Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Usaremos a seguinte forma SmartArt como fonte para nossa investigação nas diferentes seções deste artigo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origem no slide**|

No código de exemplo a seguir investigaremos como identificar **Nós Assistentes** na coleção de nós SmartArt e alterá‑los.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
1. Obtenha a referência do segundo slide usando seu Índice.  
1. Percorra todas as formas dentro do primeiro slide.  
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) e faça o casting da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) se for SmartArt.  
1. Percorra todos os nós dentro da forma SmartArt e verifique se são [**Nós Assistentes**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).  
1. Altere o status do Nó Assistente para nó normal.  
1. Salve a apresentação.

```javascript
// Criando uma instância de apresentação
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar se a forma é do tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Fazer cast da forma para SmartArt
            var smart = shape;
            // Percorrendo todos os nós da forma SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Verificar se o nó é nó Assistente
                if (node.isAssistant()) {
                    // Definir nó Assistente como falso e torná-lo nó normal
                    node.isAssistant();
                }
            }
        }
    }
    // Salvar apresentação
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nós Assistentes alterados na forma SmartArt dentro do slide**|

## **Definir formato de preenchimento do nó**
Aspose.Slides for Node.js via Java possibilita adicionar formas SmartArt personalizadas e definir seu formato de preenchimento. Este artigo explica como criar e acessar formas SmartArt e definir seu formato de preenchimento usando Aspose.Slides for Node.js via Java.

Siga os passos abaixo:

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
1. Obtenha a referência de um slide usando seu índice.  
1. Adicione uma forma [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArt) definindo seu [**LayoutType**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
1. Defina o [**FillFormat**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getFillFormat--) para os nós da forma SmartArt.  
1. Grave a apresentação modificada como um arquivo PPTX.

```javascript
// Instanciar a apresentação
var pres = new aspose.slides.Presentation();
try {
    // Acessando o slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionando forma SmartArt e nós
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Definindo cor de preenchimento do nó
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Salvar a apresentação
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerar miniatura do nó filho SmartArt**
Os desenvolvedores podem gerar uma miniatura do nó filho de um SmartArt seguindo os passos abaixo:

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
1. [Adicione SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).  
1. Obtenha a referência de um nó usando seu Índice.  
1. Obtenha a imagem em miniatura.  
1. Salve a imagem em miniatura no formato de imagem desejado.

```javascript
// Instanciar a classe Presentation que representa o arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Adicionar SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Obter a referência de um nó usando seu Índice
    var node = smart.getNodes().get_Item(1);
    // Obter miniatura
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Salvar miniatura
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**A animação SmartArt é suportada?**

Sim. O SmartArt é tratado como uma forma regular, portanto você pode [aplicar animações padrão](/slides/pt/nodejs-java/shape-animation/) (entrada, saída, ênfase, trajetórias de movimento) e ajustar o tempo. Também é possível animar formas dentro dos nós SmartArt quando necessário.

**Como localizar de forma confiável um SmartArt específico em um slide se seu ID interno for desconhecido?**

Atribua e pesquise por [texto alternativo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getalternativetext/). Definir um AltText distintivo no SmartArt permite encontrá‑lo sem depender de identificadores internos.

**A aparência do SmartArt será preservada ao converter a apresentação para PDF?**

Sim. Aspose.Slides renderiza o SmartArt com alta fidelidade visual durante a [exportação para PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), preservando layout, cores e efeitos.

**Posso extrair uma imagem de todo o SmartArt (para pré‑visualizações ou relatórios)?**

Sim. Você pode renderizar uma forma SmartArt para [formatos raster](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage) ou para [SVG](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/writeassvg/) para saída vetorial escalável, tornando‑a adequada para miniaturas, relatórios ou uso na web.