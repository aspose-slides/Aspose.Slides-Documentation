---
title: У管理 свойства презентации в JavaScript
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/nodejs-java/presentation-properties/
keywords:
- Свойства PowerPoint
- Свойства презентации
- Свойства документа
- Встроенные свойства
- Пользовательские свойства
- Продвинутые свойства
- Управление свойствами
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- Язык проверки правописания
- Язык по умолчанию
- PowerPoint
- OpenDocument
- Презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides для Node.js via Java и упростите поиск, брендинг и рабочие процессы в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба типа свойств легко доступны и управляются с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами документа презентации через класс [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/). Экземпляр этого класса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Note" %}}
Обратите внимание, что поля **Application** и **AppVersion** изменить нельзя. Aspose.Slides перезаписывает их при каждой записи, поэтому сохранённая презентация всегда сообщает «Aspose.Slides for Node.js via Java» и версию библиотеки, которая её создала. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два вида свойств документа:

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Custom** свойства — это пары **Name/Value**, определяемые пользователем. С помощью Aspose.Slides for Node.js via Java разработчики могут получать и изменять как встроенные, так и пользовательские свойства.

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Для этого нужно нажать кнопку Office и выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта **Advanced Properties** откроется диалог, позволяющий управлять свойствами документа PowerPoint, как показано на рисунке:

|**Диалог Свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В вышеприведённом **Диалогe Свойств** видны вкладки **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют задавать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

### Работа со свойствами документа с помощью Aspose.Slides for Node.js via Java

Как описано выше, Aspose.Slides for Node.js via Java поддерживает два типа свойств документа: **Built-in** и **Custom**. Поэтому разработчики могут получать оба типа свойств, используя API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java предоставляет класс [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **DocumentProperties**, доступное через объект [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation), чтобы получить свойства документа файлов презентаций, как описано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, доступные через объект [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Разделяется между разными производителями?), **PresentationFormat**, **Subject** и **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создайте экземпляр класса Presentation, представляющего презентацию
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект IDocumentProperties, связанный с Presentation
    var dp = pres.getDocumentProperties();
    // Отобразите встроенные свойства
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Изменение встроенных свойств**

Изменять встроенные свойства файлов презентаций так же просто, как их читать. Достаточно присвоить строковое значение нужному свойству, и его значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект IDocumentProperties, связанный с Presentation
    var dp = pres.getDocumentProperties();
    // Установите встроенные свойства
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Сохраните вашу презентацию в файл
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Этот пример изменяет встроенные свойства презентации, результаты отображаются ниже:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for Node.js via Java также позволяет разработчикам добавлять пользовательские значения к свойствам документа презентации. Ниже приведён пример, показывающий, как задать пользовательские свойства для презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Получение свойств документа
    var dProps = pres.getDocumentProperties();
    // Добавление пользовательских свойств
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Получение имени свойства по определенному индексу
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Удаление выбранного свойства
    dProps.removeCustomProperty(getPropertyName);
    // Сохранение презентации
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Добавлены пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Node.js via Java также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить и изменить все эти пользовательские свойства для презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект DocumentProperties, связанный с Presentation
    var dp = pres.getDocumentProperties();
    // Доступ и изменение пользовательских свойств
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Отобразите имена и значения пользовательских свойств
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Измените значения пользовательских свойств
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Сохраните вашу презентацию в файл
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

В этом примере изменяются пользовательские свойства [PPTX ](https://docs.fileformat.com/presentation/pptx/)презентации. Ниже показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Продвинутые свойства документа**

{{% alert color="info" title="Note" %}}
Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo); логика сеттера свойства [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) изменена.
{{% /alert %}} 

В класс [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo) добавлены два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки полной презентации.

Типичный сценарий: загрузить свойства, изменить некоторое значение и обновить документ можно реализовать следующим образом:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// читаем информацию о презентации
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// получаем текущие свойства
var props = info.readDocumentProperties();
// задаём новые значения полей Author и Title
props.setAuthor("New Author");
props.setTitle("New Title");
// обновляем презентацию новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Существует другой способ использовать свойства конкретной презентации как шаблон для обновления свойств в других презентациях:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Новый шаблон можно создать с нуля и затем использовать для обновления нескольких презентаций:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство LanguageId (открытое классом PortionFormat) для задания языка проверки орфографии в документе PowerPoint. Язык проверки орфографии — это язык, для которого проверяется правописание и грамматика в PowerPoint.

Этот JavaScript‑код показывает, как установить язык проверки орфографии для PowerPoint: xxx Почему свойство LanguageId отсутствует в JavaScript‑классе PortionFormat?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// установить идентификатор языка проверки орфографии
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Установка языка по умолчанию**

Этот JavaScript‑код показывает, как задать язык по умолчанию для всей презентации PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Добавляет новую прямоугольную форму с текстом
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Проверяет язык первой части
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Рабочий пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить пустое значение, если конкретное свойство это позволяет.

**Что происходит, если я добавлю пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять свойство не требуется — Aspose.Slides автоматически обновит значение свойства.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) и затем [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). См. [Build a Lightweight Presentation Inventory](/slides/ru/nodejs-java/examine-presentation/) для полного примера отчёта и ограничений, специфичных для форматов.