---
title: Convert Presentations to Multiple Formats in Python
linktitle: Convert Presentations
type: docs
weight: 70
url: /ru/python-net/developer-guide/manage-presentation/convert-presentation/
keywords:
- convert presentation
- export presentation
- PPT to PPTX
- PPT to PDF
- PPTX to PDF
- PPT to XPS
- PPTX to XPS
- PPT to TIFF
- PPTX to TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument presentations to PPTX, PDF, XPS, TIFF and more with Aspose.Slides for Python via .NET. Simple, high-quality conversion."
---

## **Введение**

Эта страница предоставляет обзор конвертации презентаций с помощью Aspose.Slides for Python via .NET. Она суммирует поддерживаемые сценарии и указывает на целевые руководства, показывающие точный код для экспорта презентаций и слайдов в такие форматы, как PDF, XPS, TIFF, а также преобразования между PPT и PPTX. При необходимости связанные статьи выделяют параметры, специфичные для формата — например, рендеринг заметок или настройку качества изображений, — и известные ограничения, такие как частичная поддержка путей PPT→PPTX. Используйте эту страницу, чтобы выбрать целевой формат, а затем следуйте указанному рецепту.

## **Конвертация PPT в PPTX**

### **О PPT/PPTX**

PPT — старый бинарный формат PowerPoint (97–2003), тогда как PPTX — формат Open XML в ZIP‑упаковке, представленный в PowerPoint 2007. По сравнению с PPT, PPTX обычно создает более мелкие файлы, поддерживает современные возможности, хорошо работает с автоматизацией документов и рекомендуется для долговременного хранения и кросс‑платформенных рабочих потоков.

### **Конвертировать PPT в PPTX**

Aspose.Slides поддерживает преобразование презентаций PPT в формат PPTX. Ключевое преимущество использования API Aspose.Slides для этой задачи — простота рабочего процесса, необходимого для получения желаемого результата. На практике вы можете выполнить конвертацию с минимальным количеством кода, сохраняя высокую точность слайдов, макетов и медиа.

{{% alert color="primary" %}}
Читайте дальше: [Конвертировать PPT в PPTX на Python](/slides/ru/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Конвертация презентаций в PDF**

### **О PDF**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) — файловый формат, созданный компанией Adobe Systems для обмена документами между организациями. Его цель — обеспечить отображение содержимого документа с одинаковым визуальным видом независимо от платформы, на которой документ просматривается.

### **Конвертировать презентации в PDF**

Любую презентацию, которую можно загрузить в Aspose.Slides, можно преобразовать в документ PDF. Вы можете экспортировать презентации в PDF напрямую с помощью компонента Aspose.Slides; сторонние библиотеки или компонент Aspose.PDF не требуются.

{{% alert color="primary" %}}
Читайте дальше: [Конвертировать PPT и PPTX в PDF на Python](/slides/ru/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Конвертация презентаций в XPS**

### **О XPS**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) — язык описания страниц и формат фиксированного документа, изначально разработанный Microsoft. Как и PDF, XPS представляет собой формат фиксированной разметки, предназначенный для сохранения точности документа и обеспечения независимости от устройства.

### **Конвертировать презентации в XPS**

Любую презентацию, которую может загрузить Aspose.Slides, можно преобразовать в формат XPS. Aspose.Slides использует высокоточный механизм разметки страниц и рендеринга для создания вывода в фиксированном формате XPS. Примечательно, что Aspose.Slides генерирует XPS напрямую, без зависимости от Windows Presentation Foundation (WPF).

{{% alert color="primary" %}}
Читайте дальше: [Конвертировать презентации PowerPoint в XPS на Python](/slides/ru/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Конвертация презентаций в TIFF**

### **О TIFF**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) — растровый формат изображений, известный тем, что сохраняет несколько изображений (страниц) в одном файле. Изначально разработанный компанией Aldus, он широко поддерживается сканерами, факсами и другими приложениями обработки изображений.

### **Конвертировать презентации в TIFF**

Любой документ, который можно загрузить в Aspose.Slides, также можно напрямую преобразовать в файл TIFF без использования сторонних компонентов. При желании вы также можете указать размер изображения для страниц в получаемом TIFF.

{{% alert color="primary" %}}
Читайте дальше: [Конвертировать презентации PowerPoint в TIFF на Python](/slides/ru/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Могу ли я включать скрытые слайды при экспорте в PDF/XPS?**

Да. Экспорт поддерживает включение скрытых слайдов с помощью соответствующей опции в настройках [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/).

**Поддерживается ли сохранение в формате PDF/A (для архивного хранения)?**

Да, уровни соответствия PDF/A [доступны](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (включая A-2a/A-2b/A-2u и A-3a/A-3b) во время экспорта.

**Что происходит со шрифтами при конвертации: встраиваются они или заменяются?**

Существует гибкая настройка: вы можете [встраивать все глифы или только используемые подмножества](/slides/ru/python-net/embedded-font/), указать [запасный шрифт](/slides/ru/python-net/fallback-font/), а также [управлять поведением](/slides/ru/python-net/font-substitution/) при отсутствии нужных стилей у шрифта.

**Как можно контролировать качество и размер получаемого PDF?**

Доступны параметры для [качества JPEG](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), [сжатия текста](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), а также порогового [достаточного разрешения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) для изображений, плюс режим, выбирающий [наилучшее сжатие изображений](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/).

**Могу ли я экспортировать только диапазон слайдов (например, 5–12)?**

Да, экспорт поддерживает выбор подмножества слайдов.

**Поддерживается ли многопоточная обработка нескольких файлов одновременно?**

Допустимо обрабатывать разные презентации параллельно в отдельных процессах. Важно: один и тот же объект [презентации](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) не должен быть загружен или сохранён из [нескольких потоков](/slides/ru/python-net/multithreading/).

**Есть ли риски при применении лицензии из разных потоков?**

Да, вызовы установки [лицензии](/slides/ru/python-net/licensing/) не являются потокобезопасными и требуют синхронизации.