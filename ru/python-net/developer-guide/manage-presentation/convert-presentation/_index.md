---
title: Конвертация презентаций в несколько форматов на Python
linktitle: Конвертация презентаций
type: docs
weight: 70
url: /ru/python-net/convert-presentation/
keywords:
- конвертация презентаций
- экспорт презентаций
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
description: "Конвертируйте презентации PowerPoint и OpenDocument в PPTX, PDF, XPS, TIFF и другие форматы с помощью Aspose.Slides for Python via .NET. Простой, высококачественный конвертер."
---

## **Введение**

Эта страница предоставляет обзор конвертации презентаций с помощью Aspose.Slides for Python via .NET. Здесь суммированы поддерживаемые сценарии и указаны ссылки на специализированные руководства, демонстрирующие точный код для экспорта презентаций и слайдов в форматы PDF, XPS, TIFF, а также конвертации между PPT и PPTX. При необходимости связанные статьи выделяют параметры, специфичные для формата — например, рендеринг заметок или настройка качества изображений, — и известные ограничения, такие как частичная поддержка путей PPT→PPTX. Используйте эту страницу, чтобы выбрать целевой формат, а затем следуйте приведённому рецепту.

## **Конвертация PPT в PPTX**

### **О PPT/PPTX**

PPT — старый бинарный формат PowerPoint (97–2003), в то время как PPTX — упакованный в ZIP формат Open XML, представленный в PowerPoint 2007. По сравнению с PPT, PPTX обычно создаёт более небольшие файлы, поддерживает современные функции, хорошо работает с автоматизацией документов и рекомендуется для долговременного хранения и кроссплатформенных рабочих процессов.

### **Конвертировать PPT в PPTX**

Aspose.Slides поддерживает конвертацию PPT‑презентаций в формат PPTX. Главное преимущество использования API Aspose.Slides для этой задачи — простота рабочего процесса, необходимого для достижения желаемого результата. На практике вы можете выполнить конвертацию с минимальным объёмом кода, сохраняя высокую точность слайдов, макетов и медиаконтента.

{{% alert color="primary" %}}
Подробнее: [Конвертировать PPT в PPTX на Python](/slides/ru/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Конвертация презентаций в PDF**

### **О PDF**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) — файловый формат, созданный Adobe Systems для обмена документами между организациями. Его цель — обеспечить одинаковый визуальный вид содержимого документа независимо от платформы, на которой он просматривается.

### **Конвертировать презентации в PDF**

Любую презентацию, которую можно загрузить в Aspose.Slides, можно преобразовать в PDF‑документ. Вы можете экспортировать презентации в PDF напрямую с помощью компонента Aspose.Slides; сторонние библиотеки или компонент Aspose.PDF не требуются.

{{% alert color="primary" %}}
Подробнее: [Конвертировать PPT и PPTX в PDF на Python](/slides/ru/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Конвертация презентаций в XPS**

### **О XPS**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) — язык описания страниц и фиксированный документный формат, изначально разработанный Microsoft. Как и PDF, XPS — фиксированный макет документа, предназначенный для сохранения точности отображения и обеспечения независимости от устройства.

### **Конвертировать презентации в XPS**

Любую презентацию, которую может загрузить Aspose.Slides, можно преобразовать в формат XPS. Aspose.Slides использует движок высокоточного макета страниц и рендеринга для создания вывода в фиксированном формате XPS. Примечательно, что Aspose.Slides генерирует XPS напрямую, без зависимости от Windows Presentation Foundation (WPF).

{{% alert color="primary" %}}
Подробнее: [Конвертировать презентации PowerPoint в XPS на Python](/slides/ru/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Конвертация презентаций в TIFF**

### **О TIFF**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) — растровый графический формат, известный возможностью хранения нескольких изображений (страниц) в одном файле. Первоначально разработанный компанией Aldus, он широко поддерживается сканерами, факсимильными устройствами и другими приложениями обработки изображений.

### **Конвертировать презентации в TIFF**

Любой документ, который можно загрузить в Aspose.Slides, также можно напрямую преобразовать в файл TIFF без использования сторонних компонентов. При желании вы также можете указать размер изображения для страниц в результирующем TIFF.

{{% alert color="primary" %}}
Подробнее: [Конвертировать презентации PowerPoint в TIFF на Python](/slides/ru/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**Можно ли включать скрытые слайды при экспорте в PDF/XPS?**

Да. Экспорт поддерживает включение скрытых слайдов через соответствующую опцию в настройках [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/).

**Поддерживается ли сохранение в формате PDF/A (для архивного хранения)?**

Да, уровни совместимости PDF/A [доступны](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (включая A-2a/A-2b/A-2u и A-3a/A-3b) во время экспорта.

**Что происходит со шрифтами при конвертации: они встраиваются или заменяются?**

Существует гибкая настройка: вы можете [встроить все глифы или только используемые подмножества](/slides/ru/python-net/embedded-font/), указать [запасной шрифт](/slides/ru/python-net/fallback-font/), и [управлять поведением](/slides/ru/python-net/font-substitution/) при отсутствии определённых стилей у шрифта.

**Как контролировать качество и размер получаемого PDF?**

Доступны параметры для [качества JPEG](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), [сжатия текста](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), а также порог [достаточного разрешения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) изображений, плюс режим, выбирающий [лучшее сжатие для картинок](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/).

**Можно ли экспортировать только диапазон слайдов (например, 5–12)?**

Да, экспорт поддерживает выбор подмножества слайдов.

**Поддерживается ли многопоточная обработка нескольких файлов одновременно?**

Допустимо обрабатывать разные презентации параллельно в отдельных процессах. Важно: один и тот же объект [презентации](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) не должен быть загружен или сохранён из [нескольких потоков](/slides/ru/python-net/multithreading/).

**Есть ли риски при применении лицензии из разных потоков?**

Да, вызовы [установки лицензии](/slides/ru/python-net/licensing/) не являются потокобезопасными и требуют синхронизации.