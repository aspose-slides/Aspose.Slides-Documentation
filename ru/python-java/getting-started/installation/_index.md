---
title: Установка
type: docs
weight: 70
url: /ru/python-java/installation/
keySlides: "Скачайте Aspose.Slides, Установите Aspose.Slides, Установка Aspose.Slides, Windows, macOS, Linux, Python"
description: "Установите Aspose.Slides для Python через Java в Windows, Linux или macOS"
---

Aspose.Slides для Python через Java является независимым от платформы API и может использоваться на любой платформе (Windows, Linux и MacOS), где установлены `Python`, `Java` и мост `jpype1`.

## **Требования к программам и версиям**

Для обеспечения корректной работы Aspose.Slides для Python через Java должны быть установлены следующие программы и пакеты:

- JRE версии >=8 (JPype1 тестировался на версиях Java с 1.8 до 11).
- Python версии >=3.7, <=3.12.
- Версия пакета JPype1: >=1.5.0.

## **Установка через pip**

Вы можете легко установить Aspose.Slides для Python через Java из [pip](https://pypi.org/), если у вас установлены все необходимые программы (Java, Python).

Создайте новую папку проекта.

[Установите JPype1](https://jpype.readthedocs.io/en/latest/install.html) с помощью следующей команды:
```
$ pip install JPype1
```

Установите Aspose.Slides для Python через Java с помощью следующей команды:
```
$ pip install aspose-slides-java
```

## **Установка из ZIP-архива**

Чтобы установить и использовать Aspose.Slides для Python через Java из ZIP-архива, выполните следующие инструкции:

### **Windows**

1. Установите JDK8 и настройте переменную окружения `JAVA_HOME`.
2. [Установите Python](https://www.python.org/downloads/) версии >=3.7 и добавьте python.exe в `PATH`.
3. [Установите инструменты сборки Microsoft C++](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Установите JPype1](https://jpype.readthedocs.io/en/latest/install.html). Вы можете выполнить следующие команды в терминале python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Скачайте Aspose.Slides для Python через Java](https://releases.aspose.com/slides/python-java/) и распакуйте его в `aspose-slides-java`.
6. Создайте файл с именем `example.py` в папке `aspose-slides-java`, используя следующий пример кода:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Заголовок слайда")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. Теперь выполните `py example.py` в командной строке, чтобы запустить его.

### **Linux**

1. Установите JDK8 для Linux и настройте переменную окружения `JAVA_HOME`.
2. [Установите Python](https://www.python.org/downloads/) версии >=3.7.
3. Установите `g++` и `python-dev`. 

- Для Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Для систем на базе RedHat:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Установите JPype1](https://jpype.readthedocs.io/en/latest/install.html). Вы можете выполнить следующие команды в терминале python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Скачайте Aspose.Slides для Python через Java](https://releases.aspose.com/slides/python-java/) и распакуйте его в `aspose-slides-java`.
6. Создайте тестовый файл с именем `example.py`, используя этот пример кода в папке `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Заголовок слайда")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Теперь выполните `py example.py` в командной строке, чтобы запустить его.

### **Mac**

1. Установите JDK8 для Mac и настройте переменную окружения `JAVA_HOME`.
2. Измените раздел JVMCapabilities в `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` с правами root. `jdk1.8.x_xxx.jdk` зависит от вашей версии jdk. Сделайте его таким:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Установите Python](https://www.python.org/downloads/) версии >=3.7.
4. Установите компиляторы GCC или Clang в зависимости от версии Python и платформы.
5. [Установите JPype1](https://jpype.readthedocs.io/en/latest/install.html). Вы можете выполнить следующие команды в терминале python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Скачайте Aspose.Slides для Python через Java](https://releases.aspose.com/slides/python-java/) и распакуйте его в `aspose-slides-java`.
7. Создайте тестовый файл с именем `example.py`, используя этот пример кода в папке `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Заголовок слайда")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. Теперь выполните `python example.py` в командной строке, чтобы запустить его.