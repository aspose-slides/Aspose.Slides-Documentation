---
title: Compatibility with PyInstaller and cx_Freeze
type: docs
weight: 122
url: /python-net/compatibility-with-pyinstaller/
---


## Compatibility with PyInstaller and cx_Freeze ##

'Aspose.Slides for Python via .NET' extensions are simply Python C-extensions, which can be frozen with the help of PyInstaller and cx_Freeze (or similar tools) as program dependencies. This means that you can use tools like PyInstaller and cx_Freeze to create executable files from your Python scripts. These tools are called freezers because they freeze your code and dependencies into a single file that can run on other machines without requiring Python or other libraries. This makes it easier to distribute your Python applications to others.

Freezing an 'Aspose.Slides for Python via .NET' extension as a program dependency is illustrated with an example of a simple program that uses Aspose.Slides.

### PyInstaller
Generally, nothing special needs to be done when packaging a program that depends on a 'Aspose.Slides for Python via .NET' extension. When a program imports an extension in a way that is visible to PyInstaller, the extension will be packaged along with the program. Since 'Aspose.Slides for Python via .NET' extensions come with PyInstaller hooks, their own dependencies will be found and copied into the bundle.

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

However, sometimes PyInstaller cannot detect some hidden imports, which are modules that are imported dynamically or indirectly by your code. To handle a hidden import in PyInstaller, use PyInstaller's options. The dependencies of an extension are specified in PyInstaller hooks that come with the 'Aspose.Slides for Python via .NET' extension.

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
To freeze a program using cx_Freeze, use its options to freeze the root package of the 'Aspose.Slides for Python via .NET' extension that you are using. This will ensure that the extension and the modules it depends on are copied with the program.

#### Using the cxfreeze script ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### Using the Setup script ####
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
