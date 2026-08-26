---
title: Защита презентаций паролем в Python
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/python-net/password-protected-presentation/
keywords:
- презентация с паролем
- открывающий пароль
- шифрование PowerPoint
- дешифрование PowerPoint
- валидация пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- Python
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и дешифрование презентаций PowerPoint PPT и PPTX, защищённых паролем, в Python с помощью Aspose.Slides."
---
## **Обзор**

Открывающий пароль шифрует презентацию. Правильный пароль необходим для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Открывающий пароль отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Защита презентаций от записи](/slides/ru/python-net/write-protected-presentation/).

Приведённые ниже рабочие процессы применимы как к презентациям PPT, так и PPTX. В примерах используются оба формата, когда важно их файловое и потоковое поведение.

## **Шифрование презентации открывающим паролем**

Используйте [ProtectionManager.encrypt](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/encrypt/) для назначения открывающего пароля. Затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) для сохранения зашифрованной презентации.

Следующий пример шифрует презентацию PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Загрузка зашифрованной презентации**

Установите [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/) в открывающий пароль и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) при загрузке файла. Загрузка завершится ошибкой, если требуется открывающий пароль, а предоставленный пароль отсутствует или неверен.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Работа с расшифрованной презентацией.
    pass
```

## **Удаление шифрования из презентации**

Загрузите презентацию с её открывающим паролем, вызовите [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/remove_encryption/), и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверка открывающего пароля перед загрузкой**

Используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) для получения [PresentationInfo](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/) без создания полного экземпляра презентации. Проверьте [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/is_password_protected/) перед запросом или проверкой пароля. Когда защита присутствует, проверьте предоставленное значение с помощью [PresentationInfo.check_password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/check_password/).

### **Рабочий процесс с указанием пути к файлу**

Следующий пример проверяет открывающий пароль для файла PPTX, передаёт проверенное значение в [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/), а затем загружает полную презентацию:

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

### **Рабочий процесс с потоком**

Перегрузка потока метода [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) обеспечивает тот же рабочий процесс. Сбросьте позицию ищущегося потока перед загрузкой полной презентации из этого потока.

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

[PresentationInfo.check_password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/check_password/) возвращает `True` только когда у презентации есть открывающий пароль и предоставленный пароль верен. Он возвращает `False` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет открывающего пароля.
- Предоставленный пароль равен `None` или пустой строке.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверка, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/is_encrypted/) для подтверждения, что исходная презентация была зашифрована. Чтобы обнаружить защиту открывающим паролем до загрузки, используйте `PresentationInfo.is_password_protected`, как показано выше.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Рекомендации по безопасности**

{{% alert color="warning" title="Безопасность" %}}
Не записывайте открывающие пароли в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, храните пароли в памяти только столько, сколько требуется, и переиспользуйте результат успешной проверки при немедленной загрузке презентации.
{{% /alert %}}

## **Защита презентации паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
2. Выберите или загрузите презентацию.
3. Введите пароль для защиты просмотра.
4. При желании введите отдельный пароль для защиты редактирования.
5. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="См. также" %}}
- [Защита презентаций от записи](/slides/ru/python-net/write-protected-presentation/)
- [Электронная подпись в PowerPoint](/slides/ru/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между открывающим паролем и паролем защиты от записи?**

Открывающий пароль шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменения без шифрования содержимого.

**Можно ли проверить открывающий пароль без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты открывающим паролем и проверьте пароль перед созданием полного экземпляра презентации.

**Поддерживают ли рабочие процессы проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку ведут себя одинаково для презентаций PPT и PPTX.