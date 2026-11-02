---
title: Управление свойствами презентации на JavaScript
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
- Язык проверки
- Язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Освойте управление свойствами презентаций в Aspose.Slides for Node.js via Java и оптимизируйте поиск, брендинг и рабочие процессы в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides for Node.js via Java поддерживает **встроенные** и **пользовательские** свойства документа. Используйте эти свойства для чтения и обновления метаданных презентации, таких как автор, заголовок и пользовательские значения.

Aspose.Slides позволяет работать со свойствами документа презентации через класс [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Экземпляр этого класса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Ниже приведены примеры, показывающие, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Aspose.Slides управляет метаданными приложения и производителя при сохранении презентаций; эти поля идентифицируют программное обеспечение, создавшее результат.
{{% /alert %}}

## **Управление свойствами презентации**

Свойства документа хранят описательную информацию вместе с содержимым презентации. Они делятся на две категории:

- **Встроенные свойства** содержат стандартные метаданные, такие как заголовок, автор и статистика документа.
- **Пользовательские свойства** хранят пары пользовательских имя/значение.

Aspose.Slides for Node.js via Java предоставляет доступ к обеим категориям. В PowerPoint выберите **File → Info → Properties → Advanced Properties**, чтобы просмотреть метаданные документа. Диалог группирует информацию по вкладкам, таким как **Summary**, **Statistics**, **Contents** и **Custom**. Используйте вкладку **Custom** для управления пользовательскими свойствами.

## **Чтение публичных свойств из зашифрованной презентации**

Пароль открытия обычно защищает как содержимое презентации, так и свойства документа. Когда презентация шифруется после вызова [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) с параметром `false`, её свойства документа остаются публичными. Приложение может затем вызвать [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) с параметром `true` и прочитать публичные метаданные без указания пароля открытия.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) управляет тем, что загружает Aspose.Slides; он не выполняет дешифрование. Если свойства были включены в шифрование, попытка загрузить их без пароля приведёт к ошибке. Если презентация не зашифрована, параметр игнорируется и загружается вся презентация.

Пример требует зашифрованной презентации, у которой свойства документа оставлены публичными. Он проверяет режим загрузки через [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) и затем читает встроенные свойства через [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения всегда должны проверять [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) перед выполнением операции, требующей полной модели объектов презентации.

{{% alert color="warning" title="Warning" %}}
Публичные метаданные могут раскрывать имена авторов, заголовки, темы, ключевые слова, сведения о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Делайте их публичными только если системы индексации, классификации, поиска или управления документами требуют доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная после вызова [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) с параметром `true`, предназначена только для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из объекта, загруженного только с документ‑свойствами, потому что публичные свойства должны оставаться согласованными с данными внутри зашифрованной презентации. Поэтому их обновление требует корректного пароля открытия и полной загрузки.

Пример требует зашифрованной презентации PPTX с публичными свойствами документа и известного пароля открытия. Он открывает полную презентацию с помощью [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), обновляет публичные встроенные свойства и сохраняет результат. Затем используется [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) для проверки сохранения шифрования и повторно открывается публичная метадата без пароля для проверки новых значений:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

Если приложение не имеет права дешифровать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Класс [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) предоставляет встроенные метаданные через методы‑получатели, включая [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) и [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Этот пример открывает существующую презентацию и выводит её сохранённые метаданные в консоль. Значения зависят от входной презентации; некоторые поля могут быть пустыми.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Изменение встроенных свойств**

Чтобы обновить встроенные метаданные, используйте методы‑установщики на объекте, возвращённом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Этот пример открывает существующую презентацию, вызывает [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) и [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), затем сохраняет обновлённую презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Сохранённый PPTX содержит новые метаданные.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление базой гиперссылок**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) возвращает базовый адрес уровня документа для относительных гиперссылок. Используйте [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) для изменения или очистки этого адреса. Это удобно при перемещении презентации и связанных файлов в другое место. Это отдельный параметр от [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) отдельной гиперссылки: изменение базы не переписывает сохранённые адреса ссылок и не меняет абсолютные назначения.

Пример требует презентацию, содержащую как относительную ссылку (например, `target.html`), так и абсолютную ссылку (например, `https://example.org/absolute.html`). Он считывает существующую базу, задаёт новую базу и сохраняет, а затем открывает презентацию для проверки значения. Затем он очищает базу, задав пустую строку, и проверяет пустое значение в отдельном сохранённом файле. Замените пример базового адреса на расположение ваших связанных файлов.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

Оба сообщения проверки должны вывести `true`. Очистка базы оставляет отдельные адреса гиперссылок неизменными.

Относительная ссылка `target.pptx` открывала `old/target.pptx`, когда база указывала на папку `old`. После изменения базы на папку `new`, сохранения и повторного открытия презентации та же ссылка открывала `new/target.pptx`. Абсолютная ссылка продолжала открывать тот же файл. Проверьте свои относительные ссылки в PowerPoint до и после перемещения презентации или изменения её базы.

## **Добавление пользовательских свойств презентации**

Пользовательские свойства хранят метаданные, которые не имеют соответствующего встроенного поля. Метод [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) позволяет задать значение по имени свойства. Этот пример создаёт презентацию, добавляет два текстовых значения и целочисленное значение версии, затем сохраняет презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Присвоение значения уже существующему имени заменяет значение этого свойства.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ и изменение пользовательских свойств**

Этот пример открывает презентацию, содержащую пользовательские свойства, и использует [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) для их перебора. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) принимает индекс, начинающийся с нуля, и возвращает имя, используемое в [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). Пример выводит каждое оригинальное имя и значение, заменяя каждое значение на нумерованную строку независимо от исходного типа, и сохраняет изменения. Если пользовательские свойства отсутствуют, цикл не вносит изменений.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Рабочий пример**

Попробуйте онлайн‑приложение [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа с помощью API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить пустое значение, если это допускает конкретное свойство.

**Что происходит, если я добавлю пользовательское свойство, которое уже существует?**

Если вы добавите пользовательское свойство с именем, которое уже существует, его текущее значение будет перезаписано новым. Нет необходимости удалять или проверять свойство заранее — Aspose.Slides автоматически обновит значение свойства.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo), а затем [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). См. пример [Build a Lightweight Presentation Inventory](/slides/ru/nodejs-java/examine-presentation/) для полного отчёта и ограничений, связанных с конкретными форматами.

**Могу ли я прочитать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Презентация должна быть зашифрована после вызова [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) с параметром `false`, и должна быть загружена после вызова [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) с параметром `true`.

**Могу ли я обновить зашифрованный файл PPTX в режиме только‑свойств‑документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.