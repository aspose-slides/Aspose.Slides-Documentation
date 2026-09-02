---
title: Gérer les polices de thème spécifiques aux scripts dans .NET
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/net/script-specific-font-mappings/
keywords:
- police spécifique au script
- mappage de police de thème
- présentation multilingue
- système d’écriture
- police cyrillique
- police arabe
- police japonaise
- police géorgienne
- police thaana
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Inspectez, ajoutez, remplacez et supprimez les mappages de police spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d'écriture. Cela permet au texte multilingue qui utilise toujours les polices du thème de suivre un schéma de polices coordonné tout en utilisant des polices appropriées pour le cyrillique, l'arabe, le japonais, le géorgien, le thaana et d’autres scripts.

Le thème possède un [IFontScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/ifontscheme/) qui contient une collection de polices majeures, généralement utilisée pour les titres, et une collection de polices mineures, généralement utilisée pour le corps du texte. En plus de leurs propriétés de polices latines et d’Asie de l’Est, les deux collections exposent des mappages des balises de systèmes d’écriture vers les noms de familles de polices via l’interface [IFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/ifonts/).

Cet article montre comment inspecter et modifier ces mappages dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d’enregistrement‑relecture.

## **Comprendre les balises de script**

Les méthodes de police de script utilisent des sous‑balises de script BCP 47 à quatre lettres pour identifier les systèmes d’écriture. Les valeurs courantes incluent :

| Tag de script | Système d'écriture |
|---|---|
| `Cyrl` | Cyrillique |
| `Arab` | Arabe |
| `Hans` | Chinois simplifié |
| `Jpan` | Japonais |
| `Geor` | Géorgien |
| `Thaa` | Thaana |

Ces mappages appartiennent au schéma de police du thème, pas aux portions de texte individuelles. Une présentation peut définir différents mappages pour les collections majeures et mineures, et elle peut omettre des mappages pour certains scripts.

## **Accéder et inspecter les mappages de police de script**

Utilisez [Presentation.MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/mastertheme/) pour accéder au thème au niveau de la présentation. Les propriétés [FontScheme.Major](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/fontscheme/major/) et [FontScheme.Minor](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/fontscheme/minor/) renvoient les deux collections [IFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/ifonts/).

Appelez [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/fr/net/aspose.slides/fonts/getscriptfontmap/) pour récupérer tous les mappages d’une collection. Pour rechercher un système d’écriture, appelez [IFonts.GetScriptFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fonts/getscriptfont/) avec sa balise de script. `GetScriptFont` renvoie `null` lorsque cette collection ne définit pas le mappage demandé.

## **Modifier les mappages et vérifier la persistance**

Utilisez [IFonts.SetScriptFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fonts/setscriptfont/) pour créer un mappage ou remplacer la famille de police actuelle. Utilisez [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fonts/removescriptfont/) pour supprimer un mappage.

L’exemple complet suivant lit tous les mappages majeurs et mineurs existants, récupère la police majeure japonaise, change la police majeure cyrillique, supprime le mappage mineur thaana, enregistre la présentation et la réouvre pour vérifier les deux changements. Pour rendre l’étape de suppression indépendante du thème initial, l’exemple crée d’abord un mappage thaana uniquement s’il n’est pas déjà défini.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

La vérification utilise le même comportement `null` qu’une recherche ordinaire : après avoir enregistré la suppression, `GetScriptFont("Thaa")` renvoie `null` pour la collection mineure.

## **Faire la distinction entre les mappages du thème et les autres paramètres de police**

Les mappages de thème spécifiques au script participent à la sélection de police, mais ils résolvent un problème différent de la mise en forme directe du texte, de la substitution et du secours :

| Mécanisme | Objectif | Effet du changement d'un mapping de thème |
|---|---|---|
| Mappage de police de thème spécifique au script | Sélectionne une police de thème majeure ou mineure pour un système d’écriture. | Le texte qui utilise toujours la police du thème correspondante peut être résolu vers la nouvelle famille mappée. |
| Police attribuée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de dépendre du thème. | La portion peut rester inchangée car son formatage direct surcharge le choix du thème. |
| Substitution de police | Remplace une police demandée lorsqu’elle n’est pas disponible ou lorsqu’une règle de substitution s’applique. | Elle agit après qu’une police a été demandée ; elle ne redéfinit pas le mappage de script du thème. |
| Police de secours | Fournit les glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Elle comble les lacunes de couverture de glyphes ; elle ne modifie pas le mappage stocké du thème. |

Pour plus d’informations sur les deux derniers mécanismes, voir [Font Substitution](/slides/fr/net/font-substitution/) et [Fallback Fonts](/slides/fr/net/fallback-font/).

Modifier un mappage dans [Presentation.MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/mastertheme/) n’affecte que le contenu dont le formatage effectif dépend encore de ce thème. Le texte peut à la place hériter d’un remplacement de thème provenant d’un maître, d’une disposition ou d’une diapositive, ou utiliser une police assignée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas le mappage au niveau de la présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Un mappage de script stocke un nom de famille de police ; il n’installe ni ne charge le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l’environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/loadexternalfonts/) ou [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/documentlevelfontsources/). Consultez [Custom Fonts](/slides/fr/net/custom-font/) pour les options de chargement disponibles.

Vérifier le mappage enregistré ne confirme que la préservation de la définition du thème. Cela ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis ou qu’elle produit la mise en page attendue. Rendu du texte représentatif pour chaque système d’écriture requis dans une image ou un PDF et inspectez la sortie. Cela permet de détecter les polices manquantes, la couverture de glyphes incomplète, le comportement de secours et les modifications de mise en page avant la distribution de la présentation. Voir [Convert PowerPoint Presentations](/slides/fr/net/convert-powerpoint/) pour des exemples de rendu et d’exportation.

## **FAQ**

**Que renvoie `GetScriptFont` lorsqu’un script n’est pas mappé ?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fonts/getscriptfont/) renvoie `null` lorsque le mappage de script demandé n’est pas défini dans cette collection majeure ou mineure.

**`SetScriptFont` ajoute‑t‑il un deuxième mappage lorsque le script existe déjà ?**

Non. [IFonts.SetScriptFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fonts/setscriptfont/) crée le mappage lorsqu’il est absent et remplace la famille de police mappée lorsque la même balise de script est déjà présente.

**Pourquoi la modification d’un mappage de thème n’a‑t‑elle pas changé certains textes ?**

Le texte peut avoir une police assignée explicitement, hériter d’un thème différent via un remplacement, ou être affecté par la substitution ou le secours lors du rendu. Un mappage de script au niveau de la présentation ne contrôle que le texte dont le formatage effectif fait encore référence à cette collection de polices du thème.

**L’enregistrement et la réouverture suffisent‑ils à valider la sortie multilingue ?**

Non. La réouverture vérifie la persistance des données du thème. Il faut également rendre le texte représentatif de chaque système d’écriture requis afin de confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.