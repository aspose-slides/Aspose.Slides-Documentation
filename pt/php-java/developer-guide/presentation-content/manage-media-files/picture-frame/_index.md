---
title: Gerenciar Quadros de Imagem em Apresentações Usando PHP
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/php-java/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- adicionar imagem
- criar imagem
- extrair imagem
- imagem raster
- imagem vetorial
- cortar imagem
- área recortada
- propriedade StretchOff
- formatação de quadro de imagem
- propriedades de quadro de imagem
- escala relativa
- efeito de imagem
- proporção de aspecto
- transparência da imagem
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Adicione quadros de imagem a apresentações PowerPoint e OpenDocument com Aspose.Slides para PHP via Java. Otimize seu fluxo de trabalho e melhore o design dos slides."
---
## **Introdução**

Um quadro de imagem é uma forma que contém uma imagem — é como uma foto em uma moldura.  

Você pode adicionar uma imagem a um slide por meio de um quadro de imagem. Dessa forma, você formata a imagem formatando o quadro de imagem.

{{% alert  title="Tip" color="primary" %}} 
A Aspose oferece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem que as pessoas criem apresentações rapidamente a partir de imagens. 
{{% /alert %}} 

## **Criar um Quadro de Imagem**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).  
2. Obtenha a referência de um slide através de seu índice.  
3. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) adicionando uma imagem à [ImageCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) associada ao objeto de apresentação que será usado para preencher a forma.  
4. Especifique a largura e a altura da imagem.  
5. Crie um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) com base na largura e altura da imagem por meio do método `addPictureFrame` exposto pelo objeto de forma associado ao slide referenciado.  
6. Adicione um quadro de imagem (contendo a foto) ao slide.  
7. Grave a apresentação modificada como um arquivo PPTX.  

Este código PHP mostra como criar um quadro de imagem:

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia a classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Adiciona um quadro de imagem com a altura e largura equivalentes à da imagem
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Grava o arquivo PPTX no disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Quadros de imagem permitem criar rapidamente slides de apresentação baseados em imagens. Quando você combina um quadro de imagem com as opções de salvamento do Aspose.Slides, pode manipular operações de entrada/saída para converter imagens de um formato para outro. Você pode querer ver estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/php-java/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/php-java/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/php-java/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/php-java/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/php-java/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Criar um Quadro de Imagem com Escala Relativa**

Alterando a escala relativa de uma imagem, você pode criar um quadro de imagem mais elaborado.  

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).  
2. Obtenha a referência de um slide através de seu índice.  
3. Adicione uma imagem à coleção de imagens da apresentação.  
4. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) adicionando uma imagem à [ImageCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) associada ao objeto de apresentação que será usado para preencher a forma.  
5. Especifique a largura e a altura relativas da imagem no quadro de imagem.  
6. Grave a apresentação modificada como um arquivo PPTX.  

Este código PHP mostra como criar um quadro de imagem com escala relativa:

```php
  # Instancia a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia a classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Adiciona Quadro de Imagem com altura e largura equivalentes à Imagem
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Definindo escala relativa de largura e altura
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Grava o arquivo PPTX no disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extrair Imagens Rasterizadas de Quadros de Imagem**

Você pode extrair imagens rasterizadas de objetos [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) e salvá‑las em PNG, JPG e outros formatos. O exemplo de código abaixo demonstra como extrair uma imagem do documento “sample.pptx” e salvá‑la em formato PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Extrair Imagens SVG de Quadros de Imagem**

Quando uma apresentação contém gráficos SVG inseridos em formas [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/), o Aspose.Slides para PHP via Java permite recuperar as imagens vetoriais originais com total fidelidade. Ao percorrer a coleção de formas do slide, você pode identificar cada [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/), verificar se o [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) subjacente contém conteúdo SVG e então salvar essa imagem em disco ou em um fluxo no seu formato SVG nativo.

O exemplo de código a seguir demonstra como extrair uma imagem SVG de um quadro de imagem:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Obter Transparência de uma Imagem**

O Aspose.Slides permite obter o efeito de transparência aplicado a uma imagem. Este código PHP demonstra a operação:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Obter Brilho e Contraste de uma Imagem**

O Aspose.Slides permite obter os efeitos de brilho e contraste aplicados a uma imagem. A classe [Luminance](https://reference.aspose.com/slides/pt/php-java/aspose.slides/luminance/) representa esse efeito de transformação de imagem.

Este código PHP demonstra como obter as configurações de brilho e contraste de um quadro de imagem:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Formatação de Quadro de Imagem**

O Aspose.Slides oferece muitas opções de formatação que podem ser aplicadas a um quadro de imagem. Usando essas opções, você pode alterar um quadro de imagem para que ele atenda a requisitos específicos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).  
2. Obtenha a referência de um slide através de seu índice.  
3. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) adicionando uma imagem à [ImageCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) associada ao objeto de apresentação que será usado para preencher a forma.  
4. Especifique a largura e a altura da imagem.  
5. Crie um `PictureFrame` com base na largura e altura da imagem por meio do método [addPictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addpictureframe/) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/) associado ao slide referenciado.  
6. Adicione o quadro de imagem (contendo a foto) ao slide.  
7. Defina a cor da linha do quadro de imagem.  
8. Defina a espessura da linha do quadro de imagem.  
9. Gire o quadro de imagem fornecendo um valor positivo ou negativo.  
   * Um valor positivo gira a imagem no sentido horário.  
   * Um valor negativo gira a imagem no sentido anti‑horário.  
10. Adicione novamente o quadro de imagem (contendo a foto) ao slide.  
11. Grave a apresentação modificada como um arquivo PPTX.  

Este código PHP demonstra o processo de formatação de quadro de imagem:

```php
  # Instancia a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Instancia a classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Adiciona Quadro de Imagem com altura e largura equivalentes à Imagem
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Aplica alguma formatação ao PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Grava o arquivo PPTX no disco
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
A Aspose desenvolveu recentemente um [Criador de Colagens gratuito](https://products.aspose.app/slides/pt/collage). Se você precisar [mesclar JPG/JPEG](https://products.aspose.app/slides/pt/collage/jpg) ou imagens PNG, [criar grades a partir de fotos](https://products.aspose.app/slides/pt/collage/photo-grid), pode usar este serviço. 
{{% /alert %}}

## **Adicionar uma Imagem como Link**

Para evitar tamanho excessivo das apresentações, você pode adicionar imagens (ou vídeos) por meio de links em vez de incorporar os arquivos diretamente nas apresentações. Este código PHP mostra como adicionar uma imagem e um vídeo a um placeholder:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Cortar Imagens**

Este código PHP mostra como cortar uma imagem existente em um slide:

```php
  $pres = new Presentation();
  # Cria novo objeto de imagem
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Adiciona um Quadro de Imagem a um Slide
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Recorta a imagem (valores em porcentagem)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Salva o resultado
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Excluir Áreas Cortadas de um Quadro**

Se desejar excluir as áreas cortadas de uma imagem contida em um quadro, você pode usar o método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Esse método retorna a imagem recortada ou a imagem original se o recorte for desnecessário.

Este código PHP demonstra a operação:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Obtém o PictureFrame do primeiro slide
    $picFrame = $slide->getShapes()->get_Item(0);
    # Exclui as áreas recortadas da imagem do PictureFrame e retorna a imagem recortada
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Salva o resultado
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
O método [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) adiciona a imagem recortada à coleção de imagens da apresentação. Se a imagem for usada apenas no [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) processado, essa configuração pode reduzir o tamanho da apresentação. Caso contrário, o número de imagens na apresentação resultante aumentará.  

Esse método converte arquivos metafile WMF/EMF em imagem raster PNG durante a operação de recorte. 
{{% /alert %}}

## **Compactar Imagens**

Você pode compactar uma imagem em uma apresentação usando o método [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Esse método comprime uma imagem reduzindo seu tamanho com base no tamanho da forma e na resolução especificada, com a opção de excluir áreas recortadas.  

Ele ajusta o tamanho e a resolução da imagem de forma semelhante ao recurso **Formato da Imagem → Compactar Imagens → Resolução** do PowerPoint.  

Os exemplos PHP a seguir demonstram como compactar uma imagem em uma apresentação especificando uma resolução alvo e, opcionalmente, removendo áreas recortadas:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Compacta a imagem com resolução alvo de 150 DPI (resolução Web) e remove áreas recortadas.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Verifica o resultado da compactação.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ou usando diretamente um valor DPI personalizado:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Compacta a imagem para 150 DPI (resolução web), removendo áreas recortadas.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
O método converte a imagem para uma resolução inferior com base no tamanho da forma e no DPI fornecido. Regiões recortadas também podem ser excluídas para otimizar o tamanho do arquivo.  
Se a imagem for um metafile (WMF/EMF) ou SVG, a compressão não será aplicada. Além disso, a qualidade do JPEG é preservada ou ligeiramente reduzida de acordo com a resolução, semelhante ao tratamento de JPEGs de alta resolução pelo PowerPoint. 
{{% /alert %}}

## **Bloquear Proporção de Aspecto**

Se desejar que uma forma contendo uma imagem mantenha sua proporção de aspecto mesmo após alterar as dimensões da imagem, você pode usar o método [setAspectRatioLocked](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) para definir a configuração *Lock Aspect Ratio*.  

Este código PHP mostra como bloquear a proporção de aspecto de uma forma:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # definir que a forma preserve a proporção ao redimensionar
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Essa configuração *Lock Aspect Ratio* preserva apenas a proporção da forma e não da imagem que ela contém. 
{{% /alert %}}

## **Usar a Propriedade StretchOff**

Usando os métodos [setStretchOffsetLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) e [setStretchOffsetBottom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/), você pode especificar um retângulo de preenchimento.  

Quando o alongamento é especificado para uma imagem, um retângulo de origem é dimensionado para caber no retângulo de preenchimento especificado. Cada borda do retângulo de preenchimento é definida por um deslocamento percentual a partir da borda correspondente da caixa delimitadora da forma. Um percentual positivo indica um recuo, enquanto um percentual negativo indica um deslocamento outward.  

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) class.  
2. Obtenha a referência de um slide através de seu índice.  
3. Adicione um retângulo `AutoShape`.  
4. Crie uma imagem.  
5. Defina o tipo de preenchimento da forma.  
6. Defina o modo de preenchimento de imagem da forma.  
7. Adicione uma imagem de preenchimento à forma.  
8. Especifique os deslocamentos da imagem a partir da borda correspondente da caixa delimitadora da forma.  
9. Grave a apresentação modificada como um arquivo PPTX.  

Este código PHP demonstra um processo que utiliza a propriedade StretchOff:

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Instancia a classe ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Adiciona um AutoShape configurado como Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Define o tipo de preenchimento da forma
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Define o modo de preenchimento da imagem da forma
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Define a imagem para preencher a forma
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Especifica os deslocamentos da imagem a partir da borda correspondente da caixa delimitadora da forma
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Grava o arquivo PPTX no disco
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Como posso descobrir quais formatos de imagem são suportados para PictureFrame?**  
O Aspose.Slides suporta tanto imagens raster (PNG, JPEG, BMP, GIF, etc.) quanto imagens vetoriais (por exemplo, SVG) por meio do objeto de imagem atribuído a um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/). A lista de formatos suportados geralmente coincide com as capacidades do mecanismo de conversão de slides e imagens.

**Como a inserção de dezenas de imagens grandes afetará o tamanho e o desempenho do PPTX?**  
Incorporar imagens grandes aumenta o tamanho do arquivo e o uso de memória; vincular imagens ajuda a manter o tamanho da apresentação reduzido, mas requer que os arquivos externos permaneçam acessíveis. O Aspose.Slides fornece a capacidade de adicionar imagens por link para reduzir o tamanho do arquivo.

**Como posso bloquear um objeto de imagem contra movimentação/redimensionamento acidental?**  
Use [travas de forma](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/getpictureframelock/) para um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) (por exemplo, desabilitar movimentação ou redimensionamento). O mecanismo de bloqueio é suportado para vários tipos de forma, incluindo [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/).

**A fidelidade vetorial do SVG é preservada ao exportar uma apresentação para PDF/imagens?**  
O Aspose.Slides permite extrair um SVG de um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) como o vetor original. Ao [exportar para PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/) ou [formatos raster](/slides/pt/php-java/convert-powerpoint-to-png/), o resultado pode ser rasterizado dependendo das configurações de exportação; o fato de o SVG original ser armazenado como vetor é confirmado pelo comportamento de extração.