---
title: Конвертировать презентации в несколько форматов в C++
linktitle: Конвертировать презентацию
type: docs
weight: 70
url: /ru/cpp/convert-presentation/
keywords:
- конвертировать презентацию
- экспортировать презентацию
- PPT в PPTX
- ODP в PPTX
- PPT в PDF
- PPTX в PDF
- ODP в PDF
- PPT в XPS
- PPTX в XPS
- ODP в XPS
- PPT в TIFF
- PPTX в TIFF
- ODP в TIFF
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в PPTX, PDF, XPS, TIFF и другие форматы с помощью Aspose.Slides для C++. Простой, высококачественный конвертер."
---

## **Конвертация PPT в PPTX**
### **О конвертации PPT в PPTX**
### **Конвертация PPT в PPTX с помощью Aspose.Slides**
Aspose.Slides for C++ предоставляет частичную поддержку конвертации презентаций в формате файла PPT в презентации в формате файла PPTX. Поскольку поддержка указанной функции конвертации презентаций только что была внедрена в Aspose.Slides for C++, на данный момент она обладает ограниченными возможностями и работает только с простыми формами презентаций. Основное преимущество, которое библиотека API Aspose.Slides for C++ предоставляет при конвертации презентации PPT в формат PPTX, — простота использования API для достижения желаемой цели. Пожалуйста, перейдите к этой [ссылка](/slides/ru/cpp/convert-presentation/) в раздел фрагментов кода для получения дополнительных сведений. Следующий раздел ясно иллюстрирует, какие функции поддерживаются, а какие нет при конвертации презентаций формата PPT в презентации формата PPTX.
{{% alert color="primary" %}} 
Читать далее [**Как конвертировать PPT в PPTX**](/slides/ru/cpp/convert-ppt-to-pptx/).
{{% /alert %}}
## **Конвертация презентации в PDF**
### **Об PDF**
The [Portable Document Format](https://en.wikipedia.org/wiki/PDF) is a file format that was created by Adobe System for exchange of documents between different organizations. The purpose of this format was to make it possible that contents of the documents may be represented in such a way that their visual appearance is not dependent of the platform on which it is being viewed.
### **PDF в Aspose.Slides for C++**
[PDF ](https://docs.fileformat.com/pdf/)is a file format that was created by Adobe System for exchange of documents between different organizations. The purpose of this format was to make it possible that the visual appearance of the document contents is not dependent of the platform on which it is being viewed. 

Any presentation document that can be loaded into Aspose.Slides for C++ can be converted to PDF document. You can export the presentation documents to PDF directly using Aspose.Slides for C++ component only. You do not need any other third party libraries or Aspose.PDF component for this purpose. 

{{% alert color="primary" %}} 
Читать далее [**Как конвертировать презентацию в PDF**](/slides/ru/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/).
{{% /alert %}}

## **Конвертация презентации в XPS**
### **Об XPS**
The [XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) is a page description language and a fixed-document format originally developed by Microsoft. Like PDF, XPS is a fixed-layout document format designed to preserve document fidelity and provide device-independent document appearance.
### **Конвертация презентации в XPS с помощью Aspose.Slides**
Any presentation document that can be loaded by Aspose.Slides for C++ can be converted to XPS format. Aspose.Slides for C++ uses the high-fidelity page layout and rendering engine to produce output in fixed-layout XPS document format. It is worth-mentioning that Aspose.Slides for C++ directly generates XPS without depending upon the Windows Presentation Foundation (WPF) classes that are packaged with C++ Framework 3.5 hence allowing Aspose.Slides for C++ to produce XPS documents on machines running C++ Framework versions earlier than version 3.5. You can learn about exporting the presentation documents to XPS documents through Aspose.Slides for C++ in [this topic](/slides/ru/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/).
{{% alert color="primary" %}} 
Читать далее [**Как конвертировать презентацию в XPS**.](/slides/ru/cpp/convert-powerpoint-to-xps/)
{{% /alert %}}
## **Конвертация презентации в TIFF**
### **Об TIFF**
The [Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) which is known for storing multiple images in one document was originally created by Aldus. This format is widely supported by scanning, faxing and other image manipulation applications.
### **Конвертация презентации в TIFF с помощью Aspose.Slides**
Any document that can be loaded in Aspose.Slide for C++ can also be converted to TIFF document directly by Aspose.Slides for C++ eliminating requirement of any third party component. Further, you can optionally define the size of the images in the resulting TIFF document. You can find information about exporting the presentation documents to TIFF documents through Aspose.Slides for C++ in [this topic](/slides/ru/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/).
{{% alert color="primary" %}} 
Читать далее [**Как конвертировать презентацию в TIFF**.](/slides/ru/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**Можно ли включать скрытые слайды при экспорте в PDF/XPS?**

Да. Экспорт поддерживает включение скрытых слайдов через соответствующую опцию в настройках [PDF](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)/[XPS](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) .

**Поддерживается ли сохранение в формате PDF/A (для архивного хранения)?**

Да, уровни совместимости PDF/A [доступны](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfcompliance/) (включая A-2a/A-2b/A-2u и A-3a/A-3b) при экспорте.

**Что происходит с шрифтами при конвертации: они встраиваются или заменяются?**

Существует гибкие варианты: вы можете [встраивать все глифы или только используемые подмножества](/slides/ru/cpp/embedded-font/), указать [резервный шрифт](/slides/ru/cpp/fallback-font/) и [управлять поведением](/slides/ru/cpp/font-substitution/) когда у шрифта отсутствуют некоторые начертания.

**Как можно контролировать качество и размер получаемого PDF?**

Доступны параметры для [качества JPEG](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/), [сжатия текста](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_textcompression/), а также порога [достаточного разрешения](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) для изображений, плюс режим, который выбирает [наилучшее сжатие для картинок](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) .

**Можно ли экспортировать только диапазон слайдов (например, 5–12)?**

Да, экспорт поддерживает выбор подмножества слайдов.

**Поддерживается ли многопоточная обработка нескольких файлов одновременно?**

Допустимо обрабатывать разные презентации параллельно в отдельных процессах. Важно: один и тот же объект [presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) не должен загружаться или сохраняться из [нескольких потоков](/slides/ru/cpp/multithreading/) .

**Есть ли риски при применении лицензии из разных потоков?**

Да, вызовы [license-setting](/slides/ru/cpp/licensing/) не являются потокобезопасными и требуют синхронизации.