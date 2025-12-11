---
title: Spécifier les polices de secours pour les présentations en С++
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
- С++
- Aspose.Slides
description: "Maîtrisez Aspose.Slides pour С++ afin de définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage cohérent du texte sur tout appareil ou système d’exploitation."
---

## **Règles de secours**

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices pouvant contenir les glyphes appropriés :
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


Il est également possible de [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) la police de secours ou d'[AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) existant.

La classe [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) peut être utilisée pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule), lorsqu'il faut spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, la substitution de police et l'intégration de police ?**

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/cpp/font-substitution/) remplace la police spécifiée entière par une autre police. L'[intégration de police](/slides/fr/cpp/embedded-font/) embarque les polices dans le fichier de sortie afin que les destinataires puissent voir le texte tel qu'il est prévu.

**Les polices de secours sont‑elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l’écran ?**

Oui. La police de secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/cpp/convert-presentation/) où les caractères doivent être dessinés mais sont absents dans la police source.

**La configuration d’une police de secours modifie‑t‑elle le fichier de présentation lui‑même, et le réglage persistera‑t‑il lors de futures ouvertures ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas stockées dans le fichier .pptx et n’apparaîtront pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influencent‑ils la sélection de la police de secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/cpp/custom-font/) que vous fournissez. Si une police n’est pas physiquement disponible, une règle y faisant référence ne pourra pas être appliquée.

**La police de secours fonctionne‑t‑elle pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes est utilisé pour rendre les caractères manquants.