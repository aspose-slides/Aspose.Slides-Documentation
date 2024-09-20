---
title: Свойства презентации
type: docs
weight: 70
url: /androidjava/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существуют два вида свойств документа:

- Определенные системой (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистику документа и так далее. **Настраиваемые** свойства — это свойства, которые определяются пользователями в виде пар **Имя/Значение**, где имя и значение определяются пользователем. С помощью Aspose.Slides для Android через Java разработчики могут получать доступ и изменять значения встроенных свойств, а также пользовательских свойств.

{{% /alert %}} 

## **Свойства документа в PowerPoint**
Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Все, что вам нужно сделать, это нажать на значок Office и выбрать в меню **Подготовка | Свойства | Дополнительные свойства** элемент меню Microsoft PowerPoint 2007, как показано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что вы не можете устанавливать значения для полей **Application** и **Producer**, так как Aspose Ltd. и Aspose.Slides для Android через Java x.x.x будут отображаться в этих полях.

{{% /alert %}} 

|**Выбор элемента меню Дополнительные свойства**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора элемента меню **Дополнительные свойства** появится диалоговое окно, позволяющее управлять свойствами документа файла PowerPoint, как показано ниже на рисунке:

|**Диалог свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В приведенном выше **Диалоге свойств** видно, что есть много вкладок, таких как **Общие**, **Сводка**, **Статистика**, **Содержимое** и **Пользовательские**. Все эти вкладки позволяют настраивать различные виды информации, относящиеся к файлам PowerPoint. Вкладка **Пользовательские** используется для управления пользовательскими свойствами файлов PowerPoint.



Работа с свойствами документа с использованием Aspose.Slides для Android через Java

Как было описано ранее, Aspose.Slides для Android через Java поддерживает два вида свойств документа: **Встроенные** и **Настраиваемые** свойства. Таким образом, разработчики могут получать доступ к обоим видам свойств с помощью API Aspose.Slides для Android через Java. Aspose.Slides для Android через Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties), который представляет свойства документа, ассоциированные с файлом презентации через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, предоставленное объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), для доступа к свойствам документа файлов презентаций, как описано ниже:

## **Доступ к встроенным свойствам**
Эти свойства, предоставленные объектом [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties), включают: **Создатель** (Автор), **Описание**, **Ключевые слова**, **Создано** (Дата создания), **Изменено** (Дата модификации), **Напечатано** (Дата последней печати), **Последний изменивший**, **Ключевые слова**, **Общий документ** (Совместно используется между различными производителями?), **Формат презентации**, **Тема** и **Название**.

```java
// Создание экземпляра класса Presentation, который представляет презентацию
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создание ссылки на объект IDocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Отображение встроенных свойств
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
    System.out.println("Дата последней печати : " + dp.getLastPrinted());
    System.out.println("Совместно используется между производителями : " + dp.getSharedDoc());
    System.out.println("Тема : " + dp.getSubject());
    System.out.println("Название : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение встроенных свойств**
Изменение встроенных свойств файлов презентаций так же просто, как и доступ к ним. Вы можете просто присвоить строковое значение любому нужному свойству, и значение свойства будет изменено. В приведенном ниже примере мы продемонстрировали, как мы можем изменить встроенные свойства документа файла презентации с помощью Aspose.Slides для Android через Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создание ссылки на объект IDocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Установка встроенных свойств
    dp.setAuthor("Aspose.Slides для Android через Java");
    dp.setTitle("Изменение свойств презентации");
    dp.setSubject("Тема Aspose");
    dp.setComments("Описание Aspose");
    dp.setManager("Руководитель Aspose");
    
    // Сохранение вашей презентации в файл
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример изменяет встроенные свойства презентации, которые можно просмотреть, как показано ниже:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**
Aspose.Slides для Android через Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Приведен пример ниже, который показывает, как установить пользовательские свойства для презентации.

```java
Presentation pres = new Presentation();
try {
    // Получение свойств документа
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Добавление пользовательских свойств
    dProps.set_Item("Новое Пользовательское", 12);
    dProps.set_Item("Мое Имя", "Mudassir");
    dProps.set_Item("Пользовательское", 124);
    
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
Aspose.Slides для Android через Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Приведен пример ниже, который показывает, как вы можете получить доступ и изменить все эти пользовательские свойства для презентации.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создание ссылки на объект DocumentProperties, связанный с Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Доступ и изменение пользовательских свойств
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Отображение имен и значений пользовательских свойств
        System.out.println("Имя пользовательского свойства : " + dp.getCustomPropertyName(i));
        System.out.println("Значение пользовательского свойства : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Изменение значений пользовательских свойств
        dp.set_Item(dp.getCustomPropertyName(i), "Новое Значение " + (i + 1));
    }
    
    // Сохранение вашей презентации в файл
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот пример изменяет пользовательские свойства [PPTX ](https://docs.fileformat.com/presentation/pptx/)презентации. Следующие фигуры показывают пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**
{{% alert color="primary" %}} 

В интерфейс [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) добавлены новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) и [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-), логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) была изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) были добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo). Они предоставляют быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки всей презентации.

Типичный сценарий загрузки свойств, изменения какого-то значения и обновления документа можно реализовать следующим образом:

```java
// Чтение информации о презентации
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Получение текущих свойств
IDocumentProperties props = info.readDocumentProperties();

// Установка новых значений полей Автор и Название
props.setAuthor("Новый Автор");
props.setTitle("Новое Название");

// Обновление презентации с новыми значениями
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Есть еще один способ использовать свойства определенной презентации в качестве шаблона для обновления свойств в других презентациях:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Автор Шаблона");
template.setTitle("Название Шаблона");
template.setCategory("Категория Шаблона");
template.setKeywords("Ключевое слово1, Ключевое слово2, Ключевое слово3");
template.setCompany("Наша Компания");
template.setComments("Создано из шаблона");
template.setContentType("Контент Шаблона");
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

Новый шаблон можно создать с нуля, а затем использовать для обновления нескольких презентаций:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Автор Шаблона");
template.setTitle("Название Шаблона");
template.setCategory("Категория Шаблона");
template.setKeywords("Ключевое слово1, Ключевое слово2, Ключевое слово3");
template.setCompany("Наша Компания");
template.setComments("Создано из шаблона");
template.setContentType("Контент Шаблона");
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

## **Проверка, изменена или создана презентация**
Aspose.Slides для Android через Java предоставляет возможность проверить, была ли презентация изменена или создана. Приведен пример ниже, который показывает, как проверить, была ли презентация создана или изменена.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Имя приложения: " + app);
System.out.println("Версия приложения: " + ver);
```

## **Установка языка проверки**

Aspose.Slides предоставляет свойство LanguageId (предоставляемое классом PortionFormat), чтобы вы могли установить язык проверки для документа PowerPoint. Язык проверки — это язык, на котором проверяются орфография и грамматика в PowerPoint.

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

    portionFormat.setLanguageId("zh-CN"); // установка Id языка проверки

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
    // Добавление новой прямоугольной формы с текстом
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Новый Текст");

    // Проверка языка первой порции
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```