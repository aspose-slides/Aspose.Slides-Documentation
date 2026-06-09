---
title: Gerenciar Marcadores de Posição de Apresentação em PHP
linktitle: Gerenciar Marcadores
type: docs
weight: 10
url: /pt/php-java/manage-placeholder/
keywords:
- marcador de posição
- marcador de posição de texto
- marcador de posição de imagem
- marcador de posição de gráfico
- texto de prompt
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie marcadores de posição no Aspose.Slides para PHP via Java com facilidade: substitua texto, personalize prompts e defina a transparência de imagens no PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você gerencie marcadores de posição de apresentações programaticamente. Este artigo explica como encontrar marcadores de posição em slides e alterar seu texto, definir texto de prompt personalizado para layouts de marcadores de posição e ajustar a transparência de uma imagem usada como plano de fundo de um marcador de posição. Também inclui um FAQ curto que esclarece a diferença entre marcadores de posição base e formas locais, explica como as alterações nos marcadores de posição podem ser aplicadas por meio de layouts ou mestres, e aponta para o gerenciamento de marcadores de posição de cabeçalho e rodapé.

## **Alterar texto em um marcador de posição**
Usando [Aspose.Slides for PHP via Java](/slides/pt/php-java/), você pode encontrar e modificar marcadores de posição em slides de apresentações. O Aspose.Slides permite que você faça alterações no texto de um marcador de posição.

**Pré-requisitos**: Você precisa de uma apresentação que contenha um marcador de posição. Você pode criar essa apresentação no aplicativo padrão Microsoft PowerPoint.

É assim que você usa o Aspose.Slides para substituir o texto no marcador de posição naquela apresentação:

1. Instancie a classe [`Presentation`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) e passe a apresentação como argumento.
2. Obtenha uma referência ao slide através de seu índice.
3. Itere pelas formas para encontrar o marcador de posição.
4. Converta o tipo da forma de marcador de posição para um [`AutoShape`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/AutoShape) e altere o texto usando o [`TextFrame`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/TextFrame) associado ao [`AutoShape`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/AutoShape).
5. Salve a apresentação modificada.

Este código PHP mostra como alterar o texto em um marcador de posição:

```php
  # Instancia a classe Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Itera pelas formas para encontrar o placeholder
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Altera o texto em cada placeholder
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Salva a apresentação no disco
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir texto de prompt em um marcador de posição**
Layouts padrão e pré-construídos contêm textos de prompt de marcador de posição, como ***Clique para adicionar um título*** ou ***Clique para adicionar um subtítulo***. Usando o Aspose.Slides, você pode inserir seus textos de prompt preferidos nos layouts de marcadores de posição.

Este código PHP mostra como definir o texto de prompt em um marcador de posição:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Itera pelo slide
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # O PowerPoint exibe "Clique para adicionar título"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Adiciona subtítulo
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir transparência da imagem do marcador de posição**

O Aspose.Slides permite que você defina a transparência da imagem de fundo em um marcador de posição de texto. Ao ajustar a transparência da imagem em tal quadro, você pode fazer o texto ou a imagem se destacar (dependendo das cores do texto e da imagem).

Este código PHP mostra como definir a transparência para o fundo de uma imagem (dentro de uma forma):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **Perguntas frequentes**

**O que é um marcador de posição base e como ele difere de uma forma local em um slide?**

Um marcador de posição base é a forma original em um layout ou mestre que a forma do slide herda — tipo, posição e parte da formatação provêm dele. Uma forma local é independente; se não houver um marcador de posição base, a herança não se aplica.

**Como posso atualizar todos os títulos ou legendas em uma apresentação sem iterar sobre cada slide?**

Edite o marcador de posição correspondente no layout ou no mestre. Slides baseados nesses layouts/mestre herdarão automaticamente a alteração.

**Como controlo os marcadores de posição padrão de cabeçalho/rodapé — data & hora, número do slide e texto do rodapé?**

Use os gerenciadores HeaderFooter no escopo apropriado (slides normais, layouts, mestre, notas/folhetos) para ativar ou desativar esses marcadores de posição e definir seu conteúdo.