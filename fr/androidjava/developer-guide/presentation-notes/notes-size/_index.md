---
title: Modifier la taille et l'orientation de la page des notes sur Android
linktitle: Taille de la page des notes
type: docs
weight: 10
url: /fr/androidjava/notes-size/
keywords:
- taille de la page des notes
- orientation des notes
- notes en paysage
- notes en portrait
- taille du document de travail
- PowerPoint
- présentation
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Lire et modifier les dimensions de la page des notes dans Aspose.Slides pour Android via Java, changer l'orientation, vérifier les tailles enregistrées et exporter les notes ou les documents de travail au format PDF et images."
---
## **Vue d'ensemble**

Utilisez [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getNotesSize--) pour accéder aux paramètres de la page des notes de la présentation. Elle renvoie un objet [INotesSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/inotessize/) dont la méthode [setSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) définit les dimensions de la page. Bien que l'objet de paramètres ne puisse pas être remplacé, vous pouvez assigner de nouvelles dimensions via cette méthode.

La largeur et la hauteur sont spécifiées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12,5 × 8⅓ pouces. Ces paramètres s'appliquent à la présentation, plutôt qu'aux notes d'une diapositive individuelle.

| Paramètre | But |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Contrôle les dimensions de la page des notes et les dimensions de page utilisées pour l'exportation des documents de travail. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Contrôle les dimensions des diapositives de présentation normales via [ISlideSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidesize/). |

Modifier l'un ou l'autre paramètre ne modifie pas automatiquement l'autre. Modifier l'orientation de la page des notes ne fait pas non plus pivoter les diapositives normales. Consultez [Slide Size](/slides/fr/androidjava/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessous utilisent un fichier `sample.pptx` existant. Pour les exemples d'exportation, utilisez une présentation contenant au moins une diapositive avec des notes de l'orateur. Chaque exemple peut être exécuté indépendamment.

## **Lire la taille et l'orientation de la page des notes**

Lisez la largeur et la hauteur et comparez‑les pour déterminer l'orientation : une page plus large est en mode paysage, une page plus haute est en mode portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer une taille de papier standard.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Passer en mode paysage sans changer la taille du papier**

Pour ne changer que l'orientation, échangez la largeur et la hauteur existantes. Cela préserve les longueurs des deux côtés, y compris celles d'une taille de papier personnalisée. La condition ci‑dessous empêche qu’une page déjà en paysage soit reconvertie en portrait et laisse une page carrée inchangée.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour l'orientation portrait, utilisez la même affectation lorsque `size.getWidth() > size.getHeight()`. Ne remplacez pas les dimensions A4 ou Letter sauf si vous souhaitez également modifier la taille du papier.

## **Définir et vérifier une taille personnalisée de la page des notes**

Attribuez les deux dimensions ensemble, puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) pour enregistrer la présentation. Cet exemple définit une page paysage de 900 × 600 points, l’enregistre au format PPTX et ouvre à nouveau le fichier enregistré pour vérifier les valeurs persistées. La comparaison autorise une tolérance de 0,01 point pour les valeurs en virgule flottante ; ce n’est pas une garantie de précision pour chaque format de fichier.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Le résultat attendu est `900.0 x 600.0 points` et `Size preserved: true`. Vérifier une présentation nouvellement ouverte confirme le fichier enregistré, plutôt que les paramètres uniquement en mémoire.

## **Exporter les notes et les documents de travail**

Les dimensions de la page définissent la zone disponible pour les mises en page des notes ou des documents de travail. Elles n’activent pas ces mises en page seules : configurez également les options d’exportation. L’exportation des diapositives normales continue d’utiliser les dimensions des diapositives.

### **Exporter les notes en PDF et PNG**

Attribuez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) à [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes en PNG en utilisant [Slide.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) et [RenderingOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/renderingoptions/).

Le mode [BottomTruncated](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/notespositions/) conserve les notes sur une seule page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. À l’échelle d’image de 1 × 1 utilisée ci‑dessus, le PNG fait 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l’échelle de rendu.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Pour l’exportation PDF avec des notes longues, [BottomFull](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/notespositions/) permet d’ajouter des pages supplémentaires si nécessaire. N’utilisez pas ce mode avec l’appel d’image d’une seule diapositive ci‑dessus, qui ne le prend pas en charge. Après le redimensionnement, examinez la sortie pour détecter les notes tronquées et le placement des objets notes‑master existants ; modifier uniquement les dimensions de la page ne doit pas être considéré comme une garantie que tout le contenu sera affiché. Consultez [Convert PowerPoint to PDF with Notes](/slides/fr/androidjava/convert-powerpoint-to-pdf-with-notes/) pour plus d’informations sur l’exportation des notes.

### **Exporter les documents de travail en PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/handoutlayoutingoptions/) pour plusieurs miniatures de diapositives sur une page. L’exemple suivant définit une page de 900 × 600 points et utilise [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/handouttype/) pour disposer jusqu’à quatre diapositives par page. Le préréglage horizontal contrôle l’ordre des diapositives ; l’orientation de la page provient de sa largeur et de sa hauteur.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Modifier la taille de la page modifie la zone disponible pour la grille du document de travail sans changer les dimensions des diapositives sources. Pour les images du document de travail, utilisez [Presentation.getImages](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) avec la disposition du document de travail, plutôt que la méthode d’image d’une diapositive individuelle. Dans Aspose.Slides, le rendu du document de travail au niveau de la présentation utilise les dimensions de la page des notes, tandis que l’appel d’image d’une diapositive individuelle ne produit pas la page du document de travail. Consultez [Handout Mode](/slides/fr/androidjava/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l'exportation et l'impression**

Conservez séparément la taille de la présentation stockée, la taille de page exportée et la taille de papier imprimée :

- **Visionneuses de présentation :** Une visionneuse peut afficher ou imprimer les notes en utilisant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d'exportation :** Les exemples de PDF de notes et de documents de travail ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions de pixels entières et une échelle de rendu, de sorte que les valeurs de points fractionnaires peuvent être arrondies dans la sortie d’image. L’exportation des diapositives normales n’applique pas la taille de la page des notes.
- **Pilotes d’imprimante :** La sélection du papier, la rotation automatique et les paramètres d’ajustement à la page peuvent modifier la sortie physique sans changer les dimensions stockées dans la présentation ou le PDF. Pour une taille de papier spécifique, alignez les paramètres de l’imprimante et inspectez l’aperçu avant impression.

## **FAQ**

**Puis-je définir la taille des notes pour une seule diapositive ?**

La taille de la page des notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent avoir un contenu de notes différent, mais cette propriété ne fournit pas une taille de page distincte pour chaque diapositive.

**Pourquoi le fait de changer l'orientation des notes n'a-t-il pas modifié mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille des diapositives normales lorsque vous souhaitez redimensionner les diapositives elles‑mêmes.

**Pourquoi mon résultat enregistré ou imprimé a-t-il une taille différente ?**

Commencez par rouvrir la présentation enregistrée et comparer ses dimensions de notes. Si elles ont changé, vérifiez si l’enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n’est pas le cas, examinez la mise en page d’exportation, l’échelle de l’image, les paramètres du visionneur et la sélection du papier de l’imprimante.