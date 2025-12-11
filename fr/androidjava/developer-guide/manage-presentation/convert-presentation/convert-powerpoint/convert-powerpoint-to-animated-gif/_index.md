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
description: "Convertir facilement des présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides pour Android via Java. Résultats rapides et de haute qualité."
---

## **Convertir des présentations en GIF animé avec les paramètres par défaut**

Ce code d'exemple en Java montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


Le GIF animé sera créé avec les paramètres par défaut. 

{{%  alert  title="TIP"  color="primary"  %}} 
Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions). Voir le code d'exemple ci‑dessous.
{{% /alert %}} 

## **Convertir des présentations en GIF animé avec des paramètres personnalisés**

Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en Java :
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // la taille du GIF résultant  
	gifOptions.setDefaultDelay(2000); // durée d'affichage de chaque diapositive avant le passage à la suivante
	gifOptions.setTransitionFps(35); // augmenter le FPS pour une meilleure qualité d'animation de transition
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}
Vous pourriez être intéressé par le convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 
{{% /alert %}}

## **FAQ**

**Et si les polices utilisées dans la présentation ne sont pas installées sur le système ?**

Installez les polices manquantes ou [configurez les polices de repli](/slides/fr/androidjava/powerpoint-fonts/). Aspose.Slides les remplacera, mais l’apparence peut différer. Pour l’image de marque, assurez‑vous toujours que les polices requises sont explicitement disponibles.

**Puis‑je superposer un filigrane sur les images du GIF ?**

Oui. [Ajoutez un objet/logo semi‑transparent](/slides/fr/androidjava/watermark/) à la diapositive maître ou aux diapositives individuelles avant l’exportation — le filigrane apparaîtra sur chaque image.