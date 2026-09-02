---
title: Защита от записи презентаций в Python
linktitle: Защита от записи
type: docs
weight: 25
url: /ru/python-net/write-protected-presentation/
keywords:
- защита от записи
- защита PowerPoint от записи
- пароль для изменения
- ограничить редактирование презентации
- удалить защиту от записи
- проверка пароля изменения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Установите, обнаружьте, проверьте и удалите пароли защиты от записи в презентациях PowerPoint PPT и PPTX с помощью Aspose.Slides для Python."
---
## **Введение**

Пароль защиты от записи ограничивает изменение презентации, но не шифрует её содержимое. Пользователи могут загрузить и просмотреть презентацию с защитой от записи без пароля. В зависимости от приложения они также могут редактировать содержимое и сохранять его под другим именем, поэтому защита от записи не должна рассматриваться как механизм конфиденциальности.

Пароль открытия служит другой цели: он шифрует презентацию и требуется для загрузки её содержимого. Чтобы зашифровать презентацию или проверить пароль открытия, см. [Защита паролем презентаций](/slides/ru/python-net/password-protected-presentation/).

Рабочие процессы в этой статье применимы как к презентациям PPT, так и PPTX. Примеры используют файлы PPTX; при сохранении в PPT используйте расширение `.ppt` и соответствующий формат сохранения PPT.

## **Установка защиты от записи в презентации**

Используйте [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/set_write_protection/) для назначения пароля, позволяющего изменять презентацию. Сохранение презентации сохраняет настройку защиты.

Следующий пример устанавливает защиту от записи в презентации PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Загрузка презентации с защитой от записи**

Поскольку защита от записи не шифрует содержимое презентации, пароль не требуется для её загрузки. Пароль имеет значение только при проверке прав на изменение защищённой презентации.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Не передавайте пароль защиты от записи в [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/). Это свойство принимает пароль открытия для зашифрованного содержимого. Если у презентации оба типа защиты, передайте пароль открытия для её загрузки и обрабатывайте пароль защиты от записи отдельно.

## **Удаление защиты от записи из презентации**

Используйте [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/remove_write_protection/) для снятия ограничения изменения, затем сохраните презентацию.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверка, защищена ли презентация от записи**

Чтобы исследовать файл без создания полного экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), вызовите [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) и проверьте [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/is_write_protected/). Свойство использует [NullableBool](https://reference.aspose.com/slides/ru/python-net/aspose.slides/nullablebool/) и возвращает `NullableBool.TRUE`, когда обнаружена защита от записи.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Перегрузка метода с параметром поток в [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) предоставляет ту же информацию для презентации, переданной в виде потока.

## **Проверка пароля защиты от записи**

Используйте [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/check_write_protection/) для проверки пароля изменения без загрузки полной презентации. Сначала проверьте [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/is_write_protected/), чтобы приложение запрашивало или проверяло пароль только при наличии защиты от записи.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/check_write_protection/) проверяет только пароль защиты от записи. Он не проверяет пароль открытия и не определяет, может ли быть загружено зашифрованное содержимое. Наоборот, [PresentationInfo.check_password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/check_password/) проверяет только пароль открытия. Если полная презентация уже загружена, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/check_write_protection/) предоставляет эквивалентную проверку защиты от записи через менеджер защиты.

В производственных приложениях не сохраняйте пароли в журналах и не включайте их в диагностические сообщения. Избегайте лишних повторных попыток проверки и храните пароли в памяти только столько времени, сколько необходимо.

{{% alert color="info" title="См. также" %}}
- [Защита паролем презентаций](/slides/ru/python-net/password-protected-presentation/)
- [Презентации только для чтения](/slides/ru/python-net/read-only-presentation/)
- [Цифровая подпись в PowerPoint](/slides/ru/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Шифрует ли защита от записи презентацию?**  
Нет. Она ограничивает изменение, но оставляет содержимое презентации доступным для загрузки и просмотра.

**Требуется ли пароль защиты от записи для открытия презентации?**  
Нет. Для загрузки зашифрованного содержимого презентации требуется только пароль открытия.

**Может ли презентация иметь одновременно пароль открытия и пароль защиты от записи?**  
Да. Передайте пароль открытия через параметры загрузки, чтобы открыть зашифрованную презентацию, и проверяйте пароль защиты от записи отдельно, когда требуется авторизация на изменение.