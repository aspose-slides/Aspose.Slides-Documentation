---
title: Свойства презентации
type: docs
weight: 70
url: /ru/nodejs-java/presentation-properties/
keywords:
- Свойства PowerPoint
- Свойства презентации
- Свойства документа
- Встроенные свойства
- Настраиваемые свойства
- Расширенные свойства
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Управляйте свойствами презентаций PowerPoint в JavaScript"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два вида свойств документа:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Настраиваемые** свойства — это пары **Имя/Значение**, определяемые пользователем. С помощью Aspose.Slides for Node.js via Java разработчики могут получать доступ и изменять значения как встроенных, так и пользовательских свойств.

{{% /alert %}} 

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документов файлов презентаций. Всё, что нужно сделать — нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что значения полей **Application** и **Producer** установить нельзя, так как в этих полях будут отображаться Aspose Ltd. и Aspose.Slides for Node.js via Java x.x.x.

{{% /alert %}} 

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта меню **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint, как показано на рисунке ниже:

|**Диалог Свойства**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В указанном **Диалоге Свойства** вы увидите несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления настраиваемыми свойствами файлов PowerPoint.

Работа со свойствами документа с использованием Aspose.Slides for Node.js via Java

Как уже было сказано, Aspose.Slides for Node.js via Java поддерживает два типа свойств документа: **Встроенные** и **Настраиваемые**. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java предоставляет класс [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **DocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation), чтобы получить доступ к свойствам документа файлов презентаций, как описано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Разделяется между разными производителями?), **PresentationFormat**, **Subject** и **Title**
```javascript
// Создать экземпляр класса Presentation, который представляет презентацию
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с презентацией
    var dp = pres.getDocumentProperties();
    // Отобразить встроенные свойства
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

Изменять встроенные свойства файлов презентаций так же просто, как их читать. Достаточно присвоить строковое значение нужному свойству, и его значение будет изменено. В примере ниже продемонстрировано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for Node.js via Java.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с презентацией
    var dp = pres.getDocumentProperties();
    // Установить встроенные свойства
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Сохранить презентацию в файл
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Этот пример изменяет встроенные свойства презентации, что видно на скриншоте ниже:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление настраиваемых свойств документа**

Aspose.Slides for Node.js via Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже представлен пример, показывающий, как задать настраиваемые свойства для презентации.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Получение свойств документа
    var dProps = pres.getDocumentProperties();
    // Добавление пользовательских свойств
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Получение имени свойства по индексу
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


|**Добавленные настраиваемые свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение настраиваемых свойств**

Aspose.Slides for Node.js via Java также позволяет разработчикам получать доступ к значениям настраиваемых свойств. Ниже приведён пример, демонстрирующий, как получить доступ и изменить все эти свойства для презентации.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект DocumentProperties, связанный с презентацией
    var dp = pres.getDocumentProperties();
    // Получить доступ к пользовательским свойствам и изменить их
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Вывести имена и значения пользовательских свойств
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Изменить значения пользовательских свойств
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Сохранить презентацию в файл
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Этот пример изменяет настраиваемые свойства [PPTX](https://docs.fileformat.com/presentation/pptx/) презентации. На рисунках показаны свойства презентации до и после изменения:

|**Настраиваемые свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Настраиваемые свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="primary" %}} 

Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo); логика сеттера свойства [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять их без загрузки всей презентации.

Типичный сценарий: загрузить свойства, изменить некоторое значение и обновить документ можно реализовать следующим образом:
```javascript
// прочитать информацию о презентации
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// получить текущие свойства
var props = info.readDocumentProperties();
// задать новые значения полей Author и Title
props.setAuthor("New Author");
props.setTitle("New Title");
// обновить презентацию новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Есть и другой способ использовать свойства конкретной презентации как шаблон для обновления свойств в других презентациях:
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


Новый шаблон можно создать с нуля, а затем использовать для обновления нескольких презентаций:
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство LanguageId (доступное через класс PortionFormat), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот JavaScript‑код показывает, как установить язык проверки орфографии для PowerPoint: xxx Почему свойство LanguageId отсутствует в JavaScript‑классе PortionFormat?
```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
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
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Добавляет новую прямоугольную фигуру с текстом
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


## **Онлайн‑пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить пустое значение, если это допускает конкретное свойство.

**Что произойдёт, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет overwritten новым. Не требуется предварительно удалять или проверять свойство — Aspose.Slides автоматически обновит его значение.

**Можно ли получить доступ к свойствам презентации без полной её загрузки?**

Да, можно получить доступ к свойствам презентации без полной её загрузки, используя метод `getPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/). Затем используйте метод `readDocumentProperties` класса [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/) для эффективного чтения свойств, экономя память и повышая производительность.