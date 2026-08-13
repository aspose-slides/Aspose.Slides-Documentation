---
title: Convertir les présentations PowerPoint en GIF animés en Java
linktitle: PowerPoint en GIF
type: docs
weight: 65
url: /fr/java/convert-powerpoint-to-animated-gif/
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
- Java
- Aspose.Slides
description: "Convertissez facilement les présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides pour Java. Résultats rapides et de haute qualité."
---
## **Aperçu**

Aspose.Slides vous permet de convertir des présentations PowerPoint en fichiers GIF animés en quelques lignes de code seulement. C’est utile lorsque vous devez partager le contenu des diapositives dans un format animé léger et largement supporté, pouvant être intégré aux pages Web, aux messageries ou à la documentation. Cet article explique comment exporter une présentation au format GIF avec les paramètres par défaut et comment personnaliser le résultat en configurant des options telles que la taille du cadre, le délai entre les diapositives et le taux de rafraîchissement des transitions via [GifOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/gifoptions/).

## **Convertir des présentations en GIF animé avec les paramètres par défaut**

Ce code d’exemple en Java montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :

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

Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/GifOptions). Voir le code d’exemple ci‑dessous. 

{{% /alert %}} 

## **Convertir des présentations en GIF animé avec des paramètres personnalisés**

Ce code d’exemple montre comment convertir une présentation en GIF animé avec des paramètres personnalisés en Java :

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

Vous pouvez tester un convertisseur GRATUIT [Texte en GIF](https://products.aspose.app/slides/fr/text-to-gif) développé par Aspose. 

{{% /alert %}}

## **FAQ**

### Que faire si les polices utilisées dans la présentation ne sont pas installées sur le système ?

Installez les polices manquantes ou [configure fallback fonts](/slides/fr/java/powerpoint-fonts/). Aspose.Slides les remplacera, mais l’aspect peut différer. Pour l’image de marque, assurez‑vous toujours que les fontes requises sont explicitement disponibles.

### Puis‑je superposer un filigrane sur les cadres du GIF ?

Oui. [Add a semi-transparent object/logo](/slides/fr/java/watermark/) à la diapositive maître ou aux diapositives individuelles avant l’exportation — le filigrane apparaîtra sur chaque cadre.