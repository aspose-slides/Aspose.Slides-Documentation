---
title: Gerenciar hiperlinks de apresentação em C++
linktitle: Gerenciar hiperlinks
type: docs
weight: 20
url: /pt/cpp/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hiperlink
- criar hiperlink
- formatar hiperlink
- remover hiperlink
- atualizar hiperlink
- hiperlink de texto
- hiperlink de slide
- hiperlink de forma
- hiperlink de imagem
- hiperlink de vídeo
- hiperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Adicionar, formatar, atualizar e remover hiperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para C++, usando exemplos em C++."
---
## **Introdução**

Um hiperlink conecta o conteúdo da apresentação a um site ou a um local dentro da apresentação. No PowerPoint, os hiperlinks geralmente servem a dois propósitos:

* Abrir um site a partir de texto, forma ou quadro de mídia.
* Navegar para outro slide, por exemplo, a partir de um índice.

Aspose.Slides for C++ permite adicionar esses links, controlar sua aparência e som, atualizar suas configurações e removê‑los. Os exemplos abaixo mostram como trabalhar com hiperlinks em elementos individuais e como acessar hiperlinks no nível da apresentação, slide ou quadro de texto.

{{% alert color="info" title="Note" %}}
Você também pode editar apresentações com o [editor gratuito de PowerPoint online da Aspose](https://products.aspose.app/slides/pt/editor).
{{% /alert %}} 

## **Adicionar hiperlinks de URL**

Você pode atribuir um URL de site a texto, forma ou quadro de mídia. O elemento ao qual você atribui o hiperlink determina a área clicável: uma porção de texto vincula o texto selecionado, enquanto uma forma ou quadro vincula o objeto do slide.

### **Adicionar hiperlinks de URL ao texto**

Para vincular texto a um site, crie um [Hyperlink](https://reference.aspose.com/slides/pt/cpp/aspose.slides/hyperlink/) e atribua‑o com o método [set_HyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portionformat/set_hyperlinkclick/) da porção de texto, como mostrado abaixo. Apenas essa parte do texto se torna clicável.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Adicionar hiperlinks de URL a formas e quadros de mídia**

Para tornar uma forma ou quadro clicável, use seu método [set_HyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/set_hyperlinkclick/). O hiperlink pertence ao próprio objeto, em vez de a uma porção de texto dentro dele.

A mesma abordagem se aplica a quadros de imagem, áudio e vídeo: atribua o hiperlink ao quadro e use [set_Tooltip](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_tooltip/) para adicionar uma dica, se necessário.

O exemplo a seguir torna um retângulo clicável:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Usar hiperlinks para criar um índice**

Hiperlinks internos permitem que os leitores saltem de um índice para um slide específico. O exemplo a seguir usa [SetInternalHyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) para vincular o texto “Page 2” no primeiro slide ao segundo slide.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Formatar hiperlinks**

### **Cor**

O método [set_ColorSource](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_colorsource/) de [IHyperlink](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/) determina se um hiperlink usa a cor de hiperlink da apresentação ou a formatação da porção de texto. Para aplicar uma cor de texto personalizada, selecione [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/hyperlinkcolorsource/) e defina a cor de preenchimento da porção. Esse recurso foi introduzido no PowerPoint 2019; versões anteriores não aplicam essa configuração.

O exemplo a seguir adiciona dois hiperlinks de texto ao mesmo slide. O primeiro usa preenchimento de texto vermelho, enquanto o segundo mantém a cor padrão de hiperlink.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **Som**

Um hiperlink pode reproduzir um som quando ativado ou interromper um som que já está sendo reproduzido. Use os métodos a seguir para configurar esses comportamentos:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_sound/) especifica o áudio associado ao hiperlink.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) controla se a ativação do hiperlink interrompe o som anterior.

#### **Adicionar som a um hiperlink**

O exemplo a seguir carrega `sampleaudio.wav` e o associa a um botão no primeiro slide. Clicar no botão reproduz o som e navega para o próximo slide. Uma segunda forma naquele slide interrompe o som anterior ao ser clicada, sem executar ação de navegação.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Extrair som de um hiperlink**

O exemplo a seguir abre a apresentação criada acima e lê o áudio do hiperlink da primeira forma para a memória através de [get_Sound](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/get_sound/) e [get_BinaryData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip e Configurações de Interação**

Você pode atualizar as seguintes configurações de [IHyperlink](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/) por meio desses métodos após atribuir um hiperlink a texto ou a uma forma:

- [set_Tooltip](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_tooltip/) define o texto que o visualizador pode exibir como dica para o link.
- [set_TargetFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_targetframe/) especifica o quadro de destino dentro de um frameset HTML pai, quando aplicável.
- [set_History](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_history/) controla se a ativação do link adiciona seu destino à lista de hiperlinks visualizados.
- [set_HighlightClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/set_highlightclick/) controla se o hiperlink é destacado ao ser clicado.

## **Remover hiperlinks de apresentações**

Use [GetAnyHyperlinks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) para coletar contêineres de hiperlink, incluindo links de porções de texto, antes de alterá‑los. O exemplo a seguir remove ambos os tipos de ativação do primeiro slide. Para remover somente um tipo, chame apenas [RemoveHyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ou [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); remover a ação de clique não remove sua contrapartida de mouse‑over.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Para remoção incondicional, [RemoveAllHyperlinks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) remove ambos os tipos de ativação no escopo selecionado em uma única chamada. Para limpeza seletiva e cobertura de mestres, layouts e notas, consulte [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Criar um inventário completo de hiperlinks**

Antes de distribuir uma apresentação, faça o inventário de suas ações interativas, bem como de seus links web. [GetAnyHyperlinks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retorna objetos [IHyperlinkContainer](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkcontainer/), não uma lista simples de strings de URL. Inspecione tanto [get_HyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) quanto [get_HyperlinkMouseOver](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) em cada contêiner. Eles são independentes: o mesmo contêiner pode expor ambas as ações, portanto um relatório completo requer até duas linhas por contêiner.

Examinar apenas hiperlinks ao nível de forma pode perder links anexados a porções de texto. Consulte o escopo apropriado em vez disso e retenha os contêineres retornados para que você possa atualizar ou remover suas ações posteriormente.

### **Consultar escopos de Apresentação, Slide e Quadro de Texto**

A interface [IHyperlinkQueries](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/) está disponível através de [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) e [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Cada escopo suporta as mesmas consultas:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) retorna contêineres com ação de clique.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) retorna contêineres com ação de mouse‑over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retorna contêineres com uma ou ambas as ações.

O exemplo a seguir cria `hyperlink-audit-input.pptx` com um link externo de clique, um link de mouse‑over de arquivo, navegação interna de slide, um link de mouse‑over de texto e uma ação de macro. Ele não executa nenhuma dessas ações. As mesmas três consultas funcionam em todos os escopos; as contagens descrevem contêineres, não totais de ações. O escopo de quadro de texto exclui os próprios links da forma que o contém.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Para este exemplo, as consultas de apresentação e slide relatam três contêineres de clique, dois de mouse‑over e três contêineres com qualquer ação. A consulta de quadro de texto relata um contêiner em cada categoria.

### **Classificar Ações e Destinos**

Use [IHyperlink::get_ActionType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/get_actiontype/) para interpretar uma ação antes de interpretar seu destino. Os valores de [HyperlinkActionType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/hyperlinkactiontype/) abrangem mais que navegação web:

| Valores | Significado para uma auditoria |
| --- | --- |
| `Hyperlink` | Hiperlink externo; inspecione a URL e seu esquema. |
| `JumpSpecificSlide` | Navegação interna para um slide específico. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegação de apresentação embutida, resolvida no contexto da apresentação de slides. |
| `JumpEndShow`, `StartCustomSlideShow` | Finaliza a apresentação atual ou inicia uma apresentação personalizada. |
| `StartMacro` | Executa uma macro. |
| `StartProgram` | Inicia um programa. |
| `OpenFile`, `OpenPresentation` | Abre um arquivo ou outra apresentação; revise separadamente das URLs da web. |
| `StartStopMedia` | Inicia ou interrompe a reprodução de mídia. |
| `NoAction`, `Unknown` | Nenhuma ação de navegação, ou uma ação não reconhecida que requer revisão. |

Leia destinos externos de [get_ExternalUrl](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/get_externalurl/) e destinos internos específicos de [get_TargetSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/get_targetslide/). Ações internas e comandos incorporados podem não ter URL externa; uma URL vazia não significa que o contêiner não tenha ação. Preserve [get_ExternalUrlOriginal](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) quando diferir da URL normalizada e inclua a tooltip retornada por [get_Tooltip](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlink/get_tooltip/) quando disponível.

### **Relatar, Sanitizar e Verificar Hiperlinks**

O exemplo C++ a seguir lê uma apresentação existente (use o arquivo criado acima), grava `hyperlink-audit.json`, aplica uma política, salva `hyperlink-sanitized.pptx` e a reabre para verificar novamente ambos os tipos de ativação. Ele coleta contêineres antes de alterá‑los e usa identidade de ponteiro para evitar processar o mesmo contêiner duas vezes. Consultas de apresentação cobrem slides ordinários; para um inventário de todo o pacote, ele também consulta explicitamente mestres, layouts, notas e os mestres de notas e folhetos quando presentes.

O relatório registra um índice de slide baseado em 1 e [get_SlideId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_slideid/) quando disponível. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecomponent/get_slide/) fornece o slide proprietário para contêineres suportados. Mestres, layouts e notas não têm índice de slide ordinário e são identificados pelo seu escopo. Contêineres de forma e contêineres de formatação de porção de texto são rotulados separadamente; outros tipos de contêiner mantêm seu nome de tipo em tempo de execução. Cada contêiner recebe um ID local ao relatório para que suas duas ações possam ser correlacionadas.

Esta política de aplicação deliberadamente restritiva permite apenas URLs HTTPS absolutas e destinos internos de slide válidos. Ela rejeita macros, programas, ações de arquivo, outras ações de apresentação, ações desconhecidas e outros esquemas de URL. Essas rejeições são decisões de política, não um veredicto de segurança da Aspose.Slides. HTTPS sozinho não estabelece confiança: adicione listas de permissões de host e outras verificações para sua aplicação. Tanto URLs externas originais quanto normalizadas são verificadas. O exemplo audita metadados sem seguir links ou executar ações.

Para remediação, o contêiner’s [get_HyperlinkManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) suporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) e [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Aqui, links externos de clique proibidos são substituídos por uma página fixa HTTPS; outros cliques proibidos e ações de mouse‑over proibidas são removidos independentemente. Defina `replaceExternalClicks` como `false` para remover todas as violações de política. Escolha uma página de substituição de propriedade da aplicação antes da implantação.

A bandeira de exportação do relatório usa uma política conservadora de revisão de PDF: sinalize ações de mouse‑over e qualquer coisa que não seja um link externo ou salto de slide específico como potencialmente não suportada. É uma dica de revisão, não um teste de capacidade ou garantia de que links não sinalizados sobreviverão à exportação. Exportações suportadas de [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/cpp/convert-powerpoint-to-html/) podem preservar hiperlinks, dependendo da ação, das opções de exportação e do visualizador. Imagens raster [images](/slides/pt/cpp/convert-powerpoint-to-png/) e [video](/slides/pt/cpp/convert-powerpoint-to-video/) não podem preservar hiperlinks interativos; sinalize toda ação ao auditar para esses resultados.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Com a entrada criada acima, o relatório contém cinco linhas de ação. O link de mouse‑over de arquivo e o clique de macro são removidos, enquanto os links HTTPS e a navegação interna de slide permanecem. A verificação imprime zero ações proibidas. Uma entrada contendo uma URL de clique externo proibida também exerce o ramo de substituição. Um contêiner com um clique permitido e um mouse‑over proibido mantém sua ação de clique.

Essa limpeza seletiva difere de [RemoveAllHyperlinks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), que remove ambos os tipos de ativação em todo o escopo selecionado independentemente da política. A verificação aqui verifica apenas ações de hiperlink; não remove projetos VBA incorporados, objetos OLE ou outro conteúdo ativo, e não valida um PDF ou arquivo HTML exportado.

## **FAQ**

**Como posso vincular a uma seção ou ao seu primeiro slide?**

Seções no PowerPoint agrupam slides, mas um hiperlink interno tem como alvo um slide individual. Para criar navegação para uma seção, vincule ao primeiro slide dessa seção.

**Posso anexar um hiperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos de slide mestre e de layout suportam hiperlinks. Links nesses elementos ficam disponíveis durante a apresentação nos slides que utilizam o mestre ou layout correspondente.

**Os hiperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Exportações suportadas de PDF e HTML podem preservar hiperlinks; imagens raster e vídeos não podem. Consulte as considerações de exportação em [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).