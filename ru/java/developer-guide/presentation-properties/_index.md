---
title: Свойства презентации
type: docs
weight: 70
url: /java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет возможность добавления некоторых свойств к файлам презентаций. Эти документные свойства позволяют сохранять полезную информацию вместе с документами (файлами презентаций). Существует два типа документных свойств, а именно:

- Определенные системой (встроенные) свойства
- Определенные пользователем (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистику документа и так далее. **Настраиваемые** свойства — это те, которые определяются пользователями в виде пар **Имя/Значение**, где как имя, так и значение задаются пользователем. Используя Aspose.Slides для Java, разработчики могут получать доступ к значениям встроенных свойств, а также настраиваемых свойств и изменять их.

{{% /alert %}} 

## **Свойства документа в PowerPoint**
Microsoft PowerPoint 2007 позволяет управлять документными свойствами файлов презентаций. Все, что вам нужно сделать, это щелкнуть значок Office и выбрать пункт меню **Подготовить | Свойства | Дополнительные свойства** в Microsoft PowerPoint 2007, как показано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что вы не можете устанавливать значения для полей **Приложение** и **Производитель**, так как Aspose Ltd. и Aspose.Slides для Java x.x.x будут отображаться в этих полях.

{{% /alert %}} 

|**Выбор пункта меню Дополнительные свойства**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После того как вы выбрали пункт меню **Дополнительные свойства**, появится диалог, позволяющий вам управлять документными свойствами файла PowerPoint, как показано ниже на рисунке:

|**Диалог свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В вышеуказанном **Диалоге свойств** вы можете увидеть, что есть много вкладок, таких как **Общие**, **Сводка**, **Статистика**, **Содержимое** и **Пользовательские**. Все эти вкладки позволяют настраивать различные виды информации, относящиеся к файлам PowerPoint. Вкладка **Пользовательские** используется для управления пользовательскими свойствами файлов PowerPoint.



Работа с документными свойствами с использованием Aspose.Slides для Java

Как мы уже упоминали ранее, Aspose.Slides для Java поддерживает два типа документных свойств, которые являются **Встроенными** и **Настраиваемыми** свойствами. Таким образом, разработчики могут получить доступ к обоим типам свойств, используя API Aspose.Slides для Java. Aspose.Slides для Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties), который представляет собой документные свойства, связанные с файлом презентации через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), чтобы получить доступ к документным свойствам файлов презентации, как показано ниже:

## **Доступ к встроенным свойствам**
Эти свойства, предоставленные объектом [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties), включают: **Создатель** (Автор), **Описание**, **Ключевые слова**, **Создан** (Дата создания), **Изменено** (Дата изменения), **Напечатано** (Дата последнего принта), **Последний изменивший**, **Ключевые слова**, **Общий документ** (Поделён ли между разными производителями?), **Формат презентации**, **Тема** и **Название**.

```java
// Создать экземпляр класса Presentation, представляющего презентацию
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Отобразить встроенные свойства
    System.out.println("Категория : " + dp.getCategory());
    System.out.println("Текущий статус : " + dp.getContentStatus());
    System.out.println("Дата создания : " + dp.getCreatedTime());
    System.out.println("Автор : " + dp.getAuthor());
    System.out.println("Описание : " + dp.getComments());
    System.out.println("Ключевые слова : " + dp.getKeywords());
    System.out.println("Последний изменивший : " + dp.getLastSavedBy());
    System.out.println("Руководитель : " + dp.getManager());
    System.out.println("Дата изменения : " + dp.getLastSavedTime());
    System.out.println("Формат презентации : " + dp.getPresentationFormat());
    System.out.println("Дата последнего принта : " + dp.getLastPrinted());
    System.out.println("Общий документ : " + dp.getSharedDoc());
    System.out.println("Тема : " + dp.getSubject());
    System.out.println("Название : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение встроенных свойств**
Изменение встроенных свойств файлов презентаций так же просто, как и доступ к ним. Вы можете просто присвоить строковое значение любому желаемому свойству, и значение свойства будет изменено. В приведенном ниже примере мы продемонстрировали, как можно изменить встроенные документные свойства файла презентации с помощью Aspose.Slides для Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Установить встроенные свойства
    dp.setAuthor("Aspose.Slides для Java");
    dp.setTitle("Изменение свойств презентации");
    dp.setSubject("Тема Aspose");
    dp.setComments("Описание Aspose");
    dp.setManager("Менеджер Aspose");
    
    // Сохранить вашу презентацию в файл
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример изменяет встроенные свойства презентации, которые можно увидеть, как показано ниже:

|**Встроенные документные свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**
Aspose.Slides для Java также позволяет разработчикам добавлять значения пользовательских свойств для документных свойств презентации. Приведен пример ниже, который показывает, как установить пользовательские свойства для презентации.

```java
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

|**Добавленные пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**
Aspose.Slides для Java также позволяет разработчикам получать доступ к значениями пользовательских свойств. Приведен пример ниже, который показывает, как получить доступ и изменить все эти пользовательские свойства для презентации.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект DocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Доступ и изменение пользовательских свойств
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Отображение имен и значений пользовательских свойств
        System.out.println("Имя пользовательского свойства : " + dp.getCustomPropertyName(i));
        System.out.println("Значение пользовательского свойства : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Изменение значений пользовательских свойств
        dp.set_Item(dp.getCustomPropertyName(i), "Новое значение " + (i + 1));
    }
    
    // Сохранить вашу презентацию в файл
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример изменяет пользовательские свойства презентации [PPTX](https://docs.fileformat.com/presentation/pptx/). Следующие фигуры показывают пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**
{{% alert color="primary" %}} 

Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) и [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) были добавлены к интерфейсу [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo), логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) была изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) были добавлены к интерфейсу [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo). Они обеспечивают быстрый доступ к документным свойствам и позволяют изменять и обновлять свойства без загрузки всей презентации.

Типичный сценарий загружает свойства, изменяет некоторое значение и обновляет документ можно реализовать следующим образом:

```java
// прочитать информацию о презентации
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// получить текущие свойства
IDocumentProperties props = info.readDocumentProperties();

// установить новые значения полей Автора и Названия
props.setAuthor("Новый Автор");
props.setTitle("Новое Название");

// обновить презентацию с новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Существует и другой способ использовать свойства определенной презентации в качестве шаблона для обновления свойств в других презентациях:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Автор Шаблона");
template.setTitle("Название Шаблона");
template.setCategory("Категория Шаблона");
template.setKeywords("Ключевое слово1, Ключевое слово2, Ключевое слово3");
template.setCompany("Наша Компания");
template.setComments("Создано из шаблона");
template.setContentType("Содержимое Шаблона");
template.setSubject("Тема Шаблона");

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

Новый шаблон может быть создан с нуля и затем использован для обновления нескольких презентаций:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Автор Шаблона");
template.setTitle("Название Шаблона");
template.setCategory("Категория Шаблона");
template.setKeywords("Ключевое слово1, Ключевое слово2, Ключевое слово3");
template.setCompany("Наша Компания");
template.setComments("Создано из шаблона");
template.setContentType("Содержимое Шаблона");
template.setSubject("Тема Шаблона");

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

## **Проверка, изменена ли или создана презентация**
Aspose.Slides для Java предоставляет возможность проверить, была ли презентация изменена или создана. Приведен пример ниже, который показывает, как проверить, была ли презентация создана или изменена.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Имя приложения: " + app);
System.out.println("Версия приложения: " + ver);
```

## **Установка языка проверки**

Aspose.Slides предоставляет свойство LanguageId (предоставленное классом PortionFormat), чтобы позволить вам установить язык проверки для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот код на Java показывает, как установить язык проверки для PowerPoint: xxx Почему LanguageId отсутствует в классе Java PortionFormat?

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

Этот код на Java показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Добавляет новую форму прямоугольника с текстом
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Новый текст");

    // Проверяет язык первой порции
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```