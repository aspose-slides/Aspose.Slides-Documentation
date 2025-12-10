---
title: Управление показом слайдов в C++
linktitle: Показ слайдов
type: docs
weight: 90
url: /ru/cpp/manage-slide-show/
keywords:
- тип показа
- представлено докладчиком
- просмотр индивидуально
- просмотр в киоске
- параметры показа
- непрерывное зацикливание
- без озвучки
- без анимации
- цвет пера
- показывать слайды
- пользовательский показ
- автоматический переход
- вручную
- с использованием таймингов
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как управлять показами слайдов в Aspose.Slides для C++. Легко контролируйте переходы слайдов, тайминги и многое другое в форматах PPT, PPTX и ODP."
---

В Microsoft PowerPoint параметры **Slide Show** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одна из самых важных функций в этом разделе — **Set Up Show**, которая позволяет адаптировать презентацию к конкретным условиям и аудиториям, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представленным докладчиком, просматриваемый индивидуально или в киоске), включить или отключить зацикливание, выбрать конкретные слайды для отображения и использовать тайминги. Этот этап подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`get_SlideShowSettings` — метод класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), который возвращает объект типа [SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/), позволяющий управлять параметрами показа слайдов в презентации PowerPoint. В этой статье мы рассмотрим, как использовать этот метод для настройки и контроля различных аспектов параметров показа слайдов. 

## **Выбор типа показа**

`SlideShowSettings.set_SlideShowType` определяет тип показа, который может быть экземпляром одной из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/). Использование этого метода позволяет адаптировать презентацию под разные сценарии использования, такие как автоматические киоски или ручные презентации.

Ниже приведён пример кода, который создаёт новую презентацию и устанавливает тип показа «Browsed by an individual» без отображения полосы прокрутки.
```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Включение параметров показа**

`SlideShowSettings.set_Loop` определяет, будет ли показ слайдов повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.set_ShowNarration` определяет, следует ли воспроизводить голосовые комментарии во время показа слайдов. Это полезно для автоматических презентаций, содержащих голосовое сопровождение для аудитории. `SlideShowSettings.set_ShowAnimation` определяет, следует ли воспроизводить анимацию, добавленную к объектам слайдов. Это полезно для полного визуального эффекта презентации.

Следующий пример кода создаёт новую презентацию и зацикливает показ слайдов.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Выбор слайдов для отображения**

Метод `SlideShowSettings.set_Slides` позволяет выбрать диапазон слайдов, которые будут показываться во время презентации. Это полезно, когда необходимо отображать только часть презентации, а не все слайды. Ниже приведён пример кода, который создаёт новую презентацию и задаёт диапазон слайдов для отображения с `2` по `9`.
```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Использование автоматического перехода слайдов**

Метод `SlideShowSettings.set_UseTimings` позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее определённой длительностью отображения. Пример кода ниже создаёт новую презентацию и отключает использование таймингов.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Отображение медиаконтролов**

Метод `SlideShowSettings.set_ShowMediaControls` определяет, следует ли отображать медиаконтролы (например, воспроизведение, паузу и остановку) во время показа слайдов, когда воспроизводится мультимедийный контент (например, видео или аудио). Это полезно, когда необходимо предоставить ведущему управление воспроизведением медиа во время презентации.

Ниже приведён пример кода, который создаёт новую презентацию и включает отображение медиаконтролов.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Часто задаваемые вопросы**

**Можно ли сохранить презентацию так, чтобы она открывалась сразу в режиме показа слайдов?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются сразу в режиме показа слайдов в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [during export](/slides/ru/cpp/save-presentation/).

**Можно ли исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Пометьте слайд как [hidden](https://reference.aspose.com/slides/cpp/aspose.slides/slide/set_hidden/). Скрытые слайды остаются в презентации, но не отображаются во время показа слайдов.

**Может ли Aspose.Slides воспроизводить слайд-шоу или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.