---
title: Экспорт в XAML
type: docs
weight: 30
url: /ru/nodejs-java/export-to-xaml/
---

## **Экспорт презентаций в XAML**

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-6-release-notes/) мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML.

{{% /alert %}} 

## **О XAML**

XAML — описательный язык программирования, позволяющий создавать или писать пользовательские классы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.

XAML, являющийся XML‑основанным языком, — вариант Microsoft для описания графического интерфейса. Обычно вы используете дизайнер для работы с файлами XAML, но при этом можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот код JavaScript показывает, как экспортировать презентацию в XAML с настройками по умолчанию:
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

Вы можете выбрать параметры из класса [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML.

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, вы можете установить метод [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) в значение true. См. пример кода JavaScript:
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


## **FAQ**

**Как гарантировать предсказуемый шрифт, если оригинальный шрифт недоступен на машине?**

Используйте [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — он используется как запасной шрифт, когда оригинальный недоступен. Это помогает избежать неожиданных замен.

**Экспортированный XAML предназначен только для WPF или его можно использовать и в других стэках XAML?**

XAML — общий язык разметки пользовательского интерфейса, используемый в WPF, UWP и Xamarin.Forms. Экспорт нацелен на совместимость со стеками Microsoft XAML; точное поведение и поддержка конкретных конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как можно предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением с помощью [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — оставьте его отключённым, если экспорт скрытых слайдов не нужен.