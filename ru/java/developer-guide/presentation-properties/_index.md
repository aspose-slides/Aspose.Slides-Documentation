---
title: Управление свойствами презентации в Java
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/java/presentation-properties/
keywords:
- Свойства PowerPoint
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
description: "Освойте свойства презентаций в Aspose.Slides for Java и оптимизируйте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба типа свойств легко доступны и управляются с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/) . Экземпляр этого интерфейса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getDocumentProperties--) . Ниже показаны примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Примечание" %}}
Обратите внимание, что поля **Application** и **AppVersion** изменить нельзя. Aspose.Slides переписывает их при каждом сохранении, поэтому сохранённая презентация всегда указывает «Aspose.Slides for Java» и версию библиотеки, которой она была создана. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.
{{% /alert %}} 

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать, — нажать значок Office и затем выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта **Advanced Properties** откроется диалог, позволяющий управлять свойствами документа PowerPoint, как показано на рисунке ниже:

|**Диалог свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В этом **Диалоге свойств** вы увидите несколько вкладок: **Общие**, **Сводка**, **Статистика**, **Содержание** и **Пользовательские**. Все эти вкладки позволяют задавать разную информацию, связанную с файлами PowerPoint. Вкладка **Пользовательские** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Работа со свойствами документа с помощью Aspose.Slides for Java**

Как уже описывалось, Aspose.Slides for Java поддерживает два вида свойств документа: **Встроенные** и **Пользовательские**. Поэтому разработчики могут получать доступ к обоим типам свойств через API Aspose.Slides for Java. Aspose.Slides for Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation), чтобы получать доступ к свойствам документа презентаций, как описано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, доступные через объект [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Совместный документ?), **PresentationFormat**, **Subject** и **Title**.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего презентацию
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект IDocumentProperties, связанный с презентацией
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

Изменять встроенные свойства файлов презентаций так же просто, как их читать. Достаточно присвоить любой строковый значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект IDocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Установите встроенные свойства
    dp.setAuthor("Aspose.Slides for Java");
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

Этот пример изменяет встроенные свойства презентации, что выглядит следующим образом:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, который добавляет три пользовательских свойства, затем ищет имя, хранящееся под индексом 2, и удаляет это свойство, поэтому сохранённая презентация сохраняет только два из них. Пользовательские свойства индексируются в алфавитном порядке, а не в порядке их добавления.

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

|**Добавленные пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все эти пользовательские свойства для презентации.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создайте ссылку на объект DocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Получите доступ к пользовательским свойствам и измените их
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Отобразить имена и значения пользовательских свойств
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Изменить значения пользовательских свойств
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Сохраните презентацию в файл
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример изменяет пользовательские свойства [PPTX](https://docs.fileformat.com/presentation/pptx/) презентации. На рисунках показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="info" title="Примечание" %}}
Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) добавлены в [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo); логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) изменена.
{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки всей презентации.

Типичный сценарий: загрузить свойства, изменить значение и обновить документ можно реализовать следующим образом:

```java
import com.aspose.slides.*;

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
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

Новый шаблон можно создать с нуля, а затем использовать его для обновления нескольких презентаций:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство LanguageId (доступное через класс PortionFormat), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, для которого проверяются правописание и грамматика в PowerPoint.

Этот Java‑код показывает, как задать язык проверки орфографии для PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако их можно изменить или установить пустыми, если это допускает конкретное свойство.

**Что происходит, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Не требуется предварительно удалять или проверять свойство — Aspose.Slides автоматически обновит значение свойства.

**Можно ли получить доступ к свойствам презентации без полной её загрузки?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) и затем [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) для чтения метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). См. пример полного отчёта в статье [Build a Lightweight Presentation Inventory](/slides/ru/java/examine-presentation/).