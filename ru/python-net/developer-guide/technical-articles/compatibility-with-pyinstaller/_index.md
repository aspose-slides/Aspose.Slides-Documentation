---
title: "Совместимость с PyInstaller и cx_Freeze"
linktitle: "Совместимость с PyInstaller"
type: docs
weight: 122
url: /ru/python-net/developer-guide/technical-articles/compatibility-with-pyinstaller/
keywords:
- compatibility
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Упакуйте Aspose.Slides for Python via .NET с помощью PyInstaller. Следуйте этому руководству, чтобы собрать, настроить и решить проблемы вашего приложения в автономный исполняемый файл."
---

## **Совместимость с PyInstaller и cx_Freeze**

Aspose.Slides for Python via .NET — это стандартные C‑расширения Python, поэтому их можно «заморозить» как зависимости программы с помощью таких инструментов, как PyInstaller и cx_Freeze (или аналогичных). Это позволяет создавать исполняемые файлы из ваших скриптов Python. Такие инструменты называют «заморозчиками», потому что они упаковывают ваш код и его зависимости в один распределяемый файл, который работает на других машинах без необходимости установки Python или дополнительных библиотек. Такой подход упрощает распространение ваших Python‑приложений.

Пример заморозки расширения Aspose.Slides for Python via .NET в качестве зависимости показан ниже на простом коде, использующем Aspose.Slides.

### **PyInstaller**

Обычно ничего особенного не требуется при упаковке программы, зависящей от расширения Aspose.Slides for Python via .NET. Когда программа импортирует расширение, которое видно PyInstaller, расширение будет включено в пакет. Поскольку Aspose.Slides for Python via .NET содержит хуки PyInstaller, его зависимости автоматически обнаруживаются и копируются в пакет.

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

Тем не менее, PyInstaller иногда может пропустить скрытые импорты — модули, импортируемые динамически или косвенно вашим кодом. Чтобы включить скрытый импорт, используйте соответствующие параметры PyInstaller. Зависимости расширения указаны в хуках PyInstaller, поставляемых вместе с Aspose.Slides for Python via .NET.

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

Для заморозки программы с помощью cx_Freeze необходимо настроить включение корневого пакета расширения Aspose.Slides for Python via .NET, которое вы используете. Это гарантирует, что расширение и все его зависимые модули будут скопированы в сборку рядом с вашим приложением.

#### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Using the Setup Script**

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

**Нужен ли Microsoft PowerPoint или .NET на машине пользователя?**

Нет, PowerPoint не требуется. Aspose.Slides — это автономный движок; Python‑пакет поставляется со всем необходимым как расширение для CPython. Пользователю не нужно отдельно устанавливать .NET.

**Как правильно прикрепить лицензию к «замороженному» приложению?**

Можно разместить XML‑файл лицензии рядом с исполняемым файлом или встроить его как ресурс и загрузить из доступного пути до первого вызова API. Важно: не изменяйте содержимое XML (даже пробелы и переносы строк).

**Что делать, если шрифты отображаются иначе после сборки, чем в процессе разработки?**

Убедитесь, что используемые шрифты доступны в целевой среде (включены в пакет или установлены в системе) и что их пути корректно разрешаются во время выполнения; поведение шрифтов особенно чувствительно в Linux.