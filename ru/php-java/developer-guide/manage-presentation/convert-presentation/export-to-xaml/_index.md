---
title: "Экспорт презентаций в XAML на PHP"
linktitle: "Презентация в XAML"
type: docs
weight: 30
url: /ru/php-java/export-to-xaml/
keywords:
- "экспорт PowerPoint"
- "экспорт OpenDocument"
- "экспорт презентации"
- "конвертировать PowerPoint"
- "конвертировать OpenDocument"
- "конвертировать презентацию"
- "PowerPoint в XAML"
- "OpenDocument в XAML"
- "презентация в XAML"
- "PPT в XAML"
- "PPTX в XAML"
- "ODP в XAML"
- "сохранить PPT как XAML"
- "сохранить PPTX как XAML"
- "сохранить ODP как XAML"
- "экспорт PPT в XAML"
- "экспорт PPTX в XAML"
- "экспорт ODP в XAML"
- PHP
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint и OpenDocument в XAML с помощью Aspose.Slides для PHP через Java — быстрое решение без Office, сохраняющее ваш макет неизменным."
---

## **Экспорт презентаций в XAML**

Aspose.Slides поддерживает экспорт в XAML. Вы можете конвертировать ваши презентации в XAML.

## **О XAML**

XAML — это описательный язык программирования, который позволяет создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, являющийся языком на основе XML, — вариант Microsoft для описания графического интерфейса. Большую часть времени вы, вероятно, будете использовать дизайнер для работы с XAML‑файлами, но вы всё равно можете писать и редактировать ваш графический интерфейс. 

## **Экспорт презентаций в XAML с настройками по умолчанию**

Этот PHP‑код показывает, как экспортировать презентацию в XAML с настройками по умолчанию:
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


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбрать параметры из класса [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/), который управляет процессом экспорта и определяет, как Aspose.Slides экспортирует вашу презентацию в XAML.

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, вы можете использовать метод [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) со значением `true`. Смотрите этот пример PHP‑кода:
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


## **Часто задаваемые вопросы**

**Как обеспечить предсказуемый шрифт, если оригинальный шрифт недоступен на компьютере?**

Установите [по умолчанию обычный шрифт](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — он будет использоваться как резервный шрифт, когда оригинальный отсутствует. Это помогает избежать неожиданных замен.

**Экспортированный XAML предназначен только для WPF или его можно использовать и в других стеках XAML?**

XAML — это общий язык разметки пользовательского интерфейса, используемый в WPF, UWP и Xamarin.Forms. Экспорт нацелен на совместимость со стеками Microsoft XAML; конкретное поведение и поддержка определённых конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как можно предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — держите его отключённым, если вам не нужно экспортировать их.