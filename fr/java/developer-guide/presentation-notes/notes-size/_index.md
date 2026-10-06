---
title: Modifier la taille et l'orientation de la page de notes en Java
linktitle: Taille de la page de notes
type: docs
weight: 10
url: /fr/java/notes-size/
keywords:
- taille de la page de notes
- orientation des notes
- notes en paysage
- notes en portrait
- taille du document de travail
- PowerPoint
- présentation
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Lire et modifier les dimensions de la page de notes dans Aspose.Slides for Java, changer l'orientation, vérifier les tailles enregistrées et exporter les notes ou les documents de travail en PDF et images."
---
## **Aperçu**

Utilisez [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getNotesSize--) pour accéder aux paramètres de la page de notes de la présentation. Elle renvoie un objet [INotesSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/inotessize/) dont la méthode [setSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) définit les dimensions de la page. Bien que l'objet de paramètres ne puisse pas être remplacé, vous pouvez assigner de nouvelles dimensions via cette méthode.

La largeur et la hauteur sont spécifiées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12.5 × 8⅓ pouces. Ces paramètres s'appliquent à la présentation, plutôt qu'aux notes d'une diapositive individuelle.

| Paramètre | Objectif |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getNotesSize--) | Contrôle les dimensions de la page de notes et les dimensions de page utilisées pour l'exportation des documents de travail. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlideSize--) | Contrôle les dimensions des diapositives de présentation normales via [ISlideSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidesize/). |

Modifier l'un ou l'autre paramètre ne modifie pas automatiquement l'autre. Modifier l'orientation de la page de notes ne fait pas non plus pivoter les diapositives normales. Consultez [Slide Size](/slides/fr/java/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessous utilisent un fichier `sample.pptx` existant. Pour les exemples d'exportation, utilisez une présentation contenant au moins une diapositive avec des notes de présentateur. Chaque exemple peut être exécuté indépendamment.

## **Lire la taille et l'orientation de la page de notes**

Lisez la largeur et la hauteur et comparez‑les pour déterminer l'orientation : une page plus large est en paysage, une page plus haute est en portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer un format de papier standard.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Passer en paysage sans changer la taille du papier**

Pour ne changer que l'orientation, échangez la largeur et la hauteur existantes. Cela conserve les longueurs des deux côtés, y compris celles d'un format de papier personnalisé. La condition ci‑dessous empêche une page déjà en paysage d'être reconvertie en portrait et laisse une page carrée inchangée.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour une orientation portrait, utilisez la même affectation lorsque `size.getWidth() > size.getHeight()`. Ne substituez pas les dimensions A4 ou Letter sauf si vous souhaitez également changer la taille du papier.

## **Définir et vérifier une taille de page de notes personnalisée**

Attribuez les deux dimensions en même temps, puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) pour enregistrer la présentation. Cet exemple définit une page en paysage de 900 × 600 points, l'enregistre au format PPTX et rouvre le fichier enregistré pour vérifier les valeurs persistées. La comparaison autorise une tolérance de 0,01 point pour les valeurs à virgule flottante ; ce n'est pas une garantie de précision pour chaque format de fichier.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Le résultat attendu est `900.0 x 600.0 points` et `Size preserved: true`. Vérifier une présentation nouvellement ouverte confirme le fichier enregistré, plutôt que uniquement les paramètres en mémoire.

## **Exporter les notes et les documents de travail**

Les dimensions de la page définissent la zone disponible pour les mises en page des notes ou des documents de travail. Elles n'activent pas ces mises en page seules : configurez également les options d'exportation. L'exportation des diapositives normales continue d'utiliser les dimensions des diapositives.

### **Exporter les notes en PDF et PNG**

Attribuez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notescommentslayoutingoptions/) à [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes en PNG en utilisant [Slide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) et [RenderingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/renderingoptions/).

Le mode [BottomTruncated](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notespositions/) garde les notes sur une seule page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. À l'échelle d'image de 1 × 1 utilisée ci‑dessus, le PNG fait 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l'échelle de rendu.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Pour l'exportation PDF avec des notes longues, [BottomFull](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notespositions/) permet d'ajouter des pages supplémentaires si nécessaire. N'utilisez pas ce mode avec l'appel d'image d'une seule diapositive ci‑dessus, qui ne le prend pas en charge. Après redimensionnement, examinez la sortie pour détecter les notes coupées et le placement des objets notes‑master existants ; changer uniquement les dimensions de la page ne doit pas être considéré comme une garantie que tout le contenu tiendra. Consultez [Convert PowerPoint to PDF with Notes](/slides/fr/java/convert-powerpoint-to-pdf-with-notes/) pour plus d'informations sur l'exportation des notes.

### **Exporter les documents de travail en PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handoutlayoutingoptions/) pour plusieurs vignettes de diapositives sur une même page. L'exemple suivant définit une page de 900 × 600 points et utilise [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handouttype/) pour disposer jusqu'à quatre diapositives par page. Le préréglage horizontal contrôle l'ordre des diapositives ; l'orientation de la page provient de sa largeur et de sa hauteur.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Modifier la taille de la page modifie la zone disponible pour la grille de documents de travail sans changer les dimensions des diapositives sources. Pour les images de documents de travail, utilisez [Presentation.getImages](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) avec la disposition de documents de travail, plutôt que la méthode d'image d'une diapositive individuelle. Dans Aspose.Slides, le rendu de documents de travail au niveau de la présentation utilise les dimensions de la page de notes, tandis que l'appel d'image d'une diapositive individuelle ne produit pas la page de document de travail. Consultez [Handout Mode](/slides/fr/java/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l'exportation et l'impression**

Gardez distinctes la taille de la présentation stockée, la taille de page exportée et la taille de papier imprimée :

- **Visionneuses de présentation :** Un visionneur peut afficher ou imprimer les notes en utilisant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d'exportation :** Les exemples de PDF de notes et de documents de travail ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions de pixels entières et une échelle de rendu, ainsi les valeurs de points fractionnaires peuvent être arrondies dans la sortie image. L'exportation des diapositives normales n'applique pas la taille de page des notes.
- **Pilotes d'imprimante :** La sélection du papier, la rotation automatique et les paramètres d'ajustement à la page peuvent modifier le résultat physique sans changer les dimensions stockées dans la présentation ou le PDF. Pour un format de papier spécifique, alignez les paramètres de l'imprimante et examinez l'aperçu avant impression.

## **FAQ**

**Puis‑je définir la taille des notes pour une seule diapositive ?**

La taille de la page de notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent contenir un contenu de notes différent, mais cette propriété ne fournit pas de taille de page séparée pour chaque diapositive.

**Pourquoi le changement d'orientation des notes n'a‑t‑il pas modifié mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille des diapositives normales lorsque vous souhaitez redimensionner les diapositives elles‑mêmes.

**Pourquoi mon résultat enregistré ou imprimé a‑t‑il une taille différente ?**

Commencez par rouvrir la présentation enregistrée et comparer ses dimensions de notes. Si celles‑ci ont changé, vérifiez si l'enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n'est pas le cas, examinez la mise en page d'exportation, l'échelle d'image, les paramètres du visionneur et la sélection du papier de l'imprimante.