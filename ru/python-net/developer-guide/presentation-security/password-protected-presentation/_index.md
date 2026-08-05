---
title: Защита презентаций паролем с помощью Python
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/python-net/password-protected-presentation/
keywords:
- заблокировать PowerPoint
- заблокировать презентацию
- разблокировать PowerPoint
- разблокировать презентацию
- защитить PowerPoint
- защитить презентацию
- задать пароль
- добавить пароль
- зашифровать PowerPoint
- зашифровать презентацию
- расшифровать PowerPoint
- расшифровать презентацию
- защита от записи
- безопасность PowerPoint
- безопасность презентации
- удалить пароль
- снять защиту
- удалить шифрование
- отключить пароль
- отключить защиту
- снять защиту от записи
- презентация PowerPoint
- Python
- Aspose.Slides
description: "Узнайте, как легко блокировать и разблокировать презентации PowerPoint и OpenDocument, защищённые паролем, с помощью Aspose.Slides для Python через .NET. Повышайте продуктивность и защищайте свои презентации с нашим пошаговым руководством."
---
## **Введение**

Когда вы защищаете презентацию паролем, вы устанавливаете пароль, который налагает определённые ограничения на презентацию. Чтобы снять ограничения, необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной презентацией.

Типично вы можете установить пароль, чтобы наложить эти ограничения на презентацию:

- **Изменение**

  Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на изменение. Это ограничение не позволяет людям изменять, менять или копировать элементы вашей презентации (если они не предоставят пароль).

  Однако, в этом случае, даже без пароля пользователь сможет получить доступ к вашему документу и открыть его. В режиме только для чтения пользователь может просматривать содержимое, включая гиперссылки, анимацию, эффекты и другие элементы внутри презентации, но не может копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определённые пользователи могли открыть вашу презентацию, вы можете установить ограничение на открытие. Это ограничение не позволяет людям даже просматривать содержимое вашей презентации (если они не предоставят пароль).

  Технически ограничение на открытие также препятствует пользователям изменять ваши презентации: когда люди не могут открыть презентацию, они не могут вносить изменения.

  **Примечание** что когда вы защищаете презентацию паролем чтобы запретить её открытие, файл презентации шифруется.

## Как защитить презентацию паролем онлайн

1. Перейдите на страницу [**Aspose.Slides Lock**](https://products.aspose.app/slides/ru/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Перетащите или загрузите файлы**.

3. Выберите файл, который вы хотите защитить паролем, на вашем компьютере.

4. Введите желаемый пароль для защиты от редактирования; введите желаемый пароль для защиты от просмотра.

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, поставьте галочку **Mark as final**.

6. Нажмите **PROTECT NOW.**

7. Нажмите **DOWNLOAD NOW.**

## **Защита паролем презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций в следующих форматах:

- PPTX и PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для презентаций, чтобы предотвратить изменения следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Удаление защиты от записи у презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, установив пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен предоставить пароль.

Для шифрования или защиты паролем презентации необходимо использовать метод `encrypt` (из [ProtectionManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/)) для установки пароля презентации. Вы передаёте пароль в метод `encrypt` и используете метод `save`, чтобы сохранить теперь зашифрованную презентацию.

Этот пример кода показывает, как зашифровать презентацию:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка защиты от записи для презентации**

Вы можете добавить отметку «Do not modify» к презентации. Таким образом вы сообщаете пользователям, что не хотите, чтобы они вносили изменения в презентацию.

**Примечание** что процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если они действительно захотят — могут изменять презентацию, но чтобы сохранить изменения, им придётся создать презентацию с другим именем.

Для установки защиты от записи необходимо использовать метод `setWriteProtection`. Этот пример кода показывает, как установить защиту от записи для презентации:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Расшифровка презентации; Открытие зашифрованной презентации**

Aspose.Slides позволяет загрузить зашифрованный файл, передав его пароль. Чтобы расшифровать презентацию, необходимо вызвать метод [remove_encryption](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/) без параметров. Затем вам придётся ввести правильный пароль для загрузки презентации.

Этот пример кода показывает, как расшифровать презентацию:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Удаление шифрования; Отключение защиты паролем**

Вы можете удалить шифрование или защиту паролем с презентации. Таким образом пользователи смогут получить доступ к презентации или изменять её без ограничений.

Чтобы удалить шифрование или защиту паролем, необходимо вызвать метод [remove_encryption](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/). Этот пример кода показывает, как удалить шифрование из презентации:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Удаление защиты от записи у презентации**

Вы можете использовать Aspose.Slides для удаления защиты от записи, применённой к файлу презентации. Таким образом пользователи могут изменять её как захотят — и они не получают предупреждений при выполнении таких действий.

Вы можете удалить защиту от записи у презентации, используя метод [remove_write_protection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/). Этот пример кода показывает, как удалить защиту от записи у презентации:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Получение свойств зашифрованной презентации**

Обычно пользователи сталкиваются с проблемой получения свойств документа зашифрованной или защищённой паролем презентации. Однако Aspose.Slides предлагает механизм, позволяющий защитить презентацию паролем, оставаясь при этом способным предоставить пользователям доступ к её свойствам.

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства её документа также защищаются паролем. Если необходимо, чтобы свойства документа оставались доступными даже после шифрования, Aspose.Slides позволяет сделать именно это.

Если вы хотите, чтобы пользователи сохраняли возможность доступа к свойствам зашифрованной презентации, установите свойство `encrypt_document_properties` объекта [ProtectionManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/) в `False`. Этот пример кода показывает, как зашифровать презентацию, одновременно предоставляя пользователям доступ к её свойствам документа:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Загрузка только свойств документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов или другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/) и установите [only_load_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/only_load_document_properties/) в `True`. В этом режиме Aspose.Slides игнорирует пароль и загружает только публично доступные свойства документа.

Следующий пример кода читает встроенные свойства документа и перечисляет пользовательские свойства через [Presentation.document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Чтение встроенных свойств документа.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Список пользовательских свойств документа.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Этот рабочий процесс работает только тогда, когда свойства документа были оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, установка `only_load_document_properties` в `True` вызывает исключение, потому что пароль игнорируется в этом режиме. Чтобы получить доступ к зашифрованным свойствам документа или загрузить полную презентацию, включая её слайды и другое содержимое, укажите правильное значение `password` в [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/).

## **Проверка, защищена ли презентация паролем перед её загрузкой**

Прежде чем загружать презентацию, возможно, вы захотите проверить и убедиться, что презентация не защищена паролем. Это позволяет избежать ошибок и аналогичных проблем, которые возникают, когда защищённая паролем презентация загружается без пароля.

Этот код Python показывает, как проверить презентацию на наличие пароля (без загрузки самой презентации):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для выполнения этой задачи вы можете использовать свойство [is_encrypted](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/), которое возвращает `True`, если презентация зашифрована, и `False`, если не зашифрована.

Этот пример кода показывает, как проверить, зашифрована ли презентация:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для выполнения этой задачи вы можете использовать свойство [is_write_protected](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/), которое возвращает `True`, если презентация зашифрована, и `False`, если не зашифрована.

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Проверка или подтверждение, что конкретный пароль был использован для защиты презентации**

Возможно, вам потребуется проверить и подтвердить, что конкретный пароль был использован для защиты документа презентации. Aspose.Slides предоставляет средства для валидации пароля.

Этот пример кода показывает, как проверить пароль:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # проверка, совпадает ли пароль
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Он возвращает `True`, если презентация была зашифрована указанным паролем. В противном случае он возвращает `False`.

{{% alert color="primary" title="Смотрите также" %}} 
- [Цифровая подпись в PowerPoint](/slides/ru/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на основе AES, обеспечивая высокий уровень защиты данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию введён неверный пароль?**

Выбрасывается исключение, указывающее, что доступ к презентации отказан. Это помогает предотвратить неавторизованный доступ и защищает содержимое презентации.

**Есть ли какие‑либо последствия для производительности при работе с презентациями, защищёнными паролем?**

Процессы шифрования и дешифрования могут добавить небольшую нагрузку во время операций открытия и сохранения. В большинстве случаев влияние на производительность минимально и незначительно влияет на общее время обработки ваших задач с презентациями.