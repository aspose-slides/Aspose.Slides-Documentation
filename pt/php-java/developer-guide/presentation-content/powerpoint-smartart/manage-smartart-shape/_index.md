---
title: Gerenciar Gráficos SmartArt em Apresentações Usando PHP
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /pt/php-java/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Cor SmartArt
- criar SmartArt
- adicionar SmartArt
- editar SmartArt
- alterar SmartArt
- acessar SmartArt
- tipo de layout SmartArt
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint em PHP usando Aspose.Slides, com exemplos de código concisos e orientações focadas em desempenho."
---
## **Visão Geral**

Aspose.Slides permite criar e gerenciar gráficos SmartArt em apresentações PowerPoint de forma programática. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, localizar SmartArt por um tipo de layout específico e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide da apresentação, verificar se uma forma é SmartArt e então modificar ou inspecionar suas propriedades.

## **Criar uma Forma SmartArt**
Aspose.Slides for PHP via Java fornece uma API para criar formas SmartArt. Para criar uma forma SmartArt em um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide usando seu índice.
3. [Adicione uma forma SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addSmartArt) definindo seu [LayoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArtLayoutType).
4. Salve a apresentação modificada como um arquivo PPTX.

```php
  # Instanciar a classe Presentation
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionar forma Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Salvar apresentação
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt adicionada ao slide**|

## **Acessar uma Forma SmartArt em um Slide**
O código a seguir será usado para acessar as formas SmartArt adicionadas no slide da apresentação. No código de exemplo, percorreremos cada forma dentro do slide e verificaremos se ela é uma forma [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt). Se a forma for do tipo SmartArt, então a converteremos para uma instância de [**SmartArt**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt).

```php
  # Carregar a apresentação desejada
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Percorrer cada forma dentro do primeiro slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar uma Forma SmartArt com um Tipo de Layout Particular**
O código de exemplo a seguir ajudará a acessar a forma [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt) com um LayoutType específico. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt) é adicionada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
2. Obtenha a referência do primeiro slide usando seu índice.
3. Percorra cada forma dentro do primeiro slide.
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt) e faça o cast da forma selecionada para SmartArt se for SmartArt.
5. Verifique a forma SmartArt com o LayoutType específico e execute o que for necessário posteriormente.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Percorrer cada forma dentro do primeiro slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArtEx
        $smart = $shape;
        # Verificando o Layout do SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alterar o Estilo de uma Forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo rápido de qualquer forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
2. Obtenha a referência do primeiro slide usando seu índice.
3. Percorra cada forma dentro do primeiro slide.
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt) e faça o cast da forma selecionada para SmartArt se for SmartArt.
5. Encontre a forma SmartArt com um Estilo específico.
6. Defina o novo Estilo para a forma SmartArt.
7. Salve a Apresentação.

```php
  # Instanciar a classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obter o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Percorrer cada forma dentro do primeiro slide
    foreach($slide->getShapes() as $shape) {
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArtEx
        $smart = $shape;
        # Verificando o estilo do SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Alterando o estilo do SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Salvando a apresentação
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt com Estilo alterado**|

## **Alterar o Estilo de Cor de uma Forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo de cor de qualquer forma SmartArt. No código de exemplo a seguir, acessaremos a forma SmartArt com um estilo de cor específico e alteraremos seu estilo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) e carregue a apresentação com a Forma SmartArt.
2. Obtenha a referência do primeiro slide usando seu índice.
3. Percorra cada forma dentro do primeiro slide.
4. Verifique se a forma é do tipo [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SmartArt) e faça o cast da forma selecionada para SmartArt se for SmartArt.
5. Encontre a forma SmartArt com um Estilo de Cor específico.
6. Defina o novo Estilo de Cor para a forma SmartArt.
7. Salve a Apresentação.

```php
  # Instanciar a Classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obter o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Percorrer cada forma dentro do primeiro slide
    foreach($slide->getShapes() as $shape) {
      # Verificar se a forma é do tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Fazer cast da forma para SmartArtEx
        $smart = $shape;
        # Verificando o tipo de cor do SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Alterando o tipo de cor do SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Salvando a apresentação
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt com Estilo de Cor alterado**|

## **Perguntas Frequentes**

**Posso animar SmartArt como um único objeto?**

Sim. SmartArt é uma forma, portanto você pode aplicar [animações padrão](/slides/pt/php-java/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, caminhos de movimento) assim como em outras formas.

**Como posso encontrar um SmartArt específico em um slide se eu não conhecer seu ID interno?**

Defina e use o Texto Alternativo (AltText) e procure a forma por esse valor — esta é uma maneira recomendada de localizar a forma alvo.

**Posso agrupar SmartArt com outras formas?**

Sim. Você pode agrupar SmartArt com outras formas (imagens, tabelas, etc.) e então [manipular o grupo](/slides/pt/php-java/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para visualização ou relatório)?**

Exporte uma miniatura/imagem da forma; a biblioteca pode [renderizar formas individuais](/slides/pt/php-java/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter a apresentação inteira para PDF?**

Sim. O motor de renderização visa alta fidelidade para [exportação PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.