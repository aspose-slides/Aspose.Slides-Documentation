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
description: "Установите Aspose.Slides for Python via Java на Windows, Linux или macOS, настройте Java и JPype и проверьте установку с помощью работающего примера."
---
Aspose.Slides for Python via Java работает на Windows, Linux и macOS. Он использует JPype для доступа к библиотеке Java из Python. Microsoft PowerPoint не требуется.

## **Требования**

Перед установкой пакетов Python установите Python и JDK, соответствующие [Системные требования](/slides/ru/python-java/system-requirements/). На этой странице перечислены совместимые версии, требования к архитектуре и любые зависимости, необходимые для сборки JPype из исходного кода.

Установите `JAVA_HOME` в каталог установки JDK, а не в его подпапку `bin`, и добавьте каталог `bin` JDK в `PATH`. Откройте новый терминал после изменения переменных окружения.

## **Установка из PyPI**

Запустите следующие команды в терминале, а не в интерактивной оболочке Python. Создайте каталог проекта и виртуальное окружение, чтобы изолировать пакеты от других проектов.

### **Windows**

При наличии выбранного интерпретатора Python, доступного как `python` в `PATH`, выполните следующие команды в Command Prompt:

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

В Debian или Ubuntu, если создание окружения не удалось из‑за отсутствия `ensurepip`, установите пакет `python3-venv` с помощью `sudo apt-get install python3-venv`, затем повторите команду создания окружения. Отдельно установленная версия Python может требовать соответствующий пакет `venv`, специфичный для её версии.

### **Установка пакетов**

С активированным виртуальным окружением установите JPype и Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Использование `python -m pip` гарантирует, что пакеты устанавливаются для интерпретатора, используемого для запуска вашего приложения.

Чтобы обновить существующую установку Aspose.Slides, выполните `python -m pip install --upgrade aspose-slides-java` в том же окружении.

## **Установка из ZIP‑архива**

Вы также можете использовать библиотеку со [страницы загрузок Aspose.Slides](https://releases.aspose.com/slides/ru/python-java/):

1. Установите Python и Java, как описано в [Требования](#prerequisites).
2. Создайте и активируйте виртуальное окружение, используя инструкции выше.
3. Установите JPype с помощью `python -m pip install JPype1`.
4. Скачайте и распакуйте ZIP‑архив Aspose.Slides for Python via Java.
5. Найдите извлечённый каталог пакета `asposeslides`. Сохраните его содержимое, включая каталог `lib` и файл JAR, вместе.
6. Разместите `example.py` из следующего раздела рядом с каталогом `asposeslides`, чтобы Python мог импортировать пакет. В архиве уже есть свой `example.py` рядом с `asposeslides`; замените его приведённым ниже.

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

С активированным виртуальным окружением запустите пример из каталога, содержащего `example.py`:

```sh
python example.py
```

Импорт `asposeslides` регистрирует встроенную библиотеку Java до запуска JVM. Импортируйте `asposeslides.api` после запуска JVM и освободите ресурсы презентации перед её завершением.

{{% alert color="info" title="Note" %}}
Без лицензии вывод будет содержать водяной знак оценки. Смотрите [инструкций по HTTPS‑сертификатам pip](https://pip.pypa.io/en/stable/topics/https-certificates/) для ограничений оценки и информации о временной лицензии.
{{% /alert %}}

## **FAQ**

**Почему Python сообщает, что JVM не найден или не может быть загружен?**

Убедитесь, что `JAVA_HOME` указывает на JDK, совместимый с вашей установкой Python и JPype, как описано в [System Requirements](/slides/ru/python-java/system-requirements/). Смотрите [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) для дополнительных проверок.

**Почему Python сообщает, что `asposeslides` отсутствует после установки?**

Пакет мог быть установлен для другого интерпретатора Python. Активируйте виртуальное окружение, используемое при установке, и выполните `python -m pip show aspose-slides-java`. При установке из ZIP убедитесь, что каталог `asposeslides` находится рядом со скриптом или иначе доступен в пути поиска модулей Python.

**Можно ли запускать пример многократно в ноутбуке?**

Пример предназначен для отдельного процесса Python. Прежде чем адаптировать его для многократного выполнения в ноутбуке, ознакомьтесь с [Limitations and API Differences](/slides/ru/python-java/limitations-and-api-differences/#import-the-library) относительно жизненного цикла JVM и рекомендаций для ноутбуков.

**Почему pip завершается с ошибкой `CERTIFICATE_VERIFY_FAILED`?**

Если ваша сеть использует прокси для проверки HTTPS, pip должен доверять его удостоверяющему центру. Настройте доверенный набор сертификатов с помощью опции `--cert` pip или переменной окружения `PIP_CERT`, следуя [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). Необходимая конфигурация зависит от вашей сети и версии pip.