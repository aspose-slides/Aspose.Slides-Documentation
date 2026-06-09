---
title: Gerenciar Apresentação de Slides em PHP
linktitle: Apresentação de Slides
type: docs
weight: 90
url: /pt/php-java/manage-slide-show/
keywords:
- tipo de exibição
- apresentado por palestrante
- navegado por indivíduo
- navegado em quiosque
- opções de exibição
- loop contínuo
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
- PHP
- Aspose.Slides
description: "Aprenda como gerenciar apresentações de slides no Aspose.Slides para PHP via Java. Controle transições de slides, temporizações e mais em formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

No Microsoft PowerPoint, as configurações de **Apresentação de Slides** são uma ferramenta essencial para preparar e apresentar apresentações profissionais. Um dos recursos mais importantes desta seção é **Configurar Apresentação**, que permite adaptar sua apresentação a condições e públicos específicos, garantindo flexibilidade e conveniência. Com esse recurso, você pode selecionar o tipo de exibição (por exemplo, apresentada por um palestrante, navegada por um indivíduo ou navegada em um quiosque), habilitar ou desabilitar a repetição, escolher slides específicos para exibir e usar temporizações. Essa etapa de preparação é crucial para tornar sua apresentação mais eficaz e profissional.

`getSlideShowSettings` é um método da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) que retorna um objeto do tipo [SlideShowSettings](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowsettings/), permitindo gerenciar as configurações de apresentação de slides em um documento PowerPoint. Neste artigo, exploraremos como usar esse método para configurar e controlar vários aspectos das configurações de apresentação de slides. 

## **Selecionar Tipo de Exibição**

`SlideShowSettings->setSlideShowType` define o tipo de apresentação de slides, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pt/php-java/aspose.slides/browsedbyindividual/), ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/php-java/aspose.slides/browsedatkiosk/). O uso desse método permite adaptar a apresentação a diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como "Navegada por um indivíduo" sem exibir a barra de rolagem.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Habilitar Opções de Exibição**

`SlideShowSettings->setLoop` determina se a apresentação de slides deve repetir em loop até ser interrompida manualmente. Isso é útil para apresentações automatizadas que precisam ser executadas continuamente. `SlideShowSettings->setShowNarration` determina se as narrações de áudio devem ser reproduzidas durante a apresentação de slides. É útil para apresentações automatizadas que contêm orientação de voz para o público. `SlideShowSettings->setShowAnimation` determina se as animações adicionadas aos objetos de slide devem ser reproduzidas. Isso é útil para fornecer o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e coloca a apresentação de slides em loop.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Selecionar Slides a Exibir**

O método `SlideShowSettings->setSlides` permite selecionar um intervalo de slides a serem exibidos durante a apresentação. Isso é útil quando você precisa mostrar apenas parte da apresentação em vez de todos os slides. O exemplo de código a seguir cria uma nova apresentação e define o intervalo de slides a ser exibido dos slides `2` até `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Usar Avanço Automático de Slides**

O método `SlideShowSettings->setUseTimings` permite habilitar ou desabilitar o uso de temporizações pré-definidas para cada slide. Isso é útil para exibir slides automaticamente com durações de exibição predefinidas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de temporizações.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Exibir Controles de Mídia**

`SlideShowSettings->setShowMediaControls` determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante a apresentação de slides quando conteúdo multimídia (por exemplo, vídeo ou áudio) é reproduzido. Isso é útil quando você deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Posso salvar uma apresentação para que ela abra diretamente no modo de apresentação de slides?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos são iniciados diretamente no modo de apresentação de slides ao serem abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [durante a exportação](/slides/pt/php-java/save-presentation/).

**Posso excluir slides individuais da exibição sem removê‑los do arquivo?**

Sim. Marque um slide como [oculto](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/sethidden/). Slides ocultos permanecem na apresentação, mas não são exibidos durante a apresentação de slides.

**Aspose.Slides pode reproduzir uma apresentação de slides ou controlar uma apresentação ao vivo na tela?**

Não. Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é feita por um aplicativo visualizador, como o PowerPoint.