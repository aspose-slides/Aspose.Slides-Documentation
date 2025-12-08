---
title: Конвертировать PPT в PPTX на C#
linktitle: Конвертировать PPT в PPTX
type: docs
weight: 20
url: /ru/net/convert-ppt-to-pptx/
keywords: "C# Конвертировать PPT в PPTX, Конвертировать презентацию PowerPoint, PPT в PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертировать PowerPoint PPT в PPTX на C# или .NET"
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью C# и онлайн‑приложения преобразования PPT в PPTX. Рассматривается следующая тема.

- [Преобразовать PPT в PPTX на C#](#convert-ppt-to-pptx)

## **C# Преобразование PPT в PPTX**

Для примера кода на C# по преобразованию PPT в PPTX см. раздел ниже, то есть [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях. 

- [C# Convert PPT to PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convert PPT to XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convert PPT to HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convert PPT to ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convert PPT to Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно преобразовать тысячи презентаций PPT в формат PPTX, лучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API поддерживает полную совместимость для преобразования презентаций PPT в PPTX и позволяет:

- Преобразовать сложные структуры мастеров, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовать презентацию, содержащую текстуры и стили заполнения картинками для автофигур.
- Преобразовать презентацию с заполнителями, текстовыми фреймами и текстовыми контейнерами.

{{% alert color="primary" %}} 

Взгляните на [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) приложение:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей преобразования PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его уже в формате PPTX.

Найдите другие живые [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) примеры.
{{% /alert %}} 

## **Преобразовать PPT в PPTX**
Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). Пример кода на C# ниже преобразует презентацию из PPT в PPTX, используя параметры по умолчанию.
```c#
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Сохранение презентации PPTX в формате PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Читайте подробнее о [**PPT vs PPTX**](/slides/ru/net/ppt-vs-pptx/) форматах презентаций и о том, как [**Aspose.Slides поддерживает преобразование PPT в PPTX**](/slides/ru/net/convert-ppt-to-pptx/).

## **FAQ**

**В чем разница между форматами PPT и PPTX?**

PPT — это старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — это новый XML‑основанный формат, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают более высокую производительность, меньший размер и лучшую восстановляемость данных.

**Можно ли преобразовать PPT в PPTX с помощью .NET?**

Да, используя библиотеку Aspose.Slides for .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего за несколько строк кода.

**Поддерживает ли Aspose.Slides пакетное преобразование нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования множества файлов PPT в PPTX, что подходит для пакетных сценариев.

**Сохранятся ли содержание и форматирование после преобразования?**

Aspose.Slides обеспечивает высокую точность преобразования презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

**Можно ли преобразовать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает преобразование файлов PPT в несколько форматов, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Возможно ли преобразовать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides for .NET — это автономный API, не требующий Microsoft PowerPoint или стороннего программного обеспечения для выполнения преобразования.

**Существует ли онлайн‑инструмент для преобразования PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения преобразования напрямую в браузере без написания кода.