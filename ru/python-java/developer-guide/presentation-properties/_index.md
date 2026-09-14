---
title: Управление свойствами презентации в Python
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/python-java/presentation-properties/
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
- редактирование метаданных
- язык корректуры
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Полный контроль над свойствами презентаций в Aspose.Slides для Python via Java и упрощение поиска, брендинга и рабочего процесса в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документов: **Встроенные** и **Пользовательские**. Оба типа свойств можно легко получить и управлять ими с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентаций через класс [DocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/). Экземпляр этого класса возвращается методом [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDocumentProperties). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Note" %}}
Обратите внимание, что поля **Application** и **AppVersion** нельзя изменять. Aspose.Slides перезаписывает их при каждом сохранении, поэтому сохранённая презентация всегда указывает «Aspose.Slides for Java» и версию библиотеки, которая её создала. Любое значение, переданное в [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#setNameOfApplication), отбрасывается при записи презентации.
{{% /alert %}}

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документов файлов презентаций. Нажмите значок Office и выберите **Prepare | Properties | Advanced Properties**, как показано ниже:

|**Выбор пункта меню «Advanced Properties»**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
После выбора **Advanced Properties** появится диалог, где можно управлять свойствами файла PowerPoint:

|**Диалог свойств**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
**Диалог свойств** содержит вкладки **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Эти вкладки позволяют настраивать различную информацию о файлах PowerPoint. Используйте вкладку **Custom** для управления пользовательскими свойствами.

## **Работа со свойствами документов с помощью Aspose.Slides для Python via Java**

Как было описано ранее, Aspose.Slides для Python via Java поддерживает как **Встроенные**, так и **Пользовательские** свойства документов. Класс [DocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/) представляет свойства документа, связанные с файлом презентации.

Для доступа к этим свойствам используйте [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDocumentProperties), как показано ниже.

## **Чтение публичных свойств из зашифрованной презентации**

Пароль открытия обычно защищает как содержимое презентации, так и свойства документа. Когда презентация зашифрована передачей `false` в [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), её свойства документа остаются публичными. Затем приложение может передать `true` в [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) и прочитать публичные метаданные без указания пароля открытия.

Опция загрузки только свойств документа контролирует, что Aspose.Slides загружает; она ничего не расшифровывает. Если свойства были включены в шифрование, их загрузка без пароля завершится ошибкой. Если презентация не зашифрована, опция игнорируется и загружается полная презентация.

Следующий пример проверяет режим загрузки через [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded), а затем читает встроенные свойства через [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDocumentProperties):

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

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения должны всегда проверять [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) перед выполнением операций, требующих полной объектной модели презентации.

{{% alert color="warning" title="Warning" %}}
Публичные метаданные могут раскрывать имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только тогда, когда системы индексирования, классификации, поиска или управления документами имеют специфическое требование доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная в режиме только свойств документа, предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из этого объекта только с метаданными, потому что публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

В следующем примере презентация открывается с помощью [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setPassword), обновляются публичные встроенные свойства и сохраняется результат. Затем проверяется, что шифрование сохранено, с помощью [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#isEncrypted), и публичные метаданные открываются без пароля для проверки новых значений:

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

Если приложение не имеет права расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Встроенные свойства, предоставляемые [DocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/), включают: **Creator** (Автор), **Description**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **Keywords**, **SharedDoc** (Общий документ?), **PresentationFormat**, **Subject**, и **Title**.

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Создайте экземпляр класса Presentation, который представляет презентацию
presentation = Presentation("Presentation.pptx")
try:
    # Создайте ссылку на объект DocumentProperties, связанный с Presentation
    properties = presentation.getDocumentProperties()

    # Отобразите встроенные свойства
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Изменение встроенных свойств**

Изменение встроенных свойств так же просто, как их получение. Используйте соответствующий сеттер для присвоения нового значения. Ниже приведен пример изменения встроенных свойств документа с помощью Aspose.Slides для Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Создайте ссылку на объект DocumentProperties, связанный с Presentation
    properties = presentation.getDocumentProperties()

    # Установите встроенные свойства
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Сохраните презентацию в файл
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Этот пример изменяет встроенные свойства презентации, как показано ниже:

|**Встроенные свойства документа после изменения**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Добавление пользовательских свойств документа**

Aspose.Slides для Python via Java также позволяет разработчикам добавлять пользовательские свойства документа к презентациям. Пример ниже добавляет три пользовательских свойства, затем ищет имя, хранящееся под индексом 2, и удаляет это свойство, так что сохранённая презентация сохраняет два из них. Пользовательские свойства индексируются в алфавитном порядке, а не в порядке их добавления.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Получение свойств документа
    properties = presentation.getDocumentProperties()

    # Добавление пользовательских свойств
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Получение имени свойства по конкретному индексу
    property_name = properties.getCustomPropertyName(2)

    # Удаление выбранного свойства
    properties.removeCustomProperty(property_name)

    # Сохранение презентации
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Добавленные пользовательские свойства документа**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Доступ и изменение пользовательских свойств**

Aspose.Slides для Python via Java также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ ко всем пользовательским свойствам в презентации и изменить их.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Создайте ссылку на объект DocumentProperties, связанный с Presentation
    properties = presentation.getDocumentProperties()

    # Получите доступ к пользовательским свойствам и измените их
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Отобразите имена и значения пользовательских свойств
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Измените значения пользовательских свойств
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Сохраните презентацию в файл
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Этот пример изменяет пользовательские свойства презентации [PPTX](https://docs.fileformat.com/presentation/pptx/). На следующих рисунках показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Пользовательские свойства после изменения**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Расширенные свойства документа**

{{% alert color="info" title="Note" %}}
Новые методы [readDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) и [writeBindedPresentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) были добавлены в [PresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/), а поведение метода [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#setLastSavedTime) изменилось.
{{% /alert %}}

Два новых метода [readDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#readDocumentProperties) и [updateDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/). Они предоставляют быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без полной загрузки презентации.

Типичный рабочий процесс загрузки свойств, изменения их значений и обновления документа может быть реализован следующим образом:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Прочитать информацию о презентации
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Получить текущие свойства
properties = presentation_info.readDocumentProperties()

# Установить новые значения полей Автора и Заголовка
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Обновить презентацию новыми значениями
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Существует другой способ использования свойств конкретной презентации как шаблона для обновления свойств в других презентациях:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Новый шаблон можно создать с нуля и затем использовать для обновления нескольких презентаций:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Установка языка корректуры**

Aspose.Slides предоставляет метод [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#setLanguageId), позволяющий установить язык корректуры для документа PowerPoint. Язык корректуры — это язык, для которого проверяется орфография и грамматика в презентации.

Этот Python‑код показывает, как установить язык корректуры для PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # установить идентификатор языка корректуры

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Установка языка по умолчанию**

Этот Python‑код показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Добавляет прямоугольную форму с текстом
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Проверяет язык первой части
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Рабочий пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить пустое значение, если это допускается конкретным свойством.

**Что произойдёт, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Нет необходимости предварительно удалять или проверять свойство — Aspose.Slides автоматически обновит значение свойства.

**Можно ли получить доступ к свойствам презентации без полной её загрузки?**

Да. Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo), а затем [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#readDocumentProperties) для чтения сохранённой метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). См. [Build a Lightweight Presentation Inventory](/slides/ru/python-java/examine-presentation/) для полного примера отчёта и ограничений, зависящих от формата.

**Можно ли прочитать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Шифрование свойств документа должно быть отключено до того, как презентация была зашифрована, и презентация должна быть загружена в режиме только свойств документа.

**Можно ли обновить зашифрованный файл PPTX в режиме только свойств документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.