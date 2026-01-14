---
title: Fallback-Schriften für Präsentationen in Python angeben
linktitle: Fallback-Schrift
type: docs
weight: 10
url: /de/python-net/create-fallback-font/
keywords:
- Fallback-Schrift
- Fallback-Regel
- Schrift anwenden
- Schrift ersetzen
- Unicode-Bereich
- fehlende Glyphe
- richtige Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Beherrschen Sie Aspose.Slides für Python über .NET, um Fallback-Schriften in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textdarstellung auf jedem Gerät oder Betriebssystem zu gewährleisten."
---

## **Fallback-Schriften angeben**

Aspose.Slides unterstützt die Klasse [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) um die Regeln zum Anwenden einer Fallback‑Schrift anzugeben. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriften dar, die die richtigen Glyphen enthalten können:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Verwenden Sie mehrere Wege, um die Schriftliste hinzuzufügen:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```


Es ist auch möglich, die Fallback‑Schrift zu [entfernen](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/remove/) oder [add_fall_back_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) in ein bestehendes [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)‑Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)‑Objekten zu organisieren, wenn es nötig ist, Fallback‑Schrift‑Ersetzungsregeln für mehrere Unicode‑Bereiche anzugeben.

{{% alert color="primary" title="Siehe auch" %}} 
- [Fallback‑Schriftensammlung erstellen](/slides/de/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schrift, Font‑Substitution und Font‑Embedding?**

Eine Fallback‑Schrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font‑Substitution](/slides/de/python-net/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font‑Embedding](/slides/de/python-net/embedded-font/) packt die Schriften in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt anzeigen können.

**Werden Fallback‑Schriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmanzeige?**

Ja. Fallback beeinflusst alle [Rendering‑ und Export‑Operationen](/slides/de/python-net/convert-presentation/), bei denen Zeichen gezeichnet werden müssen, aber in der Ausgangsschrift fehlen.

**Ändert die Konfiguration von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Fallback?**

Ja. Die Engine löst Schriften aus den verfügbaren Systemordnern und allen [zusätzlichen Pfaden](/slides/de/python-net/custom-font/) auf, die Sie angeben. Ist eine Schrift nicht physisch verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutionsmechanismus angewendet, um fehlende Zeichen darzustellen.