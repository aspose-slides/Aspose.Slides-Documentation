---
title: Comment exécuter Aspose.Slides dans Docker
linktitle: Aspose.Slides dans Docker
type: docs
weight: 150
url: /fr/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides dans Docker
- Conteneur Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- polices
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Exécutez Aspose.Slides pour Python via .NET dans Docker : un Dockerfile fonctionnel, les bibliothèques natives requises par le package, la configuration des polices et la gestion de la licence dans un conteneur."
---
## **Aperçu**

Aspose.Slides for Python via .NET s’exécute dans des conteneurs Linux, mais le paquet est un wrapper Python autour d’un runtime .NET Core 3.1 fourni. Ce runtime nécessite trois bibliothèques natives que les images Python allégées n’incluent pas, et il est exigeant quant à leurs versions. Cet article fournit un Dockerfile fonctionnel, explique pourquoi chaque dépendance est requise et montre comment ajouter des polices et une licence.

## **Un Dockerfile fonctionnel**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py` :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Construire et exécuter :

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Pourquoi l’image de base est Debian 11**

La roue `aspose.slides` regroupe un runtime **.NET Core 3.1**, et ce runtime précède les versions des bibliothèques présentes dans les versions actuelles de Debian. Sous Debian 12 et 13, le conteneur se construit correctement mais échoue lors du premier appel à `Presentation()` :

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Le message est trompeur — ICU *est* installé sur ces images, mais il s’agit d’ICU 72 ou 76, et .NET Core 3.1 ne reconnaît que les versions majeures antérieures. Debian 12 fournit en plus OpenSSL 3, ce qui engendre une seconde erreur :

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` est Debian 11, qui propose les deux versions attendues par le runtime inclus :

| Paquet | Version sur Debian 11 | Pourquoi c’est nécessaire |
|---|---|---|
| `libgdiplus` | 6.0.4 | Implémentation GDI+ utilisée pour le rendu des formes, du texte et des images |
| `libicu67` | 67.1 | Données de régionalisation. Les versions majeures plus récentes ne sont pas reconnues par .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Cryptographie. Préinstallé sur Debian 11 ; absent sur Debian 12+ |
| `libfontconfig1` | — | Découverte des polices |

`libssl1.1` est déjà présent dans l’image de base, il n’est donc pas nécessaire de le mentionner dans `apt-get install`.

Si vous devez absolument utiliser une image de base plus récente, définissez `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` pour contourner la dépendance à ICU. Cela désactive le formatage dépendant de la culture et ne résout **pas** le problème OpenSSL, d’où Debian 11 reste le choix le plus simple.

## **Polices**

Les images allégées ne contiennent aucune police. Sans au moins une police installée, le texte apparaît sous forme de cases vides dans les sorties PDF, image et HTML. `fonts-dejavu-core` constitue un petit point de départ polyvalent.

Pour reproduire l’apparence prévue d’une présentation, copiez les polices utilisées dans l’image et pointez Aspose.Slides vers celles‑ci :

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licence dans un conteneur**

N’intégrez pas le fichier de licence dans l’image — quiconque tire l’image obtient la licence. Montez‑le au moment de l’exécution :

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Sans licence, la bibliothèque s’exécute en mode d’évaluation, ce qui ajoute un filigrane et limite le nombre de diapositives traitées. Voir [Licensing](/slides/fr/python-net/licensing/) pour plus de détails.

## **Mémoire**

Le rendu en PDF ou en images consomme plus de mémoire que la lecture d’un fichier. Les conteneurs avec des limites de mémoire strictes peuvent être arrêtés par le OOM killer au milieu d’une conversion, ce qui se manifeste généralement par la disparition du processus sans trace Python. Si cela se produit, augmentez la limite de mémoire du conteneur avant d’examiner le code.