---
title: Gerenciar Apresentações de Slides em Python via Java
linktitle: Apresentação de Slides
type: docs
weight: 90
url: /pt/python-java/manage-slide-show/
keywords:
- tipo de apresentação
- apresentado por palestrante
- navegado por indivíduo
- navegado em quiosque
- opções de apresentação
- repetir continuamente
- apresentar sem narração
- apresentar sem animação
- cor da caneta
- exibir slides
- apresentação personalizada
- avançar slides
- manualmente
- usando tempos
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a gerenciar apresentações de slides no Aspose.Slides para Python via Java. Controle transições de slides, tempos e muito mais nos formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

As opções **Set Up Show** do Microsoft PowerPoint permitem escolher o tipo de apresentação, habilitar a repetição, selecionar slides e controlar como os slides avançam. Com Aspose.Slides for Python via Java, você pode configurar essas opções programaticamente e salvar‑las em um arquivo de apresentação.

O método [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlideShowSettings) retorna um objeto [SlideShowSettings](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/) que controla essas opções. Os exemplos abaixo requerem Aspose.Slides for Python via Java e um runtime Java compatível. Cada exemplo inicia a JVM se necessário e libera a apresentação ao terminar.

## **Selecionar Tipo de Apresentação**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/#setSlideShowType) define o tipo de apresentação de slides, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pt/python-java/aspose.slides/browsedbyindividual/) ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/python-java/aspose.slides/browsedatkiosk/). Usar este método permite adaptar a apresentação para diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como “Browsed by an individual” sem exibir a barra de rolagem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Habilitar Opções de Apresentação**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/#setLoop) determina se a apresentação de slides deve repetir em loop até ser interrompida manualmente. Isso é útil para apresentações automatizadas que precisam executar continuamente. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/#setShowNarration) determina se narrações de voz devem ser reproduzidas durante a apresentação. É útil para apresentações automatizadas que contêm orientação vocal para o público. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/#setShowAnimation) determina se animações adicionadas aos objetos dos slides devem ser reproduzidas. Isso é útil para proporcionar o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e repete a apresentação em loop.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Selecionar Slides para Exibir**

O método [SlideShowSettings.setSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/#setSlides) permite selecionar um intervalo de slides a serem exibidos durante a apresentação. Isso é útil quando se precisa mostrar apenas parte da apresentação em vez de todos os slides. O exemplo de código a seguir cria uma apresentação com nove slides e seleciona os slides de 2 a 9. O intervalo usa numeração de slides baseada em 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Crie nove slides para que o intervalo selecionado exista.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar Avanço dos Slides**

O método [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/#setUseTimings) permite habilitar ou desabilitar o uso de tempos pré‑definidos para cada slide. Isso é útil para avançar os slides automaticamente com durações de exibição predefinidas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de tempos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Exibir Controles de Mídia**

O método [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante a apresentação quando conteúdo multimídia (por exemplo, vídeo ou áudio) é reproduzido. Isso é útil quando se deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Posso salvar uma apresentação de modo que ela abra diretamente no modo de apresentação?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos são abertos diretamente no modo de apresentação ao serem abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [durante a exportação](/slides/pt/python-java/save-presentation/).

**Posso excluir slides individuais da apresentação sem removê‑los do arquivo?**

Sim. Marque um slide como [hidden](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#setHidden). Slides ocultos permanecem na apresentação, mas não são exibidos durante a apresentação.

**O Aspose.Slides pode reproduzir uma apresentação ou controlar uma apresentação ao vivo na tela?**

Não. O Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é feita por um aplicativo visualizador, como o PowerPoint.