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
- язык проверки правописания
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Освойте управление свойствами презентаций в Aspose.Slides для Android через Java и оптимизируйте поиск, брендинг и рабочие процессы в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба этих типа свойств легко доступны и управляются с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами документа презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/) . Экземпляр этого интерфейса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Примечание" %}}
Обратите внимание, что поля **Application** и **AppVersion** изменить нельзя. Aspose.Slides перезаписывает их при каждом сохранении, поэтому сохранённая презентация всегда указывает название продукта Aspose.Slides и версию библиотеки, которая её создала. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.
{{% /alert %}}

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать — нажать значок Office и дальше пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

|**Выбор пункта меню «Advanced Properties»**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| ** **|
После выбора пункта **Advanced Properties** появится диалог, позволяющий управлять свойствами документа PowerPoint, как показано на рисунке ниже:

|**Диалог свойств**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| ** **|
В приведённом выше **Диалог свойств** видно, что существует множество вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

### Работа с свойствами документа с помощью Aspose.Slides for Android via Java

Как мы уже упоминали, Aspose.Slides for Android via Java поддерживает два типа свойств документа: **Built-in** и **Custom**. Поэтому разработчики могут получать доступ к обоим типам свойств, используя API Aspose.Slides for Android via Java. Aspose.Slides for Android via Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties), который представляет свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, открытое объектом [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation), чтобы получить доступ к свойствам документа файлов презентаций, как описано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, доступные через объект [IDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties), включают: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** и **Title**.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего презентацию
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект IDocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Выведите встроенные свойства
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

Изменение встроенных свойств файлов презентаций так же просто, как и их чтение. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for Android via Java.

```java
import com.aspose.slides.*;

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
    
    // Сохраните вашу презентацию в файл
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример изменяет встроенные свойства презентации, которые можно увидеть ниже:

|**Встроенные свойства документа после изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| ** **|

## **Добавление пользовательских свойств документа**

Aspose.Slides for Android via Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. В примере ниже добавляются три пользовательских свойства, затем ищется имя, хранящееся под индексом 2, и это свойство удаляется, так что сохранённая презентация оставляет два из них. Пользовательские свойства индексируются в алфавитном порядке, а не в порядке их добавления.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Получение свойств документа
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Добавление пользовательских свойств
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Получение имени свойства по определенному индексу
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
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| ** **|

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Android via Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все эти пользовательские свойства для презентации.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект DocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Доступ и изменение пользовательских свойств
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Отображение имен и значений пользовательских свойств
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

|**Пользовательские свойства до изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| ** **|

|**Пользовательские свойства после изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| ** **|

## **Расширенные свойства документа**

{{% alert color="info" title="Примечание" %}}
Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) добавлены в [IPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentationInfo); логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) изменена.
{{% /alert %}}

В интерфейс [IPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentationInfo) добавлены два новых метода — [ReadDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки полной презентации.

Типичный сценарий: загрузить свойства, изменить какое‑то значение и обновить документ — можно реализовать следующим образом:

```java
import com.aspose.slides.*;

// чтение информации о презентации
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// получение текущих свойств
IDocumentProperties props = info.readDocumentProperties();

// установить новые значения полей Author и Title
props.setAuthor("New Author");
props.setTitle("New Title");

// обновить презентацию новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Существует другой способ использовать свойства конкретной презентации как шаблон для обновления свойств в других презентациях:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Новый шаблон можно создать с нуля, а затем использовать для обновления нескольких презентаций:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Установка языка проверки правописания**

Aspose.Slides предоставляет свойство LanguageId (открытое классом PortionFormat), позволяющее задать язык проверки правописания для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот Java‑код показывает, как задать язык проверки правописания для PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // установить идентификатор языка проверки правописания

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка языка по умолчанию**

Этот Java‑код показывает, как задать язык по умолчанию для всей презентации PowerPoint:

```java
import com.aspose.slides.*;

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

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако их можно изменить или, если позволяет конкретное свойство, установить пустое значение.

**Что произойдёт, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Не требуется предварительно удалять или проверять наличие свойства — Aspose.Slides автоматически обновит значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) и затем [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) для чтения метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/). См. пример «Build a Lightweight Presentation Inventory» (/slides/ru/androidjava/examine-presentation/) для полного отчёта и ограничений, специфичных для форматов.