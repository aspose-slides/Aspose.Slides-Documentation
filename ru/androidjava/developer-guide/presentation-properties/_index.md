---
title: Управление свойствами презентации на Android
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/androidjava/presentation-properties/
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
- редактирование метаданных
- язык проверки
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides for Android via Java и оптимизируйте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют сохранять полезную информацию вместе с документами (файлами презентаций). Существует два вида свойств документа:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Настраиваемые** свойства — это пары **Имя/Значение**, задаваемые пользователем. С помощью Aspose.Slides for Android via Java разработчики могут получать доступ и изменять как встроенные, так и пользовательские свойства.

{{% /alert %}} 

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документов презентаций. Всё, что нужно сделать, — нажать значок Office и далее выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что нельзя задавать значения полям **Application** и **Producer**, поскольку в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for Android via Java x.x.x.

{{% /alert %}} 

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта меню **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint, как показано на рисунке ниже:

|**Диалоговое окно свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В этом **Диалоговом окне свойств** вы увидите несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать различные типы информации, связанные с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.



Работа со свойствами документа с помощью Aspose.Slides for Android via Java

Как мы уже описали, Aspose.Slides for Android via Java поддерживает два типа свойств документа: **встроенные** и **настраиваемые**. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for Android via Java. Aspose.Slides for Android via Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, которое предоставляет объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), для доступа к свойствам документа презентаций, как описано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Общий документ?), **PresentationFormat**, **Subject** и **Title**.
```java
// Создайте экземпляр класса Presentation, представляющего презентацию
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект IDocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Отобразите встроенные свойства
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

Изменять встроенные свойства файлов презентаций так же просто, как получать к ним доступ. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for Android via Java.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект IDocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Установите встроенные свойства
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Сохраните презентацию в файл
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот пример изменяет встроенные свойства презентации, что можно увидеть на скриншоте ниже:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for Android via Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, показывающий, как задать пользовательские свойства для презентации.
```java
Presentation pres = new Presentation();
try {
    // Получение свойств документа
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Добавление пользовательских свойств
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Получение имени свойства по индексу
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Удаление выбранного свойства
    dProps.removeCustomProperty(getPropertyName);
    
    // Сохранение презентации
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|**Добавлены пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Android via Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все пользовательские свойства презентации.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект DocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Доступ и изменение пользовательских свойств
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Вывод имен и значений пользовательских свойств
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Изменение значений пользовательских свойств
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Сохраните вашу презентацию в файл
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот пример изменяет пользовательские свойства [PPTX ](https://docs.fileformat.com/presentation/pptx/)презентации. На рисунках показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="primary" %}} 

Добавлены новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo); логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo). Они предоставляют быстрый доступ к свойствам документа и позволяют изменять свойства без полной загрузки презентации.

Типичный сценарий: загрузить свойства, изменить значение и обновить документ — можно реализовать следующим образом:
```java
// чтение информации о презентации
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// получение текущих свойств
IDocumentProperties props = info.readDocumentProperties();

// установка новых значений полей Author и Title
props.setAuthor("New Author");
props.setTitle("New Title");

// обновление презентации новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Есть и другой способ использовать свойства конкретной презентации как шаблон для обновления свойств в других презентациях:
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


Новый шаблон можно создать с нуля, а затем использовать его для обновления нескольких презентаций:
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


## **Установка языка проверки правописания**

Aspose.Slides предоставляет свойство LanguageId (доступно через класс PortionFormat), позволяющее задать язык проверки правописания для документа PowerPoint. Язык проверки правописания — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот Java‑код показывает, как установить язык проверки правописания для PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?
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

    portionFormat.setLanguageId("zh-CN"); // установить Id языка проверки

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка языка по умолчанию**

Этот Java‑код показывает, как установить язык по умолчанию для всей презентации PowerPoint:
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


## **Онлайн‑пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако их можно изменить или задать пустое значение, если конкретное свойство допускает это.

**Что произойдёт, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Удалять или проверять наличие свойства предварительно не требуется, поскольку Aspose.Slides автоматически обновляет значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки её?**

Да, можно получать доступ к свойствам презентации без полной загрузки, используя метод `getPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/). Затем используйте метод `readDocumentProperties` интерфейса [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/) для эффективного чтения свойств, экономя память и повышая производительность.