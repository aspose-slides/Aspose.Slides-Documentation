---
title: Fusionner efficacement des présentations en Python via Java
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/python-java/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner présentations
- fusionner diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner présentations
- combiner diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Python
- Java
- Aspose.Slides
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument en Python via Java en clonant des diapositives, en contrôlant les maîtres et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java fusionne des présentations en clonant des diapositives d'une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) vers une autre. L'opération principale est [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un maître ou à une disposition dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en préservant leur formatage d'origine ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître depuis la présentation de destination ;
- appliquer une disposition spécifique depuis la présentation de destination ;
- normaliser les différentes tailles de diapositives avant la fusion ;
- ajouter les diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les maîtres, ressources, notes, commentaires, médias, polices, mots de passe, gros fichiers et les préoccupations liées au multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les dispositions**

Une diapositive hérite d'une grande partie de son apparence de sa disposition et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine la façon dont la diapositive fusionnée est intégrée dans la présentation de destination.

Utilisez [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) de l'une de ces manières :

- `addClone(source_slide)` — préserve la disposition et la mise en forme de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas de clonage répété de ce maître.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — attache la diapositive clonée à un [MasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/) de destination spécifique. Aspose.Slides recherche une disposition correspondante sous ce maître par type ou nom de disposition.
- `addClone(source_slide, destination_layout)` — attache directement la diapositive clonée à un [LayoutSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/) de destination spécifique.

Le maître ou la disposition passé à une surcharge `addClone` doit appartenir à la **présentation de destination**, pas à la présentation source.

## **Fusionner des présentations entières et préserver la mise en forme source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C'est le choix approprié lorsque les diapositives importées doivent conserver leur thème, maître et relations de disposition d'origine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. Cela est attendu lorsque le formatage source est intentionnellement préservé.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les index de diapositives sélectionnés depuis la présentation source.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Validez les index de diapositives avant de cloner lorsqu’ils proviennent d’une entrée utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un maître de destination**

Utilisez la surcharge de [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) lorsque les diapositives importées doivent suivre un maître qui appartient déjà à la présentation de destination.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides sélectionne une disposition appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adéquate n’existe et que `allow_clone_missing_layout` est `True`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle est `False`, une [PptxEditException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxeditexception/) est levée.

Utilisez `False` lorsque vous voulez que la fusion échoue plutôt que d’introduire une disposition supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une disposition de destination spécifique**

Utilisez la surcharge de [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) lorsque vous savez exactement quelle disposition de destination les diapositives importées doivent utiliser.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Appliquer une disposition de destination modifie la relation de disposition héritée ; cela ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination ont des structures de zones réservées différentes, inspectez le résultat pour confirmer que le formatage hérité et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Les présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation avec une autre taille de diapositive ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent donc apparaître déplacées, mises à l’échelle de façon inattendue ou hors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.setSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#setSize) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/) met à l’échelle le contenu pour qu’il s’ajuste à la taille demandée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous devez conserver la présentation source d’origine inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections importent dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections source, énumérez [Presentation.getSections](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSections), récupérez les diapositives actuelles de chaque section source avec [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getSlidesListOfSection), recréez les sections dans la destination, et clonez chaque diapositive retournée dans sa section de destination correspondante. Voir [Manage Slide Sections](/slides/fr/python-java/slide-section/) pour un exemple complet d’énumération de sections, y compris les sections vides et les modifications structurelles.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille de diapositive de chaque source supplémentaire, garde chaque source ouverte uniquement pendant sa copie, puis enregistre le fichier final une fois.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème unique de destination, remplacez l’appel simple `addClone(slide)` par la surcharge maître‑de‑destination ou disposition‑de‑destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Maîtres, dispositions et fidélité du formatage**

Le clonage de diapositives par défaut peut automatiquement faire entrer un maître source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître à plusieurs reprises. Les maîtres clonés manuellement ne sont pas suivis par ce registre, évitez donc de pré‑cloner des maîtres à moins que vous ne nécessitiez un contrôle explicite de la structure du maître.

Ne supposez pas que deux maîtres ou deux dispositions portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour [presentation notes](/slides/fr/python-java/presentation-notes/) et [presentation comments](/slides/fr/python-java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Dans les flux de travail de révision, vérifiez également les auteurs des commentaires et les fils de discussion après la combinaison de fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources intégrées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources indépendantes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur une déduplication implicite.

### **Polices intégrées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente sur différents ordinateurs, ne supposez pas que le simple clonage de diapositives garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices intégrées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) et gérer l’intégration explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/python-java/embedded-font/).

Vérifiez également que vous êtes autorisé à intégrer les polices utilisées par les fichiers source. Les licences de police peuvent restreindre l’intégration.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # Travail avec la présentation déchiffrée.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément lorsque cela est nécessaire.

### **Présentations volumineuses et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer une mémoire importante. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) offre des contrôles pour la gestion des BLOBs et l’utilisation de fichiers temporaires. Consultez [Manage Presentation BLOBs](/slides/fr/python-java/manage-blob/) pour les stratégies liées aux gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichier lorsque cela est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer à plusieurs reprises des résultats intermédiaires sauf si le flux de travail exige des points de contrôle.

### **Sécurité des threads**

Ne chargez, ne modifiez, n’enregistrez ou ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des travaux indépendants, utilisez des instances de présentation indépendantes et suivez les directives de [Aspose.Slides multithreading guidance](/slides/fr/python-java/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) sans fournir de maître ou de disposition de destination. Aspose.Slides peut automatiquement cloner le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Passez un maître de la présentation de destination, pas de la source. Aspose.Slides essaiera de mapper chaque diapositive source à une disposition appropriée sous ce maître.

**Quand devrais-je utiliser une disposition de destination spécifique plutôt qu'un maître de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un maître lorsque vous souhaitez qu’Aspose.Slides sélectionne parmi les dispositions de ce maître en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositives différentes peuvent-elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un positionnement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#setSize) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/).

**Puis-je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Comme les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑format. Voir [Supported File Formats](/slides/fr/python-java/supported-file-formats/).

**Les sections source sont-elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) lorsque la structure de section doit être conservée.

**Les notes du présentateur et les commentaires sont-ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du maître de notes, des auteurs de commentaires ou des discussions en fil, vérifiez le résultat fusionné car ces scénarios impliquent aussi des structures au niveau de la présentation en plus du contenu des diapositives.

**Que devient l'audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté avec les relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL devant demeurer accessibles après la fusion.

**Les polices intégrées de chaque source sont-elles garanties d'être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices intégrées de la destination et gérez explicitement l’intégration ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez-le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOBs lorsque de gros objets binaires dominent la consommation de mémoire, privilégiez le chargement depuis le chemin du fichier pour les très gros fichiers, libérez rapidement les présentations sources et n’enregistrez le résultat final qu’une fois nécessaire.

**Puis-je fusionner des diapositives depuis plusieurs threads ?**

Ne utilisez pas une même instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée dans ses propres instances de présentation.