---
title: Otimizar o Gerenciamento de Imagens em Apresentações Usando PHP
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/php-java/image/
keywords:
- adicionar imagem
- adicionar foto
- adicionar bitmap
- substituir imagem
- substituir foto
- da web
- fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- adicionar EMF
- adicionar WMF
- adicionar TIFF
- PowerPoint
- OpenDocument
- apresentação
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Simplifique o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides para PHP via Java, otimizando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

Imagens tornam as apresentações mais envolventes e interessantes. No Microsoft PowerPoint, você pode inserir imagens a partir de um arquivo, da internet ou de outros locais nos slides. Da mesma forma, o Aspose.Slides permite adicionar imagens aos slides em suas apresentações por meio de diferentes procedimentos. 

{{% alert  title="Tip" color="primary" %}} 

A Aspose fornece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se você quiser adicionar uma imagem como um objeto de quadro—especialmente se planeja usar opções padrão de formatação para alterar seu tamanho, adicionar efeitos etc.—veja [Quadro de Imagem](/slides/pt/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Você pode manipular operações de entrada/saída envolvendo imagens e apresentações do PowerPoint para converter uma imagem de um formato para outro. Veja estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/php-java/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/php-java/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/php-java/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/php-java/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/php-java/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/php-java/conversion/svg-to-png/).

{{% /alert %}}

O Aspose.Slides suporta operações com imagens nesses formatos populares: JPEG, PNG, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou várias imagens do seu computador a um slide em uma apresentação. Este código de exemplo mostra como adicionar uma imagem a um slide:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar Imagens da Web aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver disponível no seu computador, você pode adicioná‑la diretamente da web. 

Este código de exemplo mostra como adicionar uma imagem da web a um slide:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar Imagens a Mestres de Slides**

Um mestre de slide é o slide principal que armazena e controla informações (tema, layout, etc.) sobre todos os slides abaixo dele. Portanto, quando você adiciona uma imagem a um mestre de slide, essa imagem aparece em todos os slides sob esse mestre. 

Este código de exemplo Java mostra como adicionar uma imagem a um mestre de slide:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar Imagens como Fundos de Slides**

Você pode decidir usar uma imagem como fundo de um slide específico ou de vários slides. Nesse caso, veja como [Definir uma Imagem como Fundo de Slide](/slides/pt/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **Adicionar SVG às Apresentações**
Você pode adicionar ou inserir qualquer imagem em uma apresentação usando o método [addPictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addpictureframe/) que pertence à classe [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/).

Para criar um objeto de imagem baseado em imagem SVG, você pode fazer assim:

1. Criar objeto SvgImage para inseri‑lo na ImageShapeCollection
2. Criar objeto PPImage a partir de ISvgImage
3. Criar objeto PictureFrame usando a classe PPImage

Este código de exemplo mostra como implementar as etapas acima para adicionar uma imagem SVG em uma apresentação:
```php
  # Instanciar a classe Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Converter SVG para um Conjunto de Formas**
A conversão de SVG para um conjunto de formas do Aspose.Slides é semelhante à funcionalidade do PowerPoint usada para trabalhar com imagens SVG:

![PowerPoint Popup Menu](img_01_01.png)

A funcionalidade é fornecida por uma das sobrecargas do método [addGroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addgroupshape/) da classe [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/) que aceita um objeto [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/) como primeiro argumento.

Este código de exemplo mostra como usar o método descrito para converter um arquivo SVG em um conjunto de formas:

```php
  # Criar nova apresentação
  $presentation = new Presentation();
  try {
    # Ler conteúdo do arquivo SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Criar objeto SvgImage
    $svgImage = new SvgImage($svgContent);
    # Obter tamanho do slide
    $slideSize = $presentation->getSlideSize()->getSize();
    # Converter imagem SVG em grupo de formas dimensionando-a ao tamanho do slide
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Salvar a apresentação no formato PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Adicionar Imagens como EMF aos Slides**
O Aspose.Slides para PHP via Java permite gerar imagens EMF a partir de planilhas Excel e adicionar as imagens como EMF em slides com o Aspose.Cells. 

Este código de exemplo mostra como executar a tarefa descrita:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Salvar a pasta de trabalho no stream
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Substituir Imagens na Coleção de Imagens**

O Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação (incluindo as usadas por formas de slide). Esta seção mostra várias abordagens para atualizar imagens na coleção. A API fornece métodos simples para substituir uma imagem usando dados brutos de bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) ou outra imagem que já exista na coleção.

Siga os passos abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Carregue uma nova imagem de um arquivo em um array de bytes.
3. Substitua a imagem alvo pela nova imagem usando o array de bytes.
4. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
5. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
6. Grave a apresentação modificada como um arquivo PPTX.

```php
// Instanciar a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation("sample.pptx");
try {
    // A primeira maneira.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // A segunda maneira.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // A terceira maneira.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Salvar a apresentação em um arquivo.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Usando o conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose, você pode animar textos facilmente, criar GIFs a partir de textos etc. 

{{% /alert %}}

## **Perguntas Frequentes**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como a [imagem](/slides/pt/php-java/picture-frame/) é escalada no slide e de qualquer compressão aplicada ao salvar.

**Qual é a melhor forma de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑lo na coleção de imagens da apresentação—as atualizações serão propagadas para todos os elementos que utilizam esse recurso.

**É possível converter um SVG inserido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o que as partes individuais tornam‑se editáveis com as propriedades padrão de formas.

**Como posso definir uma imagem como fundo de vários slides de uma vez?**

[Atribua a imagem como fundo](/slides/pt/php-java/presentation-background/) no slide mestre ou no layout relevante—qualquer slide que usar esse mestre/layout herdará o fundo.

**Como impedir que a apresentação aumente de tamanho devido a muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicados, escolha resoluções razoáveis, apllique compressão ao salvar e mantenha os gráficos repetidos no mestre quando apropriado.