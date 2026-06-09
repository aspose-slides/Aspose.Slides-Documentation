---
title: Mesclar Apresentações de Forma Eficiente em PHP
linktitle: Mesclar Apresentações
type: docs
weight: 40
url: /pt/php-java/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- PHP
- Aspose.Slides
description: "Mescle apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP) de forma simples com Aspose.Slides for PHP via Java, otimizando seu fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite mesclar apresentações clonando slides de uma apresentação para outra. Este artigo explica como mesclar apresentações completas ou slides selecionados, usar um mestre de slides ou um layout específico durante a mesclagem, lidar com apresentações com tamanhos de slide diferentes e adicionar slides mesclados a uma seção de apresentação. Também cobre observações práticas relacionadas ao conteúdo mesclado, incluindo notas do apresentador, comentários, arquivos de origem protegidos por senha e uso de threads.

## **Mesclagem de Apresentações**

Quando você mescla uma apresentação a outra, está efetivamente combinando seus slides em uma única apresentação para obter um único arquivo. 

{{% alert title="Info" color="info" %}}
A maioria dos programas de apresentação (PowerPoint ou OpenOffice) não possui funções que permitam aos usuários combinar apresentações dessa forma. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/pt/php-java/), no entanto, permite mesclar apresentações de diferentes maneiras. Você pode mesclar apresentações com todas as suas formas, estilos, textos, formatação, comentários, animações, etc., sem se preocupar com perda de qualidade ou dados.

**Veja também**

[Clonar Slides](/slides/pt/php-java/clone-slides/).

{{% /alert %}}

### **O que pode ser mesclado**

Com Aspose.Slides, você pode mesclar 

* apresentações completas. Todos os slides das apresentações terminam em uma única apresentação
* slides específicos. Slides selecionados terminam em uma única apresentação
* apresentações em um mesmo formato (PPT para PPT, PPTX para PPTX, etc.) e em formatos diferentes (PPT para PPTX, PPTX para ODP, etc.) entre si. 

{{% alert title="Nota" color="warning" %}} 

Além de apresentações, Aspose.Slides permite mesclar outros arquivos:

* [Imagens](https://products.aspose.com/slides/pt/php-java/merger/image-to-image/), como [JPG para JPG](https://products.aspose.com/slides/pt/php-java/merger/jpg-to-jpg/) ou [PNG para PNG](https://products.aspose.com/slides/pt/php-java/merger/png-to-png/)
* Documentos, como [PDF para PDF](https://products.aspose.com/slides/pt/php-java/merger/pdf-to-pdf/) ou [HTML para HTML](https://products.aspose.com/slides/pt/php-java/merger/html-to-html/)
* E dois arquivos diferentes, como [imagem para PDF](https://products.aspose.com/slides/pt/php-java/merger/image-to-pdf/) ou [JPG para PDF](https://products.aspose.com/slides/pt/php-java/merger/jpg-to-pdf/) ou [TIFF para PDF](https://products.aspose.com/slides/pt/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opções de mesclagem**

Você pode aplicar opções que determinam se

* cada slide na apresentação de saída mantém um estilo exclusivo
* um estilo específico é usado para todos os slides na apresentação de saída. 

Para mesclar apresentações, Aspose.Slides fornece os métodos [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) (da classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/) ). Existem várias implementações dos métodos `addClone` que definem os parâmetros do processo de mesclagem de apresentações. Cada objeto Presentation tem uma coleção de [slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getslides/), de modo que você pode chamar um método `addClone` a partir da apresentação na qual deseja mesclar slides.

O método `addClone` retorna um objeto `Slide`, que é um clone do slide de origem. Os slides em uma apresentação de saída são simplesmente uma cópia dos slides da origem. Portanto, você pode fazer alterações nos slides resultantes (por exemplo, aplicar estilos ou opções de formatação ou layouts) sem se preocupar com a afetar as apresentações de origem. 

## **Mesclar Apresentações** 

Aspose.Slides fornece o método [addClone(Slide)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) que permite combinar slides enquanto eles mantêm seus layouts e estilos (parâmetros padrão).

Este código PHP mostra como mesclar apresentações:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Mesclar Apresentações com um Mestre de Slides**

Aspose.Slides fornece o método [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) que permite combinar slides aplicando um modelo de mestre de slides. Dessa forma, se necessário, você pode alterar o estilo dos slides na apresentação de saída.

Este código demonstra a operação descrita:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Nota" color="warning" %}} 

O layout do slide para o mestre de slides é determinado automaticamente. Quando um layout apropriado não pode ser determinado, se o parâmetro booleano `allowCloneMissingLayout` do método `addClone` estiver definido como true, o layout do slide de origem será usado. Caso contrário, [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PptxEditException) será lançada.

{{% /alert %}}

Se você quiser que os slides na apresentação de saída tenham um layout de slide diferente, use o método [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) em vez disso ao mesclar.

## **Mesclar Slides Específicos de Apresentações**

Mesclar slides específicos de várias apresentações é útil para criar decks de slides personalizados. Aspose.Slides for PHP via Java permite selecionar e importar apenas os slides de que você precisa. A API preserva a formatação, o layout e o design dos slides originais.

O seguinte código PHP cria uma nova apresentação, adiciona slides de título de duas outras apresentações e salva o resultado em um arquivo:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Mesclar Apresentações com um Layout de Slide**

Este código PHP mostra como combinar slides de apresentações aplicando o layout de slide preferido a eles para obter uma apresentação de saída única:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Mesclar Apresentações com Tamanhos de Slide Diferentes**

{{% alert title="Nota" color="warning" %}} 

Você não pode mesclar apresentações com tamanhos de slide diferentes. 

{{% /alert %}}

Para mesclar 2 apresentações com tamanhos de slide diferentes, você precisa redimensionar uma das apresentações para que seu tamanho corresponda ao da outra apresentação. 

Este código de exemplo demonstra a operação descrita:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Mesclar Slides em uma Seção de Apresentação**

Este código PHP mostra como mesclar um slide específico a uma seção em uma apresentação:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

O slide é adicionado ao final da seção. 

## **Veja Também**


Aspose fornece um [Criador de Colagem Online GRATUITO](https://products.aspose.app/slides/pt/collage). Usando este serviço online, você pode mesclar [JPG para JPG](https://products.aspose.app/slides/pt/collage/jpg) ou imagens PNG para PNG, criar [grades de fotos](https://products.aspose.app/slides/pt/collage/photo-grid) e muito mais.

Confira o [Mesclador Online GRATUITO da Aspose](https://products.aspose.app/slides/pt/merger). Ele permite mesclar apresentações PowerPoint no mesmo formato (por exemplo, PPT para PPT, PPTX para PPTX) ou entre formatos diferentes (por exemplo, PPT para PPTX, PPTX para ODP).

[![Aspose Mesclador Online GRATUITO](slides-merger.png)](https://products.aspose.app/slides/pt/merger)

## **FAQ**

**Existem limitações quanto ao número de slides ao mesclar apresentações?**

Não há limitações rígidas. Aspose.Slides pode lidar com arquivos grandes, mas o desempenho depende do tamanho e dos recursos do sistema. Para apresentações muito grandes, recomenda‑se usar uma JVM de 64 bits e alocar memória heap suficiente.

**Posso mesclar apresentações com vídeo ou áudio incorporados?**

Sim, Aspose.Slides preserva o conteúdo multimídia incorporado nos slides, mas a apresentação final pode ficar significativamente maior.

**As fontes serão preservadas ao mesclar apresentações?**

Sim. As fontes usadas nas apresentações de origem são preservadas no arquivo de saída, assumindo que estejam instaladas no sistema ou [incorporadas](/slides/pt/php-java/embedded-font/).