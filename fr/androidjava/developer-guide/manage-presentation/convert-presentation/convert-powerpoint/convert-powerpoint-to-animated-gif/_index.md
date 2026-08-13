---
title: Convertir des présentations PowerPoint en GIF animés sur Android
linktitle: PowerPoint en GIF
type: docs
weight: 65
url: /fr/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- GIF animé
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en GIF
- présentation en GIF
- diapositive en GIF
- PPT en GIF
- PPTX en GIF
- enregistrer PPT en GIF
- enregistrer PPTX en GIF
- exporter PPT en GIF
- exporter PPTX en GIF
- paramètres par défaut
- paramètres personnalisés
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertissez facilement des présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides pour Android via Java. Résultats rapides et de haute qualité."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de convertir des présentations PowerPoint en fichiers GIF animés avec seulement quelques lignes de code. Ceci est utile lorsque vous devez partager le contenu des diapositives dans un format animé léger, largement pris en charge, qui peut être intégré aux pages Web, aux messageries ou à la documentation. Cet article explique comment exporter une présentation au format GIF en utilisant les paramètres par défaut et comment personnaliser la sortie en configurant des options telles que la taille du cadre, le délai entre les diapositives et le taux d'images de transition via [GifOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/gifoptions/).

## **Convertir des présentations en GIF animé en utilisant les paramètres par défaut**

Ce code d'exemple en Java montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Le GIF animé sera créé avec les paramètres par défaut.

{{%  alert  title="TIP"  color="info"  %}} 
Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/GifOptions). Voir le code d'exemple ci‑dessous.
{{% /alert %}} 

## **Convertir des présentations en GIF animé en utilisant des paramètres personnalisés**

Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en Java :

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // la taille du GIF résultant
	gifOptions.setDefaultDelay(2000); // durée d'affichage de chaque diapositive avant de passer à la suivante
	gifOptions.setTransitionFps(35); // augmenter les FPS pour une meilleure qualité d'animation de transition
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Vous pourriez être intéressé par un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) développé par Aspose. 
{{% /alert %}}

## **FAQ**

### Que faire si les polices utilisées dans la présentation ne sont pas installées sur le système ?

Installez les polices manquantes ou [configurer les polices de secours](/slides/fr/androidjava/powerpoint-fonts/). Aspose.Slides les remplacera, mais l’apparence peut différer. Pour le branding, assurez‑vous toujours que les polices requises sont explicitement disponibles.

### Puis‑je superposer un filigrane sur les cadres du GIF ?

Oui. [Ajoutez un objet/logo semi‑transparent](/slides/fr/androidjava/watermark/) à la diapositive maîtresse ou aux diapositives individuelles avant l’exportation — le filigrane apparaîtra sur chaque cadre.