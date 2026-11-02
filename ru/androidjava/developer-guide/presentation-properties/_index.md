---
title: Управление свойствами презентации на Android
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/androidjava/presentation-properties/
keywords:
- Свойства PowerPoint
- Свойства презентации
- Свойства документа
- Встроенные свойства
- Пользовательские свойства
- Продвинутые свойства
- Управление свойствами
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- Язык проверки
- Язык по умолчанию
- PowerPoint
- OpenDocument
- Презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте свойствами презентаций с помощью Aspose.Slides для Android через Java и упростите поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides for Android via Java поддерживает **встроенные** и **пользовательские** свойства документа. Используйте эти свойства для чтения и обновления метаданных презентации, таких как автор, название и значения, определённые пользователем.

Aspose.Slides позволяет работать со свойствами документа презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/). Экземпляр этого интерфейса возвращается методом [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Ниже приведены примеры, показывающие, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Aspose.Slides управляет метаданными приложения и производителя при сохранении презентаций; эти поля указывают программное обеспечение, которое создало вывод.
{{% /alert %}}

## **Управление свойствами презентации**

Свойства документа хранят описательную информацию вместе с содержимым презентации. Они делятся на две категории:

- **Встроенные свойства** содержат стандартные метаданные, такие как название, автор и статистика документа.
- **Пользовательские свойства** хранят пары имя/значение, определённые пользователем.

Aspose.Slides for Android via Java предоставляет доступ к обеим категориям. В PowerPoint выберите **File → Info → Properties → Advanced Properties**, чтобы просмотреть метаданные документа. Диалог группирует информацию по вкладкам, таким как **Summary**, **Statistics**, **Contents** и **Custom**. Используйте вкладку **Custom** для управления пользовательскими свойствами.

## **Чтение публичных свойств из зашифрованной презентации**

Обычно пароль открытия защищает как содержимое презентации, так и свойства документа. Когда презентация зашифрована после вызова [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) с параметром `false`, её свойства документа остаются публичными. Приложение может затем вызвать [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) с параметром `true` и прочитать публичные метаданные без указания пароля открытия.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) контролирует, что Aspose.Slides загружает; он ничего не расшифровывает. Если свойства были включены в шифрование, их загрузка без пароля завершится ошибкой. Если презентация не зашифрована, параметр игнорируется и загружается полная презентация.

Пример требует зашифрованной презентации, у которой свойства документа оставлены публичными. Он проверяет режим загрузки через [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) и затем читает встроенные свойства через [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения должны всегда проверять [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) перед выполнением операций, требующих полной модели объекта презентации.

{{% alert color="warning" title="Warning" %}}
Публичные метаданные могут раскрыть имена авторов, названия, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только тогда, когда системы индексации, классификации, поиска или управления документами имеют конкретное требование доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная после вызова [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) с `true`, предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из объекта, содержащего только метаданные, поскольку публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

Пример требует зашифрованной презентации PPTX с публичными свойствами документа и известным паролем открытия. Он открывает полную презентацию с помощью [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) для проверки сохранения шифрования и снова открывает публичные метаданные без пароля, чтобы убедиться в новых значениях:

```java
import com.aspose.slides.IDocumentProperties;
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
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

Если приложению не разрешено расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Интерфейс [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) предоставляет встроенные метаданные через методы‑получатели, включая [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) и [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). Этот пример открывает существующую презентацию и выводит её сохранённые метаданные в консоль. Значения зависят от входной презентации; некоторые поля могут быть пустыми.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Изменение встроенных свойств**

Для обновления встроенных метаданных используйте методы‑установки объекта, возвращённого [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Этот пример открывает существующую презентацию, вызывает [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) и [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), затем сохраняет обновлённую презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Сохранённый PPTX содержит новые метаданные.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление базой гиперссылок**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) возвращает базовый адрес документа для относительных гиперссылок. Используйте [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) для изменения или очистки этой базы. Это полезно при перемещении презентации и связанных файлов в другое место. Это отдельно от метода отдельной гиперссылки [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--): изменение базы не переписывает сохранённые адреса ссылок и не меняет абсолютные назначения.

Пример требует презентацию, содержащую как относительную ссылку (например, `target.html`), так и абсолютную ссылку (например, `https://example.org/absolute.html`). Он читает существующую базу, задаёт новый базовый адрес, сохраняет и заново открывает презентацию, чтобы проверить значение. Затем он очищает базу пустой строкой и проверяет пустое значение в отдельном сохранённом файле. Замените пример базового адреса на расположение ваших связанных файлов.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Оба сообщения проверки должны вывести `true`. Очистка базы оставляет адреса отдельных гиперссылок неизменными.

Относительная ссылка на `target.pptx` открывала `old/target.pptx`, когда база указывала на папку `old`. После изменения базы на папку `new`, сохранения и повторного открытия презентации та же ссылка открывала `new/target.pptx`. Абсолютная ссылка продолжала открывать тот же файл. Проверьте свои относительные ссылки в PowerPoint до и после перемещения презентации или изменения её базы.

## **Добавление пользовательских свойств презентации**

Пользовательские свойства хранят метаданные, для которых нет соответствующего встроенного поля. Метод [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) позволяет присвоить значение по имени свойства. Этот пример создаёт презентацию, добавляет два текстовых значения и целочисленное значение версии, затем сохраняет презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Присвоение значения уже существующему имени заменяет значение этого свойства.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ и изменение пользовательских свойств**

Этот пример открывает презентацию, содержащую пользовательские свойства, и использует [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) для их перебора. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) принимает индекс, начинающийся с нуля, и возвращает имя, используемое в [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). Пример выводит каждое оригинальное имя и значение, заменяет каждое значение нумерованной строкой независимо от исходного типа и сохраняет изменения. Если пользовательских свойств нет, цикл не вносит изменений.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Рабочий пример**

Попробуйте онлайн‑приложение [**Просмотр и редактирование метаданных PowerPoint**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа с использованием API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако их можно изменить или установить пустыми, если это допускает конкретное свойство.

**Что происходит, если я добавлю пользовательское свойство, которое уже существует?**

Если вы добавите пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять свойство не требуется, так как Aspose.Slides автоматически обновляет значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) и затем [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). См. [Создание лёгкого инвентаря презентаций](/slides/ru/androidjava/examine-presentation/) для полного примера отчёта и ограничений, специфичных для форматов.

**Можно ли читать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Презентация должна была быть зашифрована после вызова [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) с `false`, и должна быть загружена после вызова [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) с `true`.

**Можно ли обновить зашифрованный файл PPTX в режиме только свойств документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.