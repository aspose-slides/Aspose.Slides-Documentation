---
title: Gerenciar apresentação de slides no Android
linktitle: Apresentação de Slides
type: docs
weight: 90
url: /pt/androidjava/manage-slide-show/
keywords:
- tipo de exibição
- apresentado por palestrante
- navegado por indivíduo
- navegado em quiosque
- opções de exibição
- repetir continuamente
- exibir sem narração
- exibir sem animação
- cor da caneta
- exibir slides
- exibição personalizada
- avançar slides
- manualmente
- usando cronometragens
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como gerenciar apresentações de slides no Aspose.Slides para Android via Java. Controle transições de slides, cronometragens e muito mais nos formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

No Microsoft PowerPoint, as configurações de **Slide Show** são uma ferramenta essencial para preparar e apresentar apresentações profissionais. Um dos recursos mais importantes desta seção é **Set Up Show**, que permite personalizar sua apresentação para condições e públicos específicos, garantindo flexibilidade e conveniência. Com esse recurso, você pode selecionar o tipo de exibição (por exemplo, apresentado por um palestrante, navegado por um indivíduo ou navegado em um quiosque), habilitar ou desabilitar a repetição, escolher slides específicos para exibir e usar cronometragens. Esta etapa na preparação é crucial para tornar sua apresentação mais eficaz e profissional.

`getSlideShowSettings` é um método da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) que retorna um objeto do tipo [SlideShowSettings](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowsettings/), permitindo gerenciar as configurações de apresentação de slides em uma apresentação do PowerPoint. Neste artigo, exploraremos como usar este método para configurar e controlar vários aspectos das configurações de apresentação de slides. 

## **Selecionar Tipo de Exibição**

`SlideShowSettings.setSlideShowType` define o tipo de apresentação de slides, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/browsedatkiosk/). Usar este método permite adaptar a apresentação para diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como “Browsed by an individual” sem exibir a barra de rolagem.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Habilitar Opções de Exibição**

`SlideShowSettings.setLoop` determina se a apresentação de slides deve repetir em loop até ser interrompida manualmente. Isso é útil para apresentações automatizadas que precisam rodar continuamente. `SlideShowSettings.setShowNarration` determina se as narrações de voz devem ser reproduzidas durante a apresentação de slides. É útil para apresentações automatizadas que contêm orientações de áudio para o público. `SlideShowSettings.setShowAnimation` determina se as animações adicionadas aos objetos dos slides devem ser reproduzidas. Isso é útil para proporcionar o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e repete a apresentação de slides em loop.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Selecionar Slides a Exibir**

O método `SlideShowSettings.setSlides` permite selecionar um intervalo de slides a serem exibidos durante a apresentação. Isso é útil quando você precisa mostrar apenas parte da apresentação em vez de todos os slides. O exemplo de código a seguir cria uma nova apresentação e define o intervalo de slides para exibir do slide `2` ao `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Usar Avanço de Slides**

O método `SlideShowSettings.setUseTimings` permite habilitar ou desabilitar o uso de cronometragens pré-definidas para cada slide. Isso é útil para exibir slides automaticamente com durações de exibição predefinidas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de cronometragens.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Exibir Controles de Mídia**

`SlideShowSettings.setShowMediaControls` determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante a apresentação de slides quando conteúdo multimídia (por exemplo, vídeo ou áudio) está sendo reproduzido. Isso é útil quando você deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Perguntas Frequentes**

**Posso salvar uma apresentação para que ela seja aberta diretamente no modo de apresentação de slides?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos iniciam diretamente no modo de apresentação de slides ao serem abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [durante a exportação](/slides/pt/androidjava/save-presentation/).

**Posso excluir slides individuais da apresentação sem excluí-los do arquivo?**

Sim. Marque um slide como [hidden](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Slides ocultos permanecem na apresentação, mas não são exibidos durante a apresentação de slides.

**O Aspose.Slides pode reproduzir uma apresentação de slides ou controlar uma apresentação ao vivo na tela?**

Não. O Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é feita por um aplicativo visualizador, como o PowerPoint.