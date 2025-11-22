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
description: "Упакуйте Aspose.Slides for Python via .NET с помощью PyInstaller. Следуйте этому руководству, чтобы собрать, настроить и устранить проблемы вашего приложения в автономный исполняемый файл."
---

## **Совместимость с PyInstaller и cx_Freeze**

Aspose.Slides for Python via .NET extensions являются стандартными C‑расширениями Python, поэтому их можно «заморозить» как зависимости программы с помощью инструментов, таких как PyInstaller и cx_Freeze (или аналогичных). Это позволяет создавать исполняемые файлы из ваших скриптов Python. Такие инструменты называют «freezers», потому что они упаковывают ваш код и его зависимости в один дистрибутивный файл, который работает на других машинах без необходимости установки Python или дополнительных библиотек. Такой подход упрощает распространение ваших приложений Python.

Заморозка расширения Aspose.Slides for Python via .NET в качестве зависимости показана ниже на простом примере программы, использующей Aspose.Slides.

### **PyInstaller**

Как правило, ничего особенного не требуется при упаковке программы, зависящей от расширения Aspose.Slides for Python via .NET. Когда программа импортирует расширение так, чтобы PyInstaller его обнаружил, расширение будет включено в пакет. Поскольку Aspose.Slides for Python via .NET содержит хуки PyInstaller, его зависимости автоматически определяются и копируются в пакет.

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


Однако PyInstaller иногда может пропустить скрытые импорты — модули, импортируемые динамически или косвенно вашим кодом. Чтобы включить скрытый импорт, используйте соответствующие параметры PyInstaller. Зависимости расширения указаны в хуках PyInstaller, поставляемых вместе с Aspose.Slides for Python via .NET.

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

Чтобы заморозить программу с помощью cx_Freeze, настройте её так, чтобы включить корневой пакет расширения Aspose.Slides for Python via .NET, который вы используете. Это гарантирует, что расширение и все зависимые модули будут скопированы в сборку вместе с вашим приложением.

#### **Использование скрипта cxfreeze**
```bash
$ cxfreeze slide_app.py --packages=aspose
```


#### **Использование скрипта Setup**

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

**Нужен ли Microsoft PowerPoint или .NET, установленный на машине пользователя?**

Нет, PowerPoint не требуется. Aspose.Slides – это автономный движок; Python‑пакет поставляется со всем необходимым в виде расширения для CPython. Пользователю не нужно отдельно устанавливать .NET.

**Как правильно прикрепить лицензию к замороженному приложению?**

Вы можете разместить XML‑файл лицензии рядом с исполняемым файлом или внедрить его как ресурс и загрузить из доступного пути перед первым вызовом API. Важно: не изменяйте содержимое XML (даже разрывы строк).

**Что делать, если после сборки шрифты отображаются иначе, чем в процессе разработки?**

Убедитесь, что используемые шрифты присутствуют в целевой среде (встроены в пакет или установлены в системе) и что их пути корректно разрешаются во время выполнения; поведение шрифтов особенно чувствительно в Linux.