---
title: Получение и обновление информации о презентации на JavaScript
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/nodejs-java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализ PPTX
- анализ PPT
- анализ ODP
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью JavaScript для более быстрого получения информации и более умных проверок содержимого."
---
## **Обзор**

Эта статья показывает, как просматривать информацию о презентации в Aspose.Slides. Она объясняет, как определить текущий формат презентации без загрузки полного файла, прочитать её свойства документа и при необходимости обновить эти свойства.

Примеры основаны на API [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/) и демонстрируют типовые операции работы с метаданными презентации.

## **Проверка формата презентации**

Перед работой с презентацией вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и других) она находится в данный момент.

Можно проверить формат презентации без её загрузки. См. следующий JavaScript‑код:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Получение свойств презентации**

Этот JavaScript‑код показывает, как получить свойства презентации (информацию о презентации):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Вы также можете просмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) , который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть PowerPoint‑презентация со свойствами документа, показанными ниже.

![Исходные свойства документа PowerPoint‑презентации](input_properties.png)

Этот пример кода демонстрирует, как изменить некоторые свойства презентации:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа PowerPoint‑презентации](output_properties.png)

## **Полезные ссылки**

Чтобы получить дополнительную информацию о презентации и её параметрах безопасности, могут быть полезны следующие ссылки:

- [Password-Protect Presentations](/slides/ru/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/nodejs-java/write-protected-presentation/)

## **Вопросы и ответы**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите информацию о [embedded-font](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро определить, есть ли скрытые слайды и сколько их?**

Пройдите по [коллекции слайдов](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidecollection/) и проверьте у каждого слайда [флаг видимости](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/gethidden/) .

**Можно ли обнаружить, использованы ли пользовательские размеры и ориентация слайдов, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslidesize/) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Обойдите все [диаграммы](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), и отметьте, является ли источник внутренним или ссылкой, включая любые сломанные ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите крупные изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный балл сложности, чтобы выделить потенциальные узкие места производительности.