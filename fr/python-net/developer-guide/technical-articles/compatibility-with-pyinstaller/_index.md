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
description: "Emballez Aspose.Slides for Python via .NET avec PyInstaller. Suivez ce guide pour regrouper, configurer et dépanner votre application en un exécutable autonome."
---

## **Compatibilité avec PyInstaller et cx_Freeze**

Les extensions Aspose.Slides for Python via .NET sont des extensions C Python standard, elles peuvent donc être congelées comme dépendances de programme avec des outils tels que PyInstaller et cx_Freeze (ou similaire). Cela vous permet de créer des fichiers exécutables à partir de vos scripts Python. Ces outils sont appelés « freezers » car ils emballent votre code et ses dépendances dans un seul fichier distribuable qui s’exécute sur d’autres machines sans nécessiter d’installation Python ni de bibliothèques supplémentaires. Cette approche simplifie la distribution de vos applications Python.

La congélation d’une extension Aspose.Slides for Python via .NET comme dépendance est illustrée ci‑dessous avec un programme simple qui utilise Aspose.Slides.

### **PyInstaller**

En général, rien de spécial n’est requis lors de l’empaquetage d’un programme qui dépend d’une extension Aspose.Slides for Python via .NET. Lorsque le programme importe l’extension de façon visible pour PyInstaller, l’extension sera incluse avec le programme. Comme Aspose.Slides for Python via .NET inclut des hooks PyInstaller, ses dépendances sont automatiquement détectées et copiées dans le bundle.

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

Cependant, PyInstaller peut parfois manquer des importations cachées — des modules importés dynamiquement ou indirectement par votre code. Pour inclure une importation cachée, utilisez les options de PyInstaller. Les dépendances de l’extension sont spécifiées dans les hooks PyInstaller fournis avec Aspose.Slides for Python via .NET.

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

Pour congeler un programme avec cx_Freeze, configurez‑le afin d’inclure le package racine de l’extension Aspose.Slides for Python via .NET que vous utilisez. Cela garantit que l’extension et tous les modules dépendants sont copiés dans la construction aux côtés de votre application.

#### **Utilisation du script cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Utilisation du script d’installation**

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

**Do I need Microsoft PowerPoint or .NET installed on the user’s machine?**

Non, PowerPoint n’est pas requis. Aspose.Slides est un moteur autonome ; le package Python fournit tout ce qui est nécessaire sous forme d’extension pour CPython. L’utilisateur n’a pas besoin d’installer .NET séparément.

**How should I properly attach the license to a frozen application?**

Vous pouvez placer le fichier XML de licence à côté de l’exécutable ou l’intégrer comme ressource et le charger depuis un chemin accessible avant le premier appel d’API. Important : ne modifiez pas le contenu du XML (pas même les sauts de ligne).

**What should I do if fonts render differently after the build compared to development?**

Assurez‑vous que les polices que vous utilisez sont disponibles dans l’environnement cible (emballées ou installées sur le système) et que leurs chemins sont correctement résolus à l’exécution ; le comportement des polices est particulièrement sensible sous Linux.