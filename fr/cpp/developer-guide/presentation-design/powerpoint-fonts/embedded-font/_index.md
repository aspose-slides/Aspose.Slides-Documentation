---
title: Incorporer des polices dans les présentations en C++
linktitle: Polices incorporées
type: docs
weight: 40
url: /fr/cpp/embedded-font/
keywords:
- ajouter police
- incorporer police
- incorporation de police
- obtenir police incorporée
- ajouter police incorporée
- supprimer police incorporée
- compresser police incorporée
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérez les polices incorporées dans PowerPoint avec Aspose.Slides for C++. Ajoutez, récupérez, supprimez et compressez les polices pour préserver l’apparence du texte et réduire la taille du fichier."
---
## **Introduction**

L’incorporation de polices stocke les données de police à l’intérieur d’une présentation PowerPoint. Lorsque le visualiseur prend en charge les polices incorporées, il peut afficher le texte avec ces polices même si elles ne sont pas installées sur le système cible. Cela permet de préserver les sauts de ligne, l’espacement du texte et la mise en page des diapositives.

Aspose.Slides for C++ vous permet de récupérer, d’ajouter et de supprimer des polices incorporées via la méthode [Presentation::get_FontsManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_fontsmanager/) d’une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Vous pouvez également réduire la taille des données de police incorporée en supprimant les caractères que la présentation n’utilise pas.

Les exemples ci‑dessous fonctionnent avec des fichiers PPTX. Avant d’incorporer une police, assurez‑vous que ses données de police sont disponibles pour Aspose.Slides et que sa licence autorise l’incorporation.

## **Obtenir et supprimer les polices incorporées**

Utilisez [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) pour lister les polices stockées dans une présentation. Pour en supprimer une, transmettez une police de cette liste à [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), puis enregistrez la présentation.

L’exemple suivant répertorie les polices incorporées dans `EmbeddedFonts.pptx` et supprime Calibri si elle est présente :

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Supprimer une police incorporée supprime ses données de police stockées ; cela ne modifie pas la police affectée au texte. Si la police est installée sur le système cible, le texte peut toujours l’utiliser. Sinon, le rendu peut nécessiter une [substitution de police](/slides/fr/cpp/font-substitution/), ce qui peut affecter la mise en page.

## **Inspecter les données de police et les autorisations d’incorporation**

Utilisez l’interface [IFontsManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/) pour inspecter les polices avant de les incorporer. Appelez [IFontsManager::GetFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/getfonts/) pour récupérer les polices utilisées dans la présentation. Pour chaque police, transmettez un objet [IFontData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontdata/) et la valeur requise [FontStyleType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontstyletype/) à [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/getfontbytes/). La méthode renvoie les données binaires pour ce style de police, ou `nullptr` lorsque la police ou le style demandé n’est pas disponible. Ne transmettez pas un résultat `nullptr` à [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), car cette méthode nécessite un tableau d’octets.

[EmbeddingLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/embeddinglevel/) est une énumération de drapeaux qui indique les restrictions d’incorporation stockées dans la police :

- `Installable` autorise l’incorporation et l’installation permanente sur un autre système, sous réserve de la licence de la police.
- `Restricted` interdit l’incorporation sauf autorisation du propriétaire légal de la police lorsqu’il s’agit du seul drapeau d’autorisation d’utilisation.
- `PreviewPrint` autorise une utilisation temporaire pour l’affichage et l’impression ; le document contenant la police doit être en lecture seule.
- `Editable` autorise une utilisation temporaire et permet au document d’être édité et enregistré.
- `NoSubsetting` est une restriction supplémentaire qui interdit l’incorporation d’un sous‑ensemble de glyphes. Incorporez tous les caractères lorsque ce drapeau est présent.
- `BitmapOnly` est une restriction supplémentaire qui n’autorise l’incorporation que des caractères bitmap, pas les données vectorielles. Si la police ne possède pas de caractères bitmap, elle ne peut pas être incorporée.

Les quatre premières valeurs décrivent l’autorisation d’utilisation, tandis que `NoSubsetting` et `BitmapOnly` peuvent être combinés avec elles. Vérifiez les modificateurs avec des opérations bit à bit. Comme `Installable` vaut zéro, masquez les bits d’autorisation d’utilisation et comparez le résultat avec `Installable`. Les polices actuelles ne devraient définir qu’un seul bit d’autorisation d’utilisation. Pour compatibilité avec les anciennes polices qui en définissent plusieurs, l’assistant ci‑dessous sélectionne l’autorisation la moins restrictive : `Editable`, puis `PreviewPrint`, puis `Restricted`.

L’exemple suivant audit les données régulières, en gras, italique et gras‑italique disponibles pour chaque police renvoyée par `GetFonts`. Il ignore les styles non disponibles, les polices restreintes, les polices bitmap‑only, les polices limitées à l’aperçu et à l’impression parce que la sortie reste éditable, et les polices déjà incorporées. Si un style disponible possède `NoSubsetting`, il incorpore tous les caractères de cette famille de polices.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Cette inspection signale les restrictions encodées dans chaque fichier de police. Elle ne confère pas de licence, ne prouve pas que vous avez acquis la police légalement, et ne remplace pas la vérification du contrat de licence de la police avant de distribuer une copie incorporée.

## **Ajouter des polices incorporées**

Utilisez [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/addembeddedfont/) pour incorporer une police. Ses surcharges acceptent soit un objet [IFontData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontdata/), soit un tableau d’octets contenant les données de police. L’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/embedfontcharacters/) contrôle quels caractères sont inclus :

- [All](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/embedfontcharacters/) incorpore tous les caractères de la police. Utilisez cette option lorsque les destinataires doivent éditer la présentation et saisir du nouveau texte.
- [OnlyUsed](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/embedfontcharacters/) incorpore uniquement les caractères utilisés dans la présentation afin de réduire la taille du fichier. Choisissez cette option pour une présentation finalisée destinée principalement à la visualisation.

L’exemple suivant utilise [IFontsManager::GetFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/getfonts/) pour récupérer les polices utilisées dans `Fonts.pptx` et incorpore celles qui ne le sont pas déjà. Les polices à ajouter doivent être disponibles sur la machine exécutant le code. Les polices incorporées existantes conservent leurs jeux de caractères actuels.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Compresser les polices incorporées**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) réduit les données de police incorporée en supprimant les caractères inutilisés. Elle agit sur les polices déjà incorporées, de sorte que la réduction de taille dépend de la quantité de données de police inutilisées présentes dans la présentation.

L’exemple suivant compresse les polices dans `EmbeddedFonts.pptx` et enregistre le résultat dans un fichier séparé :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Conservez le fichier original si les destinataires peuvent avoir besoin d’ajouter du texte plus tard. Les caractères supprimés lors de la compression ne sont plus disponibles dans la police incorporée, même si vous aviez initialement incorporé tous les caractères.

## **FAQ**

**Comment puis‑je vérifier si une police incorporée sera encore substituée lors du rendu ?**

Appelez [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontsmanager/getsubstitutions/) dans l’environnement où vous rendez la présentation pour voir quelles polices Aspose.Slides remplacera. Vérifiez également les paramètres de [substitution de police](/slides/fr/cpp/font-substitution/) et les règles de [fallback de police](/slides/fr/cpp/fallback-font/). Le fallback gère les caractères manquants, ainsi l’incorporation d’une police ne résout pas les caractères que la police elle‑même ne contient pas.

**Devrais‑je incorporer des polices courantes comme Arial et Calibri ?**

Basez la décision sur l’environnement cible. Si les polices requises sont disponibles sur chaque machine qui ouvre ou rend la présentation, les incorporer peut ajouter une taille de fichier inutile. Si les destinataires ou les serveurs peuvent ne pas disposer de ces polices, les incorporer peut aider à préserver l’apparence prévue, à condition que leurs licences le permettent.