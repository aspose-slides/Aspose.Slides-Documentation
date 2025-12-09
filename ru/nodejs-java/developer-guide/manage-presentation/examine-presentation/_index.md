---
title: Изучить презентацию
type: docs
weight: 30
url: /ru/nodejs-java/examine-presentation/
keywords:
- PowerPoint
- презентация
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- прочитать свойства
- изменить свойства
- модифицировать свойства
- PPTX
- PPT
- JavaScript
- Node
description: "Чтение и изменение свойств презентации PowerPoint в Node"
---

Aspose.Slides for Node.js via Java позволяет исследовать презентацию, чтобы узнать её свойства и понять её поведение.

{{% alert title="Info" color="info" %}} 
Классы [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) и [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/) содержат свойства и методы, используемые в операциях здесь.
{{% /alert %}} 

## **Проверка формата презентации**

Прежде чем работать с презентацией, возможно, вы захотите узнать, в каком формате (PPT, PPTX, ODP и других) она находится в данный момент.

Вы можете проверить формат презентации без её загрузки. Смотрите этот JavaScript‑код:
```javascript
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
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```


Возможно, вам понадобится посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), позволяющий вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint с документом свойств, показанным ниже.

![Исходные свойства документа презентации PowerPoint](input_properties.png)

Этот пример кода показывает, как изменить некоторые свойства презентации:
```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа презентации PowerPoint](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её атрибутах безопасности, могут быть полезны следующие ссылки:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только для чтения)](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, использованного для защиты презентации](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Как проверить, вложены ли шрифты и какие именно?**  
Ищите [информацию о вложенных шрифтах](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов в содержимом](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро определить, есть ли в файле скрытые слайды и их количество?**  
Пройдитесь по [коллекции слайдов](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) и проверьте у каждого слайда [флаг видимости](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/).

**Могу ли я определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**  
Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslidesize/) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**  
Да. Пройдите все [диаграммы](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) и обратите внимание, являются ли данные внутренними или ссылочными, включая любые битые ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**  
Для каждого слайда подсчитайте количество объектов и ищите большие изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный показатель сложности, чтобы отметить потенциальные узкие места производительности.