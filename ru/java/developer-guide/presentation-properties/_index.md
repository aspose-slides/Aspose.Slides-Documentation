---
title: Управление свойствами презентации в Java
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/java/presentation-properties/
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
- Язык проверки орфографии
- Язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте свойствами презентации в Aspose.Slides для Java и упрощайте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба этих типа свойств легко доступны и управляются с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/). Экземпляр этого интерфейса возвращается методом [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Примечание" %}}

Обратите внимание, что поля **Application** и **AppVersion** изменить нельзя. Aspose.Slides переписывает их при каждом сохранении, поэтому сохранённая презентация всегда отображает «Aspose.Slides for Java» и версию библиотеки, которая её создала. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.

{{% /alert %}} 

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать — нажать значок Office и выбрать пункт меню **Prepare | Properties | Advanced Properties**, как показано ниже:

|**Выбор пункта меню Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

После выбора пункта **Advanced Properties** появляется диалоговое окно, позволяющее управлять свойствами документа PowerPoint, как показано на рисунке:

|**Диалоговое окно свойств**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

В приведённом **Диалоговом окне свойств** вы можете видеть несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют задавать различные сведения о файлах PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

### Работа со свойствами документа с помощью Aspose.Slides for Java

Как мы уже описали, Aspose.Slides for Java поддерживает два вида свойств документа: **Built-in** и **Custom**. Поэтому разработчики могут получать доступ к обоим типам свойств через API Aspose.Slides for Java. Aspose.Slides for Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, доступное у объекта [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation), чтобы получить доступ к свойствам документа презентации, как описано ниже:

## **Чтение публичных свойств из зашифрованной презентации**

Обычный пароль открытия защищает как содержимое презентации, так и свойства документа. При шифровании презентации с передачей `false` в [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), её свойства документа остаются публичными. Затем приложение может передать `true` в [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) и прочитать публичные метаданные без указания пароля открытия.

Опция «только свойства документа» управляет тем, что загружает Aspose.Slides; она ничего не расшифровывает. Если свойства были включены в шифрование, загрузка их без пароля завершится ошибкой. Если презентация не зашифрована, опция игнорируется и загружается полная презентация.

Следующий пример проверяет режим загрузки через [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) и затем читает встроенные свойства через [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения должны всегда проверять [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) перед выполнением операций, требующих полной модели объектов презентации.

{{% alert color="warning" title="Предупреждение" %}}
Публичные метаданные могут раскрывать имена авторов, заголовки, темы, ключевые слова, сведения о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только тогда, когда системы индексирования, классификации, поиска или управления документами требуют доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная в режиме «только свойства документа», предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из этого объекта, потому что публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

Следующий пример открывает презентацию с помощью [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) для проверки сохранения шифрования и повторно открывает публичные метаданные без пароля, чтобы проверить новые значения:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Если приложение не имеет права расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Совместный документ?), **PresentationFormat**, **Subject** и **Title**.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation, представляющего презентацию
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Вывести встроенные свойства
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

Изменять встроенные свойства файлов презентаций так же просто, как их получать. Достаточно присвоить нужному свойству строковое значение, и значение свойства будет изменено. В примере ниже показано, как можно изменить встроенные свойства документа презентации с помощью Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект IDocumentProperties, связанный с презентацией
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

Этот пример изменяет встроенные свойства презентации, что видно на изображении ниже:

|**Встроенные свойства документа после изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. В примере ниже добавляются три пользовательских свойства, затем ищется имя, хранящееся в индексе 2, и это свойство удаляется, поэтому сохранённая презентация оставляет два из них. Пользовательские свойства индексируются в алфавитном порядке, а не в порядке добавления.

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

|**Добавленные пользовательские свойства документа**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Java также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все эти пользовательские свойства для презентации.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Создать ссылку на объект DocumentProperties, связанный с презентацией
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Доступ к пользовательским свойствам и их изменение
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Вывести имена и значения пользовательских свойств
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

Этот пример изменяет пользовательские свойства [PPTX](https://docs.fileformat.com/presentation/pptx/) презентации. На рисунках ниже показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="info" title="Примечание" %}}

Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo); логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPresentationInfo). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять их без загрузки всей презентации.

Типичный сценарий: загрузить свойства, изменить некоторое значение и обновить документ можно следующим образом:

```java
import com.aspose.slides.*;

// чтение информации о презентации
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

Новый шаблон можно создать с нуля и затем использовать для обновления нескольких презентаций:

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

Aspose.Slides предоставляет свойство LanguageId (доступное через класс PortionFormat), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

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

## **Онлайн‑пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить пустое значение, если конкретное свойство это позволяет.

**Что происходит, если я добавлю пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять свойство не требуется — Aspose.Slides автоматически обновит значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки её?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), а затем [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). См. **Build a Lightweight Presentation Inventory** (/slides/ru/java/examine-presentation/) для полного примера отчёта и ограничений для конкретных форматов.

**Можно ли прочитать публичные свойства зашифрованной презентации без пароля её открытия?**

Да. Шифрование свойств документа должно было быть отключено до шифрования презентации, и презентация должна быть загружена в режиме «только свойства документа».

**Можно ли обновить зашифрованный файл PPTX в режиме «только свойства документа»?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с корректным паролем открытия.