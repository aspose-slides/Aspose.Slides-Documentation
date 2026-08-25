---
title: Gestion des polices de thème spécifiques aux scripts en C++
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/cpp/script-specific-font-mappings/
keywords:
- police spécifique au script
- mappage de police du thème
- présentation multilingue
- système d'écriture
- police cyrillique
- police arabe
- police japonaise
- police géorgienne
- police thaana
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Inspectez, ajoutez, remplacez et supprimez les mappages de polices spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d'écriture. Cela permet d’utiliser du texte multilingue qui utilise toujours les polices du thème tout en suivant un schéma de police coordonné et en employant des polices appropriées pour le cyrillique, l’arabe, le japonais, le géorgien, le thaana et d’autres scripts.

Le [IFontScheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ifontscheme/) du thème contient une collection de polices principales, généralement utilisée pour les titres, et une collection de polices secondaires, généralement utilisée pour le corps du texte. En plus de leurs propriétés de police latine et d’Asie de l’Est, les deux collections exposent des mappages des balises de système d’écriture vers les noms de familles de polices via l’interface [IFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifonts/).

Cet article montre comment inspecter et modifier ces mappages dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d’enregistrement et de rechargement.

## **Comprendre les balises de script**

Les méthodes de police de script utilisent des sous‑balises de script BCP 47 à quatre lettres pour identifier les systèmes d’écriture. Les valeurs courantes comprennent :

| Étiquette de script | Système d'écriture |
|---|---|
| `Cyrl` | Cyrillique |
| `Arab` | Arabe |
| `Hans` | Chinois simplifié |
| `Jpan` | Japonais |
| `Geor` | Géorgien |
| `Thaa` | Thaana |

Ces mappages appartiennent au schéma de police du thème, pas aux portions de texte individuelles. Une présentation peut définir des mappages différents pour les collections principales et secondaires, et elle peut omettre des mappages pour certains scripts.

## **Accéder et inspecter les mappages de police de script**

Utilisez [Presentation::get_MasterTheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/) pour accéder au thème au niveau de la présentation. Les méthodes [FontScheme::get_Major](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_major/) et [FontScheme::get_Minor](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_minor/) renvoient les deux collections [IFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifonts/).

Appelez [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fonts/getscriptfontmap/) pour récupérer tous les mappages d’une collection. Pour rechercher un système d’écriture, appelez [Fonts::GetScriptFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fonts/getscriptfont/) avec sa balise de script. `GetScriptFont` renvoie une chaîne nulle lorsque cette collection ne définit pas le mappage demandé.

## **Modifier les mappages et vérifier la persistance**

Utilisez [Fonts::SetScriptFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fonts/setscriptfont/) pour créer un mappage ou remplacer la famille de polices actuelle. Utilisez [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fonts/removescriptfont/) pour supprimer un mappage.

L’exemple de bout en bout suivant lit tous les mappages principaux et secondaires existants, recherche la police principale japonaise, change la police principale cyrillique, supprime le mappage thaana secondaire, enregistre la présentation et la rouvre pour vérifier les deux changements. Pour rendre l’étape de suppression indépendante du thème initial, l’exemple crée d’abord un mappage Thaana uniquement lorsqu’aucun n’est déjà défini.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

La vérification utilise le même comportement de chaîne nulle qu’une recherche ordinaire : après que la suppression soit enregistrée, `GetScriptFont(u"Thaa")` renvoie une chaîne nulle pour la collection secondaire.

## **Différencier les mappages du thème des autres paramètres de police**

Les mappages de thème spécifiques à un script participent à la sélection de la police, mais ils résolvent un problème différent de la mise en forme directe du texte, de la substitution et du repli :

| Mécanisme | Objectif | Effet du changement d’un mappage du thème |
|---|---|---|
| Mappage de police de thème spécifique à un script | Sélectionne une police principale ou secondaire du thème pour un système d’écriture. | Le texte qui utilise toujours la police de thème correspondante peut être résolu vers la nouvelle famille mappée. |
| Police assignée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de dépendre du thème. | La portion peut rester inchangée car son formatage direct l’emporte sur le choix du thème. |
| Substitution de police | Remplace une police demandée lorsque celle‑ci n’est pas disponible ou lorsqu’une règle de substitution s’applique. | Elle intervient après qu’une police a été demandée ; elle ne redéfinit pas le mappage du script du thème. |
| Repli de police | Fournit des glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Elle comble les lacunes de couverture de glyphes ; elle ne modifie pas le mappage stocké du thème. |

Pour plus d’informations sur les deux derniers mécanismes, consultez [Font Substitution](/slides/fr/cpp/font-substitution/) et [Fallback Fonts](/slides/fr/cpp/fallback-font/).

Modifier un mappage via [Presentation::get_MasterTheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/) affecte uniquement le contenu dont le formatage effectif dépend encore de ce thème. Le texte peut plutôt hériter d’un remplacement de thème provenant d’un maître, d’une disposition ou d’une diapositive, ou utiliser une police assignée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas le mappage au niveau de la présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Un mappage de script stocke un nom de famille de police ; il n’installe ni ne charge le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l’environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/loadexternalfonts/) ou [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Voir [Custom Fonts](/slides/fr/cpp/custom-font/) pour les options de chargement disponibles.

Vérifier le mappage enregistré ne confirme que la préservation de la définition du thème. Cela ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis ou qu’elle produit la mise en page prévue. Rendez compte d’un texte représentatif pour chaque système d’écriture requis dans une image ou un PDF et inspectez le résultat. Cela permet de détecter les polices manquantes, la couverture incomplète des glyphes, le comportement de repli et les changements de mise en page avant la distribution de la présentation. Consultez [Convert PowerPoint Presentations](/slides/fr/cpp/convert-powerpoint/) pour des exemples de rendu et d’exportation.

## **FAQ**

**Que renvoie `GetScriptFont` lorsqu’un script n’est pas mappé ?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fonts/getscriptfont/) renvoie une chaîne nulle lorsque le mappage de script demandé n’est pas défini dans cette collection principale ou secondaire.

**`SetScriptFont` ajoute‑t‑il un second mappage lorsque le script existe déjà ?**

Non. [Fonts::SetScriptFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fonts/setscriptfont/) crée le mappage lorsqu’il manque et remplace la famille de police mappée lorsque la même balise de script est déjà présente.

**Pourquoi le changement d’un mappage de thème n’a‑t‑il pas modifié certains textes ?**

Le texte peut avoir une police assignée explicitement, hériter d’un thème différent via un remplacement, ou être affecté par une substitution ou un repli lors du rendu. Un mappage de script au niveau de la présentation ne contrôle que le texte dont le formatage effectif dépend encore de cette collection de polices du thème.

**Le fait d’enregistrer et de rouvrir suffit‑il à valider la sortie multilingue ?**

Non. Le rouvrir vérifie la persistance des données du thème. Il faut également rendre un texte représentatif de chaque système d’écriture requis pour confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.