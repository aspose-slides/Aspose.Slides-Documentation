---
title: Gerenciar nós de forma SmartArt em apresentações usando PHP
linktitle: Nó de forma SmartArt
type: docs
weight: 30
url: /pt/php-java/manage-smartart-shape-node/
keywords:
- Nó SmartArt
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
- PHP
- Aspose.Slides
description: "Gerencie nós de forma SmartArt em PPT e PPTX com Aspose.Slides para PHP via Java. Obtenha exemplos de código claros e dicas para otimizar suas apresentações."
---
## **Visão geral**

Os gráficos SmartArt em apresentações do PowerPoint são organizados por meio de nós que contêm texto e definem a estrutura do diagrama. Aspose.Slides permite que você trabalhe com esses nós SmartArt programaticamente: adicionar novos nós e nós filhos, inserir nós filhos em uma posição específica, acessar nós existentes e ler seu texto, nível e posição.

Este artigo explica como gerenciar nós de formas SmartArt. Ele mostra como remover nós, trabalhar com nós filhos por índice ou posição, mudar um nó assistente para um nó normal, ajustar a posição, tamanho e rotação das formas de nó SmartArt, definir formatos de preenchimento dos nós e gerar uma imagem em miniatura para um nó filho SmartArt.

## **Adicionar um nó SmartArt**
Aspose.Slides for PHP via Java forneceu a API mais simples para gerenciar as formas SmartArt da maneira mais fácil. O código de exemplo a seguir ajudará a adicionar nó e nó filho dentro da forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) e carregue a apresentação com a forma SmartArt.  
2. Obtenha a referência do primeiro slide usando seu índice.  
3. Percorra todas as formas dentro do primeiro slide.  
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) e faça cast do tipo da forma selecionada para [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) se for SmartArt.  
5. [Adicione um novo Nó](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnodecollection/#addNode) na forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/#getAllNodes) e defina o texto no TextFrame.  
6. Agora, [Adicione](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnodecollection/#addNode) um [**Node Filho**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/#getChildNodes) no Nó [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) recém‑adicionado e defina o texto no TextFrame.  
7. Salve a Apresentação.

```php
  # Carregar a apresentação desejada
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Percorrer todas as formas dentro do primeiro slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArt
        $smart = $shape;
        # Adicionar um novo nó SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Adicionar texto
        $TemNode->getTextFrame()->setText("Test");
        # Adicionar novo nó filho no nó pai. Ele será adicionado ao final da coleção
        $newNode = $TemNode->getChildNodes()->addNode();
        # Adicionar texto
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Salvar a apresentação
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar um nó SmartArt em uma posição específica**
No código de exemplo a seguir explicamos como adicionar os nós filhos pertencentes aos respectivos nós da forma SmartArt em uma posição específica.

1. Crie uma instância da classe Presentation.  
2. Obtenha a referência do primeiro slide usando seu índice.  
3. Adicione uma forma [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt) do tipo [**StackedList**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtLayoutType#StackedList) no slide acessado.  
4. Acesse o primeiro nó na forma SmartArt adicionada.  
5. Agora, adicione o [**Node Filho**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/#getChildNodes) para o [**Node**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtNode) selecionado na posição 2 e defina seu texto.  
6. Salve a Apresentação.

```php
  # Criando uma instância de apresentação
  $pres = new Presentation();
  try {
    # Acessar o slide da apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionar Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Acessando o nó SmartArt no índice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Adicionando novo nó filho na posição 2 no nó pai
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Adicionar texto
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Salvar a apresentação
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar um nó SmartArt**
O código de exemplo a seguir ajudará a acessar nós dentro da forma SmartArt. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma SmartArt é adicionada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
2. Obtenha a referência do primeiro slide usando seu índice.  
3. Percorra todas as formas dentro do primeiro slide.  
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) e faça cast para [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) se for SmartArt.  
5. Percorra todos os [**Nós**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt#getAllNodes--) dentro da Forma SmartArt.  
6. Acesse e exiba informações como posição do nó SmartArt, nível e Texto.

```php
  # Instanciar a classe Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Obter o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Percorrer todas as formas dentro do primeiro slide
    foreach($slide->getShapes() as $shape) {
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArt
        $smart = $shape;
        # Percorrer todos os nós dentro do SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Acessando o nó SmartArt no índice i
          $node = $smart->getAllNodes()->get_Item($i);
          # Imprimir os parâmetros do nó SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar um nó filho SmartArt**
O código de exemplo a seguir ajudará a acessar os nós filhos pertencentes aos respectivos nós da forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
2. Obtenha a referência do primeiro slide usando seu índice.  
3. Percorra todas as formas dentro do primeiro slide.  
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) e faça cast para [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) se for SmartArt.  
5. Percorra todos os [**Nós**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt#getAllNodes--) dentro da Forma SmartArt.  
6. Para cada [**Node**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtNode) da forma SmartArt selecionada, percorra todos os [**Nós Filhos**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtNode#getChildNodes--) dentro do nó específico.  
7. Acesse e exiba informações como posição, nível e Texto do [**Node Filho**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/#getChildNodes).

```php
  # Instanciar a classe Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Obter o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Percorrer todas as formas dentro do primeiro slide
    foreach($slide->getShapes() as $shape) {
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArt
        $smart = $shape;
        # Percorrer todos os nós dentro do SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Acessando o nó SmartArt no índice i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Percorrendo os nós filhos no nó SmartArt no índice i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Acessando o nó filho no nó SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Imprimindo os parâmetros do nó filho SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar um nó filho SmartArt em uma posição específica**
Neste exemplo, aprenderemos a acessar os nós filhos em posições específicas pertencentes aos respectivos nós da forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).  
2. Obtenha a referência do primeiro slide usando seu índice.  
3. Adicione uma forma SmartArt do tipo [**StackedList**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtLayoutType#StackedList).  
4. Acesse a forma SmartArt adicionada.  
5. Acesse o nó no índice 0 da forma SmartArt acessada.  
6. Agora, acesse o [**Node Filho**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/#getChildNodes) na posição 1 do nó SmartArt acessado usando o método **get_Item()**.  
7. Acesse e exiba informações como posição, nível e Texto do [**Node Filho**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/#getChildNodes).

```php
  # Instanciar a apresentação
  $pres = new Presentation();
  try {
    # Acessando o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionando a forma SmartArt no primeiro slide
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Acessando o nó SmartArt no índice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Acessando o nó filho na posição 1 no nó pai
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Imprimindo os parâmetros do nó filho SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover um nó SmartArt**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
2. Obtenha a referência do primeiro slide usando seu índice.  
3. Percorra todas as formas dentro do primeiro slide.  
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) e faça cast para [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) se for SmartArt.  
5. Verifique se o [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) tem mais de 0 nós.  
6. Selecione o nó SmartArt a ser excluído.  
7. Agora, remova o nó selecionado usando o método [**removeNode**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Salve a Apresentação.

```php
  # Carregar a apresentação desejada
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Percorrer todas as formas dentro do primeiro slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Acessando o nó SmartArt no índice 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Removendo o nó selecionado
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Salvar a apresentação
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover um nó SmartArt de uma posição específica**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt em uma posição específica.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
2. Obtenha a referência do primeiro slide usando seu índice.  
3. Percorra todas as formas dentro do primeiro slide.  
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) e faça cast para [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) se for SmartArt.  
5. Selecione o nó da forma SmartArt no índice 0.  
6. Agora, verifique se o nó SmartArt selecionado tem mais de 2 nós filhos.  
7. Agora, remova o nó na **Posição 1** usando o método [**removeNode**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Salve a Apresentação.

```php
  # Carregar a apresentação desejada
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Percorrer todas as formas dentro do primeiro slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Acessando o nó SmartArt no índice 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Removendo o nó filho na posição 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Salvar a apresentação
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir uma posição personalizada para um nó filho em um objeto SmartArt**
Aspose.Slides for PHP via Java oferece suporte para definir as propriedades [X](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#setX) e [Y](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#setY) de [SmartArtShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtShape). O trecho de código abaixo mostra como definir a posição, tamanho e rotação personalizados de SmartArtShape; observe também que a adição de novos nós provoca um recálculo das posições e tamanhos de todos os nós. Além disso, com as configurações de posição personalizada, o usuário pode definir os nós conforme necessário.

```php
  # Instanciar a classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Mover a forma SmartArt para nova posição
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Alterar as larguras da forma SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Alterar a altura da forma SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Alterar a rotação da forma SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Verificar um nó assistente**
{{% alert color="primary" %}} 

Neste artigo vamos investigar mais a fundo os recursos das formas SmartArt adicionadas em slides de apresentação programaticamente usando Aspose.Slides for PHP via Java.

{{% /alert %}} 

Usaremos a seguinte forma SmartArt de origem para nossa investigação nas diferentes seções deste artigo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origem no slide**|

No código de exemplo a seguir investigaremos como identificar **Nós Assistentes** na coleção de nós SmartArt e alterá‑los.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação com a forma SmartArt.  
2. Obtenha a referência do segundo slide usando seu índice.  
3. Percorra todas as formas dentro do primeiro slide.  
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) e faça cast para [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) se for SmartArt.  
5. Percorra todos os nós dentro da forma SmartArt e verifique se são [**Nós Assistentes**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtNode#isAssistant--).  
6. Altere o status do Nó Assistente para nó normal.  
7. Salve a Apresentação.

```php
  # Criando uma instância de apresentação
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Percorrer todas as formas dentro do primeiro slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArt
        $smart = $shape;
        # Percorrendo todos os nós da forma SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Verificar se o nó é um nó Assistente
          if ($node->isAssistant()) {
            # Definir o nó Assistente como false e transformá-lo em nó normal
            $node->isAssistant();
          }
        }
      }
    }
    # Salvar a apresentação
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nós Assistentes alterados na forma SmartArt dentro do slide**|

## **Definir o formato de preenchimento de um nó**
Aspose.Slides for PHP via Java possibilita adicionar formas SmartArt personalizadas e definir seu formato de preenchimento. Este artigo explica como criar e acessar formas SmartArt e definir seu formato de preenchimento usando Aspose.Slides for PHP via Java.

Por favor, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).  
2. Obtenha a referência de um slide usando seu índice.  
3. Adicione uma forma [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) definindo seu [**LayoutType**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Defina o [**Fill Format**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getFillFormat) para os nós da forma SmartArt.  
5. Grave a apresentação modificada como um arquivo PPTX.

```php
  # Instanciar a apresentação
  $pres = new Presentation();
  try {
    # Acessando o slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionando forma SmartArt e nós
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Definindo a cor de preenchimento do nó
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Salvar a apresentação
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gerar uma miniatura de um nó filho SmartArt**
Os desenvolvedores podem gerar uma miniatura do nó filho de um SmartArt seguindo os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).  
2. [Adicione SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnodecollection/#addNode).  
3. Obtenha a referência de um nó usando seu índice.  
4. Obtenha a imagem da miniatura.  
5. Salve a imagem da miniatura em qualquer formato de imagem desejado.

```php
  # Instanciar a classe Presentation que representa o arquivo PPTX
  $pres = new Presentation();
  try {
    # Adicionar SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Obter a referência de um nó usando seu índice
    $node = $smart->getNodes()->get_Item(1);
    # Obter miniatura
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Salvar miniatura
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**A animação SmartArt é suportada?**

Sim. SmartArt é tratado como uma forma regular, portanto você pode [aplicar animações padrão](/slides/pt/php-java/shape-animation/) (entrada, saída, ênfase, caminhos de movimento) e ajustar o tempo. Você também pode animar formas dentro dos nós SmartArt quando necessário.

**Como posso localizar de forma confiável um SmartArt específico em um slide se seu ID interno for desconhecido?**

Atribua e pesquise pelo [texto alternativo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getalternativetext/). Definir um AltText distinto no SmartArt permite encontrá‑lo programaticamente sem depender de identificadores internos.

**A aparência do SmartArt será preservada ao converter a apresentação para PDF?**

Sim. Aspose.Slides renderiza o SmartArt com alta fidelidade visual durante a [exportação para PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), preservando o layout, cores e efeitos.

**Posso extrair uma imagem de todo o SmartArt (para pré‑visualizações ou relatórios)?**

Sim. Você pode renderizar uma forma SmartArt para [formatos raster](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) ou para [SVG](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/writeassvg/) para saída vetorial escalável, tornando-a adequada para miniaturas, relatórios ou uso na web.