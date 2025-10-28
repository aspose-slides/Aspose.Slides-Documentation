---
title: Совместимость с PyInstaller и cx_Freeze
linktitle: Совместимость с PyInstaller
type: docs
weight: 122
url: /ru/python-net/compatibility-with-pyinstaller/
keywords:
- совместимость
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Упакуйте Aspose.Slides for Python via .NET с помощью PyInstaller. Следуйте этому руководству, чтобы собрать, настроить и устранять неполадки вашего приложения в автономный исполняемый файл."
---

## **Совместимость с PyInstaller и cx_Freeze**

Aspose.Slides for Python via .NET являются стандартными C‑расширениями Python, поэтому их можно «заморозить» как зависимости программы с помощью таких инструментов, как PyInstaller и cx_Freeze (или аналогичных). Это позволяет создавать исполняемые файлы из ваших скриптов Python. Такие инструменты называют «заморозчиками», потому что они упаковывают ваш код и его зависимости в один распространяемый файл, который работает на других машинах без необходимости установки Python или дополнительных библиотек. Такой подход упрощает распространение ваших Python‑приложений.

Пример заморозки расширения Aspose.Slides for Python via .NET в виде зависимости приведён ниже с простым программным примером, использующим Aspose.Slides.

### **PyInstaller**

Как правило, при упаковке программы, зависящей от расширения Aspose.Slides for Python via .NET, ничего особенного не требуется. Когда программа импортирует расширение способом, видимым для PyInstaller, расширение будет добавлено в пакет программы. Поскольку Aspose.Slides for Python via .NET включает хуки PyInstaller, его зависимости автоматически обнаруживаются и копируются в пакет.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Тем не менее, PyInstaller иногда может пропустить скрытые импорты — модули, которые импортируются динамически или косвенно вашим кодом. Чтобы включить скрытый импорт, используйте соответствующие параметры PyInstaller. Зависимости расширения указаны в хуках PyInstaller, поставляемых с Aspose.Slides for Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

### **cx_Freeze**

Чтобы «заморозить» программу с помощью cx_Freeze, настройте её так, чтобы включать корневой пакет используемого расширения Aspose.Slides for Python via .NET. Это гарантирует, что расширение и все связанные модули будут скопированы в сборку вместе с вашим приложением.

#### **Использование скрипта cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Использование скрипта setup**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Нужны ли Microsoft PowerPoint или .NET на машине пользователя?**

Нет, PowerPoint не требуется. Aspose.Slides — это автономный движок; пакет Python поставляется со всем необходимым в виде расширения для CPython. Пользователю не нужно отдельно устанавливать .NET.

**Как правильно прикрепить лицензию к замороженному приложению?**

Вы можете разместить XML‑файл лицензии рядом с исполняемым файлом или встроить его как ресурс и загрузить из доступного пути до первого вызова API. Важно: не изменяйте содержимое XML (даже переносы строк).

**Что делать, если после сборки шрифты отображаются иначе, чем в процессе разработки?**

Убедитесь, что используемые шрифты доступны в целевой среде (включены в пакет или установлены в системе) и их пути корректно определяются во время выполнения; поведение шрифтов особенно чувствительно в Linux.