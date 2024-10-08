---
title: Convertir PowerPoint en GIF animé
type: docs
weight: 65
url: /fr/java/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint en GIF animé, PPT en GIF, PPTX en GIF"
description: "Convertir PowerPoint en GIF animé : PPT en GIF, PPTX en GIF, avec l'API Aspose.Slides."
---

## Conversion de présentations en GIF animé en utilisant les paramètres par défaut ##

Ce code exemple en Java montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Le GIF animé sera créé avec des paramètres par défaut. 

{{%  alert  title="ASTUCE"  color="primary"  %}} 

Si vous préférez personnaliser les paramètres pour le GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions). Voir le code exemple ci-dessous. 

{{% /alert %}} 

## Conversion de présentations en GIF animé en utilisant des paramètres personnalisés ##
Ce code exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // la taille du GIF résultant  
	gifOptions.setDefaultDelay(2000); // combien de temps chaque diapositive sera affichée avant de passer à la suivante
	gifOptions.setTransitionFps(35); // augmenter les FPS pour une meilleure qualité d'animation de transition
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Vous voudrez peut-être consulter un convertisseur GRATUIT [Texte en GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 

{{% /alert %}}