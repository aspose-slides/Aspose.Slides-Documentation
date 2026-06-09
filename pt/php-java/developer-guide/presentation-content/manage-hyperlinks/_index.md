---
title: Gerenciar hyperlinks de apresentação em PHP
linktitle: Gerenciar hyperlink
type: docs
weight: 20
url: /pt/php-java/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hyperlink
- criar hyperlink
- formatar hyperlink
- remover hyperlink
- atualizar hyperlink
- hyperlink de texto
- hyperlink de slide
- hyperlink de forma
- hyperlink de imagem
- hyperlink de vídeo
- hyperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie hyperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para PHP via Java com facilidade — aumente a interatividade e o fluxo de trabalho em minutos."
---
## **Introdução**

Um hyperlink é uma referência a um objeto ou dado ou a um local em algo. Estes são hyperlinks comuns em apresentações do PowerPoint:

* Links para sites dentro de textos, formas ou mídia
* Links para slides

Aspose.Slides for PHP via Java permite que você execute muitas tarefas envolvendo hyperlinks em apresentações.

{{% alert color="primary" %}} 
Você pode querer conferir o simples editor on‑line gratuito da Aspose, [editor PowerPoint on‑line gratuito.](https://products.aspose.app/slides/pt/editor)
{{% /alert %}} 

## **Adicionar hyperlinks de URL**

### **Adicionar hyperlinks de URL ao texto**

Este código PHP mostra como adicionar um hyperlink de site a um texto:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Adicionar hyperlinks de URL a formas ou quadros**

Este código de exemplo mostra como adicionar um hyperlink de site a uma forma:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Adicionar hyperlinks de URL a mídia**

Aspose.Slides permite adicionar hyperlinks a imagens, arquivos de áudio e vídeo. 

Este código de exemplo mostra como adicionar um hyperlink a uma **imagem**:

```php
  $pres = new Presentation();
  try {
    # Adiciona imagem à apresentação
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Cria quadro de imagem no slide 1 com base na imagem adicionada anteriormente
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este código de exemplo mostra como adicionar um hyperlink a um **arquivo de áudio**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este código de exemplo mostra como adicionar um hyperlink a um **vídeo**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 
Talvez você queira ver *[Gerenciar OLE](/slides/pt/php-java/manage-ole/)*.
{{% /alert %}}

## **Usar hyperlinks para criar uma tabela de conteúdos**

Como os hyperlinks permitem adicionar referências a objetos ou locais, você pode usá‑los para criar uma tabela de conteúdos. 

Este código de exemplo mostra como criar uma tabela de conteúdos com hyperlinks:

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formatar hyperlinks**

### **Cor**

Com o método [setColorSource](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/setcolorsource/) na classe [Hyperlink](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/), você pode definir a cor dos hyperlinks e também obter informações de cor dos hyperlinks. O recurso foi introduzido pela primeira vez no PowerPoint 2019, portanto alterações envolvendo a propriedade não se aplicam a versões mais antigas do PowerPoint.

Este código de exemplo demonstra uma operação em que hyperlinks com cores diferentes foram adicionados ao mesmo slide:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover hyperlinks de apresentações**

### **Remover hyperlinks de texto**

Este código PHP mostra como remover o hyperlink de um texto em um slide da apresentação:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Remover hyperlinks de formas ou quadros**

Este código PHP mostra como remover o hyperlink de uma forma em um slide da apresentação:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hyperlink mutável**

A classe [Hyperlink](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/) é mutável. Com esta classe, você pode alterar os valores dessas propriedades:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

O trecho de código mostra como adicionar um hyperlink a um slide e editar seu tooltip posteriormente:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Propriedades suportadas em IHyperlinkQueries**

Você pode acessar [HyperlinkQueries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/) a partir de uma apresentação, slide ou texto para o qual o hyperlink está definido.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/gethyperlinkqueries/)

A classe [HyperlinkQueries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/) oferece esses métodos e propriedades:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Como posso criar navegação interna não apenas para um slide, mas para uma “seção” ou o primeiro slide de uma seção?**

Seções no PowerPoint são agrupamentos de slides; a navegação tecnicamente aponta para um slide específico. Para “navegar para uma seção”, normalmente você vincula ao seu primeiro slide.

**Posso anexar um hyperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos do slide mestre e dos layouts suportam hyperlinks. Esses links aparecem nos slides filhos e são clicáveis durante a apresentação.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Em [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/php-java/convert-powerpoint-to-html/), sim—os links geralmente são preservados. Ao exportar para [imagens](/slides/pt/php-java/convert-powerpoint-to-png/) e [vídeo](/slides/pt/php-java/convert-powerpoint-to-video/), a capacidade de clique não será mantida devido à natureza desses formatos (quadros raster/vídeo não suportam hyperlinks).