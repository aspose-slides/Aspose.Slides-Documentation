---
title: Экспорт презентаций в XAML с помощью Python
linktitle: Экспорт в XAML
type: docs
weight: 30
url: /ru/python-net/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертация PowerPoint
- конвертация OpenDocument
- конвертация презентации
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- Python
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint и OpenDocument в XAML на Python с помощью Aspose.Slides - быстрое решение без Office, сохраняющее макет."
---

## **Обзор**

XAML — описательный язык программирования, позволяющий создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Обычно вы будете использовать дизайнер для работы с файлами XAML, но при этом по‑прежнему можете писать и редактировать ваш GUI. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

В этом примере на Python показано, как экспортировать презентацию в XAML с настройками по умолчанию:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбирать параметры из класса [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, вы можете установить свойство [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) в значение `True`. См. пример кода на Python: 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **Часто задаваемые вопросы**

**Как гарантировать предсказуемый шрифт, если исходный шрифт недоступен на машине?**

Установите [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) в [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — он будет использоваться как резервный шрифт, когда оригинальный отсутствует. Это помогает избежать неожиданной замены.

**Экспортированный XAML предназначен только для WPF или его можно использовать и в других стэках XAML?**

XAML — общий язык разметки UI, используемый в WPF, UWP и Xamarin.Forms. Экспорт нацелен на совместимость со стеками Microsoft XAML; точное поведение и поддержка конкретных конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) в [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — оставляйте его отключённым, если экспортировать скрытые слайды не требуется.