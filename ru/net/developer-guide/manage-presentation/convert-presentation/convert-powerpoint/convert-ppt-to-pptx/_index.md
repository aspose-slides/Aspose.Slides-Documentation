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
description: "Конвертируйте устаревшие презентации PPT в современный формат PPTX быстро в .NET с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода C#, без зависимости от Microsoft Office."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью C# и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема.

- [Преобразовать PPT в PPTX на C#](#convert-ppt-to-pptx)

## **C# Преобразование PPT в PPTX**

Для примера кода C# по преобразованию PPT в PPTX см. раздел ниже, то есть [Преобразовать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT во многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [C# Преобразовать PPT в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Преобразовать PPT в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Преобразовать PPT в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Преобразовать PPT в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Преобразовать PPT в Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно преобразовать тысячи презентаций PPT в формат PPTX, наилучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего несколькими строками кода. API обеспечивает полную совместимость для конвертации презентаций PPT в PPTX, и можно:

- Преобразовать сложные структуры мастеров, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовать презентацию с текстурами и стилями заливки изображениями для автофигур.
- Преобразовать презентацию с заполнителями, текстовыми рамками и текстовыми объектами.

{{% alert color="primary" %}} 

Ознакомьтесь с приложением [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в конвертированном виде PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Преобразовать PPT в PPTX**

Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) . Пример кода C# ниже конвертирует презентацию из PPT в PPTX, используя параметры по умолчанию.
```c#
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Сохранение презентации PPTX в формате PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/net/convert-ppt-to-pptx/).

## **Вопросы и ответы**

**Какова разница между форматами PPT и PPTX?**

PPT — это более старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый XML‑основанный формат, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер файлов и улучшенное восстановление данных.

**Можно ли преобразовать PPT в PPTX с помощью .NET?**

Да, используя библиотеку Aspose.Slides для .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего несколькими строками кода.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования множества файлов PPT в PPTX, что подходит для пакетных сценариев.

**Будут ли сохранены содержимое и форматирование после конвертации?**

Aspose.Slides обеспечивает высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

**Можно ли конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в несколько форматов, включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли преобразовать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides для .NET — это автономный API и не требует Microsoft PowerPoint или стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без необходимости писать код.