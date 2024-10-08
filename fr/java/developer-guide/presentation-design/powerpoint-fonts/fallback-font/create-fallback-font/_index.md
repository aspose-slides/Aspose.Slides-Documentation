---
title: Créer une police de secours
type: docs
weight: 10
url: /fr/java/create-fallback-font/
---

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices qui peuvent contenir des glyphes appropriés :

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//En utilisant plusieurs moyens, vous pouvez ajouter une liste de polices :
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Il est également possible de [supprimer](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) une police de secours ou [ajouter des polices de secours](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) peut être utilisé pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule), lorsqu'il est nécessaire de spécifier des règles de remplacement de polices de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/java/create-fallback-fonts-collection/)
{{% /alert %}}