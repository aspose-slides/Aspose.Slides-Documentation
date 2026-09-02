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
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java fusionne des présentations en clonant des diapositives d'une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) à une autre. L'opération principale est [SlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un master ou à un layout dans la présentation de destination.

Cet article couvre les flux de fusion les plus courants :

- fusionner toutes les diapositives tout en préservant leur formatage source ;
- fusionner des diapositives sélectionnées ;
- appliquer un master de la présentation de destination ;
- appliquer un layout spécifique de la présentation de destination ;
- normaliser les tailles de diapositives différentes avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les masters, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les gros fichiers et les problématiques de multithreading.

## **Comment le clonage de diapositives affecte les masters et les layouts**

Une diapositive hérite d’une grande partie de son apparence de son layout et de son master. Pour cette raison, la surcharge de clonage que vous choisissez détermine la façon dont la diapositive fusionnée est intégrée dans la présentation de destination.

Utilisez [SlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/) de l’une des manières suivantes :

- `addClone(sourceSlide)` — préserve le layout et le formatage de la diapositive source. Au besoin, le master source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les masters clonés automatiquement afin que les diapositives répétées utilisant le même master source ne provoquent pas de clonage répété de ce master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [MasterSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/) de destination spécifique. Aspose.Slides recherche un layout correspondant sous ce master selon le type ou le nom du layout.
- `addClone(sourceSlide, destinationLayout)` — attache la diapositive clonée directement à un [LayoutSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/) de destination spécifique.

Le master ou le layout passé à une surcharge `addClone` doit appartenir à la présentation **de destination**, pas à la présentation source.

## **Fusionner des présentations entières tout en préservant le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, master et relations de layout d’origine.

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

La présentation résultante peut contenir plusieurs masters lorsque la source et la destination utilisent des conceptions différentes. Ceci est attendu lorsque le formatage source est préservé intentionnellement.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les index de diapositives sélectionnés de la présentation source.

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

Validez les index de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

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

Aspose.Slides sélectionne un layout approprié sous le master spécifié en faisant correspondre le type ou le nom du layout source. Si aucun layout approprié n’existe et que `allowCloneMissingLayout` est `true`, le layout source est cloné afin que la diapositive puisse être ajoutée. Si c’est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue au lieu d’introduire un layout supplémentaire dans le master de destination.

## **Fusionner des diapositives en utilisant un layout de destination spécifique**

Utilisez la surcharge [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) lorsque vous savez exactement quel layout de destination les diapositives importées doivent utiliser.

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

Appliquer un layout de destination modifie la relation de layout héritée ; cela ne redessine pas le contenu de la diapositive source. Si les layouts source et destination ont des structures de zones réservées différentes, inspectez le résultat pour confirmer que le formatage hérité et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Les présentations avec des dimensions de diapositives différentes peuvent être fusionnées, mais cloner une diapositive dans une présentation dont la taille de diapositive est différente ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent donc apparaître déplacées, redimensionnées de façon inattendue, ou hors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.setSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesizescaletype/) met à l’échelle le contenu pour l’adapter à la taille demandée.

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

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin de la présentation source originale intacte pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de base de clonage de diapositives ne recrée pas la hiérarchie des sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dedans explicitement avec [addClone(Slide, Section)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections source, recréez ces sections dans la destination et associez chaque diapositive source à la section de destination correspondante.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple complet suivant utilise la première présentation comme destination, normalise la taille de diapositive de chaque source supplémentaire, garde chaque source ouverte uniquement pendant sa copie, et enregistre le fichier final une seule fois.

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

Ceci constitue une base utile pour préserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème unique de destination, remplacez l’appel simple `addClone(sourceSlide)` par la surcharge de destination‑master ou de destination‑layout appropriée montrée précédemment.

## **Considérations pratiques**

### **Masters, layouts et fidélité du formatage**

Le clonage de diapositives par défaut peut automatiquement introduire un master source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des masters clonés automatiquement afin d’éviter de cloner le même master plusieurs fois. Les masters clonés manuellement ne sont pas suivis par ce registre, donc évitez de pré‑cloner des masters à moins d’avoir besoin d’un contrôle explicite sur la structure du master.

Ne supposez pas que deux masters ou deux layouts portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un master ou un layout de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositives sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour les [notes de présentation](https://docs.aspose.com/slides/fr/nodejs-java/presentation-notes/) et les [commentaires de présentation](https://docs.aspose.com/slides/fr/nodejs-java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les masters de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les commentaires en fil après la combinaison de fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse conserver les relations de la diapositive avec ses ressources.

Les ressources intégrées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les masters clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources sans lien seront toujours dédupliées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur une déduplication implicite.

### **Polices intégrées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente sur plusieurs machines, ne supposez pas que le simple clonage de diapositives garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices intégrées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) et gérer l’intégration explicitement comme décrit dans [Intégrer des polices dans les présentations](https://docs.aspose.com/slides/fr/nodejs-java/embedded-font/).

Vérifiez également que vous êtes autorisé à intégrer les polices utilisées par les fichiers source. Les licences de police peuvent restreindre l’intégration.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

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

### **Grandes présentations et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres objets binaires importants peuvent consommer une mémoire significative. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Voir [Gérer les BLOB de présentation](https://docs.aspose.com/slides/fr/nodejs-java/manage-blob/) pour les stratégies de gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis un chemin de fichier lorsque cela est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer à plusieurs reprises les résultats intermédiaires sauf si le flux de travail nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez pas, n’enregistrez pas et ne clonez pas d’instance de [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) dans plusieurs threads. Ces opérations ne sont pas prises en charge en mode multithread. Si vous devez paralléliser des travaux de fusion indépendants, utilisez plusieurs processus mono‑thread, chacun avec ses propres instances de présentation, et suivez les consignes de [multithreading d’Aspose.Slides](https://docs.aspose.com/slides/fr/nodejs-java/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) sans fournir de master ou de layout de destination. Aspose.Slides peut automatiquement cloner le master source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un master de destination. Passez un master provenant de la présentation de destination, pas de la source. Aspose.Slides essaiera de mapper chaque diapositive source à un layout approprié sous ce master.

**Quand faut‑il utiliser un layout de destination spécifique plutôt qu’un master de destination ?**

Utilisez un layout spécifique lorsque chaque diapositive importée doit utiliser un layout connu. Utilisez un master lorsque vous voulez qu’Aspose.Slides sélectionne parmi les layouts de ce master en fonction du type ou du nom du layout source.

**Peut‑on fusionner des présentations avec des tailles de diapositives différentes ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Étant donné que les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après des fusions inter‑formats. Voir [Supported File Formats](https://docs.aspose.com/slides/fr/nodejs-java/supported-file-formats/).

**Les sections source sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections requises dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) lorsque la structure des sections doit être préservée.

**Les notes du présentateur et les commentaires sont‑ils conservés ?**

Elles sont copiées avec la diapositive clonée. Pour les flux de travail dépendant du style du master de notes, des auteurs de commentaires ou des données de révision en fil, vérifiez le résultat fusionné car ces scénarios impliquent des structures au niveau de la présentation ainsi que le contenu des diapositives.

**Que se passe‑t‑il pour l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté comme partie des relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc rester disponibles après la fusion.

**Les polices intégrées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices intégrées de la destination et gérez explicitement l’intégration des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque les objets binaires volumineux dominent l’utilisation de la mémoire, privilégiez le chargement depuis un chemin de fichier pour les très gros fichiers, libérez rapidement les présentations source, et n’enregistrez le résultat final que lorsque cela est nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Ne chargez pas, n’enregistrez pas et ne clonez pas d’instances de présentation dans plusieurs threads. Pour des travaux de fusion parallèles, utilisez des processus distincts mono‑thread et des instances de présentation indépendantes.