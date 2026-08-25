---
title: Fusionner efficacement des présentations en JavaScript
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment fusionner des présentations PowerPoint et OpenDocument en JavaScript en clonant des diapositives, en contrôlant les masters et les mises en page, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Aperçu**

Aspose.Slides for Node.js via Java combine des présentations en clonant des diapositives d’une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) vers une autre. L’opération principale est [SlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un master ou à une mise en page dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur formatage d’origine ;
- fusionner les diapositives sélectionnées ;
- appliquer un master de la présentation de destination ;
- appliquer une mise en page spécifique de la présentation de destination ;
- normaliser les tailles de diapositives différentes avant la fusion ;
- ajouter les diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les masters, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les gros fichiers et les problématiques de multithreading.

## **Comment le clonage de diapositives affecte les masters et les mises en page**

Une diapositive hérite une grande partie de son apparence de sa mise en page et de son master. Pour cette raison, la surcharge de clonage que vous choisissez détermine la façon dont la diapositive fusionnée est intégrée à la présentation de destination.

Utilisez [SlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/) de l’une des manières suivantes :

- `addClone(sourceSlide)` — préserve la mise en page et le formatage de la diapositive source. Si nécessaire, le master source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les masters clonés automatiquement afin que les diapositives répétées utilisant le même master source ne provoquent pas de clonage répété de ce master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [MasterSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/) de destination spécifique. Aspose.Slides recherche une mise en page correspondante sous ce master par type ou par nom.
- `addClone(sourceSlide, destinationLayout)` — attache directement la diapositive clonée à un [LayoutSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/) de destination spécifique.

Le master ou la mise en page passé(e) à une surcharge `addClone` doit appartenir à la **présentation de destination**, pas à la présentation source.

## **Fusionner des présentations complètes tout en préservant le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, master et relations de mise en page d’origine.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

La présentation résultante peut contenir plusieurs masters lorsque la source et la destination utilisent des designs différents. Cela est attendu lorsqu’on préserve intentionnellement le formatage source.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les index de diapositives sélectionnés depuis la présentation source.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validez les index de diapositives avant le clonage lorsqu’ils proviennent d’une entrée utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un master de destination**

Utilisez la surcharge [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) lorsque les diapositives importées doivent suivre un master qui appartient déjà à la présentation de destination.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides sélectionne une mise en page appropriée sous le master indiqué en faisant correspondre le type ou le nom de la mise en page source. Si aucune mise en page adaptée n’existe et que `allowCloneMissingLayout` est `true`, la mise en page source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous voulez que la fusion échoue plutôt que d’ajouter une mise en page supplémentaire au master de destination.

## **Fusionner des diapositives en utilisant une mise en page de destination spécifique**

Utilisez la surcharge [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) lorsque vous savez exactement quelle mise en page de destination les diapositives importées doivent utiliser.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Appliquer une mise en page de destination modifie la relation de mise en page héritée ; cela ne redessine pas le contenu de la diapositive source. Si les mises en page source et destination ont des structures de placeholders différentes, inspectez le résultat pour confirmer que le formatage hérité et le comportement des placeholders sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Les présentations avec des dimensions de diapositives différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation dont la taille diffère ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent ainsi apparaître déplacées, redimensionnées de façon inattendue ou hors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.setSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesizescaletype/) met le contenu à l’échelle pour qu’il tienne dans la taille demandée.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous devez conserver la présentation source d’origine inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [addClone(Slide, Section)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections sources, parcourez [Presentation.getSections](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSections), récupérez les diapositives actuelles de chaque section source avec [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getSlidesListOfSection), recréez les sections dans la destination, et clonez chaque diapositive retournée dans sa section de destination correspondante. Consultez [Manage Slide Sections](/slides/fr/nodejs-java/slide-section/) pour un exemple complet d’énumération de sections, y compris les sections vides et les modifications structurelles.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, garde chaque source ouverte uniquement pendant sa copie, puis enregistre le fichier final une seule fois.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème unique, remplacez l’appel simple `addClone(sourceSlide)` par la surcharge de master ou de mise en page de destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Masters, mises en page et fidélité du formatage**

Le clonage de diapositives par défaut peut automatiquement apporter un master source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des masters clonés automatiquement afin d’éviter de cloner le même master plusieurs fois. Les masters clonés manuellement ne sont pas suivis par ce registre, donc évitez de pré‑cloner les masters sauf si vous avez besoin d’un contrôle explicite de la structure du master.

Ne supposez pas que deux masters ou mises en page portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un master ou une mise en page de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes de l’orateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour les [presentation notes](/slides/fr/nodejs-java/presentation-notes/) et les [presentation comments](/slides/fr/nodejs-java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les masters de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les fils de discussion après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑maîtresse plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides conserve les relations de la diapositive avec ses ressources.

Les ressources intégrées et liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié restent dépendants de leur cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les masters clonés automatiquement, mais cela ne constitue pas une garantie générale que des ressources binaires identiques provenant de présentations sources indépendantes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat au lieu de vous fier à une déduplication implicite.

### **Polices incorporées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente sur plusieurs machines, ne supposez pas que le simple clonage de diapositives garantit la disponibilité de chaque police requise dans l’environnement de destination. Vous pouvez inspecter les polices incorporées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) et gérer l’incorporation explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/nodejs-java/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers source. Les licences de polices peuvent restreindre l’incorporation.

### **Présentations protégées par mot de passe**

Une source protégée doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Travailler avec la présentation décryptée.
} finally {
    source.dispose();
}
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Grandes présentations et usage mémoire**

Les grandes présentations contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer beaucoup de mémoire. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Manage Presentation BLOBs](/slides/fr/nodejs-java/manage-blob/) pour des stratégies relatives aux gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichier lorsque c’est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer de façon répétée des résultats intermédiaires sauf si le flux de travail impose des points de contrôle.

### **Sécurité des threads**

Ne chargez, n’enregistrez ou ne clonez pas une instance de [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) dans plusieurs threads. Ces opérations ne sont pas prises en charge en multithreading. Si vous devez paralléliser des travaux de fusion indépendants, utilisez plusieurs processus monothread, chacun avec ses propres instances de présentation, et suivez les directives de [Aspose.Slides multithreading guidance](/slides/fr/nodejs-java/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) sans fournir de master ou de mise en page de destination. Aspose.Slides peut automatiquement cloner le master source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un master de destination. Fournissez un master provenant de la présentation de destination, pas de la source. Aspose.Slides essaiera de mapper chaque diapositive source à une mise en page appropriée sous ce master.

**Quand faut‑il utiliser une mise en page de destination spécifique plutôt qu’un master de destination ?**

Utilisez une mise en page spécifique lorsque chaque diapositive importée doit utiliser une mise en page connue. Utilisez un master lorsque vous voulez qu’Aspose.Slides sélectionne parmi les mises en page de ce master en fonction du type ou du nom de la mise en page source.

**Peut‑on fusionner des présentations avec des tailles de diapositives différentes ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesizescaletype/).

**Peut‑on fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Comme les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑formats. Consultez [Supported File Formats](/slides/fr/nodejs-java/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections requises dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) lorsque la structure des sections doit être conservée.

**Les notes de l’orateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du master de notes, des auteurs de commentaires ou des fils de révision, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté comme partie des relations de ressources de la diapositive clonée. Les liens externes restent externes, de sorte que leurs fichiers cibles ou URL doivent rester disponibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne vous fiez pas uniquement au clonage de diapositives pour le déploiement des polices. Inspectez les polices incorporées de la destination et gérez explicitement l’incorporation ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque de gros objets binaires dominent la consommation mémoire, privilégiez le chargement par chemin de fichier pour les très gros fichiers, libérez rapidement les présentations sources, et n’enregistrez le résultat final qu’une fois nécessaire.

**Peut‑on fusionner des diapositives depuis plusieurs threads ?**

Ne chargez, n’enregistrez ou ne clonez pas des instances de présentation dans plusieurs threads. Pour des travaux de fusion parallèles, utilisez des processus monothread séparés et des instances de présentation indépendantes.