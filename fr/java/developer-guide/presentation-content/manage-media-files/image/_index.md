---
title: Optimiser la gestion des images dans les présentations avec Java
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/java/image/
keywords:
- ajouter une image
- ajouter une image
- ajouter un bitmap
- remplacer une image
- remplacer une image
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ressources SVG externes
- résolveur SVG
- images SVG liées
- polices SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour Java, en optimisant les performances et en automatisant votre flux de travail."
---
## **Introduction**

Les images rendent les présentations plus attrayantes et visuellement séduisantes. Dans Microsoft PowerPoint, vous pouvez insérer des images sur les diapositives à partir de fichiers, d'Internet ou d'autres sources. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de présentation de plusieurs manières.

{{% alert  title="Tip" color="primary" %}} 

Aspose propose des convertisseurs gratuits —[JPEG to PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt) —qui vous permettent de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant que cadre d'image —en particulier si vous prévoyez de la redimensionner, d'appliquer des effets ou d'utiliser d'autres options de mise en forme standard—voir [Picture Frame](/slides/fr/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez convertir des images d’un format à un autre. Consultez les pages suivantes : convertissez [image to JPG](https://products.aspose.com/slides/fr/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/fr/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/fr/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/fr/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/fr/java/conversion/png-to-svg/), et [SVG to PNG](https://products.aspose.com/slides/fr/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les images dans les formats populaires tels que JPEG, PNG, BMP, GIF et d’autres.

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images stockées sur votre ordinateur à une diapositive de présentation. Le code d'exemple Java suivant montre comment ajouter une image à une diapositive :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ajouter des images depuis le Web aux diapositives**

Si l'image que vous souhaitez ajouter à une diapositive n'est pas stockée sur votre ordinateur, vous pouvez l'ajouter directement depuis le Web. 

Le code d'exemple Java suivant montre comment ajouter une image depuis le Web à une diapositive :

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Ajouter des images aux maîtres de diapositives**

Un maître de diapositive stocke et contrôle des informations telles que le thème et la mise en page des diapositives qui l'utilisent. Lorsque vous ajoutez une image à un maître de diapositive, l'image apparaît sur chaque diapositive basée sur ce maître. 

Le code d'exemple Java suivant montre comment ajouter une image à un maître de diapositive :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ajouter des images comme arrière-plans de diapositives**

Vous pouvez utiliser une image comme arrière-plan pour une ou plusieurs diapositives. Pour plus de détails, voir *[Setting Images as Backgrounds for Slides](/slides/fr/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter des SVG aux présentations**

Le contenu SVG peut être ajouté à une présentation à l'aide de la classe [SvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgimage/). L'objet [ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/) résultant peut ensuite être ajouté à la collection d'images de la présentation et utilisé pour créer un cadre d'image.

L'exemple Java suivant importe une chaîne SVG autonome. Toutes les images, styles et autres ressources utilisés par ce SVG sont intégrés directement dans le contenu SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importer du contenu SVG avec des ressources externes**

Les fichiers SVG exportés depuis des outils de conception, éditeurs de diagrammes, systèmes d'icônes et pipelines web peuvent référencer des ressources stockées en dehors du document SVG. Par exemple, un SVG peut contenir un lien d'image tel que `images/photo.png`, une valeur CSS `url(...)` ou une URL de police.

Pour importer ce type de contenu SVG, créez une implémentation de [IExternalResourceResolver](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iexternalresourceresolver/) et transmettez-la, avec une URI de base, à un constructeur approprié de [SvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgimage/). L'URI de base identifie l'emplacement du document SVG et est utilisée pour résoudre les liens relatifs.

L'interface [ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/) fournit l'accès aux informations sur le SVG importé :

- `getSvgContent()` renvoie le balisage SVG sous forme de chaîne.
- `getSvgData()` renvoie le contenu SVG sous forme de tableau d'octets.
- `getBaseUri()` renvoie l'URI de base utilisée pour les liens relatifs.
- `getExternalResourceResolver()` renvoie le résolveur assigné à l'image SVG.

### **Implémenter un résolveur de ressources externes**

Le résolveur possède deux méthodes :

- `resolveUri` combine l'URI de base et un lien de ressource relatif et renvoie une URI absolue. Retournez `null` lorsque le lien ne peut pas être résolu ou n'est pas autorisé.
- `getEntity` renvoie un flux lisible pour une URI de ressource absolue. Retournez `null` lorsque la ressource est manquante, bloquée ou indisponible. Un flux de secours peut également être renvoyé le cas échéant.

Le résolveur suivant charge les ressources liées uniquement depuis un répertoire local autorisé. Les ressources réseau et les chemins en dehors du répertoire autorisé sont bloqués. Une image de secours optionnelle est renvoyée pour les liens d'image non résolus.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Ce résolveur autorise intentionnellement uniquement les fichiers locaux.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Utilisez un fallback uniquement pour les ressources d'image.
            // Retourner un flux d'image pour une police ou une feuille de style manquante ne serait pas valide.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Résoudre les ressources liées lors de l'importation SVG**

Supposons que `assets/diagram.svg` contienne une référence relative telle que :

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

L'exemple Java suivant transmet l'URI du fichier SVG comme URI de base et fournit un résolveur personnalisé. Le résolveur convertit le lien d'image relatif en une URI absolue et renvoie un flux contenant la ressource liée pendant qu'Aspose.Slides traite le SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// L'URI de base représente l'emplacement du document SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe `SvgImage` propose également des surcharges qui acceptent les données SVG sous forme de tableau d'octets ou de flux d'entrée, ainsi qu'un résolveur de ressources externes et une URI de base.

{{% alert title="Important" color="warning" %}}

Le résolveur de ressources rend les ressources externes disponibles pendant qu'Aspose.Slides traite et rend le SVG. Il ne modifie pas le balisage SVG original ni n'intègre automatiquement les ressources résolues.

Lorsqu'un `ISvgImage` est ajouté à la collection d'images de la présentation, le fichier PPTX peut contenir à la fois la représentation SVG originale et une image raster de secours. Une ressource liée peut apparaître dans l'image de secours générée tandis qu'un lien relatif tel que `images/photo.png` reste inchangé dans le SVG stocké. Une application qui rend la représentation SVG native peut donc omettre le contenu lié lorsque la ressource externe originale n'est pas disponible.

{{% /alert %}}

### **Créer une image SVG portable**

Pour créer une image SVG qui ne dépend pas de fichiers externes, rendez le SVG autonome avant de créer le `SvgImage`. Par exemple, remplacez les URL d'images liées par des URI `data:` contenant les données de l'image :

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Une fois toutes les ressources requises intégrées dans le contenu SVG, créez le `SvgImage`, ajoutez-le à la collection d'images de la présentation et insérez-le dans un cadre d'image comme indiqué dans l'exemple précédent.

### **Gérer les ressources manquantes ou bloquées**

Retournez `null` depuis `resolveUri` lorsqu'une URI de ressource est invalide, interdite ou ne peut pas être résolue. Retournez `null` depuis `getEntity` lorsque la ressource ne peut pas être lue. Aspose.Slides poursuit le traitement du SVG sans cette ressource lorsque cela est possible.

Un flux de secours peut être renvoyé pour une ressource manquante, mais son contenu doit être compatible avec le type de ressource demandé. Par exemple, renvoyez un flux d'image uniquement pour une image manquante, pas pour une police ou une feuille de style.

{{% alert title="Security" color="warning" %}}

Ne résolvez pas de chemins de fichiers arbitraires ni d'URL réseau non restreintes provenant de fichiers SVG non fiables. Restreignez les schémas, répertoires et hôtes autorisés. Pour les ressources réseau, appliquez également des délais d'attente de connexion, des limites de taille de réponse et une validation du contenu.

{{% /alert %}}

## **Convertir un SVG en un ensemble de formes**

Aspose.Slides peut convertir un SVG en un ensemble de formes, similaire à la fonctionnalité correspondante dans PowerPoint :

![PowerPoint Popup Menu](img_01_01.png)

Cette fonctionnalité est fournie par une surcharge de la méthode [addGroupShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de l'interface [IShapeCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection) qui accepte un objet [ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISvgImage) comme premier argument.

Le code d'exemple Java suivant montre comment utiliser cette méthode pour convertir un fichier SVG en un ensemble de formes :

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nom du fichier SVG source.
String svgFileName = "sample.svg";

// Nom du fichier de présentation en sortie.
String outPptxPath = "presentation.pptx";

// Créer une nouvelle présentation.
IPresentation presentation = new Presentation();
try {
    // Lire le contenu du fichier SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Créer un objet SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtenir la taille de la diapositive.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Convertir l'image SVG en groupe de formes et la redimensionner à la taille de la diapositive.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Enregistrer la présentation au format PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Ajouter des images au format EMF aux diapositives**

Aspose.Slides for Java vous permet de générer des images EMF à partir de feuilles de calcul Excel avec Aspose.Cells et de les ajouter aux diapositives de la présentation.

Le code d'exemple Java suivant montre comment faire :

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Enregistrer le classeur dans un flux.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Ajouter le fichier tel quel afin que l'image reste un EMF vectoriel au lieu d'être rasterisée.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Remplacer des images dans la collection d'images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d'images d'une présentation, y compris les images utilisées par les formes de diapositives. Cette section décrit plusieurs manières de mettre à jour les images de la collection. Vous pouvez remplacer une image en utilisant des données binaires brutes, une instance [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/), ou une autre image déjà présente dans la collection.

Suivez les étapes ci-dessous :

1. Chargez le fichier de présentation contenant des images à l'aide de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Chargez une nouvelle image depuis un fichier dans un tableau d'octets.
3. Remplacez l'image cible par la nouvelle image en utilisant le tableau d'octets.
4. Dans la deuxième approche, chargez l'image dans un objet [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) et remplacez l'image cible par cet objet.
5. Dans la troisième approche, remplacez l'image cible par une image déjà présente dans la collection d'images de la présentation.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // La première façon.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // La deuxième façon.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // La troisième façon.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Enregistrer la présentation dans un fichier.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Avec le convertisseur gratuit [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) d'Aspose, vous pouvez facilement animer du texte et créer des GIF à partir de texte. 

{{% /alert %}}

## **FAQ**

**La résolution de l'image originale reste-t-elle intacte après l'insertion ?**

Oui. Les pixels d'origine sont conservés, mais l'apparence finale dépend de la façon dont le [picture](/slides/fr/java/picture-frame/) est mis à l'échelle sur la diapositive et de toute compression appliquée lors de l'enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives d'un coup ?**

Placez le logo sur la diapositive maître ou sur une mise en page et remplacez-le dans la collection d'images de la présentation —les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Une SVG insérée peut-elle être convertie en formes éditables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi les parties individuelles deviennent éditables avec les propriétés de forme standard.

**Comment définir une image comme arrière-plan pour plusieurs diapositives en même temps ?**

[Attribuez l'image comme arrière-plan](/slides/fr/java/presentation-background/) sur la diapositive maître ou la mise en page concernée—toutes les diapositives utilisant ce maître/ma mise en page hériteront de l'arrière-plan.

**Comment éviter qu'une présentation devienne trop lourde à cause de trop d'images ?**

Réutilisez une même ressource d'image au lieu de duplicata, choisissez des résolutions raisonnables, appliquez une compression lors de l'enregistrement, et conservez les graphiques répétés sur le maître le cas échéant.