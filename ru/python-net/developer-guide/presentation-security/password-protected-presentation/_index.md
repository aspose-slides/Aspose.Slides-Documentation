---
title: Защита презентаций паролем в Python
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/python-net/password-protected-presentation/
keywords:
- презентация с паролем
- пароль доступа
- шифрование PowerPoint
- расшифровка PowerPoint
- проверка пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- Python
- Aspose.Slides
description: "Шифруйте, обнаруживайте, проверяйте, открывайте и расшифровывайте презентации PowerPoint PPT и PPTX, защищённые паролем, в Python с помощью Aspose.Slides."
---
## **Обзор**

Пароль доступа шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль доступа отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Write-Protect Presentations](/slides/ru/python-net/write-protected-presentation/).

Приведённые ниже рабочие процессы применимы как к презентациям PPT, так и PPTX. В примерах используются оба формата, где важны их поведение при работе с файлами и потоками.

## **Зашифровать презентацию паролем доступа**

Используйте [ProtectionManager.encrypt](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/encrypt/) для назначения пароля доступа. Затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) для сохранения зашифрованной презентации.

Следующий пример шифрует презентацию PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Сделать свойства документа общедоступными**

По умолчанию Aspose.Slides включает свойства документа в шифрование презентации. Свойство [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) управляет этим поведением независимо от шифрования содержимого слайдов. Установите его в `False` перед вызовом [ProtectionManager.encrypt](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/encrypt/), если система индексации, классификации, поиска или управления документами должна читать метаданные без пароля доступа.

Следующий пример создаёт зашифрованную презентацию PPTX, оставляя её встроенные свойства документа общедоступными:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Установка `encrypt_document_properties` в `False` не делает общедоступными слайды, шаблоны, макеты, фигуры, медиа‑файлы или другое содержимое презентации. Это влияет только на свойства документа. Чтобы прочитать эти свойства без загрузки зашифрованного содержимого, см. [Manage Presentation Properties](/slides/ru/python-net/presentation-properties/).

## **Загрузить зашифрованную презентацию**

Установите [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/) в пароль доступа и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) при загрузке файла. Загрузка завершится ошибкой, когда требуется пароль доступа, но предоставленный пароль отсутствует или неверен.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Работа с расшифрованной презентацией.
    pass
```

## **Удалить шифрование из презентации**

Загрузите презентацию с её паролем доступа, вызовите [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/remove_encryption/), и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверить пароль доступа перед загрузкой**

Используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) для получения [PresentationInfo](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/) без создания полного экземпляра презентации. Проверьте [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/is_password_protected/) перед запросом или проверкой пароля. Если защита присутствует, проверьте предоставленное значение с помощью [PresentationInfo.check_password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/check_password/).

### **Рабочий процесс с файловым путём**

Следующий пример проверяет пароль доступа для файла PPTX, передаёт подтверждённое значение в [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/), а затем загружает полную презентацию:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Рабочий процесс с потоками**

Перегрузка потока метода [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) предоставляет ту же последовательность действий. Сбросьте позицию seek‑able потока перед загрузкой полной презентации из этого потока.

Следующий пример использует файл PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Возвращаемые значения CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/check_password/) возвращает `True` только тогда, когда у презентации установлен пароль доступа и предоставленный пароль верен. Он возвращает `False` в каждом из этих случаев:

- Пароль неверен.
- У презентации нет пароля доступа.
- Предоставленный пароль `None` или пустой.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверить, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/is_encrypted/), чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем доступа до загрузки, используйте `PresentationInfo.is_password_protected`, как показано выше.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Рекомендации по безопасности**

{{% alert color="warning" title="Security" %}}
Не записывайте пароли доступа в журналы и не включайте их в диагностические сообщения. Избегайте лишних повторных попыток проверки, храните пароли в памяти только столько, сколько необходимо, и переиспользуйте успешный результат проверки при немедленной загрузке презентации.

Общие свойства документа могут раскрывать имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения, даже если содержимое презентации зашифровано. Шифруйте чувствительные метаданные вместе с презентацией. Оставление свойств общедоступными должно быть осознанным решением, принимаемым только тогда, когда системы обязаны индексировать, классифицировать, искать или управлять файлом без пароля доступа.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
1. Выберите или загрузите презентацию.
1. Введите пароль для защиты просмотра.
1. При необходимости введите отдельный пароль для защиты редактирования.
1. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ru/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем доступа и паролем защиты от записи?**

Пароль доступа шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает возможность изменения без шифрования содержимого.

**Можно ли проверить пароль доступа без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем доступа и проверьте пароль перед созданием полного экземпляра презентации.

**Можно ли приложению прочитать метаданные без пароля доступа?**

Да, но только когда презентация была зашифрована с параметром `encrypt_document_properties`, установленным в `False`. Приложение должно использовать режим загрузки только свойств документа, описанный в [Manage Presentation Properties](/slides/ru/python-net/presentation-properties/).

**Поддерживают ли рабочие процессы проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по файловому пути и по потоку работают одинаково для презентаций PPT и PPTX.