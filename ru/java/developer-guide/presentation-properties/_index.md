---
title: Управление свойствами презентации в Java
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/java/presentation-properties/
keywords:
- свойства PowerPoint
- свойства презентации
- свойства документа
- встроенные свойства
- пользовательские свойства
- расширенные свойства
- управление свойствами
- изменение свойств
- метаданные документа
- редактировать метаданные
- язык проверки орфографии
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides for Java и упростите поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документов позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документов:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок документа, имя автора, статистика документа и т.д. **Настраиваемые** свойства — это свойства, определяемые пользователями как пары **Имя/Значение**, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for Java разработчики могут получать доступ и изменять значения как встроенных, так и настраиваемых свойств.

{{% /alert %}} 

## **Свойства документов в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документов файлов презентаций. Всё, что нужно сделать — нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** программы Microsoft PowerPoint 2007, как показано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что вы не можете задать значения для полей **Application** и **Producer**, поскольку в этих полях будут отображаться Aspose Ltd. и Aspose.Slides for Java x.x.x.

{{% /alert %}} 

|**Выбор пункта меню Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта меню **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint, как показано ниже на рисунке:

|**Диалог свойств**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В приведённом выше **Properties Dialog** вы можете увидеть множество вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать различные типы информации, относящейся к файлам PowerPoint. Вкладка **Custom** используется для управления настраиваемыми свойствами файлов PowerPoint.

## **Работа со свойствами документов с использованием Aspose.Slides for Java**

Как мы уже описали, Aspose.Slides for Java поддерживает два типа свойств документов: **Built-in** и **Custom**. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for Java. Aspose.Slides for Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties), который представляет свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), чтобы получить доступ к свойствам документов файлов презентаций, как описано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **Keywords**, **SharedDoc** (Общий документ между различными производителями?), **PresentationFormat**, **Subject** и **Title**.
```java
// Экземпляр класса Presentation, представляющего презентацию
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Отобразить встроенные свойства
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменение встроенных свойств**

Изменение встроенных свойств файлов презентаций так же просто, как и их получение. Достаточно присвоить строковое значение нужному свойству, и значение свойства будет изменено. В примере ниже мы продемонстрировали, как можно изменить встроенные свойства документа презентации с помощью Aspose.Slides for Java.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Установить встроенные свойства
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Сохранить презентацию в файл
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот пример изменяет встроенные свойства презентации, которые можно увидеть ниже:
|**Встроенные свойства документа после изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление настраиваемых свойств документа**

Aspose.Slides for Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, показывающий, как установить пользовательские свойства для презентации.
```java
Presentation pres = new Presentation();
try {
    // Получение свойств документа
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Добавление пользовательских свойств
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Получение имени свойства по заданному индексу
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Удаление выбранного свойства
    dProps.removeCustomProperty(getPropertyName);
    
    // Сохранение презентации
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|**Добавленные пользовательские свойства документа**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как можно получать доступ и изменять все эти пользовательские свойства для презентации.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект DocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Доступ и изменение пользовательских свойств
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Отобразить имена и значения пользовательских свойств
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Изменить значения пользовательских свойств
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Сохранить презентацию в файл
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот пример изменяет пользовательские свойства [PPTX ](https://docs.fileformat.com/presentation/pptx/)презентации. Ниже показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="primary" %}} 

Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) были добавлены в [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo), логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) была изменена.

{{% /alert %}} 

Эти два новых метода ... были добавлены в интерфейс [IPresentationInfo]. Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки всей презентации.

Типичный сценарий загрузки свойств, изменения некоторых значений и обновления документа можно реализовать следующим образом:
```java
// прочитать информацию о презентации
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// получить текущие свойства
IDocumentProperties props = info.readDocumentProperties();

// установить новые значения полей Author и Title
props.setAuthor("New Author");
props.setTitle("New Title");

// обновить презентацию новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Есть другой способ использовать свойства конкретной презентации в качестве шаблона для обновления свойств в других презентациях:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


Новый шаблон можно создать с нуля, а затем использовать для обновления нескольких презентаций:
```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство LanguageId (доступное через класс PortionFormat), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот код на Java показывает, как установить язык проверки орфографии для PowerPoint: xxx Почему свойство LanguageId отсутствует в классе Java PortionFormat?
```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // установить идентификатор языка проверки

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка языка по умолчанию**

Этот код на Java показывает, как установить язык по умолчанию для всей презентации PowerPoint:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Добавляет новую прямоугольную форму с текстом
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Проверяет язык первой части
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Живой пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документов через API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и не могут быть полностью удалены. Однако вы можете изменить их значения или установить их пустыми, если это допускается конкретным свойством.

**Что происходит, если я добавляю пользовательское свойство, которое уже существует?**

Если вы добавляете пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Вам не требуется удалять или проверять свойство заранее, так как Aspose.Slides автоматически обновляет значение свойства.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да, вы можете получить доступ к свойствам презентации без полной её загрузки, используя метод `getPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/). Затем используйте метод `readDocumentProperties`, предоставляемый интерфейсом [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/), чтобы эффективно считывать свойства, экономя память и повышая производительность.