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
- метерное лицензирование
- ограничения оценки
description: "Примените файловую, байтовую или метерную лицензию в Aspose.Slides for Python via Java и устраните ограничения оценки в ваших приложениях."
---
## **Обзор**

Aspose.Slides for Python via Java может работать в режиме оценки или с лицензией. В этой статье объясняется, как применить лицензию из файла или байтов и как настроить метерное лицензирование.

Для вариантов покупки ознакомьтесь с [Информацией о ценах](https://purchase.aspose.com/pricing/slides/ru/family). Для общих вопросов о лицензировании и покупке см. [Политика покупок и FAQ](https://purchase.aspose.com/policies).

Для ограничений оценки и способов запросить временную лицензию см. [Оценка Aspose.Slides](/slides/ru/python-java/evaluate-aspose-slides/). Применяйте временную лицензию так же, как файл приобретённой лицензии.

## **О лицензии**

Файл лицензии содержит информацию, такую как название продукта, количество лицензированных разработчиков и дату истечения подписки. Файл представляет собой цифрово подписанный XML.

{{% alert color="warning" title="Предупреждение" %}}
Не изменяйте файл лицензии. Даже дополнительный разрыв строки может аннулировать его цифровую подпись.
{{% /alert %}}

Применяйте лицензию один раз за приложение или процесс, до создания презентаций или выполнения других операций Aspose.Slides. Для файла лицензии используйте класс [License](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/). Метерное лицензирование использует пару открытого и закрытого ключей вместо файла лицензии.

## **Применение лицензии**

В следующих примерах предполагается, что Aspose.Slides for Python via Java и его зависимости установлены. Каждый пример представляет собой отдельный скрипт, который запускает JVM, импортирует API и применяет лицензию. В вашем приложении выполняйте операции с презентациями после применения лицензии и завершайте работу JVM только после окончательной обработки всех задач Aspose.Slides.

### **Применение лицензии из файла**

Передайте путь к файлу лицензии в метод [License.setLicense](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/#setLicense). Замените `Aspose.Slides.lic` на путь к вашему файлу лицензии.

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

Используйте точное имя файла, включая расширение. Например, если файл называется `Aspose.Slides.lic.xml`, включите `.xml` в путь. Абсолютный путь устраняет неоднозначность относительно рабочей директории приложения.

В примере используется метод [License.isLicensed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/#isLicensed) для проверки, была ли применена лицензия.

### **Применение лицензии из байтов**

Используйте [License.setLicenseFromBytes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/license/#setLicenseFromBytes), когда лицензия доступна в виде байтов Python. В следующем примере файл читается в бинарном режиме и закрывается перед применением лицензии.

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

Сохраните оригинальные байты без изменений. Не декодируйте, не переформатируйте и не изменяйте содержимое лицензии перед её применением.

## **Применение метерной лицензии**

Метерное лицензирование выставляет счёт в зависимости от использования API. После получения метерной лицензии примените её открытый и закрытый ключи с помощью [Metered.setMeteredKey](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/#setMeteredKey). Инициализируйте объект [Metered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/) и примените ключи один раз при запуске приложения.

В следующем примере ключи читаются из переменных окружения `ASPOSE_METERED_PUBLIC_KEY` и `ASPOSE_METERED_PRIVATE_KEY`. Установите обе переменные перед запуском скрипта.

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

{{% alert color="info" title="Примечание" %}}
Метерное лицензирование требует подключения к Интернету для проверки ключей и отправки данных об использовании. Держите закрытый ключ вне исходного кода и журналов. Смотрите [FAQ по метерному лицензированию](https://purchase.aspose.com/faqs/licensing/metered) для получения информации о подключении и оплате.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Нужно ли устанавливать другой пакет после покупки лицензии?**

Нет. Применяйте лицензию к тому же пакету, который вы использовали для оценки.

**Нужно ли применять лицензию для каждой презентации?**

Нет. Применяйте её один раз при запуске приложения, до создания или загрузки презентаций.

**Можно ли переименовать файл лицензии?**

Да. Укажите точное новое имя файла в коде и не изменяйте содержимое файла.

**Можно ли использовать временную лицензию с примером на основе байтов?**

Да. Считайте временный файл лицензии как байты и примените его так же, как приобретённую лицензию.