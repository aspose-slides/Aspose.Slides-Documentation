---
title: "Extraction de texte de diapositives : bases PPT, PPTX, ODP"
type: docs
weight: 10
url: /fr/python-java/slide-text-extraction-ppt-pptx-odp-essentials/
keywords:
- plateformes cloud
- extraction de texte de présentation
- extraction de texte de diapositive
- extraire le texte d'un PPT
- extraire le texte d'un PPTX
- extraire le texte d'un ODP
- Microsoft PowerPoint
- OpenDocument
- LibreOffice Impress
- Office Open XML
- indexation de recherche
- automatisation de documents
- analyse de données
- accessibilité
- Python
- Aspose.Slides
description: "Comprenez comment PPT, PPTX et ODP stockent le texte des diapositives et planifiez son extraction pour la recherche, l'automatisation et la localisation avec Aspose.Slides pour Python via Java."
---
## **Introduction**

L’extraction du texte d’une présentation rend le contenu des diapositives disponible pour la recherche, l’analyse, l’accessibilité et la localisation. Dans une application Python, le texte extrait peut alimenter un index, un système de gestion de documents ou un pipeline de traitement linguistique. Les workers cloud peuvent appliquer le même flux de travail aux fichiers reçus par téléchargement ou stockage d’objets.

Cet article explique comment les formats PPT, PPTX et ODP stockent le texte et comment ces différences influent sur l’extraction. Aspose.Slides for Python via Java prend en charge le chargement des trois formats ; voir [Formats de fichiers pris en charge](/slides/fr/python-java/supported-file-formats/).

## **Applications pratiques de l’extraction de texte**

- **Flux de travail documentaires :** importer le contenu des présentations dans des systèmes de gestion de documents et l’associer aux métadonnées du fichier source.  
- **Indexation de recherche :** indexer le texte des diapositives tout en conservant le nom de la présentation et le numéro de diapositive pour chaque résultat.  
- **Analyse de contenu :** identifier les sujets, les termes et les thèmes récurrents dans les archives de présentations.  
- **Accessibilité et localisation :** fournir le texte aux outils d’assistance ou aux flux de travail de traduction, avec une révision supplémentaire de l’ordre de lecture et du contexte.  
- **Analyse de mise en page :** associer le texte aux positions des objets lors de la vérification de la structure des diapositives ou de la préparation d’une exportation structurée.

## **Vue d’ensemble des formats de présentation**

### **PPT : format PowerPoint hérité**

PPT est le format binaire associé à PowerPoint 97‑2003. Ses enregistrements ne peuvent pas être traités comme des documents XML. Un analyseur doit comprendre les structures binaires et leurs relations pour reconstruire le contenu des diapositives.

Le texte peut se trouver dans les objets de diapositives, les notes et les commentaires. Un flux d’extraction doit définir quelles sources sont incluses, plutôt que de traiter une présentation comme un flux de texte continu.

### **PPTX : Office Open XML**

PPTX est un paquet ZIP contenant des parties XML et d’autres ressources. Le texte des diapositives apparaît généralement dans `ppt/slides/fr/slideX.xml` à l’intérieur des éléments `a:t`. Les notes sont stockées dans des parties séparées notes‑slide, et les commentaires possèdent leurs propres parties reliées via les relations du paquet.

Lire uniquement les éléments de texte du XML des diapositives peut laisser de côté du contenu stocké ailleurs dans le paquet. Cela ne reconstruit pas non plus le formatage ou l’ordre de lecture. Un flux complet peut devoir prendre en compte les mises en page, les formes groupées, les tableaux, les graphiques et les parties associées.

### **ODP : OpenDocument Presentation**

ODP est le format de présentation OpenDocument empaqueté utilisé par des applications comme LibreOffice Impress. Comme PPTX, il contient du XML dans un paquet ZIP, mais il utilise le vocabulaire et la structure OpenDocument.

Le contenu de la présentation est principalement stocké dans `content.xml`. Le texte des paragraphes utilise des éléments tels que `text:p`, avec des éléments imbriqués pour les spans et autres fonctionnalités textuelles. Les requêtes XML spécifiques à PPTX ne peuvent donc pas être réutilisées directement pour ODP.

## **Utiliser un modèle de présentation commun en Python**

La classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) charge les fichiers de présentation pris en charge afin que le code de l’application puisse travailler avec les diapositives et leurs objets sans implémenter de parseur de paquet ou binaire distinct pour chaque format.

Avant d’intégrer l’extraction dans un worker cloud, suivez [Installation](/slides/fr/python-java/installation/). Pour le déploiement et les considérations du cycle de vie du JVM, voir [Slides sur les plates‑formes cloud](/slides/fr/python-java/slides-on-cloud-platforms/).

Gardez ces décisions explicites dans la conception de l’extraction :

- **Portée du contenu :** décider comment gérer le texte des diapositives, les notes, les commentaires, les tableaux et les libellés de graphiques.  
- **Ordre de lecture :** préserver les limites des diapositives et utiliser les informations de mise en page lorsque l’ordre des objets est insuffisant.  
- **Texte dans les images :** recourir à un flux OCR séparé lorsque le texte est intégré dans des captures d’écran ou des diapositives numérisées.  
- **Structure de sortie :** conserver les identifiants source et écrire le texte avec un encodage qui prend en charge les langues requises, tel que UTF‑8.

## **Conclusion**

PPT nécessite une prise en charge du format binaire, tandis que PPTX et ODP utilisent des structures de paquets XML différentes. Une bibliothèque de présentation fournit un point de départ commun pour travailler avec ces formats en Python. Définir la portée du contenu et l’ordre de lecture aide à rendre le texte résultant exploitable pour l’indexation, l’analyse et la localisation.

## **FAQ**

**Puis‑je extraire le texte d’un PPT en décompressant le fichier ?**

Non. PPT utilise une structure binaire. L’approche ZIP‑et‑XML s’applique aux formats empaquetés tels que PPTX et ODP.

**Les notes et les commentaires sont‑ils stockés avec le texte principal de la diapositive dans PPTX ?**

Ils utilisent des parties de paquet séparées. Lire uniquement le XML des diapositives ne les inclut pas automatiquement.

**L’extraction de texte brut capturera‑t‑elle le texte à l’intérieur d’une capture d’écran ?**

Non. Le texte d’une capture d’écran fait partie d’une image plutôt que du texte éditable d’une diapositive. Il nécessite un OCR.