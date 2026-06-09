---
title: Gerenciar Slide Show em Java
linktitle: Exibição de Slides
type: docs
weight: 90
url: /pt/java/manage-slide-show/
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
- Java
- Aspose.Slides
description: "Aprenda a gerenciar apresentações de slides no Aspose.Slides para Java. Controle transições de slides, cronometragens e muito mais em formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

No Microsoft PowerPoint, as configurações de **Slide Show** são uma ferramenta essencial para preparar e apresentar apresentações profissionais. Um dos recursos mais importantes desta seção é **Set Up Show**, que permite adaptar sua apresentação a condições e públicos específicos, garantindo flexibilidade e conveniência. Com esse recurso, você pode selecionar o tipo de exibição (por exemplo, apresentado por um palestrante, navegado por um indivíduo ou em modo quiosque), habilitar ou desabilitar a repetição, escolher slides específicos para exibir e usar cronometragens. Essa etapa de preparação é crucial para tornar sua apresentação mais eficaz e profissional.

`getSlideShowSettings` é um método da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) que devolve um objeto do tipo [SlideShowSettings](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slideshowsettings/), permitindo gerenciar as configurações de exibição de slides em uma apresentação PowerPoint. Neste artigo, exploraremos como usar esse método para configurar e controlar vários aspectos das configurações de slide show.

## **Selecionar tipo de exibição**

`SlideShowSettings.setSlideShowType` define o tipo de slide show, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pt/java/com.aspose.slides/browsedbyindividual/) ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/java/com.aspose.slides/browsedatkiosk/). Usar esse método permite adaptar a apresentação para diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como “Browsed by an individual” sem exibir a barra de rolagem.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Habilitar opções de exibição**

`SlideShowSettings.setLoop` determina se o slide show deve repetir em loop até ser interrompido manualmente. Isso é útil para apresentações automatizadas que precisam executar continuamente. `SlideShowSettings.setShowNarration` determina se narrações de voz devem ser reproduzidas durante o slide show. É útil para apresentações automatizadas que contêm orientação por voz para o público. `SlideShowSettings.setShowAnimation` determina se as animações adicionadas aos objetos dos slides devem ser reproduzidas. Isso é útil para proporcionar o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e coloca o slide show em loop.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Selecionar slides para exibir**

O método `SlideShowSettings.setSlides` permite selecionar um intervalo de slides a serem exibidos durante a apresentação. Isso é útil quando você precisa mostrar apenas parte da apresentação em vez de todos os slides. O exemplo de código abaixo cria uma nova apresentação e define o intervalo de slides a exibir de `2` a `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Usar avançar slides**

O método `SlideShowSettings.setUseTimings` permite habilitar ou desabilitar o uso de cronometragens pré-definidas para cada slide. Isso é útil para exibir automaticamente slides com durações de exibição predefinidas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de cronometragens.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Exibir controles de mídia**

`SlideShowSettings.setShowMediaControls` determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante o slide show quando conteúdo multimídia (por exemplo, vídeo ou áudio) é reproduzido. Isso é útil quando se deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Posso salvar uma apresentação de modo que ela abra diretamente no modo de slide show?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos são iniciados diretamente no slide show ao serem abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [during export](/slides/pt/java/save-presentation/).

**Posso excluir slides individuais da exibição sem removê‑los do arquivo?**

Sim. Marque um slide como [hidden](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#setHidden-boolean-). Slides ocultos permanecem na apresentação, mas não são exibidos durante o slide show.

**Aspose.Slides pode reproduzir um slide show ou controlar uma apresentação ao vivo na tela?**

Não. Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é feita por um aplicativo visualizador, como o PowerPoint.