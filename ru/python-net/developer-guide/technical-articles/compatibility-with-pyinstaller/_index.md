---
title: Совместимость с PyInstaller и cx_Freeze
type: docs
weight: 122
url: /python-net/compatibility-with-pyinstaller/
---


## Совместимость с PyInstaller и cx_Freeze ##

Расширения 'Aspose.Slides для Python через .NET' — это простые C-расширения для Python, которые могут быть заморожены с помощью PyInstaller и cx_Freeze (или аналогичных инструментов) в качестве зависимостей программы. Это означает, что вы можете использовать такие инструменты, как PyInstaller и cx_Freeze, чтобы создавать исполняемые файлы из ваших Python-скриптов. Эти инструменты называются "фризерами", потому что они замораживают ваш код и зависимости в один файл, который может работать на других машинах без необходимости установки Python или других библиотек. Это облегчает распространение ваших Python-приложений.

Пример заморозки расширения 'Aspose.Slides для Python через .NET' в качестве зависимости программы проиллюстрирован на примере простой программы, использующей Aspose.Slides.

### PyInstaller
В общем, при упаковке программы, зависящей от расширения 'Aspose.Slides для Python через .NET', ничего особенного делать не нужно. Когда программа импортирует расширение таким образом, который виден PyInstaller, расширение будет упаковано вместе с программой. Поскольку расширения 'Aspose.Slides для Python через .NET' поставляются с хуками PyInstaller, их собственные зависимости будут найдены и скопированы в пакет.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

```
$ pyinstaller slide_app.py
```

Однако иногда PyInstaller не может обнаружить некоторые скрытые импорты, которые представляют собой модули, импортируемые динамически или косвенно вашим кодом. Чтобы обработать скрытый импорт в PyInstaller, используйте параметры PyInstaller. Зависимости расширения указываются в хуках PyInstaller, которые поставляются с расширением 'Aspose.Slides для Python через .NET'.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```
$ pyinstaller slide_app.spec
```

### cx_Freeze ###
Чтобы заморозить программу, используя cx_Freeze, используйте его параметры для заморозки корневого пакета расширения 'Aspose.Slides для Python через .NET', которое вы используете. Это обеспечит копирование расширения и модулей, от которых оно зависит, вместе с программой.

#### Использование скрипта cxfreeze ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### Использование скрипта Setup ####
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


```
$ python setup.py build_exe
```