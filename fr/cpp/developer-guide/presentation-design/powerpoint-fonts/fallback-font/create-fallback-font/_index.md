---
title: Spécifier les polices de secours pour les présentations en C++
linktitle: Police de secours
type: docs
weight: 10
url: /fr/cpp/create-fallback-font/
keywords:
- police de secours
- règle de secours
- appliquer la police
- remplacer la police
- plage Unicode
- glyphe manquant
- glyphe correct
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez Aspose.Slides pour C++ afin de définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage texte cohérent sur tout appareil ou système d'exploitation."
---

## **Règles de secours**

Aspose.Slides prend en charge l’interface [IFontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/) et la classe [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) pour spécifier les règles d’application d’une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices susceptibles de contenir les glyphes appropriés :
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Utilisation de plusieurs méthodes pour ajouter une liste de polices:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


Il est également possible de [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/remove/) une police de secours ou d’[AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) peut être utilisé pour organiser une liste d’objets [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) lorsqu’il faut spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, la substitution de police et l’incorporation de police ?**

Une police de secours n’est utilisée que pour les caractères absents dans la police principale. La [substitution de police](/slides/fr/cpp/font-substitution/) remplace la police spécifiée dans son intégralité par une autre police. L’[incorporation de police](/slides/fr/cpp/embedded-font/) intègre les polices dans le fichier de sortie afin que les destinataires puissent voir le texte tel que prévu.

**Les polices de secours sont‑elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l’écran ?**

Oui. Le secours affecte toutes les [opérations de rendu et d’exportation](/slides/fr/cpp/convert-presentation/) où les caractères doivent être dessinés mais sont absents dans la police source.

**La configuration du secours modifie‑t‑elle le fichier de présentation lui‑même, et le paramètre persistera‑t‑il lors des ouvertures ultérieures ?**

Non. Les règles de secours sont des paramètres de rendu à l’exécution dans votre code ; elles ne sont pas stockées dans le .pptx et n’apparaîtront pas dans PowerPoint.

**Le système d’exploitation (Windows/Linux/macOS) et l’ensemble des répertoires de polices influencent‑ils la sélection du secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/cpp/custom-font/) que vous fournissez. Si une police n’est pas physiquement disponible, une règle la référençant ne peut pas prendre effet.

**Le secours fonctionne‑t‑il pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s’applique pour rendre les caractères manquants.