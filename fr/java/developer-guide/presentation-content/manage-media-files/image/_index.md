---
title: Optimiser la gestion des images dans les présentations en Java
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/java/image/
keywords:
- ajouter une image
- ajouter une photo
- remplacer une image
- collection d'images
- cadre d'image
- image liée
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- SVG en formes
- ressources SVG externes
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment ajouter, réutiliser, lier, remplacer et gérer les images raster et SVG dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Java."
---
## **Introduction**

Aspose.Slides for Java propose plusieurs manières de travailler avec des images, chacune servant à un objectif différent. Vous pouvez stocker une image dans une présentation, l'afficher dans un cadre d'image, l'utiliser comme arrière‑plan de diapositive, créer un lien vers une image externe, remplacer une ressource d'image partagée ou convertir le contenu SVG en formes modifiables.

Cet article se concentre sur les ressources d'image et sur leur utilisation dans une présentation. Pour le recadrage, la transparence, les effets, l'étirement et tout autre formatage appliqué à un cadre d'image individuel, consultez [Cadre d'image](/slides/fr/java/picture-frame/).

## **Comprendre le modèle d'image**

Les concepts d'API suivants sont étroitement liés mais non interchangeables :

- La [collection d'images de présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides.iimagecollection/) stocke les ressources d'image utilisées par la présentation. Utilisez [ImageCollection.addImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imagecollection/) pour ajouter des données d'image et obtenir une ressource [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ippimage/).
- Un [cadre d'image](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ipictureframe/) est une forme qui affiche une image sur une diapositive, une disposition ou un masque. Utilisez [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ishapecollection/) pour placer une ressource d'image sur une diapositive.
- Un arrière‑plan de diapositive utilise une image comme partie du remplissage de la diapositive plutôt que comme forme. Il ne se comporte donc pas comme un cadre d'image.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ippimage/) remplace une ressource d'image. Si plusieurs éléments de la présentation utilisent cette ressource, ils utilisent tous le remplacement.
- La conversion d'un SVG en formes crée des formes de diapositive modifiables. Après conversion, le contenu n'est plus géré comme une seule ressource d'image.

Un flux de travail typique est donc : ajouter les données d'image à la collection d'images, recevoir un [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ippimage/), puis utiliser cette ressource dans un ou plusieurs cadres d'image ou remplissages.

## **Ajouter une image incorporée**

Pour insérer une image locale, chargez le fichier, ajoutez‑le à la collection d'images et créez un cadre d'image qui utilise le `IPPImage` retourné.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'image ajoutée de cette manière est incorporée dans la présentation, de sorte que le fichier résultant ne dépend pas de la disponibilité continue du fichier image original.

### **Ajouter une image depuis le Web**

Lorsqu'une image est disponible via HTTP ou HTTPS, téléchargez ses octets, ajoutez‑les à la collection d'images de la présentation et utilisez la ressource d'image retournée de la même façon qu'une image locale.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dans les applications de longue durée, réutilisez un client HTTP ou une stratégie de gestion des connexions adaptée à l'application plutôt que de créer à plusieurs reprises une infrastructure réseau inutile. Validez également les URL distantes, les tailles de réponse et les types de contenu lorsque la source n'est pas fiable.

## **Réutiliser les images sur plusieurs diapositives**

Si la même image est nécessaire plusieurs fois, ajoutez‑la à la présentation une seule fois et réutilisez le [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ippimage/) retourné lors de la création de cadres d'image supplémentaires. Cela évite de charger à plusieurs reprises les mêmes données source et rend explicite la relation entre la ressource d'image partagée et ses utilisations.

Pour les graphiques qui doivent apparaître automatiquement sur de nombreuses diapositives, comme le logo d'une société, envisagez de placer le cadre d'image sur un [masque de diapositive](/slides/fr/java/slide-master/) ou une disposition plutôt que d'ajouter une forme équivalente à chaque diapositive.

## **Utiliser une image comme arrière‑plan de diapositive**

Une image d'arrière‑plan est affectée au remplissage de la diapositive ; elle n'est pas ajoutée comme forme de cadre d'image. Cela est utile lorsque l'image doit couvrir l'arrière‑plan de la diapositive et ne doit pas être manipulée comme un objet de diapositive ordinaire.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour des options d'arrière‑plan supplémentaires, y compris les arrière‑plans de masques et de dispositions, consultez [Arrière‑plan de présentation](/slides/fr/java/presentation-background/).

## **Images incorporées et images liées**

Les images incorporées et les images liées présentent des compromis différents en termes de portabilité et de taille de fichier :

- **Image incorporée ** : les données de l'image sont stockées à l'intérieur de la présentation. La présentation est autonome, mais la taille du fichier inclut les données de l'image.
- **Image liée ** : la présentation stocke un chemin ou une URL vers une image externe. Cela peut réduire la taille de la présentation, mais la ressource externe doit rester accessible lorsque la présentation est ouverte ou rendue.

Une image liée peut être créée en attribuant le chemin externe ou l'URL via [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fr/java/com.aspose.slides.islidespicture/) plutôt qu'en incorporant les données de l'image.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez les images liées uniquement lorsque l'environnement de déploiement peut accéder de manière fiable à la ressource externe. Pour des présentations qui doivent fonctionner hors ligne ou être déplacées entre systèmes, les images incorporées sont généralement plus sûres.

## **Travailler avec des images SVG**

SVG est un format vectoriel, il peut donc être utile pour les icônes, les diagrammes et d'autres graphiques qui doivent être redimensionnés sans perte de détail comparable aux images raster. Aspose.Slides prend en charge SVG à la fois comme ressource d'image et comme source de formes de diapositive modifiables.

### **Ajouter un SVG comme image**

Créez un [SvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.svgimage/), ajoutez‑le à la collection d'images et placez la ressource d'image résultante dans un cadre d'image.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Fichiers SVG avec ressources externes**

Un SVG peut référencer des images, des feuilles de style ou des polices externes. Dans ces cas, [SvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.svgimage/) propose des constructeurs qui acceptent un [IExternalResourceResolver](https://reference.aspose.com/slides/fr/java/com.aspose.slides.iexternalresourceresolver/) et une URI de base. Le résolveur peut mapper une URI relative à une URI absolue autorisée et renvoyer un flux pour la ressource demandée.

Le résolveur rend les ressources externes disponibles pendant qu'Aspose.Slides traite le SVG, mais il ne réécrit pas le SVG en un document autonome. Si le SVG doit rester portable, incorporez ses ressources requises directement dans le SVG, par exemple en utilisant des URI `data:` pour les images liées.

Lorsque les fichiers SVG proviennent de sources non fiables, limitez les schémas, emplacements de fichiers et hôtes que le résolveur peut accéder. Les résolveurs réseau doivent également appliquer des délais d’attente, des limites de taille de réponse et une validation du contenu.

### **Convertir un SVG en formes modifiables**

Aspose.Slides peut convertir un SVG en un groupe de formes de diapositive modifiables, similaire à la commande PowerPoint correspondante.

![PowerPoint Popup Menu](img_01_01.png)

Utilisez la surcharge de [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ishapecollection/) qui accepte un [ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.isvgimage/) pour effectuer la conversion.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez la conversion SVG‑vers‑formes lorsque des éléments vectoriels individuels doivent être modifiés comme des formes PowerPoint. Si le SVG ne doit être affiché que, le conserver comme image est plus simple et évite de créer de nombreuses formes séparées.

## **Remplacer une ressource d'image existante**

Utilisez [IPPImage.replaceImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ippimage/) lorsque vous souhaitez remplacer une ressource d'image existante. Ceci est particulièrement utile pour les graphiques partagés tels que les logos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si plusieurs cadres d'image, arrière‑plans, masques ou dispositions utilisent la même ressource d'image, la remplacer met à jour toutes ces utilisations. Si seul un cadre d'image doit être modifié, attribuez une image différente à ce cadre au lieu de remplacer la ressource partagée.

`replaceImage` propose également des surcharges qui acceptent un tableau d'octets ou un autre [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ippimage/).

## **Guide pratique de gestion d'images**

### **Contrôler la taille de la présentation**

Les grandes images raster peuvent rendre une présentation inutilement volumineuse. Utilisez des images sources avec des dimensions appropriées à la taille d’affichage prévue, réutilisez les ressources d'image partagées lorsque c’est possible et évitez d’incorporer des copies répétées du même graphique en pleine résolution.

Pour les images raster déjà placées dans des cadres d'image, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ipicturefillformat/) peut réduire les données d'image selon la résolution sélectionnée et les paramètres de recadrage. Il s'agit d'un traitement de cadre d'image plutôt que d'une gestion de la collection d'images, consultez donc [Picture Frame](/slides/fr/java/picture-frame/) pour les opérations de formatage associées.

### **Choisir entre le contenu incorporé et lié**

L'incorporation rend la présentation portable car toutes les données d'image nécessaires voyagent avec le fichier. Le lien peut réduire la taille du fichier, mais il introduit une dépendance externe. N'utilisez les liens que lorsque cette dépendance est acceptable et stable.

### **Réutiliser les éléments de marque partagés**

Pour les logos, filigranes ou graphiques décoratifs répétés, utilisez une seule ressource d'image et réutilisez‑la. Si le graphique appartient à la conception de la présentation plutôt qu'au contenu des diapositives, placez‑le sur un masque ou une disposition afin qu'il soit hérité par les diapositives appropriées.

### **Conserver la portabilité des ressources SVG**

Un SVG autonome est plus facile à déplacer et à rendre de façon cohérente qu'un SVG qui dépend de fichiers ou de ressources réseau externes. Lorsque possible, incorporez les ressources requises avant d'importer le SVG. Convertissez le SVG en formes uniquement lorsque les éléments vectoriels individuels doivent être édités.

### **Utiliser l'API d'image multiplateforme moderne**

Pour le nouveau code Java, utilisez les API Aspose.Slides [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.iimage/) et [Images](https://reference.aspose.com/slides/fr/java/com.aspose.slides.images/) au lieu de l’ancienne API publique basée sur `java.awt.image.BufferedImage`. Consultez [Modern API](/slides/fr/java/modern-api/) pour les conseils de migration.

WMF et EMF nécessitent une prise en compte particulière. Lorsque ces formats sont transmis via un [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.imagecollection/) convertit le métafichier en une représentation PNG raster avant l’insertion. Si la préservation des données du métafichier est importante, utilisez plutôt la surcharge basée sur un flux de [ImageCollection.addImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.imagecollection/). La génération de contenu EMF à partir de feuilles de calcul ou d’autres produits constitue un flux d’intégration distinct et dépasse le cadre de cet article.

## **FAQ**

**Quelle est la différence entre la collection d'images et un cadre d'image ?**

La collection d'images stocke des ressources d'image réutilisables. Un cadre d'image est une forme de diapositive qui affiche l'une de ces ressources et offre un formatage propre à l'image, tel que le recadrage et les effets.

**Quelle est la meilleure façon de remplacer le même logo partout ?**

Si le logo est déjà partagé comme une unique ressource d'image, remplacez cette ressource avec [IPPImage.replaceImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ippimage/). Pour une image de marque sur l’ensemble de la présentation, placer le logo sur un masque ou une disposition peut également réduire le contenu dupliqué des diapositives.

**Pourquoi une image liée disparaît‑elle sur un autre ordinateur ?**

Une image liée dépend de son fichier ou URL externe. Si cette ressource n’est pas accessible depuis l’autre ordinateur, l’image liée peut être indisponible. Incorporez l’image lorsque la présentation doit être autonome.

**Une SVG insérée peut‑elle être modifiée comme des formes PowerPoint ?**

Oui. Convertissez le SVG avec [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides.ishapecollection/); le groupe résultant contient des formes de diapositive modifiables plutôt qu’une seule image SVG.

**Comment garder les présentations contenant de nombreuses images plus petites ?**

Réutilisez les ressources d'image partagées, évitez les sources raster inutilement grandes, compressez les images raster appropriées lorsque cela est pertinent, conservez les éléments de marque répétés sur les masques ou les dispositions, et n’utilisez des images liées que lorsqu’une dépendance externe est acceptable.