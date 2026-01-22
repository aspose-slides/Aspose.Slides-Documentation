---
title: Конвертировать PPTX в PPT на Android
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для Android через Java — обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с помощью Java. Рассматривается следующая тема.

- Преобразовать PPTX в PPT на Java

## **Преобразовать PPTX в PPT на Android**

Для примера кода на Java, преобразующего PPTX в PPT, смотрите раздел ниже, то есть [Преобразовать PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX в множество других форматов, таких как PDF, XPS, ODP, HTML и др., как обсуждается в этих статьях. 

- [Преобразовать PPTX в PDF на Android](/slides/ru/androidjava/convert-powerpoint-to-pdf/)
- [Преобразовать PPTX в XPS на Android](/slides/ru/androidjava/convert-powerpoint-to-xps/)
- [Преобразовать PPTX в HTML на Android](/slides/ru/androidjava/convert-powerpoint-to-html/)
- [Преобразовать PPTX в ODP на Android](/slides/ru/androidjava/save-presentation/)
- [Преобразовать PPTX в PNG на Android](/slides/ru/androidjava/convert-powerpoint-to-png/)

## **Преобразовать PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения методу **Save** класса [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Пример кода на Java ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```java
// создать объект Presentation, представляющий файл PPTX
Presentation presentation = new Presentation("template.pptx");

// сохранить презентацию в формате PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **Вопросы и ответы**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при конвертации.

**Можно ли преобразовать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы преобразовать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её в формате PPT; либо используйте сервис/API, поддерживающий параметры конвертации по отдельным слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настроить параметры защиты/шифрования](/slides/ru/androidjava/password-protected-presentation/) для сохранённого PPT.