---
title: Экспорт в XAML
type: docs
weight: 30
url: /net/export-to-xaml/
keywords: "Экспорт презентации PowerPoint, Конвертировать PowerPoint, XAML, PowerPoint в XAML, PPT в XAML, PPTX в XAML, C#, Csharp, .NET"
description: "Экспортировать или конвертировать презентацию PowerPoint в XAML"
---

# Экспорт презентаций в XAML

{{% alert title="Информация" color="info" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/) мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

# О XAML

XAML — это дескриптивный язык программирования, который позволяет создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и формы Xamarin.  

XAML, который является языком на основе XML, — это вариант Microsoft для описания графического интерфейса. Обычно вы будете использовать дизайнер для работы с файлами XAML, но вы все еще можете писать и редактировать свой графический интерфейс. 

## Экспорт презентаций в XAML с использованием стандартных параметров

Этот код на C# показывает, как экспортировать презентацию в XAML с использованием стандартных настроек:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## Экспорт презентаций в XAML с использованием пользовательских параметров

Вы можете выбрать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions), которые контролируют процесс экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, вы можете установить свойство [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) в true. Вот этот пример кода на C#: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```