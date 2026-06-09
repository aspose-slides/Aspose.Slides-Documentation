---
title: Gerenciar apresentação de slides em JavaScript
linktitle: Apresentação de Slides
type: docs
weight: 90
url: /pt/nodejs-java/manage-slide-show/
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
- usando temporizações
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie apresentações de slides em JavaScript com Aspose.Slides para Node.js. Controle transições de slides, temporizações e mais em formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

No Microsoft PowerPoint, as configurações de **Slide Show** são uma ferramenta essencial para preparar e apresentar apresentações profissionais. Uma das funcionalidades mais importantes nesta seção é **Set Up Show**, que permite adaptar sua apresentação a condições e públicos específicos, garantindo flexibilidade e conveniência. Com esse recurso, você pode selecionar o tipo de exibição (por exemplo, apresentado por um palestrante, visualizado por um indivíduo ou visualizado em um quiosque), habilitar ou desabilitar a repetição, escolher slides específicos para exibir e usar temporizações. Esta etapa de preparação é crucial para tornar sua apresentação mais eficaz e profissional.

`getSlideShowSettings` é um método da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) que devolve um objeto do tipo [SlideShowSettings](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowsettings/), permitindo gerenciar as configurações de apresentação de slides em um arquivo PowerPoint. Neste artigo, exploraremos como usar esse método para configurar e controlar diversos aspectos das configurações de slide show. 

## **Selecionar Tipo de Exibição**

`SlideShowSettings.setSlideShowType` define o tipo de slide show, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/browsedatkiosk/). Usar esse método permite adaptar a apresentação para diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como "Browsed by an individual" sem exibir a barra de rolagem.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Habilitar Opções de Exibição**

`SlideShowSettings.setLoop` determina se o slide show deve repetir em loop até ser interrompido manualmente. Isso é útil para apresentações automatizadas que precisam executar continuamente. `SlideShowSettings.setShowNarration` define se narrações de voz devem ser reproduzidas durante o slide show. É útil para apresentações automatizadas que contêm orientações de áudio para o público. `SlideShowSettings.setShowAnimation` indica se as animações adicionadas aos objetos de slide devem ser reproduzidas, proporcionando o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e coloca o slide show em loop.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Selecionar Slides a Exibir**

O método `SlideShowSettings.setSlides` permite selecionar um intervalo de slides a serem exibidos durante a apresentação. Isso é útil quando você precisa mostrar apenas parte da apresentação em vez de todos os slides. O exemplo de código a seguir cria uma nova apresentação e define o intervalo de slides a exibir do slide `2` ao slide `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Usar Avanço Automático de Slides**

`SlideShowSettings.setUseTimings` permite habilitar ou desabilitar o uso de temporizações pré-definidas para cada slide. Isso é útil para exibir slides automaticamente com durações de exibição determinadas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de temporizações.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Exibir Controles de Mídia**

`SlideShowSettings.setShowMediaControls` determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante o slide show quando conteúdo multimídia (por exemplo, vídeo ou áudio) for reproduzido. Isso é útil quando se deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Posso salvar uma apresentação para que ela abra diretamente no modo de slide show?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos são abertos diretamente no slide show ao serem abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [durante a exportação](/slides/pt/nodejs-java/save-presentation/).

**Posso excluir slides individuais da exibição sem removê-los do arquivo?**

Sim. Marque um slide como [hidden](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/sethidden/). Slides ocultos permanecem na apresentação, mas não são exibidos durante o slide show.

**Aspose.Slides pode reproduzir um slide show ou controlar uma apresentação ao vivo na tela?**

Não. Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é feita por um aplicativo visualizador, como o PowerPoint.