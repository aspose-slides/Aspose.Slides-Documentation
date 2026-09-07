---
title: Convertir PPTX en PPT en Python
linktitle: PPTX en PPT
type: docs
weight: 21
url: /fr/python-java/convert-pptx-to-ppt/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPTX
- PPTX en PPT
- enregistrer PPTX en tant que PPT
- exporter PPTX vers PPT
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertir PPTX au format PPT hérité en Python avec Aspose.Slides for Python via Java. Inclut un exemple de code et des notes sur la compatibilité et les fichiers protégés."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet de convertir une présentation PPTX au format PPT hérité utilisé par PowerPoint 97–2003 sans installer Microsoft PowerPoint. Chargez le fichier PPTX et enregistrez‑le au format de sortie PPT, comme indiqué ci‑dessous.

## **Convertir PPTX en PPT**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec le chemin de sortie et [SaveFormat.Ppt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Ppt).

L'exemple suivant démarre la machine virtuelle Java si nécessaire et convertit `template.pptx` en `output.ppt` en utilisant les options par défaut. Remplacez les chemins par vos propres noms de fichiers. Le bloc `finally` libère les ressources de la présentation même en cas d'échec de l'enregistrement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Charger la présentation PPTX.
presentation = Presentation("template.pptx")
try:
    # Enregistrer la présentation au format PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

L'argument [SaveFormat.Ppt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Ppt) sélectionne le format de sortie ; changer uniquement l'extension du fichier ne convertit pas une présentation. Conservez le fichier PPTX original afin de pouvoir y revenir si une fonctionnalité plus récente n'a pas d'équivalent en PPT.

## **Convertir PPTX vers d'autres formats**

Aspose.Slides prend également en charge d'autres formats de sortie. Consultez les articles correspondants pour les options et exemples spécifiques à chaque format :

- [Convertir PowerPoint en PDF avec Python](/slides/fr/python-java/convert-powerpoint-to-pdf/)
- [Convertir PowerPoint en XPS avec Python](/slides/fr/python-java/convert-powerpoint-to-xps/)
- [Convertir PowerPoint en HTML avec Python](/slides/fr/python-java/convert-powerpoint-to-html/)
- [Enregistrer les présentations en ODP avec Python](/slides/fr/python-java/save-presentation/)
- [Convertir PowerPoint en PNG avec Python](/slides/fr/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Tous les effets et fonctionnalités PPTX survivent-ils à la conversion en PPT ?**

Pas toujours. Le format PPT hérité ne prend pas en charge toutes les fonctionnalités disponibles dans PPTX. Certains effets, objets ou comportements peuvent être simplifiés ou affichés différemment. Examinez la présentation convertie dans le visualiseur prévu, surtout lorsqu'elle contient des fonctionnalités PowerPoint plus récentes.

**Puis-je convertir uniquement des diapositives sélectionnées en PPT ?**

Enregistrement au format PPT écrit l'intégralité de la présentation. Pour convertir des diapositives sélectionnées, créez une nouvelle présentation, supprimez sa diapositive vide initiale, clonez les diapositives requises dedans, puis enregistrez‑la au format PPT. Voir [Cloner des diapositives en Python](/slides/fr/python-java/clone-slides/).

**Puis-je convertir un fichier PPTX protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement de la présentation source. Vous pouvez également configurer la protection du fichier de sortie. Voir [Présentations protégées par mot de passe](/slides/fr/python-java/password-protected-presentation/).