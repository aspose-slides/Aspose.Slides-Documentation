---
title: Конвертация презентаций в несколько форматов на Python
linktitle: Конвертация презентаций
type: docs
weight: 70
url: /ru/python-net/convert-presentation/
keywords:
- конвертировать презентацию
- экспортировать презентацию
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
description: "Конвертируйте презентации PowerPoint и OpenDocument в PPTX, PDF, XPS, TIFF и другие форматы с помощью Aspose.Slides для Python через .NET. Простая, высококачественная конверсия."
---

## **Введение**

Эта страница предоставляет обзор конвертации презентаций с Aspose.Slides для Python через .NET. Она резюмирует поддерживаемые сценарии и указывает на специализированные руководства, показывающие точный код для экспорта презентаций и слайдов в форматы такие как PDF, XPS, TIFF, а также конвертации между PPT и PPTX. При необходимости связанные статьи выделяют параметры, специфичные для формата — например, рендеринг заметок или настройку качества изображений — и известные ограничения, такие как частичная поддержка путей PPT→PPTX. Используйте эту страницу, чтобы выбрать целевой формат, а затем следуйте связанному рецепту.

## **Конвертация PPT в PPTX**

### **О PPT/PPTX**

PPT — это старый бинарный формат PowerPoint (97–2003), тогда как PPTX — это упакованный в ZIP формат Open XML, представленный в PowerPoint 2007. По сравнению с PPT, PPTX обычно создаёт более небольшие файлы, поддерживает современные функции, хорошо работает с автоматизацией документов и рекомендуется для долговременного хранения и кроссплатформенных рабочих процессов.

### **Конвертация PPT в PPTX**

Aspose.Slides поддерживает конвертацию презентаций PPT в формат PPTX. Ключевое преимущество использования API Aspose.Slides для этой задачи — простота рабочего процесса, необходимого для получения желаемого результата. На практике вы можете выполнить конвертацию с минимальным объёмом кода, сохраняя высокую точность слайдов, макетов и медиа.

{{% alert color="primary" %}}
Подробнее:[Convert PPT to PPTX in Python](/slides/ru/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Конвертация презентаций в PDF**

### **О PDF**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) — это формат файлов, созданный Adobe Systems для обмена документами между организациями. Его цель — обеспечить отображение содержимого документа с одинаковым визуальным видом независимо от платформы, на которой документ просматривается.

### **Конвертация презентаций в PDF**

Любая презентация, которую можно загрузить в Aspose.Slides, может быть конвертирована в документ PDF. Вы можете экспортировать презентации в PDF напрямую с помощью компонента Aspose.Slides; сторонние библиотеки или компонент Aspose.PDF не требуются.

{{% alert color="primary" %}}
Подробнее:[Convert PPT & PPTX to PDF in Python](/slides/ru/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Конвертация презентаций в XPS**

### **О XPS**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) — это язык описания страниц и формат фиксированного документа, первоначально разработанный Microsoft. Как и PDF, XPS — это формат фиксированного расположения страниц, предназначенный для сохранения точности документа и обеспечения независимого от устройств отображения.

### **Конвертация презентаций в XPS**

Любая презентация, которую может загрузить Aspose.Slides, может быть конвертирована в формат XPS. Aspose.Slides использует высокоточный движок верстки страниц и рендеринга для создания вывода в фиксированном формате XPS. Примечательно, что Aspose.Slides генерирует XPS напрямую без использования Windows Presentation Foundation (WPF).

{{% alert color="primary" %}}
Подробнее:[Convert PowerPoint Presentations to XPS in Python](/slides/ru/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Конвертация презентаций в TIFF**

### **О TIFF**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) — это растровый формат изображений, известный тем, что хранит несколько изображений (страниц) в одном файле. Первоначально разработанный Aldus, он широко поддерживается сканерами, факсами и другими приложениями обработки изображений.

### **Конвертация презентаций в TIFF**

Любой документ, который можно загрузить в Aspose.Slides, также может быть напрямую конвертирован в файл TIFF без каких-либо сторонних компонентов. Вы также можете при необходимости указать размер изображения для страниц в полученном TIFF.

{{% alert color="primary" %}}
Подробнее:[Convert PowerPoint Presentations to TIFF in Python](/slides/ru/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Могу ли я включать скрытые слайды при экспорте в PDF/XPS?**  
Да. Экспорт поддерживает включение скрытых слайдов с помощью соответствующей опции в настройках [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) .

**Поддерживается ли сохранение в формат PDF/A (для архивного хранения)?**  
Да, уровни совместимости PDF/A [доступны](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (включая A-2a/A-2b/A-2u и A-3a/A-3b) при экспорте.

**Что происходит со шрифтами при конвертации: они встраиваются или заменяются?**  
Существует гибкие параметры: вы можете [встроить все глифы или только используемые подмножества](/slides/ru/python-net/embedded-font/), указать [резервный шрифт](/slides/ru/python-net/fallback-font/), и [управлять поведением](/slides/ru/python-net/font-substitution/) когда у шрифта отсутствуют определённые стили.

**Как я могу контролировать качество и размер получаемого PDF?**  
Доступны параметры для [качества JPEG](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), [сжатия текста](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), и порога [достаточного разрешения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) для изображений, а также режим, который выбирает [наилучшее сжатие изображений](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) .

**Могу ли я экспортировать только диапазон слайдов (например, 5–12)?**  
Да, экспорт поддерживает выбор подмножества слайдов.

**Поддерживается ли многопоточная обработка нескольких файлов одновременно?**  
Можно обрабатывать различные презентации параллельно в отдельных процессах. Важно: один и тот же объект [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) не должен быть загружен или сохранён из [нескольких потоков](/slides/ru/python-net/multithreading/) .

**Есть ли риски при применении лицензии из разных потоков?**  
Да, вызовы [license-setting](/slides/ru/python-net/licensing/) не являются потокобезопасными и требуют синхронизации.