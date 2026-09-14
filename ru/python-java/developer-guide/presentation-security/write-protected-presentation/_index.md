---
title: Защита от записи презентаций в Python
linktitle: Защита от записи
type: docs
weight: 25
url: /ru/python-java/write-protected-presentation/
keywords:
- защита от записи
- защита от записи PowerPoint
- пароль для изменения
- ограничить редактирование презентации
- удалить защиту от записи
- проверить пароль изменения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Устанавливайте, обнаруживайте, проверяйте и удаляйте пароли защиты от записи в презентациях PowerPoint PPT и PPTX с помощью Aspose.Slides для Python через Java."
---
## **Введение**

Пароль защиты от записи ограничивает изменение презентации, но не шифрует её содержимое. Пользователи могут загрузить и просматривать презентацию с защитой от записи без пароля. В зависимости от приложения они также могут редактировать содержимое и сохранять его под другим именем, поэтому защита от записи не должна рассматриваться как механизм конфиденциальности.

Пароль открытия служит другой цели: он шифрует презентацию и требуется для загрузки её содержимого. Чтобы зашифровать презентацию или проверить пароль открытия, см. [Password-Protect Presentations](/slides/ru/python-java/password-protected-presentation/).

Рабочие процессы в этой статье применимы как к презентациям PPT, так и PPTX. Примеры используют файлы PPTX; при сохранении в PPT используйте расширение `.ppt` и соответствующий формат сохранения PPT.

## **Установить защиту от записи для презентации**

Используйте [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#setWriteProtection) для назначения пароля, ограничивающего изменение презентации. Сохранение презентации сохраняет настройку защиты.

Следующий пример устанавливает защиту от записи для презентации PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Загрузить презентацию с защитой от записи**

Поскольку защита от записи не шифрует содержимое презентации, пароль не требуется для её загрузки. Пароль нужен только при проверке разрешения на изменение защищённой презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Не передавайте пароль защиты от записи в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setPassword). Этот метод принимает пароль открытия для зашифрованного содержимого. Если презентация имеет оба типа защиты, укажите пароль открытия для загрузки и обрабатывайте пароль защиты от записи отдельно.

## **Удалить защиту от записи у презентации**

Используйте [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#removeWriteProtection) для снятия ограничения изменения, затем сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Проверить, защищена ли презентация от записи**

Чтобы проанализировать файл без создания полного экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), вызовите [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) и проверьте [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#isWriteProtected). Метод использует [NullableBool](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/) и возвращает `NullableBool.True_`, когда обнаружена защита от записи.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Перегрузка потока метода [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) предоставляет ту же информацию для презентации, переданной как поток.

## **Проверка пароля защиты от записи**

Используйте [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#checkWriteProtection) для проверки пароля изменения без загрузки полной презентации. Сначала проверьте [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#isWriteProtected), чтобы приложение запрашивало или проверяло пароль только при наличии защиты от записи.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#checkWriteProtection) проверяет только пароль защиты от записи. Он не проверяет пароль открытия и не определяет, можно ли загрузить зашифрованное содержимое. Напротив, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#checkPassword) проверяет только пароль открытия. Если полная презентация уже загружена, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#checkWriteProtection) предоставляет эквивалентную проверку защиты от записи через менеджер защиты.

В производственных приложениях не записывайте пароли в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки и храните пароли в памяти только столько, сколько это необходимо.

{{% alert color="info" title="Смотрите также" %}}
- [Password-Protect Presentations](/slides/ru/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/ru/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Шифрует ли защита от записи презентацию?**

Нет. Она ограничивает изменение, но оставляет содержимое презентации доступным для загрузки и просмотра.

**Требуется ли пароль защиты от записи для открытия презентации?**

Нет. Для загрузки зашифрованного содержимого требуется только пароль открытия.

**Может ли презентация иметь одновременно пароль открытия и пароль защиты от записи?**

Да. Укажите пароль открытия через параметры загрузки, чтобы открыть зашифрованную презентацию, и проверяйте пароль защиты от записи отдельно, когда требуется авторизация на изменение.