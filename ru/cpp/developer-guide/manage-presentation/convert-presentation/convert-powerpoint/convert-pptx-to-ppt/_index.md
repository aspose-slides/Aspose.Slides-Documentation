---
title: Конвертация PPTX в PPT на C++
linktitle: Конвертация PPTX в PPT
type: docs
weight: 21
url: /cpp/convert-pptx-to-ppt/
keywords: "C++ Конвертация PPTX в PPT, Конвертация презентации PowerPoint, PPTX в PPT, Python, Aspose.Slides"
description: "Конвертация презентации PowerPoint PPTX в PPT на C++"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPTX в формат PPT с использованием C++. Рассматриваемая тема:

- Конвертация PPTX в PPT на C++

## **C++ Конвертация PPTX в PPT**

Для примера кода на C++, который конвертирует PPTX в PPT, смотрите раздел ниже, т.е. [Конвертация PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет в формате PPT. Указывая различные форматы сохранения, вы также можете сохранить файл PPTX в множество других форматов, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [C++ Конвертация PPTX в PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Конвертация PPTX в XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Конвертация PPTX в HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Конвертация PPTX в ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Конвертация PPTX в изображение](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Пример кода на C++ ниже конвертирует презентацию из PPTX в PPT с использованием параметров по умолчанию.

```cpp
// Загрузите PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Сохраните в формате PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```