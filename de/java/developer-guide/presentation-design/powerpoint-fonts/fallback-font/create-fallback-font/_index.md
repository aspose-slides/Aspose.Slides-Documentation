---  
title: Fallback-Schriften für Präsentationen in Java festlegen  
linktitle: Fallback-Schrift  
type: docs  
weight: 10  
url: /de/java/create-fallback-font/  
keywords:  
- Fallback-Schrift  
- Fallback-Regel  
- Schrift anwenden  
- Schrift ersetzen  
- Unicode-Bereich  
- fehlende Glyphe  
- korrekte Glyphe  
- PowerPoint  
- OpenDocument  
- Präsentation  
- Java  
- Aspose.Slides  
description: "Meistern Sie Aspose.Slides für Java, um Fallback-Schriften in PPT-, PPTX- und ODP-Dateien festzulegen und so eine konsistente Textanzeige auf jedem Gerät oder Betriebssystem zu gewährleisten."  
---

## **Fallback‑Regeln**

Aspose.Slides unterstützt die Schnittstelle [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule), um die Regeln für die Anwendung einer Fallback‑Schrift festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriften dar, die die richtigen Glyphen enthalten können:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Es ist ebenfalls möglich, eine Fallback‑Schrift zu [remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) oder über [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer bestehenden [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)‑Instanz hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)‑Objekten zu organisieren, wenn Fallback‑Ersetzungsregeln für mehrere Unicode‑Bereiche angegeben werden müssen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Erstellen einer Fallback‑Schrift‑Sammlung](/slides/de/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schrift, einer Schriftsubstitution und dem Einbetten von Schriften?**

Eine Fallback‑Schrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font substitution](/slides/de/java/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font embedding](/slides/de/java/embedded-font/) packt die Schriften in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt sehen können.

**Werden Fallback‑Schriften während Exporte wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?**

Ja. Fallback beeinflusst alle [rendering and export operations](/slides/de/java/convert-presentation/), bei denen Zeichen gezeichnet werden müssen, die in der Quellschrift nicht vorhanden sind.

**Ändert die Konfiguration von Fallback die Präsentationsdatei selbst und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Fallback‑Schriften?**

Ja. Die Engine löst Schriften aus den verfügbaren Systemordnern und allen von Ihnen angegebenen [additional paths](/slides/de/java/custom-font/) auf. Ist eine Schrift physisch nicht verfügbar, kann eine Regel, die sich darauf bezieht, nicht wirksam werden.

**Funktionieren Fallback‑Schriften für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus verwendet, um fehlende Zeichen darzustellen.