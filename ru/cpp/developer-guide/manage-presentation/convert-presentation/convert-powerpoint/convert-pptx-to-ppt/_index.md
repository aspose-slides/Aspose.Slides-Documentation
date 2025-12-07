---
title: Преобразовать PPTX в PPT на C++
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/cpp/convert-pptx-to-ppt/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPTX
- PPTX в PPT
- сохранить PPTX как PPT
- экспортировать PPTX в PPT
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Легко преобразуйте PPTX в PPT с помощью Aspose.Slides для C++ - обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с использованием C++. Рассмотрена следующая тема.

- Преобразовать PPTX в PPT с помощью C++

## **Преобразование PPTX в PPT на C++**

Для примера кода на C++ по преобразованию PPTX в PPT см. раздел ниже, а именно [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранить файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C++ Преобразовать PPTX в PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Преобразовать PPTX в XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Преобразовать PPTX в HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Преобразовать PPTX в ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Преобразовать PPTX в изображение](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Преобразование PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Пример кода на C++ ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```cpp
// Загрузить PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Сохранить в формате PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Сохраняются ли все эффекты и функции PPTX при сохранении в старый формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при конвертации.

**Могу ли я преобразовать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы преобразовать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно можно воспользоваться сервисом/API, поддерживающим параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настроить параметры защиты/шифрования](/slides/ru/cpp/password-protected-presentation/) для сохраняемого PPT.