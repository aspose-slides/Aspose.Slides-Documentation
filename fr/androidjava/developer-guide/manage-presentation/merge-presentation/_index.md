---
title: Fusion efficace de présentations sur Android
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/androidjava/merge-presentation/
keywords:
- fusionner PowerPoint
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
- Android
- Java
- Aspose.Slides
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument sur Android en clonant des diapositives, en contrôlant les maîtres et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java fusionne des présentations en clonant des diapositives d'une [Présentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) vers une autre. L’opération principale est [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), qui peut préserver la mise en forme de la diapositive source ou attacher la diapositive clonée à un maître ou une disposition dans la présentation cible.

Cet article couvre les workflows de fusion les plus courants :

- fusionner toutes les diapositives en préservant leur mise en forme d’origine ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître de la présentation cible ;
- appliquer une disposition spécifique de la présentation cible ;
- normaliser différentes tailles de diapositives avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un workflow de bout en bout ;
- gérer les maîtres, ressources, notes, commentaires, médias, polices, mots de passe, gros fichiers et les préoccupations de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les dispositions**

Une diapositive hérite en grande partie de son apparence de sa disposition et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée dans la présentation cible.

Utilisez [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/) de l’une des manières suivantes :

- `addClone(sourceSlide)` — préserve la disposition et la mise en forme de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation cible. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas de clonage répété de ce maître.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/) de destination spécifique. Aspose.Slides recherche une disposition correspondante sous ce maître par type ou par nom.
- `addClone(sourceSlide, destinationLayout)` — attache directement la diapositive clonée à une [ILayoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/) de destination spécifique.

Le maître ou la disposition passé(e) à une surcharge `addClone` doit appartenir à la **présentation de destination**, pas à la présentation source.

## **Fusionner des présentations entières en préservant la mise en forme source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation cible. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, maître et relations de disposition d’origine.

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

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. C’est le comportement attendu lorsque la mise en forme source est intentionnellement préservée.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner toutes les diapositives. L’exemple suivant importe uniquement les index de diapositives sélectionnés depuis la présentation source.

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

Utilisez la surcharge [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) lorsque les diapositives importées doivent suivre un maître déjà présent dans la présentation de destination.

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

Aspose.Slides sélectionne une disposition appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adaptée n’existe et que `allowCloneMissingLayout` est `true`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue plutôt que d’introduire une disposition supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une disposition de destination spécifique**

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

L’application d’une disposition de destination modifie la relation de disposition héritée ; elle ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination ont des structures de paramètres différents, inspectez le résultat pour confirmer que la mise en forme héritée et le comportement des espaces réservés sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Les présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation dont la taille de diapositive diffère ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent donc apparaître déplacées, redimensionnées de façon inattendue ou hors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.setSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesizescaletype/) redimensionne le contenu pour qu’il tienne dans la taille demandée.

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

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin que la présentation source reste inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie des sections de la présentation source. Si les sections sont importantes dans la sortie, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dedans explicitement avec [addClone(ISlide, ISection)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections source, recréez ces sections dans la destination et mappez chaque diapositive source à la section de destination correspondante.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille de diapositive de chaque source supplémentaire, ne garde chaque source ouverte que pendant la copie, puis enregistre le fichier final une fois.

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

C’est une base utile pour préserver la mise en forme source des diapositives importées. Si votre sortie doit utiliser un thème unique, remplacez l’appel simple `addClone(slide)` par la surcharge maître‑de‑destination ou disposition‑de‑destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Maîtres, dispositions et fidélité de la mise en forme**

Le clonage de diapositives par défaut peut automatiquement apporter un maître source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître plusieurs fois. Les maîtres clonés manuellement ne sont pas suivis par ce registre, évitez donc le pré‑clonage des maîtres sauf si vous avez besoin d’un contrôle explicite sur la structure du maître.

Ne supposez pas que deux maîtres ou deux dispositions portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées aux [notes de présentation](https://docs.aspose.com/slides/fr/androidjava/presentation-notes/) et aux [commentaires de présentation](https://docs.aspose.com/slides/fr/androidjava/presentation-comments/).

Si la mise en forme de la page de notes est importante, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les discussions en fil après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides maintienne les relations de la diapositive avec ses ressources.

Les ressources incorporées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu incorporé. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources indépendantes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur une déduplication implicite.

### **Polices incorporées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente d’une machine à l’autre, ne supposez pas que le simple clonage de diapositives garantit la disponibilité de chaque police requise dans l’environnement de destination. Vous pouvez inspecter les polices incorporées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) et gérer l’incorporation explicitement comme décrit dans [Incorporer des polices dans les présentations](https://docs.aspose.com/slides/fr/androidjava/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers source. Les licences de police peuvent restreindre l’incorporation.

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

### **Présentations volumineuses et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer une mémoire importante. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Gérer les BLOB de présentation](https://docs.aspose.com/slides/fr/androidjava/manage-blob/) pour des stratégies de fichiers volumineux.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichiers lorsque c’est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer fréquemment des résultats intermédiaires sauf si le workflow nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez pas, ne modifiez pas, n’enregistrez pas ou ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des tâches indépendantes, utilisez des instances de présentation indépendantes et suivez les [directives multithreading d’Aspose.Slides](https://docs.aspose.com/slides/fr/androidjava/multithreading/).

## **FAQ**

**Comment garder le design original de chaque présentation source ?**

Utilisez [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sans fournir de maître ou de disposition de destination. Aspose.Slides peut cloner automatiquement le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Passez un maître provenant de la présentation de destination, pas de la source. Aspose.Slides tentera de faire correspondre chaque diapositive source à une disposition appropriée sous ce maître.

**Quand faut‑il utiliser une disposition de destination spécifique plutôt qu’un maître de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un maître lorsque vous voulez qu’Aspose.Slides sélectionne parmi les dispositions de ce maître en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositives différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un positionnement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Étant donné que les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑format. Consultez les [Formats de fichiers pris en charge](https://docs.aspose.com/slides/fr/androidjava/supported-file-formats/).

**Les sections source sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) lorsque la structure des sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du maître de notes, des auteurs de commentaires ou des discussions en fil, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu incorporé est transporté comme partie des relations de ressources de la diapositive clonée. Les liens externes restent externes, il faut donc que leurs fichiers cibles ou URL soient toujours disponibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices incorporées de la destination et gérez explicitement l’incorporation des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque des objets binaires volumineux dominent l’utilisation de la mémoire, privilégiez le chargement depuis un chemin de fichier pour les très gros fichiers, libérez rapidement les présentations sources et enregistrez le résultat final uniquement lorsque cela est nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

N’utilisez pas une même instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée dans ses propres instances de présentation.