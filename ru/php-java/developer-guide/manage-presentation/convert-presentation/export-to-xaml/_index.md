---
title: Экспорт презентаций в XAML на PHP
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/php-java/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
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
- PHP
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint и OpenDocument в XAML с помощью Aspose.Slides для PHP через Java — быстрое решение без Office, сохраняющее макет."
---

## **Экспорт презентаций в XAML**

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML.

{{% /alert %}} 

## **О XAML**

XAML — это описательный язык программирования, который позволяет создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Обычно вы будете работать с файлами XAML в дизайнере, но при необходимости можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

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

Вы можете выбирать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML.

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из презентации при экспорте в XAML, можно установить свойство [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) в значение true. Смотрите пример PHP‑кода:
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


## **FAQ**

**Как обеспечить предсказуемый шрифт, если оригинальный шрифт недоступен на машине?**

Установите [шрифт по умолчанию для обычного текста](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — он будет использоваться как запасной шрифт, когда оригинальный отсутствует. Это помогает избежать неожиданной замены.

**Экспортируемый XAML предназначен только для WPF или его можно использовать и в других стэках XAML?**

XAML — это общий язык разметки UI, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стэками Microsoft XAML; точное поведение и поддержка конкретных конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Управлять этим можно через [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — оставляйте его отключённым, если экспорт скрытых слайдов не требуется.