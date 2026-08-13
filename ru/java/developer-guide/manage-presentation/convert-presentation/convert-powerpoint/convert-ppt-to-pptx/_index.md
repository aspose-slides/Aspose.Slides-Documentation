---
title: Преобразовать PPT в PPTX на Java
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Быстро преобразуйте устаревшие презентации PPT в современные PPTX на Java с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---
## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Java и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Преобразование PPT в PPTX на Java

## **Преобразование PPT в PPTX на Java**

Для примера кода на Java, преобразующего PPT в PPTX, см. раздел ниже — [Преобразовать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях.

- [Преобразовать PPT в PDF на Java](/slides/ru/java/convert-powerpoint-to-pdf/)
- [Преобразовать PPT в XPS на Java](/slides/ru/java/convert-powerpoint-to-xps/)
- [Преобразовать PPT в HTML на Java](/slides/ru/java/convert-powerpoint-to-html/)
- [Преобразовать PPT в ODP на Java](/slides/ru/java/save-presentation/)
- [Преобразовать PPT в PNG на Java](/slides/ru/java/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — делать это программно. С API Aspose.Slides это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость при конвертации презентации PPT в PPTX и позволяет:

- Преобразовывать сложные структуры шаблонов, макетов и слайдов.
- Преобразовывать презентацию с диаграммами.
- Преобразовывать презентацию с группированными фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовывать презентацию, имеющую текстуры и стили заполнения изображениями для автофигур.
- Преобразовывать презентацию с заполнителями, текстовыми фреймами и текстовыми контейнерами.

{{% alert color="info" %}} 

Посмотрите приложение — [**Преобразование PPT в PPTX с Aspose.Slides**](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx)

Это приложение построено на основе — [**API Aspose.Slides**](https://products.aspose.com/slides/ru/java/), поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет перетащить файл презентации в формате PPT и скачать его в преобразованном формате PPTX.

Найдите другие живые примеры — [**Конвертация Aspose.Slides**](https://products.aspose.app/slides/ru/conversion/).
{{% /alert %}} 

## **Преобразование PPT в PPTX**
Aspose.Slides for Java теперь позволяет разработчикам получать доступ к PPT через экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation) и преобразовывать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях в конвертации PPT в PPTX перейдите по этой документации — [ссылка](/slides/ru/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java предоставляет класс [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation), который представляет файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через объект Presentation при его создании. Следующий пример показывает, как преобразовать презентацию PPT в презентацию PPTX.

```java
import com.aspose.slides.*;

// Создать объект Presentation, представляющий файл PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// Сохранение PPT презентации в формате PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная PPT‑презентация**|

В приведённом выше фрагменте кода после конвертации получается следующая PPTX‑презентация

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок : Сгенерированная PPTX‑презентация после конвертации**|

## **Вопросы и ответы**

### В чём разница между форматами PPT и PPTX?

PPT — это старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — это новый основанный на XML формат, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают более высокую производительность, меньший размер и улучшенное восстановление данных.

### Поддерживает ли Aspose.Slides массовую конвертацию нескольких файлов PPT в PPTX?

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что удобно для сценариев пакетной обработки.

### Сохраняются ли содержимое и форматирование после конвертации?

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

### Можно ли конвертировать другие форматы, например PDF или HTML, из файлов PPT?

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [множество форматов](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и графические форматы такие как PNG и JPEG.

### Возможно ли преобразовать PPT в PPTX без установленного Microsoft PowerPoint?

Да, Aspose.Slides — это автономный API и не требует установки Microsoft PowerPoint или любого стороннего программного обеспечения для выполнения конвертации.

### Есть ли онлайн‑инструмент для конвертации PPT в PPTX?

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT в PPTX Converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.