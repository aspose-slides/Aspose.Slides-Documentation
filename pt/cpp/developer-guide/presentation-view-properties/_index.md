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
- ajuste do divisor vertical
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
description: "Use Aspose.Slides for C++ para configurar o layout da visualização normal, o zoom de slides e de notas, o espaçamento da grade e a visibilidade de comentários em apresentações do PowerPoint."
---
## **Introdução**

Na visualização normal do PowerPoint, o slide aparece entre um painel lateral para miniaturas ou um contorno e um painel de notas abaixo. Aspose.Slides for C++ expõe as preferências de edição salvas da apresentação por meio de [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Elas incluem o layout dos painéis, níveis de zoom, espaçamento da grade e visibilidade de comentários.

## **Sobre INormalViewProperties**

Use [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) para acessar a interface [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) controla se ícones aparecem ao lado dos títulos dos slides no contorno. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) permite que o painel lateral encaixe em seu estado minimizado quando o usuário o reduz. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) indica uma preferência por exibir um único painel na janela completa.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) controla o divisor entre o painel lateral e o slide. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) controla o divisor acima do painel de notas. Ambos aceitam um valor [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **Sobre Restaurar INormalViewProperties**

Quando um divisor é restaurado, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) fornece o tamanho salvo do painel lateral e [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) fornece o tamanho salvo da área superior do slide. Ambos expõem [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Seu método [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) aceita uma porcentagem de 0 a 100, e [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) controla se o editor ajusta o tamanho quando a janela é redimensionada.

Este exemplo atualiza uma apresentação existente. Ele restaura o divisor horizontal, define o tamanho da área superior do slide exposta por [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) para 80% com ajuste automático habilitado, e maximiza o divisor vertical. Também habilita ícones de contorno com [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) para a visualização de contorno.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Definir o Valor de Zoom Padrão**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) e [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) armazenam configurações de zoom independentes para o editor. Essas configurações não afetam as dimensões dos slides, a reprodução de apresentação de slides ou a resolução de exportação de imagens.

Este exemplo abre uma apresentação existente e habilita o dimensionamento automático com [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) para ajustar o slide à janela de edição. Para a página de notas, desabilita o dimensionamento automático e usa [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) para definir um zoom fixo de 80%.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Definir o Espaçamento da Grade**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) define a distância entre as linhas da grade de edição em toda a apresentação. Recebe um valor positivo em pontos, com 72 pontos por polegada. Este exemplo exibe o espaçamento atual em uma apresentação existente e salva uma grade de um quarto de polegada definindo o intervalo para 18 pontos.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

A grade se repete em intervalos fixos. [Guias de desenho](/slides/pt/cpp/drawing-guides/) marcam posições horizontais ou verticais individuais. Ambos são auxílios de edição e aparecem apenas em editores que os exibem. Apresentações e exportações para PDF, imagens ou SVG os omitêm.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) armazena uma preferência que editores compatíveis usam ao abrir a apresentação. Para uma apresentação existente com comentários, este exemplo exibe a configuração atual e salva uma cópia com os comentários ocultos. Também chama [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) com [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) para que a cópia abra na visualização de slide.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Ocultar comentários preserva seu texto, autores, posições, respostas e status. Para alterar os próprios comentários, veja [Comentários da Apresentação](/slides/pt/cpp/presentation-comments/). As configurações de exportação controlam se os comentários aparecem em PDF, HTML, imagens, notas ou folhetos.

## **Perguntas Frequentes**

**Por que a grade fica oculta quando eu reabro a apresentação?**  
A apresentação armazena o intervalo da grade. Para ver a grade, habilite a visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**  
Não. Adicionar, mover ou limpar uma guia não altera o intervalo da grade.

**Seções diferentes de uma apresentação podem ter configurações de visualização diferentes?**  
Não. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) se aplica a toda a apresentação.

**Posso salvar configurações de visualização diferentes para usuários diferentes?**  
O arquivo armazena um único conjunto de propriedades de visualização para todos. Um editor também pode aplicar as preferências locais de um usuário.

**Posso salvar configurações de visualização em um modelo?**  
Sim. Apresentações criadas a partir do modelo herdam as configurações de visualização salvas.