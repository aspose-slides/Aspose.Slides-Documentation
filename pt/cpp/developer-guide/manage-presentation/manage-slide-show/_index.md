---
title: Gerenciar Exibição de Slides em C++
linktitle: Exibição de Slides
type: docs
weight: 90
url: /pt/cpp/manage-slide-show/
keywords:
- tipo de exibição
- apresentado por palestrante
- naveg·ado por indivíduo
- naveg·ado em quiosque
- opções de exibição
- repetição contínua
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
- C++
- Aspose.Slides
description: "Aprenda a gerenciar apresentações de slides no Aspose.Slides para C++. Controle transições de slides, cronometragens e muito mais em formatos PPT, PPTX e ODP com facilidade."
---
## **Introdução**

No Microsoft PowerPoint, as configurações de **Apresentação de Slides** são uma ferramenta essencial para preparar e apresentar apresentações profissionais. Um dos recursos mais importantes nessa seção é **Configurar Apresentação**, que permite adaptar sua apresentação a condições e públicos específicos, garantindo flexibilidade e conveniência. Com esse recurso, você pode selecionar o tipo de exibição (por exemplo, apresentada por um palestrante, navegada por um indivíduo ou navegada em um quiosque), habilitar ou desabilitar a reprodução em loop, escolher slides específicos para exibir e usar cronometragens. Essa etapa de preparação é crucial para tornar sua apresentação mais eficaz e profissional.

`get_SlideShowSettings` é um método da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que devolve um objeto do tipo [SlideShowSettings](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slideshowsettings/), permitindo gerenciar as configurações de exibição de slides em uma apresentação do PowerPoint. Neste artigo, exploraremos como usar esse método para configurar e controlar vários aspectos das configurações de exibição de slides. 

## **Selecionar Tipo de Exibição**

`SlideShowSettings.set_SlideShowType` define o tipo de exibição de slides, que pode ser uma instância das seguintes classes: [PresentedBySpeaker](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pt/cpp/aspose.slides/browsedbyindividual/) ou [BrowsedAtKiosk](https://reference.aspose.com/slides/pt/cpp/aspose.slides/browsedatkiosk/). Usar esse método permite adaptar a apresentação para diferentes cenários de uso, como quiosques automatizados ou apresentações manuais.

O exemplo de código abaixo cria uma nova apresentação e define o tipo de exibição como “Navegada por um indivíduo” sem exibir a barra de rolagem.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Habilitar Opções de Exibição**

`SlideShowSettings.set_Loop` determina se a exibição de slides deve repetir em loop até ser interrompida manualmente. Isso é útil para apresentações automatizadas que precisam rodar continuamente. `SlideShowSettings.set_ShowNarration` determina se as narrações de voz devem ser reproduzidas durante a exibição de slides. É útil para apresentações automatizadas que contêm orientações de voz para a audiência. `SlideShowSettings.set_ShowAnimation` determina se as animações adicionadas aos objetos dos slides devem ser reproduzidas. Isso é útil para fornecer o efeito visual completo da apresentação.

O exemplo de código a seguir cria uma nova apresentação e coloca a exibição de slides em loop.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Selecionar Slides a Exibir**

O método `SlideShowSettings.set_Slides` permite selecionar um intervalo de slides a serem exibidos durante a apresentação. Isso é útil quando se deseja mostrar apenas parte da apresentação, em vez de todos os slides. O exemplo de código a seguir cria uma nova apresentação e define o intervalo de slides a ser exibido dos slides `2` ao `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usar Avanço Automático de Slides**

`SlideShowSettings.set_UseTimings` permite habilitar ou desabilitar o uso de cronometragens pré‑definidas para cada slide. Isso é útil para avançar slides automaticamente com durações de exibição predefinidas. O exemplo de código abaixo cria uma nova apresentação e desabilita o uso de cronometragens.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Exibir Controles de Mídia**

`SlideShowSettings.set_ShowMediaControls` determina se os controles de mídia (como reproduzir, pausar e parar) devem ser exibidos durante a exibição de slides quando conteúdo multimídia (por exemplo, vídeo ou áudio) estiver sendo reproduzido. Isso é útil quando você deseja dar ao apresentador controle sobre a reprodução de mídia durante a apresentação.

O exemplo de código a seguir cria uma nova apresentação e habilita a exibição dos controles de mídia.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Posso salvar uma apresentação para que ela abra diretamente no modo de exibição de slides?**

Sim. Salve o arquivo como PPSX ou PPSM; esses formatos são iniciados diretamente em modo de exibição de slides ao serem abertos no PowerPoint. No Aspose.Slides, escolha o formato de salvamento correspondente [durante a exportação](/slides/pt/cpp/save-presentation/).

**Posso excluir slides individuais da exibição sem removê‑los do arquivo?**

Sim. Marque um slide como [oculto](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/set_hidden/). Slides ocultos permanecem na apresentação, mas não são exibidos durante a exibição de slides.

**Aspose.Slides pode reproduzir uma exibição de slides ou controlar uma apresentação ao vivo na tela?**

Não. Aspose.Slides edita, analisa e converte arquivos de apresentação; a reprodução real é feita por um aplicativo visualizador, como o PowerPoint.