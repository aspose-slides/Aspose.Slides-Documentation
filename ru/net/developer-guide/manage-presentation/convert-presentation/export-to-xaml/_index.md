---
title: Экспорт в XAML
type: docs
weight: 30
url: /ru/net/export-to-xaml/
keywords: "Экспорт презентаций PowerPoint, Конвертация PowerPoint, XAML, PowerPoint в XAML, PPT в XAML, PPTX в XAML, C#, Csharp, .NET"
description: "Экспорт или конвертация презентации PowerPoint в XAML"
---

# **Экспорт презентаций в XAML**

{{% alert title="Info" color="info" %}} 
В [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/) мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 
{{% /alert %}} 

# **О XAML**

XAML — это описательный язык программирования, позволяющий создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Большую часть времени вы, вероятно, будете использовать дизайнер для работы с файлами XAML, но при этом по‑прежнему можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот код C# демонстрирует, как экспортировать презентацию в XAML с настройками по умолчанию:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбрать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, можно установить свойство [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) в значение true. См. пример кода C#: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**Как гарантировать предсказуемое отображение шрифтов, если оригинальный шрифт недоступен на компьютере?**

Установите [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) в [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — он используется как резервный шрифт, когда оригинальный недоступен. Это помогает избежать неожиданной замены шрифтов.

**Экспортированный XAML предназначен только для WPF или его можно использовать и в других XAML‑стэках?**

XAML — это универсальный язык разметки UI, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стеками Microsoft XAML; конкретное поведение и поддержка определённых конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Управлять этим поведением можно с помощью [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — оставьте его отключённым, если экспортировать скрытые слайды не требуется.