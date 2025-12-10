---
title: Конвертировать PPTX в PPT с помощью C++
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
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для C++ — обеспечьте безупречную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с использованием C++. Рассматривается следующая тема.

- Конвертация PPTX в PPT в C++

## **Конвертация PPTX в PPT в C++**

Для примера кода на C++ по конвертации PPTX в PPT см. раздел ниже, то есть [Convert PPTX to PPT](#convert-pptx-to-ppt). Код просто загружает файл PPTX и сохраняет его в формате PPT. Указывая другие форматы сохранения, вы также можете сохранять файл PPTX во многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [C++ Конвертация PPTX в PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Конвертация PPTX в XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Конвертация PPTX в HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Конвертация PPTX в ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Конвертация PPTX в Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Для конвертации PPTX в PPT просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Приведённый ниже пример кода на C++ конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```cpp
// Загрузить PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Сохранить в формате PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому при конвертации функции могут быть упрощены или растрированы.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение сохраняет всю презентацию. Чтобы конвертировать конкретные слайды, создайте новую презентацию только с этими слайдами и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли защищённые паролем презентации?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем и также [configure protection/encryption settings](/slides/ru/cpp/password-protected-presentation/) для сохраняемого PPT.