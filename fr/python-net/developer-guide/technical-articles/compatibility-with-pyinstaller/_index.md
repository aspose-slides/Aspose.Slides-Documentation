---
title: Compatibilité avec PyInstaller et cx_Freeze
linktitle: Compatibilité avec PyInstaller
type: docs
weight: 122
url: /fr/python-net/compatibility-with-pyinstaller/
keywords:
- compatibilité
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Emballez Aspose.Slides for Python via .NET avec PyInstaller. Suivez ce guide pour regrouper, configurer et dépanner votre application dans un exécutable autonome."
---


## Compatibilité avec PyInstaller et cx_Freeze ##

Les extensions 'Aspose.Slides pour Python via .NET' sont simplement des extensions C pour Python, qui peuvent être gelées avec l'aide de PyInstaller et cx_Freeze (ou d'outils similaires) en tant que dépendances de programme. Cela signifie que vous pouvez utiliser des outils comme PyInstaller et cx_Freeze pour créer des fichiers exécutables à partir de vos scripts Python. Ces outils sont appelés "freezers" car ils gèlent votre code et vos dépendances dans un seul fichier qui peut être exécuté sur d'autres machines sans nécessiter Python ou d'autres bibliothèques. Cela facilite la distribution de vos applications Python à d'autres.

Geler une extension 'Aspose.Slides pour Python via .NET' en tant que dépendance de programme est illustré par un exemple d'un programme simple qui utilise Aspose.Slides.

### PyInstaller
En général, rien de spécial n'a besoin d'être fait lors de l'emballage d'un programme qui dépend d'une extension 'Aspose.Slides pour Python via .NET'. Lorsque qu'un programme importe une extension d'une manière visible par PyInstaller, l'extension sera emballée avec le programme. Étant donné que les extensions 'Aspose.Slides pour Python via .NET' viennent avec des hooks PyInstaller, leurs propres dépendances seront trouvées et copiées dans le bundle.

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

Cependant, parfois PyInstaller ne peut pas détecter certaines importations cachées, qui sont des modules importés dynamiquement ou indirectement par votre code. Pour gérer une importation cachée dans PyInstaller, utilisez les options de PyInstaller. Les dépendances d'une extension sont spécifiées dans les hooks PyInstaller qui viennent avec l'extension 'Aspose.Slides pour Python via .NET'.

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
Pour geler un programme en utilisant cx_Freeze, utilisez ses options pour geler le package racine de l'extension 'Aspose.Slides pour Python via .NET' que vous utilisez. Cela garantira que l'extension et les modules dont elle dépend sont copiés avec le programme.

#### Utilisation du script cxfreeze ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### Utilisation du script Setup ####
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