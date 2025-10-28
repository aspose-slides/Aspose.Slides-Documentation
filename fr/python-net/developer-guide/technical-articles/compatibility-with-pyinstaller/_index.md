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
description: "Package Aspose.Slides for Python via .NET avec PyInstaller. Suivez ce guide pour regrouper, configurer et dépanner votre application en un exécutable autonome."
---

## **Compatibilité avec PyInstaller et cx_Freeze**

Les extensions Aspose.Slides for Python via .NET sont des extensions C Python standard, elles peuvent donc être « congelées » en tant que dépendances de programme avec des outils comme PyInstaller et cx_Freeze (ou similaires). Cela vous permet de créer des fichiers exécutables à partir de vos scripts Python. Ces outils sont appelés « freezers » parce qu’ils regroupent votre code et ses dépendances dans un seul fichier distribuable qui s’exécute sur d’autres machines sans nécessiter d’installation de Python ou de bibliothèques supplémentaires. Cette approche simplifie la distribution de vos applications Python.

La congélation d’une extension Aspose.Slides for Python via .NET en tant que dépendance est illustrée ci‑dessous avec un programme simple qui utilise Aspose.Slides.

### **PyInstaller**

Généralement, rien de spécial n’est requis lors de l’empaquetage d’un programme qui dépend d’une extension Aspose.Slides for Python via .NET. Lorsque le programme importe l’extension d’une manière visible pour PyInstaller, l’extension sera regroupée avec le programme. Comme Aspose.Slides for Python via .NET inclut des hooks PyInstaller, ses dépendances sont détectées automatiquement et copiées dans le paquet.

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

Toutefois, PyInstaller peut parfois omettre des importations cachées — des modules importés dynamiquement ou indirectement par votre code. Pour inclure une importation cachée, utilisez les options de PyInstaller. Les dépendances de l’extension sont spécifiées dans les hooks PyInstaller fournis avec Aspose.Slides for Python via .NET.

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

Pour congeler un programme avec cx_Freeze, configurez‑le afin d’inclure le package racine de l’extension Aspose.Slides for Python via .NET que vous utilisez. Cela garantit que l’extension et tous les modules dépendants sont copiés dans la construction avec votre application.

#### **Utilisation du script cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Utilisation du script Setup**

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

**Ai‑je besoin de Microsoft PowerPoint ou de .NET installé sur la machine de l’utilisateur ?**

Non, PowerPoint n’est pas requis. Aspose.Slides est un moteur autonome ; le package Python fournit tout le nécessaire sous forme d’une extension pour CPython. L’utilisateur n’a pas besoin d’installer .NET séparément.

**Comment joindre correctement la licence à une application congelée ?**

Vous pouvez placer le fichier XML de licence à côté de l’exécutable ou l’incorporer comme ressource et le charger depuis un chemin accessible avant le premier appel d’API. Important : ne modifiez pas le contenu du XML (pas même les sauts de ligne).

**Que faire si les polices s’affichent différemment après la construction par rapport au développement ?**

Assurez‑vous que les polices que vous utilisez sont disponibles dans l’environnement cible (intégrées ou installées sur le système) et que leurs chemins sont correctement résolus à l’exécution ; le comportement des polices est particulièrement sensible sous Linux.