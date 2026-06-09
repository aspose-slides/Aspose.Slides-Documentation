---
title: Gerenciar apresentação de slides em .NET
linktitle: Apresentação de Slides
type: docs
weight: 90
url: /pt/net/manage-slide-show/
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
- usando temporizações
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como gerenciar apresentações de slides no Aspose.Slides para .NET. Controle transições de slides, temporizações e muito mais em formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

Em Microsoft PowerPoint, as configurações de **Slide Show** são uma ferramenta essencial para preparar e apresentar apresentações profissionais. Um dos recursos mais importantes nesta seção é **Set Up Show**, que permite adaptar sua apresentação a condições e públicos específicos, garantindo flexibilidade e conveniência. Com esse recurso, você pode selecionar o tipo de exibição (por exemplo, apresentado por um palestrante, navegado por um indivíduo ou navegado em um quiosque), habilitar ou desabilitar a repetição, escolher slides específicos para exibir e usar temporizações. Essa etapa na preparação é crucial para tornar sua apresentação mais eficaz e profissional.

`SlideShowSettings` é uma propriedade da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) , do tipo [SlideShowSettings](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slideshowsettings/) , que permite gerenciar as configurações de slide show em uma apresentação do PowerPoint. Neste artigo, exploraremos como usar essa propriedade para configurar e controlar vários aspectos das configurações de slide show. 

## **Selecionar tipo de exibição**

`SlideShowSettings.SlideShowType` define o tipo de slide show, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/net/aspose.slides/presentedbyspeaker/) , [BrowsedByIndividual](https://reference.aspose.com/slides/pt/net/aspose.slides/browsedbyindividual/) , ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/net/aspose.slides/browsedatkiosk/) . Usar essa propriedade permite adaptar a apresentação para diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como “Browsed by an individual” sem exibir a barra de rolagem.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Habilitar opções de exibição**

`SlideShowSettings.Loop` determina se o slide show deve repetir em um loop até ser interrompido manualmente. Isso é útil para apresentações automatizadas que precisam ser executadas continuamente. `SlideShowSettings.ShowNarration` determina se narrações de voz devem ser reproduzidas durante o slide show. É útil para apresentações automatizadas que contêm orientação vocal para o público. `SlideShowSettings.ShowAnimation` determina se as animações adicionadas aos objetos dos slides devem ser reproduzidas. Isso é útil para fornecer o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e repete o slide show.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Selecionar slides para exibir**

A propriedade `SlideShowSettings.Slides` permite selecionar um intervalo de slides a serem mostrados durante a apresentação. Isso é útil quando você precisa exibir apenas parte da apresentação em vez de todos os slides. O exemplo de código a seguir cria uma nova apresentação e define o intervalo de slides para exibir dos slides `2` ao `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Usar avanço de slides**

A propriedade `SlideShowSettings.UseTimings` permite habilitar ou desabilitar o uso de temporizações predefinidas para cada slide. Isso é útil para exibir slides automaticamente com durações de exibição definidas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de temporizações.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Exibir controles de mídia**

A propriedade `SlideShowSettings.ShowMediaControls` determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante o slide show quando conteúdo multimídia (por exemplo, vídeo ou áudio) é reproduzido. Isso é útil quando você deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

**Posso salvar uma apresentação de modo que ela abra diretamente no modo de slide show?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos são iniciados diretamente no modo de slide show quando abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [durante a exportação](/slides/pt/net/save-presentation/).

**Posso excluir slides individuais da exibição sem excluí‑los do arquivo?**

Sim. Marque um slide como [Hidden](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/hidden/). Slides ocultos permanecem na apresentação, mas não são exibidos durante o slide show.

**O Aspose.Slides pode reproduzir um slide show ou controlar uma apresentação ao vivo na tela?**

Não. O Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é tratada por um aplicativo visualizador, como o PowerPoint.