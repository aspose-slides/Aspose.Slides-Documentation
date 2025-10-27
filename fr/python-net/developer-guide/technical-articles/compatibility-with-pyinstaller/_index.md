---
title: Compatibilité avec PyInstaller et cx_Freeze
linktitle: Compatibilité avec PyInstaller
type: docs
weight: 122
url: /fr/python-net/compatibility-with-pyinstaller/
keywords:
- compatibility
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Packagez Aspose.Slides for Python via .NET avec PyInstaller. Suivez ce guide pour regrouper, configurer et dépanner votre application en un exécutable autonome."
---

## **Compatibilité avec PyInstaller et cx_Freeze**

Les extensions Aspose.Slides for Python via .NET sont des extensions C Python standard, elles peuvent donc être « gelées » comme dépendances du programme avec des outils comme PyInstaller et cx_Freeze (ou similaires). Cela vous permet de créer des fichiers exécutables à partir de vos scripts Python. Ces outils sont appelés « freezers » parce qu’ils regroupent votre code et ses dépendances dans un seul fichier distribuable qui s’exécute sur d’autres machines sans nécessiter d’installation Python ou de bibliothèques supplémentaires. Cette approche simplifie la distribution de vos applications Python.

Le gel d’une extension Aspose.Slides for Python via .NET en tant que dépendance est illustré ci‑dessous avec un petit programme qui utilise Aspose.Slides.

### **PyInstaller**

En général, rien de spécial n’est requis lors de l’empaquetage d’un programme dépendant d’une extension Aspose.Slides for Python via .NET. Lorsqu’un programme importe l’extension d’une manière visible pour PyInstaller, l’extension sera incluse avec le programme. Comme Aspose.Slides for Python via .NET comprend des hooks PyInstaller, ses dépendances sont automatiquement détectées et copiées dans le paquet.

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

Cependant, PyInstaller peut parfois ne pas détecter des importations cachées — des modules importés dynamiquement ou indirectement par votre code. Pour inclure une importation cachée, utilisez les options de PyInstaller. Les dépendances de l’extension sont spécifiées dans les hooks PyInstaller fournis avec Aspose.Slides for Python via .NET.

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

Pour geler un programme avec cx_Freeze, configurez‑le afin d’inclure le paquet racine de l’extension Aspose.Slides for Python via .NET que vous utilisez. Cela garantit que l’extension et tous les modules dont elle dépend sont copiés dans la construction aux côtés de votre application.

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

**Dois‑je installer Microsoft PowerPoint ou .NET sur la machine de l’utilisateur ?**

Non, PowerPoint n’est pas requis. Aspose.Slides est un moteur autonome ; le package Python fournit tout le nécessaire sous forme d’une extension pour CPython. L’utilisateur n’a pas besoin d’installer .NET séparément.

**Comment attacher correctement la licence à une application gelée ?**

Vous pouvez placer le fichier XML de licence à côté de l’exécutable ou l’intégrer comme ressource et le charger depuis un chemin accessible avant le premier appel d’API. Important : ne modifiez pas le contenu du XML (pas même les sauts de ligne).

**Que faire si les polices sont rendues différemment après la construction par rapport au développement ?**

Assurez‑vous que les polices que vous utilisez sont disponibles dans l’environnement cible (emballées ou installées dans le système) et que leurs chemins sont correctement résolus au moment de l’exécution ; le comportement des polices est particulièrement sensible sous Linux.