---
title: Парольная защита презентаций в Python
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/python-java/password-protected-presentation/
keywords:
- презентация с паролем
- пароль открытия
- зашифровать PowerPoint
- расшифровать PowerPoint
- проверить пароль презентации
- проверить пароль презентации
- открыть зашифрованную презентацию
- удалить шифрование
- PowerPoint
- PPT
- PPTX
- презентация
- Python
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и расшифровка презентаций PowerPoint PPT и PPTX, защищённых паролем, с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Пароль открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Для управления паролями при изменении презентаций см. [Write-Protect Presentations](/slides/ru/python-java/write-protected-presentation/).

Ниже представленные рабочие процессы применимы как к PPT, так и к PPTX презентациям. Примеры используют оба формата, где важно их поведение при работе с файлами и потоками.

## **Шифрование презентации с паролем открытия**

Используйте [ProtectionManager.encrypt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#encrypt) для назначения пароля открытия. Затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для сохранения зашифрованной презентации.

В следующем примере шифруется PPTX презентация:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Оставить свойства документа общедоступными**

По умолчанию Aspose.Slides включает свойства документа в шифрование презентации. Метод [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) управляет этим поведением независимо от шифрования содержимого слайдов. Перед вызовом [ProtectionManager.encrypt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#encrypt) передайте `False`, если система индексации, классификации, поиска или управления документами должна читать метаданные без пароля открытия.

В следующем примере создаётся зашифрованная PPTX презентация, при этом встроенные свойства документа остаются общедоступными:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Передача `False` в [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) не делает слайды, шаблоны, макеты, фигуры, медиа‑файлы или другое содержимое презентации общедоступными. Это влияет только на свойства документа. Чтобы прочитать эти свойства без загрузки зашифрованного содержимого, см. [Manage Presentation Properties](/slides/ru/python-java/presentation-properties/).

## **Загрузка зашифрованной презентации**

Установите [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setPassword) в значение пароля открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) при загрузке файла. Загрузка завершается ошибкой, если требуется пароль открытия, но предоставленный пароль отсутствует или неверен.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Работайте с расшифрованной презентацией.
    pass
finally:
    presentation.dispose()
```

## **Удаление шифрования из презентации**

Загрузите презентацию с её паролем открытия, вызовите [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#removeEncryption) и сохраните результат. Сохранённую презентацию затем можно загружать без пароля.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Проверка пароля открытия перед загрузкой**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) для получения [PresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/) без создания полноценного экземпляра презентации. Проверьте [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#isPasswordProtected) перед запросом или проверкой пароля. При наличии защиты проверьте предоставленное значение с помощью [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Рабочий процесс с путем к файлу**

В следующем примере проверяется пароль открытия для файла PPTX, проверенное значение передаётся в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setPassword), после чего загружается полная презентация:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Рабочий процесс с потоком**

Перегрузка потока метода [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) обеспечивает такой же рабочий процесс. Сбросьте позицию seekable‑потока перед загрузкой полной презентации из этого потока.

В следующем примере используется файл PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Значения, возвращаемые checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#checkPassword) возвращает `True` только когда у презентации установлен пароль открытия и предоставленный пароль правильный. Он возвращает `False` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля открытия.
- Переданный пароль равен `None` или пустой строке.

Поведение одинаково для PPT и PPTX презентаций.

## **Проверка, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#isEncrypted), чтобы убедиться, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#isPasswordProtected), как показано выше.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Рекомендации по безопасности**

{{% alert color="warning" title="Security" %}}
Не записывайте пароли открытия в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, храните пароли в памяти только столько, сколько требуется, и повторно используйте успешный результат проверки при немедленной загрузке презентации.

Общие свойства документа могут раскрывать имена авторов, названия, тематики, ключевые слова, информацию о компании, комментарии и пользовательские значения, даже если содержимое презентации зашифровано. Шифруйте конфиденциальные метаданные вместе с презентацией. Оставление свойств общедоступными должно быть явным решением, принимаемым только тогда, когда системы обязаны индексировать, классифицировать, искать или управлять файлом без пароля открытия.
{{% /alert %}}

## **Защита презентации паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
1. Выберите или загрузите презентацию.
1. Введите пароль для защиты просмотра.
1. При желании введите отдельный пароль для защиты редактирования.
1. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ru/python-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чем разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Могу ли я проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте, присутствует ли защита паролем открытия, и проверьте пароль до создания полного экземпляра презентации.

**Можно ли приложению читать метаданные без пароля открытия?**

Да, но только когда презентация была зашифрована с отключённым шифрованием свойств документа. В этом случае приложение должно использовать режим загрузки только свойств документа, описанный в [Manage Presentation Properties](/slides/ru/python-java/presentation-properties/).

**Поддерживают ли сценарии проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку работают одинаково для PPT и PPTX презентаций.