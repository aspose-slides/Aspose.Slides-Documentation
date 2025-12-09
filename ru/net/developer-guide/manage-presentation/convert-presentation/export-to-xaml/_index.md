---
title: Экспорт презентаций в XAML в .NET
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/net/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- преобразовать PowerPoint
- преобразовать OpenDocument
- преобразовать презентацию
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспорт PPT в XAML
- экспорт PPTX в XAML
- экспорт ODP в XAML
- .NET
- C#
- Aspose.Slides
description: "Конвертировать слайды PowerPoint и OpenDocument в XAML в .NET с помощью Aspose.Slides — быстрое решение без Office, сохраняющее макет без изменений."
---

# **Экспорт презентаций в XAML**

{{% alert title="Info" color="info" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

# **О XAML**

XAML — описательный язык программирования, позволяющий строить или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Большую часть времени вы, вероятно, будете использовать дизайнер для работы с файлами XAML, но также можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот код C# показывает, как экспортировать презентацию в XAML с настройками по умолчанию:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбрать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, вы можете установить свойство [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) в значение true. См. пример кода C#: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**Как гарантировать предсказуемый шрифт, если оригинальный шрифт недоступен на машине?**

Установите [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) в [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — он будет использоваться в качестве запасного шрифта, когда оригинальный недоступен. Это помогает избежать неожиданной подстановки.

**Экспортированный XAML предназначен только для WPF или его можно использовать и в других XAML‑стэках?**

XAML — это общий язык разметки пользовательского интерфейса, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стеками Microsoft XAML; точное поведение и поддержка конкретных конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — оставьте его отключённым, если экспорт скрытых слайдов не требуется.