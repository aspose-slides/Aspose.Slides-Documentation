---
title: Incorporer des polices dans les présentations avec C++
linktitle: Intégration de police
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
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Incorporez des polices TrueType dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++, assurant un rendu précis sur toutes les plateformes."
---

## **Vue d'ensemble**

**Polices incorporées dans PowerPoint** aident à garantir que votre présentation conserve son apparence prévue lorsqu’elle est ouverte sur n’importe quel système ou appareil. C’est particulièrement important lors de l’utilisation de polices personnalisées, tierces ou non standard à des fins de marque ou de création. Sans polices incorporées, le texte peut être substitué, les mises en page peuvent se rompre et les caractères peuvent apparaître sous forme de symboles ou de rectangles illisibles, compromettant ainsi le design global.

Aspose.Slides for C++ fournit un ensemble d’API puissantes pour gérer les polices incorporées par programme. Vous pouvez utiliser les classes [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) et [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) pour inspecter, ajouter ou retirer des polices incorporées dans vos fichiers de présentation. De plus, la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) vous permet d’optimiser la taille du fichier en compressant les données de police sans affecter la qualité ou l’apparence.

Ces outils vous offrent un contrôle complet sur l’incorporation des polices, vous aidant à maintenir une typographie cohérente sur toutes les plateformes tout en réduisant la taille du fichier lorsque cela est nécessaire.

## **Obtenir les polices incorporées d’une présentation**

Aspose.Slides for C++ propose la méthode `GetEmbeddedFonts` via la classe [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/), qui permet de récupérer la liste des polices incorporées dans une présentation PowerPoint. Cela peut être utile pour auditer l’utilisation des polices, garantir la conformité aux directives de marque ou vérifier que toutes les polices nécessaires sont correctement incluses avant de partager le fichier.

Le code C++ suivant montre comment obtenir les polices incorporées d’un fichier de présentation :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Récupérez toutes les polices incorporées.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Affichez les noms des polices incorporées.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```


## **Ajouter des polices incorporées à une présentation**

Aspose.Slides for C++ vous permet d’incorporer des polices dans une présentation PowerPoint à l’aide de la méthode [AddEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/), qui propose deux surcharges pour une utilisation flexible. Vous pouvez contrôler la quantité de police incorporée en utilisant l’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) — par exemple, choisir d’incorporer uniquement les caractères utilisés ou l’ensemble complet de la police. Cette fonctionnalité est particulièrement utile lors de la préparation d’une présentation à partager ou à distribuer, afin que les polices personnalisées ou non standard s’affichent correctement sur tous les systèmes, même si ces polices ne sont pas installées.

Le code C++ suivant vérifie toutes les polices utilisées dans une présentation et incorpore celles qui ne le sont pas déjà :
```cpp
// Chargez un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Vérifiez si la police est déjà incorporée.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Incorporez la police dans la présentation.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Enregistrez la présentation sur le disque.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Supprimer les polices incorporées d’une présentation**

Aspose.Slides for C++ fournit la méthode `RemoveEmbeddedFont` via la classe [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/), qui permet de retirer des polices spécifiques incorporées dans une présentation PowerPoint. Cela peut aider à réduire la taille globale du fichier, surtout si les polices incorporées ne sont plus utilisées ou nécessaires. La suppression de polices inutilisées peut également améliorer les performances et garantir que votre présentation ne contient que les ressources essentielles.

Le code C++ suivant montre comment supprimer une police incorporée d’une présentation :
```cpp
auto fontName = u"Calibri";

// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Récupérez toutes les polices incorporées.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Supprimez la police incorporée.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```


## **Compresser les polices incorporées**

Aspose.Slides for C++ propose la méthode `CompressEmbeddedFonts` via la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/), permettant de réduire la taille globale d’une présentation en optimisant les données des polices incorporées. Cette fonctionnalité est particulièrement utile lorsque votre présentation comprend de grandes polices ou plusieurs polices et que vous souhaitez garder le fichier léger pour le partage, le stockage ou l’utilisation en ligne — sans compromettre la fidélité visuelle du contenu.

Le code C++ suivant montre comment compresser les polices incorporées dans une présentation PowerPoint :
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Comment savoir si une police spécifique de la présentation sera tout de même substituée lors du rendu malgré l’incorporation ?**

Vérifiez les [informations de substitution](/slides/fr/cpp/font-substitution/) dans le gestionnaire de polices et les [règles de repli/substitution](/slides/fr/cpp/fallback-font/) : si la police est indisponible ou restreinte, un repli sera utilisé.

**Est‑il utile d’incorporer les polices « système » comme Arial/Calibri ?**

En général non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, serveur Linux sans polices préinstallées), l’incorporation des polices système peut éliminer le risque de substitutions inattendues.