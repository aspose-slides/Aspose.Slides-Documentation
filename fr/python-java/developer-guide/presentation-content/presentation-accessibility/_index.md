---
title: Gérer l’accessibilité des présentations en Python via Java
linktitle: Accessibilité des présentations
type: docs
weight: 30
url: /fr/python-java/presentation-accessibility/
keywords:
- accessibilité des présentations
- Marquer comme décoratif
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Python via Java aide à automatiser les vérifications d’accessibilité des présentations dans les fichiers PPT, PPTX et ODP—améliorez l’expérience des lecteurs d’écran et renforcez la conformité."
---
## **Introduction**

L’accessibilité des présentations garantit que les personnes utilisant des technologies d’assistance—telles que les lecteurs d’écran, les affichages braille ou la navigation au clavier uniquement—peuvent comprendre et parcourir vos diapositives aussi efficacement que le public voyant et utilisant la souris. Les bonnes pratiques portent sur un ordre de lecture clair, un texte alternatif significatif pour les visuels informatifs, un contraste de couleur suffisant, une typographie lisible, un texte de lien descriptif et l’évitement de transmettre du sens uniquement par la couleur ou la position. Lorsque l’accessibilité est prévue dès le départ, le résultat est une structure plus propre, des visuels plus cohérents et un contenu qui atteint chaque spectateur sans contournements.

## **Marquer comme décoratif**

Marquer comme décoratif désigne les visuels purement ornementaux afin que les lecteurs d’écran les ignorent, réduisant le bruit et maintenant le focus sur le contenu pertinent. Appliquez‑le aux arrière‑plans, aux fioritures et aux espaces—jamais aux graphiques, icônes ou images qui transmettent de l’information. Aspose.Slides expose ce drapeau pour la détection et la validation, permettant des contrôles d’accessibilité automatisés et un nettoyage.

![Marquer comme décoratif](mark_as_decorative.png)

L’exemple de code suivant montre comment déterminer si une forme est marquée comme décorative.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```