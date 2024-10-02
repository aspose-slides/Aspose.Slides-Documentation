---
title: Конвертация PPTX в PPT на C#
linktitle: Конвертация PPTX в PPT
type: docs
weight: 21
url: /ru/net/convert-pptx-to-ppt/
keywords: "C# Конвертация PPTX в PPT, Конвертация презентации PowerPoint, PPTX в PPT, C#, Aspose.Slides"
description: "Конвертация презентации PowerPoint PPTX в PPT на C#"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPTX в формат PPT с помощью C#. Рассматриваемая тема следующая.

- Конвертация PPTX в PPT на C#

## **C# Конвертация PPTX в PPT**

Для получения примера кода на C# для конвертации PPTX в PPT, пожалуйста, смотрите раздел ниже, т.е. [Конвертация PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет в формате PPT. Указывая различные форматы сохранения, вы также можете сохранить файл PPTX в другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [C# Конвертация PPTX в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Конвертация PPTX в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Конвертация PPTX в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Конвертация PPTX в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Конвертация PPTX в изображение](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Пример кода на C# ниже конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.

```c#
// Создание объекта Presentation, представляющего файл PPTX
Presentation pres = new Presentation("presentation.pptx");

// Сохранение презентации PPTX в формате PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```