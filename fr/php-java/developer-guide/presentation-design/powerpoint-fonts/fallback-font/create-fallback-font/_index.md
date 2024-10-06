---
title: Créer une police de secours
type: docs
weight: 10
url: /php-java/create-fallback-font/
---

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) pour spécifier les règles à appliquer à une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices qui peuvent contenir des glyphes appropriés :

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # En utilisant plusieurs façons, vous pouvez ajouter une liste de polices :
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Il est également possible de [supprimer](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) une police de secours ou [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) peut être utilisé pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), lorsqu'il est nécessaire de spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/php-java/create-fallback-fonts-collection/)
{{% /alert %}}