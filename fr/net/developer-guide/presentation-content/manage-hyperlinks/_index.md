---
title: Gérer les hyperliens de présentation dans .NET
linktitle: Gérer les hyperliens
type: docs
weight: 20
url: /fr/net/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter un hyperlien
- créer un hyperlien
- formater l'hyperlien
- supprimer le hyperlien
- mettre à jour le hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien modifiable
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajouter, formater, mettre à jour et supprimer des hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour .NET, à l'aide d'exemples C#."
---
## **Introduction**

Un hyperlien relie le contenu d'une présentation à un site Web ou à un emplacement dans la présentation. Dans PowerPoint, les hyperliens servent généralement deux objectifs :

* Ouvrir un site Web à partir d'un texte, d'une forme ou d'un cadre multimédia.
* Naviguer vers une autre diapositive, par exemple à partir d'une table des matières.

Aspose.Slides for .NET vous permet d'ajouter ces liens, de contrôler leur apparence et leur son, de mettre à jour leurs propriétés et de les supprimer. Les exemples ci‑dessous montrent comment travailler avec les hyperliens sur des éléments individuels et comment y accéder au niveau de la présentation, de la diapositive ou du cadre de texte.

{{% alert color="info" title="Note" %}}
Vous pouvez également modifier les présentations avec l'[éditeur PowerPoint en ligne gratuit d'Aspose](https://products.aspose.app/slides/fr/editor).
{{% /alert %}} 

## **Ajouter des hyperliens URL**

Vous pouvez affecter une URL de site Web à du texte, à une forme ou à un cadre multimédia. L'élément auquel vous affectez l'hyperlien détermine la zone cliquable : une portion de texte lie le texte sélectionné, tandis qu'une forme ou un cadre lie l'objet de la diapositive.

### **Ajouter des hyperliens URL au texte**

Pour lier du texte à un site Web, affectez un [Hyperlink](https://reference.aspose.com/slides/fr/net/aspose.slides/hyperlink/) à la propriété [HyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/portionformat/hyperlinkclick/) de la portion de texte, comme indiqué ci‑dessous. Seule cette portion de texte devient cliquable.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Ajouter des hyperliens URL aux formes et cadres multimédia**

Pour rendre une forme ou un cadre cliquable, définissez sa propriété [HyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/hyperlinkclick/). L'hyperlien appartient à l'objet lui‑-même plutôt qu'à une portion de texte à l'intérieur.

La même approche s'applique aux cadres image, audio et vidéo : affectez l'hyperlien au cadre et définissez le [Tooltip](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/tooltip/) du lien si nécessaire.

L'exemple suivant rend un rectangle cliquable :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Utiliser les hyperliens pour créer une table des matières**

Les hyperliens internes permettent aux lecteurs de passer d'une table des matières à une diapositive spécifique. L'exemple suivant utilise [SetInternalHyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) pour lier le texte « Page 2 » de la première diapositive à la deuxième diapositive.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Format des hyperliens**

### **Couleur**

La propriété [ColorSource](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/colorsource/) de [IHyperlink](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/) détermine si un hyperlien utilise la couleur d'hyperlien de la présentation ou le formatage de la portion de texte. Pour appliquer une couleur de texte personnalisée, sélectionnez [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/hyperlinkcolorsource/) et définissez la couleur de remplissage de la portion. Cette fonctionnalité a été introduite dans PowerPoint 2019 ; les versions antérieures n'appliquent pas ce paramètre.

L'exemple suivant ajoute deux hyperliens texte à la même diapositive. Le premier utilise un remplissage texte rouge, tandis que le second conserve la couleur d'hyperlien par défaut.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **Son**

Un hyperlien peut jouer un son lorsqu'il est activé ou arrêter un son déjà en cours de lecture. Utilisez les propriétés suivantes pour configurer ces comportements :

- [IHyperlink.Sound](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/sound/) précise le fichier audio associé à l'hyperlien.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/stopsoundonclick/) contrôle si l'activation de l'hyperlien arrête le son précédent.

#### **Ajouter un son à un hyperlien**

L'exemple suivant charge `sampleaudio.wav` et l'associe à un bouton sur la première diapositive. Cliquer sur le bouton joue le son et navigue vers la diapositive suivante. Une deuxième forme sur la même diapositive arrête le son précédent lorsqu'elle est cliquée, sans effectuer d'action de navigation.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Extraire le son d'un hyperlien**

L'exemple suivant ouvre la présentation créée ci‑dessus et lit le son d'hyperlien de la première forme en mémoire via [Sound](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/sound/) et [BinaryData](https://reference.aspose.com/slides/fr/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Infobulle et paramètres d'interaction**

Vous pouvez mettre à jour les propriétés suivantes de [IHyperlink](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/) après avoir affecté un hyperlien à du texte ou à une forme :

- [Tooltip](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/tooltip/) définit le texte qu'un visualiseur peut afficher comme indice pour le lien.
- [TargetFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/targetframe/) spécifie le cadre cible au sein d'un frameset HTML parent, le cas échéant.
- [History](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/history/) contrôle si l'activation du lien ajoute sa destination à la liste des hyperliens consultés.
- [HighlightClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/highlightclick/) contrôle si l'hyperlien est mis en évidence lorsqu'il est cliqué.

## **Supprimer les hyperliens des présentations**

Utilisez [GetAnyHyperlinks](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) pour collecter les conteneurs d'hyperliens, y compris les liens de portions de texte, avant de les modifier. L'exemple suivant supprime les deux types d'activation de la première diapositive. Pour ne supprimer qu'un seul type, appelez uniquement [RemoveHyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ou [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) ; la suppression d'une action de clic ne supprime pas son pendant‑sur‑souris correspondant.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Pour une suppression inconditionnelle, [RemoveAllHyperlinks](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) supprime les deux types d'activation dans la portée sélectionnée en un seul appel. Pour un nettoyage sélectif couvrant les maîtres, les dispositions et les notes, voir [Rapporter, assainir et vérifier les hyperliens](#report-sanitize-and-verify-hyperlinks).

## **Créer un inventaire complet des hyperliens**

Avant de distribuer une présentation, inventoriez ses actions interactives ainsi que ses liens Web. [GetAnyHyperlinks](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) renvoie des objets [IHyperlinkContainer](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkcontainer/), pas une liste plate de chaînes URL. Inspectez à la fois [HyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) et [HyperlinkMouseOver](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) sur chaque conteneur. Ils sont indépendants : le même conteneur peut exposer les deux actions, de sorte qu'un rapport complet nécessite jusqu'à deux lignes par conteneur.

Analyser uniquement les hyperliens au niveau des formes peut manquer les liens attachés aux portions de texte. Interrogez plutôt la portée appropriée et conservez les conteneurs retournés afin de pouvoir mettre à jour ou supprimer leurs actions ultérieurement.

### **Interroger les portées de Présentation, Diapositive et Cadre de texte**

L'interface [IHyperlinkQueries](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/) est accessible via [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/hyperlinkqueries/) et [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/hyperlinkqueries/). Chaque portée prend en charge les mêmes requêtes :

- [GetHyperlinkClicks](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) renvoie les conteneurs avec une action de clic.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) renvoie les conteneurs avec une action de survol.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) renvoie les conteneurs avec l'une ou l'autre action.

L'exemple suivant crée `hyperlink-audit-input.pptx` avec un lien externe au clic, un lien fichier au survol, une navigation interne de diapositive, un lien texte au survol et une action macro. Il n'exécute aucune de ces actions. Les trois requêtes fonctionnent à chaque portée ; les décomptes décrivent des conteneurs, non le nombre total d'actions. La portée du cadre de texte exclut les liens propres à la forme englobante.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Dans cet exemple, les requêtes de présentation et de diapositive rapportent chacune trois conteneurs de clic, deux conteneurs de survol et trois conteneurs avec l'une ou l'autre action. La requête de cadre de texte rapporte un conteneur dans chaque catégorie.

### **Classer les actions et destinations**

Utilisez [IHyperlink.ActionType](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/actiontype/) pour interpréter une action avant d'en interpréter la destination. Les valeurs de [HyperlinkActionType](https://reference.aspose.com/slides/fr/net/aspose.slides/hyperlinkactiontype/) couvrent plus que la navigation Web :

| Valeurs | Signification pour un audit |
| --- | --- |
| `Hyperlink` | Hyperlien externe ; inspecter l'URL et son schéma. |
| `JumpSpecificSlide` | Navigation interne vers une diapositive précise. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigation intégrée du diaporama, résolue dans le contexte du diaporama. |
| `JumpEndShow`, `StartCustomSlideShow` | Terminer le diaporama actuel ou démarrer un diaporama personnalisé. |
| `StartMacro` | Exécuter une macro. |
| `StartProgram` | Lancer un programme. |
| `OpenFile`, `OpenPresentation` | Ouvrir un fichier ou une autre présentation ; examiner séparément des URLs Web. |
| `StartStopMedia` | Démarrer ou arrêter la lecture d'un média. |
| `NoAction`, `Unknown` | Aucun acte de navigation, ou action non reconnue nécessitant une révision. |

Lisez les destinations externes via [ExternalUrl](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/externalurl/) et les destinations internes spécifiques via [TargetSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/targetslide/). Les actions internes et les commandes intégrées peuvent ne pas avoir d'URL externe ; une URL vide ne signifie pas que le conteneur n'a aucune action. Conservez [ExternalUrlOriginal](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/externalurloriginal/) lorsqu'elle diffère de l'URL normalisée, et incluez le [Tooltip](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlink/tooltip/) lorsqu'il est disponible.

### **Rapporter, assainir et vérifier les hyperliens**

L'exemple .NET 6+ suivant lit une présentation existante (utilisez le fichier créé ci‑dessus), écrit `hyperlink-audit.json`, applique une politique, enregistre `hyperlink-sanitized.pptx` et le rouvre pour revérifier les deux types d'activation. Il collecte les conteneurs avant de les modifier et utilise l'égalité de référence pour éviter de traiter deux fois le même conteneur. Les requêtes de présentation couvrent les diapositives ordinaires ; pour un inventaire à l'échelle du package, il interroge également explicitement les maîtres, les dispositions, les notes ainsi que les maîtres de notes et de documents lorsqu'ils sont présents.

Le rapport enregistre un indice de diapositive basé sur 1 et [SlideId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/slideid/) lorsqu'il est disponible. [ISlideComponent.Slide](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecomponent/slide/) fournit la diapositive propriétaire pour les conteneurs pris en charge. Les maîtres, dispositions et notes n'ont pas d'indice de diapositive ordinaire et sont identifiés par leur portée. Les conteneurs de forme et les conteneurs de formatage de portion de texte sont étiquetés séparément ; les autres types de conteneurs conservent leur nom de type d'exécution. Chaque conteneur reçoit un ID local au rapport afin que ses deux actions puissent être corrélées.

Cette politique d'application délibérément restrictive n'autorise que les URL HTTPS absolues et les cibles de diapositive internes valides. Elle rejette les macros, programmes, actions sur fichiers, autres actions de diaporama, actions inconnues et autres schémas d'URL. Ces rejets sont des décisions de politique, pas un verdict de sécurité Aspose.Slides. HTTPS seul n'établit pas la confiance : ajoutez des listes blanches d'hôtes et d'autres contrôles pour votre application. Les URL externes originales et normalisées sont toutes deux vérifiées. L'exemple audite les métadonnées sans suivre les liens ni exécuter d'actions.

Pour la remédiation, le [HyperlinkManager](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) du conteneur prend en charge [SetExternalHyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) et [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Ici, les liens externes de clic prohibés sont remplacés par une page d'atterrissage HTTPS fixe ; les autres clics prohibés et les actions de survol prohibées sont supprimés indépendamment. Définissez `replaceExternalClicks` sur `false` pour supprimer toutes les violations de politique. Choisissez une page de remplacement appartenant à l'application avant le déploiement.

Le drapeau d'exportation du rapport utilise une politique de révision PDF conservatrice : il signale les actions de survol et tout ce qui n'est pas un lien externe ou un saut de diapositive spécifique comme potentiellement non pris en charge. Il s'agit d'une indication de révision, pas d'un test de capacité ou d'une garantie que les liens non signalés survivront à l'export. Les exportations PDF et HTML prises en charge ([PDF](/slides/fr/net/convert-powerpoint-to-pdf/) / [HTML](/slides/fr/net/convert-powerpoint-to-html/)) peuvent conserver les hyperliens, selon l'action, les options d'exportation et le visualiseur. Les [images](/slides/fr/net/convert-powerpoint-to-png/) raster et les [vidéos](/slides/fr/net/convert-powerpoint-to-video/) ne peuvent pas préserver les hyperliens interactifs ; signalez chaque action lors de l'audit pour ces sorties.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Avec l'entrée créée ci‑dessus, le rapport contient cinq lignes d'action. Le lien fichier de survol et le clic macro sont supprimés, tandis que les liens HTTPS et la navigation interne de diapositive restent. La vérification affiche zéro action prohibée. Une entrée contenant une URL de clic externe prohibée déclenche également la branche de remplacement. Un conteneur avec un clic autorisé et un survol prohibé conserve son action de clic.

Ce nettoyage sélectif diffère de [RemoveAllHyperlinks](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), qui supprime les deux types d'activation dans la portée sélectionnée, quel que soit la politique. La vérification ici ne contrôle que les actions d'hyperlien ; elle ne supprime pas les projets VBA intégrés, les objets OLE ou tout autre contenu actif, et elle ne valide pas un fichier PDF ou HTML exporté.

## **FAQ**

**Comment puis‑je créer un lien vers une section ou sa première diapositive ?**

Les sections dans PowerPoint regroupent les diapositives, mais un hyperlien interne cible une diapositive individuelle. Pour créer une navigation vers une section, liez‑la à la première diapositive de cette section.

**Puis‑je attacher un hyperlien aux éléments du maître de diapositive afin qu'il fonctionne sur toutes les diapositives ?**

Oui. Les éléments du maître de diapositive et des dispositions prennent en charge les hyperliens. Les liens sur ces éléments sont disponibles pendant la présentation sur les diapositives qui utilisent le maître ou la disposition correspondante.

**Les hyperliens seront‑ils conservés lors de l'export vers PDF, HTML, images ou vidéo ?**

Les exportations PDF et HTML prises en charge peuvent conserver les hyperliens ; les images raster et les vidéos ne le peuvent pas. Voir les considérations d'exportation dans [Rapporter, assainir et vérifier les hyperliens](#report-sanitize-and-verify-hyperlinks).