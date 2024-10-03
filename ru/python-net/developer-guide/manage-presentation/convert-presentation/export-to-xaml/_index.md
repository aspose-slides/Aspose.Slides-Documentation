---
title: Экспорт в XAML
type: docs
weight: 30
url: /ru/python-net/export-to-xaml/
keywords: "Экспорт презентации PowerPoint, Конвертация PowerPoint, XAML, PowerPoint в XAML, PPT в XAML, PPTX в XAML, Python"
description: "Экспорт или конвертация презентации PowerPoint в XAML"
---

# Экспорт презентаций в XAML

{{% alert title="Информация" color="info" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/) мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

# Что такое XAML

XAML - это декларативный язык программирования, который позволяет создавать или писать пользовательские интерфейсы для приложений, особенно тех, что используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и формы Xamarin.  

XAML, являющийся языком на основе XML, - это вариант Microsoft для описания графического интерфейса пользователя. Вы, вероятно, будете использовать конструктор для работы с файлами XAML большую часть времени, но вы все равно можете писать и редактировать свой GUI. 

## Экспорт презентаций в XAML с помощью стандартных настроек

Этот код на Python показывает, как экспортировать презентацию в XAML с установленными настройками по умолчанию:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## Экспорт презентаций в XAML с помощью пользовательских настроек

Вы можете выбирать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/), которые контролируют процесс экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавил скрытые слайды из вашей презентации при экспорте в XAML, вы можете установить свойство [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) в значение true. Посмотрите этот пример кода на Python: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```