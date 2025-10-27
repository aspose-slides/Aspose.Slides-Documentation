---
title: Конвертация презентаций в несколько форматов на Python
linktitle: Конвертация презентаций
type: docs
weight: 70
url: /ru/python-net/convert-presentation/
keywords:
- конвертация презентации
- экспорт презентации
- PPT в PPTX
- PPT в PDF
- PPTX в PDF
- PPT в XPS
- PPTX в XPS
- PPT в TIFF
- PPTX в TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint и OpenDocument в PPTX, PDF, XPS, TIFF и другие форматы с помощью Aspose.Slides для Python через .NET. Просто, высококачественная конверсия."
---

## **Введение**

На этой странице представлен обзор конвертации презентаций с использованием Aspose.Slides для Python через .NET. Описаны поддерживаемые сценарии и приведены ссылки на подробные руководства, показывающие точный код для экспорта презентаций и слайдов в такие форматы, как PDF, XPS, TIFF, а также конвертации между PPT и PPTX. При необходимости связанные статьи описывают параметры, специфичные для формата — например, рендеринг заметок или настройку качества изображений — и известные ограничения, такие как частичная поддержка пути PPT→PPTX. Используйте эту страницу, чтобы выбрать целевой формат, а затем следуйте указанным рецептам.

## **Конвертация PPT в PPTX**

### **О PPT/PPTX**

PPT — это старый двоичный формат PowerPoint (97–2003), тогда как PPTX — это упакованный в ZIP формат Open XML, представленный в PowerPoint 2007. По сравнению с PPT, PPTX обычно создаёт более маленькие файлы, поддерживает современные возможности, хорошо работает с автоматизацией документов и рекомендуется для долгосрочного хранения и кроссплатформенных рабочих процессов.

### **Конвертация PPT в PPTX**

Aspose.Slides поддерживает конвертацию презентаций PPT в формат PPTX. Ключевое преимущество использования API Aspose.Slides для этой задачи — простота рабочего процесса, необходимого для получения желаемого результата. На практике вы можете выполнить конвертацию с минимумом кода, сохранив высокую точность воспроизведения слайдов, макетов и медиа.

{{% alert color="primary" %}}
Подробнее: [Конвертация PPT в PPTX на Python](/slides/ru/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Конвертация презентаций в PDF**

### **О PDF**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) — это формат файлов, созданный Adobe Systems для обмена документами между организациями. Его цель — обеспечить одинаковое визуальное отображение содержимого документа независимо от платформы, на которой документ просматривается.

### **Конвертация презентаций в PDF**

Любую презентацию, которую можно загрузить в Aspose.Slides, можно конвертировать в документ PDF. Вы можете экспортировать презентации в PDF напрямую с помощью компонента Aspose.Slides; сторонние библиотеки или компонент Aspose.PDF не требуются.

{{% alert color="primary" %}}
Подробнее: [Конвертация PPT & PPTX в PDF на Python](/slides/ru/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Конвертация презентаций в XPS**

### **О XPS**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) — это язык описания страниц и формат фиксированного документа, изначально разработанный Microsoft. Как и PDF, XPS — это формат фиксированной разметки, предназначенный для сохранения точности документа и обеспечения независимого от устройства отображения.

### **Конвертация презентаций в XPS**

Любую презентацию, которую можно загрузить в Aspose.Slides, можно конвертировать в формат XPS. Aspose.Slides использует высокоточный движок размещения страниц и рендеринга для создания вывода в фиксированном формате XPS. Примечательно, что Aspose.Slides генерирует XPS напрямую без привлечения Windows Presentation Foundation (WPF).

{{% alert color="primary" %}}
Подробнее: [Конвертация презентаций PowerPoint в XPS на Python](/slides/ru/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Конвертация презентаций в TIFF**

### **О TIFF**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) — это растровый формат изображений, известный тем, что может хранить несколько изображений (страниц) в одном файле. Изначально разработанный компанией Aldus, он широко поддерживается сканерами, факсимильными аппаратами и другими приложениями обработки изображений.

### **Конвертация презентаций в TIFF**

Любой документ, который можно загрузить в Aspose.Slides, также может быть напрямую конвертирован в файл TIFF без использования сторонних компонентов. При желании можно также указать размер изображения для страниц в результирующем TIFF.

{{% alert color="primary" %}}
Подробнее: [Конвертация презентаций PowerPoint в TIFF на Python](/slides/ru/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**Можно ли включать скрытые слайды при экспорте в PDF/XPS?**

Да. Экспорт поддерживает включение скрытых слайдов через соответствующую опцию в настройках [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/).

**Поддерживается ли сохранение в формате PDF/A (для архивного хранения)?**

Да, уровни соответствия PDF/A [доступны](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (включая A-2a/A-2b/A-2u и A-3a/A-3b) при экспорте.

**Что происходит со шрифтами при конвертации: они встраиваются или заменяются?**

Есть гибкие варианты: вы можете [встроить все глифы или только используемые подмножества](/slides/ru/python-net/embedded-font/), указать [резервный шрифт](/slides/ru/python-net/fallback-font/), и [управлять поведением](/slides/ru/python-net/font-substitution/) при отсутствии у шрифта нужных стилей.

**Как контролировать качество и размер получаемого PDF?**

Доступны параметры для [качества JPEG](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), [сжатия текста](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), и порогового [достаточного разрешения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) изображений, а также режим, выбирающий [лучшее сжатие для картинок](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/).

**Можно ли экспортировать только определённый диапазон слайдов (например, 5–12)?**

Да, экспорт поддерживает выбор подмножества слайдов.

**Поддерживается ли многопоточная обработка нескольких файлов одновременно?**

Можно обрабатывать разные презентации параллельно в отдельных процессах. Важно: один и тот же объект [презентации](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) не должен быть загружен или сохранён из [нескольких потоков](/slides/ru/python-net/multithreading/).

**Есть ли риски при применении лицензии из разных потоков?**

Да, вызовы установки лицензии [license-setting](/slides/ru/python-net/licensing/) не являются потокобезопасными и требуют синхронизации.