---
title: Экспорт в XAML
type: docs
weight: 30
url: /java/export-to-xaml/

---

# Экспортирование презентаций в XAML

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/) мы внедрили поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

# О XAML

XAML — это декларативный язык программирования, который позволяет вам создавать или писать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и формы Xamarin.  

XAML, который является языком на основе XML, является вариантом Microsoft для описания графического интерфейса. Вы, вероятно, будете использовать дизайнер для работы с файлами XAML большую часть времени, но вы все равно можете писать и редактировать свой интерфейс. 

## Экспорт презентаций в XAML с помощью стандартных параметров

Этот код Java показывает, как экспортировать презентацию в XAML с помощью настроек по умолчанию:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## Экспорт презентаций в XAML с помощью кастомных параметров

Вы можете выбрать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions), которые контролируют процесс экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, вы можете установить свойство [ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) в true. См. этот пример кода на Java: 

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