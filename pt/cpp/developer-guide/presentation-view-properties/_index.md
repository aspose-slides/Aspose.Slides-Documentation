---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em C++
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/cpp/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo de contorno
- ícones de contorno
- ajustar divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para C++ para personalizar formatos PPT, PPTX e ODP – ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve o estado da visualização no arquivo, de modo que, ao reabrir, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) foi adicionado para fornecer acesso às propriedades da visualização normal de uma apresentação.  

As interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inormalviewrestoredproperties/) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/splitterbarstatetype/) foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades da visualização normal.

A propriedade **ShowOutlineIcons** especifica se o aplicativo deve exibir ícones ao mostrar conteúdo de contorno em qualquer das regiões de conteúdo no modo de visualização normal.

A propriedade **SnapVerticalSplitter** especifica se o divisor vertical deve se ajustar a um estado minimizado quando a região lateral estiver suficientemente pequena.

A propriedade **PreferSingleView** especifica se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se habilitada, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

As propriedades **VerticalBarState** e **HorizontalBarState** especificam o estado em que a barra de divisor horizontal ou vertical deve ser exibida. Uma barra de divisor horizontal separa o slide da região de conteúdo abaixo do slide, enquanto a barra de divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored.**

As propriedades **RestoredLeft** e **RestoredTop** especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor **SplitterBarStateType.Restored** é aplicado para **VerticalBarState** e **HorizontalBarState**, respectivamente.

## **Sobre a Restauração de INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

A propriedade **DimensionSize** especifica o tamanho da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft).  

A propriedade **AutoAdjust** especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.  

A seguir, um exemplo mostra como acessar as propriedades **ViewProperties.NormalViewProperties** de uma apresentação.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Restaurar as propriedades de visualização da apresentação
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Definir o Valor de Zoom Padrão**

Aspose.Slides for C++ agora suporta a definição do valor de zoom padrão para uma apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito configurando as [ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/) de uma apresentação. As propriedades da visualização de slide, bem como [get_NotesViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/get_notesviewproperties/), podem ser definidas programaticamente. Neste tópico, veremos com um exemplo como definir as propriedades de visualização de uma apresentação no Aspose.Slides.

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/)
1. Defina as [Properties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/) de visualização da apresentação
1. Grave a apresentação como um arquivo PPTX

No exemplo abaixo, definimos o valor de zoom para a visualização de slide, bem como para a visualização de notas.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Definindo as propriedades de visualização da apresentação
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valor de zoom em porcentagem para a visualização de slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valor de zoom em porcentagem para a visualização de notas 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Definir o Espaçamento da Grade**

Use [Presentation::get_ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_viewproperties/) para acessar as configurações de visualização de toda a apresentação. Os métodos [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iviewproperties/get_gridspacing/) e [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iviewproperties/set_gridspacing/) leem ou alteram o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos equivalem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um `demo.pptx` existente, exibe seu espaçamento de grade atual, define um intervalo de um quarto de polegada e salva o resultado.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

A grade é diferente dos [drawing guides](/slides/pt/cpp/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou limpar guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxiliares de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou em uma apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou do editor.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

Use [Presentation::get_ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_viewproperties/) para acessar as configurações de visualização de toda a apresentação. Use [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iviewproperties/get_showcomments/) e [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iviewproperties/set_showcomments/) para armazenar uma preferência sobre se os comentários devem ser mostrados quando a apresentação for aberta no PowerPoint ou em outro editor compatível.

Essa configuração controla apenas a preferência de visualização armazenada. Ela não adiciona, remove, edita ou resolve comentários. Ocultar comentários preserva seu conteúdo, autores, posições, respostas e status. Consulte [Presentation Comments](/slides/pt/cpp/presentation-comments/) para operações que alteram os próprios comentários.

O exemplo a seguir requer um `comments.pptx` existente contendo comentários. Ele exibe a configuração de visibilidade atual, solicita que os comentários sejam ocultados e salva um novo PPTX sem remover nenhum comentário. Também usa [IViewProperties::set_LastView](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iviewproperties/set_lastview/) com [ViewType::SlideView](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewtype/) para configurar a visualização de edição inicial juntamente com a visibilidade dos comentários.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Essa configuração não determina se os comentários são incluídos nas exportações em PDF, HTML, imagem, notas ou folhetos. Configure as opções específicas de exportação relevantes separadamente.

## **FAQ**

**Por que a grade não está visível após eu reabrir a apresentação?**

O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar os guias de desenho altera o espaçamento da grade?**

Não. Guias de desenho e espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo de grade armazenado inalterado.

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

[View settings](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_viewproperties/) são definidos no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré-definir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar as preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com propriedades de visualização pré-definidas para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_viewproperties/) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.