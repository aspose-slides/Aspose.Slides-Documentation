---
title: PyInstallerおよびcx_Freezeとの互換性
type: docs
weight: 122
url: /python-net/compatibility-with-pyinstaller/
---


## PyInstallerおよびcx_Freezeとの互換性 ##

'Aspose.Slides for Python via .NET'拡張は単にPython C拡張であり、PyInstallerやcx_Freeze（または類似のツール）の助けを借りてプログラム依存関係として凍結できます。これは、PyInstallerやcx_Freezeのようなツールを使用してPythonスクリプトから実行可能ファイルを作成できることを意味します。これらのツールは、コードと依存関係を単一のファイルに凍結するため、他のマシンでPythonや他のライブラリを必要とせずに実行できます。これにより、他の人にPythonアプリケーションを配布しやすくなります。

'Aspose.Slides for Python via .NET'拡張をプログラム依存関係として凍結する方法を、Aspose.Slidesを使用した簡単なプログラムの例を示して説明します。

### PyInstaller
一般的に、'Aspose.Slides for Python via .NET'拡張に依存するプログラムをパッケージ化する際に特別なことを行う必要はありません。プログラムがPyInstallerに見える形で拡張をインポートすると、その拡張はプログラムと一緒にパッケージされます。'Aspose.Slides for Python via .NET'拡張にはPyInstallerフックが付属しているため、独自の依存関係が見つかり、バンドルにコピーされます。

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

ただし、場合によってはPyInstallerが、コードによって動的または間接的にインポートされるモジュールであるいくつかの隠れたインポートを検出できないことがあります。PyInstallerで隠れたインポートを処理するには、PyInstallerのオプションを使用します。拡張の依存関係は、'Aspose.Slides for Python via .NET'拡張に付属するPyInstallerフックで指定されます。

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
cx_Freezeを使ってプログラムを凍結するには、使用している'Aspose.Slides for Python via .NET'拡張のルートパッケージを凍結するためのオプションを使用します。これにより、拡張およびそれに依存するモジュールがプログラムと一緒にコピーされます。

#### cxfreezeスクリプトを使用する場合 ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### Setupスクリプトを使用する場合 ####
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