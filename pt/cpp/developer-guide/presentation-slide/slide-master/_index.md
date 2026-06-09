---
title: Gerenciar mestres de slides de apresentação em C++
linktitle: Mestre de Slide
type: docs
weight: 80
url: /pt/cpp/slide-master/
keywords:
- mestre de slide
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
- plano de fundo
- marcador de posição
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Gerencie mestres de slides no Aspose.Slides para C++: acesse, edite, clone, compare e remova slides mestres em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a maneira usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides para C++ oferece o mesmo modelo. Uma apresentação pode conter um ou mais slides mestres, e cada slide mestre pode conter vários slides de layout. Slides normais normalmente não referenciam diretamente um slide mestre. Em vez disso, um slide normal usa um slide de layout, e esse slide de layout pertence a um slide mestre.

A hierarquia é:

1. **Slide master** – define o design e o tema compartilhados.  
1. **Slide de layout** – define um arranjo específico de marcadores de posição e formatação ao nível do layout.  
1. **Slide normal** – contém o conteúdo real da apresentação e usa um slide de layout.

![A hierarquia de slides mestres, slides de layout e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela interface [IMasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/). Todos os slides mestres em uma apresentação estão disponíveis através da coleção [Presentation::get_Masters](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Herança" %}}

Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide mestre e um slide de layout definirem ambos um plano de fundo, os slides baseados nesse layout usarão o plano de fundo do layout. Para mais informações sobre slides de layout, veja [Apply or Change Slide Layouts](/slides/pt/cpp/slide-layout/).

{{% /alert %}}

## **Acessar Slides Mestres**

No PowerPoint, você pode abrir a visualização Slide Master em **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `get_Masters()` para acessar os slides mestres:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Você também pode obter o slide mestre usado por um slide normal através de seu layout:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **O que um Slide Master contém**

Um slide mestre é um objeto semelhante a um slide. Ele implementa [IBaseSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Os membros específicos do mestre estão listados na página da API [IMasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/).

Membros de slide mestre mais usados incluem:

| Membro | Propósito |
| --- | --- |
| `get_Background()` | Define o plano de fundo ao nível do mestre. |
| `get_Shapes()` | Armazena formas colocadas no mestre, como logotipos, molduras de imagem e texto compartilhado. |
| `get_LayoutSlides()` | Armazena os slides de layout que pertencem ao mestre. |
| `get_ThemeManager()` | Fornece acesso às APIs de tema do mestre. |
| `get_HeaderFooterManager()` | Controla cabeçalhos, rodapés, datas e números de slide para o mestre e seus layouts filhos. |
| `GetDependingSlides()` | Retorna slides normais que dependem do mestre por meio de seus layouts. |

## **Adicionar uma imagem a um Slide Master**

Ao adicionar uma imagem a um slide mestre, ela aparece nos slides que usam layouts desse mestre. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide mestre:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para mais informações sobre molduras de imagem, consulte [Picture Frame](/slides/pt/cpp/picture-frame/).

## **Trabalhar com Marcadores de Posição**

Marcadores de posição são normalmente definidos em slides de layout. O slide mestre fornece o estilo e tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde são posicionados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização Slide Master.

![O comando Inserir Marcador de Posição na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o slide de layout que pertence ao mestre:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Você também pode formatar formas de marcador de posição que já existam em um slide mestre. O exemplo a seguir localiza o marcador de posição de título e aplica um preenchimento de gradiente linear:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Marcador de posição de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores de posição e texto, veja [Set Prompt Text in Placeholder](/slides/pt/cpp/manage-placeholder/) e [Text Formatting](/slides/pt/cpp/text-formatting/).

## **Alterar o plano de fundo de um Slide Master**

Um plano de fundo de mestre é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de plano de fundo sólida para o primeiro slide mestre:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para tópicos relacionados, veja [Presentation Background](/slides/pt/cpp/presentation-background/) e [Presentation Theme](/slides/pt/cpp/presentation-theme/).

## **Clonar um Slide Master para outra apresentação**

Use [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/addclone/) para copiar um slide mestre para outra apresentação. O mestre copiado pode então ser usado por layouts e slides na apresentação de destino.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Se precisar clonar slides normais juntamente com seu mestre, veja [Clone Slides](/slides/pt/cpp/clone-slides/).

## **Adicionar múltiplos Slides Mestres**

Uma apresentação pode conter vários slides mestres. Isso é útil quando diferentes seções exigem branding, estrutura de página ou configurações de tema diferentes.

![Comandos do PowerPoint para inserir e gerenciar slides mestres](slide-master_9.jpg)

O exemplo a seguir clona o mestre padrão, atribui ao clone um plano de fundo diferente, cria um layout sob esse mestre clonado e adiciona um novo slide baseado nesse layout:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Comparar Slides Mestres**

Slides mestres podem ser comparados com o método `Equals` herdado de [IBaseSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores de posição, como a data atual.

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Para mais informações, veja [Compare Presentation Slides](/slides/pt/cpp/compare-slides/).

## **Definir a visualização de Slide Master como visualização padrão**

Use o método `set_LastView` em [ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização Slide Master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para mais configurações de visualização, veja [Save Presentation](/slides/pt/cpp/save-presentation/).

## **Remover Slides Mestres não utilizados**

Apresentações às vezes contêm slides mestres que não são mais usados por nenhum slide normal. Remover mestres não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/pt/cpp/aspose.slides/masterslidecollection/removeunused/) para remover mestres não utilizados da coleção `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Você também pode usar o método low-code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas frequentes**

**Qual a diferença entre um slide master e um slide de layout?**

Um slide master define configurações de design compartilhadas, como tema, plano de fundo, formas comuns e estilos de texto. Um slide de layout pertence a um slide master e define um arranjo específico de marcadores de posição. Um slide normal usa um slide de layout, herdando tanto do layout quanto do mestre.

**Uma apresentação pode conter vários slides mestres?**

Sim. Uma apresentação pode conter vários slides mestres. Use múltiplos mestres quando diferentes seções precisam de sistemas visuais ou branding diferentes.

**Devo adicionar marcadores de posição a um slide master ou a um slide de layout?**

Na maioria dos casos, adicione marcadores de posição a slides de layout. Coloque elementos visuais compartilhados e formatação comum no slide master e, em seguida, coloque os marcadores de posição de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide master que ainda está em uso?**

Não. Um slide master que possui slides dependentes não pode ser removido com segurança diretamente. Primeiro, mova esses slides para layouts sob outro mestre, ou use um método de limpeza de mestres não usados que remova apenas mestres que não estejam em uso.