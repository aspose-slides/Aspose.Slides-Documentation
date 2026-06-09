---
title: Aplicar ou Alterar Layouts de Slide em PHP
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/php-java/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- espaço reservado
- design de apresentação
- design de slide
- layout não utilizado
- visibilidade de rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie e personalize layouts de slide no Aspose.Slides for PHP via Java. Explore tipos de layout, controle de espaços reservados e visibilidade de rodapé por meio de exemplos de código."
---
## **Introdução**

Um layout de slide define a disposição das caixas de espaço reservado e a formatação do conteúdo em um slide. Ele controla quais espaços reservados estão disponíveis e onde eles aparecem. Os layouts de slide ajudam você a criar apresentações rápida e consistentemente—seja criando algo simples ou mais complexo. Alguns dos layouts de slide mais comuns no PowerPoint incluem:

**Layout de Slide de Título** – Inclui dois espaços reservados de texto: um para o título e outro para o subtítulo.

**Layout de Título e Conteúdo** – Apresenta um espaço reservado de título menor na parte superior e um maior abaixo para o conteúdo principal (como texto, marcadores, gráficos, imagens e mais).

**Layout em Branco** – Não contém espaços reservados, dando a você controle total para projetar o slide do zero.

Os layouts de slide fazem parte de um slide mestre, que é o slide de nível superior que define os estilos de layout para a apresentação. Você pode acessar e modificar os slides de layout através do slide mestre—seja pelo tipo, nome ou ID exclusivo. Alternativamente, pode editar um slide de layout específico diretamente na apresentação.

Para trabalhar com layouts de slide no Aspose.Slides for PHP, você pode usar:
- Métodos como [getLayoutSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getLayoutSlides) e [getMasters](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getMasters) na classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) 
- Tipos como [LayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/), e [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para saber mais sobre como trabalhar com slides mestres, veja o artigo [Slide Master](/slides/pt/php-java/slide-master/).
{{% /alert %}}

## **Adicionar Layouts de Slide às Apresentações**

Para personalizar a aparência e a estrutura dos seus slides, pode ser necessário adicionar novos slides de layout a uma apresentação. O Aspose.Slides for PHP permite verificar se um layout específico já existe, adicionar um novo se necessário e usá‑lo para inserir slides baseados nesse layout.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterlayoutslidecollection/).
3. Verifique se o slide de layout desejado já existe na coleção. Caso não exista, adicione o slide de layout necessário.
4. Adicione um slide vazio baseado no novo slide de layout.
5. Salve a apresentação.

O código PHP a seguir demonstra como adicionar um layout de slide a uma apresentação do PowerPoint:

```php
// Instanciar a classe Presentation que representa um arquivo PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Percorrer os tipos de slide de layout para selecionar um slide de layout.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Uma situação em que a apresentação não contém todos os tipos de layout.
        // O arquivo de apresentação contém apenas os tipos de layout Blank e Custom.
        // No entanto, slides de layout com tipos personalizados podem ter nomes reconhecíveis,
        // como "Title", "Title and Content", etc., que podem ser usados para a seleção de slides de layout.
        // Você também pode contar com um conjunto de tipos de formas de espaço reservado.
        // Por exemplo, um slide de Título deve ter apenas o tipo de espaço reservado Title, e assim por diante.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Adicionar um slide vazio usando o slide de layout adicionado.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Salvar a apresentação no disco.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Remover Slides de Layout Não Utilizados**

O Aspose.Slides fornece o método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) da classe [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/) para permitir a exclusão de slides de layout indesejados e não utilizados.

O código PHP a seguir mostra como remover um slide de layout de uma apresentação do PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Adicionar Espaços Reservados aos Layouts de Slide**

O Aspose.Slides fornece o método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#getPlaceholderManager) que permite adicionar novos espaços reservados a um slide de layout.

Este gerenciador contém métodos para os seguintes tipos de espaço reservado:

| Espaço Reservado do PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/) Método |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Conteúdo](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Conteúdo (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texto](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Texto (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Imagem](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Gráfico](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabela](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Mídia](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Imagem Online](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

```php
$presentation = new Presentation();
try {
    // Obter o slide de layout em branco.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Obter o gerenciador de espaços reservados do slide de layout.
    $placeholderManager = $layout->getPlaceholderManager();

    // Adicionar diferentes espaços reservados ao slide de layout em branco.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Adicionar um novo slide com o layout em branco.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![Os espaços reservados no slide de layout](add_placeholders.png)

## **Definir Visibilidade do Rodapé para um Slide de Layout**

Em apresentações do PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser exibidos ou ocultados dependendo do layout do slide. O Aspose.Slides for PHP permite controlar a visibilidade desses espaços reservados de rodapé. Isso é útil quando você deseja que determinados layouts exibam informações de rodapé enquanto outros permanecem limpos e minimalistas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Obtenha uma referência ao slide de layout pelo seu índice.
3. Defina o espaço reservado de rodapé do slide como visível.
4. Defina o espaço reservado de número do slide como visível.
5. Defina o espaço reservado de data/hora como visível.
6. Salve a apresentação.

O código PHP a seguir mostra como definir a visibilidade de um rodapé de slide e executar tarefas relacionadas:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Definir Visibilidade do Rodapé em Slides Filhos**

Em apresentações do PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser controlados ao nível do slide mestre para garantir consistência em todos os slides de layout. O Aspose.Slides for PHP permite definir a visibilidade e o conteúdo desses espaços reservados de rodapé no slide mestre e propagar essas configurações para todos os slides de layout filhos. Essa abordagem garante informações de rodapé uniformes em toda a sua apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Obtenha uma referência ao slide mestre pelo seu índice.
3. Defina os espaços reservados de rodapé do mestre e de todos os slides filhos como visíveis.
4. Defina os espaços reservados de número do slide do mestre e de todos os slides filhos como visíveis.
5. Defina os espaços reservados de data/hora do mestre e de todos os slides filhos como visíveis.
6. Salve a apresentação.

O código PHP a seguir demonstra essa operação:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Perguntas Frequentes**

**Qual é a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema geral e a formatação padrão, enquanto os slides de layout definem disposições específicas de espaços reservados para diferentes tipos de conteúdo.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim, você pode clonar um slide de layout da coleção de slides de layout de uma apresentação, acessível via o método [getLayoutSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getLayoutSlides), e inseri‑lo em outra apresentação usando o método `addClone`.

**O que acontece se eu excluir um slide de layout que ainda está sendo usado por um slide?**

Se você tentar excluir um slide de layout que ainda está referenciado por ao menos um slide na apresentação, o Aspose.Slides lançará uma [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxeditexception/). Para evitar isso, use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) que remove com segurança apenas os slides de layout que não estão em uso.