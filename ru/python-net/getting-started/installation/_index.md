---
title: Установка
type: docs
weight: 70
url: /python-net/installation/
keywords: "Скачать Aspose.Slides, Установить Aspose.Slides, Установка Aspose.Slides, Windows, macOS, Python"
description: "Установите Aspose.Slides для Python через .NET в Windows или macOS"
---

Пакет Aspose.Slides для Python через .NET включает необходимые библиотеки .NET, поэтому отдельная установка .NET не требуется. Однако в зависимости от вашей платформы вам может понадобиться установить специфические зависимости для .NET и выполнить определенные требования.

## **Windows**

**Системные требования**

Проверьте и подтвердите, что спецификации вашего компьютера соответствуют или превышают [системные требования](/slides/python-net/system-requirements/).

### **Установка Aspose.Slides**

`pip` является самым простым способом скачать и установить [Aspose.Slides для Python через .NET](https://pypi.org/project/aspose.slides/) на устройствах Windows.

Чтобы установить Aspose.Slides, выполните эту команду:  `pip install aspose.slides`

**Использование Aspose.Slides**

Проверьте вашу установку Aspose.Slides, запустив этот код для создания презентации PowerPoint:

```python
# Импорт модуля Aspose.Slides для Python через .NET
import aspose.slides as slides

# Создает объект Presentation, который представляет файл презентации
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Системные требования**

Проверьте и подтвердите, что спецификации вашего компьютера соответствуют или превышают [системные требования](/slides/python-net/system-requirements/).

### **Предварительные требования**

**Python с общими библиотеками**

Существует несколько способов установки Python на macOS, но мы настоятельно рекомендуем использовать [инструмент pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

После установки и настройки pyenv вам нужно установить Python с общими библиотеками, выполнив эти команды в приложении Terminal:

1. Установите Python: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. Настройте его как глобальную установку Python: `pyenv global 3.9.13`
3. Настройте его как установку Python для текущей оболочки: `pyenv shell 3.9.13`
4. Создайте символическую ссылку на библиотеку libpython в системной директории библиотеки: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

Примечание: требуется Python версии 3.5 и выше. Версия Python 3.9.13 использовалась просто в качестве примера.

**Установка библиотеки libgdiplus**

Библиотека libgdiplus является реализацией GDI+ для Windows на macOS и Linux, которую .NET использует на этих платформах. Чтобы установить эту библиотеку, выполните следующую команду: `brew install mono-libgdiplus` 

### **Установка Aspose.Slides**

`pip` является самым простым способом скачать и установить [Aspose.Slides для Python через .NET](https://pypi.org/project/aspose.slides/) на устройствах macOS. Чтобы установить Aspose.Slides, выполните эту команду: `pip install aspose.slides`

**Использование Aspose.Slides**

Проверьте вашу установку Aspose.Slides, запустив этот код для создания презентации PowerPoint:

```python
# Импорт модуля Aspose.Slides для Python через .NET
import aspose.slides as slides

# Создает объект Presentation, который представляет файл презентации
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```