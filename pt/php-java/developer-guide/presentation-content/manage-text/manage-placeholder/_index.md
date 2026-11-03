---
title: Gerenciar Placeholders de Apresentação em PHP
linktitle: Gerenciar Placeholders
type: docs
weight: 10
url: /pt/php-java/manage-placeholder/
keywords:
- placeholder
- placeholder de texto
- placeholder de imagem
- placeholder de gráfico
- placeholder de conteúdo
- texto de prompt
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e entender a herança de placeholders com Aspose.Slides para PHP via Java."
---
## **Visão Geral**

Um placeholder é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe as informações de placeholder através do método [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/). O método devolve um objeto [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) ou `null` para uma forma normal. Use [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) para determinar o que o placeholder deve conter.

A classe da forma ainda importa depois de conhecer o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo é comumente representado por um [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) quanto a classe da forma em tempo de execução, em vez de presumir que todo placeholder é um [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) descreve o papel de um placeholder; ele não garante a classe da forma em tempo de execução. Sempre faça uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a Herança de Placeholder**

Os placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders daquele slide e pode herdar do seu layout.

Chame [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) para subir um nível nessa hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método devolve `null` quando a forma não possui placeholder base.

O exemplo a seguir lista os placeholders do primeiro slide e relata seus placeholders base:

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

Editar um placeholder em um slide normal cria ou altera uma substituição local para esse slide. Editar o layout ou o mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma ordinária local não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Remover o Status de Placeholder**

Ao adaptar um modelo, use [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) para manter um objeto existente como uma forma comum. Seu método [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) devolve `null`, mas a forma permanece na coleção do slide. Em contraste, [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) exclui a forma dessa coleção.

O exemplo a seguir requer `template.pptx` com ao menos um slide e um placeholder de texto não vazio no primeiro slide. Use um placeholder com formatação herdada do seu layout ou mestre para observar o efeito de remover esse relacionamento. O exemplo verifica que a mesma forma permanece, chama o método novamente na forma agora comum e salva o resultado.

{{% alert color="warning" title="Warning" %}}
Remover o status de placeholder não preserva automaticamente as configurações de aparência herdadas. O exemplo abaixo deixa deliberadamente essas configurações inalteradas, de modo que a saída pode parecer diferente. Uma forma cuja posição e tamanho são totalmente herdados pode ter coordenadas e dimensões zero após a chamada e tornar‑se invisível, embora continue na coleção.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Chamando o método em uma forma comum não tem efeito.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Para um placeholder correspondente, as três verificações imprimem `true`. O texto permanece, mas posição, tamanho, rotação, fonte, alinhamento de parágrafo, margens da caixa de texto, ancoragem vertical, preenchimento e configurações de linha herdadas podem mudar quando o relacionamento de placeholder é removido. Por exemplo, a formatação de título herdada pode retroceder para a formatação de texto comum. Consulte [Slide Layout](/slides/pt/php-java/slide-layout/) para mais informações sobre layouts.

Para preservar a aparência pretendida, capture a posição, tamanho e rotação resolvidos antes da chamada e copie os valores de formatação efetiva necessários para variáveis separadas. Recupere esses valores através de [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), e [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). Não confie apenas nos objetos de formatação efetiva, pois seus valores de formatação de texto podem mudar após a remoção do relacionamento. Aplique explicitamente os valores capturados à forma comum posteriormente, incluindo família da fonte, tamanho, estilo, cor, configurações de parágrafo, configurações da caixa de texto, preenchimento e linha usados pelo seu modelo.

A geometria da forma herdada também pode precisar ser atribuída explicitamente através de [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). Para um placeholder de texto retangular, isso significa atribuir [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); restaurar apenas o preenchimento e a linha pode não restaurar o retângulo visível. Modelos com efeitos adicionais ou formatação mais complexa exigem que essas configurações sejam tratadas também.

## **Alterar Texto em um Placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se a forma é um [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/).

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

Esse padrão evita tratar placeholders de imagem, gráfico, tabela ou mídia como objetos [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Ele também identifica o placeholder por finalidade em vez de depender de um índice de forma frágil.

## **Definir Texto de Prompt em um Layout**

Texto de prompt é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina texto de prompt personalizado no placeholder do layout em vez de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout via [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) e itere sobre a coleção devolvida por [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes).

O exemplo a seguir altera os prompts de título e subtítulo no layout usado pelo primeiro slide:

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

Texto de prompt não é conteúdo de slide normal. Ele é destinado a placeholders vazios em aplicações de edição como o PowerPoint. Uma vez que um usuário ou programa fornece conteúdo real, o prompt deixa de ser exibido. Alterar um prompt também não substitui texto existente nos slides que utilizam o layout.

## **Atualizar um Placeholder de Imagem**

Existem dois casos a serem tratados:

- Se o placeholder de imagem já estiver preenchido e representado por um [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), substitua a imagem através de [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) e [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- Se ainda for um placeholder vazio, adicione um quadro de imagem nas coordenadas do placeholder com [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) e remova o placeholder vazio.

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

A substituição criada para um placeholder vazio é um quadro de imagem local, não um novo placeholder, porque [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) não fornece um setter. Ele mantém a posição reservada, mas não herda mais o comportamento específico de placeholder. Se manter o relacionamento de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, depois atualize o [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Manage Picture Frames](/slides/pt/php-java/picture-frame/). Essas operações pertencem ao quadro de imagem ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com Placeholders de Gráfico e Conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). Este exemplo localiza tal gráfico tanto pelo tipo de placeholder quanto pela classe em tempo de execução, altera seu título e salva o arquivo:

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

Um placeholder de conteúdo geral costuma ter [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). No PowerPoint ele atua como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspecione a classe real da forma para saber o que contém. Layouts especializados também podem expor [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), ou [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) em um [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) apenas alterando [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/); o tipo não pode ser alterado via classe. Para preencher programaticamente uma área de gráfico ou conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

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

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder do layout. Use os artigos dedicados à [gestão de gráficos](/slides/pt/php-java/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo Completo: Atualizar Texto ou Conteúdo de Imagem**

O exemplo de ponta a ponta a seguir abre um modelo, procura no primeiro slide por um placeholder de título ou imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva a saída. O exemplo evita deliberadamente supor um índice de forma ou tratar todos os placeholders como da mesma classe.

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

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) para recuperá‑lo. Uma forma local comum devolve `null` porque não faz parte da hierarquia de placeholders.

**Posso alterar todos os títulos dos slides editando um placeholder de layout?**

É possível mudar a formatação herdada ou o texto de prompt através de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real de título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerenciar placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo apropriado: slide, layout, mestre, notas ou folhetos. Consulte [Manage Presentation Header and Footer](/slides/pt/php-java/presentation-header-and-footer/) para exemplos completos.