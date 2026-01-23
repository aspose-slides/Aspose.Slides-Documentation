---
title: Extraire des images des formes de présentation
linktitle: Image depuis la forme
type: docs
weight: 100
url: /fr/php-java/extracting-images-from-presentation-shapes/
keywords:
- extraction d'image
- récupération d'image
- arrière-plan de diapositive
- arrière-plan de forme
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java — solution rapide et conviviale pour le code."
---

## **Extraire des images des formes**

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière‑plans des diapositives. Les objets image sont ajoutés via [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/), qui est une collection d’objets [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).

Cet article explique comment extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d’une présentation, vous devez d’abord localiser l’image en parcourant chaque diapositive puis chaque forme. Une fois l’image trouvée ou identifiée, vous pouvez l’extraire et l’enregistrer comme un nouveau fichier. 
```php

```


## **FAQ**

**Puis‑je extraire l’image originale sans aucun rognage, effet ou transformation de forme ?**

Oui. Lorsque vous accédez à l’image d’une forme, vous obtenez l’objet image provenant de la collection d’images de la présentation, c’est‑à‑dire les pixels d’origine sans rognage ni effets de style. Le flux de travail parcourt la collection d’images de la présentation et les objets [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), qui stockent les données brutes.

**Existe‑t‑il un risque de dupliquer des fichiers identiques lors de l’enregistrement de nombreuses images en même temps ?**

Oui, si vous enregistrez tout sans discernement. La collection d’images d’une présentation peut contenir des données binaires identiques référencées par différentes formes ou diapositives. Pour éviter les doublons, comparez les hachages, les tailles ou le contenu des données extraites avant l’écriture.

**Comment déterminer quelles formes sont liées à une image spécifique de la collection de la présentation ?**

Aspose.Slides ne stocke pas de liens inverses des [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) vers les formes. Créez une correspondance manuellement pendant le parcours : chaque fois que vous trouvez une référence à un [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), enregistrez les formes qui l’utilisent.

**Puis‑je extraire les images incorporées dans des objets OLE, comme des documents joints ?**

Pas directement, car un objet OLE est un conteneur. Vous devez extraire le package OLE lui‑même, puis analyser son contenu avec des outils séparés. Les formes d’image de présentation fonctionnent via [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE est un type d’objet différent.