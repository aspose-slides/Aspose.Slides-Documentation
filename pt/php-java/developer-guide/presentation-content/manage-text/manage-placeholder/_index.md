---
title: Gerenciar placeholders de apresentação em PHP
linktitle: Gerenciar placeholders
type: docs
weight: 10
url: /pt/php-java/manage-placeholder/
keywords:
- espaço reservado
- placeholder de texto
- placeholder de imagem
- placeholder de gráfico
- placeholder de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e a entender a herança de placeholders com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são placeholders de título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou de um slide mestre.

Aspose.Slides expõe as informações de placeholder através do método [Shape::getPlaceholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getplaceholder/). O método devolve um objeto [Placeholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholder/) ou `null` para uma forma normal. Use [Placeholder::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholder/gettype/) para determinar o que o placeholder deve conter.

A classe da forma ainda importa depois que você conhece o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo costuma ser representado por um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [Placeholder::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholder/gettype/) quanto a classe da forma em tempo de execução, em vez de assumir que todo placeholder é um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholder/gettype/) descreve o papel de um placeholder; ele não garante a classe da forma em tempo de execução. Sempre faça uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a herança de placeholders**

Placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders no nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar do seu layout.

Chame [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getbaseplaceholder/) para subir um nível nesta hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método devolve `null` quando a forma não possui placeholder base.

O exemplo a seguir lista os placeholders no primeiro slide e relata seus placeholders base:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Editar um placeholder em um slide normal cria ou altera uma substituição local para esse slide. Editar o layout ou o mestre associado pode afetar todos os slides que ainda herdam essa configuração. Uma forma ordinária local não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se a forma é um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/gettextframe/).

Este exemplo atualiza o primeiro placeholder de título no primeiro slide e salva o resultado:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Esse padrão evita tratar placeholders de imagem, gráfico, tabela ou mídia como objetos [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/). Ele também identifica o placeholder por finalidade em vez de depender de um índice de forma frágil.

## **Definir texto de sugestão em um layout**

Texto de sugestão é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina texto de sugestão personalizado no placeholder do layout em vez de tentar acessá‑lo através da coleção de formas de um slide normal. Acesse o layout mediante [Slide::getLayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getLayoutSlide) e itere sobre a coleção devolvida por [BaseSlide::getShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getShapes).

O exemplo a seguir altera as sugestões de título e subtítulo no layout usado pelo primeiro slide:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Texto de sugestão não é conteúdo de slide normal. Ele destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Uma vez que o usuário ou programa fornece conteúdo real, a sugestão deixa de ser exibida. Alterar a sugestão também não substitui o texto existente nos slides que utilizam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a tratar:

- Se o placeholder de imagem já estiver preenchido e representado por um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/), substitua a imagem através de [PictureFillFormat::getPicture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/getpicture/) e [SlidesPicture::setImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidespicture/setimage/).
- Se ainda for um placeholder vazio, adicione um picture frame nas coordenadas do placeholder com [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addpictureframe/) e remova o placeholder vazio.

O próximo exemplo suporta ambos os casos e salva a apresentação:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A substituição criada para um placeholder vazio é um picture frame local, não um novo placeholder, porque [Shape::getPlaceholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getplaceholder/) não fornece um setter. Ela mantém a posição reservada, mas não herda mais o comportamento específico do placeholder. Se manter a relação de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, então atualize o [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) resultante com Aspose.Slides.

Para transparência, recorte e outros efeitos específicos de imagem, veja [Manage Picture Frames](/slides/pt/php-java/picture-frame/). Essas operações pertencem ao picture frame ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e de conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/). Este exemplo encontra tal gráfico tanto pelo tipo de placeholder quanto pela classe em tempo de execução, altera seu título e salva o arquivo:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Um placeholder de conteúdo geral costuma ter [PlaceholderType::Object](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspeccione a classe real da forma para descobrir o que ele contém. Layouts especializados também podem expor [PlaceholderType::Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholdertype/), ou [PlaceholderType::Diagram](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) em um [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/) apenas alterando [Placeholder::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholder/gettype/); o tipo não pode ser alterado pela classe. Para preencher programaticamente uma área vazia de gráfico ou conteúdo, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O gráfico adicionado é um gráfico local ordinário. Ele ocupa a área do placeholder, mas não herda do placeholder do layout. Use os artigos dedicados à [gestão de gráficos](/slides/pt/php-java/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo completo: atualizar texto ou imagem**

O exemplo completo a seguir abre um modelo, procura no primeiro slide um placeholder de título ou de imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente assumir um índice de forma ou tratar todos os placeholders como da mesma classe.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getbaseplaceholder/) para recuperá‑lo. Uma forma local ordinária devolve `null` porque não faz parte da hierarquia de placeholders.

**Posso alterar todos os títulos dos slides editando um placeholder de layout?**

Você pode mudar a formatação ou o texto de sugestão herdados através de um layout, mas o conteúdo do título existente está armazenado nos slides normais. Para substituir o texto do título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerencio placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo apropriado (slide, layout, mestre, notas ou folhetos). Consulte [Manage Presentation Header and Footer](/slides/pt/php-java/presentation-header-and-footer/) para exemplos completos.