---
title: Fusionner efficacement des présentations en Java
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/java/merge-presentation/
keywords:
- fusion PowerPoint
- fusionner des présentations
- fusionner des diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner des présentations
- combiner des diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Java
- Aspose.Slides
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument en Java en clonant des diapositives, en contrôlant les maîtres et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections, et en gérant les fichiers protégés ou volumineux."
---
## **Aperçu**

Aspose.Slides for Java fusionne des présentations en clonant des diapositives d’une [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) vers une autre. L’opération principale est [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un maître ou à une disposition dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives en conservant leur formatage d’origine ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître de la présentation de destination ;
- appliquer une disposition spécifique de la présentation de destination ;
- normaliser des tailles de diapositives différentes avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les maîtres, ressources, notes, commentaires, médias, polices, mots de passe, fichiers volumineux et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les dispositions**

Une diapositive hérite en grande partie de son apparence de sa disposition et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine la façon dont la diapositive fusionnée est intégrée dans la présentation de destination.

Utilisez [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/) de l’une des manières suivantes :

- `addClone(sourceSlide)` — préserve la disposition et le formatage de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas de clonage répété de ce maître.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/) de destination spécifique. Aspose.Slides recherche une disposition correspondante sous ce maître par type ou par nom.
- `addClone(sourceSlide, destinationLayout)` — attache directement la diapositive clonée à un [ILayoutSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/) de destination spécifique.

Le maître ou la disposition passé·e à une surcharge `addClone` doit appartenir à la **présentation de destination**, pas à la présentation source.

## **Fusionner des présentations entières tout en préservant le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, maître et relations de disposition d’origine.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des designs différents. C’est le comportement attendu lorsqu’on conserve intentionnellement le formatage source.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les index de diapositives sélectionnés de la présentation source.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validez les index de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un maître de destination**

Utilisez la surcharge [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) lorsque les diapositives importées doivent suivre un maître déjà présent dans la présentation de destination.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides sélectionne une disposition appropriée sous le maître indiqué en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adaptée n’existe et que `allowCloneMissingLayout` est `true`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous voulez que la fusion échoue plutôt que d’introduire une disposition supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une disposition de destination spécifique**

Utilisez la surcharge [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) lorsque vous savez exactement quelle disposition de destination les diapositives importées doivent utiliser.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Appliquer une disposition de destination modifie la relation de disposition héritée ; cela ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination ont des structures de zones réservées différentes, examinez le résultat pour confirmer que le formatage hérité et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Des présentations avec des dimensions de diapositives différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation à une autre taille ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent ainsi apparaître déplacées, redimensionnées de façon inattendue ou hors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.setSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions des diapositives. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesizescaletype/) met le contenu à l’échelle pour qu’il tienne dans la taille demandée.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin que la présentation source d’origine reste inchangée pour d’autres opérations, ouvrez une instance séparée pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [addClone(ISlide, ISection)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections sources, parcourez [Presentation.getSections](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSections--), récupérez les diapositives actuelles de chaque section source avec [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isection/#getSlidesListOfSection--), recréez les sections dans la destination, puis clonez chaque diapositive retournée dans sa section de destination correspondante. Consultez [Manage Slide Sections](/slides/fr/java/slide-section/) pour un exemple complet d’énumération de sections, incluant les sections vides et les changements structuraux.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, ne garde chaque source ouverte que pendant son copiage, et enregistre le fichier final une fois.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème unique de destination, remplacez l’appel simple `addClone(slide)` par la surcharge maître‑de‑destination ou disposition‑de‑destination appropriée présentée plus haut.

## **Considérations pratiques**

### **Maîtres, dispositions et fidélité du formatage**

Le clonage de diapositives par défaut peut automatiquement faire entrer un maître source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître plusieurs fois. Les maîtres clonés manuellement ne sont pas suivis par ce registre, évitez donc de pré‑cloner les maîtres sauf si vous avez besoin d’un contrôle explicite de la structure du maître.

Ne supposez pas que deux maîtres ou deux dispositions portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’aspect final, choisissez explicitement un maître ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour les [notes de présentation](/slides/fr/java/presentation-notes/) et les [commentaires de présentation](/slides/fr/java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers sources. Pour les flux de révision, vérifiez également les auteurs des commentaires et les fils de discussion après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources intégrées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié restent dépendants de leur cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne constitue pas une garantie générale que des ressources binaires identiques provenant de présentations sources distinctes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat au lieu de compter sur une déduplication implicite.

### **Polices intégrées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente sur plusieurs machines, ne supposez pas que le simple clonage de diapositives garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices intégrées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) et gérer l’intégration explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/java/embedded-font/).

Vérifiez également que vous êtes autorisé à intégrer les polices utilisées par les fichiers sources. Les licences de polices peuvent restreindre l’intégration.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Travaillez avec la présentation décryptée.
} finally {
    source.dispose();
}
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Grandes présentations et utilisation de la mémoire**

Les grandes présentations contenant des images haute résolution, de l’audio, de la vidéo ou d’autres objets binaires volumineux peuvent consommer beaucoup de mémoire. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) offre des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Manage Presentation BLOBs](/slides/fr/java/manage-blob/) pour des stratégies dédiées aux gros fichiers.

Pour les fichiers volumineux, privilégiez le chargement depuis des chemins de fichiers lorsque c’est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer de façon répétée des résultats intermédiaires sauf si le flux de travail nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez pas, ne modifiez pas, n’enregistrez pas ou ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des travaux indépendants, utilisez des instances de présentation indépendantes et suivez les recommandations de [Aspose.Slides multithreading guidance](/slides/fr/java/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sans fournir de maître ou de disposition de destination. Aspose.Slides peut cloner automatiquement le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Passez un maître issu de la présentation de destination, pas de la source. Aspose.Slides tentera de faire correspondre chaque diapositive source à une disposition appropriée sous ce maître.

**Quand faut‑il utiliser une disposition de destination spécifique plutôt qu’un maître de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un maître lorsque vous voulez qu’Aspose.Slides sélectionne parmi les dispositions de ce maître en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositives différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas redessiné automatiquement pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Comme les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑format. Voir [Supported File Formats](/slides/fr/java/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) lorsque la structure des sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils conservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du maître de notes, des auteurs de commentaires ou des fils de révision, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté avec les relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc rester accessibles après la fusion.

**Les polices intégrées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices intégrées de la destination et gérez explicitement l’intégration des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque les objets binaires volumineux dominent l’utilisation de la mémoire, privilégiez le chargement par chemin de fichier pour les très gros fichiers, libérez rapidement les présentations sources et n’enregistrez le résultat final qu’à la fin du processus.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

N’utilisez pas une même instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée avec ses propres instances de présentation.