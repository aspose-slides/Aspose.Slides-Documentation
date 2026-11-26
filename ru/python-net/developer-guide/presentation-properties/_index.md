---
title: Управление свойствами презентации с Python
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/python-net/presentation-properties/
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
- Python
- Aspose.Slides
description: "Мастерство управления свойствами презентации в Aspose.Slides for Python via .NET и оптимизация поиска, брендинга и рабочего процесса в ваших файлах PowerPoint."
---
## **Введение**

Aspose.Slides for Python via .NET поддерживает **встроенные** и **пользовательские** свойства документа. Используйте эти свойства для чтения и обновления метаданных презентации, таких как автор, название и пользовательские значения.

Aspose.Slides позволяет работать со свойствами документа презентации через класс [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . Экземпляр этого класса возвращается методом [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Ниже приведены примеры того, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Aspose.Slides управляет метаданными приложения и производителя при сохранении презентаций; эти поля идентифицируют программное обеспечение, создавшее результат.
{{% /alert %}}

## **Управление свойствами презентации**

Свойства документа хранят описательную информацию вместе с содержимым презентации. Они делятся на две категории:

- **Встроенные свойства** содержат стандартные метаданные, такие как название, автор и статистика документа.
- **Пользовательские свойства** хранят пользовательские пары имя/значение.

Aspose.Slides for Python via .NET предоставляет доступ к обеим категориям. В PowerPoint выберите **File → Info → Properties → Advanced Properties**, чтобы просмотреть метаданные документа. Диалог группирует информацию по вкладкам, таким как **Summary**, **Statistics**, **Contents** и **Custom**. Используйте вкладку **Custom** для управления пользовательскими свойствами.

## **Чтение публичных свойств из зашифрованной презентации**

Пароль для открытия обычно защищает как содержимое презентации, так и свойства документа. Если презентация зашифрована с помощью [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) со значением `False`, её свойства документа остаются публичными. Приложение может затем установить [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) в `True` и прочитать публичные метаданные без указания пароля открывания.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) контролирует, что загружает Aspose.Slides; она не расшифровывает ничего. Если свойства были включены в шифрование, загрузка без пароля завершится ошибкой. Если презентация не зашифрована, параметр игнорируется и загружается полная презентация.

Пример требует зашифрованную презентацию, у которой свойства документа оставлены публичными. Он проверяет режим загрузки через [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) и затем читает встроенные свойства через [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения должны всегда проверять [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) перед выполнением операции, требующей полной модели объектов презентации.

{{% alert color="warning" title="Security" %}}
Публичные метаданные могут раскрыть имена авторов, названия, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только тогда, когда системы индексации, классификации, поиска или управления документами имеют конкретную необходимость доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная с помощью [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/), предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из этого объекта только с метаданными, потому что публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

Пример требует зашифрованную презентацию PPTX с публичными свойствами документа и известным паролем открытия. Он полностью открывает презентацию с помощью [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) для проверки сохранения шифрования и заново открывает публичные метаданные без пароля, чтобы проверить новые значения:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Если приложению не разрешено расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Класс [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) предоставляет встроенные метаданные через типизированные свойства, включая [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) и [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Этот пример открывает существующую презентацию и выводит её сохранённые метаданные в консоль. Значения зависят от входной презентации; некоторые поля могут быть пустыми.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

### **Отчет о номере версии и времени редактирования**

Чтобы отчитаться о номере версии и общем времени редактирования для каждого файла PPTX в папке `presentations`, используйте [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) для получения его [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) без загрузки слайдов для редактирования. Python отображает длительность как `timedelta`, включая количество дней, когда зафиксированное время достигает 24 часов.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

Для презентации с 1 днём, 2 часами и 5 минутами зафиксированного времени редактирования в отчёте будет следующая строка.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) является записываемыми метаданными. Одного только его значения недостаточно, чтобы определить, сколько раз презентация была сохранена, или воссоздать её историю версий.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) сообщает о длительности редактирования, хранящейся в файле. Значение `0:00:00` означает, что зафиксированная длительность равна нулю, даже если кто‑то редактировал презентацию.

## **Изменение встроенных свойств**

Чтобы обновить встроенные метаданные, присвойте значения записываемым свойствам, доступным через [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Этот пример открывает существующую презентацию, задаёт [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) и [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), затем сохраняет обновлённую презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Сохранённый PPTX содержит новые метаданные.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление базой гиперссылок**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) хранит базовый путь документа для относительных гиперссылок. Это полезно при перемещении презентации и связанных с ней файлов в другое место. Он отделён от отдельного гиперссылочного свойства [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): изменение базы не переписывает сохранённые адреса ссылок и не меняет абсолютные назначения.

Пример требует презентацию, содержащую как относительную ссылку (например, `target.html`), так и абсолютную ссылку на файл или веб‑сайт. Он читает существующую базу, задаёт новый базовый адрес, сохраняет и заново открывает презентацию для проверки значения. Затем он очищает базу, задав `""`, и проверяет пустое значение в отдельном сохранённом файле. Замените пример базового адреса на расположение ваших связанных файлов.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Оба проверочных сообщения должны вывести `True`. Очистка базы оставляет отдельные адреса гиперссылок нетронутыми.

Относительная ссылка на `target.pptx` открывала `old/target.pptx`, когда база указывала на папку `old`. После изменения базы на папку `new`, сохранения и повторного открытия презентации та же ссылка открывает `new/target.pptx`. Абсолютная ссылка продолжала открывать тот же файл. Проверьте свои относительные ссылки в PowerPoint до и после перемещения презентации или изменения её базы.

## **Добавление пользовательских свойств презентации**

Пользовательские свойства хранят метаданные, не имеющие соответствующего встроенного поля. Метод [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) позволяет задать значение по имени свойства. Этот пример создаёт презентацию, добавляет два текстовых значения и одно целочисленное значение версии, затем сохраняет презентацию с помощью [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Присвоение значения уже существующему имени заменяет значение этого свойства.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ и изменение пользовательских свойств**

Этот пример открывает презентацию, содержащую пользовательские свойства, и использует [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) для их перебора. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) принимает индексацию, начинающуюся с нуля, и возвращает имя, используемое в [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Пример требует презентацию, у которой все пользовательские свойства являются строками. Он выводит каждое исходное имя и значение, заменяет каждое значение нумерованной строкой и сохраняет изменения. Если пользовательских свойств нет, цикл не вносит изменений.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) возвращает значение через одноэлементный список, передаваемый вторым аргументом. Заполнитель должен соответствовать типу сохранённого свойства: используйте `[""]` для строки или `[0]` для целого числа. Несоответствие типов вызывает `InvalidCastException`; выбирайте заполнитель согласно схеме ваших пользовательских свойств.

## **Рабочий пример**

Попробуйте онлайн‑приложение [**Просмотр и редактирование метаданных PowerPoint**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа, используя API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако их можно изменить или, если позволяет конкретное свойство, задать пустое значение.

**Что происходит, если я добавляю пользовательское свойство, которое уже существует?**

Если вы добавляете пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять наличие свойства не требуется, так как Aspose.Slides автоматически обновляет значение свойства.

**Могу ли я получить доступ к свойствам презентации без полного её загрузки?**

Да. Используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) и затем [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). См. [Создание лёгкого инвентаря презентаций](/slides/ru/python-net/examine-presentation/) для полного примера отчёта и ограничений, связанных с конкретными форматами.

**Могу ли я читать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Презентация должна была быть зашифрована с параметром [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/), установленным в `False`, и должна быть загружена с параметром [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) , установленным в `True`.

**Могу ли я обновить зашифрованный файл PPTX в режиме только свойств документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.