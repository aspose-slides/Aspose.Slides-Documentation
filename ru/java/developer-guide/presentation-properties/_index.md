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
- редактирование метаданных
- язык проверки правописания
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides для Java и оптимизируйте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба типа свойств можно легко получить и управлять ими с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами документа презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/) . Экземпляр этого интерфейса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getDocumentProperties--) . В следующих примерах показано, как читать, изменять и управлять этими свойствами.

{{% alert color="info" %}} 

Обратите внимание, что поля **Application** и **AppVersion** нельзя изменить. Aspose.Slides перезаписывает их при каждом сохранении, поэтому сохранённая презентация всегда отображает «Aspose.Slides for Java» и версию библиотеки, которая её создала. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.

{{% /alert %}} 

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать — щёлкнуть значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта **Advanced Properties** появляется диалог, позволяющий управлять свойствами документа файла PowerPoint, как показано на рисунке ниже:

|**Диалог свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В приведённом **Диалоге свойств** видно, что имеется несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать разные типы информации, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

Работа со свойствами документа с помощью Aspose.Slides for Java

Как мы уже описали, Aspose.Slides for Java поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Поэтому разработчики могут получать оба типа свойств с помощью API Aspose.Slides for Java. Aspose.Slides for Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation), чтобы получить доступ к свойствам документа файлов презентаций, как описано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, доступные через объект [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Разделяется между разными пользователями?), **PresentationFormat**, **Subject** и **Title**.

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

Изменить встроенные свойства файлов презентаций так же просто, как их получить. Достаточно присвоить строковое значение нужному свойству, и значение свойства будет изменено. В примере ниже продемонстрировано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for Java.

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
    
    // Сохраните вашу презентацию в файл
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример изменяет встроенные свойства презентации, которые можно увидеть ниже:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Пример ниже добавляет три пользовательских свойства, затем ищет имя, хранящееся в индексе 2, и удаляет это свойство, поэтому сохранённая презентация сохраняет только два из них. Пользовательские свойства упорядочиваются по алфавиту, а не в порядке добавления.

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
    
    // Получение имени свойства по конкретному индексу
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

Aspose.Slides for Java также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить и изменить все эти пользовательские свойства для презентации.

```java
import com.aspose.slides.*;

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

Этот пример изменяет пользовательские свойства [PPTX](https://docs.fileformat.com/presentation/pptx/) презентации. На рисунках ниже показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Продвинутые свойства документа**

{{% alert color="info" %}} 

Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) добавлены в [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo); логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo). Они предоставляют быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки всей презентации.

Типичный сценарий — загрузить свойства, изменить некоторое значение и обновить документ — можно реализовать следующим образом:

```java
import com.aspose.slides.*;

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

Есть другой способ использовать свойства конкретной презентации как шаблон для обновления свойств в других презентациях:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Установка языка проверки правописания**

Aspose.Slides предоставляет свойство LanguageId (из класса PortionFormat), позволяющее установить язык проверки правописания для документа PowerPoint. Язык проверки правописания — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот Java‑код показывает, как установить язык проверки правописания для PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // установить идентификатор языка проверки правописания

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка языка по умолчанию**

Этот Java‑код показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Добавляет новую форму прямоугольника с текстом
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Проверяет язык первой части
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Онлайн‑пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## ***FAQ**

### Как удалить встроенное свойство из презентации?

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить их пустыми, если это допускается конкретным свойством.

### Что происходит, если добавить пользовательское свойство, которое уже существует?

Если вы добавляете пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять наличие свойства не требуется — Aspose.Slides автоматически обновит значение свойства.

### Можно ли получить доступ к свойствам презентации без полной загрузки презентации?

Да, можно получить доступ к свойствам презентации без полной её загрузки, используя метод `getPresentationInfo` из класса [PresentationFactory](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/). Затем используйте метод `readDocumentProperties`, предоставляемый интерфейсом [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/), чтобы эффективно считывать свойства, экономя память и повышая производительность.