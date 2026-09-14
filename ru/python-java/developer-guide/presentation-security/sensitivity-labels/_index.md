---
title: Управление метками чувствительности в презентациях PowerPoint на Python
linktitle: Метки чувствительности
type: docs
weight: 50
url: /ru/python-java/sensitivity-labels/
keywords:
- метка чувствительности
- Microsoft Purview
- Microsoft Information Protection
- метаданные MIP
- маркировка содержимого
- защита информации
- управление документами
- PowerPoint
- PPTX
- безопасность презентаций
- Python
- Aspose.Slides
description: "Читать, добавлять, обновлять, удалять и мигрировать метки чувствительности Microsoft Purview в презентациях PowerPoint PPTX с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Microsoft Purview sensitivity labels помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложению может потребоваться сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные более старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides предоставляет современные метаданные меток чувствительности через [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSensitivityLabels). Этот метод возвращает [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/), которую можно просмотреть и изменить до сохранения презентации в формате PPTX.

{{% alert color="info" title="Примечание" %}}

Идентификаторы меток чувствительности и информация о политике определяются вашей конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в вашей среде перед добавлением или миграцией метаданных. Значения [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) описывают маркировку содержимого, связанную с меткой; они сами по себе не добавляют видимый текст или фигуры на слайды.

{{% /alert %}}

## **Понимание свойств метки чувствительности**

Каждый [SensitivityLabel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/) содержит следующие метаданные:

| Методы | Назначение |
| --- | --- |
| [getId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getId) и [setId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#setId) | Получить или задать идентификатор метки чувствительности в политике Purview. |
| [getSiteId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getSiteId) и [setSiteId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Получить или задать сайт, связанный с политикой метки. |
| [isEnabled](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#isEnabled) и [setEnabled](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Получить или задать, включена ли метка. |
| [isRemoved](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#isRemoved) и [setRemoved](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Получить или задать, удалена ли метка. Установите значение `True`, когда состояние удаления должно сохраняться в метаданных. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) и [setAssignmentMethodType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Получить или задать, была ли метка применена автоматически или через решение пользователя. |
| [getContentMarkTypes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Получить типы маркировки содержимого, связанные с меткой. |

Класс [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelassignmenttype/) определяет, как была назначена метка:

- [Standard](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelassignmenttype/) представляет метку по умолчанию или применённую автоматически.
- [Privileged](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую решением пользователя, включая вручную применённые, рекомендованные и обязательные метки.

Класс [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcontenttype/) определяет маркировку, связанную с меткой:

| Значение | Описание |
| --- | --- |
| [None](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcontenttype/) | Метка применена по умолчанию или автоматически. |
| [Header](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого заголовка связана с меткой. |
| [Footer](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого нижнего колонтитула связана с меткой. |
| [Watermark](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого водяного знака связана с меткой. |
| [Encryption](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcontenttype/) | Защита шифрованием связана с меткой. |

Один метке могут соответствовать несколько типов маркировки.

## **Список существующих меток чувствительности**

Прочитайте современную коллекцию меток через [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSensitivityLabels) и перечислите её. Следующий пример выводит каждое свойство и маркировку содержимого, хранящиеся для каждой метки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Добавление метки чувствительности с маркировкой содержимого**

Используйте [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/#add) с идентификатором метки, идентификатором сайта, состоянием включения и методом назначения. После того как метод вернёт новый [SensitivityLabel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/), добавьте требуемые значения маркировки через список, возвращаемый [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Следующий пример добавляет вручную выбранную метку, связанную с маркировкой нижнего колонтитула и водяного знака, а затем сохраняет результат как PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Обновление метки чувствительности**

Значения [SensitivityLabel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/) доступны для чтения и записи, за исключением списка, возвращаемого [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), который изменяется через операции со списком. После нахождения нужной метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, метод назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

Следующий пример обновляет состояние включения и метод назначения первой метки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Пометка метки чувствительности как удалённой**

Чтобы сохранить факт удаления метки, найдите её и вызовите [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#setRemoved) со значением `True`. Это сохраняет запись метки, отмечая её как удалённую. Если вместо этого нужно полностью удалить запись из современной коллекции, используйте [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); для удаления всех записей примените [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/#clear).

Следующий пример помечает конкретную метку как удалённую и сохраняет обновлённую презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Чтение и миграция устаревших меток чувствительности MIP**

Старые рабочие процессы на основе MIP могут сохранять метаданные меток чувствительности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Метод анализирует устаревшие пользовательские свойства и возвращает массив объектов [SensitivityLabel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/).

Чтобы мигрировать метаданные, добавьте каждую полученную метку в современную [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/) через [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/#add). Поскольку добавление дублирующего идентификатора метки вызывает исключение, пример проверяет целевую коллекцию перед копированием каждой метки. Вы можете добавить дополнительную проверку, чтобы убедиться, что каждая устаревшая метка всё ещё присутствует в текущей политике Purview.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Миграция копирует разобранные объекты меток в современную коллекцию. Это не требует очистки всех пользовательских свойств документа, поэтому несвязанные метаданные документа остаются нетронутыми. Используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/) для записи современных метаданных меток в файл PPTX.

## **FAQ**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавленные через список, возвращаемый [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), описывают маркировку, связанную с меткой чувствительности. Они не создают видимый текст или фигуры в презентации. При необходимости отобразить эти маркировки добавьте соответствующий контент слайдов отдельно.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Вызов [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#setRemoved) со значением `True` сохраняет запись метки и фиксирует её состояние как удалённое. Вызов [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) полностью удаляет запись из современной коллекции. Выберите операцию, соответствующую требованиям вашей организации по хранению метаданных.

**Может ли презентация содержать одновременно устаревшие метаданные MIP и современные метки чувствительности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, тогда как современные метки доступны через [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSensitivityLabels). Используйте [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getSensitivityLabels) для чтения устаревших метаданных и мигрируйте только те метки, которые ещё не присутствуют в современной коллекции.

**Что происходит, если одна и та же метка добавляется несколько раз?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabelcollection/#add) генерирует исключение, если в коллекции уже содержится метка с таким же идентификатором. Проверьте существующие значения, возвращаемые [SensitivityLabel.getId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sensitivitylabel/#getId), перед добавлением или миграцией меток.

**Какой формат вывода следует использовать для сохранения обновлённых меток чувствительности?**

Сохраните презентацию в формате PPTX, вызвав [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/), как показано в примерах выше.