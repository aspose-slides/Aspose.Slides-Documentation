---
title: 與 PyInstaller 及 cx_Freeze 的相容性
linktitle: 與 PyInstaller 的相容性
type: docs
weight: 122
url: /zh-hant/python-net/compatibility-with-pyinstaller/
keywords:
- 相容性
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "使用 PyInstaller 打包 Aspose.Slides for Python via .NET。請依照本指南將您的應用程式打包、設定，並排除故障，以產生獨立執行檔。"
---
## **簡介**

Aspose.Slides for Python via .NET 擴充功能是標準的 Python C 擴充套件，因此可以使用 PyInstaller、cx_Freeze（或類似工具）將其凍結為程式相依性。這使您能夠從 Python 腳本產生可執行檔。此類工具稱為「凍結器」，因為它們將您的程式碼及其相依項目打包成單一可分發的檔案，於其他電腦上執行時不需安裝 Python 或其他函式庫。此方式簡化了 Python 應用程式的發佈。

下面示範如何將 Aspose.Slides for Python via .NET 擴充功能凍結為相依性，例子是一個使用 Aspose.Slides 的簡易程式。

## **PyInstaller**

一般而言，將依賴 Aspose.Slides for Python via .NET 擴充功能的程式打包時不需要特別的操作。只要程式以 PyInstaller 能偵測到的方式匯入該擴充功能，該擴充功能就會與程式一起被打包。由於 Aspose.Slides for Python via .NET 包含 PyInstaller 鉤子，它的相依項目會自動被偵測並複製到套件中。

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

然而，PyInstaller 有時會遺漏隱藏匯入──即程式碼動態或間接匯入的模組。若要加入隱藏匯入，需要使用 PyInstaller 的相關選項。該擴充功能的相依項目已在隨 Aspose.Slides for Python via .NET 提供的 PyInstaller 鉤子中指定。

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

## **cx_Freeze**

若要使用 cx_Freeze 凍結程式，請設定將您使用的 Aspose.Slides for Python via .NET 擴充功能的根套件納入。這可確保該擴充功能及所有相依模組會與您的應用程式一起複製到建置目錄中。

### **使用 cxfreeze 腳本**
```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **使用 Setup 腳本**
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

**我是否需要在使用者的機器上安裝 Microsoft PowerPoint 或 .NET？**

不需要，PowerPoint 並非必須。Aspose.Slides 是自足的引擎；Python 套件以 CPython 的擴充功能形式提供所有必要的元件。使用者不需要額外安裝 .NET。

**我該如何正確地將授權檔案附加至凍結的應用程式？**

您可以將授權 XML 檔案放在可執行檔旁，或將其嵌入為資源，並在首次呼叫 API 前從可存取的路徑載入。重要提示：請勿修改 XML 內容（甚至不要更改換行）。

**如果建置後字型呈現與開發時不同，我該怎麼辦？**

請確認您使用的字型在目標環境中可用（無論是已打包或系統已安裝），且在執行時能正確解析其路徑；字型的行為在 Linux 上尤為敏感。