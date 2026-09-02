---
title: Fusion efficace des présentations en Java
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/java/merge-presentation/
keywords:
- fusion PowerPoint
- fusion présentations
- fusion diapositives
- fusion PPT
- fusion PPTX
- fusion ODP
- combiner PowerPoint
- combiner présentations
- combiner diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Java
- Aspose.Slides
description: "Apprenez comment fusionner des présentations PowerPoint et OpenDocument en Java en clonant des diapositives, en contrôlant les maîtres et les mises en page, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for Java fusionne des présentations en clonant des diapositives d'une [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) vers une autre. L'opération principale est [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), qui peut conserver le formatage de la diapositive source ou attacher la diapositive clonée à un maître ou à une mise en page dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur formatage source ;
- fusionner les diapositives sélectionnées ;
- appliquer un maître de la présentation de destination ;
- appliquer une mise en page spécifique de la présentation de destination ;
- normaliser différentes tailles de diapositives avant la fusion ;
- ajouter les diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les maîtres, ressources, notes, commentaires, médias, polices, mots de passe, gros fichiers et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les mises en page**

Une diapositive hérite de la majeure partie de son apparence de sa mise en page et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée dans la présentation de destination.

Utilisez [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/) de l'une de ces manières :

- `addClone(sourceSlide)` — conserve la mise en page et le formatage de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas un clonage répété de ce maître.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/) de destination spécifique. Aspose.Slides recherche une mise en page correspondante sous ce maître par type ou nom de mise en page.
- `addClone(sourceSlide, destinationLayout)` — attache la diapositive clonée directement à un [ILayoutSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/) de destination spécifique.

Le maître ou la mise en page passé à une surcharge `addClone` doit appartenir à la présentation **de destination**, pas à la présentation source.

## **Fusionner des présentations entières tout en préservant le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, maître et relations de mise en page d’origine.

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

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. C’est attendu lorsque le formatage source est intentionnellement préservé.

## **Fusionner les diapositives sélectionnées**

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

Utilisez la surcharge [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) lorsque les diapositives importées doivent suivre un maître qui appartient déjà à la présentation de destination.

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

Aspose.Slides sélectionne une mise en page appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la mise en page source. Si aucune mise en page adaptée n’existe et que `allowCloneMissingLayout` est `true`, la mise en page source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue plutôt que d’introduire une mise en page supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une mise en page de destination spécifique**

Utilisez la surcharge [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) lorsque vous savez exactement quelle mise en page de destination les diapositives importées doivent utiliser.

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

Appliquer une mise en page de destination modifie la relation de mise en page héritée ; cela ne redessine pas le contenu de la diapositive source. Si les mises en page source et destination ont des structures d’espace réservé différentes, examinez le résultat pour confirmer que le formatage hérité et le comportement des espaces réservés sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Les présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais cloner une diapositive dans une présentation dont la taille de diapositive est différente ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent ainsi apparaître déplacées, redimensionnées de façon inattendue ou en dehors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La [SlideSize.setSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) method can scale existing content while changing the slide dimensions. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesizescaletype/) scales content to fit within the requested size.

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

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin que la présentation source originale reste inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie des sections de la présentation source. Si les sections sont importantes dans la sortie, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [addClone(ISlide, ISection)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Les diapositives clonées sont ajoutées à la fin de la section de destination spécifiée. Pour conserver plusieurs sections source, recréez ces sections dans la destination et associez chaque diapositive source à la section de destination correspondante.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, garde chaque source ouverte uniquement pendant sa copie, et enregistre le fichier final une fois.

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

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre sortie doit utiliser un thème de destination unique, remplacez l’appel simple `addClone(slide)` par la surcharge de maître de destination ou de mise en page de destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Maîtres, mises en page et fidélité du formatage**

Le clonage par défaut des diapositives peut automatiquement introduire un maître source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître plusieurs fois. Les maîtres clonés manuellement ne sont pas suivis par ce registre, il faut donc éviter le pré‑clonage des maîtres sauf si vous avez besoin d’un contrôle explicite de la structure du maître.

Ne supposez pas que deux maîtres ou deux mises en page portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une mise en page de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour les [presentation notes](https://docs.aspose.com/slides/fr/java/presentation-notes/) et les [presentation comments](https://docs.aspose.com/slides/fr/java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers sources. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les commentaires en chaîne après avoir combiné des fichiers provenant de différents auteurs ou modèles.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, audio intégré, vidéo intégrée et données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources incorporées et les ressources liées doivent être traitées différemment. Un audio, vidéo, objet OLE ou hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu incorporé. Testez les chemins et URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources indépendantes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur la déduplication implicite.

### **Polices incorporées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente entre les machines, ne supposez pas que le simple clonage de diapositives garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices incorporées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) et gérer l’incorporation explicitement comme décrit dans [Embed Fonts in Presentations](https://docs.aspose.com/slides/fr/java/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers sources. Les licences de police peuvent restreindre l’incorporation.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Travailler avec la présentation déchiffrée.
} finally {
    source.dispose();
}
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez séparément la protection de sortie si nécessaire.

### **Grandes présentations et utilisation de la mémoire**

Les grandes présentations contenant des images haute résolution, audio, vidéo ou d’autres objets binaires volumineux peuvent consommer une mémoire importante. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Voir [Manage Presentation BLOBs](https://docs.aspose.com/slides/fr/java/manage-blob/) pour les stratégies de gros fichiers.

Pour les gros fichiers, privilégiez le chargement à partir de chemins de fichiers lorsque c’est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer à plusieurs reprises les résultats intermédiaires à moins que le flux de travail ne nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez pas, ne modifiez pas, n’enregistrez pas et ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des tâches indépendantes, utilisez des instances de présentation indépendantes et suivez les [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/fr/java/multithreading/).

## **FAQ**

**Comment conserver la conception originale de chaque présentation source ?**

Utilisez [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sans fournir de maître ou de mise en page de destination. Aspose.Slides peut automatiquement cloner le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Passez un maître de la présentation de destination, pas de la source. Aspose.Slides tentera de mapper chaque diapositive source à une mise en page appropriée sous ce maître.

**Quand faut‑il utiliser une mise en page de destination spécifique plutôt qu’un maître de destination ?**

Utilisez une mise en page spécifique lorsque chaque diapositive importée doit utiliser une mise en page connue. Utilisez un maître lorsque vous souhaitez qu’Aspose.Slides sélectionne parmi les mises en page de ce maître en fonction du type ou du nom de la mise en page source.

**Les présentations avec des tailles de diapositives différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un positionnement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, et enregistrez la destination dans un format de sortie supporté. Étant donné que les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après des fusions inter‑format. Voir [Supported File Formats](https://docs.aspose.com/slides/fr/java/supported-file-formats/).

**Les sections source sont‑elles préservées automatiquement ?**

Pas avec une boucle de base qui ne clone que les diapositives. Recréez les sections requises dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) lorsque la structure des sections doit être préservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Oui, elles sont copiées avec la diapositive clonée. Pour les flux de travail qui dépendent du style du maître de notes, des auteurs de commentaires ou des données de révision en chaîne, vérifiez le résultat fusionné car ces scénarios impliquent des structures au niveau de la présentation ainsi que du contenu des diapositives.

**Que se passe‑t‑il pour l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu incorporé est transporté comme partie des relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc rester disponibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices incorporées de la destination et gérez explicitement l’incorporation des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), puis clonez normalement ses diapositives. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque les gros objets binaires dominent l’utilisation de la mémoire, privilégiez le chargement via des chemins de fichiers pour les très gros fichiers, libérez rapidement les présentations source, et enregistrez le résultat final uniquement lorsque nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Ne pas utiliser une même instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée dans ses propres instances de présentation.