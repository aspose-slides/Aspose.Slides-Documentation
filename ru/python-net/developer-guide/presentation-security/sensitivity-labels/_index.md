---
title: Управление метками чувствительности в презентациях PowerPoint на Python
linktitle: Метки чувствительности
type: docs
weight: 50
url: /ru/python-net/sensitivity-labels/
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
description: "Чтение, добавление, обновление, удаление и миграция меток чувствительности Microsoft Purview в презентациях PowerPoint PPTX с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Microsoft Purview sensitivity labels помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложение может потребовать сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides for Python via .NET предоставляет современные метаданные меток чувствительности через [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/sensitivity_labels/). Это свойство возвращает [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/), которую можно просматривать и изменять перед сохранением презентации в формате PPTX.

{{% alert color="primary" title="Note" %}}
Идентификаторы меток чувствительности и информация о политике определяются вашей конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в вашей среде перед добавлением или миграцией метаданных. Значения [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/content_mark_types/) описывают маркировки содержимого, связанные с меткой; они сами по себе не добавляют видимый текст или фигуры на слайды.
{{% /alert %}}

## **Понимание свойств метки чувствительности**

Каждый [SensitivityLabel](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/) содержит следующие метаданные:

| Свойство | Назначение |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/id/) | Идентифицирует метку чувствительности в политике Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/site_id/) | Идентифицирует сайт, связанный с политикой метки. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Указывает, включена ли метка. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/is_removed/) | Указывает, что метка была удалена. Установите это свойство в `True`, когда состояние удаления должно сохраняться в метаданных. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Определяет, была ли метка применена автоматически или по решению пользователя. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Перечисляет типы маркировки содержимого, связанные с меткой. |

Перечисление [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelassignmenttype/) описывает, как была назначена метка:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelassignmenttype/) представляет метку по умолчанию или применённую автоматически.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую по решению пользователя, включая вручную применённые, рекомендованные и обязательные метки.

Перечисление [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcontenttype/) определяет маркировку, связанную с меткой:

| Значение | Значение |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcontenttype/) | Метка применена по умолчанию или автоматически. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка заголовка. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка нижнего колонтитула. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка водяного знака. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана защита шифрованием. |

Один метке могут быть сопоставлены несколько типов маркировки.

## **Список существующих меток чувствительности**

Прочитайте современную коллекцию меток из [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/sensitivity_labels/) и пройдите её. Пример ниже перечисляет каждое свойство и маркировку содержимого, сохранённые для каждой метки:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Добавление метки чувствительности с маркировкой содержимого**

Используйте [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/add/) с идентификатором метки, идентификатором сайта, состоянием включения и способом назначения. Передайте идентификатор сайта как объект Python `uuid.UUID`. После возврата новой [SensitivityLabel](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/) добавьте требуемые значения маркировки в [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Пример ниже добавляет вручную выбранную метку, связанную с маркировкой нижнего колонтитула и водяного знака, а затем сохраняет результат в формате PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Обновление метки чувствительности**

Свойства [SensitivityLabel](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/) доступны для чтения и записи, за исключением списка, возвращаемого [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/content_mark_types/), который изменяется через операции списка. После нахождения нужной метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, способ назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

Пример ниже обновляет состояние включения и способ назначения первой метки:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Пометка метки чувствительности как удалённой**

Чтобы сохранить факт удаления метки, найдите её и установите [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/is_removed/) в `True`. Это сохраняет запись метки, фиксируя её удалённое состояние. Если вместо этого нужно полностью удалить запись из современной коллекции, используйте [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); для удаления всех записей примените [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/clear/).

Пример ниже помечает определённую метку как удалённую и сохраняет обновлённую презентацию:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Чтение и миграция устаревших меток MIP**

Старые рабочие процессы на основе MIP могут хранить метаданные меток чувствительности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Метод разбирает устаревшие пользовательские свойства и возвращает объекты [SensitivityLabel](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/).

Для миграции метаданных добавьте каждую полученную метку в современную [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/) через [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/add/). Поскольку добавление метки с дублирующим идентификатором вызывает исключение, пример проверяет целевую коллекцию перед копированием каждой метки. Вы можете добавить дополнительную проверку, чтобы убедиться, что каждая устаревшая метка всё ещё присутствует в текущей политике Purview.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

Миграция копирует разобранные объекты меток в современную коллекцию. Это не требует очистки всех пользовательских свойств документа, поэтому несвязанные метаданные документа остаются нетронутыми. Используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) с [SaveFormat.PPTX](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/) для записи современных метаданных меток в файл PPTX.

## **FAQ**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавленные через [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/content_mark_types/), описывают маркировки, связанные с меткой чувствительности. Они не создают видимый текст или фигуры в презентации. При необходимости отображения этих маркировок добавьте соответствующее содержимое слайда отдельно.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Установка [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/is_removed/) в `True` сохраняет запись метки и фиксирует её удалённое состояние. Вызов [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) удаляет запись из современной коллекции. Выберите операцию, соответствующую требованиям вашей организации к сохранению метаданных.

**Можно ли в презентации одновременно хранить устаревшие метаданные MIP и современные метки чувствительности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, тогда как современные метки доступны через [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/sensitivity_labels/). Используйте [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) для чтения устаревших метаданных и мигрируйте только те метки, которые ещё не присутствуют в современной коллекции.

**Что происходит, если метка с тем же идентификатором добавляется более одного раза?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabelcollection/add/) генерирует исключение, когда коллекция уже содержит метку с таким же идентификатором. Проверьте существующие значения [SensitivityLabel.id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sensitivitylabel/id/) перед добавлением или миграцией меток.

**Какой формат вывода следует использовать для сохранения обновлённых меток чувствительности?**

Сохраняйте презентацию в формате PPTX, вызывая [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) с [SaveFormat.PPTX](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/), как показано в примерах выше.