---
title: Управление свойствами презентации в Python
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/python-java/presentation-properties/
keywords:
- Свойства PowerPoint
- Свойства презентации
- Свойства документа
- Встроенные свойства
- Настраиваемые свойства
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
- Python
- Aspose.Slides
description: "Управляйте свойствами презентации в Aspose.Slides для Python via Java и упрощайте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides for Python via Java поддерживает **встроенные** и **настраиваемые** свойства документа. Используйте эти свойства для чтения и обновления метаданных презентации, таких как автор, заголовок и пользовательские значения.

Aspose.Slides позволяет работать со свойствами документа презентации через класс [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) . Экземпляр этого класса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Ниже приведены примеры того, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Aspose.Slides управляет метаданными приложения и производителя при сохранении презентаций; эти поля определяют программное обеспечение, создавшее результат.
{{% /alert %}}

## **Управление свойствами презентации**

Свойства документа хранят описательную информацию вместе с содержимым презентации. Они делятся на две категории:

- **Встроенные свойства** содержат стандартные метаданные, такие как заголовок, автор и статистика документа.
- **Настраиваемые свойства** хранят пользовательские пары имени/значения.

Aspose.Slides for Python via Java предоставляет доступ к обеим категориям. В PowerPoint выберите **File → Info → Properties → Advanced Properties**, чтобы просмотреть метаданные документа. Диалог группирует информацию по вкладкам, таким как **Summary**, **Statistics**, **Contents** и **Custom**. Используйте вкладку **Custom** для управления пользовательскими свойствами.

## **Чтение публичных свойств из зашифрованной презентации**

Обычный пароль при открытии защищает как содержимое презентации, так и свойства документа. Когда презентация зашифрована после вызова [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) с параметром `False`, её свойства документа остаются публичными. Приложение затем может вызвать [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) с параметром `True` и прочитать публичные метаданные без предоставления пароля.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) управляет тем, что загружает Aspose.Slides; он ничего не расшифровывает. Если свойства были включены в шифрование, загрузка без пароля завершается неудачей. Если презентация не зашифрована, параметр игнорируется и загружается полная презентация.

В примере требуется зашифрованная презентация, у которой свойства документа оставлены публичными. Он проверяет режим загрузки через [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) и затем читает встроенные свойства через [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, мультимедиа и другие объекты презентации недоступны. Приложения всегда должны проверять [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) перед выполнением операции, требующей полной модели объектов презентации.

{{% alert color="warning" title="Warning" %}}
Публичные метаданные могут раскрыть имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте конфиденциальные свойства вместе с презентацией. Оставляйте их публичными только в тех случаях, когда системы индексации, классификации, поиска или управления документами имеют конкретное требование доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная после вызова [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) с параметром `True`, предназначена только для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из этого объекта, содержащего только метаданные, потому что публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

В примере требуется зашифрованная PPTX‑презентация с публичными свойствами документа и известным паролем открытия. Она открывает полную презентацию с помощью [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), обновляет публичные встроенные свойства и сохраняет результат. Затем используется [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) для проверки сохранения шифрования и повторно открывает публичные метаданные без пароля для проверки новых значений:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Если приложению не разрешено расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Класс [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) предоставляет встроенные метаданные через методы получения, включая [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) и [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Этот пример открывает существующую презентацию и выводит её сохранённые метаданные в консоль. Значения зависят от входной презентации; некоторые поля могут быть пустыми.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Изменение встроенных свойств**

Чтобы обновить встроенные метаданные, используйте методы‑установщики на объекте, возвращаемом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Этот пример открывает существующую презентацию, вызывает [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) и [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), затем сохраняет обновлённую презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Сохранённый PPTX содержит новые метаданные.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Управление базой гиперссылок**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) возвращает документ‑уровневую базу для относительных гиперссылок. Используйте [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) для изменения или очистки её. Это полезно при перемещении презентации и связанных файлов в другое место. Это отдельно от отдельной гиперссылки [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl): изменение базы не переписывает сохранённые адреса ссылок и не меняет абсолютные назначения.

В примере требуется презентация, содержащая как относительную ссылку, например `target.html`, так и абсолютную ссылку, например `https://example.org/absolute.html`. Он читает существующую базу, назначает новый базовый адрес и сохраняет, а затем переоткрывает презентацию для проверки значения. Затем он очищает базу пустой строкой и проверяет пустое значение в отдельном сохранённом файле. Замените пример базового адреса на расположение ваших связанных файлов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

Оба сообщения проверки должны вывести `True`. Очистка базы оставляет отдельные адреса гиперссылок без изменений.

Относительная ссылка на `target.pptx` открывала `old/target.pptx`, когда база указывала на папку `old`. После изменения базы на папку `new`, сохранения и повторного открытия презентации, та же ссылка открыла `new/target.pptx`. Абсолютная ссылка продолжала открывать тот же файл. Протестируйте ваши относительные ссылки в PowerPoint до и после перемещения презентации или изменения её базы.

## **Добавление пользовательских свойств презентации**

Пользовательские свойства хранят метаданные, для которых нет соответствующего встроенного поля. Метод [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) позволяет назначать значение по имени свойства. Этот пример создаёт презентацию, добавляет два текстовых значения и целочисленное значение версии (используя `jpype.JInt` для передачи Java‑целого), и сохраняет презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Присвоение значения существующему имени заменяет значение свойства.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ и изменение пользовательских свойств**

Этот пример открывает презентацию, содержащую пользовательские свойства, и использует [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) для их перебора. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) принимает нулевой индекс и возвращает имя, используемое в [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). Пример выводит каждое исходное имя и значение, заменяет каждое значение нумерованной строкой независимо от исходного типа и сохраняет изменения. Если пользовательские свойства отсутствуют, цикл не вносит изменений.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Рабочий пример**

Попробуйте онлайн‑приложение [**Просмотр и редактирование метаданных PowerPoint**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа, используя API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их невозможно. Однако вы можете изменить их значения или установить их пустыми, если это допускается конкретным свойством.

**Что произойдёт, если я добавлю пользовательское свойство, которое уже существует?**

Если вы добавите пользовательское свойство, которое уже существует, его текущие значение будет перезаписано новым. Удалять или проверять свойство заранее не требуется, так как Aspose.Slides автоматически обновляет значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo), а затем [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). См. [Build a Lightweight Presentation Inventory](/slides/ru/python-java/examine-presentation/) для полного примера отчётности и ограничений, зависящих от формата.

**Можно ли прочитать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Презентация должна была быть зашифрована после вызова [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) с параметром `False`, и должна быть загружена после вызова [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) с параметром `True`.

**Можно ли обновить зашифрованный файл PPTX в режиме только свойств документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.