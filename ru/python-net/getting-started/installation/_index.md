---
title: Установка
type: docs
weight: 70
url: /ru/python-net/installation/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Windows
- macOS
- Python
description: "Узнайте, как быстро установить Aspose.Slides for Python via .NET. Пошаговое руководство, системные требования и примеры кода — начните работать с презентациями PowerPoint уже сегодня!"
---

## **Обзор**

Пакет Aspose.Slides for Python via .NET поставляется со всеми необходимыми библиотеками .NET, что исключает необходимость отдельной установки .NET. Это упрощает процесс настройки и позволяет разработчикам сразу приступить к работе с презентациями. Тем не менее, в зависимости от вашей операционной системы или среды, вам всё‑равно может потребоваться установка некоторых платформенно‑специфических зависимостей, требуемых .NET. Кроме того, необходимо соблюсти определённые системные требования для полной совместимости и корректной работы пакета.

## **Windows**

**Требования к системе**

Проверьте и убедитесь, что характеристики вашего компьютера соответствуют или превышают [требованиям к системе](/slides/ru/python-net/system-requirements/).

### **Установить Aspose.Slides**

`pip` — самый простой способ загрузить и установить [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) в Windows.

Чтобы установить Aspose.Slides, выполните следующую команду:
```sh
pip install aspose-slides
```


**Использовать Aspose.Slides**

Проверьте установку Aspose.Slides, выполнив следующий код для создания презентации PowerPoint:
```python
# Импортировать модуль Aspose.Slides for Python via .NET.
import aspose.slides as slides

# Создать экземпляр класса Presentation, который представляет файл презентации.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **macOS**

**Требования к системе**

Проверьте и убедитесь, что характеристики вашего компьютера соответствуют или превышают [требованиям к системе](/slides/ru/python-net/system-requirements/).

### **Предварительные требования**

**Python с общими библиотеками**

Существует несколько способов установить Python в macOS, но мы настоятельно рекомендуем использовать [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos).

После установки и настройки **pyenv** установите Python с общими библиотеками, выполнив следующие команды в приложении Terminal:

1. Установить Python:
```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```


2. Установить его в качестве глобальной версии Python:
```sh
pyenv global 3.9.13
```


3. Установить его в качестве версии Python для конкретной оболочки:
```sh
pyenv shell 3.9.13
```


4. Создать символическую ссылку для библиотеки libpython в системном каталоге библиотек:
```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```


Note: Python 3.5 or higher is required. Version 3.9.13 is used here only as an example.

**Установить библиотеку libgdiplus**

Библиотека **libgdiplus** — это реализация Windows GDI+ для macOS и Linux, от которой .NET зависит для графических функций на этих платформах.
Чтобы установить эту библиотеку в macOS, выполните следующую команду:
```sh
brew install mono-libgdiplus
```


### **Установить Aspose.Slides**

`pip` — самый простой способ загрузить и установить [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) в macOS.

Чтобы установить Aspose.Slides, выполните следующую команду:
```sh
pip install aspose-slides
```


**Использовать Aspose.Slides**

Проверьте установку Aspose.Slides, выполнив следующий код для создания презентации PowerPoint:
```python
# Импортировать модуль Aspose.Slides for Python via .NET.
import aspose.slides as slides

# Создать экземпляр класса Presentation, который представляет файл презентации.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли установить Aspose.Slides в виртуальном окружении?**

Да, вы можете установить его в любой виртуальной среде Python с помощью `pip`. Просто убедитесь, что окружение имеет доступ к требуемым нативным зависимостям в зависимости от вашей ОС.

**Можно ли использовать Aspose.Slides в контейнерах Docker?**

Да, но нужно убедиться, что ваш образ Docker включает необходимые нативные библиотеки (**libgdiplus**, пакеты шрифтов и т.д.) и правильную версию Python.

**Есть ли бесплатная версия или ограничения пробной версии?**

Да, по умолчанию Aspose.Slides работает в режиме оценки, который добавляет водяные знаки и может иметь другие ограничения. Чтобы снять ограничения, необходимо применить действительную [лицензию](/slides/ru/python-net/licensing/).