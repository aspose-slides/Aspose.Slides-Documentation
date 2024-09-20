---
title: Экспорт в XAML
type: docs
weight: 30
url: /cpp/export-to-xaml/

---

# Экспорт презентаций в XAML

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/) мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

# О XAML

XAML - это описательный язык программирования, который позволяет вам создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Универсальная платформа Windows) и формы Xamarin.  

XAML, который является языком на основе XML, представляет собой вариант Microsoft для описания графического интерфейса. Вы, скорее всего, будете использовать дизайнер для работы с файлами XAML большую часть времени, но при этом вы все равно можете писать и редактировать свой графический интерфейс.

## Экспорт презентаций в XAML с параметрами по умолчанию

Этот код на C++ показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## Экспорт презентаций в XAML с пользовательскими параметрами

Вы можете выбрать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options), которые контролируют процесс экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавил скрытые слайды из вашей презентации при экспорте в XAML, вы можете передать значение true методу [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Вот этот образец кода на C++: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```