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

Aspose.Slides for Python via .NET extensions sont des extensions C Python standard, elles peuvent donc être gelées comme dependances de programme avec des outils comme PyInstaller et cx_Freeze (ou similaires). Cela vous permet de creer des fichiers executables a partir de vos scripts Python. Ces outils sont appeles "freezers" parce qu ils regroupent votre code et ses dependances dans un seul fichier distribuable qui s execute sur d autres machines sans requerir d installation de Python ou de bibliotheques supplementaires. Cette approche simplifie la distribution de vos applications Python.

Le gel d une extension Aspose.Slides for Python via .NET en tant que dependance est illustre ci-dessous avec un programme simple qui utilise Aspose.Slides.

### **PyInstaller**

En general, rien de special n est requis lors de l empaquetage d un programme qui depend d une extension Aspose.Slides for Python via .NET. Lorsqu un programme importe l extension de maniere visible pour PyInstaller, l extension sera integree au programme. Comme Aspose.Slides for Python via .NET inclut des hooks PyInstaller, ses dependances sont detectees automatiquement et copiees dans le paquet.

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


Cependant, PyInstaller peut parfois manquer des importations cachees - des modules importes dynamiquement ou indirectement par votre code. Pour inclure une importation cachee, utilisez les options de PyInstaller. Les dependances de l extension sont specifiees dans les hooks PyInstaller fournis avec Aspose.Slides for Python via .NET.

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

Pour geler un programme avec cx_Freeze, configurez-le afin d inclure le package racine de l extension Aspose.Slides for Python via .NET que vous utilisez. Cela garantit que l extension et tous les modules dependants sont copies dans la construction avec votre application.

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

**Ai-je besoin de Microsoft PowerPoint ou de .NET installe sur la machine de l'utilisateur ?**

Non, PowerPoint n est pas requis. Aspose.Slides est un moteur autonome ; le package Python fournit tout le necessaire sous forme d une extension pour CPython. L utilisateur n a pas besoin d installer .NET separement.

**Comment dois-je correctement attacher la licence a une application gelee ?**

Vous pouvez placer le fichier XML de licence a cote de l executable ou l integrer en tant que ressource et le charger a partir d un chemin accessible avant le premier appel API. Important: ne modifiez pas le contenu du XML (pas meme les sauts de ligne).

**Que faire si les polices s affichent différemment apres la construction par rapport au developpement ?**

Assurez-vous que les polices que vous utilisez sont disponibles dans l environnement cible (integrees ou installees system) et que leurs chemins sont correctement resolus a l execution; le comportement des polices est particulierement sensible sous Linux.