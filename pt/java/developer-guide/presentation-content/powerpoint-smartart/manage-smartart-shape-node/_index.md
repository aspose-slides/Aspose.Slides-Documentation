---
title: Gerenciar Nós de Forma SmartArt em Apresentações Usando Java
linktitle: Nó de Forma SmartArt
type: docs
weight: 30
url: /pt/java/manage-smartart-shape-node/
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
- Java
- Aspose.Slides
description: "Gerencie nós de forma SmartArt em PPT e PPTX com Aspose.Slides for Java. Obtenha exemplos de código claros e dicas para otimizar suas apresentações."
---
## **Visão geral**

Os gráficos SmartArt em apresentações do PowerPoint são organizados por nós que contêm texto e definem a estrutura do diagrama. Aspose.Slides permite que você trabalhe com esses nós SmartArt programaticamente: adicionar novos nós e nós filhos, inserir nós filhos em uma posição específica, acessar nós existentes e ler seu texto, nível e posição.

Este artigo explica como gerenciar nós de forma SmartArt. Ele mostra como remover nós, trabalhar com nós filhos por índice ou posição, mudar um nó assistente para um nó normal, ajustar a posição, tamanho e rotação das formas de nó SmartArt, definir formatos de preenchimento dos nós e gerar uma imagem em miniatura para um nó filho SmartArt.

## **Adicionar um nó SmartArt**
Aspose.Slides for Java oferece a API mais simples para gerenciar as formas SmartArt da maneira mais fácil. O código de exemplo a seguir ajuda a adicionar nó e nó filho dentro de uma forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu índice.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) e faça o cast da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) se for SmartArt.
1. [Adicionar um novo Nó](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) na forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt#getAllNodes--) e defina o texto no TextFrame.
1. Agora, [Adicionar](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) um [**Nó Filho**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ao Nó SmartArt recém‑adicionado e defina o texto no TextFrame.
1. Salve a apresentação.

```java
// Carregar a apresentação desejada
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Fazer cast da forma para SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Adicionar um novo nó SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Adicionar texto
            TemNode.getTextFrame().setText("Test");
    
            // Adicionar novo nó filho no nó pai. Será adicionado ao final da coleção
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Adicionar texto
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Salvar a apresentação
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar um nó SmartArt em uma posição específica**
No código de exemplo a seguir explicamos como adicionar os nós filhos pertencentes aos respectivos nós da forma SmartArt em posições particulares.

1. Crie uma instância da classe Presentation.
1. Obtenha a referência do primeiro slide usando seu índice.
1. Adicione uma forma SmartArt do tipo [**StackedList**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtLayoutType#StackedList) no slide acessado.
1. Acesse o primeiro nó na forma SmartArt adicionada.
1. Agora, adicione o [**Nó Filho**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNode#getChildNodes--) para o [**Nó**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtNode) selecionado na posição 2 e defina seu texto.
1. Salve a apresentação.

```java
// Criando uma instância de apresentação
Presentation pres = new Presentation();
try {
    // Acessar o slide da apresentação
    ISlide slide = pres.getSlides().get_Item(0);

    // Adicionar Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Acessando o nó SmartArt no índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Adicionando novo nó filho na posição 2 do nó pai
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Adicionar texto
    chNode.getTextFrame().setText("Sample Text Added");

    // Salvar a apresentação
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar um nó SmartArt**
O código de exemplo a seguir ajuda a acessar nós dentro da forma SmartArt. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma SmartArt é adicionada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu índice.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) e faça o cast da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) se for SmartArt.
1. Percorra todos os [**Nós**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt#getAllNodes--) dentro da Forma SmartArt.
1. Acesse e exiba informações como posição do Nó SmartArt, nível e Texto.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Fazer cast da forma para SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Percorrer todos os nós dentro do SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Acessando o nó SmartArt no índice i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Imprimindo os parâmetros do nó SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar um nó filho SmartArt**
O código de exemplo a seguir ajuda a acessar os nós filhos pertencentes aos respectivos nós da forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu índice.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) e faça o cast da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) se for SmartArt.
1. Percorra todos os [**Nós**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArt#getAllNodes--) dentro da Forma SmartArt.
1. Para cada [**Nó**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtNode) da forma SmartArt selecionada, percorra todos os [**Nós Filhos**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtNode#getChildNodes--) dentro desse nó específico.
1. Acesse e exiba informações como posição, nível e Texto do [**Nó Filho**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Fazer cast da forma para SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Percorrer todos os nós dentro do SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Acessando o nó SmartArt no índice i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Percorrendo os nós filhos no nó SmartArt no índice i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Acessando o nó filho no nó SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimindo os parâmetros do nó filho SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar um nó filho SmartArt em uma posição específica**
Neste exemplo, aprenderemos a acessar os nós filhos em posições específicas pertencentes aos respectivos nós da forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
1. Obtenha a referência do primeiro slide usando seu índice.
1. Adicione uma forma SmartArt do tipo [**StackedList**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Acesse a forma SmartArt adicionada.
1. Acesse o nó no índice 0 da forma SmartArt acessada.
1. Agora, acesse o [**Nó Filho**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNode#getChildNodes--) na posição 1 do nó SmartArt acessado usando o método **get_Item()**.
1. Acesse e exiba informações como posição, nível e Texto do [**Nó Filho**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instanciar a apresentação
Presentation pres = new Presentation();
try {
    // Acessando o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adicionando a forma SmartArt no primeiro slide
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Acessando o nó SmartArt no índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Acessando o nó filho na posição 1 do nó pai
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimindo os parâmetros do nó filho SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remover um nó SmartArt**
Neste exemplo, aprenderemos a remover nós dentro da forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu índice.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) e faça o cast da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) se for SmartArt.
1. Verifique se o [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) possui mais de 0 nós.
1. Selecione o nó SmartArt a ser excluído.
1. Agora, remova o nó selecionado usando o método [**RemoveNode**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Salve a apresentação.

```java
// Carregar a apresentação desejada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Fazer cast da forma para SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Acessando o nó SmartArt no índice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Removendo o nó selecionado
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Salvar a apresentação
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remover um nó SmartArt de uma posição específica**
Neste exemplo, aprenderemos a remover nós dentro da forma SmartArt em uma posição particular.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.
1. Obtenha a referência do primeiro slide usando seu índice.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) e faça o cast da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) se for SmartArt.
1. Selecione o nó da forma SmartArt no índice 0.
1. Agora, verifique se o nó SmartArt selecionado possui mais de 2 nós filhos.
1. Em seguida, remova o nó na **Posição 1** usando o método [**RemoveNode**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Salve a apresentação.

```java
// Carregar a apresentação desejada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Fazer cast da forma para SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Acessando o nó SmartArt no índice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Removendo o nó filho na posição 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Salvar a apresentação
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir uma posição personalizada para um nó filho em um objeto SmartArt**
Agora o Aspose.Slides for Java oferece suporte à definição das propriedades [SmartArtShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#setX-float-) e [Y](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#setY-float-). O trecho de código abaixo mostra como definir posição, tamanho e rotação personalizados da SmartArtShape; observe que a adição de novos nós provoca o recálculo das posições e tamanhos de todos os nós. Com as configurações de posição personalizada, o usuário pode definir os nós conforme necessário.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Mover a forma SmartArt para nova posição
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Alterar as larguras da forma SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Alterar a altura da forma SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Alterar a rotação da forma SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Verificar um nó assistente**
{{% alert color="primary" %}} 

Neste artigo investigaremos mais a fundo os recursos das formas SmartArt adicionadas em slides de apresentação programaticamente usando Aspose.Slides for Java.

{{% /alert %}} 

Usaremos a forma SmartArt de origem a seguir para nossa investigação nas diferentes seções deste artigo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origem no slide**|

No código de exemplo a seguir investigaremos como identificar **Nós Assistentes** na coleção de nós SmartArt e alterá‑los.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.
1. Obtenha a referência do segundo slide usando seu índice.
1. Percorra todas as formas dentro do primeiro slide.
1. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) e faça o cast da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) se for SmartArt.
1. Percorra todos os nós dentro da forma SmartArt e verifique se são [**Nós Assistentes**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtNode#isAssistant--).
1. Altere o status do Nó Assistente para nó normal.
1. Salve a apresentação.

```java
// Criando uma instância de apresentação
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Percorrer todas as formas dentro do primeiro slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Fazer cast da forma para SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Percorrendo todos os nós da forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Verificar se o nó é um nó Assistente
                if (node.isAssistant()) 
                {
                    // Definir nó Assistente como falso e torná-lo nó normal
                    node.isAssistant();
                }
            }
        }
    }
    
    // Salvar a apresentação
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nós Assistentes alterados na forma SmartArt dentro do slide**|

## **Definir o formato de preenchimento de um nó**
Aspose.Slides for Java possibilita adicionar formas SmartArt personalizadas e definir seu formato de preenchimento. Este artigo explica como criar e acessar formas SmartArt e definir seu formato de preenchimento usando Aspose.Slides for Java.

Siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Adicione uma forma [SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArt) definindo seu [**LayoutType**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Defina o [**FillFormat**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#getFillFormat--) para os nós da forma SmartArt.
1. Grave a apresentação modificada como um arquivo PPTX.

```java
// Instanciar a apresentação
Presentation pres = new Presentation();
try {
    // Acessando o slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adicionando forma SmartArt e nós
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Definindo a cor de preenchimento do nó
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Salvar a apresentação
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerar uma miniatura de um nó filho SmartArt**
Os desenvolvedores podem gerar uma miniatura do nó filho de um SmartArt seguindo os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
1. [Adicionar SmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtenha a referência de um nó usando seu índice.
1. Obtenha a imagem em miniatura.
1. Salve a imagem em miniatura no formato de imagem desejado.

```java
// Instanciar a classe Presentation que representa o arquivo PPTX
Presentation pres = new Presentation();
try {
    // Adicionar SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Obter a referência de um nó usando seu índice
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Obter miniatura
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Salvar miniatura
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**A animação SmartArt é suportada?**

Sim. SmartArt é tratada como uma forma regular, portanto você pode [aplicar animações padrão](/slides/pt/java/shape-animation/) (entrada, saída, ênfase, trajetórias) e ajustar o tempo. Também é possível animar formas dentro dos nós SmartArt quando necessário.

**Como localizar de forma confiável um SmartArt específico em um slide se seu ID interno for desconhecido?**

Atribua e procure por [texto alternativo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getAlternativeText--) . Definir um AltText distintivo no SmartArt permite encontrá‑lo programaticamente sem depender de identificadores internos.

**A aparência do SmartArt será preservada ao converter a apresentação para PDF?**

Sim. Aspose.Slides renderiza SmartArt com alta fidelidade visual durante a [exportação para PDF](/slides/pt/java/convert-powerpoint-to-pdf/), preservando layout, cores e efeitos.

**Posso extrair uma imagem de todo o SmartArt (para visualizações ou relatórios)?**

Sim. Você pode renderizar uma forma SmartArt para [formatos raster](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getImage-int-float-float-) ou para [SVG](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para saída vetorial escalável, o que a torna adequada para miniaturas, relatórios ou uso na web.