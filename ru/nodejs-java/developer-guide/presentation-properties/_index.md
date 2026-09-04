---
title: Управление свойствами презентации в JavaScript
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
- Расширенные свойства
- Управление свойствами
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- Язык проверки правописания
- Язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Владеете свойствами презентации в Aspose.Slides for Node.js via Java и оптимизируйте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба этих типа свойств можно легко получить и управлять ими с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами документа презентации через класс [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/) . Экземпляр этого класса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Ниже приведены примеры того, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Обратите внимание, что поля **Application** и **AppVersion** нельзя изменять. Aspose.Slides переписывает их при каждом сохранении, поэтому сохранённая презентация всегда сообщает "Aspose.Slides for Node.js via Java" и версию библиотеки, которая её создала. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять некоторые свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- Системно определённые (Built-in) свойства
- Пользовательские (Custom) свойства

**Built-in** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Custom** свойства — это свойства, определённые пользователями как пары **Name/Value**, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for Node.js via Java разработчики могут получать и изменять как встроенные, так и пользовательские свойства.

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать, — нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

После выбора пункта меню **Advanced Properties** появляется диалог, позволяющий управлять свойствами документа PowerPoint, как показано на рисунке ниже:

|**Диалог свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В этом **Диалог свойств** вы можете увидеть множество вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют задавать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

Работа со свойствами документа с помощью Aspose.Slides for Node.js via Java

Как мы уже описали, Aspose.Slides for Node.js via Java поддерживает два типа свойств документа: **Built-in** и **Custom**. Поэтому разработчики могут получать оба типа свойств с помощью API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java предоставляет класс [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **DocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation), чтобы получить доступ к свойствам документа файлов презентаций, как описано ниже:

## **Чтение публичных свойств из зашифрованной презентации**

Пароль открытия обычно защищает как содержание презентации, так и свойства документа. Когда презентация зашифрована с помощью передачи `false` в [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), её свойства документа остаются публичными. Затем приложение может передать `true` в [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) и прочитать публичные метаданные без указания пароля открытия.

Опция загрузки только свойств документа контролирует, что Aspose.Slides загружает; она ничего не расшифровывает. Если свойства включены в шифрование, их загрузка без пароля завершится ошибкой. Если презентация не зашифрована, опция игнорируется и загружается полная презентация.

Следующий пример проверяет режим загрузки через [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded), а затем читает встроенные свойства через [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

В этом режиме содержимое слайдов не загружается. Слайды, мастеры, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения всегда должны проверять [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) перед выполнением операции, требующей полной модели объектов презентации.

{{% alert color="warning" title="Warning" %}}
Публичные метаданные могут раскрыть имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Делайте их публичными только когда системы индексирования, классификации, поиска или управления документами имеют специфическое требование доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная в режиме только свойств документа, предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из этого объекта только с метаданными, потому что публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому обновление требует правильного пароля открытия и полной загрузки.

Следующий пример открывает презентацию с помощью [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setPassword), обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) для проверки сохранения шифрования и заново открывает публичные метаданные без пароля, чтобы проверить новые значения:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Если приложению не разрешено расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как доступные только для чтения.

## **Доступ к встроенным (Built-in) свойствам**

Эти свойства, предоставляемые объектом [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **Keywords**, **SharedDoc** (Поделена между разными создателями?), **PresentationFormat**, **Subject** и **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать экземпляр класса Presentation, представляющего презентацию
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

Изменение встроенных свойств файлов презентации так же просто, как их получение. Вы можете просто присвоить строковое значение любому нужному свойству, и значение свойства будет изменено. В примере ниже мы продемонстрировали, как можно изменить встроенные свойства документа презентации с помощью Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Этот пример изменяет встроенные свойства презентации, что можно увидеть ниже:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for Node.js via Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже показан пример, который демонстрирует, как установить пользовательские свойства для презентации.

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

|**Добавленные пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Node.js via Java также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как можно получить и изменить все эти пользовательские свойства для презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект DocumentProperties, связанный с презентацией
    var dp = pres.getDocumentProperties();
    // Доступ и изменение пользовательских свойств
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Показать имена и значения пользовательских свойств
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

Этот пример изменяет пользовательские свойства [PPTX ](https://docs.fileformat.com/presentation/pptx/)презентации. На рисунках ниже показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="info" title="Note" %}}
Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) были добавлены в [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo); логика сеттера свойства [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) была изменена.
{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) были добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PresentationInfo). Они предоставляют быстрый доступ к свойствам документа и позволяют изменять их без полной загрузки презентации.

Типичный сценарий: загрузить свойства, изменить некоторые значения и обновить документ можно реализовать следующим образом:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// прочитать информацию о презентации
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// получить текущие свойства
var props = info.readDocumentProperties();
// установить новые значения полей Author и Title
props.setAuthor("New Author");
props.setTitle("New Title");
// обновить презентацию новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Существует другой способ использовать свойства конкретной презентации в качестве шаблона для обновления свойств в других презентациях:

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

Новый шаблон можно создать с нуля, а затем использовать для обновления нескольких презентаций:

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

## **Установка языка проверки правописания**

Aspose.Slides предоставляет свойство LanguageId (доступное через класс PortionFormat), позволяющее установить язык проверки правописания для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот JavaScript‑код показывает, как установить язык проверки правописания для PowerPoint: xxx Почему свойство LanguageId отсутствует в классе JavaScript PortionFormat?

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
    portionFormat.setLanguageId("zh-CN");// установить идентификатор языка проверки правописания
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Установка языка по умолчанию**

Этот JavaScript‑код показывает, как установить язык по умолчанию для всей презентации PowerPoint:

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
    // Проверяет язык первой порции
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

## **FAQ**

**Как можно удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или установить их пустыми, если конкретное свойство позволяет это.

**Что происходит, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущие значения будут перезаписаны новыми. Не требуется предварительно удалять или проверять свойство — Aspose.Slides автоматически обновит значение свойства.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) и затем [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) для чтения сохранённой метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). См. [Build a Lightweight Presentation Inventory](/slides/ru/nodejs-java/examine-presentation/) для полного примера отчёта и ограничений, специфичных для форматов.

**Можно ли прочитать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Шифрование свойств документа должно было быть отключено до шифрования презентации, и презентация должна быть загружена в режиме только свойств документа.

**Можно ли обновить зашифрованный файл PPTX в режиме только свойств документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.