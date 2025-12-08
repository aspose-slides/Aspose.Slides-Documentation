---
title: Преобразовать PPT в PPTX в JavaScript
linktitle: Преобразовать PPT в PPTX
type: docs
weight: 20
url: /ru/nodejs-java/convert-ppt-to-pptx/
keywords: "Java преобразование PPT в PPTX, PowerPoint PPT в PPTX на JavaScript"
description: "Конвертировать PowerPoint PPT в PPTX с помощью JavaScript."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с использованием JavaScript и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Convert PPT to PPTX in JavaScript

## **Java Convert PPT to PPTX**

Для примера кода JavaScript, преобразующего PPT в PPTX, смотрите раздел ниже, а именно [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT в многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Java Convert PPT to PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java Convert PPT to XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java Convert PPT to HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java Convert PPT to ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java Convert PPT to Image](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **About PPT to PPTX Conversion**
Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам необходимо конвертировать тысячи презентаций PPT в формат PPTX, лучшим решением будет программный подход. С Aspose.Slides API это можно сделать всего в несколько строк кода. API поддерживает полную совместимость при конвертации презентаций PPT в PPTX и позволяет:

- Преобразовывать сложные структуры шаблонов, макетов и слайдов.
- Преобразовывать презентацию с диаграммами.
- Преобразовывать презентацию с групповыми фигурами, автофигурой (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовывать презентацию с текстурами и изображениями, используемыми для заливки автофигур.
- Преобразовывать презентацию с заполнителями, текстовыми кадрами и текстовыми объектами.

{{% alert color="primary" %}} 

Посмотрите приложение **Aspose.Slides PPT to PPTX Conversion**:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть работающий пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее перетащить файл презентации в формате PPT и загрузить его после конвертации в PPTX.

Найдите другие живые **Aspose.Slides Conversion** примеры.
{{% /alert %}} 

## **Convert PPT to PPTX**
Aspose.Slides for Node.js via Java теперь позволяет разработчикам получать доступ к PPT с помощью [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) класса и преобразовывать его в соответствующий [PPTX](https://docs.fileformat.com/presentation/pptx/) формат. В настоящее время поддерживается частичная конвертация [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях конвертации PPT в PPTX перейдите к этой документации [link](/slides/ru/nodejs-java/ppt-to-pptx-conversion/).

Aspose.Slides for Node.js via Java предлагает класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation), который представляет файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation при создании объекта. В следующем примере показано, как преобразовать презентацию PPT в PPTX Presentation.
```javascript
// Создать объект Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Сохранение презентации PPTX в формате PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок: Исходная презентация PPT**|

The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после конвертации**|

## **FAQ**

**What is the difference between PPT and PPTX formats?**  
**В чем разница между форматами PPT и PPTX?**  
PPT — это старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более современный XML‑основанный формат, появившийся в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и более эффективное восстановление данных.

**Does Aspose.Slides support batch conversion of multiple PPT files to PPTX?**  
**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**  
Да, вы можете использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что делает его подходящим для пакетных сценариев.

**Will the content and formatting be preserved after conversion?**  
**Сохранится ли содержимое и форматирование после конвертации?**  
Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимация, фигуры, диаграммы и другие элементы дизайна остаются неизменными при преобразовании PPT в PPTX.

**Can I convert other formats like PDF or HTML from PPT files?**  
**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**  
Да, Aspose.Slides поддерживает конвертацию файлов PPT в различные форматы, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Is it possible to convert PPT to PPTX without Microsoft PowerPoint installed?**  
**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**  
Да, Aspose.Slides — это автономный API, который не требует установки Microsoft PowerPoint или стороннего программного обеспечения для выполнения конвертации.

**Is there an online tool available for PPT to PPTX conversion?**  
**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**  
Да, вы можете использовать бесплатное веб‑приложение [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации прямо в браузере без написания кода.