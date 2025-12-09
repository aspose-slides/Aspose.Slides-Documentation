---
title: Конвертировать PPT в PPTX в .NET
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/net/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Конвертировать устаревшие презентации PPT в современные PPTX быстро в .NET с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода C#, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с использованием C# и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- [Конвертировать PPT в PPTX на C#](#convert-ppt-to-pptx)

## **C# Конвертация PPT в PPTX**

Для примера кода C# для конвертации PPT в PPTX см. раздел ниже, а именно [Конвертировать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т. д., как обсуждается в этих статьях. 

- [C# Конвертировать PPT в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Конвертировать PPT в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Конвертировать PPT в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Конвертировать PPT в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Конвертировать PPT в изображение](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам требуется конвертировать тысячи презентаций PPT в формат PPTX, наилучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколькими строками кода. API обеспечивает полную совместимость для конвертации презентаций PPT в PPTX, и возможно:

- Конвертировать сложные структуры мастеров, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и стили заполнения изображениями для автофигур.
- Конвертировать презентацию с заполнителями, текстовыми рамками и текстовыми объектами.

{{% alert color="primary" %}} 

Посмотрите на приложение [**Конвертация PPT в PPTX Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в конвертированном виде PPTX.

Найдите другие живые [**Конвертация Aspose.Slides**](https://products.aspose.app/slides/conversion/) примеры.
{{% /alert %}} 


## **Конвертировать PPT в PPTX**
Чтобы конвертировать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). Приведенный ниже пример кода C# конвертирует презентацию из PPT в PPTX, используя параметры по умолчанию.
```c#
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Сохранение презентации PPTX в формате PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Узнайте больше о форматах презентаций [**PPT против PPTX**](/slides/ru/net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/net/convert-ppt-to-pptx/).

## **Вопросы и ответы**

**В чем разница между форматами PPT и PPTX?**

PPT — это более старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Можно ли конвертировать PPT в PPTX с помощью .NET?**

Да, используя библиотеку Aspose.Slides для .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего за несколько строк кода.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации нескольких файлов PPT в PPTX, что делает его подходящим для сценариев пакетной конвертации.

**Будут ли сохранены содержание и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

**Можно ли конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в несколько форматов, включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides для .NET — это автономный API, который не требует установленного Microsoft PowerPoint или какого-либо стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете использовать бесплатное веб‑приложение [Конвертер PPT в PPTX Aspose.Slides](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.