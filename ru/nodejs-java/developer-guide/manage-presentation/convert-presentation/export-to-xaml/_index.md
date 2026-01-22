---
title: Экспорт презентаций в XAML на JavaScript
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/nodejs-java/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- преобразование PowerPoint
- преобразование OpenDocument
- преобразование презентации
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint и OpenDocument в XAML на JavaScript с помощью Aspose.Slides для Node.js — быстрое решение без Office, сохраняющее макет."
---

## **Экспорт презентаций в XAML**

Aspose.Slides поддерживает экспорт в XAML. Вы можете преобразовать свои презентации в XAML.

## **О XAML**

XAML — это описательный язык программирования, который позволяет создавать или писать пользовательские классы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Обычно вы будете использовать конструктор для работы с файлами XAML, но при желании можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот код на JavaScript показывает, как экспортировать презентацию в XAML с настройками по умолчанию:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбирать параметры из класса [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions), которые контролируют процесс экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML.

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, можно установить метод [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) в значение true. См. этот пример кода на JavaScript:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Вопросы и ответы**

**Как гарантировать предсказуемый шрифт, если оригинальный шрифт недоступен на компьютере?**

Используйте метод [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — он служит резервным шрифтом, когда оригинальный шрифт отсутствует. Это помогает избежать непредвиденных замен.

**Экспортированный XAML предназначен только для WPF или его можно использовать и в других стэках XAML?**

XAML — это общий язык разметки пользовательского интерфейса, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стеками Microsoft XAML; конкретное поведение и поддержка отдельных конструкций зависят от целевой платформы. Проверьте разметку в вашей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — оставьте его отключённым, если не требуется экспортировать скрытые слайды.