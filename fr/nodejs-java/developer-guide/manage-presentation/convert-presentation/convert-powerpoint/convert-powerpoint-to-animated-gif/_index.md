---
title: Convertir PowerPoint en GIF animé
type: docs
weight: 65
url: /fr/nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint en GIF animé, PPT en GIF, PPTX en GIF"
description: "Convertir PowerPoint en GIF animé: PPT en GIF, PPTX en GIF, avec l'API Aspose.Slides."
---

## **Conversion de présentations en GIF animé avec les paramètres par défaut**

Ce code d'exemple en JavaScript montre comment convertir une présentation en GIF animé en utilisant les paramètres standards :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Le GIF animé sera créé avec les paramètres par défaut. 

{{%  alert  title="TIP"  color="primary"  %}} 
Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions). Voir le code d'exemple ci‑dessous.
{{% /alert %}} 

## **Conversion de présentations en GIF animé avec des paramètres personnalisés**

Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en JavaScript :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// la taille du GIF résultant
    gifOptions.setDefaultDelay(2000);// la durée d'affichage de chaque diapositive avant de passer à la suivante
    gifOptions.setTransitionFps(35);// augmenter les FPS pour une meilleure qualité d'animation de transition
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
Vous voudrez peut‑être découvrir un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 
{{% /alert %}}

## **FAQ**

**Que faire si les polices utilisées dans la présentation ne sont pas installées sur le système ?**  
Installez les polices manquantes ou [configurez les polices de secours](/slides/fr/nodejs-java/powerpoint-fonts/). Aspose.Slides effectuera une substitution, mais l’apparence peut différer. Pour le branding, assurez‑vous toujours que les polices requises sont explicitement disponibles.

**Puis‑je superposer un filigrane sur les images du GIF ?**  
Oui. [Ajoutez un objet/logo semi‑transparent](/slides/fr/nodejs-java/watermark/) à la diapositive maîtresse ou aux diapositives individuelles avant l’exportation — le filigrane apparaîtra sur chaque image.