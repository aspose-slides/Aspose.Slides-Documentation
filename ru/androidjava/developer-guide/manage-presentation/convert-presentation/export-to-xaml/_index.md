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
description: "Конвертировать слайды PowerPoint и OpenDocument в XAML на Java с помощью Aspose.Slides для Android — быстрое решение без Office, сохраняющее ваш макет."
---

## **Экспорт презентаций в XAML**

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/), мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML.

{{% /alert %}} 

## **О XAML**

XAML — это описательный язык программирования, который позволяет создавать или описывать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Обычно вы будете работать с файлами XAML в дизайнере, но при необходимости можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот Java‑код демонстрирует, как экспортировать презентацию в XAML с настройками по умолчанию:
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

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды вашей презентации при экспорте в XAML, задайте свойству [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) значение true. См. пример Java‑кода:
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

**Как обеспечить предсказуемость шрифтов, если оригинальный шрифт недоступен на машине?**

Установите [шрифт по умолчанию для обычного текста](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) в [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — он будет использоваться в качестве запасного шрифта, когда оригинальный отсутствует. Это помогает избежать неожиданных замен.

**Экспортируемый XAML предназначен только для WPF или его можно использовать в других стеках XAML?**

XAML — это универсальный язык разметки UI, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стеком Microsoft XAML; точное поведение и поддержка конкретных конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) в [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — оставьте его отключённым, если экспорт скрытых слайдов не требуется.