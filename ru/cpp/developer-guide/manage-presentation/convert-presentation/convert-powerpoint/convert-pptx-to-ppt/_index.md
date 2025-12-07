---
title: Конвертация PPTX в PPT на C++
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
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для C++ — обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с использованием C++. Рассмотрены следующие темы.

- Преобразование PPTX в PPT с помощью C++

## **Преобразование PPTX в PPT с помощью C++**

Для примера кода C++ по преобразованию PPTX в PPT см. раздел ниже, а именно [Преобразовать PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C++ Преобразовать PPTX в PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Преобразовать PPTX в XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Преобразовать PPTX в HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Преобразовать PPTX в ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Преобразовать PPTX в Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Преобразовать PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Приведенный ниже пример кода C++ конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```cpp
// Загрузить PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Сохранить в формате PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Сохраняются ли все эффекты и функции PPTX при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при конвертации.

**Могу ли я конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать отдельные слайды, создайте новую презентацию, содержащую только нужные слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настройте параметры защиты/шифрования](/slides/ru/cpp/password-protected-presentation/) для сохранённого PPT.