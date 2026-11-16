---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em Python via Java
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/python-java/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo do contorno
- ícones do contorno
- encaixe do divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Use Aspose.Slides for Python via Java para configurar o layout da visualização normal, o zoom de slides e notas, o espaçamento da grade e a visibilidade de comentários em apresentações do PowerPoint."
---
## **Introdução**

Na visualização normal do PowerPoint, o slide aparece entre um painel lateral para miniaturas ou um contorno e um painel de notas abaixo. Aspose.Slides for Python via Java expõe as preferências de edição salvas da apresentação através de [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Elas incluem o layout dos painéis, níveis de zoom, espaçamento da grade e visibilidade de comentários.

## **Sobre NormalViewProperties**

Use [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para acessar a classe [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) controla se ícones aparecem ao lado dos títulos dos slides no contorno. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) permite que o painel lateral se ajuste ao estado minimizado quando o usuário o reduz. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indica a preferência por exibir um único painel na janela completa.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) controla o divisor entre o painel lateral e o slide. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) controla o divisor acima do painel de notas. Ambos aceitam um valor do tipo [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **Sobre Restaurar NormalViewProperties**

Quando um divisor é restaurado, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) fornece o tamanho salvo do painel lateral e [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) fornece o tamanho salvo da área superior do slide. Ambos retornam uma instância de [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Seu método [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) aceita uma porcentagem de 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) controla se o editor ajusta o tamanho quando a janela é redimensionada.

Este exemplo atualiza uma apresentação existente. Ele restaura o divisor horizontal, define o tamanho retornado por [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) para 80 % com ajuste automático habilitado e maximiza o divisor vertical. Também chama [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) para exibir ícones na visualização de contorno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o Valor de Zoom Padrão**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) e [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) armazenam configurações de zoom independentes para o editor. Essas configurações não afetam as dimensões dos slides, a reprodução da apresentação ou a resolução da exportação de imagens.

Este exemplo abre uma apresentação existente e chama [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) para ajustar o slide à janela de edição. Para a página de notas, desabilita o dimensionamento automático e chama [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) para definir um zoom fixo de 80 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o Espaçamento da Grade**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) define a distância entre as linhas da grade de edição em toda a apresentação. Recebe um valor positivo em pontos, com 72 pontos por polegada. Este exemplo imprime o espaçamento atual em uma apresentação existente e salva uma grade de um quarto de polegada ao definir o intervalo para 18 pontos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A grade se repete em intervalos fixos. [Drawing guides](/slides/pt/python-java/drawing-guides/) marcam posições horizontais ou verticais individuais. Ambos são auxílios de edição e aparecem apenas em editores que os exibem. Apresentações de slides e exportações para PDF, imagens ou SVG os omitêm.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) armazena uma preferência que editores compatíveis usam ao abrir a apresentação. Para uma apresentação existente com comentários, este exemplo imprime a configuração atual e salva uma cópia com os comentários ocultos. Também chama [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) com [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) para que a cópia seja aberta na visualização de slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ocultar comentários preserva o texto, autores, posições, respostas e status deles. Para alterar os próprios comentários, veja [Presentation Comments](/slides/pt/python-java/presentation-comments/). As configurações de exportação controlam se os comentários aparecem em PDF, HTML, imagens, notas ou folhetos.

## **FAQ**

**Por que a grade fica oculta quando reabro a apresentação?**

A apresentação armazena o intervalo da grade. Para ver a grade, habilite a visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**

Não. Adicionar, mover ou limpar uma guia não altera o intervalo da grade.

**Seções diferentes de uma apresentação podem ter configurações de visualização diferentes?**

Não. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) se aplica a toda a apresentação.

**Posso salvar configurações de visualização diferentes para usuários diferentes?**

O arquivo armazena um conjunto de propriedades de visualização para todos. Um editor também pode aplicar as preferências locais de um usuário.

**Posso salvar configurações de visualização em um modelo?**

Sim. Apresentações criadas a partir do modelo herdam suas configurações de visualização salvas.