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
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для C++ — обеспечьте беспрепятственную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с помощью C++. Рассматривается следующая тема.

- Преобразование PPTX в PPT с помощью C++

## **Преобразование PPTX в PPT с помощью C++**

Для примера кода C++ для преобразования PPTX в PPT см. раздел ниже, а именно [Преобразовать PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранять файл PPTX во многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C++ Преобразовать PPTX в PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Преобразовать PPTX в XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Преобразовать PPTX в HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Преобразовать PPTX в ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Преобразовать PPTX в Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Преобразовать PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Приведённый ниже пример кода C++ преобразует презентацию из PPTX в PPT с использованием параметров по умолчанию.
```cpp
// Загрузить PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Сохранить в формате PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Сохраняются ли все эффекты и функции PPTX при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при преобразовании.

**Можно ли преобразовать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение ориентировано на всю презентацию. Чтобы преобразовать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры преобразования по слайдам.

**Поддерживаются ли презентации с паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настроить параметры защиты/шифрования](/slides/ru/cpp/password-protected-presentation/) для сохранённого PPT.