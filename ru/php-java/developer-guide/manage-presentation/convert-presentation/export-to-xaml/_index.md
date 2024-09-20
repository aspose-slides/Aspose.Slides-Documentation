---
title: Экспорт в XAML
type: docs
weight: 30
url: /php-java/export-to-xaml/

---

# Экспорт презентаций в XAML

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/) мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML.

{{% /alert %}} 

# Об XAML

XAML — это описательный язык программирования, который позволяет создавать или писать пользовательские интерфейсы для приложений, особенно для тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и формы Xamarin.  

XAML, который является языком на основе XML, является вариантом Microsoft для описания графического интерфейса пользователя (GUI). Вы, скорее всего, будете использовать дизайнер для работы с файлами XAML большую часть времени, но вы все равно можете писать и редактировать свой GUI. 

## Экспорт презентаций в XAML с параметрами по умолчанию

Этот код PHP показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Экспорт презентаций в XAML с пользовательскими параметрами

Вы можете выбрать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions), которые контролируют процесс экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML.

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, вы можете задать свойство [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) в значение true. Ознакомьтесь с этим примером кода PHP:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```