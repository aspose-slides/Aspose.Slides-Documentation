---
title: Лицензирование
type: docs
weight: 80
url: /ru/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- файл лицензии
- временная лицензия
- метрическое лицензирование
- ограничения оценки
description: "Применяйте файловую, байтовую или метрическую лицензию в Aspose.Slides for Python via Java и удаляйте ограничения оценки из ваших приложений."
---
## **Обзор**

Aspose.Slides for Python via Java может работать в режиме оценки или с лицензией. В режиме оценки он добавляет текстовое поле с водяным знаком оценки на каждый слайд каждой сохраняемой презентации и обрезает текст, который ваш код читает из презентаций. Эта статья объясняет, как применить лицензию из файла или байтов и как настроить лицензирование с измерением.

Для вариантов покупки см. [Информация о ценах](https://purchase.aspose.com/pricing/slides/ru/family). Для общих вопросов о лицензировании и покупке см. [Политика покупок и FAQ](https://purchase.aspose.com/policies).

Для ограничений оценки и способа запроса временной лицензии см. [Оценка Aspose.Slides](/slides/ru/python-java/evaluate-aspose-slides/). Примените временную лицензию так же, как и файл приобретённой лицензии.

## **О лицензии**

Файл лицензии содержит информацию, такую как название продукта, количество лицензированных разработчиков и дату истечения подписки. Файл представляет собой подписанный цифровой XML.

{{% alert color="warning" title="Warning" %}}
Do not edit the license file. Even an extra line break can invalidate its digital signature.
{{% /alert %}}

Применяйте лицензию один раз за приложение или процесс, до создания презентаций или выполнения других операций Aspose.Slides. Для файла лицензии используйте класс [License](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/). Метроидное лицензирование использует пару публичного и приватного ключей вместо файла лицензии.

## **Применение лицензии**

The following examples assume that Aspose.Slides for Python via Java and its prerequisites are installed. Each example is a standalone script that starts the JVM, imports the API, and applies a license. In your application, perform your presentation operations after applying the license and shut down the JVM only after all Aspose.Slides work is complete.

### **Применение лицензии из файла**

Pass the license file path to [License.setLicense](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/#setLicense). Replace `Aspose.Slides.lic` with the path to your license file.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Выполняйте операции с презентацией здесь, перед завершением работы JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Use the exact file name, including its extension. For example, if the file is named `Aspose.Slides.lic.xml`, include `.xml` in the path. An absolute path avoids ambiguity about the application's working directory.

The example uses [License.isLicensed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/#isLicensed) to check whether the license has been applied.

### **Применение лицензии из байтов**

Use [License.setLicenseFromBytes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/#setLicenseFromBytes) when the license is available as Python bytes. The following example reads the file in binary mode and closes it before applying the license.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Выполняйте операции с презентацией здесь, перед завершением работы JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Keep the original bytes unchanged. Do not decode, reformat, or otherwise modify the license content before applying it.

## **Применение метрической лицензии**

Metered licensing bills you according to API usage. After obtaining a metered license, apply its public and private keys with [Metered.setMeteredKey](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/#setMeteredKey). Initialize the [Metered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/) object and apply the keys once at application startup.

The following example reads the keys from the `ASPOSE_METERED_PUBLIC_KEY` and `ASPOSE_METERED_PRIVATE_KEY` environment variables. Set both variables before running the script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Выполняйте операции с презентацией здесь, перед завершением работы JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Metered licensing requires an Internet connection to validate the keys and report usage. Keep the private key out of source code and logs. See the [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) for connectivity and billing details.
{{% /alert %}}

## **FAQ**

**Мне нужно установить другой пакет после покупки лицензии?**

Нет. Применяйте лицензию к тому же пакету, который использовали для оценки.

**Нужно ли применять лицензию к каждой презентации?**

Нет. Применяйте её один раз при запуске приложения, до создания или загрузки презентаций.

**Могу ли я переименовать файл лицензии?**

Да. Используйте точное новое имя файла в коде и оставьте содержимое файла без изменений.

**Могу ли я использовать временную лицензию с примером на основе байтов?**

Да. Читайте временный файл лицензии как байты и применяйте его так же, как и приобретённую лицензию.