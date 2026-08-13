---
title: Пе​реобразовать PPT в PPTX на Android
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Быстро преобразуйте устаревшие презентации PPT в современный формат PPTX на Java с помощью Aspose.Slides для Android — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---
## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с помощью Java и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема.

- Конвертировать PPT в PPTX на Java

## **Конвертация PPT в PPTX на Android**

Для примера кода на Java, конвертирующего PPT в PPTX, см. раздел ниже — [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и др., как обсуждается в этих статьях.

- [Конвертация PPT в PDF на Android](/slides/ru/androidjava/convert-powerpoint-to-pdf/)
- [Конвертация PPT в XPS на Android](/slides/ru/androidjava/convert-powerpoint-to-xps/)
- [Конвертация PPT в HTML на Android](/slides/ru/androidjava/convert-powerpoint-to-html/)
- [Конвертация PPT в ODP на Android](/slides/ru/androidjava/save-presentation/)
- [Конвертация PPT в PNG на Android](/slides/ru/androidjava/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Конвертируйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшим решением будет выполнить это программно. С API Aspose.Slides это возможно сделать всего в несколько строк кода. API обеспечивает полную совместимость для конвертации презентаций PPT в PPTX и позволяет:

- Конвертировать сложные структуры шаблонов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с группировкой фигур, автоматическими фигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и стили заливки изображениями для автоматических фигур.
- Конвертировать презентацию с заполнителями, текстовыми рамками и текстовыми держателями.

{{% alert color="info" %}} 

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/ru/androidjava/), поэтому вы можете увидеть работающий пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет перетащить файл презентации в формате PPT и скачать его в формате PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ru/conversion/).

{{% /alert %}} 

## **Конвертация PPT в PPTX**
Aspose.Slides для Android через Java теперь позволяет разработчикам получать доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) и конвертировать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX.

Aspose.Slides для Android через Java предлагает класс [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation), представляющий файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation при создании объекта. Ниже приведён пример, показывающий, как конвертировать презентацию PPT в презентацию PPTX.

```java
import com.aspose.slides.*;

// Создать объект Presentation, представляющий файл PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// Сохранить презентацию PPT в формате PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная презентация PPT**|

Приведённый выше фрагмент кода генерирует следующую презентацию PPTX после конвертации:

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после конвертации**|

## **Часто задаваемые вопросы**

### В чём разница между форматами PPT и PPTX?

PPT — старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — новый основанный на XML формат, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

### Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что подходит для сценариев пакетной обработки.

### Сохранится ли содержимое и форматирование после конвертации?

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

### Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [множество форматов](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

### Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?

Да, Aspose.Slides — автономное API и не требует Microsoft PowerPoint или стороннего программного обеспечения для выполнения конвертации.

### Есть ли онлайн‑инструмент для конвертации PPT в PPTX?

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx) для выполнения конвертации прямо в браузере без написания кода.