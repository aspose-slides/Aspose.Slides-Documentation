---
title: Экспорт презентаций в XAML на Android
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint и OpenDocument в XAML на Java с помощью Aspose.Slides для Android — быстрое решение без Office, сохраняющее макет без изменений."
---

## **Экспорт презентаций в XAML**

Aspose.Slides поддерживает экспорт в XAML. Вы можете конвертировать свои презентации в XAML.

## **О XAML**

XAML — описательный язык программирования, позволяющий создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, являющийся языком на основе XML, представляет собой вариант Microsoft для описания GUI. Обычно вы будете использовать дизайнер для работы с файлами XAML, но при желании можете писать и редактировать интерфейс вручную.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот Java‑код показывает, как экспортировать презентацию в XAML с настройками по умолчанию:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбрать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML.

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, установите свойство [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) в значение true. См. пример Java‑кода:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как обеспечить предсказуемое использование шрифтов, если оригинальный шрифт недоступен на машине?**

Установите [шрифт по умолчанию для обычного текста](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) в [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — он будет использоваться как резервный шрифт, когда оригинальный отсутствует. Это помогает избежать непредвиденных замен.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стеках XAML?**

XAML — общий язык разметки UI, используемый в WPF, UWP и Xamarin.Forms. Экспорт нацелен на совместимость со стеками Microsoft XAML; конкретное поведение и поддержка определённых конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим через [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) в [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — оставьте его отключённым, если не требуется экспортировать скрытые слайды.