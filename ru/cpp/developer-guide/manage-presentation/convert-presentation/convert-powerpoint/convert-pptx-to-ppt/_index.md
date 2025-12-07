---
title: Конвертировать PPTX в PPT на C++
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/cpp/convert-pptx-to-ppt/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPTX
- PPTX в PPT
- сохранить PPTX как PPT
- экспортировать PPTX в PPT
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для C++ — обеспечьте беспроблемную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

Этот документ объясняет, как конвертировать презентацию PowerPoint в формате PPTX в формат PPT с помощью C++. В статье рассматривается следующая тема.

- Конвертировать PPTX в PPT на C++

## **Конвертировать PPTX в PPT на C++**

Для примера кода на C++ по конвертации PPTX в PPT см. раздел ниже, т.е. [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет в формате PPT. Указывая различные форматы сохранения, вы также можете сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C++ Конвертировать PPTX в PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Конвертировать PPTX в XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Конвертировать PPTX в HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Конвертировать PPTX в ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Конвертировать PPTX в изображение](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Конвертировать PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Пример кода на C++ ниже конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```cpp
// Загрузить PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Сохранить в формате PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Сохраняются ли все эффекты и функции PPTX при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растеризованы во время конвертации.

**Могу ли я конвертировать только выбранные слайды в PPT, а не всю презентацию?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настроить параметры защиты/шифрования](/slides/ru/cpp/password-protected-presentation/) для сохраняемого PPT.