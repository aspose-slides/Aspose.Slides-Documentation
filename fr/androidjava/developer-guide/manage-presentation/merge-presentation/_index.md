---
title: Fusion efficace des présentations sur Android
linktitle: Fusionner les présentations
type: docs
weight: 40
url: /fr/androidjava/merge-presentation/
keywords:
- fusion PowerPoint
- fusionner les présentations
- fusionner les diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner les présentations
- combiner les diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Android
- Java
- Aspose.Slides
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument sur Android en clonant des diapositives, en contrôlant les masters et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java fusionne des présentations en clonant des diapositives d'une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) vers une autre. L'opération principale est [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un master ou à une disposition dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur formatage source ;
- fusionner les diapositives sélectionnées ;
- appliquer un master de la présentation de destination ;
- appliquer une disposition spécifique de la présentation de destination ;
- normaliser les différentes tailles de diapositives avant la fusion ;
- ajouter les diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les masters, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les gros fichiers et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les masters et les dispositions**

Une diapositive hérite d'une grande partie de son apparence de sa disposition et de son master. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée dans la présentation de destination.

Utilisez [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/) d'une de ces manières :

- `addClone(sourceSlide)` — préserve la disposition et le formatage de la diapositive source. Si nécessaire, le master source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les masters clonés automatiquement afin que les diapositives répétées utilisant le même master source ne provoquent pas de clonage répété de ce master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/) spécifique de destination. Aspose.Slides recherche une disposition correspondante sous ce master par type ou nom de disposition.
- `addClone(sourceSlide, destinationLayout)` — attache la diapositive clonée directement à un [ILayoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/) spécifique de destination.

Le master ou la disposition passé à une surcharge `addClone` doit appartenir à la présentation **de destination**, pas à la présentation source.

## **Fusionner des présentations entières tout en préservant le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, master et relations de disposition d'origine.

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

La présentation résultante peut contenir plusieurs masters lorsque la source et la destination utilisent des conceptions différentes. C’est attendu lorsque le formatage source est intentionnellement préservé.

## **Fusionner les diapositives sélectionnées**

Il n’est pas nécessaire de cloner chaque diapositive. L’exemple suivant importe uniquement les index de diapositives sélectionnés depuis la présentation source.

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

## **Fusionner les diapositives en utilisant un master de destination**

Utilisez la surcharge [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) lorsque les diapositives importées doivent suivre un master qui appartient déjà à la présentation de destination.

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

Aspose.Slides sélectionne une disposition appropriée sous le master spécifié en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adaptée n’existe et que `allowCloneMissingLayout` est `true`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue plutôt que d’introduire une disposition supplémentaire dans le master de destination.

## **Fusionner les diapositives en utilisant une disposition spécifique de destination**

Utilisez la surcharge [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) lorsque vous savez exactement quelle disposition de destination les diapositives importées doivent utiliser.

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

L’application d’une disposition de destination modifie la relation de disposition héritée ; elle ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination ont des structures de zones réservées différentes, inspectez le résultat pour confirmer que le formatage hérité et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositive différentes**

Les présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais cloner une diapositive dans une présentation dont la taille de diapositive est autre ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent ainsi apparaître déplacées, redimensionnées de façon inattendue ou en dehors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.setSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesizescaletype/) met à l’échelle le contenu pour qu’il s’adapte à la taille demandée.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin que la présentation source d’origine reste inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie des sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives explicitement avec [addClone(ISlide, ISection)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections sources, parcourez [Presentation.getSections](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSections--), récupérez les diapositives actuelles de chaque section source avec [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), recréez les sections dans la destination, et clonez chaque diapositive retournée dans sa section de destination correspondante. Consultez [Manage Slide Sections](/slides/fr/androidjava/slide-section/) pour un exemple complet d’énumération des sections, y compris les sections vides et les modifications structurelles.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple complet suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, garde chaque source ouverte uniquement pendant sa copie, et enregistre le fichier final une fois.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème de destination unique, remplacez l’appel simple `addClone(slide)` par la surcharge de master de destination ou de disposition de destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Masters, dispositions et fidélité du formatage**

Le clonage par défaut des diapositives peut automatiquement intégrer un master source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des masters clonés automatiquement afin d’éviter de cloner le même master à plusieurs reprises. Les masters clonés manuellement ne sont pas suivis par ce registre, évitez donc de précloner les masters sauf si vous avez besoin d’un contrôle explicite de la structure du master.

Ne supposez pas que deux masters ou dispositions portant le même nom sont visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un master ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées aux [presentation notes](/slides/fr/androidjava/presentation-notes/) et aux [presentation comments](/slides/fr/androidjava/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les masters de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les commentaires en fil après avoir combiné des fichiers provenant de différents auteurs ou modèles.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio incorporé, de la vidéo incorporée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse conserver les relations de la diapositive avec ses ressources.

Les ressources incorporées et liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié restent dépendants de leur cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu incorporé. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les masters clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources sans lien seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur la déduplication implicite.

### **Polices incorporées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente entre les machines, ne supposez pas que le simple clonage des diapositives garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices incorporées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) et gérer l’incorporation explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/androidjava/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers source. Les licences de polices peuvent restreindre l’incorporation.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Travailler avec la présentation décryptée.
} finally {
    source.dispose();
}
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Grandes présentations et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer une mémoire importante. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Manage Presentation BLOBs](/slides/fr/androidjava/manage-blob/) pour des stratégies de gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichiers lorsqu’il est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer à plusieurs reprises des résultats intermédiaires à moins que le flux de travail ne nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez, modifiez, enregistrez ou clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des tâches indépendantes, utilisez des instances de présentation distinctes et suivez les [Aspose.Slides multithreading guidance](/slides/fr/androidjava/multithreading/).

## **FAQ**

**Comment conserver la conception originale de chaque présentation source ?**

Utilisez [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sans fournir de master ou de disposition de destination. Aspose.Slides peut automatiquement cloner le master source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un master de destination. Passez un master provenant de la présentation de destination, pas de la source. Aspose.Slides tentera de faire correspondre chaque diapositive source à une disposition appropriée sous ce master.

**Quand faut‑il utiliser une disposition de destination spécifique au lieu d’un master de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un master lorsque vous voulez qu’Aspose.Slides sélectionne parmi les dispositions de ce master en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositive différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez la présentation source d’abord lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination, puis enregistrez la destination dans un format de sortie pris en charge. Comme les formats de présentation ne supportent pas exactement le même jeu de fonctionnalités, vérifiez le contenu complexe après les fusions multiformats. Consultez [Supported File Formats](/slides/fr/androidjava/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas par une boucle basique qui ne clone que les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) lorsque la structure de sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du master de notes, des auteurs de commentaires ou des données de révision en fil, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il pour l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu incorporé est transporté avec les relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc rester disponibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage des diapositives pour le déploiement des polices. Inspectez les polices incorporées de la destination et gérez explicitement l’incorporation ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque de gros objets binaires dominent la consommation de mémoire, privilégiez le chargement depuis des chemins de fichiers pour les très gros fichiers, libérez rapidement les présentations sources et enregistrez le résultat final uniquement lorsque nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Ne chargez pas, ne modifiez pas, n’enregistrez pas ou ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée à ses propres instances de présentation.