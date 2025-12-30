---
title: Extraire des images à partir des formes de présentation
linktitle: Image depuis forme
type: docs
weight: 100
url: /fr/php-java/extracting-images-from-presentation-shapes/
keywords:
- "extraction d'image"
- "récupérer l'image"
- "arrière-plan de diapositive"
- "arrière-plan de forme"
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Extraire des images à partir de formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java — solution rapide et conviviale pour le code."
---

## **Extraire des images à partir de formes**

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et également fréquemment utilisées comme arrière‑plans des diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/iimagecollection/), qui est une collection d’objets [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) .

Cet article explique comment extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d’une présentation, vous devez d’abord localiser l’image en parcourant chaque diapositive, puis chaque forme. Une fois l’image trouvée ou identifiée, vous pouvez l’extraire et l’enregistrer comme un nouveau fichier. 
```php

```


## **FAQ**

**Puis‑je extraire l'image originale sans aucun recadrage, effet ou transformation de forme ?**

Oui. Lorsque vous accédez à l'image d’une forme, vous obtenez l’objet image de la présentation’s [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/), ce qui signifie les pixels originaux sans recadrage ni effets de style. Le flux de travail parcourt la collection d’images de la présentation et les objets [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), qui stockent les données brutes.

**Existe‑t‑il un risque de dupliquer des fichiers identiques lors de la sauvegarde de nombreuses images à la fois ?**

Oui, si vous enregistrez tout sans discernement. La présentation’s [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) peut contenir des données binaires identiques référencées par différentes formes ou diapositives. Pour éviter les doublons, comparez les hachages, les tailles ou le contenu des données extraites avant l’écriture.

**Comment déterminer quelles formes sont liées à une image spécifique de la collection de la présentation ?**

Aspose.Slides ne stocke pas de liens inversés de [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) vers les formes. Créez une correspondance manuellement pendant le parcours : chaque fois que vous trouvez une référence à un [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), enregistrez les formes qui l’utilisent.

**Puis‑je extraire les images intégrées dans des objets OLE, tels que des documents attachés ?**

Pas directement, car un objet OLE est un conteneur. Vous devez d’abord extraire le package OLE lui‑même, puis analyser son contenu avec des outils séparés. Les formes d’image des présentations fonctionnent via [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) ; OLE est un type d’objet différent.