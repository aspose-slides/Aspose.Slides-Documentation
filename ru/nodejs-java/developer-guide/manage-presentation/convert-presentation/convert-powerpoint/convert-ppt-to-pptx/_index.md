---
title: Конвертировать PPT в PPTX с помощью JavaScript
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Быстро конвертировать устаревшие презентации PPT в современный формат PPTX с помощью Aspose.Slides для Node.js — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью JavaScript и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Конвертировать PPT в PPTX с помощью JavaScript

## **JavaScript конвертация PPT в PPTX**

Для примера кода JavaScript, преобразующего PPT в PPTX, см. раздел ниже — [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях.

- [Конвертировать PPT в PDF с помощью JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/)
- [Конвертировать PPT в XPS с помощью JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-xps/)
- [Конвертировать PPT в HTML с помощью JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-html/)
- [Конвертировать PPT в ODP с помощью JavaScript](/slides/ru/nodejs-java/save-presentation/)
- [Конвертировать PPT в PNG с помощью JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если необходимо конвертировать тысячи презентаций PPT в формат PPTX, лучше всего делать это программно. С API Aspose.Slides это возможно выполнить всего несколькими строками кода. API обеспечивает полную совместимость при конвертации презентаций PPT в PPTX и позволяет:

- Конвертировать сложные структуры мастеров, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и изображения в стиле заливки автофигур.
- Конвертировать презентацию с заполнителями, текстовыми фреймами и текстовыми контейнерами.

{{% alert color="primary" %}} 

Посмотрите приложение [**Aspose.Slides PPT в PPTX Converter**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/), поэтому вы увидите живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее перетащить файл презентации в формате PPT и загрузить его в виде конвертированного файла PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Конвертация PPT в PPTX**
Aspose.Slides for Node.js via Java теперь позволяет разработчикам получать доступ к PPT через экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и преобразовывать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX.

Aspose.Slides for Node.js via Java предоставляет класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation), который представляет файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation при создании объекта. Ниже приведен пример, показывающий, как конвертировать презентацию PPT в презентацию PPTX.
```javascript
// Создать объект Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Сохранить презентацию PPTX в формате PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная PPT презентация**|

В результате выполнения приведенного кода будет получена следующая презентация PPTX после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок : Сгенерированная PPTX презентация после конвертации**|

## **Часто задаваемые вопросы**

**В чём разница между форматами PPT и PPTX?**

PPT — это старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — это более новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и упрощённое восстановление данных.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что подходит для сценариев пакетной обработки.

**Сохранится ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в множество форматов, включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — это автономный API, не требующий Microsoft PowerPoint или стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT в PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx), которое позволяет выполнять конвертацию прямо в браузере без написания кода.