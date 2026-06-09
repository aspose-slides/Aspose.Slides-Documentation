---
title: Gerenciar Apresentação de Slides em Python
linktitle: Apresentação de Slides
type: docs
weight: 90
url: /pt/python-net/manage-slide-show/
keywords:
- tipo de exibição
- apresentado por palestrante
- visualizado por indivíduo
- visualizado em quiosque
- opções de exibição
- repetir continuamente
- exibir sem narração
- exibir sem animação
- cor da caneta
- exibir slides
- exibição personalizada
- avançar slides
- manualmente
- usando tempos
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a gerenciar apresentações de slides no Aspose.Slides para Python via .NET. Controle transições de slides, tempos e muito mais nos formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

No Microsoft PowerPoint, as configurações de **Slide Show** são uma ferramenta fundamental para preparar e apresentar apresentações profissionais. Uma das funcionalidades mais importantes nesta seção é **Set Up Show**, que permite personalizar sua apresentação para condições e públicos específicos, garantindo flexibilidade e conveniência. Com esse recurso, você pode selecionar o tipo de exibição (por exemplo, apresentado por um palestrante, visualizado por um indivíduo ou visualizado em um quiosque), habilitar ou desabilitar a repetição, escolher slides específicos para exibir e usar tempos. Essa etapa de preparação é crucial para tornar sua apresentação mais eficaz e profissional.

`slide_show_settings` é uma propriedade da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) do tipo [SlideShowSettings](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slideshowsettings/), que permite gerenciar as configurações de slide show em uma apresentação PowerPoint. Neste artigo, exploraremos como usar essa propriedade para configurar e controlar vários aspectos das configurações de slide show. 

## **Selecionar Tipo de Exibição**

`SlideShowSettings.slide_show_type` define o tipo de slide show, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pt/python-net/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/python-net/aspose.slides/browsedatkiosk/). Usar essa propriedade permite adaptar a apresentação para diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como “Browsed by an individual” sem exibir a barra de rolagem.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Habilitar Opções de Exibição**

`SlideShowSettings.loop` determina se o slide show deve repetir em um loop até ser interrompido manualmente. Isso é útil para apresentações automatizadas que precisam rodar continuamente. `SlideShowSettings.show_narration` determina se narrações de voz devem ser reproduzidas durante o slide show. É útil para apresentações automatizadas que contêm orientação vocal para o público. `SlideShowSettings.show_animation` determina se animações adicionadas aos objetos de slide devem ser reproduzidas. Isso é útil para proporcionar o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e repete o slide show em loop.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Selecionar Slides para Exibir**

`SlideShowSettings.slides` permite selecionar um intervalo de slides a serem exibidos durante a apresentação. Isso é útil quando você precisa mostrar apenas parte da apresentação em vez de todos os slides. O exemplo de código a seguir cria uma nova apresentação e define o intervalo de slides a exibir dos slides `2` a `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar Avanço de Slides**

`SlideShowSettings.use_timings` permite habilitar ou desabilitar o uso de tempos predefinidos para cada slide. Isso é útil para exibir slides automaticamente com durações de exibição definidas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de tempos.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Exibir Controles de Mídia**

`SlideShowSettings.show_media_controls` determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante o slide show quando conteúdo multimídia (por exemplo, vídeo ou áudio) é reproduzido. Isso é útil quando você deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso salvar uma apresentação para que ela abra diretamente no modo de apresentação?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos são abertos diretamente em modo de apresentação ao serem abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [during export](/slides/pt/python-net/save-presentation/).

**Posso excluir slides individuais da apresentação sem deletá-los do arquivo?**

Sim. Marque um slide como [hidden](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/hidden/). Slides ocultos permanecem na apresentação, mas não são exibidos durante o slide show.

**O Aspose.Slides pode reproduzir um slide show ou controlar uma apresentação ao vivo na tela?**

Não. Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é feita por um aplicativo visualizador como o PowerPoint.