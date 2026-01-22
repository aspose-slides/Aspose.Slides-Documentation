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

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с помощью C++. Рассматривается следующая тема.

- Преобразовать PPTX в PPT на C++

## **Преобразовать PPTX в PPT на C++**

Для получения примера кода C++ для преобразования PPTX в PPT см. раздел ниже, то есть [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждалось в этих статьях. 

- [Конвертировать PPTX в PDF на C++](/slides/ru/cpp/convert-powerpoint-to-pdf/)
- [Конвертировать PPTX в XPS на C++](/slides/ru/cpp/convert-powerpoint-to-xps/)
- [Конвертировать PPTX в HTML на C++](/slides/ru/cpp/convert-powerpoint-to-html/)
- [Конвертировать PPTX в ODP на C++](/slides/ru/cpp/save-presentation/)
- [Конвертировать PPTX в PNG на C++](/slides/ru/cpp/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Пример кода C++ ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```cpp
// Загрузить PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Сохранить в формате PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **Вопросы и ответы**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растеризованы во время преобразования.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать конкретные слайды, создайте новую презентацию только с этими слайдами и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [configure protection/encryption settings](/slides/ru/cpp/password-protected-presentation/) для сохраняемого PPT.