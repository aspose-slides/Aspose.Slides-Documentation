---
title: Efficiently Merge Presentations in Python via Java
linktitle: Merge Presentations
type: docs
weight: 40
url: /fr/python-java/merge-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Apprenez comment fusionner des présentations PowerPoint et OpenDocument en Python via Java en clonant des diapositives, en contrôlant les maîtres et les mises en page, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java fusionne des présentations en clonant des diapositives d’une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) vers une autre. L’opération principale est [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone), qui peut conserver le formatage de la diapositive source ou attacher la diapositive clonée à un maître ou à une mise en page dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur formatage d’origine ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître de la présentation de destination ;
- appliquer une mise en page spécifique de la présentation de destination ;
- normaliser différentes tailles de diapositive avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les maîtres, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les gros fichiers et les problématiques de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les mises en page**

Une diapositive hérite de la plupart de son apparence de sa mise en page et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée à la présentation de destination.

Utilisez [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) de l’une de ces manières :

- `addClone(source_slide)` — conserver la mise en page et le formatage de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas de clonage redondant.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — attacher la diapositive clonée à un [MasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/) de destination spécifique. Aspose.Slides recherche une mise en page correspondante sous ce maître par type ou par nom.
- `addClone(source_slide, destination_layout)` — attacher directement la diapositive clonée à une [LayoutSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/) de destination spécifique.

Le maître ou la mise en page passé à une surcharge `addClone` doit appartenir à la **présentation de destination**, pas à la présentation source.

## **Fusionner des présentations entières tout en conservant le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, leur maître et leurs relations de mise en page d’origine.

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

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. Ceci est attendu lorsque le formatage source est intentionnellement conservé.

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

Validez les index de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un maître de destination**

Utilisez la surcharge [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) lorsque les diapositives importées doivent suivre un maître déjà présent dans la présentation de destination.

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

Aspose.Slides sélectionne une mise en page appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la mise en page source. Si aucune mise en page adaptée n’existe et que `allow_clone_missing_layout` est `True`, la mise en page source est clonée afin que la diapositive puisse être ajoutée. Si elle est `False`, une [PptxEditException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxeditexception/) est levée.

Utilisez `False` lorsque vous voulez que la fusion échoue plutôt que d’introduire une mise en page supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une mise en page de destination spécifique**

Utilisez la surcharge [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) lorsque vous savez exactement quelle mise en page de destination les diapositives importées doivent utiliser.

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

L’application d’une mise en page de destination modifie la relation de mise en page héritée ; elle ne redessine pas le contenu de la diapositive source. Si les structures de espaces réservés des mises en page source et destination diffèrent, inspectez le résultat pour confirmer que le formatage hérité et le comportement des espaces réservés sont appropriés.

## **Fusionner des présentations avec des tailles de diapositive différentes**

Des présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation dont la taille est autre ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent donc apparaître déplacées, redimensionnées de façon inattendue ou en dehors de la zone visible.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.setSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#setSize) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/) met le contenu à l’échelle pour qu’il s’ajuste à la taille demandée.

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

Le redimensionnement modifie l’objet présentation source en mémoire. Si vous devez conserver la présentation source d’origine inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone).

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

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections sources, parcourez [Presentation.getSections](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSections), récupérez les diapositives actuelles de chaque section source avec [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getSlidesListOfSection), recréez les sections dans la destination et clonez chaque diapositive retournée dans la section de destination correspondante. Consultez [Manage Slide Sections](/slides/fr/python-java/slide-section/) pour un exemple complet d’énumération de sections, incluant les sections vides et les changements structurels.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, garde chaque source ouverte uniquement pendant son copie, et enregistre le fichier final une fois terminé.

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

Ceci constitue une base utile pour conserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème unique de destination, remplacez l’appel simple `addClone(slide)` par la surcharge maître‑de‑destination ou mise‑en‑page‑de‑destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Maîtres, mises en page et fidélité du formatage**

Le clonage de diapositives par défaut peut automatiquement introduire un maître source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître à plusieurs reprises. Les maîtres clonés manuellement ne sont pas suivis par ce registre, donc évitez de pré‑cloner des maîtres sauf si vous avez besoin d’un contrôle explicite sur la structure des maîtres.

Ne supposez pas que deux maîtres ou mises en page portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une mise en page de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour les [presentation notes](/slides/fr/python-java/presentation-notes/) et les [presentation comments](/slides/fr/python-java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les fils de discussion après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources intégrées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne constitue pas une garantie générale que des ressources binaires identiques provenant de présentations sources non liées seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur une déduplication implicite.

### **Polices intégrées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente d’une machine à l’autre, ne supposez pas que le simple clonage de diapositives garantit que chaque police requise soit disponible dans l’environnement de destination. Vous pouvez inspecter les polices intégrées avec [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) et gérer explicitement l’intégration comme décrit dans [Embed Fonts in Presentations](/slides/fr/python-java/embedded-font/).

Vérifiez également que vous êtes autorisé à intégrer les polices utilisées par les fichiers source. Les licences de police peuvent restreindre l’intégration.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte correctement avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword).

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
    # Travaillez avec la présentation déchiffrée.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Présentations volumineuses et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres objets binaires importants peuvent consommer beaucoup de mémoire. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Manage Presentation BLOBs](/slides/fr/python-java/manage-blob/) pour des stratégies concernant les gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichiers lorsque cela est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer à plusieurs reprises des résultats intermédiaires sauf si le flux de travail exige des points de contrôle.

### **Sécurité des threads**

Ne chargez pas, ne modifiez pas, n’enregistrez pas ou ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des travaux indépendants, utilisez des instances de présentation distinctes et suivez les directives de multithreading d’Aspose.Slides [/slides/fr/python-java/multithreading/].

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) sans fournir de maître ou de mise en page de destination. Aspose.Slides peut automatiquement cloner le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Passez un maître provenant de la présentation de destination, pas de la source. Aspose.Slides tentera de mapper chaque diapositive source à une mise en page appropriée sous ce maître.

**Quand faut‑il utiliser une mise en page de destination spécifique plutôt qu’un maître de destination ?**

Utilisez une mise en page spécifique lorsque chaque diapositive importée doit utiliser une mise en page connue. Utilisez un maître lorsque vous souhaitez qu’Aspose.Slides sélectionne parmi les mises en page de ce maître en fonction du type ou du nom de la mise en page source.

**Les présentations avec des tailles de diapositive différentes peuvent-elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize.setSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#setSize) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Parce que les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑format. Voir [Supported File Formats](/slides/fr/python-java/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) lorsque la structure des sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du maître de notes, des auteurs de commentaires ou des discussions en fil, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il pour l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté avec les relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc être disponibles après la fusion.

**Les polices intégrées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices intégrées de la destination et gérez explicitement l’intégration des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque les objets binaires dominent la consommation de mémoire, privilégiez le chargement depuis des chemins de fichiers pour les très gros fichiers, libérez rapidement les présentations sources, et n’enregistrez le résultat final qu’une fois nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Ne partagez pas une même instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) entre plusieurs threads simultanément. Gardez chaque opération de fusion isolée dans ses propres instances de présentation.