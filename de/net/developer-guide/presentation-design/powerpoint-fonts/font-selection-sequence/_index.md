---
title: Schriftauswahlablauf in Aspose.Slides für .NET
linktitle: Schriftauswahl
type: docs
weight: 80
url: /de/net/font-selection-sequence/
keywords:
- Schriftauswahl
- Schriftsubstitution
- Schriftersetzung
- Substitutionsregel
- verfügbare Schrift
- fehlende Schrift
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für .NET Schriften auswählt und dabei eine klare, konsistente Darstellung von PPT-, PPTX- und ODP-Dateien gewährleistet – verbessern Sie jetzt Ihre Folien."
---
## **Übersicht**

Wenn eine Präsentation geladen, gerendert oder in ein anderes Format konvertiert wird, berücksichtigt Aspose.Slides die eingebetteten Schriften und die der Anwendung verfügbaren Schriften. Ist eine erforderliche Schrift nicht verfügbar, wählt Aspose.Slides eine Ersatzschrift, die so nahe wie möglich an der von PowerPoint verwendeten liegt.

Verfügbare Schriften können Systemschriften, von der Anwendung geladene Schriften und in der Präsentation eingebettete Schriften umfassen. Für eine passende eingebettete und registrierte Schrift steuert die unten beschriebene .NET‑26.11‑Einstellung, welche Vorrang hat. Schrift‑Substitutionsregeln, die über [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) definiert werden, sind ein separater Mechanismus.

Sie können auch Schriften zur Laufzeit der Anwendung hinzufügen, eingebettete Schriften aus einer Präsentation verwenden oder externe Schriften für Ausgabedokumente wie PDF‑Dateien laden.

## **Schriftauswahl**

Text kann auf eine Themen‑schrift verweisen, z. B. `+mn-lt`, anstatt einen expliziten Familiennamen zu verwenden. Siehe [Thema‑Schriftverweise auflösen](/slides/de/net/presentation-theme/#resolve-theme-font-references), um die vom jeweiligen Thema angegebene Familie zu erhalten. Das Auflösen dieser Referenz ist getrennt von der Prüfung der Schriftverfügbarkeit und der Anwendung von Rendering‑Substitutionen oder Glyph‑Fallbacks; sie identifiziert nicht die Schriftdatei, die letztlich zum Rendern des Textes verwendet wird.

Beim Rendern von Folien oder Konvertieren einer Präsentation prüfen Sie, ob die angeforderten Schriften eingebettet oder aus registrierten Quellen verfügbar sind. Fehlende Schriften können Ersatz oder Substitution erfordern; siehe [**Schrift ersetzen**](/slides/de/net/font-replacement/) und [**Schrift substituieren**](/slides/de/net/font-substitution/).

Bei der Untersuchung der Schriftauswahl:

1. Lösen Sie die angeforderte Familie und den Stil auf, einschließlich etwaiger Themenreferenz.
2. Prüfen Sie eingebettete Schriften und registrierte Quellen, einschließlich Systemschriften und von der Anwendung geladene Schriften. Verwenden Sie die untenstehende Einstellung, wenn konkurrierende eingebettete und registrierte Versionen übereinstimmen.
3. Überprüfen Sie [Schrift‑Substitutionsregeln](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) und Glyph‑Fallback, falls die angeforderte Schrift oder Zeichen nicht verfügbar sind.

Aspose.Slides ermöglicht es Ihnen, Schriften zur Laufzeit der Anwendung hinzuzufügen und diese dann zu verwenden. Siehe [**Benutzerdefinierte Schriften**](/slides/de/net/custom-font/).

Wenn zusätzliche Schriften in einer Präsentation platziert werden, werden sie [**Eingebettete Schriften**](/slides/de/net/embedded-font/) genannt.

Aspose.Slides ermöglicht es Ihnen, Schriften hinzuzufügen, die nur auf Ausgabedokumente angewendet werden. Wenn beispielsweise eine Präsentation, die Sie in PDF konvertieren möchten, Schriften enthält, die in Ihrem System und den eingebetteten Schriften fehlen, können Sie die benötigten Schriften als **externe Schriften** hinzufügen oder laden.

{{% alert title="Note" color="info" %}} 
Wir verteilen keine Schriften, weder kostenpflichtige noch kostenlose. Unsere API ermöglicht das Laden externer Schriften und deren Einbettung in Dokumente, doch Sie tun dies nach eigenem Ermessen und Verantwortung.
{{% /alert %}}

## **Registrierte Schriften gegenüber eingebetteten Schriften bevorzugen**

Ab .NET 26.11 ermöglicht [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/), dass eine passende registrierte Schrift beim Export einer eingebetteten Schrift Vorrang einräumt. Der Standardwert ist `false`. Das Matching verwendet den Schrift‑namen und den Stil; ein anderer Familienname ist kein Ersatz‑Match. Registrierte Schriften können vom System oder aus [explizit geladene Schriftquellen](/slides/de/net/custom-font/) stammen.

Das folgende Beispiel verwendet das **Aspose.Slides.NET6.CrossPlatform 26.11**‑Paket auf .NET 8. Befolgen Sie die [installationsanleitung](/slides/de/net/installation/) für Ihre Umgebung. Stellen Sie `embedded-fonts.pptx` mit einer eingebetteten Schrift und `preferred.ttf` mit demselben Familiennamen und Stil bereit. Die beiden Schriftdateien sollten sich sichtbar unterscheiden, wenn Sie die Ausgabe vergleichen möchten.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Diese Einstellung ändert die Schrift‑Priorität während des Exports; sie benennt die Schrift des Textes nicht um, entfernt keine eingebetteten Schrift‑daten und bettet die registrierte Datei nicht erneut ein. Es ist eine Laufzeiteinstellung: setzen Sie sie nach dem erneuten Öffnen einer Präsentation erneut. Wenn keine passende registrierte Schrift verfügbar ist, liefert das Aktivieren der Präferenz keine; überprüfen Sie die resultierende Schrift und das Layout in Ihrer Zielumgebung.

PNG‑ und PDF‑Ausgaben mit explizit geladenen regulären Schriften wurden für die obige Konfiguration geprüft. Überprüfen Sie Ihre eigenen Schriftdateien, Stile, SDK‑Build und Ausgabeformate, bevor Sie sich auf identische Ergebnisse verlassen. Schriftmetriken können Zeilenumbrüche und Positionierungen verändern. Verwenden Sie [Schrift ersetzen](/slides/de/net/font-replacement/) oder [Substitution](/slides/de/net/font-substitution/), wenn Sie eine andere Familie benötigen, und [eingebettete Schrift‑Operationen](/slides/de/net/embedded-font/), wenn Sie die in der Präsentation gespeicherten Schriften ändern müssen.

## **FAQ**

**Wie kann ich feststellen, welche Schriften in einer Präsentation vor der Konvertierung tatsächlich verwendet werden?**

Aspose.Slides ermöglicht es Ihnen, die verwendeten Schriften über den [Schrift‑Manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) zu inspizieren, sodass Sie entscheiden können, ob Sie [einbetten](/slides/de/net/embedded-font/), [ersetzen](/slides/de/net/font-replacement/) oder [externe Quellen](/slides/de/net/custom-font/) hinzufügen. Dies hilft, unerwünschte Substitutionen beim Rendern und Export zu vermeiden.

**Kann ich zusätzliche Schrift‑verzeichnisse hinzufügen, ohne sie im Betriebssystem zu installieren?**

Ja. Sie können [externe Schrift‑quellen](/slides/de/net/custom-font/) wie Ordner oder In‑Memory‑Streams für das Rendern und den Export registrieren. Dies entfernt die Abhängigkeit von System‑schriften des Hosts und sorgt für ein vorhersehbares Layout.

**Wie verhindere ich ein stilles Zurückfallen auf eine ungeeignete Schrift, wenn ein Glyph fehlt?**

Definieren Sie im Voraus explizite [Schrift ersetzen](/slides/de/net/font-replacement/) und Schrift‑[Fallback‑Regeln](/slides/de/net/fallback-font/). Durch die Analyse verwendeter Schriften und das Festlegen einer kontrollierten Priorität für Ersatzschriften stellen Sie eine konsistente Typografie sicher und vermeiden unerwartete Ergebnisse.