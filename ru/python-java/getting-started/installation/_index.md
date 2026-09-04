---
title: Установка
type: docs
weight: 70
url: /ru/python-java/installation/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- установка Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Установите Aspose.Slides for Python via Java на Windows, Linux или macOS, настройте Java и JPype и проверьте настройки с работающим примером."
---
Aspose.Slides for Python via Java работает под Windows, Linux и macOS. Он использует JPype для доступа к Java‑библиотеке из Python. Microsoft PowerPoint не требуется.

## **Требования**

Перед установкой пакетов Python установите Python и JDK, соответствующие [System Requirements](/slides/ru/python-java/system-requirements/). На этой странице перечислены совместимые версии, требования к архитектуре и зависимости, необходимые для сборки JPype из исходного кода.

Установите переменную `JAVA_HOME` в каталог установки JDK, а не в его подкаталог `bin`, и добавьте каталог `bin` JDK в `PATH`. После изменения переменных среды откройте новый терминал.

## **Установить из PyPI**

Выполняйте приведённые команды в терминале, а не в интерактивной оболочке Python. Создайте каталог проекта и виртуальное окружение, чтобы изолировать пакеты от других проектов.

### **Windows**

При наличии выбранного интерпретатора Python, доступного как `python` в `PATH`, выполните следующие команды в командной строке:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux и macOS**

При наличии выбранной версии Python, доступной как `python3`, выполните следующие команды в Bash или zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

В Debian или Ubuntu, если создание окружения не удалось из‑за отсутствия `ensurepip`, установите пакет `python3-venv` с помощью `sudo apt-get install python3-venv`, затем повторите команду создания окружения. Отдельно установленная версия Python может потребовать соответствующий пакет `venv` для её версии.

### **Установить пакеты**

С активированным виртуальным окружением установите JPype и Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Использование `python -m pip` гарантирует установку пакетов для интерпретатора, которым запускается ваше приложение.

Чтобы обновить существующую установку Aspose.Slides, выполните `python -m pip install --upgrade aspose-slides-java` в том же окружении.

## **Установить из ZIP‑архива**

Библиотеку можно также использовать со [Страницы загрузок Aspose.Slides](https://releases.aspose.com/slides/ru/python-java/):

1. Установите Python и Java, как описано в разделе [Требования](#prerequisites).
2. Создайте и активируйте виртуальное окружение, следуя инструкциям выше.
3. Установите JPype командой `python -m pip install JPype1`.
4. Скачайте и распакуйте ZIP‑архив Aspose.Slides for Python via Java.
5. Найдите распакованный каталог пакета `asposeslides`. Сохраните его содержимое, включая каталог `lib` и JAR‑файл, вместе.
6. Поместите `example.py` из следующего раздела рядом с каталогом `asposeslides`, чтобы Python смог импортировать пакет.

## **Проверка установки**

Сохраните следующий код в файл `example.py`. Он создаёт презентацию с текстовым полем и сохраняет её как `out.pptx` в текущем рабочем каталоге.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

С активированным виртуальным окружением запустите пример из каталога, где находится `example.py`:

```sh
python example.py
```

Импорт `asposeslides` регистрирует включённую Java‑библиотеку до запуска JVM. Импортируйте `asposeslides.api` после запуска JVM и освобождайте ресурсы презентации перед её завершением.

{{% alert color="info" title="Примечание" %}}

Без лицензии в вывод добавляется водяной знак оценки. См. [Evaluate Aspose.Slides](/slides/ru/python-java/evaluate-aspose-slides/) для ограничений оценки и информации о временной лицензии.

{{% /alert %}}

## **FAQ**

**Почему Python сообщает, что JVM не найдено или не может быть загружено?**

Убедитесь, что `JAVA_HOME` указывает на JDK, совместимый с вашей установкой Python и JPype, как описано в [System Requirements](/slides/ru/python-java/system-requirements/). Дополнительные проверки см. в [руководстве по устранению проблем установки JPype](https://jpype.readthedocs.io/en/latest/install.html).

**Почему после установки Python сообщает, что `asposeslides` отсутствует?**

Пакет мог быть установлен для другого интерпретатора Python. Активируйте виртуальное окружение, использованное при установке, и выполните `python -m pip show aspose-slides-java`. При установке из ZIP‑архива убедитесь, что каталог `asposeslides` находится рядом со скриптом или доступен в пути поиска модулей Python.

**Можно ли выполнять пример многократно в ноутбуке?**

Пример предназначен для отдельного процесса Python. Прежде чем адаптировать его для повторного выполнения в ноутбуке, ознакомьтесь с разделом [Limitations and API Differences](/slides/ru/python-java/limitations-and-api-differences/#import-the-library) о жизненном цикле JVM и рекомендациями для ноутбуков.

**Почему pip завершается с ошибкой `CERTIFICATE_VERIFY_FAILED`?**

Если ваша сеть использует прокси с проверкой HTTPS, pip должен доверять его центру сертификации. Настройте доверенный набор сертификатов с помощью параметра `--cert` pip или переменной окружения `PIP_CERT`, следуя [инструкциям по сертификатам HTTPS для pip](https://pip.pypa.io/en/stable/topics/https-certificates/). Требуемая конфигурация зависит от вашей сети и версии pip.