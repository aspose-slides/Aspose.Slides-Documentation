---
title: Aplicar ou Alterar Layouts de Slide em C++
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/cpp/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- marcador de posição
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
- C++
- Aspose.Slides
description: "Gerencie e personalize layouts de slide no Aspose.Slides para C++. Explore tipos de layout, controle de marcadores de posição e visibilidade de rodapé através de exemplos de código C++."
---
## **Introdução**

Um layout de slide define a disposição das caixas de marcador de posição e a formatação do conteúdo em um slide. Ele controla quais marcadores de posição estão disponíveis e onde eles aparecem. Os layouts de slide ajudam você a criar apresentações rapidamente e de forma consistente—seja criando algo simples ou mais complexo. Alguns dos layouts de slide mais comuns no PowerPoint incluem:

**Layout de Slide de Título** – Inclui dois marcadores de posição de texto: um para o título e outro para o subtítulo.

**Layout de Título e Conteúdo** – Apresenta um marcador de posição de título menor na parte superior e um maior abaixo para o conteúdo principal (como texto, marcadores, gráficos, imagens e mais).

**Layout em Branco** – Não contém marcadores de posição, dando a você controle total para criar o slide do zero.

Os layouts de slide fazem parte de um slide mestre, que é o slide de nível superior que define os estilos de layout para a apresentação. Você pode acessar e modificar os layouts de slide através do slide mestre—seja pelo tipo, nome ou ID exclusivo. Alternativamente, pode editar um layout de slide específico diretamente na apresentação.

Para trabalhar com layouts de slide no Aspose.Slides for Android, você pode usar:

- Métodos como [get_LayoutSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_layoutslides/) e [get_Masters](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_masters/) na classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) 
- Tipos como [ILayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/), e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para saber mais sobre como trabalhar com slides mestres, confira o artigo [Slide Master](/slides/pt/cpp/slide-master/).
{{% /alert %}}

## **Adicionar Layouts de Slide às Apresentações**

Para personalizar a aparência e a estrutura dos seus slides, pode ser necessário adicionar novos layouts de slide a uma apresentação. O Aspose.Slides for Android permite verificar se um layout específico já existe, adicionar um novo se necessário e usá‑lo para inserir slides com base nesse layout.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterlayoutslidecollection/).
3. Verifique se o layout de slide desejado já existe na coleção. Caso não exista, adicione o layout de slide necessário.
4. Adicione um slide vazio baseado no novo layout de slide.
5. Salve a apresentação.

O código C++ a seguir demonstra como adicionar um layout de slide a uma apresentação PowerPoint:

```cpp
// Instanciar a classe Presentation que representa um arquivo PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Percorrer os tipos de layout de slide para selecionar um layout de slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Uma situação em que a apresentação não contém todos os tipos de layout.
    // O arquivo de apresentação contém apenas os tipos de layout Blank e Custom.
    // No entanto, slides de layout com tipos personalizados podem ter nomes reconhecíveis,
    // como "Title", "Title and Content", etc., que podem ser usados para a seleção de layout de slide.
    // Você também pode basear-se em um conjunto de tipos de formas de marcador de posição.
    // Por exemplo, um slide de Título deve ter apenas o tipo de marcador de posição Title, e assim por diante.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Adicionar um slide vazio usando o layout de slide adicionado.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Salvar a apresentação no disco.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Remover Layouts de Slide Não Utilizados**

O Aspose.Slides fornece o método [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) na classe [Compress](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/) para permitir que você exclua layouts de slide indesejados e não utilizados.

O código C++ a seguir mostra como remover um layout de slide de uma apresentação PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar Marcadores de Posição aos Layouts de Slide**

O Aspose.Slides fornece o método [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/), que permite adicionar novos marcadores de posição a um layout de slide.

Este gerenciador contém métodos para os seguintes tipos de marcadores de posição:

| Marcador de Posição do PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Conteúdo](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Conteúdo (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texto](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Texto (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Imagem](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Gráfico](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabela](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Mídia](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Imagem Online](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

O código C++ a seguir demonstra como adicionar novas formas de marcadores de posição ao layout em branco:

```cpp
auto presentation = MakeObject<Presentation>();

// Obter o slide de layout em branco.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Obter o gerenciador de marcadores de posição do slide de layout.
auto placeholderManager = layout->get_PlaceholderManager();

// Adicionar diferentes marcadores de posição ao slide de layout em branco.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Adicionar um novo slide com o layout em branco.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![Os marcadores de posição no layout do slide](add_placeholders.png)

## **Definir Visibilidade do Rodapé para um Layout de Slide**

Em apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser exibidos ou ocultados dependendo do layout do slide. O Aspose.Slides for Android permite controlar a visibilidade desses marcadores de posição de rodapé. Isso é útil quando você deseja que determinados layouts exibam informações de rodapé enquanto outros permanecem limpos e mínimos.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) class.
2. Obtenha uma referência ao layout de slide pelo seu índice.
3. Defina o marcador de posição de rodapé do slide como visível.
4. Defina o marcador de posição do número do slide como visível.
5. Defina o marcador de posição de data/hora como visível.
6. Salve a apresentação.

O código C++ a seguir mostra como definir a visibilidade de um rodapé de slide e realizar tarefas relacionadas:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir Visibilidade do Rodapé Filho para um Slide**

Em apresentações PowerPoint, os elementos de rodapé como data, número do slide e texto personalizado podem ser controlados ao nível do slide mestre para garantir consistência em todos os layouts de slide. O Aspose.Slides for Android permite definir a visibilidade e o conteúdo desses marcadores de posição de rodapé no slide mestre e propagar essas configurações para todos os layouts de slide filhos. Essa abordagem assegura informações de rodapé uniformes em toda a apresentação.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) class.
2. Obtenha uma referência ao slide mestre pelo seu índice.
3. Defina os marcadores de posição de rodapé do mestre e de todos os filhos como visíveis.
4. Defina os marcadores de posição de número do slide do mestre e de todos os filhos como visíveis.
5. Defina os marcadores de posição de data/hora do mestre e de todos os filhos como visíveis.
6. Salve a apresentação.

O código C++ a seguir demonstra essa operação:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas Frequentes**

**Qual é a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema geral e a formatação padrão, enquanto os slides de layout definem disposições específicas de marcadores de posição para diferentes tipos de conteúdo.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim, você pode clonar um slide de layout da coleção de slides de layout de uma apresentação, acessível através do método [get_LayoutSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_layoutslides/), e inseri‑lo em outra apresentação usando o método `AddClone`.

**O que acontece se eu excluir um slide de layout que ainda está sendo usado por um slide?**

Se você tentar excluir um slide de layout que ainda é referenciado por pelo menos um slide na apresentação, o Aspose.Slides lançará uma [PptxEditException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxeditexception/). Para evitar isso, use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), que remove com segurança apenas os slides de layout que não estão em uso.